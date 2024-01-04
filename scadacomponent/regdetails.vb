Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Drawing

Public Class regdetails
    Dim sql As New sqlclass

    Dim tempuserid = ""

    Public tempregister As registerdetails

    Sub New()


        ' This call is required by the designer.

        InitializeComponent()


        ' Add any initialization after the InitializeComponent() call.


    End Sub

    Sub New(ByVal tempuid As String)

        tempuserid = tempuid


        ' This call is required by the designer.

        InitializeComponent()

        TextBox5.Text = tempuid

        getdetails()

        ' Add any initialization after the InitializeComponent() call.


    End Sub



    Private Sub getProductData(ByVal dataCollection As AutoCompleteStringCollection)
        Dim c As New sqlclass
        Dim da As New SqlDataAdapter()
        Dim ds As New DataSet()


        Dim SQL As String
        c.scon1()
        Try
            '    Dim files() As String = IO.Directory.GetFiles("D:\RMS\")

            '   For Each file As String In files
            If Login_Register.levelid = 1 Then
                SQL = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select CONVERT(varchar, DecryptByKey(fname)),CONVERT(varchar, DecryptByKey(userid))  from employeeinfo where empid<>1"
            Else
                SQL = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select CONVERT(varchar, DecryptByKey(fname)),CONVERT(varchar, DecryptByKey(userid))  from employeeinfo where empid<>1 and plevel<> " & Login_Register.levelid & ""

            End If
            'MsgBox("Connection Open ! ")
            Dim sqlcmd As SqlCommand = New SqlCommand(SQL, sqlclass.sqlcon)
            sqlcmd.CommandTimeout = 60
            '   connect.cmd.ExecuteNonQuery()
            da = New SqlDataAdapter(sqlcmd)
            ds = New DataSet
            da.Fill(ds)

            For Each row As DataRow In ds.Tables(0).Rows

                dataCollection.Add(row(0).ToString + "_" + row(1).ToString)
            Next
            ' Next
            sqlcmd.Dispose()
            c.scn1.Close()
        Catch ex As Exception
            MessageBox.Show("error ! ")
        End Try
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            txtcpass.Enabled = True
            txtpass.Enabled = True
        Else
            txtcpass.Enabled = False
            txtpass.Enabled = False
        End If
    End Sub

    Private Sub TextBox5_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox5.TextChanged
        If TextBox5.Text.Contains("_") Then
            Dim query As String

            If Login_Register.levelid = 1 Then
                query = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select levelid,CONVERT(varchar, DecryptByKey(levelname)) as levelname from leveldetails where levelid<>1"
            Else
                query = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select levelid,CONVERT(varchar, DecryptByKey(levelname)) as levelname from leveldetails where levelid<>1 and levelid<>" & Login_Register.levelid
            End If
            sql.scon2()
            Dim sqlcmd As SqlCommand = New SqlCommand(query, sql.scn2)
            sqlcmd.ExecuteNonQuery()
            Dim DA = New SqlDataAdapter
            DA.SelectCommand = sqlcmd
            Dim DataSet = New DataSet
            DA.Fill(DataSet)
            ComboBox2.DataSource = DataSet.Tables(0)
            ComboBox2.ValueMember = "levelid"
            ComboBox2.DisplayMember = "levelname"
            If Login_Register.levelid > 1 Then
                '      ComboBox2.Items.Remove("Manager")
            End If
            sqlcmd.Dispose()
            Dim temp = TextBox5.Text
            Dim i = temp.IndexOf("_")
            temp = temp.Substring(i + 1)
            query = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select CONVERT(varchar, DecryptByKey(fname)),(select CONVERT(varchar, DecryptByKey(levelname))  from leveldetails where levelid =e.plevel) as levelname,active from employeeinfo as e where CONVERT(varchar, DecryptByKey(userid)) ='" & temp & "'"

            Dim sqlcmd1 As SqlCommand = New SqlCommand(query, sql.scn2)
            Dim reader As SqlDataReader = sqlcmd1.ExecuteReader
            If reader.Read Then
                TextBox4.Text = reader.Item(0)
                ComboBox2.Text = reader.Item(1)
                If reader.Item(2) = 1 Then
                    Button2.Visible = True
                    Button1.Visible = False
                End If
                If reader.Item(2) = 2 Then
                    Button2.Visible = False
                    Button1.Visible = True
                End If
            End If
            sql.scn2.Close()
        End If
    End Sub

    Sub getdetails()

        '  If TextBox5.Text.Contains("_") Then

        Dim query As String



        If Login_Register.levelid = 1 Then

            query = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select levelid,CONVERT(varchar, DecryptByKey(levelname)) as levelname from leveldetails where levelid<>1"

        Else

            query = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select levelid,CONVERT(varchar, DecryptByKey(levelname)) as levelname from leveldetails where levelid<>1 and levelid<>" & Login_Register.levelid

        End If

        sql.scon2()

        Dim sqlcmd As SqlCommand = New SqlCommand(query, sql.scn2)

        sqlcmd.ExecuteNonQuery()

        Dim DA = New SqlDataAdapter

        DA.SelectCommand = sqlcmd

        Dim DataSet = New DataSet

        DA.Fill(DataSet)

        ComboBox2.DataSource = DataSet.Tables(0)

        ComboBox2.ValueMember = "levelid"

        ComboBox2.DisplayMember = "levelname"

        If Login_Register.levelid > 1 Then

            '    ComboBox2.Items.Remove("Manager")

        End If

        sqlcmd.Dispose()

        '  Dim temp = TextBox5.Text


        'Dim i = temp.IndexOf("_")


        'temp = temp.Substring(i + 1)

        query = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select CONVERT(varchar, DecryptByKey(fname)),(select CONVERT(varchar, DecryptByKey(levelname))  from leveldetails where levelid =e.plevel) as levelname,active from employeeinfo as e where CONVERT(varchar, DecryptByKey(userid)) ='" & tempuserid & "'"


        Dim sqlcmd1 As SqlCommand = New SqlCommand(query, sql.scn2)

        Dim reader As SqlDataReader = sqlcmd1.ExecuteReader

        If reader.Read Then

            TextBox4.Text = reader.Item(0)

            ComboBox2.Text = reader.Item(1)

            If reader.Item(2) = 1 Then

                Button2.Visible = True

                Button1.Visible = False

            End If

            If reader.Item(2) = 2 Then

                Button2.Visible = False

                Button1.Visible = True

            End If

        End If

        sql.scn2.Close()

        '  End If

    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.StartPosition = FormStartPosition.CenterParent
        Dim DataCollection As New AutoCompleteStringCollection()
        getProductData(DataCollection)
        TextBox5.AutoCompleteCustomSource = DataCollection
        TextBox5.AutoCompleteMode = AutoCompleteMode.Suggest
        TextBox5.AutoCompleteSource = AutoCompleteSource.CustomSource
        'Label26.Text = ""
        'TextBox4.Text = ""
        'ComboBox2.Items.Clear()
        Label22.Text = ""
        txtcpass.Text = ""
        txtcpass.Text = ""
        Label21.Text = "*Password- Alphanumeric and Special and minimum " & Login_Register.passlen & " characters"
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim temp = TextBox5.Text
        Dim i = temp.IndexOf("_")
        temp = temp.Substring(i + 1)
        Dim query = ""
        If CheckBox1.Checked = True Then
            If txtpass.Text = txtcpass.Text And txtpass.Text.Trim.Length >= Login_Register.passlen And (IsAlphaNum(txtpass.Text) = True) Then

                     If Login_Register.passprevoiuscheck = 0 Then

                    'query = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 update employeeinfo set fname=EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & TextBox4.Text & "') ),plevel='" & ComboBox2.SelectedValue & "',password='" & sqlclass.AES_Encrypt(txtpass.Text, "r1m2s3") & "' where CONVERT(varchar, DecryptByKey(userid)) ='" & tempuserid & "'"
                    query = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 update employeeinfo set fname=EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & TextBox4.Text & "') ),plevel='" & ComboBox2.SelectedValue & "',password=EncryptByKey( Key_GUID('SymmetricKey1'),CONVERT(varchar,'" & txtpass.Text & "')) where CONVERT(varchar, DecryptByKey(userid)) ='" & tempuserid & "'"

                Else
                    sql.scon3()
                    Dim q1 = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select empid from  employeeinfo where CONVERT(varchar, DecryptByKey(userid)) ='" & tempuserid & "'"
                    Dim cmd5 As SqlCommand = New SqlCommand(q1, sql.scn3)
                    Dim READER As SqlDataReader = cmd5.ExecuteReader()
                    Dim tempempid = 0
                    If READER.Read Then
                        tempempid = READER.Item(0)
                    End If
                    READER.Close()
                    sql.scn3.Close()
                    Dim reg As New register
                    Dim tempreg = reg.changepasswordcondition(tempempid, sqlclass.AES_Encrypt(txtpass.Text, "r1m2s3"))
                    If tempreg = True Then
                        query = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 update employeeinfo set fname=EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & TextBox4.Text & "') ),plevel='" & ComboBox2.SelectedValue & "' where CONVERT(varchar, DecryptByKey(userid)) ='" & tempuserid & "'"
                    Else
                        Exit Sub
                    End If
                End If
            Else
                Exit Sub
            End If
            Else
            query = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 update employeeinfo set fname=EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & TextBox4.Text & "') ),plevel='" & ComboBox2.SelectedValue & "' where CONVERT(varchar, DecryptByKey(userid)) ='" & tempuserid & "'"
            End If
        Try
            sql.scon1()
            Dim sqlcmd As SqlCommand = New SqlCommand(query, sql.scn1)
            sqlcmd.ExecuteNonQuery()

            Label26.Text = "Details Sucessfully Updated"
            MessageBox.Show("Details Sucessfully Updated", "Details")

            Dim ev As New eventlists

            ev.insertscadaevent(Login_Register.empid, "DETAILS UPDATED", "", "OF NAME: " & TextBox4.Text, "", "", "", "", "", "", "", "", "Audittrail")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        sql.scn1.Close()

    End Sub
    Private Sub txtcpass_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcpass.TextChanged
        If txtpass.Text = txtcpass.Text Then
            Label24.Text = ""
        Else
            Label24.Text = "Password and Confirm Password do not match"
        End If
    End Sub

    Private Sub txtpass_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtpass.TextChanged
        If txtpass.Text.Length < Login_Register.passlen Then
            Label21.ForeColor = Color.Red

        Else
            Dim reg As New register
            If reg.IsAlphaNum(txtpass.Text) = True Then
                Label21.ForeColor = Color.Silver
            End If
        End If

    End Sub
    Private Function IsAlphaNum(ByVal strInputText As String) As Boolean

        '  Return System.Text.RegularExpressions.Regex.IsMatch(strInputText, "(?!^[0-9]*$)(?!^[a-zA-Z]*$)^([a-zA-Z0-9]{" & Login_Register.passlen & ",50})$")
        Return System.Text.RegularExpressions.Regex.IsMatch(strInputText, "^.*(?=.*[a-zA-Z])(?=.*\d)(?=.*[\.@_-`~!@#$%^&*()_+={}\[\]\\|:;""'<>,.?/-]){" & Login_Register.passlen & ",50}.*$")
    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim query = ""
        ' If CheckBox1.Checked = True Then
        'If txtpass.Text = txtcpass.Text Then
        'active=1 means activated
        Dim temp = TextBox5.Text
        Dim i = temp.IndexOf("_")
        temp = temp.Substring(i + 1)
        query = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 update employeeinfo set active=1 where CONVERT(varchar, DecryptByKey(userid)) ='" & temp & "'"

        Try
            sql.scon1()
            Dim sqlcmd As SqlCommand = New SqlCommand(query, sql.scn1)
            sqlcmd.ExecuteNonQuery()

            Label26.Text = "User Activated Sucessfully "
            Dim ev As New eventlists

            ev.insertscadaevent(Login_Register.empid, "USER ACTIVATED", "", "OF NAME: " & TextBox4.Text, "", "", "", "", "", "", "", "", "Audittrail")
            Button1.Visible = False
            Button2.Visible = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        sql.scn1.Close()


    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim query = ""
        ' If CheckBox1.Checked = True Then
        'If txtpass.Text = txtcpass.Text Then
        'active=2 means deactivated
        Dim temp = TextBox5.Text
        Dim i = temp.IndexOf("_")
        temp = temp.Substring(i + 1)
        query = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 update employeeinfo set active=2 where CONVERT(varchar, DecryptByKey(userid)) ='" & temp & "'"

        Try
            sql.scon1()
            Dim sqlcmd As SqlCommand = New SqlCommand(query, sql.scn1)
            sqlcmd.ExecuteNonQuery()

            Label26.Text = "User DeActivated Sucessfully "
            Dim ev As New eventlists

            ev.insertscadaevent(Login_Register.empid, "USER DEACTIVATED", "", "OF NAME: " & TextBox4.Text, "", "", "", "", "", "", "", "", "Audittrail")
            Button1.Visible = True
            Button2.Visible = False
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        sql.scn1.Close()
    End Sub


    Private Sub TextBox5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox5.Click, TextBox5.GotFocus
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

    Private Sub txtpass_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtpass.Click, txtpass.GotFocus
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


    Private Sub TextBox4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox4.Click, TextBox4.GotFocus
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