Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.ComponentModel.Design
Imports System.Windows.Forms

Public Class reportdata
    Public Enum DateTime_Record
        FromPlc
        FromSystem
    End Enum
    Public Enum Address_type
        BIT_16
        BIT_32
    End Enum
    Dim Address_Typevalue As Address_type
    Property ReportAddressType As Address_type 'report data is genrated on 16 bit address or 32 bit address
        Get
            Return Address_Typevalue
        End Get
        Set(ByVal value As Address_type)
            Address_Typevalue = value
            '  Write = write1
        End Set
    End Property
    Dim DateTime_Recordvalue As DateTime_Record
    Property DateTimeRecord As DateTime_Record
        Get
            Return DateTime_Recordvalue
        End Get
        Set(ByVal value As DateTime_Record)
            DateTime_Recordvalue = value
            '  Write = write1
        End Set
    End Property
    Dim highestindex As Integer = 0 'maximum number of rows
    Dim sql As New sqlclass
    <Category("_report essentials")>
    Property MaxNumberOfRow As Integer
        Get
            Return highestindex
        End Get
        Set(value As Integer)
            highestindex = value
        End Set
    End Property
    Dim no_of_component As Integer = 6 ' number of varia of report like 1000,1001,1002,1003,1004,1005,1006
    <Category("_report essentials")>
    Property NumberOfReportVariable As Integer
        Get
            Return no_of_component
        End Get
        Set(value As Integer)
            no_of_component = value
        End Set
    End Property
    Dim reporttrigger As Integer 'is 1 take report
    Dim reporttag As String 'tag when value of tag is 1 tak report
    <Browsable(True), Category("_report essentials")>
    Property ReportTriggerTag As String
        Get
            Return reporttag
        End Get
        Set(value As String)
            reporttag = value
        End Set
    End Property
    Dim logreport = 902 ' report lene ke baad 902 ko 1 kr do

    Dim startingaddress = 1000 'starting address for report
    <Browsable(False), Category("_report essentials")>
    Property ReportStartAddress As Integer
        Get
            Return startingaddress
        End Get
        Set(value As Integer)
            startingaddress = value
        End Set
    End Property
    Dim endaddress = 1017 ' end address
    <Browsable(False), Category("_report essentials")>
    Property ReportEndAddress As Integer
        Get
            Return endaddress
        End Get
        Set(value As Integer)
            endaddress = value
        End Set
    End Property
    Dim starttag As String 'starting tag for report
    <Browsable(True), Category("_report essentials")>
    Property ReportStartTag As String
        Get
            Return starttag
        End Get
        Set(value As String)
            starttag = value
        End Set
    End Property
    Dim endtag As String = "" ' end tag
    <Browsable(True), Category("_report essentials")>
    Property ReportEndTag As String
        Get
            Return endtag
        End Get
        Set(value As String)
            endtag = value
        End Set
    End Property



    Dim TextonIndex As New List(Of report)

    <Browsable(True), _
