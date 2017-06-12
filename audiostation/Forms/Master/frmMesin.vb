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
        If ExecSP(Me.TabPage1, IIf(Me.txtguid.Text = "", "insert", "update"), "sp_mt_mesin", "") Then MsgBox("Data telah disimpan !", MsgBoxStyle.Information, "Machine") Else MsgBox("Data Belum disimpan !", MsgBoxStyle.Critical, "Machine")

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
    Private Function ExecSP(ByVal root As Control, ByVal action As String, ByVal namasp As String, Optional filterby As String = "") As Boolean
        Dim sqlComm As New SqlCommand()
        Try
            'If cn.State = ConnectionState.Closed Then cn.Open()
            Dim sqlCon = New SqlConnection(strConn)

            Using (sqlCon)
                sqlCon.Open()
                sqlComm = New SqlCommand(namasp, sqlCon)

                sqlComm.CommandType = CommandType.StoredProcedure
                For Each ctrl As Control In root.Controls
                    If ctrl.Tag <> "" Or ctrl.Tag <> Nothing Then
                        If TypeOf ctrl Is TextBox Or TypeOf ctrl Is DateTimePicker Or TypeOf ctrl Is ComboBox Then sqlComm.Parameters.AddWithValue("@" & ctrl.Tag, ctrl.Text)
                        'If TypeOf ctrl Is ComboBox Then sqlComm.Parameters.AddWithValue("@" & ctrl.Tag, ctrl.Text)
                    Else
                    End If
                Next ctrl
                sqlComm.Parameters.AddWithValue("@action", action)
                sqlComm.Parameters.AddWithValue("@c_id", 0)
                sqlComm.Parameters.AddWithValue("@created", Format(Date.Now(), "MM/dd/yyyy hh:mm:ss tt")) : sqlComm.Parameters.AddWithValue("@createdby", My.Settings.UserName)
                sqlComm.Parameters.AddWithValue("@modified", Format(Date.Now(), "MM/dd/yyyy hh:mm:ss tt")) : sqlComm.Parameters.AddWithValue("@modifiedby", My.Settings.UserName)

                If action = "insert" Or action = "update" Then
                    sqlComm.ExecuteNonQuery()
                    Me.txtguid.Text = sqlComm.Parameters("@idmesin").SqlValue.ToString
                ElseIf action = "select" Then
                    Dim sqlReader As SqlDataReader = sqlComm.ExecuteReader()
                    If sqlReader.HasRows Then
                        While (sqlReader.Read())
                            For Each ctrl As Control In root.Controls
                                If ctrl.Tag <> "" Or ctrl.Tag <> Nothing Then
                                    If Microsoft.VisualBasic.Right(ctrl.Tag, 3) = "val" Then
                                        ctrl.Text = IIf(sqlReader.Item(ctrl.Tag).ToString = Decimal.Ceiling(sqlReader.Item(ctrl.Tag).ToString), Decimal.ToInt32(sqlReader.Item(ctrl.Tag).ToString).ToString(), sqlReader.Item(ctrl.Tag).ToString)
                                    Else
                                        ctrl.Text = sqlReader.Item(ctrl.Tag).ToString
                                    End If

                                Else
                                End If
                            Next ctrl
                        End While
                    End If
                    sqlReader.Close()
                Else
                    'delete
                End If

                sqlCon.Close()
            End Using
            ExecSP = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Machine")
            ExecSP = False
            Exit Function
        End Try
    End Function
    Private Function isirecord(ByVal guidno As String)
        Me.txtguid.Text = guidno : Me.txtkode.Text = guidno
        ExecSP(Me.TabPage1, "select", "sp_mt_mesin", Me.txtguid.Text)
    End Function
    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click

    End Sub

    Private Sub btnAdd_Click(sender As System.Object, e As System.EventArgs) Handles btnAdd.Click

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