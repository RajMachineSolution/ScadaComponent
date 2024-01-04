Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Drawing

Public Class EnterReason
    Dim sql As New sqlclass
    Dim ev As New eventlists
    Dim parentt As String
    Dim mename As String
    Dim x = 0, y = 0
    Dim recordmessage1 As String  'record message for audit trail
    Dim oldvalue As String
    Dim newvalue As String
    Dim reason As String
    Dim inserted As Boolean = False

    Dim actionreason = ""
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        insertInAuditTrail()
        ' Me.DialogResult = System.Windows.Forms.DialogResult.OK
        '  Me.Close()
    End Sub
    Sub insertInAuditTrail()
        reason = Trim(TextBox1.Text)
        If reason <> "" Then
            Label6.Text = ""
        Else
            Label6.Text = "Enter Reason!!"
            Label6.ForeColor = Color.Red
            Exit Sub
        End If
        ev.insertscadaevent(Login_Register.empid, actionreason, Login_Register.levelid, recordmessage1, oldvalue & " to " & newvalue, reason, "", "", "", "", Login_Register.lotno, Login_Register.batchno, "Audittrail")
        inserted = True
        Me.Hide()
    End Sub
    Sub New(ByVal p As String, ByVal m As String, ByVal x1 As Integer, ByVal y1 As Integer, ByVal old As String, ByVal newval As String, ByVal recmessage As String, ByVal actionres As String)
        'rec message-recordmessage
        ' This call is required by the designer.
        InitializeComponent()
        parentt = p
        mename = m
        x = x1
        y = y1
        oldvalue = old
        newvalue = newval
        Label2.Text = old
        Label4.Text = newval
        Label5.Text = recmessage
        recordmessage1 = recmessage
        actionreason = actionres
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub EnterReason_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If inserted = False Then
            insertInAuditTrail()
            inserted = False
        End If
    End Sub









    Private Sub EnterReason_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Label6.Text = ""

    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.Click, TextBox1.GotFocus
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
