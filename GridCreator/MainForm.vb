Public Class MainForm

    Public BMP As Bitmap
    Public Canvas As Graphics

    Public MonProjet As New Projet()

    '==============================================================
    '   NEW
    '==============================================================

    Sub New()
        InitializeComponent()
        MonProjet.PointsOffset.Add(New Point(0, 0))
        BMP = New Bitmap(PictureBox.Width, PictureBox.Height)
        Canvas = Graphics.FromImage(BMP)

        If My.Application.CommandLineArgs.Count = 1 Then
            Charger(MonProjet, My.Application.CommandLineArgs.Item(0))
        End If

        AfficherImage()

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
            For Each Point In MonProjet.PointsOffset
                File.WriteLine(Replace(Replace(TextBox.Text, "%X", Point.X + MonProjet.Offset.X), "%Y", Point.Y + MonProjet.Offset.Y))
            Next
            File.WriteLine("")
            File.Close()
        End If
    End Sub

    '==============================================================
    '   EVENEMENTS
    '==============================================================

    Private Sub OuvrirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OuvrirToolStripMenuItem.Click
        If Ouvrir(MonProjet) Then
            AfficherImage()
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

    Private Sub Validated(sender As Object, e As EventArgs) Handles XBox.Validated, YBox.Validated, TextBox.Validated, XBox.MouseLeave, YBox.MouseLeave, TextBox.MouseLeave

        XBox.Text = Val(XBox.Text)
        YBox.Text = Val(YBox.Text)
        MonProjet.Offset = New Point(XBox.Text, YBox.Text)

        MonProjet.Chaine = TextBox.Text

        XBox.ReadOnly = True
        YBox.ReadOnly = True
        TextBox.ReadOnly = True

        AfficherImage()

    End Sub
    Private Sub MainForm_KeyUp(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp, PictureBox.KeyUp, XBox.KeyUp, YBox.KeyUp, TextBox.KeyUp, AddButton.KeyUp, SubButton.KeyUp, ScriptButton.KeyUp

        If e.KeyCode = Keys.Right Or e.KeyCode = Keys.Left Or e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Delete Then

            If e.KeyCode = Keys.Right Then
                MonProjet.PointsActuel += New Point(1, 0)
            ElseIf e.KeyCode = Keys.Left Then
                MonProjet.PointsActuel += New Point(-1, 0)
            ElseIf e.KeyCode = Keys.Up Then
                MonProjet.PointsActuel += New Point(0, -1)
            ElseIf e.KeyCode = Keys.Down Then
                MonProjet.PointsActuel += New Point(0, 1)
            ElseIf e.KeyCode = Keys.Enter Then
                MonProjet.PointsOffset.Add(MonProjet.PointsActuel)
            ElseIf e.KeyCode = Keys.Delete Then
                If MonProjet.PointsActuel <> New Point(0, 0) Then
                    MonProjet.PointsOffset.Remove(MonProjet.PointsActuel)
                End If
            End If

            AfficherImage()

        End If

    End Sub
    Private Sub AddButton_Click(sender As Object, e As EventArgs) Handles AddButton.Click
        If (MonProjet.NB > 5) Then
            MonProjet.NB -= 2
            AfficherImage()
        End If
    End Sub
    Private Sub SubButton_Click(sender As Object, e As EventArgs) Handles SubButton.Click
        MonProjet.NB += 2
        AfficherImage()
    End Sub

    Private Sub MouseHover(sender As Object, e As EventArgs) Handles XBox.MouseHover
        XBox.ReadOnly = False
    End Sub
    Private Sub YBox_MouseHover(sender As Object, e As EventArgs) Handles YBox.MouseHover
        YBox.ReadOnly = False
    End Sub
    Private Sub TextBox_MouseHover(sender As Object, e As EventArgs) Handles XBox.MouseHover, YBox.MouseHover, TextBox.MouseHover
        XBox.ReadOnly = False
        YBox.ReadOnly = False
        TextBox.ReadOnly = False
    End Sub

    '==============================================================
    '   DESSIN
    '==============================================================

    Private Sub AfficherImage()

        Dim RatioLargeurHauteur As Single = 68 / 50

        Dim PlusDroite As Point = PlusDroitePoint()
        Dim PlusGauche As Point = PlusGauchePoint()
        Dim PlusHaut As Point = PlusHautPoint()
        Dim PlusBas As Point = PlusDroitePoint()

        Dim NbPointLargeur As Integer = Math.Abs(PlusGauche.X - PlusDroite.X) + 1
        Dim NbPointHauteur As Integer = Math.Abs(PlusHaut.Y - PlusBas.Y) + 1

        Dim Largeur As Integer = BMP.Width / MonProjet.NB
        Dim Hauteur As Integer = Largeur / RatioLargeurHauteur

        Canvas.FillRectangle(Brushes.Beige, 0, 0, BMP.Width, BMP.Height)

        For Each Point In MonProjet.PointsOffset
            Point = Point - MonProjet.PointsActuel
            Canvas.FillRectangle(Brushes.Black, CInt((BMP.Width - Largeur) / 2) + Point.X * Largeur, CInt((BMP.Height - Hauteur) / 2) + Point.Y * Hauteur, Largeur, Hauteur)
        Next

        Dim PointOrigine As Point = MonProjet.PointsOffset(0) - MonProjet.PointsActuel
        Canvas.FillRectangle(Brushes.Green, CInt((BMP.Width - Largeur) / 2) + PointOrigine.X * Largeur, CInt((BMP.Height - Hauteur) / 2) + PointOrigine.Y * Hauteur, Largeur, Hauteur)

        Canvas.FillRectangle(Brushes.Red, CInt((BMP.Width - Largeur) / 2), CInt((BMP.Height - Hauteur) / 2), Largeur, Hauteur)
        PositionLabel.Text = (MonProjet.PointsActuel.X + MonProjet.Offset.X) & ":" & (MonProjet.PointsActuel.Y + MonProjet.Offset.Y)
        TextBox.Text = MonProjet.Chaine

        PictureBox.Image = BMP

    End Sub

    Private Function PlusDroitePoint() As Point
        Dim Elus As Point = MonProjet.PointsActuel
        For Each Point In MonProjet.PointsOffset
            If Point.X > Elus.X Then
                Elus = Point
            End If
        Next
        Return Elus
    End Function
    Private Function PlusGauchePoint() As Point
        Dim Elus As Point = MonProjet.PointsActuel
        For Each Point In MonProjet.PointsOffset
            If Point.X < Elus.X Then
                Elus = Point
            End If
        Next
        Return Elus
    End Function
    Private Function PlusHautPoint() As Point
        Dim Elus As Point = MonProjet.PointsActuel
        For Each Point In MonProjet.PointsOffset
            If Point.Y < Elus.Y Then
                Elus = Point
            End If
        Next
        Return Elus
    End Function
    Private Function PlusBasPoint() As Point
        Dim Elus As Point = MonProjet.PointsActuel
        For Each Point In MonProjet.PointsOffset
            If Point.Y > Elus.Y Then
                Elus = Point
            End If
        Next
        Return Elus
    End Function

End Class
