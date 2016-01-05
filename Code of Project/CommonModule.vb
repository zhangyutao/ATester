Imports System.Runtime.InteropServices
Imports System.Runtime.ConstrainedExecution
Imports Microsoft.Win32.SafeHandles
Imports System.Security
Imports Microsoft.Win32

Module CommonModule
    Delegate Sub Delegate_EnableObject(ByRef f As Object, ByRef b As Boolean)
    Function Cmd(ByVal Command As String) As String
        Dim process As New System.Diagnostics.Process()

        process.StartInfo.FileName = "cmd.exe"
        process.StartInfo.UseShellExecute = False
        process.StartInfo.RedirectStandardInput = True
        process.StartInfo.RedirectStandardOutput = True
        process.StartInfo.RedirectStandardError = True
        process.StartInfo.CreateNoWindow = True
        process.Start()
        process.StandardInput.WriteLine(Command)
        process.StandardInput.WriteLine("exit")
        Dim Result As String = process.StandardOutput.ReadToEnd()
        process.Close()
        Return Result
    End Function
    'compare if two string array is same
    Function comparetwoarray(ByVal array1() As String, ByVal array2() As String)

        Dim stt1 As String
        Dim stt2 As String
        Dim flag As Boolean = False
        For Each stt1 In array1
            For Each stt2 In array2
                If stt1 = stt2 Then
                    flag = True
                    Exit For
                End If
            Next

            If flag = False Then
                Return False
            Else
                flag = False
            End If
        Next
        Return True

    End Function

    'Run external program and return the process id
    Function runExternalP(ByVal ex As String) As Integer
        Dim run As System.Diagnostics.Process = System.Diagnostics.Process.Start(ex)
        Return run.Id 'return process id

        'other method:
        'Shell("cmd /c cscript ""C:\Users\shuju\Documents\Visual Studio 2010\Projects\ECSLauncher\ECSLauncher\bin\Libraries\www.vbs""", 1)
        'Dim startCode As String
        'Dim WshShell As Object
        'Dim wsc As Object
        'ww = Shell("cmd /c cscript """ & ttt & """", 1)
        'WshShell = CreateObject("Wscript.Shell")
        'startCode = WshShell.run(ttt, 0, False)
        'System.Threading.Thread.Sleep(3000)
        ' MsgBox("ww")
        'endProcess()
    End Function


    Sub waitTime(ByVal mt As Integer) 'mt format is millionsecond
        For n = 1 To (mt / 10)
            System.Threading.Thread.Sleep(10)
            Application.DoEvents()
        Next
    End Sub

    Function ProcObjExistByName(ByVal name As String) As Boolean
        Dim procsses As Array
        Dim proc As Object

        If name <> "" Then
            Try
                procsses = System.Diagnostics.Process.GetProcessesByName(name)
                proc = procsses(0)
            Catch exception As Exception
                proc = Nothing
            End Try
            If proc Is Nothing Then
                Return False
            Else
                Return True
            End If

        Else
            Return False
        End If
    End Function

    Function getProcObjByName(ByVal name As String) As Object
        Dim procsses As Array
        Dim proc As Object
        If name <> "" Then
            Try
                procsses = System.Diagnostics.Process.GetProcessesByName(name)
                proc = procsses(0)
            Catch exception As Exception
                proc = Nothing
            End Try
            If proc Is Nothing Then
                Return Nothing
            Else
                Return proc
            End If
        Else
            Return Nothing
        End If
    End Function
    Sub endProcess(ByVal id As Integer)
        If id <> 0 Then
            Dim proc As Object
            Try
                proc = System.Diagnostics.Process.GetProcessById(id)
                'pro.ExitCode
            Catch exception As Exception
                proc = Nothing
            End Try

            If proc Is Nothing Then
            Else
                Try
                    proc.kill()
                Catch ex As Exception
                    proc = Nothing
                End Try

            End If
        End If


        'process = proc.GetProcessesByName()
        'id IS PID 
        'For Each process In proc
        '    MsgBox(process.id)
        '    MsgBox(process.mainmodule.filename)
        'Next

        'other method
        'other way by wmi
        'Dim objwmiprocess As Object
        'Dim colprocesslist As Object
        'objwmiprocess = GetObject("winmgmts:\\.\root\cimv2")
        'colprocesslist = objwmiprocess.execquery("select * from win32_process")
        'For Each objprocess In colprocesslist
        '    If objprocess.name = "wscript.exe" Then
        '        MsgBox(objprocess.ExecutablePath())
        '        MsgBox(objprocess.processid())
        '        objprocess.terminate()
        '        MsgBox("yes")
        '    End If

        'Next
    End Sub
    Public Declare Function GetWindowThreadProcessId Lib "User32" (ByVal hWnd As Integer, ByRef lpdwProcessId As Integer) As Integer 'this is windoew API


    Function GetLocalHostName()
        Dim HN = System.Net.Dns.GetHostName
        Return HN
    End Function
    <DllImport("User32.dll", EntryPoint:="GetAsyncKeyState", SetLastError:=True, CharSet:=CharSet.Ansi, ExactSpelling:=True, CallingConvention:=CallingConvention.Winapi)>
    Public Function GetAsyncKeyState(ByRef vKey As Integer) As Short
    End Function

    '    <DllImport("Advapi32.dll", EntryPoint:="SetSecurityDescriptorDacl", SetLastError:=True, _
    'CharSet:=CharSet.Auto, ExactSpelling:=True, _
    'CallingConvention:=CallingConvention.Winapi)>
    '    Function SetSecurityDescriptorDacl(ByRef pSecurityDescriptor As Object, ByRef bDaclPresent As Boolean, ByRef pDacl As Object, ByRef bDaclDefaulted As Boolean) As Integer

    '    End Function

    '    <DllImport("Advapi32.dll", EntryPoint:="IsValidAcl", SetLastError:=True, CharSet:=CharSet.Ansi, ExactSpelling:=True, CallingConvention:=CallingConvention.Winapi)>
    '    Public Function IsValidAcl(ByRef pAcl As Object) As Integer
    '    End Function
    '    <DllImport("Advapi32.dll", EntryPoint:="DeleteAce", SetLastError:=True, CharSet:=CharSet.Ansi, ExactSpelling:=True, CallingConvention:=CallingConvention.Winapi)>
    '    Public Function DeleteAce(ByRef pAcl As Object, ByRef dwAceIndex As Long) As Integer
    '    End Function
    '    <DllImport("Advapi32.dll", EntryPoint:="AddAccessAllowedAce", SetLastError:=True, CharSet:=CharSet.Ansi, ExactSpelling:=True, CallingConvention:=CallingConvention.Winapi)>
    '    Public Function AddAccessAllowedAce(ByRef pAcl As Object, ByRef dwAceRevision As Short, ByRef AccessMask As Short, ByRef pSid As Long) As Integer
    '    End Function

    '    <DllImport("Advapi32.dll", EntryPoint:="LookupAccountNameW", SetLastError:=True, CharSet:=CharSet.Unicode, ExactSpelling:=True, CallingConvention:=CallingConvention.Winapi)>
    '    Public Function LookupAccountName(ByVal lpSystemName As String, ByVal lpAccountName As String, ByRef Sid As long, ByRef cbSid As Integer, ByRef ReferencedDomainName As Long, ByRef cchReferencedDomainName As Integer, ByRef peUse As Long) As Integer
    '    End Function

    '    <DllImport("Kernel32.dll", EntryPoint:="HeapAlloc", SetLastError:=True, CharSet:=CharSet.Ansi, ExactSpelling:=True, CallingConvention:=CallingConvention.Winapi)>
    '    Public Function HeapAlloc(ByRef hHeap As Object, ByRef dwFlags As Short, ByRef dwBytes As Long) As Long
    '    End Function

    '    <DllImport("Kernel32.dll", EntryPoint:="HeapFree", SetLastError:=True, CharSet:=CharSet.Ansi, ExactSpelling:=True, CallingConvention:=CallingConvention.Winapi)>
    '    Public Function HeapFree(ByRef hHeap As Object, ByRef dwFlags As Short, ByRef lpMem As Long) As Long
    '    End Function
    '    <DllImport("Kernel32.dll", EntryPoint:="GetProcessHeap", SetLastError:=True, CharSet:=CharSet.Ansi, ExactSpelling:=True, CallingConvention:=CallingConvention.Winapi)>
    '    Public Function GetProcessHeap() As Long
    '    End Function
    '    Function myheapalloc(ByRef x) As Long
    '        Dim handler As Long = GetProcessHeap()
    '        Return HeapAlloc(handler, 0, x)
    '    End Function

    '    Sub myheapfree(ByRef pointer As Long)
    '        Dim handler = GetProcessHeap()
    '        HeapFree(handler, 0, pointer)
    '    End Sub



    Public Function findInstallLocationOfApp(ByVal appname As String)
        Dim location = ""
        Dim regKey As RegistryKey
        regKey = Registry.LocalMachine.OpenSubKey("Software\Microsoft\Windows\CurrentVersion\Uninstall", False)

        Dim keyArry = regKey.GetSubKeyNames
        For i = 0 To UBound(keyArry)
            Dim appKey As RegistryKey = regKey.OpenSubKey(keyArry(i))
            Dim cur = appKey.GetValue("DisplayName")
            If IsNothing(cur) Then
            Else
                If cur.ToLower.Contains(appname.ToLower) Then
                    location = appKey.GetValue("InstallLocation")
                    Exit For
                End If
            End If
            appKey.Close()
        Next

        regKey.Close()
        Return location
    End Function

    Public Sub enableObject(ByRef f As Form, ByRef b As Boolean)
        f.Enabled = b
        f.Activate()
    End Sub


    Function MsgBox(ByRef msg As String, Optional ByVal buttons As MsgBoxStyle = MsgBoxStyle.ApplicationModal, Optional ByVal title As String = "") As Integer
        Dim curForms = Application.OpenForms
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

        Dim st(0) As Array
        st(0) = Nothing
        Dim Form_Main_back_Instance As Object = Nothing
        For Each i In curForms
            If i.tag = "atester" Then
                If i.name = "Form_Main_Back" Then
                    ' Debug.Print("find mainback")
                    Form_Main_back_Instance = i
                Else
                    If i.Visible = True Then
                        ReDim Preserve st(UBound(st) + 1)
                        st(UBound(st)) = {i, i.enabled}
                    End If
                End If
            End If
        Next

        If IsNothing(Form_Main_back_Instance) = False Then
            st(0) = {Form_Main_back_Instance, Form_Main_back_Instance.enabled}
        End If

        For t = 0 To UBound(st)
            If IsNothing(st(t)) = False Then
                st(t)(0).Invoke(New Delegate_EnableObject(AddressOf enableObject), st(t)(0), False)
            End If
        Next

        Dim parentForm = st(UBound(st))(0)
        Dim parentFormlocation = parentForm.location
        mydialog.Location = New Point(parentFormlocation.x + parentForm.Width / 2 - mydialog.Width / 2, parentFormlocation.y + parentForm.Height / 2 - mydialog.Height / 2)
        ' mydialog.Location = parentFormlocation

        mydialog.Show()
        Beep()
        mydialog.BringToFront()
        Do While mydialog.DialogResult = DialogResult.None
            Application.DoEvents()
        Loop
        Dim info = mydialog.DialogResult
        mydialog.Close()
        For t = 0 To UBound(st)
            If IsNothing(st(t)) = False Then
                st(t)(0).Invoke(New Delegate_EnableObject(AddressOf enableObject), st(t)(0), st(t)(1))
            End If
        Next

        mydialog = Nothing
        ReDim st(-1)
        Return info
    End Function

    Function AddtoSync(ByRef syncVar() As Array, ByRef syncpointVar As Integer, ByRef lock As Integer, ByRef tunnel() As Boolean) As Integer

        Dim cur1 = Now
        Dim cur2 = Now
        Dim timout = 60
        Dim status = -1
        Dim sec = 0
        Do Until lock = 0 Or sec >= timout
            waitTime(1000)
            cur2 = Now
            sec = DateDiff(DateInterval.Second, cur1, cur2)
        Loop
        If DateDiff(DateInterval.Second, cur1, cur2) < timout Then
            lock = 1
            ReDim Preserve syncVar(UBound(syncVar) + 1)
            syncVar(UBound(syncVar)) = tunnel 'tunnel{request,respone}
            lock = 0
            status = UBound(syncVar)
        End If

        Return status
    End Function

    Function CheckSyncRequestStatus(ByRef syncVar() As Array, ByRef lock As Integer) As Integer
        Dim findTrue = False
        If IsNothing(syncVar) = False Then
            If UBound(syncVar) >= 0 Then
                For i = 0 To UBound(syncVar)
                    If syncVar(i)(0) Then
                        findTrue = True
                        Exit For
                    End If
                Next
            End If
        End If
        Return findTrue

    End Function

    Function IsSyncVarReady(ByRef lock As Integer) As Boolean
        Dim cur1 = Now
        Dim cur2 = Now
        Dim checktime = 5
        Dim timout = 60
        Dim status = False
        Do Until DateDiff(DateInterval.Second, cur2, Now) >= checktime Or DateDiff(DateInterval.Second, cur1, Now) >= timout
            waitTime(1000)
            If lock = 1 Then
                cur2 = Now
            End If
        Loop
        If DateDiff(DateInterval.Second, cur1, Now) >= timout Then
            status = False
        Else
            status = True
        End If
        Return status

    End Function

    Function ResponseSyncResult(ByRef syncVar() As Array, ByRef index As Integer, ByRef result As Boolean, ByRef lock As Integer) As Boolean
        Dim cur1 = Now
        Dim cur2 = Now
        Dim timout = 60
        Dim status = -1
        Dim sec = 0
        Do Until lock = 0 Or sec >= timout
            waitTime(1000)
            cur2 = Now
            sec = DateDiff(DateInterval.Second, cur1, cur2)
        Loop
        If DateDiff(DateInterval.Second, cur1, cur2) >= timout Then
            Return False
            Exit Function
        End If
        lock = 1
        syncVar(index)(1) = result

        lock = 0
        Return True
    End Function


    Function DestorySyncVar(ByRef syncVar() As Array, ByRef lock As Integer)
        Dim cur1 = Now
        Dim cur2 = Now
        Dim timout = 60
        Dim status = -1
        Dim sec = 0
        Do Until lock = 0 Or sec >= timout
            waitTime(1000)
            cur2 = Now
            sec = DateDiff(DateInterval.Second, cur1, cur2)
        Loop
        If DateDiff(DateInterval.Second, cur1, cur2) >= timout Then
            Return False
            Exit Function
        End If
        lock = 1
        ReDim syncVar(-1)
        lock = 0
        Return True
    End Function

    Function GetVbColor(ByVal colorname As String)
        Dim vbColor As Object

        Select Case LCase(colorname)
            Case "darkgreen"
                vbColor = Color.DarkGreen
            Case "yellowgreen"
                vbColor = Color.YellowGreen
            Case "transparent"
                vbColor = Color.Transparent
            Case "midnightblue"
                vbColor = Color.MidnightBlue
            Case "mediumseagreen"
                vbColor = Color.MediumSeaGreen
            Case "darkgray"
                vbColor = Color.DarkGray
            Case "lightgreen"
                vbColor = Color.LightGreen
            Case "honeydew"
                vbColor = Color.Honeydew
            Case "dimgray"
                vbColor = Color.DimGray
            Case "mintcream"
                vbColor = Color.MintCream
            Case "whitesmoke"
                vbColor = Color.WhiteSmoke
            Case "black"
                vbColor = Color.Black
            Case "white"
                vbColor = Color.White
            Case Else
                vbColor = Color.White
        End Select

        Return vbColor
    End Function

    'Public Sub GetModuleNamesByPID(ByVal procs As Process)
    '    Dim myModules = procs.Modules
    '    Debug.Print("????????????????")
    '    For i As Integer = 0 To myModules.Count - 1
    '        Debug.Print(myModules(i).ModuleName.ToString)
    '    Next


    '    'GetModuleNamesByPID = n
    'End Sub
End Module
