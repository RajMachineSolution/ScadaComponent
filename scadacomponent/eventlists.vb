
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.IO
Imports System.Security.Cryptography

Public Class eventlists
    Dim sql As New sqlclass
    Dim connetionString As String = "Data Source=.\sqlexpress;DataBase=Pharma;user id=rmsview;password=rmsview"
    Dim cnn As SqlConnection
    Public Shared eventname(100) As String
    Public Shared var1(100), var2(100), var3(100), var4(100), var5(100), action(100) As String 'status is used to record   the action taken by like plc action,user action , alarm action etc
    Public Shared selectvar(100) As Boolean
    'Public Shared SQL As String
    Sub New()
        connetionString = "Data Source=.\sqlexpress;DataBase=phrencrydecry;user id=rmsview;password=rmsview"
    End Sub

    Public Sub insertevent(ByVal empid As Integer, ByVal datee As Date, ByVal timee As String, ByVal eventname As String, ByVal oldval As String, ByVal newval As String, ByVal batch As String, ByVal note As String)
        Try
            '  connetionString = "Data Source=.\sqlexpress;Network Library=DBMSSOCN;INITIAL CATALOG=Pharma;user id=mohit;password=Mohit"
            ' connetionString = "Data Source=.\sqlexpress;DataBase=Pharma;user id=mohit;password=Mohit"

            '     cnn = New SqlConnection(connetionString)
            'cnn1 = New SqlConnection(connetionString)
            '            cnn.Open()
            sql.scon1()
            Dim sqlquery = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 insert into eventlist (empid,date,time,eventname,oldvalue,newvalue,batch,note)values('" & empid & "','" & datee & "','" & timee & "','" & eventname & "','" & oldval & "','" & newval & "','" & batch & "','" & note & "')"
            Dim cmd = New SqlCommand(sqlquery, sqlclass.sqlcon)
            cmd.CommandTimeout = 60
            cmd.ExecuteNonQuery()
            sqlclass.sqlcon.Close()
            ' cnn1.Open()
            ' sqlcon.Close()
        Catch ex As Exception
            MsgBox(ex.Message)

            MsgBox("Can not open connection insertevent1! ")
        End Try

    End Sub
    Public Sub insertscadaevent(ByVal empid As Integer, ByVal eventname As String, ByVal var1 As String, ByVal var2 As String, ByVal var3 As String, ByVal var4 As String, ByVal var5 As String, ByVal var6 As String, ByVal var7 As String, ByVal var8 As String, ByVal var9 As String, ByVal var10 As String, ByVal action As String) ' this method is used in scada to record action of scada
        Try
            Dim t = variableclass.timee
            '  Dim d =Date.Now.toString("dd-MM-yyyy").ToString("")
            '  connetionString = "Data Source=.\sqlexpress;Network Library=DBMSSOCN;INITIAL CATALOG=Pharma;user id=mohit;password=Mohit"
            ' connetionString = "Data Source=.\sqlexpress;DataBase=Pharma;user id=mohit;password=Mohit"
            '  cnn = New SqlConnection(connetionString)
            'cnn1 = New SqlConnection(connetionString)
            ' cnn.Open()
            sql.scon1()
            If variableclass.datee <> "" Then
                Dim sqlquery = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 insert into eventlist (empid,date,time,eventname,var1,var2,var3,var4,var5,var6,var7,var8,var9,var10,action)values('" & empid & "',EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & variableclass.datee & "') ),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & variableclass.timee & "') ) ,EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar(max),'" & eventname & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar(max),'" & var1 & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar(max),'" & var2 & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar(max),'" & var3 & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar(max),'" & var4 & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar(max),'" & var5 & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar(max),'" & var6 & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar(max),'" & var7 & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar(max),'" & var8 & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar(max),'" & var9 & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar(max),'" & var10 & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar(max),'" & action & "')))"
                Dim cmd = New SqlCommand(sqlquery, sql.scn1)
                cmd.CommandTimeout = 60
                cmd.ExecuteNonQuery()
            End If
            ' cnn1.Open()
            sql.scn1.Close()
        Catch ex As Exception
            MsgBox(ex.Message)

            ' MsgBox("Can not open connection  insertscadaevent! ")
        End Try

    End Sub
    Public Sub insertalarmevent(ByVal empid As Integer, ByVal var1 As String, ByVal var2 As String, ByVal eventnameindex As Integer, ByVal alarmlistindex As Integer, ByVal alarmactionindex As Integer, ByVal actionindex As Integer) 'this method is used in scada to record Alarm action of scada
        Try
            Dim sqlquery As String = ""
            Dim t = variableclass.timee
            ' connetionString = "Data Source=.\sqlexpress;Network Library=DBMSSOCN;INITIAL CATALOG=Pharma;user id=mohit;password=Mohit"

            '   cnn = New SqlConnection(connetionString)
            'cnn1 = New SqlConnection(connetionString)
            '  cnn.Open()

            sql.scon1()
            If Login_Register.Alarm_Action.Count = 0 Then
                sqlquery = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 insert into eventlist (empid,date,time,eventname,var1,var2,var3,var4,action)values('" & empid & "',EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & variableclass.datee & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & t & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & "Alarm" & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & var1 & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & var2 & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & "Alarm" & "')),'" & "" & "',EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & Login_Register.actionname(actionindex) & "')))"

            Else
                sqlquery = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 insert into eventlist (empid,date,time,eventname,var1,var2,var3,var4,action)values('" & empid & "',EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & variableclass.datee & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & t & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & Login_Register.Event_Name(eventnameindex) & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & var1 & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & var2 & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & Login_Register.Alarm_Action(alarmactionindex) & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & Login_Register.Alarm_list(alarmactionindex) & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & Login_Register.actionname(actionindex) & "')))"

            End If
            Dim cmd = New SqlCommand(sqlquery, sql.scn1)
            cmd.CommandTimeout = 60
            cmd.ExecuteNonQuery()
            sql.scn1.Close()
        Catch ex As Exception
            MsgBox(ex.Message)

            MsgBox("Can not open connection insertalarmevent ! ")
        End Try

    End Sub
    Public Sub insertuserevent(ByVal empid As Integer, ByVal eventnameindex As Integer, ByVal var1 As String, ByVal var2 As String, ByVal var3 As String, ByVal var4 As String, ByVal var5 As String, ByVal var6 As String, ByVal var7 As String, ByVal var8 As String, ByVal var9 As String, ByVal var10 As String, ByVal actionnameindex As String) ' this method of the developer who use this scada to record the action of developers users ,in this method direct parameter is passed
        Try
            ' connetionString = "Data Source=.\sqlexpress;Network Library=DBMSSOCN;INITIAL CATALOG=Pharma;user id=mohit;password=Mohit"
            Dim t = variableclass.timee
            '  connetionString = "Data Source=.\sqlexpress;Network Library=DBMSSOCN;INITIAL CATALOG=Pharma;user id=mohit;password=Mohit"
            '  connetionString = "Data Source=.\sqlexpress;DataBase=Pharma;user id=mohit;password=Mohit"
            '  cnn = New SqlConnection(connetionString)
            'cnn1 = New SqlConnection(connetionString)
            ' cnn.Open()
            sql.scon1()
            'Dim sqlquery = "insert into eventlist (empid,date,time,eventname,var1,var2,var3,var4,var5,var6,var7,var8,var9,var10,action)values('" & empid & "','" & Date.Now.toString("dd-MM-yyyy") & "','" & t & "','" & Login_Register.Event_Name(eventnameindex) & "','" & var1 & "','" & var2 & "','" & var3 & "','" & var4 & "','" & var5 & "','" & var6 & "','" & var7 & "','" & var8 & "','" & var9 & "','" & var10 & "','" & Login_Register.actionname(actionnameindex) & "')"

            Dim sqlquery = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 insert into eventlist (empid,date,time,eventname,var1,var2,var3,var4,var5,var6,var7,var8,var9,var10,action)values('" & empid & "',EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & variableclass.datee & "') ) ,EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & t & "') ) ,EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & Login_Register.Event_Name(eventnameindex) & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & var1 & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & var2 & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & var3 & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & var4 & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & var5 & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & var6 & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & var7 & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & var8 & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & var9 & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & var10 & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & Login_Register.actionname(actionnameindex) & "')))"




            Dim cmd = New SqlCommand(sqlquery, sql.scn1)
            cmd.CommandTimeout = 60
            cmd.ExecuteNonQuery()
            sql.scn1.Close()
        Catch ex As Exception
            MsgBox(ex.Message)

            MsgBox("Can not open connection  insertuserevent! ")
        End Try

    End Sub
    Public Function displayevent(ByVal filtername As String) As DataSet ' this method return the dataset for the parameter passed in it od eventlist
        Dim ds = New DataSet
        Try
            ' connetionString = "Data Source=.\sqlexpress;Network Library=DBMSSOCN;INITIAL CATALOG=Pharma;user id=mohit;password=Mohit"
            ' connetionString = "Data Source=.\sqlexpress;DataBase=Pharma;user id=mohit;password=Mohit"

            ' cnn = New SqlConnection(connetionString)
            'cnn1 = New SqlConnection(connetionString)
            'cnn.Open()
            sql.scon1()
            Dim sqlquery As String = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select empid,(select CONVERT(varchar, DecryptByKey(fname)) from employeeinfo where empid=e.empid) as name,CONVERT(varchar(8), DecryptByKey(date)),CONVERT(varchar, DecryptByKey(time)),CONVERT(varchar, DecryptByKey(eventname))"

            Dim i = 0
            For i = 0 To selectvar.Length - 1

                If selectvar(i) = True Then
                    sqlquery = sqlquery & ",CONVERT(varchar, DecryptByKey(var" & i + 1 & "))"
                End If
            Next
            If filtername = "" Then
                sqlquery = sqlquery + " from eventlist as e"
            Else
                sqlquery = sqlquery + " from eventlist as e where CONVERT(varchar, DecryptByKey(action)) like '" & filtername & "'"
            End If



            Dim cmd = New SqlCommand(sqlquery, sql.scn1)
            cmd.CommandTimeout = 60

            Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)

            da.Fill(ds)
            Return ds
            sql.scn1.Close()
            ' cnn1.Open()
        Catch ex As Exception
            MsgBox(ex.Message)

            MsgBox("Can not open connection  displayevent! ")
        End Try
        Return ds
    End Function
    Public Function displayeventfilter(ByVal filtername As String, ByVal date1 As Date, ByVal date2 As Date, ByVal batchno As String) As DataSet ' this method return the dataset for the parameter passed in it od eventlist
        Dim datee1 As DateTime = date1.Date
        Dim ds = New DataSet

        Dim datee2 As DateTime = date2.Date

        If (DateTime.Compare(date1, date2) > 0) Then
            ' which means ("date1 > date2")
            MsgBox("select the proper dates")

            Return ds
            Exit Function
        End If


        Try
            ' connetionString = "Data Source=.\sqlexpress;Network Library=DBMSSOCN;INITIAL CATALOG=Pharma;user id=mohit;password=Mohit"
            ' connetionString = "Data Source=.\sqlexpress;DataBase=Pharma;user id=mohit;password=Mohit"

            '   cnn = New SqlConnection(connetionString)
            'cnn1 = New SqlConnection(connetionString)
            '  cnn.Open()
            sql.scon1()
            Dim sqlquery As String = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select (select CONVERT(varchar, DecryptByKey(fname)) from employeeinfo where empid=e.empid) as name,Convert(varchar(10),CONVERT(date,CONVERT(varchar(8), DecryptByKey(date)),106),103),CONVERT(varchar, DecryptByKey(time)),CONVERT(varchar, DecryptByKey(eventname))"

            Dim i = 0
            For i = 0 To selectvar.Length - 1

                If selectvar(i) = True Then
                    sqlquery = sqlquery & ",CONVERT(varchar, DecryptByKey(var" & i + 1 & "))"
                End If
            Next
            If filtername = "" Then
                If batchno = "" Then
                    sqlquery = sqlquery + " from eventlist as e"

                Else
                    sqlquery = sqlquery + " from eventlist as e where CONVERT(varchar, DecryptByKey(var5))='" & batchno & "' """

                End If
            Else
                If batchno = "" Then
                    sqlquery = sqlquery + " from eventlist as e where action like '" & filtername & "' and date>='" & date1 & "' and date <='" & date2 & "' "

                Else
                    sqlquery = sqlquery + " from eventlist as e where action like '" & filtername & "' and( date>='" & date1 & "' and date <='" & date2 & "' ) and var5='" & batchno & "' " 'var5 is used for batch no.

                End If
            End If



            Dim cmd = New SqlCommand(sqlquery, sql.scn1)
            cmd.CommandTimeout = 60

            Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)

            da.Fill(ds)
            Return ds
            sql.scn1.Close()
            ' cnn1.Open()
        Catch ex As Exception
            MsgBox(ex.Message)

            MsgBox("Can not open connection displayeventfilter! ")
        End Try
        Return ds
    End Function


    Public Sub eventcall(ByVal index As Integer, ByVal flag As Boolean, ByVal action As String) ' this method is used when developer used scada variable  to record the actiona and pass only index of the variable respective of the usessss
        If flag = True Then
            Dim t = variableclass.timee
            insertuserevent(2, eventname(index), var1(index), var2(index), var3(index), var4(index), var5(index), "", "", "", "", "", action)
        End If
    End Sub
    Public Function FindControlRecursive(ByVal list As List(Of Control), ByVal parent As Control, ByVal ctrlType As System.Type) As List(Of Control)
        If parent Is Nothing Then Return list
        If parent.GetType Is ctrlType Then
            list.Add(parent)
        End If
        For Each child As Control In parent.Controls
            FindControlRecursive(list, child, ctrlType)
        Next
        Return list
    End Function
    Public Function displayeventfilterbatch(ByVal filtername As String, ByVal batchno As String) As DataSet ' this method return the dataset for the parameter passed in it od eventlist
        '   Dim datee1 As DateTime = date1.Date
        Dim ds = New DataSet




        Try
            ' connetionString = "Data Source=.\sqlexpress;Network Library=DBMSSOCN;INITIAL CATALOG=Pharma;user id=mohit;password=Mohit"
            ' connetionString = "Data Source=.\sqlexpress;DataBase=Pharma;user id=mohit;password=Mohit"

            '   cnn = New SqlConnection(connetionString)
            'cnn1 = New SqlConnection(connetionString)
            '  cnn.Open()
            sql.scon2()
            Dim sqlquery As String = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select (select CONVERT(varchar, DecryptByKey(fname)) from employeeinfo where empid=e.empid) as name,CONVERT(varchar(10), DecryptByKey(date)),CONVERT(varchar, DecryptByKey(time)),CONVERT(varchar, DecryptByKey(eventname))"

            Dim i = 0
            For i = 0 To selectvar.Length - 1

                If selectvar(i) = True Then
                    sqlquery = sqlquery & ",CONVERT(varchar, DecryptByKey(var" & i + 1 & "))"
                End If
            Next
            If filtername = "" Then
                If batchno = "" Then
                    sqlquery = sqlquery + " from eventlist as e order by CONVERT(varchar, DecryptByKey(date)) desc,CONVERT(varchar, DecryptByKey(time)) desc"

                Else
                    sqlquery = sqlquery + " from eventlist as e where CONVERT(varchar, DecryptByKey(var10))='" & batchno & "' order by CONVERT(varchar, DecryptByKey(date)) desc,CONVERT(varchar, DecryptByKey(time)) desc  "

                End If
            Else
                If batchno = "" Then
                    sqlquery = sqlquery + " from eventlist as e where CONVERT(varchar, DecryptByKey(action)) like '" & filtername & "' order by CONVERT(varchar, DecryptByKey(date)) desc,CONVERT(varchar, DecryptByKey(time)) desc"

                Else
                    sqlquery = sqlquery + " from eventlist as e where CONVERT(varchar, DecryptByKey(action)) like '" & filtername & "' and CONVERT(varchar, DecryptByKey(var10))='" & batchno & "' order by CONVERT(varchar, DecryptByKey(date)) desc,CONVERT(varchar, DecryptByKey(time)) desc " 'var5 is used for batch no.

                End If
            End If



            Dim cmd = New SqlCommand(sqlquery, sql.scn2)
            cmd.CommandTimeout = 60

            Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)

            da.Fill(ds)
            Return ds
            sql.scn2.Close()
            ' cnn1.Open()
        Catch ex As Exception
            MsgBox(ex.Message)

            MsgBox("Can not open connection ! ")
        End Try
        Return ds
    End Function
    Dim fsInput As System.IO.FileStream
    Dim fsOutput As System.IO.FileStream

    Dim strFileToEncrypt As String
    Dim strFileToDecrypt As String
    Dim strOutputEncrypt As String
    Dim strOutputDecrypt As String
    '*************************
    '** Create A Key
    '*************************

    Private Function CreateKey(ByVal strPassword As String) As Byte()
        'Convert strPassword to an array and store in chrData.
        Dim chrData() As Char = strPassword.ToCharArray
        'Use intLength to get strPassword size.
        Dim intLength As Integer = chrData.GetUpperBound(0)
        'Declare bytDataToHash and make it the same size as chrData.
        Dim bytDataToHash(intLength) As Byte

        'Use For Next to convert and store chrData into bytDataToHash.
        For i As Integer = 0 To chrData.GetUpperBound(0)
            bytDataToHash(i) = CByte(Asc(chrData(i)))
        Next

        'Declare what hash to use.
        Dim SHA512 As New System.Security.Cryptography.SHA512Managed
        'Declare bytResult, Hash bytDataToHash and store it in bytResult.
        Dim bytResult As Byte() = SHA512.ComputeHash(bytDataToHash)
        'Declare bytKey(31).  It will hold 256 bits.
        Dim bytKey(31) As Byte

        'Use For Next to put a specific size (256 bits) of 
        'bytResult into bytKey. The 0 To 31 will put the first 256 bits
        'of 512 bits into bytKey.
        For i As Integer = 0 To 31
            bytKey(i) = bytResult(i)
        Next

        Return bytKey 'Return the key.
    End Function

    '*************************
    '** Create An IV
    '*************************

    Private Function CreateIV(ByVal strPassword As String) As Byte()
        'Convert strPassword to an array and store in chrData.
        Dim chrData() As Char = strPassword.ToCharArray
        'Use intLength to get strPassword size.
        Dim intLength As Integer = chrData.GetUpperBound(0)
        'Declare bytDataToHash and make it the same size as chrData.
        Dim bytDataToHash(intLength) As Byte

        'Use For Next to convert and store chrData into bytDataToHash.
        For i As Integer = 0 To chrData.GetUpperBound(0)
            bytDataToHash(i) = CByte(Asc(chrData(i)))
        Next

        'Declare what hash to use.
        Dim SHA512 As New System.Security.Cryptography.SHA512Managed
        'Declare bytResult, Hash bytDataToHash and store it in bytResult.
        Dim bytResult As Byte() = SHA512.ComputeHash(bytDataToHash)
        'Declare bytIV(15).  It will hold 128 bits.
        Dim bytIV(15) As Byte

        'Use For Next to put a specific size (128 bits) of bytResult into bytIV.
        'The 0 To 30 for bytKey used the first 256 bits of the hashed password.
        'The 32 To 47 will put the next 128 bits into bytIV.
        For i As Integer = 32 To 47
            bytIV(i - 32) = bytResult(i)
        Next

        Return bytIV 'Return the IV.
    End Function

    '****************************
    '** Encrypt/Decrypt File
    '****************************

    Private Enum CryptoAction
        'Define the enumeration for CryptoAction.
        ActionEncrypt = 1
        ActionDecrypt = 2
    End Enum

    Private Sub EncryptOrDecryptFile(ByVal strInputFile As String,
                                         ByVal strOutputFile As String,
                                         ByVal bytKey() As Byte,
                                         ByVal bytIV() As Byte,
                                         ByVal Direction As CryptoAction)
        Try 'In case of errors.

            'Setup file streams to handle input and output.
            fsInput = New System.IO.FileStream(strInputFile, FileMode.Open,
                                               FileAccess.Read)
            fsOutput = New System.IO.FileStream(strOutputFile, FileMode.OpenOrCreate,
                                                FileAccess.Write)
            fsOutput.SetLength(0) 'make sure fsOutput is empty

            'Declare variables for encrypt/decrypt process.
            Dim bytBuffer(4096) As Byte 'holds a block of bytes for processing
            Dim lngBytesProcessed As Long = 0 'running count of bytes processed
            Dim lngFileLength As Long = fsInput.Length 'the input file's length
            Dim intBytesInCurrentBlock As Integer 'current bytes being processed
            Dim csCryptoStream As CryptoStream
            'Declare your CryptoServiceProvider.
            Dim cspRijndael As New System.Security.Cryptography.RijndaelManaged
            'Setup Progress Bar
            'pbStatus.Value = 0
            'pbStatus.Maximum = 100

            'Determine if ecryption or decryption and setup CryptoStream.
            Select Case Direction
                Case CryptoAction.ActionEncrypt
                    csCryptoStream = New CryptoStream(fsOutput,
                    cspRijndael.CreateEncryptor(bytKey, bytIV),
                    CryptoStreamMode.Write)

                Case CryptoAction.ActionDecrypt
                    csCryptoStream = New CryptoStream(fsOutput,
                    cspRijndael.CreateDecryptor(bytKey, bytIV),
                    CryptoStreamMode.Write)
            End Select

            'Use While to loop until all of the file is processed.
            While lngBytesProcessed < lngFileLength
                'Read file with the input filestream.
                intBytesInCurrentBlock = fsInput.Read(bytBuffer, 0, 4096)
                'Write output file with the cryptostream.
                csCryptoStream.Write(bytBuffer, 0, intBytesInCurrentBlock)
                'Update lngBytesProcessed
                lngBytesProcessed = lngBytesProcessed + CLng(intBytesInCurrentBlock)
                'Update Progress Bar
                '   pbStatus.Value = CInt((lngBytesProcessed / lngFileLength) * 100)
            End While

            'Close FileStreams and CryptoStream.
            csCryptoStream.Close()
            fsInput.Close()
            fsOutput.Close()

            'If encrypting then delete the original unencrypted file.
            If Direction = CryptoAction.ActionEncrypt Then
                Dim fileOriginal As New FileInfo(strFileToEncrypt)
                fileOriginal.Delete()
            End If

            'If decrypting then delete the encrypted file.
            If Direction = CryptoAction.ActionDecrypt Then
                Dim fileEncrypted As New FileInfo(strFileToDecrypt)
                fileEncrypted.Delete()
            End If

            'Update the user when the file is done.
            Dim Wrap As String = Chr(13) + Chr(10)
            If Direction = CryptoAction.ActionEncrypt Then
                '     MsgBox("Encryption Complete" + Wrap + Wrap +
                '            "Total bytes processed = " +
                '           lngBytesProcessed.ToString,
                '          MsgBoxStyle.Information, "Done")

                'Update the progress bar and textboxes.
                '    pbStatus.Value = 0
                '   txtFileToEncrypt.Text = "Click Browse to load file."
                '  txtPassEncrypt.Text = ""
                ' txtConPassEncrypt.Text = ""
                ' txtDestinationEncrypt.Text = ""
                ' btnChangeEncrypt.Enabled = False
                ' btnEncrypt.Enabled = False

            Else
                'Update the user when the file is done.
                ' MsgBox("Decryption Complete" + Wrap + Wrap +
                '       "Total bytes processed = " +
                '       lngBytesProcessed.ToString,
                '      MsgBoxStyle.Information, "Done")

                'Update the progress bar and textboxes.
                '   pbStatus.Value = 0
                '   txtFileToDecrypt.Text = "Click Browse to load file."
                '  txtPassDecrypt.Text = ""
                '  txtConPassDecrypt.Text = ""
                '  txtDestinationDecrypt.Text = ""
                ' btnChangeDecrypt.Enabled = False
                ' btnDecrypt.Enabled = False
            End If


            'Catch file not found error.
        Catch When Err.Number = 53 'if file not found
            MsgBox("Please check to make sure the path and filename" +
                    "are correct and if the file exists.",
                     MsgBoxStyle.Exclamation, "Invalid Path or Filename")

            'Catch all other errors. And delete partial files.
        Catch
            fsInput.Close()
            fsOutput.Close()

            If Direction = CryptoAction.ActionDecrypt Then
                Dim fileDelete As New FileInfo("D:/D&V Pharma/abc.txt")
                fileDelete.Delete()
                '.Value = 0
                '     txtPassDecrypt.Text = ""
                '    txtConPassDecrypt.Text = ""

                MsgBox("Please check to make sure that you entered the correct" +
                        "password.", MsgBoxStyle.Exclamation, "Invalid Password")
            Else
                Dim fileDelete As New FileInfo("D:/D&V Pharma/abc.txt")
                fileDelete.Delete()

                '    pbStatus.Value = 0
                'txtPassEncrypt.Text = ""
                'txtConPassEncrypt.Text = ""

                MsgBox("This file cannot be encrypted.",
                        MsgBoxStyle.Exclamation, "Invalid File")

            End If

        End Try
    End Sub




