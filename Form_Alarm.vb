Imports System.Threading

Public Class Form_Alarm
    Public alarmTime As Date = Nothing
    Public isThreadClickRun = 0
    Public AlarmRunEnd = 0
    Public hasSetupAlarm As Boolean = False
    Delegate Sub Delegate_EditText(ByRef bt As Object, ByRef bl As String)
    Public waitToStartRunThread As New Thread(AddressOf waitToStartRun)
    Public countremaintimeThread As New Thread(AddressOf countremaintime)
    Delegate Sub Delegate_EnabledOject(ByRef bt As Object, ByRef bl As Boolean)
    Delegate Sub Delegate_ClickButton(ByRef bt As Button)
    Delegate Sub Delegate_appendTB(ByRef tb As TextBox, ByRef ss As String)
    Delegate Sub Delegate_newForm()


    Public Sub enabledOject(ByRef bt As Object, ByRef bl As Boolean)
        bt.Enabled = bl
    End Sub

    Public Sub clickButton(ByRef bt As Button)
        bt.PerformClick()
    End Sub
    Sub appendTB(ByRef tb As TextBox, ByRef ss As String)
        tb.AppendText(ss)
    End Sub
    Private Sub BT_Close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Close.Click
        Me.Hide()
    End Sub
    Public L_TopBar_mousedownVar As Boolean = False
    Public curMousePosOnL_TopBar As Point = Nothing
    Private Sub L_FormBack_MouseDown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_TopBar.MouseDown
        L_TopBar_mousedownVar = True
        curMousePosOnL_TopBar = BT_TopBar.PointToClient(Dialog.MousePosition)
    End Sub

    Private Sub L_TopBar_MouseUp(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_TopBar.MouseUp
        L_TopBar_mousedownVar = False
        curMousePosOnL_TopBar = Nothing
    End Sub
    Private Sub L_TopBar_move(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_TopBar.MouseMove
        If L_TopBar_mousedownVar And (IsNothing(curMousePosOnL_TopBar) = False) Then
            Dim curMousePos = System.Windows.Forms.Cursor.Position
            Me.Location = New Point(curMousePos.X - curMousePosOnL_TopBar.X - BT_TopBar.Location.X, curMousePos.Y - curMousePosOnL_TopBar.Y - BT_TopBar.Location.Y)
        End If
    End Sub

    Private Sub Button_Yes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_OK.Click
        If Form_Main.IsRUNClicked Then
            MsgBox("You only can define the alarm after current run end!")
        Else
            Dim ctime = CInt(TB_TimeLeft.Text)
            TB_TimeLeft.Text = "0"
            If ctime = 0 Then
                MsgBox("Please enter a integer bigger than 0 !")
            Else
                If hasSetupAlarm = False Then
                    hasSetupAlarm = True
                    Calloff_Button.Visible = True
                Else
                    If IsNothing(waitToStartRunThread) = False Then
                        waitToStartRunThread.Abort()
                    End If
                    waitToStartRunThread = Nothing

                    If IsNothing(countremaintimeThread) = False Then
                        countremaintimeThread.Abort()
                    End If
                    countremaintimeThread = Nothing
                End If

                alarmTime = DateAdd(DateInterval.Minute, ctime, Now)
                L_Time.Text = CStr(alarmTime)
                Form_Main.alarmTime = alarmTime

                countremaintimeThread = New Thread(AddressOf countremaintime)
                countremaintimeThread.IsBackground = True
                countremaintimeThread.Start()
                waitToStartRunThread = New Thread(AddressOf waitToStartRun)
                waitToStartRunThread.IsBackground = True
                waitToStartRunThread.Start()
                Form_Main.L_TimeRemaining.Visible = True
                Button_OK.Text = "Update"
                Me.Hide()
                MsgBox("Please configure all test data in ATester before the alarm !")

            End If
        End If
    End Sub

    Private Sub Button_No_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_Cancel.Click
        TB_TimeLeft.Text = "0"
        Me.Hide()
    End Sub

    Private Sub Form_Alarm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If IsNothing(waitToStartRunThread) = False Then
            waitToStartRunThread.Abort()
        End If
        If IsNothing(countremaintimeThread) = False Then
            countremaintimeThread.Abort()
        End If
        waitToStartRunThread = Nothing
        countremaintimeThread = Nothing
    End Sub

    Private Sub Button_Cancel_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.VisibleChanged
        If hasSetupAlarm Then
            Button_OK.Text = "Update"
        Else
            Button_OK.Text = "OK"
        End If

        If Me.Visible = True Then
            Form_Main.AlarmToRunToolStripMenuItem.Enabled = False
            Me.Location = Form_Main.PointToScreen(New Point(Form_Main.ToolStrip.Location.X, Form_Main.ToolStrip.Location.Y))
        Else
            Form_Main.AlarmToRunToolStripMenuItem.Enabled = True
        End If
        TB_TimeLeft.Text = "0"
    End Sub

    Private Sub TB_TimeLeft_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TB_TimeLeft.TextChanged


        If TB_TimeLeft.Text <> "" Then
            Dim KeyCode As Integer
            For i = 1 To Len(TB_TimeLeft.Text)
                KeyCode = Asc(Mid(TB_TimeLeft.Text, i, 1))
                If KeyCode < 48 Or KeyCode > 57 Then
                    TB_TimeLeft.Text = Replace(TB_TimeLeft.Text, Mid(TB_TimeLeft.Text, i, 1), "")
                    TB_TimeLeft.Select(i - 1, False)

                    Exit For
                End If
            Next
        Else
            TB_TimeLeft.Text = 0
        End If
        TB_TimeLeft.Text = CInt(TB_TimeLeft.Text)

        Dim CtimeToRun = CInt(TB_TimeLeft.Text)
        If CtimeToRun < 0 Then
            TB_TimeLeft.Text = "0"
        End If

        If CtimeToRun > 1440 Then
            TB_TimeLeft.Text = "1440"
        End If
    End Sub

    Public Sub Calloff_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Calloff_Button.Click
        If IsNothing(waitToStartRunThread) = False Then
            waitToStartRunThread.Abort()
        End If
        waitToStartRunThread = Nothing
        If IsNothing(countremaintimeThread) = False Then
            countremaintimeThread.Abort()
        End If
        countremaintimeThread = Nothing

        TB_TimeLeft.Text = ""
        hasSetupAlarm = False
        L_Time.Text = "--"
        L_TimeRemaining.Text = "--"
        alarmTime = Nothing
        Form_Main.alarmTime = Nothing
        Calloff_Button.Visible = False
        Form_Main.L_TimeRemaining.Visible = False
        Me.Hide()
        MsgBox("The Alarm has been cancelled !" + vbCrLf + "For several reasons: " + vbCrLf + "1. user cancelled it. " + vbCrLf + "2. user is configuring ATester. " + vbCrLf + "3. user started run manually.")
    End Sub
    Sub waitToStartRun()
        Dim isUserOperating As Boolean = False
        Do Until DateDiff(DateInterval.Second, alarmTime, Now) > 0 And Form_Main.Bt_Run.Enabled = True
            If DateDiff(DateInterval.Second, alarmTime, Now) >= 0 Then
                isUserOperating = True
                Exit Do
            End If
            waitTime(5000)
        Loop
        If isUserOperating Then
            Invoke(New Delegate_ClickButton(AddressOf clickButton), Calloff_Button)
        Else
            Invoke(New Delegate_EnabledOject(AddressOf enabledOject), Calloff_Button, False)
            Invoke(New Delegate_EnabledOject(AddressOf enabledOject), Button_OK, False)
            Invoke(New Delegate_EnabledOject(AddressOf enabledOject), Button_Cancel, False)
            Invoke(New Delegate_EnabledOject(AddressOf enabledOject), TB_TimeLeft, False)

            AlarmRunEnd = 0
            isThreadClickRun = 1
            Do Until AlarmRunEnd = 1
                waitTime(1000)
            Loop
            Invoke(New Delegate_EnabledOject(AddressOf enabledOject), Calloff_Button, True)
            Invoke(New Delegate_EnabledOject(AddressOf enabledOject), Button_OK, True)
            Invoke(New Delegate_EnabledOject(AddressOf enabledOject), Button_Cancel, True)
            Invoke(New Delegate_EnabledOject(AddressOf enabledOject), TB_TimeLeft, True)
            TB_TimeLeft.Text = "0"
            If IsNothing(countremaintimeThread) = False Then
                countremaintimeThread.Abort()
            End If
            countremaintimeThread = Nothing
            hasSetupAlarm = False
            alarmTime = Nothing
            Form_Main.alarmTime = Nothing
            Invoke(New Delegate_newForm(AddressOf newForm))
        End If

    End Sub
    Sub newForm()
        Form_Main.L_TimeRemaining.Visible = False
        Calloff_Button.Visible = False
        L_Time.Text = "--"
        L_TimeRemaining.Text = "--"
        Button_OK.Text = "OK"
    End Sub

    Private Sub Form_Alarm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        BT_Close.Parent = BT_TopBar
        TB_TimeLeft.Text = "0"
        BT_TopBar.Width = Me.Width - 2 - BT_TopBar.Location.X
    End Sub
    Sub countremaintime()
        Dim ctime = DateDiff(DateInterval.Second, alarmTime, Now)
        Do Until ctime >= 0
            Dim time = CStr(CInt(0 - ctime))
            Invoke(New Delegate_EditText(AddressOf editText), L_TimeRemaining, time + " seconds")
            waitTime(1000)
            ctime = DateDiff(DateInterval.Second, alarmTime, Now)
        Loop

    End Sub
    Sub editText(ByRef bt As Object, ByRef bl As String)
        bt.text = bl
    End Sub
    Function MsgBox(ByRef msg As String, Optional ByVal buttons As MsgBoxStyle = MsgBoxStyle.ApplicationModal, Optional ByVal title As String = "") As Integer
        Dim curForms = Application.OpenForms
        Dim before = Me.Enabled
        Me.Enabled = False
        Dim mydialog As New Dialog
        If title <> "" Then
            mydialog.Text = title
        End If
        mydialog.TB_Content.Text = msg
        Select Case buttons
            Case MsgBoxStyle.YesNo
                mydialog.Button_Yes.Show()
                mydialog.Button_No.Show()
            Case MsgBoxStyle.ApplicationModal
                mydialog.Button_OK.Show()
            Case Else
                Return Microsoft.VisualBasic.MsgBox(msg, buttons, title)
        End Select

        Dim parentForm = curForms(curForms.Count - 1)
        Dim parentFormlocation = parentForm.location
        mydialog.Location = New Point(parentFormlocation.X + parentForm.Width / 2 - mydialog.Width / 2, parentFormlocation.Y + parentForm.Height / 2 - mydialog.Height / 2)
        mydialog.Show()
        Beep()
        Do While mydialog.DialogResult = DialogResult.None
            Application.DoEvents()
        Loop
        mydialog.Close()
        Me.Enabled = before
        Return mydialog.DialogResult
    End Function

    Private Sub Form_Main_EnabledChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.EnabledChanged
        If Me.Enabled Then
            BT_TopBar.BackColor = GetVbColor(My.Resources.TopbarBackColor_Enabled)
            BT_TopBar.ForeColor = GetVbColor(My.Resources.TopbarForeColor_Enabled)
        Else
            BT_TopBar.BackColor = GetVbColor(My.Resources.TopbarBackColor_Disabled)
            BT_TopBar.ForeColor = GetVbColor(My.Resources.TopbarForeColor_Disabled)

        End If

    End Sub


End Class