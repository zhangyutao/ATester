Imports System.Windows.Forms

Public Class Dialog
    Public CurForm_Enabled As Boolean
    Public Form_MoreRemoteSetting_Enabled As Boolean
    Public Form_RealTimeResult_Enabled As Boolean
    Public Form_MustDoIt_Enabled As Boolean
    'Public Form_Alarm_Enabled As Boolean

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_OK.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        'Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_No.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.No
        'Me.Close()
    End Sub


    Private Sub Button_Yes_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button_Yes.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Yes
        ' Me.Close()
    End Sub

    Private Sub BT_Close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Close.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.No
        'Me.Close()
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

    Private Sub Form_Main_EnabledChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.EnabledChanged
        If Me.Enabled Then
            BT_TopBar.BackColor = GetVbColor(My.Resources.TopbarBackColor_Enabled)
            BT_TopBar.ForeColor = GetVbColor(My.Resources.TopbarForeColor_Enabled)
        Else
            BT_TopBar.BackColor = GetVbColor(My.Resources.TopbarBackColor_Disabled)
            BT_TopBar.ForeColor = GetVbColor(My.Resources.TopbarForeColor_Disabled)

        End If

    End Sub
    Public stopflag = 0
    Private Sub TB_Content_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TB_Content.TextChanged
        If stopflag = 0 Then

            If TB_Content.Text.Length <= 60 Then
                stopflag = 1
                TB_Content.Text = vbCrLf + vbCrLf + vbCrLf + TB_Content.Text
                stopflag = 0
                TB_Content.TextAlign = HorizontalAlignment.Center
            Else
                If TB_Content.Text.Length <= 60 * 3 Then
                    stopflag = 1
                    TB_Content.Text = vbCrLf + TB_Content.Text
                    stopflag = 0
                End If
                TB_Content.TextAlign = HorizontalAlignment.Left
            End If
            TB_Content.FindForm.Focus()
        End If
    End Sub

    Private Sub Dialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        BT_Close.Parent = BT_TopBar
        BT_TopBar.Width = L_Back.Width - PictureBox_Panda.Width
        BT_Close.Location = New Point(BT_TopBar.Width - BT_Close.Width - 1, 0)
    End Sub

End Class
