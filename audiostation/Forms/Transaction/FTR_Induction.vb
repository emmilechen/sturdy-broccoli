Imports System.Data.OleDb
Imports System.Data.SqlClient
Public Class FTR_Induction
    Dim strConnection As String = My.Settings.ConnStr
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Private Sub ClearTextBox(ByVal root As Control)
        On Error Resume Next
        For Each ctrl As Control In root.Controls
            ClearTextBox(ctrl)
            If TypeOf ctrl Is TextBox Then
                CType(ctrl, TextBox).Text = String.Empty
            End If
            If TypeOf ctrl Is DateTimePicker Then
                CType(ctrl, DateTimePicker).Format = DateTimePickerFormat.Custom : CType(ctrl, DateTimePicker).CustomFormat = "yyyy-MM-dd" : CType(ctrl, DateTimePicker).Text = Now.Date
            End If
        Next ctrl
    End Sub
    Private Sub ClearCheckBox(ByVal root As Control)
        On Error Resume Next
        For Each ctrl As Control In root.Controls
            ClearCheckBox(ctrl)
            If TypeOf ctrl Is CheckBox Then
                CType(ctrl, CheckBox).Checked = False
                CType(ctrl, CheckBox).Text = ""
            End If
        Next ctrl
    End Sub
    Private Function kosong()
        ClearTextBox(Me) : ClearCheckBox(Me)
        Me.DateTimePicker1.Focus()
        assignvaltocombo(Me.ComboBox1, "", "c_id", "c_code+'-'+c_name", "mt_customer", "c_code<>''", "c_name")
        assignvaltocombo(Me.ComboBox2, "", "c_id", "c_code+'-'+c_name", "mt_customer", "c_code<>''", "c_name")
        assignvaltocombo(Me.ComboBox3, "", "sku_id", "sku_code+'-'+sku_name", "mt_sku", "sku_id<>''", "sku_code")
        assignvaltocombo(Me.ComboBox4, "", "sku_id", "sku_code+'-'+sku_name", "mt_sku", "sku_id<>''", "sku_code")
        'assignvaltocombo(Me.ComboBox5, "", "eventidd", "eventname+'-'+eventdesc", "T_Event inner join T_EventD on T_Event.eventid=T_EventD.eventidh", "eventno<>''", "eventno")

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

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        If MsgBox("Data akan disimpan, lanjutkan ?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Induction") = MsgBoxResult.Yes Then
            If Me.txtguid.Text = "" Then
                'new
                Dim strsql As String = "Insert Into tr_induction(ind_no,ind_tgl,ind_c_id,ind_sls_code_id,ind_sku_id,ind_mc_id," & _
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
                TextBox1.Text & "','" & DateTimePicker1.Text & "','" & ComboBox1.Text & "','" & ComboBox2.Text & "','" & ComboBox3.Text & "','" & ComboBox4.Text & "','" & _
                DateTimePicker2.Text & "','" & TextBox2.Text & "','" & ComboBox5.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "','" & _
                TextBox6.Text & "','" & TextBox7.Text & "','" & TextBox8.Text & "','" & TextBox9.Text & "','" & ComboBox6.Text & "','" & _
                CheckBox1.Checked & "','" & ComboBox7.Text & "','" & _
                CheckBox2.Checked & "','" & ComboBox8.Text & "','" & _
                CheckBox3.Checked & "','" & ComboBox9.Text & "','" & _
                CheckBox4.Checked & "','" & ComboBox10.Text & "','" & _
                CheckBox10.Checked & "','" & TextBox24.Text & "','" & TextBox25.Text & "','" & _
                CheckBox9.Checked & "','" & TextBox27.Text & "','" & TextBox26.Text & "','" & _
                CheckBox14.Checked & "','" & CheckBox15.Checked & "','" & CheckBox16.Checked & "','" & _
                CheckBox17.Checked & "','" & TextBox31.Text & "','" & TextBox30.Text & "','" & _
                CheckBox18.Checked & "','" & TextBox29.Text & "','" & TextBox28.Text & "','" & _
                CheckBox19.Checked & "','" & TextBox33.Text & "','" & TextBox32.Text & "','" & _
                CheckBox20.Checked & "','" & CheckBox21.Checked & "','" & CheckBox22.Checked & "','" & _
                CheckBox5.Checked & "','" & CheckBox6.Checked & "','" & CheckBox7.Checked & "','" & _
                CheckBox8.Checked & "','" & TextBox35.Text & "','" & TextBox34.Text & "','" & _
                CheckBox11.Checked & "','" & CheckBox12.Checked & "','" & CheckBox13.Checked & "','" & _
                CheckBox23.Checked & "','" & CheckBox24.Checked & "','" & _
                CheckBox28.Checked & "','" & _
                CheckBox27.Checked & "','" & TextBox36.Text & "','" & _
                CheckBox26.Checked & "','" & TextBox37.Text & "','" & _
                CheckBox25.Checked & "','" & CheckBox32.Checked & "','" & CheckBox31.Checked & "','" & CheckBox30.Checked & "','" & CheckBox29.Checked & "','" & _
                CheckBox36.Checked & "','" & TextBox38.Text & "','" & _
                CheckBox35.Checked & "','" & TextBox39.Text & "','" & _
                CheckBox34.Checked & "','" & TextBox21.Text & "','" & _
                CheckBox33.Checked & "','" & TextBox40.Text & "','" & _
                TextBox10.Text & "','" & TextBox11.Text & "','" & TextBox12.Text & "','" & TextBox13.Text & "','" & TextBox14.Text & "','" & TextBox15.Text & "','" & _
                CheckBox40.Checked & "','" & CheckBox39.Checked & "','" & CheckBox38.Checked & "','" & _
                TextBox16.Text & "','" & _
                TextBox17.Text & "','" & TextBox42.Text & "','" & _
                TextBox18.Text & "','" & TextBox41.Text & "','" & _
                TextBox19.Text & "','" & TextBox20.Text & "','" & _
                TextBox43.Text & "','" & ComboBox11.Text & "','" & _
                DateTimePicker3.Text & "','" & TextBox22.Text & "','" & DateTimePicker4.Text & "','" & _
                TextBox23.Text & "',GETDATE(),'" & My.Settings.UserName & "')"

                strsql = strsql
            Else

            End If
        End If
    End Sub
End Class