EditorBrowsable(EditorBrowsableState.Always), _
Category("_report essentials"), _
Description("Any discription for report"), _
DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
    Property DiscriptionforReport As List(Of report)    'any message to display in report table
        Get
            Return TextonIndex
        End Get
        Set(ByVal value As List(Of report))
            TextonIndex = value
        End Set
    End Property
    Dim date_index As Integer
    <Category("_Date")>
    Property DateIndex As Integer  'plc address index on which date is given
        Get
            Return date_index
        End Get
        Set(value As Integer)
            date_index = value
        End Set
    End Property
    Dim month_index As Integer    'plc address index on which month is given
    <Category("_Date")>
    Property MonthIndex As Integer
        Get
            Return month_index
        End Get
        Set(value As Integer)
            month_index = value
        End Set
    End Property
    Dim year_index As Integer     'plc address index on which year is given
    <Category("_Date")>
    Property YearIndex As Integer
        Get
            Return year_index
        End Get
        Set(value As Integer)
            year_index = value
        End Set
    End Property
    Dim hour_index As Integer
    <Category("_Time")>
    Property HourIndex As Integer  'plc address index on which time(hour) is given
        Get
            Return hour_index
        End Get
        Set(value As Integer)
            hour_index = value
        End Set
    End Property
    Dim minute_index As Integer
    <Category("_Time")>
    Property MinuteIndex As Integer  'plc address index on which time(minute) is given
        Get
            Return minute_index
        End Get
        Set(value As Integer)
            minute_index = value
        End Set
    End Property
    Dim second_index As Integer
    <Category("_Time")>
    Property SecondIndex As Integer 'plc address index on which time(second) is given
        Get
            Return second_index
        End Get
        Set(value As Integer)
            second_index = value
        End Set
    End Property

    Dim temprowinserted = 0 ' store temparary count for number of row inserted.
    Dim temparray() As Integer ' theis store he temporary valiues of current row

    Dim insertquery As String = "" 'insert report data querry
    Dim valuestoinsert As String = "" 'values to insert in database are concatinate by using it
    Dim tempexit = 0
    Dim datee1 = ""
    Dim datee
    Dim timee = ""
    Dim tempinfo() As String   ' for store detail(message) of reprot like blending start
    Dim arrayindex As Integer = 0 'used when report generates on 32 bit address to store value in temparray
    Dim temp = 1   'it is used to create dynamic querry for data insertion
    Sub insertdata()
        If variableclass.tag(reporttrigger) = 1 Then
            sql.conn1()
            For i = 0 To highestindex - 1
                If tempexit = 1 Then
                    tempexit = 0
                    Exit For

                End If
                temp = 1 'it is used to create dynamic querry for data insertion

                ReDim temparray(no_of_component - 1)  'resize temparray to store report data in it 
                ReDim tempinfo(DiscriptionforReport.Count - 1) 'used to insert discription in database store discription according to value on given index
                insertquery = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 insert into Processdata(processid"
                valuestoinsert = "values('97'"
                If ReportAddressType = Address_type.BIT_16 Then  'check report is generated on 16 bit address or 32 bit address
                    For j = 0 To no_of_component - 1   'loop tostore all values in temparray for that row
                        'stores values from given report address into tempary array
                        temparray(j) = variableclass.tag(Val(startingaddress + (no_of_component * temprowinserted)) + j)
                        If j = DateIndex Or j = MonthIndex Or j = YearIndex Or j = HourIndex Or j = MinuteIndex Or j = SecondIndex Then
                        Else
                            'concatinate and completing querry
                            insertquery = insertquery & ",var" & temp
                            Dim a = 0   'these temparary a = 1 then there is text generated to insert if 0 means direct value is inserted in database
                            For k = 0 To DiscriptionforReport.Count - 1
                                'strores any message to insert in batch report according to value on index
                                If DiscriptionforReport(k).TextIndex = j Then
                                    tempinfo(k) = DiscriptionforReport(k).TextonIndex((temparray(DiscriptionforReport(k).TextIndex)))
                                    'concatinate values to for insert query
                                    valuestoinsert = valuestoinsert & ",EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & tempinfo(k) & "'))"
                                    a = 1
                                End If

                            Next
                            If a = 0 Then
                                'concatinate values to for insert query
                                valuestoinsert = valuestoinsert & ",EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & temparray(j) & "'))"
                            End If
                            temp = temp + 1
                        End If
                        If temparray(0) = 0 Then
                            tempexit = 1
                            Exit For
                        End If

                    Next
                    'date 
                    If DateTime_Recordvalue = DateTime_Record.FromPlc Then 'check from where date time is recorde
                        If date_index <> -1 And month_index <> -1 And year_index <> -1 Then
                            '  Dim month = String.Format("{0:0#}", temparray(month_index))
                            ' datee = temparray(date_index).ToString & "/" & month.ToString & "/" & temparray(year_index).ToString
                            Try
                                datee1 = String.Format("{0:00}", temparray(date_index)).ToString & "/" & String.Format("{0:00}", temparray(month_index)).ToString & "/" & String.Format("{0:00}", temparray(year_index)).ToString
                                '
                                datee = DateTime.ParseExact(datee1.ToString, "d/M/yyyy", Nothing).ToString("dd/MM/yy")
                            Catch ex As Exception
                                MessageBox.Show("date in report:" & ex.Message)
                                Exit Sub
                            End Try

                        End If
                        'time
                        If hour_index <> -1 And minute_index <> -1 And second_index <> -1 Then
                            Try
                                timee = temparray(hour_index).ToString & ":" & temparray(minute_index).ToString & ":" & temparray(second_index).ToString
                                timee = DateTime.ParseExact(timee, "H:m:s", Nothing).ToString("HH:mm:ss")
                            Catch ex As Exception
                                MessageBox.Show("time in report:" & ex.Message)
                                Exit Sub
                            End Try
                        End If
                    Else
                        datee = DateTime.Now.ToString("dd/MM/yy")
                        timee = DateTime.Now.ToString("HH:mm:ss")
                    End If
                    'concatinate date,time and employeeid and there values to querry
                    insertquery = insertquery & ",date,time,empid)"
                    valuestoinsert = valuestoinsert & ",EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & datee & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & timee & "')),'" & Login_Register.empid & "')"
                Else
                    'if report generates on 32 bit address
                    arrayindex = 0
                    For j = 0 To (no_of_component * 2) - 1 Step 2

                        'stores values from given report address into tempary array
                        Dim ByteArr(3) As Byte
                        Dim value As Short
                        For l = 0 To 1
                            Short.TryParse(Val(variableclass.tag(Val(startingaddress + (no_of_component * (temprowinserted * 2))) + (j + l))), value)
                            Dim Temp_Byte = BitConverter.GetBytes(value)
                            ByteArr(l * 2) = Temp_Byte(0)
                            ByteArr(l * 2 + 1) = Temp_Byte(1)
                        Next
                        'in 32 bit arrayinde is used not j because j = j + 2 each time loop executes and now we are combining two address and strore in local array
                        Dim tempval = BitConverter.ToInt32(ByteArr, 0)
                        temparray(arrayindex) = tempval
                        ' temparray(j) = variableclass.d(Val(startingaddress + (no_of_component * temprowinserted)) + j)
                        If j = DateIndex Or j = MonthIndex Or j = YearIndex Or j = HourIndex Or j = MinuteIndex Or j = SecondIndex Then
                        Else
                            'concatinate and completing querry
                            insertquery = insertquery & ",var" & temp
                            Dim a = 0   'these temparary a = 1 then there is text generated to insert if 0 means direct value is inserted in database
                            For k = 0 To DiscriptionforReport.Count - 1
                                'strores any message to insert in batch report according to value on index
                                If DiscriptionforReport(k).TextIndex = j Then
                                    tempinfo(k) = DiscriptionforReport(k).TextonIndex((temparray(DiscriptionforReport(k).TextIndex / 2)))
                                    'concatinate values to for insert query
                                    valuestoinsert = valuestoinsert & ",EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & tempinfo(k) & "'))"
                                    a = 1
                                End If

                            Next
                            If a = 0 Then
                                'concatinate values to for insert query
                                valuestoinsert = valuestoinsert & ",EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & temparray(arrayindex) & "'))"
                            End If
                            temp = temp + 1
                        End If
                        If temparray(0) = 0 Then
                            tempexit = 1
                            Exit For
                        End If
                        arrayindex = arrayindex + 1
                    Next
                    'date 
                    If DateTime_Recordvalue = DateTime_Record.FromPlc Then 'check from where date time is recorde
                        If date_index <> -1 And month_index <> -1 And year_index <> -1 Then
                            '  Dim month = String.Format("{0:0#}", temparray(month_index))
                            ' datee = temparray(date_index).ToString & "/" & month.ToString & "/" & temparray(year_index).ToString
                            Try
                                datee1 = String.Format("{0:00}", temparray(date_index / 2)).ToString & "/" & String.Format("{0:00}", temparray(month_index / 2)).ToString & "/" & String.Format("{0:00}", temparray(year_index / 2)).ToString
                                '
                                datee = DateTime.ParseExact(datee1.ToString, "d/M/yyyy", Nothing).ToString("dd/MM/yy")
                            Catch ex As Exception
                                MessageBox.Show("date in report:" & ex.Message)
                                Exit Sub
                            End Try

                        End If
                        'time
                        If hour_index <> -1 And minute_index <> -1 And second_index <> -1 Then
                            Try
                                timee = temparray(hour_index / 2).ToString & ":" & temparray(minute_index / 2).ToString & ":" & temparray(second_index / 2).ToString
                                timee = DateTime.ParseExact(timee, "H:m:s", Nothing).ToString("HH:mm:ss")
                            Catch ex As Exception
                                MessageBox.Show("time in report:" & ex.Message)
                                Exit Sub
                            End Try
                        End If
                    Else
                        datee = DateTime.Now.ToString("dd/MM/yy")
                        timee = DateTime.Now.ToString("HH:mm:ss")
                    End If
                    insertquery = insertquery & ",date,time,empid)"
                    valuestoinsert = valuestoinsert & ",EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & datee & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & timee & "')),'" & Login_Register.empid & "')"
                End If
                'add a query to insert row into database
                '  insertquery = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 insert into Processdata(processid,date,time,var1,var2,var3,empid)  values('97',EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & datee & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & timee & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & temparray(7) & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & temparray(8) & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & tempinfo(0) & "')),'" & Login_Register.empid & "')"
                'cocatinate insert columns and there respective values and creating final querry
                insertquery = insertquery & valuestoinsert
                Dim cmd = New SqlCommand(insertquery, sql.cn1)
                cmd.CommandTimeout = 60

                cmd.ExecuteNonQuery()
                cmd.Dispose()

                'if tempexit <>1
                temprowinserted = temprowinserted + 1
                If temprowinserted >= highestindex Then ' checking wheather number of row inserted not to exceed highestindex
                    temprowinserted = 0



                End If
            Next
            sql.cn1.Close()
            writeIndb(reporttrigger, 0, 0)
            writeIndb(902, 1, 1)

        End If
    End Sub
    Dim tempstart = 0  'start tag name not found in database then tempstart is zero else 1
    Dim tempend = 0
    Dim temptrigger = 0

    'writes value in tag table
    'address = tagId
    ''Sub writeIndb(ByVal address As Integer, ByVal value As Integer)
    ''    sql.scon3()
    ''    Try
    ''        sql.scon2()
    ''        sql.scon3()
    ''        Dim querystring As String = ""
    ''        Dim select_query As String = "select Tag_id,value FROM Tag_detail_data where id = '1' "
    ''        Dim cmd1 = New SqlCommand(select_query, sql.scn2)
    ''        Dim reader As SqlDataReader = cmd1.ExecuteReader
    ''        If reader.Read Then
    ''            If IsDBNull(reader.Item("Tag_id")) = False Then
    ''                If variableclass.is_encrypted Then
    ''                    querystring = "SET DEADLOCK_PRIORITY HIGH BEGIN TRAN  OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 update Tag_detail_data set Tag_id = EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'1'')) where id = 1 update Tag_detail_data set Tag_id = EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & address & "')), value = EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & value & "')) where id = 2 COMMIT TRANSACTION"
    ''                Else
    ''                    querystring = "SET DEADLOCK_PRIORITY HIGH BEGIN TRAN update Tag_detail_data set Tag_id = '" & reader.Item(0) + 1 & "' where id = 1 update Tag_detail_data set Tag_id = '" & address & "', value = '" & value & "' where id = '" & reader.Item(0) + 1 & "' COMMIT TRANSACTION"
    ''                End If
    ''                Dim sqlcmd1 As SqlCommand = New SqlCommand(querystring, sql.scn3)
    ''                sqlcmd1.ExecuteNonQuery()
    ''                sqlcmd1.Dispose()
    ''            Else
    ''                If variableclass.is_encrypted Then
    ''                    querystring = "SET DEADLOCK_PRIORITY HIGH BEGIN TRAN  OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 update Tag_detail_data set Tag_id = EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'1'')) where id = 1 update Tag_detail_data set Tag_id = EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & address & "')), value = EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & value & "')) where id = 2 COMMIT TRANSACTION"
    ''                Else
    ''                    querystring = "SET DEADLOCK_PRIORITY HIGH BEGIN TRAN update Tag_detail_data set Tag_id = '2' where id = 1 update Tag_detail_data set Tag_id = '" & address & "', value = '" & value & "' where id = 2 COMMIT TRANSACTION"
    ''                End If
    ''                Dim sqlcmd1 As SqlCommand = New SqlCommand(querystring, sql.scn3)
    ''                sqlcmd1.ExecuteNonQuery()
    ''                sqlcmd1.Dispose()

    ''            End If
    ''        End If
    ''        cmd1.Dispose()
    ''        sql.scn3.Close()
    ''        sql.scn2.Close()
    ''    Catch ex As Exception

    ''    End Try
    ''End Sub
    Sub writeIndb(ByVal address As Integer, ByVal value As String, ByVal iv_value As String)
        Try
            Dim querystring As String = ""
            If address < variableclass.Iv_tag_start_id Then
                sql.scon2()
                sql.scon3()

                Dim select_query As String = "select Tag_id,value FROM Tag_detail_data where id = '1' "
                Dim cmd1 = New SqlCommand(select_query, sql.scn2)
                Dim reader As SqlDataReader = cmd1.ExecuteReader
                If reader.Read Then
                    If IsDBNull(reader.Item("Tag_id")) = False Then
                        If variableclass.is_encrypted Then
                            querystring = "SET DEADLOCK_PRIORITY HIGH BEGIN TRAN  OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 update Tag_detail_data set Tag_id = EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'1'')) where id = 1 update Tag_detail_data set Tag_id = EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & address & "')), value = EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & value & "')) where id = 2 COMMIT TRANSACTION"
                        Else
                            querystring = "SET DEADLOCK_PRIORITY HIGH BEGIN TRAN update Tag_detail_data set Tag_id = '" & reader.Item(0) + 1 & "' where id = 1 update Tag_detail_data set Tag_id = '" & address & "', value = '" & value & "' where id = '" & reader.Item(0) + 1 & "' COMMIT TRANSACTION"
                        End If
                        Dim sqlcmd1 As SqlCommand = New SqlCommand(querystring, sql.scn3)
                        sqlcmd1.ExecuteNonQuery()
                        sqlcmd1.Dispose()
                    Else
                        If variableclass.is_encrypted Then
                            querystring = "SET DEADLOCK_PRIORITY HIGH BEGIN TRAN  OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 update Tag_detail_data set Tag_id = EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'1'')) where id = 1 update Tag_detail_data set Tag_id = EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & address & "')), value = EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & value & "')) where id = 2 COMMIT TRANSACTION"
                        Else
                            querystring = "SET DEADLOCK_PRIORITY HIGH BEGIN TRAN update Tag_detail_data set Tag_id = '2' where id = 1 update Tag_detail_data set Tag_id = '" & address & "', value = '" & value & "' where id = 2 COMMIT TRANSACTION"
                        End If
                        Dim sqlcmd1 As SqlCommand = New SqlCommand(querystring, sql.scn3)
                        sqlcmd1.ExecuteNonQuery()
                        sqlcmd1.Dispose()
                    End If
                End If
                cmd1.Dispose()
                sql.scn3.Close()
                sql.scn2.Close()
            Else
                sql.scon3()
                If variableclass.is_encrypted Then
                    querystring = "SET DEADLOCK_PRIORITY HIGH BEGIN TRAN  OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 update Tag_data set  Read_value = EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & iv_value & "')) where convert(varchar, decryptbykey(Tag_name)) = '" & address & "' COMMIT TRANSACTION"
                Else
                    querystring = "SET DEADLOCK_PRIORITY HIGH BEGIN TRAN update Tag_data set Read_value = '" & iv_value & "' where Tag_id = '" & address & "' COMMIT TRANSACTION"
                End If
                Dim sqlcmd1 As SqlCommand = New SqlCommand(querystring, sql.scn3)
                sqlcmd1.ExecuteNonQuery()
                sqlcmd1.Dispose()
                sql.scn3.Close()
            End If

        Catch ex As Exception

        End Try
    End Sub


    Sub updatevalue()
        sql.scon3()
        ''  Dim querystring As String = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select Tag_id, convert(varchar, decryptbykey(Tag_name)) as Tag_name from Tag_data  where  convert(varchar, decryptbykey(Tag_name)) = '" & ReportStartTag & "' or convert(varchar, decryptbykey(Tag_name)) = '" & ReportEndTag & "' or convert(varchar, decryptbykey(Tag_name)) = '" & ReportTriggerTag & "'  "
        Dim querystring As String = ""

        'for encrypted or  non_encypted tables
        If variableclass.is_encrypted Then
            querystring = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select Tag_id, convert(varchar, decryptbykey(Tag_name)) as Tag_name from Tag_data  where  convert(varchar, decryptbykey(Tag_name)) = '" & ReportStartTag & "' or convert(varchar, decryptbykey(Tag_name)) = '" & ReportEndTag & "' or convert(varchar, decryptbykey(Tag_name)) = '" & ReportTriggerTag & "'  "
        Else
            querystring = "select Tag_id, Tag_name from Tag_data  where  Tag_name = '" & ReportStartTag & "' or Tag_name = '" & ReportEndTag & "' or Tag_name = '" & ReportTriggerTag & "'  "
        End If

        Dim sqlcmd1 As SqlCommand = New SqlCommand(querystring, sql.scn3)
        sqlcmd1.ExecuteNonQuery()
        Using reader As SqlDataReader = sqlcmd1.ExecuteReader

            While reader.Read
                If reader.Item("Tag_name") = ReportStartTag Then
                    ReportStartAddress = reader.Item("Tag_id")
                    tempstart = 1
                End If
                If reader.Item("Tag_name") = ReportEndTag Then
                    ReportEndAddress = reader.Item("Tag_id")
                    tempend = 1
                End If
                If reader.Item("Tag_name") = ReportTriggerTag Then
                    reporttrigger = reader.Item("Tag_id")
                    temptrigger = 1
                End If
            End While
            If tempstart = 0 Then
                ReportStartAddress = 0
            End If
            If tempend = 0 Then
                ReportEndAddress = 0
            End If
            If temptrigger = 0 Then
                reporttrigger = 0
            End If
        End Using
        ' sqlcmd1.Dispose()
        sql.scn3.Close()
    End Sub
End Class
'used for creating collection property for report description column
Public Class report
    Dim index As Integer = 0
    Public Property TextIndex As Integer
        Get
            Return index
        End Get
        Set(ByVal value As Integer)

            index = value

        End Set
    End Property
    Dim generateText As String()
    Public Property TextonIndex As String()
        Get
            Return generateText
        End Get
        Set(ByVal value As String())
            generateText = value
        End Set
    End Property


End Class

