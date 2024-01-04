Imports System.ComponentModel
Imports System.Data.SqlClient

Public Class customformdata
    Dim server = "", dbname = "", dbid = "", dbpass = ""
    Dim list_dataindex As New List(Of formdata)
    <Browsable(True), _
     EditorBrowsable(EditorBrowsableState.Always), _
     Category("SQL"), _
     Description("The items with sub items that should be displayed")> _
    Public Property Server_Name As String
        Get


            Return server
        End Get
        Set(ByVal value As String)
            server = value
        End Set
    End Property
    Public Property Database_Name As String
        Get
            Return dbname
        End Get
        Set(ByVal value As String)
            dbname = value


        End Set
    End Property
    Public Property Database_UserID As String
        Get
            Return dbid
        End Get
        Set(ByVal value As String)
            dbid = value

        End Set
    End Property
    Public Property Database_Password As String
        Get
            Return dbpass
        End Get
        Set(ByVal value As String)
            dbpass = value

        End Set
    End Property
    <Browsable(True), _
EditorBrowsable(EditorBrowsableState.Always), _
Category("Z"), _
Description("The items with sub items that should be displayed"), _
DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
    Property ListDataIndex As List(Of formdata)
        Get
            Return list_dataindex
        End Get
        Set(ByVal value As List(Of formdata))
            list_dataindex = value
        End Set
    End Property


    Public Sub updatedata_insertquery(ByVal index As Integer)

        Dim sqlcon As SqlConnection = New SqlConnection With {.ConnectionString = "server=" & server & "; Database= " & dbname & ";user id= " & dbid & ";password=" & dbpass & ";"}

        ' sqlcon = New SqlConnection With {.ConnectionString = "server=.\sqlexpress; Database= Pharma;user id= rmsview;password=rmsview;"}
        Try

            sqlcon.Open()

            If sqlcon.State = ConnectionState.Open Then
                Dim sqlquery = "insert into scadaformdata(rowid,empid,date,time,"
                Dim sqlqueryvalues = ""

                For i = index To list_dataindex.Count

                    For j = 0 To list_dataindex(i - 1).Dataindex.Count - 1
                        Dim tempvarible = list_dataindex(i - 1).Dataindex(j).ToString.Substring(0, 1)
                        Dim tempvaribale_value = list_dataindex(i - 1).Dataindex(j).ToString.Substring(1)
                        Dim tempdata = ""
                        If tempvarible = "D" Then
                            tempdata = variableclass.d(tempvaribale_value)
                        End If
                        If tempvarible = "M" Then
                            tempdata = variableclass.m(tempvaribale_value)
                        End If
                        If tempvarible = "I" Then
                            tempdata = variableclass.iv(tempvaribale_value)
                        End If
                        If j = list_dataindex(i - 1).Dataindex.Count - 1 Then
                            sqlqueryvalues = sqlqueryvalues & "'" & tempdata & "'"
                            sqlquery = sqlquery & "var" & j + 1 & ")values('" & list_dataindex(i - 1).FormId & "','" & Login_Register.empid & "','" & variableclass.datee & "','" & variableclass.timee & "'," & sqlqueryvalues & ")"

                        Else
                            sqlquery = sqlquery & "var" & j + 1 & ","

                            sqlqueryvalues = sqlqueryvalues + "'" & tempdata & "',"
                        End If

                        '  MsgBox(lb.Text)
                        ' code to insert the submitted data into the database  with the respect field s
                    Next
                    ' MsgBox(sqlquery)
                    Dim cmd = New SqlCommand(sqlquery, sqlcon)
                    cmd.ExecuteNonQuery()

                    cmd.Dispose()
                    sqlquery = "insert into scadaformdata(rowid,empid,date,time,"
                    sqlqueryvalues = ""
                Next
                'Try
                sqlcon.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub

    Public Sub updatedata_updatequery()
        'only single entry required in database for eevery form
        'insert a condition to check the respective formid has row in database or not if not the insert data or other wise update the data (overwrite the data)

        Dim sqlcon As SqlConnection = New SqlConnection With {.ConnectionString = "server=" & server & "; Database= " & dbname & ";user id= " & dbid & ";password=" & dbpass & ";"}

        ' sqlcon = New SqlConnection With {.ConnectionString = "server=.\sqlexpress; Database= Pharma;user id= rmsview;password=rmsview;"}
        Try

            sqlcon.Open()


            If sqlcon.State = ConnectionState.Open Then
                Dim sqlquery = "update scadaformdata set date='" & variableclass.datee & "',time='" & variableclass.timee & "',empname='" & Login_Register.Fname & "', "
                Dim sqlqueryvalues = ""

                For i = 1 To list_dataindex.Count
                    Dim cmd1 = New SqlCommand("select rowid from scadaformdata where rowid='" & list_dataindex(i - 1).FormId & "'", sqlcon)
                    Dim sqlreader As SqlDataReader = cmd1.ExecuteReader
                    If sqlreader.Read Then
                    Else
                        updatedata_insertquery(i)

                    End If
                    sqlreader.Close()
                    cmd1.Dispose()
                    For j = 0 To list_dataindex(i - 1).Dataindex.Count - 1
                        Dim tempvarible = list_dataindex(i - 1).Dataindex(j).ToString.Substring(0, 1)
                        Dim tempvaribale_value = list_dataindex(i - 1).Dataindex(j).ToString.Substring(1)
                        Dim tempdata = ""
                        If tempvarible = "D" Then
                            tempdata = variableclass.d(tempvaribale_value)
                        End If
                        If tempvarible = "M" Then
                            tempdata = variableclass.m(tempvaribale_value)
                        End If
                        If tempvarible = "I" Then
                            tempdata = variableclass.iv(tempvaribale_value)
                        End If
                        If j = list_dataindex(i - 1).Dataindex.Count - 1 Then
                            ' sqlqueryvalues = sqlqueryvalues & "'" & tempdata & "'"
                            sqlquery = sqlquery & "var" & j + 1 & "='" & tempdata & "' where rowid='" & list_dataindex(i - 1).FormId & "'"
                            '   sqlquery = sqlquery & "var" & i & ")values('" & list_dataindex(i).FormId & "','" & Login_Register.empid & "','" & Date.Now.ToString("yyyy-MM-dd") & "','" & DateTime.Now.ToString("HH:mm:ss") & "'," & sqlqueryvalues & ")"

                        Else
                            sqlquery = sqlquery & "var" & j + 1 & "='" & tempdata & "',"

                            '   sqlqueryvalues = sqlqueryvalues + "'" & tempdata & "',"
                        End If

                        '  MsgBox(lb.Text)
                        ' code to insert the submitted data into the database  with the respect field s


                        '  MsgBox(lb.Text)
                        ' code to insert the submitted data into the database  with the respect field s
                    Next
                    '  MsgBox(sqlquery)
                    Dim cmd = New SqlCommand(sqlquery, sqlcon)
                    cmd.ExecuteNonQuery()
                    ' MsgBox(sqlquery)
                    cmd.Dispose()
                    sqlquery = "update scadaformdata set date='" & variableclass.datee & "',time='" & variableclass.timee & "',empname='" & Login_Register.Fname & "', "
                    sqlqueryvalues = ""
                Next
                'Try
                sqlcon.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class
Public Class formdata
    Dim form_id As Integer
    Dim data As String()
    Public Property FormId As Integer
        Get
            Return form_id
        End Get
        Set(ByVal value As Integer)
            form_id = value
        End Set
    End Property
    Public Property Dataindex As String()
        Get
            Return data
        End Get
        Set(ByVal value As String())
            data = value
        End Set
    End Property

End Class
