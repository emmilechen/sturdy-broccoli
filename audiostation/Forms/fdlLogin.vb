Imports System.Data.SqlClient
Imports System.Data.OleDb
Public Class fdlLogin
    Dim strConnection As String = My.Settings.ConnStr
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Dim cmd As SqlCommand
    Dim isPassed As Boolean
    Private Sub fdlLogin_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If isPassed = False Then End
        Me.Dispose()
    End Sub
    Private Sub fdlLogin_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim lokasiupd As String = Format(getfiledate(My.Settings.AppLoc & "\" & My.Settings.AppName), "yyyyMMddHHmmss")
        Dim lokasicur As String = Format(getfiledate(Application.StartupPath & "\" & My.Settings.AppName), "yyyyMMddHHmmss")
        If lokasicur < lokasiupd Then
            If MsgBox("Program harap diperbaharui !", MsgBoxStyle.YesNo + MsgBoxStyle.Question, UCase(My.Settings.AppName)) = MsgBoxResult.Yes Then
                Process.Start(Application.StartupPath & "\Updater.exe") : Me.Close() 'run 1 app buat copy dan replace file dilokasi current
            Else

            End If
        End If
        Me.TextBox2.Enabled = False : Me.Button1.Enabled = False : Me.TextBox2.BackColor = Color.Gray : Me.Button1.BackColor = Color.Gray
        Label3.Text = "App " & lokasicur
        Label4.Text = "DB " & GetSysInit("db_version") : Me.TextBox1.Select()
        ' Me.Text = BulanAbjad(Now.Date)
    End Sub
    Private Sub TextBox1_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyCode = 13 Then Me.TextBox2.Select()
        If e.KeyCode = Keys.Right Then Me.TextBox2.Select()
    End Sub
    Private Sub TextBox1_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox1.TextChanged
        If CountRecordnya("user_name", "mt_user", "user_name='" & Me.TextBox1.Text & "'", True) = 1 Then
            Me.TextBox2.Enabled = True
            Me.TextBox2.BackColor = Color.DarkCyan
        Else
            Me.TextBox2.Enabled = False
            Me.Button1.Enabled = False
            Me.Button1.BackColor = Color.Gray
        End If
    End Sub
    Private Sub TextBox2_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TextBox2.KeyDown
        If e.KeyCode = 13 Then Me.Button1.Focus()
        If e.KeyCode = Keys.Right Then Me.Button1.Focus()
        If e.KeyCode = Keys.Left Then Me.TextBox1.Select()
    End Sub
    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim strConnection As String = My.Settings.ConnStr
        Dim cn As SqlConnection = New SqlConnection(strConnection)
        Dim cmd As SqlCommand = New SqlCommand("usp_mt_user_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm As SqlParameter = cmd.Parameters.Add("@user_name", SqlDbType.NVarChar, 50)
        prm.Value = CStr(Me.TextBox1.Text)

        cn.Open()

        Dim myReader As SqlDataReader = cmd.ExecuteReader()
        'Dim passwd As String
        If Not myReader.HasRows Then
            MsgBox("There is no username found. Please contact your administrator!", vbOKOnly + vbCritical, "Login")
        Else
            'Console.WriteLine("{0},{1}", myReader.GetName(1), myReader.GetName(2))
            myReader.Read()
            '-------------------------DECRYPT FROM DB-------------------------------
            Dim cipherText As String = myReader.GetString(2)
            Dim password As String = "1"
            Dim wrapper As New Dencrypt(password)
            Dim LoginPassword As String = wrapper.DecryptData(cipherText)
            '-------------------------END OF DECRYPT--------------------------------
            If TextBox2.Text <> LoginPassword Then
                MsgBox("Wrong password. Please contact your administrator!", vbOKOnly + vbCritical, "Login")
                TextBox2.Text = ""
            Else
                Me.Cursor = Cursors.WaitCursor
                frmMAIN.ToolStripStatusLabel.Text = "User login: " & TextBox1.Text & "; User level: " & myReader.GetString(4)
                My.Settings.UserName = myReader.GetString(1)
                My.Settings.UserID = GetCurrentID("user_id", "mt_user", "user_name='" & myReader.GetString(1) & "'")
                My.Settings.Save()
                p_UserLevel = myReader.GetInt32(3)
                'str_user_name = myReader.GetString(1)
                'str_user_access = myReader.GetString(3)
                isPassed = True
                Me.Close()

                myReader.Close()

                cmd = New SqlCommand("usp_sys_company_SEL", cn)
                cmd.CommandType = CommandType.StoredProcedure

                prm = cmd.Parameters.Add("@company_id", SqlDbType.Int)
                prm.Value = 1

                myReader = cmd.ExecuteReader()
                While myReader.Read
                    p_CompanyName = myReader.GetString(2)
                End While
                frmMAIN.Text = frmMAIN.Text & " - " & p_CompanyName
                InsertLogFile("Login", "Login ", My.Computer.Name, Me.Name, Me.TextBox1.Text)
                Me.Cursor = Cursors.Default
            End If

        End If
        myReader.Close()
        cn.Close()
    End Sub
    Private Sub TextBox2_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox2.TextChanged
        '------------------------BEGIN ENCRYPTING PASSWORD----------------------------
        Dim plainText As String = Me.TextBox2.Text
        Dim password As String = "1"
        Dim wrapper As New Dencrypt(password)
        Dim EncryptPass As String = wrapper.EncryptData(plainText)
        '------------------------END OF ENCRYPTING PASSWORD----------------------------
        If CountRecordnya("user_id", "mt_user", "user_name='" & Me.TextBox1.Text & "' and user_password='" & EncryptPass & "'", True) = 1 Then
            'Me.TextBox2.BackColor = Color.Bisque
            Me.Button1.Enabled = True
            Me.Button1.BackColor = Color.Turquoise
        Else
            'Me.TextBox2.BackColor = Color.Gray
            Me.Button1.Enabled = False
            Me.Button1.BackColor = Color.Gray
        End If
    End Sub
End Class