Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Drawing

Public Class changepassword
    Dim evntlist As New eventlists
    Dim x = 0, y = 0
    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Dim sql As New sqlclass
        If TextBoxnewpass.Text = TextBoxconfirmnewpass.Text And TextBoxnewpass.Text.Trim.Length >= Login_Register.passlen And (IsAlphaNum(TextBoxnewpass.Text) = True) Then
            Try
                '    If IsAlphaNum(TextBoxnewpass.Text) = True Then
                If Login_Register.passprevoiuscheck = 0 Then
                    ' Dim query As String = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 update  employeeinfo set password ='" & sqlclass.AES_Encrypt(TextBoxnewpass.Text, "r1m2s3") & "',passworddate= EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & variableclass.datee & "') ),active=1 where empid='" & Login_Register.empid & "'"
                    Dim query As String = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 update  employeeinfo set password = EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & TextBoxnewpass.Text & "')),passworddate= EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & variableclass.datee & "') ),active=1 where empid='" & Login_Register.empid & "'"
                    sql.scon1()
                    Dim sqlcmd As SqlCommand = New SqlCommand(query, sql.scn1)

                    sqlcmd.ExecuteNonQuery()
                    sqlcmd.Dispose()
                    sql.scn1.Close()
                    evntlist.insertscadaevent(Login_Register.empid, "Password Changed", "", "", "", "", "", "", "", "", "", "", "Audittrail")
                    MessageBox.Show("Password Successfully changed!!!", "ChangePassword")
                    Me.Hide()
                Else
                    Dim reg As New register
                    ' Dim tempreg = reg.changepasswordcondition(Login_Register.empid, sqlclass.AES_Encrypt(TextBoxnewpass.Text, "r1m2s3"))
                    Dim tempreg = reg.changepasswordcondition(Login_Register.empid, TextBoxnewpass.Text)
                    If tempreg = True Then
                        Dim query As String = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 update  employeeinfo set passworddate= EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & variableclass.datee & "') ),active=1 where empid='" & Login_Register.empid & "'"
                        sql.scon1()
                        Dim sqlcmd As SqlCommand = New SqlCommand(query, sql.scn1)

                        sqlcmd.ExecuteNonQuery()
                        sqlcmd.Dispose()
                        sql.scn1.Close()
                        evntlist.insertscadaevent(Login_Register.empid, "Password Changed", "", "", "", "", "", "", "", "", "", "", "Audittrail")

                        MessageBox.Show("Password Successfully changed!!!", "ChangePassword")

                    End If

                End If
            Catch ex As Exception

            End Try
        Else

        End If
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
    Private Sub TextBoxnewpass_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxnewpass.TextChanged
        If TextBoxnewpass.Text.Length < Login_Register.passlen Then
            Label18.ForeColor = Color.Red

        Else
            Dim reg As New register
            If reg.IsAlphaNum(TextBoxnewpass.Text) = True Then
                Label18.ForeColor = Color.Silver
            Else
                Label18.ForeColor = Color.Red
            End If
        End If
    End Sub
    Private Function IsAlphaNum(ByVal strInputText As String) As Boolean
        ' Return System.Text.RegularExpressions.Regex.IsMatch(strInputText, "(?!^[0-9]*$)(?!^[a-zA-Z]*$)^([a-zA-Z0-9]{" & Login_Register.passlen & ",50})$")
        Return System.Text.RegularExpressions.Regex.IsMatch(strInputText, "^.*(?=.*[a-zA-Z])(?=.*\d)(?=.*[\.@_-`~!@#$%^&*()_+={}\[\]\\|:;""'<>,.?/-]){" & Login_Register.passlen & ",50}.*$")
    End Function
    Private Sub TextBoxconfirmnewpass_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxconfirmnewpass.TextChanged
        If TextBoxnewpass.Text = TextBoxconfirmnewpass.Text Then
            Label19.Text = ""
        Else
            Label19.Text = "Password and Confirm Password do not match"
        End If
    End Sub

    Private Sub changepassword_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Me.StartPosition = FormStartPosition.CenterParent
        Label18.Text = "*Password- Alphanumeric and Special and Minimum " & Login_Register.passlen & " characters"
        ' Me.Location = (New System.Drawing.Point(x, y))
    End Sub
    Sub New(tempx, tempy)
        x = tempx
        y = tempy
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub


    Private Sub TextBoxnewpass_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxnewpass.Click, TextBoxnewpass.GotFocus
        Try
            'ON CLICK AND IF TEXTBOX GOT FOCUS KEYBOARD WILL BE POPUP AUTOMATICALLY

            '  Process.Start(FileToCopy, "scadatagsystem rmsview rmsview")
            If variableclass.on_screen_keyboard Then
                Dim pProcess() As Process = System.Diagnostics.Process.GetProcessesByName("finalKeyboarddesigned")
                If pProcess.Count > 0 Then
                Else
                    Dim FileToCopy = Application.StartupPath & "\resource\finalKeyboarddesigned.exe"
                    Dim startInfo As ProcessStartInfo = New ProcessStartInfo(FileToCopy)
                    Process.Start(startInfo)

                End If
            End If



           


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub TextBoxconfirmnewpass_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxconfirmnewpass.Click, TextBoxconfirmnewpass.GotFocus
        Try
            'ON CLICK AND IF TEXTBOX GOT FOCUS KEYBOARD WILL BE POPUP AUTOMATICALLY

            '  Process.Start(FileToCopy, "scadatagsystem rmsview rmsview")

            If variableclass.on_screen_keyboard Then

                Dim pProcess() As Process = System.Diagnostics.Process.GetProcessesByName("finalKeyboarddesigned")
                If pProcess.Count > 0 Then
                Else
                    Dim FileToCopy = Application.StartupPath & "\resource\finalKeyboarddesigned.exe"
                    Dim startInfo As ProcessStartInfo = New ProcessStartInfo(FileToCopy)
                    Process.Start(startInfo)

                End If
            End If



        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

End Class