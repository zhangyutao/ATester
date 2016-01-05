<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_RealTimeResult
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_RealTimeResult))
        Me.ListView_RTR = New System.Windows.Forms.ListView()
        Me.BT_Refresh = New System.Windows.Forms.Button()
        Me.Panel_Content = New System.Windows.Forms.Panel()
        Me.Panel_Button = New System.Windows.Forms.Panel()
        Me.L_BT_S = New System.Windows.Forms.Label()
        Me.BT_Close = New System.Windows.Forms.Button()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.BT_TopBar = New System.Windows.Forms.Button()
        Me.Button_Max = New System.Windows.Forms.Button()
        Me.Button_Min = New System.Windows.Forms.Button()
        Me.UFTOperatorBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Panel_Content.SuspendLayout()
        Me.Panel_Button.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UFTOperatorBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ListView_RTR
        '
        Me.ListView_RTR.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ListView_RTR.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListView_RTR.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.ListView_RTR.ForeColor = System.Drawing.Color.Black
        Me.ListView_RTR.FullRowSelect = True
        Me.ListView_RTR.GridLines = True
        Me.ListView_RTR.LabelWrap = False
        Me.ListView_RTR.Location = New System.Drawing.Point(0, 0)
        Me.ListView_RTR.Margin = New System.Windows.Forms.Padding(2)
        Me.ListView_RTR.Name = "ListView_RTR"
        Me.ListView_RTR.Size = New System.Drawing.Size(530, 254)
        Me.ListView_RTR.TabIndex = 0
        Me.ListView_RTR.UseCompatibleStateImageBehavior = False
        Me.ListView_RTR.View = System.Windows.Forms.View.Details
        '
        'BT_Refresh
        '
        Me.BT_Refresh.BackColor = System.Drawing.Color.White
        Me.BT_Refresh.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray
        Me.BT_Refresh.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Aqua
        Me.BT_Refresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BT_Refresh.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.BT_Refresh.ForeColor = System.Drawing.Color.Black
        Me.BT_Refresh.Location = New System.Drawing.Point(13, 6)
        Me.BT_Refresh.Margin = New System.Windows.Forms.Padding(2)
        Me.BT_Refresh.Name = "BT_Refresh"
        Me.BT_Refresh.Size = New System.Drawing.Size(107, 33)
        Me.BT_Refresh.TabIndex = 1
        Me.BT_Refresh.TabStop = False
        Me.BT_Refresh.Text = "Refresh"
        Me.BT_Refresh.UseVisualStyleBackColor = False
        '
        'Panel_Content
        '
        Me.Panel_Content.Controls.Add(Me.ListView_RTR)
        Me.Panel_Content.Location = New System.Drawing.Point(1, 80)
        Me.Panel_Content.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel_Content.Name = "Panel_Content"
        Me.Panel_Content.Size = New System.Drawing.Size(530, 254)
        Me.Panel_Content.TabIndex = 3
        '
        'Panel_Button
        '
        Me.Panel_Button.BackColor = System.Drawing.Color.Honeydew
        Me.Panel_Button.Controls.Add(Me.BT_Refresh)
        Me.Panel_Button.Controls.Add(Me.L_BT_S)
        Me.Panel_Button.Location = New System.Drawing.Point(1, 29)
        Me.Panel_Button.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel_Button.Name = "Panel_Button"
        Me.Panel_Button.Size = New System.Drawing.Size(530, 50)
        Me.Panel_Button.TabIndex = 1
        '
        'L_BT_S
        '
        Me.L_BT_S.BackColor = System.Drawing.Color.Silver
        Me.L_BT_S.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.L_BT_S.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold)
        Me.L_BT_S.ForeColor = System.Drawing.Color.White
        Me.L_BT_S.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.L_BT_S.Location = New System.Drawing.Point(11, 9)
        Me.L_BT_S.Name = "L_BT_S"
        Me.L_BT_S.Size = New System.Drawing.Size(107, 33)
        Me.L_BT_S.TabIndex = 83
        Me.L_BT_S.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        Me.BT_Close.Location = New System.Drawing.Point(494, 1)
        Me.BT_Close.Name = "BT_Close"
        Me.BT_Close.Size = New System.Drawing.Size(26, 22)
        Me.BT_Close.TabIndex = 148
        Me.BT_Close.TabStop = False
        Me.BT_Close.Text = "X"
        Me.BT_Close.UseVisualStyleBackColor = False
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
        Me.PictureBox2.TabIndex = 146
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
        Me.BT_TopBar.Location = New System.Drawing.Point(1, 1)
        Me.BT_TopBar.Name = "BT_TopBar"
        Me.BT_TopBar.Size = New System.Drawing.Size(530, 28)
        Me.BT_TopBar.TabIndex = 147
        Me.BT_TopBar.TabStop = False
        Me.BT_TopBar.Text = "          Real Time Result"
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
        Me.Button_Max.Location = New System.Drawing.Point(462, 1)
        Me.Button_Max.Name = "Button_Max"
        Me.Button_Max.Size = New System.Drawing.Size(26, 22)
        Me.Button_Max.TabIndex = 149
        Me.Button_Max.TabStop = False
        Me.Button_Max.Text = "•"
        Me.Button_Max.UseVisualStyleBackColor = False
        '
        'Button_Min
        '
        Me.Button_Min.BackColor = System.Drawing.Color.Transparent
        Me.Button_Min.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.Button_Min.FlatAppearance.BorderSize = 0
        Me.Button_Min.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red
        Me.Button_Min.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Min.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Min.ForeColor = System.Drawing.Color.Black
        Me.Button_Min.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button_Min.Location = New System.Drawing.Point(430, 2)
        Me.Button_Min.Name = "Button_Min"
        Me.Button_Min.Size = New System.Drawing.Size(26, 22)
        Me.Button_Min.TabIndex = 150
        Me.Button_Min.TabStop = False
        Me.Button_Min.Text = "_"
        Me.Button_Min.UseVisualStyleBackColor = False
        '
        'UFTOperatorBindingSource
        '
        Me.UFTOperatorBindingSource.DataSource = GetType(ATester.ExecutionOperator)
        '
        'Form_RealTimeResult
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Silver
        Me.ClientSize = New System.Drawing.Size(532, 335)
        Me.Controls.Add(Me.Button_Min)
        Me.Controls.Add(Me.Button_Max)
        Me.Controls.Add(Me.BT_Close)
        Me.Controls.Add(Me.Panel_Content)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.Panel_Button)
        Me.Controls.Add(Me.BT_TopBar)
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "Form_RealTimeResult"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Tag = "atester"
        Me.Text = "Real Time Result"
        Me.TopMost = True
        Me.Panel_Content.ResumeLayout(False)
        Me.Panel_Button.ResumeLayout(False)
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UFTOperatorBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UFTOperatorBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ListView_RTR As System.Windows.Forms.ListView
    Friend WithEvents BT_Refresh As System.Windows.Forms.Button
    Friend WithEvents Panel_Content As System.Windows.Forms.Panel
    Friend WithEvents Panel_Button As System.Windows.Forms.Panel
    Friend WithEvents L_BT_S As System.Windows.Forms.Label
    Friend WithEvents BT_Close As System.Windows.Forms.Button
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents BT_TopBar As System.Windows.Forms.Button
    Friend WithEvents Button_Max As System.Windows.Forms.Button
    Friend WithEvents Button_Min As System.Windows.Forms.Button
End Class
