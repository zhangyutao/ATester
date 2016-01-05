Imports System.Threading

'Imports MSTSCLib

Public Class Form_CheckSlave
    Delegate Sub Delegate_SetListViewCheckedItemsSubItem(ByVal lv As ListView, ByVal indexOfItem As Integer, ByVal indexOfsubItem As Integer, ByVal content As String)
    Public deafultServerNameContent As String = "Double click to edit"
    Public deafultStatusContent As String = "N/A"
    Public deafultTCContent As String = "N/A"
    Public SelectedItem As ListViewItem = Nothing
    Public arryForThreadWhichCheckSlaveSt(-1) As Object
    Public continueChecking = True


    Private Sub Form_QRDC_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        BT_TopBar.BackColor = GetVbColor(My.Resources.TopbarBackColor_Enabled)
        BT_TopBar.ForeColor = GetVbColor(My.Resources.TopbarForeColor_Enabled)
        Me.Location = Form_Main.PointToScreen(New Point(Form_Main.MenuStrip.Location.X, Form_Main.MenuStrip.Location.Y))
        Panel_ConentUpdate.Parent = Me
        Panel_checkconbutton.Parent = Me
        Panel_checkconbutton.Visible = True
        Panel_ConentUpdate.Visible = False
        Panel_table.Size = New Size(Me.Width - 2, Me.Height - Panel_checkconbutton.Location.Y - Panel_checkconbutton.Height)
        Panel_table.Location = New Point(Panel_table.Location.X, Panel_checkconbutton.Location.Y + Panel_checkconbutton.Height - 1)
        ' Panel_ConentUpdate.Dock = DockStyle.Top
        'Panel_checkconbutton.Dock = DockStyle.Top
        Bt_StopChecking.Enabled = False
        If ListView_RSlaveSt.Items.Count <= 0 Then
            ListView_RSlaveSt.Items.Add("+")
            ListView_RSlaveSt.Items.Item(0).Focused = False
            ListView_RSlaveSt.Items.Item(0).SubItems.Add(deafultServerNameContent)
            ListView_RSlaveSt.Items.Item(0).SubItems.Add(deafultStatusContent)
            ListView_RSlaveSt.Items.Item(0).SubItems.Add(deafultTCContent)
            For i = 0 To ListView_RSlaveSt.Items.Item(0).SubItems.Count - 1
                ListView_RSlaveSt.Items.Item(0).SubItems.Item(i).ForeColor = Color.Gray
            Next
        End If
        BT_TopBar.Width = Panel_topbar.Width
        Bt_CloseRDCF.Parent = BT_TopBar
        Bt_CloseRDCF.Location = New Point(BT_TopBar.Width - Bt_CloseRDCF.Width - 1, 0)
    End Sub

    Private Sub Form_QRDC_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.VisibleChanged
        If Me.Visible = True Then
            Me.Location = Form_Main.PointToScreen(New Point(Form_Main.MenuStrip.Location.X, Form_Main.MenuStrip.Location.Y))
        End If
        Form_Main.Bt_Run.Enabled = False


    End Sub

    Private Sub Bt_CloseRDCF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bt_CloseRDCF.Click
        Bt_StopChecking_Click(Me, Nothing)
        Me.Hide()
        Form_Main.Bt_Run.Enabled = True
        Form_Main.CheckRemoteUFTStatusToolStripMenuItem.Enabled = True



    End Sub

    Private Sub ListView_RDC_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListView_RSlaveSt.MouseDoubleClick
        Dim mpoint As Point = ListView_RSlaveSt.PointToClient(Form_CheckSlave.MousePosition)
        Dim Item = ListView_RSlaveSt.GetItemAt(mpoint.X, mpoint.Y)
        If IsNothing(SelectedItem) Then
        Else
            For w = 0 To SelectedItem.SubItems.Count - 1
                SelectedItem.SubItems.Item(w).BackColor = Color.White
            Next
        End If

        SelectedItem = Item
        Me.Enabled = False
        Panel_ConentUpdate.Visible = True
        Panel_checkconbutton.Visible = False
        Panel_table.Size = New Size(Me.Width - 2, Me.Height - Panel_ConentUpdate.Location.Y - Panel_ConentUpdate.Height)
        Panel_table.Location = New Point(Panel_table.Location.X, Panel_ConentUpdate.Location.Y + Panel_ConentUpdate.Height - 1)
        If SelectedItem.SubItems.Item(1).Text = deafultServerNameContent Then
            TB_IP.Text = ""

        Else
            TB_IP.Text = SelectedItem.SubItems.Item(1).Text

        End If
        For w = 0 To SelectedItem.SubItems.Count - 1
            SelectedItem.SubItems.Item(w).BackColor = Color.DeepSkyBlue
        Next

        Panel_ConentUpdate.Show()
        Me.Enabled = True
    End Sub

    Private Sub Bt_Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bt_Cancel.Click
        Me.Enabled = False
        Panel_ConentUpdate.Visible = False
        Panel_checkconbutton.Visible = True
        Panel_table.Size = New Size(Me.Width - 2, Me.Height - Panel_checkconbutton.Location.Y - Panel_checkconbutton.Height)
        Panel_table.Location = New Point(Panel_table.Location.X, Panel_checkconbutton.Location.Y + Panel_checkconbutton.Height - 1)
        For w = 0 To SelectedItem.SubItems.Count - 1
            SelectedItem.SubItems.Item(w).BackColor = Color.White
        Next
        TB_IP.Text = ""
        SelectedItem = Nothing
        Me.Enabled = True
    End Sub

    Private Sub Bt_updateCoent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bt_updateContent.Click

        Me.Enabled = False
        If Trim(TB_IP.Text) = "" Then
            MsgBox("You cannot update when a field is blank!")
        Else
            SelectedItem.SubItems.Item(1).Text = Trim(TB_IP.Text)
            For w = 0 To SelectedItem.SubItems.Count - 1
                'SelectedItem.SubItems.Item(w).BackColor = Color.White
                SelectedItem.SubItems.Item(w).ForeColor = Color.Black
            Next


            Dim findBlank = False
            Dim i = ListView_RSlaveSt.Items.Count - 1
            For j = 1 To ListView_RSlaveSt.Items.Item(i).SubItems.Count - 1
                If Trim(ListView_RSlaveSt.Items.Item(i).SubItems.Item(j).Text) = deafultServerNameContent Then
                    findBlank = True
                    Exit For
                End If

            Next

            If findBlank = False Then
                Dim newItem = ListView_RSlaveSt.Items.Add("+")
                newItem.Focused = False
                newItem.SubItems.Add(deafultServerNameContent)
                newItem.SubItems.Add(deafultStatusContent)
                newItem.SubItems.Add(deafultTCContent)
                For i = 0 To newItem.SubItems.Count - 1
                    newItem.SubItems.Item(i).ForeColor = Color.Gray
                Next
            End If
        End If

        Me.Enabled = True
    End Sub

    Private Sub Bt_Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bt_Delete.Click
        Dim msgboxvalue As Integer = MsgBox("Do you want to delete the items you selected?", MsgBoxStyle.YesNo)
        If msgboxvalue = 6 Then
            Me.Enabled = False
            Dim findChecked = False
            Dim userChecked = False
            Do
                findChecked = False
                For i = 0 To ListView_RSlaveSt.Items.Count - 1
                    If ListView_RSlaveSt.Items.Item(i).Checked Then
                        ListView_RSlaveSt.Items.RemoveAt(i)
                        findChecked = True
                        userChecked = True
                        Exit For
                    End If
                Next
                If userChecked = False Then
                    MsgBox("You have not selected any item !")
                    Me.Enabled = True
                    Exit Sub
                End If
            Loop While findChecked

            If ListView_RSlaveSt.Items.Count <= 0 Then
                ListView_RSlaveSt.Items.Add("+")
                ListView_RSlaveSt.Items.Item(0).Focused = False
                ListView_RSlaveSt.Items.Item(0).SubItems.Add(deafultServerNameContent)
                ListView_RSlaveSt.Items.Item(0).SubItems.Add(deafultStatusContent)
                ListView_RSlaveSt.Items.Item(0).SubItems.Add(deafultTCContent)

                For i = 0 To ListView_RSlaveSt.Items.Item(0).SubItems.Count - 1
                    ListView_RSlaveSt.Items.Item(0).SubItems.Item(i).ForeColor = Color.Gray
                Next
            End If
            Me.Enabled = True
        Else
            Exit Sub
        End If
    End Sub

    Private Sub Bt_Connect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bt_Connect.Click
        ReDim arryForThreadWhichCheckSlaveSt(-1)
        Bt_CloseRDCF.Enabled = False
        ListView_RSlaveSt.Enabled = False
        Bt_Connect.Enabled = False
        Bt_Delete.Enabled = False
        Dim arrySlave() As String
        ReDim arrySlave(-1)
        Dim number = -1
        For i = 0 To ListView_RSlaveSt.CheckedItems.Count - 1
            If Trim(ListView_RSlaveSt.CheckedItems.Item(i).SubItems.Item(1).Text).ToLower <> deafultServerNameContent.ToLower Then
                number = number + 1
                ReDim Preserve arrySlave(number)
                arrySlave(number) = Trim(ListView_RSlaveSt.CheckedItems.Item(i).SubItems.Item(1).Text) + "::" + CStr(ListView_RSlaveSt.CheckedItems.Item(i).Index)
                ListView_RSlaveSt.CheckedItems.Item(i).SubItems.Item(2).Text = "Try to communicate..."
                ListView_RSlaveSt.CheckedItems.Item(i).SubItems.Item(3).Text = "..."
            End If
        Next

        If UBound(arrySlave) <> -1 Then
            For j = 0 To UBound(arrySlave)
                ThreadPool.QueueUserWorkItem(New WaitCallback(AddressOf Form_CheckSlaveStatus), arrySlave(j))
            Next
        Else
            MsgBox("You have not selected any item !")
            GoTo endline
        End If
        Bt_StopChecking.Enabled = True
        Do Until UBound(arryForThreadWhichCheckSlaveSt) = UBound(arrySlave)
            Application.DoEvents()
            waitTime(1000)
            If continueChecking = False Then
                GoTo stopendline
            End If
        Loop

        Dim isAlivethread As Boolean = True
        Do While isAlivethread
            If continueChecking = False Then
                GoTo stopendline
            End If
            isAlivethread = False
            For i = 0 To UBound(arryForThreadWhichCheckSlaveSt) 'the 1st index is nothing, so from 1 to max bound
                If continueChecking = False Then
                    GoTo stopendline
                End If
                If IsNothing(arryForThreadWhichCheckSlaveSt(i)(0)) Then
                Else
                    Application.DoEvents()
                    If arryForThreadWhichCheckSlaveSt(i)(1) <> "end" Then
                        isAlivethread = True
                    End If

                End If
            Next
        Loop

