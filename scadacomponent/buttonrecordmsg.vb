Imports System.Drawing
Imports System.Windows.Forms

Public Class buttonrecordmsg
    Dim temprecordaction
    Dim temptype
    Dim actionreason = ""
    Sub New(ByVal type As String, ByVal msg As String, ByVal actionres As String)

        ' This call is required by the designer.
        InitializeComponent()
        temprecordaction = msg
        temptype = type
        actionreason = actionres
        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Private Sub OK_Button_Click(sender As System.Object, e As System.EventArgs) Handles OK_Button.Click
        insertInAuditTrail()
    End Sub
    Sub insertInAuditTrail()
        Dim reason = Trim(TextBox1.Text)
        Dim ev As New eventlists
        If reason <> "" Then
            Label2.Text = ""
        Else
            Label2.Text = "Enter Reason!!"
            Label2.ForeColor = Color.Red
            Exit Sub
        End If
        ev.insertscadaevent(Login_Register.empid, actionreason, Login_Register.levelid, temprecordaction, temptype, reason, "", "", "", "", Login_Register.lotno, Login_Register.batchno, "Audittrail")
        ' inserted = True
        Me.Hide()
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub buttonrecordmsg_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.StartPosition = FormStartPosition.CenterParent
        Label2.Text = ""
    End Sub


    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.Click, TextBox1.GotFocus
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
End Class