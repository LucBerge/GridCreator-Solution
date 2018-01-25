<Serializable>
Public Class Projet

    Public PointsOffset As New List(Of Point)
    Public PointsActuel As New Point(0, 0)
    Public Offset As New Point(0, 0)

    Public NB As Integer = 11
    Public Chaine As String = "Grille.Ajoute_Vertex(compteur, New Point(%X, %Y), Mondes.Normal)"

    '==============================================================
    '   NEW
    '==============================================================

    Sub New()
    End Sub

End Class
