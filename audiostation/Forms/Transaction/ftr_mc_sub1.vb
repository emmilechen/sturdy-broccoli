Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class ftr_mc_sub1
    Private m_SOId As Integer, m_CId As Integer
    Private namatable As String, namafieldPK As String
    Dim strConnection As String = My.Settings.ConnStr
    Private strConn As String = My.Settings.ConnStr
    Private sqlCon As SqlConnection
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Dim m_SODtlID As Integer

    Public Property SID() As Integer
        Get
            Return txtSID.Text
        End Get
        Set(ByVal Value As Integer)
            txtSID.Text = Value
        End Set
    End Property

    '    Public Property SKUUoM() As String
    '        Get
    '            Return TextBox22.Text
    '        End Get
    '        Set(ByVal Value As String)
    '            TextBox22.Text = Value
    '        End Set
    '    End Property

    '    Public Property SODtlID() As Integer
    '        Get
    '            Return m_SODtlID
    '        End Get
    '        Set(ByVal Value As Integer)
    '            m_SODtlID = Value
    '        End Set
    '    End Property

    '    Public Property SONo() As String
    '        Get
    '            Return txtSONo.Text
    '        End Get
    '        Set(ByVal Value As String)
    '            txtSONo.Text = Value
    '        End Set
    '    End Property

    '    Public Property CustomerCode() As String
    '        Get
    '            Return txtCCode.Text
    '        End Get
    '        Set(ByVal Value As String)
    '            txtCCode.Text = Value
    '        End Set
    '    End Property

    '    Public Property CustomerName() As String
    '        Get
    '            Return txtCName.Text
    '        End Get
    '        Set(ByVal Value As String)
    '            txtCName.Text = Value
    '        End Set
    '    End Property

    '    Public Property SKUCode() As String
    '        Get
    '            Return txtSKUCode.Text
    '        End Get
    '        Set(ByVal Value As String)
    '            txtSKUCode.Text = Value
    '        End Set
    '    End Property

    '    Public Property SKUName() As String
    '        Get
    '            Return txtSKUName.Text
    '        End Get
    '        Set(ByVal Value As String)
    '            txtSKUName.Text = Value
    '        End Set
    '    End Property

    '    Public Property SKUCode2() As String
    '        Get
    '            Return TextBox8.Text
    '        End Get
    '        Set(ByVal Value As String)
    '            TextBox8.Text = Value
    '        End Set
    '    End Property
    Private Function kosong()
        ClearObjectonForm(Me)
        'AssignValuetoCombo(cmbMachineID, "", "idmesin", "namamesin", "mt_mesin", "idmesin<>'*'", "namamesin")
        With Me
            .ListView1.Columns.Clear()
            .ListView1.Columns.Add("Column 0", "guid1", 0)
            .ListView1.Columns.Add("Column 1", "Grade", Me.TextBox11.Width + 5)
            .ListView1.Columns.Add("Column 2", "Width", Me.NumericTextBox1.Width + 5)
            .ListView1.Columns.Add("Column 3", "Thickness", Me.NumericTextBox2.Width + 5)
            .ListView1.Columns.Add("Column 4", "Remarks", Me.TextBox12.Width + 5)

            .ListView2.Columns.Clear()
            .ListView2.Columns.Add("Column 0", "guid2", 0)
            .ListView2.Columns.Add("Column 1", "Printing On", Me.DateTimePicker1.Width + 5)
            .ListView2.Columns.Add("Column 2", "Print Order", Me.NumericTextBox31.Width + 5)
            .ListView2.Columns.Add("Column 3", "Print Description", Me.TextBox18.Width + 5)

            .ListView3.Columns.Clear()
            .ListView3.Columns.Add("Column 0", "guid3", 0)
            .ListView3.Columns.Add("Column 1", "Process", Me.TextBox6.Width + 5)
            .ListView3.Columns.Add("Column 2", "Resin", Me.TextBox7.Width + 5)
            .ListView3.Columns.Add("Column 3", "Thickness", Me.NumericTextBox13.Width + 5)
            .ListView3.Columns.Add("Column 4", "Anchor Coating", Me.TextBox9.Width + 5)
            .ListView3.Columns.Add("Column 5", "Remarks", Me.TextBox10.Width + 5)

            .ListView4.Columns.Clear()
            .ListView4.Columns.Add("Column 0", "guid4", 0)
            .ListView4.Columns.Add("Column 1", "Process", Me.TextBox17.Width + 5)
            .ListView4.Columns.Add("Column 2", "Adhesive/Catalyst", Me.TextBox17.Width + 5)
            .ListView4.Columns.Add("Column 3", "Ratio", Me.NumericTextBox15.Width + 5)
            .ListView4.Columns.Add("Column 4", "Coating Weight", Me.NumericTextBox16.Width + 5)
            .ListView4.Columns.Add("Column 5", "Anilog", Me.NumericTextBox17.Width + 5)
            .ListView4.Columns.Add("Column 6", "Solid Content", Me.NumericTextBox18.Width + 5)
            .ListView4.Columns.Add("Column 5", "Cyl (LPI)", Me.NumericTextBox19.Width + 5)

            .ListView5.Columns.Clear()
            .ListView5.Columns.Add("Column 0", "guid5", 0)
            .ListView5.Columns.Add("Column 1", "Line Type", Me.cmbLineType.Width + 5)
            .ListView5.Columns.Add("Column 2", "Process", Me.NumericTextBox33.Width + 5)
            .ListView5.Columns.Add("Column 3", "TD", Me.NumericTextBox24.Width + 5)
            .ListView5.Columns.Add("Column 4", "MD", Me.NumericTextBox23.Width + 5)

        End With
        Me.txtguid.Text = "0"
        'm_SODtlID = 0
        Me.btnSaveD1.Tag = "N"
        Me.btnSaveD2.Tag = "N"
        Me.btnSaveD3.Tag = "N"
        Me.btnSaveD4.Tag = "N"
        Me.btnSaveD5.Tag = "N"
        '        Me.ToolStrip2.Enabled = False
        Me.cmdCancel.Enabled = False : Me.cmdDelete.Enabled = False : Me.cmdPrint.Enabled = False

        'Tab1
        Me.NumericTextBox3.Text = ""
        Me.NumericTextBox4.Text = ""
        Me.NumericTextBox5.Text = ""
        Me.NumericTextBox6.Text = ""
        Me.NumericTextBox7.Text = ""
        Me.NumericTextBox8.Text = ""

        'Tab2
        TextBox11.Text = ""
        TextBox12.Text = ""
        NumericTextBox1.Text = ""
        NumericTextBox2.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""

        'Tab3
        DateTimePicker1.Value = Now.Date
        NumericTextBox31.Text = ""
        TextBox18.Text = ""
        NumericTextBox9.Text = ""
        NumericTextBox10.Text = ""
        NumericTextBox11.Text = ""
        NumericTextBox12.Text = ""

        'Tab4
        TextBox6.Text = ""
        TextBox7.Text = ""
        TextBox9.Text = ""
        TextBox10.Text = ""
        TextBox13.Text = ""
        NumericTextBox13.Text = ""
        NumericTextBox14.Text = ""

        'Tab5
        TextBox16.Text = ""
        TextBox17.Text = ""
        NumericTextBox15.Text = ""
        NumericTextBox16.Text = ""
        NumericTextBox17.Text = ""
        NumericTextBox18.Text = ""
        NumericTextBox19.Text = ""
        NumericTextBox20.Text = ""

        'Tab6
        NumericTextBox21.Text = ""
        NumericTextBox22.Text = ""

        'Tab7
        cmbLineType.SelectedIndex = -1
        NumericTextBox23.Text = ""
        NumericTextBox24.Text = ""
        NumericTextBox33.Text = ""

        'Tab8
        NumericTextBox25.Text = ""
        NumericTextBox26.Text = ""
        NumericTextBox27.Text = ""
        NumericTextBox28.Text = ""
        NumericTextBox29.Text = ""
        NumericTextBox30.Text = ""
        NumericTextBox32.Text = ""

        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        txtProductCode.Text = ""
        TextBox14.Text = ""
        TextBox15.Text = ""
        TextBox8.Text = ""
        cmbProductionProcess.SelectedIndex = -1
        ComboBox1.SelectedIndex = -1

        dtp1.Value = Now.Date

    End Function

    Private Function isirecord(ByVal guidno As Integer)
        Me.txtguid.Text = guidno
        Fillobject(Me.txtguid, Me, "select", "usp_tr_mc_dtl1", Me.txtguid.Text, "@mc_dtl_pk1")
        opensearchform(Me.ListView1, "mc_dtl_pk11", "", "film_grade, film_width, film_thickness, film_remark", "tr_mc_dtl11 a", "a.mc_dtl_id_f1 in ('" & guidno & "')", "a.created", 0)
        opensearchform(Me.ListView2, "mc_dtl_pk12", "", "print_order_by, print_description", "tr_mc_dtl12 a", "a.mc_dtl_id_f1 in ('" & guidno & "')", "a.created", 0)
        opensearchform(Me.ListView3, "mc_dtl_pk13", "", "extrusion_process, extrusion_resin, extrusion_thickness, extrusion_anchor_coating, extrusion_remarks", "tr_mc_dtl13 a", "a.mc_dtl_id_f1 in ('" & guidno & "')", "a.created", 0)
        opensearchform(Me.ListView4, "mc_dtl_pk14", "", "drylami_process, drylami_adhesive, drylami_ratio, drylami_coating_weight, drylami_anilog, drylami_solid_content, drylami_cyl", "tr_mc_dtl14 a", "a.mc_dtl_id_f1 in ('" & guidno & "')", "a.created", 0)
        opensearchform(Me.ListView5, "mc_dtl_pk15", "", "line_type_id, quality_process_order, quality_td, quality_md", "tr_mc_dtl15 a", "a.mc_dtl_id_f1 in ('" & guidno & "')", "a.created", 0)
        'btnSO.Enabled = False
        Me.cmdCancel.Enabled = True : Me.cmdDelete.Enabled = True : Me.cmdPrint.Enabled = True
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

    Private Sub btnSaveD1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim li As ListViewItem, i As Integer
        'If Me.txtguid.Text = "0" Then Exit Sub
        If Me.txtguid.Text <> "0" And Me.txtguid_d1.Text <> "0" Then
            'Dim xguid As Integer = GetCurrentID("mp_dtl_pk", "tr_mp_dtl", "mp_id_f=" & Me.txtguid.Text & " and sku_id_f=" & Me.txtskuid.Text)
            ''update SET modified=@modified, modifiedby=@modifiedby, sku_id_f=@sku_id_f, sku_id_desc=@sku_id_desc, mp_qty=@mp_qty, tgl_realisasi_kirim=@tgl_realisasi_kirim
            'Executestr("EXEC usp_tr_proder_dtl1 'update', '" & Format(Date.Now(), "MM/dd/yyyy hh:mm:ss tt") & "','" & My.Settings.UserName & "','" & Format(Date.Now(), "MM/dd/yyyy hh:mm:ss tt") & "','" & My.Settings.UserName & "','" & Me.txtguid_d1.Text & "','" & Me.txtguid.Text & "','" & Me.txtskuid.Text & "','" & Me.TextBox9.Text & "','" & CDbl(Me.TextBox10.Text) & "','" & TextBox22.Text & "','0'")

            '            Fillobject(Me.txtguid_d1, Me.TabPage2, "update", "usp_tr_proder_dtl1", Me.txtguid_d1.Text, "@c_id") 'update detil
            '            opensearchform(Me.ListView1, "proder_dtl_pk1", "sku_id_f", "sku_code, raw_description, plano_size, plano_amount, uom_name", "tr_proder_dtl1 a inner join tr_proder b on a.proder_id_f=b.proder_id_pk inner join mt_sku c on c.sku_id=a.sku_id_f inner join mt_sku_uom d on d.uom_id=c.uom_id", "a.proder_id_f in ('" & txtguid.Text & "')", "a.created", 0)
        ElseIf Me.txtguid.Text <> "0" And Me.txtguid_d1.Text = "0" Then
            '            'insert
            '            Fillobject(Me.txtguid_d1, Me.TabPage2, "insert", "usp_tr_proder_dtl1", Me.txtguid_d1.Text, "@c_id") 'update detil
            '            opensearchform(Me.ListView1, "proder_dtl_pk1", "sku_id_f", "sku_code, raw_description, plano_size, plano_amount, uom_name", "tr_proder_dtl1 a inner join tr_proder b on a.proder_id_f=b.proder_id_pk inner join mt_sku c on c.sku_id=a.sku_id_f inner join mt_sku_uom d on d.uom_id=c.uom_id", "a.proder_id_f in ('" & txtguid.Text & "')", "a.created", 0)
        Else
            '            'insert
            '            If FindSubItem(ListView1, Me.txtskuid.Text) = True And Me.btnSaveD1.Tag = "N" Then
            '                'it is a duplicate do something
            '                MsgBox("Duplicate data !", MsgBoxStyle.Critical, Me.Text)
            '                Exit Sub
            '            Else
            '                'it is not a duplicate, go ahead and add it.
            '                If Me.btnSaveD1.Tag = "N" Then

            '                Else
            '                    For a As Integer = ListView1.SelectedItems.Count - 1 To 0
            '                        ListView1.SelectedItems(a).Remove()
            '                    Next
            '                End If
            '                i = Me.ListView1.Items.Count + 1
            '                li = ListView1.Items.Add(Me.txtguid_d1.Text)
            '                li.SubItems.Add(Me.txtskuid.Text)
            '                li.SubItems.Add(Me.TextBox8.Text)
            '                li.SubItems.Add(Me.TextBox9.Text)
            '                li.SubItems.Add(Me.TextBox10.Text)
            '                li.SubItems.Add(Me.TextBox22.Text)
            '            End If
        End If
        Me.txtguid_d1.Text = ""

        '        'Tab2
        '        TextBox8.Text = ""
        '        TextBox9.Text = ""
        '        TextBox10.Text = ""
        '        TextBox22.Text = ""

        '        Me.btnSaveD1.Tag = "N"
        '        Me.btnSaveD2.Tag = "N"
        '        Me.btnSaveD3.Tag = "N"
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

    '    Private Sub ListView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        If ListView1.SelectedItems.Count > 0 Then
    '            Me.txtguid_d1.Text = Me.ListView1.Items(ListView1.FocusedItem.Index).Text
    '            Me.txtskuid.Text = Me.ListView1.Items(ListView1.FocusedItem.Index).SubItems(1).Text
    '            Me.TextBox8.Text = Me.ListView1.Items(ListView1.FocusedItem.Index).SubItems(2).Text
    '            Me.TextBox9.Text = Me.ListView1.Items(ListView1.FocusedItem.Index).SubItems(3).Text
    '            Me.TextBox10.Text = Me.ListView1.Items(ListView1.FocusedItem.Index).SubItems(4).Text
    '            Me.TextBox22.Text = Me.ListView1.Items(ListView1.FocusedItem.Index).SubItems(5).Text
    '            Me.btnSaveD1.Tag = "E"
    '        End If
    '    End Sub

    '    Private Sub ListView2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        If ListView2.SelectedItems.Count > 0 Then
    '            Me.txtguid_d2.Text = Me.ListView2.Items(ListView2.FocusedItem.Index).Text
    '            TextBox17.Text = Me.ListView1.Items(ListView1.FocusedItem.Index).SubItems(1).Text
    '            Me.TextBox16.Text = Me.ListView1.Items(ListView1.FocusedItem.Index).SubItems(2).Text
    '            Me.TextBox15.Text = Me.ListView1.Items(ListView1.FocusedItem.Index).SubItems(3).Text
    '            Me.TextBox18.Text = Me.ListView1.Items(ListView1.FocusedItem.Index).SubItems(4).Text
    '            Me.btnSaveD2.Tag = "E"
    '        End If
    '    End Sub

    '    Private Sub ListView3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        If ListView3.SelectedItems.Count > 0 Then
    '            Me.txtguid_d3.Text = Me.ListView3.Items(ListView1.FocusedItem.Index).Text
    '            TextBox20.Text = Me.ListView1.Items(ListView1.FocusedItem.Index).SubItems(1).Text
    '            Me.TextBox19.Text = Me.ListView1.Items(ListView1.FocusedItem.Index).SubItems(2).Text
    '            Me.TextBox21.Text = Me.ListView1.Items(ListView1.FocusedItem.Index).SubItems(3).Text
    '            Me.btnSaveD3.Tag = "E"
    '        End If
    '    End Sub

    '    Private Sub btnDeleteD1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        If Me.txtSONo.Text = "" Or Me.txtguid.Text = "0" Then Exit Sub
    '        'If Me.txtguid.Text <> "0" And Me.txtguid_d1.Text <> "0" Then
    '        '    Dim xguid As Integer = GetCurrentID("proder_dtl_pk", "tr_proder_dtl", "proder_id_f=" & Me.txtguid.Text & " and sku_id_f=" & Me.txtskuid.Text)
    '        '    'update SET modified=@modified, modifiedby=@modifiedby, sku_id_f=@sku_id_f, sku_id_desc=@sku_id_desc, mp_qty=@mp_qty, tgl_realisasi_kirim=@tgl_realisasi_kirim
    '        '    Executestr("EXEC usp_tr_proder_dtl 'delete', null,null," & Format(Date.Now(), "MM/dd/yyyy hh:mm:ss tt") & "','" & My.Settings.UserName & "','" & Me.txtguid.Text)
    '        '    opensearchform(Me.ListView1, "proder_dtl_pk1", "sku_id_f", "sku_code, raw_description, plano_size, plano_amount, uom_name", "tr_proder_dtl1 a inner join tr_proder b on a.proder_id_f=b.proder_id_pk  inner join mt_sku c on c.sku_id=a.sku_id_f inner join mt_sku_uom d on d.uom_id=c.uom_id inner join tr_so_dtl e on b.so_dtl_id_f=e.so_dtl_id", "a.proder_id_f in ('" & txtguid.Text & "')", "a.created", 0)
    '        'Else
    '        '    If ListView1.SelectedItems.Count > 0 Then
    '        '        For a As Integer = ListView1.SelectedItems.Count - 1 To 0
    '        '            ListView1.SelectedItems(a).Remove()
    '        '        Next
    '        '    End If
    '        'End If
    '    End Sub

    Private Sub ftr_mc_sub1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)
        kosong()
    End Sub

    Private Sub cmdsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'save
        Dim updheader As Boolean, upddetil As Boolean, str1 As String, str2 As String
        On Error GoTo err_ToolStripButton1_Click
        '        If Me.ListView1.Items.Count = 0 Or Me.ListView2.Items.Count = 0 Or Me.ListView3.Items.Count = 0 Then MsgBox("You can't save the record while the detail is empty.", vbCritical + vbOKOnly, Me.Text) : Exit Sub
        '        If Me.txtSONo.Text = "" Then
        '            MsgBox("Sales Order No. are primary fields that should be entered. Please enter those fields before you save it.", vbCritical + vbOKOnly, Me.Text)
        '            txtSONo.Focus()
        '            Exit Sub
        '        End If
        '        If MsgBox("This " & IIf(Me.txtguid.Text = "0", "new", "") & " record will be saved, proceed?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.Yes Then
        '            namatable = "tr_proder" : namafieldPK = "proder_no"
        '            If (Me.txtguid.Text = "0") Then
        '                'Insert new
        '                txtProderNo.Text = IIf(Me.txtguid.Text = "0", GETGeneralcode("proder", namatable, namafieldPK, "proder_date", dtpProderDate.Value, False, 4, 1, "", ""), txtProderNo.Text)
        '                updheader = Fillobject(Me.txtguid, Me, "insert", "usp_tr_proder", "", "@proder_pk") 'update header
        '                For i As Integer = 0 To Me.ListView1.Items.Count - 1
        '                    'kl blm ada, INSERT
        '                    upddetil = Executestr("EXEC usp_tr_proder_dtl1 'insert', '" & Format(Date.Now(), "MM/dd/yyyy hh:mm:ss tt") & "','" & My.Settings.UserName & "','" & Format(Date.Now(), "MM/dd/yyyy hh:mm:ss tt") & "','" & My.Settings.UserName & "','" & txtguid_d1.Text & "','" & Me.txtguid.Text & "','" & ListView1.Items(i).SubItems(1).Text & "','" & ListView1.Items(i).SubItems(3).Text & "','" & ListView1.Items(i).SubItems(4).Text & "','" & dtpProderDate.Value & "','0'")
        '                Next
        '                For i As Integer = 0 To Me.ListView2.Items.Count - 1
        '                    'kl blm ada, INSERT
        '                    upddetil = Executestr("EXEC usp_tr_proder_dtl2 'insert', '" & Format(Date.Now(), "MM/dd/yyyy hh:mm:ss tt") & "','" & My.Settings.UserName & "','" & Format(Date.Now(), "MM/dd/yyyy hh:mm:ss tt") & "','" & My.Settings.UserName & "','" & txtguid_d1.Text & "','" & Me.txtguid.Text & "','" & ListView1.Items(i).SubItems(1).Text & "','" & ListView1.Items(i).SubItems(3).Text & "','" & ListView1.Items(i).SubItems(4).Text & "','" & dtpProderDate.Value & "','0'")
        '                Next
        '                For i As Integer = 0 To Me.ListView3.Items.Count - 1
        '                    'kl blm ada, INSERT
        '                    upddetil = Executestr("EXEC usp_tr_proder_dtl3 'insert', '" & Format(Date.Now(), "MM/dd/yyyy hh:mm:ss tt") & "','" & My.Settings.UserName & "','" & Format(Date.Now(), "MM/dd/yyyy hh:mm:ss tt") & "','" & My.Settings.UserName & "','" & txtguid_d1.Text & "','" & Me.txtguid.Text & "','" & ListView1.Items(i).SubItems(1).Text & "','" & ListView1.Items(i).SubItems(3).Text & "','" & ListView1.Items(i).SubItems(4).Text & "','" & dtpProderDate.Value & "','0'")
        '                Next
        '                If updheader And upddetil Then MsgBox("New record has been saved!", MsgBoxStyle.Information, Me.Text) Else txtProderNo.Text = "" : MsgBox("New record can't be saved!", MsgBoxStyle.Critical, Me.Text)
        '            Else
        '                'Update
        '                updheader = Fillobject(Me.txtguid, Me, "update", "usp_tr_proder", "", "@proder_pk") 'update header
        '                upddetil = True 'Executestr("EXEC sp_tr_mp_dtl 'update', '" & Format(Date.Now(), "MM/dd/yyyy hh:mm:ss tt") & "','" & My.Settings.UserName & "','" & Format(Date.Now(), "MM/dd/yyyy hh:mm:ss tt") & "','" & My.Settings.UserName & "','" & Me.txtguid_d.Text & "','" & Me.txtguid.Text & "','" & Me.txtskuid.Text & "','" & Me.TextBox5.Text & "','" & CDbl(Me.TextBox6.Text) & "','" & Me.dttpmp_tgl.Text & "','0'")'update detil
        '                If updheader And upddetil Then MsgBox("Record has been saved!", MsgBoxStyle.Information, Me.Text) Else txtProderNo.Text = "" : MsgBox("Record can't be saved!", MsgBoxStyle.Critical, Me.Text)
        '            End If
        '        Else
        '            MsgBox("Record was not saved!", MsgBoxStyle.Critical, Me.Text)
        '        End If
