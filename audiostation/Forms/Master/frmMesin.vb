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
        AssignValuetoCombo(Me.cmbkat, "", "primarykey", "sys_dropdown_val", "sys_dropdown", "sys_dropdown_whr='unit_uom_machine_elec'", "sys_dropdown_sort")
        AssignValuetoCombo(Me.cmbsubkat, "", "primarykey", "sys_dropdown_val", "sys_dropdown", "sys_dropdown_whr='unit_uom_machine_elec'", "sys_dropdown_sort")

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
        Me.cmbkat.Focus()
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
    End Sub
    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        Dim schemaTable As DataTable
        Dim myReader As SqlDataReader
        Dim myField As DataRow
        Dim myProperty As DataColumn
        On Error GoTo err_btnSave_Click
        If cmbkat.Text = "" Or cmbsubkat.Text = "" Or txttype.Text = "" Or txtnama.Text = "" Then
            MsgBox("Customer Code, Customer Name and Category are primary fields that should be entered. Please enter those fields before you save it.", vbCritical + vbOKOnly, Me.Text)
            cmbkat.Focus()
            Exit Sub
        End If
        Me.txtguid.Tag = ""
        Me.txtkode.Text = IIf(Me.txtguid.Text = "", GETGeneralcode("", namatable, namafieldPK, "", Me.txtnama.Text, True, 3, 1, "", ""), Me.txtkode.Text)
        If Fillobject(Me.txtguid, Me.TabPage1, IIf(Me.txtguid.Text = "", "insert", "update"), "sp_mt_mesin", "") Then MsgBox("Data telah disimpan !", MsgBoxStyle.Information, "Machine") Else MsgBox("Data Belum disimpan !", MsgBoxStyle.Critical, "Machine")

exit_btnSave_Click:
        If ConnectionState.Open = 1 Then cn.Close()
        Exit Sub

err_btnSave_Click:
        MsgBox(Err.Description)
        Resume exit_btnSave_Click
    End Sub
    
    Private Function isirecord(ByVal guidno As String)
        Me.txtguid.Text = guidno : Me.txtkode.Text = guidno
        Fillobject(Me.txtguid, Me.TabPage1, "select", "sp_mt_mesin", Me.txtguid.Text)
    End Function
    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click

    End Sub
    Private Sub btnAdd_Click(sender As System.Object, e As System.EventArgs) Handles btnAdd.Click
        kosong()
    End Sub
    Private Sub btnDelete_Click(sender As System.Object, e As System.EventArgs) Handles btnDelete.Click

    End Sub
    Private Sub TabControl1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles TabControl1.SelectedIndexChanged

    End Sub
    Private Sub btnfind_Click(sender As System.Object, e As System.EventArgs) Handles btnfind.Click
        'If Not CheckAuthor(curlevel, "isallowfilter", "FDLCreateEvent", True) Then Exit Sub
        Dim child As New FDLSearch()
        child.txtopenargs.Text = "1"
        If child.ShowDialog() = DialogResult.OK Then
            Me.txtguid.Text = child.txtChildText0.Text
        End If
    End Sub
    Private Sub txtguid_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtguid.TextChanged
        Dim xno As String
        If Me.txtguid.Text <> "" Then xno = Me.txtguid.Text : isirecord(xno)
    End Sub
End Class