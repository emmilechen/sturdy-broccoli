Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class FTR_Induction
    Dim strConnection As String = My.Settings.ConnStr
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Private Function checkall(ByVal root As Control, namachkbox As CheckBox)
        Dim chk As CheckBox
        For Each c As Control In root.Controls
            If TypeOf c Is CheckBox Then
                chk = CType(c, CheckBox)
                chk.Checked = namachkbox.Checked
            End If
        Next
    End Function
    Private Function kosong()
        ClearObjectonForm(Me) : ClearCheckBoxonForm(Me)
        Me.DateTimePicker1.Focus() : Me.CheckBox37.Text = "&Semua" : Me.CheckBox41.Text = "&Semua" : Me.CheckBox42.Text = "&Semua" : Me.CheckBox43.Text = "&Semua" : Me.CheckBox44.Text = "&Semua" : Me.CheckBox45.Text = "&Semua" : Me.CheckBox46.Text = "&Semua"
        AssignValuetoCombo(Me.ComboBox1, "", "c_id", "c_code+'-'+c_name", "mt_customer", "c_code<>''", "c_name")
        AssignValuetoCombo(Me.ComboBox2, "", "c_id", "c_code+'-'+c_name", "mt_customer", "c_code<>''", "c_name")
        AssignValuetoCombo(Me.ComboBox3, "", "sku_id", "sku_code+'-'+sku_name", "mt_sku", "sku_id<>''", "sku_code")
        AssignValuetoCombo(Me.ComboBox4, "", "sku_id", "sku_code+'-'+sku_name", "mt_sku", "sku_id<>''", "sku_code")
        AssignValuetoCombo(Me.ComboBox5, "", "sys_dropdown_id", "sys_dropdown_val", "sys_dropdown", "sys_dropdown_whr='sid_status'", "sys_dropdown_sort")
        AssignValuetoCombo(Me.ComboBox11, "", "sys_dropdown_id", "sys_dropdown_val", "sys_dropdown", "sys_dropdown_whr='sid_status'", "sys_dropdown_sort")
        Me.cmdsave.Text = "&Save"
    End Function
    Private Function isirecord(ByVal guidno As String)
        If cn.State = ConnectionState.Closed Then cn.Open()
        Dim cmd As SqlCommand
        Dim str(10) As String
        Dim itm As ListViewItem
        Dim dr As SqlDataReader
        Dim guid As Integer
        If cn.State = ConnectionState.Closed Then cn.Open()
        'fill header
        cmd = New SqlCommand("SELECT * FROM tr_induction where ind_no='" & guidno & "'", cn)
        dr = cmd.ExecuteReader()
        If dr.Read() Then
            Me.txtguid.Text = guidno
            TextBox1.Text = dr.Item("ind_no").ToString()
            DateTimePicker1.CustomFormat = "yyyy-MM-dd"
            DateTimePicker1.Text = dr.Item("ind_tgl").ToString()
            ComboBox1.SelectedValue = dr.Item("ind_c_id").ToString()
            ComboBox2.SelectedValue = dr.Item("ind_sls_code_id").ToString()
            ComboBox3.SelectedValue = dr.Item("ind_sku_id").ToString()
            ComboBox4.SelectedValue = dr.Item("ind_mc_id").ToString()
            DateTimePicker2.CustomFormat = "yyyy-MM-dd"
            DateTimePicker2.Text = dr.Item("ind_tgl_kirim").ToString()
            TextBox2.Text = dr.Item("ind_target_price").ToString()
            ComboBox5.SelectedValue = dr.Item("ind_target_status").ToString()
            TextBox3.Text = dr.Item("ind_qty_po").ToString()
            TextBox4.Text = dr.Item("ind_last_price").ToString()
            TextBox5.Text = dr.Item("ind_komisi").ToString()
            TextBox6.Text = dr.Item("ind_kompetitor1").ToString()
            TextBox7.Text = dr.Item("ind_kompetitor2").ToString()
            TextBox8.Text = dr.Item("ind_kompetitor3").ToString()
            TextBox9.Text = dr.Item("Created").ToString()
            ComboBox6.SelectedValue = dr.Item("createdby").ToString()
            CheckBox1.Checked = dr.Item("material1_st").ToString()
            ComboBox7.SelectedValue = dr.Item("material1_id").ToString()
            CheckBox2.Checked = dr.Item("material2_st").ToString()
            ComboBox8.SelectedValue = dr.Item("material2_id").ToString()
            CheckBox3.Checked = dr.Item("singleface1_st").ToString()
            ComboBox9.SelectedValue = dr.Item("singleface1_id").ToString()
            CheckBox4.Checked = dr.Item("singleface2_st").ToString()
            ComboBox10.SelectedValue = dr.Item("singleface2_id").ToString()
            CheckBox10.Checked = dr.Item("cetak_separasi_st").ToString()
            TextBox24.Text = dr.Item("cetak_separasi_f").ToString()
            TextBox25.Text = dr.Item("cetak_separasi_b").ToString()
            CheckBox9.Checked = dr.Item("cetak_khusus_st").ToString()
            TextBox27.Text = dr.Item("cetak_khusus_f").ToString()
            TextBox26.Text = dr.Item("cetak_khusus_b").ToString()

            CheckBox14.Checked = dr.Item("wb_st").ToString()
            CheckBox15.Checked = dr.Item("uv_st").ToString()
            CheckBox16.Checked = dr.Item("g_ber_st").ToString()

            CheckBox17.Checked = dr.Item("spotwb_st").ToString()
            TextBox31.Text = dr.Item("spotwb_val1").ToString()
            TextBox30.Text = dr.Item("spotwb_val2").ToString()

            CheckBox18.Checked = dr.Item("spotuv_st").ToString()
            TextBox29.Text = dr.Item("spotuv_val1").ToString()
            TextBox28.Text = dr.Item("spotuv_val2").ToString()

            CheckBox19.Checked = dr.Item("freeuv_st").ToString()
            TextBox33.Text = dr.Item("freeuv_val1").ToString()
            TextBox32.Text = dr.Item("freeuv_val2").ToString()

            CheckBox20.Checked = dr.Item("calender_st").ToString()
            CheckBox21.Checked = dr.Item("matdoff_st").ToString()
            CheckBox22.Checked = dr.Item("opv_st").ToString()

            CheckBox5.Checked = dr.Item("lam_glossy").ToString()
            CheckBox6.Checked = dr.Item("lam_doff").ToString()
            CheckBox7.Checked = dr.Item("lam_win").ToString()

            CheckBox8.Checked = dr.Item("win_patch").ToString()
            TextBox35.Text = dr.Item("win_patch_val1").ToString()
            TextBox34.Text = dr.Item("win_patch_val2").ToString()

            CheckBox11.Checked = dr.Item("lam_sf").ToString()
            CheckBox12.Checked = dr.Item("lam_boardsf").ToString()
            CheckBox13.Checked = dr.Item("lam_btb").ToString()

            CheckBox23.Checked = dr.Item("dc_man").ToString()
            CheckBox24.Checked = dr.Item("dc_las").ToString()

            CheckBox28.Checked = dr.Item("stiching").ToString()

            CheckBox27.Checked = dr.Item("embos_st").ToString()
            TextBox36.Text = dr.Item("embos_val").ToString()

            CheckBox26.Checked = dr.Item("hp_st").ToString()
            TextBox37.Text = dr.Item("hp_val").ToString()

            CheckBox25.Checked = dr.Item("kopek_st").ToString()
            CheckBox32.Checked = dr.Item("lock_bottom_st").ToString()
            CheckBox31.Checked = dr.Item("lock_samping_st").ToString()
            CheckBox30.Checked = dr.Item("lem4_st").ToString()
            CheckBox29.Checked = dr.Item("lem6_st").ToString()

            CheckBox36.Checked = dr.Item("p_plas_st").ToString()
            TextBox38.Text = dr.Item("p_plas_val").ToString()

            CheckBox35.Checked = dr.Item("p_box_st").ToString()
            TextBox39.Text = dr.Item("p_box_val").ToString()

            CheckBox34.Checked = dr.Item("sub_box_st").ToString()
            TextBox21.Text = dr.Item("sub_box_val").ToString()

            CheckBox33.Checked = dr.Item("pack_kraft_st").ToString()
            TextBox40.Text = dr.Item("pack_kraft_val").ToString()

            TextBox10.Text = dr.Item("custom1").ToString()
            TextBox11.Text = dr.Item("custom2").ToString()
            TextBox12.Text = dr.Item("custom3").ToString()
            TextBox13.Text = dr.Item("custom4").ToString()
            TextBox14.Text = dr.Item("custom5").ToString()
            TextBox15.Text = dr.Item("custom6").ToString()
   
            CheckBox40.Checked = dr.Item("mount1_val").ToString()
            CheckBox39.Checked = dr.Item("mount2_val").ToString()
            CheckBox38.Checked = dr.Item("mount3_val").ToString()

            TextBox16.Text = dr.Item("alamat_kirim").ToString()
            TextBox17.Text = dr.Item("real1_q").ToString()
            TextBox42.Text = dr.Item("real1_val").ToString()

            TextBox18.Text = dr.Item("real2_q").ToString()
            TextBox41.Text = dr.Item("real2_val").ToString()

            TextBox19.Text = dr.Item("real_3_q").ToString()
            TextBox20.Text = dr.Item("real3_val").ToString()

            TextBox43.Text = dr.Item("komisi_val").ToString()
            ComboBox11.SelectedValue = dr.Item("komisi_st").ToString()

            DateTimePicker3.CustomFormat = "yyyy-MM-dd"
            DateTimePicker3.Text = dr.Item("final_target_delivery").ToString()
            TextBox22.Text = dr.Item("user_submit").ToString()
            DateTimePicker4.CustomFormat = "yyyy-MM-dd"
            DateTimePicker4.Text = dr.Item("time_submit").ToString()

            TextBox23.Text = dr.Item("ind_keterangan").ToString()
        End If
        dr.Close()
        cmd.Dispose()

        ''fill details
        'Me.ListView1.Items.Clear()
        'guid = GetCurrentID("eventid", "t_event", "eventno='" & Me.txteventno.Text & "'")
        'cmd = New OleDbCommand("SELECT * FROM t_eventd where eventidh='" & guid & "'", cn)
        'dr = cmd.ExecuteReader()
        'If dr.HasRows Then
        '    Do While dr.Read()
        '        str(0) = IIf(IsDBNull(dr.Item("eventidd").ToString()), "#", dr.Item("eventidd").ToString())
        '        str(1) = IIf(IsDBNull(dr.Item("eventidh").ToString()), "#", dr.Item("eventidh").ToString())
        '        str(2) = IIf(IsDBNull(dr.Item("eventdesc").ToString()), "#", dr.Item("eventdesc").ToString())
        '        str(3) = IIf(IsDBNull(dr.Item("eventdate").ToString()), "#", Format(CDate(dr.Item("eventdate").ToString()), "yyyy-MM-dd"))
        '        str(4) = IIf(IsDBNull(dr.Item("eventtime").ToString()), "#", Format(CDate(dr.Item("eventtime").ToString()), "hh:mm:ss tt"))
        '        itm = New ListViewItem(str)
        '        Me.ListView1.Items.Add(itm)
        '    Loop
        'End If

        dr.Close()
        cmd.Dispose()
        Me.cmddelete.Enabled = True
        Me.cmdsave.Enabled = True : Me.cmdsave.Text = "&Update"
        'Me.cmdinfo.Enabled = Me.txteventno.Text <> ""
        Me.TextBox1.Focus()
    End Function
    Private Sub FTR_Induction_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        On Error Resume Next
        If cn.State = ConnectionState.Closed Then cn.Open()
        If Me.txtguid.Text = "" Then
            kosong()
        Else
            'isirec
            'kosong()
        End If
    End Sub
    Private Sub CheckBox37_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox37.CheckedChanged
        checkall(Me.Panel6, Me.CheckBox37)
    End Sub
    Private Sub CheckBox41_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox41.CheckedChanged
        checkall(Me.Panel8, Me.CheckBox41)
    End Sub
    Private Sub CheckBox42_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox42.CheckedChanged
        checkall(Me.Panel7, Me.CheckBox42)
    End Sub
    Private Sub CheckBox43_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox43.CheckedChanged
        checkall(Me.Panel12, Me.CheckBox43)
    End Sub
    Private Sub CheckBox44_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox44.CheckedChanged
        checkall(Me.Panel3, Me.CheckBox44)
    End Sub
    Private Sub CheckBox45_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox45.CheckedChanged
        checkall(Me.Panel4, Me.CheckBox45)
    End Sub
    Private Sub CheckBox46_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox46.CheckedChanged
        checkall(Me.Panel10, Me.CheckBox46)
    End Sub
    Private Sub TextBox2_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox2.KeyPress
        If Not checkisnumber(e.KeyChar) Then e.KeyChar = ""
    End Sub
    Private Sub TextBox3_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox3.KeyPress
        If Not checkisnumber(e.KeyChar) Then e.KeyChar = ""
    End Sub
    Private Sub TextBox4_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox4.KeyPress
        If Not checkisnumber(e.KeyChar) Then e.KeyChar = ""
    End Sub
    Private Sub TextBox5_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox5.KeyPress
        If Not checkisnumber(e.KeyChar) Then e.KeyChar = ""
    End Sub
    Private Sub TextBox24_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox24.KeyPress
        If Not checkisnumber(e.KeyChar) Then e.KeyChar = ""
    End Sub
    Private Sub TextBox25_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox25.KeyPress
        If Not checkisnumber(e.KeyChar) Then e.KeyChar = ""
    End Sub
    Private Sub TextBox26_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox26.KeyPress
        If Not checkisnumber(e.KeyChar) Then e.KeyChar = ""
    End Sub
    Private Sub TextBox27_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox27.KeyPress
        If Not checkisnumber(e.KeyChar) Then e.KeyChar = ""
    End Sub
    Private Sub TextBox34_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox34.KeyPress
        If Not checkisnumber(e.KeyChar) Then e.KeyChar = ""
    End Sub
    Private Sub TextBox35_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox35.KeyPress
        If Not checkisnumber(e.KeyChar) Then e.KeyChar = ""
    End Sub
    Private Sub TextBox28_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox28.KeyPress
        If Not checkisnumber(e.KeyChar) Then e.KeyChar = ""
    End Sub
    Private Sub TextBox29_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox29.KeyPress
        If Not checkisnumber(e.KeyChar) Then e.KeyChar = ""
    End Sub
    Private Sub TextBox30_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox30.KeyPress
        If Not checkisnumber(e.KeyChar) Then e.KeyChar = ""
    End Sub
    Private Sub TextBox31_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox31.KeyPress
        If Not checkisnumber(e.KeyChar) Then e.KeyChar = ""
    End Sub
    Private Sub TextBox32_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox32.KeyPress
        If Not checkisnumber(e.KeyChar) Then e.KeyChar = ""
    End Sub
    Private Sub TextBox33_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox33.KeyPress
        If Not checkisnumber(e.KeyChar) Then e.KeyChar = ""
    End Sub
    Private Sub TextBox36_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox36.KeyPress
        If Not checkisnumber(e.KeyChar) Then e.KeyChar = ""
    End Sub
    Private Sub TextBox37_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox37.KeyPress
        If Not checkisnumber(e.KeyChar) Then e.KeyChar = ""
    End Sub
    Private Sub TextBox38_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox38.KeyPress
        If Not checkisnumber(e.KeyChar) Then e.KeyChar = ""
    End Sub
    Private Sub TextBox39_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox39.KeyPress
        If Not checkisnumber(e.KeyChar) Then e.KeyChar = ""
    End Sub
    Private Sub TextBox40_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox40.KeyPress
        If Not checkisnumber(e.KeyChar) Then e.KeyChar = ""
    End Sub
    Private Sub TextBox17_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox17.KeyPress
        If Not checkisnumber(e.KeyChar) Then e.KeyChar = ""
    End Sub
    Private Sub TextBox18_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox18.KeyPress
        If Not checkisnumber(e.KeyChar) Then e.KeyChar = ""
    End Sub
    Private Sub TextBox19_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox19.KeyPress
        If Not checkisnumber(e.KeyChar) Then e.KeyChar = ""
    End Sub
    Private Sub TextBox20_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox20.KeyPress
        If Not checkisnumber(e.KeyChar) Then e.KeyChar = ""
    End Sub
    Private Sub TextBox41_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox41.KeyPress
        If Not checkisnumber(e.KeyChar) Then e.KeyChar = ""
    End Sub
    Private Sub TextBox42_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox42.KeyPress
        If Not checkisnumber(e.KeyChar) Then e.KeyChar = ""
    End Sub
    Private Sub TextBox43_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox43.KeyPress
        If Not checkisnumber(e.KeyChar) Then e.KeyChar = ""
    End Sub
    Private Sub txtguid_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtguid.TextChanged
        Dim xno As String
        If Me.txtguid.Text <> "" Then xno = Me.txtguid.Text : isirecord(xno)
    End Sub

    Private Sub cmdsave_Click(sender As System.Object, e As System.EventArgs) Handles cmdsave.Click
        Dim strsql As String
        If ComboBox5.SelectedValue = "" Then Exit Sub
        If MsgBox("Data akan disimpan " & IIf(Me.txtguid.Text = "", "", "ulang") & ", lanjutkan ?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Induction") = MsgBoxResult.Yes Then
            If Me.txtguid.Text = "" Then
                'new
                Me.TextBox1.Text = GetSysNumber("sinduction", Now.Date)
                strsql = "Insert Into tr_induction(ind_no,ind_tgl,ind_c_id,ind_sls_code_id,ind_sku_id,ind_mc_id," & _
                "ind_tgl_kirim,ind_target_price,ind_target_status,ind_qty_po,ind_last_price,ind_komisi," & _
                "ind_kompetitor1, ind_kompetitor2, ind_kompetitor3, Created, createdby, " & _
                "material1_st, material1_id, " & _
                "material2_st, material2_id, " & _
                "singleface1_st, singleface1_id, " & _
                "singleface2_st, singleface2_id, " & _
                "cetak_separasi_st, cetak_separasi_f, cetak_separasi_b, " & _
                "cetak_khusus_st, cetak_khusus_f, cetak_khusus_b, " & _
                "wb_st, uv_st, g_ber_st, " & _
                "spotwb_st, spotwb_val1, spotwb_val2, " & _
                "spotuv_st, spotuv_val1, spotuv_val2, " & _
                "freeuv_st, freeuv_val1, freeuv_val2, " & _
                "calender_st, matdoff_st, opv_st, " & _
                "lam_glossy, lam_doff, lam_win, " & _
                "win_patch, win_patch_val1, win_patch_val2, " & _
                "lam_sf, lam_boardsf, lam_btb, " & _
                "dc_man, dc_las, " & _
                "stiching, " & _
                "embos_st, embos_val, " & _
                "hp_st, hp_val, " & _
                "kopek_st, lock_bottom_st, lock_samping_st, lem4_st, lem6_st, " & _
                "p_plas_st, p_plas_val, " & _
                "p_box_st, p_box_val, " & _
                "sub_box_st, sub_box_val, " & _
                "pack_kraft_st, pack_kraft_val, " & _
                "custom1, custom2, custom3, custom4, custom5, custom6, " & _
                "mount1_val, mount2_val, mount3_val, " & _
                "alamat_kirim, " & _
                "real1_q, real1_val, " & _
                "real2_q, real2_val, " & _
                "real_3_q, real3_val, " & _
                "komisi_val, komisi_st, " & _
                "final_target_delivery, user_submit, time_submit, " & _
                "ind_keterangan, " & _
                "modified, modifiedby) values ('" & _
                TextBox1.Text & "','" & DateTimePicker1.Text & "','" & ComboBox1.SelectedValue & "','" & ComboBox2.SelectedValue & "','" & ComboBox3.SelectedValue & "','" & ComboBox4.SelectedValue & "','" & _
                DateTimePicker2.Text & "','" & TextBox2.Text & "','" & ComboBox5.SelectedValue & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "','" & _
                TextBox6.Text & "','" & TextBox7.Text & "','" & TextBox8.Text & "','" & TextBox9.Text & "','" & ComboBox6.SelectedValue & "','" & _
                getvalcheck(CheckBox1.Checked) & "','" & ComboBox7.SelectedValue & "','" & _
                getvalcheck(CheckBox2.Checked) & "','" & ComboBox8.SelectedValue & "','" & _
                getvalcheck(CheckBox3.Checked) & "','" & ComboBox9.SelectedValue & "','" & _
                getvalcheck(CheckBox4.Checked) & "','" & ComboBox10.SelectedValue & "','" & _
                getvalcheck(CheckBox10.Checked) & "','" & TextBox24.Text & "','" & TextBox25.Text & "','" & _
                getvalcheck(CheckBox9.Checked) & "','" & TextBox27.Text & "','" & TextBox26.Text & "','" & _
                getvalcheck(CheckBox14.Checked) & "','" & getvalcheck(CheckBox15.Checked) & "','" & getvalcheck(CheckBox16.Checked) & "','" & _
                getvalcheck(CheckBox17.Checked) & "','" & TextBox31.Text & "','" & TextBox30.Text & "','" & _
                getvalcheck(CheckBox18.Checked) & "','" & TextBox29.Text & "','" & TextBox28.Text & "','" & _
                getvalcheck(CheckBox19.Checked) & "','" & TextBox33.Text & "','" & TextBox32.Text & "','" & _
                getvalcheck(CheckBox20.Checked) & "','" & getvalcheck(CheckBox21.Checked) & "','" & getvalcheck(CheckBox22.Checked) & "','" & _
                getvalcheck(CheckBox5.Checked) & "','" & getvalcheck(CheckBox6.Checked) & "','" & getvalcheck(CheckBox7.Checked) & "','" & _
                getvalcheck(CheckBox8.Checked) & "','" & TextBox35.Text & "','" & TextBox34.Text & "','" & _
                getvalcheck(CheckBox11.Checked) & "','" & getvalcheck(CheckBox12.Checked) & "','" & getvalcheck(CheckBox13.Checked) & "','" & _
                getvalcheck(CheckBox23.Checked) & "','" & getvalcheck(CheckBox24.Checked) & "','" & _
                getvalcheck(CheckBox28.Checked) & "','" & _
                getvalcheck(CheckBox27.Checked) & "','" & TextBox36.Text & "','" & _
                getvalcheck(CheckBox26.Checked) & "','" & TextBox37.Text & "','" & _
                getvalcheck(CheckBox25.Checked) & "','" & getvalcheck(CheckBox32.Checked) & "','" & getvalcheck(CheckBox31.Checked) & "','" & getvalcheck(CheckBox30.Checked) & "','" & getvalcheck(CheckBox29.Checked) & "','" & _
                getvalcheck(CheckBox36.Checked) & "','" & TextBox38.Text & "','" & _
                getvalcheck(CheckBox35.Checked) & "','" & TextBox39.Text & "','" & _
                getvalcheck(CheckBox34.Checked) & "','" & TextBox21.Text & "','" & _
                getvalcheck(CheckBox33.Checked) & "','" & TextBox40.Text & "','" & _
                TextBox10.Text & "','" & TextBox11.Text & "','" & TextBox12.Text & "','" & TextBox13.Text & "','" & TextBox14.Text & "','" & TextBox15.Text & "','" & _
                getvalcheck(CheckBox40.Checked) & "','" & getvalcheck(CheckBox39.Checked) & "','" & getvalcheck(CheckBox38.Checked) & "','" & _
                TextBox16.Text & "','" & _
                TextBox17.Text & "','" & TextBox42.Text & "','" & _
                TextBox18.Text & "','" & TextBox41.Text & "','" & _
                TextBox19.Text & "','" & TextBox20.Text & "','" & _
                TextBox43.Text & "','" & ComboBox11.SelectedValue & "','" & _
                DateTimePicker3.Text & "','" & TextBox22.Text & "','" & DateTimePicker4.Text & "','" & _
                TextBox23.Text & "',GETDATE(),'" & My.Settings.UserName & "')"
                If Executestr(strsql) Then UpdSysNumber("sinduction")
            Else
                'update strsql
                strsql = "Update tr_induction set " & _
                "ind_tgl='" & Me.DateTimePicker1.Text & "'," & _
                "ind_c_id='" & Me.ComboBox1.SelectedValue & "'," & _
                "ind_sls_code_id='" & Me.ComboBox2.SelectedValue & "'," & _
                "ind_sku_id='" & Me.ComboBox3.SelectedValue & "'," & _
                "ind_mc_id='" & Me.ComboBox4.SelectedValue & "'," & _
                "ind_tgl_kirim='" & Me.DateTimePicker2.Text & "'," & _
                "ind_target_price='" & Me.TextBox2.Text & "'," & _
                "ind_target_status='" & Me.ComboBox5.SelectedValue & "'," & _
                "ind_qty_po='" & Me.TextBox3.Text & "'," & _
                "ind_last_price='" & Me.TextBox4.Text & "'," & _
                "ind_komisi='" & Me.TextBox5.Text & "'," & _
                "ind_kompetitor1='" & Me.TextBox6.Text & "'," & _
                "ind_kompetitor2='" & Me.TextBox7.Text & "'," & _
                "ind_kompetitor3='" & Me.TextBox8.Text & "'," & _
                "material1_st='" & getvalcheck(Me.CheckBox1.Checked) & "'," & _
                "material1_id='" & Me.ComboBox7.SelectedValue & "'," & _
                "material2_st='" & getvalcheck(Me.CheckBox2.Checked) & "'," & _
                "material2_id='" & Me.ComboBox8.SelectedValue & "'," & _
                "singleface1_st='" & getvalcheck(Me.CheckBox3.Checked) & "'," & _
                "singleface1_id='" & Me.ComboBox9.SelectedValue & "'," & _
                "singleface2_st='" & getvalcheck(Me.CheckBox4.Checked) & "'," & _
                "singleface2_id='" & Me.ComboBox10.SelectedValue & "'," & _
                "cetak_separasi_st='" & getvalcheck(Me.CheckBox10.Checked) & "'," & _
                "cetak_separasi_f='" & Me.TextBox24.Text & "'," & _
                "cetak_separasi_b='" & Me.TextBox25.Text & "'," & _
                "cetak_khusus_st='" & getvalcheck(Me.CheckBox9.Checked) & "'," & _
                "cetak_khusus_f='" & Me.TextBox27.Text & "'," & _
                "cetak_khusus_b='" & Me.TextBox26.Text & "'," & _
                "wb_st='" & getvalcheck(Me.CheckBox14.Checked) & "'," & _
                "uv_st='" & getvalcheck(Me.CheckBox15.Checked) & "'," & _
                "g_ber_st='" & getvalcheck(Me.CheckBox16.Checked) & "'," & _
                "spotwb_st='" & getvalcheck(Me.CheckBox17.Checked) & "'," & _
                "spotwb_val1='" & Me.TextBox31.Text & "'," & _
                "spotwb_val2='" & Me.TextBox30.Text & "'," & _
                "spotuv_st='" & getvalcheck(Me.CheckBox18.Checked) & "'," & _
                "spotuv_val1='" & Me.TextBox29.Text & "'," & _
                "spotuv_val2='" & Me.TextBox28.Text & "'," & _
                "freeuv_st='" & getvalcheck(Me.CheckBox19.Checked) & "'," & _
                "freeuv_val1='" & Me.TextBox33.Text & "'," & _
                "freeuv_val2='" & Me.TextBox32.Text & "'," & _
                "calender_st='" & getvalcheck(Me.CheckBox20.Checked) & "'," & _
                "matdoff_st='" & getvalcheck(Me.CheckBox21.Checked) & "'," & _
                "opv_st='" & getvalcheck(Me.CheckBox22.Checked) & "'," & _
                "lam_glossy='" & getvalcheck(Me.CheckBox5.Checked) & "'," & _
                "lam_doff='" & getvalcheck(Me.CheckBox6.Checked) & "'," & _
                "lam_win='" & getvalcheck(Me.CheckBox7.Checked) & "'," & _
                "win_patch='" & getvalcheck(Me.CheckBox8.Checked) & "'," & _
                "win_patch_val1='" & Me.TextBox35.Text & "'," & _
                "win_patch_val2='" & Me.TextBox34.Text & "'," & _
                "lam_sf='" & getvalcheck(Me.CheckBox11.Checked) & "'," & _
                "lam_boardsf='" & getvalcheck(Me.CheckBox12.Checked) & "'," & _
                "lam_btb='" & getvalcheck(Me.CheckBox13.Checked) & "'," & _
                "dc_man='" & getvalcheck(Me.CheckBox23.Checked) & "'," & _
                "dc_las='" & getvalcheck(Me.CheckBox24.Checked) & "'," & _
                "stiching='" & getvalcheck(Me.CheckBox28.Checked) & "'," & _
                "embos_st='" & getvalcheck(Me.CheckBox27.Checked) & "'," & _
                "embos_val='" & Me.TextBox36.Text & "'," & _
                "hp_st='" & getvalcheck(Me.CheckBox26.Checked) & "'," & _
                "hp_val='" & Me.TextBox37.Text & "'," & _
                "kopek_st='" & getvalcheck(Me.CheckBox25.Checked) & "'," & _
                "lock_bottom_st='" & getvalcheck(Me.CheckBox32.Checked) & "'," & _
                "lock_samping_st='" & getvalcheck(Me.CheckBox31.Checked) & "'," & _
                "lem4_st='" & getvalcheck(Me.CheckBox30.Checked) & "'," & _
                "lem6_st='" & getvalcheck(Me.CheckBox29.Checked) & "'," & _
                "p_plas_st='" & getvalcheck(Me.CheckBox36.Checked) & "'," & _
                "p_plas_val='" & Me.TextBox38.Text & "'," & _
                "p_box_st='" & getvalcheck(Me.CheckBox35.Checked) & "'," & _
                "p_box_val='" & Me.TextBox39.Text & "'," & _
                "sub_box_st='" & getvalcheck(Me.CheckBox34.Checked) & "'," & _
                "sub_box_val='" & Me.TextBox21.Text & "'," & _
                "pack_kraft_st='" & getvalcheck(Me.CheckBox33.Checked) & "'," & _
                "pack_kraft_val='" & Me.TextBox40.Text & "'," & _
                "custom1='" & Me.TextBox10.Text & "'," & _
                "custom2='" & Me.TextBox11.Text & "'," & _
                "custom3='" & Me.TextBox12.Text & "'," & _
                "custom4='" & Me.TextBox13.Text & "'," & _
                "custom5='" & Me.TextBox14.Text & "'," & _
                "custom6='" & Me.TextBox15.Text & "'," & _
                "mount1_val='" & getvalcheck(Me.CheckBox40.Checked) & "'," & _
                "mount2_val='" & getvalcheck(Me.CheckBox39.Checked) & "'," & _
                "mount3_val='" & getvalcheck(Me.CheckBox38.Checked) & "'," & _
                "alamat_kirim='" & Me.TextBox16.Text & "'," & _
                "real1_q='" & Me.TextBox17.Text & "'," & _
                "real1_val='" & Me.TextBox42.Text & "'," & _
                "real2_q='" & Me.TextBox18.Text & "'," & _
                "real2_val='" & Me.TextBox41.Text & "'," & _
                "real_3_q='" & Me.TextBox19.Text & "'," & _
                "real3_val='" & Me.TextBox20.Text & "'," & _
                "komisi_val='" & Me.TextBox43.Text & "'," & _
                "komisi_st='" & Me.ComboBox11.SelectedValue & "'," & _
                "final_target_delivery='" & DateTimePicker3.Text & "'," & _
                "user_submit='" & Me.TextBox22.Text & "'," & _
                "time_submit='" & DateTimePicker4.Text & "'," & _
                "ind_keterangan='" & Me.TextBox23.Text & "'" & _
                "where ind_no='" & Me.TextBox1.Text & "'"
                If Executestr(strsql) Then MsgBox("Data telah diperbaharui !", MsgBoxStyle.Information, "Induction")

            End If
        End If
    End Sub

    Private Sub cmdfind_Click(sender As System.Object, e As System.EventArgs) Handles cmdfind.Click
        'If Not CheckAuthor(curlevel, "isallowfilter", "FDLCreateEvent", True) Then Exit Sub
        Dim child As New FDLSearch()
        child.txtopenargs.Text = "0"
        If child.ShowDialog() = DialogResult.OK Then
            Me.txtguid.Text = child.txtChildText0.Text
        End If
    End Sub
    Private Sub cmdprint_Click(sender As System.Object, e As System.EventArgs) Handles cmdprint.Click
        Dim strConnection As String = My.Settings.ConnStr
        Dim Connection As New SqlConnection(strConnection)
        Dim strSQL As String

        strSQL = "exec RPT_Induction_Form '" & TextBox1.Text & "' "
        Dim DA As New SqlDataAdapter(strSQL, Connection)
        Dim DS As New DataSet

        DA.Fill(DS, "SO_")

        Dim strReportPath As String = Application.StartupPath & "\Reports\RPT_Induction_Form.rpt"

        If Not IO.File.Exists(strReportPath) Then
            Throw (New Exception("Unable to locate report file:" & _
              vbCrLf & strReportPath))
        End If

        Dim cr As New ReportDocument
        Dim NewMDIChild As New frmDocViewer()
        NewMDIChild.Text = "Induction Form"
        NewMDIChild.Show()

        cr.Load(strReportPath)
        cr.SetDataSource(DS.Tables("SO_"))
        With NewMDIChild
            .myCrystalReportViewer.ShowRefreshButton = False
            .myCrystalReportViewer.ShowCloseButton = False
            .myCrystalReportViewer.ShowGroupTreeButton = False
            .myCrystalReportViewer.ReportSource = cr
        End With
    End Sub
End Class