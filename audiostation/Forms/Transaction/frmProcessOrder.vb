Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class frmProcessOrder
    Private m_SOId As Integer, m_CId As Integer
    Private namatable As String, namafieldPK As String
    Dim strConnection As String = My.Settings.ConnStr
    Private strConn As String = My.Settings.ConnStr
    Private sqlCon As SqlConnection
    Dim cn As SqlConnection = New SqlConnection(strConnection)

    Private Function kosong()
        ClearObjectonForm(Me)
        '        AssignValuetoCombo(Me.cmbcust, "", "c_id", "c_code+'-'+c_name", "mt_customer", "c_code<>''", "c_name")
        '        AssignValuetoCombo(Me.cmbmp_st, "", "primarykey", "sys_dropdown_val", "sys_dropdown", "sys_dropdown_whr='wo_status'", "sys_dropdown_sort")
        With Me
            .ListView1.Columns.Clear()
            .ListView1.Columns.Add("Kolom 0", "guid1", 0)
            .ListView1.Columns.Add("Kolom 1", "skuid", 0)
            .ListView1.Columns.Add("Kolom 2", "Code", Me.TextBox8.Width + 5)
            .ListView1.Columns.Add("Kolom 3", "Plano Size", Me.TextBox9.Width + 5)
            .ListView1.Columns.Add("Kolom 4", "Plano Amount", Me.TextBox6.Width + 5)
            .ListView1.Columns.Add("Kolom 5", "UoM", Me.TextBox1.Width + 5)

            .ListView2.Columns.Clear()
            .ListView2.Columns.Add("Kolom 0", "guid2", 0)
            .ListView2.Columns.Add("Kolom 1", "skuid", 0)
            .ListView2.Columns.Add("Kolom 2", "Code", Me.TextBox17.Width + 5)
            .ListView2.Columns.Add("Kolom 3", "Qty", Me.TextBox16.Width + 5)
            .ListView2.Columns.Add("Kolom 4", "UoM", Me.TextBox15.Width + 5)
            .ListView2.Columns.Add("Kolom 5", "Group By", Me.TextBox18.Width + 5)

            .ListView3.Columns.Clear()
            .ListView3.Columns.Add("Kolom 0", "guid3", 0)
            .ListView3.Columns.Add("Kolom 1", "Text1", Me.TextBox20.Width + 5)
            .ListView3.Columns.Add("Kolom 2", "Text2", Me.TextBox19.Width + 5)
            .ListView3.Columns.Add("Kolom 3", "Text3", Me.TextBox21.Width + 10)
        End With
        Me.ListView1.Items.Clear()
        Me.ListView2.Items.Clear()
        Me.ListView3.Items.Clear()
        Me.txtguid.Text = "0"
        Me.btnSaveD1.Tag = "N"
        Me.btnSaveD2.Tag = "N"
        Me.btnSaveD3.Tag = "N"
        '        Me.ToolStrip2.Enabled = False
        Me.cmdcancel.Enabled = False : Me.cmddelete.Enabled = False : Me.cmdprint.Enabled = False
        'Tab1
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox14.Text = ""
        dtp1.Value = Now.Date

        'Tab2
        TextBox8.Text = ""
        TextBox9.Text = ""
        TextBox10.Text = ""
        TextBox22.Text = ""

        'Tab3
        TextBox7.Text = ""
        TextBox11.Text = ""
        TextBox12.Text = ""
        TextBox15.Text = ""
        TextBox16.Text = ""
        TextBox17.Text = ""
        TextBox18.Text = ""

    End Function
    Private Function isirecord(ByVal guidno As Integer)
        Me.txtguid.Text = guidno
        Fillobject(Me.txtguid, Me, "select", "usp_tr_proder", Me.txtguid.Text, "@proder_pk")
        opensearchform(Me.ListView1, "proder_dtl_pk1", "sku_id_f", "sku_code, raw_description, plano_size, plano_amount, uom_name", "tr_proder_dtl1 a inner join tr_proder b on a.proder_id_f=b.proder_id_pk  inner join mt_sku c on c.sku_id=a.sku_id_f inner join mt_sku_uom d on d.uom_id=c.uom_id inner join tr_so_dtl e on b.so_dtl_id_f=e.so_dtl_id", "a.proder_id_f in ('" & guidno & "')", "a.created", 0)
        btnSO.Enabled = False
        Me.cmdcancel.Enabled = True : Me.cmddelete.Enabled = True : Me.cmdprint.Enabled = True
    End Function
    Private Function opensearchform(ByVal namalistview As ListView, ByVal strfield1 As String, ByVal strfield2 As String, ByVal strfield3 As String, ByVal strtabel As String, ByVal strwhr As String, ByVal strord As String, Optional ByVal openargs As Integer = 0) As String
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
                    str(1) = IIf(IsDBNull(dr.Item(1).ToString()), "#", dr.Item(1).ToString())
                    str(2) = IIf(IsDBNull(dr.Item(2).ToString()), "#", dr.Item(2).ToString())
                    str(3) = IIf(IsDBNull(dr.Item(3).ToString()), "#", dr.Item(3).ToString())
                    str(4) = IIf(IsDBNull(dr.Item(4).ToString()), "#", dr.Item(4).ToString())
                    str(5) = IIf(IsDBNull(dr.Item(5).ToString()), "#", dr.Item(5).ToString())
                    str(6) = IIf(IsDBNull(dr.Item(6).ToString()), "#", Format(CDate(dr.Item(6).ToString()), "yyyy-MM-dd"))
                    str(7) = IIf(IsDBNull(dr.Item(7).ToString()), "#", Format(CDate(dr.Item(7).ToString()), "yyyy-MM-dd"))
                    str(8) = IIf(IsDBNull(dr.Item(8).ToString()), "#", Format(CDate(dr.Item(8).ToString()), "yyyy-MM-dd"))
                    itm = New ListViewItem(str)
                    .Items.Add(itm)
                Loop
            End If
            dr.Close()
            cmd.Dispose()
        End With
    End Function
    '    Private Sub ftr_mp_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    '        Me.Top = 0 : Me.Left = 0
    '        If cn.State = ConnectionState.Closed Then cn.Open()
    '        kosong()
    '    End Sub
    '    Private Sub btnCustomer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCustomer.Click
    '        Dim NewFormDialog As New fdlCUtility
    '        NewFormDialog.FrmCallerId = Me.Name
    '        NewFormDialog.Tag = "1"
    '        NewFormDialog.ShowDialog()
    '    End Sub

    '    Private Sub cmbcust_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbcust.SelectedIndexChanged
    '        On Error Resume Next
    '        ' Me.btnCustomer.Enabled = Me.cmbcust.SelectedValue <> "0" ' Me.cmbcust.SelectedIndex > 0
    '        Me.btnCustomer.Enabled = Me.cmbcust.SelectedIndex >= 0
    '    End Sub

    '    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
    '        If Me.txtsono.Text = "" Then Exit Sub
    '        Dim NewFormDialog As New fdlCUtility
    '        NewFormDialog.FrmCallerId = Me.Name
    '        NewFormDialog.Tag = "2"
    '        NewFormDialog.ShowDialog()
    '    End Sub

    Private Sub btnSaveD1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveD1.Click
        Dim li As ListViewItem, i As Integer
        If Me.txtguid.Text = "0" Then Exit Sub
        If Me.txtguid.Text <> "0" And Me.txtguid_d1.Text <> "0" Then
            Dim xguid As Integer = GetCurrentID("mp_dtl_pk", "tr_mp_dtl", "mp_id_f=" & Me.txtguid.Text & " and sku_id_f=" & Me.txtskuid.Text)
            'update SET modified=@modified, modifiedby=@modifiedby, sku_id_f=@sku_id_f, sku_id_desc=@sku_id_desc, mp_qty=@mp_qty, tgl_realisasi_kirim=@tgl_realisasi_kirim
            Executestr("EXEC usp_tr_proder_dtl 'update', '" & Format(Date.Now(), "MM/dd/yyyy hh:mm:ss tt") & "','" & My.Settings.UserName & "','" & Format(Date.Now(), "MM/dd/yyyy hh:mm:ss tt") & "','" & My.Settings.UserName & "','" & Me.txtguid_d1.Text & "','" & Me.txtguid.Text & "','" & Me.txtskuid.Text & "','" & Me.TextBox5.Text & "','" & CDbl(Me.TextBox6.Text) & "','" & Me.dttpmp_tgl.Text & "','0'")
            opensearchform(Me.ListView1, "proder_dtl_pk", "sku_id_f", "sku_code, sku_id_desc, mp_qty, uom_code, required_delivery_date, delivery_plan_date, tgl_realisasi_kirim", "tr_mp_dtl a inner join tr_mp b on a.mp_id_f=b.mp_pk  inner join mt_sku c on c.sku_id=a.sku_id_f inner join mt_sku_uom d on d.uom_id=c.uom_id inner join tr_so_dtl e on b.so_id_f=e.so_id", "a.mp_id_f in ('" & Me.txtguid.Text & "')", "a.created", 0)
        Else
            'insert
            '            If FindSubItem(ListView1, Me.txtskuid.Text) = True And Me.btnSaveD.Tag = "N" Then
            '                'it is a duplicate do something
            '                MsgBox("Duplicate data !", MsgBoxStyle.Critical, "Production Memo")
            '                Exit Sub
            '            Else
            '                'it is not a duplicate, go ahead and add it.
            '                If Me.btnSaveD.Tag = "N" Then

            '                Else
            '                    For a As Integer = ListView1.SelectedItems.Count - 1 To 0
            '                        ListView1.SelectedItems(a).Remove()
            '                    Next
            '                End If
            '                i = Me.ListView1.Items.Count + 1
            '                li = ListView1.Items.Add(Me.txtguid_d.Text)
            '                li.SubItems.Add(Me.txtskuid.Text)
            '                li.SubItems.Add(Me.TextBox4.Text)
            '                li.SubItems.Add(Me.TextBox5.Text)
            '                li.SubItems.Add(Me.TextBox6.Text)
            '                li.SubItems.Add(Me.TextBox1.Text)
            '                li.SubItems.Add(Me.TextBox7.Text)
            '                li.SubItems.Add(Me.TextBox8.Text)
            '                li.SubItems.Add(Me.DateTimePicker1.Text)
            '            End If
        End If
        Me.txtguid_d1.Text = ""

        'Tab2
        TextBox8.Text = ""
        TextBox9.Text = ""
        TextBox10.Text = ""
        TextBox22.Text = ""

        Me.btnSaveD1.Tag = "N"
        Me.btnSaveD2.Tag = "N"
        Me.btnSaveD3.Tag = "N"
    End Sub
    Private Function FindSubItem(ByVal lv As ListView, ByVal SearchString As String) As Boolean
        'find column index in listview by name "acctcode"
        Dim idx = (From c In ListView1.Columns Where c.Text = "skuid" Select c = c.Index).First()
        For Each itm As ListViewItem In lv.Items
            'search only subitems of column "acctcode"
            If itm.SubItems(idx).Text = SearchString Then Return True
        Next
        Return False
    End Function

    Private Sub ListView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.SelectedIndexChanged
        If ListView1.SelectedItems.Count > 0 Then
            Me.txtguid_d1.Text = Me.ListView1.Items(ListView1.FocusedItem.Index).Text
            'Me.txtskuid.Text = Me.ListView1.Items(ListView1.FocusedItem.Index).SubItems(1).Text
            'Me.TextBox4.Text = Me.ListView1.Items(ListView1.FocusedItem.Index).SubItems(2).Text
            'Me.TextBox5.Text = Me.ListView1.Items(ListView1.FocusedItem.Index).SubItems(3).Text
            'Me.TextBox6.Text = Me.ListView1.Items(ListView1.FocusedItem.Index).SubItems(4).Text
            'Me.TextBox1.Text = Me.ListView1.Items(ListView1.FocusedItem.Index).SubItems(5).Text
            'Me.TextBox7.Text = Me.ListView1.Items(ListView1.FocusedItem.Index).SubItems(6).Text
            'Me.TextBox8.Text = Me.ListView1.Items(ListView1.FocusedItem.Index).SubItems(7).Text
            'Me.DateTimePicker1.Text = Me.ListView1.Items(ListView1.FocusedItem.Index).SubItems(8).Text
            Me.btnSaveD1.Tag = "E"
        End If
    End Sub

    Private Sub ListView2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView2.SelectedIndexChanged
        If ListView2.SelectedItems.Count > 0 Then
            Me.txtguid_d2.Text = Me.ListView2.Items(ListView2.FocusedItem.Index).Text
            'Me.txtskuid.Text = Me.ListView1.Items(ListView1.FocusedItem.Index).SubItems(1).Text
            'Me.TextBox4.Text = Me.ListView1.Items(ListView1.FocusedItem.Index).SubItems(2).Text
            'Me.TextBox5.Text = Me.ListView1.Items(ListView1.FocusedItem.Index).SubItems(3).Text
            'Me.TextBox6.Text = Me.ListView1.Items(ListView1.FocusedItem.Index).SubItems(4).Text
            'Me.TextBox1.Text = Me.ListView1.Items(ListView1.FocusedItem.Index).SubItems(5).Text
            'Me.TextBox7.Text = Me.ListView1.Items(ListView1.FocusedItem.Index).SubItems(6).Text
            'Me.TextBox8.Text = Me.ListView1.Items(ListView1.FocusedItem.Index).SubItems(7).Text
            'Me.DateTimePicker1.Text = Me.ListView1.Items(ListView1.FocusedItem.Index).SubItems(8).Text
            Me.btnSaveD2.Tag = "E"
        End If
    End Sub

    Private Sub ListView3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView3.SelectedIndexChanged
        If ListView3.SelectedItems.Count > 0 Then
            Me.txtguid_d3.Text = Me.ListView3.Items(ListView1.FocusedItem.Index).Text
            'Me.txtskuid.Text = Me.ListView1.Items(ListView1.FocusedItem.Index).SubItems(1).Text
            'Me.TextBox4.Text = Me.ListView1.Items(ListView1.FocusedItem.Index).SubItems(2).Text
            'Me.TextBox5.Text = Me.ListView1.Items(ListView1.FocusedItem.Index).SubItems(3).Text
            'Me.TextBox6.Text = Me.ListView1.Items(ListView1.FocusedItem.Index).SubItems(4).Text
            'Me.TextBox1.Text = Me.ListView1.Items(ListView1.FocusedItem.Index).SubItems(5).Text
            'Me.TextBox7.Text = Me.ListView1.Items(ListView1.FocusedItem.Index).SubItems(6).Text
            'Me.TextBox8.Text = Me.ListView1.Items(ListView1.FocusedItem.Index).SubItems(7).Text
            'Me.DateTimePicker1.Text = Me.ListView1.Items(ListView1.FocusedItem.Index).SubItems(8).Text
            Me.btnSaveD3.Tag = "E"
        End If
    End Sub

    Private Sub btnDeleteD1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteD1.Click
        If Me.txtSONo.Text = "" Or Me.txtguid.Text = "0" Then Exit Sub
        If Me.txtguid.Text <> "0" And Me.txtguid_d1.Text <> "0" Then
            Dim xguid As Integer = GetCurrentID("proder_dtl_pk", "tr_proder_dtl", "proder_id_f=" & Me.txtguid.Text & " and sku_id_f=" & Me.txtskuid.Text)
            'update SET modified=@modified, modifiedby=@modifiedby, sku_id_f=@sku_id_f, sku_id_desc=@sku_id_desc, mp_qty=@mp_qty, tgl_realisasi_kirim=@tgl_realisasi_kirim
            Executestr("EXEC usp_tr_proder_dtl 'delete', null,null," & Format(Date.Now(), "MM/dd/yyyy hh:mm:ss tt") & "','" & My.Settings.UserName & "','" & Me.txtguid.Text)
            opensearchform(Me.ListView1, "proder_dtl_pk", "sku_id_f", "sku_code, sku_id_desc, mp_qty, uom_code, required_delivery_date, delivery_plan_date, tgl_realisasi_kirim", "tr_mp_dtl a inner join tr_mp b on a.mp_id_f=b.mp_pk  inner join mt_sku c on c.sku_id=a.sku_id_f inner join mt_sku_uom d on d.uom_id=c.uom_id inner join tr_so_dtl e on b.so_id_f=e.so_id", "a.mp_id_f in ('" & Me.txtguid.Text & "')", "a.created", 0)
        Else
            If ListView1.SelectedItems.Count > 0 Then
                For a As Integer = ListView1.SelectedItems.Count - 1 To 0
                    ListView1.SelectedItems(a).Remove()
                Next
            End If
        End If
    End Sub
    '    Private Sub btnAddD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddD.Click

    '    End Sub
    '    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
    '        'find
    '        'If Not CheckAuthor(curlevel, "isallowfilter", "FDLCreateEvent", True) Then Exit Sub
    '        Dim child As New FDLSearch()
    '        child.txtopenargs.Text = "3"
    '        If child.ShowDialog() = DialogResult.OK Then
    '            Me.txt_mp_pk.Text = child.txtChildText0.Text
    '        End If
    '    End Sub

    '    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancel.Click
    '        'cancel
    '    End Sub

    '    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddel.Click


    '    End Sub
    '    Private Sub ToolStripButton6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton6.Click
    '        Me.Close()
    '    End Sub

    '    Private Sub txtguid_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtguid.TextChanged
    '        Me.txtmp_id_f.Text = Me.txtguid.Text
    '    End Sub

    '    Private Sub txt_mp_pk_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_mp_pk.TextChanged
    '        If Me.txt_mp_pk.Text = "0" Or Me.txt_mp_pk.Text = "" Then
    '            'kosong
    '            kosong()
    '        Else
    '            'isi-record
    '            isirecord(Me.txt_mp_pk.Text)
    '        End If
    '    End Sub

    '    Private Sub txtso_id_f_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtso_id_f.TextChanged
    '        If Me.txtso_id_f.Text <> "" And Me.txt_mp_pk.Text <> "0" Then
    '            'isi
    '            Me.txtsono.Text = GetCurrentID("so_no", "tr_so", "so_id=" & Me.txtso_id_f.Text)
    '            Me.txtpono.Text = GetCurrentID("ref_no", "tr_so", "so_id=" & Me.txtso_id_f.Text)
    '            Me.cmbcust.SelectedValue = GetCurrentID("c_id", "tr_so", "so_id=" & Me.txtso_id_f.Text)
    '        Else

    '        End If
    '    End Sub
    '    Private Sub cmdprint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdprint.Click

    '    End Sub

    Private Sub frmProcessOrder_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        kosong()
    End Sub

    Private Sub cmdsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsave.Click
        'save
        Dim updheader As Boolean, upddetil As Boolean, str1 As String, str2 As String
        On Error GoTo err_ToolStripButton1_Click
        If Me.ListView1.Items.Count = 0 Or Me.ListView2.Items.Count = 0 Or Me.ListView3.Items.Count = 0 Then MsgBox("You can't save the record while the detail is empty.", vbCritical + vbOKOnly, Me.Text) : Exit Sub
        If Me.txtSONo.Text = "" Then
            MsgBox("Sales Order No. are primary fields that should be entered. Please enter those fields before you save it.", vbCritical + vbOKOnly, Me.Text)
            txtSONo.Focus()
            Exit Sub
        End If
        If MsgBox("This " & IIf(Me.txtguid.Text = "0", "new", "") & " record will be saved, proceed?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.Yes Then
            namatable = "tr_proder" : namafieldPK = "proder_no"
            If (Me.txtguid.Text = "0") Then
                'Insert new
                txtProderNo.Text = IIf(Me.txtguid.Text = "0", GETGeneralcode("proder", namatable, namafieldPK, "proder_date", dtpProderDate.Value, False, 4, 1, "", ""), txtProderNo.Text)
                updheader = Fillobject(Me.txtguid, Me, "insert", "usp_tr_proder", "", "@proder_pk") 'update header
                For i As Integer = 0 To Me.ListView1.Items.Count - 1
                    'kl blm ada, INSERT
                    upddetil = Executestr("EXEC usp_tr_proder_dtl1 'insert', '" & Format(Date.Now(), "MM/dd/yyyy hh:mm:ss tt") & "','" & My.Settings.UserName & "','" & Format(Date.Now(), "MM/dd/yyyy hh:mm:ss tt") & "','" & My.Settings.UserName & "','" & txtguid_d1.Text & "','" & Me.txtguid.Text & "','" & ListView1.Items(i).SubItems(1).Text & "','" & ListView1.Items(i).SubItems(3).Text & "','" & ListView1.Items(i).SubItems(4).Text & "','" & dtpProderDate.Value & "','0'")
                Next
                For i As Integer = 0 To Me.ListView2.Items.Count - 1
                    'kl blm ada, INSERT
                    upddetil = Executestr("EXEC usp_tr_proder_dtl2 'insert', '" & Format(Date.Now(), "MM/dd/yyyy hh:mm:ss tt") & "','" & My.Settings.UserName & "','" & Format(Date.Now(), "MM/dd/yyyy hh:mm:ss tt") & "','" & My.Settings.UserName & "','" & txtguid_d1.Text & "','" & Me.txtguid.Text & "','" & ListView1.Items(i).SubItems(1).Text & "','" & ListView1.Items(i).SubItems(3).Text & "','" & ListView1.Items(i).SubItems(4).Text & "','" & dtpProderDate.Value & "','0'")
                Next
                For i As Integer = 0 To Me.ListView3.Items.Count - 1
                    'kl blm ada, INSERT
                    upddetil = Executestr("EXEC usp_tr_proder_dtl3 'insert', '" & Format(Date.Now(), "MM/dd/yyyy hh:mm:ss tt") & "','" & My.Settings.UserName & "','" & Format(Date.Now(), "MM/dd/yyyy hh:mm:ss tt") & "','" & My.Settings.UserName & "','" & txtguid_d1.Text & "','" & Me.txtguid.Text & "','" & ListView1.Items(i).SubItems(1).Text & "','" & ListView1.Items(i).SubItems(3).Text & "','" & ListView1.Items(i).SubItems(4).Text & "','" & dtpProderDate.Value & "','0'")
                Next
                If updheader And upddetil Then MsgBox("New record has been saved!", MsgBoxStyle.Information, Me.Text) Else txtProderNo.Text = "" : MsgBox("New record can't be saved!", MsgBoxStyle.Critical, Me.Text)
            Else
                'Update
                updheader = Fillobject(Me.txtguid, Me, "update", "usp_tr_proder", "", "@proder_pk") 'update header
                upddetil = True 'Executestr("EXEC sp_tr_mp_dtl 'update', '" & Format(Date.Now(), "MM/dd/yyyy hh:mm:ss tt") & "','" & My.Settings.UserName & "','" & Format(Date.Now(), "MM/dd/yyyy hh:mm:ss tt") & "','" & My.Settings.UserName & "','" & Me.txtguid_d.Text & "','" & Me.txtguid.Text & "','" & Me.txtskuid.Text & "','" & Me.TextBox5.Text & "','" & CDbl(Me.TextBox6.Text) & "','" & Me.dttpmp_tgl.Text & "','0'")'update detil
                If updheader And upddetil Then MsgBox("Record has been saved!", MsgBoxStyle.Information, Me.Text) Else txtProderNo.Text = "" : MsgBox("Record can't be saved!", MsgBoxStyle.Critical, Me.Text)
            End If
        Else
            MsgBox("Record was not saved!", MsgBoxStyle.Critical, Me.Text)
        End If
exit_ToolStripButton1_Click:
        If ConnectionState.Open = 1 Then cn.Close()
        Exit Sub

err_ToolStripButton1_Click:
        MsgBox(Err.Description)
        Resume exit_ToolStripButton1_Click
    End Sub

    Private Sub cmdnew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdnew.Click
        'new
        kosong()
    End Sub

    Private Sub cmddelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddelete.Click
        '        'delete
        '        On Error GoTo err_ToolStripButton4_Click
        '        If Me.txtguid.Text = "" Then Exit Sub
        '        If MsgBox("Data akan dihapus, lanjutkan ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "MP") = MsgBoxResult.Yes Then
        '            If Fillobject(Me.txtguid, Me.Panel1, "delete", "sp_tr_mp", "", "@mp_pk") Then MsgBox("Data telah dihapus !", MsgBoxStyle.Information, "MP") Else Me.txtmp_no.Text = "" : MsgBox("Data gagal dihapus !", MsgBoxStyle.Critical, "MP")
        '        Else
        '            MsgBox("Data belum dihapus !", MsgBoxStyle.Critical, "MP")
        '        End If

        'exit_ToolStripButton4_Click:
        '        If ConnectionState.Open = 1 Then cn.Close()
        '        Exit Sub

        'err_ToolStripButton4_Click:
        '        MsgBox(Err.Description)
        '        Resume exit_ToolStripButton4_Click
    End Sub

    Private Sub cmdprint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdprint.Click
        '        Dim strConnection As String = My.Settings.ConnStr
        '        Dim Connection As New SqlConnection(strConnection)
        '        Dim strSQL As String
        '        If Me.txtguid.Text = "0" Or Me.txtguid.Text = "" Then Exit Sub
        '        'strSQL = "exec RPT_Sls_Order_Form '" & txtSONo.Text & "', 'so'"
        '        strSQL = "exec RPT_MP_Form " & Me.txtguid.Text & ", 'mp'"
        '        Dim DA As New SqlDataAdapter(strSQL, Connection)
        '        Dim DS As New DataSet

        '        DA.Fill(DS, "MP_")

        '        Dim strReportPath As String = Application.StartupPath & "\Reports\RPT_MP_Form.rpt"

        '        If Not IO.File.Exists(strReportPath) Then
        '            Throw (New Exception("Unable to locate report file:" & _
        '              vbCrLf & strReportPath))
        '        End If

        '        Dim cr As New ReportDocument
        '        Dim NewMDIChild As New frmDocViewer()
        '        NewMDIChild.Text = "Memo Produksi"
        '        NewMDIChild.Show()

        '        cr.Load(strReportPath)
        '        cr.SetDataSource(DS.Tables("MP_"))
        '        With NewMDIChild
        '            .myCrystalReportViewer.ShowRefreshButton = False
        '            .myCrystalReportViewer.ShowCloseButton = False
        '            .myCrystalReportViewer.ShowGroupTreeButton = False
        '            .myCrystalReportViewer.ReportSource = cr
        '        End With
    End Sub
End Class