endline:
        ListView_RSlaveSt.Enabled = True
        Bt_Connect.Enabled = True
        Bt_StopChecking.Enabled = False
        Bt_Delete.Enabled = True
        Bt_CloseRDCF.Enabled = True
stopendline:
        continueChecking = True
    End Sub

    Private Sub Bt_StopChecking_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bt_StopChecking.Click
        continueChecking = False
        If UBound(arryForThreadWhichCheckSlaveSt) = -1 Then
        Else
            For i = 0 To UBound(arryForThreadWhichCheckSlaveSt) 'the 1st index is nothing, so from 1 to max bound
                If IsNothing(arryForThreadWhichCheckSlaveSt(i)(0)) Then
                Else
                    Application.DoEvents()
                    If arryForThreadWhichCheckSlaveSt(i)(0).IsAlive() Then
                        arryForThreadWhichCheckSlaveSt(i)(0).Abort()
                    End If

                End If
            Next
        End If
        'ReDim arryForThreadWhichCheckSlaveSt(-1)
        ListView_RSlaveSt.Enabled = True
        Bt_Connect.Enabled = True
        Bt_StopChecking.Enabled = False
        Bt_Delete.Enabled = True
        Bt_CloseRDCF.Enabled = True
    End Sub
    Sub Form_CheckSlaveStatus(ByVal serverinfo)

        '#################get the thread###################
        Dim tempThread As Thread = Threading.Thread.CurrentThread
        'Debug.Print(CStr(Now) + "reach thread")
        tempThread.IsBackground = True
        Dim nextIndex As Integer = UBound(arryForThreadWhichCheckSlaveSt) + 1
        ReDim Preserve arryForThreadWhichCheckSlaveSt(nextIndex)
        arryForThreadWhichCheckSlaveSt(nextIndex) = {tempThread, "startchecking"}
        '#################get the thread END###################
        Dim arryIP = Split(serverinfo, "::")
        Dim servernameorIP = arryIP(0)
        Dim indexOfItem = CInt(arryIP(1))
        Dim status As String = ""
        Dim startTime = Now
        On Error Resume Next
        Dim isRemoteQTPConfigured As Boolean = False
        Dim UFTOperator As New ExecutionOperator
        Dim qtApp As Object = UFTOperator.CreateUFT(servernameorIP)
        If Err.Number <> 0 Then
            GoTo errorDecide
        End If

        status = "Online(" + UFTOperator.CheckRemoteServerUFTStatus(qtApp).ToUpper + ")"
        If Err.Number = 0 Then
            isRemoteQTPConfigured = True
        Else
            isRemoteQTPConfigured = False
            Err.Number = -110110
            GoTo errorDecide
        End If
        qtApp.Launch()
        status = "Online(" + UFTOperator.CheckRemoteServerUFTStatus(qtApp).ToUpper + ")"
