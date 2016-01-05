<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Dialog
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Dialog))
        Me.Button_Yes = New System.Windows.Forms.Button()
        Me.Panel_bottom = New System.Windows.Forms.Panel()
        Me.Button_No = New System.Windows.Forms.Button()
        Me.Button_OK = New System.Windows.Forms.Button()
        Me.BT_Close = New System.Windows.Forms.Button()
        Me.PictureBox_Panda = New System.Windows.Forms.PictureBox()
        Me.BT_TopBar = New System.Windows.Forms.Button()
        Me.TB_Content = New System.Windows.Forms.TextBox()
        Me.L_Back = New System.Windows.Forms.Button()
        Me.Panel_bottom.SuspendLayout()
        CType(Me.PictureBox_Panda, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button_Yes
        '
        Me.Button_Yes.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Button_Yes.AutoSize = True
        Me.Button_Yes.BackColor = System.Drawing.Color.White
        Me.Button_Yes.DialogResult = System.Windows.Forms.DialogResult.Yes
        Me.Button_Yes.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray
        Me.Button_Yes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SteelBlue
        Me.Button_Yes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan
        Me.Button_Yes.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Yes.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Button_Yes.ForeColor = System.Drawing.Color.DarkGreen
        Me.Button_Yes.Location = New System.Drawing.Point(52, 4)
        Me.Button_Yes.Name = "Button_Yes"
        Me.Button_Yes.Size = New System.Drawing.Size(78, 27)
        Me.Button_Yes.TabIndex = 1
        Me.Button_Yes.TabStop = False
        Me.Button_Yes.Text = "Yes"
        Me.Button_Yes.UseVisualStyleBackColor = False
        Me.Button_Yes.Visible = False
        '
        'Panel_bottom
        '
        Me.Panel_bottom.BackColor = System.Drawing.Color.White
        Me.Panel_bottom.Controls.Add(Me.Button_No)
        Me.Panel_bottom.Controls.Add(Me.Button_Yes)
        Me.Panel_bottom.Controls.Add(Me.Button_OK)
        Me.Panel_bottom.Location = New System.Drawing.Point(12, 209)
        Me.Panel_bottom.Name = "Panel_bottom"
        Me.Panel_bottom.Size = New System.Drawing.Size(328, 38)
        Me.Panel_bottom.TabIndex = 3
        '
        'Button_No
        '
        Me.Button_No.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Button_No.AutoSize = True
        Me.Button_No.BackColor = System.Drawing.Color.White
        Me.Button_No.DialogResult = System.Windows.Forms.DialogResult.No
        Me.Button_No.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray
        Me.Button_No.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SteelBlue
        Me.Button_No.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan
        Me.Button_No.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_No.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Button_No.ForeColor = System.Drawing.Color.DarkGreen
        Me.Button_No.Location = New System.Drawing.Point(194, 4)
        Me.Button_No.Name = "Button_No"
        Me.Button_No.Size = New System.Drawing.Size(78, 27)
        Me.Button_No.TabIndex = 1
        Me.Button_No.TabStop = False
        Me.Button_No.Text = "No"
        Me.Button_No.UseVisualStyleBackColor = False
        Me.Button_No.Visible = False
        '
        'Button_OK
        '
        Me.Button_OK.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Button_OK.AutoSize = True
        Me.Button_OK.BackColor = System.Drawing.Color.White
        Me.Button_OK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Button_OK.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray
        Me.Button_OK.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SteelBlue
        Me.Button_OK.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan
        Me.Button_OK.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_OK.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Button_OK.ForeColor = System.Drawing.Color.DarkGreen
        Me.Button_OK.Location = New System.Drawing.Point(122, 4)
        Me.Button_OK.Name = "Button_OK"
        Me.Button_OK.Size = New System.Drawing.Size(78, 27)
        Me.Button_OK.TabIndex = 2
        Me.Button_OK.TabStop = False
        Me.Button_OK.Text = "OK"
        Me.Button_OK.UseVisualStyleBackColor = False
        Me.Button_OK.Visible = False
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
        Me.BT_Close.Location = New System.Drawing.Point(327, 1)
        Me.BT_Close.Name = "BT_Close"
        Me.BT_Close.Size = New System.Drawing.Size(26, 22)
        Me.BT_Close.TabIndex = 37
        Me.BT_Close.TabStop = False
        Me.BT_Close.Text = "X"
        Me.BT_Close.UseVisualStyleBackColor = False
        '
        'PictureBox_Panda
        '
        Me.PictureBox_Panda.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox_Panda.BackgroundImage = Global.ATester.My.Resources.Resources.zhuye
        Me.PictureBox_Panda.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox_Panda.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PictureBox_Panda.Location = New System.Drawing.Point(1, 1)
        Me.PictureBox_Panda.Name = "PictureBox_Panda"
        Me.PictureBox_Panda.Size = New System.Drawing.Size(28, 28)
        Me.PictureBox_Panda.TabIndex = 94
        Me.PictureBox_Panda.TabStop = False
        '
        'BT_TopBar
        '
        Me.BT_TopBar.BackColor = System.Drawing.Color.White
        Me.BT_TopBar.BackgroundImage = Global.ATester.My.Resources.Resources.MsgboxTitle
        Me.BT_TopBar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BT_TopBar.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.BT_TopBar.FlatAppearance.BorderSize = 0
        Me.BT_TopBar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SteelBlue
        Me.BT_TopBar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan
        Me.BT_TopBar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BT_TopBar.Font = New System.Drawing.Font("Calibri", 11.0!)
        Me.BT_TopBar.ForeColor = System.Drawing.Color.DarkGreen
        Me.BT_TopBar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.BT_TopBar.Location = New System.Drawing.Point(29, 1)
        Me.BT_TopBar.Name = "BT_TopBar"
        Me.BT_TopBar.Size = New System.Drawing.Size(326, 28)
        Me.BT_TopBar.TabIndex = 122
        Me.BT_TopBar.TabStop = False
        Me.BT_TopBar.Text = "Message"
        Me.BT_TopBar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BT_TopBar.UseVisualStyleBackColor = False
        '
        'TB_Content
        '
        Me.TB_Content.BackColor = System.Drawing.Color.White
        Me.TB_Content.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TB_Content.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TB_Content.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TB_Content.ForeColor = System.Drawing.Color.DarkGreen
        Me.TB_Content.Location = New System.Drawing.Point(37, 52)
        Me.TB_Content.Multiline = True
        Me.TB_Content.Name = "TB_Content"
        Me.TB_Content.ReadOnly = True
        Me.TB_Content.Size = New System.Drawing.Size(287, 151)
        Me.TB_Content.TabIndex = 7
        Me.TB_Content.TabStop = False
        '
        'L_Back
        '
        Me.L_Back.BackColor = System.Drawing.Color.White
        Me.L_Back.Enabled = False
        Me.L_Back.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.L_Back.FlatAppearance.BorderSize = 0
        Me.L_Back.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.L_Back.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.L_Back.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.L_Back.Location = New System.Drawing.Point(1, 1)
        Me.L_Back.Name = "L_Back"
        Me.L_Back.Size = New System.Drawing.Size(354, 257)
        Me.L_Back.TabIndex = 8
        Me.L_Back.UseVisualStyleBackColor = False
        '
        'Dialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Yellow
        Me.CancelButton = Me.Button_No
        Me.ClientSize = New System.Drawing.Size(356, 259)
        Me.Controls.Add(Me.BT_Close)
        Me.Controls.Add(Me.PictureBox_Panda)
        Me.Controls.Add(Me.BT_TopBar)
        Me.Controls.Add(Me.Panel_bottom)
        Me.Controls.Add(Me.TB_Content)
        Me.Controls.Add(Me.L_Back)
        Me.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Dialog"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Tag = "atester"
        Me.Text = "Message"
        Me.TopMost = True
        Me.Panel_bottom.ResumeLayout(False)
        Me.Panel_bottom.PerformLayout()
        CType(Me.PictureBox_Panda, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button_Yes As System.Windows.Forms.Button
    Friend WithEvents Panel_bottom As System.Windows.Forms.Panel
    Friend WithEvents Button_No As System.Windows.Forms.Button
    Friend WithEvents Button_OK As System.Windows.Forms.Button
    Friend WithEvents PictureBox_Panda As System.Windows.Forms.PictureBox
    Friend WithEvents BT_Close As System.Windows.Forms.Button
    Friend WithEvents TB_Content As System.Windows.Forms.TextBox
    Friend WithEvents BT_TopBar As System.Windows.Forms.Button
    Friend WithEvents L_Back As System.Windows.Forms.Button

End Class
