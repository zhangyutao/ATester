Public Class Form_RealTimeResult
    Delegate Sub Refrech()

    Private Sub ListView_RTR_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ListView_RTR.KeyDown
        If e.Control And e.KeyCode = Keys.C Then
            If (ListView_RTR.SelectedItems.Count > 0) Then
                Dim content = ""
                For Each i In ListView_RTR.SelectedItems
                    content = content + i.Text + "," + i.SubItems(1).Text + "," + i.SubItems(2).Text + "," + i.SubItems(3).Text + vbCrLf
                Next
                Clipboard.SetDataObject(content)
            End If
        End If

        If e.Control And e.KeyCode = Keys.A Then
            For Each i In ListView_RTR.Items
                i.Selected = True
            Next
        End If
    End Sub

    Private Sub BT_Refresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Refresh.Click
        Invoke(New Refrech(AddressOf Form_Main.refrechTestStatus))
    End Sub
    Private Sub activeLink() Handles Me.FormClosing
        Form_Main.Link_RTR.Enabled = True
    End Sub
    Public min As String = ""
    Public max As String = "O"

    Public topbarWidthMin As Integer = 0
    Public buttonpanelWidthMin As Integer = 0
    Public contentWidthMin As Integer = 0
    Public contentHeightMin As Integer = 0



    Private Sub Form_RealTimeResult_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        min = Button_Max.Text
        topbarWidthMin = BT_TopBar.Width
        buttonpanelWidthMin = Panel_Button.Width
        contentWidthMin = Panel_Content.Width
        contentHeightMin = Panel_Content.Height
        Me.Location = Form_Main.PointToScreen(New Point(Form_Main.MenuStrip.Location.X, Form_Main.MenuStrip.Location.Y))
        BT_Close.Parent = BT_TopBar
        BT_Close.Location = New Point(BT_TopBar.Width - BT_Close.Width - 1, 0)
        Button_Max.Parent = BT_TopBar
        Button_Max.Location = New Point(BT_Close.Location.X - Button_Max.Width - 1, 0)
        Button_Max.Text = max
        Button_Min.Parent = BT_TopBar
        Button_Min.Location = New Point(Button_Max.Location.X - Button_Min.Width - 1, 0)
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
        If Button_Max.Text = max Then
            If L_TopBar_mousedownVar And (IsNothing(curMousePosOnL_TopBar) = False) Then
                Dim curMousePos = System.Windows.Forms.Cursor.Position
                Me.Location = New Point(curMousePos.X - curMousePosOnL_TopBar.X - BT_TopBar.Location.X, curMousePos.Y - curMousePosOnL_TopBar.Y - BT_TopBar.Location.Y)
            End If
        End If
    End Sub

    Private Sub BT_Close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Close.Click
        Me.Close()
    End Sub

    Private Sub Button_Max_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_Max.Click

        Select Case Button_Max.Text
            Case max
                Me.WindowState = FormWindowState.Maximized
                BT_TopBar.Width = Me.Width - 2
                Panel_Button.Width = Me.Width - 2
                Panel_Content.Width = Me.Width - 2
                Panel_Content.Height = Me.Height - 2 - Panel_Content.Location.Y
                Button_Max.Text = min
                BT_Close.Location = New Point(BT_TopBar.Width - BT_Close.Width - 1, 0)
                Button_Max.Location = New Point(BT_Close.Location.X - Button_Max.Width - 1, 0)
                Button_Min.Location = New Point(Button_Max.Location.X - Button_Min.Width - 1, 0)
            Case min
                BT_TopBar.Width = topbarWidthMin
                Panel_Button.Width = buttonpanelWidthMin
                Panel_Content.Width = contentWidthMin
                Button_Max.Text = max
                Panel_Content.Height = contentHeightMin
                Me.WindowState = FormWindowState.Normal
                BT_Close.Location = New Point(BT_TopBar.Width - BT_Close.Width - 1, 0)
                Button_Max.Location = New Point(BT_Close.Location.X - Button_Max.Width - 1, 0)
                Button_Min.Location = New Point(Button_Max.Location.X - Button_Min.Width - 1, 0)
        End Select
    End Sub

    Private Sub Button_Min_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_Min.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub
End Class