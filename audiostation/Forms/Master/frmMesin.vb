Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class frmMesin
    Dim strConnection As String = My.Settings.ConnStr
    Private strConn As String = My.Settings.ConnStr
    Private sqlCon As SqlConnection
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Dim cmd As SqlCommand, ctrlstr As String = ""
    Private namatable As String, namafieldPK As String
    Private Function kosong()
        ClearObjectonForm(Me)
        AssignValuetoCombo(Me.cmbkat, "", "primarykey", "sys_dropdown_val", "sys_dropdown", "sys_dropdown_whr='machine_cat'", "sys_dropdown_sort")
        AssignValuetoCombo(Me.cmbsubkat, "", "primarykey", "sys_dropdown_val", "sys_dropdown", "sys_dropdown_whr='machine_subcat'", "sys_dropdown_sort")

        AssignValuetoCombo(Me.cmbdayalistrik, "", "primarykey", "sys_dropdown_val", "sys_dropdown", "sys_dropdown_whr='unit_uom_machine_elec'", "sys_dropdown_sort")
        AssignValuetoCombo(Me.cmbkwh, "", "primarykey", "sys_dropdown_val", "sys_dropdown", "sys_dropdown_whr='unit_uom_machine_elec'", "sys_dropdown_sort")
        AssignValuetoCombo(Me.cmbtegangan, "", "primarykey", "sys_dropdown_val", "sys_dropdown", "sys_dropdown_whr='unit_uom_machine_elec'", "sys_dropdown_sort")
        AssignValuetoCombo(Me.cmbfrekuensi, "", "primarykey", "sys_dropdown_val", "sys_dropdown", "sys_dropdown_whr='unit_uom_machine_elec'", "sys_dropdown_sort")

        AssignValuetoCombo(Me.cmbcolour, "", "primarykey", "sys_dropdown_val", "sys_dropdown", "sys_dropdown_whr='unit_uom_machine_size'", "sys_dropdown_sort")
        AssignValuetoCombo(Me.cmbimgmin, "", "primarykey", "sys_dropdown_val", "sys_dropdown", "sys_dropdown_whr='unit_uom_machine_size'", "sys_dropdown_sort")

        AssignValuetoCombo(Me.cmbsizemin, "", "primarykey", "sys_dropdown_val", "sys_dropdown", "sys_dropdown_whr='unit_uom_machine_size'", "sys_dropdown_sort")
        AssignValuetoCombo(Me.cmbsizemax, "", "primarykey", "sys_dropdown_val", "sys_dropdown", "sys_dropdown_whr='unit_uom_machine_size'", "sys_dropdown_sort")

        AssignValuetoCombo(Me.cmbspeedmin, "", "primarykey", "sys_dropdown_val", "sys_dropdown", "sys_dropdown_whr='unit_uom_machine_speed'", "sys_dropdown_sort")
        AssignValuetoCombo(Me.cmbspeedmax, "", "primarykey", "sys_dropdown_val", "sys_dropdown", "sys_dropdown_whr='unit_uom_machine_speed'", "sys_dropdown_sort")

        AssignValuetoCombo(Me.cmbtgtmin, "", "primarykey", "sys_dropdown_val", "sys_dropdown", "sys_dropdown_whr='unit_uom_machine_speed'", "sys_dropdown_sort")
        AssignValuetoCombo(Me.cmbtgtmax, "", "primarykey", "sys_dropdown_val", "sys_dropdown", "sys_dropdown_whr='unit_uom_machine_speed'", "sys_dropdown_sort")
        With Me
            .ListViewa.Columns.Clear()
            .ListViewa.Columns.Add("Kolom 0", "guid", 0)
            .ListViewa.Columns.Add("Kolom 1", "urut", 0)
            .ListViewa.Columns.Add("Kolom 2", "kode", 0)
            .ListViewa.Columns.Add("Kolom 3", "Keterangan", Me.ListViewa.Width)
            opensearchform(Me.ListViewa, "primarykey", "sys_dropdown_sort", "sys_dropdown_id, sys_dropdown_val", "sys_dropdown", "sys_dropdown_whr in ('machine_division') and primarykey not in (select pk_mesin_idf from rt_mesin_div where pk_mesin_id='" & Me.txtguid.Text & "')", "sys_dropdown_sort", 0)
            Btnup.Enabled = False : Btndown.Enabled = False
            .ListViewb.Columns.Clear()
            .ListViewb.Columns.Add("Kolom 0", "guid", 0)
            .ListViewb.Columns.Add("Kolom 1", "urut", 0)
            .ListViewb.Columns.Add("Kolom 2", "kode", 0)
            .ListViewb.Columns.Add("Kolom 3", "Keterangan", Me.ListViewb.Width)
            opensearchform(Me.ListViewb, "primarykey", "sys_dropdown_sort", "sys_dropdown_id, sys_dropdown_val", "sys_dropdown", "sys_dropdown_whr in ('machine_division') and primarykey in (select pk_mesin_idf from rt_mesin_div where pk_mesin_id='" & Me.txtguid.Text & "')", "sys_dropdown_sort", 0)
        End With
        Me.btncancel.Enabled = False
        Me.btndelete.Enabled = False
        Me.Text = "Machine"
        Me.TabControl1.SelectedTab = Me.TabPage1
        Me.cmbkat.Focus()
    End Function
    Private Function opensearchform(ByVal namalistview As ListView, ByVal strfield1 As String, ByVal strfield2 As String, ByVal strfield3 As String, ByVal strtabel As String, ByVal strwhr As String, ByVal strord As String, Optional openargs As Integer = 0) As String
        On Error Resume Next
        Dim cmd As SqlCommand
        Dim str(10) As String, strsql As String
        Dim itm As ListViewItem
        Dim dr As SqlDataReader

        With namalistview
            .Items.Clear()
            strsql = "SELECT " & strfield1 & ", " & strfield2 & ", " & strfield3 & " FROM " & strtabel & " where " & strwhr & " order by " & strord
            cmd = New SqlCommand(strsql, cn)
            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                Do While dr.Read()
                    str(0) = IIf(IsDBNull(dr.Item(0).ToString()), "#", dr.Item(0).ToString())
                    str(1) = IIf(IsDBNull(dr.Item(1).ToString()), "#", dr.Item(1).ToString())
                    str(2) = IIf(IsDBNull(dr.Item(2).ToString()), "#", dr.Item(2).ToString())
                    str(3) = IIf(IsDBNull(dr.Item(3).ToString()), "#", dr.Item(3).ToString())

                    itm = New ListViewItem(str)
                    .Items.Add(itm)
                Loop
            End If
            dr.Close()
            cmd.Dispose()
        End With
    End Function
    Private Sub frmMesin_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        On Error Resume Next
        If cn.State = ConnectionState.Closed Then cn.Open()
        namatable = "mt_mesin" : namafieldPK = "idmesin"
        If Me.txtkode.Text = "" Then
            kosong()
        Else
            'isirec
            'kosong()
        End If
        Me.Left = 0 : Me.Top = 0
    End Sub
    Private Function isirecord(ByVal guidno As String)
        Me.txtguid.Text = guidno : Me.txtkode.Text = guidno
        Fillobject(Me.txtguid, Me.TabPage1, "select", "sp_mt_mesin", Me.txtguid.Text, "@idmesin")
        opensearchform(Me.ListViewa, "primarykey", "sys_dropdown_sort", "sys_dropdown_id, sys_dropdown_val", "sys_dropdown", "sys_dropdown_whr in ('machine_division') and primarykey not in (select pk_mesin_idf from rt_mesin_div where pk_mesin_id='" & Me.txtguid.Text & "')", "sys_dropdown_sort", 0)
        opensearchform(Me.ListViewb, "primarykey", "sys_dropdown_sort", "sys_dropdown_id, sys_dropdown_val", "sys_dropdown", "sys_dropdown_whr in ('machine_division') and primarykey in (select pk_mesin_idf from rt_mesin_div where pk_mesin_id='" & Me.txtguid.Text & "')", "sys_dropdown_sort", 0)
        Me.Text = "Machine - " & Me.txtnama.Text
        Me.Btnup.Enabled = True : Me.Btndown.Enabled = True
        Me.btncancel.Enabled = True : Me.btndelete.Enabled = True
    End Function
    Private Sub txtguid_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtguid.TextChanged
        Dim xno As String
        If Me.txtguid.Text <> "" Then xno = Me.txtguid.Text : isirecord(xno)
    End Sub

    Private Sub btnsave_Click(sender As System.Object, e As System.EventArgs) Handles btnsave.Click
        On Error GoTo err_btnsave_Click
        If cmbkat.Text = "" Or cmbsubkat.Text = "" Or txttype.Text = "" Or txtnama.Text = "" Then
            MsgBox("Customer Code, Customer Name and Category are primary fields that should be entered. Please enter those fields before you save it.", vbCritical + vbOKOnly, Me.Text)
            cmbkat.Focus()
            Exit Sub
        End If
        Me.txtguid.Tag = ""
        Me.txtkode.Text = IIf(Me.txtguid.Text = "", GETGeneralcode("", namatable, namafieldPK, "", Me.txtnama.Text, True, 3, 1, "", ""), Me.txtkode.Text)
        If Fillobject(Me.txtguid, Me.TabPage1, IIf(Me.txtguid.Text = "", "insert", "update"), "sp_mt_mesin", "", "@idmesin") Then MsgBox("Data telah disimpan !", MsgBoxStyle.Information, "Machine") Else MsgBox("Data Belum disimpan !", MsgBoxStyle.Critical, "Machine")

