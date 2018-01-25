Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Xml.Serialization
Imports System.IO


Module Serialization

    Private Filtre As String = "Fichier GridCreator (*.GridCreator)|*.GridCreator"
    Private Chemin As String = ""

    '==============================================================
    '   OUVRIR / ENREGISTRER / ENRIGISTRER SOUS
    '==============================================================

    Public Function Ouvrir(ByRef Objet As Projet) As Boolean

        Dim MaFenetre As New OpenFileDialog
        MaFenetre.Filter = Filtre 'Ajout du filtres

        If MaFenetre.ShowDialog() = System.Windows.Forms.DialogResult.OK Then   'Ouvre la fenetre
            Charger(Objet, MaFenetre.FileName)                                  'Charger à partir d'un chemin
            Return True
        End If

        Return False

    End Function
    Public Function Charger(ByRef Objet As Projet, ByVal CheminArg As String)

        Chemin = CheminArg   'Recupère le chemin du fichier
        Dim FluxDeFichier As Stream = File.OpenRead(Chemin) 'On ouvre le fichier et récupère son flux
        Dim Deserialiseur As New BinaryFormatter()
        Objet = CType(Deserialiseur.Deserialize(FluxDeFichier), Projet)  'Désérialisation et conversion de ce qu'on récupère dans le type « Film »
        FluxDeFichier.Close() 'Fermeture du flux

    End Function
    Public Sub Enregistrer(ByVal Objet As Projet)

        If File.Exists(Chemin) Then
            Dim FluxDeFichier As FileStream = File.Create(Chemin)   'On crée le fichier et récupère son flux
            Dim Serialiseur As New BinaryFormatter

            Serialiseur.Serialize(FluxDeFichier, Objet)      'Sérialisation et écriture
            FluxDeFichier.Close()                                   'Fermeture du fichier
        Else
            Enregistrer_Sous(Objet)
        End If

    End Sub
    Public Sub Enregistrer_Sous(ByVal Objet As Projet)

        Dim MaFenetre As New SaveFileDialog
        MaFenetre.Filter = Filtre 'Ajout du filtres

        If MaFenetre.ShowDialog() = System.Windows.Forms.DialogResult.OK Then    'Ouvre la fenetre

            Chemin = MaFenetre.FileName
            Dim FluxDeFichier As FileStream = File.Create(Chemin)   'On crée le fichier et récupère son flux
            Dim Serialiseur As New BinaryFormatter

            Serialiseur.Serialize(FluxDeFichier, Objet)  'Sérialisation et écriture
            FluxDeFichier.Close()       'Fermeture du fichier

        End If
    End Sub

End Module
