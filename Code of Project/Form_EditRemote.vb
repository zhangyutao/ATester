Imports System.Threading
Imports System.Text
Imports System.Net

Public Class Form_EditRemote
    Public L_TopBar_mousedownVar As Boolean = False
    Public curMousePosOnL_TopBar As Point = Nothing
    Public myContent As String
    Public editBoxName As String
    Public netpathSTGood = -1
    Public IsFormClosing = 0



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

    Private Sub Form_Main_EnabledChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.EnabledChanged
        If Me.Enabled Then
            BT_TopBar.BackColor = GetVbColor(My.Resources.TopbarBackColor_Enabled)
            BT_TopBar.ForeColor = GetVbColor(My.Resources.TopbarForeColor_Enabled)
        Else
            BT_TopBar.BackColor = GetVbColor(My.Resources.TopbarBackColor_Disabled)
            BT_TopBar.ForeColor = GetVbColor(My.Resources.TopbarForeColor_Disabled)

        End If

    End Sub

    Private Sub Form_Edit_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        IsFormClosing = 1
    End Sub

    Private Sub Form_EditRemote_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'BT_TopBar.Parent = Me
        BT_TopBar.Width = Me.Width - 1 - BT_TopBar.Location.X
        Bt_close_editRemoteRes.Parent = BT_TopBar
        Bt_close_editRemoteRes.Location = New Point(BT_TopBar.Width - Bt_close_editRemoteRes.Width - 1, 0)
        'Bt_close_editRemoteRes.BringToFront()
    End Sub



    Private Sub Form_MoreRemoteSetting_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.VisibleChanged
        If Me.Visible = True Then
            Me.Location = Form_Main.PointToScreen(New Point(Form_Main.ToolStrip.Location.X, Form_Main.ToolStrip.Location.Y))
        End If

    End Sub

    Private Sub Bt_Remove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bt_Remove.Click
        If LB_Content.CheckedItems.Count > 0 Then
            Do
                Dim item = LB_Content.CheckedItems.Item(0)
                LB_Content.Items.Remove(item)
            Loop Until LB_Content.CheckedItems.Count = 0
        End If
    End Sub

    Private Sub Bt_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bt_Save.Click
        Dim findRed = False
        For Each item In LB_Content.Items

            If item.ForeColor = Color.Red Then
                findRed = True
                Exit For
            End If

        Next
        Dim result As Object
        Dim continued = False
        If findRed Then
            result = MsgBox("The item which status is in red color will be removed automatically. Would you like to continue?", MsgBoxStyle.YesNo)
            If result = MsgBoxResult.Yes Then
                continued = True
            Else
                continued = False
            End If
        Else
            continued = True
        End If

        If continued Then
            If LB_Content.Items.Count > 0 Then

                If LB_Content.Items.Count > 0 Then
                    Dim content = ""
                    For Each item In LB_Content.Items
                        If Trim(item.SubItems.Item(1).Text) = "" Then
                            content = content + "@" + item.Text()
                        End If

                    Next
                    If content <> "" Then
                        myContent = content.Substring(1)
                    Else
                        myContent = ""
                    End If

                Else
                    myContent = ""
                End If

            Else
                myContent = ""
            End If

            Me.Close()
        End If
    End Sub

    Private Sub Bt_New_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bt_New.Click
        If editBoxName = "hostres" Then
            If LB_Content.Items.Count >= 1 Then
                MsgBox("You should only use one Host.")
                Exit Sub
            End If
        End If

        Dim item = LB_Content.Items.Add("")
        item.BeginEdit()

    End Sub



    'Private Sub LB_Content_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles LB_Content.MouseClick
    '    If LB_Content.Items.Count > 0 Then
    '        For Each item In LB_Content.Items
    '            If item.subitems.item(0) = "" Then
    '                LB_Content.Items.Remove(item)
    '            End If
    '        Next
    '    End If
    'End Sub

    Private Sub Bt__close_editRemoteRes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bt_close_editRemoteRes.Click
        Me.Close()
    End Sub


    Private Sub LB_Content_AfterLabelEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.LabelEditEventArgs) Handles LB_Content.AfterLabelEdit
        Dim temp = e.Label
        If IsNothing(temp) Then
            If LB_Content.Items.Item(e.Item).Text <> "" Then
                Exit Sub
            End If
        End If

        Dim status = ""
        If temp <> "" Then
            If LB_Content.Items.Item(e.Item).Text <> temp Then


                If LB_Content.Items.Item(e.Item).SubItems.Count > 1 Then
                    Do While LB_Content.Items.Item(e.Item).SubItems.Count > 1
                        LB_Content.Items.Item(e.Item).SubItems.RemoveAt(LB_Content.Items.Item(e.Item).SubItems.Count - 1)
                    Loop
                End If


                If LB_Content.Items.Count > 1 Then
                    Dim findsame = False
                    For i = 0 To LB_Content.Items.Count - 1
                        If temp = LB_Content.Items.Item(i).Text Then
                            findsame = True
                            Exit For
                        End If
                    Next
                    If findsame Then
                        status = "Duplicated"
                        GoTo Nullline
                    End If

                End If

                Select Case editBoxName
                    Case "ip"
                        If RegularExpressions.Regex.IsMatch(temp, "\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}") Then
                            Dim matchedItems = RegularExpressions.Regex.Matches(temp, "\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}")
                            If matchedItems.Count = 1 Then
                                Dim ipr = temp.Replace(matchedItems(0).ToString(), "")
                                If Trim(ipr).Equals("") Then
                                    Dim positionArray = Split(temp, ".")
                                    For Each position In positionArray
                                        If Len(position) > 1 Then

                                            If RegularExpressions.Regex.IsMatch(position, "^0") Then
                                                MsgBox("IP  """ + temp + """ should not start with 0!")
                                                status = "Wrong format"
                                                GoTo EndLine
                                            End If
                                        End If

                                        If CInt(position) > 255 Then
                                            MsgBox("IP " + temp + " 's node length should not be bigger than 255")
                                            status = "Wrong format"
                                            GoTo EndLine
                                        End If
                                    Next
                                Else
                                    MsgBox("IP  """ + temp + """ is not a valid IP address!")
                                    status = "Wrong format"
                                    GoTo EndLine
                                End If
                            Else
                                MsgBox("IP """ + temp + """ is not a valid IP address!")
                                status = "Wrong format"
                                GoTo EndLine
                            End If
                        Else
                            MsgBox("IP  """ + temp + """ is not a valid IP address!")
                            status = "Wrong format"
                            GoTo EndLine
                        End If
                        Dim errornumber = 0
                        On Error Resume Next
                        Dim w = IPAddress.Parse(temp)
                        errornumber = Err.Number
                        On Error GoTo 0
                        If errornumber <> 0 Then
                            MsgBox("IP  """ + temp + """ is not a valid IP address!")
                            status = "Wrong format"
                            GoTo EndLine
                        End If
                        MsgBox("For checking UFT on the """ + temp + """, please go to ""Check Remote Slave Status"" feature!")
                    Case "hostres", "res"
                        If temp.Length > 2 Then
                        Else
                            MsgBox("The path must start with ""\\""")
                            status = "Wrong format"
                            GoTo EndLine
                        End If
                        If Mid(temp, 1, 2) = "\\" Then 'must be the network path
                        Else
                            MsgBox("The path must start with ""\\""")
                            status = "Wrong format"
                            GoTo EndLine
                        End If
                        Dim checkNetwork As New Thread(AddressOf checkNetworkFolder)
                        L_ST.Visible = True
                        L_ST.Text = "Checking pathes' accessablility, please standby!"

                        Me.Bt_New.Enabled = False
                        Me.Bt_Remove.Enabled = False
                        Me.Bt_close_editRemoteRes.Enabled = False
                        Me.Bt_Save.Enabled = False
                        LB_Content.Enabled = False
                        checkNetwork.Start(temp)
                        Do Until netpathSTGood <> -1
                            Application.DoEvents()
                            waitTime(1000)
                        Loop
                        Dim st1 = netpathSTGood
                        netpathSTGood = -1
                        Me.Bt_New.Enabled = True
                        Me.Bt_Remove.Enabled = True
                        Me.Bt_close_editRemoteRes.Enabled = True
                        Me.Bt_Save.Enabled = True
                        LB_Content.Enabled = True
                        L_ST.Visible = False
                        If st1 = 1 Then
                            If editBoxName = "res" Then
                                MsgBox("For checking UFT on the """ + temp + """, please go to ""Check Remote Slave Status"" feature!")
                            End If
                        Else
                            status = "Inaccessible"
                            'MsgBox("""" + temp + """ is not accessable!")
                            GoTo EndLine
                        End If
                    Case "stafres"
                        If temp.Length > 1 Then
                        Else
                            MsgBox("The path must start with ""%""")
                            status = "Wrong format"
                            GoTo EndLine
                        End If
                        If Mid(temp, 1, 1) = "%" Then 'must be the network path
                        Else
                            MsgBox("The path must start with ""%""")
                            status = "Wrong format"
                            GoTo EndLine
                        End If
                        Dim checkNetwork As New Thread(AddressOf checkNetworkFolder)
                        L_ST.Visible = True
                        Dim ipadrr = Split(temp, "%")(1)
                        If RegularExpressions.Regex.IsMatch(ipadrr, "\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}") Then
                            Dim matchedItems = RegularExpressions.Regex.Matches(ipadrr, "\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}")
                            If matchedItems.Count = 1 Then
                                Dim ipr = ipadrr.Replace(matchedItems(0).ToString(), "")
                                If Trim(ipr).Equals("") Then
                                    Dim positionArray = Split(ipadrr, ".")
                                    For Each position In positionArray
                                        If Len(position) > 1 Then

                                            If RegularExpressions.Regex.IsMatch(position, "^0") Then
                                                MsgBox("IP  """ + ipadrr + """ should not start with 0!")
                                                status = "Wrong format"
                                                GoTo EndLine
                                            End If
                                        End If

                                        If CInt(position) > 255 Then
                                            MsgBox("IP " + ipadrr + " 's node length should not be bigger than 255")
                                            status = "Wrong format"
                                            GoTo EndLine
                                        End If
                                    Next
                                Else
                                    MsgBox("IP  """ + ipadrr + """ is not a valid IP address!")
                                    status = "Wrong format"
                                    GoTo EndLine
                                End If
                            Else
                                MsgBox("IP """ + ipadrr + """ is not a valid IP address!")
                                status = "Wrong format"
                                GoTo EndLine
                            End If
                        Else
                            MsgBox("IP  """ + ipadrr + """ is not a valid IP address!")
                            status = "Wrong format"
                            GoTo EndLine
                        End If
                        Dim errornumber = 0
                        On Error Resume Next
                        Dim w = IPAddress.Parse(ipadrr)
                        errornumber = Err.Number
                        On Error GoTo 0
                        If errornumber <> 0 Then
                            MsgBox("IP  """ + ipadrr + """ is not a valid IP address!")
                            status = "Wrong format"
                            GoTo EndLine
                        End If

                    Case Else
                        status = "Unknown error"
                        'MsgBox("Unknown error!")
                        GoTo EndLine
                End Select
         
            End If
        Else
            GoTo Nullline
        End If
        e.CancelEdit = False
        LB_Content.Items.Item(e.Item).SubItems.Add("")
        LB_Content.Items.Item(e.Item).ForeColor = Color.Black
        Exit Sub

EndLine:
        e.CancelEdit = False
        LB_Content.Items.Item(e.Item).SubItems.Add(status)
        LB_Content.Items.Item(e.Item).ForeColor = Color.Red
        LB_Content.Focus()
        'For Each item In LB_Content.Items
        '    If item.Text = "" Then
        '        LB_Content.Items.Remove(item)
        '    End If
        'Next
        Exit Sub
Nullline:
        e.CancelEdit = True
        LB_Content.Items.RemoveAt(e.Item)
    End Sub

    Sub checkNetworkFolder(ByVal path As String)
        Dim Class_FolderOperator1 As New FolderOperator

        If Class_FolderOperator1.hasFolder(path) Then
            netpathSTGood = 1
        Else
            netpathSTGood = 0
        End If
    End Sub


    Private Sub LB_Content_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles LB_Content.ColumnClick
        Dim Sorter = New ListViewSorter(e.Column, SortOrder.Ascending)
        LB_Content.ListViewItemSorter = Sorter
    End Sub


End Class