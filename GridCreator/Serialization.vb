Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Xml.Serialization
Imports System.IO
Imports GridCreator

Public Enum ErreursSerialization
    Aucune = 0
    Abandon = 1
    Corrompu = 2
End Enum

Module Serialization

    '==============================================================
    '   CONSTANTES
    '==============================================================

    Const FormatFichier As String = "GridCreator"
    Const Filtre As String = "Fichier " & FormatFichier & " (*." & FormatFichier & ")|*." & FormatFichier

    '==============================================================
    '   VARIABLES
    '==============================================================

    Private Chemin As String = ""
    Private MonProjet As Projet

    '==============================================================
    '   OUVRIR CHARGER
    '==============================================================

    Public Function Ouvrir(ByRef Objet As Projet) As ErreursSerialization

        Dim MaFenetre As New OpenFileDialog
        MaFenetre.Filter = Filtre 'Ajout du filtres

        If MaFenetre.ShowDialog() = System.Windows.Forms.DialogResult.OK Then   'Ouvre la fenetre
            Return Charger(Objet, MaFenetre.FileName)                                  'Charger à partir d'un chemin
        Else
            Return ErreursSerialization.Abandon
        End If

    End Function
    Public Function Charger(ByRef Objet As Projet, ByVal CheminArg As String) As ErreursSerialization

        Chemin = CheminArg                                  'Recupère le chemin du fichier
        Dim Resultat As ErreursSerialization                'Variable de retour
        Dim FluxDeFichier As Stream = File.OpenRead(Chemin) 'On ouvre le fichier et récupère son flux
        Dim Deserialiseur As New BinaryFormatter()

        Try
            Objet = CType(Deserialiseur.Deserialize(FluxDeFichier), Projet)  'Désérialisation et conversion de ce qu'on récupère dans le type « Film »
            Resultat = ErreursSerialization.Aucune
        Catch ex As Exception
            Resultat = ErreursSerialization.Corrompu
        End Try

        FluxDeFichier.Close() 'Fermeture du flux
        Return Resultat

    End Function

    '==============================================================
    '   ENREGISTRER ENRIGISTRER_SOUS
    '==============================================================

    Public Function Enregistrer(ByVal Objet As Projet) As ErreursSerialization

        If File.Exists(Chemin) Then
            Dim FluxDeFichier As FileStream = File.Create(Chemin)   'On crée le fichier et récupère son flux
            Dim Serialiseur As New BinaryFormatter

            Serialiseur.Serialize(FluxDeFichier, Objet)      'Sérialisation et écriture
            FluxDeFichier.Close()                                   'Fermeture du fichier
            Return ErreursSerialization.Aucune
        Else
            Return Enregistrer_Sous(Objet)
        End If

    End Function
    Public Function Enregistrer_Sous(ByVal Objet As Projet) As ErreursSerialization

        Dim MaFenetre As New SaveFileDialog
        MaFenetre.Filter = Filtre 'Ajout du filtres

        If MaFenetre.ShowDialog() = System.Windows.Forms.DialogResult.OK Then    'Ouvre la fenetre

            Chemin = MaFenetre.FileName
            Dim FluxDeFichier As FileStream = File.Create(Chemin)   'On crée le fichier et récupère son flux
            Dim Serialiseur As New BinaryFormatter

            Serialiseur.Serialize(FluxDeFichier, Objet)  'Sérialisation et écriture
            FluxDeFichier.Close()       'Fermeture du fichier
            Return ErreursSerialization.Aucune
        Else
            Return ErreursSerialization.Abandon
        End If
    End Function

    '==============================================================
    '   GLISSER GLISSER_ENTRER
    '==============================================================

    Public Function Glisser(ByRef e As DragEventArgs) As ErreursSerialization
        Dim Fichier As String = e.Data.GetData(DataFormats.FileDrop)(0)
        Return Charger(MonProjet, Fichier)
    End Function
    Public Sub Glisser_Entrer(ByRef e As DragEventArgs)

        Dim Fichiers() As String = e.Data.GetData(DataFormats.FileDrop)
        If Fichiers.Count = 1 And Fichiers(0).Substring(Fichiers(0).Count - FormatFichier.Count).Equals(FormatFichier) Then
            e.Effect = DragDropEffects.Copy
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    '==============================================================
    '   AFFICHAGE_ERREURS
    '==============================================================

    Public Sub Afficher_Erreurs_Serialization(ByVal Erreur As ErreursSerialization)
        Select Case Erreur
            Case ErreursSerialization.Aucune
                MessageBox.Show("L'operation s'est déroulé sans aucun problème.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Case ErreursSerialization.Abandon
                MessageBox.Show("Vous avez abandonnez l'operation.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Case ErreursSerialization.Corrompu
                MessageBox.Show("Impossible d'ouvrir le fichier. Celui-ci est corrompu.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Select
    End Sub



End Module
