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
        With Me
            .ListView1.Columns.Clear()
            .ListView1.Columns.Add("Kolom 0", "guid", 0)
            .ListView1.Columns.Add("Kolom 1", "ID", Me.TextBox9.Width + 5)
            .ListView1.Columns.Add("Kolom 2", "Field", Me.TextBox1.Width + 5)
            .ListView1.Columns.Add("Kolom 3", "Table", Me.TextBox4.Width + 5)
            .ListView1.Columns.Add("Kolom 4", "Where", Me.TextBox7.Width + 5)
            .ListView1.Columns.Add("Kolom 5", "Order by", Me.TextBox8.Width + 5)
            .ListView1.Columns.Add("Kolom 6", "Form Name", Me.TextBox12.Width + 5)
            .ListView1.Columns.Add("Kolom 7", "PK ID", Me.TextBox13.Width + 5)
            .ListView1.Columns.Add("Kolom 8", "Title", Me.TextBox14.Width + 5)
            .ListView1.Items.Clear()
        End With
        
        Me.cmbUserLevelID.SelectedIndex = 0 : Me.txtac.Text = 0
        Me.btndelete.Text = "Delete"
        Me.btndelete.Enabled = False : Me.btncancel.Enabled = False
        Me.TabControl1.SelectedTab = TabPage1
        Me.TabPage2.Enabled = False
        Me.txtfname.Focus()
    End Function
    Private Function isirecord(ByVal guidno As String)
        Me.txtguid.Text = guidno : Me.txtuserid.Text = guidno
        Fillobject(Me.txtguid, Me.TabPage1, "select", "sp_mt_user", Me.txtguid.Text, "@c_id")
        Me.TextBox11.Text = Me.txtguid.Text
        opensearchform(Me.ListView1, "pk_spotid", "spotid", "fieldname, tablename, condname, seqname, formnamep, pkidp, spotcaption", "rt_spotdashboard", "useridh='" & Me.txtguid.Text & "' AND spotid>0", "spotid", 0)
        Me.btndelete.Text = IIf(Me.txtac.Text <> 0, "Un-", "") & "Delete"
        Me.Text = "User - " & UCase(Me.txtfname.Text)
        Me.TabPage2.Enabled = True
        'ListView1.Items(k).ForeColor = Color.Black
    End Function
    'Private Function opensearchform(ByVal namalistview As ListView, ByVal strfield1 As String, ByVal strfield2 As String, ByVal strfield3 As String, ByVal strtabel As String, ByVal strwhr As String, ByVal strord As String, Optional openargs As Integer = 0) As String
    '    'On Error Resume Next
    '    Dim cmd As SqlCommand
    '    Dim str(10) As String, strsql As String
    '    Dim itm As ListViewItem
    '    Dim dr As SqlDataReader
    '    If cn.State = ConnectionState.Closed Then cn.Open()
    '    With namalistview
    '        .Items.Clear()
    '        strsql = "SELECT " & strfield1 & ", " & strfield2 & ", " & strfield3 & " FROM " & strtabel & " where " & strwhr & " order by " & strord
    '        cmd = New SqlCommand(strsql, cn)
    '        dr = cmd.ExecuteReader()
    '        If dr.HasRows Then
    '            Do While dr.Read() 'SELECT rt_form_id, formname, tablename, fieldname, signlevelid, userid FROM rt_form_sign where rt_form_sign.userid in ('1') order by formname
    '                str(0) = IIf(IsDBNull(dr.Item(0).ToString()), "#", dr.Item(0).ToString()) 'guid
    '                str(1) = IIf(IsDBNull(dr.Item(1).ToString()), "#", dr.Item(1).ToString()) 'formid
    '                str(2) = GetCurrentID("form_description", "mt_form", "form_name='" & dr.Item(1).ToString() & "'") 'formname
    '                str(3) = IIf(IsDBNull(dr.Item(2).ToString()), "#", dr.Item(2).ToString()) 'tablename
    '                str(4) = IIf(IsDBNull(dr.Item(3).ToString()), "#", dr.Item(3).ToString()) 'fieldname
    '                str(5) = IIf(IsDBNull(dr.Item(4).ToString()), "#", dr.Item(4).ToString()) 'signlevelid
    '                str(6) = IIf(IsDBNull(dr.Item(5).ToString()), "#", dr.Item(5).ToString()) 'userid
    '                str(7) = GetCurrentID("user_fname", "mt_user", "user_id=" & dr.Item(5).ToString()) 'username
    '                itm = New ListViewItem(str)
    '                .Items.Add(itm)
    '            Loop
    '        End If
    '        dr.Close()
    '        cmd.Dispose()
    '    End With
    'End Function
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
            If MsgBox("Data akan disimpan, lajutkan ?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "User") = MsgBoxResult.Yes Then
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
                    Fillobject(Me.txtguid, Me.TabPage1, "insert", "sp_mt_user", Me.txtguid.Text, "@c_id")
                    MsgBox("Data telah disimpan !", MsgBoxStyle.Information, "User")
                Else
                    'update
                    Fillobject(Me.txtguid, Me.TabPage1, "update", "sp_mt_user", Me.txtguid.Text, "@c_id")
                    MsgBox("Data telah disimpan ulang !", MsgBoxStyle.Information, "User")
                End If
            Else

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
            Exit Sub
        Else
            isirecord(Me.txtguid.Text)
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
    Private Sub txtguid_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtguid.TextChanged
        Dim xno As String
        If Me.txtguid.Text <> "" Then xno = Me.txtguid.Text : isirecord(xno)
    End Sub

    

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        Select Case TabControl1.SelectedIndex
            Case Is = 0
                'Me.ToolStripStatusLabel6.Text = "-"
            Case Is = 1
        End Select
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub btnSaveD_Click(sender As System.Object, e As System.EventArgs) Handles btnSaveD.Click
        If TextBox9.Text = "" Or TextBox1.Text = "" Or TextBox4.Text = "" Or TextBox7.Text = "" Then
            MsgBox("ID, Field and Table are primary fields that should be entered. Please enter those fields before you save it.", vbCritical + vbOKOnly, Me.Text)
            TextBox9.Focus()
            Exit Sub
        End If
        If Fillobject(Me.TextBox10, Me.TabPage2, IIf(Me.TextBox10.Text = "", "insert", "update"), "sp_rt_spotdashboard", "", "@c_id") Then MsgBox("Data telah disimpan !", MsgBoxStyle.Information, "Machine") Else MsgBox("Data Belum disimpan !", MsgBoxStyle.Critical, "Dashboard")
        opensearchform(Me.ListView1, "pk_spotid", "spotid", "fieldname, tablename, condname, seqname, formnamep, pkidp, spotcaption", "rt_spotdashboard", "useridh='" & Me.txtguid.Text & "' AND spotid>0", "spotid", 0)
        ClearObjectonForm(Me.TabPage2) : Me.TextBox9.Select() : Me.TextBox11.Text = Me.txtguid.Text
    End Sub
    Private Function opensearchform(ByVal namalistview As ListView, ByVal strfield1 As String, ByVal strfield2 As String, ByVal strfield3 As String, ByVal strtabel As String, ByVal strwhr As String, ByVal strord As String, Optional openargs As Integer = 0) As String
        On Error Resume Next
        Dim cmd As SqlCommand
        Dim str(10) As String, strsql As String
        Dim itm As ListViewItem
        Dim dr As SqlDataReader

        With namalistview
            .Items.Clear()
            strsql = "SELECT " & strfield1 & ", " & strfield2 & ", " & strfield3 & " FROM " & strtabel & " where " & strwhr & " order by " & strord
            If cn.State = ConnectionState.Closed Then cn.Open()
            cmd = New SqlCommand(strsql, cn)
            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                Do While dr.Read()
                    str(0) = IIf(IsDBNull(dr.Item(0).ToString()), "#", dr.Item(0).ToString())
                    str(1) = IIf(IsDBNull(dr.Item(1).ToString()), "#", dr.Item(1).ToString())
                    str(2) = IIf(IsDBNull(dr.Item(2).ToString()), "#", dr.Item(2).ToString())
                    str(3) = IIf(IsDBNull(dr.Item(3).ToString()), "#", dr.Item(3).ToString())
                    str(4) = IIf(IsDBNull(dr.Item(4).ToString()), "#", dr.Item(4).ToString())
                    str(5) = IIf(IsDBNull(dr.Item(5).ToString()), "#", dr.Item(5).ToString())
                    str(6) = IIf(IsDBNull(dr.Item(6).ToString()), "#", dr.Item(6).ToString())
                    str(7) = IIf(IsDBNull(dr.Item(7).ToString()), "#", dr.Item(7).ToString())
                    str(8) = IIf(IsDBNull(dr.Item(8).ToString()), "#", dr.Item(8).ToString())
                    itm = New ListViewItem(str)
                    .Items.Add(itm)
                Loop
            End If
            dr.Close()
            cmd.Dispose()
        End With
    End Function
    '"pk_spotid", "spotid", "fieldname, tablename, condname, seqname"
    Private Sub ListView1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ListView1.SelectedIndexChanged
        If ListView1.SelectedItems.Count > 0 Then
            Me.TextBox10.Text = Me.ListView1.Items(ListView1.FocusedItem.Index).Text
            Me.TextBox9.Text = Me.ListView1.Items(ListView1.FocusedItem.Index).SubItems(1).Text
            Me.TextBox1.Text = Me.ListView1.Items(ListView1.FocusedItem.Index).SubItems(2).Text
            Me.TextBox4.Text = Me.ListView1.Items(ListView1.FocusedItem.Index).SubItems(3).Text
            Me.TextBox7.Text = Me.ListView1.Items(ListView1.FocusedItem.Index).SubItems(4).Text
            Me.TextBox8.Text = Me.ListView1.Items(ListView1.FocusedItem.Index).SubItems(5).Text
            Me.TextBox12.Text = Me.ListView1.Items(ListView1.FocusedItem.Index).SubItems(6).Text
            Me.TextBox13.Text = Me.ListView1.Items(ListView1.FocusedItem.Index).SubItems(7).Text
            Me.TextBox14.Text = Me.ListView1.Items(ListView1.FocusedItem.Index).SubItems(8).Text
            Me.btnSaveD.Tag = "E"
        End If
    End Sub
    Private Sub DeleteThisDashboardItemToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles DeleteThisDashboardItemToolStripMenuItem.Click
        If Me.ListView1.SelectedItems.Count = 0 Or Me.TextBox10.Text = "" Then Exit Sub
        'Dim emailaddr As String = GetCurrentID("emailaddress", "m_member", "kodemember='" & Me.ListView2.SelectedItems(0).SubItems(1).Text & "'")
        Me.Cursor = Cursors.WaitCursor
        If Fillobject(Me.TextBox10, Me.TabPage2, "delete", "sp_rt_spotdashboard", Me.TextBox10.Text, "@pk_spotid") Then MsgBox("Data telah disimpan !", MsgBoxStyle.Information, "User-Dashboard") Else MsgBox("Data Belum disimpan !", MsgBoxStyle.Critical, "User-Dashboard")
        opensearchform(Me.ListView1, "pk_spotid", "spotid", "fieldname, tablename, condname, seqname, formnamep, pkidp, spotcaption", "rt_spotdashboard", "useridh='" & Me.txtguid.Text & "' AND spotid>0", "spotid", 0)
        ClearObjectonForm(Me.TabPage2) : Me.TextBox9.Select() : Me.TextBox11.Text = Me.txtguid.Text
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub CopyThisDashboardToToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CopyThisDashboardToToolStripMenuItem.Click
        Dim DA As New SqlDataAdapter("select user_id as guidstr, UPPER(user_fname) as nama from mt_user where user_id<>" & Me.txtguid.Text & " AND ac=0 order by user_fname", cn)
        Dim DS As New DataTable
        DA.Fill(DS)
        With ToolStripComboBox1
            .ComboBox.DataSource = DS
            .ComboBox.DisplayMember = DS.Columns(1).ToString
            .ComboBox.ValueMember = DS.Columns(0).ToString
            .ComboBox.BindingContext = BindingContext
        End With
    End Sub
    
    Private Sub SUBMITToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SUBMITToolStripMenuItem.Click
        If Me.ToolStripComboBox1.SelectedIndex >= 0 Then
            If MsgBox("Copy this dashboard data from " & Me.txtfname.Text & " to " & Me.ToolStripComboBox1.SelectedItem(1).ToString & " ?", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "User " & Me.ToolStripComboBox1.SelectedItem(0).ToString) = MsgBoxResult.Yes Then
                Me.Cursor = Cursors.WaitCursor
                Dim x1 As Boolean = Executestr("delete from rt_spotdashboard where useridh=" & Me.ToolStripComboBox1.SelectedItem(0).ToString)
                Dim x2 As Boolean = Executestr("insert into rt_spotdashboard (created, createdby, modified, modifiedby, spotid, useridh, fieldname, tablename, condname, seqname) select created, createdby, modified, modifiedby, spotid, " & Me.ToolStripComboBox1.SelectedItem(0).ToString & " as useridh, fieldname, tablename, condname, seqname from rt_spotdashboard where useridh=" & Me.txtguid.Text)
                Me.Cursor = Cursors.Default
                If x1 And x2 Then MsgBox("Copy this dashboard data from " & Me.txtfname.Text & " to " & Me.ToolStripComboBox1.SelectedItem(1).ToString & ", SUCCESS", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "User " & Me.ToolStripComboBox1.SelectedItem(0).ToString)
            Else

            End If
        Else

        End If
    End Sub

    Private Sub btnDeleteD_Click(sender As System.Object, e As System.EventArgs) Handles btnDeleteD.Click
        If Me.ListView1.SelectedItems.Count = 0 Or Me.TextBox10.Text = "" Then Exit Sub
        'Dim emailaddr As String = GetCurrentID("emailaddress", "m_member", "kodemember='" & Me.ListView2.SelectedItems(0).SubItems(1).Text & "'")
        Me.Cursor = Cursors.WaitCursor
        If Fillobject(Me.TextBox10, Me.TabPage2, "delete", "sp_rt_spotdashboard", Me.TextBox10.Text, "@pk_spotid") Then MsgBox("Data telah disimpan !", MsgBoxStyle.Information, "User-Dashboard") Else MsgBox("Data Belum disimpan !", MsgBoxStyle.Critical, "User-Dashboard")
        opensearchform(Me.ListView1, "pk_spotid", "spotid", "fieldname, tablename, condname, seqname, formnamep, pkidp, spotcaption", "rt_spotdashboard", "useridh='" & Me.txtguid.Text & "' AND spotid>0", "spotid", 0)
        ClearObjectonForm(Me.TabPage2) : Me.TextBox9.Select() : Me.TextBox11.Text = Me.txtguid.Text
        Me.Cursor = Cursors.Default
    End Sub
End Class