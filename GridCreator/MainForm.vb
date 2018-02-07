Public Class MainForm

    '==============================================================
    '   CONSTANTES
    '==============================================================

    Const TempsClic As Single = 0.1
    Const RatioLargeurHauteur As Single = 68 / 50

    '==============================================================
    '   VARIABLES
    '==============================================================

    Public Canvas As Graphics
    Public MonProjet As New Projet()

    Private Largeur As Integer
    Private Hauteur As Integer

    Private EstEnfonce As Boolean = False
    Private DateDebut, DateFin As Date
    Private PositionDebut, AnciennePosition, PositionFin As Point

    '==============================================================
    '   NEW
    '==============================================================

    Sub New()
        InitializeComponent()
        Canvas = PictureBox.CreateGraphics()

        If My.Application.CommandLineArgs.Count = 1 Then
            Dim Erreur As ErreursSerialization = Charger(MonProjet, My.Application.CommandLineArgs.Item(0))
            If Erreur = ErreursSerialization.Corrompu Then
                Afficher_Erreurs_Serialization(Erreur)
            End If
        End If

        GenererImage()

    End Sub

    '==============================================================
    '   BOUTTON
    '==============================================================

    Private Sub ScriptButton_Click(sender As Object, e As EventArgs) Handles ScriptButton.Click

        Dim Chemin As String
        Dim Filtre As String = "Fichier texte (*.txt)|*.txt"
        Dim File As System.IO.StreamWriter

        Dim MaFenetre As New SaveFileDialog
        MaFenetre.Filter = Filtre 'Ajout du filtres

        If MaFenetre.ShowDialog() = System.Windows.Forms.DialogResult.OK Then    'Ouvre la fenetre
            Chemin = MaFenetre.FileName

            File = My.Computer.FileSystem.OpenTextFileWriter(Chemin, True)    'Ouvre le flux et créer le fichier si nécessaire

            File.WriteLine("Nombre de blocs = " & MonProjet.Blocs.Count) 'Ecrit le nombre de bloc
            File.WriteLine("")  'Saut de ligne

            For Each Point In MonProjet.Blocs    'Pour chaque point
                File.WriteLine(Replace(Replace(Replace(TextBox.Text, "%C", MonProjet.Blocs.IndexOf(Point)), "%X", Point.X + MonProjet.BlocVert.X), "%Y", Point.Y + MonProjet.BlocVert.Y))  'Ajoute la ligne correspondant au bloc
            Next

            File.WriteLine("")  'Saut de ligne
            File.Close()
        End If
    End Sub

    '==============================================================
    '   MENU
    '==============================================================

    Private Sub OuvrirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OuvrirToolStripMenuItem.Click
        Dim Erreur As ErreursSerialization = Ouvrir(MonProjet)
        If Erreur = ErreursSerialization.Aucune Then
            GenererImage()
        Else
            Afficher_Erreurs_Serialization(Erreur)
        End If
    End Sub
    Private Sub EnregistrerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EnregistrerToolStripMenuItem.Click
        Enregistrer(MonProjet)
    End Sub
    Private Sub EnregistrerSousToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EnregistrerSousToolStripMenuItem.Click
        Enregistrer_Sous(MonProjet)
    End Sub
    Private Sub AideToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AideToolStripMenuItem.Click
        MsgBox("L'outil GridCreator permet de créer des grilles et de générer le script correspondant." & vbCrLf & vbCrLf &
                "===== LES BLOCS =====" & vbCrLf & vbCrLf &
                "Bloc vert = Bloc initiale de la grille (non supprimable)" & vbCrLf &
                "Bloc rouge = Bloc courant" & vbCrLf &
                "Bloc noir = Bloc de la grille" & vbCrLf & vbCrLf &
                "===== LES TOUCHES =====" & vbCrLf & vbCrLf &
                "Entrer = Ajouter un bloc" & vbCrLf &
                "Suppr = Supprimer un bloc" & vbCrLf &
                "Flèches directionnelles = Déplacer le bloc rouge", MsgBoxStyle.Information)
    End Sub

    '==============================================================
    '   EVENEMENTS TEXTBOX
    '==============================================================

    Private Sub XBox_Validated(sender As Object, e As EventArgs) Handles XBox.Validated
        XBox.Text = XBox.Text
        MonProjet.BlocVert.X = Val(XBox.Text)
        GenererImage()
    End Sub
    Private Sub YBox_Validated(sender As Object, e As EventArgs) Handles YBox.Validated
        YBox.Text = Val(YBox.Text)
        MonProjet.BlocVert.Y = Val(YBox.Text)
        GenererImage()
    End Sub
    Private Sub TextBox_Validated(sender As Object, e As EventArgs) Handles TextBox.Validated
        MonProjet.Chaine = TextBox.Text
        GenererImage()
    End Sub

    '==============================================================
    '   EVENEMENTS TEXTBOX
    '==============================================================

    Private Sub PictureBox_MouseDown(sender As Object, e As MouseEventArgs) Handles PictureBox.MouseDown

        DateDebut = DateTime.Now
        PositionDebut = PictureBox.MousePosition
        AnciennePosition = PictureBox.MousePosition
        EstEnfonce = True

    End Sub
    Private Sub PictureBox_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBox.MouseMove

        Dim PointsActuel As Point = BlocVise()
        PositionLabel.Text = (PointsActuel.X + MonProjet.BlocVert.X) & ":" & (PointsActuel.Y + MonProjet.BlocVert.Y)

        If EstEnfonce = True And (DateTime.Now.Ticks - DateDebut.Ticks) / 10000000 > TempsClic Then                           'Si un clic est enfoncée
            MonProjet.Offset = MonProjet.Offset + (AnciennePosition - PictureBox.MousePosition)
            AnciennePosition = PictureBox.MousePosition
            GenererImage()
        End If

    End Sub
    Private Sub PictureBox_MouseUp(sender As Object, e As MouseEventArgs) Handles PictureBox.MouseUp

        Dim Bloc As Point
        EstEnfonce = False
        PositionFin = PictureBox.MousePosition

        'If PositionAppui.Equals(PositionRelache) Then                      'Si le clic a eu lieu au même endroit
        If (DateTime.Now.Ticks - DateDebut.Ticks) / 10000000 < TempsClic Then     'Si le clic a eu lieu au même endroit

            Bloc = BlocVise()

            If e.Button = MouseButtons.Left Then
                If MonProjet.Blocs.Contains(Bloc) = False Then
                    MonProjet.Blocs.Add(Bloc)
                End If
            ElseIf e.Button = MouseButtons.Right Then

                If Bloc <> New Point(0, 0) Then
                    MonProjet.Blocs.Remove(Bloc)
                End If
            End If

            GenererImage()
        End If

    End Sub
    Private Sub PictureBox_MouseWheel(sender As Object, e As MouseEventArgs) Handles MyBase.MouseWheel
        If e.Delta < 0 Then
            If MonProjet.NB < 100 Then
                MonProjet.NB += 2
                GenererImage()
            End If
        Else
            If (MonProjet.NB > 5) Then
                MonProjet.NB -= 2
                GenererImage()
            End If
        End If
    End Sub

    '==============================================================
    '   DRAG DROP
    '==============================================================

    Private Sub MainForm_DragDrop(sender As Object, e As DragEventArgs) Handles MyBase.DragDrop
        Dim Erreur As ErreursSerialization = Glisser(e)
        If Erreur = ErreursSerialization.Aucune Then
            GenererImage()
        Else
            Afficher_Erreurs_Serialization(Erreur)
        End If
    End Sub
    Private Sub MainForm_DragEnter(sender As Object, e As DragEventArgs) Handles MyBase.DragEnter
        Glisser_Entrer(e)
    End Sub

    '==============================================================
    '   AUTRE
    '==============================================================

    Private Sub GenererImage()

        Largeur = PictureBox.Width / MonProjet.NB
        Hauteur = Largeur / RatioLargeurHauteur

        Canvas.FillRectangle(Brushes.Beige, 0, 0, PictureBox.Width, PictureBox.Height)
        Canvas.FillRectangle(Brushes.Green, MonProjet.Blocs(0).X * Largeur - MonProjet.Offset.X, MonProjet.Blocs(0).Y * Hauteur - MonProjet.Offset.Y, Largeur, Hauteur)

        For Indice = 1 To MonProjet.Blocs.Count - 1
            Canvas.FillRectangle(Brushes.Black, MonProjet.Blocs(Indice).X * Largeur - MonProjet.Offset.X, MonProjet.Blocs(Indice).Y * Hauteur - MonProjet.Offset.Y, Largeur, Hauteur)
        Next

        TextBox.Text = MonProjet.Chaine

    End Sub
    Private Function BlocVise() As Point

        Dim SigneX, SigneY As Byte
        Dim BlocVisee As Point

        Dim PositionSouris As Point = PictureBox.PointToClient(Cursor.Position)
        Dim PositionImage As Point = PositionSouris + MonProjet.Offset

        If PositionImage.X > 0 Then
            SigneX = 0
        Else
            SigneX = 1
        End If
        If PositionImage.Y > 0 Then
            SigneY = 0
        Else
            SigneY = 1
        End If

        BlocVisee.X = PositionImage.X \ Largeur - SigneX
        BlocVisee.Y = PositionImage.Y \ Hauteur - SigneY

        Return BlocVisee

    End Function

End Class
