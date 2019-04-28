Imports System.Security
Public Class frmMain
    Public doReboot As Boolean = False

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If CheckLFFState() = True Then
            setLabelState(True)
        Else
            setLabelState(False)
        End If
        Me.Text = My.Application.Info.AssemblyName
    End Sub

    Function CheckLFFState() As Boolean
        Dim retVal As Boolean
        Dim readValue = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\FileSystem", "LongPathsEnabled", Nothing)
        If readValue = 0 Then retVal = False Else retVal = True
        Return retVal
    End Function

    Function SetLFF(state As Boolean) As Boolean
        Dim setState As Integer = 0
        If state = True Then setState = 1 Else setState = 0
        Dim success As Boolean
        Try
            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\FileSystem", "LongPathsEnabled", setState)
            success = True
            doReboot = True
        Catch
            success = False
        End Try
        Return success
    End Function

    Sub setLabelState(state As Boolean)
        Select Case state
            Case True
                lblStatus.Text = "Enabled"
                lblStatus.ForeColor = Color.DarkGreen
            Case False
                lblStatus.Text = "Disabled"
                lblStatus.ForeColor = Color.IndianRed
        End Select
    End Sub

    Private Sub btnFix_Click(sender As Object, e As EventArgs) Handles btnFix.Click
        Dim result As Boolean = SetLFF(True)
        If result Then MsgBox("Changed successfully.", MsgBoxStyle.Information, My.Application.Info.AssemblyName) Else MsgBox("Change Failed", MsgBoxStyle.Critical, Me.Text)
        setLabelState(CheckLFFState)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If doReboot Then
            Dim result As Boolean = MsgBox("You will need to reboot for this to take effect, would you like to reboot now?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, Me.Text)
            If result = vbYes Then
                System.Diagnostics.Process.Start("shutdown", "-r -t 00")
                Application.Exit()
            Else
                Application.Exit()
            End If
        Else
            Application.Exit()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim result As Boolean = SetLFF(False)
        If result Then MsgBox("Changed successfully.", MsgBoxStyle.Information, My.Application.Info.AssemblyName) Else MsgBox("Change Failed", MsgBoxStyle.Critical, My.Application.Info.AssemblyName)
        setLabelState(CheckLFFState)
    End Sub
End Class