exit_ToolStripButton1_Click:
        If ConnectionState.Open = 1 Then cn.Close()
        Exit Sub

err_ToolStripButton1_Click:
        MsgBox(Err.Description)
        Resume exit_ToolStripButton1_Click
    End Sub

    Private Sub cmdnew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'new
        kosong()
    End Sub

    Private Sub cmddelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '        'delete
        '        On Error GoTo err_ToolStripButton4_Click
        '        If Me.txtguid.Text = "" Then Exit Sub
        '        If MsgBox("Are you sure you want to delete this record?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.Yes Then
        '            If Fillobject(Me.txtguid, Me, "delete", "usp_tr_proder", "", "@proder_pk") Then MsgBox("Record has been deleted!", MsgBoxStyle.Information, Me.Text) Else txtProderNo.Text = "" : MsgBox("Record can't be deleted!", MsgBoxStyle.Critical, Me.Text)
        '        Else
        '            MsgBox("Record has not been deleted!", MsgBoxStyle.Critical, Me.Text)
        '        End If

exit_ToolStripButton4_Click:
        If ConnectionState.Open = 1 Then cn.Close()
        Exit Sub

err_ToolStripButton4_Click:
        MsgBox(Err.Description)
        Resume exit_ToolStripButton4_Click
    End Sub

    Private Sub cmdprint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
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

    '    Private Sub btnSaveD2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveD2.Click
    '        Dim li As ListViewItem, i As Integer
    '        'If Me.txtguid.Text = "0" Then Exit Sub
    '        If Me.txtguid.Text <> "0" And Me.txtguid_d2.Text <> "0" Then
    '            'Dim xguid As Integer = GetCurrentID("proder_dtl_pk", "tr_proder_dtl", "proder_id_f=" & Me.txtguid.Text & " and sku_id_f=" & Me.txtskuid.Text)
    '            ''update SET modified=@modified, modifiedby=@modifiedby, sku_id_f=@sku_id_f, sku_id_desc=@sku_id_desc, mp_qty=@mp_qty, tgl_realisasi_kirim=@tgl_realisasi_kirim
    '            'Executestr("EXEC usp_tr_proder_dtl 'update', '" & Format(Date.Now(), "MM/dd/yyyy hh:mm:ss tt") & "','" & My.Settings.UserName & "','" & Format(Date.Now(), "MM/dd/yyyy hh:mm:ss tt") & "','" & My.Settings.UserName & "','" & Me.txtguid_d1.Text & "','" & Me.txtguid.Text & "','" & Me.txtskuid.Text & "','" & Me.TextBox9.Text & "','" & CDbl(Me.TextBox10.Text) & "','" & TextBox22.Text & "','0'")

    '            Fillobject(Me.txtguid_d2, Me.TabPage3, "update", "usp_tr_proder_dtl2", Me.txtguid_d2.Text, "@c_id") 'update detil
    '            opensearchform(Me.ListView2, "proder_dtl_pk2", "print_ink", "print_qty, uom_name, record_group", "tr_proder_dtl2 a inner join tr_proder b on a.proder_id_f=b.proder_id_pk ", "a.proder_id_f in ('" & txtguid.Text & "')", "a.created", 0)
    '        ElseIf Me.txtguid.Text <> "0" And Me.txtguid_d2.Text = "0" Then
    '            Fillobject(Me.txtguid_d2, Me.TabPage3, "insert", "usp_tr_proder_dtl2", Me.txtguid_d1.Text, "@c_id") 'update detil
    '            opensearchform(Me.ListView2, "proder_dtl_pk2", "print_ink", "print_qty, uom_name, record_group", "tr_proder_dtl2 a inner join tr_proder b on a.proder_id_f=b.proder_id_pk ", "a.proder_id_f in ('" & txtguid.Text & "')", "a.created", 0)
    '        Else
    '            'insert
    '            If FindSubItem(ListView2, TextBox17.Text) = True And Me.btnSaveD2.Tag = "N" Then
    '                'it is a duplicate do something
    '                MsgBox("Duplicate data !", MsgBoxStyle.Critical, Me.Text)
    '                Exit Sub
    '            Else
    '                'it is not a duplicate, go ahead and add it.
    '                If Me.btnSaveD2.Tag = "N" Then

    '                Else
    '                    For a As Integer = ListView2.SelectedItems.Count - 1 To 0
    '                        ListView2.SelectedItems(a).Remove()
    '                    Next
    '                End If
    '                i = Me.ListView2.Items.Count + 1
    '                li = ListView2.Items.Add(Me.txtguid_d2.Text)
    '                li.SubItems.Add(TextBox15.Text)
    '                li.SubItems.Add(Me.TextBox16.Text)
    '                li.SubItems.Add(Me.TextBox17.Text)
    '                li.SubItems.Add(Me.TextBox18.Text)
    '            End If
    '        End If
    '        Me.txtguid_d2.Text = ""

    '        'Tab3
    '        TextBox15.Text = ""
    '        TextBox16.Text = ""
    '        TextBox17.Text = ""
    '        TextBox18.Text = ""

    '        Me.btnSaveD1.Tag = "N"
    '        Me.btnSaveD2.Tag = "N"
    '        Me.btnSaveD3.Tag = "N"
    '    End Sub

    '    Private Sub btnSaveD3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveD3.Click
    '        Dim li As ListViewItem, i As Integer
    '        'If Me.txtguid.Text = "0" Then Exit Sub
    '        If Me.txtguid.Text <> "0" And Me.txtguid_d3.Text <> "0" Then
    '            'Dim xguid As Integer = GetCurrentID("proder_dtl_pk", "tr_proder_dtl", "proder_id_f=" & Me.txtguid.Text & " and sku_id_f=" & Me.txtskuid.Text)
    '            'update SET modified=@modified, modifiedby=@modifiedby, sku_id_f=@sku_id_f, sku_id_desc=@sku_id_desc, mp_qty=@mp_qty, tgl_realisasi_kirim=@tgl_realisasi_kirim
    '            'Executestr("EXEC usp_tr_proder_dtl 'update', '" & Format(Date.Now(), "MM/dd/yyyy hh:mm:ss tt") & "','" & My.Settings.UserName & "','" & Format(Date.Now(), "MM/dd/yyyy hh:mm:ss tt") & "','" & My.Settings.UserName & "','" & Me.txtguid_d1.Text & "','" & Me.txtguid.Text & "','" & Me.txtskuid.Text & "','" & Me.TextBox9.Text & "','" & CDbl(Me.TextBox10.Text) & "','" & TextBox22.Text & "','0'")
    '            Fillobject(Me.txtguid_d3, Me.TabPage4, "update", "usp_tr_proder_dtl3", Me.txtguid_d3.Text, "@c_id") 'update detil
    '            opensearchform(Me.ListView3, "proder_dtl_pk3", "proder_dtl_text1", "proder_dtl_text2, proder_dtl_text3", "tr_proder_dtl3 a inner join tr_proder b on a.proder_id_f=b.proder_id_pk", "a.proder_id_f in ('" & txtguid.Text & "')", "a.created", 0)
    '        ElseIf Me.txtguid.Text <> "0" And Me.txtguid_d3.Text = "0" Then
    '            Fillobject(Me.txtguid_d3, Me.TabPage4, "insert", "usp_tr_proder_dtl3", Me.txtguid_d3.Text, "@c_id") 'insert detil
    '            opensearchform(Me.ListView3, "proder_dtl_pk3", "proder_dtl_text1", "proder_dtl_text2, proder_dtl_text3", "tr_proder_dtl3 a inner join tr_proder b on a.proder_id_f=b.proder_id_pk", "a.proder_id_f in ('" & txtguid.Text & "')", "a.created", 0)
    '            'insert
    '            If FindSubItem(ListView3, TextBox20.Text) = True And Me.btnSaveD3.Tag = "N" Then
    '                'it is a duplicate do something
    '                MsgBox("Duplicate data !", MsgBoxStyle.Critical, Me.Text)
    '                Exit Sub
    '            Else
    '                'it is not a duplicate, go ahead and add it.
    '                If Me.btnSaveD3.Tag = "N" Then

    '                Else
    '                    For a As Integer = ListView3.SelectedItems.Count - 1 To 0
    '                        ListView3.SelectedItems(a).Remove()
    '                    Next
    '                End If
    '                i = Me.ListView3.Items.Count + 1
    '                li = ListView3.Items.Add(Me.txtguid_d3.Text)
    '                li.SubItems.Add(TextBox19.Text)
    '                li.SubItems.Add(Me.TextBox20.Text)
    '                li.SubItems.Add(Me.TextBox21.Text)
    '            End If
    '        End If
    '        Me.txtguid_d3.Text = ""

    '        'Tab3
    '        TextBox19.Text = ""
    '        TextBox20.Text = ""
    '        TextBox21.Text = ""
    '        Me.btnSaveD3.Tag = "N"
    '    End Sub

    '    Private Sub btnDeleteD2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteD2.Click
    '        If Me.txtSONo.Text = "" Or Me.txtguid.Text = "0" Then Exit Sub
    '        'If Me.txtguid.Text <> "0" And Me.txtguid_d2.Text <> "0" Then
    '        '    Dim xguid As Integer = GetCurrentID("proder_dtl_pk2", "tr_proder_dtl2", "proder_id_f=" & Me.txtguid.Text & " and sku_id_f=" & Me.txtskuid.Text)
    '        '    'update SET modified=@modified, modifiedby=@modifiedby, sku_id_f=@sku_id_f, sku_id_desc=@sku_id_desc, mp_qty=@mp_qty, tgl_realisasi_kirim=@tgl_realisasi_kirim
    '        '    Executestr("EXEC usp_tr_proder_dtl2 'delete', null,null," & Format(Date.Now(), "MM/dd/yyyy hh:mm:ss tt") & "','" & My.Settings.UserName & "','" & Me.txtguid.Text)
    '        '    opensearchform(Me.ListView2, "proder_dtl_pk2", "", "print_ink, print_qty, uom_name, record_group", "tr_proder_dtl2 a inner join tr_proder b on a.proder_id_f=b.proder_id_pk  inner join mt_sku c on c.sku_id=a.sku_id_f inner join mt_sku_uom d on d.uom_id=c.uom_id inner join tr_so_dtl e on b.so_dtl_id_f=e.so_dtl_id", "a.proder_id_f in ('" & txtguid.Text & "')", "a.created", 0)
    '        'Else
    '        '    If ListView2.SelectedItems.Count > 0 Then
    '        '        For a As Integer = ListView2.SelectedItems.Count - 1 To 0
    '        '            ListView2.SelectedItems(a).Remove()
    '        '        Next
    '        '    End If
    '        'End If
    '    End Sub

    '    Private Sub btnDeleteD3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteD3.Click
    '        If Me.txtSONo.Text = "" Or Me.txtguid.Text = "0" Then Exit Sub
    '        'If Me.txtguid.Text <> "0" And Me.txtguid_d3.Text <> "0" Then
    '        '    Dim xguid As Integer = GetCurrentID("proder_dtl_pk3", "tr_proder_dtl3", "proder_id_f=" & Me.txtguid.Text & " and sku_id_f=" & Me.txtskuid.Text)
    '        '    'update SET modified=@modified, modifiedby=@modifiedby, sku_id_f=@sku_id_f, sku_id_desc=@sku_id_desc, mp_qty=@mp_qty, tgl_realisasi_kirim=@tgl_realisasi_kirim
    '        '    Executestr("EXEC usp_tr_proder_dtl3 'delete', null,null," & Format(Date.Now(), "MM/dd/yyyy hh:mm:ss tt") & "','" & My.Settings.UserName & "','" & Me.txtguid.Text)
    '        '    opensearchform(Me.ListView3, "proder_dtl_pk3", "", "proder_dtl_text1, proder_dtl_text2, proder_dtl_text3", "tr_proder_dtl3 a inner join tr_proder b on a.proder_id_f=b.proder_id_pk  inner join mt_sku c on c.sku_id=a.sku_id_f inner join mt_sku_uom d on d.uom_id=c.uom_id inner join tr_so_dtl e on b.so_dtl_id_f=e.so_dtl_id", "a.proder_id_f in ('" & txtguid.Text & "')", "a.created", 0)
    '        'Else
    '        '    If ListView3.SelectedItems.Count > 0 Then
    '        '        For a As Integer = ListView3.SelectedItems.Count - 1 To 0
    '        '            ListView3.SelectedItems(a).Remove()
    '        '        Next
    '        '    End If
    '        'End If
    '    End Sub

    '    Private Sub btnSO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSO.Click
    '        'Dim NewFormDialog As New fdlCUtility
    '        'NewFormDialog.FrmCallerId = Me.Name
    '        'NewFormDialog.Tag = "1"
    '        'NewFormDialog.ShowDialog()
    '        Dim NewFormDialog As New fdlSOProder
    '        NewFormDialog.FrmCallerId = Me.Name
    '        NewFormDialog.ShowDialog()
    '    End Sub

    '    Private Sub btnSKU_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSKU.Click
    '        Dim NewFormDialog As New fdlSKUPO
    '        NewFormDialog.FrmCallerId = Me.Name
    '        NewFormDialog.ShowDialog()
    '    End SubPublic Class ftr_mc_sub1

    '    Private Sub btnSaveD1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveD1.Click

    '    End Sub

    '    Private Sub btnSaveD4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveD4.Click

    '    End Sub


    Private Sub cmdFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFind.Click
        Dim child As New FDLSearch()
        child.txtopenargs.Text = "8"
        If child.ShowDialog() = DialogResult.OK Then
            Me.txtguid.Text = child.txtChildText0.Text
            isirecord(Me.txtguid.Text)
        End If
    End Sub
End Class