#Region "5. Browse / Change Button "

    '******************************
    '** Browse/Change Buttons
    '******************************

    'Private Sub btnBrowseEncrypt_Click(ByVal sender As System.Object,
    '                                   ByVal e As System.EventArgs) _
    '                                   Handles btnBrowseEncrypt.Click
    '    'Setup the open dialog.
    '    OpenFileDialog.FileName = ""
    '    OpenFileDialog.Title = "Choose a file to encrypt"
    '    OpenFileDialog.InitialDirectory = "C:\"
    '    OpenFileDialog.Filter = "All Files (*.*) | *.*"

    '    'Find out if the user chose a file.
    '    If OpenFileDialog.ShowDialog = DialogResult.OK Then
    '        strFileToEncrypt = OpenFileDialog.FileName
    '        txtFileToEncrypt.Text = strFileToEncrypt

    '        Dim iPosition As Integer = 0
    '        Dim i As Integer = 0

    '        'Get the position of the last "\" in the OpenFileDialog.FileName path.
    '        '-1 is when the character your searching for is not there.
    '        'IndexOf searches from left to right.
    '        While strFileToEncrypt.IndexOf("\"c, i) <> -1
    '            iPosition = strFileToEncrypt.IndexOf("\"c, i)
    '            i = iPosition + 1
    '        End While

    '        'Assign strOutputFile to the position after the last "\" in the path.
    '        'This position is the beginning of the file name.
    '        strOutputEncrypt = strFileToEncrypt.Substring(iPosition + 1)
    '        'Assign S the entire path, ending at the last "\".
    '        Dim S As String = strFileToEncrypt.Substring(0, iPosition + 1)
    '        'Replace the "." in the file extension with "_".
    '        strOutputEncrypt = strOutputEncrypt.Replace("."c, "_"c)
    '        'The final file name.  XXXXX.encrypt
    '        txtDestinationEncrypt.Text = S + strOutputEncrypt + ".encrypt"
    '        'Update buttons.
    '        btnEncrypt.Enabled = True
    '        btnChangeEncrypt.Enabled = True

    '    End If

    'End Sub

    'Private Sub btnBrowseDecrypt_Click(ByVal sender As System.Object,
    '                                   ByVal e As System.EventArgs) _
    '                                   Handles btnBrowseDecrypt.Click
    '    'Setup the open dialog.
    '    OpenFileDialog.FileName = ""
    '    OpenFileDialog.Title = "Choose a file to decrypt"
    '    OpenFileDialog.InitialDirectory = "C:\"
    '    OpenFileDialog.Filter = "Encrypted Files (*.encrypt) | *.encrypt"

    '    'Find out if the user chose a file.
    '    If OpenFileDialog.ShowDialog = DialogResult.OK Then
    '        strFileToDecrypt = OpenFileDialog.FileName
    '        txtFileToDecrypt.Text = strFileToDecrypt
    '        Dim iPosition As Integer = 0
    '        Dim i As Integer = 0
    '        'Get the position of the last "\" in the OpenFileDialog.FileName path.
    '        '-1 is when the character your searching for is not there.
    '        'IndexOf searches from left to right.

    '        While strFileToDecrypt.IndexOf("\"c, i) <> -1
    '            iPosition = strFileToDecrypt.IndexOf("\"c, i)
    '            i = iPosition + 1
    '        End While

    '        'strOutputFile = the file path minus the last 8 characters (.encrypt)
    '        strOutputDecrypt = strFileToDecrypt.Substring(0, strFileToDecrypt.Length - 8)
    '        'Assign S the entire path, ending at the last "\".
    '        Dim S As String = strFileToDecrypt.Substring(0, iPosition + 1)
    '        'Assign strOutputFile to the position after the last "\" in the path.
    '        strOutputDecrypt = strOutputDecrypt.Substring((iPosition + 1))
    '        'Replace "_" with "."
    '        txtDestinationDecrypt.Text = S + strOutputDecrypt.Replace("_"c, "."c)
    '        'Update buttons
    '        btnDecrypt.Enabled = True
    '        btnChangeDecrypt.Enabled = True

    '    End If
    'End Sub

    'Private Sub btnChangeEncrypt_Click(ByVal sender As System.Object,
    '                                   ByVal e As System.EventArgs) _
    '                                   Handles btnChangeEncrypt.Click
    '    'Setup up folder browser.
    '    FolderBrowserDialog.Description = "Select a folder to place the encrypted file in."
    '    'If the user selected a folder assign the path to txtDestinationEncrypt.
    '    If FolderBrowserDialog.ShowDialog = DialogResult.OK Then
    '        txtDestinationEncrypt.Text = FolderBrowserDialog.SelectedPath +
    '                                     "\" + strOutputEncrypt + ".encrypt"
    '    End If
    'End Sub

    'Private Sub btnChangeDecrypt_Click(ByVal sender As System.Object,
    '                                   ByVal e As System.EventArgs) _
    '                                   Handles btnChangeDecrypt.Click
    '    'Setup up folder browser.
    '    FolderBrowserDialog.Description = "Select a folder for to place the decrypted file in."
    '    'If the user selected a folder assign the path to txtDestinationDecrypt.
    '    If FolderBrowserDialog.ShowDialog = DialogResult.OK Then
    '        txtDestinationDecrypt.Text = FolderBrowserDialog.SelectedPath +
    '                                     "\" + strOutputDecrypt.Replace("_"c, "."c)
    '    End If
    'End Sub

