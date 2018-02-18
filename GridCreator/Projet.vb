<Serializable>
Public Class Projet

    Public Offset As New Point(-104 * 5, -76 * 5)
    Public Blocs As New List(Of Point)
    Public BlocVert As New Point(0, 0)

    Public NB As Integer = 11
    Public Chaine As String = "Grille.Ajoute_Vertex(%C, New Point(%X, %Y), Mondes.Normal)"

    '==============================================================
    '   NEW
    '==============================================================

    Sub New()
        Blocs.Add(New Point(0, 0))
    End Sub

End Class
