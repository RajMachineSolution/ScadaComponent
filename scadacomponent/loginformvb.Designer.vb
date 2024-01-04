<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class loginformvb
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Login_Register1 = New scadacomponent.Login_Register()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Login_Register1
        '
        Me.Login_Register1.AdminstratorRightsLevel = "Admin"
        Me.Login_Register1.ALarmAction = New String(-1) {}
        Me.Login_Register1.Alarmlist = New String(-1) {}
        Me.Login_Register1.database = ""
        Me.Login_Register1.database_name = "scadatagsystem"
        Me.Login_Register1.Database_Password = "rmsview"
        Me.Login_Register1.Database_UserID = "rmsview"
        Me.Login_Register1.EventName = New String(-1) {}
        Me.Login_Register1.IdealLogoutTimeOFScada = 0
        Me.Login_Register1.Location = New System.Drawing.Point(1, 87)
        Me.Login_Register1.MinimumPasswordLength = 0
        Me.Login_Register1.MinimumUseridLength = 0
        Me.Login_Register1.Name = "Login_Register1"
        Me.Login_Register1.PasswordExpire = False
        Me.Login_Register1.PasswordExpireday = 0
        Me.Login_Register1.PasswordLowerCase = 0
        Me.Login_Register1.PasswordNumericCharacter = 0
        Me.Login_Register1.PasswordSpecialCharacter = 0
        Me.Login_Register1.PasswordUpperCase = 0
        Me.Login_Register1.Previous_password_Checkcount = 0
        Me.Login_Register1.RecordloginAction = True
        Me.Login_Register1.Server_Name = ".\sqlexpress"
        Me.Login_Register1.Size = New System.Drawing.Size(316, 317)
        Me.Login_Register1.TabIndex = 0
        Me.Login_Register1.Userlevel = New String(-1) {}
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.White
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.749999!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(30, 57)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 16)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "Level - NA"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.749999!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(28, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(93, 16)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Hello Guest!"
        '
        'loginformvb
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(322, 457)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Login_Register1)
        Me.Name = "loginformvb"
        Me.Text = "loginformvb"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Login_Register1 As scadacomponent.Login_Register
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
