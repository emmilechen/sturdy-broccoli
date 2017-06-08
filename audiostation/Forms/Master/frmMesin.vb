Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class frmMesin
    Dim strConnection As String = My.Settings.ConnStr
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Dim cmd As SqlCommand, ctrlstr As String = ""
    Private Sub ClearTextBox(ByVal root As Control)

        On Error Resume Next
        For Each ctrl As Control In root.Controls
            If TypeOf ctrl Is TextBox Or (TypeOf ctrl Is ComboBox) Then ctrlstr &= "," & ctrl.Name
            ClearTextBox(ctrl)
            If TypeOf ctrl Is TextBox Then
                CType(ctrl, TextBox).Text = String.Empty
            End If
            If TypeOf ctrl Is DateTimePicker Then
                CType(ctrl, DateTimePicker).Format = DateTimePickerFormat.Custom : CType(ctrl, DateTimePicker).CustomFormat = "yyyy-MM-dd" : CType(ctrl, DateTimePicker).Text = Now.Date
            End If
        Next ctrl
    End Sub
    Private Function kosong()
        ClearTextBox(Me) ': Debug.Print(ctrlstr) ': ClearCheckBox(Me)
        'Me.DateTimePicker1.Focus() : Me.CheckBox37.Text = "&Semua" : Me.CheckBox41.Text = "&Semua" : Me.CheckBox42.Text = "&Semua" : Me.CheckBox43.Text = "&Semua" : Me.CheckBox44.Text = "&Semua" : Me.CheckBox45.Text = "&Semua" : Me.CheckBox46.Text = "&Semua"
        assignvaltocombo(Me.cmbkat, "", "sys_dropdown_id", "sys_dropdown_val", "sys_dropdown", "sys_dropdown_whr='unit_uom_machine_elec'", "sys_dropdown_sort")
        assignvaltocombo(Me.cmbsubkat, "", "sys_dropdown_id", "sys_dropdown_val", "sys_dropdown", "sys_dropdown_whr='unit_uom_machine_elec'", "sys_dropdown_sort")

        assignvaltocombo(Me.cmbdayalistrik, "", "sys_dropdown_id", "sys_dropdown_val", "sys_dropdown", "sys_dropdown_whr='unit_uom_machine_elec'", "sys_dropdown_sort")
        assignvaltocombo(Me.cmbkwh, "", "sys_dropdown_id", "sys_dropdown_val", "sys_dropdown", "sys_dropdown_whr='unit_uom_machine_elec'", "sys_dropdown_sort")
        assignvaltocombo(Me.cmbtegangan, "", "sys_dropdown_id", "sys_dropdown_val", "sys_dropdown", "sys_dropdown_whr='unit_uom_machine_elec'", "sys_dropdown_sort")
        assignvaltocombo(Me.cmbfrekuensi, "", "sys_dropdown_id", "sys_dropdown_val", "sys_dropdown", "sys_dropdown_whr='unit_uom_machine_elec'", "sys_dropdown_sort")

        assignvaltocombo(Me.cmbcolour, "", "sys_dropdown_id", "sys_dropdown_val", "sys_dropdown", "sys_dropdown_whr='unit_uom_machine_size'", "sys_dropdown_sort")
        assignvaltocombo(Me.cmbimgmin, "", "sys_dropdown_id", "sys_dropdown_val", "sys_dropdown", "sys_dropdown_whr='unit_uom_machine_size'", "sys_dropdown_sort")

        assignvaltocombo(Me.cmbsizemin, "", "sys_dropdown_id", "sys_dropdown_val", "sys_dropdown", "sys_dropdown_whr='unit_uom_machine_size'", "sys_dropdown_sort")
        assignvaltocombo(Me.cmbsizemax, "", "sys_dropdown_id", "sys_dropdown_val", "sys_dropdown", "sys_dropdown_whr='unit_uom_machine_size'", "sys_dropdown_sort")

        assignvaltocombo(Me.cmbspeedmin, "", "sys_dropdown_id", "sys_dropdown_val", "sys_dropdown", "sys_dropdown_whr='unit_uom_machine_speed'", "sys_dropdown_sort")
        assignvaltocombo(Me.cmbspeedmax, "", "sys_dropdown_id", "sys_dropdown_val", "sys_dropdown", "sys_dropdown_whr='unit_uom_machine_speed'", "sys_dropdown_sort")

        assignvaltocombo(Me.cmbtgtmin, "", "sys_dropdown_id", "sys_dropdown_val", "sys_dropdown", "sys_dropdown_whr='unit_uom_machine_speed'", "sys_dropdown_sort")
        assignvaltocombo(Me.cmbtgtmax, "", "sys_dropdown_id", "sys_dropdown_val", "sys_dropdown", "sys_dropdown_whr='unit_uom_machine_speed'", "sys_dropdown_sort")
        'Me.cmdsave.Text = "&Save"
        '  select sys_dropdown_id, sys_dropdown_val from sys_dropdown where sys_dropdown_whr='sid_status' order by sys_dropdown_sort
    End Function
    Private Function assignvaltocombo(ByVal namacombo As ComboBox, strunion As String, fieldkey As String, fieldteks As String, namatabel As String, kondisi As String, sortby As String)
        '==========================================Fill Combo Template=========================================
        Dim DA As New SqlDataAdapter(strunion & "select " & fieldkey & " as guidstr, " & fieldteks & " as nama from " & namatabel & " where " & kondisi & " order by guidstr", cn)
        Dim DS As New DataSet

        DA.Fill(DS, "event")

        Dim dt As New DataTable
        dt.Columns.Add("nama", GetType(System.String))
        dt.Columns.Add("guidstr", GetType(System.String))
        '
        ' Populate the DataTable to bind to the Combobox.
        '
        Dim drDSRow As DataRow
        Dim drNewRow As DataRow

        For Each drDSRow In DS.Tables("event").Rows()
            drNewRow = dt.NewRow()
            drNewRow("nama") = drDSRow("nama")
            drNewRow("guidstr") = drDSRow("guidstr")
            dt.Rows.Add(drNewRow)
        Next

        namacombo.DropDownStyle = ComboBoxStyle.DropDownList
        With namacombo
            .DataSource = dt
            .DisplayMember = "nama"
            .ValueMember = "guidstr"
            .SelectedIndex = 0
        End With
        namacombo.SelectedValue = ""

        DA.Dispose()
        DS.Dispose()
        '==========================================END Fill combo Combo1=========================================
    End Function
    Private Sub frmMesin_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        On Error Resume Next
        If cn.State = ConnectionState.Closed Then cn.Open()
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
        If cn.State = ConnectionState.Closed Then cn.Open()

        Dim namaSP As String = "sp_mt_mesin"

        Dim strobject As String = "'" & Format(Date.Now(), "MM/dd/yyyy hh:mm:ss tt") & "','" & My.Settings.UserName & "', '" & Format(Date.Now(), "MM/dd/yyyy hh:mm:ss tt") & "', '" & My.Settings.UserName & _
                                  "', '" & Me.txtkode.Text & "', '" & Me.cmbkat.SelectedValue & "', '" & Me.cmbsubkat.SelectedValue & "', '" & Me.txttype.Text & _
                                  "', '" & Me.txtnama.Text & "', '" & Me.txtmerek.Text & "', '" & Me.txtnomesin.Text & "', '" & Me.txttahun.Text & _
                                  "', '" & Me.txtdayalistrik.Text & "', '" & Me.cmbdayalistrik.SelectedValue & "', '" & Me.txtkwh.Text & "', '" & Me.cmbkwh.SelectedValue & _
                                  "', '" & Me.txttegangan.Text & "', '" & Me.cmbtegangan.SelectedValue & "', '" & Me.txtfrekuensi.Text & "', '" & Me.cmbfrekuensi.SelectedValue & _
                                  "', '" & Me.txtcolour.Text & "', '" & Me.cmbcolour.SelectedValue & "', '" & Me.txtimgmin.Text & "', '" & Me.cmbimgmin.SelectedValue & _
                                  "', '" & Me.txtsizemin.Text & "', '" & Me.cmbsizemin.SelectedValue & "', '" & Me.txtsizemax.Text & "', '" & Me.cmbsizemax.SelectedValue & _
                                  "', '" & Me.txtspeedmin.Text & "', '" & Me.cmbspeedmin.SelectedValue & "', '" & Me.txtspeedmax.Text & "', '" & Me.cmbspeedmax.SelectedValue & _
                                  "', '" & Me.txttgtmin.Text & "', '" & Me.cmbtgtmin.SelectedValue & "', '" & Me.txttgtmax.Text & "', '" & Me.cmbtgtmax.SelectedValue & _
                                  "','0'"


        Dim sqlstr As String = "EXEC " & namaSP & IIf(Me.txtkode.Text = "", " 'insert', ", " 'update', ") & strobject
        Dim cmd As New SqlCommand(sqlstr, cn)
        ' ''If m_CId = 0 Then
        ' ''    prm1.Direction = ParameterDirection.Output
        ' ''    cn.Open()
        ' ''    cmd.ExecuteReader()
        ' ''    m_CId = prm1.Value
        ' ''    cn.Close()
        ' ''Else
        ' ''    prm1.Value = m_CId
        ' ''    cn.Open()
        ' ''    cmd.ExecuteReader()
        ' ''    cn.Close()
        ' ''End If
        ' ''clear_lvw()
        ' ''lock_obj(True)

exit_btnSave_Click:
        If ConnectionState.Open = 1 Then cn.Close()
        Exit Sub

err_btnSave_Click:
        'If Err.Number = 5 Then
        '    MsgBox("This primary code has been used (and deleted) previously. Please create with another code", vbExclamation + vbOKOnly, Me.Text)
        'Else
        MsgBox(Err.Description)
        'End If
        Resume exit_btnSave_Click
    End Sub
End Class