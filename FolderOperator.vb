Imports System.IO
Imports System.Management
Imports Shell32
Imports System.Runtime.InteropServices
Imports System.Security.AccessControl
Imports System.Security.Principal
Imports System.Security
Imports Microsoft.Win32.SafeHandles
Imports System.Runtime.ConstrainedExecution



Public Class FolderOperator
    ''Dim folderPath As String
    ''Dim folderName() As String
    ''Dim curDirPath As String

    'get program current folder path
    '[SecurityPermission(SecurityAction.Deny, Flags = SecurityPermissionFlag.UnmanagedCode)]
    Public Function createFolder(ByVal vpath As String)

        Dim sec As DirectorySecurity = New DirectorySecurity
        Dim rule As FileSystemAccessRule = New FileSystemAccessRule("Everyone", FileSystemRights.FullControl, InheritanceFlags.ContainerInherit And InheritanceFlags.ObjectInherit, PropagationFlags.InheritOnly, AccessControlType.Allow)
        sec.AddAccessRule(rule)
        Return Directory.CreateDirectory(vpath, sec)


    End Function
    Public Function getDirect()
        Dim curDirPath As String = Trim(My.Computer.FileSystem.CurrentDirectory)

        Return curDirPath
    End Function
    Sub SetDirAttribute(ByVal dirPath As String, ByVal Attributes As FileAttributes)
        Dim dirinfo = New DirectoryInfo(dirPath)
        dirinfo.Attributes = Attributes
    End Sub
    'see if this folder exists it also can be use to check share folder \\Iecscjm0\AT SC 1830e
    Public Function hasFolder(ByVal vpath As String)
        If Directory.Exists(vpath) Then
            Return True
        Else
            Return False
        End If
    End Function

    'get all folders name under the specified folder
    Public Function getAllFolders(ByVal folderPath As String)
        Dim XName As String
        Dim FolderNames(0) As String
        Dim aSize As Integer

        XName = Dir(folderPath, vbDirectory)   ' Retrieve the first entry.
        Do While XName <> ""   ' Start the loop.
            ' Use bitwise comparison to make sure MyName is a directory.
            If (GetAttr(folderPath & "\" & XName) And vbDirectory) = vbDirectory Then
                ' Display entry only if it's a directory.
                'MsgBox(XName)
                aSize = FolderNames.Length
                FolderNames(aSize - 1) = XName
                Array.Resize(FolderNames, aSize + 1)
            End If
            XName = Dir()   ' Get next entry.
            Application.DoEvents()
        Loop

        Array.Resize(FolderNames, FolderNames.Length - 1)

        Return FolderNames

    End Function
    Public Function switchFolderInSamePathLevel(ByVal OriFolderPath As String, ByVal FolderNameSwitchTo As String)
        Return Left(OriFolderPath, InStrRev(OriFolderPath, "\")) & FolderNameSwitchTo
    End Function
    Public Function getUpFolderNameInStr(ByVal OriFolderPath As String)
        Return Left(OriFolderPath, InStrRev(OriFolderPath, "\") - 1)
    End Function
    Function getAllFolderNames(ByVal curf As String)
        Dim temp1 As Integer = InStrRev(curf, "\")
        Dim temp2 As Integer = Len(curf)
        If temp1 <> temp2 Then
            curf = curf & "\"
        End If

        Dim curFoldernames() As String = getAllFolders(curf)

        Return curFoldernames

    End Function

    ''Check Folder
    'Function checkFolder(ByVal ExpectedFolders As String(), ByVal curFoldernames As String()) As Boolean
    '    If UBound(ExpectedFolders) <> UBound(curFoldernames) Then
    '        Return False
    '    Else
    '        If comparetwoarray(ExpectedFolders, curFoldernames) = True Then
    '            Return True
    '        Else
    '            Return False
    '        End If
    '    End If
    'End Function


    Function shareFolder(ByVal folderPath As String, ByVal sharename As String, ByVal Type As Integer, ByVal usernameOrGroupName As String) As String
        Dim des = ""


        ' Connect to WMI and obtain instances of Win32_OperatingSystem
        Dim osver = ""
        For Each objOS In GetObject("winmgmts:").InstancesOf("Win32_OperatingSystem")
            osver = objOS.Caption.ToString
        Next

        'If Err.Number <> 0 Then
        '    osver = ""
        '    Debug.Write(Err.Description)
        'End If

        Dim objshare As ManagementClass
        If osver.Contains("Server") Then

            'Class_MainFormControlHandler1.AddContentToTB(TB_MainLog, "Error: " + result + vbCrLf + "Failed to give shared full control of folder " + TestResultPath + " to everyone failed. UFT detail result will be put in machine which execute test, path is " + remoteReportRootFolder + vbCrLf + ">" + CStr(Now))
            'objshare = New ManagementClass("Win32_ClusterShare")
            osver = "Cluster\" + osver
            Dim CMDR = ""
            Try
                Dim process As New System.Diagnostics.Process()
                process.StartInfo.FileName = "cmd.exe"
                process.StartInfo.UseShellExecute = False
                process.StartInfo.RedirectStandardInput = True
                process.StartInfo.RedirectStandardOutput = True
                process.StartInfo.RedirectStandardError = True
                process.StartInfo.CreateNoWindow = True
                process.Start()
                process.StandardInput.WriteLine("net share " + sharename + "=" + folderPath + " /grant:" + usernameOrGroupName + ",full")
                process.StandardInput.WriteLine("exit")
                CMDR = process.StandardOutput.ReadToEnd()
                process.Close()
                If CMDR.Contains(sharename + " was shared successfully") Then
                    Return ""
                Else
                    Return des = "Create share error! version: " + osver
                End If

                'Debug.Print(CMDR)
            Catch e As Exception
                'Debug.Print(e.Message)
                Return des = "Create share error! version: " + osver + " Error msg:" + e.Message
            End Try


        Else
            objshare = New ManagementClass("Win32_Share")
            Dim errReturn As Integer = objshare.InvokeMethod("Create", New Object() {folderPath, sharename, Type})
            If errReturn <> 0 Then
                des = "Create share error! version: " + osver + " Error code:" + CStr(errReturn)
                'MsgBox("Create share failed." & vbCrLf & Err.Description)
                Return des
            End If

            'user selection
            Dim ntAccount As New NTAccount(usernameOrGroupName)

            'SID
            Dim userSID As SecurityIdentifier = ntAccount.Translate(GetType(SecurityIdentifier))
            Dim utenteSIDArray(userSID.BinaryLength) As Byte
            userSID.GetBinaryForm(utenteSIDArray, 0)

            'Trustee
            Dim userTrustee As New ManagementClass(New ManagementPath("Win32_Trustee"))
            userTrustee.SetPropertyValue("Name", "Everyone")
            userTrustee.SetPropertyValue("SID", utenteSIDArray)

            'ACE
            Dim userACE As New ManagementClass(New ManagementPath("Win32_Ace"))
            userACE.SetPropertyValue("AccessMask", 2032127)
            userACE.SetPropertyValue("AceFlags", AceFlags.ObjectInherit And AceFlags.ContainerInherit)
            userACE.SetPropertyValue("AceType", AceType.AccessAllowed)
            userACE.SetPropertyValue("Trustee", userTrustee)

            Dim userSecurityDescriptor As New ManagementClass(New ManagementPath("Win32_SecurityDescriptor"))
            Dim DACL(0) As Object
            DACL(0) = userACE
            userSecurityDescriptor.SetPropertyValue("ControlFlags", 4)
            userSecurityDescriptor.SetPropertyValue("DACL", DACL)
            Dim thisShareFolder As New ManagementObject(objshare.Path.ToString + ".Name='" + sharename + "'")

            Dim description As String = "AT"
            Dim shareNumber As Integer = 21
            Dim result = thisShareFolder.InvokeMethod("SetShareInfo", New Object() {shareNumber, description, userSecurityDescriptor})
            If result <> 0 Then
                des = "SetShareInfo error! version: " + osver + " Error code:" + CStr(result)
                'MsgBox("SetShareInfo failed." & vbCrLf & Err.Description)
                Return des
            End If

            objshare = Nothing
            ntAccount = Nothing
            userSID = Nothing
            userTrustee = Nothing
            userACE = Nothing
            userSecurityDescriptor = Nothing

        End If

        Return ""
    End Function
    Sub openFolder(ByVal path As String)
        Dim ShellA As New Shell
        ShellA.Open(path)
        'Dim Shellb As Folder
        'Shellb = ShellA.BrowseForFolder(0, "Select to open", 0)
        'Dim iBrowser As New FolderBrowserDialog
        'iBrowser.ShowDialog()
        'iBrowser.SelectedPath = path
    End Sub
    Function returnOpenFilePath(Optional ByVal ext As String = "") As String
        Dim iBrowser As New OpenFileDialog
        iBrowser.Multiselect = False
        iBrowser.InitialDirectory = Environment.SpecialFolder.Desktop
        iBrowser.ShowHelp = False

        Select Case ext
            Case ""

            Case "atconfig"
                iBrowser.Filter = "ATester Plan (*.atplan)|*.atplan"
        End Select
        iBrowser.ShowDialog()
        If iBrowser.FileName <> "" Then
        Return iBrowser.FileName
        Else
        Return ""
        End If
    End Function

    Function returnOpenFolderPath(ByVal description As String) As String
        Dim iBrowser As New FolderBrowserDialog
        iBrowser.RootFolder = Environment.SpecialFolder.Desktop
        iBrowser.ShowNewFolderButton = True
        iBrowser.Description = description
        iBrowser.ShowDialog()
        Dim path = iBrowser.SelectedPath
        iBrowser = Nothing
        If path <> "" Then
            Return path
        Else
            Return ""
        End If
    End Function

    Function returnSaveFilePath() As String
        Dim iBrowser As New SaveFileDialog
        iBrowser.InitialDirectory = Environment.SpecialFolder.Desktop
        iBrowser.CheckFileExists = False
        iBrowser.AddExtension = True
        iBrowser.DefaultExt = ".txt"
        iBrowser.Filter = "Text files (*.txt)|*.txt|All files (*.txt)|*.txt"
        iBrowser.CheckPathExists = True
        iBrowser.ShowHelp = False
        iBrowser.ShowDialog()
        If iBrowser.FileName <> "" Then
            'MsgBox(iBrowser.FileName)
            Return iBrowser.FileName
        Else
            Return ""
        End If
    End Function


    Public Sub addpathPower(ByVal pathname As String, ByVal username As String, ByVal power As String)

        Dim dirinfo As DirectoryInfo = New DirectoryInfo(pathname)

        If (dirinfo.Attributes & FileAttributes.ReadOnly) <> 0 Then
            dirinfo.Attributes = FileAttributes.Normal
        End If

        '取得访问控制列表
        Dim dirsecurity As DirectorySecurity = dirinfo.GetAccessControl()

        Select Case power
            Case "FullControl"
                'Dim ww = dirsecurity.GetOwner(GetType(SecurityIdentifier))

                dirsecurity.AddAccessRule(New FileSystemAccessRule(username, FileSystemRights.FullControl, InheritanceFlags.ObjectInherit And InheritanceFlags.ContainerInherit, PropagationFlags.NoPropagateInherit, AccessControlType.Allow))
                dirinfo.SetAccessControl(dirsecurity)

                'dirinfo = New DirectoryInfo(pathname)
                'dirsecurity = dirinfo.GetAccessControl()
                'Dim ntAccount As New NTAccount(username)
                'Dim userSID As SecurityIdentifier = ntAccount.Translate(GetType(SecurityIdentifier))
                'dirsecurity.SetOwner(userSID)
                'dirinfo.SetAccessControl(dirsecurity)
            Case "ReadOnly"
                dirsecurity.AddAccessRule(New FileSystemAccessRule(username, FileSystemRights.Read, AccessControlType.Allow))
                dirinfo.SetAccessControl(dirsecurity)

            Case "Write"
                dirsecurity.AddAccessRule(New FileSystemAccessRule(username, FileSystemRights.Write, AccessControlType.Allow))
                dirinfo.SetAccessControl(dirsecurity)

            Case "Modify"
                dirsecurity.AddAccessRule(New FileSystemAccessRule(username, FileSystemRights.Modify, AccessControlType.Allow))
                dirinfo.SetAccessControl(dirsecurity)
        End Select


    End Sub

    Public Function GetFileSystemRightsOfFolder(ByVal folder As String, ByVal userOrGroup As String) As FileSystemRights
        Dim folderSecurity = Directory.GetAccessControl(folder)
        Dim rule = folderSecurity.GetAccessRules(True, True, GetType(NTAccount)).OfType(Of FileSystemAccessRule).Where(Function(r) r.IdentityReference.Value.Contains(userOrGroup)).FirstOrDefault()
        If rule Is Nothing Then
            Return Nothing
        Else
            Return rule.FileSystemRights
        End If
    End Function

    Friend NotInheritable Class SafeLocalMemHandle
        Inherits SafeHandleZeroOrMinusOneIsInvalid

        Public Sub New()
            MyBase.New(True)
        End Sub

        Public Sub New(ByVal preexistingHandle As IntPtr, _
            ByVal ownsHandle As Boolean)
            MyBase.New(ownsHandle)
            MyBase.SetHandle(preexistingHandle)
        End Sub

        <ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success), _
            DllImport("kernel32.dll", CharSet:=CharSet.Auto, SetLastError:=True)> _
        Private Shared Function LocalFree(ByVal hMem As IntPtr) As IntPtr
        End Function

        Protected Overloads Overrides Function ReleaseHandle() As Boolean
            Return (LocalFree(MyBase.handle) = IntPtr.Zero)
        End Function

    End Class
    Sub copyFolder(ByVal src As String, ByVal dst As String)
        My.Computer.FileSystem.CopyDirectory(src, dst, True)
    End Sub
    'Structure SecurityDescriptor
    '    Dim ControlFlags As Integer
    '    Dim DACL() As ACE
    '    Dim Group As Trustee
    '    Dim Owner As Trustee
    '    Dim SACL() As ACE
    '    Sub dsfd()

    '    End Sub
    'End Structure

    'Structure Trustee
    '    Dim Domain As String
    '    Dim Name As String
    '    Dim SID() As Short
    '    Dim SidLength As Integer
    '    Dim SIDString As String
    'End Structure

    'Structure ACE
    '    Dim AccessMask As Integer
    '    Dim AceFlags As Integer
    '    Dim AceType As Integer
    '    Dim GuidInheritedObjectType As String
    '    Dim GuidObjectType As String
    '    Dim Trustee As Trustee
    'End Structure


End Class
