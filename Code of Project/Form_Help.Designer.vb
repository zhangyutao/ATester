<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_Help
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_Help))
        Me.PictureBox_Help = New System.Windows.Forms.PictureBox()
        Me.Panel_Help = New System.Windows.Forms.Panel()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.BT_TopBar = New System.Windows.Forms.Button()
        Me.BT_Close = New System.Windows.Forms.Button()
        CType(Me.PictureBox_Help, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel_Help.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox_Help
        '
        Me.PictureBox_Help.BackColor = System.Drawing.Color.White
        Me.PictureBox_Help.Image = Global.ATester.My.Resources.Resources.helpdoc
        Me.PictureBox_Help.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox_Help.Name = "PictureBox_Help"
        Me.PictureBox_Help.Size = New System.Drawing.Size(728, 4724)
        Me.PictureBox_Help.TabIndex = 0
        Me.PictureBox_Help.TabStop = False
        '
        'Panel_Help
        '
        Me.Panel_Help.AutoScroll = True
        Me.Panel_Help.BackColor = System.Drawing.Color.White
        Me.Panel_Help.Controls.Add(Me.PictureBox_Help)
        Me.Panel_Help.Location = New System.Drawing.Point(1, 29)
        Me.Panel_Help.Name = "Panel_Help"
        Me.Panel_Help.Size = New System.Drawing.Size(749, 445)
        Me.Panel_Help.TabIndex = 1
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.White
        Me.PictureBox2.BackgroundImage = Global.ATester.My.Resources.Resources.zhuye
        Me.PictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PictureBox2.Location = New System.Drawing.Point(1, 1)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(28, 28)
        Me.PictureBox2.TabIndex = 143
        Me.PictureBox2.TabStop = False
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
        Me.BT_TopBar.Location = New System.Drawing.Point(30, 1)
        Me.BT_TopBar.Name = "BT_TopBar"
        Me.BT_TopBar.Size = New System.Drawing.Size(720, 28)
        Me.BT_TopBar.TabIndex = 144
        Me.BT_TopBar.TabStop = False
        Me.BT_TopBar.Text = "Help"
        Me.BT_TopBar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BT_TopBar.UseVisualStyleBackColor = False
        '
        'BT_Close
        '
        Me.BT_Close.BackColor = System.Drawing.Color.Transparent
        Me.BT_Close.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.BT_Close.FlatAppearance.BorderSize = 0
        Me.BT_Close.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red
        Me.BT_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BT_Close.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Bold)
        Me.BT_Close.ForeColor = System.Drawing.Color.Black
        Me.BT_Close.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.BT_Close.Location = New System.Drawing.Point(722, 2)
        Me.BT_Close.Name = "BT_Close"
        Me.BT_Close.Size = New System.Drawing.Size(26, 22)
        Me.BT_Close.TabIndex = 145
        Me.BT_Close.TabStop = False
        Me.BT_Close.Text = "X"
        Me.BT_Close.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BT_Close.UseVisualStyleBackColor = False
        '
        'Form_Help
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Silver
        Me.ClientSize = New System.Drawing.Size(751, 475)
        Me.Controls.Add(Me.BT_Close)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.BT_TopBar)
        Me.Controls.Add(Me.Panel_Help)
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form_Help"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Tag = "atester"
        Me.Text = "Help"
        CType(Me.PictureBox_Help, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel_Help.ResumeLayout(False)
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PictureBox_Help As System.Windows.Forms.PictureBox
    Friend WithEvents Panel_Help As System.Windows.Forms.Panel
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents BT_TopBar As System.Windows.Forms.Button
    Friend WithEvents BT_Close As System.Windows.Forms.Button
End Class
