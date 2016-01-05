Public Class ListViewSorter
    Implements IComparer
    Public SortColumn As Integer
    Public order As SortOrder
    Private objCompare As CaseInsensitiveComparer

    Sub New(ByVal SortColumn As Integer, ByVal order As SortOrder)
        Me.SortColumn = SortColumn
        Me.order = order
        objCompare = New CaseInsensitiveComparer
    End Sub
    Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements System.Collections.IComparer.Compare
        Dim result As Integer
        Dim listItemA As ListViewItem = TryCast(x, ListViewItem)
        Dim listItemB As ListViewItem = TryCast(y, ListViewItem)
        On Error GoTo errorline
        result = objCompare.Compare(listItemA.SubItems.Item(SortColumn).Text, listItemB.SubItems.Item(SortColumn).Text)
        If order = SortOrder.Ascending Then
            Return result
        ElseIf order = SortOrder.Descending Then
            Return -result
        Else
            Return 0
        End If
errorline:
        On Error GoTo 0
        Return 0
    End Function
End Class
