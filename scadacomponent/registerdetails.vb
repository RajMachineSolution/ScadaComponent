Imports System.Data.SqlClient
Imports System.Windows.Forms

Public Class registerdetails
    Dim sql As New sqlclass
    Public tempregister As registerdetails
    Private Sub registerdetails_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        filldata()
    End Sub
    Sub filldata()
        Dim query = ""
        ' query = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 update employeeinfo set active=1 where CONVERT(varchar, DecryptByKey(userid)) ='" & temp & "'"

        Try
            Dim da As SqlDataAdapter
            Dim ds As New DataSet
            sql.conn1()
            If Login_Register.levelid = 1 Then
                query = "  OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 Select CONVERT(varchar, DecryptByKey(fname)) as 'Full Name',CONVERT(varchar, DecryptByKey(userid)) as UserId,(select CONVERT(varchar, DecryptByKey(levelname)) from leveldetails where levelid=e.plevel) as level,CASE active WHEN 2 THEN 'Deactivated' WHEN 1 THEN 'Activated' end as Status from employeeinfo as e where empid<>1 and empid<>2 order by 'full name' "

            Else
                query = "  OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 Select CONVERT(varchar, DecryptByKey(fname)) as 'Full Name',CONVERT(varchar, DecryptByKey(userid)) as UserId,(select CONVERT(varchar, DecryptByKey(levelname)) from leveldetails where levelid=e.plevel) as level,CASE active WHEN 2 THEN 'Deactivated' WHEN 1 THEN 'Activated' end as Status from employeeinfo as e where empid<>1 and empid<>2 and plevel <>'" & Login_Register.levelid & "' order by 'full name' "

            End If
            '       "order by  convert(date,CONVERT(varchar, DecryptByKey(date)),103) ,       convert(time, Convert(varchar, DecryptByKey(time)))"

            Dim cmd = New SqlCommand(query, sql.cn1)
            cmd.CommandTimeout = 60
            da = New SqlDataAdapter(cmd)
            da.Fill(ds)
            detailsgrid.DataSource = ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        sql.cn1.Close()
    End Sub

    Private Sub detailsgrid_CellClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles detailsgrid.CellClick
        If e.RowIndex < 0 Then
            For Each column As DataGridViewColumn In detailsgrid.Columns
                column.SortMode = DataGridViewColumnSortMode.NotSortable
            Next
            Exit Sub
        End If

        If e.ColumnIndex = 0 Then
            Dim t = detailsgrid.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
            Dim userid = detailsgrid.Rows(e.RowIndex).Cells(1).Value.ToString.Trim
            Dim regdetail As New regdetails(userid)
            'regdetail.tempregister = Me.
            regdetail.TopMost = True
            regdetail.StartPosition = FormStartPosition.CenterParent
            regdetail.ShowDialog()

        End If
    End Sub

    'Private Sub detailsgrid_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles detailsgrid.CellContentClick
    '    If e.RowIndex < 0 Then
    '        For Each column As DataGridViewColumn In detailsgrid.Columns
    '            column.SortMode = DataGridViewColumnSortMode.NotSortable
    '        Next
    '    End If
    '    If e.ColumnIndex = 0 Then
    '        Dim t = detailsgrid.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
    '        Dim userid = detailsgrid.Rows(e.RowIndex).Cells(1).Value.ToString.Trim
    '        Dim regdetails As New regdetails(userid)
    '        regdetails.ShowDialog()

    '    End If
    'End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        filldata()
    End Sub
End Class