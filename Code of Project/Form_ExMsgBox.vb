Public Class Form_ExMsgBox
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
        Me.Hide()
    End Sub

    'Private Sub Form_ExMsgBox_EnabledChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.EnabledChanged
    '    If Me.Enabled Then
    '        BT_TopBar.BackColor = GetVbColor(My.Resources.TopbarBackColor_Enabled)
    '        BT_TopBar.ForeColor = GetVbColor(My.Resources.TopbarForeColor_Enabled)
    '    Else
    '        BT_TopBar.BackColor = GetVbColor(My.Resources.TopbarBackColor_Disabled)
    '        BT_TopBar.ForeColor = GetVbColor(My.Resources.TopbarForeColor_Disabled)

    '    End If
    'End Sub

    Private Sub Form_ExMsgBox_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        BT_Close.Parent = BT_TopBar
        BT_TopBar.Width = Me.Width - 2 - BT_TopBar.Location.X

    End Sub


End Class