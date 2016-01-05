<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_CheckSlave
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_CheckSlave))
        Me.ListView_RSlaveSt = New System.Windows.Forms.ListView()
        Me.CB = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.IP = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Status = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TimeConsuming = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TB_IP = New System.Windows.Forms.TextBox()
        Me.Panel_ConentUpdate = New System.Windows.Forms.Panel()
        Me.Bt_Cancel = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Bt_updateContent = New System.Windows.Forms.Button()
        Me.L_Bt_updateCoent = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.L_back = New System.Windows.Forms.Label()
        Me.Bt_Connect = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Bt_CloseRDCF = New System.Windows.Forms.Button()
        Me.Bt_Delete = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Bt_StopChecking = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Panel_checkconbutton = New System.Windows.Forms.Panel()
        Me.Panel_table = New System.Windows.Forms.Panel()
        Me.Panel_topbar = New System.Windows.Forms.Panel()
        Me.PictureBox_Panda = New System.Windows.Forms.PictureBox()
        Me.BT_TopBar = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel_ConentUpdate.SuspendLayout()
        Me.Panel_checkconbutton.SuspendLayout()
        Me.Panel_table.SuspendLayout()
        Me.Panel_topbar.SuspendLayout()
        CType(Me.PictureBox_Panda, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ListView_RSlaveSt
        '
        Me.ListView_RSlaveSt.AutoArrange = False
        Me.ListView_RSlaveSt.BackColor = System.Drawing.Color.White
        Me.ListView_RSlaveSt.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ListView_RSlaveSt.CheckBoxes = True
        Me.ListView_RSlaveSt.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.CB, Me.IP, Me.Status, Me.TimeConsuming})
        Me.ListView_RSlaveSt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListView_RSlaveSt.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListView_RSlaveSt.ForeColor = System.Drawing.Color.Black
        Me.ListView_RSlaveSt.FullRowSelect = True
        Me.ListView_RSlaveSt.GridLines = True
        Me.ListView_RSlaveSt.LabelWrap = False
        Me.ListView_RSlaveSt.Location = New System.Drawing.Point(0, 0)
        Me.ListView_RSlaveSt.Margin = New System.Windows.Forms.Padding(2)
        Me.ListView_RSlaveSt.MultiSelect = False
        Me.ListView_RSlaveSt.Name = "ListView_RSlaveSt"
        Me.ListView_RSlaveSt.ShowGroups = False
        Me.ListView_RSlaveSt.ShowItemToolTips = True
        Me.ListView_RSlaveSt.Size = New System.Drawing.Size(595, 325)
        Me.ListView_RSlaveSt.TabIndex = 1
        Me.ListView_RSlaveSt.UseCompatibleStateImageBehavior = False
        Me.ListView_RSlaveSt.View = System.Windows.Forms.View.Details
        '
        'CB
        '
        Me.CB.Text = "  √"
        Me.CB.Width = 37
        '
        'IP
        '
        Me.IP.Text = "IP or Server Name"
        Me.IP.Width = 238
        '
        'Status
        '
        Me.Status.Text = "Status"
        Me.Status.Width = 163
        '
        'TimeConsuming
        '
        Me.TimeConsuming.Text = "Time-consuming(s)"
        Me.TimeConsuming.Width = 122
        '
        'TB_IP
        '
        Me.TB_IP.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TB_IP.Font = New System.Drawing.Font("Calibri", 11.0!)
        Me.TB_IP.Location = New System.Drawing.Point(43, 56)
        Me.TB_IP.Name = "TB_IP"
        Me.TB_IP.Size = New System.Drawing.Size(505, 18)
        Me.TB_IP.TabIndex = 2
        '
        'Panel_ConentUpdate
        '
        Me.Panel_ConentUpdate.BackColor = System.Drawing.Color.Honeydew
        Me.Panel_ConentUpdate.Controls.Add(Me.Bt_Cancel)
        Me.Panel_ConentUpdate.Controls.Add(Me.Label7)
        Me.Panel_ConentUpdate.Controls.Add(Me.Bt_updateContent)
        Me.Panel_ConentUpdate.Controls.Add(Me.TB_IP)
        Me.Panel_ConentUpdate.Controls.Add(Me.L_Bt_updateCoent)
        Me.Panel_ConentUpdate.Controls.Add(Me.Label4)
        Me.Panel_ConentUpdate.Location = New System.Drawing.Point(1, 26)
        Me.Panel_ConentUpdate.Name = "Panel_ConentUpdate"
        Me.Panel_ConentUpdate.Size = New System.Drawing.Size(596, 125)
        Me.Panel_ConentUpdate.TabIndex = 3
        Me.Panel_ConentUpdate.Visible = False
        '
        'Bt_Cancel
        '
        Me.Bt_Cancel.BackColor = System.Drawing.Color.White
        Me.Bt_Cancel.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray
        Me.Bt_Cancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Aqua
        Me.Bt_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Bt_Cancel.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Bt_Cancel.ForeColor = System.Drawing.Color.Black
        Me.Bt_Cancel.Location = New System.Drawing.Point(327, 83)
        Me.Bt_Cancel.Name = "Bt_Cancel"
        Me.Bt_Cancel.Size = New System.Drawing.Size(61, 26)
        Me.Bt_Cancel.TabIndex = 10
        Me.Bt_Cancel.TabStop = False
        Me.Bt_Cancel.Text = "Cancel"
        Me.Bt_Cancel.UseVisualStyleBackColor = False
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Silver
        Me.Label7.Location = New System.Drawing.Point(325, 85)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(61, 26)
        Me.Label7.TabIndex = 11
        '
        'Bt_updateContent
        '
        Me.Bt_updateContent.BackColor = System.Drawing.Color.White
        Me.Bt_updateContent.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray
        Me.Bt_updateContent.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Aqua
        Me.Bt_updateContent.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Bt_updateContent.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Bt_updateContent.ForeColor = System.Drawing.Color.Black
        Me.Bt_updateContent.Location = New System.Drawing.Point(218, 83)
        Me.Bt_updateContent.Name = "Bt_updateContent"
        Me.Bt_updateContent.Size = New System.Drawing.Size(61, 26)
        Me.Bt_updateContent.TabIndex = 3
        Me.Bt_updateContent.TabStop = False
        Me.Bt_updateContent.Text = "Update"
        Me.Bt_updateContent.UseVisualStyleBackColor = False
        '
        'L_Bt_updateCoent
        '
        Me.L_Bt_updateCoent.BackColor = System.Drawing.Color.Silver
        Me.L_Bt_updateCoent.Location = New System.Drawing.Point(216, 85)
        Me.L_Bt_updateCoent.Name = "L_Bt_updateCoent"
        Me.L_Bt_updateCoent.Size = New System.Drawing.Size(61, 26)
        Me.L_Bt_updateCoent.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(228, 26)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(153, 25)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Enter IP or Server Name"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'L_back
        '
        Me.L_back.Location = New System.Drawing.Point(0, 0)
        Me.L_back.Name = "L_back"
        Me.L_back.Size = New System.Drawing.Size(594, 71)
        Me.L_back.TabIndex = 4
        '
        'Bt_Connect
        '
        Me.Bt_Connect.BackColor = System.Drawing.Color.White
        Me.Bt_Connect.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray
        Me.Bt_Connect.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Aqua
        Me.Bt_Connect.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Bt_Connect.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Bt_Connect.ForeColor = System.Drawing.Color.Black
        Me.Bt_Connect.Location = New System.Drawing.Point(218, 32)
        Me.Bt_Connect.Name = "Bt_Connect"
        Me.Bt_Connect.Size = New System.Drawing.Size(127, 26)
        Me.Bt_Connect.TabIndex = 5
        Me.Bt_Connect.Text = "Check Connection"
        Me.Bt_Connect.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Silver
        Me.Label1.Location = New System.Drawing.Point(216, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(128, 26)
        Me.Label1.TabIndex = 6
        '
        'Bt_CloseRDCF
        '
        Me.Bt_CloseRDCF.BackColor = System.Drawing.Color.Transparent
        Me.Bt_CloseRDCF.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.Bt_CloseRDCF.FlatAppearance.BorderSize = 0
        Me.Bt_CloseRDCF.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red
        Me.Bt_CloseRDCF.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Bt_CloseRDCF.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Bold)
        Me.Bt_CloseRDCF.ForeColor = System.Drawing.Color.Black
        Me.Bt_CloseRDCF.Location = New System.Drawing.Point(562, 0)
        Me.Bt_CloseRDCF.Margin = New System.Windows.Forms.Padding(2)
        Me.Bt_CloseRDCF.Name = "Bt_CloseRDCF"
        Me.Bt_CloseRDCF.Size = New System.Drawing.Size(29, 22)
        Me.Bt_CloseRDCF.TabIndex = 7
        Me.Bt_CloseRDCF.TabStop = False
        Me.Bt_CloseRDCF.Text = "X"
        Me.Bt_CloseRDCF.UseVisualStyleBackColor = False
        '
        'Bt_Delete
        '
        Me.Bt_Delete.BackColor = System.Drawing.Color.White
        Me.Bt_Delete.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray
        Me.Bt_Delete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Aqua
        Me.Bt_Delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Bt_Delete.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Bt_Delete.ForeColor = System.Drawing.Color.Black
        Me.Bt_Delete.Location = New System.Drawing.Point(12, 32)
        Me.Bt_Delete.Name = "Bt_Delete"
        Me.Bt_Delete.Size = New System.Drawing.Size(53, 26)
        Me.Bt_Delete.TabIndex = 8
        Me.Bt_Delete.Text = "Delete"
        Me.Bt_Delete.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Silver
        Me.Label2.Location = New System.Drawing.Point(10, 34)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 26)
        Me.Label2.TabIndex = 9
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Silver
        Me.Label3.Location = New System.Drawing.Point(359, 34)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(101, 26)
        Me.Label3.TabIndex = 11
        '
        'Bt_StopChecking
        '
        Me.Bt_StopChecking.BackColor = System.Drawing.Color.White
        Me.Bt_StopChecking.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray
        Me.Bt_StopChecking.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Aqua
        Me.Bt_StopChecking.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Bt_StopChecking.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Bt_StopChecking.ForeColor = System.Drawing.Color.Black
        Me.Bt_StopChecking.Location = New System.Drawing.Point(361, 32)
        Me.Bt_StopChecking.Name = "Bt_StopChecking"
        Me.Bt_StopChecking.Size = New System.Drawing.Size(100, 26)
        Me.Bt_StopChecking.TabIndex = 10
        Me.Bt_StopChecking.Text = "Stop Checking"
        Me.Bt_StopChecking.UseVisualStyleBackColor = False
        '
        'Panel_checkconbutton
        '
        Me.Panel_checkconbutton.BackColor = System.Drawing.Color.Honeydew
        Me.Panel_checkconbutton.Controls.Add(Me.Bt_StopChecking)
        Me.Panel_checkconbutton.Controls.Add(Me.Label3)
        Me.Panel_checkconbutton.Controls.Add(Me.Bt_Delete)
        Me.Panel_checkconbutton.Controls.Add(Me.Bt_Connect)
        Me.Panel_checkconbutton.Controls.Add(Me.Label1)
        Me.Panel_checkconbutton.Controls.Add(Me.Label2)
        Me.Panel_checkconbutton.Controls.Add(Me.L_back)
        Me.Panel_checkconbutton.Location = New System.Drawing.Point(1, 26)
        Me.Panel_checkconbutton.Name = "Panel_checkconbutton"
        Me.Panel_checkconbutton.Size = New System.Drawing.Size(595, 71)
        Me.Panel_checkconbutton.TabIndex = 12
        '
        'Panel_table
        '
        Me.Panel_table.AutoScroll = True
        Me.Panel_table.BackColor = System.Drawing.Color.White
        Me.Panel_table.Controls.Add(Me.ListView_RSlaveSt)
        Me.Panel_table.Location = New System.Drawing.Point(1, 72)
        Me.Panel_table.Name = "Panel_table"
        Me.Panel_table.Size = New System.Drawing.Size(595, 325)
        Me.Panel_table.TabIndex = 13
        '
        'Panel_topbar
        '
        Me.Panel_topbar.BackColor = System.Drawing.Color.White
        Me.Panel_topbar.Controls.Add(Me.Bt_CloseRDCF)
        Me.Panel_topbar.Controls.Add(Me.PictureBox_Panda)
        Me.Panel_topbar.Controls.Add(Me.BT_TopBar)
        Me.Panel_topbar.Location = New System.Drawing.Point(1, 1)
        Me.Panel_topbar.Name = "Panel_topbar"
        Me.Panel_topbar.Size = New System.Drawing.Size(595, 28)
        Me.Panel_topbar.TabIndex = 14
        '
        'PictureBox_Panda
        '
        Me.PictureBox_Panda.BackColor = System.Drawing.Color.White
        Me.PictureBox_Panda.BackgroundImage = Global.ATester.My.Resources.Resources.zhuye
        Me.PictureBox_Panda.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox_Panda.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PictureBox_Panda.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox_Panda.Name = "PictureBox_Panda"
        Me.PictureBox_Panda.Size = New System.Drawing.Size(28, 28)
        Me.PictureBox_Panda.TabIndex = 98
        Me.PictureBox_Panda.TabStop = False
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
        Me.BT_TopBar.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.BT_TopBar.ForeColor = System.Drawing.Color.DarkGreen
        Me.BT_TopBar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.BT_TopBar.Location = New System.Drawing.Point(0, 0)
        Me.BT_TopBar.Name = "BT_TopBar"
        Me.BT_TopBar.Size = New System.Drawing.Size(310, 28)
        Me.BT_TopBar.TabIndex = 124
        Me.BT_TopBar.TabStop = False
        Me.BT_TopBar.Text = "           Check Remote Slave Status"
        Me.BT_TopBar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BT_TopBar.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(1, 1)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(595, 396)
        Me.Label5.TabIndex = 15
        '
        'Form_CheckSlave
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Silver
        Me.ClientSize = New System.Drawing.Size(597, 398)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel_ConentUpdate)
        Me.Controls.Add(Me.Panel_topbar)
        Me.Controls.Add(Me.Panel_table)
        Me.Controls.Add(Me.Panel_checkconbutton)
        Me.Controls.Add(Me.Label5)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form_CheckSlave"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Tag = "atester"
        Me.Text = "Check Remote Slave Status"
        Me.Panel_ConentUpdate.ResumeLayout(False)
        Me.Panel_ConentUpdate.PerformLayout()
        Me.Panel_checkconbutton.ResumeLayout(False)
        Me.Panel_table.ResumeLayout(False)
        Me.Panel_topbar.ResumeLayout(False)
        CType(Me.PictureBox_Panda, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ListView_RSlaveSt As System.Windows.Forms.ListView
    Friend WithEvents IP As System.Windows.Forms.ColumnHeader
    Friend WithEvents CB As System.Windows.Forms.ColumnHeader
    Friend WithEvents Status As System.Windows.Forms.ColumnHeader
    Friend WithEvents TB_IP As System.Windows.Forms.TextBox
    Friend WithEvents Panel_ConentUpdate As System.Windows.Forms.Panel
    Friend WithEvents Bt_updateContent As System.Windows.Forms.Button
    Friend WithEvents L_Bt_updateCoent As System.Windows.Forms.Label
    Friend WithEvents L_back As System.Windows.Forms.Label
    Friend WithEvents Bt_Connect As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Bt_CloseRDCF As System.Windows.Forms.Button
    Friend WithEvents Bt_Delete As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Bt_StopChecking As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Bt_Cancel As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents TimeConsuming As System.Windows.Forms.ColumnHeader
    Friend WithEvents Panel_checkconbutton As System.Windows.Forms.Panel
    Friend WithEvents Panel_table As System.Windows.Forms.Panel
    Friend WithEvents Panel_topbar As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents PictureBox_Panda As System.Windows.Forms.PictureBox
    Friend WithEvents BT_TopBar As System.Windows.Forms.Button
End Class
