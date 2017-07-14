Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System
Imports System.IO
Imports System.Security.Cryptography
Imports System.Text
Public Class frmUser
    Private ListView1Sorter As lvColumnSorter
    Dim strConnection As String = My.Settings.ConnStr
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Dim cmd As SqlCommand
    Dim m_UserId As Integer
    Dim isAllowDelete As Boolean
    Private namatable As String, namafieldPK As String
    Private Function kosong()
        ClearObjectonForm(Me)
        AssignValuetoCombo(Me.cmbUserLevelID, "", "user_level_id", "user_level_description", "mt_user_level", "AC=0", "user_level_id")
        AssignValuetoCombo(Me.cmbdept, "", "primarykey", "sys_dropdown_val", "sys_dropdown", "sys_dropdown_whr='unit_user_dept'", "sys_dropdown_sort")
        AssignValuetoCombo(Me.cmbdiv, "", "primarykey", "sys_dropdown_val", "sys_dropdown", "sys_dropdown_whr='unit_user_div'", "sys_dropdown_sort")
        Me.cmbUserLevelID.SelectedIndex = 0 : Me.txtac.Text = 0
        Me.btndelete.Text = "Delete"
        Me.btndelete.Enabled = False : Me.btncancel.Enabled = False
        Me.txtfname.Focus()
    End Function
    Private Function isirecord(ByVal guidno As String)
        Me.txtguid.Text = guidno : Me.txtuserid.Text = guidno
        Fillobject(Me.txtguid, Me.Panel1, "select", "sp_mt_user", Me.txtguid.Text, "@user_id")
        Me.btndelete.Text = IIf(Me.txtac.Text <> 0, "Un-", "") & "Delete"
        'ListView1.Items(k).ForeColor = Color.Black
    End Function
    Private Sub frmUser_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        isAllowDelete = canDelete(Me.Name)
        namatable = "mt_user" : namafieldPK = "user_id"
        If Me.txtuserid.Text = "" Then
            kosong()
        Else
            'isirec
            'kosong()
        End If
    End Sub

    Sub clear_obj()
        m_UserId = 0
        txtUserName.Text = ""
        txtUserPassword.Text = ""
        cmbUserLevelID.SelectedIndex = 0
    End Sub

    Sub lock_obj(ByVal isLock As Boolean)
        txtUserName.ReadOnly = isLock
        txtUserPassword.ReadOnly = isLock
        cmbUserLevelID.Enabled = Not isLock
        If isAllowDelete = True Then btnDelete.Enabled = Not isLock Else btnDelete.Enabled = False
        
        btnSave.Enabled = Not isLock
        btnCancel.Enabled = Not isLock
    End Sub


    Private Sub txtUserPassword_MouseDoubleClick(sender As Object, e As System.Windows.Forms.MouseEventArgs)
        If txtUserPassword.Text <> "" Then MsgBox("Password : " & Me.txtUserPassword.Text, MsgBoxStyle.Information, "User")
    End Sub


    Private Sub txtguid_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtguid.TextChanged
        Dim xno As String
        If Me.txtguid.Text <> "" Then xno = Me.txtguid.Text : isirecord(xno)
    End Sub


    Private Sub btnfind_Click(sender As System.Object, e As System.EventArgs) Handles btnfind.Click
        'If Not CheckAuthor(curlevel, "isallowfilter", "FDLCreateEvent", True) Then Exit Sub
        Dim child As New FDLSearch()
        child.txtopenargs.Text = "2"
        If child.ShowDialog() = DialogResult.OK Then
            kosong()
            Me.txtguid.Text = child.txtChildText0.Text
        End If
    End Sub

    Private Sub btnsave_Click(sender As System.Object, e As System.EventArgs) Handles btnsave.Click
        Try
            If Me.txtguid.Text = "" Then
                'insert
                Me.txtUserName.Text = Microsoft.VisualBasic.Left(Replace(CStr(Me.txtfname.Text), " ", ""), 8) & Format(CDate(Me.DateTimePicker1.Text), "yydd")
                '------------------------BEGIN ENCRYPTING PASSWORD----------------------------
                Dim plainText As String = txtUserPassword.Text
                Dim password As String = "1"

                Dim wrapper As New Dencrypt(password)
                Dim EncryptPass As String = wrapper.EncryptData(plainText)
                Me.txtUserPassword.Text = EncryptPass
                '------------------------END OF ENCRYPTING PASSWORD----------------------------
                Fillobject(Me.txtguid, Me.Panel1, "insert", "sp_mt_user", Me.txtguid.Text, "@user_id")
            Else
                'update
                Fillobject(Me.txtguid, Me.Panel1, "update", "sp_mt_user", Me.txtguid.Text, "@user_id")
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnexit_Click(sender As System.Object, e As System.EventArgs) Handles btnexit.Click
        Me.Close()
    End Sub

    Private Sub btncancel_Click(sender As System.Object, e As System.EventArgs) Handles btncancel.Click
        If Me.txtguid.Text = "" Then

        Else

        End If
    End Sub
    Private Sub btndelete_Click(sender As System.Object, e As System.EventArgs) Handles btndelete.Click
        Try
     
            If MsgBox("Data akan dihapus, lanjutkan ?", vbCritical + vbYesNo, Me.Text) = MsgBoxResult.Yes Then
                'update
                If Me.btndelete.Text = "Un-Delete" Then Me.txtac.Text = 0
                If Fillobject(Me.txtguid, Me.Panel1, "delete", "sp_mt_user", Me.txtguid.Text, "@user_id") Then MsgBox("Data telah dihapus !", MsgBoxStyle.Information, "User")
            Else
                Exit Sub
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnnew_Click(sender As System.Object, e As System.EventArgs) Handles btnnew.Click
        kosong()
    End Sub
End Class