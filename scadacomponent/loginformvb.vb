Public Class loginformvb
    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        AddHandler Login_Register1.Logon, AddressOf login_sucessfull
    End Sub
    Dim lgn As New Login

    Public Sub login_sucessfull(ByVal empid, ByVal Fname, ByVal plevel)

        If empid = -1 Then
            scadacomponent.Login_Register.plevel = 0
            scadacomponent.Login_Register.levelid = 0
            Label1.Text = "Hello "
            Label2.Text = ""
            Label1.Text = "Hello Guest User!"
            Label2.Text = "NA"
        Else
            Label1.Text = "Hello " & Fname
            Label2.Text = Login_Register.levelname
        End If
        lgn.loginsuccess(empid, Fname, plevel)
    End Sub


End Class