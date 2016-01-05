<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_Alarm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_Alarm))
        Me.BT_Close = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TB_TimeLeft = New System.Windows.Forms.TextBox()
        Me.Button_Cancel = New System.Windows.Forms.Button()
        Me.Button_OK = New System.Windows.Forms.Button()
        Me.Calloff_Button = New System.Windows.Forms.Button()
        Me.PictureBox_Panda = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.LAlarm = New System.Windows.Forms.Label()
        Me.L_Time = New System.Windows.Forms.Label()
        Me.L_TimeRemaining = New System.Windows.Forms.Label()
        Me.BT_TopBar = New System.Windows.Forms.Button()
        CType(Me.PictureBox_Panda, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.BT_Close.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.BT_Close.Location = New System.Drawing.Point(307, 0)
        Me.BT_Close.Name = "BT_Close"
        Me.BT_Close.Size = New System.Drawing.Size(26, 22)
        Me.BT_Close.TabIndex = 96
        Me.BT_Close.TabStop = False
        Me.BT_Close.Text = "X"
        Me.BT_Close.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Label1.Location = New System.Drawing.Point(36, 90)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(274, 15)
        Me.Label1.TabIndex = 99
        Me.Label1.Text = "Define a new time when you want to start the run." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(1, 1)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(335, 200)
        Me.Label2.TabIndex = 100
        Me.Label2.Text = "Label2"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.White
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(80, 112)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(35, 15)
        Me.Label3.TabIndex = 101
        Me.Label3.Text = "After"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.White
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(202, 112)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 15)
        Me.Label4.TabIndex = 102
        Me.Label4.Text = "minutes"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TB_TimeLeft
        '
        Me.TB_TimeLeft.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TB_TimeLeft.Location = New System.Drawing.Point(121, 108)
        Me.TB_TimeLeft.Name = "TB_TimeLeft"
        Me.TB_TimeLeft.Size = New System.Drawing.Size(75, 22)
        Me.TB_TimeLeft.TabIndex = 103
        Me.TB_TimeLeft.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Button_Cancel
        '
        Me.Button_Cancel.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Button_Cancel.AutoSize = True
        Me.Button_Cancel.BackColor = System.Drawing.Color.White
        Me.Button_Cancel.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray
        Me.Button_Cancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SteelBlue
        Me.Button_Cancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan
        Me.Button_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Cancel.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Button_Cancel.ForeColor = System.Drawing.Color.Black
        Me.Button_Cancel.Location = New System.Drawing.Point(238, 155)
        Me.Button_Cancel.Name = "Button_Cancel"
        Me.Button_Cancel.Size = New System.Drawing.Size(60, 27)
        Me.Button_Cancel.TabIndex = 105
        Me.Button_Cancel.TabStop = False
        Me.Button_Cancel.Text = "Close"
        Me.Button_Cancel.UseVisualStyleBackColor = False
        '
        'Button_OK
        '
        Me.Button_OK.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Button_OK.AutoSize = True
        Me.Button_OK.BackColor = System.Drawing.Color.White
        Me.Button_OK.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray
        Me.Button_OK.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SteelBlue
        Me.Button_OK.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan
        Me.Button_OK.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_OK.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Button_OK.ForeColor = System.Drawing.Color.Black
        Me.Button_OK.Location = New System.Drawing.Point(177, 155)
        Me.Button_OK.Name = "Button_OK"
        Me.Button_OK.Size = New System.Drawing.Size(55, 27)
        Me.Button_OK.TabIndex = 104
        Me.Button_OK.TabStop = False
        Me.Button_OK.Text = "OK"
        Me.Button_OK.UseVisualStyleBackColor = False
        '
        'Calloff_Button
        '
        Me.Calloff_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Calloff_Button.AutoSize = True
        Me.Calloff_Button.BackColor = System.Drawing.Color.White
        Me.Calloff_Button.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray
        Me.Calloff_Button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SteelBlue
        Me.Calloff_Button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red
        Me.Calloff_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Calloff_Button.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Calloff_Button.ForeColor = System.Drawing.Color.Black
        Me.Calloff_Button.Location = New System.Drawing.Point(12, 155)
        Me.Calloff_Button.Name = "Calloff_Button"
        Me.Calloff_Button.Size = New System.Drawing.Size(95, 27)
        Me.Calloff_Button.TabIndex = 106
        Me.Calloff_Button.TabStop = False
        Me.Calloff_Button.Text = "Cancel Alarm"
        Me.Calloff_Button.UseVisualStyleBackColor = False
        Me.Calloff_Button.Visible = False
        '
        'PictureBox_Panda
        '
        Me.PictureBox_Panda.BackColor = System.Drawing.Color.White
        Me.PictureBox_Panda.BackgroundImage = Global.ATester.My.Resources.Resources.zhuye
        Me.PictureBox_Panda.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox_Panda.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PictureBox_Panda.Location = New System.Drawing.Point(2, 1)
        Me.PictureBox_Panda.Name = "PictureBox_Panda"
        Me.PictureBox_Panda.Size = New System.Drawing.Size(28, 28)
        Me.PictureBox_Panda.TabIndex = 97
        Me.PictureBox_Panda.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.White
        Me.PictureBox1.Image = Global.ATester.My.Resources.Resources.timer2
        Me.PictureBox1.Location = New System.Drawing.Point(5, 29)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(55, 55)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 107
        Me.PictureBox1.TabStop = False
        '
        'LAlarm
        '
        Me.LAlarm.AutoSize = True
        Me.LAlarm.BackColor = System.Drawing.Color.White
        Me.LAlarm.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LAlarm.Location = New System.Drawing.Point(68, 39)
        Me.LAlarm.Name = "LAlarm"
        Me.LAlarm.Size = New System.Drawing.Size(134, 30)
        Me.LAlarm.TabIndex = 108
        Me.LAlarm.Text = "You have an Alarm on: " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Time remaining:"
        Me.LAlarm.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'L_Time
        '
        Me.L_Time.AutoSize = True
        Me.L_Time.BackColor = System.Drawing.Color.White
        Me.L_Time.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L_Time.ForeColor = System.Drawing.Color.OrangeRed
        Me.L_Time.Location = New System.Drawing.Point(195, 39)
        Me.L_Time.Name = "L_Time"
        Me.L_Time.Size = New System.Drawing.Size(15, 15)
        Me.L_Time.TabIndex = 110
        Me.L_Time.Text = "--"
        '
        'L_TimeRemaining
        '
        Me.L_TimeRemaining.AutoSize = True
        Me.L_TimeRemaining.BackColor = System.Drawing.Color.White
        Me.L_TimeRemaining.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L_TimeRemaining.ForeColor = System.Drawing.Color.OrangeRed
        Me.L_TimeRemaining.Location = New System.Drawing.Point(163, 54)
        Me.L_TimeRemaining.Name = "L_TimeRemaining"
        Me.L_TimeRemaining.Size = New System.Drawing.Size(15, 15)
        Me.L_TimeRemaining.TabIndex = 111
        Me.L_TimeRemaining.Text = "--"
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
        Me.BT_TopBar.Location = New System.Drawing.Point(2, 1)
        Me.BT_TopBar.Name = "BT_TopBar"
        Me.BT_TopBar.Size = New System.Drawing.Size(310, 28)
        Me.BT_TopBar.TabIndex = 123
        Me.BT_TopBar.TabStop = False
        Me.BT_TopBar.Text = "          Alarm"
        Me.BT_TopBar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BT_TopBar.UseVisualStyleBackColor = False
        '
        'Form_Alarm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Silver
        Me.ClientSize = New System.Drawing.Size(337, 202)
        Me.Controls.Add(Me.L_Time)
        Me.Controls.Add(Me.L_TimeRemaining)
        Me.Controls.Add(Me.LAlarm)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Calloff_Button)
        Me.Controls.Add(Me.Button_Cancel)
        Me.Controls.Add(Me.Button_OK)
        Me.Controls.Add(Me.TB_TimeLeft)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.BT_Close)
        Me.Controls.Add(Me.PictureBox_Panda)
        Me.Controls.Add(Me.BT_TopBar)
        Me.Controls.Add(Me.Label2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form_Alarm"
        Me.Tag = "atester"
        Me.Text = "Alarm"
        Me.TopMost = True
        CType(Me.PictureBox_Panda, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BT_Close As System.Windows.Forms.Button
    Friend WithEvents PictureBox_Panda As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TB_TimeLeft As System.Windows.Forms.TextBox
    Friend WithEvents Button_Cancel As System.Windows.Forms.Button
    Friend WithEvents Button_OK As System.Windows.Forms.Button
    Friend WithEvents Calloff_Button As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents LAlarm As System.Windows.Forms.Label
    Friend WithEvents L_Time As System.Windows.Forms.Label
    Friend WithEvents L_TimeRemaining As System.Windows.Forms.Label
    Friend WithEvents BT_TopBar As System.Windows.Forms.Button
End Class
