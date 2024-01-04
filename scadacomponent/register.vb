Imports System.Data.SqlClient
Imports System.Drawing
Imports System.Windows.Forms

Public Class register
    Dim ev As New eventlists
    Public Event regon()
    Dim sql As New sqlclass
    Private Sub btnRRegister_Click(sender As System.Object, e As System.EventArgs) Handles btnRRegister.Click
        If txtname.Text <> "" And txtid.Text.Length >= Login_Register.useridlen And txtpass.Text.Length >= Login_Register.passlen And (txtid.Text = txtcid.Text) And (txtpass.Text = txtcpass.Text) And (IsAlphaNum(txtpass.Text) = True) Then
            Dim selectid As String = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 Select CONVERT(varchar, DecryptByKey(userid)) from employeeinfo where CONVERT(varchar, DecryptByKey(userid)) ='" & Trim(txtid.Text) & "'"
            Try
                sql.scon1()
                Dim sqlcmd1 As SqlCommand = New SqlCommand(selectid, sql.scn1)
                Dim reader2 As SqlDataReader = sqlcmd1.ExecuteReader
                If reader2.Read Then
                    MsgBox("UserID already registered, Kindly enter a different 'UserID'!", MsgBoxStyle.Exclamation)
                Else
                    Label7.Text = ""

                    Dim name As String = txtname.Text
                    Dim userid As String = txtid.Text
                    Dim pass As String = txtpass.Text

                    'Dim wrapper As New Simple3Des(pass)
                    ' Dim encryptpass As String = sqlclass.AES_Encrypt(pass, "r1m2s3")
                    Dim encryptpass As String = pass

                    Try
                        ' Dim query As String = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 insert into employeeinfo output INSERTED.empid values( EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & name & "') ), EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & userid & "') ),'" & encryptpass & "','" & ComboBox1.SelectedValue & "','0', EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & variableclass.datee & "') ))"
                        Dim query As String = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 insert into employeeinfo output INSERTED.empid values( EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & name & "') ), EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & userid & "') ), EncryptByKey( Key_GUID('SymmetricKey1'),CONVERT(varchar,'" & encryptpass & "')), '" & ComboBox1.SelectedValue & "','0', EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & variableclass.datee & "') ))"

                        sql.scon2()
                        Dim sqlcmd As SqlCommand = New SqlCommand(query, sql.scn2)

                        Dim tempempid = DirectCast(sqlcmd.ExecuteScalar(), Integer)

                        changepasswordcondition(tempempid, encryptpass)
                        sqlcmd.Dispose()
                        sql.scn2.Close()
                        '  Label7.Text = "Successfully registered!!!"
                        MessageBox.Show("Successfully registered!!!", "Register")
                        Dim ev As New eventlists

                        ev.insertscadaevent(Login_Register.empid, "NEW REGISTRACTION", "", "NAME: " & name, "Level: " & ComboBox1.Text, "", "", "", "", "", "", "", "Audittrail")
                        txtname.Text = ""
                        txtid.Text = ""
                        txtcid.Text = ""
                        txtpass.Text = ""
                        txtcpass.Text = ""
                        '   Label7.ForeColor = Color.DarkGreen
                        '           ev.insertscadaevent(Login_Register.empid, "New Registration", "", "", "", "", "", "", "", "", "", "", "Audittrail")
                        RaiseEvent regon()
                        '   Me.Close()
                    Catch ex As SqlException

                        sql.scn2.Close()
                        MsgBox("Error - " & ex.Message)
                    End Try
                End If
                reader2.Close()
                sqlcmd1.Dispose()
            Catch ex As Exception
            Finally

                sql.scn1.Close()
            End Try
        Else
            If Not (txtname.Text <> "" And txtid.Text <> "" And txtpass.Text <> "" And txtcid.Text <> "" And txtcpass.Text <> "") Then
                Label7.Text = "All Fields are Mandatory"
            ElseIf Label5.Text <> "" Or Label6.Text <> "" Then
                Label7.Text = "Confirm(s) fields dont match"
            Else
                Label7.Text = "Something is not right"
            End If

        End If
    End Sub
    Private Sub TextBox3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcid.TextChanged
        If txtid.Text = txtcid.Text Then
            Label5.Text = ""
        Else
            Label5.Text = "UserId and Confirm UserId do not match"
        End If
    End Sub

    Private Sub txtcpass_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcpass.TextChanged
        If txtpass.Text = txtcpass.Text Then
            Label6.Text = ""
        Else
            Label6.Text = "Password and Confirm Password do not match"
        End If
    End Sub
    Private Sub txtid_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtid.TextChanged
        If txtid.Text.Length < Login_Register.useridlen Then
            Label8.ForeColor = Color.Red

        Else
            Label8.ForeColor = Color.Silver
        End If
    End Sub

    Private Sub txtpass_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtpass.TextChanged
        If txtpass.Text.Length < Login_Register.passlen Or IsAlphaNum(txtpass.Text) = False Then
            Label9.ForeColor = Color.Red

        Else
            If IsAlphaNum(txtpass.Text) = True Then
                Label9.ForeColor = Color.Silver
            End If
        End If

    End Sub
    Public Function IsAlphaNum(ByVal strInputText As String) As Boolean
        Dim loginreg As New Login_Register
        '--  Return System.Text.RegularExpressions.Regex.IsMatch(strInputText, "(?!^[0-9]*$)(?!^[a-zA-Z]*$)^([a-zA-Z0-9]{" & Login_Register.passlen & ",50})$")


        'Return System.Text.RegularExpressions.Regex.IsMatch(strInputText, "(?!^[0-9]*$)(?!^[a-zA-Z]*$)(?!^[`~!@#\$%\^&\*\(\)_\-\+=\{\}\[\]\\\|:;""'<>,\.\?/]*$)^([a-zA-Z0-9]{" & Login_Register.passlen & ",50})$")

        '  Return System.Text.RegularExpressions.Regex.IsMatch(strInputText, "^.*(?=.*[a-zA-Z])(?=.*\d)(?=.*[\.@_-`~!@#$%^&*()_+={}\[\]\\|:;""'<>,.?/-]){" & Login_Register.passlen & ",50}.*$")

        Dim t1 = System.Text.RegularExpressions.Regex.IsMatch(strInputText, "^(.*?[A-Z]){" & loginreg.passuppercase & ",}.*$")
        Dim t2 = System.Text.RegularExpressions.Regex.IsMatch(strInputText, "^(.*?[0-9]){" & loginreg.passnumericchar & ",}.*$")
        Dim t3 = System.Text.RegularExpressions.Regex.IsMatch(strInputText, "^(.*?[a-z]){" & loginreg.passlowercase & ",}.*$")
        Dim t4 = System.Text.RegularExpressions.Regex.IsMatch(strInputText, "^(.*?[\.@_-`~!@#$%^&*()_+={}\[\]\\|:;""'<>,.?/-]){" & loginreg.passspecialchar & ",}.*$")
        If t1 = True And t2 = True And t3 = True And t4 = True And strInputText.Length >= Login_Register.passlen Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub register_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Me.StartPosition = FormStartPosition.CenterParent

        Label8.Text = "*User ID should have minimum " & Login_Register.useridlen & " characters"
        Label9.Text = "*Password- Alphanumeric and Special and minimum " & Login_Register.passlen & " characters"
        Dim query2 As String
        If Login_Register.plevel = Login_Register.mngr Then
            query2 = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 Select levelid,CONVERT(varchar, DecryptByKey(levelname)) as levelname from leveldetails where levelid >2 and levelid<>" & Login_Register.mngr
        Else
            query2 = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 Select levelid,CONVERT(varchar, DecryptByKey(levelname)) as levelname from leveldetails where levelid >2"
        End If
        sql.scon3()
        Dim sqlcmd1 As SqlCommand = New SqlCommand(query2, sql.scn3)
        '  Dim reader As SqlDataReader = sqlcmd.ExecuteReader

        Dim i = 0, j = 0
        'While reader.Read
        '    If String.Compare(reader.Item(1), "Manager", True) Then
        '        mngr = reader.Item(0)
        '        Exit While
        '    End If
        'End While

        sqlcmd1.ExecuteNonQuery()
        Dim DA = New SqlDataAdapter
        DA.SelectCommand = sqlcmd1
        Dim DataSet = New DataSet
        DA.Fill(DataSet)
        ComboBox1.DataSource = DataSet.Tables(0)
        ComboBox1.ValueMember = "levelid"
        ComboBox1.DisplayMember = "levelname"
        sql.scn3.Close()
    End Sub

    Private Sub btnRLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRLogin.Click
        Me.Close()
    End Sub

    Public Function changepasswordcondition(ByVal empid As Integer, ByVal temp_pass As String) As String
        If Login_Register.passprevoiuscheck = 0 Then
            Exit Function
        End If
        Dim query = "select count(*) from passwordlist where empid='" & empid & "' "
        sql.scon2()
        Dim sqlcmd As SqlCommand = New SqlCommand(query, sql.scn2)
        Dim reader As SqlDataReader = sqlcmd.ExecuteReader
        Dim temp_pass_count = 0
        If reader.Read Then
            temp_pass_count = reader.Item(0)
        End If
        reader.Close()
        If temp_pass_count < Login_Register.passprevoiuscheck Then
            Dim temppre = previous_password_check(temp_pass, empid)
            If temppre = True Then
                Return True
            End If
        Else
            Dim temppre = previous_password_check(temp_pass, empid)
            If temppre = True Then
                Dim q2 = "delete from passwordlist where empid='" & empid & "' and sno=(select top 1 sno from passwordlist where empid='" & empid & "' order by  CONVERT(varchar, DecryptByKey(date)),sno asc)"
                sql.scon3()
                Dim sqlcmd1 As SqlCommand = New SqlCommand(q2, sql.scn3)
                sqlcmd1.ExecuteNonQuery()
                sql.scn3.Close()
                Return True
                '     MessageBox.Show("Password Successfully changed!!!", "ChangePassword")
            End If
        End If
        sql.scn2.Close()
    End Function

    'previous_password_check check the entered password with the prevoius entered

    Public Function previous_password_check(ByVal temp_pass As String, ByVal empid As Integer) As Boolean
        sql.scon4()
        Dim q1 = "select empid from passwordlist where password='" & temp_pass & "' and empid='" & empid & "'"
        Dim sqlcmd As SqlCommand = New SqlCommand(q1, sql.scn4)
        Dim reader As SqlDataReader = sqlcmd.ExecuteReader
        If reader.Read Then
            MsgBox("Please enter different password can't use previously " & Login_Register.passprevoiuscheck & " used password")
            Return False
        Else
            q1 = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 insert into passwordlist(empid,password,date) values('" & empid & "','" & temp_pass & "', EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & variableclass.datee & "') ))"
            sql.scon3()
            Dim sqlcmd1 As SqlCommand = New SqlCommand(q1, sql.scn3)
            sqlcmd1.ExecuteNonQuery()
            q1 = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 update employeeinfo set password='" & temp_pass & "' where empid='" & empid & "'"
            sql.scon3()
            sqlcmd1 = New SqlCommand(q1, sql.scn3)
            sqlcmd1.ExecuteNonQuery()
            sql.scn3.Close()
            Return True
        End If
        sql.scn4.Close()
    End Function


    Private Sub txtcid_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcid.Click, txtcid.GotFocus
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

    Private Sub txtcpass_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcpass.Click, txtcpass.GotFocus
        Try
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

    Private Sub txtid_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtid.Click, txtid.GotFocus
        Try
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

    Private Sub txtpass_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtpass.Click, txtpass.GotFocus
        'ON CLICK AND IF TEXTBOX GOT FOCUS KEYBOARD WILL BE POPUP AUTOMATICALLY
        Try
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

    'ON CLICK AND IF TEXTBOX GOT FOCUS KEYBOARD WILL BE POPUP AUTOMATICALLY
    Private Sub txtname_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtname.Click, txtname.GotFocus
        Try
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