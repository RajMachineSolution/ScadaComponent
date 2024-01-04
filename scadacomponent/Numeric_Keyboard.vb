Imports System.Windows.Forms
Imports System.Data.SqlClient

Public Class Numeric_Keyboard

    Dim tag_id As Integer
    Dim old_val As Double
    Dim Minimum_value As Double
    Dim Maximum_value As Double
    Dim write_gain As Double
    Dim bitType As String
    Dim record_event As String
    Dim Record_message As String
    Dim Record_action_message As String
    'Dim enable_keyboard As Boolean

    Sub New(ByVal tagid As Integer, ByVal previous_val As Double, ByVal min_val As Double, ByVal max_val As Double, ByVal gain As Double, ByVal BIT_TYPE As String, ByVal recordevent As String, ByVal recordmessage As String, ByVal record_actionmessage As String, ByVal show_keyboard As Boolean)

        ' This call is required by the designer.
        InitializeComponent()

        tag_id = tagid
        old_val = previous_val
        Minimum_value = min_val
        Maximum_value = max_val
        write_gain = gain
        bitType = BIT_TYPE
        record_event = recordevent
        Record_message = recordmessage
        Record_action_message = record_actionmessage
        '   enable_keyboard = show_keyboard


        Label1.Text = Minimum_value & " <=  INPUT  <= " & Maximum_value
        If variableclass.enable_keyboard = True Then
            TextBox1.Text = ""
        Else
            TextBox1.Text = ""
        End If


        Label1.Left = 297 - Label1.Width
        Label2.Text = ""
        '  TextBox1.Focus()
        ' Add any initialization after the InitializeComponent() call.

    End Sub

   



    Private Sub ButtonZERO_Click(sender As System.Object, e As System.EventArgs) Handles ButtonZERO.Click
        Try
            TextBox1.Focus()
            SendKeys.Send("0")
            ' textbox1.AppendText("0")
        Catch txt As NullReferenceException

        End Try
    End Sub

    Private Sub ButtonSEVEN_Click(sender As System.Object, e As System.EventArgs) Handles ButtonSEVEN.Click
        Try
            TextBox1.Focus()
            SendKeys.Send("7")
            '  textbox1.AppendText("1")
        Catch txt As NullReferenceException

        End Try
    End Sub

    Private Sub ButtonTWO_Click(sender As System.Object, e As System.EventArgs) Handles ButtonTWO.Click
        Try
            TextBox1.Focus()
            SendKeys.Send("2")
            ' textbox1.AppendText("2")
            ' TextBox1.Text = TextBox1.Text & "0"
        Catch txt As NullReferenceException

        End Try
    End Sub

    Private Sub ButtonTHREE_Click(sender As System.Object, e As System.EventArgs) Handles ButtonTHREE.Click
        Try
            TextBox1.Focus()
            SendKeys.Send("3")
            ' textbox1.AppendText("3")
            ' TextBox1.Text = TextBox1.Text & "0"
        Catch txt As NullReferenceException

        End Try
    End Sub

    Private Sub ButtonFOUR_Click(sender As System.Object, e As System.EventArgs) Handles ButtonFOUR.Click
        Try
            TextBox1.Focus()
            SendKeys.Send("4")
            'textbox1.AppendText("4")
            ' TextBox1.Text = TextBox1.Text & "0"
        Catch txt As NullReferenceException

        End Try
    End Sub

    Private Sub ButtonFIVE_Click(sender As System.Object, e As System.EventArgs) Handles ButtonFIVE.Click
        Try
            TextBox1.Focus()
            SendKeys.Send("5")
            'textbox1.AppendText("5")
            ' TextBox1.Text = TextBox1.Text & "0"
        Catch txt As NullReferenceException

        End Try
    End Sub

    Private Sub ButtonSIX_Click(sender As System.Object, e As System.EventArgs) Handles ButtonSIX.Click
        Try
            TextBox1.Focus()
            SendKeys.Send("6")
            'textbox1.AppendText("6")
            ' TextBox1.Text = TextBox1.Text & "0"
        Catch txt As NullReferenceException

        End Try
    End Sub

    Private Sub ButtonONE_Click(sender As System.Object, e As System.EventArgs) Handles ButtonONE.Click
        Try
            TextBox1.Focus()
            SendKeys.Send("1")
            'textbox1.AppendText("7")
            ' TextBox1.Text = TextBox1.Text & "0"
        Catch txt As NullReferenceException

        End Try
    End Sub

    Private Sub ButtonEIGHT_Click(sender As System.Object, e As System.EventArgs) Handles ButtonEIGHT.Click
        Try
            TextBox1.Focus()
            SendKeys.Send("8")
            'textbox1.AppendText("8")
            ' TextBox1.Text = TextBox1.Text & "0"
        Catch txt As NullReferenceException

        End Try
    End Sub

    Private Sub ButtonNINE_Click(sender As System.Object, e As System.EventArgs) Handles ButtonNINE.Click
        Try
            TextBox1.Focus()
            SendKeys.Send("9")
            'textbox1.AppendText("9")
            ' TextBox1.Text = TextBox1.Text & "0"
        Catch txt As NullReferenceException

        End Try
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Try
            ' TextBox1.Focus()
            If TextBox1.Text.Contains(".") Then
            Else
                SendKeys.Send(".")
                TextBox1.Focus()
            End If

            ' TextBox1.AppendText(".")
            ' TextBox1.Text = TextBox1.Text & "0"
        Catch txt As NullReferenceException

        End Try
    End Sub

    Private Sub Button5_Click(sender As System.Object, e As System.EventArgs) Handles Button5.Click
        TextBox1.Focus()
        SendKeys.Send("{backspace}")
    End Sub

    Private Sub Button6_Click(sender As System.Object, e As System.EventArgs) Handles Button6.Click
        TextBox1.Text = ""
    End Sub

    Dim keyboard_key_press_first_time = 0

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        'If keyboard_key_press_first_time = 0 Then
        '    TextBox1.Focus()
        '    TextBox1.SelectionStart = TextBox1.Text.Length
        '    keyboard_key_press_first_time = 1
        'End If
        '97 - 122 = Ascii codes for simple letters
        '65 - 90  = Ascii codes for capital letters
        '48 - 57  = Ascii codes for numbers
        '46 .
        '45 -
        If Val(Asc(e.KeyChar)) = 8 Then

        ElseIf Val(Asc(e.KeyChar)) = 46 Then
            If TextBox1.Text.Contains(".") Then
                e.Handled = True
                Exit Sub
            End If
        ElseIf Asc(e.KeyChar) = 43 Then
            If TextBox1.Text.Contains("-") Then
                TextBox1.Text = TextBox1.Text.Remove(0, 1)
                TextBox1.SelectionStart = TextBox1.Text.Length
            End If
            e.Handled = True
        ElseIf Asc(e.KeyChar) = 45 Then
            If TextBox1.Text.Contains("-") Then
                e.Handled = True
                Exit Sub
            Else
                TextBox1.Text = "-" & TextBox1.Text
                TextBox1.SelectionStart = TextBox1.Text.Length
                e.Handled = True
                Exit Sub

                'End If
            End If
        ElseIf (Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57) Then
            e.Handled = True
            '  End If
        End If
    End Sub


    Dim temp_variable_to_close_keyboard = 0


    Private Sub Button9_Click(sender As System.Object, e As System.EventArgs) Handles Button9.Click
        write_values_in_database()
        If temp_variable_to_close_keyboard = 0 Then
            Me.Close()
        End If
    End Sub


    Private Sub TextBox1_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyDown
        ' TextBox1.Focus()
        If e.KeyCode = Keys.Enter Then
            write_values_in_database()
            If temp_variable_to_close_keyboard = 0 Then
                Me.Close()
            End If
        ElseIf e.KeyCode = Keys.A Then
        End If
    End Sub

    'write numeric entry value in database 
    Sub write_values_in_database()
        temp_variable_to_close_keyboard = 0
        ' Dim value_to_record
        If TextBox1.Text = "" Or TextBox1.Text Is Nothing Then
            temp_variable_to_close_keyboard = 1
            Label2.Text = "Enter Value!"
            'MessageBox.Show("Enter Value!")
            Exit Sub
        End If
        If Double.Parse(Val(TextBox1.Text)) >= Minimum_value And Double.Parse(Val(TextBox1.Text)) <= Maximum_value Then
        Else
            'MsgBox("Enter Correct value in a range " & Minimum_value & " to " & Maximum_value)
            Label2.Text = "Enter value in a range " & Minimum_value & " to " & Maximum_value
            temp_variable_to_close_keyboard = 1
            Exit Sub
        End If

        'get bumeric ebtry bit type 
        If bitType = "16BIT" Then
            Dim tempvtw = Val(TextBox1.Text) * write_gain
            '  value_to_record = tempvtw
            Try
                If tempvtw >= -32768 And tempvtw <= 32767 Then
                    'first reson entered then move ahed
                    If record_event = "WithMessageInAuditTrail" Then
                        '      ev.insertscadaevent(Login_Register.empid, "Button Pressed", Login_Register.levelid, Me.RecordMessage, "", "", "", "", "", "", "", "", "Audittrail")
                        '--popo messagebox for msg record
                        If Label1.Text <> TextBox1.Text Then
                            Dim btnp As New EnterReason(Me.Name, Me.Name, Me.Location.X, Me.Location.Y, old_val, TextBox1.Text, Record_message, Record_action_message)
                            btnp.TopMost = True
                            btnp.ShowDialog()
                        End If
                    End If
                    writeIndb(tag_id, tempvtw, tempvtw)
                Else
                    TextBox1.Text = old_val
                    Label2.Text = "Value Overflow!"
                    'MessageBox.Show("Value Overflow", "Alert")
                    temp_variable_to_close_keyboard = 1
                    Exit Sub
                End If
            Catch ex As ArithmeticException
                TextBox1.Text = old_val
                Label2.Text = "Value Overflow"
                'MessageBox.Show("Value Overflow", "Alert")
                temp_variable_to_close_keyboard = 1
                Exit Sub
            End Try
        ElseIf bitType = "32BIT" Then
            '32 bit to 16 bit converterssss
            Dim Byte_Arr(3) As Byte
            Try
                Dim tempval_to_write = Convert.ToInt32(Val(TextBox1.Text) * write_gain)
                Byte_Arr = BitConverter.GetBytes(Convert.ToInt32(Val(TextBox1.Text) * write_gain))
                Dim value_to_write As String = BitConverter.ToInt16(Byte_Arr, 0) & "," & BitConverter.ToInt16(Byte_Arr, 2)
                'first reson entered then move ahed
                If record_event = "WithMessageInAuditTrail" Then
                    '      ev.insertscadaevent(Login_Register.empid, "Button Pressed", Login_Register.levelid, Me.RecordMessage, "", "", "", "", "", "", "", "", "Audittrail")
                    '--popo messagebox for msg record
                    If Label1.Text <> TextBox1.Text Then
                        Dim btnp As New EnterReason(Me.Name, Me.Name, Me.Location.X, Me.Location.Y, old_val, TextBox1.Text, Record_message, Record_action_message)
                        btnp.TopMost = True
                        btnp.ShowDialog()
                    End If
                End If
                '  value_to_record = tempval_to_write
                writeIndb(tag_id, value_to_write, tempval_to_write)
            Catch ex As ArithmeticException
                Label2.Text = "Value Overflow!"
                'MessageBox.Show("Value Overflow", "Alert")
                temp_variable_to_close_keyboard = 1
                Exit Sub
            End Try
        End If

        If record_event = "DirectlyInAuditTrail" Then
            If Label1.Text <> TextBox1.Text Then
                Dim ev As New eventlists
                ev.insertscadaevent(Login_Register.empid, Record_action_message, Login_Register.levelid, Record_message, old_val & " to " & TextBox1.Text, "", "", "", "", "", Login_Register.lotno, Login_Register.batchno, "Audittrail")
            End If
        End If
    End Sub

    Dim sql As New scadacomponent.sqlclass

    ''Sub writeIndb(ByVal address As Integer, ByVal value As String)
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


    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        If TextBox1.Text = "" Then
            TextBox1.Text = "-"
        Else
            If TextBox1.Text.Contains("-") Then
                TextBox1.Text = TextBox1.Text.Remove(0, 1)
            Else
                TextBox1.Text = "-" & TextBox1.Text
            End If
        End If
        TextBox1.Focus()
        TextBox1.SelectionStart = TextBox1.Text.Length
    End Sub

    Private Sub Numeric_Keyboard_Activated(sender As Object, e As System.EventArgs) Handles Me.Activated
        TextBox1.Focus()
    End Sub


    'Private Sub Numeric_Keyboard_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
    '    TextBox1.Focus()
    '    TextBox1.SelectionStart = TextBox1.Text.Length
    'End Sub

    Private Sub Button8_Click(sender As System.Object, e As System.EventArgs) Handles Button8.Click
        SendKeys.Send("{LEFT}")
        TextBox1.Focus()
    End Sub

    Private Sub Button7_Click(sender As System.Object, e As System.EventArgs) Handles Button7.Click
        TextBox1.Focus()
        SendKeys.Send("{RIGHT}")
    End Sub

    Private Sub Numeric_Keyboard_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Activate()
        Me.Show()
        If variableclass.enable_keyboard = True Then
            Me.Height = 356
            TextBox1.Enabled = True
        Else

            Me.Height = 116
            TextBox1.Enabled = True
        End If

        TextBox1.Focus()
        TextBox1.SelectionStart = TextBox1.Text.Length
    End Sub
End Class