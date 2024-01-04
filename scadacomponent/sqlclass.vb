Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Data
Imports System.Windows.Forms
Imports System.Drawing

Public Class sqlclass
    Public Shared server = ""
    Public Shared dbname = ""
    Public Shared dbid = ""
    Public Shared dbpass As String = ""
    ' Public Shared sqlcon As New SqlConnection
    Public Shared sqlcon As New SqlConnection

    Public Shared Batchlist As New AutoCompleteStringCollection()
    Public Shared lotlist As New AutoCompleteStringCollection()

    Public Shared cnn1, cnn2, cnn3, cnn4, cnn5, rightcnn As SqlConnection
    Public Shared px As Boolean
    Public cn1, cn2, cn3, cn4, cn5, cnb As SqlConnection
    Public scn1, scn2, scn3, scn4, scn5 As SqlConnection
    Public Shared database As String = ""

    'Public Shared SQL As String
    Public Shared cmd1 As SqlCommand
    Public Shared cmd2 As SqlCommand
    Public Shared cmd3 As SqlCommand
    Public Shared cmd4 As SqlCommand
    Public Shared cmd5 As SqlCommand
    Sub New()
        '   rightcon()
        '    sqlcon = New SqlConnection With {.ConnectionString = "server=" & server & "; Database= " & dbname & ";user id= " & dbid & ";password=" & dbpass & ";"}
    End Sub
    Public Sub con1()
        'sqlcon = New SqlConnection With {.ConnectionString = "server=" & server & "; Database= " & dbname & ";user id= " & dbid & ";password=" & dbpass & ";"}
        'sqlcon = New SqlConnection With {.ConnectionString = "server=.\sqlexpress; Database= interventioncipla;user id= rmsview;password=rmsview;"}
        sqlcon = New SqlConnection With {.ConnectionString = "server=" & server & "; Database= " & dbname & ";user id= " & dbid & ";password=" & dbpass & ";"}

        Try
            cnn1 = sqlcon
            cnn1.Open()

        Catch ex As Exception
            MsgBox("Can not open connection ! -" & ex.Message)
        End Try

    End Sub
    Public Sub con3()
        sqlcon = New SqlConnection With {.ConnectionString = "server=" & server & "; Database= " & dbname & ";user id= " & dbid & ";password=" & dbpass & ";"}

        Try
            cnn3 = sqlcon
            cnn3.Open()
        Catch ex As Exception
            MsgBox("Can not open connection ! -" & ex.Message)
        End Try

    End Sub
    Public Sub con2()
        ' server = ".\sqlexpress"
        ' dbname = "interventioncipla"
        'dbid = "rmsview"
        'dbpass = "rmsview"
        sqlcon = New SqlConnection With {.ConnectionString = "server=" & server & "; Database= " & dbname & ";user id= " & dbid & ";password=" & dbpass & ";"}

        Try
            cnn2 = sqlcon
            cnn2.Open()
        Catch ex As Exception
            MsgBox("Can not open connection ! -" & ex.Message)
        End Try

    End Sub
    Public Sub conn1()
        'server = ".\sqlexpress"
        '   dbname = "interventioncipla"
        '   dbid = "rmsview"
        '   dbpass = "rmsview"
        ' sqlcon = New SqlConnection With {.ConnectionString = "server=" & server & "; Database= " & dbname & ";user id= " & dbid & ";password=" & dbpass & ";"}
        ' sqlcon = New SqlConnection With {.ConnectionString = "server=.\sqlexpress; Database= Pharma;user id= rmsview;password=rmsview;"}
      
        Try
            sqlcon = New SqlConnection With {.ConnectionString = "server=" & server & "; Database= " & dbname & ";user id= " & dbid & ";password=" & dbpass & ";"}

            cn1 = sqlcon
            cn1.Open()

        Catch ex As Exception
            MsgBox("Can not open connection ! -" & ex.Message)
        End Try

    End Sub
    Public Sub conn3()
        'server = ".\sqlexpress"
        '   dbname = "interventioncipla"
        '  dbid = "rmsview"
        '  dbpass = "rmsview"

        ' sqlcon = New SqlConnection With {.ConnectionString = "server=" & server & "; Database= " & dbname & ";user id= " & dbid & ";password=" & dbpass & ";"}
        '  MsgBox(server & "" & dbname & "" & dbname & "" & dbid & "" & dbpass)
        ' sqlcon = New SqlConnection With {.ConnectionString = "server=" & server & "; Database= " & dbname & ";user id= " & dbid & ";password=" & dbpass & ";"}
        sqlcon = New SqlConnection With {.ConnectionString = "server=" & server & "; Database= " & dbname & ";user id= " & dbid & ";password=" & dbpass & ";"}

        '  sqlcon = New SqlConnection With {.ConnectionString = "server=.\sqlexpress; Database= Pharma;user id= rmsview;password=rmsview;"}
        Try
            cn3 = sqlcon
            cn3.Open()
        Catch ex As Exception
            MsgBox("Can not open connection ! -" & ex.Message)
        End Try

    End Sub
    Public Sub conn2()
        'sqlcon = New SqlConnection With {.ConnectionString = "server=" & server & "; Database= " & dbname & ";user id= " & dbid & ";password=" & dbpass & ";"}
        'sqlcon = New SqlConnection With {.ConnectionString = "server=" & server & "; Database= " & dbname & ";user id= " & dbid & ";password=" & dbpass & ";"}

        '  sqlcon = New SqlConnection With {.ConnectionString = "server=.\sqlexpress; Database= interventioncipla;user id= rmsview;password=rmsview;"}
        sqlcon = New SqlConnection With {.ConnectionString = "server=" & server & "; Database= " & dbname & ";user id= " & dbid & ";password=" & dbpass & ";"}

        Try
            cn2 = sqlcon
            cn2.Open()
        Catch ex As Exception
            MsgBox("Can not open connection ! -" & ex.Message)
        End Try

    End Sub
    Public Shared Function AES_Encrypt(ByVal input As String, ByVal pass As String) As String
        Dim AES As New System.Security.Cryptography.RijndaelManaged
        Dim Hash_AES As New System.Security.Cryptography.MD5CryptoServiceProvider
        Dim encrypted As String = ""
        Try
            Dim hash(31) As Byte
            Dim temp As Byte() = Hash_AES.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(pass))
            Array.Copy(temp, 0, hash, 0, 16)
            Array.Copy(temp, 0, hash, 15, 16)
            AES.Key = hash
            AES.Mode = Security.Cryptography.CipherMode.ECB
            Dim DESEncrypter As System.Security.Cryptography.ICryptoTransform = AES.CreateEncryptor
            Dim Buffer As Byte() = System.Text.ASCIIEncoding.ASCII.GetBytes(input)
            encrypted = Convert.ToBase64String(DESEncrypter.TransformFinalBlock(Buffer, 0, Buffer.Length))
            Return encrypted
        Catch ex As Exception
        End Try
        Return encrypted
    End Function

    Public Shared Function AES_Decrypt(ByVal input As String, ByVal pass As String) As String
        Dim AES As New System.Security.Cryptography.RijndaelManaged
        Dim Hash_AES As New System.Security.Cryptography.MD5CryptoServiceProvider
        Dim decrypted As String = ""
        Try
            Dim hash(31) As Byte
            Dim temp As Byte() = Hash_AES.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(pass))
            Array.Copy(temp, 0, hash, 0, 16)
            Array.Copy(temp, 0, hash, 15, 16)
            AES.Key = hash
            AES.Mode = Security.Cryptography.CipherMode.ECB
            Dim DESDecrypter As System.Security.Cryptography.ICryptoTransform = AES.CreateDecryptor
            Dim Buffer As Byte() = Convert.FromBase64String(input)
            decrypted = System.Text.ASCIIEncoding.ASCII.GetString(DESDecrypter.TransformFinalBlock(Buffer, 0, Buffer.Length))
            Return decrypted
        Catch ex As Exception
        End Try
        Return decrypted
    End Function
    Public Sub getBatchlist()
        Batchlist.Clear()
        Dim query As String = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 Select distinct CONVERT(varchar, DecryptByKey(batchno)) from batchproduct"
        conn3()
        Try
            ' SQL = "select id,Full_name  from User_Info where  status=1 "
            '  'MsgBox("Connection Open ! ")
            cmd3 = New SqlCommand(query, sqlcon)
            '    connect.cmd.CommandTimeout = 60
            ' connect.cmd.ExecuteNonQuery()
            Dim DA As SqlDataAdapter = New SqlDataAdapter(cmd3)
            Dim DataSet As DataSet = New DataSet
            DA.Fill(DataSet)
            For Each row As DataRow In DataSet.Tables(0).Rows
                Batchlist.Add(row(0).ToString())
            Next
            cmd3.Dispose()
            cn3.Close()
        Catch ex As Exception
            MessageBox.Show("Can not open connection ! ")
        End Try


    End Sub

    Public Sub getLotlist(ByVal btch As String)
        lotlist.Clear()
        Dim query As String = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 Select CONVERT(varchar, DecryptByKey(lotno))  from batchproduct where CONVERT(varchar, DecryptByKey(batchno))='" & btch & "'"
        conn3()
        Try
            ' SQL = "select id,Full_name  from User_Info where  status=1 "
            '  'MsgBox("Connection Open ! ")
            cmd3 = New SqlCommand(query, sqlcon)
            '    connect.cmd.CommandTimeout = 60
            ' connect.cmd.ExecuteNonQuery()
            Dim DA As SqlDataAdapter = New SqlDataAdapter(cmd3)
            Dim DataSet As DataSet = New DataSet
            DA.Fill(DataSet)
            For Each row As DataRow In DataSet.Tables(0).Rows
                lotlist.Add(row(0).ToString())
            Next
            cmd3.Dispose()
            cn3.Close()
        Catch ex As Exception
            MessageBox.Show("Can not open connection ! ")
        End Try


    End Sub

    Public Sub conB()
        'sqlcon = New SqlConnection With {.ConnectionString = "server=" & server & "; Database= " & dbname & ";user id= " & dbid & ";password=" & dbpass & ";"}
        sqlcon = New SqlConnection With {.ConnectionString = "server=.\sqlexpress; Database= LupinSC;user id= rmsview;password=rmsview;"}
        Try
            cnb = sqlcon
            cnb.Open()

        Catch ex As Exception
            MsgBox("Can not open connection ! -" & ex.Message)
        End Try

    End Sub


    'Subs with variable database
    Public Sub scon1()
        'server = ".\sqlexpress"
        '    dbname = database
        'dbid = "rms"
        ' dbpass = "rms"
        ' sqlcon = New SqlConnection With {.ConnectionString = "server=" & server & "; Database= " & dbname & ";user id= " & dbid & ";password=" & dbpass & ";"}
        ' sqlcon = New SqlConnection With {.ConnectionString = "server=.\sqlexpress; Database= Pharma;user id= rmsview;password=rmsview;"}
        sqlcon = New SqlConnection With {.ConnectionString = "server=" & server & "; Database= " & dbname & ";user id= " & dbid & ";password=" & dbpass & ";"}

        Try
            scn1 = sqlcon
            scn1.Open()

        Catch ex As Exception
            '  MsgBox("Can not open connection ! -" & ex.Message)
        End Try

    End Sub
    Public Sub scon3()
        '  server = ".\sqlexpress"
        'dbname = database
        'dbid = "rmsview"
        'dbpass = "rmsview"



        ' sqlcon = New SqlConnection With {.ConnectionString = "server=" & server & "; Database= " & dbname & ";user id= " & dbid & ";password=" & dbpass & ";"}
        sqlcon = New SqlConnection With {.ConnectionString = "server=" & server & "; Database= " & dbname & ";user id= " & dbid & ";password=" & dbpass & ";"}

        '  sqlcon = New SqlConnection With {.ConnectionString = "server=.\sqlexpress; Database= Pharma;user id= rmsview;password=rmsview;"}
        '      Try
        scn3 = sqlcon
        '  If scn3.State <> ConnectionState.Open Then
        scn3.Open()
        'MsgBox("1")
        ' End If
        'Catch ex As Exception
        'MsgBox("Can not open connection ! -" & ex.Message)
        'End Try

    End Sub


    Public Sub scon2()
        'server = ".\sqlexpress"
        'dbname = database
        'dbid = "rmsview"
        'dbpass = "rmsview"
        'sqlcon = New SqlConnection With {.ConnectionString = "server=" & server & "; Database= " & dbname & ";user id= " & dbid & ";password=" & dbpass & ";"}
        sqlcon = New SqlConnection With {.ConnectionString = "server=" & server & "; Database= " & dbname & ";user id= " & dbid & ";password=" & dbpass & ";"}

        ' sqlcon = New SqlConnection With {.ConnectionString = "server=.\sqlexpress; Database= Pharma;user id= rmsview;password=rmsview;"}
        Try
            scn2 = sqlcon
            scn2.Open()
        Catch ex As Exception
            MsgBox("Can not open connection ! -" & ex.Message)
        End Try

    End Sub

    Public Sub scon4()
        'server = ".\sqlexpress"
        dbname = database
        dbid = "rmsview"
        dbpass = "rmsview"

        ' sqlcon = New SqlConnection With {.ConnectionString = "server=" & server & "; Database= " & dbname & ";user id= " & dbid & ";password=" & dbpass & ";"}
        sqlcon = New SqlConnection With {.ConnectionString = "server=" & server & "; Database= " & dbname & ";user id= " & dbid & ";password=" & dbpass & ";"}

        '  sqlcon = New SqlConnection With {.ConnectionString = "server=.\sqlexpress; Database= Pharma;user id= rmsview;password=rmsview;"}
        Try
            scn4 = sqlcon
            scn4.Open()
        Catch ex As Exception
            MsgBox("Can not open connection ! -" & ex.Message)
        End Try

    End Sub
    Public Sub scon5()
        'server = ".\sqlexpress"
        'dbname = database
        'dbid = "rmsview"
        'dbpass = "rmsview"
        'sqlcon = New SqlConnection With {.ConnectionString = "server=" & server & "; Database= " & dbname & ";user id= " & dbid & ";password=" & dbpass & ";"}
        sqlcon = New SqlConnection With {.ConnectionString = "server=" & server & "; Database= " & dbname & ";user id= " & dbid & ";password=" & dbpass & ";"}

        ' sqlcon = New SqlConnection With {.ConnectionString = "server=.\sqlexpress; Database= Pharma;user id= rmsview;password=rmsview;"}
        Try
            scn5 = sqlcon
            scn5.Open()
        Catch ex As Exception
            MsgBox("Can not open connection ! -" & ex.Message)
        End Try

    End Sub
    Public Shared Sub rightcon()
        ' sqlcon = New SqlConnection With {.ConnectionString = "server=" & server & "; Database= " & dbname & ";user id= " & dbid & ";password=" & dbpass & ";"}
        ' sqlcon = New SqlConnection With {.ConnectionString = "server=" & server & "; Database= " & dbname & ";user id= " & dbid & ";password=" & dbpass & ";"}

        '  sqlcon = New SqlConnection With {.ConnectionString = "server=.\sqlexpress; Database= Pharma;user id= rmsview;password=rmsview;"}
        '      Try
        If rightcnn Is Nothing Then
            rightcnn = New SqlConnection With {.ConnectionString = "server=" & server & "; Database= " & dbname & ";user id= " & dbid & ";password=" & dbpass & ";"}

        End If


        Try
            If rightcnn.State <> ConnectionState.Open Then
                rightcnn.Open()
                ' MsgBox("1")
            End If
        Catch ex As Exception
        End Try
    End Sub
    Public Sub alternatecolours(ByVal dgv As DataGridView)
        For i = 0 To dgv.Rows.Count - 1 Step 2
            dgv.Rows(i).DefaultCellStyle.BackColor = Color.LightCyan
            If i + 1 <= dgv.Rows.Count - 1 Then
                dgv.Rows(i + 1).DefaultCellStyle.BackColor = Color.MintCream
            End If
        Next
    End Sub




    Public Sub scon9()
        '  server = ".\sqlexpress"
        'dbname = database
        'dbid = "rmsview"
        'dbpass = "rmsview"



        ' sqlcon = New SqlConnection With {.ConnectionString = "server=" & server & "; Database= " & dbname & ";user id= " & dbid & ";password=" & dbpass & ";"}
        ' sqlcon = New SqlConnection With {.ConnectionString = "server=" & server & "; Database= " & dbname & ";user id= " & dbid & ";password=" & dbpass & ";"}

        sqlcon = New SqlConnection With {.ConnectionString = "server=.\sqlexpress; Database= scadatagsystem;user id= rmsview;password=rmsview;"}
        '      Try
        scn3 = sqlcon
        '  If scn3.State <> ConnectionState.Open Then
        scn3.Open()
        'MsgBox("1")
        ' End If
        'Catch ex As Exception
        'MsgBox("Can not open connection ! -" & ex.Message)
        'End Try

    End Sub
End Class

