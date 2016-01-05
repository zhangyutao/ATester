Imports System.Management

Public Class Form_MustDoIt


    'Public RDPC As AxMSTSCLib.AxMsRdpClient7 = Nothing
    'Private Sub SetRdpClientProperties()

    '    RDPC = New AxMSTSCLib.AxMsRdpClient7
    '    AddHandler RDPC.OnDisconnected, AddressOf onDisct
    '    RDPC.Parent = Me
    '    RDPC.Dock = DockStyle.Fill
    '    RDPC.Server = "15.50.5.187"
    '    RDPC.UserName = "zhanyuta"
    '    RDPC.Domain = "asiapacific"
    '    RDPC.ConnectingText = "Connecting"
    '    RDPC.DisconnectedText = "Disconnected"
    '    RDPC.ConnectedStatusText = "Connected"
    '    RDPC.AdvancedSettings8.b()
    '    RDPC.AdvancedSettings8.ClearTextPassword = "ASDfgh!@#456"
    '    RDPC.DesktopHeight = 300
    '    RDPC.DesktopWidth = 300

    '    'Try
    '    '    'Connection credentials to the remote computer, not needed if the logged account has access  
    '    '    Dim oConn As ConnectionOptions = New ConnectionOptions
    '    '    oConn.Username = "asiapacific\zhanyuta"
    '    '    oConn.Password = "ASDfgh!@#456"
    '    '    Dim strNameSpace As String = "\\"
    '    '    Dim srvname = "15.50.5.187"
    '    '    If (srvname <> "") Then
    '    '        strNameSpace = (strNameSpace + srvname)
    '    '    Else
    '    '        strNameSpace = (strNameSpace + ".")
    '    '    End If
    '    '    strNameSpace = (strNameSpace + "\root\cimv2")
    '    '    Dim oMs As ManagementScope = New ManagementScope(strNameSpace, oConn)
    '    '    oMs.Connect()
    '    '    'get Fixed disk state  
    '    '    Dim oQuery As ObjectQuery = New ObjectQuery("select FreeSpace,Size,Name from Win32_LogicalDisk where DriveType=3")
    '    '    'Execute the query  
    '    '    Dim oSearcher As ManagementObjectSearcher = New ManagementObjectSearcher(oMs, oQuery)

    '    '    'Get the results  
    '    '    Dim oReturnCollection As ManagementObjectCollection = oSearcher.Get

    '    '    'loop through found drives and write out info  
    '    '    Dim D_Freespace As Double = 0
    '    '    Dim D_Totalspace As Double = 0
    '    '    Dim ListBox1 As ListBox
    '    '    ListBox1.Parent = Me
    '    '    For Each oReturn As ManagementObject In oReturnCollection

    '    '        ' Disk name  
    '    '        ListBox1.Items.Add(("Disk: " + oReturn("Name").ToString))

    '    '        ' Free Space in bytes  
    '    '        ListBox1.Items.Add("Free Space: " + oReturn("FreeSpace").ToString)

    '    '        'Total Space in bytes  
    '    '        ListBox1.Items.Add("Total Space: " + oReturn("Size").ToString)
    '    '    Next

    '    'Catch ex As Exception
    '    '    MessageBox.Show(ex.Message)
    '    'End Try

    'End Sub
    'Public Sub Connect()

    '    SetRdpClientProperties()
    '    RDPC.Connect()

    'End Sub
    'Public Sub ConnectViaConsole()

    '    RDPC.AdvancedSettings.ConnectToServerConsole = True
    '    SetRdpClientProperties()
    '    RDPC.Connect()

    'End Sub
    'Public Sub onDisct()
    '    'MsgBox("disconnected")
    'End Sub
    Public IsFormNotClosed As Boolean
    Public Form_Main_Enabled As Boolean
    Public Form_MoreRemoteSetting_Enabled As Boolean
    Public Form_RealTimeResult_Enabled As Boolean
    Private Sub Form_Notification_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        BT_TopBar.Width = Me.Width - 3 - BT_TopBar.Location.X
        BT_TopBar.BackColor = GetVbColor(My.Resources.TopbarBackColor_Enabled)
        BT_TopBar.ForeColor = GetVbColor(My.Resources.TopbarForeColor_Enabled)
        Me.Location = Form_Main.PointToScreen(New Point(Form_Main.ToolStrip.Location.X, Form_Main.ToolStrip.Location.Y))
        IsFormNotClosed = True
        Form_Main_Enabled = Form_Main.Enabled
        Form_MoreRemoteSetting_Enabled = Form_MissionPanel.Enabled
        Form_RealTimeResult_Enabled = Form_RealTimeResult.Enabled
        Form_Main.Enabled = False
        Form_MissionPanel.Enabled = False
        Form_RealTimeResult.Enabled = False

    End Sub


    Private Sub Form_Notification_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Form_Main.notificationActionCode <> 5 And Form_Main.notificationActionCode <> 4 Then
            Form_Main.strSharedFolderPathOfOtherServerReport = ""
            Form_Main.strSharedFolderNameOfOtherServerReport = ""
        End If

        Form_Main.Enabled = Form_Main_Enabled
        Form_MissionPanel.Enabled = Form_MoreRemoteSetting_Enabled
        Form_RealTimeResult.Enabled = Form_RealTimeResult_Enabled
        IsFormNotClosed = False
    End Sub

    Private Sub Bt_Donot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bt_Donot.Click
        Form_Main.notificationActionCode = 1
    End Sub

    Private Sub Bt_Configured_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bt_Configured.Click
        Form_Main.notificationActionCode = 2
    End Sub

    Private Sub Bt_StopRun_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bt_StopRun.Click
        Form_Main.notificationActionCode = 3
    End Sub

    Private Sub Bt_Previous_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bt_Previous.Click
        Form_Main.notificationActionCode = 4
    End Sub

    Private Sub Bt_confirmed_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bt_confirmed.Click
        Form_Main.notificationActionCode = 5
    End Sub

    Private Sub B_Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bt_Cancel.Click
        Form_Main.notificationActionCode = 6
    End Sub

    Private Sub TB_Notification_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TB_Notification.KeyDown
        If e.KeyCode = Keys.A And e.Control Then
            TB_Notification.SelectAll()
        End If
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
End Class