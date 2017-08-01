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

        AssignValuetoCombo(Me.ComboBox1, "", "form_name", "form_description", "mt_form", "form_name<>''", "form_description")
        AssignValuetoCombo(Me.ComboBox2, "", "name", "name", "sys.tables", "name<>''", "name")
        'select COLUMN_NAME from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME = 'Customer'
        'AssignValuetoCombo(Me.ComboBox3, "", "COLUMN_NAME", "COLUMN_NAME", "INFORMATION_SCHEMA.COLUMNS", "TABLE_NAME='" & Me.ComboBox2.SelectedValue & "'", "COLUMN_NAME")
        AssignValuetoCombo(Me.ComboBox4, "", "user_level_id", "user_level_id", "mt_user_level", "user_level_id>0", "user_level_id")
        AssignValuetoCombo(Me.ComboBox5, "", "user_id", "user_fname", "mt_user", "user_id>0", "user_id")
        Me.TextBox1.Text = 0
        Me.cmbUserLevelID.SelectedIndex = 0 : Me.txtac.Text = 0
        Me.btndelete.Text = "Delete"
        Me.btndelete.Enabled = False : Me.btncancel.Enabled = False
        Me.TabControl1.SelectedTab = TabPage1
        With Me 'formname=@formname, fieldname=@fieldname, signlevelid=@signlevelid, userid=@userid
            .ListView1.Columns.Clear()
            .ListView1.Columns.Add("Kolom 0", "guid", 0)
            .ListView1.Columns.Add("Kolom 1", "formid", 0)
            .ListView1.Columns.Add("Kolom 2", "formname", Me.ComboBox1.Width + 5)
            .ListView1.Columns.Add("Kolom 3", "tablename", Me.ComboBox2.Width + 10)
            .ListView1.Columns.Add("Kolom 4", "fieldname", Me.ComboBox2.Width + 10)
            .ListView1.Columns.Add("Kolom 5", "signlevelid", Me.TextBox4.Width + 5)
            .ListView1.Columns.Add("Kolom 6", "userid", 0)
            .ListView1.Columns.Add("Kolom 7", "username", Me.ComboBox4.Width + 5)
        End With
        Me.ListView1.Items.Clear()
        opensearchform(Me.ListView1, "rt_form_id", "formname", "tablename, fieldname, signlevelid, userid", "rt_form_sign", "rt_form_sign.userid in ('" & Me.txtguid.Text & "')", "formname", 0)

        Me.txtfname.Focus()
    End Function
    Private Function isirecord(ByVal guidno As String)
        Me.txtguid.Text = guidno : Me.txtuserid.Text = guidno
        Fillobject(Me.txtguid, Me.TabPage1, "select", "sp_mt_user", Me.txtguid.Text, "@user_id")
        Me.btndelete.Text = IIf(Me.txtac.Text <> 0, "Un-", "") & "Delete"
        'ListView1.Items(k).ForeColor = Color.Black
    End Function
    Private Function opensearchform(ByVal namalistview As ListView, ByVal strfield1 As String, ByVal strfield2 As String, ByVal strfield3 As String, ByVal strtabel As String, ByVal strwhr As String, ByVal strord As String, Optional openargs As Integer = 0) As String
        'On Error Resume Next
        Dim cmd As SqlCommand
        Dim str(10) As String, strsql As String
        Dim itm As ListViewItem
        Dim dr As SqlDataReader
        If cn.State = ConnectionState.Closed Then cn.Open()
        With namalistview
            .Items.Clear()
            strsql = "SELECT " & strfield1 & ", " & strfield2 & ", " & strfield3 & " FROM " & strtabel & " where " & strwhr & " order by " & strord
            cmd = New SqlCommand(strsql, cn)
            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                Do While dr.Read() 'SELECT rt_form_id, formname, tablename, fieldname, signlevelid, userid FROM rt_form_sign where rt_form_sign.userid in ('1') order by formname
                    str(0) = IIf(IsDBNull(dr.Item(0).ToString()), "#", dr.Item(0).ToString()) 'guid
                    str(1) = IIf(IsDBNull(dr.Item(1).ToString()), "#", dr.Item(1).ToString()) 'formid
                    str(2) = GetCurrentID("form_description", "mt_form", "form_name='" & dr.Item(1).ToString() & "'") 'formname
                    str(3) = IIf(IsDBNull(dr.Item(2).ToString()), "#", dr.Item(2).ToString()) 'tablename
                    str(4) = IIf(IsDBNull(dr.Item(3).ToString()), "#", dr.Item(3).ToString()) 'fieldname
                    str(5) = IIf(IsDBNull(dr.Item(4).ToString()), "#", dr.Item(4).ToString()) 'signlevelid
                    str(6) = IIf(IsDBNull(dr.Item(5).ToString()), "#", dr.Item(5).ToString()) 'userid
                    str(7) = GetCurrentID("user_fname", "mt_user", "user_id=" & dr.Item(5).ToString()) 'username
                    itm = New ListViewItem(str)
                    .Items.Add(itm)
                Loop
            End If
            dr.Close()
            cmd.Dispose()
        End With
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


    Private Sub btnfind_Click(sender As System.Object, e As System.EventArgs) Handles btnfind.Click
        'If Not CheckAuthor(curlevel, "isallowfilter", "FDLCreateEvent", True) Then Exit Sub
        Dim child As New FDLSearch()
        child.txtopenargs.Text = "2"
        If child.ShowDialog() = DialogResult.OK Then
            'kosong()
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
                Fillobject(Me.txtguid, Me.TabPage1, "insert", "sp_mt_user", Me.txtguid.Text, "@user_id")
            Else
                'update
                Fillobject(Me.txtguid, Me.TabPage1, "update", "sp_mt_user", Me.txtguid.Text, "@user_id")
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
                If Fillobject(Me.txtguid, Me.TabPage1, "delete", "sp_mt_user", Me.txtguid.Text, "@user_id") Then MsgBox("Data telah dihapus !", MsgBoxStyle.Information, "User")
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
    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Fillobject(Me.TextBox1, Me.TabPage2, "insert", "sp_rt_form_sign", Me.TextBox1.Text, "@user_id")
        opensearchform(Me.ListView1, "rt_form_id", "formname", "tablename, fieldname, signlevelid, userid", "rt_form_sign", "rt_form_sign.userid in ('" & Me.txtguid.Text & "')", "formname", 0)

    End Sub


    Private Sub ListView1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ListView1.SelectedIndexChanged
        If ListView1.SelectedItems.Count > 0 Then
            'Str(0) = IIf(IsDBNull(dr.Item(0).ToString()), "#", dr.Item(0).ToString()) 'guid
            'Str(1) = IIf(IsDBNull(dr.Item(1).ToString()), "#", dr.Item(1).ToString()) 'formid
            'Str(2) = GetCurrentID("form_description", "mt_form", "form_name='" & dr.Item(1).ToString() & "'") 'formname
            'Str(3) = IIf(IsDBNull(dr.Item(3).ToString()), "#", dr.Item(3).ToString()) 'tablename
            'Str(4) = IIf(IsDBNull(dr.Item(4).ToString()), "#", dr.Item(4).ToString()) 'fieldname
            'Str(5) = IIf(IsDBNull(dr.Item(5).ToString()), "#", dr.Item(5).ToString()) 'signlevelid
            'Str(6) = IIf(IsDBNull(dr.Item(6).ToString()), "#", dr.Item(6).ToString()) 'userid
            'Str(7) = GetCurrentID("user_fname", "mt_user", "user_id=" & dr.Item(6).ToString()) 'username
            Me.TextBox1.Text = Me.ListView1.Items(ListView1.FocusedItem.Index).Text
            Me.ComboBox1.SelectedValue = Me.ListView1.Items(ListView1.FocusedItem.Index).SubItems(1).Text
            'Me.TextBox4.Text = Me.ListView1.Items(ListView1.FocusedItem.Index).SubItems(2).Text
            Me.ComboBox2.SelectedValue = Me.ListView1.Items(ListView1.FocusedItem.Index).SubItems(3).Text
            'Me.ComboBox3.SelectedValue = Me.ListView1.Items(ListView1.FocusedItem.Index).SubItems(4).Text
            Me.ComboBox4.SelectedValue = Me.ListView1.Items(ListView1.FocusedItem.Index).SubItems(5).Text
            Me.ComboBox5.SelectedValue = Me.ListView1.Items(ListView1.FocusedItem.Index).SubItems(6).Text
     
        End If
    End Sub

    Private Sub txtguid_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtguid.TextChanged
        Dim xno As String
        If Me.txtguid.Text <> "" Then xno = Me.txtguid.Text : isirecord(xno)
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged
        'COLUMN_NAME from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME = 'Customer'
        If Me.txtguid.Text = "" Then Exit Sub
        If Me.ComboBox2.SelectedIndex >= 0 Then autocompleteteks(Me.TextBox4, "distinct COLUMN_NAME", "INFORMATION_SCHEMA.COLUMNS", "TABLE_NAME in ('" & ComboBox2.SelectedValue & "')", "COLUMN_NAME")
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        Select Case TabControl1.SelectedIndex
            Case Is = 0
                'Me.ToolStripStatusLabel6.Text = "-"
            Case Is = 1
                opensearchform(Me.ListView1, "rt_form_id", "formname", "tablename, fieldname, signlevelid, userid", "rt_form_sign", "rt_form_sign.userid in ('" & Me.txtguid.Text & "')", "formname", 0)
        End Select
    End Sub
End Class