Imports System.Drawing.Design
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Windows.Forms.Design
Imports System.Reflection
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Globalization

Public Class DatetimeComponent
    Public Enum Datedisplay_format
        ddMMyy
        MMddyy
        yyMMdd
        ddMMyyyy
        yyyyMMdd
        MMddyyyy
    End Enum

    Public Enum Dateseparator
        Slash
        Dash
    End Enum

    Public Enum selectdatefrom
        Plc
        System
    End Enum


    Public Enum variableupdate
        Yes
        No
    End Enum

    Dim displaydateformat As Datedisplay_format
    <Category("_Date Format"), Description("Format in which date display")>
    Property Date_Display_format As Datedisplay_format
        Get
            Return displaydateformat
        End Get
        Set(ByVal value As Datedisplay_format)
            displaydateformat = value
            If date_separatorvar = Dateseparator.Dash Then
                If displaydateformat = Datedisplay_format.yyMMdd Then
                    Date_Separator = Dateseparator.Slash
                End If
            End If
        End Set
    End Property

    'get date time from pc or plc
    Dim selectdate_from As selectdatefrom
    <Category("_Date Format"), Description("get date time from plc or system")>
    Property Select_Datetime_from As selectdatefrom
        Get
            Return selectdate_from
        End Get
        Set(ByVal value As selectdatefrom)
            selectdate_from = value
        End Set
    End Property
    'property for select date separator slash or dash
    Dim date_separatorvar As Dateseparator
    <Category("_Date Format"), Description("set '/' or '-' as date separator")>
    Property Date_Separator As Dateseparator
        Get
            Return date_separatorvar
        End Get
        Set(ByVal value As Dateseparator)
            If Date_Display_format = Datedisplay_format.yyMMdd Then
                date_separatorvar = Dateseparator.Slash
            Else
                date_separatorvar = value
            End If
        End Set
    End Property

    'property for display seconds in date time or not
    Dim seconddisplaytagid As Integer = 0
    Dim seconddisplaytag As String
    <Category("_Date Format")> _
    Public Property SecondDisplay_Tag As String
        Get
            Return seconddisplaytag
        End Get
        Set(ByVal value As String)

            seconddisplaytag = value
        End Set
    End Property

    'stores tag id 
    Dim secondtagid As Integer
    Dim secondtag As String
    'tag for second
    <Category("_Tag Name Time"), Description("Tag name which gets second from plc")>
    Property Second_Tag As String
        Get
            Return secondtag
        End Get
        Set(ByVal tag As String)
            secondtag = tag
            'writeadd = VALUE
        End Set
    End Property

    'stores tag id 
    Dim minutetagid As Integer
    Dim minutetag As String
    'tag for minute
    <Category("_Tag Name Time"), Description("Tag name which gets Minute from plc")>
    Property Minute_Tag As String
        Get
            Return minutetag

        End Get
        Set(ByVal tag As String)
            minutetag = tag
            'writeadd = VALUE
        End Set
    End Property

    'stores tag id 
    Dim hourtagid As Integer
    Dim hourtag As String
    'tag for hour
    <Category("_Tag Name Time"), Description("Tag name which gets hour from plc")>
    Property Hour_Tag As String
        Get
            Return hourtag

        End Get
        Set(ByVal tag As String)
            hourtag = tag
            'writeadd = VALUE
        End Set
    End Property

    'stores tag id 
    Dim datetagid As Integer
    Dim datetag As String
    'tag for Date
    <Category("_Tag Name Date"), Description("Tag name which gets date from plc")>
    Property Day_Tag As String
        Get
            Return datetag

        End Get
        Set(ByVal tag As String)
            datetag = tag
            'writeadd = VALUE
        End Set
    End Property

    'stores tag id 
    Dim monthtagid As Integer
    Dim monthtag As String
    'tag for Month
    <Category("_Tag Name Date"), Description("Tag name which gets month from plc")>
    Property Month_Tag As String
        Get
            Return monthtag

        End Get
        Set(ByVal tag As String)
            monthtag = tag
            'writeadd = VALUE
        End Set
    End Property

    'stores tag id 
    Dim yeartagid As Integer
    Dim yeartag As String
    'tag for hour
    <Category("_Tag Name Date"), Description("Tag name which gets year from plc")>
    Property Year_Tag As String
        Get
            Return yeartag

        End Get
        Set(ByVal tag As String)
            yeartag = tag
            'writeadd = VALUE
        End Set
    End Property
    Dim updatevariable As variableupdate
    <Category("_misc"), Description("Update date time of scada with component")>
    Property Update_variable As variableupdate
        Get
            Return updatevariable

        End Get
        Set(ByVal value As variableupdate)
            updatevariable = value
            If Update_variable = variableupdate.Yes Then
                variableclass.datetimeupdate_counter = variableclass.datetimeupdate_counter + 1
            End If
            'writeadd = VALUE
        End Set
    End Property

    'store date and time tag tagid for updating date time for client
    Dim clientdateid As Integer = 0
    Dim clienttimeid As Integer = 0

    Dim sql As New sqlclass
    'stores count if 6 means all date time tag are right
    Dim tempcount = 0
    'function which update tag id for each tag
    Sub updatevalue()
        Try
            If Select_Datetime_from = selectdatefrom.Plc Then
                tempcount = 0
                sql.scon3()
                ''   Dim querystring As String = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select Tag_id, convert(varchar, decryptbykey(Tag_name)) as Tag_name from Tag_data  where  convert(varchar, decryptbykey(Tag_name)) = '" & secondtag & "' or convert(varchar, decryptbykey(Tag_name)) = '" & minutetag & "' or convert(varchar, decryptbykey(Tag_name)) = '" & hourtag & "' or convert(varchar, decryptbykey(Tag_name)) = '" & datetag & "' or convert(varchar, decryptbykey(Tag_name)) = '" & monthtag & "' or convert(varchar, decryptbykey(Tag_name)) = '" & yeartag & "' or convert(varchar, decryptbykey(Tag_name)) = '" & seconddisplaytag & "' "
                Dim querystring As String = ""

                'for encrypted or  non_encypted tables
                If variableclass.is_encrypted Then
                    querystring = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select Tag_id, convert(varchar, decryptbykey(Tag_name)) as Tag_name from Tag_data  where  convert(varchar, decryptbykey(Tag_name)) = '" & secondtag & "' or convert(varchar, decryptbykey(Tag_name)) = '" & minutetag & "' or convert(varchar, decryptbykey(Tag_name)) = '" & hourtag & "' or convert(varchar, decryptbykey(Tag_name)) = '" & datetag & "' or convert(varchar, decryptbykey(Tag_name)) = '" & monthtag & "' or convert(varchar, decryptbykey(Tag_name)) = '" & yeartag & "' or convert(varchar, decryptbykey(Tag_name)) = '" & seconddisplaytag & "' "
                Else
                    querystring = "select Tag_id, Tag_name from Tag_data  where Tag_name = '" & secondtag & "' or Tag_name = '" & minutetag & "' or Tag_name = '" & hourtag & "' or Tag_name = '" & datetag & "' or Tag_name = '" & monthtag & "' or Tag_name = '" & yeartag & "' or Tag_name = '" & seconddisplaytag & "' "
                End If


                Dim sqlcmd1 As SqlCommand = New SqlCommand(querystring, sql.scn3)
                sqlcmd1.ExecuteNonQuery()
                Using reader As SqlDataReader = sqlcmd1.ExecuteReader

                    While reader.Read
                        If reader.Item("Tag_name") = secondtag Then
                            secondtagid = reader.Item("Tag_id")
                            tempcount = tempcount + 1
                        End If
                        If reader.Item("Tag_name") = minutetag Then
                            minutetagid = reader.Item("Tag_id")
                            tempcount = tempcount + 1
                        End If
                        If reader.Item("Tag_name") = hourtag Then
                            hourtagid = reader.Item("Tag_id")
                            tempcount = tempcount + 1
                        End If
                        If reader.Item("Tag_name") = datetag Then
                            datetagid = reader.Item("Tag_id")
                            tempcount = tempcount + 1
                        End If
                        If reader.Item("Tag_name") = monthtag Then
                            monthtagid = reader.Item("Tag_id")
                            tempcount = tempcount + 1
                        End If
                        If reader.Item("Tag_name") = yeartag Then
                            yeartagid = reader.Item("Tag_id")
                            tempcount = tempcount + 1
                        End If
                        If reader.Item("Tag_name") = seconddisplaytag Then
                            seconddisplaytagid = reader.Item("Tag_id")

                        End If
                    End While
                    'If tempcount <> 6 Then
                    '    ' Select_Datetime_from = selectdatefrom.System

                    'End If
                End Using
                ' sqlcmd1.Dispose()
                sql.scn3.Close()
            ElseIf Select_Datetime_from = selectdatefrom.System Then
                sql.scon3()
                '  Dim querystring As String = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select Tag_id, convert(varchar, decryptbykey(Tag_name)) as Tag_name from Tag_data  where  convert(varchar, decryptbykey(Tag_name)) = '" & seconddisplaytag & "' "
                Dim querystring As String = ""
                'for encrypted or  non_encypted tables
                If variableclass.is_encrypted Then
                    querystring = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select Tag_id, convert(varchar, decryptbykey(Tag_name)) as Tag_name from Tag_data  where  convert(varchar, decryptbykey(Tag_name)) = '" & seconddisplaytag & "' "
                Else
                    querystring = "select Tag_id,Tag_name from Tag_data  where  Tag_name = '" & seconddisplaytag & "' "
                End If

                Dim sqlcmd1 As SqlCommand = New SqlCommand(querystring, sql.scn3)
                sqlcmd1.ExecuteNonQuery()
                Using reader As SqlDataReader = sqlcmd1.ExecuteReader

                    While reader.Read
                        If reader.Item("Tag_name") = seconddisplaytag Then
                            seconddisplaytagid = reader.Item("Tag_id")

                        End If
                    End While
                End Using
                ' sqlcmd1.Dispose()
                sql.scn3.Close()
            End If
            'get tag id for updating date time for client
            sql.scon3()
            ''   Dim querystring_date As String = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select Tag_id, convert(varchar, decryptbykey(Tag_name)) as Tag_name from Tag_data  where  convert(varchar, decryptbykey(Tag_name)) = 'Date' or convert(varchar, decryptbykey(Tag_name)) = 'Time' "
            Dim querystring_date As String = ""

            'for encrypted or  non_encypted tables
            If variableclass.is_encrypted Then
                querystring_date = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select Tag_id, convert(varchar, decryptbykey(Tag_name)) as Tag_name from Tag_data  where  convert(varchar, decryptbykey(Tag_name)) = 'Date' or convert(varchar, decryptbykey(Tag_name)) = 'Time' "
            Else
                querystring_date = "select Tag_id, Tag_name from Tag_data  where  Tag_name = 'Date(0)' or Tag_name = 'Time(0)' "
            End If



            Dim sqlcmd_date As SqlCommand = New SqlCommand(querystring_date, sql.scn3)
            sqlcmd_date.ExecuteNonQuery()
            Using reader As SqlDataReader = sqlcmd_date.ExecuteReader

                While reader.Read
                    'get tag id of client date and time
                    If reader.Item("Tag_name") = "Date(0)" Then
                        clientdateid = reader.Item("Tag_id")
                    ElseIf reader.Item("Tag_name") = "Time(0)" Then
                        clienttimeid = reader.Item("Tag_id")
                    End If
                End While
            End Using
            ' sqlcmd1.Dispose()
            sql.scn3.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub

    Public Shared tempdate = ""
    Public Shared temptime = ""
    'use to display date and time according to selected format
    Dim displaydate
    Dim displaytime
    'to update date time
    Sub update_datetime()
        

        If Update_variable = variableupdate.Yes Then
            If Select_Datetime_from = selectdatefrom.Plc Then

                Dim month = String.Format("{0:0#}", Val(variableclass.tag(monthtagid)))
                tempdate = variableclass.tag(datetagid).ToString & "/" & month.ToString & "/" & variableclass.tag(yeartagid).ToString
                tempdate = DateTime.ParseExact(tempdate.ToString, "d/M/yyyy", Nothing).ToString("dd-MM-yy", CultureInfo.InvariantCulture)
                temptime = variableclass.tag(hourtagid).ToString & ":" & variableclass.tag(minutetagid).ToString & ":" & variableclass.tag(secondtagid).ToString
                temptime = DateTime.ParseExact(temptime, "H:m:s", Nothing).ToString("HH:mm:ss")
            ElseIf Select_Datetime_from = selectdatefrom.System Then
                tempdate = DateTime.Now.ToString("dd-MM-yy")
                temptime = DateTime.Now.ToString("HH:mm:ss")
            End If
            variableclass.datee = tempdate
            variableclass.timee = temptime
            'update date time for client in database 
            writeIndb(clientdateid, variableclass.datee, variableclass.datee)
            writeIndb(clienttimeid, variableclass.timee, variableclass.timee)
        ElseIf Update_variable = variableupdate.No Then
            If Select_Datetime_from = selectdatefrom.Plc Then

                Dim month = String.Format("{0:0#}", Val(variableclass.tag(monthtagid)))
                tempdate = variableclass.tag(datetagid).ToString & "/" & month.ToString & "/" & variableclass.tag(yeartagid).ToString
                tempdate = DateTime.ParseExact(tempdate.ToString, "d/M/yyyy", Nothing).ToString("dd-MM-yy", CultureInfo.InvariantCulture)
                temptime = variableclass.tag(hourtagid).ToString & ":" & variableclass.tag(minutetagid).ToString & ":" & variableclass.tag(secondtagid).ToString
                temptime = DateTime.ParseExact(temptime, "H:m:s", Nothing).ToString("HH:mm:ss")


            ElseIf Select_Datetime_from = selectdatefrom.System Then
                tempdate = DateTime.Now.ToString("dd-MM-yy")
                temptime = DateTime.Now.ToString("HH:mm:ss")
            End If

        End If
        
        'convert date in selected format by user to display
        If Date_Separator = Dateseparator.Dash Then
            If displaydateformat = Datedisplay_format.ddMMyy Then
                displaydate = Date.ParseExact(tempdate, "dd-MM-yy", Nothing).ToString("dd-MM-yy")
                'displaydate = displaydate.Replace("/", "-")
            ElseIf displaydateformat = Datedisplay_format.MMddyy Then
                displaydate = Date.ParseExact(tempdate, "dd-MM-yy", Nothing).ToString("MM-dd-yy")
                ' displaydate = displaydate.Replace("/", "-")
            ElseIf displaydateformat = Datedisplay_format.yyMMdd Then
                displaydate = Date.ParseExact(tempdate, "dd-MM-yy", Nothing).ToString("yy-MM-dd")
                'displaydate = displaydate.Replace("/", "-")
            ElseIf displaydateformat = Datedisplay_format.yyyyMMdd Then
                displaydate = Date.ParseExact(tempdate, "dd-MM-yy", Nothing).ToString("yyyy-MM-dd")
                ' displaydate = displaydate.Replace("/", "-")
            ElseIf displaydateformat = Datedisplay_format.MMddyyyy Then
                displaydate = Date.ParseExact(tempdate, "dd-MM-yy", Nothing).ToString("MM-dd-yyyy")
                'displaydate = displaydate.Replace("/", "-")
            ElseIf displaydateformat = Datedisplay_format.ddMMyyyy Then
                displaydate = Date.ParseExact(tempdate, "dd-MM-yy", Nothing).ToString("dd-MM-yyyy")
                '  displaydate = displaydate.Replace("/", "-")
            End If
        ElseIf Date_Separator = Dateseparator.Slash Then
            If displaydateformat = Datedisplay_format.ddMMyy Then
                displaydate = Date.ParseExact(tempdate, "dd-MM-yy", Nothing).ToString("dd-MM-yy")
                displaydate = displaydate.Replace("-", "/")
            ElseIf displaydateformat = Datedisplay_format.MMddyy Then
                displaydate = Date.ParseExact(tempdate, "dd-MM-yy", Nothing).ToString("MM-dd-yy")
                displaydate = displaydate.Replace("-", "/")
            ElseIf displaydateformat = Datedisplay_format.yyMMdd Then
                displaydate = Date.ParseExact(tempdate, "dd-MM-yy", Nothing).ToString("yy-MM-dd")
                displaydate = displaydate.Replace("-", "/")
            ElseIf displaydateformat = Datedisplay_format.yyyyMMdd Then
                displaydate = Date.ParseExact(tempdate, "dd-MM-yy", Nothing).ToString("yyyy-MM-dd")
                displaydate = displaydate.Replace("-", "/")
            ElseIf displaydateformat = Datedisplay_format.MMddyyyy Then
                displaydate = Date.ParseExact(tempdate, "dd-MM-yy", Nothing).ToString("MM-dd-yyyy")
                displaydate = displaydate.Replace("-", "/")
            ElseIf displaydateformat = Datedisplay_format.ddMMyyyy Then
                displaydate = Date.ParseExact(tempdate, "dd-MM-yy", Nothing).ToString("dd-MM-yyyy")
                displaydate = displaydate.Replace("-", "/")
            End If
        End If
        'display second or not in time
        If Val(variableclass.tag(seconddisplaytagid)) = 1 Then
            displaytime = temptime
        Else
            displaytime = DateTime.ParseExact(temptime, "HH:mm:ss", Nothing).ToString("HH:mm")
        End If
        'display date time on label
        Me.Text = displaydate & " " & displaytime
        'for sunpharama hmi requirement 
        ' Me.Text = displaytime
        '  Me.Text = temptime
    End Sub



    '' write tag value in database 
    'Sub writeIndb(ByVal address As Integer, ByVal value As String)

    '    Try
    '        sql.scon2()
    '        sql.scon3()
    '        Dim querystring As String = ""
    '        Dim select_query As String = "select Tag_id,value FROM Tag_detail_data where id = '1' "
    '        Dim cmd1 = New SqlCommand(select_query, sql.scn2)
    '        Dim reader As SqlDataReader = cmd1.ExecuteReader
    '        If reader.Read Then
    '            If IsDBNull(reader.Item("Tag_id")) = False Then
    '                If variableclass.is_encrypted Then
    '                    querystring = "SET DEADLOCK_PRIORITY HIGH BEGIN TRAN  OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 update Tag_detail_data set Tag_id = EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'1'')) where id = 1 update Tag_detail_data set Tag_id = EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & address & "')), value = EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & value & "')) where id = 2 COMMIT TRANSACTION"
    '                Else
    '                    querystring = "SET DEADLOCK_PRIORITY HIGH BEGIN TRAN update Tag_detail_data set Tag_id = '" & reader.Item(0) + 1 & "' where id = 1 update Tag_detail_data set Tag_id = '" & address & "', value = '" & value & "' where id = '" & reader.Item(0) + 1 & "' COMMIT TRANSACTION"
    '                End If
    '                Dim sqlcmd1 As SqlCommand = New SqlCommand(querystring, sql.scn3)
    '                sqlcmd1.ExecuteNonQuery()
    '                sqlcmd1.Dispose()
    '            Else
    '                If variableclass.is_encrypted Then
    '                    querystring = "SET DEADLOCK_PRIORITY HIGH BEGIN TRAN  OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 update Tag_detail_data set Tag_id = EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'1'')) where id = 1 update Tag_detail_data set Tag_id = EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & address & "')), value = EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & value & "')) where id = 2 COMMIT TRANSACTION"
    '                Else
    '                    querystring = "SET DEADLOCK_PRIORITY HIGH BEGIN TRAN update Tag_detail_data set Tag_id = '2' where id = 1 update Tag_detail_data set Tag_id = '" & address & "', value = '" & value & "' where id = 2 COMMIT TRANSACTION"
    '                End If
    '                Dim sqlcmd1 As SqlCommand = New SqlCommand(querystring, sql.scn3)
    '                sqlcmd1.ExecuteNonQuery()
    '                sqlcmd1.Dispose()
    '            End If
    '        End If
    '        cmd1.Dispose()
    '        sql.scn3.Close()
    '        sql.scn2.Close()
    '    Catch ex As Exception

    '    End Try
    'End Sub

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


End Class
