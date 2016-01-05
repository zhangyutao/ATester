Imports System.Threading
Imports System.Text
Imports System.Net

Public Class Form_Module

    Dim strTagOn As String = "on"
    Dim strTagOff As String = "off"
    Dim clOn As Color = Color.Green
    Dim clOff As Color = Color.Gray
    Dim strModuleFilePath As String
    Dim strBPTFilePath As String
    Dim strDataFolderName As String = "Docs"
    Dim strModuleFileName As String = "BPT Owner.xlsx"
    Dim strBPTOwnerFileName As String = "BPT Owner.xlsx"
    Dim TopBar_mousedownVar As Boolean = False
    Dim curMousePosOnTopBar As Point = Nothing

    ' read from excel and create dynamic objects into listview
    Private Sub Form_Module_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

        Dim exc As ExcelOperator
        exc = New ExcelOperator()
        Dim moduleNames As String
        Dim strPath As String

        strPath = IIf(Strings.Right(Application.StartupPath, 1) <> "\", Application.StartupPath, Strings.Left(Application.StartupPath, Application.StartupPath.Length - 1))
        strModuleFilePath = Mid(strPath, 1, Strings.InStrRev(strPath, "\")) & strDataFolderName & "\" & strModuleFileName
        strBPTFilePath = Mid(strPath, 1, Strings.InStrRev(strPath, "\")) & strDataFolderName & "\" & strBPTOwnerFileName

        moduleNames = exc.readModuleNamesFromExcel(strModuleFilePath)

        ' Create list view , add to main window
        createListView(moduleNames)


    End Sub

    Private Sub createListView(ByVal strAllModule As String)

        ' Create List View object
        'Dim objLV As ListView
        Dim intObjLVX As Integer = 55
        Dim intObjLVY As Integer = 97
        Dim intObjLVWidth As Integer = 320
        Dim intObjLVHeight As Integer = 200
        Dim arrModules As Array
        Dim strSeperator As String = "@@"
        Dim strMd As String = ""
        Dim objLVItem As ListViewItem
        Dim objSubItem As ListViewItem.ListViewSubItem
        Dim clOn As Color = Color.Green
        Dim clOff As Color = Color.Gray
        Dim strTagOn As String = "on"
        Dim strTagOff As String = "off"

        'objLV = New ListView()
        objLV.CheckBoxes = True
        objLV.View = View.Details
        objLV.GridLines = False

        objLV.Bounds = New Rectangle(New Point(10, 10), New Size(300, 200))
        objLV.Columns.Add("Module", 130, HorizontalAlignment.Center)
        objLV.Columns.Add("High", 60, HorizontalAlignment.Center)
        objLV.Columns.Add("Medium", 60, HorizontalAlignment.Center)
        objLV.Columns.Add("Low", 60, HorizontalAlignment.Center)

        ' split module names string, module1@@module2@@module3
        arrModules = Split(strAllModule, strSeperator)

        For i = 0 To UBound(arrModules)
            strMd = arrModules(i).ToString
            objLVItem = New ListViewItem(strMd)
            objLVItem.UseItemStyleForSubItems = False
            objSubItem = objLVItem.SubItems.Add("H")
            objSubItem.Tag = strTagOff
            objSubItem.BackColor = clOff

            objSubItem = objLVItem.SubItems.Add("M")
            objSubItem.Tag = strTagOff
            objSubItem.BackColor = clOff

            objSubItem = objLVItem.SubItems.Add("L")
            objSubItem.Tag = strTagOff
            objSubItem.BackColor = clOff

            objLV.Items.Add(objLVItem)
        Next

        ' add list view to form
        Me.Controls.Add(objLV)
        objLV.BringToFront()
        objLV.Location = New Point(intObjLVX, intObjLVY)
        objLV.Width = intObjLVWidth
        objLV.Height = intObjLVHeight

        Me.lbCount.Text = Me.objLV.CheckedItems.Count & "/" & Me.objLV.Items.Count

    End Sub


    Private Sub Bt_close_editRemoteRes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bt_close_editRemoteRes.Click
        Me.Close()
    End Sub

    ' occurs when item check status change
    Private Sub objLV_ItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles objLV.ItemCheck

        If e.NewValue = CheckState.Checked Then
            For i As Integer = 1 To objLV.Items(e.Index).SubItems.Count - 1
                objLV.Items(e.Index).SubItems(i).BackColor = clOn
                objLV.Items(e.Index).SubItems(i).Tag = strTagOn
            Next

            Me.lbCount.Text = Me.objLV.CheckedItems.Count + 1 & "/" & Me.objLV.Items.Count

        Else
            For i As Integer = 1 To objLV.Items(e.Index).SubItems.Count - 1
                objLV.Items(e.Index).SubItems(i).BackColor = clOff
                objLV.Items(e.Index).SubItems(i).Tag = strTagOff
            Next

            Me.lbCount.Text = Me.objLV.CheckedItems.Count - 1 & "/" & Me.objLV.Items.Count
        End If

    End Sub

    ' click priority label, activate/deactivate the priority
    Private Sub objLV_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles objLV.MouseDown

        Dim info As ListViewHitTestInfo = DirectCast(sender, ListView).HitTest(e.X, e.Y)
        Dim sb As ListViewItem.ListViewSubItem

        If info.Item.SubItems.IndexOf(info.SubItem) > 0 Then
            If info.Item.Checked Then
                'check whether list item is checked
                If info.SubItem.Tag = strTagOff And info.SubItem.BackColor = clOff Then ' if subitem is tag 'off' and backcolor is gray
                    'set tag to 'on' and color to green
                    info.SubItem.Tag = strTagOn
                    info.SubItem.BackColor = clOn
                ElseIf info.SubItem.Tag = strTagOn And info.SubItem.BackColor = clOn Then ' else subitem is tag 'on' and backcolor is green
                    info.SubItem.Tag = strTagOff
                    info.SubItem.BackColor = clOff

                End If

                If info.Item.SubItems.Item(1).Tag = strTagOff And info.Item.SubItems.Item(2).Tag = strTagOff And info.Item.SubItems.Item(3).Tag = strTagOff Then
                    info.Item.Checked = False
                End If

            Else

                info.Item.Checked = True

                For i = 1 To info.Item.SubItems.Count - 1
                    sb = info.Item.SubItems(i)
                    sb.Tag = strTagOff
                    sb.BackColor = clOff
                Next

                info.SubItem.Tag = strTagOn
                info.SubItem.BackColor = clOn


            End If
        End If
    End Sub

    ' select all modules
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        For Each obj As ListViewItem In objLV.Items
            obj.Checked = True
        Next
        ckbH.Checked = True
        ckbM.Checked = True
        ckbL.Checked = True
    End Sub

    Private Sub Bt_New_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bt_New.Click
        For Each obj As ListViewItem In objLV.Items
            obj.Checked = False
        Next
        ckbH.Checked = False
        ckbM.Checked = False
        ckbL.Checked = False
    End Sub

    Private Sub Bt_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bt_Save.Click
        Dim strModule As String = ""
        Dim strPrio As String = ""
        Dim strModulesTotal As String = ""
        Dim intCaseCount As Integer = 0

        For Each objItem As ListViewItem In objLV.Items
            If objItem.Checked Then
                strModule = objItem.Text
                For i As Integer = 1 To objItem.SubItems.Count - 1 ' iterate all priorities

                    If objItem.SubItems(i).Tag = strTagOn And objItem.SubItems(i).BackColor = clOn Then
                        strPrio += objItem.SubItems(i).Text
                    End If
                Next
                ' format：Module1||HML@@Module2||ML@@Module3||HL
                If strPrio <> "" Then
                    strModulesTotal += strModule & "||" & strPrio & "@@"
                End If
                strPrio = ""
            End If
        Next

        If strModulesTotal.Length = 0 Then
            MsgBox("Select at least one module and priority.")
            Exit Sub
        End If

        strModulesTotal = Mid(strModulesTotal, 1, strModulesTotal.Length - 2)

        'invoke funciton to find cases
        Dim exc As ExcelOperator
        Dim caseList As String
        exc = New ExcelOperator

        caseList = exc.QueryBPTBaseOnConditions(strModulesTotal, strBPTFilePath)
        caseList = Replace(caseList, "||", vbCrLf)
        intCaseCount = Split(caseList, vbCrLf).Count
        Form_Main.TB_BPTList.Text = caseList
        Form_Main.CLB_Testlist.Items.Clear()
        Form_Main.CLB_Testlist.Items.AddRange(Split(caseList, vbCrLf))

        'ATester.My.Resources.Resources.expand
        If Not Form_Main.getExpandList() Then
            Form_Main.ExpandButton.PerformClick()
        End If
        Form_Main.RadioButton_Textbox.Checked = True
        Form_Main.TB_MainLog.AppendText(intCaseCount & " Module cases have been loaded into mission list." & vbCrLf)
        'close this window
        Me.Close()

    End Sub

    Private Sub ckbH_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckbH.CheckedChanged
        Dim intHindex As Integer = 1
        Dim blnHChecked As Boolean = ckbH.Checked

        If blnHChecked Then

            For Each obj As ListViewItem In objLV.Items
                If obj.Checked Then
                    If obj.SubItems(intHindex).Tag = strTagOff And obj.SubItems(intHindex).BackColor = clOff Then
                        obj.SubItems(intHindex).Tag = strTagOn
                        obj.SubItems(intHindex).BackColor = clOn
                    End If
                End If
            Next

        Else

            For Each obj As ListViewItem In objLV.Items
                If obj.Checked Then
                    If obj.SubItems(intHindex).Tag = strTagOn And obj.SubItems(intHindex).BackColor = clOn Then
                        obj.SubItems(intHindex).Tag = strTagOff
                        obj.SubItems(intHindex).BackColor = clOff
                    End If
                End If
            Next

        End If
    End Sub

    Private Sub ckbM_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckbM.CheckedChanged
        Dim intHindex As Integer = 2
        Dim blnMChecked As Boolean = ckbM.Checked

        If blnMChecked Then

            For Each obj As ListViewItem In objLV.Items
                If obj.Checked Then
                    If obj.SubItems(intHindex).Tag = strTagOff And obj.SubItems(intHindex).BackColor = clOff Then
                        obj.SubItems(intHindex).Tag = strTagOn
                        obj.SubItems(intHindex).BackColor = clOn
                    End If
                End If
            Next

        Else

            For Each obj As ListViewItem In objLV.Items
                If obj.Checked Then
                    If obj.SubItems(intHindex).Tag = strTagOn And obj.SubItems(intHindex).BackColor = clOn Then
                        obj.SubItems(intHindex).Tag = strTagOff
                        obj.SubItems(intHindex).BackColor = clOff
                    End If
                End If
            Next

        End If
    End Sub

    Private Sub ckbL_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckbL.CheckedChanged
        Dim intHindex As Integer = 3
        Dim blnLChecked As Boolean = ckbL.Checked

        If blnLChecked Then

            For Each obj As ListViewItem In objLV.Items
                If obj.Checked Then
                    If obj.SubItems(intHindex).Tag = strTagOff And obj.SubItems(intHindex).BackColor = clOff Then
                        obj.SubItems(intHindex).Tag = strTagOn
                        obj.SubItems(intHindex).BackColor = clOn
                    End If
                End If
            Next

        Else

            For Each obj As ListViewItem In objLV.Items
                If obj.Checked Then
                    If obj.SubItems(intHindex).Tag = strTagOn And obj.SubItems(intHindex).BackColor = clOn Then
                        obj.SubItems(intHindex).Tag = strTagOff
                        obj.SubItems(intHindex).BackColor = clOff
                    End If
                End If
            Next

        End If
    End Sub

    Private Sub Bt_Remove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bt_Remove.Click
        Me.Close()
    End Sub


    Private Sub BT_TopBar_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles BT_TopBar.MouseDown
        TopBar_mousedownVar = True
        curMousePosOnTopBar = BT_TopBar.PointToClient(Form_Module.MousePosition)
    End Sub

    Private Sub BT_TopBar_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles BT_TopBar.MouseMove
        If TopBar_mousedownVar And (IsNothing(curMousePosOnTopBar) = False) Then
            Dim curMousePos = System.Windows.Forms.Cursor.Position
            Me.Location = New Point(curMousePos.X - curMousePosOnTopBar.X - BT_TopBar.Location.X, curMousePos.Y - curMousePosOnTopBar.Y - BT_TopBar.Location.Y)
        End If
    End Sub

    Private Sub BT_TopBar_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles BT_TopBar.MouseUp
        TopBar_mousedownVar = False
        curMousePosOnTopBar = Nothing
    End Sub

End Class