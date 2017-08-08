Imports System.Data.SqlClient
Imports System.Data.OleDb
Public Class frmFormmod
    Dim strConnection As String = My.Settings.ConnStr
    Private strConn As String = My.Settings.ConnStr
    Private sqlCon As SqlConnection
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Private Function kosong()
        ClearObjectonForm(Me)
        AssignValuetoCombo(Me.ComboBox1, "", "form_name", "form_description", "mt_form", "form_name<>''", "form_description")
        AssignValuetoCombo(Me.ComboBox2, "", "name", "name", "sys.tables", "name<>''", "name")
        AssignValuetoCombo(Me.ComboBox4, "", "user_level_id", "user_level_id", "mt_user_level", "user_level_id>0", "user_level_id")
        AssignValuetoCombo(Me.ComboBox5, "", "user_id", "user_fname", "mt_user", "user_id>0", "user_id")
        With Me
            .ListView1.Columns.Clear()
            .ListView1.Columns.Add("Kolom 0", "guid", 0)
            .ListView1.Columns.Add("Kolom 1", "formid", 0)
            .ListView1.Columns.Add("Kolom 2", "formname", 0)
            .ListView1.Columns.Add("Kolom 3", "tablename", Me.ComboBox2.Width + 5)
            .ListView1.Columns.Add("Kolom 4", "fieldname", Me.TextBox4.Width + 5)
            .ListView1.Columns.Add("Kolom 5", "signlevelid", Me.ComboBox4.Width + 5)
            .ListView1.Columns.Add("Kolom 6", "userid", 0)
            .ListView1.Columns.Add("Kolom 7", "username", (Me.ListView2.Width - (Me.ComboBox2.Width + Me.TextBox4.Width + Me.ComboBox4.Width)))
        End With
        Me.ListView1.Items.Clear()
        'opensearchform(Me.ListView1, "rt_form_id", "formname", "tablename, fieldname, signlevelid, userid", "rt_form_sign", "rt_form_sign.userid in ('" & Me.txtguid.Text & "')", "formname", 0)

        With Me
            .ListView2.Columns.Clear()
            .ListView2.Columns.Add("Kolom 0", "guid", 0)
            .ListView2.Columns.Add("Kolom 1", "form_name", Me.TextBox2.Width + 5)
            .ListView2.Columns.Add("Kolom 2", "form_description", Me.TextBox3.Width + 5)
            .ListView2.Columns.Add("Kolom 3", "menu_sort", Me.TextBox5.Width + 10)
            .ListView2.Columns.Add("Kolom 4", "menu_name", Me.TextBox6.Width + 5)
            .ListView2.Columns.Add("Kolom 5", "menu_group", Me.TextBox7.Width + 5)
            .ListView2.Columns.Add("Kolom 6", "parent_id", Me.TextBox8.Width + 5)
        End With
        Me.ListView2.Items.Clear()
        opensearchform(Me.ListView2, "form_name", "form_description", "menu_sort, menu_name, menu_group, parent_id", "mt_form", "form_name<>''", "form_name", 0)

        Me.TextBox2.Focus()
        Me.btncancel.Enabled = False : Me.btndelete.Enabled = False ': Me.btnprint.Enabled = False
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
                Do While dr.Read()
                    str(0) = IIf(IsDBNull(dr.Item(0).ToString()), "#", dr.Item(0).ToString())
                    str(1) = IIf(IsDBNull(dr.Item(0).ToString()), "#", dr.Item(0).ToString())
                    str(2) = IIf(IsDBNull(dr.Item(1).ToString()), "#", dr.Item(1).ToString())
                    str(3) = IIf(IsDBNull(dr.Item(2).ToString()), "#", dr.Item(2).ToString())
                    str(4) = IIf(IsDBNull(dr.Item(3).ToString()), "#", dr.Item(3).ToString())
                    str(5) = IIf(IsDBNull(dr.Item(4).ToString()), "#", dr.Item(4).ToString())
                    str(6) = IIf(IsDBNull(dr.Item(5).ToString()), "#", dr.Item(5).ToString())
                    If strfield1 = "rt_form_id" Then str(7) = GetCurrentID("user_fname", "mt_user", "user_id=" & dr.Item(5).ToString()) 'username
                    itm = New ListViewItem(str)
                    .Items.Add(itm)
                Loop
            End If
            dr.Close()
            cmd.Dispose()
        End With
    End Function
    Private Sub Panel2_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles Panel2.Paint

    End Sub
    Private Sub Panel1_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub
    Private Sub frmFormmod_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Top = 0 : Me.Left = 0
        If cn.State = ConnectionState.Closed Then cn.Open()
        kosong()
    End Sub

    Private Sub ListView2_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ListView2.SelectedIndexChanged
        If ListView2.SelectedItems.Count > 0 Then
            Me.txtguid.Text = Me.ListView2.Items(ListView2.FocusedItem.Index).Text
            Me.TextBox2.Text = Me.ListView2.Items(ListView2.FocusedItem.Index).SubItems(1).Text
            Me.TextBox3.Text = Me.ListView2.Items(ListView2.FocusedItem.Index).SubItems(2).Text
            Me.TextBox5.Text = Me.ListView2.Items(ListView2.FocusedItem.Index).SubItems(3).Text
            Me.TextBox6.Text = Me.ListView2.Items(ListView2.FocusedItem.Index).SubItems(4).Text
            Me.TextBox7.Text = Me.ListView2.Items(ListView2.FocusedItem.Index).SubItems(5).Text
            Me.TextBox8.Text = Me.ListView2.Items(ListView2.FocusedItem.Index).SubItems(6).Text
            Me.ComboBox1.SelectedValue = Me.ListView2.Items(ListView2.FocusedItem.Index).SubItems(1).Text
            opensearchform(Me.ListView1, "rt_form_id", "formname", "tablename, fieldname, signlevelid, userid", "rt_form_sign", "rt_form_sign.formname in ('" & Me.txtguid.Text & "')", "formname", 0)

        End If
    End Sub

    Private Sub btnsave_Click(sender As System.Object, e As System.EventArgs) Handles btnsave.Click
        Dim strsql As String
        If Me.TextBox2.Text = "" Or Me.TextBox3.Text = "" Or Me.TextBox5.Text = "" Or Me.TextBox6.Text = "" Then Exit Sub
        If Me.txtguid.Text = "" Then
            'new
            strsql = "insert into mt_form (form_name, form_description, menu_sort, menu_name, menu_group, parent_id) values ('" & Me.TextBox2.Text & "', '" & Me.TextBox3.Text & "', '" & Me.TextBox5.Text & "', '" & Me.TextBox6.Text & "', '" & Me.TextBox7.Text & "', '" & Me.TextBox8.Text & "')"
            If Executestr(strsql) Then MsgBox("Data telah disimpan !", MsgBoxStyle.Information, Me.Text) Else MsgBox("Data belum disimpan !", MsgBoxStyle.Information, Me.Text)
        Else
            'edit
            strsql = "update mt_form set form_description='" & Me.TextBox3.Text & "', menu_sort='" & Me.TextBox5.Text & "', menu_name='" & Me.TextBox6.Text & "', menu_group='" & Me.TextBox7.Text & "', parent_id='" & Me.TextBox8.Text & "' where form_name='" & Me.TextBox2.Text & "'"
            If Executestr(strsql) Then MsgBox("Data telah disimpan !", MsgBoxStyle.Information, Me.Text) Else MsgBox("Data belum disimpan !", MsgBoxStyle.Information, Me.Text)
        End If
        kosong()
    End Sub

    Private Sub btnnew_Click(sender As System.Object, e As System.EventArgs) Handles btnnew.Click
        kosong()
    End Sub

    Private Sub btnexit_Click(sender As System.Object, e As System.EventArgs) Handles btnexit.Click
        Me.Close()
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
            Me.ComboBox2.SelectedValue = Me.ListView1.Items(ListView1.FocusedItem.Index).SubItems(3).Text
            Me.TextBox4.Text = Me.ListView1.Items(ListView1.FocusedItem.Index).SubItems(4).Text
            'Me.ComboBox3.SelectedValue = Me.ListView1.Items(ListView1.FocusedItem.Index).SubItems(4).Text
            Me.ComboBox4.SelectedValue = Me.ListView1.Items(ListView1.FocusedItem.Index).SubItems(5).Text
            Me.ComboBox5.SelectedValue = Me.ListView1.Items(ListView1.FocusedItem.Index).SubItems(6).Text

        End If
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged
        'COLUMN_NAME from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME = 'Customer'
        If Me.txtguid.Text = "" Then Exit Sub
        If Me.ComboBox2.SelectedIndex >= 0 Then autocompleteteks(Me.TextBox4, "distinct COLUMN_NAME", "INFORMATION_SCHEMA.COLUMNS", "TABLE_NAME in ('" & ComboBox2.SelectedValue & "')", "COLUMN_NAME")
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Fillobject(Me.TextBox1, Me.Panel2, "insert", "sp_rt_form_sign", Me.TextBox1.Text, "@user_id")
        opensearchform(Me.ListView1, "rt_form_id", "formname", "tablename, fieldname, signlevelid, userid", "rt_form_sign", "rt_form_sign.formname in ('" & Me.txtguid.Text & "')", "formname", 0)
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        If Me.TextBox1.Text = "" Then Exit Sub
        Dim strsql As String = "delete from rt_form_id where form_name='" & Me.TextBox2.Text & "' and userid=" & Me.ComboBox5.SelectedValue
        If Executestr(strsql) Then MsgBox("Data telah dihapus !", MsgBoxStyle.Information, Me.Text) Else MsgBox("Data belum dihapus !", MsgBoxStyle.Information, Me.Text)
        opensearchform(Me.ListView1, "rt_form_id", "formname", "tablename, fieldname, signlevelid, userid", "rt_form_sign", "rt_form_sign.formname in ('" & Me.txtguid.Text & "')", "formname", 0)
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        ClearObjectonForm(Me.Panel2)
    End Sub
End Class