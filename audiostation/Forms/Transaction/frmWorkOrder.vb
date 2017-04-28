Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class frmWorkOrder
    Dim strConnection As String = My.Settings.ConnStr
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Dim cmd As SqlCommand

    Dim m_StockAdjId As Integer
    Dim m_StockAdjNo As String
    Dim m_StockAdjDId As Integer
    Dim m_SKUId As Integer
    Dim m_locationId As Integer
    Dim m_StockAdjCost As Double
    Dim m_StockAdjCostPerUnit As Double
    'Dim m_SKUQtyBalance As Double
    Dim m_QtyProduceBefore As Double
    Dim m_so_dtl_id As Integer

    Dim m_StockAdjDId_detail As Integer
    Dim m_wo_dtl_id As Integer
    Dim m_SKUId_detail As Integer
    Dim m_SKUQtyBalance_detail As Double
    Dim m_LocationId_detail As Integer
    Dim m_LocationIdBefore_detail As Integer
    Dim m_LocationQty_detail As Double
    Dim m_StockAdjCost_detail As Double
    Dim m_StockAdjQtyBefore_detail As Double
    Dim m_StockAdjCostBefore_detail As Double
    Dim m_qty_perunit As Double
    Dim m_RealStockAdjQtyBefore As Double
    Dim m_RealStockAdjCostBefore As Double

    Dim isGetNum As Boolean
    Dim isGetNumStockAdj As Boolean
    Dim isAllowStockMinus As Boolean = GetSysInit("sku_qty_minus")
    Dim isAllowDelete As Boolean

    Dim m_PeriodId As Integer
    Dim m_PeriodArr(0, 0) As String
    Dim isPosted As Boolean

    Private Sub frmWorkOrder_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim prm1 As SqlParameter
        Dim prm2 As SqlParameter
        Dim myReader As SqlDataReader
        Dim i As Integer = 0

        isAllowDelete = canDelete(Me.Name + "List")

        'Add item cmbPeriodId
        cmd = New SqlCommand("usp_sys_period_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        prm1 = cmd.Parameters.Add("@period_type", SqlDbType.NVarChar, 50)
        prm1.Value = "month_period"
        prm2 = cmd.Parameters.Add("@is_locked_sku", SqlDbType.Bit)
        prm2.Value = 0

        cn.Open()
        myReader = cmd.ExecuteReader

        cmbPeriodId.Items.Clear()
        While myReader.Read
            cmbPeriodId.Items.Add(New clsMyListInt(myReader.GetString(1), myReader.GetInt32(0)))
            i += 1
        End While
        If cmbPeriodId.Items.Count > 0 Then cmbPeriodId.SelectedIndex = 0

        myReader.Close()
        cn.Close()

        'Add Period Array
        ReDim m_PeriodArr(i - 1, 2)

        cmd = New SqlCommand("usp_sys_period_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        prm1 = cmd.Parameters.Add("@period_type", SqlDbType.NVarChar, 50)
        prm1.Value = "month_period"
        prm2 = cmd.Parameters.Add("@is_locked_sku", SqlDbType.Bit)
        prm2.Value = 0

        cn.Open()
        myReader = cmd.ExecuteReader

        i = 0
        While myReader.Read
            m_PeriodArr(i, 0) = myReader.GetInt32(0)
            m_PeriodArr(i, 1) = myReader.GetDateTime(2)
            m_PeriodArr(i, 2) = myReader.GetDateTime(3)
            i += 1
        End While

        myReader.Close()
        cn.Close()

        If m_StockAdjId = 0 Then
            btnAdd_Click(sender, e)
        Else
            m_StockAdjDId = 0
            m_StockAdjDId_detail = 0
            m_wo_dtl_id = 0
            view_record()
            clear_lvw()
            lock_obj(True)
            lock_objD(True)
        End If

    End Sub

    Public Property StockAdjId() As Integer
        Get
            Return m_StockAdjId
        End Get
        Set(ByVal Value As Integer)
            m_StockAdjId = Value
        End Set
    End Property
    Public Property so_dtl_id() As Integer
        Get
            Return m_so_dtl_id
        End Get
        Set(ByVal Value As Integer)
            m_so_dtl_id = Value
        End Set
    End Property

    Public Property SKUId() As Integer
        Get
            Return m_SKUId
        End Get
        Set(ByVal Value As Integer)
            m_SKUId = Value
        End Set
    End Property

    Public Property skuCode() As String
        Get
            Return txtSkuCodeHeader.Text
        End Get
        Set(ByVal Value As String)
            txtSkuCodeHeader.Text = Value
        End Set
    End Property

    Public Property skuName() As String
        Get
            Return txtSkuNameHeader.Text
        End Get
        Set(ByVal Value As String)
            txtSkuNameHeader.Text = Value
        End Set
    End Property

    Public Property UomDetail() As String
        Get
            Return txtUomDetail.Text
        End Get
        Set(ByVal Value As String)
            txtUomDetail.Text = Value
        End Set
    End Property

    Public Property SKUId_detail() As Integer
        Get
            Return m_SKUId_detail
        End Get
        Set(ByVal Value As Integer)
            m_SKUId_detail = Value
        End Set
    End Property

    Public Property skuCodeDetail() As String
        Get
            Return txtSkuCodeDetail.Text
        End Get
        Set(ByVal Value As String)
            txtSkuCodeDetail.Text = Value
        End Set
    End Property

    Public Property skuNameDetail() As String
        Get
            Return txtSkuNameDetail.Text
        End Get
        Set(ByVal Value As String)
            txtSkuNameDetail.Text = Value
        End Set
    End Property

    Public Property LocationId() As Integer
        Get
            Return m_LocationId
        End Get
        Set(ByVal Value As Integer)
            m_LocationId = Value
        End Set
    End Property

    Public Property LocationCode() As String
        Get
            Return txtLocationHeader.Text
        End Get
        Set(ByVal Value As String)
            txtLocationHeader.Text = Value
        End Set
    End Property

    Public Property LocationId_Detail() As Integer
        Get
            Return m_LocationId_detail
        End Get
        Set(ByVal Value As Integer)
            m_LocationId_detail = Value
        End Set
    End Property

    Public Property LocationQty_Detail() As Integer
        Get
            Return m_LocationQty_detail
        End Get
        Set(ByVal Value As Integer)
            m_LocationQty_detail = Value
        End Set
    End Property
    Public Property LocationCodeDetail() As String
        Get
            Return txtLocationDetail.Text
        End Get
        Set(ByVal Value As String)
            txtLocationDetail.Text = Value
        End Set
    End Property

    Public Property SONo() As String
        Get
            Return txtSONo.Text
        End Get
        Set(ByVal Value As String)
            txtSONo.Text = Value
        End Set
    End Property

    Public Property UoM() As String
        Get
            Return txtUoM.Text
        End Get
        Set(ByVal Value As String)
            txtUoM.Text = Value
        End Set
    End Property

    Public Property QtyHeader() As Decimal
        Get
            Return ntbQtyHeader.Text
            Return ntbQtyOutstanding.Text
        End Get
        Set(ByVal Value As Decimal)
            ntbQtyHeader.Text = Value
            ntbQtyOutstanding.Text = Value
        End Set
    End Property

    Public Property custCode() As String
        Get
            Return txtCustomerCode.Text
        End Get
        Set(ByVal Value As String)
            txtCustomerCode.Text = Value
        End Set
    End Property

    Public Property custName() As String
        Get
            Return txtCustomerName.Text
        End Get
        Set(ByVal Value As String)
            txtCustomerName.Text = Value
        End Set
    End Property


    Public Property SODetailRequiredDate() As Date
        Get
            Return dtpWODelDate.Value
        End Get
        Set(ByVal Value As Date)
            dtpWODelDate.Value = Value
        End Set
    End Property

    Public Property SKUQtyBalance_detail() As Double
        Get
            Return m_SKUQtyBalance_detail
        End Get
        Set(ByVal Value As Double)
            m_SKUQtyBalance_detail = Value
        End Set
    End Property
    Public Property WorkOrderDetailCost() As String
        Get
            Return ntbCostDetail.Text
        End Get
        Set(ByVal Value As String)
            ntbCostDetail.Text = Value
        End Set
    End Property

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        clear_obj()
        clear_objD()
        clear_lvw()
        lock_obj(False)
        lock_objD(False)
    End Sub

    
    Sub clear_obj()
        txtWONo.Text = ""
        dtpWODate.Value = FormatDateTime(Now, DateFormat.ShortDate)
        txtSONo.Text = ""
        txtWOStatus.Text = ""
        txtSkuCodeHeader.Text = ""
        txtSkuNameHeader.Text = ""
        txtCustomerCode.Text = ""
        txtCustomerName.Text = ""
        txtLocationHeader.Text = ""
        ntbQtyHeader.Text = FormatNumber(0, 2)
        txtWORemarks.Text = ""
        txtInfo1.Text = ""
        txtInfo2.Text = ""
        txtInfo3.Text = ""
        ntbQtyProduced.Text = FormatNumber(0, 2)
        ntbQtyOutstanding.Text = FormatNumber(0, 2)
        ntbTotalQtyProduced.Text = FormatNumber(0, 2)

        m_StockAdjId = 0
        m_StockAdjDId = 0
        m_SKUId = 0
        m_LocationId = 0
        m_StockAdjCost = 0
        m_so_dtl_id = 0

        isGetNum = True
        isGetNumStockAdj = True
    End Sub

    Sub clear_objD()
        txtSkuCodeDetail.Text = ""
        txtSkuNameDetail.Text = ""
        txtLocationDetail.Text = ""
        txtUomDetail.Text = ""
        ntbQtyDetail.Text = FormatNumber(0, 2)
        ntbCostDetail.Text = FormatNumber(0, 2)
        ntbQtyPerUnitDetail.Text = FormatNumber(0, 2)

        m_StockAdjDId_detail = 0
        m_wo_dtl_id = 0
        m_SKUId_detail = 0
        m_SKUQtyBalance_detail = 0
        m_LocationId_detail = 0
        m_LocationIdBefore_detail = 0
        m_LocationQty_detail = 0
        m_StockAdjCost_detail = 0
        m_StockAdjQtyBefore_detail = 0
        m_StockAdjCostBefore_detail = 0
        m_qty_perunit = 0
    End Sub
    Sub lock_obj(ByVal isLock As Boolean)
        txtWONo.ReadOnly = isLock
        dtpWODate.Enabled = Not isLock
        dtpWODelDate.Enabled = Not isLock
        txtWORemarks.ReadOnly = isLock
        txtInfo1.ReadOnly = isLock
        txtInfo2.ReadOnly = isLock
        txtInfo3.ReadOnly = isLock
        ntbQtyHeader.ReadOnly = isLock

        btnEdit.Enabled = isLock
        btnAdd.Enabled = isLock
        btnSave.Enabled = Not isLock
        btnCancel.Enabled = Not isLock
        btnConfirm.Enabled = Not isLock
        btnConfirmOut.Enabled = Not isLock
        ntbQtyProduced.ReadOnly = isLock
        btnPrint.Enabled = isLock
        btnSkuCodeHeader.Enabled = Not isLock
        btnLocationHeader.Enabled = Not isLock
        btnSONo.Enabled = Not isLock

        If txtWONo.Text = "" Then
            txtWONo.ReadOnly = False
            btnDelete.Enabled = isLock
        Else
            txtWONo.ReadOnly = True
            If isAllowDelete = True Then btnDelete.Enabled = Not isLock Else btnDelete.Enabled = False
            btnSkuCodeHeader.Enabled = False
            btnLocationHeader.Enabled = False
            ntbQtyHeader.ReadOnly = True
        End If
        If txtWOStatus.Text = "" Then
            btnConfirm.Enabled = False
            btnConfirmOut.Enabled = False
        End If
        If txtWOStatus.Text = "Outstanding" Then
            btnSONo.Enabled = False
            btnConfirm.Enabled = False
        End If
        If txtWOStatus.Text = "Revised" Then
            btnSONo.Enabled = False
            btnConfirm.Enabled = False
        End If
        If txtWOStatus.Text = "Released" Then
            btnSONo.Enabled = False
            btnConfirmOut.Enabled = False
        End If
        If txtWOStatus.Text = "Partially Produced" Then
            btnDelete.Enabled = False
            btnSONo.Enabled = False
            btnConfirmOut.Enabled = False
        End If
        If txtWOStatus.Text = "Completed" Then
            btnConfirm.Enabled = False
            ntbQtyProduced.ReadOnly = True
            btnDelete.Enabled = False
            btnSONo.Enabled = False
            btnConfirmOut.Enabled = False
        End If
    End Sub

    Sub lock_objD(ByVal isLock As Boolean)
        ntbQtyDetail.ReadOnly = isLock
        ntbCostDetail.ReadOnly = isLock

        btnLocationDetail.Enabled = Not isLock
        btnSKUDetail.Enabled = Not isLock
        btnSaveD.Enabled = Not isLock
        btnDeleteD.Enabled = Not isLock
        btnAddD.Enabled = Not isLock

        If txtWOStatus.Text = "Partial" Or txtWOStatus.Text = "Completed" Then
            btnDeleteD.Enabled = False
            btnSaveD.Enabled = False
            btnAddD.Enabled = False
            btnSKUDetail.Enabled = False
            btnLocationDetail.Enabled = False
            ntbQtyDetail.ReadOnly = True
            ntbCostDetail.ReadOnly = True
        End If
    End Sub

    Sub view_record()
        cmd = New SqlCommand("usp_tr_work_order_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm1 As SqlParameter = cmd.Parameters.Add("@stock_adj_id", SqlDbType.Int)
        prm1.Value = m_StockAdjId

        cn.Open()

        Dim myReader As SqlDataReader = cmd.ExecuteReader()

        While myReader.Read
            txtWONo.Text = myReader.GetString(0)
            dtpWODate.Value = myReader.GetDateTime(1)
            'dtpWODelDate.Value = myReader.GetDateTime(11)
            txtSONo.Text = myReader.GetString(2)
            txtCustomerCode.Text = myReader.GetString(3)
            txtCustomerName.Text = myReader.GetString(4)
            txtSkuCodeHeader.Text = myReader.GetString(5)
            txtSkuNameHeader.Text = myReader.GetString(6)
            ntbQtyHeader.Text = myReader.GetDecimal(7)
            ntbTotalQtyProduced.Text = myReader.GetDecimal(8)
            m_QtyProduceBefore = myReader.GetDecimal(8)
            ntbQtyOutstanding.Text = myReader.GetDecimal(9)
            ntbQtyProduced.Text = FormatNumber(0, 2)
            If myReader.GetString(10) = "O" Then
                txtWOStatus.Text = "Outstanding"
            ElseIf myReader.GetString(10) = "V" Then
                txtWOStatus.Text = "Revised"
            ElseIf myReader.GetString(10) = "R" Then
                txtWOStatus.Text = "Released"
            ElseIf myReader.GetString(10) = "P" Then
                txtWOStatus.Text = "Partially Produced"
            Else
                txtWOStatus.Text = "Completed"
            End If
            txtLocationHeader.Text = myReader.GetString(17)
            m_SKUId = myReader.GetInt32(18)
            'txtUoM.Text = myReader.GetString(19)
            m_StockAdjId = myReader.GetInt32(21)
            m_locationId = myReader.GetInt32(25)
            m_StockAdjNo = myReader.GetString(26)
            m_so_dtl_id = myReader.GetInt32(27)
            If Not myReader.IsDBNull(myReader.GetOrdinal("wo_del_date")) Then
                dtpWODelDate.Value = myReader.GetValue(myReader.GetOrdinal("wo_del_date"))
            Else
                dtpWODelDate.Value = System.DateTime.Now
            End If
            If Not myReader.IsDBNull(myReader.GetOrdinal("wo_remarks")) Then
                txtWORemarks.Text = myReader.GetString(myReader.GetOrdinal("wo_remarks"))
            Else
                txtWORemarks.Text = ""
            End If

            If Not myReader.IsDBNull(myReader.GetOrdinal("sku_uom")) Then
                txtWORemarks.Text = myReader.GetString(myReader.GetOrdinal("sku_uom"))
            Else
                txtUoM.Text = ""
            End If

            If Not myReader.IsDBNull(myReader.GetOrdinal("info1")) Then
                txtInfo1.Text = myReader.GetString(myReader.GetOrdinal("info1"))
            Else
                txtInfo1.Text = ""
            End If

            If Not myReader.IsDBNull(myReader.GetOrdinal("info2")) Then
                txtInfo2.Text = myReader.GetString(myReader.GetOrdinal("info2"))
            Else
                txtInfo2.Text = ""
            End If

            If Not myReader.IsDBNull(myReader.GetOrdinal("info3")) Then
                txtInfo3.Text = myReader.GetString(myReader.GetOrdinal("info3"))
            Else
                txtInfo3.Text = ""
            End If

        End While

        myReader.Close()
        cn.Close()

        Dim nList As clsMyListInt
        For i = 1 To cmbPeriodId.Items.Count
            nList = cmbPeriodId.Items(i - 1)
            If m_PeriodId = nList.ItemData Then
                cmbPeriodId.SelectedIndex = i - 1
                Exit For
            End If
        Next
    End Sub

    Sub clear_lvw()
        With ListView1
            .Clear()
            .View = View.Details
            .Columns.Add("wo_dtl_id", 0)
            .Columns.Add("wo_no", 0)
            .Columns.Add("stock_adj_id", 0)
            .Columns.Add("stock_adj_dtl_id", 0)
            .Columns.Add("stock_balance", 0, HorizontalAlignment.Right)
            .Columns.Add("sku_id", 0)
            .Columns.Add("Stock Code", 120)
            .Columns.Add("Stock Name", 330)
            .Columns.Add("Location", 80)
            .Columns.Add("Unit Qty", 80)
            .Columns.Add("Total Qty", 80, HorizontalAlignment.Right)
            .Columns.Add("UoM", 50)
            .Columns.Add("Unit Cost", 90, HorizontalAlignment.Right)
            .Columns.Add("Total Cost", 120, HorizontalAlignment.Right)
            .Columns.Add("location_id", 0)
            .Columns.Add("location_qty", 0)
            .Columns.Add("stock_adj_qty", 0)
            .Columns.Add("stock_adj_cost", 0)
        End With

        If m_StockAdjId <> 0 Then
            cmd = New SqlCommand("usp_tr_work_order_dtl_SEL", cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm1 As SqlParameter = cmd.Parameters.Add("@wo_no", SqlDbType.NVarChar, 50)
            prm1.Value = txtWONo.Text

            cn.Open()

            Dim myReader As SqlDataReader = cmd.ExecuteReader()

            'Call FillList(myReader, Me.ListView1, 12, 1)
            Dim lvItem As ListViewItem
            Dim i As Integer, intCurrRow As Integer

            While myReader.Read
                lvItem = New ListViewItem(CStr(myReader.Item(0))) 'wo_no
                lvItem.Tag = intCurrRow 'ID
                For i = 1 To 3
                    lvItem.SubItems.Add(myReader.Item(i))
                Next
                lvItem.SubItems.Add(myReader.GetValue(4)) 'stock_balance
                For i = 5 To 8
                    lvItem.SubItems.Add(myReader.Item(i))
                Next

                lvItem.SubItems.Add(myReader.Item(15)) 'qty_perunit
                lvItem.SubItems.Add(myReader.GetValue(9)) 'wo_qty
                lvItem.SubItems.Add(IIf(myReader.Item(10) Is System.DBNull.Value, "", myReader.Item(10))) 'UoM
                lvItem.SubItems.Add(FormatNumber(myReader.Item(11))) 'wo_dtl_cost
                lvItem.SubItems.Add(FormatNumber(myReader.Item(12))) 'wo_total_cost
                lvItem.SubItems.Add(myReader.Item(13)) 'location id
                lvItem.SubItems.Add(myReader.Item(14)) 'location qty
                lvItem.SubItems.Add(IIf(myReader.Item(16) Is System.DBNull.Value, 0, myReader.Item(16))) 'adj_qty
                lvItem.SubItems.Add(IIf(myReader.Item(17) Is System.DBNull.Value, 0, myReader.Item(17))) 'adj_cost

                If intCurrRow Mod 2 = 0 Then
                    lvItem.BackColor = Color.Lavender
                Else
                    lvItem.BackColor = Color.White
                End If
                lvItem.UseItemStyleForSubItems = True

                ListView1.Items.Add(lvItem)
                intCurrRow += 1
            End While

            myReader.Close()
            cn.Close()
        End If
    End Sub

    Private Sub ListView1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.Click
        With ListView1.SelectedItems.Item(0)
            m_StockAdjDId = .SubItems.Item(3).Text
            Dim mList As clsMyListStr
            Dim i As Integer
            m_wo_dtl_id = .SubItems.Item(0).Text
            m_StockAdjDId_detail = .SubItems.Item(3).Text
            m_SKUQtyBalance_detail = CDbl(.SubItems.Item(4).Text)
            m_SKUId_detail = .SubItems.Item(5).Text
            txtSkuCodeDetail.Text = .SubItems.Item(6).Text
            txtSkuNameDetail.Text = .SubItems.Item(7).Text
            txtLocationDetail.Text = .SubItems.Item(8).Text
            ntbQtyPerUnitDetail.Text = CDbl(.SubItems.Item(9).Text)
            m_qty_perunit = CDbl(.SubItems.Item(9).Text)
            ntbQtyDetail.Text = .SubItems.Item(10).Text
            m_StockAdjQtyBefore_detail = CDbl(.SubItems.Item(10).Text)
            txtUomDetail.Text = .SubItems.Item(11).Text
            ntbCostDetail.Text = FormatNumber(.SubItems.Item(12).Text)
            m_StockAdjCostBefore_detail = CDbl(.SubItems.Item(12).Text)
            m_LocationId_detail = CInt(.SubItems.Item(14).Text)
            m_LocationIdBefore_detail = CInt(.SubItems.Item(14).Text)
            m_LocationQty_detail = CDbl(.SubItems.Item(15).Text)
            m_RealStockAdjQtyBefore = CDbl(.SubItems.Item(16).Text)
            m_RealStockAdjCostBefore = CDbl(.SubItems.Item(17).Text)

            If btnSaveD.Enabled = True Then
                btnSKUDetail.Enabled = False
                btnLocationDetail.Enabled = False
            End If
        End With
    End Sub


    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If txtWONo.Text = "" Then
            Me.Close()
        Else
            lock_obj(True)
            lock_objD(True)
            clear_objD()
            m_StockAdjDId_detail = 0
            m_wo_dtl_id = 0
        End If
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        clear_objD()
        lock_obj(False)
        lock_objD(False)
    End Sub
    Private Sub btnAddD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddD.Click
        clear_objD()
        btnSKUDetail.Enabled = True
    End Sub
    Private Sub btnDeleteD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteD.Click
        If m_wo_dtl_id = 0 Then Exit Sub
        If m_StockAdjDId_detail = 0 Then Exit Sub
        If MsgBox("Are you sure you want to delete this record?", vbYesNo + vbCritical, Me.Text) = vbYes Then
            Try
                '-------------------------Start Delete from work order detail-------------------------------
                cmd = New SqlCommand("usp_tr_work_order_dtl_DEL", cn)
                cmd.CommandType = CommandType.StoredProcedure

                Dim prm1 As SqlParameter = cmd.Parameters.Add("@wo_dtl_id", SqlDbType.Int)
                prm1.Value = m_wo_dtl_id

                cn.Open()
                cmd.ExecuteReader()
                cn.Close()
                '-------------------------End Delete from work order detail-------------------------------
                '-------------------------Start Delete from stock adjustment detail out-------------------------------
                cmd = New SqlCommand("usp_tr_stock_adj_dtl_DEL", cn)
                cmd.CommandType = CommandType.StoredProcedure

                Dim prm2 As SqlParameter = cmd.Parameters.Add("@stock_adj_dtl_id", SqlDbType.Int)
                prm2.Value = m_StockAdjDId_detail

                cn.Open()
                cmd.ExecuteReader()
                cn.Close()
                '-------------------------End Delete from stock adjustment detail out-------------------------------
                clear_lvw()
                clear_objD()
                SaveWorkOrderHeader()
                view_record()
                lock_obj(False)
                btnAddD_Click(sender, e)
            Catch ex As Exception
                MsgBox(ex.Message)
                If ConnectionState.Open = 1 Then cn.Close()
            End Try
        End If
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If MsgBox("Are you sure you want to delete this record?", vbYesNo + vbCritical, Me.Text) = vbYes Then
            Try
                '-------------------------Start Delete from work order detail-------------------------------
                cmd = New SqlCommand("usp_tr_work_order_DEL", cn)
                cmd.CommandType = CommandType.StoredProcedure

                Dim prm1 As SqlParameter = cmd.Parameters.Add("@wo_no", SqlDbType.NVarChar, 50)
                prm1.Value = txtWONo.Text
                Dim prm2 As SqlParameter = cmd.Parameters.Add("@user_name", SqlDbType.NVarChar, 50)
                prm2.Value = My.Settings.UserName

                cn.Open()
                cmd.ExecuteReader()
                cn.Close()
                '-------------------------End Delete from work order detail-------------------------------
                '-------------------------Start Delete from stock adjustment detail out-------------------------------
                cmd = New SqlCommand("usp_tr_stock_adj_DEL", cn)
                cmd.CommandType = CommandType.StoredProcedure

                Dim prm3 As SqlParameter = cmd.Parameters.Add("@stock_adj_id", SqlDbType.Int)
                prm3.Value = m_StockAdjId
                Dim prm4 As SqlParameter = cmd.Parameters.Add("@user_name", SqlDbType.NVarChar, 50)
                prm4.Value = My.Settings.UserName

                cn.Open()
                cmd.ExecuteReader()
                cn.Close()
                '-------------------------End Delete from stock adjustment detail out-------------------------------
                btnAdd_Click(sender, e)
            Catch ex As Exception
                MsgBox(ex.Message)
                If ConnectionState.Open = 1 Then cn.Close()
            End Try
        End If
        autoRefresh()
    End Sub
    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Dim strConnection As String = My.Settings.ConnStr
        Dim Connection As New SqlConnection(strConnection)
        Dim strSQL As String

        strSQL = "exec RPT_Work_Order_Form '" & txtWONo.Text & "'"
        Dim DA As New SqlDataAdapter(strSQL, Connection)
        Dim DS As New DataSet

        DA.Fill(DS, "WorkOrder_")

        Dim strReportPath As String = Application.StartupPath & "\Reports\RPT_Work_Order_Form.rpt"

        If Not IO.File.Exists(strReportPath) Then
            Throw (New Exception("Unable to locate report file:" & _
              vbCrLf & strReportPath))
        End If

        Dim cr As New ReportDocument
        Dim NewMDIChild As New frmDocViewer()
        NewMDIChild.Text = "Work Order"
        NewMDIChild.Show()

        cr.Load(strReportPath)
        cr.SetDataSource(DS.Tables("WorkOrder_"))
        With NewMDIChild
            .myCrystalReportViewer.ShowRefreshButton = False
            .myCrystalReportViewer.ShowCloseButton = False
            .myCrystalReportViewer.ShowGroupTreeButton = False
            .myCrystalReportViewer.ReportSource = cr
        End With
    End Sub
    Private Sub btnSONo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSONo.Click
        Dim NewFormDialog As New fdlSOWO
        NewFormDialog.FrmCallerId = Me.Name
        NewFormDialog.ShowDialog()
    End Sub

    Private Sub btnSkuCodeHeader_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSkuCodeHeader.Click
        If txtSONo.Text = "" Then
            MsgBox("Please insert Sales Order No. !", MsgBoxStyle.Critical)
            txtSONo.Focus()
            Exit Sub
        End If
        Dim NewFormDialog As New fdlSKUWO
        NewFormDialog.FrmCallerId = Me.Name
        NewFormDialog.ShowDialog()
    End Sub

    Private Sub btnLocationHeader_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLocationHeader.Click
        If txtSONo.Text = "" Then
            MsgBox("Please insert Sales Order No. !", MsgBoxStyle.Critical)
            txtSONo.Focus()
            Exit Sub
        End If

        If txtSkuCodeHeader.Text = "" Then
            MsgBox("Please insert Stock Code !", MsgBoxStyle.Critical)
            txtSkuCodeHeader.Focus()
            Exit Sub
        End If
        Dim NewFormDialog As New fdlLocation
        NewFormDialog.FrmCallerId = Me.Name + ("Header")
        NewFormDialog.ShowDialog()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If txtSONo.Text = "" Then
            MsgBox("Please insert Sales Order No. !", MsgBoxStyle.Critical)
            txtSONo.Focus()
            Exit Sub
        End If

        If txtSkuCodeHeader.Text = "" Then
            MsgBox("Please insert Stock Code !", MsgBoxStyle.Critical)
            txtSkuCodeHeader.Focus()
            Exit Sub
        End If

        If txtLocationHeader.Text = "" Then
            MsgBox("Please insert Finished Goods Location. !", MsgBoxStyle.Critical)
            txtLocationHeader.Focus()
            Exit Sub
        End If

        Try
            SaveWorkOrderHeader()

            view_record()
            lock_obj(True)
            lock_objD(True)

        Catch ex As Exception
            MsgBox(ex.Message)
            If ConnectionState.Open = 1 Then cn.Close()
        End Try
    End Sub

    Sub SaveWorkOrderHeader()
        If m_PeriodId <> cmbPeriodId.Items(cmbPeriodId.SelectedIndex).ItemData Then
            MsgBox("The transaction date you specified is not within the date range of your accounting period.", vbCritical + vbOKOnly, Me.Text)
            Exit Sub
        End If

        Try
            If m_StockAdjId = 0 Then
                If txtWONo.Text = "" Then
                    txtWONo.Text = GetSysNumber("work_order", Now.Date)
                    isGetNum = True
                Else
                    isGetNum = False
                End If
                m_StockAdjNo = GetSysNumber("stock_production", Now.Date)
                isGetNumStockAdj = True
            Else
                isGetNumStockAdj = False
            End If

            '----------------------------- START SAVE TO WO TABLE-------------------------------------HENDRA
            cmd = New SqlCommand(IIf(m_StockAdjId = 0, "usp_tr_work_order_INS", "usp_tr_work_order_UPD"), cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm1 As SqlParameter = cmd.Parameters.Add("@wo_no", SqlDbType.NVarChar, 50)
            prm1.Value = txtWONo.Text
            Dim prm2 As SqlParameter = cmd.Parameters.Add("@wo_date", SqlDbType.SmallDateTime)
            prm2.Value = dtpWODate.Value.Date
            Dim prm3 As SqlParameter = cmd.Parameters.Add("@wo_del_date", SqlDbType.SmallDateTime)
            prm3.Value = dtpWODelDate.Value.Date
            Dim prm4 As SqlParameter = cmd.Parameters.Add("@so_no", SqlDbType.NVarChar, 50)
            prm4.Value = txtSONo.Text
            Dim prm5 As SqlParameter = cmd.Parameters.Add("@sku_code", SqlDbType.NVarChar, 50)
            prm5.Value = txtSkuCodeHeader.Text
            Dim prm6 As SqlParameter = cmd.Parameters.Add("@location_code", SqlDbType.NVarChar, 50)
            prm6.Value = txtLocationHeader.Text
            Dim prm7 As SqlParameter = cmd.Parameters.Add("@qty_order", SqlDbType.Decimal)
            prm7.Value = IIf(ntbQtyHeader.Text = "", 0, CDbl(ntbQtyHeader.Text))
            Dim prm8 As SqlParameter = cmd.Parameters.Add("@qty_produce", SqlDbType.Decimal)
            prm8.Value = CDbl(ntbTotalQtyProduced.Text)
            Dim prm9 As SqlParameter = cmd.Parameters.Add("@unit_cost", SqlDbType.Decimal)
            prm9.Value = m_StockAdjCostPerUnit
            Dim prm10 As SqlParameter = cmd.Parameters.Add("@wo_remarks", SqlDbType.NVarChar, 255)
            prm10.Value = IIf(txtWORemarks.Text = "", DBNull.Value, txtWORemarks.Text)
            Dim prm11 As SqlParameter = cmd.Parameters.Add("@info1", SqlDbType.NVarChar, 255)
            prm11.Value = IIf(txtInfo1.Text = "", DBNull.Value, txtInfo1.Text)
            Dim prm12 As SqlParameter = cmd.Parameters.Add("@info2", SqlDbType.NVarChar, 255)
            prm12.Value = IIf(txtInfo2.Text = "", DBNull.Value, txtInfo2.Text)
            Dim prm13 As SqlParameter = cmd.Parameters.Add("@info3", SqlDbType.NVarChar, 255)
            prm13.Value = IIf(txtInfo3.Text = "", DBNull.Value, txtInfo3.Text)
            Dim prm14 As SqlParameter = cmd.Parameters.Add("@status", SqlDbType.NVarChar, 25)
            If txtWOStatus.Text = "Released" Then
                prm14.Value = "V"
            Else
                If CDbl(ntbQtyHeader.Text) = CDbl(ntbQtyOutstanding.Text) Then
                    prm14.Value = "O"
                ElseIf CDbl(ntbQtyOutstanding.Text) > 0 Then
                    prm14.Value = "P"
                Else
                    prm14.Value = "C"
                End If
            End If

            'MsgBox(CStr(prm14.Value))
            Dim prm15 As SqlParameter = cmd.Parameters.Add("@user_name", SqlDbType.NVarChar, 50)
            prm15.Value = My.Settings.UserName
            Dim prm17 As SqlParameter = cmd.Parameters.Add("@so_dtl_id", SqlDbType.Int)
            prm17.Value = m_so_dtl_id
            'Dim prm16 As SqlParameter = cmd.Parameters.Add("@stock_adj_id", SqlDbType.Int)

            If m_StockAdjId = 0 Then
                'prm16.Direction = ParameterDirection.Output

                cn.Open()
                cmd.ExecuteReader()
                'm_StockAdjId = prm16.Value
                'MessageBox.Show(m_StockAdjId)
                cn.Close()
                If isGetNum = True Then UpdSysNumber("work_order")
                txtWONo.ReadOnly = True
            Else
                'prm16.Value = m_StockAdjId
                cn.Open()
                cmd.ExecuteReader()
                cn.Close()
                'clear_lvw()
            End If
            '----------------------------- END SAVE TO WO TABLE-------------------------------------HENDRA

            '----------------------------- START SAVE TO STK ADJ TABLE HEADER-------------------------------------HENDRA
            cmd = New SqlCommand(IIf(m_StockAdjId = 0, "usp_tr_stock_adj_INS", "usp_tr_stock_adj_UPD"), cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm31 As SqlParameter = cmd.Parameters.Add("@trans_type", SqlDbType.NVarChar, 50)
            prm31.Value = "STPRO"
            Dim prm32 As SqlParameter = cmd.Parameters.Add("@stock_adj_no", SqlDbType.NVarChar, 50)
            prm32.Value = m_StockAdjNo
            Dim prm33 As SqlParameter = cmd.Parameters.Add("@stock_adj_date", SqlDbType.SmallDateTime)
            prm33.Value = dtpWODate.Value.Date
            Dim prm34 As SqlParameter = cmd.Parameters.Add("@stock_adj_remarks", SqlDbType.NVarChar, 255)
            prm34.Value = IIf(txtWORemarks.Text = "", DBNull.Value, txtWORemarks.Text)
            Dim prm35 As SqlParameter = cmd.Parameters.Add("@user_name", SqlDbType.NVarChar, 50)
            prm35.Value = My.Settings.UserName
            Dim prm37 As SqlParameter = cmd.Parameters.Add("@wo_no", SqlDbType.NVarChar, 50)
            prm37.Value = txtWONo.Text
            Dim prm38 As SqlParameter = cmd.Parameters.Add("@stock_adj_period_id", SqlDbType.Int)
            prm38.Value = cmbPeriodId.Items(cmbPeriodId.SelectedIndex).ItemData
            Dim prm36 As SqlParameter = cmd.Parameters.Add("@stock_adj_id", SqlDbType.Int)

            If m_StockAdjId = 0 Then
                prm36.Direction = ParameterDirection.Output

                cn.Open()
                cmd.ExecuteReader()
                m_StockAdjId = prm36.Value
                'MessageBox.Show(m_StockAdjId)
                cn.Close()
                If isGetNumStockAdj = True Then UpdSysNumber("stock_production")
                'txtWONo.ReadOnly = True
            Else
                prm36.Value = m_StockAdjId
                cn.Open()
                cmd.ExecuteReader()
                cn.Close()
                'clear_lvw()
            End If
            '----------------------------- END SAVE TO STK ADJ TABLE HEADER-------------------------------------HENDRA

        Catch ex As Exception
            MsgBox(ex.Message)
            If ConnectionState.Open = 1 Then cn.Close()
        End Try
        autoRefresh()
    End Sub

    Private Sub btnSaveD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveD.Click
        If txtSONo.Text = "" Then
            MsgBox("Please insert Sales Order No. !", MsgBoxStyle.Critical)
            txtSONo.Focus()
            Exit Sub
        End If

        If txtSkuCodeHeader.Text = "" Then
            MsgBox("Please insert Finished Goods Stock Code !", MsgBoxStyle.Critical)
            txtSkuCodeHeader.Focus()
            Exit Sub
        End If

        If txtLocationHeader.Text = "" Then
            MsgBox("Please insert Finished Goods Location !", MsgBoxStyle.Critical)
            txtLocationHeader.Focus()
            Exit Sub
        End If

        If txtSkuCodeDetail.Text = "" Then
            MsgBox("Please insert Material Requirement Stock Code !", MsgBoxStyle.Critical)
            txtSkuCodeDetail.Focus()
            Exit Sub
        End If

        If txtLocationDetail.Text = "" Then
            MsgBox("Please insert Material Requirement Location !", MsgBoxStyle.Critical)
            txtLocationDetail.Focus()
            Exit Sub
        End If

        If m_StockAdjDId_detail > 0 And isAllowStockMinus = False And m_LocationId_detail <> m_LocationIdBefore_detail And m_LocationQty_detail < CDbl(ntbQtyDetail.Text) Then
            MsgBox("Material Requirement > Stock location balance", vbExclamation + vbOK, Me.Text)
            ntbQtyDetail.Text = m_LocationQty_detail
            Exit Sub
        End If

        SaveWorkOrderHeader()
        SaveWorkOrderDetail()

    End Sub
    Sub SaveWorkOrderDetail()
        Try
            If txtWOStatus.Text = "Released" Then
                lock_obj(True)
            End If
            '----------------------------- START SAVE TO STK ADJ TABLE DETAIL FOR STOCK OUT-------------------------------------HENDRA

            cmd = New SqlCommand(IIf(m_StockAdjDId_detail = 0, "usp_tr_stock_adj_dtl_INS", "usp_tr_stock_adj_dtl_UPD"), cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm241 As SqlParameter = cmd.Parameters.Add("@stock_adj_id", SqlDbType.Int)
            prm241.Value = m_StockAdjId
            Dim prm242 As SqlParameter = cmd.Parameters.Add("@sku_id", SqlDbType.Int)
            prm242.Value = m_SKUId_detail
            Dim prm243 As SqlParameter = cmd.Parameters.Add("@stock_adj_desc", SqlDbType.NVarChar, 255)
            prm243.Value = IIf(txtSkuNameDetail.Text = "", DBNull.Value, txtSkuNameDetail.Text)
            Dim prm244 As SqlParameter = cmd.Parameters.Add("@location_id", SqlDbType.Int)
            prm244.Value = m_LocationId_detail
            Dim prm245 As SqlParameter = cmd.Parameters.Add("@stock_adj_qty", SqlDbType.Decimal)
            prm245.Value = 0
            Dim prm246 As SqlParameter = cmd.Parameters.Add("@stock_adj_cost", SqlDbType.Money)
            prm246.Value = 0
            If m_StockAdjDId_detail <> 0 Then
                Dim prm247 As SqlParameter = cmd.Parameters.Add("@stock_adj_dtl_id", SqlDbType.Int)
                prm247.Value = m_StockAdjDId_detail
                Dim prm248 As SqlParameter = cmd.Parameters.Add("@location_id_before", SqlDbType.Int)
                prm248.Value = m_LocationIdBefore_detail
                Dim prm249 As SqlParameter = cmd.Parameters.Add("@stock_adj_qty_before", SqlDbType.Decimal)
                prm249.Value = m_RealStockAdjQtyBefore
                Dim prm250 As SqlParameter = cmd.Parameters.Add("@stock_adj_cost_before", SqlDbType.Money)
                prm250.Value = m_RealStockAdjCostBefore
            End If
            cn.Open()
            Dim id As String = cmd.ExecuteScalar
            cn.Close()

            '----------------------------- END SAVE TO STK ADJ TABLE DETAIL FOR STOCK OUT-------------------------------------HENDRA
            '----------------------------- START SAVE TO WORK ORDER DTL-------------------------------------HENDRA

            cmd = New SqlCommand(IIf(m_wo_dtl_id = 0, "usp_tr_work_order_dtl_INS", "usp_tr_work_order_dtl_UPD"), cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm261 As SqlParameter = cmd.Parameters.Add("@wo_no", SqlDbType.NVarChar, 50)
            prm261.Value = txtWONo.Text
            Dim prm262 As SqlParameter = cmd.Parameters.Add("@sku_code", SqlDbType.NVarChar, 50)
            prm262.Value = txtSkuCodeDetail.Text
            Dim prm263 As SqlParameter = cmd.Parameters.Add("@wo_dtl_qty", SqlDbType.Decimal)
            prm263.Value = CDbl(ntbQtyDetail.Text)
            Dim prm264 As SqlParameter = cmd.Parameters.Add("@location_code", SqlDbType.NVarChar, 50)
            prm264.Value = txtLocationDetail.Text
            Dim prm265 As SqlParameter = cmd.Parameters.Add("@wo_dtl_cost", SqlDbType.Decimal)
            prm265.Value = CDbl(ntbCostDetail.Text)
            Dim prm266 As SqlParameter = cmd.Parameters.Add("@qty_perunit", SqlDbType.Decimal)
            prm266.Value = CDbl(ntbQtyPerUnitDetail.Text)
            If m_wo_dtl_id <> 0 Then
                Dim prm267 As SqlParameter = cmd.Parameters.Add("@wo_dtl_id", SqlDbType.Int)
                prm267.Value = m_wo_dtl_id
            End If
            Dim prm268 As SqlParameter = cmd.Parameters.Add("@stock_adj_dtl_id", SqlDbType.Int)
            If m_StockAdjDId_detail = 0 Then
                prm268.Value = id
            Else
                prm268.Value = m_StockAdjDId_detail
            End If

            cn.Open()
            cmd.ExecuteReader()
            cn.Close()
            clear_lvw()
            clear_objD()
            view_record()
            '----------------------------- END SAVE TO WORK ORDER DTL-------------------------------------HENDRA
        Catch ex As Exception
            MsgBox(ex.Message)
            If ConnectionState.Open = 1 Then cn.Close()
        End Try

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim TotalSum As Double = 0
        Dim TempNode As ListViewItem
        Dim TempDbl As Double
        Dim TotalCostDetail As Double
        For Each TempNode In ListView1.Items
            If Double.TryParse(TempNode.SubItems.Item(13).Text, TempDbl) Then
                TotalSum += TempDbl
            End If
        Next
        TotalCostDetail = (TotalSum / CDbl(ntbQtyHeader.Text))
        MsgBox(CStr(TotalCostDetail))
    End Sub

    Private Sub btnConfirm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConfirm.Click
        If ntbQtyProduced.DecimalValue = 0 Then
            MsgBox("Please enter Qty. To Produce", vbCritical, Me.Text)
            ntbQtyProduced.Focus()
            Exit Sub
        End If
        '----------------- SET TOTAL COST ---------------------
        Dim TotalSum As Double = 0
        Dim TempNode As ListViewItem
        Dim TempDbl As Double
        For Each TempNode In ListView1.Items
            If Double.TryParse(TempNode.SubItems.Item(13).Text, TempDbl) Then
                TotalSum += TempDbl
            End If
        Next
        m_StockAdjCost = TotalSum
        m_StockAdjCostPerUnit = (TotalSum / CDbl(ntbQtyHeader.Text))
        '-------------- END SET TOTAL COST -------------------
        If MsgBox("Are you sure to confirm stock produce?", vbYesNo + vbCritical, Me.Text) = vbYes Then
            Try
                '----------------------------- START SAVE TO WO TABLE-------------------------------------HENDRA
                cmd = New SqlCommand("usp_tr_work_order_CONFIRM", cn)
                cmd.CommandType = CommandType.StoredProcedure

                Dim prm201 As SqlParameter = cmd.Parameters.Add("@wo_no", SqlDbType.NVarChar, 50)
                prm201.Value = txtWONo.Text
                Dim prm204 As SqlParameter = cmd.Parameters.Add("@so_no", SqlDbType.NVarChar, 50)
                prm204.Value = txtSONo.Text
                Dim prm205 As SqlParameter = cmd.Parameters.Add("@sku_code", SqlDbType.NVarChar, 50)
                prm205.Value = txtSkuCodeHeader.Text
                Dim prm208 As SqlParameter = cmd.Parameters.Add("@qty_produce", SqlDbType.Decimal)
                prm208.Value = IIf(ntbQtyProduced.Text = "", 0, CDbl(ntbQtyProduced.Text))
                Dim prm209 As SqlParameter = cmd.Parameters.Add("@unit_cost", SqlDbType.Decimal)
                prm209.Value = m_StockAdjCostPerUnit
                Dim prm210 As SqlParameter = cmd.Parameters.Add("@so_dtl_id", SqlDbType.Int)
                prm210.Value = m_so_dtl_id
                Dim prm214 As SqlParameter = cmd.Parameters.Add("@status", SqlDbType.NVarChar, 25)
                If CDbl(ntbQtyHeader.Text) = CDbl(ntbQtyOutstanding.Text) - CDbl(ntbQtyProduced.Text) Then
                    prm214.Value = "O"
                ElseIf CDbl(ntbQtyOutstanding.Text) - CDbl(ntbQtyProduced.Text) > 0 Then
                    prm214.Value = "P"
                Else
                    prm214.Value = "C"
                End If
                Dim prm215 As SqlParameter = cmd.Parameters.Add("@user_name", SqlDbType.NVarChar, 50)
                prm215.Value = My.Settings.UserName
                'Dim prm16 As SqlParameter = cmd.Parameters.Add("@stock_adj_id", SqlDbType.Int)
                cn.Open()
                cmd.ExecuteReader()
                cn.Close()
                'clear_lvw()
                '----------------------------- END SAVE TO WO TABLE-------------------------------------HENDRA

                '----------------------------- START SAVE TO STK ADJ TABLE DETAIL FOR STOCK IN-------------------------------------HENDRA
                cmd = New SqlCommand("usp_tr_stock_adj_dtl_INS", cn)
                cmd.CommandType = CommandType.StoredProcedure

                Dim prm51 As SqlParameter = cmd.Parameters.Add("@stock_adj_id", SqlDbType.Int)
                prm51.Value = m_StockAdjId
                Dim prm52 As SqlParameter = cmd.Parameters.Add("@sku_id", SqlDbType.Int)
                prm52.Value = m_SKUId
                Dim prm53 As SqlParameter = cmd.Parameters.Add("@stock_adj_desc", SqlDbType.NVarChar, 255)
                prm53.Value = IIf(txtSkuNameHeader.Text = "", DBNull.Value, txtSkuNameHeader.Text)
                Dim prm54 As SqlParameter = cmd.Parameters.Add("@location_id", SqlDbType.Int)
                prm54.Value = m_locationId
                Dim prm55 As SqlParameter = cmd.Parameters.Add("@stock_adj_qty", SqlDbType.Decimal)
                prm55.Value = ntbQtyProduced.Text
                Dim prm56 As SqlParameter = cmd.Parameters.Add("@stock_adj_cost", SqlDbType.Money)
                prm56.Value = m_StockAdjCostPerUnit

                cn.Open()
                cmd.ExecuteReader()
                cn.Close()

                cmd = New SqlCommand("usp_tr_stock_adj_dtl_INS", cn)
                clear_lvw()
                clear_objD()
                '----------------------------- END SAVE TO STK ADJ TABLE DETAIL FOR STOCK IN-------------------------------------HENDRA
                view_record()
                lock_obj(True)
                lock_objD(True)
            Catch ex As Exception
                MsgBox(ex.Message)
                If ConnectionState.Open = 1 Then cn.Close()
            End Try
        End If
        autoRefresh()
    End Sub
    Private Sub btnConfirmOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConfirmOut.Click
        If MsgBox("Are you sure to confirm material release?", vbYesNo + vbCritical, Me.Text) = vbYes Then
            If ListView1.Items.Count = 0 Then
                MsgBox("Please fill the material release first!", vbCritical, Me.Text)
                btnSKUDetail.Focus()
                Exit Sub
            End If
            Try
                Dim StockLocation As Double
                Dim myReader As SqlDataReader
                'Dim test999 As String
                For i = 0 To ListView1.Items.Count - 1
                    'test999 = "select sku_qty from mt_sku_location where sku_id = " + ListView1.Items(i).SubItems(5).Text + " and location_id = " + ListView1.Items(i).SubItems(14).Text + " "
                    cmd = New SqlCommand("select sku_qty from mt_sku_location where sku_id = " + ListView1.Items(i).SubItems(5).Text + " and location_id = " + ListView1.Items(i).SubItems(14).Text + " ", cn)
                    'MsgBox(CStr(test999))
                    cn.Open()

                    myReader = cmd.ExecuteReader()

                    While myReader.Read
                        StockLocation = CDbl(myReader.Item(0))
                    End While

                    myReader.Close()
                    cn.Close()

                    If CInt(ListView1.Items(i).SubItems(3).Text) > 0 And isAllowStockMinus = False And StockLocation < CDbl(ListView1.Items(i).SubItems(10).Text) Then
                        MsgBox("Material release for item " + ListView1.Items(i).SubItems(6).Text + " " + ListView1.Items(i).SubItems(7).Text + " > Stock location balance" + vbCrLf + "Material release canceled!", vbCritical + vbOK, Me.Text)
                        Exit Sub
                    End If
                Next

                For i = 0 To ListView1.Items.Count - 1
                    'm_wo_dtl_id = .SubItems.Item(0).Text
                    'm_StockAdjDId_detail = .SubItems.Item(3).Text
                    'm_SKUQtyBalance_detail = CDbl(.SubItems.Item(4).Text)
                    'm_SKUId_detail = .SubItems.Item(5).Text
                    'txtSkuCodeDetail.Text = .SubItems.Item(6).Text
                    'txtSkuNameDetail.Text = .SubItems.Item(7).Text
                    'txtLocationDetail.Text = .SubItems.Item(8).Text
                    'ntbQtyPerUnitDetail.Text = CDbl(.SubItems.Item(9).Text)
                    'm_qty_perunit = CDbl(.SubItems.Item(9).Text)
                    'ntbQtyDetail.Text = .SubItems.Item(10).Text
                    'm_StockAdjQtyBefore_detail = CDbl(.SubItems.Item(10).Text)
                    'txtUomDetail.Text = .SubItems.Item(11).Text
                    'ntbCostDetail.Text = FormatNumber(.SubItems.Item(12).Text)
                    'm_StockAdjCostBefore_detail = CDbl(.SubItems.Item(12).Text)
                    'm_LocationId_detail = CInt(.SubItems.Item(14).Text)
                    'm_LocationIdBefore_detail = CInt(.SubItems.Item(14).Text)
                    'm_LocationQty_detail = CDbl(.SubItems.Item(15).Text)
                    '----------------------------- START SAVE TO STK ADJ TABLE DETAIL FOR STOCK OUT-------------------------------------HENDRA
                    cmd = New SqlCommand("usp_tr_stock_adj_dtl_UPD", cn)
                    cmd.CommandType = CommandType.StoredProcedure

                    Dim prm241 As SqlParameter = cmd.Parameters.Add("@stock_adj_id", SqlDbType.Int)
                    prm241.Value = m_StockAdjId
                    Dim prm242 As SqlParameter = cmd.Parameters.Add("@sku_id", SqlDbType.Int)
                    prm242.Value = CInt(ListView1.Items(i).SubItems(5).Text)
                    Dim prm243 As SqlParameter = cmd.Parameters.Add("@stock_adj_desc", SqlDbType.NVarChar, 255)
                    prm243.Value = ListView1.Items(i).SubItems(7).Text
                    Dim prm244 As SqlParameter = cmd.Parameters.Add("@location_id", SqlDbType.Int)
                    prm244.Value = CInt(ListView1.Items(i).SubItems(14).Text)
                    Dim prm245 As SqlParameter = cmd.Parameters.Add("@stock_adj_qty", SqlDbType.Decimal)
                    prm245.Value = CDbl(ListView1.Items(i).SubItems(10).Text) * -1
                    Dim prm246 As SqlParameter = cmd.Parameters.Add("@stock_adj_cost", SqlDbType.Money)
                    prm246.Value = CDbl(ListView1.Items(i).SubItems(12).Text)
                    Dim prm247 As SqlParameter = cmd.Parameters.Add("@stock_adj_dtl_id", SqlDbType.Int)
                    prm247.Value = CInt(ListView1.Items(i).SubItems(3).Text)
                    Dim prm248 As SqlParameter = cmd.Parameters.Add("@location_id_before", SqlDbType.Int)
                    prm248.Value = CInt(ListView1.Items(i).SubItems(14).Text)
                    Dim prm249 As SqlParameter = cmd.Parameters.Add("@stock_adj_qty_before", SqlDbType.Decimal)
                    prm249.Value = CDbl(ListView1.Items(i).SubItems(16).Text)
                    Dim prm250 As SqlParameter = cmd.Parameters.Add("@stock_adj_cost_before", SqlDbType.Money)
                    prm250.Value = CDbl(ListView1.Items(i).SubItems(17).Text)

                    cn.Open()
                    cmd.ExecuteReader()
                    cn.Close()
                Next

                '----------------------------- END SAVE TO STK ADJ TABLE DETAIL FOR STOCK OUT-------------------------------------HENDRA
                '----------------------------- START UPDATE TO WO TABLE-------------------------------------HENDRA
                cmd = New SqlCommand("usp_tr_work_order_UPD", cn)
                cmd.CommandType = CommandType.StoredProcedure

                Dim prm1 As SqlParameter = cmd.Parameters.Add("@wo_no", SqlDbType.NVarChar, 50)
                prm1.Value = txtWONo.Text
                Dim prm2 As SqlParameter = cmd.Parameters.Add("@wo_date", SqlDbType.SmallDateTime)
                prm2.Value = dtpWODate.Value.Date
                Dim prm3 As SqlParameter = cmd.Parameters.Add("@wo_del_date", SqlDbType.SmallDateTime)
                prm3.Value = dtpWODelDate.Value.Date
                Dim prm4 As SqlParameter = cmd.Parameters.Add("@so_no", SqlDbType.NVarChar, 50)
                prm4.Value = txtSONo.Text
                Dim prm5 As SqlParameter = cmd.Parameters.Add("@sku_code", SqlDbType.NVarChar, 50)
                prm5.Value = txtSkuCodeHeader.Text
                Dim prm6 As SqlParameter = cmd.Parameters.Add("@location_code", SqlDbType.NVarChar, 50)
                prm6.Value = txtLocationHeader.Text
                Dim prm7 As SqlParameter = cmd.Parameters.Add("@qty_order", SqlDbType.Decimal)
                prm7.Value = IIf(ntbQtyHeader.Text = "", 0, CDbl(ntbQtyHeader.Text))
                Dim prm8 As SqlParameter = cmd.Parameters.Add("@qty_produce", SqlDbType.Decimal)
                prm8.Value = CDbl(ntbTotalQtyProduced.Text)
                Dim prm9 As SqlParameter = cmd.Parameters.Add("@unit_cost", SqlDbType.Decimal)
                prm9.Value = m_StockAdjCostPerUnit
                Dim prm10 As SqlParameter = cmd.Parameters.Add("@wo_remarks", SqlDbType.NVarChar, 255)
                prm10.Value = IIf(txtWORemarks.Text = "", DBNull.Value, txtWORemarks.Text)
                Dim prm11 As SqlParameter = cmd.Parameters.Add("@info1", SqlDbType.NVarChar, 255)
                prm11.Value = IIf(txtInfo1.Text = "", DBNull.Value, txtInfo1.Text)
                Dim prm12 As SqlParameter = cmd.Parameters.Add("@info2", SqlDbType.NVarChar, 255)
                prm12.Value = IIf(txtInfo2.Text = "", DBNull.Value, txtInfo2.Text)
                Dim prm13 As SqlParameter = cmd.Parameters.Add("@info3", SqlDbType.NVarChar, 255)
                prm13.Value = IIf(txtInfo3.Text = "", DBNull.Value, txtInfo3.Text)
                Dim prm14 As SqlParameter = cmd.Parameters.Add("@status", SqlDbType.NVarChar, 25)
                prm14.Value = "R"
                Dim prm15 As SqlParameter = cmd.Parameters.Add("@user_name", SqlDbType.NVarChar, 50)
                prm15.Value = My.Settings.UserName
                Dim prm17 As SqlParameter = cmd.Parameters.Add("@so_dtl_id", SqlDbType.Int)
                prm17.Value = m_so_dtl_id
                'Dim prm16 As SqlParameter = cmd.Parameters.Add("@stock_adj_id", SqlDbType.Int)

                cn.Open()
                cmd.ExecuteReader()
                cn.Close()

                '----------------------------- END UPDATE TO WO TABLE-------------------------------------HENDRA
                MsgBox("Material releasing done!", vbInformation)
                view_record()
                lock_obj(True)
                lock_objD(True)
            Catch ex As Exception
                MsgBox(ex.Message)
                If ConnectionState.Open = 1 Then cn.Close()
            End Try
        End If
        autoRefresh()
    End Sub
    Private Sub btnSKUDetail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSKUDetail.Click
        If txtSONo.Text = "" Then
            MsgBox("Please insert Sales Order No. !", MsgBoxStyle.Critical)
            txtSONo.Focus()
            Exit Sub
        End If

        If txtSkuCodeHeader.Text = "" Then
            MsgBox("Please insert Stock Code !", MsgBoxStyle.Critical)
            txtSkuCodeHeader.Focus()
            Exit Sub
        End If

        If txtLocationHeader.Text = "" Then
            MsgBox("Please insert Finished Goods Location. !", MsgBoxStyle.Critical)
            txtLocationHeader.Focus()
            Exit Sub
        End If

        txtLocationDetail.Text = ""

        Dim NewFormDialog As New fdlSKUAdj
        NewFormDialog.FrmCallerId = Me.Name
        NewFormDialog.ShowDialog()
    End Sub

    Private Sub btnLocationDetail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLocationDetail.Click
        If txtSONo.Text = "" Then
            MsgBox("Please insert Sales Order No. !", MsgBoxStyle.Critical)
            txtSONo.Focus()
            Exit Sub
        End If

        If txtSkuCodeHeader.Text = "" Then
            MsgBox("Please insert Finished Goods Stock Code !", MsgBoxStyle.Critical)
            txtSkuCodeHeader.Focus()
            Exit Sub
        End If

        If txtLocationHeader.Text = "" Then
            MsgBox("Please insert Finished Goods Location !", MsgBoxStyle.Critical)
            txtLocationHeader.Focus()
            Exit Sub
        End If

        If txtSkuCodeDetail.Text = "" Then
            MsgBox("Please insert Material Requirement Stock Code !", MsgBoxStyle.Critical)
            txtSkuCodeDetail.Focus()
            Exit Sub
        End If

        Dim NewFormDialog As New fdlLocation
        NewFormDialog.FrmCallerId = Me.Name + "Detail"
        NewFormDialog.SKUId = m_SKUId_detail
        NewFormDialog.ShowDialog()
    End Sub

    Private Sub ntbQtyDetail_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ntbQtyDetail.LostFocus
        If txtSkuCodeDetail.Text = "" Then
            MsgBox("Please insert Material Requirement Stock Code !", MsgBoxStyle.Critical)
            txtSkuCodeDetail.Focus()
            ntbQtyDetail.Text = FormatNumber(0, 2)
            txtSkuCodeDetail.Focus()
        End If

        If txtLocationDetail.Text = "" Then
            MsgBox("Please insert Material Requirement Location !", MsgBoxStyle.Critical)
            ntbQtyDetail.Text = FormatNumber(0, 2)
            txtLocationDetail.Focus()
        End If

        If ntbQtyDetail.Text = "" Then ntbQtyDetail.Text = FormatNumber(0, 2)
        If CDbl(ntbQtyDetail.Text) < 0 Then ntbQtyDetail.Text = CDbl(ntbQtyDetail.Text) * -1
        If isAllowStockMinus = False And m_LocationQty_detail + m_StockAdjQtyBefore_detail < CDbl(ntbQtyDetail.Text) Then
            MsgBox("Material Requirement > Stock Location", vbExclamation + vbOK, Me.Text)
            If m_StockAdjDId_detail = 0 Then
                ntbQtyDetail.Text = FormatNumber(0, 2)
            End If

            ntbQtyDetail.Focus()
        End If

        ntbQtyPerUnitDetail.Text = FormatNumber(CDbl(ntbQtyDetail.Text) / CDbl(ntbQtyHeader.Text), 2)
        If CDbl(ntbCostDetail.Text) < 0 Then ntbCostDetail.Text = CDbl(ntbCostDetail.Text) * -1


        'If cmbStockMovementType.Items(cmbStockMovementType.SelectedIndex).ItemData = "O" And isAllowStockMinus = False And m_LocationQty + (m_StockAdjQtyBefore * -1) < CDbl(ntbStockAdjQty.Text) Then
        '    MsgBox("Movement qty out > Stock location balance", vbExclamation + vbOK, Me.Text)
        '    'ntbStockAdjQty.Text = m_SKUQtyBalance
        '    ntbStockAdjQty.Text = FormatNumber(m_LocationQty)
        'End If
    End Sub

    'Private Sub ntbQtyPerUnitDetail_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ntbQtyPerUnitDetail.LostFocus
    '    If m_StockAdjDId_detail <> 0 Then
    '        If txtSkuCodeDetail.Text = "" Then
    '            MsgBox("Please insert Material Requirement Stock Code !", MsgBoxStyle.Critical)
    '            txtSkuCodeDetail.Focus()
    '            ntbQtyDetail.Text = FormatNumber(0, 2)
    '            txtSkuCodeDetail.Focus()
    '        End If

    '        If txtLocationDetail.Text = "" Then
    '            MsgBox("Please insert Material Requirement Location !", MsgBoxStyle.Critical)
    '            ntbQtyDetail.Text = FormatNumber(0, 2)
    '            txtLocationDetail.Focus()
    '        End If
    '    End If

    '    If ntbQtyPerUnitDetail.Text = "" Then ntbQtyPerUnitDetail.Text = FormatNumber(0, 2)
    '    If CDbl(ntbQtyPerUnitDetail.Text) < 0 Then ntbQtyPerUnitDetail.Text = CDbl(ntbQtyPerUnitDetail.Text) * -1
    '    If m_StockAdjDId_detail <> 0 Then
    '        ntbQtyDetail.Text = FormatNumber(CDbl(ntbQtyPerUnitDetail.Text) * CDbl(ntbQtyHeader.Text), 2)
    '    End If
    'End Sub

    Private Sub ntbQtyHeader_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ntbQtyHeader.LostFocus
        If ntbQtyHeader.Text = "" Then ntbQtyHeader.Text = FormatNumber(0, 2)
        If CDbl(ntbQtyHeader.Text) < 0 Then ntbQtyHeader.Text = CDbl(ntbQtyHeader.Text) * -1
        If CDbl(ntbQtyHeader.Text) < CDbl(ntbQtyProduced.Text) Then
            MsgBox("Qty Produced > Qty Order", MsgBoxStyle.Critical)
            ntbQtyHeader.Text = ntbQtyProduced.Text
            ntbQtyOutstanding.Text = CDbl(ntbQtyHeader.Text) - CDbl(ntbQtyProduced.Text)
        Else
            ntbQtyOutstanding.Text = CDbl(ntbQtyHeader.Text) - CDbl(ntbQtyProduced.Text)
        End If
    End Sub

    Private Sub ntbQtyProduced_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ntbQtyProduced.LostFocus
        If ntbQtyProduced.Text = "" Then ntbQtyProduced.Text = FormatNumber(0, 2)
        If CDbl(ntbQtyProduced.Text) < 0 Then ntbQtyProduced.Text = CDbl(ntbQtyProduced.Text) * -1
        If CDbl(ntbQtyHeader.Text) < (CDbl(ntbQtyProduced.Text) + CDbl(ntbTotalQtyProduced.Text)) Then
            MsgBox("Qty Produced > Qty Order " + vbCrLf + "Qty Order : " + CStr(ntbQtyHeader.Text) + vbCrLf + "Qty Outstanding : " + CStr(ntbQtyOutstanding.Text), MsgBoxStyle.Critical)
            ntbQtyProduced.Text = FormatNumber(0, 2)
            ntbQtyOutstanding.Text = CDbl(ntbQtyHeader.Text) - CDbl(ntbTotalQtyProduced.Text)
        Else
            ntbQtyOutstanding.Text = CDbl(ntbQtyHeader.Text) - CDbl(ntbTotalQtyProduced.Text)
        End If
    End Sub

    Private Sub ntbCostDetail_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ntbCostDetail.LostFocus
        If ntbCostDetail.Text = "" Then ntbCostDetail.Text = FormatNumber(0, 2)
        If CDbl(ntbCostDetail.Text) < 0 Then ntbCostDetail.Text = CDbl(ntbCostDetail.Text) * -1
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim TotalSum As Double = 0
        Dim TempNode As ListViewItem
        Dim TempDbl As Double
        For Each TempNode In ListView1.Items
            If Double.TryParse(TempNode.SubItems.Item(13).Text, TempDbl) Then
                TotalSum += TempDbl
            End If
        Next
        MsgBox(TotalSum)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        MsgBox("m_StockAdjDId_detail " + CStr(m_StockAdjDId_detail) + vbCrLf & _
               "m_wo_dtl_id " + CStr(m_wo_dtl_id) + vbCrLf & _
               "m_SKUId_detail " + CStr(m_SKUId_detail) + vbCrLf & _
               "m_SKUQtyBalance_detail " + CStr(m_SKUQtyBalance_detail) + vbCrLf & _
               "m_LocationId_detail " + CStr(m_LocationId_detail) + vbCrLf & _
               "m_LocationIdBefore_detail " + CStr(m_LocationIdBefore_detail) + vbCrLf & _
               "m_LocationQty_detail " + CStr(m_LocationQty_detail) + vbCrLf & _
               "m_StockAdjCost_detail " + CStr(m_StockAdjCost_detail) + vbCrLf & _
               "m_StockAdjQtyBefore_detail " + CStr(m_StockAdjQtyBefore_detail) + vbCrLf & _
               "m_StockAdjCostBefore_detail " + CStr(m_StockAdjCostBefore_detail) + vbCrLf & _
               "m_qty_perunit " + CStr(m_qty_perunit))
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        MsgBox("m_StockAdjId " + CStr(m_StockAdjId))
    End Sub
    'Set autorefresh list---hendra
    Sub autoRefresh()
        If Application.OpenForms().OfType(Of frmWorkOrderList).Any Then
            Call frmWorkOrderList.frmWorkOrderListShow(Nothing, EventArgs.Empty)
        End If
    End Sub

    Private Sub dtpWODate_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpWODate.ValueChanged
        For i = 0 To m_PeriodArr.GetUpperBound(0)
            If dtpWODate.Value >= m_PeriodArr(i, 1) AndAlso dtpWODate.Value <= m_PeriodArr(i, 2) Then
                cmbPeriodId.SelectedIndex = i
                m_PeriodId = cmbPeriodId.Items(cmbPeriodId.SelectedIndex).ItemData
                Exit For
            Else
                m_PeriodId = 0
            End If
        Next
    End Sub
End Class
