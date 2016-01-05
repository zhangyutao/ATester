'this Class is to control all other classes. it control all vars, objects  during the form1
Public Class MainFormControlHandler
    Private _TB_ReportFolder_Text As String
    Private _TB_Servers_Text As String
    Private _CB_Servers_Checked As Boolean
    Private class_FileOperator1 As New FileOperator
    Public Property CB_Servers_Checked As Boolean ' for control the checked status of check box "CB_Servers" of MainForm
        Set(ByVal value As Boolean)
            _CB_Servers_Checked = value
        End Set
        Get
            CB_Servers_Checked = _CB_Servers_Checked
        End Get
    End Property

    Public Property TB_ReportFolder_Text As String ' for control the text of TextBox "TB_ReportFolder" of MainForm
        Set(ByVal value As String)
            _TB_ReportFolder_Text = value
        End Set
        Get
            TB_ReportFolder_Text = _TB_ReportFolder_Text
        End Get
    End Property
    Public Property TB_Servers_Text As String ' for control the text of TextBox "TB_Servers_" of MainForm
        Set(ByVal value As String)
            _TB_Servers_Text = value
        End Set
        Get
            TB_Servers_Text = _TB_Servers_Text
        End Get
    End Property
    'add array to check box list
    Sub AddArrayToCLB(ByRef clb As CheckedListBox, ByVal arr() As String)

        For Each value In arr
            If Trim(value) <> "" Then
                clb.Items.Add(value)
            End If
        Next
    End Sub
    Sub AddContentToTB(ByRef tb As TextBox, ByVal content As String, Optional ByVal following As String = vbCrLf)
        tb.WordWrap = False
        tb.AppendText(">" + content + following)
    End Sub
    Sub AddArrayToTBWihtNewLines(ByRef tb As TextBox, ByVal arr() As String)
        Dim tmpstr As String = ""
        For Each value In arr
            If Trim(value) <> "" Then
                tmpstr = tmpstr + vbCrLf + value
            End If
        Next
        If UBound(tb.Lines) = -1 Then
            tb.AppendText(Mid(tmpstr, Len(vbCrLf) + 1))
        Else
            If Mid(tb.Text, Len(tb.Text) - 1) = vbCrLf Then
                tb.AppendText(Mid(tmpstr, Len(vbCrLf) + 1) + vbCrLf)
            Else
                tb.AppendText(tmpstr + vbCrLf)
            End If

        End If

    End Sub
    Sub AddArrayToNotifyIcon(ByRef tb As NotifyIcon, ByVal arr() As String)
        Dim tmpstr As String = ""
        For Each value In arr
            If Trim(value) <> "" Then
                tmpstr = tmpstr + vbCrLf + value
            End If
        Next
        tb.ShowBalloonTip(2000, "Double click to show", "Remote Status:" + vbCrLf + Replace(tmpstr, vbCrLf, "", 1, 1), ToolTipIcon.Info)
    End Sub

    Sub AddTextToTB(ByRef tb As TextBox, ByVal txtPath As String)
        Dim temp = class_FileOperator1.ReadTextLines(txtPath)
        If IsNothing(temp) Then
        Else
            tb.Text = ""
            AddArrayToTBWihtNewLines(tb, temp)
        End If
    End Sub
    Sub AddTextToCLB(ByRef clb As CheckedListBox, ByVal txtPath As String)
        Dim temp() = class_FileOperator1.ReadTextLines(txtPath)
        If IsNothing(temp) Then
        Else
            clb.Items.Clear()
            AddArrayToCLB(clb, temp)
        End If
    End Sub

    Sub CleanTB(ByRef tb As TextBox)
        tb.Text = ""
    End Sub
    Sub CleanCLB(ByRef clb As CheckedListBox)
        clb.Items.Clear()
    End Sub
End Class
