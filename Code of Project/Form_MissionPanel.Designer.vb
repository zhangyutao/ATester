<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_MissionPanel
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_MissionPanel))
        Me.BT_Close = New System.Windows.Forms.Button()
        Me.ToolTip_BTIPS = New System.Windows.Forms.ToolTip(Me.components)
        Me.BT_GTFAT = New System.Windows.Forms.Button()
        Me.L_ListForIP = New System.Windows.Forms.Label()
        Me.L_BT_GTFAT = New System.Windows.Forms.Label()
        Me.L_IPWrong = New System.Windows.Forms.Label()
        Me.Label_slaveinfo = New System.Windows.Forms.Label()
        Me.PictureBox_Panda = New System.Windows.Forms.PictureBox()
        Me.Panel_Content = New System.Windows.Forms.Panel()
        Me.L_AllTotal_IPs = New System.Windows.Forms.Label()
        Me.L_Note = New System.Windows.Forms.Label()
        Me.BT_TopBar = New System.Windows.Forms.Button()
        Me.Button_Max = New System.Windows.Forms.Button()
        Me.Panel_Main = New System.Windows.Forms.Panel()
        CType(Me.PictureBox_Panda, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel_Content.SuspendLayout()
        Me.Panel_Main.SuspendLayout()
        Me.SuspendLayout()
        '
        'BT_Close
        '
        Me.BT_Close.BackColor = System.Drawing.Color.Transparent
        Me.BT_Close.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.BT_Close.FlatAppearance.BorderSize = 0
        Me.BT_Close.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red
        Me.BT_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BT_Close.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Bold)
        Me.BT_Close.ForeColor = System.Drawing.Color.Black
        Me.BT_Close.Location = New System.Drawing.Point(250, 0)
        Me.BT_Close.Margin = New System.Windows.Forms.Padding(2)
        Me.BT_Close.Name = "BT_Close"
        Me.BT_Close.Size = New System.Drawing.Size(29, 22)
        Me.BT_Close.TabIndex = 0
        Me.BT_Close.TabStop = False
        Me.BT_Close.Text = "X"
        Me.ToolTip_BTIPS.SetToolTip(Me.BT_Close, "Close")
        Me.BT_Close.UseVisualStyleBackColor = False
        '
        'BT_GTFAT
        '
        Me.BT_GTFAT.BackColor = System.Drawing.Color.White
        Me.BT_GTFAT.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray
        Me.BT_GTFAT.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Aqua
        Me.BT_GTFAT.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BT_GTFAT.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT_GTFAT.ForeColor = System.Drawing.Color.Black
        Me.BT_GTFAT.Location = New System.Drawing.Point(8, 62)
        Me.BT_GTFAT.Margin = New System.Windows.Forms.Padding(2)
        Me.BT_GTFAT.Name = "BT_GTFAT"
        Me.BT_GTFAT.Size = New System.Drawing.Size(90, 41)
        Me.BT_GTFAT.TabIndex = 3
        Me.BT_GTFAT.TabStop = False
        Me.BT_GTFAT.Text = "Refresh"
        Me.ToolTip_BTIPS.SetToolTip(Me.BT_GTFAT, "Get test name from host or respective remote server and put them in the active ta" & _
                "b")
        Me.BT_GTFAT.UseVisualStyleBackColor = False
        Me.BT_GTFAT.Visible = False
        '
        'L_ListForIP
        '
        Me.L_ListForIP.BackColor = System.Drawing.Color.Transparent
        Me.L_ListForIP.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.L_ListForIP.Font = New System.Drawing.Font("Nirmala UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.L_ListForIP.ForeColor = System.Drawing.Color.Black
        Me.L_ListForIP.Location = New System.Drawing.Point(111, 44)
        Me.L_ListForIP.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.L_ListForIP.Name = "L_ListForIP"
        Me.L_ListForIP.Size = New System.Drawing.Size(69, 40)
        Me.L_ListForIP.TabIndex = 1
        Me.L_ListForIP.Text = "ListForIP"
        Me.L_ListForIP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.L_ListForIP.Visible = False
        '
        'L_BT_GTFAT
        '
        Me.L_BT_GTFAT.BackColor = System.Drawing.Color.LightGray
        Me.L_BT_GTFAT.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.L_BT_GTFAT.Location = New System.Drawing.Point(18, 58)
        Me.L_BT_GTFAT.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.L_BT_GTFAT.Name = "L_BT_GTFAT"
        Me.L_BT_GTFAT.Size = New System.Drawing.Size(45, 34)
        Me.L_BT_GTFAT.TabIndex = 4
        Me.L_BT_GTFAT.Visible = False
        '
        'L_IPWrong
        '
        Me.L_IPWrong.AutoSize = True
        Me.L_IPWrong.BackColor = System.Drawing.Color.White
        Me.L_IPWrong.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.L_IPWrong.Location = New System.Drawing.Point(-2, 0)
        Me.L_IPWrong.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.L_IPWrong.Name = "L_IPWrong"
        Me.L_IPWrong.Size = New System.Drawing.Size(0, 15)
        Me.L_IPWrong.TabIndex = 2
        Me.L_IPWrong.Visible = False
        '
        'Label_slaveinfo
        '
        Me.Label_slaveinfo.BackColor = System.Drawing.Color.Transparent
        Me.Label_slaveinfo.Font = New System.Drawing.Font("Calibri", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_slaveinfo.ForeColor = System.Drawing.Color.Black
        Me.Label_slaveinfo.Location = New System.Drawing.Point(9, 23)
        Me.Label_slaveinfo.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label_slaveinfo.Name = "Label_slaveinfo"
        Me.Label_slaveinfo.Size = New System.Drawing.Size(185, 224)
        Me.Label_slaveinfo.TabIndex = 5
        Me.Label_slaveinfo.Visible = False
        '
        'PictureBox_Panda
        '
        Me.PictureBox_Panda.BackColor = System.Drawing.Color.White
        Me.PictureBox_Panda.BackgroundImage = Global.ATester.My.Resources.Resources.zhuye
        Me.PictureBox_Panda.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox_Panda.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PictureBox_Panda.Location = New System.Drawing.Point(1, 1)
        Me.PictureBox_Panda.Name = "PictureBox_Panda"
        Me.PictureBox_Panda.Size = New System.Drawing.Size(28, 28)
        Me.PictureBox_Panda.TabIndex = 96
        Me.PictureBox_Panda.TabStop = False
        '
        'Panel_Content
        '
        Me.Panel_Content.BackColor = System.Drawing.Color.White
        Me.Panel_Content.BackgroundImage = Global.ATester.My.Resources.Resources.Mainback
        Me.Panel_Content.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel_Content.Controls.Add(Me.L_AllTotal_IPs)
        Me.Panel_Content.Controls.Add(Me.Label_slaveinfo)
        Me.Panel_Content.Location = New System.Drawing.Point(3, 139)
        Me.Panel_Content.Name = "Panel_Content"
        Me.Panel_Content.Size = New System.Drawing.Size(277, 155)
        Me.Panel_Content.TabIndex = 98
        '
        'L_AllTotal_IPs
        '
        Me.L_AllTotal_IPs.AutoSize = True
        Me.L_AllTotal_IPs.Location = New System.Drawing.Point(122, 169)
        Me.L_AllTotal_IPs.Name = "L_AllTotal_IPs"
        Me.L_AllTotal_IPs.Size = New System.Drawing.Size(0, 13)
        Me.L_AllTotal_IPs.TabIndex = 6
        Me.L_AllTotal_IPs.Visible = False
        '
        'L_Note
        '
        Me.L_Note.AutoSize = True
        Me.L_Note.BackColor = System.Drawing.Color.Transparent
        Me.L_Note.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L_Note.ForeColor = System.Drawing.Color.Red
        Me.L_Note.Location = New System.Drawing.Point(111, 89)
        Me.L_Note.Name = "L_Note"
        Me.L_Note.Size = New System.Drawing.Size(111, 14)
        Me.L_Note.TabIndex = 7
        Me.L_Note.Text = "*one line one case"
        '
        'BT_TopBar
        '
        Me.BT_TopBar.BackColor = System.Drawing.Color.White
        Me.BT_TopBar.BackgroundImage = Global.ATester.My.Resources.Resources.title
        Me.BT_TopBar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BT_TopBar.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.BT_TopBar.FlatAppearance.BorderSize = 0
        Me.BT_TopBar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SteelBlue
        Me.BT_TopBar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan
        Me.BT_TopBar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BT_TopBar.Font = New System.Drawing.Font("Calibri", 11.0!)
        Me.BT_TopBar.ForeColor = System.Drawing.Color.DarkGreen
        Me.BT_TopBar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.BT_TopBar.Location = New System.Drawing.Point(1, 1)
        Me.BT_TopBar.Name = "BT_TopBar"
        Me.BT_TopBar.Size = New System.Drawing.Size(168, 28)
        Me.BT_TopBar.TabIndex = 143
        Me.BT_TopBar.TabStop = False
        Me.BT_TopBar.Text = "         Mission Panel"
        Me.BT_TopBar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BT_TopBar.UseVisualStyleBackColor = False
        '
        'Button_Max
        '
        Me.Button_Max.BackColor = System.Drawing.Color.Transparent
        Me.Button_Max.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.Button_Max.FlatAppearance.BorderSize = 0
        Me.Button_Max.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red
        Me.Button_Max.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Max.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Max.ForeColor = System.Drawing.Color.Black
        Me.Button_Max.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button_Max.Location = New System.Drawing.Point(217, 0)
        Me.Button_Max.Name = "Button_Max"
        Me.Button_Max.Size = New System.Drawing.Size(26, 22)
        Me.Button_Max.TabIndex = 151
        Me.Button_Max.TabStop = False
        Me.Button_Max.Text = "•"
        Me.Button_Max.UseVisualStyleBackColor = False
        '
        'Panel_Main
        '
        Me.Panel_Main.BackColor = System.Drawing.Color.YellowGreen
        Me.Panel_Main.BackgroundImage = Global.ATester.My.Resources.Resources.Mainback
        Me.Panel_Main.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel_Main.Controls.Add(Me.Panel_Content)
        Me.Panel_Main.Controls.Add(Me.L_Note)
        Me.Panel_Main.Controls.Add(Me.L_ListForIP)
        Me.Panel_Main.Controls.Add(Me.BT_GTFAT)
        Me.Panel_Main.Controls.Add(Me.L_BT_GTFAT)
        Me.Panel_Main.Location = New System.Drawing.Point(2, 28)
        Me.Panel_Main.Name = "Panel_Main"
        Me.Panel_Main.Size = New System.Drawing.Size(359, 352)
        Me.Panel_Main.TabIndex = 152
        '
        'Form_MissionPanel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Silver
        Me.ClientSize = New System.Drawing.Size(379, 391)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel_Main)
        Me.Controls.Add(Me.Button_Max)
        Me.Controls.Add(Me.PictureBox_Panda)
        Me.Controls.Add(Me.L_IPWrong)
        Me.Controls.Add(Me.BT_TopBar)
        Me.Controls.Add(Me.BT_Close)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "Form_MissionPanel"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Tag = "atester"
        Me.Text = "Test Missions"
        Me.TopMost = True
        CType(Me.PictureBox_Panda, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel_Content.ResumeLayout(False)
        Me.Panel_Content.PerformLayout()
        Me.Panel_Main.ResumeLayout(False)
        Me.Panel_Main.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BT_Close As System.Windows.Forms.Button
    Friend WithEvents ToolTip_BTIPS As System.Windows.Forms.ToolTip
    Friend WithEvents L_ListForIP As System.Windows.Forms.Label
    Friend WithEvents BT_GTFAT As System.Windows.Forms.Button
    Friend WithEvents L_BT_GTFAT As System.Windows.Forms.Label
    Friend WithEvents L_IPWrong As System.Windows.Forms.Label
    Friend WithEvents Label_slaveinfo As System.Windows.Forms.Label
    Friend WithEvents PictureBox_Panda As System.Windows.Forms.PictureBox
    Friend WithEvents Panel_Content As System.Windows.Forms.Panel
    Friend WithEvents L_AllTotal_IPs As System.Windows.Forms.Label
    Friend WithEvents BT_TopBar As System.Windows.Forms.Button
    Friend WithEvents L_Note As System.Windows.Forms.Label
    Friend WithEvents Button_Max As System.Windows.Forms.Button
    Friend WithEvents Panel_Main As System.Windows.Forms.Panel
End Class
