Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class frmSKU
    Private ListView1Sorter As lvColumnSorter
    Dim strConnection As String = My.Settings.ConnStr
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Dim cmd As SqlCommand
    Dim m_SKUId As Integer, m_SKUId2 As Integer, m_SKURawId As Integer
    Dim isAllowDelete As Boolean
    Dim Dec As Integer = GetSysInit("decimal_digit")
    Dim m_loadFlag As Boolean = False

    Public Property SKUId2() As Integer
        Get
            Return m_SKUId2
        End Get
        Set(ByVal Value As Integer)
            m_SKUId2 = Value
        End Set
    End Property

    Public Property SKUCode2() As String
        Get
            Return txtSKUCode2.Text
        End Get
        Set(ByVal Value As String)
            txtSKUCode2.Text = Value
        End Set
    End Property

    Public Property SKUName2() As String
        Get
            Return txtSKUName2.Text
        End Get
        Set(ByVal Value As String)
            txtSKUName2.Text = Value
        End Set
    End Property

    Private Sub frmSKU_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        isAllowDelete = canDelete(Me.Name)

        clear_obj()

        cmbFilterBy.Items.Add("<All>")
        cmbFilterBy.Items.Add("Code")
        cmbFilterBy.Items.Add("Name")

        Dim prm1 As SqlParameter, prm2 As SqlParameter
        Dim myReader As SqlDataReader

        'Populate Sub-Category
        cmd = New SqlCommand("usp_mt_sku_category_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        prm1 = cmd.Parameters.Add("@category_id", SqlDbType.Int)
        prm1.Value = 0
        prm2 = cmd.Parameters.Add("@is_sub_category", SqlDbType.Bit)
        prm2.Value = 1

        cn.Open()
        myReader = cmd.ExecuteReader

        cbCategory.Items.Add(New clsMyListInt("All", 0))
        Do While myReader.Read
            cmbCategoryID.Items.Add(New clsMyListInt(myReader.GetString(1), myReader.GetInt32(0)))
            cbCategory.Items.Add(New clsMyListInt(myReader.GetString(1), myReader.GetInt32(0)))
        Loop
        myReader.Close()
        cn.Close()

        'Populate UoM
        cmd = New SqlCommand("usp_mt_sku_uom", cn)
        cmd.CommandType = CommandType.StoredProcedure

        prm1 = cmd.Parameters.Add("@action", SqlDbType.NVarChar, 50)
        prm1.Value = "READ"

        cn.Open()
        myReader = cmd.ExecuteReader

        Do While myReader.Read
            cmbUomID.Items.Add(New clsMyListInt(myReader.GetString(1), myReader.GetInt32(0)))
        Loop
        myReader.Close()
        cn.Close()

        cbCategory.SelectedIndex = 0
        cmbFilterBy.SelectedIndex = 0

        'populateCbCategory()
        'clear_lvw()
        m_loadFlag = True
        'If ListView1.Items.Count > 0 Then
        '    ListView1.Items.Item(0).Selected = True
        '    ListView1_Click(sender, e)
        'End If

        'lock_obj(True)
    End Sub

    Private Sub ListView1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.Click
        'If m_SKUId = 0 And btnAdd.Enabled = False Then lock_obj(True)
        With ListView1.SelectedItems.Item(0)
            'txtSKUID.Text = Strings.Mid(ListView1.SelectedItems(0).Tag, 2, Len(ListView1.SelectedItems(0).Tag) - 1)
            lblCurrentRecord.Text = "Selected record: " + CStr(CInt(RightSplitUF(ListView1.SelectedItems.Item(0).Tag) + 1)) + " of " + ListView1.Items.Count.ToString
            m_SKUId = LeftSplitUF(.Tag)

            Dim mList As clsMyListInt
            Dim i As Integer
            For i = 1 To cmbCategoryID.Items.Count
                mList = cmbCategoryID.Items(i - 1)
                If CInt(.SubItems.Item(0).Text) = mList.ItemData Then
                    cmbCategoryID.SelectedIndex = i - 1
                    Exit For
                End If
            Next

            txtSKUCode.Text = .SubItems.Item(1).Text
            txtSKUName.Text = .SubItems.Item(2).Text
            txtSKUBarcode.Text = .SubItems.Item(3).Text

            For i = 1 To cmbUomID.Items.Count
                mList = cmbUomID.Items(i - 1)
                If CInt(.SubItems.Item(4).Text) = mList.ItemData Then
                    cmbUomID.SelectedIndex = i - 1
                    Exit For
                End If
            Next

            ntbSalesDiscPercent.Text = FormatNumber(.SubItems.Item(5).Text) * 100
            ntbSalesPrice.Text = FormatNumber(.SubItems.Item(6).Text, Dec)
            NumericTextBox1.Text = FormatNumber(.SubItems.Item(7).Text)
            NumericTextBox2.Text = FormatNumber(.SubItems.Item(8).Text)
            NumericTextBox3.Text = FormatNumber(.SubItems.Item(9).Text)
            NumericTextBox4.Text = FormatNumber(.SubItems.Item(10).Text)
            txtLastCost.Text = FormatNumber(.SubItems.Item(11).Text)
            txtStockValue.Text = FormatNumber(.SubItems.Item(12).Text)
            txtStockBalance.Text = .SubItems.Item(13).Text
            txtAvgCost.Text = FormatNumber(.SubItems.Item(14).Text)
            txtSKURemarks.Text = .SubItems.Item(15).Text
            txtSKUInfo1.Text = .SubItems.Item(16).Text
            txtSKUInfo2.Text = .SubItems.Item(17).Text
            txtSKUInfo3.Text = .SubItems.Item(18).Text
            chbIsFinishedGoods.Checked = .SubItems.Item(19).Text

            clear_lvw2()
            clear_lvw3()
        End With
    End Sub

    Private Sub txtFilter_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFilter.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then clear_lvw()
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        clear_obj()
        lock_obj(False)
        clear_lvw3()
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        lock_obj(False)
        lock_objD(False)
        clear_objD()
        If m_SKUId <> 0 Then txtSKUCode.ReadOnly = True
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If m_SKUId = 0 And ListView1.Items.Count > 0 Then
            ListView1.Items.Item(0).Selected = True
            ListView1_Click(sender, e)
        End If
        lock_obj(True)
        lock_objD(True)
        clear_objD()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        On Error GoTo err_btnSave_Click
        If Me.txtSKUCode.Text = "" Then Me.txtSKUCode.Text = GETGeneralcode("", "mt_sku", "sku_code", "", Me.txtSKUName.Text, True, 4, 1, "", "")
        If txtSKUCode.Text = "" Or txtSKUName.Text = "" Or cmbCategoryID.SelectedIndex = -1 Then
            MsgBox("Stock Code, Stock Name and Stock Category are primary fields that should be entered. Please enter those fields before you save it.", vbCritical + vbOKOnly, Me.Text)
            txtSKUCode.Focus()
            Exit Sub
        End If

        SaveSKUHeader()
        clear_lvw()
        lock_obj(True)
        lock_objD(True)

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

    Sub SaveSKUHeader()
        Try
            cmd = New SqlCommand(IIf(m_SKUId = 0, "usp_mt_sku_INS", "usp_mt_sku_UPD"), cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm2 As SqlParameter = cmd.Parameters.Add("@category_id", SqlDbType.Int)
            prm2.Value = cmbCategoryID.Items(cmbCategoryID.SelectedIndex).ItemData
            Dim prm3 As SqlParameter = cmd.Parameters.Add("@sku_code", SqlDbType.NVarChar, 50)
            prm3.Value = txtSKUCode.Text
            Dim prm4 As SqlParameter = cmd.Parameters.Add("@sku_name", SqlDbType.NVarChar, 255)
            prm4.Value = txtSKUName.Text
            Dim prm5 As SqlParameter = cmd.Parameters.Add("@sku_barcode", SqlDbType.NVarChar, 255)
            prm5.Value = IIf(txtSKUBarcode.Text = "", DBNull.Value, txtSKUBarcode.Text)
            Dim prm6 As SqlParameter = cmd.Parameters.Add("@uom_id", SqlDbType.Int)
            prm6.Value = cmbUomID.Items(cmbUomID.SelectedIndex).ItemData
            Dim prm7 As SqlParameter = cmd.Parameters.Add("@sales_discount", SqlDbType.Decimal)
            prm7.Value = IIf(ntbSalesDiscPercent.Text = "", 0, ntbSalesDiscPercent.Text)
            Dim prm8 As SqlParameter = cmd.Parameters.Add("@sales_price", SqlDbType.Decimal)
            prm8.Value = IIf(ntbSalesPrice.Text = "", 0, ntbSalesPrice.Text)
            Dim prm9 As SqlParameter = cmd.Parameters.Add("@pack_qty", SqlDbType.Decimal)
            prm9.Value = CDbl(NumericTextBox1.Text)
            Dim prm10 As SqlParameter = cmd.Parameters.Add("@sku_volume", SqlDbType.Decimal)
            prm10.Value = CDbl(NumericTextBox2.Text)
            Dim prm11 As SqlParameter = cmd.Parameters.Add("@gross_weight", SqlDbType.Decimal)
            prm11.Value = CDbl(NumericTextBox3.Text)
            Dim prm12 As SqlParameter = cmd.Parameters.Add("@net_weight", SqlDbType.Decimal)
            prm12.Value = CDbl(NumericTextBox4.Text)

            Dim prm13 As SqlParameter = cmd.Parameters.Add("@sku_remarks", SqlDbType.NVarChar, 255)
            prm13.Value = IIf(txtSKURemarks.Text = "", DBNull.Value, txtSKURemarks.Text)
            Dim prm14 As SqlParameter = cmd.Parameters.Add("@sku_info1", SqlDbType.NVarChar, 255)
            prm14.Value = IIf(txtSKUInfo1.Text = "", DBNull.Value, txtSKUInfo1.Text)
            Dim prm15 As SqlParameter = cmd.Parameters.Add("@sku_info2", SqlDbType.NVarChar, 255)
            prm15.Value = IIf(txtSKUInfo2.Text = "", DBNull.Value, txtSKUInfo2.Text)
            Dim prm16 As SqlParameter = cmd.Parameters.Add("@sku_info3", SqlDbType.NVarChar, 255)
            prm16.Value = IIf(txtSKUInfo3.Text = "", DBNull.Value, txtSKUInfo3.Text)
            Dim prm17 As SqlParameter = cmd.Parameters.Add("@user_name", SqlDbType.NVarChar, 50)
            prm17.Value = My.Settings.UserName
            Dim prm18 As SqlParameter = cmd.Parameters.Add("@is_finished_goods", SqlDbType.Bit)
            prm18.Value = chbIsFinishedGoods.Checked

            Dim prm21 As SqlParameter = cmd.Parameters.Add("@sku_id", SqlDbType.Int)

            If m_SKUId = 0 Then
                prm21.Direction = ParameterDirection.Output

                cn.Open()
                cmd.ExecuteReader()
                m_SKUId = prm21.Value
                cn.Close()
                txtSKUCode.ReadOnly = True
            Else
                prm21.Value = m_SKUId
                cn.Open()
                cmd.ExecuteReader()
                cn.Close()
            End If

        Catch ex As Exception
            'If Err.Number = 5 Then
            '    MsgBox("This primary code has been used (and deleted) previously. Please create with another code", vbExclamation + vbOKOnly, Me.Text)
            'Else
            MsgBox(ex.Message)
            'End If
            If ConnectionState.Open = 1 Then cn.Close()
        End Try
    End Sub

    Sub clear_lvw()
        With ListView1
            .Clear()
            .View = View.Details
            .Columns.Add("Category", 0)
            .Columns.Add("Code", 90)
            .Columns.Add("Name", 300)
            .Columns.Add("Barcode", 0)
            .Columns.Add("UoM", 0)
            .Columns.Add("Sales Disc", 0).TextAlign = HorizontalAlignment.Right
            .Columns.Add("Sales Price", 0).TextAlign = HorizontalAlignment.Right
            .Columns.Add("pack_qty", 0).TextAlign = HorizontalAlignment.Right
            .Columns.Add("sku_volume", 0).TextAlign = HorizontalAlignment.Right
            .Columns.Add("gross_weight", 0).TextAlign = HorizontalAlignment.Right
            .Columns.Add("net_weight", 0).TextAlign = HorizontalAlignment.Right
            .Columns.Add("Last Cost", 0).TextAlign = HorizontalAlignment.Right
            .Columns.Add("Stock Val", 0).TextAlign = HorizontalAlignment.Right
            .Columns.Add("Balance", 90).TextAlign = HorizontalAlignment.Right
            .Columns.Add("Avg Cost", 0).TextAlign = HorizontalAlignment.Right
            .Columns.Add("Remarks", 0)
            .Columns.Add("Info1", 0)
            .Columns.Add("Info2", 0)
            .Columns.Add("Info3", 0)
            .Columns.Add("is_finished_goods", 0)
        End With


        cmd = New SqlCommand("usp_mt_sku_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm1 As SqlParameter = cmd.Parameters.Add("@sku_id", SqlDbType.Int)
        prm1.Value = 0
        Dim prm2 As SqlParameter = cmd.Parameters.Add("@sku_code", SqlDbType.NVarChar, 50)
        prm2.Value = IIf(cmbFilterBy.Text = "Product Code", txtFilter.Text, DBNull.Value)
        Dim prm3 As SqlParameter = cmd.Parameters.Add("@sku_name", SqlDbType.NVarChar, 50)
        prm3.Value = IIf(cmbFilterBy.Text = "Product Name", txtFilter.Text, DBNull.Value)
        Dim prm4 As SqlParameter = cmd.Parameters.Add("@is_finished_goods", SqlDbType.Bit)
        prm4.Value = chbIsFinishedGoods2.Checked
        Dim prm5 As SqlParameter = cmd.Parameters.Add("@category_id", SqlDbType.Int)
        If cbCategory.SelectedIndex = 0 Then
            prm5.Value = DBNull.Value
        Else
            prm5.Value = cbCategory.Items(cbCategory.SelectedIndex).ItemData
        End If

        cn.Open()

        Dim myReader As SqlDataReader = cmd.ExecuteReader()

        Call FillList(myReader, Me.ListView1, 20, 1)

        myReader.Close()
        cn.Close()
    End Sub

    Sub clear_lvw2()
        With ListView2
            .Clear()
            .View = View.Details
            .Columns.Add("sku_id1", 0)
            .Columns.Add("sku_id2", 0)
            .Columns.Add("Product Code", 90)
            .Columns.Add("Product Name", 150)
            .Columns.Add("Qty", 90, HorizontalAlignment.Right)
        End With

        If m_SKUId <> 0 Then
            cmd = New SqlCommand("usp_mt_sku_raw", cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm1 As SqlParameter = cmd.Parameters.Add("@action", SqlDbType.NVarChar)
            prm1.Value = "READ"
            Dim prm2 As SqlParameter = cmd.Parameters.Add("@sku_id1", SqlDbType.Int)
            prm2.Value = m_SKUId

            cn.Open()

            Dim myReader As SqlDataReader = cmd.ExecuteReader()

            Call FillList(myReader, Me.ListView2, 5, 1)
            myReader.Close()
            cn.Close()
        End If
    End Sub

    Sub clear_lvw3()
        With ListView3
            .Clear()
            .View = View.Details
            .Columns.Add("period_id", 0)
            .Columns.Add("Period Name", 120)
            .Columns.Add("Beginning Qty", 90, HorizontalAlignment.Right)
            .Columns.Add("Incoming Qty", 90, HorizontalAlignment.Right)
            .Columns.Add("Outgoing Qty", 90, HorizontalAlignment.Right)
            .Columns.Add("Beginning Value", 120, HorizontalAlignment.Right)
            .Columns.Add("Incoming Value", 120, HorizontalAlignment.Right)
            .Columns.Add("Outgoing Value", 120, HorizontalAlignment.Right)
        End With

        cmd = New SqlCommand("usp_mt_sku_balance_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm1 As SqlParameter = cmd.Parameters.Add("@sku_id", SqlDbType.Int, 255)
        prm1.Value = m_SKUId

        cn.Open()

        Dim myReader As SqlDataReader = cmd.ExecuteReader()

        'Call FillList(myReader, Me.ListView2, 6, 1)
        Dim lvItem As ListViewItem
        Dim intCurrRow As Integer

        While myReader.Read
            lvItem = New ListViewItem(CStr(myReader.Item(1))) 'period_id
            lvItem.Tag = CStr(myReader.Item(0)) & "*~~~~~*" & intCurrRow 'balance_id
            'lvItem.Tag = "v" & CStr(DR.Item(0))
            lvItem.SubItems.Add(myReader.Item(2)) 'period_name
            lvItem.SubItems.Add(FormatNumber(myReader.Item(3))) 'qty_begin
            lvItem.SubItems.Add(FormatNumber(myReader.Item(4))) 'qty_in
            lvItem.SubItems.Add(FormatNumber(myReader.Item(5))) 'qty_out
            lvItem.SubItems.Add(FormatNumber(myReader.Item(6))) 'val_begin
            lvItem.SubItems.Add(FormatNumber(myReader.Item(7))) 'val_in
            lvItem.SubItems.Add(FormatNumber(myReader.Item(8))) 'val_out
            If intCurrRow Mod 2 = 0 Then
                lvItem.BackColor = Color.Lavender
            Else
                lvItem.BackColor = Color.White
            End If
            lvItem.UseItemStyleForSubItems = True

            ListView3.Items.Add(lvItem)
            intCurrRow += 1
        End While

        myReader.Close()
        cn.Close()
    End Sub

    Sub clear_obj()
        m_SKUId = 0
        txtSKUCode.Text = ""
        txtSKUName.Text = ""
        cmbCategoryID.SelectedIndex = -1
        cmbUomID.SelectedIndex = -1
        txtSKUBarcode.Text = ""
        ntbSalesDiscPercent.Text = 0
        ntbSalesPrice.Text = FormatNumber(0)
        NumericTextBox1.Text = FormatNumber(0)
        NumericTextBox2.Text = FormatNumber(0)
        NumericTextBox3.Text = FormatNumber(0)
        NumericTextBox4.Text = FormatNumber(0)
        txtLastCost.Text = FormatNumber(0)
        txtStockValue.Text = FormatNumber(0)
        txtStockBalance.Text = 0
        txtAvgCost.Text = FormatNumber(0)
        txtSKURemarks.Text = ""
        txtSKUInfo1.Text = ""
        txtSKUInfo2.Text = ""
        txtSKUInfo3.Text = ""
        chbIsFinishedGoods.Checked = False
    End Sub

    Sub clear_objD()
        For Each ctrl As Control In TabPage3.Controls
            If TypeOf ctrl Is TextBox Then ctrl.Text = ""
        Next

        m_SKURawId = 0
        m_SKUId2 = 0
        'txtSKUCode2.Text = ""
        'txtSKUName2.Text = ""
        'ntbSKUPackageQty.Text = ""
    End Sub

    Sub lock_obj(ByVal isLock As Boolean)
        txtSKUCode.ReadOnly = isLock
        txtSKUName.ReadOnly = isLock
        cmbCategoryID.Enabled = Not isLock
        cmbUomID.Enabled = Not isLock
        txtSKUBarcode.ReadOnly = isLock
        ntbSalesDiscPercent.ReadOnly = isLock
        ntbSalesPrice.ReadOnly = isLock
        NumericTextBox1.ReadOnly = isLock
        NumericTextBox2.ReadOnly = isLock
        NumericTextBox3.ReadOnly = isLock
        NumericTextBox4.ReadOnly = isLock

        txtSKURemarks.ReadOnly = isLock
        txtSKUInfo1.ReadOnly = isLock
        txtSKUInfo2.ReadOnly = isLock
        txtSKUInfo3.ReadOnly = isLock

        chbIsFinishedGoods.Enabled = Not isLock

        If m_SKUId = 0 Then
            btnDelete.Enabled = isLock
        Else
            If isAllowDelete = True Then btnDelete.Enabled = Not isLock Else btnDelete.Enabled = False
        End If
        btnEdit.Enabled = isLock
        btnAdd.Enabled = isLock
        btnSave.Enabled = Not isLock
        btnCancel.Enabled = Not isLock
    End Sub

    Sub lock_objD(ByVal isLock As Boolean)
        btnSKU.Enabled = Not isLock
        ntbRawQty.ReadOnly = isLock
        btnSaveD.Enabled = Not isLock
        btnDeleteD.Enabled = Not isLock
        btnAddD.Enabled = Not isLock
    End Sub

    Private Sub cmbSKUCatID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCategoryID.SelectedIndexChanged
        'Dim mList As clsMyList
        'mList = cmbSKUCatID.Items(cmbSKUCatID.SelectedIndex)
        'In the following statement, you can either use mList.ToString or
        'mList.Name. They both return the Name property.
        'Label1.Text = mList.ItemData & "  " & mList.Name
        'Alternately, you can use the following syntax.
        'Label1.Text = ComboBox1.Items(ComboBox1.SelectedIndex).ItemData _
        ' & "  " & ComboBox1.Items(ComboBox1.SelectedIndex).ToString
    End Sub

    Private Sub cmbFilterBy_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbFilterBy.SelectedIndexChanged
        If cmbFilterBy.SelectedItem.ToString = "<All>" Then
            txtFilter.Text = ""
            If m_SKUId <> 0 Then clear_obj()
            clear_lvw()
        End If
        btnCancel_Click(sender, e)
    End Sub

    Private Sub ntbSalesPrice_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ntbSalesPrice.LostFocus
        ntbSalesPrice.Text = FormatNumber(ntbSalesPrice.Text, Dec)
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If MsgBox("Are you sure you want to delete this record?", vbYesNo + vbCritical, Me.Text) = vbYes Then
            cmd = New SqlCommand("usp_mt_sku_DEL", cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm1 As SqlParameter = cmd.Parameters.Add("@sku_id", SqlDbType.Int)
            prm1.Value = m_SKUId
            Dim prm2 As SqlParameter = cmd.Parameters.Add("@user_name", SqlDbType.NVarChar, 50)
            prm2.Value = My.Settings.UserName
            Dim prm3 As SqlParameter = cmd.Parameters.Add("@row_count", SqlDbType.Int)
            prm3.Direction = ParameterDirection.Output
            cn.Open()
            cmd.ExecuteReader()
            cn.Close()
            If prm3.Value = 1 Then
                MsgBox("You can't delete this record because it's already used in transaction.", vbCritical, Me.Text)
            Else
                clear_lvw()
                clear_obj()
            End If
            lock_obj(True)
        End If
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ListView1Sorter = New lvColumnSorter()
        ListView1.ListViewItemSorter = ListView1Sorter
    End Sub

    Private Sub ListView1_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles ListView1.ColumnClick
        If (e.Column = ListView1Sorter.SortColumn) Then
            ' Reverse the current sort direction for this column.
            If (ListView1Sorter.Order = Windows.Forms.SortOrder.Ascending) Then
                ListView1Sorter.Order = Windows.Forms.SortOrder.Descending
            Else
                ListView1Sorter.Order = Windows.Forms.SortOrder.Ascending
            End If
        Else
            ' Set the column number that is to be sorted; default to ascending.
            ListView1Sorter.SortColumn = e.Column
            ListView1Sorter.Order = Windows.Forms.SortOrder.Ascending
        End If

        ' Perform the sort with these new sort options.
        ListView1.Sort()
    End Sub

    Private Sub NumericTextBox1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles NumericTextBox1.LostFocus
        If NumericTextBox1.Text = "" Then NumericTextBox1.Text = FormatNumber(0)
        NumericTextBox1.Text = FormatNumber(NumericTextBox1.Text)
    End Sub

    Private Sub NumericTextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericTextBox1.TextChanged

    End Sub

    Private Sub NumericTextBox2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles NumericTextBox2.LostFocus
        If NumericTextBox2.Text = "" Then NumericTextBox2.Text = FormatNumber(0)
        NumericTextBox2.Text = FormatNumber(NumericTextBox2.Text)
    End Sub

    Private Sub NumericTextBox3_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles NumericTextBox3.LostFocus
        If NumericTextBox3.Text = "" Then NumericTextBox3.Text = FormatNumber(0)
        NumericTextBox3.Text = FormatNumber(NumericTextBox3.Text)
    End Sub

    Private Sub NumericTextBox4_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles NumericTextBox4.LostFocus
        If NumericTextBox4.Text = "" Then NumericTextBox4.Text = FormatNumber(0)
        NumericTextBox4.Text = FormatNumber(NumericTextBox4.Text)
    End Sub

    Private Sub btnFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        clear_lvw()
    End Sub

    Sub populateCbCategory()
        Dim adapter As New SqlDataAdapter
        Dim ds As New DataSet
        Dim i As Integer = 0
        Try
            cn.Open()
            cmd = New SqlCommand("usp_mt_sku_category_SEL", cn)
            cmd.CommandType = CommandType.StoredProcedure

            adapter.SelectCommand = cmd
            adapter.Fill(ds)
            adapter.Dispose()
            cmd.Dispose()
            cn.Close()

            cbCategory.Items.Add(New clsMyListStr("All", ""))

            cbCategory.DataSource = ds.Tables(0)
            cbCategory.ValueMember = "category_id"
            cbCategory.DisplayMember = "category_code"
        Catch ex As Exception
            MsgBox(ex.Message)
            If ConnectionState.Open = 1 Then cn.Close()
        End Try
    End Sub

    Private Sub Label22_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub cbCategory_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'If m_loadFlag = True Then
        '    clear_lvw()
        'End If
    End Sub

    Private Sub ListView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.SelectedIndexChanged

    End Sub

    'Private Sub DataGridView1_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
    '    Dim i As Integer
    '    i = DataGridView1.CurrentRow.Index
    '    m_SKUId = DataGridView1.Item(0, i).Value

    '    With DataGridView1
    '        Dim mList As clsMyListInt
    '        Dim j As Integer
    '        For j = 1 To cmbSKUCatID.Items.Count
    '            mList = cmbSKUCatID.Items(j - 1)
    '            If CInt(.Item(1, i).Value) = mList.ItemData Then
    '                cmbSKUCatID.SelectedIndex = j - 1
    '                Exit For
    '            End If
    '        Next

    '        txtSKUCode.Text = .Item(2, i).Value
    '        txtSKUName.Text = .Item(3, i).Value
    '        txtSKUBarcode.Text = IIf(IsDBNull(.Item(4, i).Value), "", .Item(4, i).Value)
    '        txtSKUUoM.Text = IIf(IsDBNull(.Item(5, i).Value), "", .Item(5, i).Value)
    '        ntbSalesDiscPercent.Text = FormatNumber(.Item(6, i).Value) * 100
    '        ntbSalesPrice.Text = FormatNumber(.Item(7, i).Value, Dec)
    '        NumericTextBox1.Text = FormatNumber(.Item(8, i).Value)
    '        NumericTextBox2.Text = FormatNumber(.Item(9, i).Value)
    '        NumericTextBox3.Text = FormatNumber(.Item(10, i).Value)
    '        NumericTextBox4.Text = FormatNumber(.Item(11, i).Value)
    '        txtLastCost.Text = FormatNumber(.Item(12, i).Value)
    '        txtStockValue.Text = FormatNumber(.Item(13, i).Value)
    '        txtStockBalance.Text = .Item(14, i).Value
    '        txtAvgCost.Text = FormatNumber(.Item(15, i).Value)
    '        txtSKURemarks.Text = IIf(IsDBNull(.Item(16, i).Value), "", .Item(16, i).Value)
    '        txtSKUInfo1.Text = IIf(IsDBNull(.Item(17, i).Value), "", .Item(17, i).Value)
    '        txtSKUInfo2.Text = IIf(IsDBNull(.Item(18, i).Value), "", .Item(18, i).Value)
    '        txtSKUInfo3.Text = IIf(IsDBNull(.Item(19, i).Value), "", .Item(19, i).Value)
    '    End With
    'End Sub

    Private Sub btnSKU_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSKU.Click
        Dim NewFormDialog As New fdlSKU
        NewFormDialog.FrmCallerId = Me.Name
        NewFormDialog.ShowDialog()
    End Sub

    Private Sub btnSaveD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveD.Click
        Try
            If m_SKUId = 0 Then
                If txtSKUCode.Text = "" Or txtSKUName.Text = "" Or cmbCategoryID.SelectedIndex = -1 Then
                    MsgBox("Product Code, Product Name & Sub Category are primary fields that should be entered. Please enter those fields before you save it.", vbCritical + vbOKOnly, Me.Text)
                    txtSKUCode.Focus()
                    Exit Sub
                End If
                SaveSKUHeader()
            End If

            cmd = New SqlCommand("usp_mt_sku_raw", cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm11 As SqlParameter = cmd.Parameters.Add("@action", SqlDbType.NVarChar)
            prm11.Value = IIf(m_SKURawId = 0, "CREATE", "UPDATE")
            Dim prm17 As SqlParameter = cmd.Parameters.Add("@sku_id1", SqlDbType.Int)
            prm17.Value = m_SKUId
            Dim prm18 As SqlParameter = cmd.Parameters.Add("@sku_id2", SqlDbType.Int)
            prm18.Value = m_SKUId2
            Dim prm19 As SqlParameter = cmd.Parameters.Add("@raw_qty", SqlDbType.Decimal)
            prm19.Value = IIf(ntbRawQty.Text = "", 0, CDbl(ntbRawQty.Text))

            If m_SKURawId <> 0 Then
                Dim prm24 As SqlParameter = cmd.Parameters.Add("@raw_id", SqlDbType.Int, 255)
                prm24.Value = m_SKURawId
            End If
            cn.Open()
            cmd.ExecuteReader()
            cn.Close()

            clear_lvw2()
            clear_objD()

        Catch ex As Exception
            'If Err.Number = 5 Then
            '    MsgBox("This primary code has been used (and deleted) previously. Please create with another code", vbExclamation + vbOKOnly, Me.Text)
            'Else
            MsgBox(ex.Message)
            'End If
            If ConnectionState.Open = 1 Then cn.Close()
        End Try
    End Sub

    Private Sub ntbRawQty_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ntbRawQty.LostFocus
        If ntbRawQty.Text = "" Then ntbRawQty.Text = FormatNumber(0)
        ntbRawQty.Text = FormatNumber(ntbRawQty.Text)
    End Sub

    Private Sub btnDeleteD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteD.Click
        If m_SKURawId = 0 Then Exit Sub
        If MsgBox("Are you sure you want to delete this record?", vbYesNo + vbCritical, Me.Text) = vbYes Then
            cmd = New SqlCommand("usp_mt_sku_raw", cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm1 As SqlParameter = cmd.Parameters.Add("@action", SqlDbType.NVarChar)
            prm1.Value = "DELETE"
            Dim prm2 As SqlParameter = cmd.Parameters.Add("@raw_id", SqlDbType.Int)
            prm2.Value = m_SKURawId

            cn.Open()
            cmd.ExecuteReader()
            cn.Close()

            clear_lvw2()
            clear_objD()
        End If
    End Sub

    Private Sub ListView2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView2.Click
        With ListView2.SelectedItems.Item(0)
            m_SKURawId = LeftSplitUF(.Tag)
            m_SKUId2 = .SubItems.Item(1).Text
            txtSKUCode2.Text = .SubItems.Item(2).Text
            txtSKUName2.Text = .SubItems.Item(3).Text
            ntbRawQty.Text = .SubItems.Item(4).Text
        End With
    End Sub

    Private Sub btnAddD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddD.Click
        clear_objD()
    End Sub
End Class