<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_Module
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_Module))
        Me.Bt_Remove = New System.Windows.Forms.Button()
        Me.Bt_New = New System.Windows.Forms.Button()
        Me.Bt_close_editRemoteRes = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Bt_Save = New System.Windows.Forms.Button()
        Me.L_ST = New System.Windows.Forms.Label()
        Me.ToolTip_Format = New System.Windows.Forms.ToolTip(Me.components)
        Me.BT_TopBar = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.objLV = New System.Windows.Forms.ListView()
        Me.ckbH = New System.Windows.Forms.CheckBox()
        Me.ckbM = New System.Windows.Forms.CheckBox()
        Me.ckbL = New System.Windows.Forms.CheckBox()
        Me.lbCount = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Bt_Remove
        '
        Me.Bt_Remove.BackColor = System.Drawing.Color.White
        Me.Bt_Remove.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.Bt_Remove.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.Bt_Remove.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SteelBlue
        Me.Bt_Remove.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan
        Me.Bt_Remove.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Bt_Remove.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Bt_Remove.ForeColor = System.Drawing.Color.Black
        Me.Bt_Remove.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Bt_Remove.Location = New System.Drawing.Point(322, 352)
        Me.Bt_Remove.Name = "Bt_Remove"
        Me.Bt_Remove.Size = New System.Drawing.Size(59, 26)
        Me.Bt_Remove.TabIndex = 136
        Me.Bt_Remove.TabStop = False
        Me.Bt_Remove.Text = "Cancel"
        Me.Bt_Remove.UseVisualStyleBackColor = False
        '
        'Bt_New
        '
        Me.Bt_New.BackColor = System.Drawing.Color.White
        Me.Bt_New.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.Bt_New.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.Bt_New.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SteelBlue
        Me.Bt_New.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan
        Me.Bt_New.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Bt_New.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Bt_New.ForeColor = System.Drawing.Color.Black
        Me.Bt_New.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Bt_New.Location = New System.Drawing.Point(140, 317)
        Me.Bt_New.Name = "Bt_New"
        Me.Bt_New.Size = New System.Drawing.Size(84, 26)
        Me.Bt_New.TabIndex = 132
        Me.Bt_New.TabStop = False
        Me.Bt_New.Text = "Reset"
        Me.Bt_New.UseVisualStyleBackColor = False
        '
        'Bt_close_editRemoteRes
        '
        Me.Bt_close_editRemoteRes.BackColor = System.Drawing.Color.Transparent
        Me.Bt_close_editRemoteRes.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.Bt_close_editRemoteRes.FlatAppearance.BorderSize = 0
        Me.Bt_close_editRemoteRes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red
        Me.Bt_close_editRemoteRes.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Bt_close_editRemoteRes.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Bold)
        Me.Bt_close_editRemoteRes.ForeColor = System.Drawing.Color.Black
        Me.Bt_close_editRemoteRes.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Bt_close_editRemoteRes.Location = New System.Drawing.Point(421, 0)
        Me.Bt_close_editRemoteRes.Name = "Bt_close_editRemoteRes"
        Me.Bt_close_editRemoteRes.Size = New System.Drawing.Size(26, 22)
        Me.Bt_close_editRemoteRes.TabIndex = 129
        Me.Bt_close_editRemoteRes.TabStop = False
        Me.Bt_close_editRemoteRes.Text = "X"
        Me.Bt_close_editRemoteRes.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Bt_close_editRemoteRes.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.White
        Me.PictureBox1.BackgroundImage = Global.ATester.My.Resources.Resources.zhuye
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PictureBox1.Location = New System.Drawing.Point(13, 1)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(28, 28)
        Me.PictureBox1.TabIndex = 130
        Me.PictureBox1.TabStop = False
        '
        'Bt_Save
        '
        Me.Bt_Save.BackColor = System.Drawing.Color.White
        Me.Bt_Save.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.Bt_Save.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.Bt_Save.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SteelBlue
        Me.Bt_Save.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan
        Me.Bt_Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Bt_Save.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Bt_Save.ForeColor = System.Drawing.Color.Black
        Me.Bt_Save.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Bt_Save.Location = New System.Drawing.Point(248, 352)
        Me.Bt_Save.Name = "Bt_Save"
        Me.Bt_Save.Size = New System.Drawing.Size(57, 26)
        Me.Bt_Save.TabIndex = 138
        Me.Bt_Save.TabStop = False
        Me.Bt_Save.Text = "OK"
        Me.Bt_Save.UseVisualStyleBackColor = False
        '
        'L_ST
        '
        Me.L_ST.BackColor = System.Drawing.Color.Transparent
        Me.L_ST.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.L_ST.ForeColor = System.Drawing.Color.Red
        Me.L_ST.Location = New System.Drawing.Point(24, 30)
        Me.L_ST.Name = "L_ST"
        Me.L_ST.Size = New System.Drawing.Size(315, 33)
        Me.L_ST.TabIndex = 141
        Me.L_ST.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.L_ST.Visible = False
        '
        'ToolTip_Format
        '
        Me.ToolTip_Format.AutomaticDelay = 200
        '
        'BT_TopBar
        '
        Me.BT_TopBar.AllowDrop = True
        Me.BT_TopBar.BackColor = System.Drawing.Color.White
        Me.BT_TopBar.BackgroundImage = Global.ATester.My.Resources.Resources.title
        Me.BT_TopBar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BT_TopBar.Cursor = System.Windows.Forms.Cursors.SizeAll
        Me.BT_TopBar.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.BT_TopBar.FlatAppearance.BorderSize = 0
        Me.BT_TopBar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SteelBlue
        Me.BT_TopBar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan
        Me.BT_TopBar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BT_TopBar.Font = New System.Drawing.Font("Calibri", 11.0!)
        Me.BT_TopBar.ForeColor = System.Drawing.Color.DarkGreen
        Me.BT_TopBar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.BT_TopBar.Location = New System.Drawing.Point(42, 1)
        Me.BT_TopBar.Name = "BT_TopBar"
        Me.BT_TopBar.Size = New System.Drawing.Size(373, 28)
        Me.BT_TopBar.TabIndex = 142
        Me.BT_TopBar.TabStop = False
        Me.BT_TopBar.Text = "Select Module"
        Me.BT_TopBar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BT_TopBar.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Transparent
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button1.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SteelBlue
        Me.Button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.Black
        Me.Button1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button1.Location = New System.Drawing.Point(51, 46)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(182, 28)
        Me.Button1.TabIndex = 144
        Me.Button1.TabStop = False
        Me.Button1.Text = "Module and Priority:"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.White
        Me.Button4.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.Button4.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.Button4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SteelBlue
        Me.Button4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Button4.ForeColor = System.Drawing.Color.Black
        Me.Button4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button4.Location = New System.Drawing.Point(55, 317)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(79, 26)
        Me.Button4.TabIndex = 151
        Me.Button4.TabStop = False
        Me.Button4.Text = "Select All"
        Me.Button4.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label3.Location = New System.Drawing.Point(-3, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(439, 391)
        Me.Label3.TabIndex = 128
        '
        'objLV
        '
        Me.objLV.Location = New System.Drawing.Point(55, 98)
        Me.objLV.Name = "objLV"
        Me.objLV.Size = New System.Drawing.Size(121, 97)
        Me.objLV.TabIndex = 152
        Me.objLV.UseCompatibleStateImageBehavior = False
        '
        'ckbH
        '
        Me.ckbH.AutoSize = True
        Me.ckbH.Location = New System.Drawing.Point(209, 77)
        Me.ckbH.Name = "ckbH"
        Me.ckbH.Size = New System.Drawing.Size(15, 14)
        Me.ckbH.TabIndex = 153
        Me.ckbH.UseVisualStyleBackColor = True
        '
        'ckbM
        '
        Me.ckbM.AutoSize = True
        Me.ckbM.Location = New System.Drawing.Point(271, 77)
        Me.ckbM.Name = "ckbM"
        Me.ckbM.Size = New System.Drawing.Size(15, 14)
        Me.ckbM.TabIndex = 153
        Me.ckbM.UseVisualStyleBackColor = True
        '
        'ckbL
        '
        Me.ckbL.AutoSize = True
        Me.ckbL.Location = New System.Drawing.Point(333, 77)
        Me.ckbL.Name = "ckbL"
        Me.ckbL.Size = New System.Drawing.Size(15, 14)
        Me.ckbL.TabIndex = 153
        Me.ckbL.UseVisualStyleBackColor = True
        '
        'lbCount
        '
        Me.lbCount.AutoSize = True
        Me.lbCount.Location = New System.Drawing.Point(95, 77)
        Me.lbCount.Name = "lbCount"
        Me.lbCount.Size = New System.Drawing.Size(0, 13)
        Me.lbCount.TabIndex = 154
        '
        'Form_Module
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Silver
        Me.BackgroundImage = Global.ATester.My.Resources.Resources.Mainback
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(439, 390)
        Me.Controls.Add(Me.lbCount)
        Me.Controls.Add(Me.ckbL)
        Me.Controls.Add(Me.ckbM)
        Me.Controls.Add(Me.ckbH)
        Me.Controls.Add(Me.objLV)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.L_ST)
        Me.Controls.Add(Me.Bt_Save)
        Me.Controls.Add(Me.Bt_Remove)
        Me.Controls.Add(Me.Bt_New)
        Me.Controls.Add(Me.Bt_close_editRemoteRes)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.BT_TopBar)
        Me.Controls.Add(Me.Label3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form_Module"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Tag = "atester"
        Me.Text = "Form_Edit"
        Me.TopMost = True
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Bt_Remove As System.Windows.Forms.Button
    Friend WithEvents Bt_New As System.Windows.Forms.Button
    Friend WithEvents Bt_close_editRemoteRes As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Bt_Save As System.Windows.Forms.Button
    Friend WithEvents L_ST As System.Windows.Forms.Label
    Friend WithEvents ToolTip_Format As System.Windows.Forms.ToolTip
    Friend WithEvents BT_TopBar As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents objLV As System.Windows.Forms.ListView
    Friend WithEvents ckbH As System.Windows.Forms.CheckBox
    Friend WithEvents ckbM As System.Windows.Forms.CheckBox
    Friend WithEvents ckbL As System.Windows.Forms.CheckBox
    Friend WithEvents lbCount As System.Windows.Forms.Label
End Class
