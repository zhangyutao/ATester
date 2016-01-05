<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_Main
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_Main))
        Me.Panel_RunStatus = New System.Windows.Forms.Panel()
        Me.L_RunningStatus = New System.Windows.Forms.Label()
        Me.Panel_RunInfo = New System.Windows.Forms.Panel()
        Me.Link_FR = New System.Windows.Forms.LinkLabel()
        Me.BT_Progress = New System.Windows.Forms.Button()
        Me.L_RoundID = New System.Windows.Forms.Label()
        Me.L_PRValue = New System.Windows.Forms.Label()
        Me.L_Remain_Value = New System.Windows.Forms.Label()
        Me.L_Total_Value = New System.Windows.Forms.Label()
        Me.Link_RTR = New System.Windows.Forms.LinkLabel()
        Me.L_Remain = New System.Windows.Forms.Label()
        Me.L_PassRate = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.P_RM = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Bt_RunningMgmt = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Panel_Log = New System.Windows.Forms.Panel()
        Me.BT_Erase = New System.Windows.Forms.Button()
        Me.TB_MainLog = New System.Windows.Forms.TextBox()
        Me.L_LogTitle = New System.Windows.Forms.Label()
        Me.Bt_Log_Edit_Back = New System.Windows.Forms.Button()
        Me.Bt_logback = New System.Windows.Forms.Button()
        Me.Bt_runingst = New System.Windows.Forms.Button()
        Me.Panel_Reporting = New System.Windows.Forms.Panel()
        Me.L_tip_Timeout = New System.Windows.Forms.Button()
        Me.L_Tip_RunResult = New System.Windows.Forms.Button()
        Me.L_Reporting = New System.Windows.Forms.Label()
        Me.BT_CheckReport = New System.Windows.Forms.Button()
        Me.TB_ReportFolder_R = New System.Windows.Forms.TextBox()
        Me.TB_ReportFolder = New System.Windows.Forms.TextBox()
        Me.P_ReportIP_back = New System.Windows.Forms.Panel()
        Me.CLB_ReportServerIP = New System.Windows.Forms.CheckedListBox()
        Me.L_ReportServerIP = New System.Windows.Forms.Label()
        Me.CB_Excel = New System.Windows.Forms.CheckBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Button_Report_Back = New System.Windows.Forms.Button()
        Me.Panel_RemoteMode = New System.Windows.Forms.Panel()
        Me.TB_DeadLine = New System.Windows.Forms.TextBox()
        Me.BT_EditResource = New System.Windows.Forms.Button()
        Me.L_PerOneSlave = New System.Windows.Forms.Label()
        Me.CB_HostMode = New System.Windows.Forms.CheckBox()
        Me.TB_OneTimeNumber = New System.Windows.Forms.TextBox()
        Me.TB_RR_IPs = New System.Windows.Forms.TextBox()
        Me.TB_RR_Dir = New System.Windows.Forms.TextBox()
        Me.Panel_LocalMode = New System.Windows.Forms.Panel()
        Me.BT_LC = New System.Windows.Forms.Button()
        Me.TB_LC = New System.Windows.Forms.TextBox()
        Me.Label_LR_Dir = New System.Windows.Forms.Label()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.L_TimeOut_Unit = New System.Windows.Forms.Label()
        Me.Bt_EditSlaveIPs = New System.Windows.Forms.Button()
        Me.Label_RR_IPs = New System.Windows.Forms.Label()
        Me.Label_RRDir = New System.Windows.Forms.Label()
        Me.Label_OT = New System.Windows.Forms.Label()
        Me.Label_timeout = New System.Windows.Forms.Label()
        Me.BT_EachSlave_back = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.BT_Clean_LC_Save = New System.Windows.Forms.Button()
        Me.TB_RR_Dir_Save = New System.Windows.Forms.TextBox()
        Me.TB_RR_IPs_Save = New System.Windows.Forms.TextBox()
        Me.L_TimeRemaining = New System.Windows.Forms.Label()
        Me.BT_IMBPT = New System.Windows.Forms.Button()
        Me.BT_EXTBPT = New System.Windows.Forms.Button()
        Me.L_BT_IMBPT = New System.Windows.Forms.Label()
        Me.L_BT_EXTBPT = New System.Windows.Forms.Label()
        Me.BT_Clean_RR_IPs_Save = New System.Windows.Forms.Button()
        Me.PictureBox_Panda = New System.Windows.Forms.PictureBox()
        Me.BT_Clean_RR_Dirs_Save = New System.Windows.Forms.Button()
        Me.ExpandButton = New System.Windows.Forms.Button()
        Me.BT_Close = New System.Windows.Forms.Button()
        Me.BT_Min = New System.Windows.Forms.Button()
        Me.CB_Servers = New System.Windows.Forms.CheckBox()
        Me.CB_NormalRun = New System.Windows.Forms.CheckBox()
        Me.MenuStrip = New System.Windows.Forms.MenuStrip()
        Me.MenuToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenConfigurationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveConfigurationAsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ShutdownAfterRunToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CloseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem_Advance = New System.Windows.Forms.ToolStripMenuItem()
        Me.RemoteDesktopManagerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CheckRemoteUFTStatusToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LibraryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.GoldenCasesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SelectModulesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label_shutdown = New System.Windows.Forms.Label()
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton_SavePlan = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton_OpenConfiguration = New System.Windows.Forms.ToolStripButton()
        Me.Bt_Run = New System.Windows.Forms.ToolStripButton()
        Me.Bt_Stop = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton_CheckSlaveStatus = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton_RDM = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton_ShutDown = New System.Windows.Forms.ToolStripButton()
        Me.AlarmToRunToolStripMenuItem = New System.Windows.Forms.ToolStripButton()
        Me.Panel_TestMissionPanel = New System.Windows.Forms.Panel()
        Me.Bt_MaxList = New System.Windows.Forms.Button()
        Me.Panel_TestMissionList = New System.Windows.Forms.Panel()
        Me.TB_BPTList = New System.Windows.Forms.TextBox()
        Me.CLB_Testlist = New System.Windows.Forms.CheckedListBox()
        Me.Bt_Clean_All = New System.Windows.Forms.Button()
        Me.Bt_Refresh = New System.Windows.Forms.Button()
        Me.Bt_select_All = New System.Windows.Forms.Button()
        Me.CB_CRT = New System.Windows.Forms.CheckBox()
        Me.L_TestMissionTitle = New System.Windows.Forms.Label()
        Me.BT_TestList_Back = New System.Windows.Forms.Button()
        Me.RadioButton_Textbox = New System.Windows.Forms.RadioButton()
        Me.L_TBRTotal = New System.Windows.Forms.Label()
        Me.Label_ListNrTitle = New System.Windows.Forms.Label()
        Me.RadioButton_Listbox = New System.Windows.Forms.RadioButton()
        Me.Button_TestMission = New System.Windows.Forms.Button()
        Me.Panel_CustomMissionPanel = New System.Windows.Forms.Panel()
        Me.ListView_CustomMission = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Bt_MissionPanel = New System.Windows.Forms.Button()
        Me.L_totalOfCustom = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Button11 = New System.Windows.Forms.Button()
        Me.BT_TopBar = New System.Windows.Forms.Button()
        Me.Button_TopBar_Back = New System.Windows.Forms.Button()
        Me.Panel_RunMode = New System.Windows.Forms.Panel()
        Me.L_RunMode = New System.Windows.Forms.Label()
        Me.RadioButton_RemoteMode = New System.Windows.Forms.RadioButton()
        Me.RadioButton_LocalMode = New System.Windows.Forms.RadioButton()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.BT_RunMode_Back = New System.Windows.Forms.Button()
        Me.TB_LC_Save = New System.Windows.Forms.TextBox()
        Me.TB_FormBack = New System.Windows.Forms.Button()
        Me.NI = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.ToolTipDeleteInfo = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolTipForHostModel = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolTip_Panda = New System.Windows.Forms.ToolTip(Me.components)
        Me.L_Tool_Split = New System.Windows.Forms.Button()
        Me.Panel_ProjectType = New System.Windows.Forms.Panel()
        Me.L_tsofcaseTile = New System.Windows.Forms.Label()
        Me.TB_tsofcase = New System.Windows.Forms.TextBox()
        Me.L_tsofcaseUnit = New System.Windows.Forms.Label()
        Me.ComboBox_Project = New System.Windows.Forms.ComboBox()
        Me.L_PT = New System.Windows.Forms.Label()
        Me.BT_bottom = New System.Windows.Forms.Button()
        Me.ProgressBar_Run_top = New System.Windows.Forms.ProgressBar()
        Me.Panel_RunStatus.SuspendLayout()
        Me.Panel_RunInfo.SuspendLayout()
        Me.P_RM.SuspendLayout()
        Me.Panel_Log.SuspendLayout()
        Me.Panel_Reporting.SuspendLayout()
        Me.P_ReportIP_back.SuspendLayout()
        Me.Panel_RemoteMode.SuspendLayout()
        Me.Panel_LocalMode.SuspendLayout()
        CType(Me.PictureBox_Panda, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip.SuspendLayout()
        Me.ToolStrip.SuspendLayout()
        Me.Panel_TestMissionPanel.SuspendLayout()
        Me.Panel_TestMissionList.SuspendLayout()
        Me.Panel_CustomMissionPanel.SuspendLayout()
        Me.Panel_RunMode.SuspendLayout()
        Me.Panel_ProjectType.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel_RunStatus
        '
        Me.Panel_RunStatus.BackgroundImage = Global.ATester.My.Resources.Resources.Mainback
        Me.Panel_RunStatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel_RunStatus.Controls.Add(Me.L_RunningStatus)
        Me.Panel_RunStatus.Controls.Add(Me.Panel_RunInfo)
        Me.Panel_RunStatus.Controls.Add(Me.P_RM)
        Me.Panel_RunStatus.Controls.Add(Me.Panel_Log)
        Me.Panel_RunStatus.Controls.Add(Me.Bt_logback)
        Me.Panel_RunStatus.Controls.Add(Me.Bt_runingst)
        Me.Panel_RunStatus.Location = New System.Drawing.Point(9, 296)
        Me.Panel_RunStatus.Name = "Panel_RunStatus"
        Me.Panel_RunStatus.Size = New System.Drawing.Size(540, 288)
        Me.Panel_RunStatus.TabIndex = 143
        '
        'L_RunningStatus
        '
        Me.L_RunningStatus.BackColor = System.Drawing.Color.YellowGreen
        Me.L_RunningStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.L_RunningStatus.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L_RunningStatus.ForeColor = System.Drawing.Color.DarkGreen
        Me.L_RunningStatus.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.L_RunningStatus.Location = New System.Drawing.Point(1, 1)
        Me.L_RunningStatus.Name = "L_RunningStatus"
        Me.L_RunningStatus.Size = New System.Drawing.Size(537, 19)
        Me.L_RunningStatus.TabIndex = 122
        Me.L_RunningStatus.Text = "Running Status"
        '
        'Panel_RunInfo
        '
        Me.Panel_RunInfo.BackColor = System.Drawing.Color.Transparent
        Me.Panel_RunInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel_RunInfo.Controls.Add(Me.Link_FR)
        Me.Panel_RunInfo.Controls.Add(Me.BT_Progress)
        Me.Panel_RunInfo.Controls.Add(Me.L_RoundID)
        Me.Panel_RunInfo.Controls.Add(Me.L_PRValue)
        Me.Panel_RunInfo.Controls.Add(Me.L_Remain_Value)
        Me.Panel_RunInfo.Controls.Add(Me.L_Total_Value)
        Me.Panel_RunInfo.Controls.Add(Me.Link_RTR)
        Me.Panel_RunInfo.Controls.Add(Me.L_Remain)
        Me.Panel_RunInfo.Controls.Add(Me.L_PassRate)
        Me.Panel_RunInfo.Controls.Add(Me.Label6)
        Me.Panel_RunInfo.Controls.Add(Me.Label8)
        Me.Panel_RunInfo.Controls.Add(Me.Button3)
        Me.Panel_RunInfo.Location = New System.Drawing.Point(5, 25)
        Me.Panel_RunInfo.Name = "Panel_RunInfo"
        Me.Panel_RunInfo.Size = New System.Drawing.Size(370, 75)
        Me.Panel_RunInfo.TabIndex = 127
        '
        'Link_FR
        '
        Me.Link_FR.ActiveLinkColor = System.Drawing.Color.IndianRed
        Me.Link_FR.AutoSize = True
        Me.Link_FR.BackColor = System.Drawing.Color.Transparent
        Me.Link_FR.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Link_FR.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.Link_FR.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Link_FR.LinkColor = System.Drawing.Color.DarkOrange
        Me.Link_FR.Location = New System.Drawing.Point(267, 56)
        Me.Link_FR.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Link_FR.Name = "Link_FR"
        Me.Link_FR.Size = New System.Drawing.Size(74, 14)
        Me.Link_FR.TabIndex = 145
        Me.Link_FR.TabStop = True
        Me.Link_FR.Text = "Final Report"
        Me.Link_FR.VisitedLinkColor = System.Drawing.Color.Green
        '
        'BT_Progress
        '
        Me.BT_Progress.BackColor = System.Drawing.Color.Transparent
        Me.BT_Progress.BackgroundImage = Global.ATester.My.Resources.Resources.progress0
        Me.BT_Progress.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BT_Progress.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.BT_Progress.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.BT_Progress.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.BT_Progress.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.BT_Progress.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BT_Progress.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.BT_Progress.ForeColor = System.Drawing.Color.Orange
        Me.BT_Progress.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.BT_Progress.Location = New System.Drawing.Point(6, 46)
        Me.BT_Progress.Name = "BT_Progress"
        Me.BT_Progress.Size = New System.Drawing.Size(243, 24)
        Me.BT_Progress.TabIndex = 123
        Me.BT_Progress.TabStop = False
        Me.BT_Progress.Text = "0%"
        Me.BT_Progress.UseVisualStyleBackColor = False
        '
        'L_RoundID
        '
        Me.L_RoundID.BackColor = System.Drawing.Color.Transparent
        Me.L_RoundID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.L_RoundID.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L_RoundID.ForeColor = System.Drawing.Color.MidnightBlue
        Me.L_RoundID.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.L_RoundID.Location = New System.Drawing.Point(62, 6)
        Me.L_RoundID.Name = "L_RoundID"
        Me.L_RoundID.Size = New System.Drawing.Size(229, 17)
        Me.L_RoundID.TabIndex = 144
        Me.L_RoundID.Text = "N/A"
        '
        'L_PRValue
        '
        Me.L_PRValue.AutoSize = True
        Me.L_PRValue.BackColor = System.Drawing.Color.Transparent
        Me.L_PRValue.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.L_PRValue.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.L_PRValue.ForeColor = System.Drawing.Color.MidnightBlue
        Me.L_PRValue.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.L_PRValue.Location = New System.Drawing.Point(231, 27)
        Me.L_PRValue.Name = "L_PRValue"
        Me.L_PRValue.Size = New System.Drawing.Size(22, 14)
        Me.L_PRValue.TabIndex = 141
        Me.L_PRValue.Text = "0%"
        '
        'L_Remain_Value
        '
        Me.L_Remain_Value.AutoSize = True
        Me.L_Remain_Value.BackColor = System.Drawing.Color.Transparent
        Me.L_Remain_Value.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.L_Remain_Value.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.L_Remain_Value.ForeColor = System.Drawing.Color.MidnightBlue
        Me.L_Remain_Value.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.L_Remain_Value.Location = New System.Drawing.Point(33, 27)
        Me.L_Remain_Value.Name = "L_Remain_Value"
        Me.L_Remain_Value.Size = New System.Drawing.Size(13, 14)
        Me.L_Remain_Value.TabIndex = 50
        Me.L_Remain_Value.Text = "0"
        '
        'L_Total_Value
        '
        Me.L_Total_Value.AutoSize = True
        Me.L_Total_Value.BackColor = System.Drawing.Color.Transparent
        Me.L_Total_Value.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.L_Total_Value.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.L_Total_Value.ForeColor = System.Drawing.Color.MidnightBlue
        Me.L_Total_Value.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.L_Total_Value.Location = New System.Drawing.Point(117, 27)
        Me.L_Total_Value.Name = "L_Total_Value"
        Me.L_Total_Value.Size = New System.Drawing.Size(13, 14)
        Me.L_Total_Value.TabIndex = 49
        Me.L_Total_Value.Text = "0"
        '
        'Link_RTR
        '
        Me.Link_RTR.ActiveLinkColor = System.Drawing.Color.IndianRed
        Me.Link_RTR.AutoSize = True
        Me.Link_RTR.BackColor = System.Drawing.Color.Transparent
        Me.Link_RTR.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Link_RTR.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.Link_RTR.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Link_RTR.LinkColor = System.Drawing.Color.DarkOrange
        Me.Link_RTR.Location = New System.Drawing.Point(267, 36)
        Me.Link_RTR.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Link_RTR.Name = "Link_RTR"
        Me.Link_RTR.Size = New System.Drawing.Size(102, 14)
        Me.Link_RTR.TabIndex = 75
        Me.Link_RTR.TabStop = True
        Me.Link_RTR.Text = "Real-Time Report"
        Me.Link_RTR.VisitedLinkColor = System.Drawing.Color.Green
        '
        'L_Remain
        '
        Me.L_Remain.BackColor = System.Drawing.Color.Transparent
        Me.L_Remain.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.L_Remain.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.L_Remain.ForeColor = System.Drawing.Color.MidnightBlue
        Me.L_Remain.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.L_Remain.Location = New System.Drawing.Point(4, 27)
        Me.L_Remain.Name = "L_Remain"
        Me.L_Remain.Size = New System.Drawing.Size(42, 16)
        Me.L_Remain.TabIndex = 48
        Me.L_Remain.Text = "Left:"
        '
        'L_PassRate
        '
        Me.L_PassRate.BackColor = System.Drawing.Color.Transparent
        Me.L_PassRate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.L_PassRate.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.L_PassRate.ForeColor = System.Drawing.Color.MidnightBlue
        Me.L_PassRate.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.L_PassRate.Location = New System.Drawing.Point(167, 27)
        Me.L_PassRate.Name = "L_PassRate"
        Me.L_PassRate.Size = New System.Drawing.Size(71, 16)
        Me.L_PassRate.TabIndex = 47
        Me.L_PassRate.Text = "Pass Rate:"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label6.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label6.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label6.Location = New System.Drawing.Point(1, 6)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(70, 17)
        Me.Label6.TabIndex = 76
        Me.Label6.Text = "Round ID:"
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label8.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.Label8.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label8.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label8.Location = New System.Drawing.Point(77, 27)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(53, 16)
        Me.Label8.TabIndex = 142
        Me.Label8.Text = "Total:"
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.Transparent
        Me.Button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button3.Enabled = False
        Me.Button3.FlatAppearance.BorderColor = System.Drawing.Color.Honeydew
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Location = New System.Drawing.Point(0, 0)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(370, 75)
        Me.Button3.TabIndex = 128
        Me.Button3.UseVisualStyleBackColor = False
        '
        'P_RM
        '
        Me.P_RM.BackColor = System.Drawing.Color.Transparent
        Me.P_RM.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.P_RM.Controls.Add(Me.Label1)
        Me.P_RM.Controls.Add(Me.Bt_RunningMgmt)
        Me.P_RM.Controls.Add(Me.Button2)
        Me.P_RM.Location = New System.Drawing.Point(381, 25)
        Me.P_RM.Name = "P_RM"
        Me.P_RM.Size = New System.Drawing.Size(153, 75)
        Me.P_RM.TabIndex = 83
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(6, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(144, 17)
        Me.Label1.TabIndex = 131
        Me.Label1.Text = "Management"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Bt_RunningMgmt
        '
        Me.Bt_RunningMgmt.BackColor = System.Drawing.Color.Transparent
        Me.Bt_RunningMgmt.BackgroundImage = Global.ATester.My.Resources.Resources.mission123
        Me.Bt_RunningMgmt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Bt_RunningMgmt.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.Bt_RunningMgmt.FlatAppearance.BorderSize = 0
        Me.Bt_RunningMgmt.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.Bt_RunningMgmt.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Bt_RunningMgmt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Bt_RunningMgmt.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Bt_RunningMgmt.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Bt_RunningMgmt.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Bt_RunningMgmt.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Bt_RunningMgmt.Location = New System.Drawing.Point(3, 28)
        Me.Bt_RunningMgmt.Name = "Bt_RunningMgmt"
        Me.Bt_RunningMgmt.Size = New System.Drawing.Size(147, 43)
        Me.Bt_RunningMgmt.TabIndex = 114
        Me.Bt_RunningMgmt.TabStop = False
        Me.ToolTipForHostModel.SetToolTip(Me.Bt_RunningMgmt, "Manage slaves and related test mission.")
        Me.Bt_RunningMgmt.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Transparent
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button2.Enabled = False
        Me.Button2.FlatAppearance.BorderColor = System.Drawing.Color.Honeydew
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Location = New System.Drawing.Point(0, 0)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(153, 75)
        Me.Button2.TabIndex = 130
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Panel_Log
        '
        Me.Panel_Log.BackColor = System.Drawing.Color.Transparent
        Me.Panel_Log.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel_Log.Controls.Add(Me.BT_Erase)
        Me.Panel_Log.Controls.Add(Me.TB_MainLog)
        Me.Panel_Log.Controls.Add(Me.L_LogTitle)
        Me.Panel_Log.Controls.Add(Me.Bt_Log_Edit_Back)
        Me.Panel_Log.Location = New System.Drawing.Point(8, 109)
        Me.Panel_Log.Name = "Panel_Log"
        Me.Panel_Log.Size = New System.Drawing.Size(521, 166)
        Me.Panel_Log.TabIndex = 124
        '
        'BT_Erase
        '
        Me.BT_Erase.BackColor = System.Drawing.Color.Transparent
        Me.BT_Erase.BackgroundImage = Global.ATester.My.Resources.Resources.cleanLog3Normal
        Me.BT_Erase.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BT_Erase.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.BT_Erase.FlatAppearance.BorderSize = 0
        Me.BT_Erase.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.BT_Erase.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.BT_Erase.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BT_Erase.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT_Erase.ForeColor = System.Drawing.Color.MidnightBlue
        Me.BT_Erase.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.BT_Erase.Location = New System.Drawing.Point(20, 1)
        Me.BT_Erase.Name = "BT_Erase"
        Me.BT_Erase.Size = New System.Drawing.Size(23, 23)
        Me.BT_Erase.TabIndex = 46
        Me.BT_Erase.UseVisualStyleBackColor = False
        '
        'TB_MainLog
        '
        Me.TB_MainLog.BackColor = System.Drawing.Color.Honeydew
        Me.TB_MainLog.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TB_MainLog.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TB_MainLog.ForeColor = System.Drawing.Color.Green
        Me.TB_MainLog.Location = New System.Drawing.Point(1, 27)
        Me.TB_MainLog.MaxLength = 9999999
        Me.TB_MainLog.Multiline = True
        Me.TB_MainLog.Name = "TB_MainLog"
        Me.TB_MainLog.ReadOnly = True
        Me.TB_MainLog.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TB_MainLog.Size = New System.Drawing.Size(517, 137)
        Me.TB_MainLog.TabIndex = 16
        Me.TB_MainLog.TabStop = False
        Me.TB_MainLog.WordWrap = False
        '
        'L_LogTitle
        '
        Me.L_LogTitle.BackColor = System.Drawing.Color.Transparent
        Me.L_LogTitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.L_LogTitle.Font = New System.Drawing.Font("Calibri", 10.0!, System.Drawing.FontStyle.Bold)
        Me.L_LogTitle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.L_LogTitle.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.L_LogTitle.Location = New System.Drawing.Point(98, 2)
        Me.L_LogTitle.Name = "L_LogTitle"
        Me.L_LogTitle.Size = New System.Drawing.Size(36, 19)
        Me.L_LogTitle.TabIndex = 68
        Me.L_LogTitle.Text = "Log"
        Me.L_LogTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Bt_Log_Edit_Back
        '
        Me.Bt_Log_Edit_Back.BackColor = System.Drawing.Color.Silver
        Me.Bt_Log_Edit_Back.Enabled = False
        Me.Bt_Log_Edit_Back.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.Bt_Log_Edit_Back.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SteelBlue
        Me.Bt_Log_Edit_Back.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan
        Me.Bt_Log_Edit_Back.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Bt_Log_Edit_Back.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Bt_Log_Edit_Back.ForeColor = System.Drawing.Color.White
        Me.Bt_Log_Edit_Back.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Bt_Log_Edit_Back.Location = New System.Drawing.Point(0, 26)
        Me.Bt_Log_Edit_Back.Name = "Bt_Log_Edit_Back"
        Me.Bt_Log_Edit_Back.Size = New System.Drawing.Size(519, 139)
        Me.Bt_Log_Edit_Back.TabIndex = 133
        Me.Bt_Log_Edit_Back.TabStop = False
        Me.ToolTipForHostModel.SetToolTip(Me.Bt_Log_Edit_Back, "Manage slaves and related test mission.")
        Me.Bt_Log_Edit_Back.UseVisualStyleBackColor = False
        '
        'Bt_logback
        '
        Me.Bt_logback.BackColor = System.Drawing.Color.Transparent
        Me.Bt_logback.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Bt_logback.Enabled = False
        Me.Bt_logback.FlatAppearance.BorderColor = System.Drawing.Color.Honeydew
        Me.Bt_logback.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Bt_logback.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Bt_logback.Location = New System.Drawing.Point(5, 105)
        Me.Bt_logback.Name = "Bt_logback"
        Me.Bt_logback.Size = New System.Drawing.Size(530, 172)
        Me.Bt_logback.TabIndex = 128
        Me.Bt_logback.UseVisualStyleBackColor = False
        '
        'Bt_runingst
        '
        Me.Bt_runingst.BackColor = System.Drawing.Color.White
        Me.Bt_runingst.BackgroundImage = Global.ATester.My.Resources.Resources.Mainback
        Me.Bt_runingst.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Bt_runingst.Enabled = False
        Me.Bt_runingst.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray
        Me.Bt_runingst.FlatAppearance.BorderSize = 0
        Me.Bt_runingst.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Bt_runingst.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Bt_runingst.Location = New System.Drawing.Point(0, 0)
        Me.Bt_runingst.Name = "Bt_runingst"
        Me.Bt_runingst.Size = New System.Drawing.Size(540, 282)
        Me.Bt_runingst.TabIndex = 90
        Me.Bt_runingst.UseVisualStyleBackColor = False
        '
        'Panel_Reporting
        '
        Me.Panel_Reporting.BackgroundImage = Global.ATester.My.Resources.Resources.Mainback
        Me.Panel_Reporting.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel_Reporting.Controls.Add(Me.L_tip_Timeout)
        Me.Panel_Reporting.Controls.Add(Me.L_Tip_RunResult)
        Me.Panel_Reporting.Controls.Add(Me.L_Reporting)
        Me.Panel_Reporting.Controls.Add(Me.BT_CheckReport)
        Me.Panel_Reporting.Controls.Add(Me.TB_ReportFolder_R)
        Me.Panel_Reporting.Controls.Add(Me.TB_ReportFolder)
        Me.Panel_Reporting.Controls.Add(Me.P_ReportIP_back)
        Me.Panel_Reporting.Controls.Add(Me.L_ReportServerIP)
        Me.Panel_Reporting.Controls.Add(Me.CB_Excel)
        Me.Panel_Reporting.Controls.Add(Me.Label5)
        Me.Panel_Reporting.Controls.Add(Me.Button_Report_Back)
        Me.Panel_Reporting.Location = New System.Drawing.Point(9, 217)
        Me.Panel_Reporting.Name = "Panel_Reporting"
        Me.Panel_Reporting.Size = New System.Drawing.Size(540, 77)
        Me.Panel_Reporting.TabIndex = 142
        '
        'L_tip_Timeout
        '
        Me.L_tip_Timeout.BackColor = System.Drawing.Color.Transparent
        Me.L_tip_Timeout.BackgroundImage = CType(resources.GetObject("L_tip_Timeout.BackgroundImage"), System.Drawing.Image)
        Me.L_tip_Timeout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.L_tip_Timeout.FlatAppearance.BorderSize = 0
        Me.L_tip_Timeout.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver
        Me.L_tip_Timeout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan
        Me.L_tip_Timeout.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.L_tip_Timeout.Location = New System.Drawing.Point(240, 20)
        Me.L_tip_Timeout.Name = "L_tip_Timeout"
        Me.L_tip_Timeout.Size = New System.Drawing.Size(14, 14)
        Me.L_tip_Timeout.TabIndex = 139
        Me.ToolTipDeleteInfo.SetToolTip(Me.L_tip_Timeout, "Tip")
        Me.L_tip_Timeout.UseVisualStyleBackColor = False
        '
        'L_Tip_RunResult
        '
        Me.L_Tip_RunResult.BackColor = System.Drawing.Color.Transparent
        Me.L_Tip_RunResult.BackgroundImage = CType(resources.GetObject("L_Tip_RunResult.BackgroundImage"), System.Drawing.Image)
        Me.L_Tip_RunResult.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.L_Tip_RunResult.FlatAppearance.BorderSize = 0
        Me.L_Tip_RunResult.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver
        Me.L_Tip_RunResult.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan
        Me.L_Tip_RunResult.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.L_Tip_RunResult.Location = New System.Drawing.Point(290, 21)
        Me.L_Tip_RunResult.Name = "L_Tip_RunResult"
        Me.L_Tip_RunResult.Size = New System.Drawing.Size(14, 14)
        Me.L_Tip_RunResult.TabIndex = 138
        Me.ToolTipDeleteInfo.SetToolTip(Me.L_Tip_RunResult, "Tip")
        Me.L_Tip_RunResult.UseVisualStyleBackColor = False
        '
        'L_Reporting
        '
        Me.L_Reporting.BackColor = System.Drawing.Color.YellowGreen
        Me.L_Reporting.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.L_Reporting.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L_Reporting.ForeColor = System.Drawing.Color.DarkGreen
        Me.L_Reporting.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.L_Reporting.Location = New System.Drawing.Point(1, 1)
        Me.L_Reporting.Name = "L_Reporting"
        Me.L_Reporting.Size = New System.Drawing.Size(537, 19)
        Me.L_Reporting.TabIndex = 12
        Me.L_Reporting.Text = "Reporting"
        '
        'BT_CheckReport
        '
        Me.BT_CheckReport.BackColor = System.Drawing.Color.Transparent
        Me.BT_CheckReport.BackgroundImage = CType(resources.GetObject("BT_CheckReport.BackgroundImage"), System.Drawing.Image)
        Me.BT_CheckReport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BT_CheckReport.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.BT_CheckReport.FlatAppearance.BorderSize = 0
        Me.BT_CheckReport.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.BT_CheckReport.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.BT_CheckReport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.BT_CheckReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BT_CheckReport.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.BT_CheckReport.ForeColor = System.Drawing.Color.MidnightBlue
        Me.BT_CheckReport.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.BT_CheckReport.Location = New System.Drawing.Point(487, 45)
        Me.BT_CheckReport.Name = "BT_CheckReport"
        Me.BT_CheckReport.Size = New System.Drawing.Size(39, 26)
        Me.BT_CheckReport.TabIndex = 15
        Me.BT_CheckReport.TabStop = False
        Me.BT_CheckReport.Text = "..."
        Me.BT_CheckReport.UseVisualStyleBackColor = False
        '
        'TB_ReportFolder_R
        '
        Me.TB_ReportFolder_R.BackColor = System.Drawing.Color.White
        Me.TB_ReportFolder_R.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TB_ReportFolder_R.Font = New System.Drawing.Font("Calibri", 11.0!)
        Me.TB_ReportFolder_R.Location = New System.Drawing.Point(64, 48)
        Me.TB_ReportFolder_R.Name = "TB_ReportFolder_R"
        Me.TB_ReportFolder_R.ReadOnly = True
        Me.TB_ReportFolder_R.Size = New System.Drawing.Size(196, 18)
        Me.TB_ReportFolder_R.TabIndex = 45
        Me.TB_ReportFolder_R.Text = "C:\ATester_RemoteRun"
        Me.TB_ReportFolder_R.Visible = False
        Me.TB_ReportFolder_R.WordWrap = False
        '
        'TB_ReportFolder
        '
        Me.TB_ReportFolder.BackColor = System.Drawing.Color.White
        Me.TB_ReportFolder.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TB_ReportFolder.Font = New System.Drawing.Font("Calibri", 11.0!)
        Me.TB_ReportFolder.Location = New System.Drawing.Point(64, 48)
        Me.TB_ReportFolder.Name = "TB_ReportFolder"
        Me.TB_ReportFolder.ReadOnly = True
        Me.TB_ReportFolder.Size = New System.Drawing.Size(417, 18)
        Me.TB_ReportFolder.TabIndex = 10
        Me.TB_ReportFolder.WordWrap = False
        '
        'P_ReportIP_back
        '
        Me.P_ReportIP_back.BackColor = System.Drawing.Color.White
        Me.P_ReportIP_back.Controls.Add(Me.CLB_ReportServerIP)
        Me.P_ReportIP_back.Location = New System.Drawing.Point(395, 39)
        Me.P_ReportIP_back.Name = "P_ReportIP_back"
        Me.P_ReportIP_back.Size = New System.Drawing.Size(140, 36)
        Me.P_ReportIP_back.TabIndex = 137
        '
        'CLB_ReportServerIP
        '
        Me.CLB_ReportServerIP.BackColor = System.Drawing.Color.White
        Me.CLB_ReportServerIP.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.CLB_ReportServerIP.CheckOnClick = True
        Me.CLB_ReportServerIP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CLB_ReportServerIP.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.CLB_ReportServerIP.FormattingEnabled = True
        Me.CLB_ReportServerIP.Location = New System.Drawing.Point(0, 0)
        Me.CLB_ReportServerIP.Name = "CLB_ReportServerIP"
        Me.CLB_ReportServerIP.Size = New System.Drawing.Size(140, 36)
        Me.CLB_ReportServerIP.Sorted = True
        Me.CLB_ReportServerIP.TabIndex = 81
        Me.CLB_ReportServerIP.ThreeDCheckBoxes = True
        Me.CLB_ReportServerIP.Visible = False
        '
        'L_ReportServerIP
        '
        Me.L_ReportServerIP.BackColor = System.Drawing.Color.Transparent
        Me.L_ReportServerIP.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.L_ReportServerIP.ForeColor = System.Drawing.Color.MidnightBlue
        Me.L_ReportServerIP.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.L_ReportServerIP.Location = New System.Drawing.Point(393, 22)
        Me.L_ReportServerIP.Name = "L_ReportServerIP"
        Me.L_ReportServerIP.Size = New System.Drawing.Size(140, 23)
        Me.L_ReportServerIP.TabIndex = 72
        Me.L_ReportServerIP.Tag = Global.ATester.My.Resources.Resources.TopbarBackColor_Disabled
        Me.L_ReportServerIP.Text = "Result Server IP"
        Me.L_ReportServerIP.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.ToolTipDeleteInfo.SetToolTip(Me.L_ReportServerIP, "The server which is used to receive UFT detail result.")
        '
        'CB_Excel
        '
        Me.CB_Excel.BackColor = System.Drawing.Color.Transparent
        Me.CB_Excel.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.CB_Excel.FlatAppearance.BorderSize = 0
        Me.CB_Excel.FlatAppearance.CheckedBackColor = System.Drawing.Color.White
        Me.CB_Excel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Cyan
        Me.CB_Excel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan
        Me.CB_Excel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CB_Excel.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.CB_Excel.ForeColor = System.Drawing.Color.MidnightBlue
        Me.CB_Excel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.CB_Excel.Location = New System.Drawing.Point(3, 21)
        Me.CB_Excel.Name = "CB_Excel"
        Me.CB_Excel.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.CB_Excel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CB_Excel.Size = New System.Drawing.Size(125, 23)
        Me.CB_Excel.TabIndex = 30
        Me.CB_Excel.Text = "ADDL Report?"
        Me.ToolTipDeleteInfo.SetToolTip(Me.CB_Excel, "Select it to get a additional report in Excel format." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "          ")
        Me.CB_Excel.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label5.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.Label5.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label5.Location = New System.Drawing.Point(2, 49)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(108, 15)
        Me.Label5.TabIndex = 66
        Me.Label5.Tag = Global.ATester.My.Resources.Resources.TopbarBackColor_Disabled
        Me.Label5.Text = "Directory"
        '
        'Button_Report_Back
        '
        Me.Button_Report_Back.BackColor = System.Drawing.Color.Transparent
        Me.Button_Report_Back.Enabled = False
        Me.Button_Report_Back.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray
        Me.Button_Report_Back.FlatAppearance.BorderSize = 0
        Me.Button_Report_Back.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Report_Back.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button_Report_Back.Location = New System.Drawing.Point(0, 0)
        Me.Button_Report_Back.Name = "Button_Report_Back"
        Me.Button_Report_Back.Size = New System.Drawing.Size(540, 77)
        Me.Button_Report_Back.TabIndex = 89
        Me.Button_Report_Back.UseVisualStyleBackColor = False
        '
        'Panel_RemoteMode
        '
        Me.Panel_RemoteMode.BackColor = System.Drawing.Color.Transparent
        Me.Panel_RemoteMode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel_RemoteMode.Controls.Add(Me.TB_DeadLine)
        Me.Panel_RemoteMode.Controls.Add(Me.BT_EditResource)
        Me.Panel_RemoteMode.Controls.Add(Me.L_PerOneSlave)
        Me.Panel_RemoteMode.Controls.Add(Me.CB_HostMode)
        Me.Panel_RemoteMode.Controls.Add(Me.TB_OneTimeNumber)
        Me.Panel_RemoteMode.Controls.Add(Me.TB_RR_IPs)
        Me.Panel_RemoteMode.Controls.Add(Me.TB_RR_Dir)
        Me.Panel_RemoteMode.Controls.Add(Me.Panel_LocalMode)
        Me.Panel_RemoteMode.Controls.Add(Me.L_TimeOut_Unit)
        Me.Panel_RemoteMode.Controls.Add(Me.Bt_EditSlaveIPs)
        Me.Panel_RemoteMode.Controls.Add(Me.Label_RR_IPs)
        Me.Panel_RemoteMode.Controls.Add(Me.Label_RRDir)
        Me.Panel_RemoteMode.Controls.Add(Me.Label_OT)
        Me.Panel_RemoteMode.Controls.Add(Me.Label_timeout)
        Me.Panel_RemoteMode.Controls.Add(Me.BT_EachSlave_back)
        Me.Panel_RemoteMode.Controls.Add(Me.Button6)
        Me.Panel_RemoteMode.Location = New System.Drawing.Point(1, 146)
        Me.Panel_RemoteMode.Name = "Panel_RemoteMode"
        Me.Panel_RemoteMode.Size = New System.Drawing.Size(533, 64)
        Me.Panel_RemoteMode.TabIndex = 134
        '
        'TB_DeadLine
        '
        Me.TB_DeadLine.BackColor = System.Drawing.Color.White
        Me.TB_DeadLine.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TB_DeadLine.Font = New System.Drawing.Font("Calibri", 11.0!)
        Me.TB_DeadLine.Location = New System.Drawing.Point(463, 42)
        Me.TB_DeadLine.Name = "TB_DeadLine"
        Me.TB_DeadLine.Size = New System.Drawing.Size(47, 18)
        Me.TB_DeadLine.TabIndex = 19
        Me.TB_DeadLine.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TB_DeadLine.WordWrap = False
        '
        'BT_EditResource
        '
        Me.BT_EditResource.BackColor = System.Drawing.Color.Transparent
        Me.BT_EditResource.BackgroundImage = CType(resources.GetObject("BT_EditResource.BackgroundImage"), System.Drawing.Image)
        Me.BT_EditResource.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BT_EditResource.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.BT_EditResource.FlatAppearance.BorderSize = 0
        Me.BT_EditResource.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.BT_EditResource.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.BT_EditResource.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.BT_EditResource.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BT_EditResource.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT_EditResource.ForeColor = System.Drawing.Color.MidnightBlue
        Me.BT_EditResource.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.BT_EditResource.Location = New System.Drawing.Point(138, 36)
        Me.BT_EditResource.Name = "BT_EditResource"
        Me.BT_EditResource.Size = New System.Drawing.Size(39, 24)
        Me.BT_EditResource.TabIndex = 22
        Me.BT_EditResource.TabStop = False
        Me.BT_EditResource.Text = "..."
        Me.BT_EditResource.UseVisualStyleBackColor = False
        '
        'L_PerOneSlave
        '
        Me.L_PerOneSlave.BackColor = System.Drawing.Color.Transparent
        Me.L_PerOneSlave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.L_PerOneSlave.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.L_PerOneSlave.ForeColor = System.Drawing.Color.MidnightBlue
        Me.L_PerOneSlave.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.L_PerOneSlave.Location = New System.Drawing.Point(386, 4)
        Me.L_PerOneSlave.Name = "L_PerOneSlave"
        Me.L_PerOneSlave.Size = New System.Drawing.Size(143, 17)
        Me.L_PerOneSlave.TabIndex = 58
        Me.L_PerOneSlave.Text = "Per Each Slave"
        Me.L_PerOneSlave.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'CB_HostMode
        '
        Me.CB_HostMode.BackColor = System.Drawing.Color.Transparent
        Me.CB_HostMode.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.CB_HostMode.FlatAppearance.CheckedBackColor = System.Drawing.Color.White
        Me.CB_HostMode.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Cyan
        Me.CB_HostMode.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan
        Me.CB_HostMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CB_HostMode.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.CB_HostMode.ForeColor = System.Drawing.Color.MidnightBlue
        Me.CB_HostMode.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.CB_HostMode.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.CB_HostMode.Location = New System.Drawing.Point(1, 1)
        Me.CB_HostMode.Name = "CB_HostMode"
        Me.CB_HostMode.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.CB_HostMode.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CB_HostMode.Size = New System.Drawing.Size(140, 23)
        Me.CB_HostMode.TabIndex = 59
        Me.CB_HostMode.Text = "Host Mode?"
        Me.ToolTipForHostModel.SetToolTip(Me.CB_HostMode, "Pay attention:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "The ""Host Mode"" requires the machine which the ""Host Dir"" specifi" & _
                "es and the machines " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "which the ""IPs"" specifies and the machine where you ran AT" & _
                "ester can access each others." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "  " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10))
        Me.CB_HostMode.UseVisualStyleBackColor = False
        '
        'TB_OneTimeNumber
        '
        Me.TB_OneTimeNumber.BackColor = System.Drawing.Color.White
        Me.TB_OneTimeNumber.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TB_OneTimeNumber.Font = New System.Drawing.Font("Calibri", 11.0!)
        Me.TB_OneTimeNumber.Location = New System.Drawing.Point(397, 42)
        Me.TB_OneTimeNumber.Name = "TB_OneTimeNumber"
        Me.TB_OneTimeNumber.Size = New System.Drawing.Size(54, 18)
        Me.TB_OneTimeNumber.TabIndex = 18
        Me.TB_OneTimeNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TB_OneTimeNumber.WordWrap = False
        '
        'TB_RR_IPs
        '
        Me.TB_RR_IPs.BackColor = System.Drawing.Color.White
        Me.TB_RR_IPs.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TB_RR_IPs.Font = New System.Drawing.Font("Calibri", 11.0!)
        Me.TB_RR_IPs.Location = New System.Drawing.Point(183, 42)
        Me.TB_RR_IPs.Name = "TB_RR_IPs"
        Me.TB_RR_IPs.ReadOnly = True
        Me.TB_RR_IPs.Size = New System.Drawing.Size(144, 18)
        Me.TB_RR_IPs.TabIndex = 11
        Me.TB_RR_IPs.WordWrap = False
        '
        'TB_RR_Dir
        '
        Me.TB_RR_Dir.BackColor = System.Drawing.Color.White
        Me.TB_RR_Dir.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TB_RR_Dir.Font = New System.Drawing.Font("Calibri", 11.0!)
        Me.TB_RR_Dir.Location = New System.Drawing.Point(4, 42)
        Me.TB_RR_Dir.Name = "TB_RR_Dir"
        Me.TB_RR_Dir.ReadOnly = True
        Me.TB_RR_Dir.Size = New System.Drawing.Size(126, 18)
        Me.TB_RR_Dir.TabIndex = 62
        Me.TB_RR_Dir.WordWrap = False
        '
        'Panel_LocalMode
        '
        Me.Panel_LocalMode.BackColor = System.Drawing.Color.Transparent
        Me.Panel_LocalMode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel_LocalMode.Controls.Add(Me.BT_LC)
        Me.Panel_LocalMode.Controls.Add(Me.TB_LC)
        Me.Panel_LocalMode.Controls.Add(Me.Label_LR_Dir)
        Me.Panel_LocalMode.Controls.Add(Me.Button7)
        Me.Panel_LocalMode.Location = New System.Drawing.Point(3, 63)
        Me.Panel_LocalMode.Name = "Panel_LocalMode"
        Me.Panel_LocalMode.Size = New System.Drawing.Size(530, 64)
        Me.Panel_LocalMode.TabIndex = 133
        Me.Panel_LocalMode.TabStop = True
        '
        'BT_LC
        '
        Me.BT_LC.BackColor = System.Drawing.Color.Transparent
        Me.BT_LC.BackgroundImage = CType(resources.GetObject("BT_LC.BackgroundImage"), System.Drawing.Image)
        Me.BT_LC.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BT_LC.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.BT_LC.FlatAppearance.BorderSize = 0
        Me.BT_LC.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.BT_LC.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.BT_LC.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.BT_LC.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BT_LC.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.BT_LC.ForeColor = System.Drawing.Color.MidnightBlue
        Me.BT_LC.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.BT_LC.Location = New System.Drawing.Point(484, 21)
        Me.BT_LC.Name = "BT_LC"
        Me.BT_LC.Size = New System.Drawing.Size(39, 26)
        Me.BT_LC.TabIndex = 44
        Me.BT_LC.TabStop = False
        Me.BT_LC.Text = "..."
        Me.BT_LC.UseVisualStyleBackColor = False
        '
        'TB_LC
        '
        Me.TB_LC.BackColor = System.Drawing.Color.White
        Me.TB_LC.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TB_LC.Font = New System.Drawing.Font("Calibri", 11.0!)
        Me.TB_LC.Location = New System.Drawing.Point(9, 26)
        Me.TB_LC.Name = "TB_LC"
        Me.TB_LC.ReadOnly = True
        Me.TB_LC.Size = New System.Drawing.Size(469, 18)
        Me.TB_LC.TabIndex = 42
        Me.TB_LC.WordWrap = False
        '
        'Label_LR_Dir
        '
        Me.Label_LR_Dir.BackColor = System.Drawing.Color.Transparent
        Me.Label_LR_Dir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label_LR_Dir.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.Label_LR_Dir.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label_LR_Dir.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label_LR_Dir.Location = New System.Drawing.Point(3, 4)
        Me.Label_LR_Dir.Name = "Label_LR_Dir"
        Me.Label_LR_Dir.Size = New System.Drawing.Size(96, 19)
        Me.Label_LR_Dir.TabIndex = 60
        Me.Label_LR_Dir.Tag = Global.ATester.My.Resources.Resources.TopbarBackColor_Disabled
        Me.Label_LR_Dir.Text = "Test Res Dir"
        '
        'Button7
        '
        Me.Button7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button7.Enabled = False
        Me.Button7.FlatAppearance.BorderColor = System.Drawing.Color.Honeydew
        Me.Button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button7.ForeColor = System.Drawing.Color.Transparent
        Me.Button7.Location = New System.Drawing.Point(0, 0)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(530, 64)
        Me.Button7.TabIndex = 123
        Me.Button7.UseVisualStyleBackColor = True
        '
        'L_TimeOut_Unit
        '
        Me.L_TimeOut_Unit.BackColor = System.Drawing.Color.Transparent
        Me.L_TimeOut_Unit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.L_TimeOut_Unit.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.L_TimeOut_Unit.ForeColor = System.Drawing.Color.MidnightBlue
        Me.L_TimeOut_Unit.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.L_TimeOut_Unit.Location = New System.Drawing.Point(506, 40)
        Me.L_TimeOut_Unit.Name = "L_TimeOut_Unit"
        Me.L_TimeOut_Unit.Size = New System.Drawing.Size(24, 20)
        Me.L_TimeOut_Unit.TabIndex = 33
        Me.L_TimeOut_Unit.Text = "m"
        Me.L_TimeOut_Unit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Bt_EditSlaveIPs
        '
        Me.Bt_EditSlaveIPs.BackColor = System.Drawing.Color.Transparent
        Me.Bt_EditSlaveIPs.BackgroundImage = CType(resources.GetObject("Bt_EditSlaveIPs.BackgroundImage"), System.Drawing.Image)
        Me.Bt_EditSlaveIPs.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Bt_EditSlaveIPs.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.Bt_EditSlaveIPs.FlatAppearance.BorderSize = 0
        Me.Bt_EditSlaveIPs.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.Bt_EditSlaveIPs.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Bt_EditSlaveIPs.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Bt_EditSlaveIPs.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Bt_EditSlaveIPs.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Bt_EditSlaveIPs.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Bt_EditSlaveIPs.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Bt_EditSlaveIPs.Location = New System.Drawing.Point(335, 36)
        Me.Bt_EditSlaveIPs.Name = "Bt_EditSlaveIPs"
        Me.Bt_EditSlaveIPs.Size = New System.Drawing.Size(39, 24)
        Me.Bt_EditSlaveIPs.TabIndex = 119
        Me.Bt_EditSlaveIPs.TabStop = False
        Me.Bt_EditSlaveIPs.Text = "..."
        Me.Bt_EditSlaveIPs.UseVisualStyleBackColor = False
        '
        'Label_RR_IPs
        '
        Me.Label_RR_IPs.BackColor = System.Drawing.Color.Transparent
        Me.Label_RR_IPs.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label_RR_IPs.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.Label_RR_IPs.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label_RR_IPs.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label_RR_IPs.Location = New System.Drawing.Point(227, 24)
        Me.Label_RR_IPs.Name = "Label_RR_IPs"
        Me.Label_RR_IPs.Size = New System.Drawing.Size(67, 18)
        Me.Label_RR_IPs.TabIndex = 61
        Me.Label_RR_IPs.Tag = Global.ATester.My.Resources.Resources.TopbarBackColor_Disabled
        Me.Label_RR_IPs.Text = "Slave IPs"
        Me.ToolTipDeleteInfo.SetToolTip(Me.Label_RR_IPs, "The ip of machines which is used to execute UFT test.")
        '
        'Label_RRDir
        '
        Me.Label_RRDir.BackColor = System.Drawing.Color.Transparent
        Me.Label_RRDir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label_RRDir.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.Label_RRDir.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label_RRDir.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label_RRDir.Location = New System.Drawing.Point(17, 24)
        Me.Label_RRDir.Name = "Label_RRDir"
        Me.Label_RRDir.Size = New System.Drawing.Size(122, 19)
        Me.Label_RRDir.TabIndex = 63
        Me.Label_RRDir.Tag = Global.ATester.My.Resources.Resources.TopbarBackColor_Disabled
        Me.Label_RRDir.Text = "Slave Test Res Dirs"
        Me.ToolTipDeleteInfo.SetToolTip(Me.Label_RRDir, "The path of machine which stores the UFT test resource (the top parent folder).")
        '
        'Label_OT
        '
        Me.Label_OT.BackColor = System.Drawing.Color.Transparent
        Me.Label_OT.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label_OT.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.Label_OT.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label_OT.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label_OT.Location = New System.Drawing.Point(394, 24)
        Me.Label_OT.Name = "Label_OT"
        Me.Label_OT.Size = New System.Drawing.Size(57, 18)
        Me.Label_OT.TabIndex = 28
        Me.Label_OT.Text = "Allot No"
        Me.Label_OT.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label_timeout
        '
        Me.Label_timeout.BackColor = System.Drawing.Color.Transparent
        Me.Label_timeout.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label_timeout.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.Label_timeout.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label_timeout.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label_timeout.Location = New System.Drawing.Point(456, 24)
        Me.Label_timeout.Name = "Label_timeout"
        Me.Label_timeout.Size = New System.Drawing.Size(64, 18)
        Me.Label_timeout.TabIndex = 27
        Me.Label_timeout.Text = "Timeout"
        Me.Label_timeout.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'BT_EachSlave_back
        '
        Me.BT_EachSlave_back.Enabled = False
        Me.BT_EachSlave_back.FlatAppearance.BorderColor = System.Drawing.Color.Honeydew
        Me.BT_EachSlave_back.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BT_EachSlave_back.ForeColor = System.Drawing.Color.Transparent
        Me.BT_EachSlave_back.Location = New System.Drawing.Point(385, 0)
        Me.BT_EachSlave_back.Name = "BT_EachSlave_back"
        Me.BT_EachSlave_back.Size = New System.Drawing.Size(145, 64)
        Me.BT_EachSlave_back.TabIndex = 121
        Me.BT_EachSlave_back.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Enabled = False
        Me.Button6.FlatAppearance.BorderColor = System.Drawing.Color.Honeydew
        Me.Button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button6.ForeColor = System.Drawing.Color.Transparent
        Me.Button6.Location = New System.Drawing.Point(0, 0)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(380, 64)
        Me.Button6.TabIndex = 122
        Me.Button6.UseVisualStyleBackColor = True
        '
        'BT_Clean_LC_Save
        '
        Me.BT_Clean_LC_Save.BackColor = System.Drawing.Color.MediumSeaGreen
        Me.BT_Clean_LC_Save.BackgroundImage = Global.ATester.My.Resources.Resources.del_nor
        Me.BT_Clean_LC_Save.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BT_Clean_LC_Save.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.BT_Clean_LC_Save.FlatAppearance.BorderSize = 0
        Me.BT_Clean_LC_Save.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SteelBlue
        Me.BT_Clean_LC_Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BT_Clean_LC_Save.Font = New System.Drawing.Font("Arial", 5.25!)
        Me.BT_Clean_LC_Save.ForeColor = System.Drawing.Color.White
        Me.BT_Clean_LC_Save.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BT_Clean_LC_Save.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.BT_Clean_LC_Save.Location = New System.Drawing.Point(292, 29)
        Me.BT_Clean_LC_Save.Name = "BT_Clean_LC_Save"
        Me.BT_Clean_LC_Save.Size = New System.Drawing.Size(14, 14)
        Me.BT_Clean_LC_Save.TabIndex = 53
        Me.BT_Clean_LC_Save.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.ToolTipDeleteInfo.SetToolTip(Me.BT_Clean_LC_Save, "Delete all records")
        Me.BT_Clean_LC_Save.UseVisualStyleBackColor = False
        Me.BT_Clean_LC_Save.Visible = False
        '
        'TB_RR_Dir_Save
        '
        Me.TB_RR_Dir_Save.BackColor = System.Drawing.Color.White
        Me.TB_RR_Dir_Save.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TB_RR_Dir_Save.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TB_RR_Dir_Save.ForeColor = System.Drawing.Color.RoyalBlue
        Me.TB_RR_Dir_Save.Location = New System.Drawing.Point(349, 36)
        Me.TB_RR_Dir_Save.Multiline = True
        Me.TB_RR_Dir_Save.Name = "TB_RR_Dir_Save"
        Me.TB_RR_Dir_Save.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TB_RR_Dir_Save.Size = New System.Drawing.Size(222, 104)
        Me.TB_RR_Dir_Save.TabIndex = 54
        Me.TB_RR_Dir_Save.Visible = False
        Me.TB_RR_Dir_Save.WordWrap = False
        '
        'TB_RR_IPs_Save
        '
        Me.TB_RR_IPs_Save.BackColor = System.Drawing.Color.White
        Me.TB_RR_IPs_Save.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TB_RR_IPs_Save.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TB_RR_IPs_Save.ForeColor = System.Drawing.Color.RoyalBlue
        Me.TB_RR_IPs_Save.Location = New System.Drawing.Point(268, 12)
        Me.TB_RR_IPs_Save.Multiline = True
        Me.TB_RR_IPs_Save.Name = "TB_RR_IPs_Save"
        Me.TB_RR_IPs_Save.ReadOnly = True
        Me.TB_RR_IPs_Save.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TB_RR_IPs_Save.Size = New System.Drawing.Size(269, 123)
        Me.TB_RR_IPs_Save.TabIndex = 64
        Me.TB_RR_IPs_Save.Visible = False
        Me.TB_RR_IPs_Save.WordWrap = False
        '
        'L_TimeRemaining
        '
        Me.L_TimeRemaining.AutoSize = True
        Me.L_TimeRemaining.BackColor = System.Drawing.Color.Yellow
        Me.L_TimeRemaining.Cursor = System.Windows.Forms.Cursors.Hand
        Me.L_TimeRemaining.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold)
        Me.L_TimeRemaining.ForeColor = System.Drawing.Color.OrangeRed
        Me.L_TimeRemaining.Location = New System.Drawing.Point(268, 51)
        Me.L_TimeRemaining.Name = "L_TimeRemaining"
        Me.L_TimeRemaining.Size = New System.Drawing.Size(15, 14)
        Me.L_TimeRemaining.TabIndex = 112
        Me.L_TimeRemaining.Text = "--"
        Me.L_TimeRemaining.Visible = False
        '
        'BT_IMBPT
        '
        Me.BT_IMBPT.BackColor = System.Drawing.Color.White
        Me.BT_IMBPT.Enabled = False
        Me.BT_IMBPT.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.BT_IMBPT.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SteelBlue
        Me.BT_IMBPT.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan
        Me.BT_IMBPT.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BT_IMBPT.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.BT_IMBPT.ForeColor = System.Drawing.Color.Black
        Me.BT_IMBPT.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.BT_IMBPT.Location = New System.Drawing.Point(585, 51)
        Me.BT_IMBPT.Name = "BT_IMBPT"
        Me.BT_IMBPT.Size = New System.Drawing.Size(56, 26)
        Me.BT_IMBPT.TabIndex = 56
        Me.BT_IMBPT.TabStop = False
        Me.BT_IMBPT.Text = "Import"
        Me.BT_IMBPT.UseVisualStyleBackColor = False
        Me.BT_IMBPT.Visible = False
        '
        'BT_EXTBPT
        '
        Me.BT_EXTBPT.BackColor = System.Drawing.Color.White
        Me.BT_EXTBPT.Enabled = False
        Me.BT_EXTBPT.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.BT_EXTBPT.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SteelBlue
        Me.BT_EXTBPT.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan
        Me.BT_EXTBPT.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BT_EXTBPT.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.BT_EXTBPT.ForeColor = System.Drawing.Color.Black
        Me.BT_EXTBPT.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.BT_EXTBPT.Location = New System.Drawing.Point(644, 51)
        Me.BT_EXTBPT.Name = "BT_EXTBPT"
        Me.BT_EXTBPT.Size = New System.Drawing.Size(56, 26)
        Me.BT_EXTBPT.TabIndex = 57
        Me.BT_EXTBPT.TabStop = False
        Me.BT_EXTBPT.Text = "Export"
        Me.BT_EXTBPT.UseVisualStyleBackColor = False
        Me.BT_EXTBPT.Visible = False
        '
        'L_BT_IMBPT
        '
        Me.L_BT_IMBPT.BackColor = System.Drawing.Color.Silver
        Me.L_BT_IMBPT.Enabled = False
        Me.L_BT_IMBPT.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.L_BT_IMBPT.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold)
        Me.L_BT_IMBPT.ForeColor = System.Drawing.Color.White
        Me.L_BT_IMBPT.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.L_BT_IMBPT.Location = New System.Drawing.Point(583, 53)
        Me.L_BT_IMBPT.Name = "L_BT_IMBPT"
        Me.L_BT_IMBPT.Size = New System.Drawing.Size(56, 26)
        Me.L_BT_IMBPT.TabIndex = 85
        Me.L_BT_IMBPT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.L_BT_IMBPT.Visible = False
        '
        'L_BT_EXTBPT
        '
        Me.L_BT_EXTBPT.BackColor = System.Drawing.Color.Silver
        Me.L_BT_EXTBPT.Enabled = False
        Me.L_BT_EXTBPT.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.L_BT_EXTBPT.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold)
        Me.L_BT_EXTBPT.ForeColor = System.Drawing.Color.White
        Me.L_BT_EXTBPT.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.L_BT_EXTBPT.Location = New System.Drawing.Point(642, 53)
        Me.L_BT_EXTBPT.Name = "L_BT_EXTBPT"
        Me.L_BT_EXTBPT.Size = New System.Drawing.Size(56, 26)
        Me.L_BT_EXTBPT.TabIndex = 84
        Me.L_BT_EXTBPT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.L_BT_EXTBPT.Visible = False
        '
        'BT_Clean_RR_IPs_Save
        '
        Me.BT_Clean_RR_IPs_Save.BackColor = System.Drawing.Color.MediumSeaGreen
        Me.BT_Clean_RR_IPs_Save.BackgroundImage = Global.ATester.My.Resources.Resources.del_nor
        Me.BT_Clean_RR_IPs_Save.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BT_Clean_RR_IPs_Save.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.BT_Clean_RR_IPs_Save.FlatAppearance.BorderSize = 0
        Me.BT_Clean_RR_IPs_Save.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SteelBlue
        Me.BT_Clean_RR_IPs_Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BT_Clean_RR_IPs_Save.Font = New System.Drawing.Font("Arial", 5.25!)
        Me.BT_Clean_RR_IPs_Save.ForeColor = System.Drawing.Color.White
        Me.BT_Clean_RR_IPs_Save.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.BT_Clean_RR_IPs_Save.Location = New System.Drawing.Point(256, 29)
        Me.BT_Clean_RR_IPs_Save.Name = "BT_Clean_RR_IPs_Save"
        Me.BT_Clean_RR_IPs_Save.Size = New System.Drawing.Size(14, 14)
        Me.BT_Clean_RR_IPs_Save.TabIndex = 65
        Me.BT_Clean_RR_IPs_Save.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTipDeleteInfo.SetToolTip(Me.BT_Clean_RR_IPs_Save, "Delete all records")
        Me.BT_Clean_RR_IPs_Save.UseVisualStyleBackColor = False
        Me.BT_Clean_RR_IPs_Save.Visible = False
        '
        'PictureBox_Panda
        '
        Me.PictureBox_Panda.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox_Panda.BackgroundImage = Global.ATester.My.Resources.Resources.panda
        Me.PictureBox_Panda.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox_Panda.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PictureBox_Panda.Location = New System.Drawing.Point(3, 3)
        Me.PictureBox_Panda.Name = "PictureBox_Panda"
        Me.PictureBox_Panda.Size = New System.Drawing.Size(18, 18)
        Me.PictureBox_Panda.TabIndex = 93
        Me.PictureBox_Panda.TabStop = False
        '
        'BT_Clean_RR_Dirs_Save
        '
        Me.BT_Clean_RR_Dirs_Save.BackColor = System.Drawing.Color.MediumSeaGreen
        Me.BT_Clean_RR_Dirs_Save.BackgroundImage = Global.ATester.My.Resources.Resources.del_nor
        Me.BT_Clean_RR_Dirs_Save.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BT_Clean_RR_Dirs_Save.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.BT_Clean_RR_Dirs_Save.FlatAppearance.BorderSize = 0
        Me.BT_Clean_RR_Dirs_Save.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SteelBlue
        Me.BT_Clean_RR_Dirs_Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BT_Clean_RR_Dirs_Save.Font = New System.Drawing.Font("Arial", 5.25!)
        Me.BT_Clean_RR_Dirs_Save.ForeColor = System.Drawing.Color.White
        Me.BT_Clean_RR_Dirs_Save.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.BT_Clean_RR_Dirs_Save.Location = New System.Drawing.Point(219, 29)
        Me.BT_Clean_RR_Dirs_Save.Name = "BT_Clean_RR_Dirs_Save"
        Me.BT_Clean_RR_Dirs_Save.Size = New System.Drawing.Size(14, 14)
        Me.BT_Clean_RR_Dirs_Save.TabIndex = 55
        Me.BT_Clean_RR_Dirs_Save.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.ToolTipDeleteInfo.SetToolTip(Me.BT_Clean_RR_Dirs_Save, "Delete all records")
        Me.BT_Clean_RR_Dirs_Save.UseVisualStyleBackColor = False
        Me.BT_Clean_RR_Dirs_Save.Visible = False
        '
        'ExpandButton
        '
        Me.ExpandButton.BackColor = System.Drawing.Color.White
        Me.ExpandButton.BackgroundImage = Global.ATester.My.Resources.Resources.expand
        Me.ExpandButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ExpandButton.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.ExpandButton.FlatAppearance.BorderSize = 0
        Me.ExpandButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.ExpandButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.ExpandButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ExpandButton.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ExpandButton.ForeColor = System.Drawing.Color.Black
        Me.ExpandButton.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ExpandButton.Location = New System.Drawing.Point(559, 108)
        Me.ExpandButton.Name = "ExpandButton"
        Me.ExpandButton.Size = New System.Drawing.Size(14, 470)
        Me.ExpandButton.TabIndex = 58
        Me.ExpandButton.TabStop = False
        Me.ToolTipForHostModel.SetToolTip(Me.ExpandButton, "Test Mission")
        Me.ExpandButton.UseVisualStyleBackColor = False
        '
        'BT_Close
        '
        Me.BT_Close.BackColor = System.Drawing.Color.Transparent
        Me.BT_Close.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.BT_Close.FlatAppearance.BorderSize = 0
        Me.BT_Close.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red
        Me.BT_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BT_Close.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Bold)
        Me.BT_Close.ForeColor = System.Drawing.Color.White
        Me.BT_Close.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.BT_Close.Location = New System.Drawing.Point(519, -1)
        Me.BT_Close.Name = "BT_Close"
        Me.BT_Close.Size = New System.Drawing.Size(29, 22)
        Me.BT_Close.TabIndex = 36
        Me.BT_Close.TabStop = False
        Me.BT_Close.Text = "X"
        Me.BT_Close.UseVisualStyleBackColor = False
        '
        'BT_Min
        '
        Me.BT_Min.BackColor = System.Drawing.Color.Transparent
        Me.BT_Min.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BT_Min.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.BT_Min.FlatAppearance.BorderSize = 0
        Me.BT_Min.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Aqua
        Me.BT_Min.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BT_Min.Font = New System.Drawing.Font("Calibri", 6.0!, System.Drawing.FontStyle.Bold)
        Me.BT_Min.ForeColor = System.Drawing.Color.White
        Me.BT_Min.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.BT_Min.Location = New System.Drawing.Point(490, -1)
        Me.BT_Min.Name = "BT_Min"
        Me.BT_Min.Size = New System.Drawing.Size(28, 22)
        Me.BT_Min.TabIndex = 37
        Me.BT_Min.TabStop = False
        Me.BT_Min.Text = "__"
        Me.BT_Min.UseVisualStyleBackColor = False
        '
        'CB_Servers
        '
        Me.CB_Servers.BackColor = System.Drawing.Color.WhiteSmoke
        Me.CB_Servers.CheckAlign = System.Drawing.ContentAlignment.TopCenter
        Me.CB_Servers.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.CB_Servers.FlatAppearance.CheckedBackColor = System.Drawing.Color.White
        Me.CB_Servers.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Cyan
        Me.CB_Servers.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SteelBlue
        Me.CB_Servers.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CB_Servers.Font = New System.Drawing.Font("Arial", 7.8!)
        Me.CB_Servers.ForeColor = System.Drawing.Color.Black
        Me.CB_Servers.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CB_Servers.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.CB_Servers.Location = New System.Drawing.Point(235, 129)
        Me.CB_Servers.Name = "CB_Servers"
        Me.CB_Servers.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CB_Servers.Size = New System.Drawing.Size(11, 16)
        Me.CB_Servers.TabIndex = 14
        Me.CB_Servers.UseVisualStyleBackColor = False
        Me.CB_Servers.Visible = False
        '
        'CB_NormalRun
        '
        Me.CB_NormalRun.BackColor = System.Drawing.Color.WhiteSmoke
        Me.CB_NormalRun.CheckAlign = System.Drawing.ContentAlignment.TopLeft
        Me.CB_NormalRun.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.CB_NormalRun.FlatAppearance.CheckedBackColor = System.Drawing.Color.White
        Me.CB_NormalRun.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Cyan
        Me.CB_NormalRun.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SteelBlue
        Me.CB_NormalRun.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CB_NormalRun.Font = New System.Drawing.Font("Arial", 7.8!)
        Me.CB_NormalRun.ForeColor = System.Drawing.Color.Black
        Me.CB_NormalRun.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CB_NormalRun.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.CB_NormalRun.Location = New System.Drawing.Point(197, 129)
        Me.CB_NormalRun.Name = "CB_NormalRun"
        Me.CB_NormalRun.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CB_NormalRun.Size = New System.Drawing.Size(11, 16)
        Me.CB_NormalRun.TabIndex = 58
        Me.CB_NormalRun.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.CB_NormalRun.UseVisualStyleBackColor = False
        Me.CB_NormalRun.Visible = False
        '
        'MenuStrip
        '
        Me.MenuStrip.BackColor = System.Drawing.Color.Transparent
        Me.MenuStrip.Dock = System.Windows.Forms.DockStyle.None
        Me.MenuStrip.Font = New System.Drawing.Font("Segoe UI", 7.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuToolStripMenuItem, Me.ToolStripMenuItem_Advance, Me.ToolStripMenuItem1, Me.HelpToolStripMenuItem})
        Me.MenuStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow
        Me.MenuStrip.Location = New System.Drawing.Point(2, 26)
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Size = New System.Drawing.Size(273, 23)
        Me.MenuStrip.TabIndex = 92
        Me.MenuStrip.Text = "MenuStrip"
        '
        'MenuToolStripMenuItem
        '
        Me.MenuToolStripMenuItem.BackColor = System.Drawing.Color.Transparent
        Me.MenuToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.MenuToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenConfigurationToolStripMenuItem, Me.SaveConfigurationAsToolStripMenuItem, Me.ShutdownAfterRunToolStripMenuItem, Me.CloseToolStripMenuItem})
        Me.MenuToolStripMenuItem.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuToolStripMenuItem.ForeColor = System.Drawing.Color.DarkGreen
        Me.MenuToolStripMenuItem.Name = "MenuToolStripMenuItem"
        Me.MenuToolStripMenuItem.Size = New System.Drawing.Size(50, 19)
        Me.MenuToolStripMenuItem.Text = "Menu"
        Me.MenuToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.TopLeft
        '
        'OpenConfigurationToolStripMenuItem
        '
        Me.OpenConfigurationToolStripMenuItem.BackColor = System.Drawing.Color.White
        Me.OpenConfigurationToolStripMenuItem.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.OpenConfigurationToolStripMenuItem.Image = Global.ATester.My.Resources.Resources.openplan
        Me.OpenConfigurationToolStripMenuItem.Name = "OpenConfigurationToolStripMenuItem"
        Me.OpenConfigurationToolStripMenuItem.Size = New System.Drawing.Size(226, 22)
        Me.OpenConfigurationToolStripMenuItem.Text = "Open Configuration"
        '
        'SaveConfigurationAsToolStripMenuItem
        '
        Me.SaveConfigurationAsToolStripMenuItem.BackColor = System.Drawing.Color.White
        Me.SaveConfigurationAsToolStripMenuItem.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.SaveConfigurationAsToolStripMenuItem.Image = Global.ATester.My.Resources.Resources.saveplan
        Me.SaveConfigurationAsToolStripMenuItem.Name = "SaveConfigurationAsToolStripMenuItem"
        Me.SaveConfigurationAsToolStripMenuItem.Size = New System.Drawing.Size(226, 22)
        Me.SaveConfigurationAsToolStripMenuItem.Text = "Save Configuration As..."
        '
        'ShutdownAfterRunToolStripMenuItem
        '
        Me.ShutdownAfterRunToolStripMenuItem.BackColor = System.Drawing.Color.White
        Me.ShutdownAfterRunToolStripMenuItem.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.ShutdownAfterRunToolStripMenuItem.Image = Global.ATester.My.Resources.Resources.shut3
        Me.ShutdownAfterRunToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ShutdownAfterRunToolStripMenuItem.Name = "ShutdownAfterRunToolStripMenuItem"
        Me.ShutdownAfterRunToolStripMenuItem.Size = New System.Drawing.Size(226, 22)
        Me.ShutdownAfterRunToolStripMenuItem.Text = "Shut down after run is over"
        '
        'CloseToolStripMenuItem
        '
        Me.CloseToolStripMenuItem.BackColor = System.Drawing.Color.White
        Me.CloseToolStripMenuItem.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.CloseToolStripMenuItem.Name = "CloseToolStripMenuItem"
        Me.CloseToolStripMenuItem.Size = New System.Drawing.Size(226, 22)
        Me.CloseToolStripMenuItem.Text = "Exit"
        '
        'ToolStripMenuItem_Advance
        '
        Me.ToolStripMenuItem_Advance.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripMenuItem_Advance.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RemoteDesktopManagerToolStripMenuItem, Me.CheckRemoteUFTStatusToolStripMenuItem, Me.LibraryToolStripMenuItem})
        Me.ToolStripMenuItem_Advance.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripMenuItem_Advance.ForeColor = System.Drawing.Color.DarkGreen
        Me.ToolStripMenuItem_Advance.Name = "ToolStripMenuItem_Advance"
        Me.ToolStripMenuItem_Advance.Size = New System.Drawing.Size(75, 19)
        Me.ToolStripMenuItem_Advance.Text = "Advanced"
        Me.ToolStripMenuItem_Advance.TextAlign = System.Drawing.ContentAlignment.TopLeft
        '
        'RemoteDesktopManagerToolStripMenuItem
        '
        Me.RemoteDesktopManagerToolStripMenuItem.BackColor = System.Drawing.Color.White
        Me.RemoteDesktopManagerToolStripMenuItem.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.RemoteDesktopManagerToolStripMenuItem.Image = Global.ATester.My.Resources.Resources.monitor1
        Me.RemoteDesktopManagerToolStripMenuItem.Name = "RemoteDesktopManagerToolStripMenuItem"
        Me.RemoteDesktopManagerToolStripMenuItem.Size = New System.Drawing.Size(226, 22)
        Me.RemoteDesktopManagerToolStripMenuItem.Text = "Remote Desktop Manager"
        '
        'CheckRemoteUFTStatusToolStripMenuItem
        '
        Me.CheckRemoteUFTStatusToolStripMenuItem.BackColor = System.Drawing.Color.White
        Me.CheckRemoteUFTStatusToolStripMenuItem.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.CheckRemoteUFTStatusToolStripMenuItem.Image = Global.ATester.My.Resources.Resources.checksever
        Me.CheckRemoteUFTStatusToolStripMenuItem.Name = "CheckRemoteUFTStatusToolStripMenuItem"
        Me.CheckRemoteUFTStatusToolStripMenuItem.Size = New System.Drawing.Size(226, 22)
        Me.CheckRemoteUFTStatusToolStripMenuItem.Text = "Check Remote Slave Status"
        '
        'LibraryToolStripMenuItem
        '
        Me.LibraryToolStripMenuItem.BackColor = System.Drawing.Color.White
        Me.LibraryToolStripMenuItem.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.LibraryToolStripMenuItem.Image = Global.ATester.My.Resources.Resources.openlib
        Me.LibraryToolStripMenuItem.Name = "LibraryToolStripMenuItem"
        Me.LibraryToolStripMenuItem.Size = New System.Drawing.Size(226, 22)
        Me.LibraryToolStripMenuItem.Text = "Library Shortcut"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GoldenCasesToolStripMenuItem, Me.SelectModulesToolStripMenuItem})
        Me.ToolStripMenuItem1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripMenuItem1.ForeColor = System.Drawing.Color.DarkGreen
        Me.ToolStripMenuItem1.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(94, 19)
        Me.ToolStripMenuItem1.Text = "Select Cases"
        Me.ToolStripMenuItem1.TextAlign = System.Drawing.ContentAlignment.TopLeft
        '
        'GoldenCasesToolStripMenuItem
        '
        Me.GoldenCasesToolStripMenuItem.BackColor = System.Drawing.Color.White
        Me.GoldenCasesToolStripMenuItem.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.GoldenCasesToolStripMenuItem.Image = CType(resources.GetObject("GoldenCasesToolStripMenuItem.Image"), System.Drawing.Image)
        Me.GoldenCasesToolStripMenuItem.Name = "GoldenCasesToolStripMenuItem"
        Me.GoldenCasesToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
        Me.GoldenCasesToolStripMenuItem.Text = "Golden Cases"
        '
        'SelectModulesToolStripMenuItem
        '
        Me.SelectModulesToolStripMenuItem.BackColor = System.Drawing.Color.White
        Me.SelectModulesToolStripMenuItem.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.SelectModulesToolStripMenuItem.Image = CType(resources.GetObject("SelectModulesToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SelectModulesToolStripMenuItem.Name = "SelectModulesToolStripMenuItem"
        Me.SelectModulesToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
        Me.SelectModulesToolStripMenuItem.Text = "Select Modules"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.BackColor = System.Drawing.Color.Transparent
        Me.HelpToolStripMenuItem.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HelpToolStripMenuItem.ForeColor = System.Drawing.Color.DarkGreen
        Me.HelpToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(51, 19)
        Me.HelpToolStripMenuItem.Text = "Help?"
        Me.HelpToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.TopLeft
        '
        'Label_shutdown
        '
        Me.Label_shutdown.AutoSize = True
        Me.Label_shutdown.BackColor = System.Drawing.Color.Yellow
        Me.Label_shutdown.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_shutdown.ForeColor = System.Drawing.Color.OrangeRed
        Me.Label_shutdown.Location = New System.Drawing.Point(268, 65)
        Me.Label_shutdown.Name = "Label_shutdown"
        Me.Label_shutdown.Size = New System.Drawing.Size(165, 14)
        Me.Label_shutdown.TabIndex = 113
        Me.Label_shutdown.Text = "Shut down after run is over - On"
        Me.ToolTipDeleteInfo.SetToolTip(Me.Label_shutdown, "You can turn off it from Menu.")
        Me.Label_shutdown.Visible = False
        '
        'ToolStrip
        '
        Me.ToolStrip.AllowMerge = False
        Me.ToolStrip.AutoSize = False
        Me.ToolStrip.BackColor = System.Drawing.Color.White
        Me.ToolStrip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ToolStrip.CanOverflow = False
        Me.ToolStrip.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip.GripMargin = New System.Windows.Forms.Padding(0)
        Me.ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton_SavePlan, Me.ToolStripButton_OpenConfiguration, Me.Bt_Run, Me.Bt_Stop, Me.ToolStripButton_CheckSlaveStatus, Me.ToolStripButton_RDM, Me.ToolStripButton_ShutDown, Me.AlarmToRunToolStripMenuItem})
        Me.ToolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow
        Me.ToolStrip.Location = New System.Drawing.Point(2, 51)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Padding = New System.Windows.Forms.Padding(0)
        Me.ToolStrip.Size = New System.Drawing.Size(756, 32)
        Me.ToolStrip.TabIndex = 121
        Me.ToolStrip.Text = "Tool Bar"
        '
        'ToolStripButton_SavePlan
        '
        Me.ToolStripButton_SavePlan.BackColor = System.Drawing.Color.White
        Me.ToolStripButton_SavePlan.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton_SavePlan.Image = Global.ATester.My.Resources.Resources.saveplan
        Me.ToolStripButton_SavePlan.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_SavePlan.Margin = New System.Windows.Forms.Padding(3, 2, 3, 0)
        Me.ToolStripButton_SavePlan.Name = "ToolStripButton_SavePlan"
        Me.ToolStripButton_SavePlan.Size = New System.Drawing.Size(24, 24)
        Me.ToolStripButton_SavePlan.Text = "Save Plan"
        '
        'ToolStripButton_OpenConfiguration
        '
        Me.ToolStripButton_OpenConfiguration.BackColor = System.Drawing.Color.White
        Me.ToolStripButton_OpenConfiguration.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton_OpenConfiguration.Image = Global.ATester.My.Resources.Resources.openplan
        Me.ToolStripButton_OpenConfiguration.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_OpenConfiguration.Margin = New System.Windows.Forms.Padding(3, 2, 3, 0)
        Me.ToolStripButton_OpenConfiguration.Name = "ToolStripButton_OpenConfiguration"
        Me.ToolStripButton_OpenConfiguration.Size = New System.Drawing.Size(24, 24)
        Me.ToolStripButton_OpenConfiguration.Text = "Open Plan"
        '
        'Bt_Run
        '
        Me.Bt_Run.BackColor = System.Drawing.Color.White
        Me.Bt_Run.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Bt_Run.Image = Global.ATester.My.Resources.Resources.play
        Me.Bt_Run.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Bt_Run.Margin = New System.Windows.Forms.Padding(3, 2, 3, 0)
        Me.Bt_Run.Name = "Bt_Run"
        Me.Bt_Run.Size = New System.Drawing.Size(24, 24)
        Me.Bt_Run.Text = "Run"
        '
        'Bt_Stop
        '
        Me.Bt_Stop.BackColor = System.Drawing.Color.White
        Me.Bt_Stop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Bt_Stop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Bt_Stop.Image = Global.ATester.My.Resources.Resources.stop2
        Me.Bt_Stop.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Bt_Stop.Margin = New System.Windows.Forms.Padding(3, 2, 3, 0)
        Me.Bt_Stop.Name = "Bt_Stop"
        Me.Bt_Stop.Size = New System.Drawing.Size(24, 24)
        Me.Bt_Stop.Text = "Stop"
        '
        'ToolStripButton_CheckSlaveStatus
        '
        Me.ToolStripButton_CheckSlaveStatus.BackColor = System.Drawing.Color.White
        Me.ToolStripButton_CheckSlaveStatus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton_CheckSlaveStatus.Image = Global.ATester.My.Resources.Resources.checksever
        Me.ToolStripButton_CheckSlaveStatus.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_CheckSlaveStatus.Margin = New System.Windows.Forms.Padding(3, 2, 3, 0)
        Me.ToolStripButton_CheckSlaveStatus.Name = "ToolStripButton_CheckSlaveStatus"
        Me.ToolStripButton_CheckSlaveStatus.Size = New System.Drawing.Size(24, 24)
        Me.ToolStripButton_CheckSlaveStatus.Text = "Check Remote Slave Status"
        '
        'ToolStripButton_RDM
        '
        Me.ToolStripButton_RDM.BackColor = System.Drawing.Color.White
        Me.ToolStripButton_RDM.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton_RDM.Image = Global.ATester.My.Resources.Resources.monitor1
        Me.ToolStripButton_RDM.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_RDM.Margin = New System.Windows.Forms.Padding(3, 2, 3, 0)
        Me.ToolStripButton_RDM.Name = "ToolStripButton_RDM"
        Me.ToolStripButton_RDM.Size = New System.Drawing.Size(24, 24)
        Me.ToolStripButton_RDM.Text = "Remote Desktop Manager"
        '
        'ToolStripButton_ShutDown
        '
        Me.ToolStripButton_ShutDown.BackColor = System.Drawing.Color.White
        Me.ToolStripButton_ShutDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton_ShutDown.Image = Global.ATester.My.Resources.Resources.shut3
        Me.ToolStripButton_ShutDown.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_ShutDown.Margin = New System.Windows.Forms.Padding(3, 2, 3, 0)
        Me.ToolStripButton_ShutDown.Name = "ToolStripButton_ShutDown"
        Me.ToolStripButton_ShutDown.Size = New System.Drawing.Size(24, 24)
        Me.ToolStripButton_ShutDown.Text = "Shut down - Off"
        '
        'AlarmToRunToolStripMenuItem
        '
        Me.AlarmToRunToolStripMenuItem.BackColor = System.Drawing.Color.White
        Me.AlarmToRunToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.AlarmToRunToolStripMenuItem.Image = Global.ATester.My.Resources.Resources.timer2
        Me.AlarmToRunToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.AlarmToRunToolStripMenuItem.Margin = New System.Windows.Forms.Padding(3, 2, 3, 0)
        Me.AlarmToRunToolStripMenuItem.Name = "AlarmToRunToolStripMenuItem"
        Me.AlarmToRunToolStripMenuItem.Size = New System.Drawing.Size(24, 24)
        Me.AlarmToRunToolStripMenuItem.Text = "Alarm"
        '
        'Panel_TestMissionPanel
        '
        Me.Panel_TestMissionPanel.BackColor = System.Drawing.Color.Transparent
        Me.Panel_TestMissionPanel.BackgroundImage = Global.ATester.My.Resources.Resources.Mainback
        Me.Panel_TestMissionPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel_TestMissionPanel.Controls.Add(Me.Bt_MaxList)
        Me.Panel_TestMissionPanel.Controls.Add(Me.Panel_TestMissionList)
        Me.Panel_TestMissionPanel.Controls.Add(Me.Bt_Clean_All)
        Me.Panel_TestMissionPanel.Controls.Add(Me.Bt_Refresh)
        Me.Panel_TestMissionPanel.Controls.Add(Me.Bt_select_All)
        Me.Panel_TestMissionPanel.Controls.Add(Me.CB_CRT)
        Me.Panel_TestMissionPanel.Controls.Add(Me.L_TestMissionTitle)
        Me.Panel_TestMissionPanel.Controls.Add(Me.BT_TestList_Back)
        Me.Panel_TestMissionPanel.Controls.Add(Me.RadioButton_Textbox)
        Me.Panel_TestMissionPanel.Controls.Add(Me.L_TBRTotal)
        Me.Panel_TestMissionPanel.Controls.Add(Me.Label_ListNrTitle)
        Me.Panel_TestMissionPanel.Controls.Add(Me.RadioButton_Listbox)
        Me.Panel_TestMissionPanel.Controls.Add(Me.Button_TestMission)
        Me.Panel_TestMissionPanel.ForeColor = System.Drawing.Color.White
        Me.Panel_TestMissionPanel.Location = New System.Drawing.Point(591, 85)
        Me.Panel_TestMissionPanel.Name = "Panel_TestMissionPanel"
        Me.Panel_TestMissionPanel.Size = New System.Drawing.Size(197, 488)
        Me.Panel_TestMissionPanel.TabIndex = 99
        '
        'Bt_MaxList
        '
        Me.Bt_MaxList.BackColor = System.Drawing.Color.Transparent
        Me.Bt_MaxList.BackgroundImage = Global.ATester.My.Resources.Resources.expandtestlist
        Me.Bt_MaxList.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Bt_MaxList.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.Bt_MaxList.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.Bt_MaxList.FlatAppearance.BorderSize = 0
        Me.Bt_MaxList.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.Bt_MaxList.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Bt_MaxList.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Bt_MaxList.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Bt_MaxList.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Bt_MaxList.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Bt_MaxList.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Bt_MaxList.Location = New System.Drawing.Point(166, 1)
        Me.Bt_MaxList.Name = "Bt_MaxList"
        Me.Bt_MaxList.Size = New System.Drawing.Size(28, 17)
        Me.Bt_MaxList.TabIndex = 142
        Me.Bt_MaxList.TabStop = False
        Me.Bt_MaxList.UseVisualStyleBackColor = False
        '
        'Panel_TestMissionList
        '
        Me.Panel_TestMissionList.BackColor = System.Drawing.SystemColors.Control
        Me.Panel_TestMissionList.Controls.Add(Me.TB_BPTList)
        Me.Panel_TestMissionList.Controls.Add(Me.CLB_Testlist)
        Me.Panel_TestMissionList.Location = New System.Drawing.Point(6, 67)
        Me.Panel_TestMissionList.Name = "Panel_TestMissionList"
        Me.Panel_TestMissionList.Size = New System.Drawing.Size(183, 323)
        Me.Panel_TestMissionList.TabIndex = 138
        '
        'TB_BPTList
        '
        Me.TB_BPTList.BackColor = System.Drawing.Color.White
        Me.TB_BPTList.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TB_BPTList.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TB_BPTList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TB_BPTList.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TB_BPTList.Location = New System.Drawing.Point(0, 0)
        Me.TB_BPTList.MaxLength = 9999999
        Me.TB_BPTList.Multiline = True
        Me.TB_BPTList.Name = "TB_BPTList"
        Me.TB_BPTList.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TB_BPTList.Size = New System.Drawing.Size(183, 323)
        Me.TB_BPTList.TabIndex = 8
        Me.TB_BPTList.Visible = False
        Me.TB_BPTList.WordWrap = False
        '
        'CLB_Testlist
        '
        Me.CLB_Testlist.BackColor = System.Drawing.Color.White
        Me.CLB_Testlist.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.CLB_Testlist.CheckOnClick = True
        Me.CLB_Testlist.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.CLB_Testlist.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CLB_Testlist.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.CLB_Testlist.FormattingEnabled = True
        Me.CLB_Testlist.HorizontalScrollbar = True
        Me.CLB_Testlist.Location = New System.Drawing.Point(0, 0)
        Me.CLB_Testlist.Name = "CLB_Testlist"
        Me.CLB_Testlist.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CLB_Testlist.ScrollAlwaysVisible = True
        Me.CLB_Testlist.Size = New System.Drawing.Size(183, 323)
        Me.CLB_Testlist.TabIndex = 1
        Me.CLB_Testlist.TabStop = False
        Me.CLB_Testlist.ThreeDCheckBoxes = True
        '
        'Bt_Clean_All
        '
        Me.Bt_Clean_All.BackColor = System.Drawing.Color.Transparent
        Me.Bt_Clean_All.BackgroundImage = CType(resources.GetObject("Bt_Clean_All.BackgroundImage"), System.Drawing.Image)
        Me.Bt_Clean_All.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Bt_Clean_All.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.Bt_Clean_All.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.Bt_Clean_All.FlatAppearance.BorderSize = 0
        Me.Bt_Clean_All.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.Bt_Clean_All.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Bt_Clean_All.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Bt_Clean_All.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Bt_Clean_All.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Bt_Clean_All.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Bt_Clean_All.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Bt_Clean_All.Location = New System.Drawing.Point(96, 413)
        Me.Bt_Clean_All.Name = "Bt_Clean_All"
        Me.Bt_Clean_All.Size = New System.Drawing.Size(93, 26)
        Me.Bt_Clean_All.TabIndex = 4
        Me.Bt_Clean_All.TabStop = False
        Me.Bt_Clean_All.Text = "Clean All"
        Me.Bt_Clean_All.UseVisualStyleBackColor = False
        '
        'Bt_Refresh
        '
        Me.Bt_Refresh.BackColor = System.Drawing.Color.Transparent
        Me.Bt_Refresh.BackgroundImage = CType(resources.GetObject("Bt_Refresh.BackgroundImage"), System.Drawing.Image)
        Me.Bt_Refresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Bt_Refresh.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.Bt_Refresh.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.Bt_Refresh.FlatAppearance.BorderSize = 0
        Me.Bt_Refresh.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.Bt_Refresh.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Bt_Refresh.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Bt_Refresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Bt_Refresh.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Bt_Refresh.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Bt_Refresh.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Bt_Refresh.Location = New System.Drawing.Point(6, 445)
        Me.Bt_Refresh.Name = "Bt_Refresh"
        Me.Bt_Refresh.Size = New System.Drawing.Size(183, 26)
        Me.Bt_Refresh.TabIndex = 5
        Me.Bt_Refresh.TabStop = False
        Me.Bt_Refresh.Text = "Refresh"
        Me.ToolTipForHostModel.SetToolTip(Me.Bt_Refresh, "Get test list from Dir you provided.")
        Me.Bt_Refresh.UseVisualStyleBackColor = False
        '
        'Bt_select_All
        '
        Me.Bt_select_All.BackColor = System.Drawing.Color.Transparent
        Me.Bt_select_All.BackgroundImage = CType(resources.GetObject("Bt_select_All.BackgroundImage"), System.Drawing.Image)
        Me.Bt_select_All.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Bt_select_All.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.Bt_select_All.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.Bt_select_All.FlatAppearance.BorderSize = 0
        Me.Bt_select_All.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.Bt_select_All.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Bt_select_All.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Bt_select_All.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Bt_select_All.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Bt_select_All.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Bt_select_All.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Bt_select_All.Location = New System.Drawing.Point(6, 413)
        Me.Bt_select_All.Name = "Bt_select_All"
        Me.Bt_select_All.Size = New System.Drawing.Size(84, 26)
        Me.Bt_select_All.TabIndex = 3
        Me.Bt_select_All.TabStop = False
        Me.Bt_select_All.Text = "Select All"
        Me.Bt_select_All.UseVisualStyleBackColor = False
        '
        'CB_CRT
        '
        Me.CB_CRT.BackColor = System.Drawing.Color.Transparent
        Me.CB_CRT.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.CB_CRT.FlatAppearance.CheckedBackColor = System.Drawing.Color.White
        Me.CB_CRT.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Cyan
        Me.CB_CRT.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan
        Me.CB_CRT.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CB_CRT.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CB_CRT.ForeColor = System.Drawing.Color.MidnightBlue
        Me.CB_CRT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CB_CRT.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.CB_CRT.Location = New System.Drawing.Point(1, 19)
        Me.CB_CRT.Name = "CB_CRT"
        Me.CB_CRT.Padding = New System.Windows.Forms.Padding(75, 0, 0, 0)
        Me.CB_CRT.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CB_CRT.Size = New System.Drawing.Size(193, 23)
        Me.CB_CRT.TabIndex = 68
        Me.CB_CRT.Text = "Custom Mission?"
        Me.ToolTipForHostModel.SetToolTip(Me.CB_CRT, "Custom test mission for each slave.")
        Me.CB_CRT.UseVisualStyleBackColor = False
        '
        'L_TestMissionTitle
        '
        Me.L_TestMissionTitle.BackColor = System.Drawing.Color.YellowGreen
        Me.L_TestMissionTitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.L_TestMissionTitle.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L_TestMissionTitle.ForeColor = System.Drawing.Color.DarkGreen
        Me.L_TestMissionTitle.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.L_TestMissionTitle.Location = New System.Drawing.Point(1, 1)
        Me.L_TestMissionTitle.Name = "L_TestMissionTitle"
        Me.L_TestMissionTitle.Size = New System.Drawing.Size(194, 19)
        Me.L_TestMissionTitle.TabIndex = 29
        Me.L_TestMissionTitle.Text = "Test Mission"
        '
        'BT_TestList_Back
        '
        Me.BT_TestList_Back.BackColor = System.Drawing.Color.Transparent
        Me.BT_TestList_Back.Enabled = False
        Me.BT_TestList_Back.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.BT_TestList_Back.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BT_TestList_Back.Location = New System.Drawing.Point(5, 66)
        Me.BT_TestList_Back.Name = "BT_TestList_Back"
        Me.BT_TestList_Back.Size = New System.Drawing.Size(185, 325)
        Me.BT_TestList_Back.TabIndex = 9
        Me.BT_TestList_Back.UseVisualStyleBackColor = False
        '
        'RadioButton_Textbox
        '
        Me.RadioButton_Textbox.BackColor = System.Drawing.Color.Transparent
        Me.RadioButton_Textbox.FlatAppearance.BorderColor = System.Drawing.Color.SeaGreen
        Me.RadioButton_Textbox.FlatAppearance.BorderSize = 0
        Me.RadioButton_Textbox.FlatAppearance.CheckedBackColor = System.Drawing.Color.Honeydew
        Me.RadioButton_Textbox.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Honeydew
        Me.RadioButton_Textbox.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Honeydew
        Me.RadioButton_Textbox.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.RadioButton_Textbox.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_Textbox.ForeColor = System.Drawing.Color.MidnightBlue
        Me.RadioButton_Textbox.Location = New System.Drawing.Point(97, 389)
        Me.RadioButton_Textbox.Name = "RadioButton_Textbox"
        Me.RadioButton_Textbox.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.RadioButton_Textbox.Size = New System.Drawing.Size(92, 23)
        Me.RadioButton_Textbox.TabIndex = 127
        Me.RadioButton_Textbox.Text = "TextBox"
        Me.RadioButton_Textbox.UseVisualStyleBackColor = False
        '
        'L_TBRTotal
        '
        Me.L_TBRTotal.AutoSize = True
        Me.L_TBRTotal.BackColor = System.Drawing.Color.Transparent
        Me.L_TBRTotal.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.L_TBRTotal.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L_TBRTotal.ForeColor = System.Drawing.Color.MidnightBlue
        Me.L_TBRTotal.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.L_TBRTotal.Location = New System.Drawing.Point(40, 48)
        Me.L_TBRTotal.Name = "L_TBRTotal"
        Me.L_TBRTotal.Size = New System.Drawing.Size(13, 14)
        Me.L_TBRTotal.TabIndex = 57
        Me.L_TBRTotal.Text = "0"
        '
        'Label_ListNrTitle
        '
        Me.Label_ListNrTitle.BackColor = System.Drawing.Color.Transparent
        Me.Label_ListNrTitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label_ListNrTitle.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_ListNrTitle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label_ListNrTitle.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label_ListNrTitle.Location = New System.Drawing.Point(3, 48)
        Me.Label_ListNrTitle.Name = "Label_ListNrTitle"
        Me.Label_ListNrTitle.Size = New System.Drawing.Size(45, 36)
        Me.Label_ListNrTitle.TabIndex = 56
        Me.Label_ListNrTitle.Text = "Total:"
        '
        'RadioButton_Listbox
        '
        Me.RadioButton_Listbox.BackColor = System.Drawing.Color.Transparent
        Me.RadioButton_Listbox.FlatAppearance.BorderColor = System.Drawing.Color.SeaGreen
        Me.RadioButton_Listbox.FlatAppearance.BorderSize = 0
        Me.RadioButton_Listbox.FlatAppearance.CheckedBackColor = System.Drawing.Color.Honeydew
        Me.RadioButton_Listbox.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Honeydew
        Me.RadioButton_Listbox.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Honeydew
        Me.RadioButton_Listbox.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.RadioButton_Listbox.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_Listbox.ForeColor = System.Drawing.Color.MidnightBlue
        Me.RadioButton_Listbox.Location = New System.Drawing.Point(6, 389)
        Me.RadioButton_Listbox.Name = "RadioButton_Listbox"
        Me.RadioButton_Listbox.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.RadioButton_Listbox.Size = New System.Drawing.Size(85, 23)
        Me.RadioButton_Listbox.TabIndex = 126
        Me.RadioButton_Listbox.Text = "ListBox"
        Me.RadioButton_Listbox.UseVisualStyleBackColor = False
        '
        'Button_TestMission
        '
        Me.Button_TestMission.BackColor = System.Drawing.Color.Transparent
        Me.Button_TestMission.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button_TestMission.Enabled = False
        Me.Button_TestMission.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray
        Me.Button_TestMission.FlatAppearance.BorderSize = 0
        Me.Button_TestMission.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_TestMission.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button_TestMission.Location = New System.Drawing.Point(0, 0)
        Me.Button_TestMission.Name = "Button_TestMission"
        Me.Button_TestMission.Size = New System.Drawing.Size(197, 488)
        Me.Button_TestMission.TabIndex = 90
        Me.Button_TestMission.UseVisualStyleBackColor = False
        '
        'Panel_CustomMissionPanel
        '
        Me.Panel_CustomMissionPanel.BackColor = System.Drawing.Color.Transparent
        Me.Panel_CustomMissionPanel.BackgroundImage = Global.ATester.My.Resources.Resources.Mainback
        Me.Panel_CustomMissionPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel_CustomMissionPanel.Controls.Add(Me.ListView_CustomMission)
        Me.Panel_CustomMissionPanel.Controls.Add(Me.Bt_MissionPanel)
        Me.Panel_CustomMissionPanel.Controls.Add(Me.L_totalOfCustom)
        Me.Panel_CustomMissionPanel.Controls.Add(Me.Label4)
        Me.Panel_CustomMissionPanel.Controls.Add(Me.Button11)
        Me.Panel_CustomMissionPanel.ForeColor = System.Drawing.Color.White
        Me.Panel_CustomMissionPanel.Location = New System.Drawing.Point(591, 85)
        Me.Panel_CustomMissionPanel.Name = "Panel_CustomMissionPanel"
        Me.Panel_CustomMissionPanel.Size = New System.Drawing.Size(197, 493)
        Me.Panel_CustomMissionPanel.TabIndex = 103
        '
        'ListView_CustomMission
        '
        Me.ListView_CustomMission.AutoArrange = False
        Me.ListView_CustomMission.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ListView_CustomMission.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
        Me.ListView_CustomMission.FullRowSelect = True
        Me.ListView_CustomMission.GridLines = True
        Me.ListView_CustomMission.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.ListView_CustomMission.LabelWrap = False
        Me.ListView_CustomMission.Location = New System.Drawing.Point(6, 67)
        Me.ListView_CustomMission.Name = "ListView_CustomMission"
        Me.ListView_CustomMission.Size = New System.Drawing.Size(184, 339)
        Me.ListView_CustomMission.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.ListView_CustomMission.TabIndex = 104
        Me.ToolTipForHostModel.SetToolTip(Me.ListView_CustomMission, "Click ""Mission Panel"" to edit.")
        Me.ListView_CustomMission.UseCompatibleStateImageBehavior = False
        Me.ListView_CustomMission.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Slave"
        Me.ColumnHeader1.Width = 88
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Tests Number"
        Me.ColumnHeader2.Width = 95
        '
        'Bt_MissionPanel
        '
        Me.Bt_MissionPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Bt_MissionPanel.BackColor = System.Drawing.Color.Transparent
        Me.Bt_MissionPanel.BackgroundImage = CType(resources.GetObject("Bt_MissionPanel.BackgroundImage"), System.Drawing.Image)
        Me.Bt_MissionPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Bt_MissionPanel.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.Bt_MissionPanel.FlatAppearance.BorderSize = 0
        Me.Bt_MissionPanel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Bt_MissionPanel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Bt_MissionPanel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Bt_MissionPanel.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Bt_MissionPanel.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Bt_MissionPanel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Bt_MissionPanel.Location = New System.Drawing.Point(9, 415)
        Me.Bt_MissionPanel.Name = "Bt_MissionPanel"
        Me.Bt_MissionPanel.Size = New System.Drawing.Size(182, 54)
        Me.Bt_MissionPanel.TabIndex = 67
        Me.Bt_MissionPanel.Text = "Mission Panel"
        Me.Bt_MissionPanel.UseVisualStyleBackColor = False
        '
        'L_totalOfCustom
        '
        Me.L_totalOfCustom.AutoSize = True
        Me.L_totalOfCustom.BackColor = System.Drawing.Color.Transparent
        Me.L_totalOfCustom.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.L_totalOfCustom.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.L_totalOfCustom.ForeColor = System.Drawing.Color.MidnightBlue
        Me.L_totalOfCustom.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.L_totalOfCustom.Location = New System.Drawing.Point(40, 48)
        Me.L_totalOfCustom.Name = "L_totalOfCustom"
        Me.L_totalOfCustom.Size = New System.Drawing.Size(15, 17)
        Me.L_totalOfCustom.TabIndex = 104
        Me.L_totalOfCustom.Text = "0"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label4.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.Label4.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(3, 48)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 36)
        Me.Label4.TabIndex = 103
        Me.Label4.Text = "Total:"
        '
        'Button11
        '
        Me.Button11.BackColor = System.Drawing.Color.Transparent
        Me.Button11.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button11.Enabled = False
        Me.Button11.FlatAppearance.BorderColor = System.Drawing.Color.Honeydew
        Me.Button11.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button11.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button11.Location = New System.Drawing.Point(0, 0)
        Me.Button11.Name = "Button11"
        Me.Button11.Size = New System.Drawing.Size(197, 493)
        Me.Button11.TabIndex = 90
        Me.Button11.UseVisualStyleBackColor = False
        '
        'BT_TopBar
        '
        Me.BT_TopBar.BackColor = System.Drawing.Color.Transparent
        Me.BT_TopBar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BT_TopBar.FlatAppearance.BorderColor = System.Drawing.Color.Green
        Me.BT_TopBar.FlatAppearance.BorderSize = 0
        Me.BT_TopBar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.BT_TopBar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.BT_TopBar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BT_TopBar.Font = New System.Drawing.Font("Nirmala UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT_TopBar.ForeColor = System.Drawing.Color.White
        Me.BT_TopBar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.BT_TopBar.Location = New System.Drawing.Point(1, 1)
        Me.BT_TopBar.Name = "BT_TopBar"
        Me.BT_TopBar.Size = New System.Drawing.Size(766, 24)
        Me.BT_TopBar.TabIndex = 121
        Me.BT_TopBar.TabStop = False
        Me.BT_TopBar.Text = "ATester"
        Me.BT_TopBar.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.BT_TopBar.UseVisualStyleBackColor = False
        '
        'Button_TopBar_Back
        '
        Me.Button_TopBar_Back.BackColor = System.Drawing.Color.Silver
        Me.Button_TopBar_Back.BackgroundImage = Global.ATester.My.Resources.Resources.title
        Me.Button_TopBar_Back.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button_TopBar_Back.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.Button_TopBar_Back.FlatAppearance.BorderSize = 0
        Me.Button_TopBar_Back.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button_TopBar_Back.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button_TopBar_Back.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_TopBar_Back.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_TopBar_Back.ForeColor = System.Drawing.Color.White
        Me.Button_TopBar_Back.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button_TopBar_Back.Location = New System.Drawing.Point(1, 1)
        Me.Button_TopBar_Back.Name = "Button_TopBar_Back"
        Me.Button_TopBar_Back.Size = New System.Drawing.Size(266, 29)
        Me.Button_TopBar_Back.TabIndex = 133
        Me.Button_TopBar_Back.TabStop = False
        Me.Button_TopBar_Back.UseVisualStyleBackColor = False
        '
        'Panel_RunMode
        '
        Me.Panel_RunMode.BackgroundImage = Global.ATester.My.Resources.Resources.Mainback
        Me.Panel_RunMode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel_RunMode.Controls.Add(Me.L_RunMode)
        Me.Panel_RunMode.Controls.Add(Me.RadioButton_RemoteMode)
        Me.Panel_RunMode.Controls.Add(Me.RadioButton_LocalMode)
        Me.Panel_RunMode.Controls.Add(Me.Button4)
        Me.Panel_RunMode.Controls.Add(Me.BT_RunMode_Back)
        Me.Panel_RunMode.Controls.Add(Me.TB_LC_Save)
        Me.Panel_RunMode.Location = New System.Drawing.Point(9, 112)
        Me.Panel_RunMode.Name = "Panel_RunMode"
        Me.Panel_RunMode.Size = New System.Drawing.Size(540, 104)
        Me.Panel_RunMode.TabIndex = 141
        '
        'L_RunMode
        '
        Me.L_RunMode.BackColor = System.Drawing.Color.YellowGreen
        Me.L_RunMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.L_RunMode.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L_RunMode.ForeColor = System.Drawing.Color.DarkGreen
        Me.L_RunMode.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.L_RunMode.Location = New System.Drawing.Point(1, 1)
        Me.L_RunMode.Name = "L_RunMode"
        Me.L_RunMode.Size = New System.Drawing.Size(537, 19)
        Me.L_RunMode.TabIndex = 131
        Me.L_RunMode.Text = "Running Mode"
        '
        'RadioButton_RemoteMode
        '
        Me.RadioButton_RemoteMode.BackColor = System.Drawing.Color.Transparent
        Me.RadioButton_RemoteMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.RadioButton_RemoteMode.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.RadioButton_RemoteMode.ForeColor = System.Drawing.Color.MidnightBlue
        Me.RadioButton_RemoteMode.Location = New System.Drawing.Point(72, 18)
        Me.RadioButton_RemoteMode.Name = "RadioButton_RemoteMode"
        Me.RadioButton_RemoteMode.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.RadioButton_RemoteMode.Size = New System.Drawing.Size(75, 23)
        Me.RadioButton_RemoteMode.TabIndex = 129
        Me.RadioButton_RemoteMode.Text = "Remote"
        Me.RadioButton_RemoteMode.UseVisualStyleBackColor = False
        '
        'RadioButton_LocalMode
        '
        Me.RadioButton_LocalMode.BackColor = System.Drawing.Color.Transparent
        Me.RadioButton_LocalMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.RadioButton_LocalMode.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.RadioButton_LocalMode.ForeColor = System.Drawing.Color.MidnightBlue
        Me.RadioButton_LocalMode.Location = New System.Drawing.Point(5, 18)
        Me.RadioButton_LocalMode.Name = "RadioButton_LocalMode"
        Me.RadioButton_LocalMode.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.RadioButton_LocalMode.Size = New System.Drawing.Size(61, 23)
        Me.RadioButton_LocalMode.TabIndex = 128
        Me.RadioButton_LocalMode.Text = "Local"
        Me.RadioButton_LocalMode.UseVisualStyleBackColor = False
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.Transparent
        Me.Button4.Enabled = False
        Me.Button4.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray
        Me.Button4.FlatAppearance.BorderSize = 0
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button4.Location = New System.Drawing.Point(0, 0)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(540, 107)
        Me.Button4.TabIndex = 130
        Me.Button4.UseVisualStyleBackColor = False
        '
        'BT_RunMode_Back
        '
        Me.BT_RunMode_Back.BackColor = System.Drawing.Color.Transparent
        Me.BT_RunMode_Back.Enabled = False
        Me.BT_RunMode_Back.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.BT_RunMode_Back.FlatAppearance.BorderSize = 0
        Me.BT_RunMode_Back.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BT_RunMode_Back.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT_RunMode_Back.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.BT_RunMode_Back.Location = New System.Drawing.Point(0, 19)
        Me.BT_RunMode_Back.Name = "BT_RunMode_Back"
        Me.BT_RunMode_Back.Size = New System.Drawing.Size(533, 19)
        Me.BT_RunMode_Back.TabIndex = 136
        Me.BT_RunMode_Back.UseVisualStyleBackColor = False
        '
        'TB_LC_Save
        '
        Me.TB_LC_Save.BackColor = System.Drawing.Color.White
        Me.TB_LC_Save.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TB_LC_Save.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TB_LC_Save.ForeColor = System.Drawing.Color.RoyalBlue
        Me.TB_LC_Save.Location = New System.Drawing.Point(56, -25)
        Me.TB_LC_Save.Multiline = True
        Me.TB_LC_Save.Name = "TB_LC_Save"
        Me.TB_LC_Save.ReadOnly = True
        Me.TB_LC_Save.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TB_LC_Save.Size = New System.Drawing.Size(435, 127)
        Me.TB_LC_Save.TabIndex = 52
        Me.TB_LC_Save.Visible = False
        Me.TB_LC_Save.WordWrap = False
        '
        'TB_FormBack
        '
        Me.TB_FormBack.BackColor = System.Drawing.Color.White
        Me.TB_FormBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.TB_FormBack.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.TB_FormBack.FlatAppearance.BorderSize = 0
        Me.TB_FormBack.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.TB_FormBack.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.TB_FormBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.TB_FormBack.Location = New System.Drawing.Point(0, 0)
        Me.TB_FormBack.Name = "TB_FormBack"
        Me.TB_FormBack.Size = New System.Drawing.Size(795, 598)
        Me.TB_FormBack.TabIndex = 140
        Me.TB_FormBack.UseVisualStyleBackColor = False
        '
        'NI
        '
        Me.NI.BalloonTipTitle = "ATester"
        Me.NI.Icon = CType(resources.GetObject("NI.Icon"), System.Drawing.Icon)
        Me.NI.Text = "ATester"
        '
        'ToolTipDeleteInfo
        '
        Me.ToolTipDeleteInfo.AutomaticDelay = 1500
        Me.ToolTipDeleteInfo.AutoPopDelay = 15000
        Me.ToolTipDeleteInfo.BackColor = System.Drawing.Color.White
        Me.ToolTipDeleteInfo.InitialDelay = 100
        Me.ToolTipDeleteInfo.ReshowDelay = 300
        '
        'ToolTipForHostModel
        '
        Me.ToolTipForHostModel.AutoPopDelay = 5000
        Me.ToolTipForHostModel.BackColor = System.Drawing.Color.White
        Me.ToolTipForHostModel.InitialDelay = 100
        Me.ToolTipForHostModel.ReshowDelay = 200
        Me.ToolTipForHostModel.ShowAlways = True
        '
        'ToolTip_Panda
        '
        Me.ToolTip_Panda.AutomaticDelay = 100
        Me.ToolTip_Panda.AutoPopDelay = 2000
        Me.ToolTip_Panda.BackColor = System.Drawing.Color.White
        Me.ToolTip_Panda.InitialDelay = 100
        Me.ToolTip_Panda.IsBalloon = True
        Me.ToolTip_Panda.ReshowDelay = 20
        '
        'L_Tool_Split
        '
        Me.L_Tool_Split.BackColor = System.Drawing.Color.White
        Me.L_Tool_Split.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.L_Tool_Split.FlatAppearance.BorderSize = 0
        Me.L_Tool_Split.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.L_Tool_Split.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.L_Tool_Split.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.L_Tool_Split.Location = New System.Drawing.Point(133, 78)
        Me.L_Tool_Split.Name = "L_Tool_Split"
        Me.L_Tool_Split.Size = New System.Drawing.Size(75, 2)
        Me.L_Tool_Split.TabIndex = 145
        Me.L_Tool_Split.UseVisualStyleBackColor = False
        '
        'Panel_ProjectType
        '
        Me.Panel_ProjectType.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel_ProjectType.Controls.Add(Me.L_tsofcaseTile)
        Me.Panel_ProjectType.Controls.Add(Me.TB_tsofcase)
        Me.Panel_ProjectType.Controls.Add(Me.L_tsofcaseUnit)
        Me.Panel_ProjectType.Controls.Add(Me.ComboBox_Project)
        Me.Panel_ProjectType.Controls.Add(Me.L_PT)
        Me.Panel_ProjectType.Location = New System.Drawing.Point(9, 82)
        Me.Panel_ProjectType.Name = "Panel_ProjectType"
        Me.Panel_ProjectType.Size = New System.Drawing.Size(540, 27)
        Me.Panel_ProjectType.TabIndex = 146
        '
        'L_tsofcaseTile
        '
        Me.L_tsofcaseTile.BackColor = System.Drawing.Color.Transparent
        Me.L_tsofcaseTile.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.L_tsofcaseTile.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L_tsofcaseTile.ForeColor = System.Drawing.Color.MidnightBlue
        Me.L_tsofcaseTile.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.L_tsofcaseTile.Location = New System.Drawing.Point(342, 3)
        Me.L_tsofcaseTile.Name = "L_tsofcaseTile"
        Me.L_tsofcaseTile.Size = New System.Drawing.Size(67, 21)
        Me.L_tsofcaseTile.TabIndex = 134
        Me.L_tsofcaseTile.Text = "Timeout"
        Me.L_tsofcaseTile.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TB_tsofcase
        '
        Me.TB_tsofcase.BackColor = System.Drawing.Color.Honeydew
        Me.TB_tsofcase.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TB_tsofcase.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TB_tsofcase.Location = New System.Drawing.Point(415, 4)
        Me.TB_tsofcase.Name = "TB_tsofcase"
        Me.TB_tsofcase.Size = New System.Drawing.Size(47, 19)
        Me.TB_tsofcase.TabIndex = 149
        Me.TB_tsofcase.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TB_tsofcase.WordWrap = False
        '
        'L_tsofcaseUnit
        '
        Me.L_tsofcaseUnit.BackColor = System.Drawing.Color.Transparent
        Me.L_tsofcaseUnit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.L_tsofcaseUnit.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L_tsofcaseUnit.ForeColor = System.Drawing.Color.MidnightBlue
        Me.L_tsofcaseUnit.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.L_tsofcaseUnit.Location = New System.Drawing.Point(468, 4)
        Me.L_tsofcaseUnit.Name = "L_tsofcaseUnit"
        Me.L_tsofcaseUnit.Size = New System.Drawing.Size(70, 20)
        Me.L_tsofcaseUnit.TabIndex = 150
        Me.L_tsofcaseUnit.Text = "min/case"
        Me.L_tsofcaseUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ComboBox_Project
        '
        Me.ComboBox_Project.BackColor = System.Drawing.Color.Honeydew
        Me.ComboBox_Project.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ComboBox_Project.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox_Project.ForeColor = System.Drawing.Color.Black
        Me.ComboBox_Project.FormattingEnabled = True
        Me.ComboBox_Project.Location = New System.Drawing.Point(85, 2)
        Me.ComboBox_Project.Name = "ComboBox_Project"
        Me.ComboBox_Project.Size = New System.Drawing.Size(114, 23)
        Me.ComboBox_Project.TabIndex = 147
        '
        'L_PT
        '
        Me.L_PT.BackColor = System.Drawing.Color.Transparent
        Me.L_PT.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.L_PT.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L_PT.ForeColor = System.Drawing.Color.MidnightBlue
        Me.L_PT.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.L_PT.Location = New System.Drawing.Point(0, 1)
        Me.L_PT.Name = "L_PT"
        Me.L_PT.Size = New System.Drawing.Size(94, 23)
        Me.L_PT.TabIndex = 148
        Me.L_PT.Text = "Project Type"
        Me.L_PT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BT_bottom
        '
        Me.BT_bottom.BackColor = System.Drawing.Color.Transparent
        Me.BT_bottom.BackgroundImage = Global.ATester.My.Resources.Resources.title
        Me.BT_bottom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BT_bottom.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.BT_bottom.FlatAppearance.BorderSize = 0
        Me.BT_bottom.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.BT_bottom.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.BT_bottom.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BT_bottom.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT_bottom.ForeColor = System.Drawing.Color.White
        Me.BT_bottom.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.BT_bottom.Location = New System.Drawing.Point(0, 576)
        Me.BT_bottom.Name = "BT_bottom"
        Me.BT_bottom.Size = New System.Drawing.Size(766, 21)
        Me.BT_bottom.TabIndex = 144
        Me.BT_bottom.TabStop = False
        Me.BT_bottom.Text = "V8.0 Designed by Chinese Team "
        Me.BT_bottom.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.BT_bottom.UseVisualStyleBackColor = False
        '
        'ProgressBar_Run_top
        '
        Me.ProgressBar_Run_top.BackColor = System.Drawing.Color.White
        Me.ProgressBar_Run_top.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ProgressBar_Run_top.ForeColor = System.Drawing.Color.Green
        Me.ProgressBar_Run_top.Location = New System.Drawing.Point(0, 575)
        Me.ProgressBar_Run_top.Name = "ProgressBar_Run_top"
        Me.ProgressBar_Run_top.Size = New System.Drawing.Size(795, 24)
        Me.ProgressBar_Run_top.Step = 0
        Me.ProgressBar_Run_top.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.ProgressBar_Run_top.TabIndex = 147
        Me.ProgressBar_Run_top.Visible = False
        '
        'Form_Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(795, 599)
        Me.ControlBox = False
        Me.Controls.Add(Me.ProgressBar_Run_top)
        Me.Controls.Add(Me.Panel_ProjectType)
        Me.Controls.Add(Me.L_Tool_Split)
        Me.Controls.Add(Me.BT_bottom)
        Me.Controls.Add(Me.Panel_RunStatus)
        Me.Controls.Add(Me.BT_TopBar)
        Me.Controls.Add(Me.Panel_Reporting)
        Me.Controls.Add(Me.Panel_RemoteMode)
        Me.Controls.Add(Me.Button_TopBar_Back)
        Me.Controls.Add(Me.BT_Clean_LC_Save)
        Me.Controls.Add(Me.TB_RR_Dir_Save)
        Me.Controls.Add(Me.ToolStrip)
        Me.Controls.Add(Me.TB_RR_IPs_Save)
        Me.Controls.Add(Me.Label_shutdown)
        Me.Controls.Add(Me.L_TimeRemaining)
        Me.Controls.Add(Me.MenuStrip)
        Me.Controls.Add(Me.BT_IMBPT)
        Me.Controls.Add(Me.CB_NormalRun)
        Me.Controls.Add(Me.BT_EXTBPT)
        Me.Controls.Add(Me.CB_Servers)
        Me.Controls.Add(Me.L_BT_IMBPT)
        Me.Controls.Add(Me.BT_Min)
        Me.Controls.Add(Me.L_BT_EXTBPT)
        Me.Controls.Add(Me.BT_Close)
        Me.Controls.Add(Me.BT_Clean_RR_IPs_Save)
        Me.Controls.Add(Me.ExpandButton)
        Me.Controls.Add(Me.PictureBox_Panda)
        Me.Controls.Add(Me.BT_Clean_RR_Dirs_Save)
        Me.Controls.Add(Me.Panel_RunMode)
        Me.Controls.Add(Me.Panel_TestMissionPanel)
        Me.Controls.Add(Me.Panel_CustomMissionPanel)
        Me.Controls.Add(Me.TB_FormBack)
        Me.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.ForeColor = System.Drawing.Color.Black
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MainMenuStrip = Me.MenuStrip
        Me.MaximizeBox = False
        Me.Name = "Form_Main"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Tag = "atester"
        Me.Text = "ATester"
        Me.Panel_RunStatus.ResumeLayout(False)
        Me.Panel_RunInfo.ResumeLayout(False)
        Me.Panel_RunInfo.PerformLayout()
        Me.P_RM.ResumeLayout(False)
        Me.Panel_Log.ResumeLayout(False)
        Me.Panel_Log.PerformLayout()
        Me.Panel_Reporting.ResumeLayout(False)
        Me.Panel_Reporting.PerformLayout()
        Me.P_ReportIP_back.ResumeLayout(False)
        Me.Panel_RemoteMode.ResumeLayout(False)
        Me.Panel_RemoteMode.PerformLayout()
        Me.Panel_LocalMode.ResumeLayout(False)
        Me.Panel_LocalMode.PerformLayout()
        CType(Me.PictureBox_Panda, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        Me.Panel_TestMissionPanel.ResumeLayout(False)
        Me.Panel_TestMissionPanel.PerformLayout()
        Me.Panel_TestMissionList.ResumeLayout(False)
        Me.Panel_TestMissionList.PerformLayout()
        Me.Panel_CustomMissionPanel.ResumeLayout(False)
        Me.Panel_CustomMissionPanel.PerformLayout()
        Me.Panel_RunMode.ResumeLayout(False)
        Me.Panel_RunMode.PerformLayout()
        Me.Panel_ProjectType.ResumeLayout(False)
        Me.Panel_ProjectType.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CLB_Testlist As System.Windows.Forms.CheckedListBox
    Friend WithEvents Bt_select_All As System.Windows.Forms.Button
    Friend WithEvents Bt_Refresh As System.Windows.Forms.Button
    Friend WithEvents Bt_Clean_All As System.Windows.Forms.Button
    Friend WithEvents TB_ReportFolder As System.Windows.Forms.TextBox
    Friend WithEvents L_Reporting As System.Windows.Forms.Label
    Friend WithEvents TB_RR_IPs As System.Windows.Forms.TextBox
    Friend WithEvents CB_Servers As System.Windows.Forms.CheckBox
    Friend WithEvents BT_CheckReport As System.Windows.Forms.Button
    Friend WithEvents TB_MainLog As System.Windows.Forms.TextBox
    Friend WithEvents TB_OneTimeNumber As System.Windows.Forms.TextBox
    Friend WithEvents TB_DeadLine As System.Windows.Forms.TextBox
    Friend WithEvents BT_EditResource As System.Windows.Forms.Button
    Friend WithEvents Label_OT As System.Windows.Forms.Label
    Friend WithEvents Label_timeout As System.Windows.Forms.Label
    Friend WithEvents TB_BPTList As System.Windows.Forms.TextBox
    Friend WithEvents L_TestMissionTitle As System.Windows.Forms.Label
    Friend WithEvents CB_Excel As System.Windows.Forms.CheckBox
    Friend WithEvents L_TimeOut_Unit As System.Windows.Forms.Label
    Friend WithEvents BT_Close As System.Windows.Forms.Button
    Friend WithEvents BT_Min As System.Windows.Forms.Button
    Friend WithEvents NI As System.Windows.Forms.NotifyIcon
    Friend WithEvents TB_LC As System.Windows.Forms.TextBox
    Friend WithEvents BT_LC As System.Windows.Forms.Button
    Friend WithEvents TB_ReportFolder_R As System.Windows.Forms.TextBox
    Friend WithEvents BT_Erase As System.Windows.Forms.Button
    Friend WithEvents L_Remain As System.Windows.Forms.Label
    Friend WithEvents L_Remain_Value As System.Windows.Forms.Label
    Friend WithEvents L_Total_Value As System.Windows.Forms.Label
    Friend WithEvents L_PassRate As System.Windows.Forms.Label
    Friend WithEvents BT_Clean_LC_Save As System.Windows.Forms.Button
    Friend WithEvents TB_RR_Dir_Save As System.Windows.Forms.TextBox
    Friend WithEvents BT_Clean_RR_Dirs_Save As System.Windows.Forms.Button
    Friend WithEvents BT_EXTBPT As System.Windows.Forms.Button
    Friend WithEvents BT_IMBPT As System.Windows.Forms.Button
    Friend WithEvents L_TBRTotal As System.Windows.Forms.Label
    Friend WithEvents Label_ListNrTitle As System.Windows.Forms.Label
    Friend WithEvents ExpandButton As System.Windows.Forms.Button
    Friend WithEvents CB_NormalRun As System.Windows.Forms.CheckBox
    Friend WithEvents CB_HostMode As System.Windows.Forms.CheckBox
    Friend WithEvents Label_LR_Dir As System.Windows.Forms.Label
    Friend WithEvents Label_RR_IPs As System.Windows.Forms.Label
    Friend WithEvents TB_RR_Dir As System.Windows.Forms.TextBox
    Friend WithEvents Label_RRDir As System.Windows.Forms.Label
    Friend WithEvents BT_Clean_RR_IPs_Save As System.Windows.Forms.Button
    Friend WithEvents TB_RR_IPs_Save As System.Windows.Forms.TextBox
    Friend WithEvents L_PerOneSlave As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Bt_MissionPanel As System.Windows.Forms.Button
    Friend WithEvents ToolTipDeleteInfo As System.Windows.Forms.ToolTip
    Friend WithEvents CB_CRT As System.Windows.Forms.CheckBox
    Friend WithEvents L_ReportServerIP As System.Windows.Forms.Label
    Friend WithEvents ToolTipForHostModel As System.Windows.Forms.ToolTip
    Friend WithEvents Link_RTR As System.Windows.Forms.LinkLabel
    Friend WithEvents CLB_ReportServerIP As System.Windows.Forms.CheckedListBox
    Friend WithEvents L_BT_IMBPT As System.Windows.Forms.Label
    Friend WithEvents L_BT_EXTBPT As System.Windows.Forms.Label
    Friend WithEvents L_LogTitle As System.Windows.Forms.Label
    Friend WithEvents Button_Report_Back As System.Windows.Forms.Button
    Friend WithEvents Bt_runingst As System.Windows.Forms.Button
    Friend WithEvents Button_TestMission As System.Windows.Forms.Button
    Friend WithEvents MenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents ToolStripMenuItem_Advance As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RemoteDesktopManagerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LibraryToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CheckRemoteUFTStatusToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveConfigurationAsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenConfigurationToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PictureBox_Panda As System.Windows.Forms.PictureBox
    Friend WithEvents ToolTip_Panda As System.Windows.Forms.ToolTip
    Friend WithEvents CloseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Panel_TestMissionPanel As System.Windows.Forms.Panel
    Friend WithEvents ShutdownAfterRunToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents L_TimeRemaining As System.Windows.Forms.Label
    Friend WithEvents Label_shutdown As System.Windows.Forms.Label
    Friend WithEvents Bt_RunningMgmt As System.Windows.Forms.Button
    Friend WithEvents Bt_EditSlaveIPs As System.Windows.Forms.Button
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents Bt_Run As System.Windows.Forms.ToolStripButton
    Friend WithEvents Bt_Stop As System.Windows.Forms.ToolStripButton
    Friend WithEvents AlarmToRunToolStripMenuItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton_CheckSlaveStatus As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton_RDM As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton_OpenConfiguration As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton_SavePlan As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton_ShutDown As System.Windows.Forms.ToolStripButton
    Friend WithEvents L_RunningStatus As System.Windows.Forms.Label
    Friend WithEvents Panel_CustomMissionPanel As System.Windows.Forms.Panel
    Friend WithEvents Button11 As System.Windows.Forms.Button
    Friend WithEvents ListView_CustomMission As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents L_totalOfCustom As System.Windows.Forms.Label
    Friend WithEvents RadioButton_Listbox As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton_Textbox As System.Windows.Forms.RadioButton
    Friend WithEvents Panel_Log As System.Windows.Forms.Panel
    Friend WithEvents Panel_RunInfo As System.Windows.Forms.Panel
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Bt_logback As System.Windows.Forms.Button
    Friend WithEvents L_RunMode As System.Windows.Forms.Label
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents RadioButton_LocalMode As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton_RemoteMode As System.Windows.Forms.RadioButton
    Friend WithEvents Panel_LocalMode As System.Windows.Forms.Panel
    Friend WithEvents Panel_RemoteMode As System.Windows.Forms.Panel
    Friend WithEvents TB_LC_Save As System.Windows.Forms.TextBox
    Friend WithEvents BT_RunMode_Back As System.Windows.Forms.Button
    Friend WithEvents P_ReportIP_back As System.Windows.Forms.Panel
    Friend WithEvents Panel_TestMissionList As System.Windows.Forms.Panel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents BT_TopBar As System.Windows.Forms.Button
    Friend WithEvents L_PRValue As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents P_RM As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents TB_FormBack As System.Windows.Forms.Button
    Friend WithEvents BT_EachSlave_back As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents Button_TopBar_Back As System.Windows.Forms.Button
    Friend WithEvents L_RoundID As System.Windows.Forms.Label
    Friend WithEvents Bt_Log_Edit_Back As System.Windows.Forms.Button
    Friend WithEvents Panel_RunMode As System.Windows.Forms.Panel
    Friend WithEvents Panel_Reporting As System.Windows.Forms.Panel
    Friend WithEvents Panel_RunStatus As System.Windows.Forms.Panel
    Friend WithEvents BT_TestList_Back As System.Windows.Forms.Button
    Friend WithEvents L_Tip_RunResult As System.Windows.Forms.Button
    Friend WithEvents L_tip_Timeout As System.Windows.Forms.Button
    Friend WithEvents BT_Progress As System.Windows.Forms.Button
    Friend WithEvents L_Tool_Split As System.Windows.Forms.Button
    Friend WithEvents Panel_ProjectType As System.Windows.Forms.Panel
    Friend WithEvents L_PT As System.Windows.Forms.Label
    Friend WithEvents ComboBox_Project As System.Windows.Forms.ComboBox
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GoldenCasesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SelectModulesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TB_tsofcase As System.Windows.Forms.TextBox
    Friend WithEvents L_tsofcaseUnit As System.Windows.Forms.Label
    Friend WithEvents L_tsofcaseTile As System.Windows.Forms.Label
    Friend WithEvents BT_bottom As System.Windows.Forms.Button
    Friend WithEvents Link_FR As System.Windows.Forms.LinkLabel
    Friend WithEvents Bt_MaxList As System.Windows.Forms.Button
    Friend WithEvents ProgressBar_Run_top As System.Windows.Forms.ProgressBar

End Class