#End Region




    '******************************
    '** Encrypt/Decrypt Buttons
    '******************************

    Public Sub EncryptFile(ByVal filepath As String)

        'Make sure the password is correct.
        '    If txtConPassEncrypt.Text = "hello" Then
        'Declare variables for the key and iv.
        'The key needs to hold 256 bits and the iv 128 bits.
        Dim bytKey As Byte()
        Dim bytIV As Byte()
        'Send the password to the CreateKey function.
        bytKey = CreateKey("encryptedfile")
        'Send the password to the CreateIV function.
        bytIV = CreateIV("encryptedfile")
        'Start the encryption.
        strFileToEncrypt = filepath
        Dim encryptedfile = filepath.Substring(0, (filepath.ToString.Length - 4)) & "_enc.encrypt"

        EncryptOrDecryptFile(strFileToEncrypt, encryptedfile,
                             bytKey, bytIV, CryptoAction.ActionEncrypt)
        'Else
        'MsgBox("Please re-enter your password.", MsgBoxStyle.Exclamation)
        ' txtPassEncrypt.Text = ""
        ' txtConPassEncrypt.Text = ""
        'End If
    End Sub

    Public Sub DecryptFile(ByVal filepath As String)

        'Make sure the password is correct.
        'If txtConPassDecrypt.Text = txtPassDecrypt.Text Then
        'Declare variables for the key and iv.
        'The key needs to hold 256 bits and the iv 128 bits.
        Dim bytKey As Byte()
        Dim bytIV As Byte()
        'Send the password to the CreateKey function.
        bytKey = CreateKey("encryptedfile")
        'Send the password to the CreateIV function.
        bytIV = CreateIV("encryptedfile")
        'Start the decryption.

        strFileToDecrypt = filepath
        Dim decryptedfile = filepath.Substring(0, (filepath.ToString.Length - 12)) & ".txt"
        EncryptOrDecryptFile(strFileToDecrypt, decryptedfile,
                             bytKey, bytIV, CryptoAction.ActionDecrypt)
        'Else
        'MsgBox("Please re-enter your password.", MsgBoxStyle.Exclamation)
        'txtPassDecrypt.Text = ""
        'txtConPassDecrypt.Text = ""
        'End If
    End Sub
    Public Sub insertalarmAppeared(ByVal empid As Integer, ByVal alarmlistindex As Integer, ByVal status As Integer, ByVal batchnumber As String) 'this method is used in scada to record Alarm action of scada
        'alarmlistindex returns index of list of alarms entered in properrty of login_register
        'alarmname from alarmlistindex needs to be passed in eventname

        'Status states the alarmaction
        'status=1 - Alarm Appeared
        'Status=2 - Alarm Acknowledged
        'Status=3 - Alarm Resolved
        '    Dim c As New sqlclass
        Try
            sql.scon1()
            Dim s = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select top 1 CONVERT(varchar, DecryptByKey(var5)) as status from EventList where CONVERT(varchar, DecryptByKey(eventname))='" & Login_Register.Alarm_list(alarmlistindex) & "' order by CONVERT(varchar, DecryptByKey(date)) desc,CONVERT(varchar, DecryptByKey(time)) desc "
            Dim sqlcmd1 As SqlCommand = New SqlCommand(s, sql.scn1)
            Dim reader As SqlDataReader = sqlcmd1.ExecuteReader
            If reader.Read Then

                If reader.Item(0) = 3 Then


                    Dim sqlquery As String = ""
                    Dim t = variableclass.timee
                    ' connetionString = "Data Source=.\sqlexpress;Network Library=DBMSSOCN;INITIAL CATALOG=Pharma;user id=mohit;password=Mohit"

                    'cnn = New SqlConnection(connetionString)
                    'cnn1 = New SqlConnection(connetionString)
                    'cnn.Open()
                    sql.scon2()
                    If Login_Register.Alarm_list.Count = 0 Then
                        sqlquery = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 insert into eventlist (empid,date,time,eventname,var5,var10,action)values('" & empid & "',EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & variableclass.datee & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & t & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'Alarm')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & status & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & batchnumber & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'Alarm')))"
                    Else
                        sqlquery = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 insert into eventlist (empid,date,time,eventname,var5,var10,action)values('" & empid & "',EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & variableclass.datee & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & t & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & Login_Register.Alarm_list(alarmlistindex) & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & status & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & batchnumber & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'Alarm')))"
                    End If
                    Dim cmd = New SqlCommand(sqlquery, sql.scn2)
                    cmd.CommandTimeout = 60
                    cmd.ExecuteNonQuery()
                    sql.scn2.Close()
                End If
            Else
                Dim sqlquery As String = ""
                Dim t = variableclass.timee
                ' connetionString = "Data Source=.\sqlexpress;Network Library=DBMSSOCN;INITIAL CATALOG=Pharma;user id=mohit;password=Mohit"

                'cnn = New SqlConnection(connetionString)
                'cnn1 = New SqlConnection(connetionString)
                'cnn.Open()
                sql.scon2()
                If Login_Register.Alarm_list.Count = 0 Then
                    sqlquery = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 insert into eventlist (empid,date,time,eventname,var5,var10,action)values('" & empid & "',EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & variableclass.datee & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & t & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'Alarm')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & status & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & batchnumber & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'Alarm')))"
                Else
                    sqlquery = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 insert into eventlist (empid,date,time,eventname,var5,var10,action)values('" & empid & "',EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & variableclass.datee & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & t & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & Login_Register.Alarm_list(alarmlistindex) & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & status & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & batchnumber & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'Alarm')))"
                End If
                Dim cmd = New SqlCommand(sqlquery, sql.scn2)
                cmd.CommandTimeout = 60
                cmd.ExecuteNonQuery()
                sql.scn2.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)

            MsgBox("Can not open connection insertalarmevent ! ")
        End Try
        sql.scn1.Close()
    End Sub
    Public Sub insertalarmAppeared1(ByVal empid As Integer, ByVal alarmlistindex As Integer, ByVal status As Integer, ByVal batchnumber As String) 'this method is used in scada to record Alarm action of scada
        'alarmlistindex returns index of list of alarms entered in properrty of login_register
        'alarmname from alarmlistindex needs to be passed in eventname

        'Status states the alarmaction
        'status=1 - Alarm Appeared
        'Status=2 - Alarm Acknowledged
        'Status=3 - Alarm Resolved
        ' Dim c As New sqlclass
        Try

            sql.scon1()

            Dim s = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select top 1 CONVERT(varchar, DecryptByKey(var5)) as status from EventList where CONVERT(varchar, DecryptByKey(eventname))='" & AlarmControl.alist(alarmlistindex) & "' order by CONVERT(varchar, DecryptByKey(date)) desc,CONVERT(varchar, DecryptByKey(time)) desc "
            Dim sqlcmd1 As SqlCommand = New SqlCommand(s, sql.scn1)
            Dim reader As SqlDataReader = sqlcmd1.ExecuteReader
            If reader.Read Then

                If reader.Item(0) = 3 Then


                    Dim sqlquery As String = ""
                    Dim t = variableclass.timee
                    ' connetionString = "Data Source=.\sqlexpress;Network Library=DBMSSOCN;INITIAL CATALOG=Pharma;user id=mohit;password=Mohit"

                    ' cnn = New SqlConnection(connetionString)
                    'cnn1 = New SqlConnection(connetionString)
                    'cnn.Open()
                    sql.scon2()
                    If AlarmControl.alist.Count = 0 Then
                        sqlquery = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 insert into eventlist (empid,date,time,eventname,var5,var10,action)values('" & empid & "',EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & variableclass.datee & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & t & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'Alarm')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & status & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & batchnumber & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'Alarm')))"
                    Else
                        sqlquery = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 insert into eventlist (empid,date,time,eventname,var5,var10,action)values('" & empid & "',EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & variableclass.datee & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & t & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & AlarmControl.alist(alarmlistindex) & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & status & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & batchnumber & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'Alarm')))"
                    End If
                    Dim cmd = New SqlCommand(sqlquery, sql.scn2)
                    cmd.CommandTimeout = 60
                    cmd.ExecuteNonQuery()
                    sql.scn2.Close()
                End If
            Else
                Dim sqlquery As String = ""
                Dim t = variableclass.timee
                ' connetionString = "Data Source=.\sqlexpress;Network Library=DBMSSOCN;INITIAL CATALOG=Pharma;user id=mohit;password=Mohit"

                'cnn = New SqlConnection(connetionString)
                'cnn1 = New SqlConnection(connetionString)
                'cnn.Open()
                sql.scon2()
                If AlarmControl.alist.Count = 0 Then
                    sqlquery = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 insert into eventlist (empid,date,time,eventname,var5,var10,action)values('" & empid & "',EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & variableclass.datee & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & t & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'Alarm')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & status & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & batchnumber & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'Alarm')))"
                Else
                    sqlquery = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 insert into eventlist (empid,date,time,eventname,var5,var10,action)values('" & empid & "',EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & variableclass.datee & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & t & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & AlarmControl.alist(alarmlistindex) & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & status & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & batchnumber & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'Alarm')))"
                End If
                Dim cmd = New SqlCommand(sqlquery, sql.scn2)
                cmd.CommandTimeout = 60
                cmd.ExecuteNonQuery()
                sql.scn2.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)

            MsgBox("Can not open connection insertalarmevent ! ")
        End Try
        sql.scn1.Close()
    End Sub
  
End Class

