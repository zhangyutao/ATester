Imports Microsoft.Office.Interop

Public Class ExcelOperator
    Public ReportExcelAccessStatus As Boolean = True ' for control thread to write excel report
    Public sharefolder As Boolean
    Public Class_FileOperator1 As New FileOperator
    Public FolderOperator1 As New FolderOperator
    Public isLocalIPHost As Boolean
    Sub prepareExcel(ByVal ExeclReportPath As String, ByVal reportime As String, ByVal arrayBPTsSelected() As Object)
        '###########this sub is designed specailly for "ReportTemplate.xlsx"##########
        If ExeclReportPath <> "" Then



            '###########Write execel report##########
            Dim xlApp As New Excel.Application
            Dim xlAPPHWND As Integer = xlApp.Hwnd
            Dim xlAppProcessID As Integer = 0
            GetWindowThreadProcessId(xlAPPHWND, xlAppProcessID)
            xlApp.EnableEvents = False
            xlApp.Visible = False
            Dim xlBook As Object = xlApp.Workbooks.Open(ExeclReportPath)

            Dim xlSheet As Object = xlBook.Worksheets("Summary")

            Dim xlOwnerSheet As Object = xlBook.Worksheets("BPT ownership")
            xlOwnerSheet.Visible = False
            xlSheet.Activate()
            'Write Executing Date
            xlSheet.Cells(2, 4) = reportime

            'Write Testing Env
            'xlSheet.Cells(9, 4) = strTestENV
            'xlSheet.Cells(9, 4).HorizontalAlignment = -4108
            'xlSheet.Cells(9, 4).VerticalAlignment = -4108


            Dim resultRow As Integer = 12 'the result begin on 12 row 
            Dim rowIndex As Integer = 0
            For i = 0 To UBound(arrayBPTsSelected)
                xlSheet.Range("A" & resultRow + rowIndex & ":B" & resultRow + rowIndex).MergeCells = True ' merge the A and B for storing BPT Name
                xlSheet.Cells(resultRow + rowIndex, 1) = arrayBPTsSelected(i) '1 is the col A for BPT Name
                xlSheet.Cells(resultRow + rowIndex, 1).HorizontalAlignment = -4131
                xlSheet.Cells(resultRow + rowIndex, 1).VerticalAlignment = -4108
                xlSheet.Cells(resultRow + rowIndex, 14) = "=VLOOKUP($A" + CStr(resultRow + rowIndex) + ",'BPT ownership'!$A:$B,2,FALSE)" '8 is the col N for Owner
                xlSheet.Cells(resultRow + rowIndex, 14).HorizontalAlignment = -4108
                xlSheet.Cells(resultRow + rowIndex, 14).VerticalAlignment = -4108
                xlSheet.Cells(resultRow + rowIndex, 15) = "=VLOOKUP($A" + CStr(resultRow + rowIndex) + ",'BPT ownership'!$A:$C,3,FALSE)" '9 is the col O for Module
                xlSheet.Cells(resultRow + rowIndex, 15).HorizontalAlignment = -4108
                xlSheet.Cells(resultRow + rowIndex, 15).VerticalAlignment = -4108
                rowIndex = rowIndex + 1
            Next

            ' save the Excel file
            xlBook.Save()
            xlApp.EnableEvents = True
            'Close the workbook
            xlBook.Close(True)
            xlBook = Nothing
            ' close the application and clean the object
            endProcess(xlAppProcessID)
            'xlApp.Quit()
            xlApp = Nothing
        End If
    End Sub
    Sub WriteResultToReportExcel(ByVal projectType As String, ByVal RunResultsStatus As String, ByVal execlReportPath As String, ByVal startTime As Date, ByVal testCaseName As String, ByVal testStartTime As Date, ByVal strTestResultPath As String, ByVal ServerName As String, ByVal strRunResultsShareFolderName As String, ByVal blnRemoteRun As Boolean, ByVal blnHostModel As Boolean)
        '###########this sub is designed specailly for "ReportTemplate.xlsx"##########


        If execlReportPath <> "" Then
            Dim test_subreport As String = ""
            Select Case projectType
                Case "UFT Project"
                    test_subreport = testCaseName + "\Report"
                Case "Maven Project"
                    test_subreport = testCaseName
                Case Else
                    test_subreport = testCaseName + "\Report"
            End Select

            If LCase(RunResultsStatus).Contains("fail") Then
                RunResultsStatus = "Failed"
            End If

            If LCase(RunResultsStatus).Contains("pass") Then
                RunResultsStatus = "Passed"
            End If

            Do While ReportExcelAccessStatus = False
                waitTime(100)
            Loop
            ReportExcelAccessStatus = False
            On Error Resume Next
            Dim xlApp As New Excel.Application
            Dim xlAPPHWND As Integer = xlApp.Hwnd
            xlApp.Visible = False
            Dim xlAppProcessID As Integer = 0
            GetWindowThreadProcessId(xlAPPHWND, xlAppProcessID)
            Dim xlBook As Object = xlApp.Workbooks.Open(execlReportPath)
            Dim xlSheet As Object = xlBook.Worksheets("Summary") 'this is hard code
            Dim endTime = Now ' record endTime
            Dim testColRow As Integer = 11 ' hard code
            Dim resultRow As Integer = 12 ' hard code
            Dim rowIndex As Integer = 9999 'a estimate row number for the report excel
            Dim findCaseName = False
            For Counter = 0 To rowIndex - 1
                Dim curCell = xlSheet.Cells(resultRow + Counter, 1)
                Dim curStatus = xlSheet.Cells(resultRow + Counter, 4)
                If curCell.Value = testCaseName And Trim(CStr(curStatus.Value)) = "" Then
                    findCaseName = True
                    xlSheet.Cells(resultRow + Counter, 4) = RunResultsStatus ' Auto Result col
                    xlSheet.Cells(resultRow + Counter, 4).HorizontalAlignment = -4108
                    xlSheet.Cells(resultRow + Counter, 4).VerticalAlignment = -4108
                    xlSheet.Cells(resultRow + Counter, 5) = DateDiff("s", testStartTime, endTime) / 60 'calculate test cost time and write toCost Time(s)
                    xlSheet.Cells(resultRow + Counter, 5).NumberFormat = "0.00"
                    xlSheet.Cells(resultRow + Counter, 5).HorizontalAlignment = -4108
                    xlSheet.Cells(resultRow + Counter, 5).VerticalAlignment = -4108
                    If blnRemoteRun Then
                        If blnHostModel Then
                            xlSheet.Hyperlinks.Add(xlSheet.Cells(resultRow + Counter, 4), strTestResultPath + "\" + test_subreport)
                            xlSheet.Cells(testColRow, 16) = "The test is excuted in below servers"
                            xlSheet.Cells(resultRow + Counter, 16) = ServerName
                            If isLocalIPHost Then
                                On Error Resume Next
                                Cmd("ICacls """ + strTestResultPath + "\" + testCaseName + """ /T /C /grant:r everyone:F")
                                On Error GoTo 0
                            End If
                        Else
                            xlSheet.Cells(testColRow, 16) = "The test is excuted in below servers and DetailRes is put in that server"
                            Select Case projectType
                                Case "UFT Project"
                                    xlSheet.Cells(resultRow + Counter, 16) = "[" + ServerName + "]" + strTestResultPath + "\" + test_subreport
                                Case "Maven Project"
                                    xlSheet.Cells(resultRow + Counter, 16) = "[" + ServerName + "]" + strTestResultPath
                                Case Else
                                    xlSheet.Cells(resultRow + Counter, 16) = "[" + ServerName + "]" + strTestResultPath + "\" + test_subreport
                            End Select

                        End If
                    Else
                        'xlSheet.Cells(testColRow, 16) = "The directory of detail result folder"
                        
                                xlSheet.Hyperlinks.Add(xlSheet.Cells(resultRow + Counter, 4), strTestResultPath + "\" + test_subreport)
                    
                        If sharefolder Then
                            'xlSheet.Cells(testColRow, 17) = "The shared path of detail result folder"
                            'xlSheet.Hyperlinks.Add(xlSheet.Cells(resultRow + Counter, 11), "\\" + ServerName + "\" + strRunResultsShareFolderName + "\" + qtpTN + "\Report")
                        End If
                    End If
                    If RunResultsStatus = "Passed" Then ' Manual Result col
                        xlSheet.Cells(resultRow + Counter, 3) = "Passed"
                        xlSheet.Cells(resultRow + Counter, 3).HorizontalAlignment = -4108
                        xlSheet.Cells(resultRow + Counter, 3).VerticalAlignment = -4108
                    End If
                    Exit For
                End If
            Next
            If findCaseName = False Then
                For Counter = 0 To rowIndex - 1
                    Dim curCell = xlSheet.Cells(resultRow + Counter, 1)
                    If curCell.Value = "" Then
                        xlSheet.Range("A" & resultRow + Counter & ":B" & resultRow + Counter).MergeCells = True ' merge the A and B for storing BPT Name
                        xlSheet.Cells(resultRow + Counter, 1) = testCaseName
                        xlSheet.Cells(resultRow + Counter, 4) = RunResultsStatus ' Auto Result col
                        xlSheet.Cells(resultRow + Counter, 4).HorizontalAlignment = -4108
                        xlSheet.Cells(resultRow + Counter, 4).VerticalAlignment = -4108
                        xlSheet.Cells(resultRow + Counter, 5) = DateDiff("s", testStartTime, endTime) / 60 'calculate test cost time and write toCost Time(s)
                        xlSheet.Cells(resultRow + Counter, 5).NumberFormat = "0.00"
                        xlSheet.Cells(resultRow + Counter, 5).HorizontalAlignment = -4108
                        xlSheet.Cells(resultRow + Counter, 5).VerticalAlignment = -4108
                        If blnRemoteRun Then
                            If blnHostModel Then
                                xlSheet.Hyperlinks.Add(xlSheet.Cells(resultRow + Counter, 4), strTestResultPath + "\" + test_subreport)
                                xlSheet.Cells(testColRow, 16) = "The test is excuted in below servers"
                                xlSheet.Cells(resultRow + Counter, 16) = ServerName
                                If isLocalIPHost Then
                                    On Error Resume Next
                                    Cmd("ICacls """ + strTestResultPath + "\" + testCaseName + """ /T /C /grant:r everyone:F")
                                    On Error GoTo 0
                                End If
                            Else
                                xlSheet.Cells(testColRow, 16) = "The test is excuted in below servers and DetailRes is put in that server"
                                Select Case projectType
                                    Case "UFT Project"
                                        xlSheet.Cells(resultRow + Counter, 16) = "[" + ServerName + "]" + strTestResultPath + "\" + test_subreport
                                    Case "Maven Project"
                                        xlSheet.Cells(resultRow + Counter, 16) = "[" + ServerName + "]" + strTestResultPath
                                    Case Else
                                        xlSheet.Cells(resultRow + Counter, 16) = "[" + ServerName + "]" + strTestResultPath + "\" + test_subreport
                                End Select

                            End If
                        Else
                            'xlSheet.Cells(testColRow, 16) = "The directory of detail result folder"
                         
                

                            If sharefolder Then
                                'xlSheet.Cells(testColRow, 17) = "The shared path of detail result folder"
                                'xlSheet.Hyperlinks.Add(xlSheet.Cells(resultRow + Counter, 11), "\\" + ServerName + "\" + strRunResultsShareFolderName + "\" + qtpTN + "\Report")
                            End If
                        End If
                        If RunResultsStatus = "Passed" Then ' Manual Result col
                            xlSheet.Cells(resultRow + Counter, 3) = "Passed"
                            xlSheet.Cells(resultRow + Counter, 3).HorizontalAlignment = -4108
                            xlSheet.Cells(resultRow + Counter, 3).VerticalAlignment = -4108
                        End If


                        xlSheet.Range("A" & resultRow + rowIndex & ":B" & resultRow + rowIndex).MergeCells = True ' merge the A and B for storing BPT Name
                        xlSheet.Cells(resultRow + Counter, 14) = "=VLOOKUP($A" + CStr(resultRow + Counter) + ",'BPT ownership'!$A:$B,2,FALSE)" '14 is the col N for Owner
                        xlSheet.Cells(resultRow + Counter, 14).HorizontalAlignment = -4108
                        xlSheet.Cells(resultRow + Counter, 14).VerticalAlignment = -4108
                        xlSheet.Cells(resultRow + Counter, 15) = "=VLOOKUP($A" + CStr(resultRow + Counter) + ",'BPT ownership'!$A:$C,3,FALSE)" '15 is the col O for Module
                        xlSheet.Cells(resultRow + Counter, 15).HorizontalAlignment = -4108
                        xlSheet.Cells(resultRow + Counter, 15).VerticalAlignment = -4108
                        Exit For
                    End If


                Next
                'Dim errorpatch = FolderOperator1.getUpFolderNameInStr(strTestResultPath) + "\CannotFindNameLog.txt"
                'Class_FileOperator1.WriteResultToRunTimeReportFile(errorpatch, qtpTN, RunResultsStatus)
            End If
            xlSheet.Cells(10, 12) = DateDiff("s", startTime, endTime) / 60 ' calculate Total Time Consuming and write to Execel Total Time Consuming(minutes)
            xlSheet.Cells(10, 12).NumberFormat = "0.00"
            ' save the Excel file
            xlApp.EnableEvents = False
            xlBook.Save()
            'xlApp.ActiveWorkbook.SaveAs Filename:=strTestReportPath+"TestResult.htm",FileFormat:=xlHTML
            xlApp.EnableEvents = True
            'Close the workbook
            xlBook.Close(True)
            xlBook = Nothing
            ' close the application and clean the object
            endProcess(xlAppProcessID)
            'xlApp.Quit()
            xlApp = Nothing
            ReportExcelAccessStatus = True
            On Error GoTo 0
        End If

    End Sub


    ' 2015 apr 14 vince/ For reading module names from excel file
    Function readModuleNamesFromExcel(ByVal strExcelPath) As String
        Dim strModuleHead As String = "Module Name"
        Dim objModuleHead As Excel.Range
        Dim objModuleNameCell As Excel.Range
        Dim strModuleName As String
        Dim strModuleNames As String = ""
        Dim blnHasMoreModules As Boolean = True
        Dim IntModulePosition As Integer
        Dim objExcelApp As Excel.Application
        Dim objModuleSheet As Excel.Worksheet
        Dim strModuleSheetName As String = "Module Cases"

        objExcelApp = New Excel.Application
        Dim blnLoop As Boolean = True
        Dim blnStringSearch As Boolean = False

        Try

            objExcelApp.Workbooks.Open(strExcelPath)
            objModuleSheet = objExcelApp.ActiveWorkbook.Worksheets.Item(strModuleSheetName)

            objModuleHead = objModuleSheet.Rows.Find(strModuleHead)  ' find head cell of module names

            objModuleNameCell = objModuleHead.Offset(1, 0)

            Do  ' retrieve all module names
                strModuleName = objModuleNameCell.Value
                IntModulePosition = InStr(strModuleNames, strModuleName)

                If IntModulePosition < 1 Then

                    strModuleNames = strModuleNames & "@@" & strModuleName
                Else

                    Do
                        IntModulePosition = InStr(IntModulePosition, strModuleNames, strModuleName)
                        If IntModulePosition > 0 Then
                            If Mid(strModuleNames, IntModulePosition - 1, 1) = "@" And Mid(strModuleNames, IntModulePosition + Len(strModuleName), 1) = "@" Then
                                blnStringSearch = True
                            End If

                            If Mid(strModuleNames, IntModulePosition - 1, 1) = "@" And IntModulePosition - 1 + Len(strModuleName) = Len(strModuleNames) Then
                                blnStringSearch = True
                            End If

                            IntModulePosition += 1
                        Else
                            blnLoop = False
                        End If

                    Loop While blnLoop And Not blnStringSearch

                    If Not blnStringSearch Then
                        strModuleNames = strModuleNames & "@@" & strModuleName
                    End If

                End If

                objModuleNameCell = objModuleNameCell.Offset(1, 0)

                If (Trim(objModuleNameCell.Value) = "") Then
                    blnHasMoreModules = False
                End If

                blnLoop = True
                blnStringSearch = False
            Loop While blnHasMoreModules

            objExcelApp.Application.DisplayAlerts = False
            objExcelApp.Workbooks.Close()
            objExcelApp.Quit()
            objExcelApp = Nothing
            strModuleNames = Mid(strModuleNames, 3)

            Return strModuleNames
        Catch e As Exception
            objExcelApp.Application.DisplayAlerts = False
            objExcelApp.Workbooks.Close()
            objExcelApp.Quit()
            objExcelApp = Nothing
            MsgBox("Something happened when reading from excel: " & e.Message)
            Return False
        End Try

    End Function

    '2015/04/15_Created by Rex for query BPT from Excel and output case list
    Function QueryBPTBaseOnConditions(ByVal queryCondition As String, ByVal xlPath As String) As String

        Dim xlApp As New Excel.Application
        Dim xlSheet As Excel.Worksheet
        Dim objModuleHead As Excel.Range
        Dim objModuleNameCell As Excel.Range
        Dim objPriorityHead As Excel.Range
        Dim objCaseNameHead As Excel.Range
        Dim objPriorityCell As Excel.Range
        Dim objCaseNameCell As Excel.Range

        Dim arrQueryParentCondition As Array
        Dim arrQueryChildCondition As Array
        Dim intCountParentCondition As Integer
        Dim i As Integer
        Dim strConditionTemp As String
        Dim strFinalCondition As String = ""
        Dim intColN_ModuleName As Integer
        Dim intColN_Priority As Integer
        Dim intColN_CaseName As Integer
        'Dim intRows As Integer
        Dim intAreaRows As Integer

        Try
            arrQueryParentCondition = Split(queryCondition, "@@", -1, 1)
            intCountParentCondition = UBound(arrQueryParentCondition)
            For i = 0 To intCountParentCondition
                arrQueryChildCondition = Split(arrQueryParentCondition(i), "||", -1, 1)
                If InStr(arrQueryChildCondition(1), "H") <> 0 Then
                    strConditionTemp = arrQueryChildCondition(0) & "_High"
                    strFinalCondition = strFinalCondition & "**" & strConditionTemp
                End If

                If InStr(arrQueryChildCondition(1), "M") <> 0 Then
                    strConditionTemp = arrQueryChildCondition(0) & "_Medium"
                    strFinalCondition = strFinalCondition & "**" & strConditionTemp
                End If

                If InStr(arrQueryChildCondition(1), "L") <> 0 Then
                    strConditionTemp = arrQueryChildCondition(0) & "_Low"
                    strFinalCondition = strFinalCondition & "**" & strConditionTemp
                End If
            Next

            Dim arrQueryCondition As Array
            Dim intArrQueryConditionNum As Integer

            Dim intTempModuleNameRow As Integer
            Dim strTempQuery As String
            Dim strTempBPTCaseNames As String = ""
            Dim blnHasMoreModules As Boolean = True

            strFinalCondition = Mid(strFinalCondition, 3)
            arrQueryCondition = Split(strFinalCondition, "**")
            intArrQueryConditionNum = UBound(arrQueryCondition)

            xlApp.Visible = False
            xlApp.Workbooks.Open(xlPath)
            xlSheet = xlApp.Worksheets("Module Cases")
            'intRows = xlSheet.Range("C1").End(Excel.XlDirection.xlDown).Row

            objModuleHead = xlSheet.Rows.Find("Module Name")
            intColN_ModuleName = objModuleHead.Column
            objModuleNameCell = objModuleHead.Offset(1, 0)

            objPriorityHead = xlSheet.Rows.Find("Priority")
            intColN_Priority = objPriorityHead.Column
            objPriorityCell = objPriorityHead.Offset(1, 0)

            objCaseNameHead = xlSheet.Rows.Find("Case Name")
            intColN_CaseName = objCaseNameHead.Column
            objCaseNameCell = objCaseNameHead.Offset(1, 0)

            Do
                If objModuleNameCell.MergeCells Then
                    intAreaRows = objModuleNameCell.MergeArea.Rows.Count
                    intTempModuleNameRow = objModuleNameCell.Row
                    For m = 0 To intAreaRows - 1
                        strTempQuery = xlSheet.Cells(intTempModuleNameRow, intColN_ModuleName).value & "_" & xlSheet.Cells(intTempModuleNameRow + m, intColN_Priority).value
                        For Each queryItem In arrQueryCondition
                            If Trim(queryItem) = Trim(strTempQuery) Then
                                strTempBPTCaseNames = strTempBPTCaseNames & "||" & xlSheet.Cells(intTempModuleNameRow + m, intColN_CaseName).value
                                Exit For
                            End If
                        Next
                    Next

                    objModuleNameCell = objModuleNameCell.Offset(1, 0)
                Else
                    intTempModuleNameRow = objModuleNameCell.Row
                    strTempQuery = xlSheet.Cells(intTempModuleNameRow, intColN_ModuleName).value & "_" & xlSheet.Cells(intTempModuleNameRow, intColN_Priority).value
                    For Each queryItem In arrQueryCondition
                        If Trim(queryItem) = Trim(strTempQuery) Then
                            strTempBPTCaseNames = strTempBPTCaseNames & "||" & xlSheet.Cells(intTempModuleNameRow, intColN_CaseName).value
                            Exit For
                        End If
                    Next
                    objModuleNameCell = objModuleNameCell.Offset(1, 0)
                End If

                If (Trim(objModuleNameCell.Value) = "") Then
                    blnHasMoreModules = False
                End If

            Loop While blnHasMoreModules

            xlApp.Application.DisplayAlerts = False
            xlApp.Workbooks.Close()
            xlApp.Quit()
            xlApp = Nothing
            strTempBPTCaseNames = Mid(strTempBPTCaseNames, 3)

            Return strTempBPTCaseNames

        Catch e As Exception
            xlApp.Application.DisplayAlerts = False
            xlApp.Workbooks.Close()
            xlApp.Quit()
            xlApp = Nothing
            MsgBox("Something happened when output BPT list from excel: " & e.Message)
            Return False
        End Try

    End Function

    '2015/04/16_Created by Rex for get golden BPT from Excel and output case list
    Function ReadGoldenCaseFromExcel(ByVal xlPath As String) As String
        Dim xlApp As New Excel.Application
        Dim xlSheet As Excel.Worksheet
        Dim objHeadATCaseName As Excel.Range
        Dim objATCaseNameCell As Excel.Range
        Dim intColN_ATCaseName As Integer
        Dim strBPTCaseList As String = ""
        Dim blnHasMoreModules As Boolean = True

        xlApp.Visible = False
        xlApp.Workbooks.Open(xlPath)
        xlSheet = xlApp.Worksheets("Golden Cases")
        objHeadATCaseName = xlSheet.Rows.Find("AT Case Name")
        intColN_ATCaseName = objHeadATCaseName.Column
        objATCaseNameCell = objHeadATCaseName.Offset(1, 0)

        Try
            Do
                strBPTCaseList = strBPTCaseList & "||" & objATCaseNameCell.Value
                objATCaseNameCell = objATCaseNameCell.Offset(1, 0)

                If (Trim(objATCaseNameCell.Value) = "") Then
                    blnHasMoreModules = False
                End If
            Loop While blnHasMoreModules

            xlApp.Application.DisplayAlerts = False
            xlApp.Workbooks.Close()
            xlApp.Quit()
            xlApp = Nothing
            strBPTCaseList = Mid(strBPTCaseList, 3)

            Return strBPTCaseList

        Catch e As Exception
            xlApp.Application.DisplayAlerts = False
            xlApp.Workbooks.Close()
            xlApp.Quit()
            xlApp = Nothing
            MsgBox("Something happened when output Golden BPT list from excel: " & e.Message)
            Return False
        End Try

    End Function
End Class
