Imports System.Threading

Public Class Form_RunMgmt

    Public Shared tunnel() As Boolean
    Delegate Sub Delegate_Normal()
    Public finished As Boolean = False
    Public Runlist_RunningMissionRelationShip(-1) As Array

    Private Sub Bt_CloseMoreRemoteSetting_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bt_Close.Click
        Me.Close()
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



    Public Sub Bt_R_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bt_R.Click
        Bt_Close.Enabled = False

        If ListView_SlaveInMission.SelectedItems.Count > 0 Then
            Me.Enabled = False
            Dim res = MsgBox("Remove selected slave?", MsgBoxStyle.YesNo)
            Me.Enabled = True
            If res = MsgBoxResult.Yes Then
                Dim exceptionMsg(-1) As String
                Dim progress = "Progress: "
                BT_R_Mission.Enabled = False
                BT_A_Mission.Enabled = False
                Bt_R.Enabled = False
                BT_A.Enabled = False
                ListView_SlaveInMission.Enabled = False
                Dim request = True
                Dim response = False
                ReDim tunnel(1)
                tunnel = {request, response}

                popMsgMethod(progress + "waiting to access mission resource.")
                Dim threadIndexInsynVar = -1
                If Form_Main.CB_CRT.Checked And Form_Main.CB_Servers.Checked Then

                    threadIndexInsynVar = AddtoSync(ExecutionOperator.syncStatusOfCustomRemote, ExecutionOperator.synchroPointSTOfCustomRemote, ExecutionOperator.syncStatusLockOfCustomRemote, tunnel)
                Else

                    threadIndexInsynVar = AddtoSync(ExecutionOperator.syncStatusOfRemote, ExecutionOperator.synchroPointSTOfRemote, ExecutionOperator.syncStatusLockOfRemote, tunnel)

                End If

                If threadIndexInsynVar = -1 Then
                    BT_R_Mission.Enabled = True
                    BT_A_Mission.Enabled = True
                    Bt_R.Enabled = True
                    BT_A.Enabled = True
                    ListView_SlaveInMission.Enabled = True
                    ReDim Preserve exceptionMsg(UBound(exceptionMsg) + 1)
                    exceptionMsg(UBound(exceptionMsg)) = "Error on add to sync for Bt_R_Click!"
                    If UBound(exceptionMsg) > -1 Then

                        Dim emsg As String = ""
                        For f = 0 To UBound(exceptionMsg)
                            emsg = emsg + CStr(f) + "." + exceptionMsg(f) + " "
                        Next
                        addToExBox(progress + "(Exception) " + emsg)


                    End If
                    Exit Sub
                End If


                Dim selectditem() As String
                ReDim selectditem(-1)
                For i = 0 To ListView_SlaveInMission.SelectedItems.Count - 1
                    ReDim Preserve selectditem(UBound(selectditem) + 1)
                    selectditem(UBound(selectditem)) = ListView_SlaveInMission.SelectedItems.Item(i).Text

                Next

                popMsgMethod(progress + "updating server information.")
                For j = 0 To UBound(selectditem)

                    For k = 0 To UBound(ExecutionOperator.arryServerFullyInfo)
                        If IsNothing(ExecutionOperator.arryServerFullyInfo(k)) = False Then


                            If selectditem(j) = ExecutionOperator.arryServerFullyInfo(k)(1) Then
                                popMsgMethod(progress + "updating Standby Slaves List.")
                                If ListView_Standby_Slave.Items.Count > 0 Then
                                    Dim findItem = False
                                    For b = 0 To ListView_Standby_Slave.Items.Count - 1
                                        If selectditem(j) = ListView_Standby_Slave.Items.Item(b).Text Then
                                            findItem = True
                                            ListView_Standby_Slave.Items.Item(j).SubItems.Item(1).Text = ExecutionOperator.arryServerFullyInfo(k)(0)
                                            Exit For
                                        End If
                                    Next
                                    If findItem = False Then
                                        Dim newItem = ListView_Standby_Slave.Items.Add(selectditem(j))
                                        newItem.SubItems.Add(ExecutionOperator.arryServerFullyInfo(k)(0))

                                    End If
                                Else
                                    Dim newItem = ListView_Standby_Slave.Items.Add(selectditem(j))
                                    newItem.SubItems.Add(ExecutionOperator.arryServerFullyInfo(k)(0))
                                End If

                                popMsgMethod(progress + "updating Slaves in Mission List.")
                                If ListView_SlaveInMission.Items.Count > 0 Then
                                    Dim findItem = False
                                    For Each item In ListView_SlaveInMission.Items
                                        If selectditem(j) = item.Text Then
                                            findItem = True
                                            ListView_SlaveInMission.Items.Remove(item)
                                            Exit For
                                        End If
                                    Next
                                End If

                                Array.Clear(ExecutionOperator.arryServerFullyInfo, k, 1)
                                Exit For
                            End If
                        End If
                    Next

                    popMsgMethod(progress + "aborting server's mission.")
                    Dim tempVar = ExecutionOperator.arryForThreadWhichRunRemoteBPT
                    Dim findThread = False
                    If UBound(tempVar) > -1 Then
                        For h = 0 To UBound(tempVar)
                            If tempVar(h)(1) = selectditem(j) Then
                                findThread = True
                                If IsNothing(tempVar(h)(0)) Then
                                    Exit For
                                Else
                                    If tempVar(h)(0).IsAlive = False Then
                                        Exit For
                                    Else
                                        Dim newTh As New Thread(AddressOf cancelThread)
                                        newTh.IsBackground = True
                                        finished = False
                                        newTh.Start(tempVar(h)(0))
                                        Dim curtime1 = Now
                                        Dim curtime2 = Now
                                        Do Until finished Or DateDiff("s", curtime1, curtime2) >= 60
                                            Application.DoEvents()
                                            waitTime(1000)
                                            curtime2 = Now
                                        Loop
                                        If DateDiff("s", curtime1, curtime2) >= 60 Then
                                            newTh = Nothing
                                            tempVar(h)(0) = Nothing
                                            ReDim Preserve exceptionMsg(UBound(exceptionMsg) + 1)
                                            exceptionMsg(UBound(exceptionMsg)) = "aborting server mission timeout, so force to remove it."
                                        End If
                                        Exit For
                                    End If
                                End If

                            End If
                        Next
                    End If

                    popMsgMethod(progress + "updating mission information.")
                    If Form_Main.CustomRemoteTestModel Then
                        Dim tempSelectedCase(-1) As Array
                        For t = 0 To UBound(ExecutionOperator.arryRunList)
                            If IsNothing(ExecutionOperator.arryRunList(t)) = False Then
                                If selectditem(j) = ExecutionOperator.arryRunList(t)(2) Then
                                    ReDim Preserve tempSelectedCase(UBound(tempSelectedCase) + 1)
                                    tempSelectedCase(UBound(tempSelectedCase)) = {ExecutionOperator.arryRunList(t)(0), ExecutionOperator.arryRunList(t)(2)}
                                    Array.Clear(ExecutionOperator.arryRunList, t, 1)
                                End If
                            End If
                        Next
                        If UBound(tempSelectedCase) > -1 Then
                            popMsgMethod(progress + "updating Standby Test Mission List.")
                            For b = 0 To UBound(tempSelectedCase)
                                Dim newItem = ListView_StandBy_TestMission.Items.Add(tempSelectedCase(b)(0))
                                newItem.SubItems.Add(tempSelectedCase(b)(1))
                            Next

                            popMsgMethod(progress + "updating Running Test Mission List.")
                            For b = 0 To UBound(tempSelectedCase)
                                If ListView_TestInMission.Items.Count > 0 Then
                                    For Each item In ListView_TestInMission.Items
                                        If tempSelectedCase(b)(0) = item.subitems.item(0).Text And tempSelectedCase(b)(1) = item.subitems.item(1).Text Then
                                            ListView_TestInMission.Items.Remove(item)

                                        End If
                                    Next
                                Else
                                    Exit For
                                End If
                            Next
                        End If
                    Else
                        For t = 0 To UBound(ExecutionOperator.arryRunList)
                            If IsNothing(ExecutionOperator.arryRunList(t)) = False Then
                                If selectditem(j) = ExecutionOperator.arryRunList(t)(2) Then
                                    Dim status = ExecutionOperator.arryRunList(t)(1)
                                    If status.Contains("done") Then
                                    ElseIf status.Contains("error") Then
                                    Else
                                        ExecutionOperator.arryRunList(t)(1) = "ready"
                                        ExecutionOperator.arryRunList(t)(2) = "Not Assigned"
                                    End If
                                    Exit For
                                End If
                            End If
                        Next

                    End If
                Next



                tunnel(0) = False

                popMsgMethod(progress + "done.")
                BT_R_Mission.Enabled = True
                BT_A_Mission.Enabled = True
                Bt_R.Enabled = True
                BT_A.Enabled = True
                ListView_SlaveInMission.Enabled = True
                If tunnel(1) = True Then
                    ReDim Preserve exceptionMsg(UBound(exceptionMsg) + 1)
                    exceptionMsg(UBound(exceptionMsg)) = "Bt_R_Click thread is finished after time out setting of UFT remote main thread!"
                End If

                If UBound(exceptionMsg) > -1 Then

                    Dim emsg As String = ""
                    For f = 0 To UBound(exceptionMsg)
                        emsg = emsg + CStr(f) + "." + exceptionMsg(f) + " "
                    Next
                    addToExBox(progress + "(Exception) " + emsg)


                End If

            End If
        Else
            MsgBox("You have not selected anything!")
        End If
        Bt_Close.Enabled = True
    End Sub

    Sub cancelThread(ByVal th As Thread)
        If IsNothing(th) Then
        Else
            If th.IsAlive Then
                Application.DoEvents()
                On Error Resume Next
                th.Abort()
                On Error GoTo 0
            End If
        End If

        finished = True
    End Sub
    'Private Sub BT_A_EnabledChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles BT_A.EnabledChanged
    '    If BT_A.Enabled Then
    '        BT_A.BackColor = Color.MediumSeaGreen
    '    Else
    '        BT_A.BackColor = Color.DarkGray
    '    End If
    'End Sub

    'Private Sub Bt_R_EnabledChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Bt_R.EnabledChanged
    '    If Bt_R.Enabled Then
    '        Bt_R.BackColor = Color.MediumSeaGreen
    '    Else
    '        Bt_R.BackColor = Color.DarkGray
    '    End If
    'End Sub

    Private Sub BT_A_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_A.Click
        Bt_Close.Enabled = False
        If IsNothing(ExecutionOperator.arryServerFullyInfo) = False Then


            If ListView_Standby_Slave.SelectedItems.Count > 0 Then
                Me.Enabled = False
                Dim res = MsgBox("Add selected slave?", MsgBoxStyle.YesNo)
                Me.Enabled = True
                Dim progress = "Progress: "
                If res = MsgBoxResult.Yes Then
                    Dim exceptionMsg(-1) As String
                    BT_R_Mission.Enabled = False
                    BT_A_Mission.Enabled = False
                    Bt_R.Enabled = False
                    BT_A.Enabled = False
                    ListView_Standby_Slave.Enabled = False
                    Dim request = True
                    Dim response = False
                    ReDim tunnel(1)
                    tunnel = {request, response}

                    popMsgMethod(progress + "waiting to access mission resource.")
                    Dim threadIndexInsynVar = -1
                    If Form_Main.CB_CRT.Checked And Form_Main.CB_Servers.Checked Then

                        threadIndexInsynVar = AddtoSync(ExecutionOperator.syncStatusOfCustomRemote, ExecutionOperator.synchroPointSTOfCustomRemote, ExecutionOperator.syncStatusLockOfCustomRemote, tunnel)
                    Else

                        threadIndexInsynVar = AddtoSync(ExecutionOperator.syncStatusOfRemote, ExecutionOperator.synchroPointSTOfRemote, ExecutionOperator.syncStatusLockOfRemote, tunnel)

                    End If

                    If threadIndexInsynVar = -1 Then
                        BT_R_Mission.Enabled = True
                        BT_A_Mission.Enabled = True
                        Bt_R.Enabled = True
                        BT_A.Enabled = True
                        ListView_Standby_Slave.Enabled = True
                        ReDim Preserve exceptionMsg(UBound(exceptionMsg) + 1)
                        exceptionMsg(UBound(exceptionMsg)) = "Error on add to sync for Bt_A_Click!"
                        If UBound(exceptionMsg) > -1 Then

                            Dim emsg As String = ""
                            For f = 0 To UBound(exceptionMsg)
                                emsg = emsg + CStr(f) + "." + exceptionMsg(f) + " "
                            Next
                            addToExBox(progress + "(Exception) " + emsg)


                        End If
                        Exit Sub
                    End If


                    Dim selectditem() As Array
                    ReDim selectditem(-1)
                    For i = 0 To ListView_Standby_Slave.SelectedItems.Count - 1
                        ReDim Preserve selectditem(UBound(selectditem) + 1)
                        selectditem(UBound(selectditem)) = {ListView_Standby_Slave.SelectedItems.Item(i)}

                    Next



                    For j = 0 To UBound(selectditem)

                        If Form_Main.CustomRemoteTestModel Then


                            Dim arrayBPTsSelected(-1) As String
                            For Each item In ListView_StandBy_TestMission.Items
                                If item.subitems.item(1).text = selectditem(j)(0).subitems.item(0).text Then
                                    ReDim Preserve arrayBPTsSelected(UBound(arrayBPTsSelected) + 1)
                                    arrayBPTsSelected(UBound(arrayBPTsSelected)) = item.subitems.item(0).text
                                End If
                            Next
                            If UBound(arrayBPTsSelected) > -1 Then
                                popMsgMethod(progress + "adding server information.")
                                Dim finditemB = False
                                For k = 0 To UBound(ExecutionOperator.arryServerFullyInfo)
                                    If IsNothing(ExecutionOperator.arryServerFullyInfo(k)) = False Then
                                        If selectditem(j)(0).subitems.item(0).text = ExecutionOperator.arryServerFullyInfo(k)(1) Then
                                            ExecutionOperator.arryServerFullyInfo(k)(2) = "disct"
                                            finditemB = True
                                            Exit For
                                        End If
                                    End If
                                Next
                                If finditemB Then
                                Else
                                    ReDim Preserve ExecutionOperator.arryServerFullyInfo(UBound(ExecutionOperator.arryServerFullyInfo) + 1)
                                    ExecutionOperator.arryServerFullyInfo(UBound(ExecutionOperator.arryServerFullyInfo)) = {selectditem(j)(0).subitems.item(1).text, selectditem(j)(0).subitems.item(0).text, "disct", Nothing, Nothing, False}
                                End If
                                popMsgMethod(progress + "updating Standby Slaves List.")

                                For Each item In ListView_Standby_Slave.Items
                                    If item.text = selectditem(j)(0).subitems.item(0).text Then
                                        ListView_Standby_Slave.Items.Remove(item)
                                        Exit For
                                    End If
                                Next

                                popMsgMethod(progress + "adding mission information.")

                                For hh = 0 To UBound(arrayBPTsSelected)
                                    ReDim Preserve ExecutionOperator.arryRunList(UBound(ExecutionOperator.arryRunList) + 1)
                                    ExecutionOperator.arryRunList(UBound(ExecutionOperator.arryRunList)) = {arrayBPTsSelected(hh), "ready", selectditem(j)(0).subitems.item(0).text, ""}

                                    ReDim Preserve Runlist_RunningMissionRelationShip(UBound(Runlist_RunningMissionRelationShip) + 1)
                                    Dim newItem As ListViewItem = Nothing
                                    Runlist_RunningMissionRelationShip(UBound(Runlist_RunningMissionRelationShip)) = {UBound(Runlist_RunningMissionRelationShip), newItem}
                                Next

                                popMsgMethod(progress + "updating Standby Test Mission List.")

                                For Each item In ListView_StandBy_TestMission.Items
                                    ListView_StandBy_TestMission.Items.Remove(selectditem(j)(0))
                                Next
                            Else
                                ReDim Preserve exceptionMsg(UBound(exceptionMsg) + 1)
                                exceptionMsg(UBound(exceptionMsg)) = "Cannot add slave """ + selectditem(j)(0).subitems.item(0).text + """ since no case is associated it!"
                            End If

                        Else
                            Dim finditemB = False
                            For k = 0 To UBound(ExecutionOperator.arryServerFullyInfo)
                                If IsNothing(ExecutionOperator.arryServerFullyInfo(k)) = False Then


                                    If selectditem(j)(0).subitems.item(0).text = ExecutionOperator.arryServerFullyInfo(k)(1) Then
                                        ExecutionOperator.arryServerFullyInfo(k)(2) = "disct"
                                        finditemB = True
                                        Exit For
                                    End If
                                End If
                            Next
                            If finditemB Then
                            Else
                                ReDim Preserve ExecutionOperator.arryServerFullyInfo(UBound(ExecutionOperator.arryServerFullyInfo) + 1)
                                ExecutionOperator.arryServerFullyInfo(UBound(ExecutionOperator.arryServerFullyInfo)) = {selectditem(j)(0).subitems.item(1).text, selectditem(j)(0).subitems.item(0).text, "disct", Nothing, Nothing, False}
                            End If
                            popMsgMethod(progress + "updating Standby Slaves List.")


                            ListView_Standby_Slave.Items.Remove(selectditem(j)(0))


                        End If
                    Next

                    tunnel(0) = False
                    popMsgMethod(progress + "done.")
                    BT_R_Mission.Enabled = True
                    BT_A_Mission.Enabled = True
                    Bt_R.Enabled = True
                    BT_A.Enabled = True
                    ListView_Standby_Slave.Enabled = True
                    If tunnel(1) = True Then
                        ReDim Preserve exceptionMsg(UBound(exceptionMsg) + 1)
                        exceptionMsg(UBound(exceptionMsg)) = "BT_A_Click thread is finished after time out of UFT remote main thread!"
                    End If

                    If UBound(exceptionMsg) > -1 Then

                        Dim emsg As String = ""
                        For f = 0 To UBound(exceptionMsg)
                            emsg = emsg + CStr(f) + "." + exceptionMsg(f) + " "
                        Next
                        addToExBox(progress + "(Exception) " + emsg)


                    End If
                End If
            Else
                MsgBox("You have not selected anything!")
            End If
        Else
            MsgBox("You cannot add until test mission starts!")
        End If
        Bt_Close.Enabled = True
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
    Public stopflag = 0
    Private Sub popMsgMethod(ByVal sender As String)

        If sender.Length > 0 Then
            sender = sender + " at " + CStr(Hour(Now)) + ":" + CStr(Minute(Now)) + ":" + CStr(Second(Now))
            L_ST.Text = sender
            L_ST.AutoSize = False
            L_ST.Width = 0
            L_ST.Height = 0
            L_ST.AutoSize = True
            L_ST.Visible = False
            L_St_Close.Visible = False
            If L_ST.Width + L_ST.Location.X > (Me.Width - 90) Then
                L_ST.AutoSize = False
                L_ST.Width = Me.Width - 90 - L_ST.Location.X
                L_ST.Height = 34
            Else
                Dim w = L_ST.Width
                Dim h = L_ST.Height
                L_ST.AutoSize = False
                L_ST.Width = w + 12
                L_ST.Height = h
                If L_ST.Width + L_ST.Location.X > (Me.Width - 90) Then
                    L_ST.Width = Me.Width - 90 - L_ST.Location.X
                    L_ST.Height = 34
                End If
            End If
            L_St_Close.Parent = L_ST
            L_St_Close.Location = New Point(L_ST.Width - L_St_Close.Width, 0)
            L_ST.Visible = True
            L_St_Close.Visible = True
            L_St_Close.BringToFront()
            Dim stx As Integer = L_ST.Location.X
            Dim sty As Integer = L_ST.Location.Y
            Dim cx As Integer = L_St_Close.Location.X
            Dim cy As Integer = L_St_Close.Location.Y
            Dim d = 2
            For mt = 1 To 2
                waitTime(30)
                L_ST.Location = New Point(stx, sty + d)
                L_St_Close.Location = New Point(cx, cy + d)
                waitTime(30)
                L_ST.Location = New Point(stx, sty)
                L_St_Close.Location = New Point(cx, cy)
                waitTime(30)
                L_ST.Location = New Point(stx, sty - d)
                L_St_Close.Location = New Point(cx, cy - d)
                waitTime(30)
                L_ST.Location = New Point(stx, sty)
                L_St_Close.Location = New Point(cx, cy)
            Next


        Else
            L_ST.Visible = False
            L_St_Close.Visible = False
        End If

    End Sub

    Private Sub L_St_Close_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles L_St_Close.Click
        L_ST.Text = ""
        L_ST.Visible = False
        L_St_Close.Visible = False
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bt_New.Click
        Dim item = ListView_Standby_Slave.Items.Add("")
        ListView_Standby_Slave.LabelEdit = True
        item.BeginEdit()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bt_Remove.Click
        If ListView_Standby_Slave.SelectedItems.Count > 0 Then
            Do
                Dim item = ListView_Standby_Slave.SelectedItems.Item(0)
                ListView_Standby_Slave.Items.Remove(item)
            Loop Until ListView_Standby_Slave.SelectedItems.Count = 0
        End If
    End Sub

    Private Sub ListView_Standby_AfterLabelEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.LabelEditEventArgs) Handles ListView_Standby_Slave.AfterLabelEdit
        Dim oListView_Standby = ListView_Standby_Slave.Enabled
        Dim oBT_A = BT_A.Enabled
        Dim oBt_R = Bt_R.Enabled
        Dim oBt_New = Bt_New.Enabled
        Dim oBt_Remove = Bt_Remove.Enabled

        Dim oListView_Standby_Mission = ListView_StandBy_TestMission.Enabled
        Dim oBT_A_Mission = BT_A_Mission.Enabled
        Dim oBt_R_Mission = BT_R_Mission.Enabled
        Dim oBt_New_Mission = BT_New_StandbyMission.Enabled
        Dim oBt_Remove_Mission = BT_R_StandbyMission.Enabled

        If e.Label = "" Then
            e.CancelEdit = True
            ListView_Standby_Slave.Items.RemoveAt(e.Item)
        Else
            ListView_Standby_Slave.Enabled = False
            BT_A.Enabled = False
            Bt_R.Enabled = False
            Bt_New.Enabled = False
            Bt_Remove.Enabled = False

            ListView_StandBy_TestMission.Enabled = False
            BT_A_Mission.Enabled = False
            BT_R_Mission.Enabled = False
            BT_New_StandbyMission.Enabled = False
            BT_R_StandbyMission.Enabled = False


            tempResPath = ""
            IsResCancel = -1

            If Form_Main.HostModel Then

                If e.Item = 0 Then
                    If ListView_SlaveInMission.Items.Count = 0 Then
                        P_ResPath.Visible = True
                        Do
                            Application.DoEvents()
                            waitTime(100)
                        Loop Until IsResCancel <> -1 Or Me.Visible = False
                    Else
                        IsResCancel = 0
                        tempResPath = ListView_SlaveInMission.Items.Item(0).SubItems.Item(2).Text
                    End If

                Else
                    IsResCancel = 0
                    tempResPath = ListView_Standby_Slave.Items.Item(0).SubItems.Item(1).Text
                End If
            Else

                P_ResPath.Visible = True
                Do
                    Application.DoEvents()
                    waitTime(100)
                Loop Until IsResCancel <> -1 Or Me.Visible = False
            End If

            If IsResCancel = 0 Then
                e.CancelEdit = False
                ListView_Standby_Slave.Items.Item(e.Item).SubItems.Add(Trim(tempResPath))
                If Form_Main.CustomRemoteTestModel Then
                    tempMission = Nothing
                    IsMissionCancel = -1
                    P_Mission.Visible = True
                    L_Mission_Tile.Text = "Must provide test mission for the new Slave " + e.Label + ":"
                    Do
                        Application.DoEvents()
                        waitTime(100)
                    Loop Until IsMissionCancel <> -1 Or Me.Visible = False
                    If IsMissionCancel = 0 Then
                        For Each line In tempMission.Lines
                            Dim newline = Trim(Replace(line, Chr(9), ""))
                            If newline <> "" Then
                                Dim newItem = ListView_StandBy_TestMission.Items.Add(newline)
                                newItem.SubItems.Add(e.Label)
                            End If
                        Next
                    Else
                        e.CancelEdit = True
                        ListView_Standby_Slave.Items.RemoveAt(e.Item)
                    End If
                End If

            Else
                e.CancelEdit = True
                ListView_Standby_Slave.Items.RemoveAt(e.Item)
            End If
        End If
        ListView_Standby_Slave.Enabled = oListView_Standby
        BT_A.Enabled = oBT_A
        Bt_R.Enabled = oBt_R
        Bt_New.Enabled = oBt_New
        Bt_Remove.Enabled = oBt_Remove

        ListView_StandBy_TestMission.Enabled = oListView_Standby_Mission
        BT_A_Mission.Enabled = oBT_A_Mission
        BT_R_Mission.Enabled = oBt_R_Mission
        BT_New_StandbyMission.Enabled = oBt_New_Mission
        BT_R_StandbyMission.Enabled = oBt_Remove_Mission
        ListView_Standby_Slave.LabelEdit = False

    End Sub
    Public tempResPath As String = ""
    Public IsResCancel As Integer = -1
    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bt_OK.Click
        Dim newline = Trim(Replace(TB_ResPath.Text, Chr(9), ""))
        If newline <> "" Then
            tempResPath = newline
            IsResCancel = 0
            P_ResPath.Visible = False
        End If

    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bt_Cancel.Click
        IsResCancel = 1
        P_ResPath.Visible = False

    End Sub

    Public tempMission As TextBox = Nothing
    Public IsMissionCancel As Integer = -1

    Private Sub Bt_Ok_Mission_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bt_Ok_Mission.Click

        If Trim(TB_Mission.Text) = "" Then
        Else
            tempMission = TB_Mission
            IsMissionCancel = 0
            P_Mission.Visible = False
        End If


    End Sub

    Private Sub Bt_Cancel_Mission_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bt_Cancel_Mission.Click
        IsMissionCancel = 1
        P_Mission.Visible = False
    End Sub

    Private Sub Button2_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_New_StandbyMission.Click
        'Dim item = ListView_StandBy_Mission.Items.Add("")
        'ListView_StandBy_Mission.LabelEdit = True
        'item.BeginEdit()
        Dim oListView_Standby = ListView_Standby_Slave.Enabled
        Dim oBT_A = BT_A.Enabled
        Dim oBt_R = Bt_R.Enabled
        Dim oBt_New = Bt_New.Enabled
        Dim oBt_Remove = Bt_Remove.Enabled

        Dim oListView_Standby_Mission = ListView_StandBy_TestMission.Enabled
        Dim oBT_A_Mission = BT_A_Mission.Enabled
        Dim oBt_R_Mission = BT_R_Mission.Enabled
        Dim oBt_New_Mission = BT_New_StandbyMission.Enabled
        Dim oBt_Remove_Mission = BT_R_StandbyMission.Enabled

        BT_A.Enabled = False
        Bt_R.Enabled = False
        Bt_New.Enabled = False
        Bt_Remove.Enabled = False

        ListView_StandBy_TestMission.Enabled = False
        BT_A_Mission.Enabled = False
        BT_R_Mission.Enabled = False
        BT_New_StandbyMission.Enabled = False
        BT_R_StandbyMission.Enabled = False

        If Form_Main.CustomRemoteTestModel Then
            tempNewMission = Nothing
            IsNewMissionCancel = -1
            P_NewMission.Show()
            Do
                Application.DoEvents()
                waitTime(100)
            Loop Until IsNewMissionCancel <> -1 Or Me.Visible = False
            If IsNewMissionCancel = 0 Then
                tempMUSTIP = ""
                IsMUSTIPCancel = -1
                P_MustIP.Visible = True

                Do
                    Application.DoEvents()
                    waitTime(100)
                Loop Until IsMUSTIPCancel <> -1 Or Me.Visible = False
                If IsMUSTIPCancel = 0 Then
                    For Each line In tempNewMission.Lines
                        Dim newline = Trim(Replace(line, Chr(9), ""))
                        If newline <> "" Then
                            Dim newItem = ListView_StandBy_TestMission.Items.Add(newline)
                            newItem.SubItems.Add(Trim(tempMUSTIP))
                        End If

                    Next
                End If
            End If

        Else
            tempNewMission = Nothing
            IsNewMissionCancel = -1
            P_NewMission.Show()
            Do
                Application.DoEvents()
                waitTime(100)
            Loop Until IsNewMissionCancel <> -1 Or Me.Visible = False
            If IsNewMissionCancel = 0 Then
                For Each line In tempNewMission.Lines
                    If Trim(line) <> "" Then
                        Dim newItem = ListView_StandBy_TestMission.Items.Add(line)
                        If Form_Main.LocalRunModel Then
                            newItem.SubItems.Add("Local")
                        Else
                            newItem.SubItems.Add("Not Assigned")
                        End If

                    End If

                Next
            End If
        End If




        ListView_Standby_Slave.Enabled = oListView_Standby
        BT_A.Enabled = oBT_A
        Bt_R.Enabled = oBt_R
        Bt_New.Enabled = oBt_New
        Bt_Remove.Enabled = oBt_Remove

        ListView_StandBy_TestMission.Enabled = oListView_Standby_Mission
        BT_A_Mission.Enabled = oBT_A_Mission
        BT_R_Mission.Enabled = oBt_R_Mission
        BT_New_StandbyMission.Enabled = oBt_New_Mission
        BT_R_StandbyMission.Enabled = oBt_Remove_Mission

    End Sub

    Private Sub Button1_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_R_StandbyMission.Click
        If ListView_StandBy_TestMission.SelectedItems.Count > 0 Then
            Do
                Dim item = ListView_StandBy_TestMission.SelectedItems.Item(0)
                ListView_StandBy_TestMission.Items.Remove(item)
            Loop Until ListView_StandBy_TestMission.SelectedItems.Count = 0
        End If
    End Sub

    Public tempMUSTIP As String = ""
    Public IsMUSTIPCancel As Integer = -1
    Private Sub Button2_Click_3(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_OK_MustIP.Click
        Dim newline = Trim(Replace(TB_IP.Text, Chr(9), ""))
        If newline <> "" Then
            tempMUSTIP = newline
            IsMUSTIPCancel = 0
            P_MustIP.Visible = False
        End If

    End Sub

    Private Sub Button1_Click_3(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Cancel_MustIP.Click
        IsMUSTIPCancel = 1
        P_MustIP.Visible = False
    End Sub

    Private Sub BT_A_Mission_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_A_Mission.Click
        Bt_Close.Enabled = False

        If IsNothing(ExecutionOperator.arryRunList) = False Then


            If ListView_StandBy_TestMission.SelectedItems.Count > 0 Then
                Me.Enabled = False
                Dim res = MsgBox("Add selected test mission?", MsgBoxStyle.YesNo)
                Me.Enabled = True
                Dim exceptionMsg(-1) As String
                Dim progress = "Progress: "
                If res = MsgBoxResult.Yes Then
                    BT_R_Mission.Enabled = False
                    BT_A_Mission.Enabled = False
                    Bt_R.Enabled = False
                    BT_A.Enabled = False
                    ListView_StandBy_TestMission.Enabled = False
                    Dim request = True
                    Dim response = False
                    ReDim tunnel(1)
                    tunnel = {request, response}

                    popMsgMethod(progress + "waiting to access mission resource.")
                    Dim threadIndexInsynVar = -1
                    If Form_Main.CB_Servers.Checked Then
                        If Form_Main.CB_CRT.Checked And Form_Main.CB_Servers.Checked Then

                            threadIndexInsynVar = AddtoSync(ExecutionOperator.syncStatusOfCustomRemote, ExecutionOperator.synchroPointSTOfCustomRemote, ExecutionOperator.syncStatusLockOfCustomRemote, tunnel)
                        Else

                            threadIndexInsynVar = AddtoSync(ExecutionOperator.syncStatusOfRemote, ExecutionOperator.synchroPointSTOfRemote, ExecutionOperator.syncStatusLockOfRemote, tunnel)

                        End If
                    Else
                        threadIndexInsynVar = AddtoSync(ExecutionOperator.syncStatusOfLocal, ExecutionOperator.synchroPointSTOfLocal, ExecutionOperator.syncStatusLockOfLocal, tunnel)
                    End If


                    If threadIndexInsynVar = -1 Then

                        BT_R_Mission.Enabled = True
                        BT_A_Mission.Enabled = True
                        Bt_R.Enabled = True
                        BT_A.Enabled = True
                        ListView_StandBy_TestMission.Enabled = True
                        ReDim Preserve exceptionMsg(UBound(exceptionMsg) + 1)
                        exceptionMsg(UBound(exceptionMsg)) = "Error on add to sync for BT_A_Mission_Click!"
                        If UBound(exceptionMsg) > -1 Then

                            Dim emsg As String = ""
                            For f = 0 To UBound(exceptionMsg)
                                emsg = emsg + CStr(f) + "." + exceptionMsg(f) + " "
                            Next
                            addToExBox(progress + "(Exception) " + emsg)


                        End If
                        Exit Sub
                    End If


                    Dim selectditem() As Array
                    ReDim selectditem(-1)
                    For i = 0 To ListView_StandBy_TestMission.SelectedItems.Count - 1
                        ReDim Preserve selectditem(UBound(selectditem) + 1)
                        selectditem(UBound(selectditem)) = {ListView_StandBy_TestMission.SelectedItems.Item(i)}

                    Next


                    popMsgMethod(progress + "adding mission information.")
                    'For j = 0 To UBound(selectditem)

                    '    For k = 0 To UBound(UFTOperator.arryRunList)
                    '        If IsNothing(UFTOperator.arryRunList(k)) = False Then
                    '            If selectditem(j)(0) = UFTOperator.arryRunList(k)(0) And selectditem(j)(1) = UFTOperator.arryRunList(k)(2) Then
                    '                Array.Clear(UFTOperator.arryRunList, k, 1)
                    '                'ReDim Preserve exceptionMsg(UBound(exceptionMsg) + 1)
                    '                'exceptionMsg(UBound(exceptionMsg)) = selectditem(j)(0) + " is already in Running Test Mission list!"
                    '                ReDim Preserve UFTOperator.arryRunList(UBound(UFTOperator.arryRunList) + 1)
                    '                UFTOperator.arryRunList(UBound(UFTOperator.arryRunList)) = {selectditem(j)(0), "ready", selectditem(j)(1)}

                    '                Exit For
                    '            End If
                    '        End If
                    '    Next
                    'Next
                    For j = 0 To UBound(selectditem)
                        ReDim Preserve ExecutionOperator.arryRunList(UBound(ExecutionOperator.arryRunList) + 1)
                        ExecutionOperator.arryRunList(UBound(ExecutionOperator.arryRunList)) = {selectditem(j)(0).subitems.item(0).text, "ready", selectditem(j)(0).subitems.item(1).text, ""}
                        ReDim Preserve Runlist_RunningMissionRelationShip(UBound(Runlist_RunningMissionRelationShip) + 1)
                        Dim newItem As ListViewItem = Nothing
                        Runlist_RunningMissionRelationShip(UBound(Runlist_RunningMissionRelationShip)) = {UBound(Runlist_RunningMissionRelationShip), newItem}
                    Next
                    popMsgMethod(progress + "updating Standby Test Mission List.")
                    For i = 0 To UBound(selectditem)
                        ListView_StandBy_TestMission.Items.Remove(selectditem(i)(0))
                    Next




                    tunnel(0) = False
                    popMsgMethod(progress + "done.")
                    Bt_R.Enabled = True
                    BT_A.Enabled = True
                    BT_R_Mission.Enabled = True
                    BT_A_Mission.Enabled = True
                    ListView_StandBy_TestMission.Enabled = True
                    If tunnel(1) = True Then
                        ReDim Preserve exceptionMsg(UBound(exceptionMsg) + 1)
                        exceptionMsg(UBound(exceptionMsg)) = "BT_A_Mission_Click thread is finished after time out of UFT remote main thread!"
                    End If

                    If UBound(exceptionMsg) > -1 Then

                        Dim emsg As String = ""
                        For f = 0 To UBound(exceptionMsg)
                            emsg = emsg + CStr(f) + "." + exceptionMsg(f) + " "
                        Next
                        addToExBox(progress + "(Exception) " + emsg)


                    End If

                End If
            Else
                MsgBox("You have not selected anything!")
            End If
        Else
            MsgBox("You cannot add until test mission starts!")
        End If
        Bt_Close.Enabled = True
    End Sub

    'Private Sub BT_A_MissionEnabledChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles BT_A_Mission.EnabledChanged
    '    If BT_A_Mission.Enabled Then
    '        BT_A_Mission.BackColor = Color.MediumSeaGreen
    '    Else
    '        BT_A_Mission.BackColor = Color.DarkGray
    '    End If
    'End Sub

    'Private Sub BT_R_MissionEnabledChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles BT_R_Mission.EnabledChanged
    '    If BT_R_Mission.Enabled Then
    '        BT_R_Mission.BackColor = Color.MediumSeaGreen
    '    Else
    '        BT_R_Mission.BackColor = Color.DarkGray
    '    End If
    'End Sub

    Private Sub BT_R_Mission_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_R_Mission.Click
        Bt_Close.Enabled = False

        If ListView_TestInMission.SelectedItems.Count > 0 Then
            Me.Enabled = False
            Dim res = MsgBox("Remove selected test mission?", MsgBoxStyle.YesNo)
            Me.Enabled = True
            Dim progress = "Progress: "
            If res = MsgBoxResult.Yes Then
                Dim exceptionMsg(-1) As String
                Bt_R.Enabled = False
                BT_A.Enabled = False
                BT_R_Mission.Enabled = False
                BT_A_Mission.Enabled = False
                ListView_TestInMission.Enabled = False
                Dim request = True
                Dim response = False
                ReDim tunnel(1)
                tunnel = {request, response}

                popMsgMethod(progress + "waiting to access mission resource.")
                Dim threadIndexInsynVar = -1
                If Form_Main.CB_Servers.Checked Then
                    If Form_Main.CB_CRT.Checked And Form_Main.CB_Servers.Checked Then

                        threadIndexInsynVar = AddtoSync(ExecutionOperator.syncStatusOfCustomRemote, ExecutionOperator.synchroPointSTOfCustomRemote, ExecutionOperator.syncStatusLockOfCustomRemote, tunnel)
                    Else

                        threadIndexInsynVar = AddtoSync(ExecutionOperator.syncStatusOfRemote, ExecutionOperator.synchroPointSTOfRemote, ExecutionOperator.syncStatusLockOfRemote, tunnel)

                    End If
                Else
                    threadIndexInsynVar = AddtoSync(ExecutionOperator.syncStatusOfLocal, ExecutionOperator.synchroPointSTOfLocal, ExecutionOperator.syncStatusLockOfLocal, tunnel)
                End If


                If threadIndexInsynVar = -1 Then
                    Bt_R.Enabled = True
                    BT_A.Enabled = True
                    BT_R_Mission.Enabled = True
                    BT_A_Mission.Enabled = True
                    ListView_TestInMission.Enabled = True
                    ReDim Preserve exceptionMsg(UBound(exceptionMsg) + 1)
                    exceptionMsg(UBound(exceptionMsg)) = "Error on add to sync for BT_R_Mission_Click!"
                    If UBound(exceptionMsg) > -1 Then

                        Dim emsg As String = ""
                        For f = 0 To UBound(exceptionMsg)
                            emsg = emsg + CStr(f) + "." + exceptionMsg(f) + " "
                        Next
                        addToExBox(progress + "(Exception) " + emsg)


                    End If
                    Exit Sub
                End If


                Dim selectditem() As Array
                ReDim selectditem(-1)
                popMsgMethod(progress + "updating mission information.")
                For Each item In ListView_TestInMission.SelectedItems

                    Dim finditemB = False
                    Dim assignServer = ""
                    For k = 0 To UBound(ExecutionOperator.arryRunList)
                        If IsNothing(ExecutionOperator.arryRunList(k)) = False Then
                            If item.SubItems.Item(0).Text = ExecutionOperator.arryRunList(k)(0) Then
                                If ExecutionOperator.arryRunList(k)(1) <> "run" Then
                                    Array.Clear(ExecutionOperator.arryRunList, k, 1)
                                    finditemB = True
                                    Exit For
                                Else
                                    assignServer = ExecutionOperator.arryRunList(k)(2)
                                    Exit For
                                End If
                            End If

                        End If
                    Next
                    If finditemB = False Then
                        ReDim Preserve exceptionMsg(UBound(exceptionMsg) + 1)
                        exceptionMsg(UBound(exceptionMsg)) = item.SubItems.Item(0).Text + " has been assigned to slave """ + assignServer + """!"
                    Else
                        ReDim Preserve selectditem(UBound(selectditem) + 1)
                        selectditem(UBound(selectditem)) = {item}
                        popMsgMethod(progress + "updating Running Test Mission List.")
                        ListView_TestInMission.Items.Remove(item)
                    End If

                Next

                If UBound(selectditem) > -1 Then
                    For i = 0 To UBound(selectditem)
                        popMsgMethod(progress + "updating Standby Test Mission List.")
                        Dim newItem = ListView_StandBy_TestMission.Items.Add(selectditem(i)(0).SubItems.Item(0).Text)

                        If Form_Main.CustomRemoteTestModel Then
                            newItem.SubItems.Add(selectditem(i)(0).SubItems.Item(1).Text)
                        Else
                            newItem.SubItems.Add("Not Assigned")
                        End If



                    Next
                End If

                tunnel(0) = False
                popMsgMethod(progress + "done.")
                Bt_R.Enabled = True
                BT_A.Enabled = True
                BT_R_Mission.Enabled = True
                BT_A_Mission.Enabled = True
                ListView_TestInMission.Enabled = True
                If tunnel(1) = True Then
                    ReDim Preserve exceptionMsg(UBound(exceptionMsg) + 1)
                    exceptionMsg(UBound(exceptionMsg)) = "BT_R_Mission_Click thread is finished after time out of UFT remote main thread!"
                End If

                If UBound(exceptionMsg) > -1 Then

                    Dim emsg As String = ""
                    For f = 0 To UBound(exceptionMsg)
                        emsg = emsg + CStr(f) + "." + exceptionMsg(f) + " "
                    Next
                    addToExBox(progress + "(Exception) " + emsg)


                End If
            End If
        Else
            MsgBox("You have not selected anything!")
        End If
        Bt_Close.Enabled = True
    End Sub

    Private Sub P_Mission_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles P_Mission.VisibleChanged
        If P_Mission.Visible Then
            P_Mission.Location = New Point(Me.ListView_Standby_Slave.Location.X + 20, Me.ListView_Standby_Slave.Location.Y + 10)
        End If
    End Sub

    Private Sub P_ResPath_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles P_ResPath.VisibleChanged
        If P_ResPath.Visible Then
            P_ResPath.Location = New Point(Me.ListView_Standby_Slave.Location.X + 20, Me.ListView_Standby_Slave.Location.Y + 10)
        End If
    End Sub

    Private Sub P_MustIP_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles P_MustIP.VisibleChanged
        If P_MustIP.Visible Then
            P_MustIP.Location = New Point(Me.ListView_StandBy_TestMission.Location.X + 20, Me.ListView_StandBy_TestMission.Location.Y + 10)
        End If
    End Sub

    Public tempNewMission As TextBox = Nothing
    Public IsNewMissionCancel As Integer = -1
    Private Sub Bt_P_NewMission_OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bt_P_NewMission_OK.Click
        If Trim(TB_NewMission.Text) = "" Then
        Else
            tempNewMission = TB_NewMission
            IsNewMissionCancel = 0
            P_NewMission.Visible = False
        End If
    End Sub

    Private Sub Bt_P_NewMission_Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bt_P_NewMission_Cancel.Click
        IsNewMissionCancel = 1
        P_NewMission.Visible = False
    End Sub

    Private Sub P_NewMission_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles P_NewMission.VisibleChanged
        If P_NewMission.Visible Then
            P_NewMission.Location = New Point(Me.Bt_Remove.Location.X + 20, Me.Bt_Remove.Location.Y + 10)
        End If
    End Sub

    Sub addToExBox(ByVal m As String)
        L_Link_ExBox.Show()
        L_NewExMsg.Show()
        L_Link_ExBox.LinkVisited = False
        Form_ExMsgBox.TB_ExBox.AppendText(CStr(Now) + ": " + m + vbCrLf)
    End Sub

    Private Sub ListView_StandBy_Mission_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles ListView_StandBy_TestMission.ColumnClick

        Dim Sorter = New ListViewSorter(e.Column, SortOrder.Ascending)
        ListView_StandBy_TestMission.ListViewItemSorter = Sorter

    End Sub


    Private Sub ListView_InMission_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles ListView_SlaveInMission.ColumnClick
        Dim Sorter = New ListViewSorter(e.Column, SortOrder.Ascending)
        ListView_SlaveInMission.ListViewItemSorter = Sorter
    End Sub

    Private Sub ListView_MIssionList_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles ListView_TestInMission.ColumnClick
        Dim Sorter = New ListViewSorter(e.Column, SortOrder.Ascending)
        ListView_TestInMission.ListViewItemSorter = Sorter
    End Sub

    Private Sub ListView_Standby_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles ListView_Standby_Slave.ColumnClick
        Dim Sorter = New ListViewSorter(e.Column, SortOrder.Ascending)
        ListView_Standby_Slave.ListViewItemSorter = Sorter
    End Sub

    Private Sub Bt_ExBox_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles L_Link_ExBox.LinkClicked
        L_Link_ExBox.LinkVisited = True
        Form_ExMsgBox.Location = Me.PointToScreen(New Point(Me.BT_TopBar.Location.X + 30, Me.BT_TopBar.Location.Y + 30))
        Form_ExMsgBox.Show()
        L_NewExMsg.Hide()
    End Sub

    Private Sub L_NewExMsg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles L_NewExMsg.Click

        Form_ExMsgBox.Location = Me.PointToScreen(New Point(Me.BT_TopBar.Location.X + 30, Me.BT_TopBar.Location.Y + 30))
        Form_ExMsgBox.Show()
        L_NewExMsg.Hide()
    End Sub

    Private Sub BT_SlaveRD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_SlaveRD.Click
        Dim cur = ListView_Standby_Slave.Items
        Dim total = cur.Count
        Dim items As Integer = 0
        If total <= 0 Then
            MsgBox("No duplicate Slave found.")
        Else
            Dim i = 0
            Do While i < total - 1
                If i + 1 > total - 1 Then
                Else
                    Dim j = i + 1
                    Do While j < total
                        If cur.Item(i).SubItems.Item(0).Text = cur.Item(j).SubItems.Item(0).Text And cur.Item(i).SubItems.Item(1).Text = cur.Item(j).SubItems.Item(1).Text Then
                            items = items + 1

                            cur.Remove(cur.Item(j))
                        Else
                            j = j + 1
                        End If

                        total = cur.Count
                    Loop
                End If
                i = i + 1
                total = cur.Count
            Loop


            If items > 0 Then
                MsgBox("Found and removed " + CStr(items) + " duplicate Slave.")
            Else
                MsgBox("No duplicate Slave found.")
            End If


        End If
    End Sub

    Private Sub BT_MissionRD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_MissionRD.Click
        Dim cur = ListView_StandBy_TestMission.Items
        Dim total = cur.Count
        Dim items As Integer = 0
        If total <= 0 Then
            MsgBox("No duplicate Mission found.")
        Else
            Dim i = 0
            Do While i < total - 1
                If i + 1 > total - 1 Then
                Else
                    Dim j = i + 1
                    Do While j < total
                        If cur.Item(i).SubItems.Item(0).Text = cur.Item(j).SubItems.Item(0).Text And cur.Item(i).SubItems.Item(1).Text = cur.Item(j).SubItems.Item(1).Text Then
                            items = items + 1

                            cur.Remove(cur.Item(j))
                        Else
                            j = j + 1
                        End If

                        total = cur.Count
                    Loop
                End If
                i = i + 1
                total = cur.Count
            Loop


            If items > 0 Then
                MsgBox("Found and removed " + CStr(items) + " duplicate Mission.")
            Else
                MsgBox("No duplicate Mission found.")
            End If


        End If
    End Sub

    Private Sub BT_Min_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Min.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Public tempItem As ListViewItem.ListViewSubItem
    Private Sub ListView_Standby_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListView_Standby_Slave.MouseDoubleClick

        Dim newMP = ListView_Standby_Slave.PointToClient(Form_RunMgmt.MousePosition)
        Dim mainItem = ListView_Standby_Slave.GetItemAt(newMP.X, newMP.Y)
        Dim subItem = mainItem.GetSubItemAt(newMP.X, newMP.Y)
        If Form_Main.HostModel Then
            If subItem.Bounds.X = 0 Then
                tempItem = subItem
                Dim TextBox = New TextBox
                TextBox.Parent = ListView_Standby_Slave
                AddHandler TextBox.LostFocus, AddressOf LostFocusOfTempText
                TextBox.Size = New Size(ListView_Standby_Slave.Columns.Item(0).Width, subItem.Bounds.Height)
                TextBox.Location = New Point(subItem.Bounds.X, subItem.Bounds.Y)
                TextBox.Text = subItem.Text
                TextBox.Show()
                TextBox.BringToFront()
                TextBox.Focus()
                TextBox.SelectionStart = TextBox.Text.Length
            End If
        Else
            tempItem = subItem
            Dim TextBox = New TextBox
            TextBox.Parent = ListView_Standby_Slave
            AddHandler TextBox.LostFocus, AddressOf LostFocusOfTempText
            If subItem.Bounds.X = 0 Then
                TextBox.Size = New Size(ListView_Standby_Slave.Columns.Item(0).Width, subItem.Bounds.Height)
            Else
                TextBox.Size = New Size(subItem.Bounds.Width, subItem.Bounds.Height)
            End If
            TextBox.Location = New Point(subItem.Bounds.X, subItem.Bounds.Y)
            TextBox.Text = subItem.Text
            TextBox.Show()
            TextBox.BringToFront()
            TextBox.Focus()
            TextBox.SelectionStart = TextBox.Text.Length

        End If
    End Sub
    Sub LostFocusOfTempText(ByVal sender As Object, ByVal e As EventArgs)
        sender.hide()
        tempItem.Text = sender.text
    End Sub

    Private Sub Panel1_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel1.MouseClick
        Panel1.Focus()
    End Sub

    Private Sub ListView_StandBy_Mission_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListView_StandBy_TestMission.MouseDoubleClick
        Dim newMP = ListView_StandBy_TestMission.PointToClient(Form_RunMgmt.MousePosition)
        Dim mainItem = ListView_StandBy_TestMission.GetItemAt(newMP.X, newMP.Y)
        Dim subItem = mainItem.GetSubItemAt(newMP.X, newMP.Y)
        If Form_Main.CustomRemoteTestModel Then
            tempItem = subItem
            Dim TextBox = New TextBox
            TextBox.Parent = ListView_StandBy_TestMission
            AddHandler TextBox.LostFocus, AddressOf LostFocusOfTempText

            If subItem.Bounds.X = 0 Then
                TextBox.Size = New Size(ListView_Standby_Slave.Columns.Item(0).Width, subItem.Bounds.Height)
            Else
                TextBox.Size = New Size(subItem.Bounds.Width, subItem.Bounds.Height)
            End If
            TextBox.Location = New Point(subItem.Bounds.X, subItem.Bounds.Y)
            TextBox.Text = subItem.Text
            TextBox.Show()
            TextBox.BringToFront()
            TextBox.Focus()
            TextBox.SelectionStart = TextBox.Text.Length
        Else
            If subItem.Bounds.X = 0 Then
                tempItem = subItem
                Dim TextBox = New TextBox
                TextBox.Parent = ListView_StandBy_TestMission
                AddHandler TextBox.LostFocus, AddressOf LostFocusOfTempText
                TextBox.Size = New Size(ListView_Standby_Slave.Columns.Item(0).Width, subItem.Bounds.Height)
                TextBox.Location = New Point(subItem.Bounds.X, subItem.Bounds.Y)
                TextBox.Text = subItem.Text
                TextBox.Show()
                TextBox.BringToFront()
                TextBox.Focus()
                TextBox.SelectionStart = TextBox.Text.Length
            End If

        End If
    End Sub

    Private Sub Form_SlaveManager_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        BT_TopBar.Width = Me.Width - 2 - BT_TopBar.Location.X
        Bt_Close.Parent = BT_TopBar
        BT_Min.Parent = BT_TopBar
    End Sub
End Class