exit_btnsave_Click:
        If ConnectionState.Open = 1 Then cn.Close()
        Exit Sub

err_btnsave_Click:
        MsgBox(Err.Description)
        Resume exit_btnsave_Click
    End Sub

    Private Sub btnfind_Click(sender As System.Object, e As System.EventArgs) Handles btnfind.Click
        'If Not CheckAuthor(curlevel, "isallowfilter", "FDLCreateEvent", True) Then Exit Sub
        Dim child As New FDLSearch()
        child.txtopenargs.Text = "1"
        If child.ShowDialog() = DialogResult.OK Then
            Me.txtguid.Text = child.txtChildText0.Text
        End If
    End Sub

    Private Sub btnnew_Click(sender As System.Object, e As System.EventArgs) Handles btnnew.Click
        kosong()
    End Sub

    Private Sub btnexit_Click(sender As System.Object, e As System.EventArgs) Handles btnexit.Click
        Me.Close()
    End Sub

    Private Sub Btndown_Click(sender As System.Object, e As System.EventArgs) Handles Btndown.Click
        'insert
        For i = 0 To Me.ListViewa.SelectedItems.Count - 1
            Executestr("insert into rt_mesin_div(pk_mesin_id,pk_mesin_idf) values ('" & Me.txtguid.Text & "','" & Me.ListViewa.SelectedItems(i).SubItems(0).Text & "')")
        Next
        opensearchform(Me.ListViewa, "primarykey", "sys_dropdown_sort", "sys_dropdown_id, sys_dropdown_val", "sys_dropdown", "sys_dropdown_whr in ('machine_division') and primarykey not in (select pk_mesin_idf from rt_mesin_div where pk_mesin_id='" & Me.txtguid.Text & "')", "sys_dropdown_sort", 0)
        opensearchform(Me.ListViewb, "primarykey", "sys_dropdown_sort", "sys_dropdown_id, sys_dropdown_val", "sys_dropdown", "sys_dropdown_whr in ('machine_division') and primarykey in (select pk_mesin_idf from rt_mesin_div where pk_mesin_id='" & Me.txtguid.Text & "')", "sys_dropdown_sort", 0)
        Btnup.Enabled = False : Btndown.Enabled = False
    End Sub

    Private Sub Btnup_Click(sender As System.Object, e As System.EventArgs) Handles Btnup.Click
        'delete
        For i = 0 To Me.ListViewb.SelectedItems.Count - 1
            Executestr("delete from rt_mesin_div where pk_mesin_id='" & Me.txtguid.Text & "' AND pk_mesin_idf='" & Me.ListViewb.SelectedItems(i).SubItems(0).Text & "'")
        Next
            opensearchform(Me.ListViewa, "primarykey", "sys_dropdown_sort", "sys_dropdown_id, sys_dropdown_val", "sys_dropdown", "sys_dropdown_whr in ('machine_division') and primarykey not in (select pk_mesin_idf from rt_mesin_div where pk_mesin_id='" & Me.txtguid.Text & "')", "sys_dropdown_sort", 0)
            opensearchform(Me.ListViewb, "primarykey", "sys_dropdown_sort", "sys_dropdown_id, sys_dropdown_val", "sys_dropdown", "sys_dropdown_whr in ('machine_division') and primarykey in (select pk_mesin_idf from rt_mesin_div where pk_mesin_id='" & Me.txtguid.Text & "')", "sys_dropdown_sort", 0)
        Btnup.Enabled = False : Btndown.Enabled = False
    End Sub

    Private Sub ListViewa_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ListViewa.SelectedIndexChanged
        If Me.txtguid.Text = "" Then Exit Sub
        If Me.ListViewa.SelectedItems.Count > 0 Then Btnup.Enabled = False : Btndown.Enabled = True
    End Sub

    Private Sub ListViewb_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ListViewb.SelectedIndexChanged
        If Me.txtguid.Text = "" Then Exit Sub
        If Me.ListViewb.SelectedItems.Count > 0 Then Btnup.Enabled = True : Btndown.Enabled = False
    End Sub
End Class