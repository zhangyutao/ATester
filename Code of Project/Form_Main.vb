
Imports System.Threading
Imports Microsoft.Office.Interop
Imports System.Text
Imports System.IO
Imports System.Management



Public Class Form_Main
    Public TempTestReportPath = ""
    Public isShutDownAuto = False
    Public L_Tip_RunResult_info = ""
    Public L_tip_Timeout_info = ""
    Public RadioButton_Listbox_BeforeClickRun As Boolean
    Public RadioButton_Textbox_BeforeClickRun As Boolean
    Public editContent_Remote As String = ""
    Public editBoxName_Remote As String = ""
    Public handleformMoreControlTh As Thread = Nothing
    Public ExectionTest As Thread = Nothing
    Public alarmTime As Date = Nothing
    Dim Alarm As New Form_Alarm
    Public userClickRun As Boolean = True
    Public AlarmRunEnd As Integer = 0
    Public firstActive As Boolean = True
    Public useSecurityConfig As Boolean = False
    Public localIP() As String
    Public isLocalIPForReport = 0 ' 1- local, 2- other
    Public OtherIP As String
    Public strSharedFolderPathOfOtherServerReport As String = ""
    Public strSharedFolderNameOfOtherServerReport As String = ""
    Public notificationActionCode = 0 '1-wonot, 2- have configured, 3-stoprun
    Public CloseRCDM As Boolean = False
    Public RDCMOpend As Boolean = False
    Public installRDCMOpend As Boolean = False
    Public CloseinstallRCDM As Boolean = False
    'Public RDCManMSIName As String = "RDCMan@ATester.msi"
    Public RDCManFolderName As String = "Remote Desktop Connection Manager"
    Public RDCManName = "RDCMan.exe"
    Public RDG_ChinaATVMGroup = "ChinaATVMGroup.rdg"
    Public globalButtonColor = GetVbColor(My.Resources.GlobalButtonBackColor) 'FromArgb(47, 170, 210)
    Public globalLabelColor = GetVbColor(My.Resources.NormalbarBackColor_Enabled)
    Public globalButtonBackColor_Disable = GetVbColor(My.Resources.GlobalButtonBackColor_Disable)
    Delegate Sub Delegate_PandainfoShow(ByRef pb As PictureBox, ByVal msg As String, ByVal msg1 As String)
    Delegate Sub Delegate_CleanTB(ByRef tb As TextBox)
    Delegate Sub Delegate_EnableTSMI(ByRef bt As ToolStripMenuItem)
    Delegate Sub Delegate_CleanCLB(ByRef clb As CheckedListBox)
    Delegate Sub Delegate_AddArrayToCLB(ByRef clb As CheckedListBox, ByVal msg() As String)
    Delegate Sub Delegate_AddArrayToNotifyIcon(ByRef tb As NotifyIcon, ByVal msg() As String)
    Delegate Sub Delegate_AddContentToTB(ByRef tb As TextBox, ByVal msg As String, ByVal following As String)
    Delegate Sub Delegate_AddArrayToTBWihtNewLines(ByRef tb As TextBox, ByVal msg() As String)
    'Delegate Sub Delegate_SetEnableToBt_Cancel(ByRef tb As Button, ByVal msg As Boolean)
    Delegate Sub Delegate_controlsStatusAfterExitClickBt_Run()
    Delegate Sub Delegate_Bt_CancelPerformClick()
    Delegate Sub Delegate_AddArrayToRichTB(ByRef rtb As RichTextBox, ByVal msg() As String)
    Delegate Sub Delegate_Normal()
    Delegate Sub Delegate_FormAction(ByRef formObj As Form)
    Delegate Sub Delegate_writeProgressBar(ByRef pb As Button, ByVal progress As Double)
    Delegate Sub Delegate_writeLable(ByRef LabelObj As Label, ByVal msg As String)
    Delegate Sub Delegate_writeNIText(ByRef NIObj As NotifyIcon, ByVal msg As String)
    Delegate Sub Delegate_writeyourF(ByRef FormObj As Form, ByVal msg As String)
    Delegate Sub Delegate_BT_IPs_MouseHover(ByRef button As Button, ByVal msg As String)
    Delegate Sub Delegate_ClickButton(ByRef button As Object)
    Delegate Sub Delegate_AssociateTip(ByRef rtb As ToolTip, ByRef o As Object, ByRef msg As String)
    Public alarmRunMonitorThread As New Thread(AddressOf alarmRunMonitor)
    Dim HostSharedDetailResultFolderPath As String = ""
    Dim mainFormThreadForRUNTime(-1) As Object
    Public IsRUNClicked As Boolean = False
    Public stopUFTClassStatusCheck As Boolean = False
    Dim expandlist As Boolean = False
    Dim newSplitterDistabce As Integer = 0
    Dim beforeSplitterDistabce As Integer = 0
    Dim beforeMeSizeWidth As Integer = 0
    Dim minwidth As Integer = 0
    Dim defualtOneTimeNumber As String = "1"
    Dim defaultTimeOut As String = "5"
    Dim Class_FileOperator1 As New FileOperator
    Dim Class_MainFormControlHandler1 As New MainFormControlHandler
    Dim Class_FolderOperator1 As New FolderOperator
    Public WithEvents Class_ExecutionOperator1 As New ExecutionOperator
    Dim RemoteMode As Boolean = False
    Dim ExcelMode As Boolean = False
    'Dim SkipPPValidMode As Boolean = False
    Dim Array_BPTNames() As String
    Dim DefaultValueTitle As String = "" '"[Default]"
    Public ExampleValueTitle As String = "" '"[Example]"
    Dim ProjectTitle As String = "VPC"
    Dim FolderName_BPT As String = "BPT"
    Dim FolderName_SRC_TEST As String = "src\test"
    Dim FolderName_Lib As String = "Libraries"
    Dim FolderName_me_config As String = "config"
    Dim FolderName_me_3rdpt As String = "3rdParTools"
    Dim FileName_LCLog As String = "LC.txt"
    Dim FileName_RSLog As String = "RS.txt"
    Dim FileName_IPLog As String = "IP.txt"
    Dim FileName_UFTConfig As String = "UFTConfig.txt"
    Dim FolderName_DefaultTestingResult As String = "ATester_Result"
    Dim FolderName_NewRoundResult As String = "Round_"
    Dim FolderNamePrefix_RunResult As String = "DetailRes"
    Dim FolderNamePrefix_Report As String = "Report"
    Dim FileNamePrefix_TXTReport As String = "QuickView_"
    Dim FileNamePrefix_ExcelReport As String = ProjectTitle + " AT Report_"
    'Dim FileName_ExcelReportTemplate As String = "ReportTemplate.xlsx"
    Dim FileName_ExcelReportTemplate As String = "ReportReference.xlsm"
    Dim remoteReportRootFolder As String = "C:\ATester_RemoteRun"
    'Dim shareReportMode As Boolean = False
    Dim StrMyDir As String = Class_FolderOperator1.getDirect()
    Dim Folder_DefaultTestingResult_Path As String = Class_FolderOperator1.switchFolderInSamePathLevel(StrMyDir, FolderName_DefaultTestingResult)
    Dim Folder_Root_Path As String = Class_FolderOperator1.getUpFolderNameInStr(StrMyDir)
    Dim Folder_TestCase_Path As String = Class_FolderOperator1.switchFolderInSamePathLevel(StrMyDir, FolderName_BPT)
    Dim Folder_me_config_Path As String = StrMyDir + "\" + FolderName_me_config
    Dim Folder_me_3rdpt_Path As String = StrMyDir + "\" + FolderName_me_3rdpt
    Dim Folder_RDCMan_Path As String = Folder_me_3rdpt_Path + "\" + RDCManFolderName
    Dim FilePath_LCLog As String = Folder_me_config_Path + "\" + FileName_LCLog
    Dim FilePath_RSLog As String = Folder_me_config_Path + "\" + FileName_RSLog
    Dim FilePath_IPLog As String = Folder_me_config_Path + "\" + FileName_IPLog

    Dim FilePath_UFTConfig As String = Folder_me_config_Path + "\" + FileName_UFTConfig
    'Dim Folder_me_config_Path As String = Class_FolderOperator1.switchFolderInSamePathLevel(StrMyDir, FolderName_me_config) 'only for developping use
    Public blnRefreshEnd As Boolean = False
    Public blnCheckBPTlistEnd As Boolean = False
    Public blnBPTlistIsRight As Boolean = False
    Public blnCheckNetworkFolderComplete As Boolean = False
    Public blnNetworkFolderGood As Boolean = False
    Public arryShareFolders() As String = Nothing
    Public projectTypes() As String = {"UFT Project", "Maven Project"}
    Public ProjectType As String
    'Public MyExcel As Object = Nothing
    Public AbortExecutionTesthread As Boolean = False ' this value will tell code when to abort Thread for QTP
    Public ExecutionTestThreadUsed As Boolean = False '
    Public blnFinishCancelThread_R As Boolean = False
    Public blnFinishCancelThread_N As Boolean = False
    Public bfBMX As Integer
    Public bfBMY As Integer
    Public bfBCX As Integer
    Public bfBCY As Integer
    Public bfVX As Integer
    Public bfVCY As Integer
    Public origalWidth As Integer
    Public diff As Integer
    Public arryIPs_TBs_Relation(-1) As Object 'use to fill customRemote info {Button for server,TB for server,total TC number of server,remain TC number of server,BPTs of server}
    Public RSChange As Boolean = False
    Public RSChangeTime As Integer = 0
    Public IPsChange As Boolean = False
    Public IPBTW As Integer
    Public IPsChangeTime As Integer = 0
    Public IPSListTitle As String = "Test Mission of "
    Public deadLineSecond As Integer = 0
    Public TB_RR_DirSelfchange As Boolean = False
    Public CB_HostModelSelfchange As Boolean = False
    Public CB_CRTSelfchange As Boolean = False
    Public Shared HostModel As Boolean = False
    Public RunTimeResult_TestResultPath As String = ""
    Public isTopButton As String = "y"
    Public runOverAsNormalStatus As Boolean = False
    Public shutDownThread As Thread = Nothing
    Public Shared LocalRunModel As Boolean = False
    Public Shared CustomRemoteTestModel As Boolean = False
    Public Panel_TestMissionPanel_Location
    Public Panel_TestMissionPanel_Size
    Public Panel_TestMissionList_Size
    Public Panel_CustomMissionPanel_Location
    Public Panel_CustomMissionPanel_Size
    Public ListView_CustomMission_Size
    Public L_TestMissionTitle_Size
    Public CB_CRT_Size



    Private Sub MainForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim tempFolder_Root_Path = Folder_Root_Path
        'Dim splashForm As New Form_Splash
        'splashForm.Show()
        Dim desktopSize As Size = System.Windows.Forms.SystemInformation.PrimaryMonitorSize
        Dim deskheight As Integer = desktopSize.Height
        Dim deskwidth As Integer = desktopSize.Width
        If deskwidth < Me.Size.Width Or deskheight < Me.Size.Height Then
            MsgBox("Your display's resolution must be larger than " + CStr(Me.Size.Width) + "x" + CStr(Me.Size.Height) + "! If not the ATester cannot be showed fully.")
        End If
        L_TestMissionTitle.Parent = Panel_TestMissionPanel
        Bt_MaxList.Parent = L_TestMissionTitle
        Bt_MaxList.Location = New Point(L_TestMissionTitle.Width - Bt_MaxList.Width - 3, 0)
        CB_CRT.Parent = Panel_TestMissionPanel
        BT_Min.Parent = BT_TopBar
        BT_Close.Parent = BT_TopBar
        Panel_CustomMissionPanel.Visible = False
        Panel_TestMissionPanel.Visible = True
        origalWidth = Me.Width
        diff = origalWidth - (ExpandButton.Location.X + ExpandButton.Width + 14)
        Me.Width = origalWidth - diff
        TB_FormBack.Width = Me.Width
        TB_FormBack.Height = Me.Height
        TB_FormBack.Location = New Point(0, 0)
        Panel_TestMissionPanel.Height = Me.Height - Panel_TestMissionPanel.Location.Y - 3
        Button_TopBar_Back.Parent = Me
        Button_TopBar_Back.Location = New Point(0, 0)
        Button_TopBar_Back.Width = TB_FormBack.Width
        Button_TopBar_Back.Height = Button_TopBar_Back.Location.Y + BT_TopBar.Height + MenuStrip.Height + 3
        Button_TopBar_Back.BringToFront()

        PictureBox_Panda.Parent = Button_TopBar_Back
        BT_TopBar.Parent = Button_TopBar_Back
        BT_TopBar.Width = Button_TopBar_Back.Width - PictureBox_Panda.Width - PictureBox_Panda.Location.X - 1
        BT_TopBar.Location = New Point(PictureBox_Panda.Location.X + PictureBox_Panda.Width + 1, 0)
        MenuStrip.Parent = Button_TopBar_Back
        MenuStrip.Location = New Point(0, BT_TopBar.Location.Y + BT_TopBar.Height)
        ToolStrip.Parent = Me
        ToolStrip.Width = Button_TopBar_Back.Width + 4
        ToolStrip.Location = New Point(-1, Button_TopBar_Back.Location.X + Button_TopBar_Back.Height)
        ToolStrip.BringToFront()
        L_Tool_Split.Parent = Me
        L_Tool_Split.Location = New Point(ToolStrip.Location.X, ToolStrip.Location.Y + ToolStrip.Height - 1)
        L_Tool_Split.Width = ToolStrip.Width
        L_Tool_Split.BringToFront()
        BT_Min.Parent = Button_TopBar_Back
        BT_Min.Location = New Point(Button_TopBar_Back.Width - BT_Close.Width - BT_Min.Width - 3, 0)
        BT_Min.BringToFront()
        BT_Close.Parent = Button_TopBar_Back
        BT_Close.Location = New Point(Button_TopBar_Back.Width - BT_Close.Width - 2, 0)
        BT_Close.BringToFront()
        expandlist = False
        Panel_LocalMode.Parent = Panel_RunMode
        Panel_RemoteMode.Parent = Panel_RunMode
        Panel_LocalMode.Location = New Point(BT_RunMode_Back.Location.X + 5, BT_RunMode_Back.Location.Y + BT_RunMode_Back.Height + 1)
        Panel_RemoteMode.Location = New Point(BT_RunMode_Back.Location.X + 5, BT_RunMode_Back.Location.Y + BT_RunMode_Back.Height + 1)
        Panel_LocalMode.BringToFront()
        Panel_RemoteMode.BringToFront()
        Label_timeout.Enabled = False
        Label_OT.Enabled = False
        L_TimeOut_Unit.Enabled = False
        L_tip_Timeout.Visible = False
        Label_RRDir.Enabled = False
        L_PerOneSlave.Enabled = False
        BT_bottom.Location = New Point(TB_FormBack.Location.X, TB_FormBack.Location.Y + TB_FormBack.Height - BT_bottom.Height)
        BT_bottom.Width = TB_FormBack.Width
        BT_bottom.BringToFront()
        ProgressBar_Run_top.Parent = Me
        ProgressBar_Run_top.BringToFront()
        CB_HostMode.Enabled = False
        Bt_Run.Enabled = True
        Bt_Stop.Enabled = False
        CB_Servers.Enabled = True
        TB_ReportFolder.Enabled = True
        TB_LC.Enabled = True
        BT_LC.Enabled = True
        TB_RR_Dir.Enabled = False
        TB_OneTimeNumber.Enabled = False
        TB_DeadLine.Enabled = False
        BT_EditResource.Enabled = False
        Bt_Refresh.Enabled = True
        Bt_select_All.Enabled = True
        Bt_Clean_All.Enabled = True

        Dim TB_LC_Point = Me.PointToClient(Me.Panel_LocalMode.PointToScreen(TB_LC.Location))
        Dim TB_RR_Dir_Point = Me.PointToClient(Me.Panel_RemoteMode.PointToScreen(TB_RR_Dir.Location))
        Dim TB_RR_IPs_Point = Me.PointToClient(Me.Panel_RemoteMode.PointToScreen(TB_RR_IPs.Location))
        L_tip_Timeout.Parent = Panel_RemoteMode


        writeProgressBar(BT_Progress, 0)
        TB_LC_Save.Parent = Me
        TB_RR_Dir_Save.Parent = Me
        TB_RR_IPs_Save.Parent = Me
        BT_Clean_LC_Save.Parent = Me
        BT_Clean_RR_Dirs_Save.Parent = Me
        BT_Clean_RR_IPs_Save.Parent = Me

        TB_LC_Save.Location = New Point(TB_LC_Point.X, TB_LC_Point.Y + TB_LC.Height)
        TB_RR_Dir_Save.Location = New Point(TB_RR_Dir_Point.X, TB_RR_Dir_Point.Y + TB_RR_Dir.Height)
        TB_RR_IPs_Save.Location = New Point(TB_RR_IPs_Point.X, TB_RR_IPs_Point.Y + TB_RR_IPs.Height)
        TB_LC_Save.Width = TB_LC.Width
        TB_RR_Dir_Save.Width = TB_RR_Dir.Width
        TB_RR_IPs_Save.Width = TB_RR_IPs.Width

        BT_Clean_LC_Save.Location = New Point(TB_LC_Point.X + TB_LC_Save.Width - BT_Clean_LC_Save.Width - 2, TB_LC_Point.Y + TB_LC_Save.Height + 2)
        BT_Clean_RR_Dirs_Save.Location = New Point(TB_RR_Dir_Point.X + TB_RR_Dir_Save.Width - BT_Clean_RR_Dirs_Save.Width - 2, TB_RR_Dir_Point.Y + TB_RR_Dir_Save.Height + 2)
        BT_Clean_RR_IPs_Save.Location = New Point(TB_RR_IPs_Point.X + TB_RR_IPs_Save.Width - BT_Clean_RR_IPs_Save.Width - 2, TB_RR_IPs_Point.Y + TB_RR_IPs_Save.Height + 2)
        BT_Clean_LC_Save.BringToFront()
        BT_Clean_RR_Dirs_Save.BringToFront()
        BT_Clean_RR_IPs_Save.BringToFront()

        L_tip_Timeout.Location = New Point(L_PerOneSlave.Location.X + L_PerOneSlave.Width - L_tip_Timeout.Width - 3, BT_EachSlave_back.Location.Y + 1)
        RadioButton_LocalMode.Checked = True
        Label_shutdown.Parent = Me
        L_TimeRemaining.Parent = Me
        L_Tip_RunResult.Parent = Panel_Reporting
        Bt_MaxList.BringToFront()

        For Each pt In projectTypes
            ComboBox_Project.Items.Add(pt)
        Next

        ComboBox_Project.SelectedItem = ComboBox_Project.Items.Item(0)
        ProjectType = ComboBox_Project.Text
        ExecutionOperator.projectType = ComboBox_Project.Text

        TB_tsofcase.Text = "60"
        ExecutionOperator.tsOfMavenTestCase = CLng(CInt(TB_tsofcase.Text) * 60 * 1000)

        TB_OneTimeNumber.Text = defualtOneTimeNumber
        TB_OneTimeNumber.MaxLength = 3
        TB_DeadLine.Text = defaultTimeOut
        TB_DeadLine.MaxLength = 3
        TB_LC.Text = tempFolder_Root_Path
        TB_LC.Select(0, 0)
        TB_ReportFolder.Text = DefaultValueTitle + Folder_DefaultTestingResult_Path
        TB_ReportFolder.Select(0, 0)
        TB_LC_Save.Text = Class_FileOperator1.ReadText(FilePath_LCLog)
        TB_RR_Dir_Save.Text = Class_FileOperator1.ReadText(FilePath_RSLog)
        TB_RR_IPs_Save.Text = Class_FileOperator1.ReadText(FilePath_IPLog)


        Dim HostName = System.Net.Dns.GetHostName
        Dim IPAdresses() = System.Net.Dns.GetHostAddresses(HostName)

        ReDim localIP(-1)
        For i = 0 To UBound(IPAdresses)
            Dim IPAdress = IPAdresses(i)
            If RegularExpressions.Regex.IsMatch(IPAdress.ToString, "\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}") Then
                CLB_ReportServerIP.Items.Add(IPAdress.ToString)
                ReDim Preserve localIP(UBound(localIP) + 1)
                localIP(UBound(localIP)) = IPAdress.ToString
            End If
        Next
        RadioButton_Textbox.Checked = True
        'waitTime(2500)
        'splashForm.Close()
        'waitTime(50)
        alarmRunMonitorThread.Start()
        Me.Location = New Point(desktopSize.Width / 2 - Me.Width / 2, desktopSize.Height / 2 - Me.Height / 2)
        hostmode_TB_RR_Dir_Width = TB_RR_Dir.Width
        hostmode_BT_EditResource_Location = BT_EditResource.Location

        Panel_TestMissionPanel_Location = Panel_TestMissionPanel.Location
        Panel_TestMissionPanel_Size = Panel_TestMissionPanel.Size
        Panel_TestMissionList_Size = Panel_TestMissionList.Size
        Panel_CustomMissionPanel_Location = Panel_CustomMissionPanel.Location
        Panel_CustomMissionPanel_Size = Panel_CustomMissionPanel.Size
        ListView_CustomMission_Size = ListView_CustomMission.Size
        L_TestMissionTitle_Size = L_TestMissionTitle.Size
        CB_CRT_Size = CB_CRT.Size


    End Sub
    Dim ComboBox_Project_Enabled As Boolean
    Dim TB_RR_IPSEnable_BeforeClickRun As Boolean
    Dim Bt_selectEnable_All_BeforeClickRun As Boolean
    Dim Bt_RefreshEnable_BeforeClickRun As Boolean
    Dim Bt_CleanEnable_All_BeforeClickRun As Boolean
    Dim CLBEnable_BeforeClickRun As Boolean
    Dim Bt_RunEnable_BeforeClickRun As Boolean
    Dim Bt_CancelEnable_BeforeClickRun As Boolean
    Dim L_stop_back_BeforeClickRun As Boolean
    Dim CB_ServersEnable_BeforeClickRun As Boolean
    Dim CB_NormalRun_BeforeClickRun As Boolean
    Dim CB_ServersChkedEnable_BeforeClickRun As Boolean
    Dim RadioButton_RemoteModeEnabled As Boolean
    Dim RadioButton_LocalModeEnabled As Boolean
    Dim TB_ReportFolderEnable_BeforeClickRun As Boolean
    Dim TB_ServersEnable_BeforeClickRun As Boolean
    Dim TB_OneTimeNumber_BeforeClickRun As Boolean
    Dim TB_DeadLine_BeforeClickRun As Boolean
    Dim TB_BPTList_BeforeClickRun As Boolean
    Dim BT_S_BeforeClickRun As Boolean
    Dim BT_CheckReport_BeforeClickRun As Boolean
    Dim BT_CheckServers_BeforeClickRun As Boolean
    Dim Bt_EditSlaveIPs_BeforeClickRun As Boolean
    Dim CB_Excel_BeforeClickRun As Boolean
    Dim BT_Close_BeforeClickRun As Boolean
    Dim CB_SValid_BeforeClickRun As Boolean
    Dim CB_hostserver_BeforeClickRun As Boolean
    Dim TB_LC_BeforeClickRun As Boolean
    Dim BT_LC_BeforeClickRun As Boolean
    Dim CB_ShareReportFolder_BeforeClickRun As Boolean
    Dim TB_ReportFolder_R_BeforeClickRun As Boolean
    Dim TB_IPATester_BeforeClickRun As Boolean
    Dim LB_AesterIP_BeforeClickRun As Boolean
    Dim L_IPATester_BeforeClickRun As Boolean
    Dim L_Total_BeforeClickRun As Boolean
    Dim L_Total_Value_BeforeClickRun As Boolean
    Dim L_Remain_BeforeClickRun As Boolean
    Dim L_Remain_Value_BeforeClickRun As Boolean
    Dim BT_IMBPT_BeforeClickRun As Boolean
    Dim BT_EXTBPT_BeforeClickRun As Boolean
    Dim CB_HostModelEnabled_BeforeClickRun As Boolean
    Dim BT_GTFAT_BeforeClickRun As Boolean
    Dim L_CRT_BeforeClickRun As Boolean
    Dim CB_CRT_BeforeClickRun As Boolean
    Dim AlarmToRunToolStripMenuItem_BeforeClickRun As Boolean

    Private Sub Bt_Run_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bt_Run.Click
        runOverAsNormalStatus = False
        If Alarm.hasSetupAlarm Then
            If Alarm.isThreadClickRun = 0 Then
                userClickRun = True
                Form_Alarm.Calloff_Button_Click(Nothing, Nothing)
                Alarm.isThreadClickRun = 0
                Alarm.AlarmRunEnd = 1
                Alarm.Enabled = False
            Else
                userClickRun = False
            End If
        Else
            userClickRun = True
        End If
        HostModel = CB_HostMode.Checked And CB_Servers.Checked
        CustomRemoteTestModel = CB_CRT.Checked And CB_Servers.Checked
        Class_ExecutionOperator1.UFTConfigStream = Class_FileOperator1.ReadText(FilePath_UFTConfig)


        '#########record what Local and remote run path used##############
        RecordLC()
        RecordServers()
        If HostModel Then
            RecordIPs()
        End If
        '#########record what Local and remote run path used END##############

        '##########record current controls status###################
        ComboBox_Project_Enabled = ComboBox_Project.Enabled
        TB_RR_IPSEnable_BeforeClickRun = TB_RR_IPs.Enabled
        Bt_selectEnable_All_BeforeClickRun = Bt_select_All.Enabled
        Bt_RefreshEnable_BeforeClickRun = Bt_Refresh.Enabled
        Bt_CleanEnable_All_BeforeClickRun = Bt_Clean_All.Enabled
        CLBEnable_BeforeClickRun = CLB_Testlist.Enabled
        Bt_RunEnable_BeforeClickRun = Bt_Run.Enabled
        Bt_CancelEnable_BeforeClickRun = Bt_Stop.Enabled

        CB_ServersEnable_BeforeClickRun = CB_Servers.Enabled
        CB_NormalRun_BeforeClickRun = CB_NormalRun.Enabled

        RadioButton_RemoteModeEnabled = RadioButton_RemoteMode.Enabled
        RadioButton_LocalModeEnabled = RadioButton_LocalMode.Enabled

        TB_ReportFolderEnable_BeforeClickRun = TB_ReportFolder.Enabled
        TB_ServersEnable_BeforeClickRun = TB_RR_Dir.Enabled
        TB_OneTimeNumber_BeforeClickRun = TB_OneTimeNumber.Enabled
        TB_DeadLine_BeforeClickRun = TB_DeadLine.Enabled
        TB_BPTList_BeforeClickRun = TB_BPTList.Enabled
        RadioButton_Listbox_BeforeClickRun = RadioButton_Listbox.Enabled
        RadioButton_Textbox_BeforeClickRun = RadioButton_Textbox.Enabled
        BT_CheckReport_BeforeClickRun = BT_CheckReport.Enabled
        BT_CheckServers_BeforeClickRun = BT_EditResource.Enabled
        Bt_EditSlaveIPs_BeforeClickRun = Bt_EditSlaveIPs.Enabled
        CB_Excel_BeforeClickRun = CB_Excel.Enabled
        BT_Close_BeforeClickRun = BT_Close.Enabled
        'CB_SValid_BeforeClickRun = CB_SValid.Enabled
        CB_hostserver_BeforeClickRun = CB_HostMode.Enabled
        TB_LC_BeforeClickRun = TB_LC.Enabled
        BT_LC_BeforeClickRun = BT_LC.Enabled
        'CB_ShareReportFolder_BeforeClickRun = CB_ShareReportFolder.Enabled
        TB_ReportFolder_R_BeforeClickRun = TB_ReportFolder_R.Enabled
        LB_AesterIP_BeforeClickRun = CLB_ReportServerIP.Enabled
        L_IPATester_BeforeClickRun = L_ReportServerIP.Enabled

        L_Total_BeforeClickRun = L_PassRate.Visible
        L_Total_Value_BeforeClickRun = L_Total_Value.Visible
        L_Remain_BeforeClickRun = L_Remain.Visible
        L_Remain_Value_BeforeClickRun = L_Remain_Value.Visible
        BT_IMBPT_BeforeClickRun = BT_IMBPT.Enabled
        BT_EXTBPT_BeforeClickRun = BT_EXTBPT.Enabled
        CB_HostModelEnabled_BeforeClickRun = CB_HostMode.Enabled
        BT_GTFAT_BeforeClickRun = Form_MissionPanel.BT_GTFAT.Enabled
        AlarmToRunToolStripMenuItem_BeforeClickRun = AlarmToRunToolStripMenuItem.Enabled
        CB_CRT_BeforeClickRun = CB_CRT.Enabled
        '##########record current controls status END###################

        If CB_NormalRun.Checked = True Or CB_Servers.Checked = True Then
            If CB_NormalRun.Checked = True And CB_Servers.Checked = True Then
                If userClickRun Then
                    MsgBox("Please just select an Running Mode!")
                    controlsStatusAfterRunEnd()
                    Exit Sub
                Else
                    Class_MainFormControlHandler1.AddContentToTB(TB_MainLog, "Please just select an Running Mode!")
                    controlsStatusAfterRunEnd()
                    Exit Sub
                End If

            Else

                If userClickRun Then
                    If CB_Excel.Checked = False Then
                        Dim msgvalue As Integer = MsgBox("You have not selected ""ADDL Report"". We recommend to use ""ADDL Report"" for more detailed result. Would you like to continue without ADDL Report?" + vbCrLf + "Yes: continue to run." + vbCrLf + "No: stop, and then you have chance to select that option.", MsgBoxStyle.YesNo)
                        If msgvalue = 6 Then

                        Else
                            Dim cur = Bt_Run.Enabled
                            Bt_Run.Enabled = Not cur
                            Bt_Run.Enabled = cur
                            controlsStatusAfterRunEnd()
                            Exit Sub
                        End If
                    End If
                End If
                'Dim needCheckServerFolder As Boolean = BT_CheckServers.Enabled ' if the button is availble for click means use didn't use it, so next step needs to check the input
                controlsStatusAfterRunBegin()
                Class_MainFormControlHandler1.AddContentToTB(TB_MainLog, "Preparing test related parameters.")
                RemoteMode = CB_Servers.Checked
                ExcelMode = CB_Excel.Checked
                'SkipPPValidMode = CB_SValid.Checked
                'shareReportMode = CB_ShareReportFolder.Checked
                '#############Check and then get the servers for remote######################
                If HostModel Then
                    If CLB_ReportServerIP.Items.Count = 0 Then
                        Class_MainFormControlHandler1.AddContentToTB(TB_MainLog, "You have not selected a IP to specify Report Server!")
                        Class_MainFormControlHandler1.AddContentToTB(TB_MainLog, "<Error>Quit test run due to the parameter error!")
                        controlsStatusAfterRunEnd()
                        Exit Sub
                    End If

                    If CLB_ReportServerIP.CheckedItems.Count = 0 Then
                        Class_MainFormControlHandler1.AddContentToTB(TB_MainLog, "You have not selected a IP to specify Report Server!")
                        Class_MainFormControlHandler1.AddContentToTB(TB_MainLog, "<Error>Quit test run due to the parameter error!")
                        controlsStatusAfterRunEnd()
                        Exit Sub
                    End If
                    Select Case isLocalIPForReport
                        Case 1
                        Case 2
                            If Trim(OtherIP) = "" Or Trim(strSharedFolderPathOfOtherServerReport) = "" Or Trim(strSharedFolderNameOfOtherServerReport) = "" Then
                                Dim statecode = intialTestResultFolderForOtherServer(CLB_ReportServerIP.SelectedItems.Item(0))
                                If statecode = 2 Then
                                    Class_MainFormControlHandler1.AddContentToTB(TB_MainLog, "<Stop>Quit test run due to user stop!")
                                    controlsStatusAfterRunEnd()
                                    Exit Sub
                                End If
                            End If
                        Case 0
                            Class_MainFormControlHandler1.AddContentToTB(TB_MainLog, "<Stop>Quit test run due to isLocalIPForReport=0 !")
                            controlsStatusAfterRunEnd()
                            Exit Sub
                    End Select
                End If
                Dim arryTempIPsPath() As String = {""}
                Dim arryInputIPsPath() As String = {""}
                Dim hostServer As String = ""
                Dim arryTempInputExcutionPath() As String = {""}
                Dim arryInputExcutionPath() As String = {""}
                If ProjectType = "UFT Project" Then
                    If RemoteMode Then
                        'If SkipPPValidMode Then
                        'Else
                        If blnNetworkFolderGood Then
                            GoTo GetServerList
                        Else
                            checkInputServers()
                            If blnNetworkFolderGood Then
                                GoTo GetServerList
                            Else
                                controlsStatusAfterRunEnd()
                                Class_MainFormControlHandler1.AddContentToTB(TB_MainLog, "<Error>Quit test run due to the parameter error!")
                                Exit Sub
                            End If
                        End If
                        ' End If
GetServerList:
                        If HostModel Then
                            hostServer = TB_RR_Dir.Text

                            Dim TBIPsText As String
                            If TB_RR_IPs.Text.Length > ExampleValueTitle.Length Then
                                If String.Equals(TB_RR_IPs.Text.Substring(0, ExampleValueTitle.Length), ExampleValueTitle) Then
                                    TBIPsText = TB_RR_IPs.Text.Substring(ExampleValueTitle.Length)
                                Else
                                    TBIPsText = TB_RR_IPs.Text
                                End If
                            Else
                                TBIPsText = TB_RR_IPs.Text
                            End If

                            arryTempIPsPath = Split(TBIPsText, "@")
                            Dim tempString As String
                            For i = 0 To UBound(arryTempIPsPath)
                                tempString = Trim(arryTempIPsPath(i))
                                If tempString <> "" Then
                                    If Mid(tempString, Len(tempString), 1) = "\" Then
                                        tempString = Mid(tempString, 1, Len(tempString) - 1)
                                    End If
                                    arryInputIPsPath(UBound(arryInputIPsPath)) = tempString
                                    ReDim Preserve arryInputIPsPath(UBound(arryInputIPsPath) + 1)
                                End If
                            Next
                            If UBound(arryInputIPsPath) > 0 Then
                                ReDim Preserve arryInputIPsPath(UBound(arryInputIPsPath) - 1)
                            End If
                        Else
                            Dim TBServersText As String
                            If TB_RR_Dir.Text.Length > ExampleValueTitle.Length Then
                                If String.Equals(TB_RR_Dir.Text.Substring(0, ExampleValueTitle.Length), ExampleValueTitle) Then
                                    TBServersText = TB_RR_Dir.Text.Substring(ExampleValueTitle.Length)
                                Else
                                    TBServersText = TB_RR_Dir.Text
                                End If
                            Else
                                TBServersText = TB_RR_Dir.Text
                            End If

                            arryTempInputExcutionPath = Split(TBServersText, "@")
                            Dim tempString As String
                            For i = 0 To UBound(arryTempInputExcutionPath)
                                tempString = Trim(arryTempInputExcutionPath(i))
                                If tempString <> "" Then
                                    If Mid(tempString, Len(tempString), 1) = "\" Then
                                        tempString = Mid(tempString, 1, Len(tempString) - 1)
                                    End If
                                    arryInputExcutionPath(UBound(arryInputExcutionPath)) = tempString
                                    ReDim Preserve arryInputExcutionPath(UBound(arryInputExcutionPath) + 1)
                                End If
                            Next
                            If UBound(arryInputExcutionPath) > 0 Then
                                ReDim Preserve arryInputExcutionPath(UBound(arryInputExcutionPath) - 1)
                            End If
                        End If

                    End If
                End If

                If ProjectType = "Maven Project" Then
                    Dim TBServersText As String
                    If TB_RR_Dir.Text.Length > ExampleValueTitle.Length Then
                        If String.Equals(TB_RR_Dir.Text.Substring(0, ExampleValueTitle.Length), ExampleValueTitle) Then
                            TBServersText = TB_RR_Dir.Text.Substring(ExampleValueTitle.Length)
                        Else
                            TBServersText = TB_RR_Dir.Text
                        End If
                    Else
                        TBServersText = TB_RR_Dir.Text
                    End If

                    arryTempInputExcutionPath = Split(TBServersText, "@")
                    Dim tempString As String
                    For i = 0 To UBound(arryTempInputExcutionPath)
                        tempString = Trim(arryTempInputExcutionPath(i))
                        If tempString <> "" Then
                            arryInputExcutionPath(UBound(arryInputExcutionPath)) = tempString
                            ReDim Preserve arryInputExcutionPath(UBound(arryInputExcutionPath) + 1)
                        End If
                    Next
                    If UBound(arryInputExcutionPath) > 0 Then
                        ReDim Preserve arryInputExcutionPath(UBound(arryInputExcutionPath) - 1)
                    End If
                End If
                If CustomRemoteTestModel Then
                    If RSChange Or IPsChange Then
                        Class_MainFormControlHandler1.AddContentToTB(TB_MainLog, "You need to re-edit ""Custom Mission"" when modifying content of ""Test Res Dirs"" or ""Slave IPs""")
                        Class_MainFormControlHandler1.AddContentToTB(TB_MainLog, "<Error>Quit test run due to the parameter error!")
                        controlsStatusAfterRunEnd()
                        Exit Sub
                    End If
                    If UBound(arryIPs_TBs_Relation) <= -1 Then
                        Class_MainFormControlHandler1.AddContentToTB(TB_MainLog, "You have not assgined test mission!")
                        Class_MainFormControlHandler1.AddContentToTB(TB_MainLog, "<Error>Quit test run due to the parameter error!")
                        controlsStatusAfterRunEnd()
                        Exit Sub
                    End If
                End If
                '#############Check and then get the servers for remote END######################
                '##############Get the BPT selected#########################

                Dim arrayBPTsSelected(0) As String
                Dim arrayBPTsSelectedAndStatus(-1) As Object
                If CustomRemoteTestModel Then
                    '###############prepare BPT name and status ###################
                    'the BPT status has four values,"ready","run","error","done"
                    'ready - the BPT is not run
                    'run - the BPT is run by some server
                    'error - the BPT has run and get error
                    'done - then BPT has run completed
                    Dim unIndex = 0
                    For i = 0 To UBound(arryIPs_TBs_Relation)
                        Dim arrayBPTsSelectedTemp() As String = Split(arryIPs_TBs_Relation(i)(1).Text, vbCrLf)
                        For v = 0 To UBound(arrayBPTsSelectedTemp)
                            Dim testNameTemp As String = Trim(Replace(arrayBPTsSelectedTemp(v), Chr(9), ""))
                            If testNameTemp <> "" Then
                                ReDim Preserve arrayBPTsSelectedAndStatus(unIndex)
                                If HostModel Then
                                    arrayBPTsSelectedAndStatus(unIndex) = {testNameTemp, "ready", Trim(arryIPs_TBs_Relation(i)(0).Text), ""}
                                    unIndex = unIndex + 1
                                Else
                                    If ProjectType = "UFT Project" Then
                                        arrayBPTsSelectedAndStatus(unIndex) = {testNameTemp, "ready", Trim(Split(arryIPs_TBs_Relation(i)(0).Text, "\")(2)), ""}
                                        unIndex = unIndex + 1
                                    End If

                                    If ProjectType = "Maven Project" Then
                                        arrayBPTsSelectedAndStatus(unIndex) = {testNameTemp, "ready", Trim(Split(arryIPs_TBs_Relation(i)(0).Text, "%")(1)), ""}
                                        unIndex = unIndex + 1
                                    End If

                                End If

                            End If
                        Next
                    Next

                    For k = 0 To UBound(arrayBPTsSelectedAndStatus)
                        ReDim Preserve arrayBPTsSelected(k)
                        arrayBPTsSelected(k) = arrayBPTsSelectedAndStatus(k)(0)
                    Next
                    L_Total_Value.Text = UBound(arrayBPTsSelectedAndStatus) + 1
                    L_Remain_Value.Text = UBound(arrayBPTsSelectedAndStatus) + 1
                    '###############prepare BPT name and status###################
                Else
                    If RadioButton_Listbox.Checked Then
                        If CLB_Testlist.CheckedItems.Count = 0 Then ' check if report are select to run, if not will exit the "Bt_Run.Click" event
                            Class_MainFormControlHandler1.AddContentToTB(TB_MainLog, "You have not assgined test mission!")
                            Class_MainFormControlHandler1.AddContentToTB(TB_MainLog, "<Error>Quit test run due to the parameter error!")
                            controlsStatusAfterRunEnd()
                            Exit Sub
                        End If

                        For i = 0 To CLB_Testlist.Items.Count - 1
                            Dim testNameTemp As String = Trim(Replace(CLB_Testlist.Items(i), Chr(9), ""))
                            If CLB_Testlist.GetItemChecked(i) And testNameTemp <> "" Then
                                arrayBPTsSelected(UBound(arrayBPTsSelected)) = testNameTemp
                                ReDim Preserve arrayBPTsSelected(UBound(arrayBPTsSelected) + 1)
                            End If
                        Next
                        If UBound(arrayBPTsSelected) > 0 Then
                            ReDim Preserve arrayBPTsSelected(UBound(arrayBPTsSelected) - 1)
                        End If
                    End If

                    If RadioButton_Textbox.Checked Then
                        If TB_BPTList.Text = "" Then ' check if report are select to run, if not will exit the "Bt_Run.Click" event
                            Class_MainFormControlHandler1.AddContentToTB(TB_MainLog, "You have not assgined test mission!")
                            Class_MainFormControlHandler1.AddContentToTB(TB_MainLog, "<Error>Quit test run due to the parameter error!")
                            controlsStatusAfterRunEnd()
                            Exit Sub
                        End If

                        Dim arrayBPTsSelectedTemp() As String = Split(TB_BPTList.Text, vbCrLf)
                        For i = 0 To UBound(arrayBPTsSelectedTemp)
                            Dim testNameTemp As String = Trim(Replace(arrayBPTsSelectedTemp(i), Chr(9), ""))
                            If testNameTemp <> "" Then
                                arrayBPTsSelected(UBound(arrayBPTsSelected)) = testNameTemp
                                ReDim Preserve arrayBPTsSelected(UBound(arrayBPTsSelected) + 1)
                            End If
                        Next
                        If UBound(arrayBPTsSelected) > 0 Then
                            ReDim Preserve arrayBPTsSelected(UBound(arrayBPTsSelected) - 1)
                        End If

                        If RemoteMode And Not HostModel Then
                        Else
                            Dim checkBPTs As New Thread(AddressOf CheckBPTList)
                            checkBPTs.Start(arrayBPTsSelected)
                            'Class_MainFormControlHandler1.AddContentToTB(TB_MainLog, "Refreshing To Be Run List")
                            Do Until blnCheckBPTlistEnd
                                Application.DoEvents()
                                waitTime(200)
                            Loop
                            If blnBPTlistIsRight Then
                                blnCheckBPTlistEnd = False
                                blnBPTlistIsRight = False
                            Else
                                blnCheckBPTlistEnd = False
                                Class_MainFormControlHandler1.AddContentToTB(TB_MainLog, "There was some issue in test mission you assigned.")
                                Class_MainFormControlHandler1.AddContentToTB(TB_MainLog, "<Error>Quit test run due to the parameter error!")
                                controlsStatusAfterRunEnd()
                                Exit Sub
                            End If
                        End If
                    End If

                    '###############prepare BPT name and status ###################
                    ReDim arrayBPTsSelectedAndStatus(UBound(arrayBPTsSelected))
                    'the BPT status has four values,"ready","run","error","done"
                    'ready - the BPT is not run
                    'run - the BPT is run by some server
                    'error - the BPT has run and get error
                    'done - then BPT has run completed
                    If RemoteMode Then
                        For a = 0 To UBound(arrayBPTsSelected)
                            arrayBPTsSelectedAndStatus(a) = {arrayBPTsSelected(a), "ready", "Not Assigned", ""}
                        Next
                    Else
                        For a = 0 To UBound(arrayBPTsSelected)
                            arrayBPTsSelectedAndStatus(a) = {arrayBPTsSelected(a), "ready", "Local", ""}
                        Next
                    End If


                    L_Total_Value.Text = UBound(arrayBPTsSelectedAndStatus) + 1
                    L_Remain_Value.Text = UBound(arrayBPTsSelectedAndStatus) + 1
                    '###############prepare BPT name and status###################
                End If

                Class_MainFormControlHandler1.AddContentToTB(TB_MainLog, "Test related parameters were ready.")
                '##############Get the BPT selected END#########################



                '#############Check and then Create folder for storing run report and detail result######################
                Class_MainFormControlHandler1.AddContentToTB(TB_MainLog, "Preparing test related folders and files.")
                Dim Folder_TestingResult As String
                If RemoteMode Then
                    Folder_TestingResult = remoteReportRootFolder
                    TB_ReportFolder.Enabled = True
                    TB_ReportFolder.Text = remoteReportRootFolder
                    TB_ReportFolder.Enabled = False
                Else
                    If TB_ReportFolder.Text.Length > DefaultValueTitle.Length Then
                        If String.Equals(TB_ReportFolder.Text.Substring(0, DefaultValueTitle.Length), DefaultValueTitle) Then
                            Folder_TestingResult = TB_ReportFolder.Text.Substring(DefaultValueTitle.Length)
                        Else
                            Folder_TestingResult = TB_ReportFolder.Text
                        End If
                    Else
                        Folder_TestingResult = TB_ReportFolder.Text
                    End If
                End If

                If Folder_TestingResult <> "" Then
                    If Mid(Folder_TestingResult, Len(Folder_TestingResult), 1) = "\" Then ' resove the end "\" of folder input by user, this can be used for folder, so have to cut it for code.
                        Folder_TestingResult = Mid(Folder_TestingResult, 1, Len(Folder_TestingResult) - 1)
                    End If
                    If Class_FolderOperator1.hasFolder(Folder_TestingResult) Then
                    Else
                        If Class_FolderOperator1.hasFolder(Class_FolderOperator1.getUpFolderNameInStr(Folder_TestingResult)) Then
                            If userClickRun Then
                                Dim msgboxvalue As Integer = MsgBox("The folder for saving report does not exist, " + vbCrLf + "ATester will create it for you. Do you agree?" + vbCrLf + "Path: " + Folder_TestingResult, MsgBoxStyle.YesNo)
                                If msgboxvalue = 6 Then
                                    Class_FolderOperator1.createFolder(Folder_TestingResult)

                                Else
                                    TB_ReportFolder.Text = DefaultValueTitle + Folder_DefaultTestingResult_Path
                                    Class_MainFormControlHandler1.AddContentToTB(TB_MainLog, "<Error>Quit test run due to user cancel!")
                                    controlsStatusAfterRunEnd()
                                    Exit Sub
                                End If
                            Else
                                Class_FolderOperator1.createFolder(Folder_TestingResult)
                            End If
                        Else
                            Class_MainFormControlHandler1.AddContentToTB(TB_MainLog, "The folder path <" + Folder_TestingResult + "> you typed for saving report was invalid")
                            Class_MainFormControlHandler1.AddContentToTB(TB_MainLog, "<Error>Quit test run due to the parameter error!")
                            controlsStatusAfterRunEnd()
                            TB_ReportFolder.Focus()
                            TB_ReportFolder.SelectAll()
                            Exit Sub
                        End If
                    End If
                Else
                    Class_MainFormControlHandler1.AddContentToTB(TB_MainLog, "Please input a valid folder path for saving run report and detail results")
                    Class_MainFormControlHandler1.AddContentToTB(TB_MainLog, "<Error>Quit test run due to the parameter error!")
                    controlsStatusAfterRunEnd()
                    TB_ReportFolder.Focus()
                    TB_ReportFolder.SelectAll()
                    Exit Sub
                End If

                '#############Check and then Create folder for storing run report and detail result END######################




                '###############prepare run BPT related masters###################

                Dim strYear As Integer
                Dim strMonth As Integer
                Dim strDay As Integer
                Dim strNow As Date = Now
                strYear = DatePart("yyyy", strNow)
                strMonth = DatePart("m", strNow)
                strDay = DatePart("d", strNow)
                Dim strDate As String = CStr(strYear) + "-" + CStr(strMonth) + "-" + CStr(strDay)
                Dim strEportTimeForFolder As String = strDate + "_" + CStr(Hour(strNow)) + "-" + CStr(Minute(strNow)) + "-" + CStr(Second(strNow))
                Dim strEportTime As String = strDate + " " + CStr(Hour(strNow)) + ":" + CStr(Minute(strNow)) + ":" + CStr(Second(strNow))
                Dim strNewRoundResultFolderName As String = FolderName_NewRoundResult + strEportTimeForFolder
                Dim strRunResultsFolderName As String = FolderNamePrefix_RunResult
                Dim strReportFolderName As String = FolderNamePrefix_Report
                Dim TxtReportName As String = FileNamePrefix_TXTReport + strEportTimeForFolder + ".txt"
                Dim ExeclReportName As String = FileNamePrefix_ExcelReport + strEportTimeForFolder + ".xlsm"
                Dim BPTPath As String = Folder_TestCase_Path
                Dim NewRoundResultPath As String = Folder_TestingResult + "\" + strNewRoundResultFolderName
                Class_FolderOperator1.createFolder(NewRoundResultPath)

                Dim TestReportPath As String = NewRoundResultPath + "\" + strReportFolderName ' for this tool to record run result and put report
                Dim TestResultPath As String = ""

                TestResultPath = NewRoundResultPath + "\" + strRunResultsFolderName ' for UFT to put run time result

                'TestResultPath = "\report"



                Dim TxtReportPath As String = TestReportPath + "\" + TxtReportName
                L_RoundID.Text = strEportTimeForFolder
                If RemoteMode Then
                    Class_FolderOperator1.createFolder(TestReportPath)
                    Class_FolderOperator1.SetDirAttribute(TestReportPath, FileAttributes.Normal)
                    '######give full control for Test Report Path ########
                    Dim username = "Everyone"
                    On Error Resume Next
                    Class_FolderOperator1.addpathPower(TestReportPath, username, "FullControl")
                    'If Err.Number <> 0 Then
                    '    Class_MainFormControlHandler1.AddContentToTB(TB_MainLog, "Give full control of folder " + TestReportPath + " to everyone failed. UFT detail result will be put in machine which execute test,path is " + TestResultPath + vbCrLf + ">" + CStr(Now))
                    '    On Error GoTo 0
                    '    GoTo outShare
                    'End If
                    On Error GoTo 0


                    Dim result = Class_FolderOperator1.shareFolder(TestReportPath, strReportFolderName + strEportTimeForFolder, 0, username)


                    '######give full control for Test Report Path END########
                    If HostModel Then
                        If isLocalIPForReport = 1 Then
                            HostSharedDetailResultFolderPath = "\\" + Trim(CLB_ReportServerIP.CheckedItems.Item(0)) + "\" + strRunResultsFolderName + strEportTimeForFolder
                            Dim username2 = "Everyone"
                            Class_FolderOperator1.createFolder(TestResultPath)
                            Class_FolderOperator1.SetDirAttribute(TestResultPath, FileAttributes.Normal)
                            On Error Resume Next
                            Class_FolderOperator1.addpathPower(TestResultPath, username2, "FullControl")
                            If Err.Number <> 0 Then
                                'MsgBox("The path " + TestResultPath + " cannot be get full control access. You cannot use ""Host Model""!")
                                'controlsStatusAfterExitClickBt_Run()
                                'Exit Sub
                                HostSharedDetailResultFolderPath = TestResultPath ' put result in server local
                                Class_MainFormControlHandler1.AddContentToTB(TB_MainLog, "Give full control of folder " + TestResultPath + " to everyone failed. UFT detail result will be put in machine which execute test,path is " + TestResultPath + vbCrLf + ">" + CStr(Now))
                                On Error GoTo 0
                                GoTo outShare
                            End If
                            On Error GoTo 0


                            Dim result2 = Class_FolderOperator1.shareFolder(TestResultPath, strRunResultsFolderName + strEportTimeForFolder, 0, username2)

                            If result2 <> "" Then
                                'MsgBox("The path " + TestResultPath + " cannot be shared to other server. You cannot use ""Host Model""!")
                                'controlsStatusAfterExitClickBt_Run()
                                'Exit Sub
                                HostSharedDetailResultFolderPath = TestResultPath ' put result in server local
                                Class_MainFormControlHandler1.AddContentToTB(TB_MainLog, "Error: " + result2 + vbCrLf + "Failed to give shared full control of folder " + TestResultPath + " to everyone failed. UFT detail result will be put in machine which execute test, path is " + TestResultPath + vbCrLf + ">" + CStr(Now))
                                On Error GoTo 0
                            Else

                            End If
                        Else
                            HostSharedDetailResultFolderPath = "\\" + Trim(CLB_ReportServerIP.CheckedItems.Item(0)) + "\" + strSharedFolderNameOfOtherServerReport
                        End If
                    End If
outShare:

                Else
                    Class_FolderOperator1.createFolder(TestReportPath)
                    Class_FolderOperator1.SetDirAttribute(TestReportPath, FileAttributes.Normal)

                    Class_FolderOperator1.createFolder(TestResultPath)
                    Class_FolderOperator1.SetDirAttribute(TestResultPath, FileAttributes.Normal)

                    'If shareReportMode Then
                    '    Class_UFTOperator1.shareReportFolder = True
                    '    Class_FolderOperator1.shareFolder(TestReportPath, strReportFolderName + strEportTimeForFolder)
                    '    Class_FolderOperator1.shareFolder(TestResultPath, strRunResultsFolderName + strEportTimeForFolder)
                    'End If
                End If

                Dim ExeclReportPath As String = ""
                If ExcelMode Then
                    ExeclReportPath = TestReportPath + "\" + ExeclReportName
                    Class_FileOperator1.CopyFile(Folder_me_config_Path + "\" + FileName_ExcelReportTemplate, ExeclReportPath)
                    Class_FileOperator1.SetFileAttribute(ExeclReportPath, FileAttributes.Normal)
                    Class_FileOperator1.CreateText(TxtReportPath)
                    Class_FileOperator1.SetFileAttribute(TxtReportPath, FileAttributes.Normal)
                Else
                    Class_FileOperator1.CreateText(TxtReportPath)
                    Class_FileOperator1.SetFileAttribute(TxtReportPath, FileAttributes.Normal)
                End If

                On Error Resume Next
                Cmd("ICacls """ + TestReportPath + """ /T /C /grant:r everyone:F")
                On Error GoTo 0
                On Error Resume Next
                Cmd("ICacls """ + TestResultPath + """ /T /C /grant:r everyone:F")
                On Error GoTo 0

                Class_MainFormControlHandler1.AddContentToTB(TB_MainLog, "Test related folders and files were ready.")
                '###############prepare run BPT related masters END###################


                Dim Class_ExcelOperator As New ExcelOperator
                Class_ExcelOperator.prepareExcel(ExeclReportPath, strEportTime, arrayBPTsSelected)

                Class_MainFormControlHandler1.AddContentToTB(TB_MainLog, "--------------------------- BEGIN --------------------------------------------" + vbCrLf + ">" + CStr(Now))

                Me.ProgressBar_Run_top.Visible = True
                If RemoteMode Then
                    'Me.WindowState = FormWindowState.Minimized
                    '###################Run In Remote################

                    '###############prepare fully server information for remote testing###################
                    Dim arryInitiateServerFullyInfo(0)
                    ''two dimension arry. It contains "{execute path, server path,server status,UFT assgined to the server, BPT assigned to the server}" of each server
                    If HostModel Then
                        ReDim arryInitiateServerFullyInfo(UBound(arryInputIPsPath))
                        For b = 0 To UBound(arryInputIPsPath)
                            Dim InitiateUFT As Object = Nothing
                            Dim InitiateBPTsSelected As Object = Nothing
                            arryInitiateServerFullyInfo(b) = {hostServer + "\" + FolderName_BPT, Trim(arryInputIPsPath(b)), "disct", InitiateUFT, InitiateBPTsSelected, False}
                            'Class_FolderOperator1.createFolder(TestResultPath + "\" + Trim(arryInputIPsPath(b)))
                        Next
                    Else

                        ReDim arryInitiateServerFullyInfo(UBound(arryInputExcutionPath))
                        If ProjectType = "UFT Project" Then
                            For b = 0 To UBound(arryInputExcutionPath)
                                Dim InitiateUFT As Object = Nothing
                                Dim InitiateBPTsSelected As Object = Nothing
                                arryInitiateServerFullyInfo(b) = {arryInputExcutionPath(b) + "\" + FolderName_BPT, Trim(Split(arryInputExcutionPath(b), "\")(2)), "disct", InitiateUFT, InitiateBPTsSelected, False}

                            Next
                        End If
                        If ProjectType = "Maven Project" Then
                            For b = 0 To UBound(arryInputExcutionPath)
                                Dim InitiateBPTsSelected As Object = Nothing
                                arryInitiateServerFullyInfo(b) = {Trim(Split(arryInputExcutionPath(b), "%")(2)), Trim(Split(arryInputExcutionPath(b), "%")(1)), "disct", Nothing, InitiateBPTsSelected, False}

                            Next
                        End If
                    End If

                    '###############prepare fully server information for remote testing END###################
                    If HostModel Then
                        Class_ExecutionOperator1.strTestResultPath = HostSharedDetailResultFolderPath
                        Select Case isLocalIPForReport
                            Case 0
                                Class_MainFormControlHandler1.AddContentToTB(TB_MainLog, "<Stop>Quit test run due to isLocalIPForReport=0 !")
                                controlsStatusAfterRunEnd()
                                Exit Sub
                            Case 1
                                Class_ExecutionOperator1.strTestResultPath_Backup = TestResultPath
                                RunTimeResult_TestResultPath = TestResultPath
                                Class_ExecutionOperator1.ReportTestResultPath = HostSharedDetailResultFolderPath
                                Class_ExecutionOperator1.isLocalIPHost = True
                            Case 2
                                Class_ExecutionOperator1.strTestResultPath_Backup = strSharedFolderPathOfOtherServerReport
                                RunTimeResult_TestResultPath = "[on " + Trim(CLB_ReportServerIP.CheckedItems.Item(0)) + "]" + strSharedFolderPathOfOtherServerReport
                                Class_ExecutionOperator1.ReportTestResultPath = HostSharedDetailResultFolderPath
                                TestResultPath = RunTimeResult_TestResultPath
                                Class_ExecutionOperator1.isLocalIPHost = False
                        End Select

                        Class_ExecutionOperator1.HostModel = True
                    Else
                        Class_ExecutionOperator1.strTestResultPath = TestResultPath  'each server has self result path
                        'TestResultPath = "\report"
                        RunTimeResult_TestResultPath = TestResultPath
                        Class_ExecutionOperator1.HostModel = False
                    End If

                    TempTestReportPath = TestReportPath
                    Class_ExecutionOperator1.strTestReportPath = TestReportPath
                    Class_ExecutionOperator1.strExeclReportPath = ExeclReportPath
                    ExecutionOperator.arryRunList = arrayBPTsSelectedAndStatus
                    ExecutionOperator.arryServerFullyInfo = arryInitiateServerFullyInfo
                    Class_ExecutionOperator1.strTxtReportPath = TxtReportPath
                    Class_ExecutionOperator1.runStartTime = CDate(strEportTime)
                    Class_ExecutionOperator1.OneTimeNumber = CInt(TB_OneTimeNumber.Text) - 1
                    deadLineSecond = CInt(TB_DeadLine.Text) * 60
                    Dim ExectionTest_R As New Thread(AddressOf Class_ExecutionOperator1.ExectionRandom_Remote)
                    Dim ExectionTest_CR As New Thread(AddressOf Class_ExecutionOperator1.ExectionCustom_Remote)
                    Link_RTR.Visible = True
                    'Class_MainFormControlHandler1.AddContentToTB(TB_MainLog, "-------------------------- BEGIN RUN ----------------------" + vbCrLf + CStr(Now))

                    'controlsStatusWhenRun()
                    Dim monitorServerStatusAndWriteStatus As New Thread(AddressOf ShowSlavesStatusAndWriteStatus)
                    Dim monitorRunsStatus As New Thread(AddressOf monitorRunNumberStatus)

                    Dim getexitValue As Integer = Class_ExecutionOperator1.exitValue ' this value was to know how kind way "Class_UFTOperator1.ExectionUFTBPT_Remote" exits
                    If AbortExecutionTesthread Then ' here will check if user click cancel or close button
                        getexitValue = 3
                        GoTo EndLine_R
                    End If
                    L_PassRate.Visible = True
                    L_Total_Value.Visible = True
                    L_Remain.Visible = True
                    L_Remain_Value.Visible = True
                    ExecutionTestThreadUsed = True
                    If CustomRemoteTestModel Then
                        ExectionTest_CR.Start()
                        ExectionTest_CR.IsBackground = True
                    Else
                        ExectionTest_R.Start()
                        ExectionTest_R.IsBackground = True
                    End If
                    Link_RTR.Enabled = True
                    monitorServerStatusAndWriteStatus.Start()
                    monitorServerStatusAndWriteStatus.IsBackground = True
                    monitorRunsStatus.Start()
                    monitorRunsStatus.IsBackground = True
                    Do While getexitValue = 0 Or getexitValue = 4
                        Application.DoEvents()
                        getexitValue = Class_ExecutionOperator1.exitValue
                        If Class_ExecutionOperator1.blnCancelRemote Then
                            If CustomRemoteTestModel Then
                                If ExectionTest_CR.IsAlive Then
                                    ExectionTest_CR.Abort()
                                End If
                            Else
                                If ExectionTest_R.IsAlive Then
                                    ExectionTest_R.Abort()
                                End If
                            End If
                            Dim CancelThreadsOfRunRunBPTs As New Thread(AddressOf CancelThreadsOfRunRunBPTs_OnlyForRemote)
                            Class_MainFormControlHandler1.AddContentToTB(TB_MainLog, "Please wait to cancel running threads.")
                            CancelThreadsOfRunRunBPTs.Start()
                            Do Until blnFinishCancelThread_R
                                Application.DoEvents()
                                waitTime(5000)
                            Loop

                            Class_MainFormControlHandler1.AddContentToTB(TB_MainLog, "All threads were cancelled.")
                            '###########for cancel all threads runing in pool for run BPT END##########
                            getexitValue = 3  'means the Class_UFTOperator1.exitValue has been cancelled 
                            Exit Do
                        End If
                        waitTime(2000)
                    Loop
                    stopUFTClassStatusCheck = True
                    monitorServerStatusAndWriteStatus.Abort()
                    monitorRunsStatus.Abort()
                    'controlsStatusAfterExitClickBt_Run()
EndLine_R:
                    If HostModel Then
                        On Error Resume Next
                        Cmd("TAKEOWN /F """ + TestReportPath + """ /R /D Y")
                        On Error GoTo 0
                        On Error Resume Next
                        Cmd("TAKEOWN /F """ + TestResultPath + """ /R /D Y")
                        On Error GoTo 0
                    End If
                    If getexitValue = 1 Then
                        Class_MainFormControlHandler1.AddContentToTB(TB_MainLog, "<Warning> The run ends with exception, please check board log and report.")
                        Class_MainFormControlHandler1.AddContentToTB(TB_MainLog, "<Report> " + TestReportPath)
                        If ProjectType = "UFT Project" Then
                            If HostModel Then
                                Class_MainFormControlHandler1.AddContentToTB(TB_MainLog, "<DetailResult> " + TestResultPath)
                            Else
                                Class_MainFormControlHandler1.AddContentToTB(TB_MainLog, "<DetailResultOnRemote> " + TestResultPath)
                            End If
                        End If

                    End If
                    If getexitValue = 2 Then
                        Class_MainFormControlHandler1.AddContentToTB(TB_MainLog, "<Done> The run was completed.")
                        Class_MainFormControlHandler1.AddContentToTB(TB_MainLog, "<Report> " + TestReportPath)
                        If ProjectType = "UFT Project" Then
                            If HostModel Then
                                Class_MainFormControlHandler1.AddContentToTB(TB_MainLog, "<DetailResult> " + TestResultPath)
                            Else
                                Class_MainFormControlHandler1.AddContentToTB(TB_MainLog, "<DetailResultOnRemote> " + TestResultPath)
                            End If
                        End If

                    End If
                    If getexitValue = 3 Then
                        Class_MainFormControlHandler1.AddContentToTB(TB_MainLog, "<Stopped> The run was stopped.")
                        Class_MainFormControlHandler1.AddContentToTB(TB_MainLog, "<Report> " + TestReportPath)
                        If ProjectType = "UFT Project" Then
                            If HostModel Then
                                Class_MainFormControlHandler1.AddContentToTB(TB_MainLog, "<DetailResult> " + TestResultPath)
                            Else
                                Class_MainFormControlHandler1.AddContentToTB(TB_MainLog, "<DetailResultOnRemote> " + TestResultPath)
                            End If
                        End If

                    End If
                    '###################Run In Remote END################
                Else
                    '###################Run In local model################

                    'create and share folders for TestReport and TestResult
                    ExecutionOperator.projectType = ProjectType
                    Class_ExecutionOperator1.Folder_Project_Root_Path = Folder_Root_Path
                    Class_ExecutionOperator1.strTestResultPath = TestResultPath
                    TempTestReportPath = TestReportPath
                    Class_ExecutionOperator1.strTestReportPath = TestReportPath
                    Class_ExecutionOperator1.strExeclReportPath = ExeclReportPath
                    Class_ExecutionOperator1.strTxtReportPath = TxtReportPath
                    Class_ExecutionOperator1.strEportTimeForFolder = strEportTimeForFolder
                    Class_ExecutionOperator1.strTestCasePath = BPTPath
                    ExecutionOperator.arryRunList = arrayBPTsSelectedAndStatus
                    Class_ExecutionOperator1.runStartTime = CDate(strEportTime)
                    Link_RTR.Visible = True
                    Dim getexitValue As Integer
                    If ProjectType = "UFT Project" Then


                        '##################Close QTP for stable control #######################
                        If Class_ExecutionOperator1.QTPRelatedExist() Then
                            If userClickRun Then
                                Dim msgvalue As Integer = MsgBox("Processes of UFT were being used. " + vbCrLf + vbCrLf + "Click 'Yes' button: start running (ATester will close the processes of UFT if that are still alive)." + vbCrLf + "Click 'No' button: stop running", MsgBoxStyle.YesNo)
                                If msgvalue = 6 Then
                                    On Error Resume Next
                                    Class_ExecutionOperator1.KillQTP()
                                    If Err.Number <> 0 Then
                                        Class_MainFormControlHandler1.AddContentToTB(TB_MainLog, "Error happens when closing UFT related processes, please close that manually!")
                                        getexitValue = 1
                                        GoTo EndLine_N
                                    End If
                                    On Error GoTo 0
                                    'On Error Resume Next
                                    'CreateObject("Shell.Application").ToggleDesktop()
                                    'On Error GoTo 0
                                    'Me.WindowState = FormWindowState.Minimized
                                Else
                                    Class_MainFormControlHandler1.AddContentToTB(TB_MainLog, "User stops this test run.", vbCrLf)
                                    getexitValue = 3
                                    GoTo EndLine_N
                                End If
                            Else
                                On Error Resume Next
                                Class_ExecutionOperator1.KillQTP()
                                If Err.Number <> 0 Then
                                    Class_MainFormControlHandler1.AddContentToTB(TB_MainLog, "Error happens when closing UFT related processes, please close that manually!")
                                    getexitValue = 1
                                    GoTo EndLine_N
                                End If
                                On Error GoTo 0
                                'On Error Resume Next
                                'CreateObject("Shell.Application").ToggleDesktop()
                                'On Error GoTo 0
                                'Me.WindowState = FormWindowState.Minimized
                            End If

                        Else
                            'On Error Resume Next
                            'CreateObject("Shell.Application").ToggleDesktop()
                            'On Error GoTo 0
                            'Me.WindowState = FormWindowState.Minimized
                        End If
                    End If
                    '##################Close QTP for stable control END#######################

                    ExectionTest = New Thread(AddressOf Class_ExecutionOperator1.Exection_Local)
                    Dim monitorRunsStatus As New Thread(AddressOf monitorRunNumberStatus)
                    'Class_MainFormControlHandler1.AddContentToTB(TB_MainLog, "-------------------------- BEGIN RUN ----------------------" + vbCrLf + CStr(Now))

                    If AbortExecutionTesthread Then ' here will check if user click cancel or close button
                        getexitValue = 3
                        GoTo EndLine_N
                    End If
                    L_PassRate.Visible = True
                    L_Total_Value.Visible = True
                    L_Remain.Visible = True
                    L_Remain_Value.Visible = True
                    ExecutionTestThreadUsed = True
                    getexitValue = Class_ExecutionOperator1.exitValue ' this value is to know how kind way "Class_UFTOperator1.ExectionUFTBPT_Normal" exits
                    ExectionTest.Start()
                    ExectionTest.IsBackground = True
                    monitorRunsStatus.Start()
                    monitorRunsStatus.IsBackground = True
                    Link_RTR.Enabled = True
                    Do While getexitValue = 0 Or getexitValue = 4
                        Application.DoEvents()
                        getexitValue = Class_ExecutionOperator1.exitValue
                        If AbortExecutionTesthread Then
                            'ExectionUFTBPT.Abort()
                            Dim CancelThreadsOfRunRunBPTs As New Thread(AddressOf CancelThreadsOfExecutionTest_Local)
                            Class_MainFormControlHandler1.AddContentToTB(TB_MainLog, "Please wait for cancelling related threads.")
                            CancelThreadsOfRunRunBPTs.Start()
                            Do Until blnFinishCancelThread_N
                                Application.DoEvents()
                                waitTime(10000)
                            Loop

                            getexitValue = 3  'means the Class_UFTOperator1.exitValue has been cancelled 
                            Class_MainFormControlHandler1.AddContentToTB(TB_MainLog, "All threads were cancelled.")
                            Exit Do
                        End If
                        waitTime(2000)
                    Loop
                    monitorRunsStatus.Abort()
                    'If getexitValue = 0 Or getexitValue = 4 Then ' when the getexitValue is 0 or 4 here that says Class_UFTOperator1.exitValue has changed to other than 0 or4 but not have chance to assign to getexitValue, so here we assign again
                    '    getexitValue = Class_UFTOperator1.exitValue
                    'End If
                    'controlsStatusAfterExitClickBt_Run()
EndLine_N:
                    If getexitValue = 1 Then
                        Class_MainFormControlHandler1.AddContentToTB(TB_MainLog, "<Warning> The run ends with exception, please check board log and report.")
                        Class_MainFormControlHandler1.AddContentToTB(TB_MainLog, "<Report> " + TestReportPath)
                        Class_MainFormControlHandler1.AddContentToTB(TB_MainLog, "<DetailResult> " + TestResultPath)
                    End If
                    If getexitValue = 2 Then
                        Class_MainFormControlHandler1.AddContentToTB(TB_MainLog, "<Done> The run was completed.")
                        Class_MainFormControlHandler1.AddContentToTB(TB_MainLog, "<Report> " + TestReportPath)
                        Class_MainFormControlHandler1.AddContentToTB(TB_MainLog, "<DetailResult> " + TestResultPath)
                    End If
                    If getexitValue = 3 Then
                        Class_MainFormControlHandler1.AddContentToTB(TB_MainLog, "<Stopped> The run was stopped.")
                        Class_MainFormControlHandler1.AddContentToTB(TB_MainLog, "<Report> " + TestReportPath)
                        Class_MainFormControlHandler1.AddContentToTB(TB_MainLog, "<DetailResult> " + TestResultPath)
                    End If
                    '###################Run In local model END################
                End If

                Class_MainFormControlHandler1.AddContentToTB(TB_MainLog, CStr(Now) + vbCrLf + ">---------------------------- END ---------------------------------------------")
                runOverAsNormalStatus = True
                NewForm()
            End If
        Else
            If userClickRun Then
                MsgBox("Please select an Running Mode!!!")
                controlsStatusAfterRunEnd()
                Exit Sub
            Else
                Class_MainFormControlHandler1.AddContentToTB(TB_MainLog, "Please select an Running Mode!!!")
                controlsStatusAfterRunEnd()
                Exit Sub
            End If
        End If

        Me.ProgressBar_Run_top.Visible = False
    End Sub
    Private Sub Bt_select_All_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bt_select_All.Click
        If RadioButton_Listbox.Checked Then
            If CLB_Testlist.Items.Count > 0 Then
                For i = 0 To CLB_Testlist.Items.Count - 1
                    CLB_Testlist.SetItemChecked(i, True)
                Next
            End If
            L_TBRTotal.Text = CStr(CLB_Testlist.CheckedItems.Count)
        End If

        If RadioButton_Textbox.Checked Then
            If TB_BPTList.Text <> "" Then
                TB_BPTList.Focus()
                TB_BPTList.SelectAll()
            End If
        End If
    End Sub
    Private Sub Bt_Clean_All_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bt_Clean_All.Click
        If RadioButton_Listbox.Checked Then
            If CLB_Testlist.Items.Count > 0 Then
                For i = 0 To CLB_Testlist.Items.Count - 1
                    CLB_Testlist.SetItemChecked(i, False)
                Next
            End If
            L_TBRTotal.Text = CStr(CLB_Testlist.CheckedItems.Count)
        End If

        If RadioButton_Textbox.Checked Then
            TB_BPTList.Text = ""
            TB_BPTList.Focus()
        End If
    End Sub

    Private Sub Bt_Refresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bt_Refresh.Click
        If Folder_TestCase_Path = "" Then
            If CB_NormalRun.Checked Then
                MsgBox("Please input Dir path!")
            End If
            If CB_Servers.Checked And CB_HostMode.Checked Then
                MsgBox("Please input Dir path!")
            End If
        Else
            If CB_NormalRun.Checked Then
                Dim Bt_RunEnabled = Bt_Run.Enabled
                Dim RadioButton_Textbox_Enabled = RadioButton_Textbox.Enabled
                Dim RadioButton_Listbox_Enabled = RadioButton_Listbox.Enabled
                Dim Bt_select_AllEnabled = Bt_select_All.Enabled
                Dim Bt_Clean_AllEnabled = Bt_Clean_All.Enabled
                Dim BT_CheckReportEnabled = BT_CheckReport.Enabled
                Dim BT_IMBPTEnabled = BT_IMBPT.Enabled
                Dim BT_EXTBPTEnabled = BT_EXTBPT.Enabled
                Dim CB_ServersEnabled = CB_Servers.Enabled
                Dim CB_NormalRunEnabled = CB_NormalRun.Enabled
                Dim RadioButton_RemoteModeEnabled = RadioButton_RemoteMode.Enabled
                Dim RadioButton_LocalModeEnabled = RadioButton_LocalMode.Enabled
                Dim BT_LCEnabled = BT_LC.Enabled
                Dim BT_CheckServersEnabled = BT_EditResource.Enabled

                Dim TB_LCEnabled = TB_LC.Enabled
                Dim BT_OpenLibEnabled = LibraryToolStripMenuItem.Enabled
                Dim BT_CloseEnabled = BT_Close.Enabled

                Bt_Refresh.Enabled = False
                Bt_Run.Enabled = False
                RadioButton_Textbox.Enabled = False
                RadioButton_Listbox.Enabled = False
                Bt_select_All.Enabled = False
                Bt_Clean_All.Enabled = False
                BT_CheckReport.Enabled = False
                BT_IMBPT.Enabled = False
                BT_EXTBPT.Enabled = False
                CB_NormalRun.Enabled = False
                CB_Servers.Enabled = False
                RadioButton_RemoteMode.Enabled = False
                RadioButton_LocalMode.Enabled = False
                BT_LC.Enabled = False
                BT_EditResource.Enabled = False

                TB_LC.Enabled = False
                LibraryToolStripMenuItem.Enabled = False
                BT_Close.Enabled = False
                Class_MainFormControlHandler1.AddContentToTB(TB_MainLog, "Retrieve the TestCases' name. The time spent depends on your computer speed.")
                Dim checkRefresh As New Thread(AddressOf CheckBPTPathAndSetRelatedControls)
                checkRefresh.Start()
                'Class_MainFormControlHandler1.AddContentToTB(TB_MainLog, "Refreshing To Be Run List")
                Do Until blnRefreshEnd
                    Application.DoEvents()
                    waitTime(200)
                Loop
                'Class_MainFormControlHandler1.AddContentToTB(TB_MainLog, "Refreshing done")

                If RadioButton_Listbox.Checked Then
                    L_TBRTotal.Text = CStr(CLB_Testlist.CheckedItems.Count)
                End If

                If RadioButton_Textbox.Checked Then
                    Dim linecount = 0
                    For i = 0 To UBound(TB_BPTList.Lines)
                        If Trim(TB_BPTList.Lines(i)) <> "" Then
                            linecount = linecount + 1
                        End If
                    Next
                    L_TBRTotal.Text = CStr(linecount)
                End If
                blnRefreshEnd = False
                Bt_Refresh.Enabled = True
                Bt_Run.Enabled = Bt_RunEnabled

                RadioButton_Textbox.Enabled = RadioButton_Textbox_Enabled
                RadioButton_Listbox.Enabled = RadioButton_Listbox_Enabled
                Bt_select_All.Enabled = Bt_select_AllEnabled
                Bt_Clean_All.Enabled = Bt_Clean_AllEnabled
                BT_CheckReport.Enabled = BT_CheckReportEnabled
                BT_IMBPT.Enabled = BT_IMBPTEnabled
                BT_EXTBPT.Enabled = BT_EXTBPTEnabled
                CB_NormalRun.Enabled = CB_NormalRunEnabled
                CB_Servers.Enabled = CB_ServersEnabled
                RadioButton_RemoteMode.Enabled = RadioButton_RemoteModeEnabled
                RadioButton_LocalMode.Enabled = RadioButton_LocalModeEnabled
                BT_LC.Enabled = BT_LCEnabled
                BT_EditResource.Enabled = BT_CheckServersEnabled


                TB_LC.Enabled = TB_LCEnabled
                LibraryToolStripMenuItem.Enabled = BT_OpenLibEnabled
                BT_Close.Enabled = BT_CloseEnabled

            End If
            If CB_Servers.Checked And CB_HostMode.Checked Then
                Dim Bt_RunEnabled = Bt_Run.Enabled
                Dim RadioButton_Listbox_Enabled = RadioButton_Listbox.Enabled
                Dim RadioButton_Textbox_Enabled = RadioButton_Textbox.Enabled
                Dim Bt_select_AllEnabled = Bt_select_All.Enabled
                Dim Bt_Clean_AllEnabled = Bt_Clean_All.Enabled
                Dim BT_CheckReportEnabled = BT_CheckReport.Enabled
                Dim BT_IMBPTEnabled = BT_IMBPT.Enabled
                Dim BT_EXTBPTEnabled = BT_EXTBPT.Enabled
                Dim CB_ServersEnabled = CB_Servers.Enabled
                Dim CB_NormalRunEnabled = CB_NormalRun.Enabled
                Dim RadioButton_RemoteModeEnabled = RadioButton_RemoteMode.Enabled
                Dim RadioButton_LocalModeEnabled = RadioButton_LocalMode.Enabled
                Dim BT_LCEnabled = BT_LC.Enabled
                Dim BT_CheckServersEnabled = BT_EditResource.Enabled
                Dim Bt_EditSlaveIPsEnabled = Bt_EditSlaveIPs.Enabled

                Dim TB_LCEnabled = TB_LC.Enabled
                Dim BT_OpenLibEnabled = LibraryToolStripMenuItem.Enabled
                Dim BT_CloseEnabled = BT_Close.Enabled
                Dim CB_HostEnabled = CB_HostMode.Enabled
                Dim TB_RR_DirEnabled = TB_RR_Dir.Enabled
                Dim Bt_MoreRemoteEnabled = Bt_MissionPanel.Enabled
                Dim CB_CRTEnabled = CB_CRT.Enabled

                TB_RR_Dir.Enabled = False
                CB_HostMode.Enabled = False
                Bt_Refresh.Enabled = False
                Bt_Run.Enabled = False

                RadioButton_Listbox.Enabled = False
                RadioButton_Textbox.Enabled = False
                Bt_select_All.Enabled = False
                Bt_Clean_All.Enabled = False
                BT_CheckReport.Enabled = False
                BT_IMBPT.Enabled = False
                BT_EXTBPT.Enabled = False
                CB_NormalRun.Enabled = False
                CB_Servers.Enabled = False
                RadioButton_RemoteMode.Enabled = False
                RadioButton_LocalMode.Enabled = False
                BT_LC.Enabled = False
                BT_EditResource.Enabled = False
                Bt_EditSlaveIPs.Enabled = False
                TB_LC.Enabled = False
                LibraryToolStripMenuItem.Enabled = False
                BT_Close.Enabled = False
                Bt_MissionPanel.Enabled = False
                CB_CRT.Enabled = False

                Class_MainFormControlHandler1.AddContentToTB(TB_MainLog, "Retrieve the TestCases' name. The time spent depends on your network speed.")
                Dim checkRefresh As New Thread(AddressOf CheckBPTPathAndSetRelatedControls)
                checkRefresh.Start()

                'Class_MainFormControlHandler1.AddContentToTB(TB_MainLog, "Refreshing To Be Run List")
                Do Until blnRefreshEnd
                    Application.DoEvents()
                    waitTime(200)
                Loop
                'Class_MainFormControlHandler1.AddContentToTB(TB_MainLog, "Refreshing done")

                If RadioButton_Textbox.Checked Then
                    Dim linecount = 0
                    For i = 0 To UBound(TB_BPTList.Lines)
                        If Trim(TB_BPTList.Lines(i)) <> "" Then
                            linecount = linecount + 1
                        End If
                    Next
                    L_TBRTotal.Text = CStr(linecount)
                End If


                If RadioButton_Listbox.Checked Then
                    L_TBRTotal.Text = CStr(CLB_Testlist.CheckedItems.Count)
                End If


                blnRefreshEnd = False
                Bt_Refresh.Enabled = True
                Bt_Run.Enabled = Bt_RunEnabled

                RadioButton_Listbox.Enabled = RadioButton_Listbox_Enabled
                RadioButton_Textbox.Enabled = RadioButton_Textbox_Enabled
                Bt_select_All.Enabled = Bt_select_AllEnabled
                Bt_Clean_All.Enabled = Bt_Clean_AllEnabled
                BT_CheckReport.Enabled = BT_CheckReportEnabled
                BT_IMBPT.Enabled = BT_IMBPTEnabled
                BT_EXTBPT.Enabled = BT_EXTBPTEnabled
                CB_NormalRun.Enabled = CB_NormalRunEnabled
                CB_Servers.Enabled = CB_ServersEnabled
                RadioButton_RemoteMode.Enabled = RadioButton_RemoteModeEnabled
                RadioButton_LocalMode.Enabled = RadioButton_LocalModeEnabled
                BT_LC.Enabled = BT_LCEnabled
                BT_EditResource.Enabled = BT_CheckServersEnabled
                Bt_EditSlaveIPs.Enabled = Bt_EditSlaveIPsEnabled
                TB_LC.Enabled = TB_LCEnabled
                LibraryToolStripMenuItem.Enabled = BT_OpenLibEnabled
                BT_Close.Enabled = BT_CloseEnabled
                CB_HostMode.Enabled = CB_HostEnabled
                TB_RR_Dir.Enabled = TB_RR_DirEnabled
                Bt_MissionPanel.Enabled = Bt_MoreRemoteEnabled
                CB_CRT.Enabled = CB_CRTEnabled

            End If
        End If

    End Sub


    Private Sub controlsStatusAfterRunBegin()
        ' L_Progress.Visible = True
        IsRUNClicked = True
        ComboBox_Project.Enabled = False
        TB_MainLog.WordWrap = False
        Bt_select_All.Enabled = False
        Bt_Refresh.Enabled = False
        Bt_Clean_All.Enabled = False
        CLB_Testlist.Enabled = False
        Bt_Run.Enabled = False

        CB_NormalRun.Enabled = False
        CB_Servers.Enabled = False
        RadioButton_RemoteMode.Enabled = False
        RadioButton_LocalMode.Enabled = False
        TB_ReportFolder.Enabled = False
        TB_RR_Dir.Enabled = False
        TB_OneTimeNumber.Enabled = False
        TB_DeadLine.Enabled = False
        TB_BPTList.Enabled = False
        RadioButton_Listbox.Enabled = False
        RadioButton_Textbox.Enabled = False
        BT_CheckReport.Enabled = False
        BT_EditResource.Enabled = False
        Bt_EditSlaveIPs.Enabled = False
        CB_Excel.Enabled = False
        Bt_Stop.Enabled = True

        AlarmToRunToolStripMenuItem.Enabled = False
        ' CB_SValid.Enabled = False
        'CB_ShareReportFolder.Enabled = False
        TB_LC.Enabled = False
        BT_LC.Enabled = False
        TB_ReportFolder_R.Enabled = False
        CLB_ReportServerIP.Enabled = False
        L_ReportServerIP.Enabled = False
        BT_IMBPT.Enabled = False
        BT_EXTBPT.Enabled = False
        TB_RR_IPs.Enabled = False
        CB_HostMode.Enabled = False
        CB_CRT.Enabled = False
        CheckRemoteUFTStatusToolStripMenuItem.Enabled = False
        Form_MissionPanel.BT_GTFAT.Enabled = False
        'On Error Resume Next
        If UBound(arryIPs_TBs_Relation) > -1 Then
            For i = 0 To UBound(arryIPs_TBs_Relation)
                arryIPs_TBs_Relation(i)(1).ReadOnly = True
                arryIPs_TBs_Relation(i)(3).visible = True
                arryIPs_TBs_Relation(i)(3).Tag = arryIPs_TBs_Relation(i)(2).Tag
                arryIPs_TBs_Relation(i)(3).Text = "Remaining: " + CStr(arryIPs_TBs_Relation(i)(2).Tag)
            Next
        End If

        'On Error GoTo 0
    End Sub
    Private Sub controlsStatusAfterRunEnd()
        'L_Progress.Visible = False
        TB_RR_IPs.Enabled = TB_RR_IPSEnable_BeforeClickRun
        Bt_select_All.Enabled = Bt_selectEnable_All_BeforeClickRun
        Bt_Refresh.Enabled = Bt_RefreshEnable_BeforeClickRun
        Bt_Clean_All.Enabled = Bt_CleanEnable_All_BeforeClickRun
        CLB_Testlist.Enabled = CLBEnable_BeforeClickRun
        Bt_Run.Enabled = Bt_RunEnable_BeforeClickRun

        Bt_Stop.Enabled = Bt_CancelEnable_BeforeClickRun

        CB_NormalRun.Enabled = CB_NormalRun_BeforeClickRun
        CB_Servers.Enabled = CB_ServersEnable_BeforeClickRun

        RadioButton_RemoteMode.Enabled = RadioButton_RemoteModeEnabled
        RadioButton_LocalMode.Enabled = RadioButton_LocalModeEnabled

        TB_ReportFolder.Enabled = TB_ReportFolderEnable_BeforeClickRun
        TB_RR_Dir.Enabled = TB_ServersEnable_BeforeClickRun
        TB_OneTimeNumber.Enabled = TB_OneTimeNumber_BeforeClickRun
        TB_DeadLine.Enabled = TB_DeadLine_BeforeClickRun
        TB_BPTList.Enabled = TB_BPTList_BeforeClickRun
        RadioButton_Listbox.Enabled = RadioButton_Listbox_BeforeClickRun
        RadioButton_Textbox.Enabled = RadioButton_Textbox_BeforeClickRun
        BT_CheckReport.Enabled = BT_CheckReport_BeforeClickRun
        BT_EditResource.Enabled = BT_CheckServers_BeforeClickRun
        Bt_EditSlaveIPs.Enabled = Bt_EditSlaveIPs_BeforeClickRun
        CB_Excel.Enabled = CB_Excel_BeforeClickRun
        BT_Close.Enabled = BT_Close_BeforeClickRun
        'CB_SValid.Enabled = CB_SValid_BeforeClickRun
        CB_HostMode.Enabled = CB_hostserver_BeforeClickRun
        TB_LC.Enabled = TB_LC_BeforeClickRun
        BT_LC.Enabled = BT_LC_BeforeClickRun
        'CB_ShareReportFolder.Enabled = CB_ShareReportFolder_BeforeClickRun
        TB_ReportFolder_R.Enabled = TB_ReportFolder_R_BeforeClickRun
        CLB_ReportServerIP.Enabled = LB_AesterIP_BeforeClickRun
        L_ReportServerIP.Enabled = L_IPATester_BeforeClickRun
        L_PassRate.Visible = L_Total_BeforeClickRun
        L_Total_Value.Visible = L_Total_Value_BeforeClickRun
        L_Remain.Visible = L_Remain_BeforeClickRun
        L_Remain_Value.Visible = L_Remain_Value_BeforeClickRun
        BT_IMBPT.Enabled = BT_IMBPT_BeforeClickRun
        BT_EXTBPT.Enabled = BT_EXTBPT_BeforeClickRun
        CB_HostMode.Enabled = CB_HostModelEnabled_BeforeClickRun
        AlarmToRunToolStripMenuItem.Enabled = AlarmToRunToolStripMenuItem_BeforeClickRun
        CB_CRT.Enabled = CB_CRT_BeforeClickRun
        Form_MissionPanel.BT_GTFAT.Enabled = BT_GTFAT_BeforeClickRun
        ComboBox_Project.Enabled = ComboBox_Project_Enabled
        On Error Resume Next
        If UBound(arryIPs_TBs_Relation) > -1 Then
            For i = 0 To UBound(arryIPs_TBs_Relation)
                arryIPs_TBs_Relation(i)(1).ReadOnly = False
            Next
        End If
        On Error GoTo 0
        'Me.TopLevel = True
        IsRUNClicked = False
        ' Me.BringToFront() 'put on the top
        ' Link_RTR.Visible = False
        CheckRemoteUFTStatusToolStripMenuItem.Enabled = True
        Alarm.enabledOject(Alarm.Calloff_Button, True)
        Alarm.enabledOject(Alarm.Button_OK, True)
        Alarm.enabledOject(Alarm.Button_Cancel, True)
        Alarm.enabledOject(Alarm.TB_TimeLeft, True)

        Me.ProgressBar_Run_top.Visible = False
    End Sub
    Private Sub CB_NormalRun_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CB_NormalRun.CheckedChanged
        ConfiguraionFileChange()
        If CB_NormalRun.Checked = True Then
            Panel_RemoteMode.Hide()
            Panel_LocalMode.Show()
            Panel_Log.Visible = True
            Panel_Log.BringToFront()
            Dim logwith = Bt_logback.Width - 9
            L_LogTitle.Location = New Point(logwith / 2 - L_LogTitle.Width / 2, L_LogTitle.Location.Y)
            Panel_Log.Width = logwith
            Bt_Log_Edit_Back.Width = logwith - 2
            TB_MainLog.Width = logwith - 4
            Panel_CustomMissionPanel.Visible = False
            Panel_TestMissionPanel.Visible = True
            L_TestMissionTitle.Parent = Panel_TestMissionPanel
            CB_CRT.Parent = Panel_TestMissionPanel
            L_TestMissionTitle.BringToFront()
            CB_CRT.BringToFront()
            CB_Servers.Checked = False
            CB_Servers.Enabled = True
            BT_LC.BackColor = globalButtonColor
            TB_RR_IPs.BackColor = Color.White
            TB_LC.Enabled = True
            BT_LC.Enabled = True
            TB_ReportFolder.Enabled = True
            BT_CheckReport.Location = New Point(TB_ReportFolder.Location.X + TB_ReportFolder.Width + 6, TB_ReportFolder.Location.Y - 4)
            BT_CheckReport.Enabled = True
            Label_LR_Dir.Enabled = True
            TB_ReportFolder.Show()
            LibraryToolStripMenuItem.Enabled = True
            Label_timeout.Enabled = False
            Label_OT.Enabled = False
            L_TimeOut_Unit.Enabled = False
            L_PerOneSlave.Enabled = False
            Bt_MissionPanel.Enabled = False
            TB_RR_Dir.Enabled = False
            TB_DeadLine.Enabled = False
            TB_OneTimeNumber.Enabled = False
            BT_EditResource.Enabled = False
            CB_HostMode.Enabled = False
            ExpandButton.Enabled = True
            CB_CRT.Enabled = False
            Label_RRDir.Enabled = False
            L_tip_Timeout.Visible = False
            TB_ReportFolder_R.Hide()
            CLB_ReportServerIP.Hide()
            P_ReportIP_back.Hide()
            L_ReportServerIP.Hide()
            L_Tip_RunResult.Visible = False
            Dim currentText = TB_LC.Text
            TB_LC.Text = " "
            TB_LC.Text = currentText
            TB_LC.Focus()
            HostModel = CB_HostMode.Checked And CB_Servers.Checked
            CustomRemoteTestModel = CB_CRT.Checked And CB_Servers.Checked
            LocalRunModel = True

            If IsNothing(handleformMoreControlTh) Then
            Else
                If handleformMoreControlTh.IsAlive Then
                    handleformMoreControlTh.Abort()
                    handleformMoreControlTh = Nothing
                End If
            End If
            Bt_RunningMgmt.Enabled = True
        End If
    End Sub


    Private Sub CB_Servers_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CB_Servers.CheckedChanged
        ConfiguraionFileChange()
        If CB_Servers.Checked = True Then
            Panel_LocalMode.Hide()
            Panel_RemoteMode.Show()

            Panel_Log.Visible = True
            Panel_Log.BringToFront()
            Dim logwith = Bt_logback.Width - 9
            L_LogTitle.Location = New Point(logwith / 2 - L_LogTitle.Width / 2, L_LogTitle.Location.Y)
            Panel_Log.Width = logwith
            Bt_Log_Edit_Back.Width = logwith - 2
            TB_MainLog.Width = logwith - 4



            If CB_CRT.Checked = True Then
                Panel_CustomMissionPanel.Visible = True
                Panel_TestMissionPanel.Visible = False
                L_TestMissionTitle.Parent = Panel_CustomMissionPanel
                CB_CRT.Parent = Panel_CustomMissionPanel
                L_TestMissionTitle.BringToFront()
                CB_CRT.BringToFront()
            End If

            Label_timeout.Enabled = True
            Label_OT.Enabled = True
            L_TimeOut_Unit.Enabled = True
            L_PerOneSlave.Enabled = True
            If ProjectType = "UFT Project" Then
                CB_HostMode.Enabled = True
                If CB_HostMode.Checked Then
                    Bt_EditSlaveIPs.Enabled = True
                    LibraryToolStripMenuItem.Enabled = True
                Else
                    LibraryToolStripMenuItem.Enabled = False
                End If
            End If


            CB_NormalRun.Checked = False
            CB_NormalRun.Enabled = True
            TB_RR_Dir.Enabled = True
            TB_DeadLine.Enabled = True
            TB_OneTimeNumber.Enabled = True
            BT_EditResource.Enabled = True
            Label_RRDir.Enabled = True
            L_tip_Timeout.Visible = True
            L_tip_Timeout.BringToFront()
            TB_ReportFolder_R.Show()
            Dim currentText = TB_RR_Dir.Text
            TB_RR_DirSelfchange = True
            TB_RR_Dir.Text = " "
            TB_RR_Dir.Text = currentText
            TB_RR_DirSelfchange = False
            CB_NormalRun.Enabled = True
            BT_LC.BackColor = Color.DarkGray
            TB_LC.Enabled = False
            BT_LC.Enabled = False
            TB_ReportFolder.Enabled = False
            TB_ReportFolder.Hide()
            TB_ReportFolder_R.Show()
            TB_ReportFolder_R.ForeColor = Color.Black
            Label_LR_Dir.Enabled = False
            BT_CheckReport.Enabled = False
            TB_ReportFolder.Hide()
            CB_CRT.Enabled = True
            CB_HostModelSelfchange = True
            Dim currentchecked = CB_HostMode.Checked
            CB_HostMode.Checked = Not currentchecked
            CB_HostMode.Checked = currentchecked
            CB_HostModelSelfchange = False

            Dim currentCRTchecked = CB_CRT.Checked
            CB_CRTSelfchange = True
            CB_CRT.Checked = Not currentCRTchecked
            CB_CRT.Checked = currentCRTchecked
            CB_CRTSelfchange = False

            TB_RR_Dir.Focus()
            HostModel = CB_HostMode.Checked And CB_Servers.Checked
            CustomRemoteTestModel = CB_CRT.Checked And CB_Servers.Checked
            LocalRunModel = False

            If IsNothing(handleformMoreControlTh) Then
            Else
                If handleformMoreControlTh.IsAlive Then
                    handleformMoreControlTh.Abort()
                    handleformMoreControlTh = Nothing
                End If
            End If
            Bt_RunningMgmt.Enabled = True
        End If
    End Sub

    Public Sub AddMessageToTB_MainLog(ByVal msg As String, ByVal following As String) Handles Class_ExecutionOperator1.AddMessageToTB_MainLogEvnt
        Invoke(New Delegate_AddContentToTB(AddressOf AddMsgToTextBox), TB_MainLog, msg, following)
    End Sub



    Public Sub AddMsgToTextBox(ByRef tb As TextBox, ByVal msg As String, Optional ByVal following As String = vbCrLf)
        Class_MainFormControlHandler1.AddContentToTB(tb, msg, following)
    End Sub

    Public Sub SetEnableToBt(ByRef bt As Button, ByVal bln As Boolean)
        bt.Enabled = bln
    End Sub
    Public Sub NewForm()
        controlsStatusAfterRunEnd()
        blnCheckNetworkFolderComplete = False
        blnNetworkFolderGood = False
        blnCheckNetworkFolderComplete = Nothing
        AbortExecutionTesthread = False
        blnFinishCancelThread_R = False
        blnFinishCancelThread_N = False
        Class_ExecutionOperator1.strTestResultPath = ""
        Class_ExecutionOperator1.strTestReportPath = ""
        Class_ExecutionOperator1.strTestCasePath = ""
        ExecutionOperator.arryRunList = Nothing
        Class_ExecutionOperator1.strTxtReportPath = ""
        Class_ExecutionOperator1.strExeclReportPath = ""
        Class_ExecutionOperator1.exitValue = 4
        Class_ExecutionOperator1.openUFTByme = False
        ExecutionOperator.arryServerFullyInfo = Nothing
        Class_ExecutionOperator1.OneTimeNumber = 0
        Class_ExecutionOperator1.RemoteErrorRun = False
        Class_ExecutionOperator1.blnCancelRemote = False
        Class_ExecutionOperator1.strEportTimeForFolder = ""
        Class_ExecutionOperator1.Class_FileOperator1 = New FileOperator
        Class_ExecutionOperator1.Class_ExcelOperator2 = New ExcelOperator
        ReDim ExecutionOperator.arryForThreadWhichRunRemoteBPT(-1)
        Class_ExecutionOperator1.runStartTime = Nothing
        Class_ExecutionOperator1.shareReportFolder = False
        stopUFTClassStatusCheck = True
        strSharedFolderPathOfOtherServerReport = ""
        strSharedFolderNameOfOtherServerReport = ""
        'isLocalIPForReport = 0
        deadLineSecond = 0
        ExecutionTestThreadUsed = False
        'L_Total_Value.Text = "0"
        'L_Remain_Value.Text = "0"
        'L_RoundID.Text = "N/A"
        'L_PRValue.Text = "0%"
        'L_Progress.Text = "0%"
        'Link_RTR.Enabled = False
        writeNIText(NI, "ATester")
        writeFormText(Me, "ATester")
        If Me.WindowState = FormWindowState.Minimized Then
            'NI.ShowBalloonTip(5000, "ATester", "Run over, please check result.", ToolTipIcon.Info)
            NI.Visible = False
        End If
        Me.Show()
        Me.WindowState = FormWindowState.Minimized
        Me.WindowState = FormWindowState.Normal
        TB_MainLog.SelectionStart = TB_MainLog.Text.Length
        TB_MainLog.ScrollToCaret()

    End Sub


    Private Sub TB_OneTimeNumber_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TB_OneTimeNumber.TextChanged
        ConfiguraionFileChange()
        If TB_OneTimeNumber.Text <> "" Then
            Dim KeyCode As Integer
            For i = 1 To Len(TB_OneTimeNumber.Text)
                KeyCode = Asc(Mid(TB_OneTimeNumber.Text, i, 1))
                If KeyCode < 48 Or KeyCode > 57 Then
                    TB_OneTimeNumber.Text = Replace(TB_OneTimeNumber.Text, Mid(TB_OneTimeNumber.Text, i, 1), "")
                    TB_OneTimeNumber.Select(i - 1, False)
                    'MsgBox("please input a integer")
                    Exit For
                End If
            Next
        Else
            TB_OneTimeNumber.Text = defualtOneTimeNumber
        End If
        TB_OneTimeNumber.Text = CInt(TB_OneTimeNumber.Text)
        If CInt(TB_OneTimeNumber.Text) = "0" Then
            TB_OneTimeNumber.Text = defualtOneTimeNumber
        End If
    End Sub
    Sub CancelThreadsOfExecutionTest_Local()
        'On Error Resume Next
        If UBound(mainFormThreadForRUNTime) <= -1 Then
        Else
            For i = 0 To UBound(mainFormThreadForRUNTime)
                If IsNothing(mainFormThreadForRUNTime(i)(0)) Then
                Else

                    If mainFormThreadForRUNTime(i)(0).IsAlive() Then
                        mainFormThreadForRUNTime(i)(0).Abort()
                    End If
                End If
            Next
        End If

        If IsNothing(ExectionTest) Then
        Else
            If ProjectType = "UFT Project" Then
                Dim killUFTThread As New Thread(AddressOf killUFT)
                killUFTThread.IsBackground = True
                killUFTThread.Start()
            End If

            'Invoke(New Delegate_AddContentToTB(AddressOf AddMsgToTextBox), TB_MainLog, "UFT was closed.", vbCrLf)
            If ExectionTest.IsAlive() Then
                ExectionTest.Abort()
                ExectionTest = Nothing
            End If
        End If

        'For j = 0 To UBound(UFTOperator.arryServerFullyInfo)
        '    Application.DoEvents()
        '    UFTOperator.arryServerFullyInfo(j)(3).test.stop()
        '    'UFTOperator.arryServerFullyInfo(j)(3).Quit()
        'Next
        If ProjectType = "Maven Project" Then
            killMRP("l")
        End If
        On Error GoTo 0
        blnFinishCancelThread_N = True
    End Sub
    Sub killMRP(ByVal loc As String)
        Class_ExecutionOperator1.killMavenRelatedProcesses(loc)
    End Sub
    Sub killUFT()
        If Class_ExecutionOperator1.openUFTByme Then
            Class_ExecutionOperator1.KillQTP()
        End If
    End Sub
    Sub CancelThreadsOfRunRunBPTs_OnlyForRemote()

        If UBound(mainFormThreadForRUNTime) <= -1 Then
        Else
            For i = 0 To UBound(mainFormThreadForRUNTime)
                If IsNothing(mainFormThreadForRUNTime(i)(0)) Then
                Else

                    If mainFormThreadForRUNTime(i)(0).IsAlive() Then
                        mainFormThreadForRUNTime(i)(0).Abort()
                    End If
                End If
            Next
        End If

        If UBound(ExecutionOperator.arryForThreadWhichRunRemoteBPT) > -1 Then
            For i = 0 To UBound(ExecutionOperator.arryForThreadWhichRunRemoteBPT) 'the 1st index is nothing, so from 1 to max bound
                If IsNothing(ExecutionOperator.arryForThreadWhichRunRemoteBPT(i)) Then
                Else
                    Dim curUFT = ExecutionOperator.arryForThreadWhichRunRemoteBPT(i)(1)
                    Dim curUFTServer = ExecutionOperator.arryForThreadWhichRunRemoteBPT(i)(2)
                    If IsNothing(curUFT) = False Then
                        Dim quiteUFTThread As New Thread(AddressOf StopUFTTest)
                        quiteUFTThread.IsBackground = True
                        quiteUFTThread.Start(curUFT)
                        Invoke(New Delegate_AddContentToTB(AddressOf AddMsgToTextBox), TB_MainLog, "Test of Slave """ + curUFTServer + """ was stopped.", vbCrLf)
                    End If
                    If IsNothing(ExecutionOperator.arryForThreadWhichRunRemoteBPT(i)(0)) = False And ExecutionOperator.arryForThreadWhichRunRemoteBPT(i)(0).IsAlive() Then
                        ExecutionOperator.arryForThreadWhichRunRemoteBPT(i)(0).Abort()
                    End If
                    If IsNothing(curUFT) = False Then
                        On Error Resume Next
                        curUFT.Quit()
                        On Error GoTo 0
                        Invoke(New Delegate_AddContentToTB(AddressOf AddMsgToTextBox), TB_MainLog, "Slave """ + curUFTServer + """ was disconnected.", vbCrLf)
                    End If
                End If
            Next
        End If
        If ProjectType = "Maven Project" Then
            killMRP("r")
        End If
        blnFinishCancelThread_R = True
    End Sub
    Sub StopUFTTest(ByVal uft As Object)
        On Error Resume Next
        uft.Test.Stop()
        'uft.Quit()
        On Error GoTo 0
    End Sub
    Private Sub TB_DeadLine_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TB_DeadLine.TextChanged
        ConfiguraionFileChange()
        If TB_DeadLine.Text <> "" Then
            Dim KeyCode As Integer
            For i = 1 To Len(TB_DeadLine.Text)
                KeyCode = Asc(Mid(TB_DeadLine.Text, i, 1))
                If KeyCode < 48 Or KeyCode > 57 Then
                    TB_DeadLine.Text = Replace(TB_DeadLine.Text, Mid(TB_DeadLine.Text, i, 1), "")
                    TB_DeadLine.Select(i - 1, False)
                    'MsgBox("please input a integer")
                    Exit For
                End If
            Next
        Else
            TB_DeadLine.Text = defaultTimeOut
        End If
        TB_DeadLine.Text = CInt(TB_DeadLine.Text)
        If CInt(TB_DeadLine.Text) = "0" Then
            TB_DeadLine.Text = defaultTimeOut
        End If

    End Sub
    Sub checkSlavesTimeOut(ByVal info As Object)
        '#################get the thread###################
        Dim tempThread As Thread = Threading.Thread.CurrentThread
        'Debug.Print(CStr(Now) + "reach thread")
        tempThread.IsBackground = True
        Dim nextIndex As Integer = UBound(mainFormThreadForRUNTime) + 1
        ReDim Preserve mainFormThreadForRUNTime(nextIndex)
        mainFormThreadForRUNTime(nextIndex) = {tempThread, "mainformruntime"}
        '#################get the thread END###################
        Dim findNotDisct As Boolean
        Dim deadlinecount = 0
        Dim waitSec = 500
        Dim reachtimeout As Boolean = False
        Dim tempStatusString As String

        Do While reachtimeout = False
            Dim findserver = False
            If IsNothing(ExecutionOperator.arryServerFullyInfo) = False Then
                For w = 0 To UBound(ExecutionOperator.arryServerFullyInfo)
                    If IsNothing(ExecutionOperator.arryServerFullyInfo(w)) = False Then
                        If ExecutionOperator.arryServerFullyInfo(w)(1) = info(1) Then
                            findserver = True
                            Exit For
                        End If
                    End If
                Next
                If findserver = False Then
                    'Invoke(New Delegate_AddContentToTB(AddressOf AddMsgToTextBox), TB_MainLog, "Removing: server " + info(1) + " was removed from Mission by user.", vbCrLf)
                    Exit Do
                End If
            Else
                'Invoke(New Delegate_AddContentToTB(AddressOf AddMsgToTextBox), TB_MainLog, "Removing: server " + info(1) + " was removed from Mission by user.", vbCrLf)
                Exit Do
            End If
            findNotDisct = False
            tempStatusString = ""

            If info(2) <> "disct" Then
                findNotDisct = True
            End If

            If findNotDisct Then
                waitTime(waitSec)
                deadlinecount = 0
            Else
                If deadlinecount * waitSec > deadLineSecond * 1000 Then
                    Invoke(New Delegate_AddContentToTB(AddressOf AddMsgToTextBox), TB_MainLog, "Stopping: connection of server " + info(1) + " was timeout. <" + CStr(deadLineSecond / 60) + "> minutes", vbCrLf)
                    waitTime(2000)

                    If IsNothing(ExecutionOperator.arryServerFullyInfo) = False Then
                        Dim findserver1 = False
                        For w = 0 To UBound(ExecutionOperator.arryServerFullyInfo)
                            If IsNothing(ExecutionOperator.arryServerFullyInfo(w)) = False Then
                                If ExecutionOperator.arryServerFullyInfo(w)(1) = info(1) Then
                                    ExecutionOperator.arryServerFullyInfo(w)(2) = "timeout"
                                    findserver1 = True
                                    Exit For
                                End If
                            End If
                        Next
                        If findserver1 = False Then
                            'Invoke(New Delegate_AddContentToTB(AddressOf AddMsgToTextBox), TB_MainLog, "Removing: server " + info(1) + " was removed from Mission by user.", vbCrLf)
                            Exit Do
                        End If
                    Else
                        'Invoke(New Delegate_AddContentToTB(AddressOf AddMsgToTextBox), TB_MainLog, "Removing: server " + info(1) + " was removed from Mission by user.", vbCrLf)
                        Exit Do
                    End If
                    'Exit Do no need to abort, the Bt_CancelPerformClick will abort the thread
                    reachtimeout = True
                Else
                    deadlinecount = deadlinecount + 1
                    waitTime(waitSec)
                End If
            End If

        Loop
    End Sub
    Sub ShowSlavesStatusAndWriteStatus()


        For i = 0 To UBound(ExecutionOperator.arryServerFullyInfo)
            If IsNothing(ExecutionOperator.arryServerFullyInfo(i)) = False Then
                ThreadPool.QueueUserWorkItem(New WaitCallback(AddressOf checkSlavesTimeOut), ExecutionOperator.arryServerFullyInfo(i))
            End If
        Next
        'Dim write As New Thread(AddressOf writeUFTClassStatusToRTB)
        'write.Start()

    End Sub
    Sub writeUFTClassStatusToRTB()
        '#################get the thread###################
        Dim tempThread As Thread = Threading.Thread.CurrentThread
        'Debug.Print(CStr(Now) + "reach thread")
        tempThread.IsBackground = True
        Dim nextIndex As Integer = UBound(mainFormThreadForRUNTime) + 1
        ReDim Preserve mainFormThreadForRUNTime(nextIndex)
        mainFormThreadForRUNTime(nextIndex) = {tempThread, "mainformruntime"}
        '#################get the thread END###################

        stopUFTClassStatusCheck = False
        Dim arryTempServerIF() As String = {""}
        Do While stopUFTClassStatusCheck = False
            ReDim arryTempServerIF(0)
            arryTempServerIF(0) = ""
            For i = 0 To UBound(ExecutionOperator.arryServerFullyInfo)
                If IsNothing(ExecutionOperator.arryServerFullyInfo(i)) = False Then


                    '################transfer server show status##############
                    Dim showServerStatus = ""
                    Select Case ExecutionOperator.arryServerFullyInfo(i)(2)
                        Case "disct"
                            showServerStatus = "DISCONNECTED"
                        Case "ready"
                            showServerStatus = "READY"
                        Case "busy"
                            showServerStatus = "BUSY"
                        Case "notlaunch"
                            showServerStatus = "READY"
                        Case "process"
                            showServerStatus = "BUSY"
                        Case "timeout"
                            showServerStatus = "TIMEOUT"
                    End Select
                    arryTempServerIF(UBound(arryTempServerIF)) = ExecutionOperator.arryServerFullyInfo(i)(1) + ":" + showServerStatus
                    ReDim Preserve arryTempServerIF(UBound(arryTempServerIF) + 1)
                    '################transfer server show status end##############
                End If
            Next
            ReDim Preserve arryTempServerIF(UBound(arryTempServerIF) - 1)
            ' Invoke(New Delegate_AddArrayToRichTB(AddressOf AddArrayToRTB_ST), RTB_ST, arryTempServerIF)
            waitTime(100)
        Loop
    End Sub
    Sub Bt_CancelPerformClick()
        Bt_Stop.PerformClick()
    End Sub
    Sub AddArrayToRTB_ST(ByRef rtb As RichTextBox, ByVal arr() As String)
        Dim tmpstr As String = ""
        For Each value In arr
            If Trim(value) <> "" Then
                tmpstr = tmpstr + vbCrLf + value
            End If
        Next
        rtb.Text = Replace(tmpstr, vbCrLf, "", 1, 1)

    End Sub



    Private Sub TB_BPTList_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TB_BPTList.KeyDown
        If e.KeyCode = Keys.A And e.Control Then
            TB_BPTList.SelectAll()
        End If
    End Sub

    Public TB_BPTList_Position As Point = Nothing
    Private Sub TB_BPTList_MouseMove(ByVal sender As Object, ByVal e As System.EventArgs) Handles TB_BPTList.MouseMove

        Dim mpoint As Point = TB_BPTList.PointToClient(Form_Main.MousePosition)
        If TB_BPTList_Position <> mpoint Then
            TB_BPTList_Position = mpoint
            If UBound(TB_BPTList.Lines) > -1 Then
                Dim cpoint = TB_BPTList.GetPositionFromCharIndex(TB_BPTList.TextLength - 1)
                If mpoint.Y <= cpoint.Y + TB_BPTList.Font.Height Then
                    Dim cx = mpoint.X + 15
                    Dim cy = mpoint.Y + 15
                    ToolTipDeleteInfo.Show(TB_BPTList.Lines(TB_BPTList.GetLineFromCharIndex(TB_BPTList.GetCharIndexFromPosition(mpoint))), TB_BPTList, cx, cy, 2000)
                End If

            End If
        End If
    End Sub


    Private Sub BT_CheckReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_CheckReport.Click

        '#############Check and then Create folder for storing run report and detail result######################
        Dim Folder_TestingResult As String
        'If TB_ReportFolder.Text.Length > DefaultValueTitle.Length Then
        '    If TB_ReportFolder.Text.Substring(0, DefaultValueTitle.Length) = DefaultValueTitle Then
        '        Folder_TestingResult = TB_ReportFolder.Text.Substring(DefaultValueTitle.Length)
        '    Else
        '        Folder_TestingResult = TB_ReportFolder.Text
        '    End If
        'Else
        '    Folder_TestingResult = TB_ReportFolder.Text
        'End If

        Folder_TestingResult = Class_FolderOperator1.returnOpenFolderPath("Select the folder which you store test report and result:")
        If Folder_TestingResult <> "" Then
            TB_ReportFolder.Text = Folder_TestingResult
        End If


        'If Folder_TestingResult <> "" Then
        '    If Class_FolderOperator1.hasFolder(Folder_TestingResult) Then
        '        MsgBox("Path was valid.")
        '    Else
        'If Class_FolderOperator1.hasFolder(Class_FolderOperator1.getUpFolderNameInStr(Folder_TestingResult)) Then
        '    Dim msgboxvalue As Integer = MsgBox("The folder path for saving report does not exist. " + vbCrLf + "ATester will create it for you. Do you agree?" + vbCrLf + Folder_TestingResult, MsgBoxStyle.YesNo)
        '    If msgboxvalue = 6 Then
        '        Class_FolderOperator1.createFolder(Folder_TestingResult)
        '    Else
        '        TB_ReportFolder.Text = DefaultValueTitle + Folder_DefaultTestingResult_Path
        '        Exit Sub
        '    End If
        'Else
        '    MsgBox("The folder path for saving report was invalid" + vbCrLf + Folder_TestingResult)

        '    TB_ReportFolder.Focus()
        '    TB_ReportFolder.SelectAll()
        '    Exit Sub
        'End If
        '    End If
        'Else
        '    MsgBox("Please path was invalid")
        '    TB_ReportFolder.Focus()
        '    TB_ReportFolder.SelectAll()
        '    Exit Sub
        'End If
        '#############Check and then Create folder for storing run report and detail result END######################


    End Sub

    Public Sub checkInputServers()
        Dim orgilCKS = BT_EditResource.Enabled
        Dim orgilesip = Bt_EditSlaveIPs.Enabled
        Dim orgilC = Bt_Stop.Enabled
        Dim orgilClose = BT_Close.Enabled
        Dim orgilCBS = CB_Servers.Enabled
        Dim orgilBTR = Bt_Run.Enabled
        Dim orgilTBS = TB_RR_Dir.Enabled
        Dim orgilCBHM = CB_HostMode.Enabled
        Dim orgilCBNR = CB_NormalRun.Enabled
        BT_EditResource.Enabled = False
        Bt_EditSlaveIPs.Enabled = False
        CB_NormalRun.Enabled = False
        Bt_Stop.Enabled = False


        BT_Close.Enabled = False
        CB_Servers.Enabled = False
        Bt_Run.Enabled = False


        TB_RR_Dir.Enabled = False
        CB_HostMode.Enabled = False
        '#############Check and then get the servers for remote######################
        Dim TBServersText As String
        If TB_RR_Dir.Text.Length > ExampleValueTitle.Length Then
            If String.Equals(TB_RR_Dir.Text.Substring(0, ExampleValueTitle.Length), ExampleValueTitle) Then
                TBServersText = TB_RR_Dir.Text.Substring(ExampleValueTitle.Length)
            Else
                TBServersText = TB_RR_Dir.Text
            End If
        Else
            TBServersText = TB_RR_Dir.Text
        End If

        Dim arryInputExcutionPath() As String = {""}
        Dim arryTempInputExcutionPath() As String = {""}
        If TBServersText = "" Then
            If Bt_Run.Enabled Then
                MsgBox("Please input the Dir, refer to the tip!")
            Else
                Class_MainFormControlHandler1.AddContentToTB(TB_MainLog, "Please input the Dir, refer to the tip!")
            End If

            GoTo EndLine
        Else
            If CB_HostMode.Checked Then
                If Mid(TBServersText, 1, 2) = "\\" Then 'must be the network path
                Else
                    If Bt_Run.Enabled Then
                        MsgBox("Dir was invalid. Please refer to the tip!")
                    Else
                        Class_MainFormControlHandler1.AddContentToTB(TB_MainLog, "Dir was invalid. Please refer to the tip!")
                    End If

                    GoTo EndLine
                End If
                If InStr(TBServersText, "@") > 0 Then
                    If Bt_Run.Enabled Then
                        MsgBox("Dir was invalid. Please refer to the tip!")
                    Else
                        Class_MainFormControlHandler1.AddContentToTB(TB_MainLog, "Dir was invalid. Please refer to the tip!")
                    End If

                    GoTo EndLine
                End If
                Dim TB_RR_IPsText = TB_RR_IPs.Text
                If Mid(TB_RR_IPsText, 1, 1) = "@" Then
                    TB_RR_IPsText = Mid(TB_RR_IPsText, 2)
                End If
                If Trim(TB_RR_IPsText) = "" Then

                    If Bt_Run.Enabled Then
                        MsgBox("IPs were invalid. Please refer to the tip!")
                    Else
                        Class_MainFormControlHandler1.AddContentToTB(TB_MainLog, "IPs were invalid. Please refer to the tip!")
                    End If
                    GoTo EndLine
                End If
                Dim IPsArray = Split(TB_RR_IPsText, "@")
                For Each ip In IPsArray

                    If RegularExpressions.Regex.IsMatch(ip, "\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}") Then
                        Dim matchedItems = RegularExpressions.Regex.Matches(ip, "\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}")
                        If matchedItems.Count = 1 Then
                            Dim ipr = ip.Replace(matchedItems(0).ToString(), "")
                            If Trim(ipr).Equals("") Then
                                Dim positionArray = Split(ip, ".")
                                For Each position In positionArray
                                    If Len(position) > 1 Then

                                        If RegularExpressions.Regex.IsMatch(position, "^0") Then
                                            If Bt_Run.Enabled Then
                                                MsgBox("IP " + ip + " was invalid. Please refer to the tip!")
                                            Else
                                                Class_MainFormControlHandler1.AddContentToTB(TB_MainLog, "IP " + ip + " was invalid. Please refer to the tip!")
                                            End If

                                            GoTo EndLine
                                        End If
                                    End If

                                    If CInt(position) > 255 Then
                                        If Bt_Run.Enabled Then
                                            MsgBox("IP " + ip + " was invalid. The IP node's length cannot be bigger than 255")
                                        Else
                                            Class_MainFormControlHandler1.AddContentToTB(TB_MainLog, "IP " + ip + " was invalid. The IP node's length cannot be bigger than 255")
                                        End If

                                        GoTo EndLine
                                    End If
                                Next
                            Else
                                If Bt_Run.Enabled Then
                                    MsgBox("IP " + ip + " was invalid. Please refer to the tip!")
                                Else
                                    Class_MainFormControlHandler1.AddContentToTB(TB_MainLog, "IP " + ip + " was invalid. Please refer to the tip!")
                                End If
                                GoTo EndLine
                            End If
                        Else
                            If Bt_Run.Enabled Then
                                MsgBox("IP " + ip + " was invalid. Please refer to the tip!")
                            Else
                                Class_MainFormControlHandler1.AddContentToTB(TB_MainLog, "IP " + ip + " was invalid. Please refer to the tip!")
                            End If
                            GoTo EndLine
                        End If
                    Else
                        If Bt_Run.Enabled Then
                            MsgBox("IP " + ip + " was invalid. Please refer to the tip!")
                        Else
                            Class_MainFormControlHandler1.AddContentToTB(TB_MainLog, "IP " + ip + " was invalid. Please refer to the tip!")
                        End If

                        GoTo EndLine
                    End If
                Next
                Dim tempArry() As String = {""}
                tempArry(0) = TBServersText
                arryShareFolders = tempArry
            Else
                arryTempInputExcutionPath = Split(TBServersText, "@")
                For i = 0 To UBound(arryTempInputExcutionPath)
                    If Trim(arryTempInputExcutionPath(i)) <> "" Then
                        arryInputExcutionPath(UBound(arryInputExcutionPath)) = Trim(arryTempInputExcutionPath(i))
                        ReDim Preserve arryInputExcutionPath(UBound(arryInputExcutionPath) + 1)
                    End If
                Next
                If UBound(arryInputExcutionPath) > 0 Then
                    ReDim Preserve arryInputExcutionPath(UBound(arryInputExcutionPath) - 1)
                End If
                If arryInputExcutionPath(0) = "" Then
                    If Bt_Run.Enabled Then
                        MsgBox("Dir was invalid. Please refer to the tip!")
                    Else
                        Class_MainFormControlHandler1.AddContentToTB(TB_MainLog, "Dir was invalid. Please refer to the tip!")
                    End If

                    GoTo EndLine
                Else
                    arryShareFolders = arryInputExcutionPath
                End If
            End If
            Dim checkNetwork As New Thread(AddressOf checkNetworkFolder)
            Class_MainFormControlHandler1.AddContentToTB(TB_MainLog, "Checking test resources' availibility.", vbCrLf)
            checkNetwork.Start()
            Do Until blnCheckNetworkFolderComplete
                Application.DoEvents()
            Loop
            If blnNetworkFolderGood Then
                Class_MainFormControlHandler1.AddContentToTB(TB_MainLog, "Test resources were ready.")
            Else
                GoTo EndLine
            End If
        End If
EndLine:
        BT_EditResource.Enabled = orgilCKS
        Bt_EditSlaveIPs.Enabled = orgilesip
        Bt_Stop.Enabled = orgilC

        BT_Close.Enabled = orgilClose
        CB_Servers.Enabled = orgilCBS
        Bt_Run.Enabled = orgilBTR

        TB_RR_Dir.Enabled = orgilTBS
        CB_HostMode.Enabled = orgilCBHM
        CB_NormalRun.Enabled = orgilCBNR
        TB_RR_Dir.Focus()
        TB_RR_Dir.SelectAll()
        '#############Check and then get the servers for remote END######################
        blnCheckNetworkFolderComplete = False
        'blnNetworkFolderGood = False'don't reset this var since it is used by Bt_RUNClik sub
        arryShareFolders = Nothing
    End Sub

    'Private Sub RTB_ST_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If RTB_ST.Text <> "" Then
    '        Dim LineStr() As String
    '        Dim statusStr As String
    '        LineStr = RTB_ST.Lines
    '        For i = 0 To UBound(LineStr)
    '            statusStr = Trim(Split(LineStr(i), ":")(1))
    '            Select Case statusStr
    '                Case "DISCONNECTED"
    '                    Dim fstC = RTB_ST.GetFirstCharIndexFromLine(i)
    '                    'RTB_ST.Focus()
    '                    Dim lastIndex = fstC + Len(LineStr(i)) - 1
    '                    Dim statLen = Len("DISCONNECTED")
    '                    Dim statuFstIndex = lastIndex - statLen + 1
    '                    RTB_ST.Select(statuFstIndex, statLen)
    '                    RTB_ST.SelectionBackColor = Color.White
    '                    RTB_ST.SelectionColor = Color.Brown

    '                Case "TIMEOUT"
    '                    Dim fstC = RTB_ST.GetFirstCharIndexFromLine(i)
    '                    'RTB_ST.Focus()
    '                    Dim lastIndex = fstC + Len(LineStr(i)) - 1
    '                    Dim statLen = Len("TIMEOUT")
    '                    Dim statuFstIndex = lastIndex - statLen + 1
    '                    RTB_ST.Select(statuFstIndex, statLen)
    '                    RTB_ST.SelectionBackColor = Color.Red
    '                    RTB_ST.SelectionColor = Color.White

    '                Case "READY"
    '                    Dim fstC = RTB_ST.GetFirstCharIndexFromLine(i)
    '                    ' RTB_ST.Focus()
    '                    Dim lastIndex = fstC + Len(LineStr(i)) - 1
    '                    Dim statLen = Len("READY")
    '                    Dim statuFstIndex = lastIndex - statLen + 1
    '                    RTB_ST.Select(statuFstIndex, statLen)
    '                    RTB_ST.SelectionBackColor = Color.Green
    '                    RTB_ST.SelectionColor = Color.White

    '                Case "BUSY"
    '                    Dim fstC = RTB_ST.GetFirstCharIndexFromLine(i)
    '                    'RTB_ST.Focus()
    '                    Dim lastIndex = fstC + Len(LineStr(i)) - 1
    '                    Dim statLen = Len("BUSY")
    '                    Dim statuFstIndex = lastIndex - statLen + 1
    '                    RTB_ST.Select(statuFstIndex, statLen)
    '                    RTB_ST.SelectionBackColor = Color.Orange
    '                    RTB_ST.SelectionColor = Color.White

    '            End Select
    '        Next
    '        RTB_ST.Select(0, 0)
    '    End If
    'End Sub


    Private Sub CB_Excel_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CB_Excel.MouseUp
        If CB_Excel.Checked Then
            CB_Excel.Enabled = False
            On Error Resume Next
            Dim xlApp As New Excel.Application
            xlApp.Visible = False
            Dim xlAppHWND As Integer = xlApp.Hwnd()
            Dim xlAppProcessID As Integer = 0
            GetWindowThreadProcessId(xlAppHWND, xlAppProcessID)
            endProcess(xlAppProcessID)
            'xlApp.Quit()
            xlApp = Nothing
            If Err.Number <> 0 Then ' this code referred the ms excel object liberary 14.0
                MsgBox("""Additional Report"" requires that your computer has installed MS Excel." + vbCrLf + "Error Code: " + CStr(Err.Number) + vbCrLf + Err.Description)
                CB_Excel.Enabled = True
                CB_Excel.Checked = False
                CB_Excel.Enabled = False
            Else
                CB_Excel.Enabled = True
            End If
            On Error GoTo 0

        End If
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
            Invoke(New Delegate_AddContentToTB(AddressOf AddMsgToTextBox), TB_MainLog, "You provided bad test dir:", vbCrLf)
            Invoke(New Delegate_AddArrayToTBWihtNewLines(AddressOf Class_MainFormControlHandler1.AddArrayToTBWihtNewLines), TB_MainLog, wrongPath)
            blnNetworkFolderGood = False
        Else
            blnNetworkFolderGood = True
            'Invoke(New Delegate_AddContentToTB(AddressOf AddMsgToTextBox), TB_MainLog, "All the network folders are good", vbCrLf)
        End If
        blnCheckNetworkFolderComplete = True
    End Sub

    Private Sub TB_RR_Dir_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TB_RR_Dir.SizeChanged
        Dim TB_RR_Dir_Point = Me.PointToClient(Me.Panel_RemoteMode.PointToScreen(TB_RR_Dir.Location))
        TB_RR_Dir_Save.Width = TB_RR_Dir.Width
        BT_Clean_RR_Dirs_Save.Location = New Point(TB_RR_Dir_Point.X + TB_RR_Dir_Save.Width - BT_Clean_RR_Dirs_Save.Width - 2, TB_RR_Dir_Point.Y + TB_RR_Dir_Save.Height + 2)
    End Sub




    Private Sub TB_Servers_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TB_RR_Dir.TextChanged
        ConfiguraionFileChange()
        CLB_ReportServerIP.Enabled = False

        If TB_RR_DirSelfchange Then
        Else
            clearCustomMissionMonitor()
            blnNetworkFolderGood = False ' this value to to tell the whold code the new value has not been validated
            RSChange = True
        End If

        If CB_HostMode.Checked Then
            Dim CLBbound = CLB_ReportServerIP.Items.Count - 1
            Dim tempstring
            tempstring = Trim(TB_RR_Dir.Text)
            If tempstring = "" Then
                TB_RR_Dir.Text = ""
                Folder_Root_Path = ""
                Folder_TestCase_Path = ""
                CLB_ReportServerIP.Items.Clear()
                For i = 0 To UBound(localIP)
                    CLB_ReportServerIP.Items.Add(localIP(i))
                Next

            Else
                If Len(tempstring) > 2 Then
                    If Mid(tempstring, 1, 2) = "\\" And InStr(tempstring, "@") = 0 Then 'Must be the network path
                        If Mid(tempstring, Len(tempstring), 1) = "\" Then
                            tempstring = Mid(tempstring, 1, Len(tempstring) - 1)
                        End If
                        Dim newHostIP = Split(tempstring, "\")(2)
                        If UBound(localIP) = CLBbound Then
                        Else
                            For i = 0 To CLBbound
                                Dim curIP = CLB_ReportServerIP.Items.Item(i)
                                Dim findIP = False
                                For j = 0 To UBound(localIP)
                                    If curIP = localIP(j) Then
                                        findIP = True
                                        Exit For
                                    End If
                                Next
                                If findIP Then
                                Else
                                    CLB_ReportServerIP.Items.RemoveAt(i)
                                    clearCLB_ReportServerIP()
                                    Exit For
                                End If
                            Next
                        End If
                        Dim findInLocalIP = False
                        For w = 0 To UBound(localIP)
                            If newHostIP = localIP(w) Then
                                findInLocalIP = True
                                Exit For
                            End If
                        Next
                        If findInLocalIP = False Then
                            CLB_ReportServerIP.Items.Add(newHostIP)
                            clearCLB_ReportServerIP()
                        End If
                        Folder_Root_Path = tempstring
                        Folder_TestCase_Path = tempstring + "\" + FolderName_BPT
                    Else
                        MsgBox("Dir was invalid. Please refer to the tip!")
                        Folder_Root_Path = ""
                        Folder_TestCase_Path = ""

                        If UBound(localIP) = CLBbound Then
                        Else
                            For i = 0 To CLBbound
                                Dim curIP = CLB_ReportServerIP.Items.Item(i)
                                Dim findIP = False
                                For j = 0 To UBound(localIP)
                                    If curIP = localIP(j) Then
                                        findIP = True
                                        Exit For
                                    End If
                                Next
                                If findIP Then
                                Else
                                    CLB_ReportServerIP.Items.RemoveAt(i)
                                    clearCLB_ReportServerIP()


                                    Exit For
                                End If
                            Next
                        End If
                    End If
                End If

            End If
        End If
        CLB_ReportServerIP.Enabled = True
    End Sub

    Private Sub TB_RR_DirClicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles TB_RR_Dir.Click
        If TB_RR_Dir_Save.Visible Then
            TB_RR_Dir_Save.Visible = False
            BT_Clean_RR_Dirs_Save.Visible = False

        Else
            TB_RR_Dir_Save.Visible = True
            TB_RR_Dir_Save.BringToFront()
            BT_Clean_RR_Dirs_Save.Visible = True
            BT_Clean_RR_Dirs_Save.BringToFront()
        End If

    End Sub

    Private Sub TB_Servers_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TB_RR_Dir.LostFocus
        TB_RR_Dir_Save.Visible = False
        BT_Clean_RR_Dirs_Save.Visible = False
    End Sub

    Private Sub Bt_Stop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bt_Stop.Click
        Dim cur = BT_Close.Enabled
        BT_Close.Enabled = Not cur
        BT_Close.Enabled = cur
        BT_Close.Enabled = False
        If ExecutionTestThreadUsed Then
            If RemoteMode Then
                Class_ExecutionOperator1.blnCancelRemote = True
                Bt_Stop.Enabled = False

            Else
                AbortExecutionTesthread = True
                Bt_Stop.Enabled = False

            End If
        Else
            AbortExecutionTesthread = True
        End If
    End Sub
    Private Sub BT_Close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Close.Click
        If RDCMOpend Then
            Dim msgval = MsgBox("Remote Desktop Connection Manager is opening, do you want to close it?", MsgBoxStyle.YesNo)
            If msgval = 6 Then
                CloseRCDM = True
                Do While RDCMOpend
                    waitTime(1000)
                Loop
            End If
        End If
        If installRDCMOpend Then
            CloseinstallRCDM = True
        End If

        If ExecutionTestThreadUsed Then
            If RemoteMode Then
                Class_ExecutionOperator1.blnCancelRemote = True
                Bt_Stop.Enabled = False


                ''###########for cancel all threads runing in pool for run BPT##########
                'Dim CancelThreadsOfRunRunBPTs As New Thread(AddressOf CancelThreadsOfRunRunBPTs_OnlyForRemote)
                'CancelThreadsOfRunRunBPTs.Start()
                'CancelThreadsOfRunRunBPTs.IsBackground = True
                'Do Until blnFinishCancelThread_R
                '    Application.DoEvents()
                'Loop
                ''###########for cancel all threads runing in pool for run BPT END##########
            Else
                AbortExecutionTesthread = True
                Bt_Stop.Enabled = False


            End If
        Else
            AbortExecutionTesthread = True
        End If
        'waitTime(1000)
        ''Thread.CurrentThread.Abort()
        'Class_MainFormControlHandler1.AddContentToTB(TB_MainLog, "Please wait to cancel running threads.")
        BT_Close.Enabled = False
        If IsNothing(shutDownThread) = False Then
            If shutDownThread.IsAlive Then
                shutDownThread.Abort()
            End If

        End If
        If IsNothing(handleformMoreControlTh) = False Then
            If handleformMoreControlTh.IsAlive Then
                handleformMoreControlTh.Abort()
            End If
        End If


        alarmRunMonitorThread.Abort()
        alarmRunMonitorThread = Nothing
        Dim closeMe As New Thread(AddressOf closeMainForm)
        closeMe.Start()
    End Sub
    Sub closeMainForm()
        Dim timeout = 60 * 5 'sec
        Dim starttime = Now
        Do While ExecutionTestThreadUsed And DateDiff("s", starttime, Now) < timeout
            Application.DoEvents()
            waitTime(1000)
        Loop
        If ExecutionTestThreadUsed Then
            Class_MainFormControlHandler1.AddContentToTB(TB_MainLog, "Unknown issue to quit UFT or staf  process. Please manually end it!")
            MsgBox("Unknown issue to quit UFT or staf process. Please manually end it!")
        Else
            Invoke(New Delegate_FormAction(AddressOf closeForm), Me)
        End If

    End Sub
    Sub closeForm(ByRef formObj As Form)
        ToolTip_Panda.SetToolTip(PictureBox_Panda, " ")
        ToolTip_Panda.Show("再见!", PictureBox_Panda, "1000")
        'TB_MainLog.AppendText("谢谢使用，再见！")
        waitTime(1000)
        Form_MissionPanel.Close()
        Form_RealTimeResult.Close()
        Form_MustDoIt.Close()
        Form_CheckSlave.Close()
        Form_Help.Close()
        Alarm.Close()
        formObj.Close()

    End Sub

    Private Sub BT_Min_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Min.Click
        Me.WindowState = FormWindowState.Minimized
        'Form_Main_Back.WindowState = FormWindowState.Minimized

        'Me.Hide()
        'NI.Visible = True
        'NI.ShowBalloonTip(50, "ATester", "Click me to open", ToolTipIcon.None)
    End Sub

    Private Sub NI_MouseClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles NI.MouseClick
        'Me.Show()
        'Me.WindowState = FormWindowState.Normal
        'NI.Visible = False
        'TB_MainLog.SelectionStart = TB_MainLog.Text.Length
        'TB_MainLog.ScrollToCaret()
    End Sub

    Private Sub TB_LC_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TB_LC.MouseClick
        If TB_LC_Save.Visible Then
            TB_LC_Save.Visible = False
            BT_Clean_LC_Save.Visible = False
        Else
            TB_LC_Save.Visible = True
            TB_LC_Save.BringToFront()
            BT_Clean_LC_Save.Visible = True
            BT_Clean_LC_Save.BringToFront()
        End If
    End Sub


    'Private Sub TB_LC_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TB_LC.MouseDown
    '  If TB_LC_Save.Visible Then
    '    TB_LC_Save.Visible = False
    '    BT_Clean_LC_Save.Visible = False
    'Else
    '    TB_LC_Save.Visible = True
    '    BT_Clean_LC_Save.Visible = True
    '    BT_Clean_LC_Save.BringToFront()
    'End If

    'End Sub

    Private Sub TB_LC_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TB_LC.LostFocus
        TB_LC_Save.Visible = False
        BT_Clean_LC_Save.Visible = False
    End Sub

    Private Sub TB_RR_IPs_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TB_RR_IPs.MouseClick
        If TB_RR_IPs_Save.Visible Then
            TB_RR_IPs_Save.Visible = False
            BT_Clean_RR_IPs_Save.Visible = False
        Else
            TB_RR_IPs_Save.Visible = True
            TB_RR_IPs_Save.BringToFront()
            BT_Clean_RR_IPs_Save.Visible = True
            BT_Clean_RR_IPs_Save.BringToFront()
        End If
    End Sub

    Private Sub TB_IP_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TB_RR_IPs.LostFocus
        TB_RR_IPs_Save.Visible = False
        BT_Clean_RR_IPs_Save.Visible = False
    End Sub

    Private Sub TB_LC_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TB_LC.TextChanged
        Dim tempstring
        tempstring = Trim(TB_LC.Text)
        If tempstring = "" Then
            Folder_Root_Path = ""
            Folder_TestCase_Path = ""
            TB_LC.Text = ""
        Else
            If Mid(tempstring, 1, 2) = "\\" Then 'disable the network path
                MsgBox("Please don't use ShareName for ""Dir"".")
                TB_LC.Text = ""
                Folder_Root_Path = ""
                Folder_TestCase_Path = ""
            Else
                If Mid(tempstring, Len(tempstring), 1) = "\" Then
                    tempstring = Mid(tempstring, 1, Len(tempstring) - 1)
                End If
                If ProjectType = "UFT Project" Then
                    Folder_Root_Path = tempstring
                    Folder_TestCase_Path = tempstring + "\" + FolderName_BPT
                End If
                If ProjectType = "Maven Project" Then
                    Folder_Root_Path = tempstring
                    Folder_TestCase_Path = tempstring + "\" + FolderName_SRC_TEST + "\java"
                End If
            End If
        End If
        ConfiguraionFileChange()
        'CheckBPTPathAndSetRelatedControls()
    End Sub
    Sub CheckBPTPathAndSetRelatedControls()
        If Class_FolderOperator1.hasFolder(Folder_TestCase_Path) = True Then
            If ProjectType = "UFT Project" Then
                Array_BPTNames = Class_FolderOperator1.getAllFolderNames(Folder_TestCase_Path) 'find all BPT names which are under BPT folder
            End If

            If ProjectType = "Maven Project" Then
                ReDim allFileNames_Temp(-1)
                findFileType(Folder_TestCase_Path, "java")
                Array_BPTNames = allFileNames_Temp
            End If

            Invoke(New Delegate_CleanCLB(AddressOf Class_MainFormControlHandler1.CleanCLB), CLB_Testlist)
            Invoke(New Delegate_CleanTB(AddressOf Class_MainFormControlHandler1.CleanTB), TB_BPTList)
            Invoke(New Delegate_AddArrayToCLB(AddressOf Class_MainFormControlHandler1.AddArrayToCLB), CLB_Testlist, Array_BPTNames)
            Invoke(New Delegate_AddArrayToTBWihtNewLines(AddressOf Class_MainFormControlHandler1.AddArrayToTBWihtNewLines), TB_BPTList, Array_BPTNames)
            Invoke(New Delegate_AddContentToTB(AddressOf Class_MainFormControlHandler1.AddContentToTB), TB_MainLog, "All TestCases' name was obtained.", vbCrLf)
        Else
            Invoke(New Delegate_CleanCLB(AddressOf Class_MainFormControlHandler1.CleanCLB), CLB_Testlist)
            Invoke(New Delegate_CleanTB(AddressOf Class_MainFormControlHandler1.CleanTB), TB_BPTList)
            Invoke(New Delegate_AddContentToTB(AddressOf Class_MainFormControlHandler1.AddContentToTB), TB_MainLog, "Directory was not exsiting: " + Folder_TestCase_Path, vbCrLf)
        End If
        blnRefreshEnd = True
    End Sub

    Public allFileNames_Temp(-1) As String
    Sub findFileType(ByVal rootPath As String, ByVal type As String)
        Dim lastSuffix As String = "." + type
        Dim findPartten As String = "*" + lastSuffix
        If Class_FolderOperator1.hasFolder(rootPath) Then
            For Each filenameInstance As String In IO.Directory.GetFiles(rootPath, findPartten)
                Dim file As IO.FileInfo = New IO.FileInfo(filenameInstance)
                Dim filename As String = file.Name
                ReDim Preserve allFileNames_Temp(UBound(allFileNames_Temp) + 1)
                allFileNames_Temp(UBound(allFileNames_Temp)) = Mid(filename, 1, filename.Length - lastSuffix.Length)
            Next
            Dim subDir() As String = Class_FolderOperator1.getAllFolderNames(rootPath)
            If UBound(subDir) > -1 Then
                For Each direct In subDir
                    findFileType(rootPath + "\" + direct, type)
                Next
            End If
        End If
    End Sub

    Sub CheckBPTList(ByVal list As Array)
        'Dim arrayWrongBPTsTemp() As String = {""}
        'For i = 0 To UBound(arrayBPTsSelected)
        '    If Class_FolderOperator1.hasFolder(Folder_BPT_Path + "\" + arrayBPTsSelected(i)) Then
        '    Else
        '        arrayWrongBPTsTemp(UBound(arrayWrongBPTsTemp)) = arrayBPTsSelected(i)
        '        ReDim Preserve arrayWrongBPTsTemp(UBound(arrayWrongBPTsTemp) + 1)
        '    End If
        'Next
        'If UBound(arrayWrongBPTsTemp) > 0 Then
        '    ReDim Preserve arrayWrongBPTsTemp(UBound(arrayWrongBPTsTemp) - 1)
        'End If
        'Dim tempStr As String = ""
        'If arrayWrongBPTsTemp(0) <> "" Then
        '    For i = 0 To UBound(arrayWrongBPTsTemp)
        '        tempStr = tempStr + "," + arrayWrongBPTsTemp(i)
        '    Next
        '    Class_MainFormControlHandler1.AddContentToTB(TB_MainLog, "Some BPTs of ""To Be Run List"" are inexistent:" + vbCrLf + Mid(tempStr, 2), vbCrLf)
        '    'MsgBox("The BPTs you want to run are inexistent." + vbCrLf + "Missed BPT's Name:" + vbCrLf + Mid(tempStr, 2))
        '    controlsStatusAfterExitClickBt_Run()
        '    Exit Sub
        'End If

        Dim arrayWrongBPTsTemp() As String = {""}
        Dim msgchecklist
        If CB_NormalRun.Checked Then
            msgchecklist = "Checking TestCase name in the directory you provided. The time spent depends on your computer speed."
        Else
            msgchecklist = "Checking TestCase name in the directory you provided. The time spent depends on your network speed."
        End If
        Invoke(New Delegate_AddContentToTB(AddressOf Class_MainFormControlHandler1.AddContentToTB), TB_MainLog, msgchecklist, vbCrLf)

        If ProjectType = "UFT Project" Then
            For i = 0 To UBound(list)
                If Class_FolderOperator1.hasFolder(Folder_TestCase_Path + "\" + list(i)) Then
                Else
                    arrayWrongBPTsTemp(UBound(arrayWrongBPTsTemp)) = list(i)
                    ReDim Preserve arrayWrongBPTsTemp(UBound(arrayWrongBPTsTemp) + 1)
                End If
            Next
        End If

        If ProjectType = "Maven Project" Then
            ReDim allFileNames_Temp(-1)
            findFileType(Folder_TestCase_Path, "java")
            For i = 0 To UBound(list)
                Dim findTestCase = False
                For Each fileName In allFileNames_Temp
                    If fileName = list(i) Then
                        findTestCase = True
                        Exit For
                    End If
                Next
                If findTestCase = False Then
                    arrayWrongBPTsTemp(UBound(arrayWrongBPTsTemp)) = list(i)
                    ReDim Preserve arrayWrongBPTsTemp(UBound(arrayWrongBPTsTemp) + 1)
                End If
            Next
        End If

        If UBound(arrayWrongBPTsTemp) > 0 Then
            ReDim Preserve arrayWrongBPTsTemp(UBound(arrayWrongBPTsTemp) - 1)
        End If
        Dim tempStr As String = ""
        If arrayWrongBPTsTemp(0) <> "" Then
            For i = 0 To UBound(arrayWrongBPTsTemp)
                tempStr = tempStr + "," + arrayWrongBPTsTemp(i)
            Next
            Invoke(New Delegate_AddContentToTB(AddressOf Class_MainFormControlHandler1.AddContentToTB), TB_MainLog, "Some BPT in your test mission was not existing:" + vbCrLf + Mid(tempStr, 2), vbCrLf)
            'MsgBox("The BPTs you want to run are inexistent." + vbCrLf + "Missed BPT's Name:" + vbCrLf + Mid(tempStr, 2))
            blnBPTlistIsRight = False
        Else
            blnBPTlistIsRight = True
        End If
        blnCheckBPTlistEnd = True
    End Sub

    Private Sub BT_LC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_LC.Click
        'find script folder
        'If TB_LC.Text = "" Then
        '    MsgBox("The path was invalid")
        'Else

        '    If Class_FolderOperator1.hasFolder(Folder_BPT_Path) = True Then
        '        MsgBox("The path was valid, please click refresh to get the 'To Be Run' list.")
        '    Else
        '        MsgBox("No BPTs found in the path:" + vbCrLf + Folder_BPT_Path)

        '    End If
        'End If
        Dim path = Class_FolderOperator1.returnOpenFolderPath("Select the top folder where test resource is:")
        If path <> "" Then
            TB_LC.Text = path
        End If


    End Sub


    Private Sub Erase_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Erase.Click
        TB_MainLog.Text = ""
    End Sub

    Private Sub TB_MainLog_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TB_MainLog.DoubleClick

        If UBound(TB_MainLog.Lines) > -1 Then ' no content in the text box
            Dim curLintext As String = TB_MainLog.Lines(TB_MainLog.GetLineFromCharIndex(TB_MainLog.GetFirstCharIndexOfCurrentLine()))
            Dim path As String = ""
            If InStr(1, curLintext, "<Report>") > 0 Then
                path = Trim(Split(curLintext, "<Report>")(1))
            End If
            If InStr(1, curLintext, "<DetailResult>") > 0 Then
                path = Trim(Split(curLintext, "<DetailResult>")(1))
            End If

            If path <> "" Then ' if no report find
                Class_FolderOperator1.openFolder(path)
            End If
        End If
    End Sub



    Private Sub TB_MainLog_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TB_MainLog.TextChanged
        If TB_MainLog.Text <> "" Then
            TB_MainLog.Select(TB_MainLog.Text.Length, 0)
            TB_MainLog.ScrollToCaret()
        End If
    End Sub

    Sub monitorRunNumberStatus()
        Dim CustomRemoteTestModel = CB_CRT.Checked And CB_Servers.Checked
        If CustomRemoteTestModel Then
            Dim waitSec = 2000
            Do While True
                Dim allImcomplete As Integer = 0
                Dim allPassed As Integer = 0
                For i = 0 To UBound(arryIPs_TBs_Relation)
                    Dim findIncomplete As Integer = 0
                    Dim findPassed As Integer = 0
                    For k = 0 To UBound(ExecutionOperator.arryRunList)
                        If IsNothing(ExecutionOperator.arryRunList(k)) = False Then
                            If arryIPs_TBs_Relation(i)(0).Text.Contains(ExecutionOperator.arryRunList(k)(2)) Then
                                If ExecutionOperator.arryRunList(k)(1) = "ready" Or ExecutionOperator.arryRunList(k)(1) = "run" Then
                                    findIncomplete = findIncomplete + 1
                                End If

                                If LCase(ExecutionOperator.arryRunList(k)(1)).Contains("pass") Then
                                    findPassed = findPassed + 1
                                End If
                            End If

                        End If

                    Next

                    'Do Until arryIPs_TBs_Relation(i)(3).IsAccessible()
                    '    Application.DoEvents()
                    '    waitTime(200)
                    'Loop
                    Invoke(New Delegate_writeLable(AddressOf writeLabel), arryIPs_TBs_Relation(i)(3), "Remaining: " + CStr(findIncomplete)) 'remaining case for custom remote task
                    allImcomplete = allImcomplete + findIncomplete
                    allPassed = allPassed + findPassed
                Next
                Invoke(New Delegate_writeLable(AddressOf writeLabel), L_Remain_Value, CStr(allImcomplete))

                Dim totalNr As Integer = 0
                For w = 0 To UBound(ExecutionOperator.arryRunList)
                    If IsNothing(ExecutionOperator.arryRunList(w)) = False Then
                        totalNr = totalNr + 1
                    End If
                Next
                Invoke(New Delegate_writeLable(AddressOf writeLabel), L_Total_Value, CStr(totalNr))
                Dim progress = CInt(((totalNr - allImcomplete) / totalNr) * 100)
                Invoke(New Delegate_writeProgressBar(AddressOf writeProgressBar), BT_Progress, progress)
                Dim passedRate = CInt((allPassed / totalNr) * 100)
                Invoke(New Delegate_writeLable(AddressOf writeLabel), L_PRValue, CStr(passedRate) + "%")

                Invoke(New Delegate_writeNIText(AddressOf writeNIText), NI, "Total: " + CStr(totalNr) + " Remaining: " + CStr(allImcomplete))
                Invoke(New Delegate_writeyourF(AddressOf writeFormText), Me, "Total: " + CStr(totalNr) + " Remaining: " + CStr(allImcomplete))
                waitTime(waitSec)
            Loop
        Else
            Dim waitSec = 2000
            Do While True
                Dim findIncomplete As Integer = 0
                Dim findPassed As Integer = 0
                For i = 0 To UBound(ExecutionOperator.arryRunList)
                    If IsNothing(ExecutionOperator.arryRunList(i)) = False Then
                        If ExecutionOperator.arryRunList(i)(1) = "ready" Or ExecutionOperator.arryRunList(i)(1) = "run" Then
                            findIncomplete = findIncomplete + 1
                        End If
                        If LCase(ExecutionOperator.arryRunList(i)(1)).Contains("pass") Then
                            findPassed = findPassed + 1
                        End If
                    End If
                Next
                Invoke(New Delegate_writeLable(AddressOf writeLabel), L_Remain_Value, CStr(findIncomplete))

                Dim totalNr As Integer = 0
                For w = 0 To UBound(ExecutionOperator.arryRunList)
                    If IsNothing(ExecutionOperator.arryRunList(w)) = False Then
                        totalNr = totalNr + 1
                    End If
                Next
                Invoke(New Delegate_writeLable(AddressOf writeLabel), L_Total_Value, CStr(totalNr))
                Dim progress = CInt(((totalNr - findIncomplete) / totalNr) * 100)
                Invoke(New Delegate_writeProgressBar(AddressOf writeProgressBar), BT_Progress, progress)
                Dim passedRate = CInt((findPassed / totalNr) * 100)
                Invoke(New Delegate_writeLable(AddressOf writeLabel), L_PRValue, CStr(passedRate) + "%")
                Invoke(New Delegate_writeNIText(AddressOf writeNIText), NI, "Total: " + CStr(totalNr) + " Remaining: " + CStr(findIncomplete))
                Invoke(New Delegate_writeyourF(AddressOf writeFormText), Me, "Total: " + CStr(totalNr) + " Remaining: " + CStr(findIncomplete))
                waitTime(waitSec)
            Loop
        End If


    End Sub
    Sub writeProgressBar(ByRef pb As Button, ByVal progress As Integer)
        Select Case progress
            Case Is <= 0
                pb.BackgroundImage = My.Resources.progress0
            Case 1 To 5
                pb.BackgroundImage = My.Resources.progress1
            Case 6 To 10
                pb.BackgroundImage = My.Resources.progress2
            Case 11 To 15
                pb.BackgroundImage = My.Resources.progress3
            Case 16 To 20
                pb.BackgroundImage = My.Resources.progress4
            Case 21 To 25
                pb.BackgroundImage = My.Resources.progress5
            Case 26 To 30
                pb.BackgroundImage = My.Resources.progress6
            Case 31 To 35
                pb.BackgroundImage = My.Resources.progress7
            Case 36 To 40
                pb.BackgroundImage = My.Resources.progress8
            Case 41 To 45
                pb.BackgroundImage = My.Resources.progress9
            Case 46 To 50
                pb.BackgroundImage = My.Resources.progress10
            Case 51 To 55
                pb.BackgroundImage = My.Resources.progress11
            Case 56 To 60
                pb.BackgroundImage = My.Resources.progress12
            Case 61 To 65
                pb.BackgroundImage = My.Resources.progress13
            Case 66 To 70
                pb.BackgroundImage = My.Resources.progress14
            Case 71 To 75
                pb.BackgroundImage = My.Resources.progress15
            Case 76 To 80
                pb.BackgroundImage = My.Resources.progress16
            Case 81 To 85
                pb.BackgroundImage = My.Resources.progress17
            Case 86 To 90
                pb.BackgroundImage = My.Resources.progress18
            Case 91 To 95
                pb.BackgroundImage = My.Resources.progress19
            Case 96 To 100
                pb.BackgroundImage = My.Resources.progress20
        End Select

        BT_Progress.Text = CStr(progress) + "%"
    End Sub
    Sub writeLabel(ByRef yourLabel As Label, ByVal msg As String)
        yourLabel.Text = msg
    End Sub
    Sub writeNIText(ByRef yourNI As NotifyIcon, ByVal msg As String)
        yourNI.Text = msg
    End Sub
    Sub writeFormText(ByRef yourF As Form, ByVal msg As String)
        yourF.Text = msg
    End Sub
    Private Sub TB_MainLog_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TB_MainLog.KeyDown

        If e.KeyCode = Keys.A And e.Control Then
            TB_MainLog.SelectAll()
        End If
    End Sub


    Private Sub SplitContainer1_Panel1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        TB_LC_Save.Visible = False
        BT_Clean_LC_Save.Visible = False
        TB_RR_Dir_Save.Visible = False
        BT_Clean_RR_Dirs_Save.Visible = False
        TB_RR_IPs_Save.Visible = False
        BT_Clean_RR_IPs_Save.Visible = False
    End Sub

    Private Sub SplitContainer1_Panel2_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        TB_LC_Save.Visible = False
        BT_Clean_LC_Save.Visible = False
        TB_RR_Dir_Save.Visible = False
        BT_Clean_RR_Dirs_Save.Visible = False
        TB_RR_IPs_Save.Visible = False
        BT_Clean_RR_IPs_Save.Visible = False
    End Sub
    'Private Sub SplitContainer2_Panel1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
    '    TB_LC_Save.Visible = False
    '    BT_Clean_LC_Save.Visible = False
    '    TB_Servers_Save.Visible = False
    '    BT_Clean_Servers_Save.Visible = False
    '    TB_RR_IPs_Save.Visible = False
    '    BT_Clean_RR_IPs_Save.Visible = False
    'End Sub
    'Private Sub SplitContainer2_Panel2_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles SplitContainer2.Panel2.MouseDown
    '    TB_LC_Save.Visible = False
    '    BT_Clean_LC_Save.Visible = False
    '    TB_Servers_Save.Visible = False
    '    BT_Clean_Servers_Save.Visible = False
    '    TB_RR_IPs_Save.Visible = False
    '    BT_Clean_RR_IPs_Save.Visible = False
    'End Sub

    Sub RecordIPs()
        If TB_RR_IPs.Text <> "" Then
            If UBound(TB_RR_IPs_Save.Lines) = -1 Then
                TB_RR_IPs_Save.AppendText(Trim(TB_RR_IPs.Text))
            Else
                Dim Find = False
                For i = 0 To UBound(TB_RR_IPs_Save.Lines)
                    If Trim(TB_RR_IPs.Text) = Trim(TB_RR_IPs_Save.Lines(i)) Then
                        Find = True
                    End If
                Next
                If Find = False Then
                    If UBound(TB_RR_IPs_Save.Lines) = -1 Then
                        TB_RR_IPs_Save.AppendText(Trim(TB_RR_IPs.Text))
                    Else
                        TB_RR_IPs_Save.AppendText(vbCrLf + Trim(TB_RR_IPs.Text))
                    End If

                End If
            End If

            Class_FileOperator1.OverWriteFileWithString(FilePath_IPLog, TB_RR_IPs_Save.Text)
        End If
    End Sub

    Private Sub TB_IP_Save_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TB_RR_IPs_Save.LostFocus
        TB_RR_IPs_Save.Visible = False
        BT_Clean_RR_IPs_Save.Visible = False
    End Sub

    Private Sub TB_IP_Save_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TB_RR_IPs_Save.MouseDown
        If UBound(TB_RR_IPs_Save.Lines) > -1 Then
            TB_RR_IPs.Text = TB_RR_IPs_Save.Lines(TB_RR_IPs_Save.GetLineFromCharIndex(TB_RR_IPs_Save.GetFirstCharIndexOfCurrentLine()))
            TB_RR_IPs.Focus()
            TB_RR_IPs.SelectAll()
        End If
    End Sub

    Public TB_RR_IPs_Save_Position As Point = Nothing
    Private Sub TB_RR_IPs_Save_MouseMove(ByVal sender As Object, ByVal e As System.EventArgs) Handles TB_RR_IPs_Save.MouseMove
        Dim mpoint As Point = TB_RR_IPs_Save.PointToClient(Form_Main.MousePosition)
        If TB_RR_IPs_Save_Position <> mpoint Then
            TB_RR_IPs_Save_Position = mpoint
            If UBound(TB_RR_IPs_Save.Lines) > -1 Then
                Dim cpoint = TB_RR_IPs_Save.GetPositionFromCharIndex(TB_RR_IPs_Save.TextLength - 1)
                If mpoint.Y <= cpoint.Y + TB_RR_IPs_Save.Font.Height Then
                    Dim cx = mpoint.X
                    Dim cy = mpoint.Y + 10
                    ToolTipDeleteInfo.Show(TB_RR_IPs_Save.Lines(TB_RR_IPs_Save.GetLineFromCharIndex(TB_RR_IPs_Save.GetCharIndexFromPosition(mpoint))), TB_RR_IPs_Save, cx, cy, 2000)
                End If
            End If
        End If
    End Sub

    Private Sub BT_IP_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Clean_RR_IPs_Save.MouseDown
        TB_RR_IPs_Save.Visible = True
        TB_RR_IPs_Save.Text = ""
        Class_FileOperator1.OverWriteFileWithString(FilePath_IPLog, "")
        waitTime(200)
        TB_RR_IPs_Save.Visible = False
    End Sub

    Private Sub BT_EditResource_EnabledChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles BT_EditResource.EnabledChanged
        If BT_EditResource.Enabled Then
            BT_EditResource.BackgroundImage = My.Resources.buttonYellowBackShort
        Else
            BT_EditResource.BackgroundImage = My.Resources.backYellowBackShortHover1
        End If
    End Sub

    'Private Sub BT_EditResource_EnabledChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles BT_EditResource.EnabledChanged
    '    If BT_EditResource.Enabled Then
    '        BT_EditResource.BackColor = globalButtonColor
    '    Else
    '        BT_EditResource.BackColor = Color.DarkGray
    '    End If

    'End Sub
    '###################
    Private Sub BT_CheckServers_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles BT_EditResource.MouseDown
        RecordServers()
        If CB_HostMode.Checked Then
            RecordIPs()
        End If
    End Sub
    Sub RecordServers()
        If TB_RR_Dir.Text <> "" Then
            If UBound(TB_RR_Dir_Save.Lines) = -1 Then
                TB_RR_Dir_Save.AppendText(Trim(TB_RR_Dir.Text))
            Else
                Dim Find = False
                For i = 0 To UBound(TB_RR_Dir_Save.Lines)
                    If Trim(TB_RR_Dir.Text) = Trim(TB_RR_Dir_Save.Lines(i)) Then
                        Find = True
                    End If
                Next
                If Find = False Then
                    If UBound(TB_RR_Dir_Save.Lines) = -1 Then
                        TB_RR_Dir_Save.AppendText(Trim(TB_RR_Dir.Text))
                    Else
                        TB_RR_Dir_Save.AppendText(vbCrLf + Trim(TB_RR_Dir.Text))
                    End If

                End If
            End If

            Class_FileOperator1.OverWriteFileWithString(FilePath_RSLog, TB_RR_Dir_Save.Text)
        End If
    End Sub

    Private Sub TTB_Servers_Save_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TB_RR_Dir_Save.LostFocus
        TB_RR_Dir_Save.Visible = False
        BT_Clean_RR_Dirs_Save.Visible = False
    End Sub

    Public TB_Servers_Save_Position As Point = Nothing
    Private Sub TTB_Servers_Save_MouseMove(ByVal sender As Object, ByVal e As System.EventArgs) Handles TB_RR_Dir_Save.MouseMove
        Dim mpoint As Point = TB_RR_Dir_Save.PointToClient(Form_Main.MousePosition)
        If TB_Servers_Save_Position <> mpoint Then
            TB_Servers_Save_Position = mpoint
            If UBound(TB_RR_Dir_Save.Lines) > -1 Then
                Dim cpoint = TB_RR_Dir_Save.GetPositionFromCharIndex(TB_RR_Dir_Save.TextLength - 1)
                If mpoint.Y <= cpoint.Y + TB_RR_Dir_Save.Font.Height Then
                    Dim cx = mpoint.X
                    Dim cy = mpoint.Y + 10
                    ToolTipDeleteInfo.Show(TB_RR_Dir_Save.Lines(TB_RR_Dir_Save.GetLineFromCharIndex(TB_RR_Dir_Save.GetCharIndexFromPosition(mpoint))), TB_RR_Dir_Save, cx, cy, 2000)
                End If
            End If
        End If
    End Sub


    Private Sub TB_Servers_Save_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TB_RR_Dir_Save.MouseDown

        If UBound(TB_RR_Dir_Save.Lines) > -1 Then
            TB_RR_Dir.Text = TB_RR_Dir_Save.Lines(TB_RR_Dir_Save.GetLineFromCharIndex(TB_RR_Dir_Save.GetFirstCharIndexOfCurrentLine()))
            TB_RR_Dir.Focus()
            TB_RR_Dir.SelectAll()

        End If
    End Sub

    Private Sub BT_Clean_Servers_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Clean_RR_Dirs_Save.MouseDown
        TB_RR_Dir_Save.Visible = True
        TB_RR_Dir_Save.Text = ""
        Class_FileOperator1.OverWriteFileWithString(FilePath_RSLog, "")
        waitTime(200)
        TB_RR_Dir_Save.Visible = False
    End Sub

    Private Sub BT_LC_EnabledChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles BT_LC.EnabledChanged
        If BT_LC.Enabled Then
            BT_LC.BackgroundImage = My.Resources.buttonYellowBackShort
        Else
            BT_LC.BackgroundImage = My.Resources.backYellowBackShortHover1
        End If
    End Sub

    '###################
    Private Sub BT_LC_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles BT_LC.MouseDown
        RecordLC()
    End Sub
    Sub RecordLC()
        If TB_LC.Text <> "" Then
            If UBound(TB_LC_Save.Lines) = -1 Then
                TB_LC_Save.AppendText(Trim(TB_LC.Text))
            Else
                Dim Find = False
                For i = 0 To UBound(TB_LC_Save.Lines)
                    If Trim(TB_LC.Text) = Trim(TB_LC_Save.Lines(i)) Then
                        Find = True
                    End If
                Next
                If Find = False Then
                    If UBound(TB_LC_Save.Lines) = -1 Then
                        TB_LC_Save.AppendText(Trim(TB_LC.Text))
                    Else
                        TB_LC_Save.AppendText(vbCrLf + Trim(TB_LC.Text))
                    End If

                End If
            End If

            Class_FileOperator1.OverWriteFileWithString(FilePath_LCLog, TB_LC_Save.Text)
        End If
    End Sub
    Private Sub TB_LC_Save_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TB_LC_Save.LostFocus
        TB_LC_Save.Visible = False
        BT_Clean_LC_Save.Visible = False
    End Sub

    Private Sub TB_LC_Save_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TB_LC_Save.MouseDown
        If UBound(TB_LC_Save.Lines) > -1 Then
            TB_LC.Text = TB_LC_Save.Lines(TB_LC_Save.GetLineFromCharIndex(TB_LC_Save.GetFirstCharIndexOfCurrentLine()))
            TB_LC.Focus()
            TB_LC.SelectAll()
        End If
    End Sub
    Public TB_LC_Save_Position As Point = Nothing

    Private Sub TB_LC_Save_MouseMove(ByVal sender As Object, ByVal e As System.EventArgs) Handles TB_LC_Save.MouseMove
        Dim mpoint As Point = TB_LC_Save.PointToClient(Form_Main.MousePosition)
        If TB_LC_Save_Position <> mpoint Then
            TB_LC_Save_Position = mpoint
            If UBound(TB_LC_Save.Lines) > -1 Then
                Dim cpoint = TB_LC_Save.GetPositionFromCharIndex(TB_LC_Save.TextLength - 1)
                If mpoint.Y <= cpoint.Y + TB_LC_Save.Font.Height Then
                    Dim cx = mpoint.X
                    Dim cy = mpoint.Y + 10
                    ToolTipDeleteInfo.Show(TB_LC_Save.Lines(TB_LC_Save.GetLineFromCharIndex(TB_LC_Save.GetCharIndexFromPosition(mpoint))), TB_LC_Save, cx, cy, 2000)
                End If
            End If
        End If

    End Sub

    Private Sub BT_Clean_LC_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Clean_LC_Save.MouseDown
        TB_LC_Save.Visible = True
        TB_LC_Save.Text = ""
        Class_FileOperator1.OverWriteFileWithString(FilePath_LCLog, "")
        waitTime(200)
        TB_LC_Save.Visible = False
    End Sub

    Private Sub BT_IMBPT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_IMBPT.Click
        Dim path = Class_FolderOperator1.returnOpenFilePath()
        Class_MainFormControlHandler1.AddTextToTB(TB_BPTList, path)
        Class_MainFormControlHandler1.AddTextToCLB(CLB_Testlist, path)
    End Sub

    Private Sub BT_EXTBPT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_EXTBPT.Click
        If RadioButton_Listbox.Checked Then
            Dim temp() As String = Nothing
            For i = 0 To CLB_Testlist.Items.Count - 1
                ReDim Preserve temp(i)
                temp(i) = CLB_Testlist.Items.Item(i)
            Next
            If IsNothing(temp) Then
                Class_FileOperator1.OverWriteAllText(Class_FolderOperator1.returnSaveFilePath(), {""})
            Else
                Class_FileOperator1.OverWriteAllText(Class_FolderOperator1.returnSaveFilePath(), temp)
            End If
        End If
        If RadioButton_Textbox.Checked Then
            Class_FileOperator1.OverWriteFileWithString(Class_FolderOperator1.returnSaveFilePath(), TB_BPTList.Text)
        End If


    End Sub

    Private Sub TB_BPTList_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TB_BPTList.TextChanged
        ConfiguraionFileChange()
        If RadioButton_Textbox.Checked Then
            Dim linecount = 0
            For i = 0 To UBound(TB_BPTList.Lines)
                If Trim(Replace(TB_BPTList.Lines(i), Chr(9), "")) <> "" Then
                    linecount = linecount + 1
                End If
            Next
            L_TBRTotal.Text = CStr(linecount)
        End If
    End Sub

    Private Sub SetModuleCasesToList(ByVal casesList As String)

    End Sub

    Private Sub CLB_Testlist_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CLB_Testlist.MouseUp
        L_TBRTotal.Text = CStr(CLB_Testlist.CheckedItems.Count)
    End Sub

    'Public CLB_Testlist_Position As Point = Nothing
    'Private Sub CLB_TestlistMouseMove(ByVal sender As Object, ByVal e As System.EventArgs) Handles CLB_Testlist.MouseMove

    '    Dim mpoint As Point = CLB_Testlist.PointToClient(Form_Main.MousePosition)
    '    If CLB_Testlist_Position <> mpoint Then
    '        CLB_Testlist_Position = mpoint
    '        Dim singleheight = CLB_Testlist.PreferredHeight / CLB_Testlist.Items.Count
    '        For i = 1 To CLB_Testlist.Items.Count
    '            If mpoint.Y < i * singleheight And mpoint.Y > (i - 1) * singleheight Then
    '                Dim cx = mpoint.X + 15
    '                Dim cy = mpoint.Y + 15
    '                ToolTipDeleteInfo.Show(CLB_Testlist.Items.Item(i - 1), CLB_Testlist, cx, cy, 2000)
    '            End If
    '        Next
    '    End If
    'End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExpandButton.Click
        'Me.Hide()
        If expandlist Then
            origalWidth = Me.Width
            diff = origalWidth - (ExpandButton.Location.X + ExpandButton.Width + 14)
            Me.Width = origalWidth - diff
            TB_FormBack.Width = Me.Width




            'L_Version.Location = New Point(TB_FormBack.Width - L_Version.Size.Width - 2, L_TopBar.Height + L_TopBar.Location.Y + 2)
            ' ExpandButton.Text = ">"
            ExpandButton.BackgroundImage = My.Resources.expand
            expandlist = False
            Button_TopBar_Back.Width = TB_FormBack.Width
            ToolStrip.Width = Button_TopBar_Back.Width + 4
            'MenuStrip.Width = Button_TopBar_Back.Width

            'Button_Menu_Split.Location = New Point(MenuStrip.Location.X, MenuStrip.Location.Y + MenuStrip.Height)

            L_Tool_Split.Location = New Point(0, ToolStrip.Location.Y + ToolStrip.Height - 1)
            L_Tool_Split.Width = ToolStrip.Width + 2
            BT_TopBar.Width = Button_TopBar_Back.Width - PictureBox_Panda.Width - PictureBox_Panda.Location.X - 1
            BT_Min.Location = New Point(Button_TopBar_Back.Width - BT_Close.Width - BT_Min.Width - 3, 0)
            BT_Min.BringToFront()
            BT_bottom.Location = New Point(TB_FormBack.Location.X, TB_FormBack.Location.Y + TB_FormBack.Height - BT_bottom.Height)
            BT_bottom.Width = TB_FormBack.Width
            BT_bottom.BringToFront()
            BT_Close.Location = New Point(Button_TopBar_Back.Width - BT_Close.Width - 2, 0)
            BT_Close.BringToFront()
            ProgressBar_Run_top.Parent = Me
            ProgressBar_Run_top.BringToFront()
        Else
            Me.Width = origalWidth
            TB_FormBack.Width = origalWidth


            'L_Version.Location = New Point(TB_FormBack.Width - L_Version.Size.Width - 2, L_TopBar.Height + L_TopBar.Location.Y + 2)
            'ExpandButton.Text = "<"
            ExpandButton.BackgroundImage = My.Resources.adduct

            expandlist = True

            Button_TopBar_Back.Width = TB_FormBack.Width
            ToolStrip.Width = Button_TopBar_Back.Width + 4
            'MenuStrip.Width = Button_TopBar_Back.Width

            ' Button_Menu_Split.Location = New Point(MenuStrip.Location.X, MenuStrip.Location.Y + MenuStrip.Height)

            L_Tool_Split.Location = New Point(0, ToolStrip.Location.Y + ToolStrip.Height - 1)
            L_Tool_Split.Width = ToolStrip.Width + 2
            BT_TopBar.Width = Button_TopBar_Back.Width - PictureBox_Panda.Width - PictureBox_Panda.Location.X - 1
            BT_Min.Location = New Point(Button_TopBar_Back.Width - BT_Close.Width - BT_Min.Width - 3, 0)
            BT_Min.BringToFront()
            BT_bottom.Location = New Point(TB_FormBack.Location.X, TB_FormBack.Location.Y + TB_FormBack.Height - BT_bottom.Height)
            BT_bottom.Width = TB_FormBack.Width
            BT_bottom.BringToFront()
            BT_Close.Location = New Point(Button_TopBar_Back.Width - BT_Close.Width - 2, 0)
            BT_Close.BringToFront()
            ProgressBar_Run_top.Parent = Me
            ProgressBar_Run_top.BringToFront()
        End If
        Me.Show()
    End Sub

    Public hostmode_TB_RR_Dir_Width As Integer
    Public hostmode_BT_EditResource_Location As Point
    Private Sub CB_hostserver_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CB_HostMode.CheckedChanged


        If CB_HostModelSelfchange = False Then
            RSChangeTime = 0
            IPsChangeTime = 0

            ReDim Items_LV_Standby_Slave_Remote(-1)
            ReDim Items_LV_Standby_Mission_Remote(-1)
            clearCustomMissionMonitor()
        End If

        If CB_HostMode.Checked Then

            Bt_Refresh.Enabled = True

            LibraryToolStripMenuItem.Enabled = True
            Label_RRDir.Text = "Host Test Res Dir"
            TB_RR_Dir.Width = hostmode_TB_RR_Dir_Width
            BT_EditResource.Location = hostmode_BT_EditResource_Location

            TB_RR_IPs.BackColor = Color.White
            'Label_RR_IPs.BackColor = globalLabelColor
            TB_RR_IPs.Show()
            Label_RR_IPs.Show()
            Bt_EditSlaveIPs.Show()

            Dim currentText = TB_RR_Dir.Text
            TB_RR_DirSelfchange = True
            TB_RR_Dir.Text = " "
            TB_RR_Dir.Text = currentText
            TB_RR_DirSelfchange = False
            'BT_OpenLib.Enabled = True
            L_Tip_RunResult.Visible = True
            L_Tip_RunResult_info = "DetailRes will be saved in above path of machine which the ""Result Server IP"" specifies."
            L_ReportServerIP.Show()
            P_ReportIP_back.Show()
            CLB_ReportServerIP.Show()
            CLB_ReportServerIP.BringToFront()
            'CB_Excel.Width = L_ReportServerIP.Location.X - CB_Excel.Location.X - 3
            BT_CheckReport.Location = New Point(L_ReportServerIP.Location.X - BT_CheckReport.Width - 8, BT_CheckReport.Location.Y)

            TB_ReportFolder_R.Size = New Size(BT_CheckReport.Location.X - TB_ReportFolder_R.Location.X - 6, TB_ReportFolder_R.Height)
            L_Tip_RunResult.Location = New Point(TB_ReportFolder_R.Location.X + TB_ReportFolder_R.Width - L_Tip_RunResult.Width - 1, L_Reporting.Location.Y + L_Reporting.Height + 1)
            L_Tip_RunResult.BringToFront()
            'If CB_HostModelSelfchange = False Then
            '    MsgBox("1. Please be noted that the Host Model requires a high speed network enviroment during the machines where you ran ATester, stores UFT test resource and execute UFT test!" + vbCrLf + "2. Please ensure the machines where execute UFT test has full control permission of the folder C:\ATester_RemoteRun of machine where you ran the ATester!")
            'End If

        Else
            Bt_Refresh.Enabled = False
            TB_RR_Dir.Width = TB_RR_IPs.Location.X + TB_RR_IPs.Width - TB_RR_Dir.Location.X
            BT_EditResource.Location = Bt_EditSlaveIPs.Location
            LibraryToolStripMenuItem.Enabled = False
            Label_RRDir.Text = "Slave Test Res Dirs"
            TB_RR_IPs.Hide()
            Label_RR_IPs.Hide()
            Bt_EditSlaveIPs.Hide()
            L_Tip_RunResult.Visible = True
            L_Tip_RunResult_info = "DetailRes will be saved in above path of machines which the ""Slave IPs"" specify."
            CLB_ReportServerIP.Hide()
            P_ReportIP_back.Hide()
            L_ReportServerIP.Hide()

            'CB_Excel.Width = Button_Report_Back.Location.X + Button_Report_Back.Width - CB_Excel.Location.X - 3
            BT_CheckReport.Location = New Point(Button_Report_Back.Location.X + Button_Report_Back.Width - BT_CheckReport.Width - 8, TB_ReportFolder.Location.Y - 4)

            TB_ReportFolder_R.Size = New Size(BT_CheckReport.Location.X - TB_ReportFolder_R.Location.X - 6, TB_ReportFolder_R.Height)
            L_Tip_RunResult.Location = New Point(TB_ReportFolder_R.Location.X + TB_ReportFolder_R.Width - L_Tip_RunResult.Width - 1, L_Reporting.Location.Y + L_Reporting.Height + 1)
            L_Tip_RunResult.BringToFront()
        End If
        HostModel = CB_HostMode.Checked And CB_Servers.Checked
        CustomRemoteTestModel = CB_CRT.Checked And CB_Servers.Checked
    End Sub

    Private Sub Bt_MoreRemote_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bt_MissionPanel.Click
        ConfiguraionFileChange()
        If IsRUNClicked = False Then
            Me.Enabled = False
        End If
        Dim errorinput As Boolean = False
        'Form_MoreRemoteSetting.Visible = True
        'Form_MissionPanel.Hide()
        Form_MissionPanel.BT_Close.Enabled = True
        'Dim newpoint As Point = Me.PointToScreen(Me.Location)
        'Form_MoreRemoteSetting.Location = Form_MoreRemoteSetting.PointToClient(newpoint)
        CB_NormalRun.Enabled = False


        If CB_HostMode.Checked = True Then
            IPsChangeTime = IPsChangeTime + 1
            If IPsChange = True Or IPsChangeTime = 1 Or RSChange = True Then
                IPsChange = False
                RSChange = False
                If UBound(arryIPs_TBs_Relation) > -1 Then
                    Form_MissionPanel.L_ListForIP.AutoSize = False
                    Form_MissionPanel.L_ListForIP.Size = New Size(0, 0)
                    Form_MissionPanel.L_ListForIP.Location = New Point(0, 0)
                    Form_MissionPanel.L_ListForIP.Text = ""
                    Form_MissionPanel.L_ListForIP.Visible = False
                    Form_MissionPanel.Label_slaveinfo.Visible = False
                    Form_MissionPanel.BT_GTFAT.Size = New Size(0, 0)
                    Form_MissionPanel.BT_GTFAT.Location = New Point(0, 0)
                    Form_MissionPanel.BT_GTFAT.Visible = False
                    Form_MissionPanel.L_BT_GTFAT.Size = New Size(0, 0)
                    Form_MissionPanel.L_BT_GTFAT.Location = New Point(0, 0)
                    Form_MissionPanel.L_BT_GTFAT.Visible = False
                    Form_MissionPanel.Panel_Content.Visible = False
                    'remove the BT and TBs
                    For i = 0 To UBound(arryIPs_TBs_Relation)
                        arryIPs_TBs_Relation(i)(0).Size = New Size(0, 0)
                        arryIPs_TBs_Relation(i)(1).Size = New Size(0, 0)
                        arryIPs_TBs_Relation(i)(2).Size = New Size(0, 0)
                        arryIPs_TBs_Relation(i)(3).Size = New Size(0, 0)
                        arryIPs_TBs_Relation(i)(0).Text = ""
                        arryIPs_TBs_Relation(i)(1).Text = ""
                        arryIPs_TBs_Relation(i)(2).Text = ""
                        arryIPs_TBs_Relation(i)(3).Text = ""
                        arryIPs_TBs_Relation(i)(0).Tag = ""
                        arryIPs_TBs_Relation(i)(1).Tag = ""
                        arryIPs_TBs_Relation(i)(2).Tag = ""
                        arryIPs_TBs_Relation(i)(3).Tag = ""
                        Form_MissionPanel.Panel_Content.Controls.Remove(arryIPs_TBs_Relation(i)(0))
                        Form_MissionPanel.Panel_Content.Controls.Remove(arryIPs_TBs_Relation(i)(1))
                        Form_MissionPanel.Panel_Content.Controls.Remove(arryIPs_TBs_Relation(i)(2))
                        Form_MissionPanel.Panel_Content.Controls.Remove(arryIPs_TBs_Relation(i)(3))
                    Next
                    ReDim arryIPs_TBs_Relation(-1)
                End If

                Dim arryTempIPsPath() As String = {""}
                Dim arryInputIPsPath(-1) As String
                Dim TBIPsText As String
                If TB_RR_IPs.Text.Length > ExampleValueTitle.Length Then
                    If String.Equals(TB_RR_IPs.Text.Substring(0, ExampleValueTitle.Length), ExampleValueTitle) Then
                        TBIPsText = TB_RR_IPs.Text.Substring(ExampleValueTitle.Length)
                    Else
                        TBIPsText = TB_RR_IPs.Text
                    End If
                Else
                    TBIPsText = TB_RR_IPs.Text
                End If

                arryTempIPsPath = Split(TBIPsText, "@")
                Dim tempString As String
                For i = 0 To UBound(arryTempIPsPath)
                    tempString = Trim(arryTempIPsPath(i))
                    If tempString <> "" Then
                        If Mid(tempString, Len(tempString), 1) = "\" Then
                            tempString = Mid(tempString, 1, Len(tempString) - 1)
                        End If
                        ReDim Preserve arryInputIPsPath(UBound(arryInputIPsPath) + 1)
                        arryInputIPsPath(UBound(arryInputIPsPath)) = tempString

                    End If
                Next
                If UBound(arryInputIPsPath) <= -1 Or Trim(TB_RR_Dir.Text) = "" Then
                    'Form_MoreRemoteSetting.Panel_Content.AutoScroll = False
                    'Form_MoreRemoteSetting.Panel_Content.AutoSize = False
                    'Form_MoreRemoteSetting.L_IPWrong.Visible = True
                    'Form_MoreRemoteSetting.Panel_Content.Visible = False
                    'Form_MoreRemoteSetting.L_IPWrong.Location = New Point(5, 30)
                    'Form_MoreRemoteSetting.L_IPWrong.Text = "The Host Dir or IPs you inputted was wrong. Please refer to the tip!"

                    'Form_MoreRemoteSetting.Size = New Size(Form_MoreRemoteSetting.L_IPWrong.Width + Form_MoreRemoteSetting.Bt_CloseMoreRemoteSetting.Width + 20, Form_MoreRemoteSetting.L_IPWrong.Size.Height + 40)
                    'Form_MoreRemoteSetting.L_TopBar.Width = Form_MoreRemoteSetting.Width - 24
                    'Form_MoreRemoteSetting.Bt_CloseMoreRemoteSetting.Location = New Point(Form_MoreRemoteSetting.Width - Form_MoreRemoteSetting.Bt_CloseMoreRemoteSetting.Width - 3, 3)

                    MsgBox("The Dir or IPs you provided in Running Mode is wrong!")
                    errorinput = True
                    Me.Enabled = True
                    ' Me.BringToFront()
                    CB_NormalRun.Enabled = True
                    IPsChangeTime = 0
                Else

                    Form_MissionPanel.Panel_Content.AutoScroll = False
                    Form_MissionPanel.Panel_Content.AutoSize = False

                    Form_MissionPanel.L_IPWrong.Text = ""
                    Form_MissionPanel.L_IPWrong.Visible = False
                    Dim startInver As Integer = 5
                    Dim BTX As Integer = 20
                    Dim BTY As Integer = 0
                    Dim BTH As Integer = 26
                    Dim BTW As Integer = 120
                    Dim TBW As Integer = 400
                    Dim TBH As Integer = 200
                    Dim Label_slaveinfo_Localtion = 30
                    Dim TB_IPs_Location = BTX + BTW - BTX
                    Dim ScorllW As Integer = 20
                    IPBTW = BTW
                    Dim BTHinterval As Integer = 25
                    Dim rowinterval As Integer = 5
                    Dim firstButtonDistence As Integer = 10
                    Dim FMRSH As Integer = 400
                    Dim L_ListForIP_H As Integer = 80
                    ReDim arryIPs_TBs_Relation(UBound(arryInputIPsPath))
                    Form_MissionPanel.Panel_Main.Location = New Point(1, Form_MissionPanel.BT_TopBar.Location.Y + Form_MissionPanel.BT_TopBar.Height)
                    Form_MissionPanel.BT_GTFAT.Visible = True
                    Form_MissionPanel.BT_GTFAT.Size = New Size(75, 41)
                    Form_MissionPanel.L_BT_GTFAT.Visible = True
                    Form_MissionPanel.L_BT_GTFAT.Size = New Size(Form_MissionPanel.BT_GTFAT.Width, Form_MissionPanel.BT_GTFAT.Height)

                    Form_MissionPanel.L_BT_GTFAT.SendToBack()
                    Form_MissionPanel.Label_slaveinfo.Visible = True


                    Form_MissionPanel.Panel_Content.Visible = True
                    Form_MissionPanel.L_ListForIP.Visible = True
                    Form_MissionPanel.L_ListForIP.Size = New Size(TBW, L_ListForIP_H)
                    Form_MissionPanel.L_ListForIP.Location = New Point(TB_IPs_Location, 0)

                    Form_MissionPanel.BT_GTFAT.Location = New Point(Label_slaveinfo_Localtion + 5, Form_MissionPanel.L_ListForIP.Height / 2 - Form_MissionPanel.BT_GTFAT.Height / 2)
                    Form_MissionPanel.L_BT_GTFAT.Location = New Point(Form_MissionPanel.BT_GTFAT.Location.X - 2, Form_MissionPanel.BT_GTFAT.Location.Y + 2)

                    Form_MissionPanel.Panel_Content.Location = New Point(1, Form_MissionPanel.L_ListForIP.Location.Y + Form_MissionPanel.L_ListForIP.Height)
                    Form_MissionPanel.Label_slaveinfo.Location = New Point(Label_slaveinfo_Localtion, 2)

                    For i = 0 To UBound(arryInputIPsPath)
                        Dim BT_IPs As New Button
                        Form_MissionPanel.Panel_Content.Controls.Add(BT_IPs)
                        BT_IPs.Visible = True
                        BT_IPs.AutoSize = False
                        BT_IPs.Name = "DynBT" + CStr(i)
                        BT_IPs.Location = New Point(BTX, startInver + (BTY + i) * BTHinterval)
                        BT_IPs.Size = New Size(BTW, BTH)
                        BT_IPs.Text = arryInputIPsPath(i)
                        BT_IPs.Font = New System.Drawing.Font("Calibri", 8, FontStyle.Regular, GraphicsUnit.Point)
                        BT_IPs.TextAlign = ContentAlignment.MiddleLeft
                        BT_IPs.BackColor = Color.WhiteSmoke
                        BT_IPs.ForeColor = Color.Black
                        BT_IPs.FlatStyle = FlatStyle.Flat
                        BT_IPs.FlatAppearance.BorderColor = Color.DarkGray
                        BT_IPs.FlatAppearance.BorderSize = 1
                        BT_IPs.TabStop = False
                        BT_IPs.FlatAppearance.MouseOverBackColor = Color.Cyan
                        AddHandler BT_IPs.MouseEnter, AddressOf ShowText
                        AddHandler BT_IPs.Click, AddressOf ShiftTB_IPs
                        Dim TB_IPs As New TextBox
                        Form_MissionPanel.Panel_Content.Controls.Add(TB_IPs)
                        TB_IPs.Visible = True
                        TB_IPs.Font = New System.Drawing.Font("Calibri", 9, FontStyle.Regular, GraphicsUnit.Point)
                        TB_IPs.Name = "DynTB" + CStr(i)
                        TB_IPs.BorderStyle = BorderStyle.None
                        TB_IPs.Location = New Point(TB_IPs_Location, Form_MissionPanel.Label_slaveinfo.Location.Y)
                        TB_IPs.ReadOnly = False
                        TB_IPs.Multiline = True
                        TB_IPs.ScrollBars = ScrollBars.Both
                        TB_IPs.TabStop = False
                        TB_IPs.ShortcutsEnabled = True

                        If ((UBound(arryInputIPsPath) + 1) * BTHinterval + BTHinterval) > FMRSH Then
                            TB_IPs.Size = New Size(TBW, (UBound(arryInputIPsPath) + 1) * BTHinterval + BTHinterval + startInver)
                        Else
                            TB_IPs.Size = New Size(TBW, FMRSH)
                        End If
                        TB_IPs.BorderStyle = BorderStyle.None
                        TB_IPs.WordWrap = False
                        AddHandler TB_IPs.TextChanged, AddressOf showtotal
                        AddHandler TB_IPs.KeyDown, AddressOf keyprocess

                        Dim L_Total_IPs As New Label
                        Form_MissionPanel.L_ListForIP.Controls.Add(L_Total_IPs)
                        L_Total_IPs.Name = "DynLT" + CStr(i)
                        L_Total_IPs.Visible = True
                        L_Total_IPs.AutoSize = True
                        L_Total_IPs.BorderStyle = BorderStyle.None
                        L_Total_IPs.Font = New System.Drawing.Font("Calibri", 9, FontStyle.Regular, GraphicsUnit.Point)
                        L_Total_IPs.BackColor = Color.Transparent
                        L_Total_IPs.Text = "Number of tests: 0"
                        L_Total_IPs.Tag = "0"
                        L_Total_IPs.ForeColor = Color.Black
                        L_Total_IPs.TabStop = False
                        L_Total_IPs.Location = New Point(Form_MissionPanel.L_ListForIP.Width - L_Total_IPs.Width - 1, Form_MissionPanel.L_ListForIP.Height - L_Total_IPs.Height - 1)

                        Dim L_Remaining_IPs As New Label
                        Form_MissionPanel.L_ListForIP.Controls.Add(L_Remaining_IPs)
                        L_Remaining_IPs.Name = "DynLR" + CStr(i)
                        L_Remaining_IPs.Visible = True
                        L_Remaining_IPs.AutoSize = True
                        L_Remaining_IPs.BorderStyle = BorderStyle.None
                        L_Remaining_IPs.Font = New System.Drawing.Font("Calibri", 9, FontStyle.Regular, GraphicsUnit.Point)
                        L_Remaining_IPs.BackColor = Color.White
                        L_Remaining_IPs.Text = "Remaining: 0"
                        L_Remaining_IPs.Tag = "0"
                        L_Remaining_IPs.ForeColor = Color.Black
                        L_Remaining_IPs.TabStop = False
                        L_Remaining_IPs.Location = New Point(1, Form_MissionPanel.L_ListForIP.Height - L_Remaining_IPs.Height - 1)
                        L_Remaining_IPs.Visible = False
                        Dim BPTArry(-1) As Object
                        arryIPs_TBs_Relation(i) = {BT_IPs, TB_IPs, L_Total_IPs, L_Remaining_IPs, BPTArry}


                    Next
                    ' arryIPs_TBs_Relation(0)(0).FlatAppearance.BorderColor = Color.Black
                    arryIPs_TBs_Relation(0)(0).Location = New Point(firstButtonDistence, arryIPs_TBs_Relation(0)(0).Location.Y)
                    arryIPs_TBs_Relation(0)(0).BackColor = Color.White
                    arryIPs_TBs_Relation(0)(0).ForeColor = Color.Black
                    'arryIPs_TBs_Relation(0)(0).FlatAppearance.BorderColor = Color.Gainsboro
                    arryIPs_TBs_Relation(0)(0).Font = New System.Drawing.Font("Arial", 9, FontStyle.Regular, GraphicsUnit.Point)
                    arryIPs_TBs_Relation(0)(0).Tag = isTopButton
                    arryIPs_TBs_Relation(0)(0).BringToFront()
                    arryIPs_TBs_Relation(0)(1).BringToFront()
                    arryIPs_TBs_Relation(0)(1).Focus()
                    arryIPs_TBs_Relation(0)(2).BringToFront()
                    arryIPs_TBs_Relation(0)(3).BringToFront()

                    If ((UBound(arryInputIPsPath) + 1) * BTHinterval + BTHinterval) > FMRSH Then
                        Form_MissionPanel.Label_slaveinfo.Size = New Size(Form_MissionPanel.Label_slaveinfo.Width, (UBound(arryInputIPsPath) + 1) * BTHinterval + BTHinterval + startInver)
                    Else
                        Form_MissionPanel.Label_slaveinfo.Size = New Size(Form_MissionPanel.Label_slaveinfo.Width, FMRSH)
                    End If

                    Form_MissionPanel.L_ListForIP.Text = IPSListTitle + """" + arryInputIPsPath(0) + """"

                    Form_MissionPanel.Panel_Content.SendToBack()
                    Form_MissionPanel.Panel_Content.AutoScroll = True
                    Form_MissionPanel.Panel_Content.Size = New Size(BTW + Form_MissionPanel.L_ListForIP.Width + 30, FMRSH + 20)


                    Form_MissionPanel.Panel_Main.Size = New Size(Form_MissionPanel.Panel_Content.Width + 2, Form_MissionPanel.Panel_Content.Height + Form_MissionPanel.Panel_Content.Location.Y + 20)

                    Form_MissionPanel.Size = New Size(Form_MissionPanel.Panel_Main.Width + 2, Form_MissionPanel.Panel_Main.Height + Form_MissionPanel.Panel_Main.Location.Y + 1)
                    Form_MissionPanel.BT_TopBar.Width = Form_MissionPanel.Width - 2
                    Form_MissionPanel.BT_Close.Location = New Point(Form_MissionPanel.BT_TopBar.Width - Form_MissionPanel.BT_Close.Width - 1, 0)
                    Form_MissionPanel.Label_slaveinfo.SendToBack()

                    Form_MissionPanel.L_Note.Parent = Form_MissionPanel.L_ListForIP
                    Form_MissionPanel.L_Note.Location = New Point(0, 0)
                    Form_MissionPanel.L_Note.BringToFront()
                End If
            End If
        Else
            RSChangeTime = RSChangeTime + 1
            If RSChange = True Or RSChangeTime = 1 Then
                RSChange = False
                IPsChange = False
                If UBound(arryIPs_TBs_Relation) > -1 Then
                    Form_MissionPanel.L_ListForIP.AutoSize = False
                    Form_MissionPanel.L_ListForIP.Size = New Size(0, 0)
                    Form_MissionPanel.L_ListForIP.Location = New Point(0, 0)
                    Form_MissionPanel.L_ListForIP.Text = ""
                    Form_MissionPanel.L_ListForIP.Visible = False
                    Form_MissionPanel.Label_slaveinfo.Visible = False
                    Form_MissionPanel.BT_GTFAT.Size = New Size(0, 0)
                    Form_MissionPanel.BT_GTFAT.Location = New Point(0, 0)
                    Form_MissionPanel.BT_GTFAT.Visible = False
                    Form_MissionPanel.L_BT_GTFAT.Size = New Size(0, 0)
                    Form_MissionPanel.L_BT_GTFAT.Location = New Point(0, 0)
                    Form_MissionPanel.L_BT_GTFAT.Visible = False
                    Form_MissionPanel.Panel_Content.Visible = False
                    'remove the BT and TBs
                    For i = 0 To UBound(arryIPs_TBs_Relation)
                        arryIPs_TBs_Relation(i)(0).Size = New Size(0, 0)
                        arryIPs_TBs_Relation(i)(1).Size = New Size(0, 0)
                        arryIPs_TBs_Relation(i)(2).Size = New Size(0, 0)
                        arryIPs_TBs_Relation(i)(3).Size = New Size(0, 0)
                        arryIPs_TBs_Relation(i)(0).Text = ""
                        arryIPs_TBs_Relation(i)(1).Text = ""
                        arryIPs_TBs_Relation(i)(2).Text = ""
                        arryIPs_TBs_Relation(i)(3).Text = ""
                        arryIPs_TBs_Relation(i)(0).Tag = ""
                        arryIPs_TBs_Relation(i)(1).Tag = ""
                        arryIPs_TBs_Relation(i)(2).Tag = ""
                        arryIPs_TBs_Relation(i)(3).Tag = ""

                        Form_MissionPanel.Panel_Content.Controls.Remove(arryIPs_TBs_Relation(i)(0))
                        Form_MissionPanel.Panel_Content.Controls.Remove(arryIPs_TBs_Relation(i)(1))
                        Form_MissionPanel.Panel_Content.Controls.Remove(arryIPs_TBs_Relation(i)(2))
                        Form_MissionPanel.Panel_Content.Controls.Remove(arryIPs_TBs_Relation(i)(3))
                    Next
                    ReDim arryIPs_TBs_Relation(-1)
                End If

                Dim arryTempIPsPath() As String = {""}
                Dim arryInputIPsPath(-1) As String
                Dim TBRRDsText As String
                If TB_RR_Dir.Text.Length > ExampleValueTitle.Length Then
                    If String.Equals(TB_RR_Dir.Text.Substring(0, ExampleValueTitle.Length), ExampleValueTitle) Then
                        TBRRDsText = TB_RR_Dir.Text.Substring(ExampleValueTitle.Length)
                    Else
                        TBRRDsText = TB_RR_Dir.Text
                    End If
                Else
                    TBRRDsText = TB_RR_Dir.Text
                End If

                arryTempIPsPath = Split(TBRRDsText, "@")
                Dim tempString As String
                For i = 0 To UBound(arryTempIPsPath)
                    tempString = Trim(arryTempIPsPath(i))
                    If tempString <> "" Then
                        If Mid(tempString, Len(tempString), 1) = "\" Then
                            tempString = Mid(tempString, 1, Len(tempString) - 1)
                        End If
                        ReDim Preserve arryInputIPsPath(UBound(arryInputIPsPath) + 1)
                        arryInputIPsPath(UBound(arryInputIPsPath)) = tempString

                    End If
                Next
                If UBound(arryInputIPsPath) <= -1 Then
                    'Form_MoreRemoteSetting.Panel_Content.AutoScroll = False
                    'Form_MoreRemoteSetting.Panel_Content.AutoSize = False
                    'Form_MoreRemoteSetting.Panel_Content.Visible = False
                    'Form_MoreRemoteSetting.L_IPWrong.Visible = True
                    'Form_MoreRemoteSetting.L_IPWrong.Location = New Point(5, 30)
                    'Form_MoreRemoteSetting.L_IPWrong.Text = "The Dir you inputted was wrong. Please refer to the tip!"
                    'Form_MoreRemoteSetting.Size = New Size(Form_MoreRemoteSetting.L_IPWrong.Width + Form_MoreRemoteSetting.Bt_CloseMoreRemoteSetting.Width + 20, Form_MoreRemoteSetting.L_IPWrong.Size.Height + 40)
                    'Form_MoreRemoteSetting.L_TopBar.Width = Form_MoreRemoteSetting.Width - 24
                    'Form_MoreRemoteSetting.Bt_CloseMoreRemoteSetting.Location = New Point(Form_MoreRemoteSetting.Width - Form_MoreRemoteSetting.Bt_CloseMoreRemoteSetting.Width - 3, 3)

                    MsgBox("The Dir or IPs you provided in Running Mode is wrong!")
                    errorinput = True
                    Me.Enabled = True
                    'Me.BringToFront()
                    CB_NormalRun.Enabled = True
                    RSChangeTime = 0
                Else


                    Form_MissionPanel.Panel_Content.AutoScroll = False
                    Form_MissionPanel.Panel_Content.AutoSize = False

                    Form_MissionPanel.L_IPWrong.Text = ""
                    Form_MissionPanel.L_IPWrong.Visible = False
                    Dim startInver As Integer = 5
                    Dim BTX As Integer = 20
                    Dim BTY As Integer = 0
                    Dim BTH As Integer = 26
                    Dim BTW As Integer = 120
                    Dim TBW As Integer = 400
                    Dim TBH As Integer = 200
                    Dim ScorllW As Integer = 20
                    IPBTW = BTW
                    Dim BTHinterval As Integer = 25
                    Dim rowinterval As Integer = 5
                    Dim firstButtonDistence = 10
                    Dim Label_slaveinfo_Localtion = 30
                    Dim TB_IPs_Location = BTX + BTW - BTX
                    Dim FMRSH As Integer = 400
                    Dim L_ListForIP_H As Integer = 80
                    ReDim arryIPs_TBs_Relation(UBound(arryInputIPsPath))
                    Form_MissionPanel.Panel_Main.Location = New Point(1, Form_MissionPanel.BT_TopBar.Location.Y + Form_MissionPanel.BT_TopBar.Height)

                    Form_MissionPanel.BT_GTFAT.Visible = True
                    Form_MissionPanel.BT_GTFAT.Size = New Size(75, 41)

                    Form_MissionPanel.L_BT_GTFAT.Visible = True
                    Form_MissionPanel.L_BT_GTFAT.Size = New Size(Form_MissionPanel.BT_GTFAT.Width, Form_MissionPanel.BT_GTFAT.Height)

                    Form_MissionPanel.L_BT_GTFAT.SendToBack()
                    Form_MissionPanel.Label_slaveinfo.Visible = True
                    Form_MissionPanel.Panel_Content.Visible = True
                    Form_MissionPanel.L_ListForIP.Visible = True
                    Form_MissionPanel.L_ListForIP.Location = New Point(TB_IPs_Location, 0)
                    Form_MissionPanel.L_ListForIP.Size = New Size(TBW, L_ListForIP_H)
                    Form_MissionPanel.BT_GTFAT.Location = New Point(Label_slaveinfo_Localtion + 5, Form_MissionPanel.L_ListForIP.Height / 2 - Form_MissionPanel.BT_GTFAT.Height / 2)
                    Form_MissionPanel.L_BT_GTFAT.Location = New Point(Form_MissionPanel.BT_GTFAT.Location.X - 2, Form_MissionPanel.BT_GTFAT.Location.Y + 2)


                    Form_MissionPanel.Panel_Content.Location = New Point(1, Form_MissionPanel.L_ListForIP.Location.Y + Form_MissionPanel.L_ListForIP.Height)
                    Form_MissionPanel.Label_slaveinfo.Location = New Point(Label_slaveinfo_Localtion, 2)

                    For i = 0 To UBound(arryInputIPsPath)
                        Dim BT_IPs As New Button
                        Form_MissionPanel.Panel_Content.Controls.Add(BT_IPs)
                        BT_IPs.Visible = True
                        BT_IPs.AutoSize = False
                        BT_IPs.Name = "DynBT" + CStr(i)
                        BT_IPs.Location = New Point(BTX, startInver + (BTY + i) * BTHinterval)
                        BT_IPs.Size = New Size(BTW, BTH)
                        BT_IPs.Text = arryInputIPsPath(i)
                        BT_IPs.Font = New System.Drawing.Font("Calibri", 8, FontStyle.Regular, GraphicsUnit.Point)
                        BT_IPs.TextAlign = ContentAlignment.MiddleLeft
                        BT_IPs.BackColor = Color.WhiteSmoke
                        BT_IPs.ForeColor = Color.Black
                        BT_IPs.FlatStyle = FlatStyle.Flat
                        BT_IPs.FlatAppearance.BorderColor = Color.DarkGray
                        BT_IPs.FlatAppearance.BorderSize = 1
                        BT_IPs.TabStop = False
                        BT_IPs.FlatAppearance.MouseOverBackColor = Color.Cyan
                        AddHandler BT_IPs.MouseEnter, AddressOf ShowText
                        AddHandler BT_IPs.Click, AddressOf ShiftTB_IPs
                        Dim TB_IPs As New TextBox
                        Form_MissionPanel.Panel_Content.Controls.Add(TB_IPs)
                        TB_IPs.Visible = True
                        TB_IPs.Font = New System.Drawing.Font("Calibri", 9, FontStyle.Regular, GraphicsUnit.Point)
                        TB_IPs.Name = "DynTB" + CStr(i)
                        TB_IPs.Location = New Point(TB_IPs_Location, Form_MissionPanel.Label_slaveinfo.Location.Y)
                        TB_IPs.ReadOnly = False
                        TB_IPs.Multiline = True
                        TB_IPs.ScrollBars = ScrollBars.Both
                        TB_IPs.TabStop = False
                        TB_IPs.ShortcutsEnabled = True
                        If ((UBound(arryInputIPsPath) + 1) * BTHinterval + BTHinterval) > FMRSH Then
                            TB_IPs.Size = New Size(TBW, (UBound(arryInputIPsPath) + 1) * BTHinterval + BTHinterval + startInver)
                        Else
                            TB_IPs.Size = New Size(TBW, FMRSH)
                        End If
                        TB_IPs.BorderStyle = BorderStyle.None
                        TB_IPs.WordWrap = False
                        AddHandler TB_IPs.TextChanged, AddressOf showtotal
                        AddHandler TB_IPs.KeyDown, AddressOf keyprocess


                        Dim L_Total_IPs As New Label
                        Form_MissionPanel.L_ListForIP.Controls.Add(L_Total_IPs)
                        L_Total_IPs.Name = "DynLT" + CStr(i)
                        L_Total_IPs.Visible = True
                        L_Total_IPs.AutoSize = True
                        L_Total_IPs.BorderStyle = BorderStyle.None
                        L_Total_IPs.Font = New System.Drawing.Font("Calibri", 9, FontStyle.Regular, GraphicsUnit.Point)
                        L_Total_IPs.BackColor = Color.Transparent
                        L_Total_IPs.Text = "Number of tests: 0"
                        L_Total_IPs.Tag = "0"
                        L_Total_IPs.ForeColor = Color.Black
                        L_Total_IPs.TabStop = False
                        L_Total_IPs.Location = New Point(Form_MissionPanel.L_ListForIP.Width - L_Total_IPs.Width - 1, Form_MissionPanel.L_ListForIP.Height - L_Total_IPs.Height - 1)

                        Dim L_Remaining_IPs As New Label
                        Form_MissionPanel.L_ListForIP.Controls.Add(L_Remaining_IPs)
                        L_Remaining_IPs.Name = "DynLR" + CStr(i)
                        L_Remaining_IPs.Visible = True
                        L_Remaining_IPs.AutoSize = True
                        L_Remaining_IPs.BorderStyle = BorderStyle.None
                        L_Remaining_IPs.Font = New System.Drawing.Font("Calibri", 9, FontStyle.Regular, GraphicsUnit.Point)
                        L_Remaining_IPs.BackColor = Color.Transparent
                        L_Remaining_IPs.Text = "Remaining: 0"
                        L_Remaining_IPs.Tag = "0"
                        L_Remaining_IPs.ForeColor = Color.Black
                        L_Remaining_IPs.TabStop = False
                        L_Remaining_IPs.Location = New Point(1, Form_MissionPanel.L_ListForIP.Height - L_Remaining_IPs.Height - 1)
                        L_Remaining_IPs.Visible = False
                        Dim BPTArry(-1) As Object
                        arryIPs_TBs_Relation(i) = {BT_IPs, TB_IPs, L_Total_IPs, L_Remaining_IPs, BPTArry}
                    Next

                    'arryIPs_TBs_Relation(0)(0).FlatAppearance.BorderColor = Color.Black
                    arryIPs_TBs_Relation(0)(0).Location = New Point(firstButtonDistence, arryIPs_TBs_Relation(0)(0).Location.Y)
                    arryIPs_TBs_Relation(0)(0).BackColor = Color.White
                    arryIPs_TBs_Relation(0)(0).ForeColor = Color.Black
                    arryIPs_TBs_Relation(0)(0).Font = New System.Drawing.Font("Calibri", 9, FontStyle.Regular, GraphicsUnit.Point)
                    arryIPs_TBs_Relation(0)(0).Tag = isTopButton
                    arryIPs_TBs_Relation(0)(0).BringToFront()
                    arryIPs_TBs_Relation(0)(1).BringToFront()
                    arryIPs_TBs_Relation(0)(1).Focus()
                    arryIPs_TBs_Relation(0)(2).BringToFront()
                    arryIPs_TBs_Relation(0)(3).BringToFront()

                    If ((UBound(arryInputIPsPath) + 1) * BTHinterval + BTHinterval) > FMRSH Then
                        Form_MissionPanel.Label_slaveinfo.Size = New Size(Form_MissionPanel.Label_slaveinfo.Width, (UBound(arryInputIPsPath) + 1) * BTHinterval + BTHinterval + startInver)
                    Else
                        Form_MissionPanel.Label_slaveinfo.Size = New Size(Form_MissionPanel.Label_slaveinfo.Width, FMRSH)
                    End If

                    Form_MissionPanel.L_ListForIP.Text = IPSListTitle + """" + arryInputIPsPath(0) + """"
                    Form_MissionPanel.Panel_Content.SendToBack()
                    Form_MissionPanel.Panel_Content.AutoScroll = True
                    Form_MissionPanel.Panel_Content.Size = New Size(BTW + Form_MissionPanel.L_ListForIP.Width + 30, FMRSH + 20)

                    Form_MissionPanel.Panel_Main.Size = New Size(Form_MissionPanel.Panel_Content.Width + 2, Form_MissionPanel.Panel_Content.Height + Form_MissionPanel.Panel_Content.Location.Y + 20)

                    Form_MissionPanel.Size = New Size(Form_MissionPanel.Panel_Main.Width + 2, Form_MissionPanel.Panel_Main.Height + Form_MissionPanel.Panel_Main.Location.Y + 1)

                    Form_MissionPanel.BT_TopBar.Width = Form_MissionPanel.Width - 2
                    Form_MissionPanel.BT_Close.Location = New Point(Form_MissionPanel.BT_TopBar.Width - Form_MissionPanel.BT_Close.Width - 1, 0)
                    Form_MissionPanel.Label_slaveinfo.SendToBack()

                    Form_MissionPanel.L_Note.Parent = Form_MissionPanel.L_ListForIP
                    Form_MissionPanel.L_Note.Location = New Point(0, 0)
                    Form_MissionPanel.L_Note.BringToFront()
                End If
            End If
        End If
        If errorinput = False Then
            Form_MissionPanel.Show()
        End If



    End Sub
    Sub showtotal()
        Dim totalLineCount = 0
        For i = 0 To UBound(arryIPs_TBs_Relation)

            Dim linecount = 0
            For r = 0 To UBound(arryIPs_TBs_Relation(i)(1).Lines)
                If Trim(Replace(arryIPs_TBs_Relation(i)(1).Lines(r), vbTab, "")) <> "" Then
                    linecount = linecount + 1
                End If
            Next

            arryIPs_TBs_Relation(i)(2).Tag = linecount
            arryIPs_TBs_Relation(i)(2).Text = "Number of tests: " + CStr(linecount)
            arryIPs_TBs_Relation(i)(2).Location = New Point(Form_MissionPanel.L_ListForIP.Width - arryIPs_TBs_Relation(i)(2).Width - 1, Form_MissionPanel.L_ListForIP.Height - arryIPs_TBs_Relation(i)(2).Height - 1)


            For r = 0 To UBound(arryIPs_TBs_Relation(i)(1).Lines)
                If Trim(Replace(arryIPs_TBs_Relation(i)(1).Lines(r), vbTab, "")) <> "" Then
                    totalLineCount = totalLineCount + 1
                End If
            Next
        Next

        Form_MissionPanel.L_AllTotal_IPs.Parent = Form_MissionPanel.L_ListForIP
        Form_MissionPanel.L_AllTotal_IPs.Visible = True
        Form_MissionPanel.L_AllTotal_IPs.AutoSize = True
        Form_MissionPanel.L_AllTotal_IPs.BorderStyle = BorderStyle.None
        Form_MissionPanel.L_AllTotal_IPs.Font = New System.Drawing.Font("Arial", 9, FontStyle.Regular, GraphicsUnit.Point)
        Form_MissionPanel.L_AllTotal_IPs.BackColor = Color.Transparent
        Form_MissionPanel.L_AllTotal_IPs.Text = "Total: " + CStr(totalLineCount)
        Form_MissionPanel.L_AllTotal_IPs.ForeColor = Color.Black
        Form_MissionPanel.L_AllTotal_IPs.TabStop = False
        Form_MissionPanel.L_AllTotal_IPs.Location = New Point(Form_MissionPanel.L_ListForIP.Width - Form_MissionPanel.L_AllTotal_IPs.Width - 1, 1)

    End Sub
    Sub ShowText()
        Dim unObject As New Object
        Dim MPoint As Point
        MPoint = Form_MissionPanel.Panel_Content.PointToClient(Form_MissionPanel.MousePosition)
        unObject = Form_MissionPanel.Panel_Content.GetChildAtPoint(MPoint)
        Form_MissionPanel.ToolTip_BTIPS.Show(unObject.text, unObject)
    End Sub

    Sub ShiftTB_IPs()
        'Form_MissionPanel.Enabled = False
        Dim unBT As New Object
        Dim MPoint As Point
        MPoint = Form_MissionPanel.Panel_Content.PointToClient(Form_MissionPanel.MousePosition)
        unBT = Form_MissionPanel.Panel_Content.GetChildAtPoint(MPoint)
        Dim x1 = 20
        Dim x2 = 10
        For i = 0 To UBound(arryIPs_TBs_Relation)
            arryIPs_TBs_Relation(i)(0).BackColor = Color.WhiteSmoke
            arryIPs_TBs_Relation(i)(0).Font = New System.Drawing.Font("Calibri", 8, FontStyle.Regular, GraphicsUnit.Point)
            arryIPs_TBs_Relation(i)(0).ForeColor = Color.Black
            'arryIPs_TBs_Relation(i)(0).FlatAppearance.BorderColor = Color.DarkGray
            arryIPs_TBs_Relation(i)(0).Location = New Point(x1, arryIPs_TBs_Relation(i)(0).Location.Y)
            'arryIPs_TBs_Relation(i)(0).Size = New Size(IPBTW, unBT.Size.Height)
            arryIPs_TBs_Relation(i)(0).Tag = "n"
            If arryIPs_TBs_Relation(i)(0).Name = unBT.Name Then

                unBT.Tag = isTopButton
                unBT.BackColor = Color.White
                unBT.ForeColor = Color.Black
                'unBT.FlatAppearance.BorderColor = Color.Black
                unBT.Font = New System.Drawing.Font("Calibri", 9, FontStyle.Regular, GraphicsUnit.Point)
                unBT.Location = New Point(x2, unBT.Location.Y)
                'unBT.Size = New Size(IPBTW, unBT.Size.Height)

                unBT.BringToFront()

                arryIPs_TBs_Relation(i)(1).BringToFront()
                arryIPs_TBs_Relation(i)(2).BringToFront()
                arryIPs_TBs_Relation(i)(3).BringToFront()
                Form_MissionPanel.L_ListForIP.Text = IPSListTitle + """" + arryIPs_TBs_Relation(i)(0).Text + """"
                'Form_MissionPanel.Enabled = True
                'arryIPs_TBs_Relation(i)(1).Focus()
                Form_MissionPanel.L_BT_GTFAT.Focus()
            End If
        Next

        'If Form_MissionPanel.Enabled = False Then
        '    Form_MissionPanel.Enabled = True
        'End If

    End Sub

    Private Sub TB_RR_IPs_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TB_RR_IPs.TextChanged
        IPsChange = True
        ConfiguraionFileChange()
        clearCustomMissionMonitor()
    End Sub


    Private Sub CB_CRT_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CB_CRT.CheckedChanged
        ConfiguraionFileChange()
        If CB_CRTSelfchange = False Then
            ReDim Items_LV_Standby_Slave_Remote(-1)
            ReDim Items_LV_Standby_Mission_Remote(-1)



            If CB_CRT.Checked Then

                Panel_CustomMissionPanel.Visible = True
                Panel_TestMissionPanel.Visible = False
                L_TestMissionTitle.Parent = Panel_CustomMissionPanel

                CB_CRT.Parent = Panel_CustomMissionPanel
                L_TestMissionTitle.BringToFront()

                CB_CRT.BringToFront()
            Else


                Panel_CustomMissionPanel.Visible = False
                Panel_TestMissionPanel.Visible = True
                L_TestMissionTitle.Parent = Panel_TestMissionPanel

                CB_CRT.Parent = Panel_TestMissionPanel
                L_TestMissionTitle.BringToFront()

                CB_CRT.BringToFront()
            End If
        End If

        If CB_CRT.Checked Then
            Bt_MissionPanel.Enabled = True

            TB_OneTimeNumber.BackColor = Color.LightGray
            TB_OneTimeNumber.Enabled = False
        Else
            Bt_MissionPanel.Enabled = False

            TB_OneTimeNumber.Enabled = True
            TB_OneTimeNumber.BackColor = Color.White
        End If
        CustomRemoteTestModel = CB_CRT.Checked And CB_Servers.Checked

    End Sub

    'Private Sub BT_Min_EnabledChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles BT_Min.EnabledChanged
    '    If BT_Min.Enabled Then
    '        BT_Min.BackColor = Color.White
    '    Else
    '        BT_Min.BackColor = Color.LightGray
    '    End If

    'End Sub

    'Private Sub BT_Close_EnabledChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles BT_Close.EnabledChanged
    '    If BT_Close.Enabled Then
    '        BT_Close.BackColor = Color.Black
    '        CloseToolStripMenuItem.Enabled = True
    '    Else
    '        BT_Close.BackColor = Color.LightGray
    '        CloseToolStripMenuItem.Enabled = False
    '    End If
    'End Sub

    'Private Sub ExpandButton_EnabledChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ExpandButton.EnabledChanged
    '    If ExpandButton.Enabled Then
    '        ExpandButton.BackColor = globalButtonColor
    '    Else
    '        ExpandButton.BackColor = Color.LightGray
    '    End If
    'End Sub


    Private Sub Link_RTR_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles Link_RTR.LinkClicked
        If IsRUNClicked Then
            Me.Link_RTR.Enabled = False
            refrechTestStatus()
            Form_RealTimeResult.Show()
        Else
            MsgBox("No real-time report right now!", MsgBoxStyle.OkOnly)
        End If

    End Sub
    Public Sub refrechTestStatus()
        'Form_RealTimeResult.Hide()
        'Form_RealTimeResult.Visible = True

        Dim cacheRL = ExecutionOperator.arryRunList
        If IsNothing(cacheRL) Then
        Else
            Form_RealTimeResult.ListView_RTR.Sorting = SortOrder.None
            Form_RealTimeResult.ListView_RTR.Clear()
            Form_RealTimeResult.ListView_RTR.Columns.Add("Test Name")
            Form_RealTimeResult.ListView_RTR.Columns.Add("Status")
            Form_RealTimeResult.ListView_RTR.Columns.Add("Executed on IP")
            Form_RealTimeResult.ListView_RTR.Columns.Add("Result Path")
            Form_RealTimeResult.ListView_RTR.Columns.Item(0).Width = 200
            Form_RealTimeResult.ListView_RTR.Columns.Item(1).Width = 100
            Form_RealTimeResult.ListView_RTR.Columns.Item(2).Width = 150
            Form_RealTimeResult.ListView_RTR.Columns.Item(3).Width = 600
            Form_RealTimeResult.ListView_RTR.Columns.Item(0).TextAlign = HorizontalAlignment.Center
            Form_RealTimeResult.ListView_RTR.Columns.Item(1).TextAlign = HorizontalAlignment.Center
            Form_RealTimeResult.ListView_RTR.Columns.Item(2).TextAlign = HorizontalAlignment.Center
            Form_RealTimeResult.ListView_RTR.Columns.Item(3).TextAlign = HorizontalAlignment.Left
            Dim rowF = -1
            For i = 0 To UBound(cacheRL)
                If IsNothing(cacheRL(i)) = False Then

                    If cacheRL(i)(2) <> "Local" Then
                        Dim cacheRP = ""

                        If ProjectType = "UFT Project" Then
                            If HostModel Then
                                cacheRP = RunTimeResult_TestResultPath + "\" + cacheRL(i)(2)
                            Else
                                cacheRP = "[On " + cacheRL(i)(2) + "] " + RunTimeResult_TestResultPath
                            End If
                        End If
                        If ProjectType = "Maven Project" Then
                            If HostModel Then
                                cacheRP = RunTimeResult_TestResultPath + "\" + cacheRL(i)(2)
                            Else
                                cacheRP = "[On " + cacheRL(i)(2) + "] " + cacheRL(i)(3)
                            End If
                        End If
                        'name
                        rowF = rowF + 1
                        Form_RealTimeResult.ListView_RTR.Items.Add(cacheRL(i)(0))

                        'status
                        If cacheRL(i)(1) = "ready" Then
                            Form_RealTimeResult.ListView_RTR.Items.Item(rowF).SubItems.Add("TOBERUN")
                        Else
                            Form_RealTimeResult.ListView_RTR.Items.Item(rowF).SubItems.Add(UCase(cacheRL(i)(1)))
                        End If
                        'ip
                        Form_RealTimeResult.ListView_RTR.Items.Item(rowF).SubItems.Add(cacheRL(i)(2))
                        'report path
                        If cacheRL(i)(1).Contains("done") Then
                            If ProjectType = "UFT Project" Then
                                Form_RealTimeResult.ListView_RTR.Items.Item(rowF).SubItems.Add(cacheRP + "\" + cacheRL(i)(0) + "\Report")
                            End If
                            If ProjectType = "Maven Project" Then
                                Form_RealTimeResult.ListView_RTR.Items.Item(rowF).SubItems.Add(cacheRP)
                            End If
                        Else
                            Form_RealTimeResult.ListView_RTR.Items.Item(rowF).SubItems.Add("")
                        End If
                    Else
                        Dim cacheRP = Class_ExecutionOperator1.strTestResultPath
                        'name
                        rowF = rowF + 1
                        Form_RealTimeResult.ListView_RTR.Items.Add(cacheRL(i)(0))
                        'status
                        If cacheRL(i)(1) = "ready" Then
                            Form_RealTimeResult.ListView_RTR.Items.Item(rowF).SubItems.Add("TOBERUN")
                        Else
                            Form_RealTimeResult.ListView_RTR.Items.Item(rowF).SubItems.Add(UCase(cacheRL(i)(1)))
                        End If
                        'ip
                        Form_RealTimeResult.ListView_RTR.Items.Item(rowF).SubItems.Add("Local")
                        'report path
                        If cacheRL(i)(1).Contains("done") Then
                            If ProjectType = "UFT Project" Then
                                Form_RealTimeResult.ListView_RTR.Items.Item(rowF).SubItems.Add(cacheRP + "\" + cacheRL(i)(0) + "\Report")
                            End If
                            If ProjectType = "Maven Project" Then
                                Form_RealTimeResult.ListView_RTR.Items.Item(rowF).SubItems.Add(cacheRL(i)(3))
                            End If

                        Else
                            Form_RealTimeResult.ListView_RTR.Items.Item(rowF).SubItems.Add("")
                        End If

                    End If
                End If

            Next
            Form_RealTimeResult.ListView_RTR.Sorting = SortOrder.Ascending
            Form_RealTimeResult.ListView_RTR.Sort()
        End If

    End Sub

    Private Sub TB_LC_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles TB_LC.MouseHover
        ToolTipDeleteInfo.Show(TB_LC.Text, TB_LC, 15000)
    End Sub

    Private Sub TB_ReportFolder_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles TB_ReportFolder.MouseHover
        'waitTime(200)
        ToolTipDeleteInfo.Show(TB_ReportFolder.Text, TB_ReportFolder, 15000)
    End Sub

    Private Sub TB_RR_IPs_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles TB_RR_IPs.MouseHover
        'waitTime(200)
        ToolTipDeleteInfo.Show(TB_RR_IPs.Text, TB_RR_IPs, 15000)
    End Sub


    Private Sub TB_RR_Dir_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles TB_RR_Dir.MouseHover
        ToolTipDeleteInfo.Show(TB_RR_Dir.Text, TB_RR_Dir, 15000)
    End Sub
    Sub keyprocess()
        For i = 0 To UBound(arryIPs_TBs_Relation)
            If arryIPs_TBs_Relation(i)(0).Tag = isTopButton Then
                Form_MissionPanel.tempTaskTB = arryIPs_TBs_Relation(i)(1)
                Exit For
            End If
        Next
    End Sub



    'Public CLB_ReportServerIP_Position As Point = Nothing
    'Private Sub CLB_ReportServerIPMouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles CLB_ReportServerIP.MouseMove

    '    Dim mpoint As Point = CLB_ReportServerIP.PointToClient(Form_Main.MousePosition)
    '    If CLB_ReportServerIP_Position <> mpoint Then
    '        CLB_ReportServerIP_Position = mpoint
    '        Dim singleheight = CLB_ReportServerIP.PreferredHeight / CLB_ReportServerIP.Items.Count
    '        Dim currentShowedItemsIndexes() As Integer
    '        ReDim currentShowedItemsIndexes(-1)
    '        Dim number = -1
    '        For h = 1 To CLB_ReportServerIP.Items.Count
    '            If CLB_ReportServerIP.DisplayRectangle.Contains(New Point(0, h * singleheight)) Then
    '                number = number + 1
    '                ReDim Preserve currentShowedItemsIndexes(number)
    '                currentShowedItemsIndexes(UBound(currentShowedItemsIndexes)) = h - 1
    '            End If
    '        Next

    '        For i = 1 To UBound(currentShowedItemsIndexes) + 1
    '            If mpoint.Y < i * singleheight And mpoint.Y > (i - 1) * singleheight Then
    '                Dim cx = mpoint.X + 15
    '                Dim cy = mpoint.Y + 15
    '                ToolTipDeleteInfo.Show(CLB_ReportServerIP.Items.Item(currentShowedItemsIndexes(i - 1)), CLB_ReportServerIP, cx, cy, 2000)
    '            End If
    '        Next
    '    End If
    'End Sub

    Private Sub CLB_AesterIP_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CLB_ReportServerIP.SelectedIndexChanged

        If CLB_ReportServerIP.SelectedItems.Count > 0 Then
            Dim currentSelected = CLB_ReportServerIP.SelectedItems.Item(0)

            CLB_ReportServerIP.Enabled = False
            For i = 1 To CLB_ReportServerIP.Items.Count
                If currentSelected = CLB_ReportServerIP.Items.Item(i - 1) Then
                Else
                    CLB_ReportServerIP.SetItemChecked(i - 1, False)
                End If
            Next

            isLocalIPForReport = 0
            If CLB_ReportServerIP.CheckedItems.Count = 0 Then
            Else
                Dim newChecked = CLB_ReportServerIP.CheckedItems.Item(0)

                For j = 0 To UBound(localIP)
                    If newChecked = localIP(j) Then
                        isLocalIPForReport = 1
                        Exit For
                    End If
                Next
                If isLocalIPForReport <> 1 Then
                    isLocalIPForReport = 2
                End If

                If OtherIP <> newChecked Then

                    If isLocalIPForReport = 2 Then

                        Dim st = intialTestResultFolderForOtherServer(newChecked)
                        If st = 1 Then
                            OtherIP = newChecked
                        End If
                    End If


                End If
            End If


            CLB_ReportServerIP.Enabled = True
        End If


    End Sub
    Dim previousActionLocation As Object = Nothing
    Function intialTestResultFolderForOtherServer(ByVal serverName)

        notificationActionCode = 0 '1 - donotconfig, 2-configured,3- stoprun, 4 - previous, 5-confirmed,6-cancelorstoprun
        Form_MustDoIt.Bt_Donot.Visible = False
        Form_MustDoIt.Bt_Configured.Visible = False
        Form_MustDoIt.Bt_StopRun.Visible = False
        Form_MustDoIt.Bt_Previous.Visible = False
        Form_MustDoIt.Bt_confirmed.Visible = False
        Form_MustDoIt.Bt_Cancel.Visible = False

        Dim stateCode = 0 '1 -confired,2- cancelorstoprun

        If IsNothing(previousActionLocation) Then
            Form_MustDoIt.Close()
            Dim strYear As Integer
            Dim strMonth As Integer
            Dim strDay As Integer
            Dim strNow As Date = Now
            strYear = DatePart("yyyy", strNow)
            strMonth = DatePart("m", strNow)
            strDay = DatePart("d", strNow)
            Dim strDate As String = CStr(strYear) + "-" + CStr(strMonth) + "-" + CStr(strDay)
            Dim newTimeForFolderOfOtherServerReport = strDate + "_" + CStr(Hour(strNow)) + "-" + CStr(Minute(strNow)) + "-" + CStr(Second(strNow))
            strSharedFolderPathOfOtherServerReport = "C:\ATester_RemoteRun\Round" + newTimeForFolderOfOtherServerReport + "\DetailRes"
            strSharedFolderNameOfOtherServerReport = "DetailRes" + newTimeForFolderOfOtherServerReport

            Form_MustDoIt.TB_Notification.Text = "MUST DO IT !!!" + vbCrLf + "Please follow below steps on the server """ + serverName + """ to share the folder for receiving UFT detail result:" + vbCrLf + vbCrLf + "1. Run the ""cmd.exe""(C:\Windows\System32) as Adminstrator role." + vbCrLf + vbCrLf + "2. Execute command lines by order:" + vbCrLf + "1) Md " + strSharedFolderPathOfOtherServerReport + vbCrLf + vbCrLf + "2) ICacls """ + strSharedFolderPathOfOtherServerReport + """ /T /C /grant:r everyone:F" + vbCrLf + vbCrLf + "3) Net share " + strSharedFolderNameOfOtherServerReport + "=" + strSharedFolderPathOfOtherServerReport + " /grant:everyone,full" + vbCrLf
            Form_MustDoIt.TB_Notification.SelectionLength = 1
            Form_MustDoIt.TB_Notification.SelectionLength = 0
            Form_MustDoIt.Bt_Donot.Visible = True
            Form_MustDoIt.Bt_Configured.Visible = True
        Else
            Form_MustDoIt.TB_Notification.Text = "MUST DO IT !!!" + vbCrLf + "Please follow below steps on the server """ + serverName + """ to share the folder for receiving UFT detail result:" + vbCrLf + vbCrLf + "1. Run the ""cmd.exe""(C:\Windows\System32) as Adminstrator role." + vbCrLf + vbCrLf + "2. Execute command lines by order:" + vbCrLf + "1) Md " + strSharedFolderPathOfOtherServerReport + vbCrLf + vbCrLf + "2) ICacls """ + strSharedFolderPathOfOtherServerReport + """ /T /C /grant:r everyone:F" + vbCrLf + vbCrLf + "3) Net share " + strSharedFolderNameOfOtherServerReport + "=" + strSharedFolderPathOfOtherServerReport + " /grant:everyone,full" + vbCrLf
            Form_MustDoIt.TB_Notification.SelectionLength = 1
            Form_MustDoIt.TB_Notification.SelectionLength = 0
            Form_MustDoIt.Bt_Donot.Visible = True
            Form_MustDoIt.Bt_Configured.Visible = True
        End If


        If IsRUNClicked Then
            Form_MustDoIt.Bt_StopRun.Visible = True
        End If

        Form_MustDoIt.Show()
        If IsNothing(previousActionLocation) = False Then
            Form_MustDoIt.Location = previousActionLocation
            previousActionLocation = Nothing
        End If
        Do While True And Form_MustDoIt.IsFormNotClosed
            Application.DoEvents()
            If notificationActionCode <> 0 Then
                Select Case notificationActionCode
                    Case 1
                        Form_MustDoIt.TB_Notification.Text = "If you do not execute previous command lines, the UFT report result will be put in folder """ + strSharedFolderPathOfOtherServerReport + """ of machines which execute test." + vbCrLf + vbCrLf + "Click ""Confirmed"" button to continue." + vbCrLf
                        Form_MustDoIt.TB_Notification.SelectionLength = 1
                        Form_MustDoIt.TB_Notification.SelectionLength = 0
                        Form_MustDoIt.Bt_Donot.Visible = False
                        Form_MustDoIt.Bt_Configured.Visible = False
                        Form_MustDoIt.Bt_StopRun.Visible = False
                        Form_MustDoIt.Bt_Previous.Visible = True
                        Form_MustDoIt.Bt_confirmed.Visible = True
                        Form_MustDoIt.Bt_Cancel.Visible = True
                        If IsRUNClicked Then
                            Form_MustDoIt.Bt_Cancel.Text = "Stop current run"
                        Else
                            Form_MustDoIt.Bt_Cancel.Text = "Close"
                        End If
                        Form_MustDoIt.Bt_Cancel.Visible = True
                        notificationActionCode = 0
                        Do While True
                            Application.DoEvents()
                            If notificationActionCode <> 0 Then
                                Select Case notificationActionCode
                                    Case 4
                                        previousActionLocation = Form_MustDoIt.Location
                                        intialTestResultFolderForOtherServer(serverName)

                                    Case 5
                                        Form_MustDoIt.Close()
                                        stateCode = 1
                                    Case 6
                                        strSharedFolderPathOfOtherServerReport = ""
                                        strSharedFolderNameOfOtherServerReport = ""
                                        Form_MustDoIt.Close()
                                        stateCode = 2
                                End Select
                                Exit Do
                            End If
                        Loop

                    Case 2
                        Form_MustDoIt.TB_Notification.Text = "If you failed to execute previous command lines, the UFT report result will be put in folder """ + strSharedFolderPathOfOtherServerReport + """ of machines which execute test." + vbCrLf + vbCrLf + "Click ""Confirmed"" button to continue." + vbCrLf
                        Form_MustDoIt.TB_Notification.SelectionLength = 1
                        Form_MustDoIt.TB_Notification.SelectionLength = 0
                        Form_MustDoIt.Bt_Donot.Visible = False
                        Form_MustDoIt.Bt_Configured.Visible = False
                        Form_MustDoIt.Bt_StopRun.Visible = False
                        Form_MustDoIt.Bt_Previous.Visible = True
                        Form_MustDoIt.Bt_confirmed.Visible = True
                        Form_MustDoIt.Bt_Cancel.Visible = True
                        If IsRUNClicked Then
                            Form_MustDoIt.Bt_Cancel.Text = "Stop current run"
                        Else
                            Form_MustDoIt.Bt_Cancel.Text = "Close"
                        End If
                        Form_MustDoIt.Bt_Cancel.Visible = True
                        notificationActionCode = 0
                        Do While True
                            Application.DoEvents()
                            If notificationActionCode <> 0 Then
                                Select Case notificationActionCode
                                    Case 4
                                        previousActionLocation = Form_MustDoIt.Location
                                        intialTestResultFolderForOtherServer(serverName)

                                    Case 5
                                        Form_MustDoIt.Close()
                                        stateCode = 1


                                    Case 6
                                        strSharedFolderPathOfOtherServerReport = ""
                                        strSharedFolderNameOfOtherServerReport = ""
                                        Form_MustDoIt.Close()
                                        stateCode = 2
                                End Select
                                Exit Do
                            End If
                        Loop
                    Case 3
                        Form_MustDoIt.Close()
                        strSharedFolderPathOfOtherServerReport = ""
                        strSharedFolderNameOfOtherServerReport = ""
                        stateCode = 2
                End Select

                notificationActionCode = 0
                Exit Do

            End If

        Loop
        Return stateCode
    End Function

    'Sub installRDCM(ByVal installSource)
    '    installRDCMOpend = True
    '    Dim myProcess As Process = System.Diagnostics.Process.Start(installSource)
    '    waitTime(5000)
    '    Dim exitcode = -1
    '    Do Until exitcode >= 0
    '        On Error Resume Next
    '        exitcode = myProcess.ExitCode
    '        On Error GoTo 0
    '        If Err.Number <> 0 Then
    '            exitcode = -1
    '        End If
    '        If CloseinstallRCDM Then
    '            Exit Do
    '        End If
    '    Loop
    '    installRDCMOpend = False
    '    CloseinstallRCDM = False
    '    Invoke(New Delegate_EnableBT(AddressOf EnableBT), Bt_QRDC)
    'End Sub

    Sub openRDCM(ByVal installLocation)
        RDCMOpend = True
        Dim myProcess As New System.Diagnostics.Process()
        myProcess.StartInfo.FileName = installLocation
        myProcess.StartInfo.Arguments = """" + Folder_me_config_Path + "\" + RDG_ChinaATVMGroup + """"
        myProcess.StartInfo.UseShellExecute = True
        myProcess.Start()
        waitTime(5000)
        Dim exitcode = -1
        Do Until exitcode >= 0
            On Error Resume Next
            exitcode = myProcess.ExitCode
            On Error GoTo 0
            If Err.Number <> 0 Then
                exitcode = -1
            End If
            If CloseRCDM Then
                myProcess.Kill()
                Exit Do
            End If
        Loop
        CloseRCDM = False
        RDCMOpend = False
        Invoke(New Delegate_EnableTSMI(AddressOf EnableToolStripMenuItem), RemoteDesktopManagerToolStripMenuItem)
    End Sub
    Sub EnableToolStripMenuItem(ByRef TSMI As ToolStripMenuItem)
        TSMI.Enabled = True
    End Sub
    Sub clearCLB_ReportServerIP()
        For h = 0 To CLB_ReportServerIP.Items.Count - 1
            CLB_ReportServerIP.SetItemCheckState(h, CheckState.Unchecked)
        Next
        strSharedFolderPathOfOtherServerReport = ""
        strSharedFolderNameOfOtherServerReport = ""
    End Sub


    Private Sub RemoteDesktopManagerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RemoteDesktopManagerToolStripMenuItem.Click
        RemoteDesktopManagerToolStripMenuItem.Enabled = False
        'Form_QRDC.Show()
        'Form_QRDC.BringToFront()
        'Dim installLocation = findInstallLocationOfApp(RDCManDisplayName)

        ' Dim installLocation = "C:\Program Files (x86)\Remote Desktop Connection Manager\RDCMan.exe"
        'If Trim(installLocation) <> "" Then
        Dim openRDCMThread As New Thread(AddressOf openRDCM)
        openRDCMThread.IsBackground = True
        openRDCMThread.Start(Folder_RDCMan_Path + "\" + RDCManName)
        'Else
        '    Dim installRDCMThread As New Thread(AddressOf installRDCM)
        '    Dim installSource = Folder_me_config_Path + "\" + RDCManMSIName
        '    installRDCMThread.IsBackground = True
        '    installRDCMThread.Start(installSource)
        'End If
    End Sub

    Private Sub LibraryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LibraryToolStripMenuItem.Click
        If CB_NormalRun.Checked Then
            If Trim(Folder_Root_Path) <> "" Then
                Dim path As String = Folder_Root_Path + "\" + FolderName_Lib
                If Class_FolderOperator1.hasFolder(path) Then
                    Class_FolderOperator1.openFolder(path)
                Else
                    MsgBox("The path of Library folder was not existing: " + path)
                End If
            Else
                MsgBox("You have not provided Directory.")
            End If
        End If

        If CB_Servers.Checked And CB_HostMode.Checked Then
            If Trim(Folder_Root_Path) <> "" Then
                Dim path As String = Folder_Root_Path + "\" + FolderName_Lib
                If Class_FolderOperator1.hasFolder(path) Then
                    Class_FolderOperator1.openFolder(path)
                Else
                    MsgBox("The path of Library folder was not existing: " + path)
                End If
            Else
                MsgBox("You have not provided Directory.")
            End If
        End If
    End Sub

    Private Sub CheckRemoteUFTStatusToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckRemoteUFTStatusToolStripMenuItem.Click
        CheckRemoteUFTStatusToolStripMenuItem.Enabled = False
        Form_CheckSlave.Show()

    End Sub

    Private Sub HelpToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HelpToolStripMenuItem.Click
        Form_Help.Show()
        'runExternalP(Folder_me_config_Path + "\help.txt")
    End Sub

    Private Sub SaveConfigurationAsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveConfigurationAsToolStripMenuItem.Click
        Dim path As String
        Dim iBrowser As New SaveFileDialog
        iBrowser.InitialDirectory = Environment.SpecialFolder.Desktop
        iBrowser.CheckFileExists = False
        iBrowser.AddExtension = True
        iBrowser.Filter = "ATester Plan (*.atplan)|*.atplan"
        iBrowser.CheckPathExists = True
        iBrowser.ShowHelp = False
        iBrowser.ShowDialog()
        If iBrowser.FileName <> "" Then
            'MsgBox(iBrowser.FileName)
            path = iBrowser.FileName
        Else
            path = ""
        End If


        If path <> "" Then
            If Not path.Contains(".atplan") Then
                GoTo errorline
            End If

            On Error GoTo errorline
            Dim CB_NormalRunSt() = {"1@", CStr(CB_NormalRun.Checked), "@1"}
            Dim TB_LCText() = {"2@", TB_LC.Text, "@2"}


            Dim CB_ServersSt() = {"3@", CStr(CB_Servers.Checked), "@3"}
            Dim CB_HostModelSt = {"4@", CStr(CB_HostMode.Checked), "@4"}
            Dim TB_RR_DirText = {"5@", TB_RR_Dir.Text, "@5"}
            Dim TB_RR_IPsText = {"6@", TB_RR_IPs.Text, "@6"}
            Dim TB_OneTimeNumberText = {"7@", TB_OneTimeNumber.Text, "@7"}
            Dim TB_DeadLineText = {"8@", TB_DeadLine.Text, "@8"}

            Dim CB_CRTSt = {"9@", CStr(CB_CRT.Checked), "@9"}
            Dim arrayCRTList(0) As String
            arrayCRTList(0) = "10@"
            If CB_CRT.Checked Then
                If UBound(arryIPs_TBs_Relation) > -1 Then
                    For i = 0 To UBound(arryIPs_TBs_Relation)
                        ReDim Preserve arrayCRTList(UBound(arrayCRTList) + 1)
                        arrayCRTList(UBound(arrayCRTList)) = "10-" + CStr(i + 1) + "@" + vbCrLf + arryIPs_TBs_Relation(i)(1).Text + vbCrLf + "@10-" + CStr(i + 1)
                    Next
                End If
            End If
            ReDim Preserve arrayCRTList(UBound(arrayCRTList) + 1)
            arrayCRTList(UBound(arrayCRTList)) = "@10"

            Dim TB_BPTListText = {"11@", TB_BPTList.Text, "@11"}


            Dim arrayCLBList(0) As String
            arrayCLBList(0) = "12@"
            If CLB_Testlist.Items.Count > 0 Then
                For i = 0 To CLB_Testlist.Items.Count - 1
                    ReDim Preserve arrayCLBList(UBound(arrayCLBList) + 1)
                    arrayCLBList(UBound(arrayCLBList)) = CLB_Testlist.Items.Item(i)
                Next
            End If
            ReDim Preserve arrayCLBList(UBound(arrayCLBList) + 1)
            arrayCLBList(UBound(arrayCLBList)) = "@12"


            Dim TB_ReportFolderText = {"13@", TB_ReportFolder.Text, "@13"}

            Dim CB_ExcelSt = {"14@", CB_Excel.Checked, "@14"}

            Dim arryAll(-1) As String
            For i = 0 To UBound(CB_NormalRunSt)
                ReDim Preserve arryAll(UBound(arryAll) + 1)
                arryAll(UBound(arryAll)) = CB_NormalRunSt(i)
            Next
            For i = 0 To UBound(TB_LCText)
                ReDim Preserve arryAll(UBound(arryAll) + 1)
                arryAll(UBound(arryAll)) = TB_LCText(i)
            Next
            For i = 0 To UBound(CB_ServersSt)
                ReDim Preserve arryAll(UBound(arryAll) + 1)
                arryAll(UBound(arryAll)) = CB_ServersSt(i)
            Next
            For i = 0 To UBound(CB_HostModelSt)
                ReDim Preserve arryAll(UBound(arryAll) + 1)
                arryAll(UBound(arryAll)) = CB_HostModelSt(i)
            Next
            For i = 0 To UBound(TB_RR_DirText)
                ReDim Preserve arryAll(UBound(arryAll) + 1)
                arryAll(UBound(arryAll)) = TB_RR_DirText(i)
            Next
            For i = 0 To UBound(TB_RR_IPsText)
                ReDim Preserve arryAll(UBound(arryAll) + 1)
                arryAll(UBound(arryAll)) = TB_RR_IPsText(i)
            Next
            For i = 0 To UBound(TB_OneTimeNumberText)
                ReDim Preserve arryAll(UBound(arryAll) + 1)
                arryAll(UBound(arryAll)) = TB_OneTimeNumberText(i)
            Next
            For i = 0 To UBound(TB_DeadLineText)
                ReDim Preserve arryAll(UBound(arryAll) + 1)
                arryAll(UBound(arryAll)) = TB_DeadLineText(i)
            Next
            For i = 0 To UBound(CB_CRTSt)
                ReDim Preserve arryAll(UBound(arryAll) + 1)
                arryAll(UBound(arryAll)) = CB_CRTSt(i)
            Next
            For i = 0 To UBound(arrayCRTList)
                ReDim Preserve arryAll(UBound(arryAll) + 1)
                arryAll(UBound(arryAll)) = arrayCRTList(i)
            Next
            For i = 0 To UBound(TB_BPTListText)
                ReDim Preserve arryAll(UBound(arryAll) + 1)
                arryAll(UBound(arryAll)) = TB_BPTListText(i)
            Next
            For i = 0 To UBound(arrayCLBList)
                ReDim Preserve arryAll(UBound(arryAll) + 1)
                arryAll(UBound(arryAll)) = arrayCLBList(i)
            Next
            For i = 0 To UBound(TB_ReportFolderText)
                ReDim Preserve arryAll(UBound(arryAll) + 1)
                arryAll(UBound(arryAll)) = TB_ReportFolderText(i)
            Next
            For i = 0 To UBound(CB_ExcelSt)
                ReDim Preserve arryAll(UBound(arryAll) + 1)
                arryAll(UBound(arryAll)) = CB_ExcelSt(i)
            Next
            If useSecurityConfig Then
                Dim securityIndex = 0
                For w = 0 To UBound(arryAll)
                    Dim curText = arryAll(w)
                    Dim newText As String = ""
                    For i = 0 To curText.Length - 1
                        Dim curChar = curText.Substring(i, 1)
                        Dim changedChar As String = ""
                        Select Case curChar
                            Case "a"
                                changedChar = "q"
                            Case "b"
                                changedChar = "w"
                            Case "c"
                                changedChar = "e"
                            Case "d"
                                changedChar = "r"
                            Case "e"
                                changedChar = "t"
                            Case "f"
                                changedChar = "y"
                            Case "g"
                                changedChar = "u"
                            Case "h"
                                changedChar = "i"
                            Case "i"
                                changedChar = "o"
                            Case "j"
                                changedChar = "p"
                            Case "k"
                                changedChar = "a"
                            Case "l"
                                changedChar = "s"
                            Case "m"
                                changedChar = "d"
                            Case "n"
                                changedChar = "f"
                            Case "o"
                                changedChar = "g"
                            Case "p"
                                changedChar = "h"
                            Case "q"
                                changedChar = "j"
                            Case "r"
                                changedChar = "k"
                            Case "s"
                                changedChar = "l"
                            Case "t"
                                changedChar = "z"
                            Case "u"
                                changedChar = "x"
                            Case "v"
                                changedChar = "c"
                            Case "w"
                                changedChar = "v"
                            Case "x"
                                changedChar = "b"
                            Case "y"
                                changedChar = "n"
                            Case "z"
                                changedChar = "m"
                            Case "a".ToUpper
                                changedChar = "q".ToUpper
                            Case "b".ToUpper
                                changedChar = "w".ToUpper
                            Case "c".ToUpper
                                changedChar = "e".ToUpper
                            Case "d".ToUpper
                                changedChar = "r".ToUpper
                            Case "e".ToUpper
                                changedChar = "t".ToUpper
                            Case "f".ToUpper
                                changedChar = "y".ToUpper
                            Case "g".ToUpper
                                changedChar = "u".ToUpper
                            Case "h".ToUpper
                                changedChar = "i".ToUpper
                            Case "i".ToUpper
                                changedChar = "o".ToUpper
                            Case "j".ToUpper
                                changedChar = "p".ToUpper
                            Case "k".ToUpper
                                changedChar = "a".ToUpper
                            Case "l".ToUpper
                                changedChar = "s".ToUpper
                            Case "m".ToUpper
                                changedChar = "d".ToUpper
                            Case "n".ToUpper
                                changedChar = "f".ToUpper
                            Case "o".ToUpper
                                changedChar = "g".ToUpper
                            Case "p".ToUpper
                                changedChar = "h".ToUpper
                            Case "q".ToUpper
                                changedChar = "j".ToUpper
                            Case "r".ToUpper
                                changedChar = "k".ToUpper
                            Case "s".ToUpper
                                changedChar = "l".ToUpper
                            Case "t".ToUpper
                                changedChar = "z".ToUpper
                            Case "u".ToUpper
                                changedChar = "x".ToUpper
                            Case "v".ToUpper
                                changedChar = "c".ToUpper
                            Case "w".ToUpper
                                changedChar = "v".ToUpper
                            Case "x".ToUpper
                                changedChar = "b".ToUpper
                            Case "y".ToUpper
                                changedChar = "n".ToUpper
                            Case "z".ToUpper
                                changedChar = "m".ToUpper
                            Case "/"
                                changedChar = "."
                            Case "\"
                                changedChar = "^"
                            Case ":"
                                changedChar = "/"
                            Case "."
                                changedChar = "%"
                            Case "^"
                                changedChar = ":"
                            Case "%"
                                changedChar = "\"
                            Case Else
                                changedChar = curChar
                        End Select
                        newText = newText + changedChar
                    Next
                    arryAll(w) = newText
                Next
            End If

            Dim tempstr As String = ""
            For i = 0 To arryAll.Length - 1
                tempstr = tempstr & vbCrLf & arryAll(i)
            Next
            tempstr = Replace(tempstr, vbCrLf, "", 1, 1)

            Dim fileStream() As Byte = System.Text.Encoding.UTF8.GetBytes(tempstr)
            File.WriteAllBytes(path, fileStream)

            MsgBox("Saved Successfully.")
            Dim name = Split(path, "\")
            BT_TopBar.Text = "ATester - " + name(UBound(name))


        End If
        On Error GoTo 0
        Exit Sub
errorline:
        On Error GoTo 0
        MsgBox("Error on save atconfig file: " + path)
    End Sub

    Private Sub OpenConfigurationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenConfigurationToolStripMenuItem.Click
        Dim path = Class_FolderOperator1.returnOpenFilePath("atconfig")
        Dim isRemoteMode = False
        Dim isHostMode = False
        Dim isCustomMode = False
        If path <> "" Then
            Me.Enabled = False
            If Not path.Contains(".atplan") Then
                GoTo errorLine
            End If
            On Error GoTo errorLine
            Dim fileStream() As Byte = File.ReadAllBytes(path)
            Dim stringType = System.Text.Encoding.UTF8.GetString(fileStream)
            Dim configFile() = Split(stringType, vbCrLf)
            If useSecurityConfig Then
                Dim securityIndex = 0
                For w = 0 To UBound(configFile)
                    Dim curText = configFile(w)
                    Dim newText As String = ""
                    For i = 0 To curText.Length - 1
                        Dim curChar = curText.Substring(i, 1)
                        Dim changedChar As String = ""
                        Select Case curChar
                            Case "q"
                                changedChar = "a"
                            Case "w"
                                changedChar = "b"
                            Case "e"
                                changedChar = "c"
                            Case "r"
                                changedChar = "d"
                            Case "t"
                                changedChar = "e"
                            Case "y"
                                changedChar = "f"
                            Case "u"
                                changedChar = "g"
                            Case "i"
                                changedChar = "h"
                            Case "o"
                                changedChar = "i"
                            Case "p"
                                changedChar = "j"
                            Case "a"
                                changedChar = "k"
                            Case "s"
                                changedChar = "l"
                            Case "d"
                                changedChar = "m"
                            Case "f"
                                changedChar = "n"
                            Case "g"
                                changedChar = "o"
                            Case "h"
                                changedChar = "p"
                            Case "j"
                                changedChar = "q"
                            Case "k"
                                changedChar = "r"
                            Case "l"
                                changedChar = "s"
                            Case "z"
                                changedChar = "t"
                            Case "x"
                                changedChar = "u"
                            Case "c"
                                changedChar = "v"
                            Case "v"
                                changedChar = "w"
                            Case "b"
                                changedChar = "x"
                            Case "n"
                                changedChar = "y"
                            Case "m"
                                changedChar = "z"
                            Case "q".ToUpper
                                changedChar = "a".ToUpper
                            Case "w".ToUpper
                                changedChar = "b".ToUpper
                            Case "e".ToUpper
                                changedChar = "c".ToUpper
                            Case "r".ToUpper
                                changedChar = "d".ToUpper
                            Case "t".ToUpper
                                changedChar = "e".ToUpper
                            Case "y".ToUpper
                                changedChar = "f".ToUpper
                            Case "u".ToUpper
                                changedChar = "g".ToUpper
                            Case "i".ToUpper
                                changedChar = "h".ToUpper
                            Case "o".ToUpper
                                changedChar = "i".ToUpper
                            Case "p".ToUpper
                                changedChar = "j".ToUpper
                            Case "a".ToUpper
                                changedChar = "k".ToUpper
                            Case "s".ToUpper
                                changedChar = "l".ToUpper
                            Case "d".ToUpper
                                changedChar = "m".ToUpper
                            Case "f".ToUpper
                                changedChar = "n".ToUpper
                            Case "g".ToUpper
                                changedChar = "o".ToUpper
                            Case "h".ToUpper
                                changedChar = "p".ToUpper
                            Case "j".ToUpper
                                changedChar = "q".ToUpper
                            Case "k".ToUpper
                                changedChar = "r".ToUpper
                            Case "l".ToUpper
                                changedChar = "s".ToUpper
                            Case "z".ToUpper
                                changedChar = "t".ToUpper
                            Case "x".ToUpper
                                changedChar = "u".ToUpper
                            Case "c".ToUpper
                                changedChar = "v".ToUpper
                            Case "v".ToUpper
                                changedChar = "w".ToUpper
                            Case "b".ToUpper
                                changedChar = "x".ToUpper
                            Case "n".ToUpper
                                changedChar = "y".ToUpper
                            Case "m".ToUpper
                                changedChar = "z".ToUpper
                            Case "."
                                changedChar = "/"
                            Case "^"
                                changedChar = "\"
                            Case "/"
                                changedChar = ":"
                            Case "%"
                                changedChar = "."
                            Case ":"
                                changedChar = "^"
                            Case "\"
                                changedChar = "%"
                            Case Else
                                changedChar = curChar
                        End Select
                        newText = newText + changedChar
                    Next
                    configFile(w) = newText
                Next
            End If
            For i = 0 To UBound(configFile)
                If configFile(i) = "1@" Then
                    For j = i + 1 To UBound(configFile)
                        If configFile(j) = "@1" Then
                            Exit For
                        End If
                        If configFile(j).ToLower = "true" Then
                            RadioButton_LocalMode.Checked = True
                            isRemoteMode = False
                            'Else
                            '    RadioButton_LocalMode.Checked = False
                        End If
                    Next
                End If


                If configFile(i) = "3@" Then
                    For j = i + 1 To UBound(configFile)
                        If configFile(j) = "@3" Then
                            Exit For
                        End If
                        If configFile(j).ToLower = "true" Then
                            RadioButton_RemoteMode.Checked = True
                            isRemoteMode = True
                            'Else
                            '    RadioButton_RemoteMode.Checked = False
                        End If
                    Next
                End If
                If isRemoteMode = False Then
                    If configFile(i) = "2@" Then
                        For j = i + 1 To UBound(configFile)
                            If configFile(j) = "@2" Then
                                Exit For
                            End If
                            TB_LC.Text = configFile(j)
                        Next
                    End If
                End If


                If isRemoteMode Then
                    If configFile(i) = "4@" Then
                        For j = i + 1 To UBound(configFile)
                            If configFile(j) = "@4" Then
                                Exit For
                            End If
                            If configFile(j).ToLower = "true" Then
                                CB_HostMode.Checked = True
                                isHostMode = True
                            Else
                                CB_HostMode.Checked = False
                            End If
                        Next
                    End If
                End If


                If configFile(i) = "5@" Then
                    For j = i + 1 To UBound(configFile)
                        If configFile(j) = "@5" Then
                            Exit For
                        End If
                        TB_RR_Dir.Text = configFile(j)
                    Next
                End If
                If isHostMode Then
                    If configFile(i) = "6@" Then
                        For j = i + 1 To UBound(configFile)
                            If configFile(j) = "@6" Then
                                Exit For
                            End If
                            TB_RR_IPs.Text = configFile(j)
                        Next
                    End If
                End If


                If configFile(i) = "7@" Then
                    For j = i + 1 To UBound(configFile)
                        If configFile(j) = "@7" Then
                            Exit For
                        End If
                        TB_OneTimeNumber.Text = configFile(j)
                    Next
                End If

                If configFile(i) = "8@" Then
                    For j = i + 1 To UBound(configFile)
                        If configFile(j) = "@8" Then
                            Exit For
                        End If
                        TB_DeadLine.Text = configFile(j)
                    Next
                End If

                If configFile(i) = "11@" Then
                    'If ExpandButton.Text = "<" Then
                    '    ExpandButton.PerformClick()
                    'End If
                    TB_BPTList.Clear()
                    For j = i + 1 To UBound(configFile)
                        If configFile(j) = "@11" Then
                            Exit For
                        End If
                        TB_BPTList.AppendText(configFile(j) + vbCrLf)
                    Next
                End If

                If configFile(i) = "12@" Then
                    'If ExpandButton.Text = "<" Then
                    '    ExpandButton.PerformClick()
                    'End If
                    CLB_Testlist.Items.Clear()
                    For j = i + 1 To UBound(configFile)
                        If configFile(j) = "@12" Then
                            Exit For
                        End If
                        CLB_Testlist.Items.Add(configFile(j))
                    Next
                End If

                If configFile(i) = "13@" Then
                    For j = i + 1 To UBound(configFile)
                        If configFile(j) = "@13" Then
                            Exit For
                        End If
                        TB_ReportFolder.Text = configFile(j)
                    Next
                End If

                If configFile(i) = "9@" Then
                    For j = i + 1 To UBound(configFile)
                        If configFile(j) = "@9" Then
                            Exit For
                        End If
                        If configFile(j).ToLower = "true" Then
                            CB_CRT.Checked = True
                            isCustomMode = True
                        Else
                            CB_CRT.Checked = False
                        End If
                    Next
                End If

                If configFile(i) = "14@" Then
                    For j = i + 1 To UBound(configFile)
                        If configFile(j) = "@14" Then
                            Exit For
                        End If
                        If configFile(j).ToLower = "true" Then
                            CB_Excel.Checked = True
                        Else
                            CB_Excel.Checked = False
                        End If
                    Next
                End If

                If isCustomMode Then
                    If configFile(i) = "10@" Then
                        Me.Enabled = True
                        Bt_MissionPanel.PerformClick()
                        'Me.Enabled = False
                        Dim curtime = Now
                        Dim curtime1 = Now
                        Do Until (Form_MissionPanel.Visible = True) Or (DateDiff("s", curtime, curtime1) >= 3)
                            waitTime(200)
                            curtime1 = Now
                        Loop

                        'Me.Enabled = True
                        Dim h = 1
                        For j = i + 1 To UBound(configFile)
                            If configFile(j) = "@10" Then
                                Exit For
                            End If
                            If configFile(j) = "10-" + CStr(h) + "@" Then
                                arryIPs_TBs_Relation(h - 1)(1).clear()
                                For w = j + 1 To UBound(configFile)
                                    If configFile(w) = "@10-" + CStr(h) Then
                                        Exit For
                                    End If
                                    arryIPs_TBs_Relation(h - 1)(1).AppendText(configFile(w) + vbCrLf)
                                Next
                                h = h + 1
                            End If
                        Next
                        Form_MissionPanel.BT_Close.PerformClick()

                        Me.Enabled = False
                    End If
                End If

            Next
            Dim name = Split(path, "\")
            BT_TopBar.Text = "ATester - " + name(UBound(name))
            On Error GoTo 0
            MsgBox("Load is completed!")
        End If

        Me.Enabled = True
        Exit Sub
errorLine:
        On Error GoTo 0
        MsgBox("Error on opening the configuration file: " + path)
        Me.Enabled = True
    End Sub
    Public PictureBox_Panda_mousedownValue As Boolean = False
    Public curMousePosOnPictureBox_Panda As Point = Nothing

    Private Sub PictureBox_Panda_MouseDown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox_Panda.MouseDown
        PictureBox_Panda_mousedownValue = True
        curMousePosOnPictureBox_Panda = PictureBox_Panda.PointToClient(Form_Main.MousePosition)
    End Sub

    Private Sub PictureBox_Panda_MouseUp(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox_Panda.MouseUp
        PictureBox_Panda_mousedownValue = False
        curMousePosOnPictureBox_Panda = Nothing
    End Sub
    Private Sub PictureBox_Panda_move(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox_Panda.MouseMove
        If PictureBox_Panda_mousedownValue And (IsNothing(curMousePosOnPictureBox_Panda) = False) Then
            Dim curMousePos = System.Windows.Forms.Cursor.Position
            Me.Location = New Point(curMousePos.X - curMousePosOnPictureBox_Panda.X - PictureBox_Panda.Location.X, curMousePos.Y - curMousePosOnPictureBox_Panda.Y - PictureBox_Panda.Location.Y)
        End If
    End Sub

    Public TopBar_mousedownVar As Boolean = False
    Public curMousePosOnTopBar As Point = Nothing
    Private Sub L_TopBar_MouseDown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_TopBar.MouseDown
        TopBar_mousedownVar = True
        curMousePosOnTopBar = BT_TopBar.PointToClient(Form_Main.MousePosition)
    End Sub

    Private Sub L_TopBar_MouseUp(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_TopBar.MouseUp
        TopBar_mousedownVar = False
        curMousePosOnTopBar = Nothing
    End Sub
    Private Sub L_TopBar_move(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_TopBar.MouseMove
        If TopBar_mousedownVar And (IsNothing(curMousePosOnTopBar) = False) Then
            Dim curMousePos = System.Windows.Forms.Cursor.Position
            Me.Location = New Point(curMousePos.X - curMousePosOnTopBar.X - BT_TopBar.Location.X, curMousePos.Y - curMousePosOnTopBar.Y - BT_TopBar.Location.Y)
        End If
    End Sub

    Public L_FormBack_mousedownVar As Boolean = False
    Public curMousePosOnL_FormBack As Point = Nothing
    Private Sub L_FormBack_MouseDown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TB_FormBack.MouseDown
        L_FormBack_mousedownVar = True
        curMousePosOnL_FormBack = TB_FormBack.PointToClient(Form_Main.MousePosition)
    End Sub

    Private Sub L_FormBack_MouseUp(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TB_FormBack.MouseUp
        L_FormBack_mousedownVar = False
        curMousePosOnL_FormBack = Nothing
    End Sub
    Private Sub L_FormBack_move(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TB_FormBack.MouseMove
        If L_FormBack_mousedownVar And (IsNothing(curMousePosOnL_FormBack) = False) Then
            Dim curMousePos = System.Windows.Forms.Cursor.Position
            Me.Location = New Point(curMousePos.X - curMousePosOnL_FormBack.X - TB_FormBack.Location.X, curMousePos.Y - curMousePosOnL_FormBack.Y - TB_FormBack.Location.Y)
        End If
    End Sub

    'Private Sub Form_Main_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated

    '    If firstActive Then
    '        Dim pandainfoThread As New Thread(AddressOf pandainfo)
    '        pandainfoThread.IsBackground = True
    '        pandainfoThread.Start()
    '        firstActive = False
    '    End If
    'End Sub
    Sub pandainfo()
        Dim currenttime = Hour(Now)
        Dim msg As String = ""
        Dim msg1 As String = ""
        If currenttime >= 0 And currenttime <= 6 Then
            msg = "早起的鸟儿有虫吃！"
            msg1 = "Panda has dark circles under eyes"
        End If

        If currenttime > 6 And currenttime <= 11 Then
            msg = "早上好！"
            msg1 = "Panda loves bamboo"
        End If

        If currenttime > 11 And currenttime <= 13 Then
            msg = "中午好！" + vbCrLf + "别忘了午休哟！"
            msg1 = "Panda likes sleeping"
        End If

        If currenttime > 13 And currenttime <= 18 Then
            msg = "下午好！"
            msg1 = "Panda loves bamboo"
        End If

        If currenttime > 18 And currenttime <= 23 Then
            msg = "晚上好，别太幸苦哟！"
            msg1 = "Panda has dark circles under eyes"
        End If
        Do Until PictureBox_Panda.Visible
            waitTime(200)
        Loop

        waitTime(1000)
        Invoke(New Delegate_PandainfoShow(AddressOf PandainfoShow), PictureBox_Panda, msg, msg1)

    End Sub
    Sub PandainfoShow(ByRef pb As PictureBox, ByVal msg As String, ByVal msg1 As String)

        'ToolTip_Panda.IsBalloon = False
        ToolTip_Panda.SetToolTip(pb, " ")
        ToolTip_Panda.Show(msg, pb, 1000)
        waitTime(3000)
        'ToolTip_Panda.IsBalloon = True
        ToolTip_Panda.SetToolTip(pb, msg1)

    End Sub

    'Sub toolTip1_Draw(ByVal sender As Object, ByVal e As DrawToolTipEventArgs) Handles PictureBox_Panda

    '    e.DrawBackground()
    '    Dim f = New System.Drawing.Font("黑体", e.Font.Size, FontStyle.Bold)

    '    e.Graphics.DrawString(e.ToolTipText, f, Brushes.Black, New PointF(0, 0))

    'End Sub

    'Sub toolTip1_Draw(ByVal sender As Object, ByVal e As DrawToolTipEventArgs) Handles ToolTip_Panda.Draw
    '    e.DrawBackground()
    '    Dim f = New System.Drawing.Font("Arial", 8, FontStyle.Regular, GraphicsUnit.Point)
    '    'Dim newLoc As System.Drawing.Point = New Point(0, 0)
    '    'Dim newSize As System.Drawing.Size = New Size(1500, 125)
    '    'Dim newRect As System.Drawing.Rectangle = New Rectangle(newLoc, newSize)
    '    ' e.Graphics.FillRectangle(Brushes.Black, New Rectangle(newLoc, newSize))
    '    ' e.Graphics.DrawRectangle(New System.Drawing.Pen(System.Drawing.Color.Red), New Rectangle(10, 10, 200, 300))
    '    e.Graphics.DrawString(e.ToolTipText, f, Brushes.Black, New PointF(0, 0))
    '    e.DrawBorder()

    'End Sub

    'Private Sub DrawRectangle(ByRef text As String)
    '    Dim f = New System.Drawing.Font("Arial", 12, FontStyle.Regular, GraphicsUnit.Point)
    '    Dim myPen As New System.Drawing.Pen(System.Drawing.Color.Red)
    '    Dim formGraphics As System.Drawing.Graphics
    '    formGraphics = Me.CreateGraphics()
    '    formGraphics.DrawRectangle(myPen, New Rectangle(0, 0, 200, 300))
    '    formGraphics.DrawString(text, f, Brushes.Black, New PointF(0, 0))
    '    myPen.Dispose()
    '    formGraphics.Dispose()
    'End Sub


    Private Sub CloseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseToolStripMenuItem.Click
        BT_Close.PerformClick()
    End Sub

    Sub clickButton(ByRef bt As Object)
        bt.PerformClick()
    End Sub
    Sub alarmRunMonitor()
        Do While True
            Dim ctime = DateDiff(DateInterval.Second, Now, alarmTime)
            If ctime >= 0 Then
                Dim time = CStr(CInt(ctime))
                Invoke(New Delegate_writeLable(AddressOf writeLabel), L_TimeRemaining, "Auto run after " + time + " seconds")
            End If
            If Alarm.isThreadClickRun = 1 Then
                Invoke(New Delegate_AddContentToTB(AddressOf Class_MainFormControlHandler1.AddContentToTB), TB_MainLog, "A test mission is triggerd by Alarm !!!", vbCrLf)
                Invoke(New Delegate_ClickButton(AddressOf clickButton), Bt_Run)
                alarmTime = Nothing
                Alarm.isThreadClickRun = 0
                Alarm.AlarmRunEnd = 1
            End If
            waitTime(500)
        Loop
    End Sub

    'Private Sub Form_Main_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.VisibleChanged
    '    If Me.Visible Then
    '        Me.Location = Me.PointToScreen(New Point(109, 0))
    '    End If
    'End Sub

    Private Sub ShutdownAfterRunToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShutdownAfterRunToolStripMenuItem.Click


        Select Case isShutDownAuto
            Case True '"√Shut down after run over"
                Dim i = MsgBox("Would you like to cancel the shut down plan?", MsgBoxStyle.YesNo)
                If i = MsgBoxResult.Yes Then
                    ' ShutdownAfterRunToolStripMenuItem.Text = "Shut down after run over"
                    'ShutdownAfterRunToolStripMenuItem.Image = Nothing
                    'ToolStripButton_ShutDown.Image = My.Resources.shutdown3
                    ToolStripButton_ShutDown.Text = "Shut down - Off"
                    If IsNothing(shutDownThread) Then
                    Else
                        If shutDownThread.IsAlive Then
                            shutDownThread.Abort()
                        End If
                        shutDownThread = Nothing
                    End If
                    Label_shutdown.Visible = False
                End If
                isShutDownAuto = False

            Case False '"Shut down after run over"
                Dim i = MsgBox("Would you like to shut down your computer after a recent run is over?", MsgBoxStyle.YesNo)
                If i = MsgBoxResult.Yes Then
                    ToolStripButton_ShutDown.Text = "Shut down - On"
                    shutDownThread = New Thread(AddressOf shutDownComputerTask)
                    shutDownThread.IsBackground = True
                    shutDownThread.Start()
                    Label_shutdown.Visible = True
                    If L_TimeRemaining.Visible Then
                        Label_shutdown.Location = New Point(Label_shutdown.Location.X, ToolStrip.Location.Y + 15)
                        Label_shutdown.BringToFront()
                        L_TimeRemaining.BringToFront()
                    Else
                        Label_shutdown.Location = New Point(Label_shutdown.Location.X, ToolStrip.Location.Y + 1)
                        Label_shutdown.BringToFront()
                        L_TimeRemaining.BringToFront()
                    End If


                End If
                isShutDownAuto = True
        End Select

    End Sub
    Sub shutDownComputerTask()
        runOverAsNormalStatus = False
        Do While True
            waitTime(1000)
            If runOverAsNormalStatus Then
                Exit Do
            End If
        Loop
        Shell("shutdown.exe -s -t 10")
    End Sub

    Private Sub Bt_MoreConntrol_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bt_RunningMgmt.Click
        If IsNothing(handleformMoreControlTh) Then
            handleformMoreControlTh = New Thread(AddressOf handleformMoreControl)
            handleformMoreControlTh.IsBackground = True
            Dim point = Me.PointToScreen(New Point(Me.MenuStrip.Location.X, Me.MenuStrip.Location.Y))
            handleformMoreControlTh.Start(point)
        Else
            If handleformMoreControlTh.IsAlive = False Then
                handleformMoreControlTh = Nothing
                handleformMoreControlTh = New Thread(AddressOf handleformMoreControl)
                handleformMoreControlTh.IsBackground = True
                Dim point = Me.PointToScreen(New Point(Me.MenuStrip.Location.X, Me.MenuStrip.Location.Y))
                handleformMoreControlTh.Start(point)
            Else
                handleformMoreControlTh.Abort()
                handleformMoreControlTh = Nothing
                handleformMoreControlTh = New Thread(AddressOf handleformMoreControl)
                handleformMoreControlTh.IsBackground = True
                Dim point = Me.PointToScreen(New Point(Me.MenuStrip.Location.X, Me.MenuStrip.Location.Y))
                handleformMoreControlTh.Start(point)
            End If
        End If
        Bt_RunningMgmt.Enabled = False
    End Sub

    Public Items_LV_Standby_Slave_Remote(-1) As Array
    Public Items_LV_Standby_Mission_Remote(-1) As Array
    Public Items_LV_Standby_Mission_Normal(-1) As Array

    Sub handleformMoreControl(ByVal point As Point)
        If CB_NormalRun.Checked Then
            Dim formMoreControl As New Form_RunMgmt
            formMoreControl.L_Tip_EditMission.Hide()
            formMoreControl.L_ListSlaveStandBy.Enabled = False
            formMoreControl.L_ListSlaveInMission.Enabled = False
            formMoreControl.ListView_Standby_Slave.Enabled = False
            formMoreControl.ListView_SlaveInMission.Enabled = False
            formMoreControl.BT_SlaveRD.Enabled = False
            formMoreControl.Bt_New.Enabled = False
            formMoreControl.Bt_Remove.Enabled = False
            formMoreControl.BT_A.Enabled = False
            formMoreControl.Bt_R.Enabled = False
            If UBound(Items_LV_Standby_Mission_Normal) > -1 Then
                For i = 0 To UBound(Items_LV_Standby_Mission_Normal)
                    Dim newitem = formMoreControl.ListView_StandBy_TestMission.Items.Add(Items_LV_Standby_Mission_Normal(i)(0))
                    newitem.SubItems.Add(Items_LV_Standby_Mission_Normal(i)(1))
                Next
            End If

            formMoreControl.Show()
            formMoreControl.BringToFront()
            formMoreControl.Location = point
            formMoreControl.BT_A_Mission.Enabled = True
            formMoreControl.BT_R_Mission.Enabled = True

            Dim cur = formMoreControl.BT_TopBar.Text
            formMoreControl.BT_TopBar.Text = cur + " (Local Mode)"

            Do While formMoreControl.Visible
                If formMoreControl.ListView_StandBy_TestMission.Items.Count > 0 Then
                    ReDim Items_LV_Standby_Mission_Normal(-1)
                    For Each item In formMoreControl.ListView_StandBy_TestMission.Items
                        If Trim(item.text) <> "" Then
                            ReDim Preserve Items_LV_Standby_Mission_Normal(UBound(Items_LV_Standby_Mission_Normal) + 1)
                            Items_LV_Standby_Mission_Normal(UBound(Items_LV_Standby_Mission_Normal)) = {item.text, item.subitems.item(1).text}
                        End If

                    Next
                Else
                    ReDim Items_LV_Standby_Mission_Normal(-1)
                End If
                Dim missionInfo = ExecutionOperator.arryRunList
                If IsNothing(missionInfo) = False Then
                    Dim findMission = False
                    On Error GoTo errorline
                    If UBound(formMoreControl.Runlist_RunningMissionRelationShip) > -1 Then
                        For i = 0 To UBound(missionInfo)
                            If IsNothing(missionInfo(i)) = False Then
                                If IsNothing(formMoreControl.Runlist_RunningMissionRelationShip(i)(1)) = False Then
                                    Dim intboolean = formMoreControl.Runlist_RunningMissionRelationShip(i)(1).GetType.Name.ToLower.StartsWith("int")
                                    If intboolean Then
                                        'Dim newItem = formMoreControl.ListView_TestInMission.Items.Add(missionInfo(i)(0))
                                        'newItem.SubItems.Add(missionInfo(i)(2))
                                        'newItem.SubItems.Add(missionInfo(i)(1))
                                        'formMoreControl.Runlist_RunningMissionRelationShip(i)(1) = newItem
                                    Else
                                        findMission = True
                                        If formMoreControl.Runlist_RunningMissionRelationShip(i)(1).SubItems.item(1).text = missionInfo(i)(2) Then
                                        Else
                                            formMoreControl.Runlist_RunningMissionRelationShip(i)(1).SubItems.item(1).text = missionInfo(i)(2)
                                        End If

                                        If formMoreControl.Runlist_RunningMissionRelationShip(i)(1).SubItems.item(2).text = missionInfo(i)(1) Then
                                        Else
                                            formMoreControl.Runlist_RunningMissionRelationShip(i)(1).SubItems.item(2).text = missionInfo(i)(1)
                                        End If
                                    End If
                                Else
                                    Dim newItem = formMoreControl.ListView_TestInMission.Items.Add(missionInfo(i)(0))
                                    newItem.SubItems.Add(missionInfo(i)(2))
                                    newItem.SubItems.Add(missionInfo(i)(1))
                                    formMoreControl.Runlist_RunningMissionRelationShip(i)(1) = newItem
                                End If


                            Else
                                If IsNothing(formMoreControl.Runlist_RunningMissionRelationShip(i)(1)) = False Then
                                    Dim intboolean = formMoreControl.Runlist_RunningMissionRelationShip(i)(1).GetType.Name.ToLower.StartsWith("int")
                                    If intboolean = False Then
                                        formMoreControl.ListView_TestInMission.Items.Remove(formMoreControl.Runlist_RunningMissionRelationShip(i)(1))
                                    End If
                                End If
                            End If
                        Next
                    Else
                        For i = 0 To UBound(missionInfo)
                            If IsNothing(missionInfo(i)) = False Then
                                findMission = True
                                Dim newItem = formMoreControl.ListView_TestInMission.Items.Add(missionInfo(i)(0))
                                newItem.SubItems.Add(missionInfo(i)(2))
                                newItem.SubItems.Add(missionInfo(i)(1))
                                ReDim Preserve formMoreControl.Runlist_RunningMissionRelationShip(UBound(formMoreControl.Runlist_RunningMissionRelationShip) + 1)
                                formMoreControl.Runlist_RunningMissionRelationShip(UBound(formMoreControl.Runlist_RunningMissionRelationShip)) = {i, newItem}
                            Else
                                ReDim Preserve formMoreControl.Runlist_RunningMissionRelationShip(UBound(formMoreControl.Runlist_RunningMissionRelationShip) + 1)
                                formMoreControl.Runlist_RunningMissionRelationShip(UBound(formMoreControl.Runlist_RunningMissionRelationShip)) = {i, Nothing}
                            End If
                        Next

                    End If

                    If findMission = False Then
                        Do While formMoreControl.ListView_TestInMission.Items.Count > 0
                            formMoreControl.ListView_TestInMission.Items.RemoveAt(0)
                        Loop
                    End If
                Else
                    Do While formMoreControl.ListView_TestInMission.Items.Count > 0
                        formMoreControl.ListView_TestInMission.Items.RemoveAt(0)
                    Loop
                End If
                Dim n = formMoreControl.ListView_TestInMission.Items.Count
                Dim n1 = formMoreControl.ListView_StandBy_TestMission.Items.Count
                Dim n2 = formMoreControl.ListView_SlaveInMission.Items.Count
                Dim n3 = formMoreControl.ListView_Standby_Slave.Items.Count
                If n <> 0 Then
                    formMoreControl.L_TestNRInMission.Visible = True
                    formMoreControl.L_TestNRInMission.Text = n.ToString
                Else
                    formMoreControl.L_TestNRInMission.Visible = False
                End If
                If n1 <> 0 Then
                    formMoreControl.L_TestNrStandby.Visible = True
                    formMoreControl.L_TestNrStandby.Text = n1.ToString
                Else
                    formMoreControl.L_TestNrStandby.Visible = False
                End If
                If n2 <> 0 Then
                    formMoreControl.L_SlaveInMission.Visible = True
                    formMoreControl.L_SlaveInMission.Text = n2.ToString
                Else
                    formMoreControl.L_SlaveInMission.Visible = False
                End If
                If n3 <> 0 Then
                    formMoreControl.L_SlaveStandby.Visible = True
                    formMoreControl.L_SlaveStandby.Text = n3.ToString
                Else
                    formMoreControl.L_SlaveStandby.Visible = False
                End If


errorline:
                waitTime(100)

            Loop
        End If
        If CB_Servers.Checked Then
            Dim formMoreControl As New Form_RunMgmt
            If UBound(Items_LV_Standby_Slave_Remote) > -1 Then
                For i = 0 To UBound(Items_LV_Standby_Slave_Remote)
                    Dim newitem = formMoreControl.ListView_Standby_Slave.Items.Add(Items_LV_Standby_Slave_Remote(i)(0))
                    newitem.SubItems.Add(Items_LV_Standby_Slave_Remote(i)(1))
                Next
            End If

            If UBound(Items_LV_Standby_Mission_Remote) > -1 Then
                For i = 0 To UBound(Items_LV_Standby_Mission_Remote)
                    Dim newitem = formMoreControl.ListView_StandBy_TestMission.Items.Add(Items_LV_Standby_Mission_Remote(i)(0))
                    newitem.SubItems.Add(Items_LV_Standby_Mission_Remote(i)(1))
                Next
            End If

            formMoreControl.Show()
            formMoreControl.BringToFront()
            formMoreControl.Location = point

            Dim startCustomModel = Form_Main.CustomRemoteTestModel
            Dim startHostModel = Form_Main.HostModel
            If Form_Main.CustomRemoteTestModel Then
                formMoreControl.BT_A_Mission.Enabled = False
                formMoreControl.BT_R_Mission.Enabled = False
                formMoreControl.L_Tip_EditMission.Show()
            Else
                formMoreControl.BT_A_Mission.Enabled = True
                formMoreControl.BT_R_Mission.Enabled = True
                formMoreControl.L_Tip_EditMission.Hide()
            End If
            Dim cur = formMoreControl.BT_TopBar.Text
            If Form_Main.CustomRemoteTestModel = True And Form_Main.HostModel = True Then
                formMoreControl.BT_TopBar.Text = cur + " (Remote Mode + Host Mode + Custom Mission)"
            ElseIf Form_Main.CustomRemoteTestModel = True And Form_Main.HostModel = False Then
                formMoreControl.BT_TopBar.Text = cur + " (Remote Mode + Custom Mission)"
            ElseIf Form_Main.CustomRemoteTestModel = False And Form_Main.HostModel = True Then
                formMoreControl.BT_TopBar.Text = cur + " (Remote Mode + Host Mode + Auto Mission)"
            ElseIf Form_Main.CustomRemoteTestModel = False And Form_Main.HostModel = False Then
                formMoreControl.BT_TopBar.Text = cur + " (Remote Mode + Auto Mission)"
            End If

            Do While formMoreControl.Visible

                Dim curCustomModel = Form_Main.CustomRemoteTestModel
                Dim curHostModel = Form_Main.HostModel

                If startHostModel <> curHostModel Then
                    formMoreControl.ListView_Standby_Slave.Items.Clear()
                    startHostModel = curHostModel
                End If
                If startCustomModel <> curCustomModel Then
                    formMoreControl.ListView_StandBy_TestMission.Items.Clear()
                    If Form_Main.CustomRemoteTestModel Then
                        formMoreControl.BT_A_Mission.Enabled = False
                        formMoreControl.BT_R_Mission.Enabled = False
                        formMoreControl.L_Tip_EditMission.Show()
                    Else
                        formMoreControl.BT_A_Mission.Enabled = True
                        formMoreControl.BT_R_Mission.Enabled = True
                        formMoreControl.L_Tip_EditMission.Hide()
                    End If
                    startCustomModel = curCustomModel
                End If

                If Form_Main.CustomRemoteTestModel = True And Form_Main.HostModel = True Then
                    formMoreControl.BT_TopBar.Text = cur + " (Remote Mode + Host Mode + Custom Mission)"
                ElseIf Form_Main.CustomRemoteTestModel = True And Form_Main.HostModel = False Then
                    formMoreControl.BT_TopBar.Text = cur + " (Remote Mode + Custom Mission)"
                ElseIf Form_Main.CustomRemoteTestModel = False And Form_Main.HostModel = True Then
                    formMoreControl.BT_TopBar.Text = cur + " (Remote Mode + Host Mode + Auto Mission)"
                ElseIf Form_Main.CustomRemoteTestModel = False And Form_Main.HostModel = False Then
                    formMoreControl.BT_TopBar.Text = cur + " (Remote Mode + Auto Mission)"
                End If

                If formMoreControl.ListView_Standby_Slave.Items.Count > 0 Then
                    ReDim Items_LV_Standby_Slave_Remote(-1)
                    For Each item In formMoreControl.ListView_Standby_Slave.Items
                        If Trim(item.text) <> "" Then
                            ReDim Preserve Items_LV_Standby_Slave_Remote(UBound(Items_LV_Standby_Slave_Remote) + 1)
                            Items_LV_Standby_Slave_Remote(UBound(Items_LV_Standby_Slave_Remote)) = {item.text, item.subitems.item(1).text}
                        End If

                    Next
                Else
                    ReDim Items_LV_Standby_Slave_Remote(-1)
                End If

                Dim findnottimeout = False
                Dim info = ExecutionOperator.arryServerFullyInfo
                If IsNothing(info) = False Then
                    Dim findServer = False
                    On Error GoTo errorline2
                    For i = 0 To UBound(info)
                        If IsNothing(info(i)) = False Then
                            findServer = True

                            If formMoreControl.ListView_SlaveInMission.Items.Count > 0 Then
                                Dim findItem = False
                                For j = 0 To formMoreControl.ListView_SlaveInMission.Items.Count - 1
                                    If info(i)(1) = formMoreControl.ListView_SlaveInMission.Items.Item(j).Text Then
                                        findItem = True
                                        If formMoreControl.ListView_SlaveInMission.Items.Item(j).SubItems.Item(1).Text = info(i)(2) Then
                                        Else
                                            formMoreControl.ListView_SlaveInMission.Items.Item(j).SubItems.Item(1).Text = info(i)(2)
                                        End If
                                        If formMoreControl.ListView_SlaveInMission.Items.Item(j).SubItems.Item(2).Text = info(i)(0) Then
                                        Else
                                            formMoreControl.ListView_SlaveInMission.Items.Item(j).SubItems.Item(2).Text = info(i)(0)
                                        End If

                                        Exit For
                                    End If
                                Next
                                If findItem = False Then
                                    Dim newItem = formMoreControl.ListView_SlaveInMission.Items.Add(info(i)(1))
                                    newItem.SubItems.Add(info(i)(2))
                                    newItem.SubItems.Add(info(i)(0))

                                End If
                            Else
                                Dim newItem = formMoreControl.ListView_SlaveInMission.Items.Add(info(i)(1))
                                newItem.SubItems.Add(info(i)(2))
                                newItem.SubItems.Add(info(i)(0))
                            End If
                        End If
                    Next
                    If findServer = False Then
                        Do While formMoreControl.ListView_SlaveInMission.Items.Count > 0
                            formMoreControl.ListView_SlaveInMission.Items.RemoveAt(0)
                        Loop
                    End If
                Else
                    Do While formMoreControl.ListView_SlaveInMission.Items.Count > 0
                        formMoreControl.ListView_SlaveInMission.Items.RemoveAt(0)
                    Loop

                End If

                If formMoreControl.ListView_StandBy_TestMission.Items.Count > 0 Then
                    ReDim Items_LV_Standby_Mission_Remote(-1)
                    For Each item In formMoreControl.ListView_StandBy_TestMission.Items
                        If Trim(item.text) <> "" Then
                            ReDim Preserve Items_LV_Standby_Mission_Remote(UBound(Items_LV_Standby_Mission_Remote) + 1)
                            Items_LV_Standby_Mission_Remote(UBound(Items_LV_Standby_Mission_Remote)) = {item.text, item.subitems.item(1).text}
                        End If

                    Next
                Else
                    ReDim Items_LV_Standby_Mission_Remote(-1)
                End If
                Dim missionInfo = ExecutionOperator.arryRunList
                If IsNothing(missionInfo) = False Then
                    Dim findMission = False
                    On Error GoTo errorline2
                    If UBound(formMoreControl.Runlist_RunningMissionRelationShip) > -1 Then
                        For i = 0 To UBound(missionInfo)
                            If IsNothing(missionInfo(i)) = False Then
                                If IsNothing(formMoreControl.Runlist_RunningMissionRelationShip(i)(1)) = False Then
                                    Dim intboolean = formMoreControl.Runlist_RunningMissionRelationShip(i)(1).GetType.Name.ToLower.StartsWith("int")
                                    If intboolean Then
                                        'Dim newItem = formMoreControl.ListView_TestInMission.Items.Add(missionInfo(i)(0))
                                        'newItem.SubItems.Add(missionInfo(i)(2))
                                        'newItem.SubItems.Add(missionInfo(i)(1))
                                        'formMoreControl.Runlist_RunningMissionRelationShip(i)(1) = newItem
                                    Else

                                        findMission = True
                                        If formMoreControl.Runlist_RunningMissionRelationShip(i)(1).SubItems.item(1).text = missionInfo(i)(2) Then
                                        Else
                                            formMoreControl.Runlist_RunningMissionRelationShip(i)(1).SubItems.item(1).text = missionInfo(i)(2)
                                        End If

                                        If formMoreControl.Runlist_RunningMissionRelationShip(i)(1).SubItems.item(2).text = missionInfo(i)(1) Then
                                        Else
                                            formMoreControl.Runlist_RunningMissionRelationShip(i)(1).SubItems.item(2).text = missionInfo(i)(1)
                                        End If
                                    End If
                                Else
                                    Dim newItem = formMoreControl.ListView_TestInMission.Items.Add(missionInfo(i)(0))
                                    newItem.SubItems.Add(missionInfo(i)(2))
                                    newItem.SubItems.Add(missionInfo(i)(1))
                                    formMoreControl.Runlist_RunningMissionRelationShip(i)(1) = newItem
                                End If
                            Else

                                If IsNothing(formMoreControl.Runlist_RunningMissionRelationShip(i)(1)) = False Then
                                    Dim intboolean = formMoreControl.Runlist_RunningMissionRelationShip(i)(1).GetType.Name.ToLower.StartsWith("int")
                                    If intboolean = False Then
                                        formMoreControl.ListView_TestInMission.Items.Remove(formMoreControl.Runlist_RunningMissionRelationShip(i)(1))
                                    End If
                                End If

                            End If
                        Next
                    Else
                        For i = 0 To UBound(missionInfo)
                            If IsNothing(missionInfo(i)) = False Then
                                findMission = True
                                Dim newItem = formMoreControl.ListView_TestInMission.Items.Add(missionInfo(i)(0))
                                newItem.SubItems.Add(missionInfo(i)(2))
                                newItem.SubItems.Add(missionInfo(i)(1))
                                ReDim Preserve formMoreControl.Runlist_RunningMissionRelationShip(UBound(formMoreControl.Runlist_RunningMissionRelationShip) + 1)
                                formMoreControl.Runlist_RunningMissionRelationShip(UBound(formMoreControl.Runlist_RunningMissionRelationShip)) = {i, newItem}
                            Else
                                ReDim Preserve formMoreControl.Runlist_RunningMissionRelationShip(UBound(formMoreControl.Runlist_RunningMissionRelationShip) + 1)
                                formMoreControl.Runlist_RunningMissionRelationShip(UBound(formMoreControl.Runlist_RunningMissionRelationShip)) = {i, Nothing}
                            End If
                        Next

                    End If

                    If findMission = False Then
                        Do While formMoreControl.ListView_TestInMission.Items.Count > 0
                            formMoreControl.ListView_TestInMission.Items.RemoveAt(0)
                        Loop
                    End If
                Else
                    Do While formMoreControl.ListView_TestInMission.Items.Count > 0
                        formMoreControl.ListView_TestInMission.Items.RemoveAt(0)
                    Loop
                End If
                Dim n = formMoreControl.ListView_TestInMission.Items.Count
                Dim n1 = formMoreControl.ListView_StandBy_TestMission.Items.Count
                Dim n2 = formMoreControl.ListView_SlaveInMission.Items.Count
                Dim n3 = formMoreControl.ListView_Standby_Slave.Items.Count
                If n <> 0 Then
                    formMoreControl.L_TestNRInMission.Visible = True
                    formMoreControl.L_TestNRInMission.Text = n.ToString
                Else
                    formMoreControl.L_TestNRInMission.Visible = False
                End If
                If n1 <> 0 Then
                    formMoreControl.L_TestNrStandby.Visible = True
                    formMoreControl.L_TestNrStandby.Text = n1.ToString
                Else
                    formMoreControl.L_TestNrStandby.Visible = False
                End If
                If n2 <> 0 Then
                    formMoreControl.L_SlaveInMission.Visible = True
                    formMoreControl.L_SlaveInMission.Text = n2.ToString
                Else
                    formMoreControl.L_SlaveInMission.Visible = False
                End If
                If n3 <> 0 Then
                    formMoreControl.L_SlaveStandby.Visible = True
                    formMoreControl.L_SlaveStandby.Text = n3.ToString
                Else
                    formMoreControl.L_SlaveStandby.Visible = False
                End If
errorline2:
                waitTime(100)

            Loop
        End If

        Invoke(New Delegate_Normal(AddressOf enable_Bt_MoreConntrol))

    End Sub
    Sub enable_Bt_MoreConntrol()
        Bt_RunningMgmt.Enabled = True
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bt_EditSlaveIPs.Click
        Dim editForm As New Form_EditRemote
        Bt_Run.Enabled = False
        Bt_EditSlaveIPs.Enabled = False
        editBoxName_Remote = "ip"
        editForm.editBoxName = editBoxName_Remote
        editForm.ToolTip_Format.SetToolTip(editForm.LB_Content, "Format is 31.22.12.13")
        editForm.LB_Content.Items.Clear()
        editForm.L_Title.Text = "IP address of Slaves"
        If TB_RR_IPs.Text <> "" Then
            Dim IPsArray = Split(TB_RR_IPs.Text, "@")
            For i = 0 To UBound(IPsArray)
                Dim curItem = editForm.LB_Content.Items.Add(IPsArray(i))
                curItem.SubItems.Add("")
            Next
        End If
        editForm.Show()


        Dim content = ""
        Do
            Application.DoEvents()
            content = editForm.myContent
        Loop Until editForm.IsFormClosing = 1
        If content <> "" Then
            Me.TB_RR_IPs.Text = content
        End If
        Bt_EditSlaveIPs.Enabled = True
        Bt_Run.Enabled = True
    End Sub

    Private Sub BT_CheckServers_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_EditResource.Click
        Dim editForm As New Form_EditRemote
        BT_EditResource.Enabled = False
        Bt_Run.Enabled = False
        If CB_HostMode.Checked Then
            editBoxName_Remote = "hostres"
            editForm.editBoxName = editBoxName_Remote
            editForm.ToolTip_Format.SetToolTip(editForm.LB_Content, "Format likes \\31.22.12.13\AT_Resource_Root_Folder")
            editForm.LB_Content.Items.Clear()
            editForm.L_Title.Text = "Path of shared folder of Host"
            If TB_RR_Dir.Text <> "" Then
                Dim IPsArray = Split(TB_RR_Dir.Text, "@")
                For i = 0 To UBound(IPsArray)
                    Dim curItem = editForm.LB_Content.Items.Add(IPsArray(i))
                    curItem.SubItems.Add("")
                Next
            End If
            editForm.Show()

        Else
            If ProjectType = "UFT Project" Then
                editBoxName_Remote = "res"
                editForm.editBoxName = editBoxName_Remote
                editForm.ToolTip_Format.SetToolTip(editForm.LB_Content, "Format likes \\31.22.12.13\AT_Resource_Root_Folder")
                editForm.LB_Content.Items.Clear()
                editForm.L_Title.Text = "Path of shared folder of Slave"
                If TB_RR_Dir.Text <> "" Then
                    Dim IPsArray = Split(TB_RR_Dir.Text, "@")
                    For i = 0 To UBound(IPsArray)
                        Dim curItem = editForm.LB_Content.Items.Add(IPsArray(i))
                        curItem.SubItems.Add("")
                    Next
                End If
                editForm.Show()
            End If

            If ProjectType = "Maven Project" Then
                editBoxName_Remote = "stafres"
                editForm.editBoxName = editBoxName_Remote
                editForm.ToolTip_Format.SetToolTip(editForm.LB_Content, "Format likes %31.22.12.13%C:\AT_Resource_Root_Folder")
                editForm.LB_Content.Items.Clear()
                editForm.L_Title.Text = "Path of project folder of Slave"
                If TB_RR_Dir.Text <> "" Then
                    Dim IPsArray = Split(TB_RR_Dir.Text, "@")
                    For i = 0 To UBound(IPsArray)
                        Dim curItem = editForm.LB_Content.Items.Add(IPsArray(i))
                        curItem.SubItems.Add("")
                    Next
                End If
                editForm.Show()
            End If
        End If
        Dim content = ""
        Do
            Application.DoEvents()
            content = editForm.myContent
        Loop Until editForm.IsFormClosing = 1
        If content <> "" Then
            Me.TB_RR_Dir.Text = content
        End If
        BT_EditResource.Enabled = True
        Bt_Run.Enabled = True

    End Sub

    Sub AssociateTip(ByRef t As ToolTip, ByRef o As Object, ByRef msg As String)
        t.SetToolTip(o, msg)
    End Sub

    Private Sub Label_localrun_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If CB_NormalRun.Checked Then
            CB_NormalRun.Checked = False
        Else
            CB_NormalRun.Checked = True
        End If
    End Sub


    Private Sub Label_RemoteRun_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If CB_Servers.Checked Then
            CB_Servers.Checked = False
        Else
            CB_Servers.Checked = True
        End If
    End Sub

    Private Sub L_CRT_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If CB_CRT.Checked Then
            CB_CRT.Checked = False
        Else
            CB_CRT.Checked = True
        End If

    End Sub

    Private Sub AlarmToRunToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AlarmToRunToolStripMenuItem.Click
        Alarm.Show()
    End Sub


    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton_OpenConfiguration.Click
        OpenConfigurationToolStripMenuItem.PerformClick()
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton_CheckSlaveStatus.Click
        CheckRemoteUFTStatusToolStripMenuItem.PerformClick()
    End Sub

    Private Sub CheckRemoteUFTStatusToolStripMenuItem_EnabledChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckRemoteUFTStatusToolStripMenuItem.EnabledChanged
        If CheckRemoteUFTStatusToolStripMenuItem.Enabled Then
            ToolStripButton_CheckSlaveStatus.Enabled = True
        Else
            ToolStripButton_CheckSlaveStatus.Enabled = False
        End If
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton_RDM.Click
        RemoteDesktopManagerToolStripMenuItem.PerformClick()
    End Sub

    Private Sub RemoteDesktopManagerToolStripMenuItem_EnabledChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RemoteDesktopManagerToolStripMenuItem.EnabledChanged
        If RemoteDesktopManagerToolStripMenuItem.Enabled Then
            ToolStripButton_RDM.Enabled = True
        Else
            ToolStripButton_RDM.Enabled = False
        End If
    End Sub

    Private Sub L_TimeRemaining_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles L_TimeRemaining.Click
        Alarm.Show()
    End Sub

    Private Sub ConfiguraionFileChange()
        Dim cur = BT_TopBar.Text
        If cur.Contains("ATester -") And (Not cur.Contains(".atplan*")) Then
            BT_TopBar.Text = cur + "*"
        End If

    End Sub

    Private Sub TB_ReportFolder_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TB_ReportFolder.TextChanged
        ConfiguraionFileChange()
    End Sub


    Private Sub TB_ReportFolder_R_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TB_ReportFolder_R.TextChanged
        ConfiguraionFileChange()
    End Sub


    Private Sub ToolStripButton_SavePlan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton_SavePlan.Click
        SaveConfigurationAsToolStripMenuItem.PerformClick()
    End Sub

    Private Sub ToolStripButton_ShutDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton_ShutDown.Click
        Dim cur = ToolStripButton_ShutDown.Enabled
        ToolStripButton_ShutDown.Enabled = Not cur
        ToolStripButton_ShutDown.Enabled = cur
        ShutdownAfterRunToolStripMenuItem.PerformClick()

    End Sub

    Private Sub L_TBL_EnabledChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles L_TestMissionTitle.EnabledChanged
        If L_TestMissionTitle.Enabled Then
            L_TestMissionTitle.BackColor = GetVbColor(My.Resources.NormalbarBackColor_Enabled)
            L_TestMissionTitle.ForeColor = GetVbColor(My.Resources.NormalbarForeColor_Enabled)
        Else
            L_TestMissionTitle.BackColor = GetVbColor(My.Resources.NormalbarBackColor_Disabled)
            L_TestMissionTitle.ForeColor = GetVbColor(My.Resources.NormalbarForeColor_Disabled)
        End If
    End Sub


    Private Sub L_RunModel_EnabledChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles L_RunMode.EnabledChanged
        If L_RunMode.Enabled Then
            L_RunMode.BackColor = GetVbColor(My.Resources.NormalbarBackColor_Enabled)
            L_RunMode.ForeColor = GetVbColor(My.Resources.NormalbarForeColor_Enabled)
        Else
            L_RunMode.BackColor = GetVbColor(My.Resources.NormalbarBackColor_Disabled)
            L_RunMode.ForeColor = GetVbColor(My.Resources.NormalbarForeColor_Disabled)

        End If
    End Sub

    Private Sub Label6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles L_RunningStatus.EnabledChanged
        If L_RunningStatus.Enabled Then
            L_RunningStatus.BackColor = GetVbColor(My.Resources.NormalbarBackColor_Enabled)
            L_RunningStatus.ForeColor = GetVbColor(My.Resources.NormalbarForeColor_Enabled)
        Else
            L_RunningStatus.BackColor = GetVbColor(My.Resources.NormalbarBackColor_Disabled)
            L_RunningStatus.ForeColor = GetVbColor(My.Resources.NormalbarForeColor_Disabled)
        End If
    End Sub

    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles L_Reporting.EnabledChanged
        If L_Reporting.Enabled Then
            L_Reporting.BackColor = GetVbColor(My.Resources.NormalbarBackColor_Enabled)
            L_Reporting.ForeColor = GetVbColor(My.Resources.NormalbarForeColor_Enabled)
        Else
            L_Reporting.BackColor = GetVbColor(My.Resources.NormalbarBackColor_Disabled)
            L_Reporting.ForeColor = GetVbColor(My.Resources.NormalbarForeColor_Disabled)
        End If
    End Sub

    Private Sub CB_CRT_EnabledChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CB_CRT.EnabledChanged
        If CB_CRT.Enabled Then
            CB_CRT.BackColor = GetVbColor(My.Resources.NormalSebarBackColor_Enabled)
            CB_CRT.ForeColor = GetVbColor(My.Resources.NormalSebarForeColor_Enabled)
        Else
            CB_CRT.BackColor = Color.Gainsboro
            CB_CRT.ForeColor = GetVbColor(My.Resources.NormalSebarForeColor_Disabled)
        End If
    End Sub

    Public Sub clearCustomMissionMonitor()
        ListView_CustomMission.Items.Clear()
        L_totalOfCustom.Text = "0"
    End Sub

    Private Sub RadioButton_Listbox_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_Listbox.CheckedChanged
        If RadioButton_Listbox.Checked Then
            RadioButton_Textbox.Checked = False

            TB_BPTList.Visible = False
            CLB_Testlist.Visible = True
            CLB_Testlist.BringToFront()
            L_TBRTotal.Text = CStr(CLB_Testlist.CheckedItems.Count)
            RadioButton_Listbox.BackColor = Color.LightGreen
        Else
            RadioButton_Listbox.BackColor = Color.Transparent

        End If

    End Sub

    Private Sub RadioButton_Textbox_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_Textbox.CheckedChanged
        If RadioButton_Textbox.Checked Then
            RadioButton_Listbox.Checked = False

            CLB_Testlist.Visible = False
            TB_BPTList.Visible = True
            TB_BPTList.BringToFront()
            Dim linecount = 0
            For i = 0 To UBound(TB_BPTList.Lines)
                If Trim(TB_BPTList.Lines(i)) <> "" Then
                    linecount = linecount + 1
                End If
            Next
            L_TBRTotal.Text = CStr(linecount)
            TB_BPTList.Focus()
            RadioButton_Textbox.BackColor = Color.LightGreen
        Else
            RadioButton_Textbox.BackColor = Color.Transparent
        End If

    End Sub

    Private Sub L_TimeRemaining_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles L_TimeRemaining.VisibleChanged
        If L_TimeRemaining.Visible Then
            L_TimeRemaining.Location = New Point(Label_shutdown.Location.X, ToolStrip.Location.Y + 1)
            Label_shutdown.Location = New Point(Label_shutdown.Location.X, ToolStrip.Location.Y + 15)
            Label_shutdown.BringToFront()
            L_TimeRemaining.BringToFront()
        Else
            L_TimeRemaining.Location = New Point(Label_shutdown.Location.X, ToolStrip.Location.Y + 1)
            Label_shutdown.Location = New Point(Label_shutdown.Location.X, ToolStrip.Location.Y + 1)
            Label_shutdown.BringToFront()
            L_TimeRemaining.BringToFront()
        End If
    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_LocalMode.CheckedChanged
        If RadioButton_LocalMode.Checked Then
            CB_NormalRun.Checked = True
            'CB_Servers.Checked = False
            RadioButton_LocalMode.BackColor = Color.LightGreen

            Bt_Refresh.Enabled = True

        Else
            RadioButton_LocalMode.BackColor = Color.Transparent
        End If
    End Sub

    Private Sub RadioButton_RemoteMode_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_RemoteMode.CheckedChanged
        If RadioButton_RemoteMode.Checked Then
            CB_Servers.Checked = True
            'CB_NormalRun.Checked = False
            RadioButton_RemoteMode.BackColor = Color.LightGreen
            If CB_HostMode.Checked Then
                Bt_Refresh.Enabled = True
            Else
                Bt_Refresh.Enabled = False
            End If
        Else
            RadioButton_RemoteMode.BackColor = Color.Transparent
        End If
    End Sub

    Private Sub L_Tip_RunResult_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles L_Tip_RunResult.Click
        MsgBox(L_Tip_RunResult_info)
    End Sub

    Private Sub L_tip_Timeout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles L_tip_Timeout.Click
        L_tip_Timeout_info = "1. Allot No is the number of tests will be assigned to one slave at one time." + vbCrLf + "2. Time out is a time that decides one slave does not  work."
        MsgBox(L_tip_Timeout_info)
    End Sub

    Private Sub BT_TopBar_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles BT_TopBar.MouseLeave
        If BT_TopBar.Focused Then
            L_RunMode.Focus()

        End If
    End Sub

    Private Sub ExpandButton_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles ExpandButton.MouseEnter
        If expandlist Then
            ExpandButton.BackgroundImage = My.Resources.adductHover

        Else
            ExpandButton.BackgroundImage = My.Resources.expandHover

        End If
    End Sub

    Private Sub ExpandButton_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ExpandButton.MouseLeave
        If expandlist Then
            ExpandButton.BackgroundImage = My.Resources.adduct

        Else
            ExpandButton.BackgroundImage = My.Resources.expand

        End If
        If ExpandButton.Focused Then
            TB_MainLog.Focus()
        End If
    End Sub

    Private Sub Bt_RunningMgmt_EnabledChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Bt_RunningMgmt.EnabledChanged
        If Bt_RunningMgmt.Enabled Then
            Bt_RunningMgmt.BackgroundImage = My.Resources.mission123
        Else
            Bt_RunningMgmt.BackgroundImage = My.Resources.mission123_disabled
        End If
    End Sub

    Private Sub Bt_RunningMgmt_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Bt_RunningMgmt.MouseEnter
        Bt_RunningMgmt.BackgroundImage = My.Resources.mission123_hover
    End Sub

    Private Sub Bt_RunningMgmt_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Bt_RunningMgmt.MouseLeave
        If Bt_RunningMgmt.Enabled Then
            Bt_RunningMgmt.BackgroundImage = My.Resources.mission123
        End If
    End Sub

    Private Sub BT_CheckReport_EnabledChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles BT_CheckReport.EnabledChanged
        If BT_CheckReport.Enabled Then
            BT_CheckReport.BackgroundImage = My.Resources.buttonYellowBackShort
        Else
            BT_CheckReport.BackgroundImage = My.Resources.backYellowBackShortHover1
        End If
    End Sub

    Private Sub BT_CheckReport_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles BT_CheckReport.MouseEnter
        BT_CheckReport.BackgroundImage = My.Resources.backYellowBackShortHover1
    End Sub

    Private Sub BT_CheckReport_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles BT_CheckReport.MouseLeave
        If BT_CheckReport.Enabled Then
            BT_CheckReport.BackgroundImage = My.Resources.buttonYellowBackShort
        End If

    End Sub

    Private Sub BT_LC_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles BT_LC.MouseEnter
        BT_LC.BackgroundImage = My.Resources.backYellowBackShortHover1
    End Sub

    Private Sub BT_LC_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles BT_LC.MouseLeave
        If BT_LC.Enabled Then
            BT_LC.BackgroundImage = My.Resources.buttonYellowBackShort
        End If

    End Sub

    Private Sub Bt_EditSlaveIPs_EnabledChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Bt_EditSlaveIPs.EnabledChanged
        If Bt_EditSlaveIPs.Enabled Then
            Bt_EditSlaveIPs.BackgroundImage = My.Resources.buttonYellowBackShort
        Else
            Bt_EditSlaveIPs.BackgroundImage = My.Resources.backYellowBackShortHover1
        End If
    End Sub

    Private Sub Bt_EditSlaveIPs_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Bt_EditSlaveIPs.MouseEnter
        Bt_EditSlaveIPs.BackgroundImage = My.Resources.backYellowBackShortHover1
    End Sub

    Private Sub Bt_EditSlaveIPs_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Bt_EditSlaveIPs.MouseLeave
        If Bt_EditSlaveIPs.Enabled Then
            Bt_EditSlaveIPs.BackgroundImage = My.Resources.buttonYellowBackShort
        End If

    End Sub

    Private Sub BT_EditResource_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles BT_EditResource.MouseEnter
        BT_EditResource.BackgroundImage = My.Resources.backYellowBackHover
    End Sub

    Private Sub BT_EditResource_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles BT_EditResource.MouseLeave
        If BT_EditResource.Enabled Then
            BT_EditResource.BackgroundImage = My.Resources.buttonYellowBackShort
        End If

    End Sub

    Private Sub Bt_select_All_EnabledChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Bt_select_All.EnabledChanged
        If Bt_select_All.Enabled Then
            Bt_select_All.BackgroundImage = My.Resources.buttonYellowBackNormal
        Else
            Bt_select_All.BackgroundImage = My.Resources.backYellowBackHover
        End If
    End Sub

    Private Sub Bt_select_All_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Bt_select_All.MouseEnter
        Bt_select_All.BackgroundImage = My.Resources.backYellowBackHover
    End Sub

    Private Sub Bt_select_All_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Bt_select_All.MouseLeave
        If Bt_select_All.Enabled Then
            Bt_select_All.BackgroundImage = My.Resources.buttonYellowBackNormal
        End If

    End Sub

    Private Sub Bt_Clean_All_EnabledChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Bt_Clean_All.EnabledChanged
        If Bt_Clean_All.Enabled Then
            Bt_Clean_All.BackgroundImage = My.Resources.buttonYellowBackNormal
        Else
            Bt_Clean_All.BackgroundImage = My.Resources.backYellowBackHover
        End If
    End Sub


    Private Sub Bt_Clean_All_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Bt_Clean_All.MouseEnter
        Bt_Clean_All.BackgroundImage = My.Resources.backYellowBackHover
    End Sub

    Private Sub Bt_Clean_All_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Bt_Clean_All.MouseLeave
        If Bt_Clean_All.Enabled Then
            Bt_Clean_All.BackgroundImage = My.Resources.buttonYellowBackNormal
        End If

    End Sub

    Private Sub Bt_Refresh_EnabledChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Bt_Refresh.EnabledChanged
        If Bt_Refresh.Enabled Then
            Bt_Refresh.BackgroundImage = My.Resources.buttonYellowBackNormal
        Else
            Bt_Refresh.BackgroundImage = My.Resources.backYellowBackHover
        End If
    End Sub

    Private Sub Bt_Refresh_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Bt_Refresh.MouseEnter
        Bt_Refresh.BackgroundImage = My.Resources.backYellowBackHover
    End Sub

    Private Sub Bt_Refresh_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Bt_Refresh.MouseLeave
        If Bt_Refresh.Enabled Then
            Bt_Refresh.BackgroundImage = My.Resources.buttonYellowBackNormal
        End If

    End Sub

    Private Sub Bt_MissionPanel_EnabledChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Bt_MissionPanel.EnabledChanged
        If Bt_MissionPanel.Enabled Then
            Bt_MissionPanel.BackgroundImage = My.Resources.buttonYellowBackNormal
        Else
            Bt_MissionPanel.BackgroundImage = My.Resources.backYellowBackHover
        End If
    End Sub

    Private Sub Bt_MissionPanel_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Bt_MissionPanel.MouseEnter
        Bt_MissionPanel.BackgroundImage = My.Resources.backYellowBackHover
    End Sub

    Private Sub Bt_MissionPanel_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Bt_MissionPanel.MouseLeave
        If Bt_MissionPanel.Enabled Then
            Bt_MissionPanel.BackgroundImage = My.Resources.buttonYellowBackNormal
        End If

    End Sub

    Private Sub BT_Erase_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles BT_Erase.MouseEnter
        BT_Erase.BackgroundImage = My.Resources.cleanLog3Hover
    End Sub

    Private Sub BT_Erase_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles BT_Erase.MouseLeave
        If BT_Erase.Enabled Then
            BT_Erase.BackgroundImage = My.Resources.cleanLog3Normal
        End If

    End Sub

    Private Sub BT_Clean_LC_Save_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Clean_LC_Save.MouseLeave
        BT_Clean_LC_Save.BackgroundImage = ATester.My.Resources.Resources.del_nor
    End Sub

    Private Sub BT_Clean_LC_Save_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles BT_Clean_LC_Save.MouseEnter
        BT_Clean_LC_Save.BackgroundImage = ATester.My.Resources.Resources.delete
    End Sub

    Private Sub BT_Clean_RR_Dirs_Save_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles BT_Clean_RR_Dirs_Save.MouseEnter
        BT_Clean_RR_Dirs_Save.BackgroundImage = ATester.My.Resources.Resources.delete
    End Sub

    Private Sub BT_Clean_RR_Dirs_Save_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles BT_Clean_RR_Dirs_Save.MouseLeave
        BT_Clean_RR_Dirs_Save.BackgroundImage = ATester.My.Resources.Resources.del_nor

    End Sub

    Private Sub BT_Clean_RR_IPs_Save_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles BT_Clean_RR_IPs_Save.MouseEnter
        BT_Clean_RR_IPs_Save.BackgroundImage = ATester.My.Resources.Resources.delete
    End Sub

    Private Sub BT_Clean_RR_IPs_Save_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles BT_Clean_RR_IPs_Save.MouseLeave
        BT_Clean_RR_IPs_Save.BackgroundImage = ATester.My.Resources.Resources.del_nor

    End Sub

    Private Sub ComboBox_Project_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox_Project.TextChanged

        Select Case ComboBox_Project.Text
            Case "UFT Project"
                ExecutionOperator.projectType = "UFT Project"
                ProjectType = "UFT Project"
                CB_HostMode.Enabled = True
                TB_tsofcase.Enabled = False
            Case "Maven Project"

                ExecutionOperator.projectType = "Maven Project"
                ProjectType = "Maven Project"
                TB_tsofcase.Enabled = True

                CB_HostMode.Checked = False
                CB_HostMode.Enabled = False
        End Select
        TB_Servers_TextChanged(Me, Nothing)
        TB_LC_TextChanged(Me, Nothing)
    End Sub
    'Sub resetKeyControls()
    '    TB_LC.ResetText()
    '    TB_RR_Dir.ResetText()
    '    TB_RR_IPs.ResetText()
    '    CLB_Testlist.Items.Clear()
    '    TB_BPTList.ResetText()
    'End Sub



    Private Sub SelectModulesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectModulesToolStripMenuItem.Click
        Form_Module.Show()

    End Sub

    Private Sub GoldenCasesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GoldenCasesToolStripMenuItem.Click
        Dim exc As New ExcelOperator
        Dim strCaseList As String
        Dim strModuleFilePath As String
        Dim strDataFolderName As String = "Docs"
        Dim strModuleFileName As String = "BPT Owner.xlsx"
        Dim strBPTOwnerFileName As String = "BPT Owner.xlsx"
        Dim strBPTFilePath As String
        Dim strPath As String
        Dim intCaseCount As Integer = 0

        strPath = IIf(Strings.Right(Application.StartupPath, 1) <> "\", Application.StartupPath, Strings.Left(Application.StartupPath, Application.StartupPath.Length - 1))
        strModuleFilePath = Mid(strPath, 1, Strings.InStrRev(strPath, "\")) & strDataFolderName & "\" & strModuleFileName
        strBPTFilePath = Mid(strPath, 1, Strings.InStrRev(strPath, "\")) & strDataFolderName & "\" & strBPTOwnerFileName

        strCaseList = exc.ReadGoldenCaseFromExcel(strModuleFilePath)

        strCaseList = Replace(strCaseList, "||", vbCrLf)
        intCaseCount = Split(strCaseList, vbCrLf).Count

        TB_MainLog.AppendText(intCaseCount & " Golden cases have been loaded into mission list." & vbCrLf)

        Me.TB_BPTList.Text = strCaseList
        Me.CLB_Testlist.Items.Clear()
        Me.CLB_Testlist.Items.AddRange(Split(strCaseList, vbCrLf))

        If Not getExpandList() Then
            ExpandButton.PerformClick()
        End If

        Me.RadioButton_Textbox.Checked = True

    End Sub

    Public Function getExpandList() As Boolean
        Return expandlist
    End Function


    Private Sub TB_tsofcase_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TB_tsofcase.EnabledChanged
        Select Case TB_tsofcase.Enabled
            Case True
                L_tsofcaseTile.Enabled = True
                L_tsofcaseUnit.Enabled = True
            Case False
                L_tsofcaseTile.Enabled = False
                L_tsofcaseUnit.Enabled = False

        End Select
    End Sub

    Private Sub TB_tsofcase_TextChanged1(ByVal sender As Object, ByVal e As System.EventArgs) Handles TB_tsofcase.TextChanged
        If TB_tsofcase.Text <> "" Then
            Dim KeyCode As Integer
            For i = 1 To Len(TB_tsofcase.Text)
                KeyCode = Asc(Mid(TB_tsofcase.Text, i, 1))
                If KeyCode < 48 Or KeyCode > 57 Then
                    TB_tsofcase.Text = Replace(TB_tsofcase.Text, Mid(TB_tsofcase.Text, i, 1), "")
                    TB_tsofcase.Select(i - 1, False)
                    'MsgBox("please input a integer")
                    Exit For
                End If
            Next
        Else
            TB_tsofcase.Text = "0"
        End If
        TB_tsofcase.Text = CInt(TB_tsofcase.Text)
        If CInt(TB_tsofcase.Text) = "0" Then
            TB_tsofcase.Text = "0"
        End If
    End Sub

    Private Sub Link_FR_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles Link_FR.LinkClicked

        If TempTestReportPath.Trim <> "" Then
            MsgBox("Your action on the report may impact the test execution if the excution is not over!" + vbCrLf + "The right way is that copying the report to other place then doing next things.", MsgBoxStyle.OkOnly)
            Class_FolderOperator1.openFolder(TempTestReportPath.Trim)
        Else
            MsgBox("No report right now!", MsgBoxStyle.OkOnly)
        End If

    End Sub
    Dim isBt_MaxListexpand = False
    Private Sub Bt_MaxList_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bt_MaxList.Click

        If isBt_MaxListexpand = False Then

            Panel_TestMissionPanel.Location = New Point(9, Panel_TestMissionPanel.Location.Y)
            Panel_TestMissionPanel.Width = Me.Width - 15

            Panel_TestMissionList.Width = Panel_TestMissionPanel.Width - 15

            Panel_CustomMissionPanel.Location = New Point(9, Panel_CustomMissionPanel.Location.Y)
            Panel_CustomMissionPanel.Width = Me.Width - 15

            ListView_CustomMission.Width = Panel_CustomMissionPanel.Width - 15
            L_TestMissionTitle.Width = Panel_TestMissionPanel.Width
            CB_CRT.Width = Panel_TestMissionPanel.Width

            Bt_MaxList.BackgroundImage = ATester.My.Resources.Resources.drawintestlist
            Bt_MaxList.Parent = L_TestMissionTitle.Parent
            Bt_MaxList.Location = New Point(L_TestMissionTitle.Location.X + L_TestMissionTitle.Width - Bt_MaxList.Width - 2, L_TestMissionTitle.Location.X)
            Bt_MaxList.BringToFront()
            isBt_MaxListexpand = True
        Else
            Panel_TestMissionPanel.Location = Panel_TestMissionPanel_Location
            Panel_TestMissionPanel.Size = Panel_TestMissionPanel_Size
            Panel_TestMissionList.Size = Panel_TestMissionList_Size

            Panel_CustomMissionPanel.Location = Panel_CustomMissionPanel_Location
            Panel_CustomMissionPanel.Size = Panel_CustomMissionPanel_Size
            ListView_CustomMission.Size = ListView_CustomMission_Size
            L_TestMissionTitle.Size = L_TestMissionTitle_Size
            CB_CRT.Size = CB_CRT_Size

            Bt_MaxList.BackgroundImage = ATester.My.Resources.Resources.expandtestlist
            Bt_MaxList.Parent = L_TestMissionTitle.Parent
            Bt_MaxList.Location = New Point(L_TestMissionTitle.Location.X + L_TestMissionTitle.Width - Bt_MaxList.Width - 2, L_TestMissionTitle.Location.X)
            Bt_MaxList.BringToFront()
            isBt_MaxListexpand = False
        End If


        Select Case CB_CRT.Checked
            Case True
                Panel_TestMissionPanel.BringToFront()
                Panel_CustomMissionPanel.BringToFront()

            Case False
                Panel_CustomMissionPanel.BringToFront()
                Panel_TestMissionPanel.BringToFront()

        End Select

        BT_bottom.BringToFront()
        ProgressBar_Run_top.Parent = Me
        ProgressBar_Run_top.BringToFront()
    End Sub


    Private Sub Bt_MaxList_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Bt_MaxList.MouseHover
        If isBt_MaxListexpand = False Then
            ToolTipDeleteInfo.Show("Expand", Bt_MaxList)
        Else
            ToolTipDeleteInfo.Show("Collapse", Bt_MaxList)
        End If

    End Sub
End Class