errorDecide:
        Select Case Err.Number
            Case 0
            Case -110110
                Dim username = System.Security.Principal.WindowsIdentity.GetCurrent().Name
                status = "Security of DCOM ""QuickTest Professional Automation"" is not allowed user""" + username + """ to access. Suggestion:follow UFT's help doc to configure."
            Case Else
                If isRemoteQTPConfigured Then
                    status = CStr(Err.Number) + "-" + Err.Description + ". Suggestion: Maybe you have not opened screen of slave server"
                Else
                    Dim username = System.Security.Principal.WindowsIdentity.GetCurrent().Name
                    status = CStr(Err.Number) + "-" + Err.Description + ". Suggestion: Opened screen of slave server and configure Security of DCOM ""QuickTest Professional Automation"" for user """ + username + """"
                End If

        End Select
        On Error GoTo 0
        Dim endTime = Now

        Invoke(New Delegate_SetListViewCheckedItemsSubItem(AddressOf setListViewCheckedItemsSubItem), ListView_RSlaveSt, indexOfItem, 2, status)
        Invoke(New Delegate_SetListViewCheckedItemsSubItem(AddressOf setListViewCheckedItemsSubItem), ListView_RSlaveSt, indexOfItem, 3, CStr(DateDiff("s", startTime, endTime)))


        UFTOperator = Nothing
        qtApp = Nothing
        arryForThreadWhichCheckSlaveSt(nextIndex)(1) = "end"
    End Sub
    'Sub getListViewCheckedItems(ByRef lv As ListView)
    '    curCheckItems = lv.CheckedItems
    'End Sub

    Sub setListViewCheckedItemsSubItem(ByVal lv As ListView, ByVal indexOfItem As Integer, ByVal indexOfsubItem As Integer, ByVal content As String)
        lv.CheckedItems.Item(indexOfItem).SubItems.Item(indexOfsubItem).Text = content
    End Sub

    Public L_TopBar_mousedownVar As Boolean = False
    Public curMousePosOnL_TopBar As Point = Nothing
    Private Sub L_FormBack_MouseDown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_TopBar.MouseDown
        L_TopBar_mousedownVar = True
        curMousePosOnL_TopBar = BT_TopBar.PointToClient(Form_CheckSlave.MousePosition)
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