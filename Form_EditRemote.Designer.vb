<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_EditRemote
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_EditRemote))
        Me.Bt_Remove = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Bt_New = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.L_Title = New System.Windows.Forms.Label()
        Me.Bt_close_editRemoteRes = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Bt_Save = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LB_Content = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.L_ST = New System.Windows.Forms.Label()
        Me.ToolTip_Format = New System.Windows.Forms.ToolTip(Me.components)
        Me.BT_TopBar = New System.Windows.Forms.Button()
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
        Me.Bt_Remove.Location = New System.Drawing.Point(123, 352)
        Me.Bt_Remove.Name = "Bt_Remove"
        Me.Bt_Remove.Size = New System.Drawing.Size(70, 26)
        Me.Bt_Remove.TabIndex = 136
        Me.Bt_Remove.TabStop = False
        Me.Bt_Remove.Text = "Remove"
        Me.Bt_Remove.UseVisualStyleBackColor = False
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Silver
        Me.Label7.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label7.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label7.Location = New System.Drawing.Point(121, 354)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(70, 26)
        Me.Label7.TabIndex = 137
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        Me.Bt_New.Location = New System.Drawing.Point(30, 352)
        Me.Bt_New.Name = "Bt_New"
        Me.Bt_New.Size = New System.Drawing.Size(70, 26)
        Me.Bt_New.TabIndex = 132
        Me.Bt_New.TabStop = False
        Me.Bt_New.Text = "Add"
        Me.Bt_New.UseVisualStyleBackColor = False
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Silver
        Me.Label6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label6.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label6.Location = New System.Drawing.Point(28, 354)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(70, 26)
        Me.Label6.TabIndex = 133
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'L_Title
        '
        Me.L_Title.BackColor = System.Drawing.Color.Transparent
        Me.L_Title.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.L_Title.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L_Title.ForeColor = System.Drawing.Color.Black
        Me.L_Title.Location = New System.Drawing.Point(30, 66)
        Me.L_Title.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.L_Title.Name = "L_Title"
        Me.L_Title.Size = New System.Drawing.Size(377, 24)
        Me.L_Title.TabIndex = 135
        Me.L_Title.Text = "Slave Test Resource Directory"
        Me.L_Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        Me.Bt_close_editRemoteRes.Location = New System.Drawing.Point(409, 0)
        Me.Bt_close_editRemoteRes.Name = "Bt_close_editRemoteRes"
        Me.Bt_close_editRemoteRes.Size = New System.Drawing.Size(26, 22)
        Me.Bt_close_editRemoteRes.TabIndex = 129
        Me.Bt_close_editRemoteRes.TabStop = False
        Me.Bt_close_editRemoteRes.Text = "X"
        Me.Bt_close_editRemoteRes.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Bt_close_editRemoteRes.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label3.Location = New System.Drawing.Point(2, 2)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(437, 388)
        Me.Label3.TabIndex = 128
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.White
        Me.PictureBox1.BackgroundImage = Global.ATester.My.Resources.Resources.zhuye
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PictureBox1.Location = New System.Drawing.Point(1, 1)
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
        Me.Bt_Save.Location = New System.Drawing.Point(350, 352)
        Me.Bt_Save.Name = "Bt_Save"
        Me.Bt_Save.Size = New System.Drawing.Size(57, 26)
        Me.Bt_Save.TabIndex = 138
        Me.Bt_Save.TabStop = False
        Me.Bt_Save.Text = "Save"
        Me.Bt_Save.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Silver
        Me.Label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(348, 354)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 26)
        Me.Label1.TabIndex = 139
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LB_Content
        '
        Me.LB_Content.AutoArrange = False
        Me.LB_Content.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.LB_Content.CheckBoxes = True
        Me.LB_Content.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
        Me.LB_Content.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.LB_Content.GridLines = True
        Me.LB_Content.LabelEdit = True
        Me.LB_Content.LabelWrap = False
        Me.LB_Content.Location = New System.Drawing.Point(30, 106)
        Me.LB_Content.MultiSelect = False
        Me.LB_Content.Name = "LB_Content"
        Me.LB_Content.Size = New System.Drawing.Size(377, 231)
        Me.LB_Content.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.LB_Content.TabIndex = 140
        Me.LB_Content.UseCompatibleStateImageBehavior = False
        Me.LB_Content.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Item"
        Me.ColumnHeader1.Width = 245
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Status"
        Me.ColumnHeader2.Width = 125
        '
        'L_ST
        '
        Me.L_ST.BackColor = System.Drawing.Color.Transparent
        Me.L_ST.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.L_ST.ForeColor = System.Drawing.Color.Red
        Me.L_ST.Location = New System.Drawing.Point(12, 30)
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
        Me.BT_TopBar.Size = New System.Drawing.Size(296, 28)
        Me.BT_TopBar.TabIndex = 142
        Me.BT_TopBar.TabStop = False
        Me.BT_TopBar.Text = "Edit"
        Me.BT_TopBar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BT_TopBar.UseVisualStyleBackColor = False
        '
        'Form_EditRemote
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Silver
        Me.BackgroundImage = Global.ATester.My.Resources.Resources.Mainback
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(439, 390)
        Me.Controls.Add(Me.L_ST)
        Me.Controls.Add(Me.LB_Content)
        Me.Controls.Add(Me.Bt_Save)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Bt_Remove)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Bt_New)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.L_Title)
        Me.Controls.Add(Me.Bt_close_editRemoteRes)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.BT_TopBar)
        Me.Controls.Add(Me.Label3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form_EditRemote"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Tag = "atester"
        Me.Text = "Form_Edit"
        Me.TopMost = True
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Bt_Remove As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Bt_New As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents L_Title As System.Windows.Forms.Label
    Friend WithEvents Bt_close_editRemoteRes As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Bt_Save As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LB_Content As System.Windows.Forms.ListView
    Friend WithEvents L_ST As System.Windows.Forms.Label
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ToolTip_Format As System.Windows.Forms.ToolTip
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents BT_TopBar As System.Windows.Forms.Button
End Class
