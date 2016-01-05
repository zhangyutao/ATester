Imports System.Threading
Imports Microsoft.Office.Interop
Imports System.Text

Public Class Form_MissionPanel
    Dim checkNetwork As New Thread(AddressOf checkNetworkFolder)
    Dim checkRefresh As New Thread(AddressOf CheckBPTPathAndSetRelatedControls)
    Public arryShareFolders() As String = Nothing
    Public blnCheckNetworkFolderComplete As Boolean = False
    Public blnNetworkFolderGood As Boolean = False
    Public blnRefreshEnd As Boolean = False
    Public Class_FolderOperator1 As New FolderOperator
    Public Class_MainFormControlHandler1 As New MainFormControlHandler
    Public TopTextButton As Object = Nothing
    Public TopTextBox As Object = Nothing
    Public Folder_BPT_Path As String = ""
    Delegate Sub Delegate_AddContentToTB(ByRef tb As TextBox, ByVal msg As String, ByVal following As String)
    Delegate Sub Delegate_AddArrayToTBWihtNewLines(ByRef tb As TextBox, ByVal msg() As String)
    Delegate Sub Delegate_CleanTB(ByRef tb As TextBox)
    Dim Array_BPTNames() As String
    Public BPTFolder = "\BPT"
    Public TBGetingIndex As Integer = -1
    'Public strWhenGenerate = ""
    Public WithEvents tempTaskTB As New TextBox


    Private Sub Bt_CloseMoreRemoteSetting_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Close.Click
        If UBound(Form_Main.arryIPs_TBs_Relation) > -1 Then
            Form_Main.clearCustomMissionMonitor()
            For i = 0 To UBound(Form_Main.arryIPs_TBs_Relation)
                Dim arraySlavename = Nothing
                Dim Slavename As String = ""
                If Form_Main.ProjectType = "UFT Project" Then
                    arraySlavename = Split(Form_Main.arryIPs_TBs_Relation(i)(0).text, "\")

                    If UBound(arraySlavename) > 0 Then
                        Slavename = arraySlavename(2)
                    Else
                        Slavename = arraySlavename(0)
                    End If
                End If
                If Form_Main.ProjectType = "Maven Project" Then
                    arraySlavename = Split(Form_Main.arryIPs_TBs_Relation(i)(0).text, "%")
                    If UBound(arraySlavename) > 0 Then
                        Slavename = arraySlavename(1)
                    Else
                        Slavename = arraySlavename(0)
                    End If
                End If

                Dim arrayTestNr = Split(Form_Main.arryIPs_TBs_Relation(i)(2).text, ":")
                Dim testNr
                If UBound(arrayTestNr) > 0 Then
                    testNr = arrayTestNr(1)
                Else
                    testNr = "0"
                End If
                Dim newitem = Form_Main.ListView_CustomMission.Items.Add(Slavename)
                newitem.SubItems.Add(testNr)
                Dim arrayTotal = Split(L_AllTotal_IPs.Text, ":")
                Dim total
                If UBound(arrayTotal) > 0 Then
                    total = arrayTotal(1)
                Else
                    total = "0"
                End If
                Form_Main.L_totalOfCustom.Text = total
            Next

        End If
        BT_Close.Enabled = False
        Form_Main.CB_NormalRun.Enabled = True
        If Button_Max.Text = ButtonMaxText_Min Then
            Button_Max.PerformClick()
        End If


        Me.Visible = False
        Form_Main.Enabled = True
        Form_Main.BringToFront()

    End Sub

    Private Sub BT_GTFAT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_GTFAT.Click
        BT_Close.Enabled = False
        'strWhenGenerate = "You cannot close the panel when generate test list!"
        'Me.ToolTip_BTIPS.Show(strWhenGenerate, Bt_CloseMoreRemoteSetting, 3000)
        For i = 0 To UBound(Form_Main.arryIPs_TBs_Relation)
            Form_Main.arryIPs_TBs_Relation(i)(0).Enabled = False
            If Form_Main.arryIPs_TBs_Relation(i)(0).Tag = Form_Main.isTopButton Then
                Form_Main.arryIPs_TBs_Relation(i)(0).Enabled = True
                Form_Main.arryIPs_TBs_Relation(i)(1).readonly = True
                TopTextButton = Form_Main.arryIPs_TBs_Relation(i)(0)
                TopTextBox = Form_Main.arryIPs_TBs_Relation(i)(1)
                TBGetingIndex = i
            End If
        Next
        BT_GTFAT.Enabled = False
        generateTestList()
        Form_Main.arryIPs_TBs_Relation(TBGetingIndex)(1).readonly = False
        TBGetingIndex = -1
        BT_GTFAT.Enabled = True
        For i = 0 To UBound(Form_Main.arryIPs_TBs_Relation)
            Form_Main.arryIPs_TBs_Relation(i)(0).Enabled = True
        Next
        'strWhenGenerate = ""
        BT_Close.Enabled = True
    End Sub
    Public Sub generateTestList()
        TopTextBox.ReadOnly = True
        TopTextBox.BackColor = Color.White
        Dim arryInputExcutionPath() As String = {""}
        Dim arryTempInputExcutionPath() As String = {""}
        Dim SourceDir As String = ""
        If Form_Main.CB_HostMode.Checked Then
            SourceDir = Form_Main.TB_RR_Dir.Text
            If Mid(SourceDir, 1, 2) = "\\" Then 'must be the network path
            Else
                MsgBox("Shared Dir you provided was invalid.")
                GoTo EndLine
            End If
            If InStr(SourceDir, "@") > 0 Then
                MsgBox("Shared Dir you provided was invalid.")
                GoTo EndLine
            End If
            Dim tempArry() As String = {""}
            tempArry(0) = SourceDir
            arryShareFolders = tempArry
            Folder_BPT_Path = SourceDir + BPTFolder
        Else
            Dim IPs = Form_Main.TB_RR_Dir.Text
            If Mid(IPs, 1, 1) = "@" Then
                IPs = Mid(IPs, 2)
            End If
            If Trim(IPs) = "" Then
                MsgBox("Shared Dir you provided was invalid.")
                GoTo EndLine
            End If
            SourceDir = TopTextButton.Text
            Folder_BPT_Path = SourceDir + BPTFolder
            Dim tempArry() As String = {""}
            tempArry(0) = SourceDir
            arryShareFolders = tempArry
        End If

        TopTextBox.Text = ">Loading... Please do not close the window." + vbCrLf
        checkNetwork = Nothing
        checkNetwork = New Thread(AddressOf checkNetworkFolder)
        checkNetwork.Start()
        Do Until blnCheckNetworkFolderComplete
            Application.DoEvents()
        Loop
        If blnNetworkFolderGood Then
            'Class_MainFormControlHandler1.AddContentToTB(TopTextBox, "Obtain the BPTs' Name. The time depends on your network speed.")
            checkRefresh = Nothing
            checkRefresh = New Thread(AddressOf CheckBPTPathAndSetRelatedControls)
            checkRefresh.Start()
            Do Until blnRefreshEnd
                Application.DoEvents()
                waitTime(200)
            Loop
            blnRefreshEnd = False
            Folder_BPT_Path = ""
        Else
            GoTo EndLine
        End If

EndLine:
        blnCheckNetworkFolderComplete = False
        arryShareFolders = Nothing
        Folder_BPT_Path = ""
        TopTextBox.ReadOnly = False
    End Sub

    Sub checkNetworkFolder()

        Dim wrongPath() As String = {""}

        For Each path In arryShareFolders
            If Class_FolderOperator1.hasFolder(path) Then
            Else
                wrongPath(UBound(wrongPath)) = path
                ReDim Preserve wrongPath(UBound(wrongPath) + 1)
            End If
        Next

        If UBound(wrongPath) > 0 Then
            ReDim Preserve wrongPath(UBound(wrongPath) - 1)
        End If

        If wrongPath(0) <> "" Then
            'MsgBox("Some network folders are bad, please see the information in the 'Remote UFT Status' panel.")
            Invoke(New Delegate_AddContentToTB(AddressOf Class_MainFormControlHandler1.AddContentToTB), TopTextBox, "You provided a bad path of Shared Dir:", vbCrLf)
            Invoke(New Delegate_AddArrayToTBWihtNewLines(AddressOf Class_MainFormControlHandler1.AddArrayToTBWihtNewLines), TopTextBox, wrongPath)
            blnNetworkFolderGood = False
        Else
            blnNetworkFolderGood = True
            'Invoke(New Delegate_AddContentToTB(AddressOf AddMsgToTextBox), TB_MainLog, "All the network folders are good", vbCrLf)
        End If
        blnCheckNetworkFolderComplete = True

    End Sub

    Sub CheckBPTPathAndSetRelatedControls()

        If Class_FolderOperator1.hasFolder(Folder_BPT_Path) = True Then
            Array_BPTNames = Class_FolderOperator1.getAllFolderNames(Folder_BPT_Path) 'find all BPT names which are under BPT folder
            Invoke(New Delegate_CleanTB(AddressOf Class_MainFormControlHandler1.CleanTB), TopTextBox)
            Invoke(New Delegate_AddArrayToTBWihtNewLines(AddressOf Class_MainFormControlHandler1.AddArrayToTBWihtNewLines), TopTextBox, Array_BPTNames)
        Else
            Invoke(New Delegate_CleanTB(AddressOf Class_MainFormControlHandler1.CleanTB), TopTextBox)
            Invoke(New Delegate_AddContentToTB(AddressOf Class_MainFormControlHandler1.AddContentToTB), TopTextBox, "Shared Dir you provided was not existing: " + Folder_BPT_Path, vbCrLf)

        End If
        blnRefreshEnd = True

    End Sub

    'Private Sub Bt_CloseMoreRemoteSetting_EnabledChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Bt_CloseMoreRemoteSetting.EnabledChanged
    '    If Bt_CloseMoreRemoteSetting.Enabled Then
    '        Bt_CloseMoreRemoteSetting.BackColor = Color.Black
    '    Else
    '        Bt_CloseMoreRemoteSetting.BackColor = Color.LightGray
    '    End If
    'End Sub


    Private Sub TempTBKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tempTaskTB.KeyDown

        If e.KeyCode = Keys.A And e.Control Then
            tempTaskTB.SelectAll()
        End If
    End Sub

    Public TempTB_Position As Point = Nothing
    Private Sub tempTaskTB_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tempTaskTB.MouseMove
        Dim mpoint As Point = tempTaskTB.PointToClient(Form_Main.MousePosition)
        If TempTB_Position <> mpoint Then
            TempTB_Position = mpoint
            If UBound(tempTaskTB.Lines) > -1 Then
                Dim cpoint = tempTaskTB.GetPositionFromCharIndex(tempTaskTB.TextLength - 1)
                If mpoint.Y <= cpoint.Y + tempTaskTB.Font.Height Then
                    Dim cx = mpoint.X
                    Dim cy = mpoint.Y + 10
                    ToolTip_BTIPS.Show(tempTaskTB.Lines(tempTaskTB.GetLineFromCharIndex(tempTaskTB.GetCharIndexFromPosition(mpoint))), tempTaskTB, cx, cy, 2000)
                End If
            End If
        End If
    End Sub

    Private Sub Form_MoreRemoteSetting_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        checkNetwork.Abort()
        checkRefresh.Abort()
        checkNetwork = Nothing
        checkRefresh = Nothing
    End Sub

    Private Sub Form_MoreRemoteSetting_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.VisibleChanged
        If Me.Visible = True Then
            Me.Location = Form_Main.PointToScreen(New Point(Form_Main.ToolStrip.Location.X, Form_Main.ToolStrip.Location.Y))
        End If

    End Sub


    Public ButtonMaxText_Min As String = ""
    Public ButtonMaxText_Max As String = "O"

    Public topbarWidthMin As Integer = 0
    Public L_ListForIP_Orignal_Location As Point = Nothing
    Public contentWidthMin As Integer = 0
    Public contentHeightMin As Integer = 0
    Public TBWidthMin As Integer = 0
    Public TBHeightMin As Integer = 0
    Public me_MinSize As Size = Nothing

    Private Sub Form_MoreRemoteSetting_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ButtonMaxText_Min = Button_Max.Text
        topbarWidthMin = BT_TopBar.Width
        L_ListForIP_Orignal_Location = L_ListForIP.Location
        contentWidthMin = Panel_Content.Width
        contentHeightMin = Panel_Content.Height

        BT_Close.Parent = BT_TopBar
        Button_Max.Parent = BT_TopBar
        Me.Location = Form_Main.PointToScreen(New Point(Form_Main.ToolStrip.Location.X, Form_Main.ToolStrip.Location.Y))
        BT_Close.Location = New Point(BT_TopBar.Width - BT_Close.Width - 1, 0)
        Button_Max.Parent = BT_TopBar
        Button_Max.Location = New Point(BT_Close.Location.X - Button_Max.Width - 1, 0)
        Button_Max.Text = ButtonMaxText_Max
        me_MinSize = Me.Size
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
        If Button_Max.Text = ButtonMaxText_Max Then
            If L_TopBar_mousedownVar And (IsNothing(curMousePosOnL_TopBar) = False) Then
                Dim curMousePos = System.Windows.Forms.Cursor.Position
                Me.Location = New Point(curMousePos.X - curMousePosOnL_TopBar.X - BT_TopBar.Location.X, curMousePos.Y - curMousePosOnL_TopBar.Y - BT_TopBar.Location.Y)
            End If
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

    Private Sub Button_Max_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_Max.Click
        Select Case Button_Max.Text
            Case ButtonMaxText_Max

                Dim newSize = System.Windows.Forms.SystemInformation.PrimaryMonitorSize

                Button_Max.Text = ButtonMaxText_Min
                Panel_Main.Size = New Size(newSize.Width - 2, newSize.Height - Panel_Main.Location.Y - 2)
                BT_TopBar.Width = newSize.Width - 2
                BT_Close.Location = New Point(BT_TopBar.Width - BT_Close.Width - 1, 0)
                Button_Max.Location = New Point(BT_Close.Location.X - Button_Max.Width - 1, 0)
                Panel_Content.Size = New Size(Panel_Main.Width - 2, Panel_Main.Height - 1 - Panel_Content.Location.Y - 20)

                Dim allContentPanelControls As Control.ControlCollection = Me.Panel_Content.Controls
                For Each i In allContentPanelControls
                    If i.GetType.ToString() = "System.Windows.Forms.TextBox" Then
                        If TBWidthMin = 0 Then
                            TBWidthMin = i.Width
                        End If
                        If TBHeightMin = 0 Then
                            TBHeightMin = i.Height
                        End If
                        i.Width = Panel_Content.Width - i.Location.x - 30
                        If i.Height < Panel_Content.Height - i.Location.Y - 1 Then
                            i.Height = Panel_Content.Height - i.Location.Y - 1
                        End If

                        L_ListForIP.Width = i.Width


                    End If
                Next

                Dim allL_ListForIPControls As Control.ControlCollection = Me.L_ListForIP.Controls
                For Each t In allL_ListForIPControls
                    If t.GetType.ToString() = "System.Windows.Forms.Label" Then
                        If t.name.Contains("DynLT") Then
                            t.Location = New Point(L_ListForIP.Width - t.Width - 1, L_ListForIP.Height - t.Height - 1)
                        End If
                        If t.name.Contains("DynLR") Then
                            t.Location = New Point(1, L_ListForIP.Height - t.Height - 1)
                        End If
                    End If
                Next
                Me.WindowState = FormWindowState.Maximized
            Case ButtonMaxText_Min

                BT_TopBar.Width = topbarWidthMin
                Button_Max.Text = ButtonMaxText_Max
                Panel_Main.Size = New Size(me_MinSize.Width - 2, me_MinSize.Height - Panel_Main.Location.Y - 2)
                L_ListForIP.Location = L_ListForIP_Orignal_Location
                Panel_Content.Width = contentWidthMin
                Panel_Content.Height = contentHeightMin

                BT_Close.Location = New Point(BT_TopBar.Width - BT_Close.Width - 1, 0)
                Button_Max.Location = New Point(BT_Close.Location.X - Button_Max.Width - 1, 0)
                Dim allContentPanelControls As Control.ControlCollection = Me.Panel_Content.Controls
                For Each i In allContentPanelControls
                    If i.GetType.ToString() = "System.Windows.Forms.TextBox" Then
                        i.Width = TBWidthMin
                        i.Height = TBHeightMin
                        L_ListForIP.Width = i.Width
                    End If
                Next

                Dim allL_ListForIPControls As Control.ControlCollection = Me.L_ListForIP.Controls
                For Each t In allL_ListForIPControls
                    If t.GetType.ToString() = "System.Windows.Forms.Label" Then
                        If t.name.Contains("DynLT") Then
                            t.Location = New Point(L_ListForIP.Width - t.Width - 1, L_ListForIP.Height - t.Height - 1)
                        End If
                        If t.name.Contains("DynLR") Then
                            t.Location = New Point(1, L_ListForIP.Height - t.Height - 1)
                        End If
                    End If
                Next
                Me.WindowState = FormWindowState.Normal
        End Select
    End Sub
End Class