Imports System.Threading
Imports System.IO

Public Class ExecutionOperator
    Public Folder_Project_Root_Path As String
    Public Shared projectType As String
    Public Shared syncStatusOfLocal(-1) As Array '{{is requesting:a var of boolean, syncstatus:a var of boolean}，{request,status}....}
    Public Shared syncStatusLockOfLocal As Integer = 0 '0 is not using, 1 is using
    Public Shared synchroPointSTOfLocal As Integer ' 0 - other thread can access 1 - other thread cannot access

    Public Shared syncStatusOfCustomRemote(-1) As Array '{{is requesting:a var of boolean, syncstatus:a var of boolean}，{request,status}....}
    Public Shared syncStatusLockOfCustomRemote As Integer = 0 '0 is not using, 1 is using
    Public Shared synchroPointSTOfCustomRemote As Integer ' 0 - other thread cannot access 1 - other thread cannot access


    Public Shared syncStatusOfRemote(-1) As Array '{{is requesting:a var of boolean, syncstatus:a var of boolean}，{request,status}....}
    Public Shared syncStatusLockOfRemote As Integer = 0 '0 is not using, 1 is using
    Public Shared synchroPointSTOfRemote As Integer ' 0 - other thread can access 1 - other thread cannot access

    Public Class_FileOperator1 As New FileOperator
    Public Class_FolderOperator2 As New FolderOperator
    Public Class_ExcelOperator2 As New ExcelOperator
    Public Event AddMessageToTB_MainLogEvnt(ByVal msg As String, ByVal following As String)
    'Public Event SetEnableToBt_Cancel(ByVal bln As Boolean)
    Private Class_MainFormControlHandler2 As New MainFormControlHandler
    Public shareReportFolder As Boolean = False
    Public strTestResultPath As String 'run result path
    Public strTestResultPath_Backup As String 'run result path when host model cannot access the strTestResultPath will use it
    Public strTestReportPath As String = "" 'report path
    Public strExeclReportPath As String 'report excel path
    Public strTxtReportPath As String ' text report path
    Public strTestCasePath As String ' BPT folder path on local
    Public Shared arryRunList As Object ' BPT name array for local, {BPT name, BPT status, Server Path, Result Path} for remote. BPT status:"ready" - the BPT is not run. "run" - the BPT is run by some server. "error" - the BPT has run and get error. "done" - then BPT has run completed
    Public Shared arryServerFullyInfo() As Object = Nothing  'two dimension arry. It contains "{execute path, server path,server status,UFT assgined to the server, BPT assigned to the server,lockupdate boolean}" of each server
    Public openUFTByme As Boolean = False ' if i open the QTP? ture - yes
    Public exitValue As Integer = 4 ' exitValue:1-  exit by exception, 2- exit normally,0- have not exited sub,3 - user stop run,4 - no start sub
    Public OneTimeNumber As Integer = 0
    Public RemoteErrorRun As Boolean = False 'work with sub "RunBPTs_OnlyForRemote" for know any exception found in run BPTs
    Public Shared arryForThreadWhichRunRemoteBPT(-1) As Object
    Public runStartTime As Date
    Public blnCancelRemote As Boolean = False
    Public strEportTimeForFolder As String = ""
    Public UFTConfigStream As String = ""
    Public HostModel As String = ""
    Public ReportTestResultPath As String = ""
    Public isLocalIPHost As Boolean
    Public STAFEC_STAFSelfErr As Integer = -11111
    Public STAFEC_MVNServiceErr As Integer = -22222
    Public STAFEC_STAFSeviceTS As Integer = -33333
    Public STAFEC_AnalysisResOfSvc As Integer = -44444
    Public Shared tsOfMavenTestCase As Long = 120000 'in milliseconds




    Sub Exection_Local()
        ''#############get information of thread##########################
        'Dim tempThread As Thread = Threading.Thread.CurrentThread
        '' tempThread.IsBackground = True
        'Dim nextIndex As Integer = UBound(arryForThreadWhichRunRemoteBPT) + 1
        'ReDim Preserve arryForThreadWhichRunRemoteBPT(nextIndex)
        'arryForThreadWhichRunRemoteBPT(nextIndex) = {tempThread, "normal"}
        ''#############get information of thread END##########################

        exitValue = 0

        On Error GoTo ErrorHandler
        Class_ExcelOperator2.sharefolder = shareReportFolder
        Dim strServerName = GetLocalHostName()
        Dim strShareResultsFolderName = Mid(strTestResultPath, InStrRev(strTestResultPath, "\") + 1) + strEportTimeForFolder
        waitTime(2000)
        Dim obj_ExecutionApp As Object = Nothing
        Dim qtAppTestSettingsEnvironmentValueIDs As String = ""
        If projectType = "UFT Project" Then
            RaiseEvent AddMessageToTB_MainLogEvnt("Launching UFT, please wait a while", vbCrLf)
            openUFTByme = True
            Debug.Print("creatUFT")
            obj_ExecutionApp = CreateUFT("")
            If obj_ExecutionApp.GetStatus = "Not launched" Then
                obj_ExecutionApp.Launch() ' Start QuickTest
            End If
            Class_FileOperator1.CreateText(strTestReportPath & "\IDslog.txt")
            UFTAppSet(obj_ExecutionApp)
            RaiseEvent AddMessageToTB_MainLogEvnt("UFT is launched successfully", vbCrLf)
        End If
        Dim STAFProc As Process = Nothing
        If projectType = "Maven Project" Then

            On Error GoTo ErrorHandler
            RaiseEvent AddMessageToTB_MainLogEvnt("Launching STAFProc, please wait a while", vbCrLf)
            Dim STAFArray = launchStaf()
            STAFProc = STAFArray(0)
            If STAFArray(1) Then
                RaiseEvent AddMessageToTB_MainLogEvnt("STAFProc is launched successfully", vbCrLf)
            Else
                RaiseEvent AddMessageToTB_MainLogEvnt("It is failed to launch STAFProc", vbCrLf)
                Err.Number = STAFEC_STAFSelfErr
                Err.Description = STAFArray(2)
                GoTo ErrorHandler
            End If

        End If
        'run Each BPT
        RaiseEvent AddMessageToTB_MainLogEvnt("Start test missions", vbCrLf)
        Dim maxBPTIndex As Integer = UBound(arryRunList)

        For i = 0 To UBound(arryRunList)
            'sync resource 
            Dim syncwaittime = 2
            Dim cur = Now
            synchroPointSTOfLocal = 0
            Do
                waitTime(100)
            Loop Until DateDiff(DateInterval.Second, cur, Now) >= syncwaittime
            synchroPointSTOfLocal = 1

            If IsSyncVarReady(syncStatusLockOfLocal) Then

                If CheckSyncRequestStatus(syncStatusOfLocal, syncStatusLockOfLocal) Then
                    Dim synchropointResponseTimeout = 120
                    Dim curtime = Now
                    Do
                        waitTime(100)

                    Loop Until CheckSyncRequestStatus(syncStatusOfLocal, syncStatusLockOfLocal) = False Or DateDiff(DateInterval.Second, curtime, Now) >= synchropointResponseTimeout
                    If CheckSyncRequestStatus(syncStatusOfLocal, syncStatusLockOfLocal) = False Then
                    Else
                        For p = 0 To UBound(syncStatusOfLocal)
                            Dim st = False
                            If syncStatusOfLocal(p)(0) = True Then
                                st = ResponseSyncResult(syncStatusOfLocal, p, True, syncStatusLockOfLocal)
                            End If
                            If st = False Then
                                RaiseEvent AddMessageToTB_MainLogEvnt("Exception: unknown error on Destory Sync Var for thread for access reource of Exection_Local!", vbCrLf)
                            End If
                        Next
                    End If
                End If
                Dim st1 = DestorySyncVar(syncStatusOfLocal, syncStatusLockOfLocal)
                If st1 = False Then
                    RaiseEvent AddMessageToTB_MainLogEvnt("Exception: unknown error on Destory Sync Var for thread for access reource of Exection_Local!", vbCrLf)
                End If
            Else
                RaiseEvent AddMessageToTB_MainLogEvnt("Exception: unknown error on wait thread for access reource of Exection_Local!", vbCrLf)
            End If
            'sync resource end


            Dim errornumber = 0
            Dim errordes = ""
            Dim RunResultsStatus As String = ""
            Dim testStartTime As Date = Now  ' record BPT start Time
            On Error GoTo ErrorHandler
            Dim TestCaseName As String = arryRunList(i)(0)

            If Trim(TestCaseName) <> "" Then

                On Error Resume Next

                If projectType = "UFT Project" Then
                    Debug.Print("openTest")
                    arryRunList(i)(1) = "run"
                    Dim qtTest As Object = OpenUFTTest(obj_ExecutionApp, strTestCasePath + "\" + TestCaseName, True, False)
                    If Err.Number <> 0 Then
                        GoTo ErrorDecide
                    End If
                    On Error GoTo ErrorDecide
                    Debug.Print("setTest")
                    qtTest = UFEAppTestSet(obj_ExecutionApp, qtAppTestSettingsEnvironmentValueIDs)

                    Dim qtResultsOpt As Object = SetupUFTResult("", strTestResultPath, TestCaseName)
                    'RaiseEvent AddMessageToTB_MainLog("Start: [" + qtpTN + "]", vbCrLf)
                    Debug.Print("openRun")

                    qtTest.Run(qtResultsOpt, False) ' Run the test
                    Do While qtTest.IsRunning
                        qtAppTestSettingsEnvironmentValueIDs = qtTest.Environment.Value("IDs")
                        Application.DoEvents()
                        waitTime(500)
                    Loop

                    RunResultsStatus = qtTest.LastRunResults.Status
                    qtResultsOpt = Nothing ' Release the Run Results Options object
                    qtTest = Nothing ' Release the Test object
                    Debug.Print("openReport")
                End If

                If projectType = "Maven Project" Then
                    arryRunList(i)(1) = "run"
                    Debug.Print("openTest")
                    Dim res() As Object = runStafMavenService_Local(Folder_Project_Root_Path, TestCaseName, tsOfMavenTestCase)
                    If Err.Number <> 0 Then
                        GoTo ErrorDecide
                    End If
                    RunResultsStatus = res(0)
                    If RunResultsStatus = "error" Then
                        RaiseEvent AddMessageToTB_MainLogEvnt(TestCaseName + ": Error to execute the TestCase", vbCrLf)
                        Err.Number = res(2)
                        Err.Description = res(1)
                    End If
                End If
ErrorDecide:
                errornumber = Err.Number
                errordes = Err.Description
                On Error GoTo 0

                Select Case errornumber
                    Case 0
                        arryRunList(i)(1) = "done-" & LCase(RunResultsStatus)
                        arryRunList(i)(3) = strTestResultPath
                        'RaiseEvent AddMessageToTB_MainLog("End: " + RunResultsStatus, vbCrLf)
                        Class_FileOperator1.WriteResultToRunTimeReportFile(strTxtReportPath, TestCaseName, RunResultsStatus)
                        Class_ExcelOperator2.WriteResultToReportExcel(projectType, RunResultsStatus, strExeclReportPath, runStartTime, TestCaseName, testStartTime, strTestResultPath, strServerName, strShareResultsFolderName, False, False)
                    Case 1006  'cannot open test case
                        arryRunList(i)(1) = "error"
                        arryRunList(i)(3) = strTestResultPath
                        RaiseEvent AddMessageToTB_MainLogEvnt("[" + TestCaseName + "] gets problem on executing TestCase. Description:" + CStr(errornumber) + "-" + errordes, vbCrLf)
                        RunResultsStatus = "Error:" + CStr(errornumber) + "-" + errordes
                        Class_FileOperator1.WriteResultToRunTimeReportFile(strTxtReportPath, TestCaseName, RunResultsStatus)
                        Class_ExcelOperator2.WriteResultToReportExcel(projectType, RunResultsStatus, strExeclReportPath, runStartTime, TestCaseName, testStartTime, strTestResultPath, strServerName, strShareResultsFolderName, False, False)
                        On Error GoTo 0
                        'Err.Clear()
                    Case STAFEC_MVNServiceErr
                        arryRunList(i)(1) = "error"
                        arryRunList(i)(3) = strTestResultPath
                        RaiseEvent AddMessageToTB_MainLogEvnt("[" + TestCaseName + "] gets problem on executing TestCase. Description:" + CStr(errornumber) + "-" + errordes, vbCrLf)
                        RunResultsStatus = "Error:" + CStr(errornumber) + "-" + errordes
                        Class_FileOperator1.WriteResultToRunTimeReportFile(strTxtReportPath, TestCaseName, RunResultsStatus)
                        Class_ExcelOperator2.WriteResultToReportExcel(projectType, RunResultsStatus, strExeclReportPath, runStartTime, TestCaseName, testStartTime, strTestResultPath, strServerName, strShareResultsFolderName, False, False)
                    Case Else
                        arryRunList(i)(1) = "error"
                        arryRunList(i)(3) = strTestResultPath
                        RaiseEvent AddMessageToTB_MainLogEvnt("[" + TestCaseName + "] gets problem on executing TestCase. Description:" + CStr(errornumber) + "-" + errordes, vbCrLf)
                        RunResultsStatus = "Error:" + CStr(errornumber) + "-" + errordes
                        Class_FileOperator1.WriteResultToRunTimeReportFile(strTxtReportPath, TestCaseName, RunResultsStatus)
                        Class_ExcelOperator2.WriteResultToReportExcel(projectType, RunResultsStatus, strExeclReportPath, runStartTime, TestCaseName, testStartTime, strTestResultPath, strServerName, strShareResultsFolderName, False, False)
                        If i <> maxBPTIndex Then
                            If projectType = "UFT Project" Then
                                KillQTP()
                                On Error GoTo ErrorHandler
                                obj_ExecutionApp = CreateUFT("") 'for continue run next BPT from exception
                            End If
                        End If

                        On Error GoTo 0
                End Select
            End If
        Next
        If projectType = "UFT Project" Then
            obj_ExecutionApp.test.close()
            obj_ExecutionApp.Quit() ' Exit QuickTest
            obj_ExecutionApp = Nothing ' Release the Application object
        End If
        If projectType = "Maven Project" Then
            If IsNothing(STAFProc) = False Then
                If STAFProc.HasExited = False Then
                    STAFProc.Kill()
                End If
                STAFProc = Nothing ' Release the Application object
            End If
        End If
        exitValue = 2
        Exit Sub
ErrorHandler:
        Select Case Err.Number
            Case 0
                exitValue = 2
                Exit Sub
            Case Else
                Dim ErrDescription As String = "Unknown"
                If Err.Description <> "" Then
                    ErrDescription = Err.Description
                End If
                RaiseEvent AddMessageToTB_MainLogEvnt("Error: get problem on accessing UFT/STAF. Description:" + CStr(Err.Number) + "-" + Err.Description, vbCrLf)
                exitValue = 1
                Exit Sub
        End Select
    End Sub

    Sub ExectionRandom_Remote()

        ''#############get information of thread##########################
        'Dim tempThread As Thread = Threading.Thread.CurrentThread
        '' tempThread.IsBackground = True
        'Dim nextIndex As Integer = UBound(arryForThreadWhichRunRemoteBPT) + 1
        'ReDim Preserve arryForThreadWhichRunRemoteBPT(nextIndex)
        'arryForThreadWhichRunRemoteBPT(nextIndex) = {tempThread, "remote"}
        ''#############get information of thread END##########################
        exitValue = 0
        'Logic: will refresh  each server to get its UFT status, when find a "ready" UFT, will use it to execute BPT which is in status "ready".
        'the server's status that are defined in function "CheckRemoteServerUFTStatus"
        'disct - the remote UFT is disconnect
        'ready - the remote UFT is ready
        'busy - the remote UFT is busy
        'notlaunch - the remote UFT is not launched
        'process - remote UFT is processing BPTs assigned
        'timeout - the UFT server is disconneted expire the timeout setting
        'arryServerFullyInfo -  two dimension arry. It contains "{execute path, server path,server status,UFT assgined to the server, BPT assigned to the server}" of each server

        '########################notice###########################
        'RaiseEvent SetEnableToBt_Cancel(True) 'enable the cancel button
        'Dim holdforuser As Integer = 5
        'RaiseEvent AddMessageToTB_MainLog("will start remote run in <" + CStr(holdforuser) + "> seconds", vbCrLf)
        'For k = 1 To holdforuser 'give time to use to stop the run
        '    'RaiseEvent AddMessageToTB_MainLog(CStr(holdforuser - k + 1) + "s", "  ")
        '    waitTime(1000)
        'Next
        ' RaiseEvent AddMessageToTB_MainLog(vbCrLf, "")
        '########################notice END###########################
        Class_ExcelOperator2.sharefolder = shareReportFolder
        Dim intServerIndex = 0
        Dim intMaxServerIndex = UBound(arryServerFullyInfo)
        Dim curServerStatus As String = ""
        Dim curUFT As Object = Nothing
        Dim refreshServerSeconds As Integer = 30000
        Dim STAFProc As Process = Nothing

        Do Until blnCancelRemote 'will still run until all BPTs are done in all servers 
            'sync resource 
            Dim syncwaittime = 5
            Dim cur = Now
            synchroPointSTOfRemote = 0
            Do
                waitTime(100)
            Loop Until DateDiff(DateInterval.Second, cur, Now) >= syncwaittime
            synchroPointSTOfRemote = 1

            If IsSyncVarReady(syncStatusLockOfRemote) Then

                If CheckSyncRequestStatus(syncStatusOfRemote, syncStatusLockOfRemote) Then
                    Dim synchropointResponseTimeout = 120
                    Dim curtime = Now
                    Do
                        waitTime(100)

                    Loop Until CheckSyncRequestStatus(syncStatusOfRemote, syncStatusLockOfRemote) = False Or DateDiff(DateInterval.Second, curtime, Now) >= synchropointResponseTimeout
                    If CheckSyncRequestStatus(syncStatusOfRemote, syncStatusLockOfRemote) = False Then
                    Else
                        For i = 0 To UBound(syncStatusOfRemote)
                            Dim st = False
                            If syncStatusOfRemote(i)(0) = True Then
                                st = ResponseSyncResult(syncStatusOfRemote, i, True, syncStatusLockOfRemote)
                            End If
                            If st = False Then
                                RaiseEvent AddMessageToTB_MainLogEvnt("Exception: unknown error on Destory Sync Var for thread for access reource of ExectionRandom_Remote!", vbCrLf)
                            End If
                        Next
                    End If
                End If
                Dim st1 = DestorySyncVar(syncStatusOfRemote, syncStatusLockOfRemote)
                If st1 = False Then
                    RaiseEvent AddMessageToTB_MainLogEvnt("Exception: unknown error on Destory Sync Var for thread for access reource of ExectionRandom_Remote!", vbCrLf)
                End If
            Else
                RaiseEvent AddMessageToTB_MainLogEvnt("Exception: unknown error on wait thread for access reource of ExectionRandom_Remote!", vbCrLf)
            End If
            'sync resource end

            ' Application.DoEvents()
            Dim findblnReadyTC = False
            Dim findblnRunTC = False
            Dim findblnNotAllTimeOut = False
            For i = 0 To UBound(arryRunList) ' Check if all BPT has been done
                If IsNothing(arryRunList(i)) = False Then
                    If arryRunList(i)(1) = "ready" Then
                        findblnReadyTC = True
                        Exit For
                    End If
                End If
            Next
            If findblnReadyTC Then
            Else
                For n = 0 To UBound(arryRunList) ' Check if all BPT has been done
                    If IsNothing(arryRunList(n)) = False Then
                        If arryRunList(n)(1) = "run" Then
                            findblnRunTC = True
                            Exit For
                        End If
                    End If

                Next
                If findblnRunTC Then
                Else
                    Exit Do ' out the loop when all BPTs are done
                End If
            End If
            For c = 0 To UBound(arryServerFullyInfo)
                If IsNothing(arryServerFullyInfo(c)) Then
                Else
                    If arryServerFullyInfo(c)(2) <> "timeout" Then
                        findblnNotAllTimeOut = True
                        Exit For
                    End If
                End If
            Next
            If findblnNotAllTimeOut = False Then
                blnCancelRemote = True
                Exit Do
            End If
            If findblnReadyTC Then
                If IsNothing(arryServerFullyInfo(intServerIndex)) Then
                    curServerStatus = "skipassignwork"
                Else
                    If arryServerFullyInfo(intServerIndex)(2) = "process" Or arryServerFullyInfo(intServerIndex)(2) = "timeout" Then ' verify if the server is still processing the BPT assigned
                        curServerStatus = "skipassignwork"
                    Else
                        If projectType = "UFT Project" Then
                            If IsNothing(arryServerFullyInfo(intServerIndex)(3)) Then
                                GoTo CreateObj
                            Else
                                curServerStatus = CheckRemoteServerUFTStatus(arryServerFullyInfo(intServerIndex)(3))
                            End If
                        End If
                        If projectType = "Maven Project" Then
                            If IsNothing(STAFProc) Then
                                RaiseEvent AddMessageToTB_MainLogEvnt("Launching STAFProc, please wait a while", vbCrLf)
                                Dim STAFArray = launchStaf()
                                STAFProc = STAFArray(0)
                                If STAFArray(1) Then
                                    RaiseEvent AddMessageToTB_MainLogEvnt("STAFProc is launched successfully", vbCrLf)
                                    curServerStatus = "ready"
                                Else
                                    RaiseEvent AddMessageToTB_MainLogEvnt("It is failed to launch STAFProc: " + STAFArray(2), vbCrLf)
                                    RemoteErrorRun = True
                                    Exit Do
                                End If
                            End If
                           

                        End If
                    End If
                End If
                Select Case curServerStatus
                    Case "disct"
CreateObj:
                        'RaiseEvent AddMessageToTB_MainLog("Server [" + arryServerFullyInfo(intServerIndex)(1) + "] is being connected", vbCrLf)
                        On Error Resume Next
                        arryServerFullyInfo(intServerIndex)(3) = CreateUFT(arryServerFullyInfo(intServerIndex)(1))
                        If Err.Number <> 0 Then
                            RaiseEvent AddMessageToTB_MainLogEvnt("Error: [" + arryServerFullyInfo(intServerIndex)(1) + "] gets problem on connecting server, will try again after a while " + CStr(Now) + ". Description:" + Err.Description + ". Error Code:" + CStr(Err.Number), vbCrLf)
                            arryServerFullyInfo(intServerIndex)(3) = Nothing
                            arryServerFullyInfo(intServerIndex)(2) = "disct"
                            'RaiseEvent AddMessageToTB_MainLog("<Server> " + arryServerFullyInfo(intServerIndex)(1) + "'s UFT status is [disct]", vbCrLf)
                            On Error GoTo 0
                        Else
                            'RaiseEvent AddMessageToTB_MainLog("<Server> " + arryServerFullyInfo(intServerIndex)(1) + " has been connected", vbCrLf)
                            Dim laterServerStatus As String = CheckRemoteServerUFTStatus(arryServerFullyInfo(intServerIndex)(3))
                            Select Case laterServerStatus
                                Case "notlaunch"
                                    arryServerFullyInfo(intServerIndex)(2) = "notlaunch"
                                    GoTo LauchUFTObj
                                Case "ready"
                                    arryServerFullyInfo(intServerIndex)(2) = "ready"
                                    GoTo RunTest
                                Case "busy"
                                    arryServerFullyInfo(intServerIndex)(2) = "busy"
                                    'RaiseEvent AddMessageToTB_MainLog("<Server> " + arryServerFullyInfo(intServerIndex)(1) + "'s UFT status is [busy]", vbCrLf)
                                Case "disct"
                                    arryServerFullyInfo(intServerIndex)(3) = Nothing
                                    arryServerFullyInfo(intServerIndex)(2) = "disct"
                                    'RaiseEvent AddMessageToTB_MainLog("<Server> " + arryServerFullyInfo(intServerIndex)(1) + "'s UFT status is [disct]", vbCrLf)
                            End Select
                        End If
                    Case "notlaunch"
LauchUFTObj:
                        'RaiseEvent AddMessageToTB_MainLog("server " + arryServerFullyInfo(intServerIndex)(1) + "'s UFT status is [notlaunch]", vbCrLf)
                        On Error Resume Next
                        arryServerFullyInfo(intServerIndex)(3).launch()
                        If Err.Number <> 0 Then
                            RaiseEvent AddMessageToTB_MainLogEvnt("Error: [" + arryServerFullyInfo(intServerIndex)(1) + "] gets problem on launching UFT, will try again after a while " + CStr(Now) + ". Description:" + CStr(Err.Number) + "-" + Err.Description, vbCrLf)
                            arryServerFullyInfo(intServerIndex)(3) = Nothing
                            arryServerFullyInfo(intServerIndex)(2) = "disct"
                            'RaiseEvent AddMessageToTB_MainLog("<Server> " + arryServerFullyInfo(intServerIndex)(1) + "'s UFT status is [disct]", vbCrLf)
                            On Error GoTo 0
                        Else

                            On Error Resume Next
                            UFTAppSet(arryServerFullyInfo(intServerIndex)(3))
                            If Err.Number <> 0 Then
                                RaiseEvent AddMessageToTB_MainLogEvnt("Error: [" + arryServerFullyInfo(intServerIndex)(1) + "] gets problem on configuring UFT, will try again after a while " + CStr(Now) + ". Description:" + Err.Description + ". Error Code:" + CStr(Err.Number), vbCrLf)
                                arryServerFullyInfo(intServerIndex)(3) = Nothing
                                arryServerFullyInfo(intServerIndex)(2) = "disct"
                                'RaiseEvent AddMessageToTB_MainLog("<Server> " + arryServerFullyInfo(intServerIndex)(1) + "'s UFT status is [disct]", vbCrLf)
                                On Error GoTo 0
                            Else
                                'RaiseEvent AddMessageToTB_MainLog("<Server> " + arryServerFullyInfo(intServerIndex)(1) + " has been configured right", vbCrLf)
                                arryServerFullyInfo(intServerIndex)(2) = "ready"
                                GoTo RunTest
                            End If
                            'End If
                        End If
                    Case "busy"
                        arryServerFullyInfo(intServerIndex)(2) = "busy"
                    Case "ready"
RunTest:
                        arryServerFullyInfo(intServerIndex)(2) = "ready"
                        Dim arryBPTSelectedForServer(OneTimeNumber) As String ' work with sub "RunBPTs" to let it know which BPT should be run
                        Dim countFillTimes As Integer = 0
                        For h = 0 To UBound(arryRunList) ' find file for run
                            If IsNothing(arryRunList(h)) = False Then
                                If arryRunList(h)(0) = "" Then
                                    arryRunList(h)(1) = "removed"
                                Else
                                    If arryRunList(h)(1) = "ready" Then
                                        arryBPTSelectedForServer(countFillTimes) = arryRunList(h)(0)
                                        arryRunList(h)(1) = "run" 'set the status to the BPT for avoid other server try them
                                        arryRunList(h)(2) = arryServerFullyInfo(intServerIndex)(1) 'put server path to arryRunList
                                        countFillTimes = countFillTimes + 1
                                        If countFillTimes = UBound(arryBPTSelectedForServer) + 1 Then
                                            Exit For
                                        End If
                                    End If
                                End If
                            End If

                        Next
                        Dim finalArryBPTSelectedForServer(0) As String
                        finalArryBPTSelectedForServer(0) = ""
                        Dim number As Integer = 0
                        For p = 0 To UBound(arryBPTSelectedForServer)
                            If arryBPTSelectedForServer(p) <> "" Then
                                ReDim Preserve finalArryBPTSelectedForServer(number)
                                finalArryBPTSelectedForServer(number) = arryBPTSelectedForServer(p)
                                'RaiseEvent AddMessageToTB_MainLog("Arrange [" + arryServerFullyInfo(intServerIndex)(1) + "] to execute [" + finalArryBPTSelectedForServer(number) + "]", vbCrLf)
                                number = number + 1
                            End If

                        Next
                        arryBPTSelectedForServer = Nothing
                        arryServerFullyInfo(intServerIndex)(4) = finalArryBPTSelectedForServer
                        finalArryBPTSelectedForServer = Nothing ' initiate for next assign
                        arryServerFullyInfo(intServerIndex)(2) = "process" ' this status is not get from UFT but signs the server is processing BPTs and will be changed to "ready" in Thread "RunBPTs_OnlyForRemote"
                        'RaiseEvent AddMessageToTB_MainLog("<Server> " + arryServerFullyInfo(intServerIndex)(1) + "'s UFT status is [process]", vbCrLf)
                        If UBound(arryServerFullyInfo(intServerIndex)(4)) = 0 And arryServerFullyInfo(intServerIndex)(4)(0) = "" Then
                        Else
                            Dim mythread As Thread = Nothing

                            If projectType = "UFT Project" Then
                                mythread = New Thread(AddressOf RunBPTs_OnlyForRemote)
                            End If

                            If projectType = "Maven Project" Then
                                mythread = New Thread(AddressOf RunMVNTest_OnlyForRemote)
                            End If
                            '#################get the thread###################

                            'Debug.Print(CStr(Now) + "reach thread")
                            Dim newIndex As Integer = UBound(arryForThreadWhichRunRemoteBPT) + 1
                            ReDim Preserve arryForThreadWhichRunRemoteBPT(newIndex)
                            arryForThreadWhichRunRemoteBPT(newIndex) = {mythread, arryServerFullyInfo(intServerIndex)(3), arryServerFullyInfo(intServerIndex)(1)}
                            '#################get the thread END###################

                            mythread.IsBackground = True
                            mythread.Start(arryServerFullyInfo(intServerIndex))
                            'ThreadPool.QueueUserWorkItem(New WaitCallback(AddressOf RunBPTs_OnlyForRemote), arryServerFullyInfo(intServerIndex))
                            RaiseEvent AddMessageToTB_MainLogEvnt("Arrange [" + arryServerFullyInfo(intServerIndex)(1) + "] to execute test missions", vbCrLf)
                        End If



                        Debug.Print(CStr(Now) + "send case")

                End Select
            End If
            intServerIndex = intServerIndex + 1
            If intServerIndex = intMaxServerIndex + 1 Then
                intServerIndex = 0 ' all server has been checked, go to next iteration check
                'RaiseEvent AddMessageToTB_MainLog("<Refresh> Will refresh servers' status again in <" + CStr(refreshServerSeconds / 1000) + "> seconds", vbCrLf)
                'Debug.Print("<Refresh> Will refresh servers' status again in <" + CStr(refreshServerSeconds) + "seconds>")
                waitTime(refreshServerSeconds)

            End If
        Loop
        '#####wait all threads to end and then out the sub########
        'Dim AvailableWorker As Integer
        'Dim AvailablePorts As Integer
        'Dim MaxWorker As Integer
        'Dim MaxPorts As Integer
        'ThreadPool.GetAvailableThreads(AvailableWorker, AvailablePorts)
        'ThreadPool.GetMaxThreads(MaxWorker, MaxPorts)
        'Do Until AvailableWorker = MaxWorker And AvailablePorts = MaxPorts
        '    ThreadPool.GetAvailableThreads(AvailableWorker, AvailablePorts)
        '    ThreadPool.GetMaxThreads(MaxWorker, MaxPorts)
        '    RaiseEvent AddMessageToTB_MainLog("Some threads is working, please wait they to end", vbCrLf)
        '    waitTime(20000)
        'Loop
        '#####wait all threads to end and then out the sub END########
        If blnCancelRemote Then
            exitValue = 3
        Else
            If RemoteErrorRun Then
                exitValue = 1
            Else
                exitValue = 2
            End If
        End If
    End Sub
    Sub ExectionCustom_Remote()

        ''#############get information of thread##########################
        'Dim tempThread As Thread = Threading.Thread.CurrentThread
        '' tempThread.IsBackground = True
        'Dim nextIndex As Integer = UBound(arryForThreadWhichRunRemoteBPT) + 1
        'ReDim Preserve arryForThreadWhichRunRemoteBPT(nextIndex)
        'arryForThreadWhichRunRemoteBPT(nextIndex) = {tempThread, "CustomRemote"}
        ''#############get information of thread END##########################
        exitValue = 0
        'Logic: will refresh  each server to get its UFT status, when find a "ready" UFT, will use it to execute BPT which is in status "ready".
        'the server's status that are defined in function "CheckRemoteServerUFTStatus"
        'disct - the remote UFT is disconnect
        'ready - the remote UFT is ready
        'busy - the remote UFT is busy
        'notlaunch - the remote UFT is not launched
        'process - remote UFT is processing BPTs assigned
        'timeout - the UFT server is disconneted expire the timeout setting
        'arryServerFullyInfo -  two dimension arry. It contains "{execute path, server path,server status,UFT assgined to the server, BPT assigned to the server}" of each server

        '########################notice###########################
        'RaiseEvent SetEnableToBt_Cancel(True) 'enable the cancel button
        'Dim holdforuser As Integer = 5
        'RaiseEvent AddMessageToTB_MainLog("will start remote run in <" + CStr(holdforuser) + "> seconds", vbCrLf)
        'For k = 1 To holdforuser 'give time to use to stop the run
        '    'RaiseEvent AddMessageToTB_MainLog(CStr(holdforuser - k + 1) + "s", "  ")
        '    waitTime(1000)
        'Next
        ' RaiseEvent AddMessageToTB_MainLog(vbCrLf, "")
        '########################notice END###########################
        Class_ExcelOperator2.sharefolder = shareReportFolder
        Dim intServerIndex = 0
        Dim intMaxServerIndex = UBound(arryServerFullyInfo)
        Dim curServerStatus As String = ""
        Dim curUFT As Object = Nothing
        Dim refreshServerSeconds As Integer = 5000
        Dim STAFProc As Process = Nothing

        Do Until blnCancelRemote 'will still run until all BPTs are done in all servers 

            'sync resource 
            Dim syncwaittime = 5
            Dim cur = Now
            synchroPointSTOfCustomRemote = 0
            Do
                waitTime(100)
            Loop Until DateDiff(DateInterval.Second, cur, Now) >= syncwaittime
            synchroPointSTOfCustomRemote = 1

            If IsSyncVarReady(syncStatusLockOfCustomRemote) Then

                If CheckSyncRequestStatus(syncStatusOfCustomRemote, syncStatusLockOfCustomRemote) Then
                    Dim synchropointResponseTimeout = 120
                    Dim curtime = Now
                    Do
                        waitTime(100)

                    Loop Until CheckSyncRequestStatus(syncStatusOfCustomRemote, syncStatusLockOfCustomRemote) = False Or DateDiff(DateInterval.Second, curtime, Now) >= synchropointResponseTimeout
                    If CheckSyncRequestStatus(syncStatusOfCustomRemote, syncStatusLockOfCustomRemote) = False Then

                    Else
                        For i = 0 To UBound(syncStatusOfCustomRemote)
                            Dim st = False
                            If syncStatusOfCustomRemote(i)(0) = True Then
                                st = ResponseSyncResult(syncStatusOfCustomRemote, i, True, syncStatusLockOfCustomRemote)
                            End If
                            If st = False Then
                                RaiseEvent AddMessageToTB_MainLogEvnt("Exception: unknown error on Response Sync Result to thread for access reource of ExectionCustom_Remote!", vbCrLf)
                            End If
                        Next
                    End If
                End If
                Dim st1 = DestorySyncVar(syncStatusOfCustomRemote, syncStatusLockOfCustomRemote)
                If st1 = False Then
                    RaiseEvent AddMessageToTB_MainLogEvnt("Exception: unknown error on Destory Sync Var for thread for access reource of ExectionCustom_Remote!", vbCrLf)
                End If
            Else
                RaiseEvent AddMessageToTB_MainLogEvnt("Exception: unknown error on wait thread for access reource of ExectionCustom_Remote!", vbCrLf)
            End If
            'sync resource end

            ' Application.DoEvents()
            Dim findblnRunAbleTC = False
            Dim findblnNotAllTimeOut = False
            For i = 0 To UBound(arryRunList) ' Check if all BPT has been done
                If IsNothing(arryRunList(i)) = False Then
                    If (arryRunList(i)(1) = "ready" Or arryRunList(i)(1) = "run") Then
                        Dim findMatchedServer = False
                        For c = 0 To UBound(arryServerFullyInfo)
                            If IsNothing(arryServerFullyInfo(c)) Then
                            Else
                                If arryRunList(i)(2) = arryServerFullyInfo(c)(1) Then

                                    If arryServerFullyInfo(c)(2) <> "timeout" Then
                                        findMatchedServer = True
                                    Else
                                        findMatchedServer = False

                                    End If
                                    Exit For
                                End If

                            End If
                        Next
                        If findMatchedServer = True Then
                            findblnRunAbleTC = True
                            Exit For
                        End If

                    End If
                End If

            Next
            If findblnRunAbleTC = False Then
                Exit Do
            End If
            For c = 0 To UBound(arryServerFullyInfo)
                If IsNothing(arryServerFullyInfo(c)) Then
                Else
                    If arryServerFullyInfo(c)(2) <> "timeout" Then
                        findblnNotAllTimeOut = True
                        Exit For
                    End If
                End If
            Next
            If findblnNotAllTimeOut = False Then
                blnCancelRemote = True
                Exit Do
            End If
            For intServerIndex = 0 To UBound(arryServerFullyInfo)
                If IsNothing(arryServerFullyInfo(intServerIndex)) = False Then
                    'Dim findNoRunOfDerver As Boolean = False
                    'For gg = 0 To UBound(arryRunList)
                    '    If IsNothing(arryRunList(gg)) = False Then
                    '        If arryRunList(gg)(2) = arryServerFullyInfo(intServerIndex)(1) Then
                    '            If arryRunList(gg)(1) = "ready" Then
                    '                findNoRunOfDerver = True
                    '                Exit For
                    '            End If
                    '        End If
                    '    End If

                    'Next


                    'RaiseEvent AddMessageToTB_MainLog("monitoring remote ufts status", vbCrLf)
                    If IsNothing(arryServerFullyInfo(intServerIndex)) Then
                        curServerStatus = "skipassignwork"
                    Else
                        If arryServerFullyInfo(intServerIndex)(2) = "process" Or arryServerFullyInfo(intServerIndex)(2) = "timeout" Then ' verify if the server is still processing the BPT assigned
                            curServerStatus = "skipassignwork"
                            'RaiseEvent AddMessageToTB_MainLog("Server [" + arryServerFullyInfo(intServerIndex)(1) + "] UFT is working.", vbCrLf)
                            'RaiseEvent AddMessageToTB_MainLog("<Server> " + arryServerFullyInfo(intServerIndex)(1) + "'s UFT status is [process]", vbCrLf)
                        Else
                            If projectType = "UFT Project" Then
                                If IsNothing(arryServerFullyInfo(intServerIndex)(3)) Then
                                    GoTo CreateUFTObj
                                Else
                                    curServerStatus = CheckRemoteServerUFTStatus(arryServerFullyInfo(intServerIndex)(3))
                                End If
                            End If
                            If projectType = "Maven Project" Then
                                If IsNothing(STAFProc) Then
                                    RaiseEvent AddMessageToTB_MainLogEvnt("Launching STAFProc, please wait a while", vbCrLf)
                                    Dim STAFArray = launchStaf()
                                    STAFProc = STAFArray(0)
                                    If STAFArray(1) Then
                                        RaiseEvent AddMessageToTB_MainLogEvnt("STAFProc is launched successfully", vbCrLf)
                                        curServerStatus = "ready"
                                    Else
                                        RaiseEvent AddMessageToTB_MainLogEvnt("It is failed to launch STAFProc: " + STAFArray(2), vbCrLf)
                                        RemoteErrorRun = True
                                        Exit Do
                                    End If
                                End If


                            End If
                        End If
                    End If
                    Select Case curServerStatus
                        Case "disct"
CreateUFTObj:
                            'RaiseEvent AddMessageToTB_MainLog("Server [" + arryServerFullyInfo(intServerIndex)(1) + "] is being connected", vbCrLf)
                            On Error Resume Next
                            arryServerFullyInfo(intServerIndex)(3) = CreateUFT(arryServerFullyInfo(intServerIndex)(1))
                            If Err.Number <> 0 Then
                                RaiseEvent AddMessageToTB_MainLogEvnt("Error: [" + arryServerFullyInfo(intServerIndex)(1) + "] gets problem on connecting server, will try again after a while " + CStr(Now) + ". Description:" + Err.Description + ". Error Code:" + CStr(Err.Number), vbCrLf)
                                arryServerFullyInfo(intServerIndex)(3) = Nothing
                                arryServerFullyInfo(intServerIndex)(2) = "disct"
                                'RaiseEvent AddMessageToTB_MainLog("<Server> " + arryServerFullyInfo(intServerIndex)(1) + "'s UFT status is [disct]", vbCrLf)
                                On Error GoTo 0
                            Else
                                'RaiseEvent AddMessageToTB_MainLog("<Server> " + arryServerFullyInfo(intServerIndex)(1) + " has been connected", vbCrLf)
                                Dim laterServerStatus As String = CheckRemoteServerUFTStatus(arryServerFullyInfo(intServerIndex)(3))
                                Select Case laterServerStatus
                                    Case "notlaunch"
                                        arryServerFullyInfo(intServerIndex)(2) = "notlaunch"
                                        GoTo LauchUFTObj
                                    Case "ready"
                                        arryServerFullyInfo(intServerIndex)(2) = "ready"
                                        GoTo RunTestObj
                                    Case "busy"
                                        arryServerFullyInfo(intServerIndex)(2) = "busy"
                                        'RaiseEvent AddMessageToTB_MainLog("<Server> " + arryServerFullyInfo(intServerIndex)(1) + "'s UFT status is [busy]", vbCrLf)
                                    Case "disct"
                                        arryServerFullyInfo(intServerIndex)(3) = Nothing
                                        arryServerFullyInfo(intServerIndex)(2) = "disct"
                                        'RaiseEvent AddMessageToTB_MainLog("<Server> " + arryServerFullyInfo(intServerIndex)(1) + "'s UFT status is [disct]", vbCrLf)
                                End Select
                            End If
                        Case "notlaunch"
LauchUFTObj:
                            'RaiseEvent AddMessageToTB_MainLog("server " + arryServerFullyInfo(intServerIndex)(1) + "'s UFT status is [notlaunch]", vbCrLf)
                            On Error Resume Next
                            arryServerFullyInfo(intServerIndex)(3).launch()
                            If Err.Number <> 0 Then
                                RaiseEvent AddMessageToTB_MainLogEvnt("Error: [" + arryServerFullyInfo(intServerIndex)(1) + "] gets problem on launching UFT, will try again after a while " + CStr(Now) + ". Description:" + CStr(Err.Number) + "-" + Err.Description, vbCrLf)
                                arryServerFullyInfo(intServerIndex)(3) = Nothing
                                arryServerFullyInfo(intServerIndex)(2) = "disct"
                                'RaiseEvent AddMessageToTB_MainLog("<Server> " + arryServerFullyInfo(intServerIndex)(1) + "'s UFT status is [disct]", vbCrLf)
                                On Error GoTo 0
                            Else

                                On Error Resume Next
                                UFTAppSet(arryServerFullyInfo(intServerIndex)(3))
                                If Err.Number <> 0 Then
                                    RaiseEvent AddMessageToTB_MainLogEvnt("Error: [" + arryServerFullyInfo(intServerIndex)(1) + "] gets problem on configuring UFT, will try again after a while " + CStr(Now) + ". Description:" + Err.Description + ". Error Code:" + CStr(Err.Number), vbCrLf)
                                    arryServerFullyInfo(intServerIndex)(3) = Nothing
                                    arryServerFullyInfo(intServerIndex)(2) = "disct"
                                    'RaiseEvent AddMessageToTB_MainLog("<Server> " + arryServerFullyInfo(intServerIndex)(1) + "'s UFT status is [disct]", vbCrLf)
                                    On Error GoTo 0
                                Else
                                    'RaiseEvent AddMessageToTB_MainLog("<Server> " + arryServerFullyInfo(intServerIndex)(1) + " has been configured right", vbCrLf)
                                    arryServerFullyInfo(intServerIndex)(2) = "ready"
                                    GoTo RunTestObj
                                End If
                                'End If
                            End If
                        Case "busy"
                            arryServerFullyInfo(intServerIndex)(2) = "busy"
                            'RaiseEvent AddMessageToTB_MainLog("<Server> " + arryServerFullyInfo(intServerIndex)(1) + "'s UFT status is [busy]", vbCrLf)
                        Case "ready"
RunTestObj:
                            arryServerFullyInfo(intServerIndex)(2) = "ready"
                            'RaiseEvent AddMessageToTB_MainLog("<Server> " + arryServerFullyInfo(intServerIndex)(1) + "'s UFT status is [ready]", vbCrLf)

                            'Debug.Print(CStr(Now) + "find case")
                            'RaiseEvent AddMessageToTB_MainLog("sending task to server [" + arryServerFullyInfo(intServerIndex)(1) + "]", vbCrLf)

                            Dim finalArryBPTSelectedForServer(0) As String
                            finalArryBPTSelectedForServer(0) = ""
                            Dim number As Integer = 0
                            For p = 0 To UBound(arryRunList)
                                If IsNothing(arryRunList(p)) = False Then


                                    If arryRunList(p)(2) = arryServerFullyInfo(intServerIndex)(1) Then
                                        If arryRunList(p)(0) <> "" Then
                                            If arryRunList(p)(1) = "ready" Then
                                                ReDim Preserve finalArryBPTSelectedForServer(number)
                                                finalArryBPTSelectedForServer(number) = arryRunList(p)(0)
                                                arryRunList(p)(1) = "run"
                                                'RaiseEvent AddMessageToTB_MainLog("Arrange [" + arryServerFullyInfo(intServerIndex)(1) + "] to execute [" + finalArryBPTSelectedForServer(number) + "]", vbCrLf)
                                                number = number + 1
                                            End If
                                        Else
                                            arryRunList(p)(1) = "removed"
                                        End If
                                    End If
                                End If
                            Next
                            arryServerFullyInfo(intServerIndex)(4) = finalArryBPTSelectedForServer
                            finalArryBPTSelectedForServer = Nothing ' initiate for next assign
                            arryServerFullyInfo(intServerIndex)(2) = "process" ' this status is not get from UFT but signs the server is processing BPTs and will be changed to "ready" in Thread "RunBPTs_OnlyForRemote"
                            'RaiseEvent AddMessageToTB_MainLog("<Server> " + arryServerFullyInfo(intServerIndex)(1) + "'s UFT status is [process]", vbCrLf)
                            If UBound(arryServerFullyInfo(intServerIndex)(4)) = 0 And arryServerFullyInfo(intServerIndex)(4)(0) = "" Then
                            Else
                                Dim mythread As Thread = Nothing

                                If projectType = "UFT Project" Then
                                    mythread = New Thread(AddressOf RunBPTs_OnlyForRemote)
                                End If

                                If projectType = "Maven Project" Then
                                    mythread = New Thread(AddressOf RunMVNTest_OnlyForRemote)
                                End If
                                '#################get the thread###################

                                'Debug.Print(CStr(Now) + "reach thread")
                                Dim newIndex As Integer = UBound(arryForThreadWhichRunRemoteBPT) + 1
                                ReDim Preserve arryForThreadWhichRunRemoteBPT(newIndex)
                                arryForThreadWhichRunRemoteBPT(newIndex) = {mythread, arryServerFullyInfo(intServerIndex)(3), arryServerFullyInfo(intServerIndex)(1)}
                                '#################get the thread END###################

                                mythread.IsBackground = True
                                mythread.Start(arryServerFullyInfo(intServerIndex))
                                'ThreadPool.QueueUserWorkItem(New WaitCallback(AddressOf RunBPTs_OnlyForRemote), arryServerFullyInfo(intServerIndex))
                                RaiseEvent AddMessageToTB_MainLogEvnt("Arrange [" + arryServerFullyInfo(intServerIndex)(1) + "] to execute test missions", vbCrLf)
                            End If

                            Debug.Print(CStr(Now) + "send case")
                    End Select

                End If
            Next

            waitTime(refreshServerSeconds)
        Loop

        If blnCancelRemote Then
            exitValue = 3
        Else
            If RemoteErrorRun Then
                exitValue = 1
            Else
                exitValue = 2
            End If
        End If
    End Sub
    '##########################################################################
    'Creating an object on a remote server can only be accomplished when Internet security is turned off. 
    'You can create an object on a remote networked computer by passing the name of the computer 
    'to the servername argument of CreateObject. That name is the same as the machine name portion of a share name. 
    'For a network share named "\\myserver\public", the servername is "myserver". In addition, you can specify 
    'servername using DNS format or an IP address.
    '########################################################################
    Function CreateUFT(ByVal location As String) As Object
        Dim qtApp As Object = CreateObject("QuickTest.Application", location)
        Return qtApp
    End Function

    Function GetUFT(ByVal path As String) As Object
        Dim qtApp As Object = GetObject("QuickTest.Application")
        Return qtApp
    End Function
    Sub LaunchUFT(ByRef qtApp As Object)
        qtApp.Launch()
    End Sub
    Function OpenUFTTest(ByRef qtApp As Object, ByVal CasePath As String, ByVal OpenInReadOnlyMode As Boolean, ByVal SaveCurrent As Boolean) As Object
        qtApp.open(CasePath, OpenInReadOnlyMode, SaveCurrent)
        Dim hasFolders = False
        Dim tempFolders = GetUFTValue(UFTConfigStream, "qtApp.Folders.Add")
        If IsNothing(tempFolders) Then
        Else
            hasFolders = True
        End If

        If hasFolders Then
            Dim qtFolders As Object = qtApp.Folders ' Get the Folders collection object
            qtFolders.RemoveAll()
            If IsArray(tempFolders) Then
                For i = 0 To UBound(tempFolders)
                    Dim strPath = tempFolders(i)
                    'Dim strPath = qtFolders.Locate(tempFolders(i))
                    'If strPath <> "" Then
                    qtFolders.Add(strPath, i + 1)
                    'End If
                Next
            Else
                'Dim strPath = qtFolders.Locate(tempFolders)
                'If strPath <> "" Then
                Dim strPath = tempFolders
                qtFolders.Add(strPath, 1)
                'End If
            End If
            qtFolders = Nothing
        End If

        Dim qtTest As Object = qtApp.Test ' set run settings for the test
        Return qtTest
    End Function
    Function OpenUFTTest_Remote(ByRef qtApp As Object, ByVal CasePath As String, ByVal OpenInReadOnlyMode As Boolean, ByVal SaveCurrent As Boolean) As Object
        qtApp.open(CasePath, OpenInReadOnlyMode, SaveCurrent)
        Dim hasFolders = False
        Dim tempFolders = GetUFTValue(UFTConfigStream, "qtApp.Folders.Add")
        If IsNothing(tempFolders) Then
        Else
            hasFolders = True
        End If

        If hasFolders Then
            Dim qtFolders As Object = qtApp.Folders ' Get the Folders collection object
            qtFolders.RemoveAll()
            If IsArray(tempFolders) Then
                For i = 0 To UBound(tempFolders)
                    Dim strPath = Replace(tempFolders(i), "..\..\", Split(CasePath, "BPT")(0))
                    'Dim strPath = qtFolders.Locate(tempFolders(i))
                    'If strPath <> "" Then
                    qtFolders.Add(strPath, i + 1)
                    'End If
                Next
            Else
                'Dim strPath = qtFolders.Locate(tempFolders)
                'If strPath <> "" Then
                Dim strPath = Replace(tempFolders, "..\..\", Split(CasePath, "BPT")(0))
                qtFolders.Add(strPath, 1)
                'End If
            End If
            qtFolders = Nothing
        End If

        Dim qtTest As Object = qtApp.Test ' set run settings for the test
        Return qtTest
    End Function

    Sub UFTAppSet(ByRef qtApp As Object) ' this function just can be called once a UFT is launched
        qtApp.WindowState = "Minimized" ' Maximize the QuickTest window
        qtApp.Options.ActiveScreen.CaptureLevel = "None"
        Dim temp
        temp = GetUFTValue(UFTConfigStream, "qtApp.Visible")
        If IsNothing(temp) Then
        Else
            qtApp.Visible = temp
        End If

        temp = GetUFTValue(UFTConfigStream, "qtApp.Options.Run.ImageCaptureForTestResults")
        If IsNothing(temp) Then
        Else
            qtApp.Options.Run.ImageCaptureForTestResults = temp
        End If

        temp = GetUFTValue(UFTConfigStream, "qtApp.Options.Run.MovieCaptureForTestResults")
        If IsNothing(temp) Then
        Else
            qtApp.Options.Run.MovieCaptureForTestResults = temp
        End If

        temp = GetUFTValue(UFTConfigStream, "qtApp.Options.Run.SaveMovieOfEntireRun")
        If IsNothing(temp) Then
        Else
            qtApp.Options.Run.SaveMovieOfEntireRun = temp
        End If

        temp = GetUFTValue(UFTConfigStream, "qtApp.Options.Run.MovieSegmentSize")
        If IsNothing(temp) Then
        Else
            qtApp.Options.Run.MovieSegmentSize = temp
        End If

        temp = GetUFTValue(UFTConfigStream, "qtApp.Options.Run.RunMode")
        If IsNothing(temp) Then
        Else
            qtApp.Options.Run.RunMode = temp
        End If

        temp = GetUFTValue(UFTConfigStream, "qtApp.Options.Run.ViewResults")
        If IsNothing(temp) Then
        Else
            qtApp.Options.Run.ViewResults = temp
        End If

    End Sub
    Function UFEAppTestSet(ByRef qtApp As Object, ByVal inject As String) ' this function just can be called once a test has been opened in a UFT



        Dim qtTest As Object = qtApp.Test
        Dim temp
        temp = GetUFTValue(UFTConfigStream, "qtApp.Test.Settings.Web.BrowserNavigationTimeout")
        If IsNothing(temp) Then
        Else
            qtTest.Settings.Web.BrowserNavigationTimeout = temp
        End If

        temp = GetUFTValue(UFTConfigStream, "qtApp.Test.Settings.Run.ObjectSyncTimeOut")
        If IsNothing(temp) Then
        Else
            qtTest.Settings.Run.ObjectSyncTimeOut = temp
        End If

        temp = GetUFTValue(UFTConfigStream, "qtApp.Test.Settings.Run.IterationMode")
        If IsNothing(temp) Then
        Else
            qtTest.Settings.Run.IterationMode = temp
        End If

        temp = GetUFTValue(UFTConfigStream, "qtApp.Test.Settings.Run.OnError")
        If IsNothing(temp) Then
        Else
            qtTest.Settings.Run.OnError = temp
        End If

        temp = GetUFTValue(UFTConfigStream, "qtApp.Test.Settings.Run.DisableSmartIdentification")
        If IsNothing(temp) Then
        Else
            qtTest.Settings.Run.DisableSmartIdentification = temp
        End If

        'add defualt library---------
        Dim qtLibraries As Object = qtTest.Settings.Resources.Libraries ' Get the libraries collection object
        qtLibraries.RemoveAll()
        qtLibraries.Add(qtTest.Name + "_sql.vbs", 1)
        Dim actionCount = qtTest.Actions.Count
        Dim qtFolders As Object = qtApp.Folders ' Get the Folders collection object
        Dim strPath = "..\..\BC\"

        For i = 1 To actionCount
            Dim strBCName = qtTest.Actions.Item(i).Name
            If InStr(strBCName, "[") > 0 Then
                strBCName = Trim(Split(strBCName, "[")(1))
                strBCName = Trim(Split(strBCName, "]")(0))
            End If
            qtFolders.Add(strPath + strBCName, qtFolders.Count + 1)
            qtLibraries.Add(strBCName + "_sql.vbs", qtLibraries.Count + 1)
        Next
        'add defualt library END-------

        Dim hasLibraries = False
        Dim tempLibraries = GetUFTValue(UFTConfigStream, "qtApp.Test.Settings.Resources.Libraries.Add")
        If IsNothing(tempLibraries) Then
        Else
            hasLibraries = True
        End If
        If hasLibraries Then
            If IsArray(tempLibraries) Then
                For i = 0 To UBound(tempLibraries)
                    qtLibraries.Add(tempLibraries(i), qtLibraries.Count + 1)
                Next
            Else
                qtLibraries.Add(tempLibraries, qtLibraries.Count + 1)
            End If
            'qtLibraries.Add("..\..\Libraries\CommonFunctions.vbs") 'The path should be the same as the one shows on your local or VM
            'qtLibraries.Add("..\..\Libraries\CommonParameters.vbs") 'The path should be the same as the one shows on your local or VM
            qtLibraries = Nothing
        End If

        Dim hasRecovery = False
        Dim tempRecovery = GetUFTValue(UFTConfigStream, "qtApp.Test.Settings.Recovery.Add")
        If IsNothing(tempRecovery) Then
        Else
            hasRecovery = True
        End If
        If hasRecovery Then
            Dim qtTestRecovery As Object = qtTest.Settings.Recovery ' Return the Recovery object for the current test 
            On Error Resume Next
            qtTestRecovery.RemoveAll() ' Remove them 
            'Add recovery scenarios 

            If IsArray(tempRecovery) Then
                For i = 0 To UBound(tempRecovery)
                    qtTestRecovery.Add(tempRecovery(i), i + 1)
                Next
            Else
                qtTestRecovery.Add(tempRecovery, 1)
            End If
            'qtTestRecovery.Add("..\..\RecoveryScenario\ExploreOrIExploreCrash.qrs", "ExploreOrIExploreCrash", 1)
            'qtTestRecovery.Add("..\..\RecoveryScenario\IEWarning_DefaultBrower.qrs", "IEWarning_DefaultBrower", 1) ' For click yes to the warning about IE is not the default IE 
            '  qtTestRecovery.Add "..\..\RecoveryScenario\IEWarning_Security.qrs", "IEWarning_Security", 2 ' for click yes to the warning about IE security warning
            '  qtTestRecovery.Add "..\..\RecoveryScenario\RecordModified.qrs", "RecordModified", 3 'for the popup window which is caused by the record is modified by others.
            '  qtTestRecovery.Add "..\..\RecoveryScenario\CriticalResource.qrs", "CriticalResource", 2 ' For the popup window which is caused by the record is using by others'
            'Enable all scenarios 
            If Err.Number = 0 Then
                For intIndex = 1 To qtTestRecovery.Count ' Iterate the scenarios 
                    qtTestRecovery.Item(intIndex).Enabled = True ' Enable each Recovery Scenario (Note: the 'Item' property is default and can be omitted) 
                Next
                temp = GetUFTValue(UFTConfigStream, "qtApp.Test.Settings.Recovery.Enabled")
                If IsNothing(temp) Then
                Else
                    qtTestRecovery.Enabled = temp
                End If

                temp = GetUFTValue(UFTConfigStream, "qtApp.Test.Settings.Recovery.SetActivationMode")
                If IsNothing(temp) Then
                Else
                    qtTestRecovery.SetActivationMode(temp)
                End If

            End If
            On Error GoTo 0
            qtTestRecovery = Nothing
        End If

        Dim path = strTestReportPath & "\IDslog.txt"
        If inject = "" Then
            temp = GetUFTValue(UFTConfigStream, "qtApp.Test.Settings.Environment.Value.IDs")
            If IsNothing(temp) Then
                qtTest.Environment.Value("IDs") = ""
                Class_FileOperator1.WriteFile(path, "None")
            Else
                qtTest.Environment.Value("IDs") = temp 'for transport several IDs from Atester to BPTs
                Class_FileOperator1.WriteFile(path, temp)
            End If
        Else
            qtTest.Environment.Value("IDs") = inject
            Class_FileOperator1.WriteFile(path, inject)
        End If
        Return qtTest
    End Function
    Function UFEAppTestSet_Remote(ByRef qtApp As Object, ByVal CasePath As String, ByVal inject As String) ' this function just can be called once a test has been opened in a UFT
        Dim qtTest As Object = qtApp.Test
        Dim temp
        temp = GetUFTValue(UFTConfigStream, "qtApp.Test.Settings.Web.BrowserNavigationTimeout")
        If IsNothing(temp) Then
        Else
            qtTest.Settings.Web.BrowserNavigationTimeout = temp
        End If

        temp = GetUFTValue(UFTConfigStream, "qtApp.Test.Settings.Run.ObjectSyncTimeOut")
        If IsNothing(temp) Then
        Else
            qtTest.Settings.Run.ObjectSyncTimeOut = temp
        End If

        temp = GetUFTValue(UFTConfigStream, "qtApp.Test.Settings.Run.IterationMode")
        If IsNothing(temp) Then
        Else
            qtTest.Settings.Run.IterationMode = temp
        End If

        temp = GetUFTValue(UFTConfigStream, "qtApp.Test.Settings.Run.OnError")
        If IsNothing(temp) Then
        Else
            qtTest.Settings.Run.OnError = temp
        End If

        temp = GetUFTValue(UFTConfigStream, "qtApp.Test.Settings.Run.DisableSmartIdentification")
        If IsNothing(temp) Then
        Else
            qtTest.Settings.Run.DisableSmartIdentification = temp
        End If

        'add defualt library---------
        Dim qtLibraries As Object = qtTest.Settings.Resources.Libraries ' Get the libraries collection object
        qtLibraries.RemoveAll()
        qtLibraries.Add(qtTest.Name + "_sql.vbs", 1)
        Dim actionCount = qtTest.Actions.Count
        Dim qtFolders As Object = qtApp.Folders ' Get the Folders collection object
        Dim strPath = Split(CasePath, "BPT")(0) + "BC\"

        For i = 1 To actionCount
            Dim strBCName = Trim(qtTest.Actions.Item(i).Name)
            If InStr(strBCName, "[") > 0 Then
                strBCName = Trim(Split(strBCName, "[")(1))
                strBCName = Trim(Split(strBCName, "]")(0))
            End If

            qtFolders.Add(strPath + strBCName, 1)
            qtLibraries.Add(strBCName + "_sql.vbs", qtLibraries.Count + 1)
        Next
        'add defualt library END-------

        Dim hasLibraries = False
        Dim tempLibraries = GetUFTValue(UFTConfigStream, "qtApp.Test.Settings.Resources.Libraries.Add")
        If IsNothing(tempLibraries) Then
        Else
            hasLibraries = True
        End If

        If hasLibraries Then
            If IsArray(tempLibraries) Then
                For i = 0 To UBound(tempLibraries)
                    qtLibraries.Add(tempLibraries(i), qtLibraries.Count + 1)
                Next
            Else
                qtLibraries.Add(tempLibraries, qtLibraries.Count + 1)
            End If
            'qtLibraries.Add("..\..\Libraries\CommonFunctions.vbs") 'The path should be the same as the one shows on your local or VM
            'qtLibraries.Add("..\..\Libraries\CommonParameters.vbs") 'The path should be the same as the one shows on your local or VM
            qtLibraries = Nothing
        End If

        Dim hasRecovery = False
        Dim tempRecovery = GetUFTValue(UFTConfigStream, "qtApp.Test.Settings.Recovery.Add")
        If IsNothing(tempRecovery) Then
        Else
            hasRecovery = True
        End If
        If hasRecovery Then
            Dim qtTestRecovery As Object = qtTest.Settings.Recovery ' Return the Recovery object for the current test 
            On Error Resume Next
            qtTestRecovery.RemoveAll() ' Remove them 
            'Add recovery scenarios 

            If IsArray(tempRecovery) Then
                'Dim CasePath = qtTest.Environment.Value("TestDir")
                For i = 0 To UBound(tempRecovery)
                    qtTestRecovery.Add(Replace(tempRecovery(i), "..\..\", Split(CasePath, "BPT")(0)), i + 1)
                Next
            Else
                'Dim CasePath = qtTest.Environment.Value("TestDir")
                qtTestRecovery.Add(Replace(tempRecovery, "..\..\", Split(CasePath, "BPT")(0)), 1)
            End If
            'qtTestRecovery.Add("..\..\RecoveryScenario\ExploreOrIExploreCrash.qrs", "ExploreOrIExploreCrash", 1)
            'qtTestRecovery.Add("..\..\RecoveryScenario\IEWarning_DefaultBrower.qrs", "IEWarning_DefaultBrower", 1) ' For click yes to the warning about IE is not the default IE 
            '  qtTestRecovery.Add "..\..\RecoveryScenario\IEWarning_Security.qrs", "IEWarning_Security", 2 ' for click yes to the warning about IE security warning
            '  qtTestRecovery.Add "..\..\RecoveryScenario\RecordModified.qrs", "RecordModified", 3 'for the popup window which is caused by the record is modified by others.
            '  qtTestRecovery.Add "..\..\RecoveryScenario\CriticalResource.qrs", "CriticalResource", 2 ' For the popup window which is caused by the record is using by others'
            'Enable all scenarios 
            If Err.Number = 0 Then
                For intIndex = 1 To qtTestRecovery.Count ' Iterate the scenarios 
                    qtTestRecovery.Item(intIndex).Enabled = True ' Enable each Recovery Scenario (Note: the 'Item' property is default and can be omitted) 
                Next
                temp = GetUFTValue(UFTConfigStream, "qtApp.Test.Settings.Recovery.Enabled")
                If IsNothing(temp) Then
                Else
                    qtTestRecovery.Enabled = temp
                End If

                temp = GetUFTValue(UFTConfigStream, "qtApp.Test.Settings.Recovery.SetActivationMode")
                If IsNothing(temp) Then
                Else
                    qtTestRecovery.SetActivationMode(temp)
                End If

            End If
            On Error GoTo 0
            qtTestRecovery = Nothing
        End If

        qtTest.Environment.Value("IDs") = inject 'for transport several IDs from Atester to BPTs
        Return qtTest
    End Function
    Function SetupUFTResult(ByVal HostPath As String, ByVal strTestResultPath As String, ByVal qtpTN As String) As Object
        Dim qtResultsOpt As Object
        If HostPath = "" Then
            qtResultsOpt = CreateObject("QuickTest.RunResultsOptions") ' Create the Run Results Options object
        Else
            qtResultsOpt = CreateObject("QuickTest.RunResultsOptions", HostPath)
        End If
        qtResultsOpt.ResultsLocation = strTestResultPath + "\" + qtpTN ' Set the results location
        Return qtResultsOpt
    End Function
    Function CheckUFTHasException(ByRef qtApp As Object)
        If qtApp Is Nothing Then
            Return True
        Else
            Return False
        End If
    End Function

    Function QTPRelatedExist()
        Dim QTPRelatedID(3) As Integer
        If ProcObjExistByName("UFT") Then
            QTPRelatedID(0) = 1
        End If
        If ProcObjExistByName("QTPro") Then
            QTPRelatedID(1) = 1
        End If
        If ProcObjExistByName("QTAutomationAgent") Then
            QTPRelatedID(2) = 1
        End If
        If ProcObjExistByName("QtpAutomationAgent") Then
            QTPRelatedID(3) = 1
        End If
        If QTPRelatedID(0) <> 0 Or QTPRelatedID(1) <> 0 Or QTPRelatedID(2) <> 0 Or QTPRelatedID(3) <> 0 Then
            Return True ' QTP related process exists
        Else
            Return False
        End If
    End Function
    Sub KillQTP()

        Dim QTPRelatedID(3) As Integer

        If ProcObjExistByName("UFT") Then
            QTPRelatedID(0) = getProcObjByName("UFT").id
        End If
        If ProcObjExistByName("QTPro") Then
            QTPRelatedID(1) = getProcObjByName("QTPro").id
        End If
        If ProcObjExistByName("QTAutomationAgent") Then
            QTPRelatedID(2) = getProcObjByName("QTAutomationAgent").id
        End If
        If ProcObjExistByName("QtpAutomationAgent") Then
            QTPRelatedID(3) = getProcObjByName("QtpAutomationAgent").id
        End If
        For i = 0 To UBound(QTPRelatedID)
            endProcess(QTPRelatedID(i))
        Next
    End Sub

    Sub killMavenRelatedProcesses(ByVal loc As String)
        Select Case loc
            Case "l"
                'Do While ProcObjExistByName("java")
                '    On Error Resume Next
                '    endProcess(getProcObjByName("java").id)
                '    On Error GoTo 0
                'Loop
                'Do While ProcObjExistByName("cmd")
                '    On Error Resume Next
                '    endProcess(getProcObjByName("cmd").id)
                '    On Error GoTo 0
                'Loop
                'Do While ProcObjExistByName("STAF")
                '    On Error Resume Next
                '    endProcess(getProcObjByName("STAF").id)
                '    On Error GoTo 0
                'Loop
                Dim host = "LOCAL"

                Dim run_processid As New System.Diagnostics.Process()
                run_processid.StartInfo.FileName = "cmd.exe"
                run_processid.StartInfo.UseShellExecute = False
                run_processid.StartInfo.RedirectStandardInput = True
                run_processid.StartInfo.RedirectStandardOutput = True
                run_processid.StartInfo.RedirectStandardError = True
                run_processid.StartInfo.CreateNoWindow = True
                run_processid.Start()
                Dim commanmdline = "STAF " + host + " CLEAN CLEANMVNPROC"
                run_processid.StandardInput.WriteLine(commanmdline)
                tempOutPut_Process = ""
                AddHandler run_processid.OutputDataReceived, New DataReceivedEventHandler(AddressOf OnDataReceived)
                run_processid.BeginOutputReadLine()
                Dim count As Long = 0
                Dim finishFlag As Boolean = False
                Do While True
                    If tempOutPut_Process.Contains("Response" + vbCrLf + "--------") Then
                        finishFlag = True
                        waitTime(5000)
                        Exit Do
                    End If
                    If tempOutPut_Process.Contains("Error submitting request, RC:") Then
                        finishFlag = False
                        waitTime(5000)
                        Exit Do
                    End If
                    waitTime(1000)
                    count = count + 1
                    If count >= 600 Then
                        Exit Do
                    End If
                Loop
                If finishFlag = False Then
                    RaiseEvent AddMessageToTB_MainLogEvnt("Error occurs when close maven related processes , please check it before next run:" + tempOutPut_Process, vbCrLf)
                    If run_processid.HasExited Then
                        If run_processid.ExitCode <> 0 Then
                            Dim errorinfo = run_processid.StandardError.ReadToEnd()
                            run_processid.Dispose()
                            RaiseEvent AddMessageToTB_MainLogEvnt("More info:" + errorinfo, vbCrLf)
                            Exit Sub
                        End If
                    Else
                        run_processid.Kill()
                        run_processid.Dispose()
                        'RaiseEvent AddMessageToTB_MainLogEvnt("Failed to kill Maven related processes on host " + host + ", please check it before next run!!!", vbCrLf)
                        Exit Sub
                    End If
                End If

            Case "r"
                For ii = 0 To arryServerFullyInfo.Length - 1
                    Dim host = arryServerFullyInfo(ii)(1)
                    Dim run_processid As New System.Diagnostics.Process()
                    run_processid.StartInfo.FileName = "cmd.exe"
                    run_processid.StartInfo.UseShellExecute = False
                    run_processid.StartInfo.RedirectStandardInput = True
                    run_processid.StartInfo.RedirectStandardOutput = True
                    run_processid.StartInfo.RedirectStandardError = True
                    run_processid.StartInfo.CreateNoWindow = True
                    run_processid.Start()
                    Dim commanmdline = "STAF " + host + " CLEAN CLEANMVNPROC"
                    run_processid.StandardInput.WriteLine(commanmdline)
                    tempOutPut_Process = ""
                    AddHandler run_processid.OutputDataReceived, New DataReceivedEventHandler(AddressOf OnDataReceived)
                    run_processid.BeginOutputReadLine()
                    Dim count As Long = 0
                    Dim finishFlag As Boolean = False
                    Do While True
                        If tempOutPut_Process.Contains("Response" + vbCrLf + "--------") Then
                            finishFlag = True
                            waitTime(5000)
                            Exit Do
                        End If
                        If tempOutPut_Process.Contains("Error submitting request, RC:") Then
                            finishFlag = False
                            waitTime(5000)
                            Exit Do
                        End If
                        waitTime(1000)
                        count = count + 1
                        If count >= 600 Then
                            Exit Do
                        End If
                    Loop
                    If finishFlag = False Then
                        RaiseEvent AddMessageToTB_MainLogEvnt("Error occurs when close maven related processes on " + host + ", please check it before next run:" + tempOutPut_Process, vbCrLf)
                        If run_processid.HasExited Then
                            If run_processid.ExitCode <> 0 Then
                                Dim errorinfo = run_processid.StandardError.ReadToEnd()
                                run_processid.Dispose()
                                RaiseEvent AddMessageToTB_MainLogEvnt("More info:" + errorinfo, vbCrLf)
                                Exit Sub
                            End If
                        Else
                            run_processid.Kill()
                            run_processid.Dispose()
                            'RaiseEvent AddMessageToTB_MainLogEvnt("Failed to kill Maven related processes on host " + host + ", please check it before next run!!!", vbCrLf)
                            Exit Sub
                        End If
                    End If
                Next
                

        End Select
    End Sub
    Function CheckRemoteServerUFTStatus(ByRef UFT As Object) As String   'strServerAddress: \\Computername or \\xxx.xxx.xxx.xxx
        'this function will return below status
        'disct - the remote UFT cannot be used
        'ready - the remote UFT is ready
        'busy - the remote UFT is busy

        On Error Resume Next
        Dim currentStatus As String = GetUFTStatus(UFT)
        If Err.Number <> 0 Then
            RaiseEvent AddMessageToTB_MainLogEvnt("<Expection> Remote UFT gets problem, will still try to connect it later. Exception:" + Err.Description + ". Error Code:" + CStr(Err.Number), vbCrLf)
            Return "disct"
            On Error GoTo 0
        Else
            'Introduction of status of UFT 
            'Not launched--QuickTest is not started. 
            'Ready--QuickTest is idle and ready to perform operations. 
            'Busy--QuickTest is currently performing an operation. 
            'Running--QuickTest is running a test or component. 
            'Recording--QuickTest is recording. 
            'Waiting--QuickTest is waiting for user input. 
            'Paused--The current run session is paused. 
            Select Case currentStatus
                Case "Not launched"
                    Return "notlaunch"
                Case "Ready"
                    Return "ready"
                Case "Busy"
                    Return "busy"
                Case "Running"
                    Return "busy"
                Case "Recording"
                    Return "busy"
                Case "Waiting"
                    Return "busy"
                Case "Paused"
                    Return "busy"
            End Select
        End If
    End Function
    Function GetUFTStatus(ByRef UFT As Object) As String
        Return UFT.GetStatus
    End Function
    Sub RunBPTs_OnlyForRemote(ByVal serverInfo() As Object) 'It contains "{execute path, server path, server status, UFT assgined to the server, BPT assigned to the server}"

        Dim TestPath As String = serverInfo(0)
        Dim ServerOwnTest As String = Trim(Split(TestPath, "\")(2))
        Dim ServerPath = serverInfo(1)
        'Dim debugOrignalVar As Object = arryServerFullyInfo
        Dim UFT As Object = serverInfo(3)
        Dim BPTs() As String = serverInfo(4)
        Dim i = 0
        Dim connection As String = ""
        Dim qtAppTestSettingsEnvironmentValueIDs_Remote As String = ""
        Dim testResultpath = ""
        Dim cannotUseShareFolder = False
        If HostModel Then
            testResultpath = strTestResultPath + "\" + ServerPath
            Class_ExcelOperator2.isLocalIPHost = isLocalIPHost
        Else
            testResultpath = strTestResultPath
        End If
        Dim errorcode = 0
        Dim errordes = ""
        Do Until i = (UBound(BPTs) + 1)
            Err.Number = 0
            Dim qtpTN As String = BPTs(i)
            If qtpTN <> "" Then
                Dim RunResultsStatus As String = ""
                'connection = CheckRemoteServerUFTStatus(UFT)
                'If connection = "disct" Then
                '    GoTo UTFConectionProblem
                'End If
                On Error Resume Next

                'RaiseEvent AddMessageToTB_MainLog("[" + qtpTN + "]: is processed by server [" + ServerPath + "]", vbCrLf)
                'Debug.Print(CStr(Now) + "open case")
                Dim testStartTime = Now  ' record BPT start Time
                Dim UFTTest As Object = OpenUFTTest_Remote(UFT, TestPath + "\" + qtpTN, True, False)
                If Err.Number <> 0 Then
                    GoTo ErrorDecide
                End If
                On Error GoTo ErrorDecide
                'Debug.Print(CStr(Now) + "set case")
                UFTTest = UFEAppTestSet_Remote(UFT, TestPath + "\" + qtpTN, qtAppTestSettingsEnvironmentValueIDs_Remote)
                'Debug.Print(CStr(Now) + "set case result")
                Dim qtResultsOpt As Object = SetupUFTResult(ServerPath, testResultpath, qtpTN)
                'Debug.Print(CStr(Now) + "run case")
                UFTTest.Run(qtResultsOpt, False) ' Run the test. must to set false here, because if use true here will wait UFT run the test end, then move to next step, that will block kill thread and close QTP
                Do While UFTTest.IsRunning
                    Application.DoEvents()
                    waitTime(500)
                    qtAppTestSettingsEnvironmentValueIDs_Remote = UFTTest.Environment.Value("IDs")
                Loop

                RunResultsStatus = UFTTest.LastRunResults.Status
                qtResultsOpt = Nothing ' Release the Run Results Options object
                UFTTest = Nothing ' Release the Test object
ErrorDecide:
                errorcode = Err.Number
                errordes = Err.Description
                On Error GoTo 0
                Select Case errorcode
                    Case -2147023570 'unknown user name or bad password for modify host's folder' put the report in server's local
                        Err.Number = 0
                        RaiseEvent AddMessageToTB_MainLogEvnt("The path " + testResultpath + " has access error. UFT detail result will be saved in path" + strTestResultPath_Backup + " of machine where execute testing." + CStr(Now), vbCrLf)
                        testResultpath = strTestResultPath_Backup
                        ReportTestResultPath = strTestResultPath_Backup
                        cannotUseShareFolder = True
                        Class_ExcelOperator2.isLocalIPHost = False
                        On Error GoTo ErrorDecide
                        qtResultsOpt = SetupUFTResult(ServerPath, testResultpath, qtpTN)
                        UFTTest.Run(qtResultsOpt, False) ' Run the test. must to set false here, because if use true here will wait UFT run the test end, then move to next step, that will block kill thread and close QTP
                        Do While UFTTest.IsRunning
                            Application.DoEvents()
                            waitTime(500)
                            qtAppTestSettingsEnvironmentValueIDs_Remote = UFTTest.Environment.Value("IDs")
                        Loop
                        RunResultsStatus = UFTTest.LastRunResults.Status
                        qtResultsOpt = Nothing ' Release the Run Results Options object
                        UFTTest = Nothing ' Release the Test object
                        GoTo ErrorDecide
                    Case 0
                        'RaiseEvent AddMessageToTB_MainLog(RunResultsStatus + ": [" + qtpTN + "] from server [" + ServerPath + "] " + CStr(Now), vbCrLf)
                        Class_FileOperator1.WriteResultToRunTimeReportFile(strTxtReportPath, qtpTN, RunResultsStatus)
                        Dim respath As String = ""
                        If HostModel Then
                            If cannotUseShareFolder Then
                                Class_ExcelOperator2.WriteResultToReportExcel(projectType, RunResultsStatus, strExeclReportPath, runStartTime, qtpTN, testStartTime, ReportTestResultPath, ServerPath, "", True, False)
                            Else
                                Class_ExcelOperator2.WriteResultToReportExcel(projectType, RunResultsStatus, strExeclReportPath, runStartTime, qtpTN, testStartTime, ReportTestResultPath + "\" + ServerPath, ServerPath, "", True, True)
                            End If
                            respath = ReportTestResultPath
                        Else
                            Class_ExcelOperator2.WriteResultToReportExcel(projectType, RunResultsStatus, strExeclReportPath, runStartTime, qtpTN, testStartTime, testResultpath, ServerPath, "", True, False)
                            respath = testResultpath
                        End If

                        For t = 0 To UBound(arryRunList)
                            If IsNothing(arryRunList(t)) = False Then
                                If ServerPath = arryRunList(t)(2) Then
                                    If arryRunList(t)(0) = qtpTN Then
                                        arryRunList(t)(1) = "done-" & LCase(RunResultsStatus)
                                        arryRunList(t)(3) = respath
                                    End If
                                End If
                            End If

                        Next
                    Case 429 'Cannot create ActiveX component.
                        RaiseEvent AddMessageToTB_MainLogEvnt("Error: [" + qtpTN + "] from server [" + ServerPath + "] " + CStr(Now) + ". Description:" + CStr(errorcode) + "-" + errordes, vbCrLf)
                        RunResultsStatus = "Error:" + CStr(errorcode) + "-" + errordes
                        Class_FileOperator1.WriteResultToRunTimeReportFile(strTxtReportPath, qtpTN, RunResultsStatus)
                        GoTo UTFConectionProblem
                    Case 462 'no connection.
                        RaiseEvent AddMessageToTB_MainLogEvnt("Error: [" + qtpTN + "] from server [" + ServerPath + "] " + CStr(Now) + ". Description:" + CStr(errorcode) + "-" + errordes, vbCrLf)
                        RunResultsStatus = "Error:" + CStr(errorcode) + "-" + errordes
                        Class_FileOperator1.WriteResultToRunTimeReportFile(strTxtReportPath, qtpTN, RunResultsStatus)
                        GoTo UTFConectionProblem
                    Case -2147023170 'The remote procedure call failed
                        RaiseEvent AddMessageToTB_MainLogEvnt("Error: [" + qtpTN + "] from server [" + ServerPath + "] " + CStr(Now) + ". Description:" + CStr(errorcode) + "-" + errordes, vbCrLf)
                        RunResultsStatus = "Error:" + CStr(errorcode) + "-" + errordes
                        Class_FileOperator1.WriteResultToRunTimeReportFile(strTxtReportPath, qtpTN, RunResultsStatus)
                        GoTo UTFConectionProblem
                    Case -2147352567 'Neither QTP license nor UFT license is installed, can’t run QTP Automation
                        RaiseEvent AddMessageToTB_MainLogEvnt("Error: [" + qtpTN + "] from server [" + ServerPath + "] " + CStr(Now) + ". Description:" + CStr(errorcode) + "-" + errordes, vbCrLf)
                        RunResultsStatus = "Error:" + CStr(errorcode) + "-" + errordes
                        Class_FileOperator1.WriteResultToRunTimeReportFile(strTxtReportPath, qtpTN, RunResultsStatus)
                        GoTo UTFConectionProblem
                    Case 1006  'cannot open test case
                        RaiseEvent AddMessageToTB_MainLogEvnt("Error: [" + qtpTN + "] from server [" + ServerPath + "] " + CStr(Now) + ". Description:" + CStr(errorcode) + "-" + errordes, vbCrLf)
                        RunResultsStatus = "Error:" + CStr(errorcode) + "-" + errordes
                        Class_FileOperator1.WriteResultToRunTimeReportFile(strTxtReportPath, qtpTN, RunResultsStatus)
                        Dim respath As String = ""
                        If HostModel Then
                            If cannotUseShareFolder Then
                                Class_ExcelOperator2.WriteResultToReportExcel(projectType, RunResultsStatus, strExeclReportPath, runStartTime, qtpTN, testStartTime, ReportTestResultPath, ServerPath, "", True, False)
                            Else
                                Class_ExcelOperator2.WriteResultToReportExcel(projectType, RunResultsStatus, strExeclReportPath, runStartTime, qtpTN, testStartTime, ReportTestResultPath + "\" + ServerPath, ServerPath, "", True, True)
                            End If
                            respath = ReportTestResultPath
                        Else
                            Class_ExcelOperator2.WriteResultToReportExcel(projectType, RunResultsStatus, strExeclReportPath, runStartTime, qtpTN, testStartTime, testResultpath, ServerPath, "", True, False)
                            respath = testResultpath
                        End If


                        For t = 0 To UBound(arryRunList)
                            If IsNothing(arryRunList(t)) = False Then
                                If ServerPath = arryRunList(t)(2) Then
                                    If arryRunList(t)(0) = qtpTN Then
                                        arryRunList(t)(1) = "error"
                                        arryRunList(t)(3) = respath
                                    End If
                                End If
                            End If
                        Next

                        RemoteErrorRun = True
                        On Error GoTo 0
                    Case 5 '5-Access to the path
                        RaiseEvent AddMessageToTB_MainLogEvnt("Error: [" + qtpTN + "] from server [" + ServerPath + "] " + CStr(Now) + ". Description:" + CStr(errorcode) + "-" + errordes, vbCrLf)
                        RunResultsStatus = "Error:" + CStr(errorcode) + "-" + errordes
                        Class_FileOperator1.WriteResultToRunTimeReportFile(strTxtReportPath, qtpTN, RunResultsStatus)
                        For t = 0 To UBound(arryRunList)
                            If IsNothing(arryRunList(t)) = False Then
                                If ServerPath = arryRunList(t)(2) Then
                                    If arryRunList(t)(0) = qtpTN Then
                                        arryRunList(t)(1) = "error"
                                    End If
                                End If
                            End If
                        Next

                        RemoteErrorRun = True
                        On Error GoTo 0
                    Case -2147023570 'unknown user name or bad password for modify host's folder
                        RaiseEvent AddMessageToTB_MainLogEvnt("Error: [" + qtpTN + "] from server [" + ServerPath + "] " + CStr(Now) + ". Description:" + CStr(errorcode) + "-" + errordes, vbCrLf)
                        RunResultsStatus = "Error:" + CStr(errorcode) + "-" + errordes
                        Class_FileOperator1.WriteResultToRunTimeReportFile(strTxtReportPath, qtpTN, RunResultsStatus)
                        For t = 0 To UBound(arryRunList)
                            If IsNothing(arryRunList(t)) = False Then
                                If ServerPath = arryRunList(t)(2) Then
                                    If arryRunList(t)(0) = qtpTN Then
                                        arryRunList(t)(1) = "error"
                                    End If
                                End If
                            End If
                        Next

                        RemoteErrorRun = True
                        On Error GoTo 0
                    Case Else
                        'RaiseEvent AddMessageToTB_MainLog("Error: [" + qtpTN + "] from server [" + ServerPath + "] " + CStr(Now) + ". Description:" + CStr(errorcode) + "-" + errordes, vbCrLf)
                        'RunResultsStatus = "Error:" + CStr(errorcode) + "-" + errordes
                        'Class_FileOperator1.WriteResultToRunTimeReportFile(strTxtReportPath, qtpTN, RunResultsStatus)
                        'GoTo UTFConectionProblem
                        RaiseEvent AddMessageToTB_MainLogEvnt("Error: [" + qtpTN + "] from server [" + ServerPath + "] " + CStr(Now) + ". Description:" + CStr(errorcode) + "-" + errordes, vbCrLf)
                        RunResultsStatus = "Error:" + CStr(errorcode) + "-" + errordes
                        Class_FileOperator1.WriteResultToRunTimeReportFile(strTxtReportPath, qtpTN, RunResultsStatus)
                        For t = 0 To UBound(arryRunList)
                            If IsNothing(arryRunList(t)) = False Then
                                If ServerPath = arryRunList(t)(2) Then
                                    If arryRunList(t)(0) = qtpTN Then
                                        arryRunList(t)(1) = "error"
                                    End If
                                End If
                            End If
                        Next

                        RemoteErrorRun = True
                        On Error GoTo 0
                End Select
            End If
            i = i + 1
        Loop
        serverInfo(2) = "ready" 'when BPTs are completed, change status from "process" to "ready", to tell main sub the server can be ready for next connection check
        Exit Sub
UTFConectionProblem:
        On Error GoTo 0
        serverInfo(3) = Nothing
        serverInfo(2) = "disct"
        For w = i To UBound(BPTs) 'release BPTs to other available server run
            For t = 0 To UBound(arryRunList)
                If IsNothing(arryRunList(t)) = False Then
                    If ServerPath = arryRunList(t)(2) Then
                        If arryRunList(t)(0) = BPTs(w) Then
                            arryRunList(t)(1) = "ready"
                        End If
                    End If
                End If
            Next
        Next
        RemoteErrorRun = True
    End Sub
    Function GetUFTValue(ByVal stream As String, ByVal path As String)
        Dim lineArry = Split(stream, vbCrLf)
        Dim value
        Dim valueArry(-1)
        Dim findCount = 0
        For i = 0 To UBound(lineArry)
            If LCase(Trim(Split(lineArry(i), "=")(0))) = LCase(path) Then
                findCount = findCount + 1
                value = Trim(Split(lineArry(i), "=")(1))
                value = Trim(Split(value, "'")(0))
                If value <> "" Then
                    If InStr(value, """") > 0 Then
                        value = CStr(Replace(value, """", ""))
                    Else
                        If IsNumeric(value) Then
                            value = CInt(value)
                        Else
                            value = CBool(value)
                        End If

                    End If
                    ReDim Preserve valueArry(findCount - 1)
                    valueArry(findCount - 1) = value
                End If
            End If
        Next
        Dim res As Object = Nothing
        Select Case UBound(valueArry)
            Case Is > 0
                res = valueArry
            Case 0
                res = valueArry(0)
            Case Is < 0
                res = Nothing
        End Select

        Return res
    End Function

    Function launchStaf() As Object()
        Do While ProcObjExistByName("java")
            On Error Resume Next
            endProcess(getProcObjByName("java").id)
            On Error GoTo 0
        Loop
        Do While ProcObjExistByName("cmd")
            On Error Resume Next
            endProcess(getProcObjByName("cmd").id)
            On Error GoTo 0
        Loop
        Do While ProcObjExistByName("STAF")
            On Error Resume Next
            endProcess(getProcObjByName("STAF").id)
            On Error GoTo 0
        Loop
        Do While ProcObjExistByName("STAFProc")
            On Error Resume Next
            endProcess(getProcObjByName("STAFProc").id)
            On Error GoTo 0
        Loop

        Dim stafworkright = False
        Dim launch_process As New Process
        launch_process.StartInfo.FileName = "cmd.exe"
        launch_process.StartInfo.UseShellExecute = False
        launch_process.StartInfo.RedirectStandardInput = True
        launch_process.StartInfo.RedirectStandardOutput = True
        launch_process.StartInfo.RedirectStandardError = True
        launch_process.StartInfo.CreateNoWindow = True
        launch_process.Start()
        launch_process.StandardInput.WriteLine("STAFProc")
        tempOutPut_Process = ""
        AddHandler launch_process.OutputDataReceived, New DataReceivedEventHandler(AddressOf OnDataReceived)
        launch_process.BeginOutputReadLine()
        Dim count As Integer = 0

        Do While True

            If (tempOutPut_Process.Contains("STAFProc version") And tempOutPut_Process.Contains("initialized")) Or tempOutPut_Process.Contains("STAFProc already started") Then
                stafworkright = True
                Exit Do
            End If
            waitTime(1000)
            count = count + 1
            If count = 120 Then
                Exit Do
            End If
        Loop

        If stafworkright = False Then
            If launch_process.HasExited Then
                If launch_process.ExitCode <> 0 Then
                    Dim resmsg = launch_process.StandardError.ReadToEnd()
                    launch_process.Kill()
                    Return {launch_process, stafworkright, resmsg}
                End If
            Else

                launch_process.Kill()
                Return {launch_process, stafworkright, tempOutPut_Process}
            End If
        End If

        launch_process.Kill()
        Debug.Print(tempOutPut_Process)
        Return {launch_process, stafworkright, tempOutPut_Process}
    End Function
    Public tempOutPut_Process As String
    Sub OnDataReceived(ByVal sender As System.Object, ByVal e As DataReceivedEventArgs)
        If IsNothing(e.Data) = False Then
            tempOutPut_Process = tempOutPut_Process + vbCrLf + e.Data
        End If
    End Sub
    Function runStafMavenService_Local(ByVal projectPath As String, ByVal testcase As String, ByVal timeoutforcase As Long) As Object()

        Dim strNow As Date = Now

        Dim strMonth As String = DatePart(DateInterval.Month, strNow)
        Dim strDay As String = DatePart(DateInterval.Day, strNow)
        Dim strHour As String = DatePart(DateInterval.Hour, strNow)
        Dim strMin As String = DatePart(DateInterval.Minute, strNow)
        Dim strSec As String = DatePart(DateInterval.Second, strNow)

        Dim strTime As String = CStr(strMonth) + "-" + CStr(strDay) + " " + CStr(strHour) + "-" + CStr(strMin) + "-" + CStr(strSec)
        Dim logName As String = testcase + "-" + strTime
        Dim run_processid As New System.Diagnostics.Process()
        run_processid.StartInfo.FileName = "cmd.exe"
        run_processid.StartInfo.UseShellExecute = False
        run_processid.StartInfo.RedirectStandardInput = True
        run_processid.StartInfo.RedirectStandardOutput = True
        run_processid.StartInfo.RedirectStandardError = True
        run_processid.StartInfo.CreateNoWindow = True
        run_processid.Start()
        Dim commanmdline = "STAF local RUNTC RUN PATH """ + projectPath + """ TESTCASES """ + testcase + """ HOSTFROM local LOGNAME """ + logName + """"
        run_processid.StandardInput.WriteLine(commanmdline)
        tempOutPut_Process = ""
        AddHandler run_processid.OutputDataReceived, New DataReceivedEventHandler(AddressOf OnDataReceived)
        run_processid.BeginOutputReadLine()
        Dim count As Long = 0
        Dim finishFlag As Boolean = False
        Do While True
            If tempOutPut_Process.Contains("Response" + vbCrLf + "--------") Then
                finishFlag = True
                waitTime(5000)
                Exit Do
            End If
            If tempOutPut_Process.Contains("Error submitting request, RC:") Then
                finishFlag = False
                waitTime(5000)
                Exit Do
            End If
            waitTime(1000)
            count = count + 1
            If count >= (timeoutforcase / 1000) Then
                Exit Do
            End If
        Loop
        If finishFlag = False Then
            If run_processid.HasExited Then
                If run_processid.ExitCode <> 0 Then
                    Dim errorinfo = run_processid.StandardError.ReadToEnd()
                    run_processid.Kill()

                    run_processid.Dispose()
                    Return {"error", errorinfo, STAFEC_STAFSeviceTS}
                    Exit Function
                End If
            Else
                run_processid.Kill()
                run_processid.Dispose()
                Return {"error", tempOutPut_Process, STAFEC_STAFSeviceTS}
                Exit Function
            End If
        End If
        run_processid.Kill()
        run_processid.Dispose()
        Debug.Print(tempOutPut_Process)
        Dim res_processid As New System.Diagnostics.Process()
        res_processid.StartInfo.FileName = "cmd.exe"
        res_processid.StartInfo.UseShellExecute = False
        res_processid.StartInfo.RedirectStandardInput = True
        res_processid.StartInfo.RedirectStandardOutput = True
        res_processid.StartInfo.RedirectStandardError = True
        res_processid.StartInfo.CreateNoWindow = True
        res_processid.Start()
        Dim commanmdline1 = "STAF local LOG QUERY GLOBAL LOGNAME """ + logName + """ ALL"
        res_processid.StandardInput.WriteLine(commanmdline1)
        tempOutPut_Process = ""
        AddHandler res_processid.OutputDataReceived, New DataReceivedEventHandler(AddressOf OnDataReceived)
        res_processid.BeginOutputReadLine()
        Dim count1 As Integer = 0
        Dim finishFlag1 As Boolean = False
        Do While True
            If tempOutPut_Process.Contains("Response" + vbCrLf + "--------") Then
                finishFlag1 = True
                waitTime(5000)
                Exit Do
            End If
            If tempOutPut_Process.Contains("Error submitting request, RC:") Then
                finishFlag1 = False
                waitTime(5000)
                Exit Do
            End If
            waitTime(1000)
            count1 = count1 + 1
            If count1 = 120 Then
                Exit Do
            End If
        Loop
        If finishFlag1 = False Then
            If res_processid.HasExited Then
                If res_processid.ExitCode <> 0 Then
                    Dim errorinfo = res_processid.StandardError.ReadToEnd()
                    res_processid.Kill()
                    res_processid.Dispose()
                    Return {"error", errorinfo, STAFEC_STAFSeviceTS}
                    Exit Function
                End If

            Else
                res_processid.Kill()
                res_processid.Dispose()
                Return {"error", tempOutPut_Process, STAFEC_STAFSeviceTS}
                Exit Function
            End If
        End If

        Dim temp As String = tempOutPut_Process
        Dim resArray() As String = Split(Split(temp, "Response" & vbCrLf & "--------")(1), vbCrLf)
        Dim index = -1
        Dim firstColumnLen As Integer = 0
        Dim secColumnLen As Integer = 0
        Dim thirdColumnLen As Integer = 0
        Dim detailLine As String = ""
        Dim detailResult As String = ""
        Dim finishFlag2 As Boolean = False

        For Each res In resArray
            If Trim(res).Equals("") Then
            Else
                index = index + 1
                If index = 1 Then
                    firstColumnLen = Split(res, " ")(0).Length
                    secColumnLen = Split(res, " ")(1).Length
                    thirdColumnLen = Split(res, " ")(2).Length
                End If

                If index = 2 Then
                    detailLine = res
                    detailResult = Trim(Mid(detailLine, firstColumnLen + 1 + secColumnLen + 1, thirdColumnLen))
                    finishFlag2 = True

                End If

                If index > 2 Then
                    detailResult = detailResult + vbCrLf + Trim(res)
                End If
            End If

        Next
        If finishFlag2 = False Then

            res_processid.Kill()
            res_processid.Dispose()
            Return {"error", tempOutPut_Process, STAFEC_AnalysisResOfSvc}
        End If

        Dim status = Trim(Mid(detailLine, firstColumnLen + 1, secColumnLen))

        res_processid.Kill()
        res_processid.Dispose()
        If LCase(status) = "error" Then
            Return {"error", detailResult, STAFEC_MVNServiceErr}
        Else
            On Error Resume Next
            Dim reportreference = Split(detailResult, "%")(1)
            Dim buldts = ""
            If reportreference.ToLower.Trim = "n/a" Then
                RaiseEvent AddMessageToTB_MainLogEvnt("Exception: cannot get result folder name from detail result:" + detailResult, vbCrLf)
            Else
                buldts = Split(reportreference, "_")(0) + "_" + Split(reportreference, "_")(1)
            End If

            If buldts <> "" Then
                Dim reportsrc As String = ""
                Dim mvnProReportPath = projectPath + "\report"
                If Class_FolderOperator2.hasFolder(mvnProReportPath) Then
                    Dim foldernames() As String = Class_FolderOperator2.getAllFolderNames(mvnProReportPath)
                    For Each fname In foldernames
                        If fname.Contains(buldts + "_" + Trim(testcase)) Then
                            reportsrc = mvnProReportPath + "\" + fname
                            Dim dst As String = strTestResultPath + "\" + fname.Substring(fname.IndexOf("_", fname.IndexOf("_") + 1) + 1)
                            Class_FolderOperator2.copyFolder(reportsrc, dst)
                            Exit For
                        End If
                    Next
                Else
                    Debug.Print("cannnot find " + mvnProReportPath)
                End If
            End If
            On Error GoTo 0
        End If
        Return {status, detailResult, 0}
    End Function

    Function runStafMavenService_Remote(ByVal host As String, ByVal projectPath As String, ByVal testcase As String, ByVal timeoutforcase As Long) As Object()

        Dim strNow As Date = Now

        Dim strMonth As String = DatePart(DateInterval.Month, strNow)
        Dim strDay As String = DatePart(DateInterval.Day, strNow)
        Dim strHour As String = DatePart(DateInterval.Hour, strNow)
        Dim strMin As String = DatePart(DateInterval.Minute, strNow)
        Dim strSec As String = DatePart(DateInterval.Second, strNow)

        Dim strTime As String = CStr(strMonth) + "-" + CStr(strDay) + " " + CStr(strHour) + "-" + CStr(strMin) + "-" + CStr(strSec)
        Dim logName As String = testcase + "-" + strTime
        Dim reportsrc As String = ""
        Dim run_processid As New System.Diagnostics.Process()
        run_processid.StartInfo.FileName = "cmd.exe"
        run_processid.StartInfo.UseShellExecute = False
        run_processid.StartInfo.RedirectStandardInput = True
        run_processid.StartInfo.RedirectStandardOutput = True
        run_processid.StartInfo.RedirectStandardError = True
        run_processid.StartInfo.CreateNoWindow = True
        run_processid.Start()
        Dim commanmdline = "STAF " + host + " RUNTC RUN PATH """ + projectPath + """ TESTCASES """ + testcase + """ HOSTFROM " + host + " LOGNAME """ + logName + """"
        run_processid.StandardInput.WriteLine(commanmdline)
        tempOutPut_Process = ""
        AddHandler run_processid.OutputDataReceived, New DataReceivedEventHandler(AddressOf OnDataReceived)
        run_processid.BeginOutputReadLine()
        Dim count As Long = 0
        Dim finishFlag As Boolean = False
        Dim errorFlag As Boolean = False
        Dim staferrorcode As Integer = 0
        Do While True
            If tempOutPut_Process.Contains("Response" + vbCrLf + "--------") Then
                finishFlag = True
                waitTime(5000)
                Exit Do
            End If
            If tempOutPut_Process.Contains("Error submitting request, RC:") Then
                finishFlag = True
                errorFlag = False
                Dim lines = tempOutPut_Process.Split(vbCrLf)
                For e = 0 To lines.Length
                    If lines(e).Contains("Error submitting request, RC:") Then
                        staferrorcode = lines(e).Split(":")(1).Trim()
                        Exit For
                    End If
                Next
                If staferrorcode = 0 Then
                    staferrorcode = -1 'error here,but unknown
                End If
                waitTime(5000)
                Exit Do
            End If
            waitTime(1000)
            count = count + 1
            If count >= (timeoutforcase / 1000) Then
                Exit Do
            End If
        Loop
        If finishFlag = False Then
            If run_processid.HasExited Then
                If run_processid.ExitCode <> 0 Then
                    Dim errorinfo = run_processid.StandardError.ReadToEnd()
                    run_processid.Kill()
                    run_processid.Dispose()
                    Return {"error", errorinfo, STAFEC_STAFSeviceTS}
                    Exit Function
                End If
            Else
                run_processid.Kill()
                run_processid.Dispose()
                Return {"error", tempOutPut_Process, STAFEC_STAFSeviceTS}
                Exit Function
            End If
        End If
        If errorFlag Then
            run_processid.Kill()
            run_processid.Dispose()
            Return {"error", tempOutPut_Process, staferrorcode}
            Exit Function
        End If

        run_processid.Kill()
        run_processid.Dispose()
        Debug.Print(tempOutPut_Process)
        Dim res_processid As New System.Diagnostics.Process()
        res_processid.StartInfo.FileName = "cmd.exe"
        res_processid.StartInfo.UseShellExecute = False
        res_processid.StartInfo.RedirectStandardInput = True
        res_processid.StartInfo.RedirectStandardOutput = True
        res_processid.StartInfo.RedirectStandardError = True
        res_processid.StartInfo.CreateNoWindow = True
        res_processid.Start()
        Dim commanmdline1 = "STAF " + host + " LOG QUERY GLOBAL LOGNAME """ + logName + """ ALL"
        res_processid.StandardInput.WriteLine(commanmdline1)
        tempOutPut_Process = ""
        AddHandler res_processid.OutputDataReceived, New DataReceivedEventHandler(AddressOf OnDataReceived)
        res_processid.BeginOutputReadLine()
        Dim count1 As Integer = 0
        Dim finishFlag1 As Boolean = False
        Do While True
            If tempOutPut_Process.Contains("Response" + vbCrLf + "--------") Then
                finishFlag1 = True
                waitTime(5000)
                Exit Do
            End If
            If tempOutPut_Process.Contains("Error submitting request, RC:") Then
                finishFlag1 = False
                waitTime(5000)
                Exit Do
            End If
            waitTime(1000)
            count1 = count1 + 1
            If count1 = 120 Then
                Exit Do
            End If
        Loop
        If finishFlag1 = False Then
            If res_processid.HasExited Then
                If res_processid.ExitCode <> 0 Then
                    Dim errorinfo = res_processid.StandardError.ReadToEnd()
                    res_processid.Kill()
                    res_processid.Dispose()
                    Return {"error", errorinfo, STAFEC_STAFSeviceTS}
                    Exit Function
                End If
            Else
                res_processid.Kill()
                res_processid.Dispose()
                Return {"error", tempOutPut_Process, STAFEC_STAFSeviceTS}
                Exit Function
            End If
        End If

        Dim temp As String = tempOutPut_Process
        Dim resArray() As String = Split(Split(temp, "Response" & vbCrLf & "--------")(1), vbCrLf)
        Dim index = -1
        Dim firstColumnLen As Integer = 0
        Dim secColumnLen As Integer = 0
        Dim thirdColumnLen As Integer = 0
        Dim detailLine As String = ""
        Dim detailResult As String = ""
        Dim finishFlag2 As Boolean = False

        For Each res In resArray
            If Trim(res).Equals("") Then
            Else
                index = index + 1
                If index = 1 Then
                    firstColumnLen = Split(res, " ")(0).Length
                    secColumnLen = Split(res, " ")(1).Length
                    thirdColumnLen = Split(res, " ")(2).Length
                End If

                If index = 2 Then
                    detailLine = res
                    detailResult = Trim(Mid(detailLine, firstColumnLen + 1 + secColumnLen + 1, thirdColumnLen))
                    finishFlag2 = True

                End If

                If index > 2 Then
                    detailResult = detailResult + vbCrLf + Trim(res)
                End If
            End If

        Next
        If finishFlag2 = False Then

            res_processid.Kill()
            res_processid.Dispose()
            Return {"error", tempOutPut_Process, STAFEC_AnalysisResOfSvc}
        End If

        Dim status = Trim(Mid(detailLine, firstColumnLen + 1, secColumnLen))

        res_processid.Kill()
        res_processid.Dispose()
        If LCase(status) = "error" Then
            Return {"error", detailResult, STAFEC_MVNServiceErr}
        Else
            On Error Resume Next
            Dim reportreference = Split(detailResult, "%")(1)
            Dim buldts = Split(reportreference, "_")(0) + "_" + Split(reportreference, "_")(1)
            If buldts <> "" Then

                Dim mvnProReportPath = projectPath + "\report"
                If Class_FolderOperator2.hasFolder(mvnProReportPath) Then
                    Dim foldernames() As String = Class_FolderOperator2.getAllFolderNames(mvnProReportPath)
                    For Each fname In foldernames
                        If fname.Contains(buldts + "_" + Trim(testcase)) Then
                            reportsrc = mvnProReportPath + "\" + fname
                            'Dim dst As String = strTestResultPath + "\" + fname.Substring(fname.IndexOf("_", fname.IndexOf("_") + 1) + 1)
                            'Class_FolderOperator2.copyFolder(reportsrc, dst)
                            Exit For
                        End If
                    Next
                Else
                    Debug.Print("cannnot find " + mvnProReportPath)
                End If
            End If
            On Error GoTo 0
        End If
        Return {status, detailResult, 0, reportsrc}
    End Function

    Sub RunMVNTest_OnlyForRemote(ByVal serverInfo() As Object) 'It contains "{execute path, server path, server status, UFT assgined to the server, TestCases assigned to the server}"

        Dim TestPath As String = serverInfo(0)
        Dim ServerPath = serverInfo(1)
        'Dim UFT As Object = serverInfo(3)
        Dim TestCases() As String = serverInfo(4)
        Dim i = 0

        Dim cannotUseShareFolder = False


        Dim errornumber = 0
        Dim errordes = ""
        Do Until i = (UBound(TestCases) + 1)
            Err.Number = 0
            Dim testname As String = TestCases(i)
            Dim RunResultsStatus As String = ""
            If testname <> "" Then
                Dim testStartTime = Now
                Dim mark = ""
                Dim resPath = ""
                On Error GoTo ErrorDecide
                ' record BPT start Time
                arryRunList(i)(1) = "run"
                Debug.Print("openTest")
                Dim res() As Object = runStafMavenService_Remote(ServerPath, TestPath, testname, tsOfMavenTestCase)
                RunResultsStatus = res(0)
                If RunResultsStatus = "error" Then
                    RaiseEvent AddMessageToTB_MainLogEvnt(testname + ": Error to execute the TestCase", vbCrLf)
                    Err.Number = CLng(res(2))
                    Err.Description = res(1)
                Else
                    resPath = res(3)
                End If
ErrorDecide:
                errornumber = Err.Number
                errordes = Err.Description
                On Error GoTo 0

                Select Case errornumber
                    Case 16
                        RaiseEvent AddMessageToTB_MainLogEvnt("Error: [" + testname + "] from server [" + ServerPath + "] " + CStr(Now) + ". Description:" + CStr(errornumber) + "-" + errordes, vbCrLf)
                        RunResultsStatus = "Error:" + CStr(errornumber) + "-" + errordes
                        Class_FileOperator1.WriteResultToRunTimeReportFile(strTxtReportPath, testname, RunResultsStatus)
                        GoTo STAFConectionProblem
                    Case 0
                        'RaiseEvent AddMessageToTB_MainLog(RunResultsStatus + ": [" + qtpTN + "] from server [" + ServerPath + "] " + CStr(Now), vbCrLf)
                        Class_FileOperator1.WriteResultToRunTimeReportFile(strTxtReportPath, testname, RunResultsStatus)
                        Class_ExcelOperator2.WriteResultToReportExcel(projectType, RunResultsStatus, strExeclReportPath, runStartTime, testname, testStartTime, resPath, ServerPath, "", True, False)


                        For t = 0 To UBound(arryRunList)
                            If IsNothing(arryRunList(t)) = False Then
                                If ServerPath = arryRunList(t)(2) Then
                                    If arryRunList(t)(0) = testname Then
                                        arryRunList(t)(1) = "done-" & LCase(RunResultsStatus)
                                        arryRunList(t)(3) = resPath
                                    End If
                                End If
                            End If

                        Next
                    Case Else
                        RaiseEvent AddMessageToTB_MainLogEvnt("Error: [" + testname + "] from server [" + ServerPath + "] " + CStr(Now) + ". Description:" + CStr(errornumber) + "-" + errordes, vbCrLf)
                        RunResultsStatus = "Error:" + CStr(errornumber) + "-" + errordes
                        Class_FileOperator1.WriteResultToRunTimeReportFile(strTxtReportPath, testname, RunResultsStatus)
                        For t = 0 To UBound(arryRunList)
                            If IsNothing(arryRunList(t)) = False Then
                                If ServerPath = arryRunList(t)(2) Then
                                    If arryRunList(t)(0) = testname Then
                                        arryRunList(t)(1) = "error"
                                    End If
                                End If
                            End If
                        Next

                        RemoteErrorRun = True
                        On Error GoTo 0
                End Select
            End If
            i = i + 1
        Loop
        serverInfo(2) = "ready" 'when TestCase are completed, change status from "process" to "ready", to tell main sub the server can be ready for next connection check
        Exit Sub
STAFConectionProblem:
        On Error GoTo 0
        serverInfo(3) = Nothing
        serverInfo(2) = "disct"
        For w = i To UBound(TestCases) 'release BPTs to other available server run
            For t = 0 To UBound(arryRunList)
                If IsNothing(arryRunList(t)) = False Then
                    If ServerPath = arryRunList(t)(2) Then
                        If arryRunList(t)(0) = TestCases(w) Then
                            arryRunList(t)(1) = "ready"
                        End If
                    End If
                End If
            Next
        Next
        RemoteErrorRun = True
    End Sub
End Class
