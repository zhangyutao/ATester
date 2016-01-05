Imports System.IO
Imports System.Text

Public Class FileOperator
    'Public vpath As String
    'Public readtext() As String

    'check whether the file is existing
    Public Function hasfile(ByVal vpath)
        If File.Exists(vpath) = True Then
            Return True
        Else
            Return False
        End If
    End Function

    ''read a file by path
    'Public Sub readfile()
    '    If hasfile(vpath) = True Then
    '        readtext = File.ReadAllLines(vpath, Encoding.UTF8)
    '    End If
    'End Sub

    'search and edit the text in a file
    'Public Sub searchEdit(ByVal searchtext As String, ByVal newtext As String)
    '    Dim readt As String
    '    For i = 0 To UBound(readtext)
    '        readt = readtext(i)
    '        If InStr(readt, searchtext) > 0 Then
    '            readtext(i) = newtext
    '            Exit For
    '        End If
    '    Next
    '    'save edited file
    '    File.WriteAllLines(vpath, readtext)
    'End Sub

    'write lines to file
    Public Sub OverWriteAllText(ByVal fpath As String, ByVal arr As String())
        If fpath <> "" Then
            Dim tempstr As String = ""
            For i = 0 To arr.Length - 1
                tempstr = tempstr & vbCrLf & arr(i)
            Next
            tempstr = Replace(tempstr, vbCrLf, "", 1, 1)
            File.WriteAllText(fpath, tempstr)
        End If
    End Sub


    Sub WriteFile(ByVal Path As String, ByVal strContent As String)
        If Path <> "" Then
            If File.ReadAllText(Path) = "" Then
                File.AppendAllText(Path, strContent)
            Else
                File.AppendAllText(Path, vbCrLf + strContent)
            End If

        End If
    End Sub
    Sub WriteResultToRunTimeReportFile(ByVal strTxtReportPath As String, ByVal qtpTestName As String, ByVal strRunResultsStatus As String)
        WriteFile(strTxtReportPath, qtpTestName + ":" + strRunResultsStatus)
    End Sub
    Sub SetFileAttribute(ByVal fpath As String, ByVal Attributes As FileAttributes)
        Dim fileinfo = New FileInfo(fpath)
        fileinfo.Attributes = Attributes
    End Sub
    Public Sub CopyFile(ByVal fpath As String, ByVal tpath As String)
        File.Copy(fpath, tpath, True)
        'Dim fso As Object = CreateObject("Scripting.FileSystemObject")
        'fso.CopyFile(fpath, tpath)
    End Sub
    Public Function openFile(ByVal Path As String)
        Return File.OpenRead(Path)
    End Function

    Public Sub deleteFile(ByVal Path As String)
        File.Delete(Path)
    End Sub
    Public Sub CreateText(ByVal fpath As String)
        Dim temp As Object = File.CreateText(fpath)
        temp.close()
    End Sub
    Public Function ReadText(ByVal fpath As String) As String
        Dim temp() = Split(fpath, ".")
        Select Case temp(UBound(temp))
            Case "txt"
                Return File.ReadAllText(fpath)
            Case Else
                MsgBox("please select .txt format file.")
                Return ""
        End Select

    End Function
    Public Function ReadTextLines(ByVal fpath As String) As String()
        Dim temp() = Split(fpath, ".")
        Select Case temp(UBound(temp))
            Case "txt"
                Return File.ReadAllLines(fpath)
            Case Else
                'MsgBox("please select .txt format file.")
                Return Nothing
        End Select

    End Function

    Sub OverWriteFileWithString(ByVal Path As String, ByVal strContent As String)
        If Path <> "" Then
            File.WriteAllText(Path, strContent)
        End If
    End Sub
 
End Class
