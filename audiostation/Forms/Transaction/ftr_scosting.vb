Imports System.Data.SqlClient
Public Class ftr_scosting
    Dim strConnection As String = My.Settings.ConnStr
    Private strConn As String = My.Settings.ConnStr
    Private sqlCon As SqlConnection
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Private m_guid As String, m_d_guid As String
    Private namatable As String, namafieldPK As String
    Private Function kosong()
        Me.cmdsave.Tag = "F"
        ClearObjectonForm(Me)
        AssignValuetoCombo(Me.ComboBox1, "", "c_id", "c_name+', '+c_title", "mt_customer", "c_code<>''", "c_name")
        AssignValuetoCombo(Me.ComboBox14, "", "sku_id", "sku_name", "mt_sku", "is_finished_goods=1", "sku_name")

        AssignValuetoCombo(Me.ComboBox2, "select 0 as guidstr, 'PILIH' as nama union ", "uom_id", "uom_code", "mt_sku_uom", "1=1", "uom_code", "0")
        AssignValuetoCombo(Me.ComboBox3, "select 0 as guidstr, 'PILIH' as nama union ", "uom_id", "uom_code", "mt_sku_uom", "1=1", "uom_code", "0")
        AssignValuetoCombo(Me.ComboBox4, "select 0 as guidstr, 'PILIH' as nama union ", "uom_id", "uom_code", "mt_sku_uom", "1=1", "uom_code", "0")
        AssignValuetoCombo(Me.ComboBox5, "select 0 as guidstr, 'PILIH' as nama union ", "uom_id", "uom_code", "mt_sku_uom", "1=1", "uom_code", "0")
        AssignValuetoCombo(Me.ComboBox6, "", "primarykey", "sys_dropdown_val", "sys_dropdown", "sys_dropdown_whr='production_cost_component'", "sys_dropdown_sort")

        AssignValuetoCombo(Me.ComboBox7, "select 0 as guidstr, 'PILIH' as nama union ", "uom_id", "uom_code", "mt_sku_uom", "1=1", "uom_code", "0")
        AssignValuetoCombo(Me.ComboBox9, "select 0 as guidstr, 'PILIH' as nama union ", "uom_id", "uom_code", "mt_sku_uom", "1=1", "uom_code", "0")
        AssignValuetoCombo(Me.ComboBox10, "select 0 as guidstr, 'PILIH' as nama union ", "uom_id", "uom_code", "mt_sku_uom", "1=1", "uom_code", "0")
        AssignValuetoCombo(Me.ComboBox11, "select 0 as guidstr, 'PILIH' as nama union ", "uom_id", "uom_code", "mt_sku_uom", "1=1", "uom_code", "0")
        AssignValuetoCombo(Me.ComboBox12, "select 0 as guidstr, 'PILIH' as nama union ", "uom_id", "uom_code", "mt_sku_uom", "1=1", "uom_code", "0")
        AssignValuetoCombo(Me.ComboBox13, "select 0 as guidstr, 'PILIH' as nama union ", "uom_id", "uom_code", "mt_sku_uom", "1=1", "uom_code", "0")

        AssignValuetoCombo(Me.ComboBox8, "", "sys_dropdown_sort", "sys_dropdown_val", "sys_dropdown", "sys_dropdown_whr='costing_status'", "sys_dropdown_sort") : Me.ComboBox8.SelectedValue = 0
        With Me
            .ListView1.Columns.Clear()
            .ListView1.Columns.Add("Kolom 0", "guid", 0)

            .ListView1.Columns.Add("Kolom 1", "ID_Biaya", 0)
            .ListView1.Columns.Add("Kolom 1.1", "Keterangan_Biaya", Me.ComboBox6.Width + 5)

            .ListView1.Columns.Add("Kolom 2.0", "Qty", Me.TextBox12.Width + 5)
            .ListView1.Columns.Add("Kolom 2.1", "ID_UOM", 0)
            .ListView1.Columns.Add("Kolom 2.2", "UOM", Me.ComboBox7.Width + 15)

            .ListView1.Columns.Add("Kolom 3", "Harga", Me.TextBox13.Width + 20)

            .ListView1.Columns.Add("Kolom 4.0", "QTY_Unit_1", Me.TextBox14.Width + 5)
            .ListView1.Columns.Add("Kolom 4.1", "ID_Unit_1", 0)
            .ListView1.Columns.Add("Kolom 4.2", "Unit_1", Me.ComboBox9.Width + 20)

            .ListView1.Columns.Add("Kolom 5.0", "QTY_Unit_2", Me.TextBox15.Width + 5)
            .ListView1.Columns.Add("Kolom 5.1", "ID_Unit_2", 0)
            .ListView1.Columns.Add("Kolom 5.2", "Unit_2", Me.ComboBox10.Width + 20)

            .ListView1.Columns.Add("Kolom 6.0", "QTY_Unit_3", Me.TextBox16.Width + 5)
            .ListView1.Columns.Add("Kolom 6.1", "ID_Unit_3", 0)
            .ListView1.Columns.Add("Kolom 6.2", "Unit_3", Me.ComboBox11.Width + 20)

            .ListView1.Columns.Add("Kolom 7.2", "QTY_Unit_4", Me.TextBox17.Width + 5)
            .ListView1.Columns.Add("Kolom 7.1", "ID_Unit_4", 0)
            .ListView1.Columns.Add("Kolom 7.2", "Unit_4", Me.ComboBox12.Width + 20)

            .ListView1.Columns.Add("Kolom 8.2", "QTY_Unit_5", Me.TextBox18.Width + 5)
            .ListView1.Columns.Add("Kolom 8.1", "ID_Unit_5", 0)
            .ListView1.Columns.Add("Kolom 8.2", "Unit_5", Me.ComboBox13.Width + 5)

            .ListView1.Columns.Add("Kolom 9", "Jumlah", Me.TextBox19.Width + 33)
        End With
        Me.txtguid.Text = "0" : Me.txtguid_d.Text = "0" : Me.btnSaveD.Tag = "N"
        Me.ListView1.Items.Clear()
        Me.TextBox30.Text = "" : Me.TextBox31.Text = "" : Me.TextBox32.Text = "0" : Me.TextBox2.Text = "0" : Me.TextBox27.Text = "0"
        Me.TextBox3.Text = 0 : Me.TextBox4.Text = 0 : Me.TextBox5.Text = 0 : Me.TextBox6.Text = 0 : Me.TextBox7.Text = 0 : Me.TextBox8.Text = 0 : Me.TextBox9.Text = 0 : Me.TextBox10.Text = 0 : Me.TextBox11.Text = 0
        Me.TextBox12.Text = 0 : Me.TextBox13.Text = 0 : Me.TextBox14.Text = 0 : Me.TextBox15.Text = 0 : Me.TextBox16.Text = 0 : Me.TextBox17.Text = 0 : Me.TextBox18.Text = 0 : Me.TextBox29.Text = 0
        Me.TextBox20.Text = 0 : Me.TextBox21.Text = 0 : Me.TextBox22.Text = 0 : Me.TextBox23.Text = 0 : Me.TextBox24.Text = 0 : Me.TextBox25.Text = 0 : Me.TextBox26.Text = 0
        Me.cmdcancel.Enabled = False : Me.cmddel.Enabled = False : Me.btnSaveD.Enabled = False : Me.ComboBox6.Enabled = False
        Me.ComboBox1.Select()
    End Function
    Private Function opensearchform(ByVal namalistview As ListView, ByVal strfield1 As String, ByVal strfield2 As String, ByVal strfield3 As String, ByVal strtabel As String, ByVal strwhr As String, ByVal strord As String, Optional ByVal openargs As Integer = 0) As String
        'On Error Resume Next
        Dim cmd As SqlCommand
        Dim str(22) As String, strsql As String
        Dim itm As ListViewItem
        Dim dr As SqlDataReader
        If cn.State = ConnectionState.Closed Then cn.Open()
        With namalistview
            .Items.Clear() '"cost_d_id", "sku_id_f", "sku_id_desc1, sku_qty, sku_uom_f, harga1_val, nilai1_val, nilai1_uom, nilai2_val, nilai2_uom, nilai3_val, nilai3_uom, nilai4_val, nilai4_uom, nilai5_val, nilai5_uom"
            strsql = "SELECT " & strfield1 & ", " & strfield2 & ", " & strfield3 & " FROM " & strtabel & " where " & strwhr & " order by " & strord
            cmd = New SqlCommand(strsql, cn)
            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                Do While dr.Read()
                    str(0) = IIf(IsDBNull(dr.Item(0).ToString()), "#", dr.Item(0).ToString())

                    str(1) = IIf(IsDBNull(dr.Item(1).ToString()), "#", dr.Item(1).ToString())
                    str(2) = IIf(IsDBNull(dr.Item(2).ToString()), "#", dr.Item(2).ToString())

                    str(3) = IIf(IsDBNull(dr.Item(3).ToString()), "#", dr.Item(3).ToString())
                    str(4) = IIf(IsDBNull(dr.Item(4).ToString()), "#", dr.Item(4).ToString())
                    str(5) = IIf(IsDBNull(dr.Item(4).ToString()), "#", GetCurrentID("uom_code", "mt_sku_uom", "uom_id=" & dr.Item(4).ToString()))

                    str(6) = IIf(IsDBNull(dr.Item(5).ToString()), "#", dr.Item(5).ToString())

                    str(7) = IIf(IsDBNull(dr.Item(6).ToString()), "#", dr.Item(6).ToString())
                    str(8) = IIf(IsDBNull(dr.Item(7).ToString()), "#", dr.Item(7).ToString())
                    str(9) = IIf(IsDBNull(dr.Item(7).ToString()), "#", GetCurrentID("uom_code", "mt_sku_uom", "uom_id=" & dr.Item(7).ToString()))

                    str(10) = IIf(IsDBNull(dr.Item(8).ToString()), "#", dr.Item(8).ToString())
                    str(11) = IIf(IsDBNull(dr.Item(9).ToString()), "#", dr.Item(9).ToString())
                    str(12) = IIf(IsDBNull(dr.Item(9).ToString()), "#", GetCurrentID("uom_code", "mt_sku_uom", "uom_id=" & dr.Item(9).ToString()))

                    str(13) = IIf(IsDBNull(dr.Item(10).ToString()), "#", dr.Item(10).ToString())
                    str(14) = IIf(IsDBNull(dr.Item(11).ToString()), "#", dr.Item(11).ToString())
                    str(15) = IIf(IsDBNull(dr.Item(11).ToString()), "#", GetCurrentID("uom_code", "mt_sku_uom", "uom_id=" & dr.Item(11).ToString()))

                    str(16) = IIf(IsDBNull(dr.Item(12).ToString()), "#", dr.Item(12).ToString())
                    str(17) = IIf(IsDBNull(dr.Item(13).ToString()), "#", dr.Item(13).ToString())
                    str(18) = IIf(IsDBNull(dr.Item(13).ToString()), "#", GetCurrentID("uom_code", "mt_sku_uom", "uom_id=" & dr.Item(13).ToString()))

                    str(19) = IIf(IsDBNull(dr.Item(14).ToString()), "#", dr.Item(14).ToString())
                    str(20) = IIf(IsDBNull(dr.Item(15).ToString()), "#", dr.Item(15).ToString())
                    str(21) = IIf(IsDBNull(dr.Item(15).ToString()), "#", GetCurrentID("uom_code", "mt_sku_uom", "uom_id=" & dr.Item(15).ToString()))

                    Dim jumlah As Decimal = 0
                    jumlah = (Decimal.Ceiling(IIf(str(3) = "", 0, str(3))) * Decimal.Ceiling(IIf(str(6) = "", 0, str(6))) * Decimal.Ceiling(IIf(str(7) = "", 0, str(7))) * Decimal.Ceiling(IIf(str(10) = "", 0, str(10)))) - (Decimal.Ceiling(IIf(str(13) = "", 0, str(13))) * Decimal.Ceiling(IIf(str(16) = "", 0, str(16))) * Decimal.Ceiling(IIf(str(19) = "", 0, str(19))))

                    str(22) = IIf(IsDBNull(jumlah), "#", jumlah)

                    itm = New ListViewItem(str)
                    .Items.Add(itm)
                Loop
            End If
            AssignValuetoCombo(Me.ComboBox6, "", "primarykey", "sys_dropdown_val", "sys_dropdown", "sys_dropdown_whr='production_cost_component' and primarykey not in (" & loopthroughlistview(Me.ListView1, 1) & ")", "sys_dropdown_sort")
            dr.Close()
            cmd.Dispose()
        End With
    End Function
    Private Sub ftr_scosting_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Top = 0 : Me.Left = 0
        kosong()
    End Sub
    Private Function isirecord(ByVal guidno As Integer)
        Me.TextBox32.Text = guidno 'assign value Header ke detil object
        Fillobject(Me.txtguid, Me, "select", "sp_tr_costing", Me.txtguid.Text, "@c_id")
        Me.ComboBox8.SelectedValue = 1 'default value STATUS=OPEN
        opensearchform(Me.ListView1, "cost_d_id", "sku_id_f", "sku_id_desc1, sku_qty, sku_uom_f, harga1_val, nilai1_val, nilai1_uom, nilai2_val, nilai2_uom, nilai3_val, nilai3_uom, nilai4_val, nilai4_uom, nilai5_val, nilai5_uom", "tr_costing_d a", "a.cost_id_f in ('" & guidno & "')", "a.created", 0)
        Me.cmdcancel.Enabled = True : Me.cmddel.Enabled = True : Me.cmdprint.Enabled = True : Me.cmdsave.Tag = "S"
    End Function
    Private Sub cmdcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancel.Click
        kosong()
    End Sub
    Private Sub cmdsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsave.Click
        'save
        Dim updheader As Boolean, upddetil As Boolean, str1 As String, str2 As String, noindex As Integer
        On Error GoTo err_cmdsave_Click
        If Me.ListView1.Items.Count = 0 Then MsgBox("Data tidak dapat disimpan, karena detil barang masih kosong !", vbCritical + vbOKOnly, Me.Text) : Exit Sub
        If Me.ComboBox1.Text = "" Or Me.ComboBox14.Text = "" Or Me.TextBox2.Text = "" Then
            MsgBox("Code, Name and Qty are primary fields that should be entered. Please enter those fields before you save it.", vbCritical + vbOKOnly, Me.Text)
            ComboBox1.Focus()
            Exit Sub
        End If
        If MsgBox("Data akan di" & IIf(Me.txtguid.Text = "0", "simpan", "simpan ulang") & ", lanjutkan ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.Yes Then
            namatable = "tr_costing" : namafieldPK = "cost_no" : Me.ComboBox8.SelectedValue = 2 : Me.cmdsave.Tag = "X"
            If (Me.txtguid.Text = "0") Then
                'Insert new
                Me.TextBox1.Text = IIf(Me.txtguid.Text = "0", GETGeneralcode("CO", namatable, namafieldPK, "cost_date", CDate(Me.DateTimePicker1.Text), False, 4, 1, "", ""), Me.TextBox1.Text)
                updheader = Fillobject(Me.txtguid, Me, "insert", "sp_tr_costing", "", "@c_id") 'update header
                noindex = GetCurrentID("cost_id", namatable, namafieldPK & "='" & Me.TextBox1.Text & "'")
                For i As Integer = 0 To Me.ListView1.Items.Count - 1
                    'kl blm ada, INSERT
                    upddetil = Executestr("EXEC sp_tr_costing_dtl 'insert', '" & Format(Date.Now(), "MM/dd/yyyy hh:mm:ss tt") & "','" & My.Settings.UserName & "','" & Format(Date.Now(), "MM/dd/yyyy hh:mm:ss tt") & "','" & My.Settings.UserName & "','" & _
                                          Me.txtguid_d.Text & "','" & Me.txtguid.Text & "'," & ListView1.Items(i).SubItems(1).Text & ",'" & Me.ListView1.Items(i).SubItems(2).Text & "','" & ListView1.Items(i).SubItems(2).Text & "'," & _
                                          ListView1.Items(i).SubItems(3).Text & "," & ListView1.Items(i).SubItems(4).Text & "," & ListView1.Items(i).SubItems(6).Text & "," & _
                                          ListView1.Items(i).SubItems(7).Text & "," & ListView1.Items(i).SubItems(8).Text & "," & _
                                          ListView1.Items(i).SubItems(10).Text & "," & ListView1.Items(i).SubItems(11).Text & "," & _
                                          ListView1.Items(i).SubItems(13).Text & "," & ListView1.Items(i).SubItems(14).Text & "," & _
                                          ListView1.Items(i).SubItems(16).Text & "," & ListView1.Items(i).SubItems(17).Text & "," & _
                                          ListView1.Items(i).SubItems(19).Text & "," & ListView1.Items(i).SubItems(20).Text & "," & CDec(ListView1.Items(i).SubItems(22).Text))
                Next
                If updheader And upddetil Then MsgBox("Data telah disimpan !", MsgBoxStyle.Information, "MP") Else Me.TextBox1.Text = "" : MsgBox("Data gagal disimpan !", MsgBoxStyle.Critical, Me.Text)
            Else
                'Update
                noindex = Me.txtguid.Text
                updheader = Fillobject(Me.txtguid, Me, "update", "sp_tr_costing", "", "@c_id") 'update header
                upddetil = True
                If updheader And upddetil Then MsgBox("Data telah disimpan ulang !", MsgBoxStyle.Information, Me.Text) Else Me.TextBox1.Text = "" : MsgBox("Data gagal disimpan ulang !", MsgBoxStyle.Critical, Me.Text)
            End If
            kosong()
            Me.txtguid.Text = noindex
            'isirecord(noindex)
        Else
            MsgBox("Data Belum disimpan !", MsgBoxStyle.Critical, "Costing")
        End If
exit_cmdsave_Click:
        If ConnectionState.Open = 1 Then cn.Close()
        Exit Sub

err_cmdsave_Click:
        MsgBox(Err.Description)
        Resume exit_cmdsave_Click

    End Sub
    Private Sub cmdfind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdfind.Click
        'If Not CheckAuthor(curlevel, "isallowfilter", "FDLCreateEvent", True) Then Exit Sub
        Dim child As New FDLSearch()
        child.txtopenargs.Text = "7"
        If child.ShowDialog() = DialogResult.OK Then
            Me.txtguid.Text = child.txtChildText0.Text
        End If
    End Sub
    Private Sub cmddel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddel.Click
        'del
    End Sub
    Private Sub cmdnew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdnew.Click
        kosong()
    End Sub
    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub
    Private Sub cmdprint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdprint.Click

    End Sub
    Private Sub txtguid_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtguid.TextChanged
        If Me.cmdsave.Tag = "X" Then Exit Sub
        If Me.cmdsave.Tag = "F" And (Me.txtguid.Text = "0" Or Me.txtguid.Text = "") Then Exit Sub Else isirecord(Me.txtguid.Text)
    End Sub
    Private Sub TextBox12_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox12.KeyPress
        '97 - 122 = Ascii codes for simple letters, '65 - 90  = Ascii codes for capital letters, '48 - 57  = Ascii codes for numbers
        e.Handled = Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = ".")
    End Sub
    Private Sub TextBox13_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox13.KeyPress
        '97 - 122 = Ascii codes for simple letters, '65 - 90  = Ascii codes for capital letters, '48 - 57  = Ascii codes for numbers
        e.Handled = Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = ".") 'If Asc(e.KeyChar) <> 8 Then If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then e.Handled = True
    End Sub
    Private Sub TextBox14_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox14.KeyPress
        '97 - 122 = Ascii codes for simple letters, '65 - 90  = Ascii codes for capital letters, '48 - 57  = Ascii codes for numbers
        e.Handled = Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = ".")
    End Sub
    Private Sub TextBox15_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox15.KeyPress
        '97 - 122 = Ascii codes for simple letters, '65 - 90  = Ascii codes for capital letters, '48 - 57  = Ascii codes for numbers
        e.Handled = Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = ".")
    End Sub
    Private Sub TextBox16_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox16.KeyPress
        '97 - 122 = Ascii codes for simple letters, '65 - 90  = Ascii codes for capital letters, '48 - 57  = Ascii codes for numbers
        e.Handled = Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = ".")
    End Sub
    Private Sub TextBox17_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox17.KeyPress
        '97 - 122 = Ascii codes for simple letters, '65 - 90  = Ascii codes for capital letters, '48 - 57  = Ascii codes for numbers
        e.Handled = Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = ".")
    End Sub
    Private Sub TextBox18_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox18.KeyPress
        '97 - 122 = Ascii codes for simple letters, '65 - 90  = Ascii codes for capital letters, '48 - 57  = Ascii codes for numbers
        e.Handled = Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = ".")
    End Sub
    Private Sub TextBox12_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox12.TextChanged
        Me.TextBox19.Text = FormatNumber(HITUNGDETAIL(), 2)
    End Sub
    Private Function HITUNGDETAIL() As Decimal
        'Decimal.Ceiling(sqlReader.Item(ctrl.Tag).ToString)
        On Error Resume Next
        HITUNGDETAIL = ((IIf(Me.TextBox12.Text = "", 0, CDec(Me.TextBox12.Text))) * (IIf(Me.TextBox13.Text = "", 0, CDec(Me.TextBox13.Text))) * (IIf(Me.TextBox14.Text = "", 0, CDec(Me.TextBox14.Text))) * (IIf(Me.TextBox15.Text = "", 0, CDec(Me.TextBox15.Text))) - (IIf(Me.TextBox16.Text = "", 0, CDec(Me.TextBox16.Text)))) * ((IIf(Me.TextBox17.Text = "", 0, CDec(Me.TextBox17.Text))) * (IIf(Me.TextBox18.Text = "", 0, CDec(Me.TextBox18.Text))))
    End Function
    Private Sub TextBox13_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox13.TextChanged
        Me.TextBox19.Text = FormatNumber(HITUNGDETAIL(), 2)
    End Sub
    Private Sub TextBox14_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox14.TextChanged
        Me.TextBox19.Text = FormatNumber(HITUNGDETAIL(), 2)
    End Sub
    Private Sub TextBox15_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox15.TextChanged
        Me.TextBox19.Text = FormatNumber(HITUNGDETAIL(), 2)
    End Sub
    Private Sub TextBox16_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox16.TextChanged
        Me.TextBox19.Text = FormatNumber(HITUNGDETAIL(), 2)
    End Sub
    Private Sub TextBox17_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox17.TextChanged
        Me.TextBox19.Text = FormatNumber(HITUNGDETAIL(), 2)
    End Sub
    Private Sub TextBox18_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox18.TextChanged
        Me.TextBox19.Text = FormatNumber(HITUNGDETAIL(), 2)
    End Sub
    Private Sub btnSaveD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveD.Click
        Dim li As ListViewItem, i As Integer, urutan As Integer
        'If Me.txtguid.Text = "0" Then Exit Sub
        'Exit Sub
        urutan = 0
        If Me.txtguid.Text <> "0" And Me.txtguid_d.Text <> "0" Then 'header dan detail siap diedit
            Fillobject(Me.txtguid_d, Me.TabPage1, "update", "sp_tr_costing_dtl", Me.txtguid_d.Text, "@c_id") 'update detil
            opensearchform(Me.ListView1, "cost_d_id", "sku_id_f", "sku_id_desc1, sku_qty, sku_uom_f, harga1_val, nilai1_val, nilai1_uom, nilai2_val, nilai2_uom, nilai3_val, nilai3_uom, nilai4_val, nilai4_uom, nilai5_val, nilai5_uom", "tr_costing_d a", "a.cost_id_f in ('" & Me.txtguid.Text & "')", "a.created", 0)
        ElseIf Me.txtguid.Text <> "0" And Me.txtguid_d.Text = "0" Then 'header siap diedit dan detail siap insert new
            Fillobject(Me.txtguid_d, Me.TabPage1, "insert", "sp_tr_costing_dtl", "", "@c_id") 'insert detil
            opensearchform(Me.ListView1, "cost_d_id", "sku_id_f", "sku_id_desc1, sku_qty, sku_uom_f, harga1_val, nilai1_val, nilai1_uom, nilai2_val, nilai2_uom, nilai3_val, nilai3_uom, nilai4_val, nilai4_uom, nilai5_val, nilai5_uom", "tr_costing_d a", "a.cost_id_f in ('" & Me.txtguid.Text & "')", "a.created", 0)
        Else
            'insert
            If FindSubItem(ListView1, Me.ComboBox6.Text) = True And Me.btnSaveD.Tag = "N" Then
                'it is a duplicate do something
                MsgBox("Duplicate data !", MsgBoxStyle.Critical, "Costing")
                Exit Sub
            Else
                'it is not a duplicate, go ahead and add it.
                If Me.btnSaveD.Tag = "N" Then

                Else
                    urutan = ListView1.FocusedItem.Index
                    For a As Integer = ListView1.SelectedItems.Count - 1 To 0
                        ListView1.SelectedItems(a).Remove()
                    Next
                End If
                'Me.ListView1.Items(ListView1.FocusedItem.Index).Text
                'li = Me.ListView1.Items(urutan)

                li = ListView1.Items.Add(Me.txtguid_d.Text)
                li.SubItems.Add(Me.ComboBox6.SelectedValue)
                li.SubItems.Add(Me.ComboBox6.Text)

                li.SubItems.Add(Me.TextBox12.Text)
                li.SubItems.Add(Me.ComboBox7.SelectedValue)
                li.SubItems.Add(Me.ComboBox7.Text)

                li.SubItems.Add(Me.TextBox13.Text)

                li.SubItems.Add(Me.TextBox14.Text)
                li.SubItems.Add(Me.ComboBox9.SelectedValue)
                li.SubItems.Add(Me.ComboBox9.Text)

                li.SubItems.Add(Me.TextBox15.Text)
                li.SubItems.Add(Me.ComboBox10.SelectedValue)
                li.SubItems.Add(Me.ComboBox10.Text)

                li.SubItems.Add(Me.TextBox16.Text)
                li.SubItems.Add(Me.ComboBox11.SelectedValue)
                li.SubItems.Add(Me.ComboBox11.Text)

                li.SubItems.Add(Me.TextBox17.Text)
                li.SubItems.Add(Me.ComboBox12.SelectedValue)
                li.SubItems.Add(Me.ComboBox12.Text)

                li.SubItems.Add(Me.TextBox18.Text)
                li.SubItems.Add(Me.ComboBox13.SelectedValue)
                li.SubItems.Add(Me.ComboBox13.Text)

                li.SubItems.Add(Me.TextBox19.Text)
            End If
        End If
        Me.txtguid_d.Text = "0"
        Me.TextBox12.Text = "0"
        Me.TextBox13.Text = "0"
        Me.TextBox14.Text = "0"
        Me.TextBox15.Text = "0"
        Me.TextBox16.Text = "0"
        Me.TextBox17.Text = "0"
        Me.TextBox18.Text = "0"
        AssignValuetoCombo(Me.ComboBox6, "", "primarykey", "sys_dropdown_val", "sys_dropdown", "sys_dropdown_whr='production_cost_component' and primarykey not in (" & loopthroughlistview(Me.ListView1, 1, "") & ")", "sys_dropdown_sort")
        Me.ComboBox6.SelectedValue = ""
        If Me.ListView1.Items.Count > 0 Then Me.TextBox20.Text = loopthroughlistview(Me.ListView1, 22, "", True) : Me.TextBox20.Text = FormatNumber(IIf(Me.TextBox20.Text = "", 0, Me.TextBox20.Text), 2)
        Me.ComboBox6.Select
        Me.btnSaveD.Tag = "N" : Me.btnSaveD.Enabled = False
    End Sub
    Private Function FindSubItem(ByVal lv As ListView, ByVal SearchString As String) As Boolean
        'find column index in listview by name "acctcode"
        Dim idx = (From c In ListView1.Columns Where c.Text = "Keterangan_Biaya" Select c = c.Index).First()
        For Each itm As ListViewItem In lv.Items
            'search only subitems of column "acctcode"
            If itm.SubItems(idx).Text = SearchString Then Return True
        Next
        Return False
    End Function
    Private Sub ComboBox6_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox6.SelectedIndexChanged
        If Me.ComboBox6.SelectedIndex >= 0 Then Me.TextBox30.Text = Me.ComboBox6.Text : Me.TextBox31.Text = Me.ComboBox6.Text : Me.btnSaveD.Enabled = True
    End Sub
    Private Sub ListView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.SelectedIndexChanged
        If ListView1.SelectedItems.Count > 0 Then
            AssignValuetoCombo(Me.ComboBox6, "", "primarykey", "sys_dropdown_val", "sys_dropdown", "sys_dropdown_whr='production_cost_component' and primarykey not in (" & loopthroughlistview(Me.ListView1, 1, Me.ListView1.Items(ListView1.FocusedItem.Index).SubItems(1).Text) & ")", "sys_dropdown_sort")

            Me.txtguid_d.Text = Me.ListView1.Items(ListView1.FocusedItem.Index).Text
            Me.ComboBox6.SelectedValue = Me.ListView1.Items(ListView1.FocusedItem.Index).SubItems(1).Text
            Me.TextBox30.Text = Me.ListView1.Items(ListView1.FocusedItem.Index).SubItems(2).Text : Me.TextBox31.Text = Me.ListView1.Items(ListView1.FocusedItem.Index).SubItems(2).Text

            Me.TextBox12.Text = Me.ListView1.Items(ListView1.FocusedItem.Index).SubItems(3).Text
            Me.ComboBox7.SelectedValue = Me.ListView1.Items(ListView1.FocusedItem.Index).SubItems(4).Text

            Me.TextBox13.Text = Me.ListView1.Items(ListView1.FocusedItem.Index).SubItems(6).Text

            Me.TextBox14.Text = Me.ListView1.Items(ListView1.FocusedItem.Index).SubItems(7).Text
            Me.ComboBox9.SelectedValue = Me.ListView1.Items(ListView1.FocusedItem.Index).SubItems(8).Text

            Me.TextBox15.Text = Me.ListView1.Items(ListView1.FocusedItem.Index).SubItems(10).Text
            Me.ComboBox10.SelectedValue = Me.ListView1.Items(ListView1.FocusedItem.Index).SubItems(11).Text

            Me.TextBox16.Text = Me.ListView1.Items(ListView1.FocusedItem.Index).SubItems(13).Text
            Me.ComboBox11.SelectedValue = Me.ListView1.Items(ListView1.FocusedItem.Index).SubItems(14).Text

            Me.TextBox17.Text = Me.ListView1.Items(ListView1.FocusedItem.Index).SubItems(16).Text
            Me.ComboBox12.SelectedValue = Me.ListView1.Items(ListView1.FocusedItem.Index).SubItems(17).Text

            Me.TextBox18.Text = Me.ListView1.Items(ListView1.FocusedItem.Index).SubItems(19).Text
            Me.ComboBox13.SelectedValue = Me.ListView1.Items(ListView1.FocusedItem.Index).SubItems(20).Text

            Me.TextBox19.Text = Me.ListView1.Items(ListView1.FocusedItem.Index).SubItems(22).Text

            Me.btnSaveD.Tag = "E" : Me.btnSaveD.Enabled = True

        End If
    End Sub
    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        Me.ComboBox6.Enabled = Me.ComboBox1.SelectedIndex >= 0
    End Sub
    Private Sub btnAddD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddD.Click
        Me.txtguid_d.Text = "0"
        Me.TextBox12.Text = "0"
        Me.TextBox13.Text = "0"
        Me.TextBox14.Text = "0"
        Me.TextBox15.Text = "0"
        Me.TextBox16.Text = "0"
        Me.TextBox17.Text = "0"
        Me.TextBox18.Text = "0"
        Me.TextBox19.Text = "0"
        AssignValuetoCombo(Me.ComboBox6, "", "primarykey", "sys_dropdown_val", "sys_dropdown", "sys_dropdown_whr='production_cost_component' and primarykey not in (" & loopthroughlistview(Me.ListView1, 1, "") & ")", "sys_dropdown_sort")
        Me.ComboBox6.SelectedValue = "" : Me.ComboBox6.Select()
    End Sub
    Private Sub btnDeleteD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteD.Click
        MsgBox("Temporarily this function is disabled !", MsgBoxStyle.Information, "Costing")
    End Sub
End Class