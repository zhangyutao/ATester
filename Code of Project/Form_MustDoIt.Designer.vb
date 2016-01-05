<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_MustDoIt
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_MustDoIt))
        Me.TB_Notification = New System.Windows.Forms.TextBox()
        Me.Bt_Donot = New System.Windows.Forms.Button()
        Me.Bt_Configured = New System.Windows.Forms.Button()
        Me.Bt_StopRun = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Bt_Previous = New System.Windows.Forms.Button()
        Me.Bt_Cancel = New System.Windows.Forms.Button()
        Me.Bt_confirmed = New System.Windows.Forms.Button()
        Me.PictureBox_Panda = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BT_TopBar = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox_Panda, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TB_Notification
        '
        Me.TB_Notification.BackColor = System.Drawing.Color.White
        Me.TB_Notification.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TB_Notification.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.TB_Notification.ForeColor = System.Drawing.Color.Black
        Me.TB_Notification.Location = New System.Drawing.Point(2, 30)
        Me.TB_Notification.Multiline = True
        Me.TB_Notification.Name = "TB_Notification"
        Me.TB_Notification.ReadOnly = True
        Me.TB_Notification.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TB_Notification.Size = New System.Drawing.Size(390, 260)
        Me.TB_Notification.TabIndex = 92
        Me.TB_Notification.TabStop = False
        '
        'Bt_Donot
        '
        Me.Bt_Donot.BackColor = System.Drawing.Color.White
        Me.Bt_Donot.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.Bt_Donot.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray
        Me.Bt_Donot.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SteelBlue
        Me.Bt_Donot.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan
        Me.Bt_Donot.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Bt_Donot.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Bt_Donot.ForeColor = System.Drawing.Color.Black
        Me.Bt_Donot.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Bt_Donot.Location = New System.Drawing.Point(12, 3)
        Me.Bt_Donot.Name = "Bt_Donot"
        Me.Bt_Donot.Size = New System.Drawing.Size(92, 26)
        Me.Bt_Donot.TabIndex = 94
        Me.Bt_Donot.TabStop = False
        Me.Bt_Donot.Text = "I won't do it"
        Me.Bt_Donot.UseVisualStyleBackColor = False
        Me.Bt_Donot.Visible = False
        '
        'Bt_Configured
        '
        Me.Bt_Configured.BackColor = System.Drawing.Color.White
        Me.Bt_Configured.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.Bt_Configured.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray
        Me.Bt_Configured.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SteelBlue
        Me.Bt_Configured.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan
        Me.Bt_Configured.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Bt_Configured.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Bt_Configured.ForeColor = System.Drawing.Color.Black
        Me.Bt_Configured.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Bt_Configured.Location = New System.Drawing.Point(110, 3)
        Me.Bt_Configured.Name = "Bt_Configured"
        Me.Bt_Configured.Size = New System.Drawing.Size(124, 26)
        Me.Bt_Configured.TabIndex = 96
        Me.Bt_Configured.TabStop = False
        Me.Bt_Configured.Text = "I have configured it"
        Me.Bt_Configured.UseVisualStyleBackColor = False
        Me.Bt_Configured.Visible = False
        '
        'Bt_StopRun
        '
        Me.Bt_StopRun.BackColor = System.Drawing.Color.White
        Me.Bt_StopRun.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.Bt_StopRun.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray
        Me.Bt_StopRun.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SteelBlue
        Me.Bt_StopRun.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan
        Me.Bt_StopRun.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Bt_StopRun.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Bt_StopRun.ForeColor = System.Drawing.Color.Black
        Me.Bt_StopRun.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Bt_StopRun.Location = New System.Drawing.Point(257, 3)
        Me.Bt_StopRun.Name = "Bt_StopRun"
        Me.Bt_StopRun.Size = New System.Drawing.Size(124, 26)
        Me.Bt_StopRun.TabIndex = 98
        Me.Bt_StopRun.TabStop = False
        Me.Bt_StopRun.Text = "Stop current run"
        Me.Bt_StopRun.UseVisualStyleBackColor = False
        Me.Bt_StopRun.Visible = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BackgroundImage = Global.ATester.My.Resources.Resources.Mainback
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Controls.Add(Me.Bt_Previous)
        Me.Panel1.Controls.Add(Me.Bt_Cancel)
        Me.Panel1.Controls.Add(Me.Bt_Donot)
        Me.Panel1.Controls.Add(Me.Bt_confirmed)
        Me.Panel1.Controls.Add(Me.Bt_StopRun)
        Me.Panel1.Controls.Add(Me.Bt_Configured)
        Me.Panel1.Location = New System.Drawing.Point(1, 292)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(392, 37)
        Me.Panel1.TabIndex = 100
        '
        'Bt_Previous
        '
        Me.Bt_Previous.BackColor = System.Drawing.Color.White
        Me.Bt_Previous.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.Bt_Previous.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray
        Me.Bt_Previous.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SteelBlue
        Me.Bt_Previous.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan
        Me.Bt_Previous.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Bt_Previous.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Bt_Previous.ForeColor = System.Drawing.Color.Black
        Me.Bt_Previous.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Bt_Previous.Location = New System.Drawing.Point(12, 3)
        Me.Bt_Previous.Name = "Bt_Previous"
        Me.Bt_Previous.Size = New System.Drawing.Size(82, 26)
        Me.Bt_Previous.TabIndex = 101
        Me.Bt_Previous.TabStop = False
        Me.Bt_Previous.Text = "<<Previous"
        Me.Bt_Previous.UseVisualStyleBackColor = False
        Me.Bt_Previous.Visible = False
        '
        'Bt_Cancel
        '
        Me.Bt_Cancel.BackColor = System.Drawing.Color.White
        Me.Bt_Cancel.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.Bt_Cancel.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray
        Me.Bt_Cancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SteelBlue
        Me.Bt_Cancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red
        Me.Bt_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Bt_Cancel.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Bt_Cancel.ForeColor = System.Drawing.Color.Black
        Me.Bt_Cancel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Bt_Cancel.Location = New System.Drawing.Point(257, 3)
        Me.Bt_Cancel.Name = "Bt_Cancel"
        Me.Bt_Cancel.Size = New System.Drawing.Size(124, 26)
        Me.Bt_Cancel.TabIndex = 105
        Me.Bt_Cancel.TabStop = False
        Me.Bt_Cancel.Text = "Close"
        Me.Bt_Cancel.UseVisualStyleBackColor = False
        Me.Bt_Cancel.Visible = False
        '
        'Bt_confirmed
        '
        Me.Bt_confirmed.BackColor = System.Drawing.Color.White
        Me.Bt_confirmed.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.Bt_confirmed.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray
        Me.Bt_confirmed.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SteelBlue
        Me.Bt_confirmed.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan
        Me.Bt_confirmed.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Bt_confirmed.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Bt_confirmed.ForeColor = System.Drawing.Color.Black
        Me.Bt_confirmed.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Bt_confirmed.Location = New System.Drawing.Point(158, 3)
        Me.Bt_confirmed.Name = "Bt_confirmed"
        Me.Bt_confirmed.Size = New System.Drawing.Size(92, 26)
        Me.Bt_confirmed.TabIndex = 103
        Me.Bt_confirmed.TabStop = False
        Me.Bt_confirmed.Text = "Confirmed"
        Me.Bt_confirmed.UseVisualStyleBackColor = False
        Me.Bt_confirmed.Visible = False
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
        Me.PictureBox_Panda.TabIndex = 102
        Me.PictureBox_Panda.TabStop = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(1, 1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(392, 328)
        Me.Label1.TabIndex = 104
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
        Me.BT_TopBar.Size = New System.Drawing.Size(392, 28)
        Me.BT_TopBar.TabIndex = 147
        Me.BT_TopBar.TabStop = False
        Me.BT_TopBar.Text = "         Must Do It"
        Me.BT_TopBar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BT_TopBar.UseVisualStyleBackColor = False
        '
        'Form_MustDoIt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Silver
        Me.ClientSize = New System.Drawing.Size(394, 330)
        Me.Controls.Add(Me.PictureBox_Panda)
        Me.Controls.Add(Me.TB_Notification)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.BT_TopBar)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form_MustDoIt"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Tag = "atester"
        Me.Text = "Must Do It"
        Me.TopMost = True
        Me.Panel1.ResumeLayout(False)
        CType(Me.PictureBox_Panda, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TB_Notification As System.Windows.Forms.TextBox
    Friend WithEvents Bt_Donot As System.Windows.Forms.Button
    Friend WithEvents Bt_Configured As System.Windows.Forms.Button
    Friend WithEvents Bt_StopRun As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Bt_Previous As System.Windows.Forms.Button
    Friend WithEvents Bt_confirmed As System.Windows.Forms.Button
    Friend WithEvents Bt_Cancel As System.Windows.Forms.Button
    Friend WithEvents PictureBox_Panda As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BT_TopBar As System.Windows.Forms.Button
End Class
