Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class frmabsenproduksi
    Private m_SOId As Integer, m_CId As Integer
    Private namatable As String, namafieldPK As String
    Dim strConnection As String = My.Settings.ConnStr
    Private strConn As String = My.Settings.ConnStr
    Private sqlCon As SqlConnection
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Private Function kosong()
        ClearObjectonForm(Me)
        AssignValuetoCombo(Me.ComboBox3, "", "sys_dropdown_sort", "sys_dropdown_val", "sys_dropdown", "sys_dropdown_whr='unit_check_absprod'", "sys_dropdown_sort", "1")
        AssignValuetoCombo(Me.ComboBox1, "select 0 as guidstr, 'PILIH' as nama union ", "primarykey", "sys_dropdown_val", "sys_dropdown", "sys_dropdown_whr='unit_shift_absprod'", "sys_dropdown_sort", "0")
        AssignValuetoCombo(Me.ComboBox2, "select 0 as guidstr, 'PILIH' as nama union ", "user_id", "user_fname", "mt_user", "user_level_id>1", "user_fname", "0")
        AssignValuetoCombo(Me.ComboBox4, "select 0 as guidstr, 'PILIH' as nama union ", "primarykey", "namamesin", "mt_mesin", "1=1", "namamesin", "0")
        AssignValuetoCombo(Me.ComboBox5, "select 0 as guidstr, 'PILIH' as nama union ", "mp_pk", "mp_no", "tr_mp", "1=1", "mp_no", "0") 
        Me.ComboBox6.Enabled = False
        AssignValuetoCombo(Me.ComboBox7, "select 0 as guidstr, 'PILIH' as nama union ", "uom_id", "uom_code", "mt_sku_uom", "1=1", "uom_code", "0")
        AssignValuetoCombo(Me.ComboBox8, "select 0 as guidstr, 'PILIH' as nama union ", "uom_id", "uom_code", "mt_sku_uom", "1=1", "uom_code", "0")
        Me.TextBox1.Text = "0" : Me.TextBox2.Text = "0"
        Me.DateTimePicker1.Focus()
        Me.Text = "Absen Produksi"
        namatable = "tr_abs_prod" : namafieldPK = "abs_id"
        Me.btncancel.Enabled = False : Me.btndelete.Enabled = False : Me.cmdprint.Enabled = False
    End Function
    Private Function isirecord(ByVal guidno As Integer)
        'Me.txtguid.Text = guidno
        Fillobject(Me.txtguid, Me, "select", "tr_abs_prod", "abs_id='" & Me.txtguid.Text & "'", "abs_id", True)
        Me.ComboBox6.SelectedValue = GetCurrentID("prod_id", "tr_abs_prod", "abs_id='" & Me.txtguid.Text & "'")
        Me.Text = "Absen Produksi - " & Me.txtkode.Text
        Me.TextBox1.Text = FormatNumber(Me.TextBox1.Text, 0) : Me.TextBox2.Text = FormatNumber(Me.TextBox2.Text, 0)
        Me.btncancel.Enabled = True : Me.btndelete.Enabled = True
    End Function
    Private Sub frmabsenproduksi_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Top = 0 : Me.Left = 0
        If cn.State = ConnectionState.Closed Then cn.Open()
        kosong()
    End Sub
    Private Sub ComboBox5_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboBox5.SelectedIndexChanged
        If Me.ComboBox5.SelectedIndex >= 0 And Me.ComboBox5.SelectedValue.ToString <> "System.Data.DataRowView" Then
            AssignValuetoCombo(Me.ComboBox6, "", "sku_id_f", "sku_id_desc", "tr_mp_dtl", "mp_id_f='" & Me.ComboBox5.SelectedValue & "'", "skud_id_desc")
            Me.ComboBox6.BackColor = Color.GreenYellow
            Me.ComboBox6.Enabled = True
        Else
            Me.ComboBox6.Enabled = False
        End If

    End Sub
    Private Sub TextBox1_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub TextBox2_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox2.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub btnsave_Click(sender As System.Object, e As System.EventArgs) Handles btnsave.Click
        On Error GoTo err_btnsave_Click
        If Me.ComboBox1.Text = "" Or ComboBox2.Text = "" Or ComboBox3.Text = "" Or ComboBox4.Text = "" Then
            MsgBox("Shift Code, Worker Name and MP are primary fields that should be entered. Please enter those fields before you save it.", vbCritical + vbOKOnly, Me.Text)
            ComboBox1.Focus()
            Exit Sub
        End If
        Me.txtguid.Tag = ""
        Me.txtkode.Text = IIf(Me.txtguid.Text = "", GETGeneralcode("RP", namatable, namafieldPK, "abs_date", CDate(Me.DateTimePicker1.Text), False, 6, 1, "", ""), Me.txtkode.Text)
        If Fillobject(Me.txtguid, Me, IIf(Me.txtguid.Text = "", "insert", "update"), "tr_abs_prod", "abs_id='" & Me.txtguid.Text & "'", "abs_id", True) Then MsgBox("Data telah disimpan !", MsgBoxStyle.Information, "Machine") Else MsgBox("Data Belum disimpan !", MsgBoxStyle.Critical, "Machine")

exit_btnsave_Click:
        If ConnectionState.Open = 1 Then cn.Close()
        Exit Sub

err_btnsave_Click:
        MsgBox(Err.Description)
        Resume exit_btnsave_Click
    End Sub
    Private Sub btnexit_Click(sender As System.Object, e As System.EventArgs) Handles btnexit.Click
        Me.Close()
    End Sub
    Private Sub btnnew_Click(sender As System.Object, e As System.EventArgs) Handles btnnew.Click
        kosong()
    End Sub
    Private Sub btnfind_Click(sender As System.Object, e As System.EventArgs) Handles btnfind.Click
        Dim child As New FDLSearch()
        child.txtopenargs.Text = "6"
        If child.ShowDialog() = DialogResult.OK Then
            Me.txtguid.Text = child.txtChildText0.Text
        End If
    End Sub
    Private Sub ComboBox7_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboBox7.SelectedIndexChanged
        If Me.ComboBox7.SelectedIndex >= 0 Then Me.ComboBox8.SelectedValue = Me.ComboBox7.SelectedValue
    End Sub
    Private Sub txtguid_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtguid.TextChanged
        If Me.txtguid.Text <> "" Then isirecord(Me.txtguid.Text)
    End Sub
    Private Sub btncancel_Click(sender As System.Object, e As System.EventArgs) Handles btncancel.Click
        If Me.txtguid.Text <> "" Then isirecord(Me.txtguid.Text)
    End Sub
End Class