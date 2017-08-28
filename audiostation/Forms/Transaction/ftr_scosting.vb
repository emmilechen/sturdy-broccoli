Imports System.Data.SqlClient
Public Class ftr_scosting
    Dim strConnection As String = My.Settings.ConnStr
    Private strConn As String = My.Settings.ConnStr
    Private sqlCon As SqlConnection
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Private m_guid As String, m_d_guid As String
    Private namatable As String, namafieldPK As String
    Private Function kosong()
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
        With Me
            .ListView1.Columns.Clear()
            .ListView1.Columns.Add("Kolom 0", "guid", 0)

            .ListView1.Columns.Add("Kolom 1", "ID_Biaya", 0)
            .ListView1.Columns.Add("Kolom 1.1", "Keterangan_Biaya", Me.ComboBox6.Width + 5)

            .ListView1.Columns.Add("Kolom 2.0", "Qty", Me.TextBox12.Width + 5)
            .ListView1.Columns.Add("Kolom 2.1", "ID_UOM", 0)
            .ListView1.Columns.Add("Kolom 2.2", "UOM", Me.ComboBox7.Width + 5)

            .ListView1.Columns.Add("Kolom 3", "Harga", Me.TextBox13.Width + 20)

            .ListView1.Columns.Add("Kolom 4.0", "QTY_Unit_1", Me.TextBox14.Width + 5)
            .ListView1.Columns.Add("Kolom 4.1", "ID_Unit_1", 0)
            .ListView1.Columns.Add("Kolom 4.2", "Unit_1", Me.ComboBox9.Width + 5)

            .ListView1.Columns.Add("Kolom 5.0", "QTY_Unit_2", Me.TextBox15.Width + 5)
            .ListView1.Columns.Add("Kolom 5.1", "ID_Unit_2", 0)
            .ListView1.Columns.Add("Kolom 5.2", "Unit_2", Me.ComboBox10.Width + 5)

            .ListView1.Columns.Add("Kolom 6.0", "QTY_Unit_3", Me.TextBox16.Width + 5)
            .ListView1.Columns.Add("Kolom 6.1", "ID_Unit_3", 0)
            .ListView1.Columns.Add("Kolom 6.2", "Unit_3", Me.ComboBox11.Width + 5)

            .ListView1.Columns.Add("Kolom 7.2", "QTY_Unit_4", Me.TextBox17.Width + 5)
            .ListView1.Columns.Add("Kolom 7.1", "ID_Unit_4", 0)
            .ListView1.Columns.Add("Kolom 7.2", "Unit_4", Me.ComboBox12.Width + 5)

            .ListView1.Columns.Add("Kolom 8.2", "QTY_Unit_5", Me.TextBox18.Width + 5)
            .ListView1.Columns.Add("Kolom 8.1", "ID_Unit_5", 0)
            .ListView1.Columns.Add("Kolom 8.2", "Unit_5", Me.ComboBox13.Width + 5)
        End With
        Me.txtguid.Text = "0" : Me.txtguid_d.Text = "0" : Me.btnSaveD.Tag = "N"
        Me.ListView1.Items.Clear()
        Me.TextBox12.Text = "0"
        Me.TextBox13.Text = "0"
        Me.TextBox14.Text = "0"
        Me.TextBox15.Text = "0"
        Me.TextBox16.Text = "0"
        Me.TextBox17.Text = "0"
        Me.TextBox18.Text = "0"
        'opensearchform(Me.ListView1, "rt_form_id", "formname", "tablename, fieldname, signlevelid, userid", "rt_form_sign", "rt_form_sign.userid in ('" & Me.txtguid.Text & "')", "formname", 0)
        Me.ComboBox1.Focus()
        Me.cmdcancel.Enabled = False : Me.cmddel.Enabled = False ': Me.btnprint.Enabled = False
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
    Private Sub ftr_scosting_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Top = 0 : Me.Left = 0
        kosong()
    End Sub
    Private Function isirecord(ByVal guidno As Integer)
        Me.txtguid.Text = guidno

        Fillobject(Me.txtguid, Me, "select", "sp_tr_costing", Me.txtguid.Text, "@c_id")
        'opensearchform(Me.ListView1, "mp_dtl_pk", "sku_id_f", "sku_code, sku_id_desc, mp_qty, uom_code, required_delivery_date, delivery_plan_date, tgl_realisasi_kirim", "tr_mp_dtl a inner join tr_mp b on a.mp_id_f=b.mp_pk  inner join mt_sku c on c.sku_id=a.sku_id_f inner join mt_sku_uom d on d.uom_id=c.uom_id inner join tr_so_dtl e on b.so_id_f=e.so_id", "a.mp_id_f in ('" & guidno & "')", "a.created", 0)
        'Me.Text = "Machine - " & Me.txtnama.Text

        Me.cmdcancel.Enabled = True : Me.cmddel.Enabled = True : Me.cmdprint.Enabled = True
    End Function
    Private Sub cmdcancel_Click(sender As System.Object, e As System.EventArgs) Handles cmdcancel.Click
        kosong()
    End Sub

    Private Sub cmdsave_Click(sender As System.Object, e As System.EventArgs) Handles cmdsave.Click
        'save
        Dim updheader As Boolean, upddetil As Boolean, str1 As String, str2 As String
        On Error GoTo err_cmdsave_Click
        'If Me.ListView1.Items.Count = 0 Then MsgBox("Data tidak dapat disimpan, karena detil barang masih kosong !", vbCritical + vbOKOnly, Me.Text) : Exit Sub
        If Me.ComboBox1.Text = "" Or Me.ComboBox14.Text = "" Or Me.TextBox2.Text = "" Then
            MsgBox("Code, Name and Qty are primary fields that should be entered. Please enter those fields before you save it.", vbCritical + vbOKOnly, Me.Text)
            ComboBox1.Focus()
            Exit Sub
        End If
        If MsgBox("Data akan di" & IIf(Me.txtguid.Text = "0", "simpan", "simpan ulang") & ", lanjutkan ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "MP") = MsgBoxResult.Yes Then
            namatable = "tr_costing" : namafieldPK = "cost_no"
            If (Me.txtguid.Text = "0") Then
                'Insert new
                Me.TextBox1.Text = IIf(Me.txtguid.Text = "0", GETGeneralcode("CO", namatable, namafieldPK, "cost_date", CDate(Me.DateTimePicker1.Text), False, 4, 1, "", ""), Me.TextBox1.Text)
                'Me.txtguid.Tag = ""
                updheader = Fillobject(Me.txtguid, Me, "insert", "sp_tr_costing", "", "@c_id") 'update header
                'For i As Integer = 0 To Me.ListView1.Items.Count - 1
                '    'kl blm ada, INSERT
                '    upddetil = Executestr("EXEC sp_tr_costing_dtl 'insert', '" & Format(Date.Now(), "MM/dd/yyyy hh:mm:ss tt") & "','" & My.Settings.UserName & "','" & Format(Date.Now(), "MM/dd/yyyy hh:mm:ss tt") & "','" & My.Settings.UserName & "','" & Me.txtguid_d.Text & "','" & Me.txtguid.Text & "','" & ListView1.Items(i).SubItems(1).Text & "','" & ListView1.Items(i).SubItems(3).Text & "','" & ListView1.Items(i).SubItems(4).Text & "','" & Me.DateTimePicker1.Text & "','0'")
                'Next'upddetil
                If updheader Then MsgBox("Data telah disimpan !", MsgBoxStyle.Information, "MP") Else Me.TextBox1.Text = "" : MsgBox("Data gagal disimpan !", MsgBoxStyle.Critical, "MP")
                'Me.txtguid.Tag = "cost_id"
            Else
                'Update
                updheader = Fillobject(Me.txtguid, Me.Panel1, "update", "sp_tr_costing", "", "@cost_id") 'update header
                upddetil = True 'Executestr("EXEC sp_tr_costing_dtl 'update', '" & Format(Date.Now(), "MM/dd/yyyy hh:mm:ss tt") & "','" & My.Settings.UserName & "','" & Format(Date.Now(), "MM/dd/yyyy hh:mm:ss tt") & "','" & My.Settings.UserName & "','" & Me.txtguid_d.Text & "','" & Me.txtguid.Text & "','" & Me.txtskuid.Text & "','" & Me.TextBox5.Text & "','" & CDbl(Me.TextBox6.Text) & "','" & Me.datetimepicker1.Text & "','0'")'update detil
                If updheader And upddetil Then MsgBox("Data telah disimpan ulang !", MsgBoxStyle.Information, "MP") Else Me.TextBox1.Text = "" : MsgBox("Data gagal disimpan ulang !", MsgBoxStyle.Critical, "MP")
            End If
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

    Private Sub cmdfind_Click(sender As System.Object, e As System.EventArgs) Handles cmdfind.Click
        'If Not CheckAuthor(curlevel, "isallowfilter", "FDLCreateEvent", True) Then Exit Sub
        Dim child As New FDLSearch()
        child.txtopenargs.Text = "7"
        If child.ShowDialog() = DialogResult.OK Then
            Me.txtguid.Text = child.txtChildText0.Text
        End If
    End Sub

    Private Sub cmddel_Click(sender As System.Object, e As System.EventArgs) Handles cmddel.Click
        'del
    End Sub

    Private Sub cmdnew_Click(sender As System.Object, e As System.EventArgs) Handles cmdnew.Click
        kosong()
    End Sub

    Private Sub cmdexit_Click(sender As System.Object, e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub cmdprint_Click(sender As System.Object, e As System.EventArgs) Handles cmdprint.Click

    End Sub

    Private Sub txtguid_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtguid.TextChanged
        If Me.txtguid.Text = "0" Or Me.txtguid.Text = "" Then Exit Sub
        isirecord(Me.txtguid.Text)
    End Sub

    Private Sub TextBox12_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox12.KeyPress
        '97 - 122 = Ascii codes for simple letters, '65 - 90  = Ascii codes for capital letters, '48 - 57  = Ascii codes for numbers
        If Asc(e.KeyChar) <> 8 Then If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then e.Handled = True
    End Sub

    Private Sub TextBox13_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox13.KeyPress
        '97 - 122 = Ascii codes for simple letters, '65 - 90  = Ascii codes for capital letters, '48 - 57  = Ascii codes for numbers
        If Asc(e.KeyChar) <> 8 Then If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then e.Handled = True
    End Sub

    Private Sub TextBox14_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox14.KeyPress
        '97 - 122 = Ascii codes for simple letters, '65 - 90  = Ascii codes for capital letters, '48 - 57  = Ascii codes for numbers
        If Asc(e.KeyChar) <> 8 Then If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then e.Handled = True
    End Sub

    Private Sub TextBox15_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox15.KeyPress
        '97 - 122 = Ascii codes for simple letters, '65 - 90  = Ascii codes for capital letters, '48 - 57  = Ascii codes for numbers
        If Asc(e.KeyChar) <> 8 Then If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then e.Handled = True
    End Sub

    Private Sub TextBox16_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox16.KeyPress
       '97 - 122 = Ascii codes for simple letters, '65 - 90  = Ascii codes for capital letters, '48 - 57  = Ascii codes for numbers
        If Asc(e.KeyChar) <> 8 Then If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then e.Handled = True
    End Sub

    Private Sub TextBox17_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox17.KeyPress
         '97 - 122 = Ascii codes for simple letters, '65 - 90  = Ascii codes for capital letters, '48 - 57  = Ascii codes for numbers
        If Asc(e.KeyChar) <> 8 Then If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then e.Handled = True
    End Sub

    Private Sub TextBox18_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox18.KeyPress
        '97 - 122 = Ascii codes for simple letters, '65 - 90  = Ascii codes for capital letters, '48 - 57  = Ascii codes for numbers
        If Asc(e.KeyChar) <> 8 Then If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then e.Handled = True
    End Sub
    Private Sub TextBox12_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox12.TextChanged
        Me.TextBox19.Text = HITUNGDETAIL()
    End Sub
    Private Function HITUNGDETAIL() As Decimal
        'Decimal.Ceiling(sqlReader.Item(ctrl.Tag).ToString)
        HITUNGDETAIL = (Decimal.Ceiling(IIf(Me.TextBox12.Text = "", 0, Me.TextBox12.Text)) * Decimal.Ceiling(IIf(Me.TextBox13.Text = "", 0, Me.TextBox13.Text)) * Decimal.Ceiling(IIf(Me.TextBox14.Text = "", 0, Me.TextBox14.Text)) * Decimal.Ceiling(IIf(Me.TextBox15.Text = "", 0, Me.TextBox15.Text))) - (Decimal.Ceiling(IIf(Me.TextBox16.Text = "", 0, Me.TextBox16.Text)) * Decimal.Ceiling(IIf(Me.TextBox17.Text = "", 0, Me.TextBox17.Text)) * Decimal.Ceiling(IIf(Me.TextBox18.Text = "", 0, Me.TextBox18.Text)))
    End Function

    Private Sub TextBox13_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox13.TextChanged
        Me.TextBox19.Text = HITUNGDETAIL()
    End Sub

    Private Sub TextBox14_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox14.TextChanged
        Me.TextBox19.Text = HITUNGDETAIL()
    End Sub

    Private Sub TextBox15_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox15.TextChanged
        Me.TextBox19.Text = HITUNGDETAIL()
    End Sub

    Private Sub TextBox16_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox16.TextChanged
        Me.TextBox19.Text = HITUNGDETAIL()
    End Sub

    Private Sub TextBox17_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox17.TextChanged
        Me.TextBox19.Text = HITUNGDETAIL()
    End Sub

    Private Sub TextBox18_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox18.TextChanged
        Me.TextBox19.Text = HITUNGDETAIL()
    End Sub

    Private Sub btnSaveD_Click(sender As System.Object, e As System.EventArgs) Handles btnSaveD.Click
        Dim li As ListViewItem, i As Integer
        'If Me.txtguid.Text = "0" Then Exit Sub
        If Me.txtguid.Text <> "0" And Me.txtguid_d.Text <> "0" Then
            'Dim xguid As Integer = GetCurrentID("mp_dtl_pk", "tr_mp_dtl", "mp_id_f=" & Me.txtguid.Text & " and sku_id_f=" & Me.txtskuid.Text)
            ''update SET modified=@modified, modifiedby=@modifiedby, sku_id_f=@sku_id_f, sku_id_desc=@sku_id_desc, mp_qty=@mp_qty, tgl_realisasi_kirim=@tgl_realisasi_kirim
            'Executestr("EXEC sp_tr_mp_dtl 'update', '" & Format(Date.Now(), "MM/dd/yyyy hh:mm:ss tt") & "','" & My.Settings.UserName & "','" & Format(Date.Now(), "MM/dd/yyyy hh:mm:ss tt") & "','" & My.Settings.UserName & "','" & Me.txtguid_d.Text & "','" & Me.txtguid.Text & "','" & Me.txtskuid.Text & "','" & Me.TextBox5.Text & "','" & CDbl(Me.TextBox6.Text) & "','" & Me.dttpmp_tgl.Text & "','0'")
            'opensearchform(Me.ListView1, "mp_dtl_pk", "sku_id_f", "sku_code, sku_id_desc, mp_qty, uom_code, required_delivery_date, delivery_plan_date, tgl_realisasi_kirim", "tr_mp_dtl a inner join tr_mp b on a.mp_id_f=b.mp_pk  inner join mt_sku c on c.sku_id=a.sku_id_f inner join mt_sku_uom d on d.uom_id=c.uom_id inner join tr_so_dtl e on b.so_id_f=e.so_id", "a.mp_id_f in ('" & Me.txtguid.Text & "')", "a.created", 0)
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
                    For a As Integer = ListView1.SelectedItems.Count - 1 To 0
                        ListView1.SelectedItems(a).Remove()
                    Next
                End If

                li = ListView1.Items.Add(Me.txtguid_d.Text)
                li.SubItems.Add(Me.ComboBox6.SelectedValue)
                li.SubItems.Add(Me.ComboBox6.SelectedText)

                li.SubItems.Add(Me.TextBox12.Text)
                li.SubItems.Add(Me.ComboBox7.SelectedValue)
                li.SubItems.Add(Me.ComboBox7.SelectedText)

                li.SubItems.Add(Me.TextBox13.Text)

                li.SubItems.Add(Me.TextBox14.Text)
                li.SubItems.Add(Me.ComboBox9.SelectedValue)
                li.SubItems.Add(Me.ComboBox9.SelectedText)

                li.SubItems.Add(Me.TextBox15.Text)
                li.SubItems.Add(Me.ComboBox10.SelectedValue)
                li.SubItems.Add(Me.ComboBox10.SelectedText)

                li.SubItems.Add(Me.TextBox16.Text)
                li.SubItems.Add(Me.ComboBox11.SelectedValue)
                li.SubItems.Add(Me.ComboBox11.SelectedText)

                li.SubItems.Add(Me.TextBox17.Text)
                li.SubItems.Add(Me.ComboBox12.SelectedValue)
                li.SubItems.Add(Me.ComboBox12.SelectedText)

                li.SubItems.Add(Me.TextBox18.Text)
                li.SubItems.Add(Me.ComboBox13.SelectedValue)
                li.SubItems.Add(Me.ComboBox13.SelectedText)
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
        Me.btnSaveD.Tag = "N"
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
End Class