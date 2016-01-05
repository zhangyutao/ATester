Public Class Form_Help

    Private Sub Form_Help_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If Me.Visible = False Then
            Me.Location = Form_Main.PointToScreen(New Point(Form_Main.MenuStrip.Location.X, Form_Main.MenuStrip.Location.Y))
        End If
    End Sub

    Private Sub Form_Help_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Location = Form_Main.PointToScreen(New Point(Form_Main.MenuStrip.Location.X - 45, Form_Main.MenuStrip.Location.Y))
        BT_Close.Parent = BT_TopBar
        BT_Close.Location = New Point(BT_TopBar.Width - BT_Close.Width - 1, 0)
    End Sub

    Public L_TopBar_mousedownVar As Boolean = False
    Public curMousePosOnL_TopBar As Point = Nothing
    Private Sub L_FormBack_MouseDown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_TopBar.MouseDown
        L_TopBar_mousedownVar = True
        curMousePosOnL_TopBar = BT_TopBar.PointToClient(Dialog.MousePosition)
    End Sub

    Private Sub L_TopBar_MouseUp(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_TopBar.MouseUp
        L_TopBar_mousedownVar = False
        curMousePosOnL_TopBar = Nothing
    End Sub
    Private Sub L_TopBar_move(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_TopBar.MouseMove
        If L_TopBar_mousedownVar And (IsNothing(curMousePosOnL_TopBar) = False) Then
            Dim curMousePos = System.Windows.Forms.Cursor.Position
            Me.Location = New Point(curMousePos.X - curMousePosOnL_TopBar.X - BT_TopBar.Location.X, curMousePos.Y - curMousePosOnL_TopBar.Y - BT_TopBar.Location.Y)
        End If
    End Sub

    Private Sub BT_Close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Close.Click
        Me.Close()
    End Sub
End Class