﻿Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class frmPPitching
    Dim strConnection As String = My.Settings.ConnStr
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Dim cmd As SqlCommand
    Dim m_POId As Integer
    Dim m_PONo As String
    Dim m_SId As Integer
    Dim m_CurrBaseId As Integer
    Dim m_POType As String
    Dim m_PaymentMethod As String
    Dim m_POStatus As String
    Dim m_POStatusArr(4, 1) As String
    Dim m_PODId As Integer
    Dim m_PRequestDId As Integer
    Dim m_PODtlType As String
    Dim m_SKUId As Integer
    Dim isSKUPackage As Boolean
    Dim m_LocationId As Integer
    Dim m_PchCodeId As Integer
    Dim m_POTaxPercent As Single
    Dim m_CurrId As Integer
    Dim m_POQtyBefore As Double
    Dim m_SumPReceiveQty As Double
    Dim m_POCurrRateBefore As Double
    Dim m_FrmCallerId As String
    Dim isGetNum As Boolean
    Dim isAllowDelete As Boolean
    Dim isConvertToPO As Boolean
    Private docPO As ReportDocument
    Dim Dec As Integer = GetSysInit("decimal_digit")

    'A DataAdapter gives us the ability to get data from a database and send changes back to the database.
    Dim poDetail_DataAdapter As SqlDataAdapter = Nothing

    'The DataTable that will actually contain the data that the GridView is displaying.
    Dim poDetail_DataTable As DataTable = Nothing

    'A DataTable that is the source for the grid's combobox. We don't need to update this data, it is just
    'there to facilitate binding the [GrowsOn] field of the table.
    Dim growsOnTable As DataTable = Nothing

    Private Sub frmPO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ToolTip1.SetToolTip(btnSupplier, "Search Supplier")
        ToolTip1.SetToolTip(btnSKU, "Search Stock")
        ToolTip1.SetToolTip(btnSaveD, "Save Line")
        ToolTip1.SetToolTip(btnDeleteD, "Delete Line")
        ToolTip1.SetToolTip(btnAddD, "Add Line")

        isAllowDelete = canDelete(Me.Name + "List")
        m_POTaxPercent = GetSysInit("tax_percent") * 100

        Dim prm1 As SqlParameter
        Dim myReader As SqlDataReader

        'Base Currency
        cmd = New SqlCommand("usp_mt_curr_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        prm1 = cmd.Parameters.Add("@base_curr", SqlDbType.Bit)
        prm1.Value = 1

        cn.Open()
        myReader = cmd.ExecuteReader

        While myReader.Read
            m_CurrBaseId = myReader.GetInt32(0)
            'm_CurrBaseCode = myReader.GetString(1)
        End While

        myReader.Close()
        cn.Close()

        'Add item cmbPOType
        cmd = New SqlCommand("sp_sys_dropdown_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        prm1 = cmd.Parameters.Add("@sys_dropdown_whr", SqlDbType.NVarChar, 50)
        prm1.Value = "po_type"

        cn.Open()
        myReader = cmd.ExecuteReader

        cmbPOType.Items.Clear()
        While myReader.Read
            cmbPOType.Items.Add(New clsMyListStr(myReader.GetString(1), myReader.GetString(0)))
        End While
        cmbPOType.SelectedIndex = 0

        myReader.Close()
        cn.Close()

        'Add item cmbPOStatus
        cmd = New SqlCommand("sp_sys_dropdown_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        prm1 = cmd.Parameters.Add("@sys_dropdown_whr", SqlDbType.NVarChar, 50)
        prm1.Value = "ppitching_status"

        cn.Open()
        myReader = cmd.ExecuteReader
        Dim i As Integer = 0

        While myReader.Read
            m_POStatusArr(i, 0) = myReader.GetString(0)
            m_POStatusArr(i, 1) = myReader.GetString(1)
            i += 1
        End While

        myReader.Close()
        cn.Close()

        'Add item cmbPaymentType
        cmd = New SqlCommand("sp_sys_dropdown_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        prm1 = cmd.Parameters.Add("@sys_dropdown_whr", SqlDbType.NVarChar, 50)
        prm1.Value = "payment_type"

        cn.Open()
        myReader = cmd.ExecuteReader

        cmbPaymentMethod.Items.Clear()
        While myReader.Read
            cmbPaymentMethod.Items.Add(New clsMyListStr(myReader.GetString(1), myReader.GetString(0)))
        End While
        cmbPaymentMethod.SelectedIndex = 0

        myReader.Close()
        cn.Close()

        'Add item cmbPODtlType
        cmd = New SqlCommand("sp_sys_dropdown_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        prm1 = cmd.Parameters.Add("@sys_dropdown_whr", SqlDbType.NVarChar, 50)
        prm1.Value = "po_dtl_type"

        cn.Open()
        myReader = cmd.ExecuteReader

        cmbPODtlType.Items.Clear()
        While myReader.Read
            cmbPODtlType.Items.Add(New clsMyListStr(myReader.GetString(1), myReader.GetString(0)))
        End While
        cmbPODtlType.SelectedIndex = 0

        myReader.Close()
        cn.Close()

        If m_POId = 0 Then
            btnAdd_Click(sender, e)
        Else
            m_PODId = 0
            view_record()
            clear_lvw()
            'bindGrid()
            'btnEdit_Click(sender, e)
            clear_objD()
            lock_obj(True)
            lock_objD(True)
        End If
    End Sub

    Private Sub btnSupplier_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSupplier.Click
        Dim NewFormDialog As New fdlSupplier
        NewFormDialog.FrmCallerId = Me.Name
        NewFormDialog.ShowDialog()
    End Sub

    Public Property FrmCallerId() As String
        Get
            Return m_FrmCallerId
        End Get
        Set(ByVal Value As String)
            m_FrmCallerId = Value
        End Set
    End Property

    Public Property POId() As Integer
        Get
            Return m_POId
        End Get
        Set(ByVal Value As Integer)
            m_POId = Value
        End Set
    End Property

    Public Property SId() As Integer
        Get
            Return m_SId
        End Get
        Set(ByVal Value As Integer)
            m_SId = Value
        End Set
    End Property

    Public Property SCode() As String
        Get
            Return txtSCode.Text
        End Get
        Set(ByVal Value As String)
            txtSCode.Text = Value
        End Set
    End Property

    Public Property SName() As String
        Get
            Return txtSName.Text
        End Get
        Set(ByVal Value As String)
            txtSName.Text = Value
        End Set
    End Property

    Public Property PchCodeId() As Integer
        Get
            Return m_PchCodeId
        End Get
        Set(ByVal Value As Integer)
            m_PchCodeId = Value
        End Set
    End Property

    Public Property PchCode() As String
        Get
            Return txtPchCode.Text
        End Get
        Set(ByVal Value As String)
            txtPchCode.Text = Value
        End Set
    End Property

    Public Property CurrId() As Integer
        Get
            Return m_CurrId
        End Get
        Set(ByVal Value As Integer)
            m_CurrId = Value
        End Set
    End Property

    Public Property CurrCode() As String
        Get
            Return txtCurrCode.Text
        End Get
        Set(ByVal Value As String)
            txtCurrCode.Text = Value
        End Set
    End Property

    Public Property CurrRate() As String
        Get
            Return ntbPOCurrRate.Text
        End Get
        Set(ByVal Value As String)
            ntbPOCurrRate.Text = Value
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

    Public Property SKUCode() As String
        Get
            Return txtSKUCode.Text
        End Get
        Set(ByVal Value As String)
            txtSKUCode.Text = Value
        End Set
    End Property

    Public Property SKUName() As String
        Get
            Return txtPODtlDesc.Text
        End Get
        Set(ByVal Value As String)
            txtPODtlDesc.Text = Value
        End Set
    End Property

    Public Property SKUUoM() As String
        Get
            Return txtSKUUoM.Text
        End Get
        Set(ByVal Value As String)
            txtSKUUoM.Text = Value
        End Set
    End Property

    Public Property SKUPackageCheck() As Boolean
        Get
            Return isSKUPackage
        End Get
        Set(ByVal Value As Boolean)
            isSKUPackage = Value
        End Set
    End Property

    Public Property PaymentTerms() As Integer
        Get
            Return ntbPaymentTerms.Text
        End Get
        Set(ByVal Value As Integer)
            ntbPaymentTerms.Text = Value
        End Set
    End Property

    Public Property PRequestId() As Integer
        Get
            Return m_PRequestDId
        End Get
        Set(ByVal Value As Integer)
            m_PRequestDId = Value
        End Set
    End Property

    Public Property PRequestNo() As String
        Get
            Return txtPRequestNo.Text
        End Get
        Set(ByVal Value As String)
            txtPRequestNo.Text = Value
        End Set
    End Property

    Public Property POQty() As Integer
        Get
            Return ntbPOQty.Text
        End Get
        Set(ByVal Value As Integer)
            ntbPOQty.Text = Value
        End Set
    End Property

    Public Property UnitPrice() As String
        Get
            Return ntbPOPrice.Text
        End Get
        Set(ByVal Value As String)
            ntbPOPrice.Text = Value
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
            Return txtLocationCode.Text
        End Get
        Set(ByVal Value As String)
            txtLocationCode.Text = Value
        End Set
    End Property

    Private Sub btnSKU_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSKU.Click
        If m_SId = 0 Or m_PchCodeId = 0 Then
            MsgBox("Purchase Code & Supplier information are primary fields that should be entered. Please enter those fields before you save it.", vbCritical + vbOKOnly, Me.Text)
            txtSCode.Focus()
            Exit Sub
        End If
        Select Case cmbPODtlType.Items(cmbPODtlType.SelectedIndex).ItemData
            Case "S"
                Dim NewFormDialog As New fdlSKUPO
                NewFormDialog.FrmCallerId = Me.Name
                NewFormDialog.ShowDialog()
            Case "E"
                Dim NewFormDialog As New fdlExpense
                NewFormDialog.FrmCallerId = Me.Name
                NewFormDialog.ShowDialog()
        End Select
    End Sub

    Sub clear_obj()
        m_POId = 0
        m_PchCodeId = 0
        m_SId = 0
        m_CurrId = 0
        m_POCurrRateBefore = 0
        m_PONo = ""
        txtPPitchingNo.Text = ""
        dtpPPitchingDate.Value = FormatDateTime(Now, DateFormat.ShortDate)
        txtSCode.Text = ""
        txtPchCode.Text = ""
        txtSName.Text = ""
        txtCurrCode.Text = ""
        ntbPOCurrRate.Text = FormatNumber("1")
        txtShipVia.Text = ""
        txtRefNo.Text = ""
        txtPORemarks.Text = ""
        ntbPaymentTerms.Text = 0
        cmbPOType.SelectedIndex = 0
        cmbPaymentMethod.SelectedIndex = 0
        m_POStatus = m_POStatusArr(0, 0)
        txtPitchingStatus.Text = m_POStatusArr(0, 1)
        txtPOSubtotal.Text = FormatNumber("0")
        txtPOTax.Text = FormatNumber("0")
        txtPOTotal.Text = FormatNumber("0")
        txtLocalPOSubTotal.Text = FormatNumber("0")
        txtLocalPOTax.Text = FormatNumber("0")
        txtLocalPOTotal.Text = FormatNumber("0")
        txtRevise.Text = 0
        txtPrinted.Text = 0
        isGetNum = True

        ''Add item cmbCurrId
        'Dim prm1 As SqlParameter
        'Dim myReader As SqlDataReader
        'cmd = New SqlCommand("usp_mt_curr_SEL", cn)
        'cmd.CommandType = CommandType.StoredProcedure

        'prm1 = cmd.Parameters.Add("@base_curr", SqlDbType.Bit)
        'prm1.Value = 1

        'cn.Open()
        'myReader = cmd.ExecuteReader
        'While myReader.Read
        '    m_CurrId = myReader.GetInt32(0)
        '    txtCurrCode.Text = myReader.GetString(1)
        '    ntbPOCurrRate.Text = FormatNumber(myReader.Item(4))
        'End While
        'myReader.Close()
        'cn.Close()
    End Sub

    Sub clear_objD()
        m_PODId = 0
        m_PRequestDId = 0
        m_LocationId = 0
        m_POQtyBefore = 0
        m_SumPReceiveQty = 0
        cmbPODtlType.SelectedIndex = 0
        txtPRequestNo.Text = ""
        txtSKUCode.Text = ""
        txtPODtlDesc.Text = ""
        ntbPOQty.Text = FormatNumber(1)
        txtSKUUoM.Text = ""
        ntbPOPrice.Text = FormatNumber(0, Dec)
        ntbPOTaxPercent.Text = FormatNumber(m_POTaxPercent, 0)
        txtPOTaxAmt.Text = FormatNumber(0)
        txtPOGrossAmt.Text = FormatNumber(0)
        txtPONetAmt.Text = FormatNumber(0)
        txtLocationCode.Text = ""
    End Sub

    Sub lock_obj(ByVal isLock As Boolean)
        dtpPPitchingDate.Enabled = Not isLock
        dtpDeliveryDate.Enabled = Not isLock
        txtShipVia.ReadOnly = isLock
        txtRefNo.ReadOnly = isLock
        ntbPaymentTerms.ReadOnly = isLock
        ntbPOCurrRate.ReadOnly = isLock
        txtPORemarks.ReadOnly = isLock
        cmbPaymentMethod.Enabled = Not isLock
        cmbPOType.Enabled = Not isLock
        btnSupplier.Enabled = Not isLock
        btnPchCode.Enabled = Not isLock

        btnAdd.Enabled = isLock
        btnEdit.Enabled = False
        btnSubmitApproval.Visible = False
        btnApprove.Visible = False
        btnReject.Visible = False
        btnConvertToPO.Visible = False

        Select Case m_FrmCallerId
            Case "frmPPitchingList"
                'btnVoid.Visible = True
            Case "frmPPitchingApprovalList"
                'btnVoid.Visible = False
                btnApprove.Visible = True
                btnReject.Visible = True
                btnAdd.Enabled = False
        End Select

        'If m_POStatus = "A" And isClosed = False Then btnCloseRequest.Enabled = isLock Else btnCloseRequest.Enabled = False
        Select Case m_POStatus
            Case "D" 'Draft
                btnEdit.Enabled = isLock
                btnSubmitApproval.Visible = True
            Case "W" 'Waiting for Approval
                If m_FrmCallerId = "frmPPitchingApprovalList" Then btnEdit.Enabled = isLock
            Case "A" 'Approved
                If m_PONo = "" Then
                    btnConvertToPO.Visible = True
                    btnConvertToPO.Enabled = isLock
                End If
            Case "R" 'Revised
                btnEdit.Enabled = isLock
                btnSubmitApproval.Visible = True
            Case "V" 'Void
        End Select

        'If m_POStatus = "FR" Or m_POStatus = "I" Or m_POStatus = "P" Then btnEdit.Enabled = False Else btnEdit.Enabled = isLock

        'btnAdd.Enabled = isLock
        btnSave.Enabled = Not isLock
        btnCancel.Enabled = Not isLock
        btnPrint.Enabled = isLock
        btnPreview.Enabled = isLock

        'If txtCurrCode.Text = "IDR" Then
        '    ntbPOCurrRate.ReadOnly = True
        'Else
        '    ntbPOCurrRate.ReadOnly = False
        'End If

        If m_POId = 0 Then
            txtPPitchingNo.ReadOnly = False
            btnDelete.Enabled = isLock
            'btnSubmitApproval.Enabled = isLock
            btnReject.Enabled = isLock
            btnApprove.Enabled = isLock
        Else
            txtPPitchingNo.ReadOnly = True
            'If p_UserLevel = 1 Then btnDelete.Enabled = Not isLock Else btnDelete.Enabled = False
            'If canDelete(p_UserLevel, Me.Name + "List") = True Then
            btnSubmitApproval.Enabled = isLock
            btnReject.Enabled = isLock
            btnApprove.Enabled = isLock
            If isAllowDelete = True Then btnDelete.Enabled = Not isLock Else btnDelete.Enabled = False
        End If
    End Sub

    Sub lock_objD(ByVal isLock As Boolean)
        cmbPODtlType.Enabled = Not isLock
        txtPODtlDesc.ReadOnly = isLock
        ntbPOQty.ReadOnly = isLock
        ntbPOPrice.ReadOnly = isLock
        ntbPOTaxPercent.ReadOnly = isLock

        btnPRequest.Enabled = Not isLock
        btnSKU.Enabled = Not isLock
        btnLocation.Enabled = Not isLock
        btnSaveD.Enabled = Not isLock
        btnDeleteD.Enabled = Not isLock
        btnAddD.Enabled = Not isLock
    End Sub

    Sub clear_lvw()
        With ListView1
            .Clear()
            .View = View.Details
            .Columns.Add("po_id", 0)
            .Columns.Add("po_dtl_type", 0)
            .Columns.Add("Line Type", 90)
            .Columns.Add("prequestDId", 0)
            .Columns.Add("Purchase Request No.", 90)
            .Columns.Add("sku_id", 0)
            .Columns.Add("Code", 60)
            .Columns.Add("Line Description", 250)
            .Columns.Add("locationId", 0)
            .Columns.Add("Location", 90)
            .Columns.Add("Qty", 60, HorizontalAlignment.Right)
            .Columns.Add("UoM", 60)
            .Columns.Add("Unit Price", 90, HorizontalAlignment.Right)
            .Columns.Add("Gross Amount", 120, HorizontalAlignment.Right)
            .Columns.Add("Tax %", 60, HorizontalAlignment.Right)
            .Columns.Add("Tax Amount", 90, HorizontalAlignment.Right)
            .Columns.Add("Net Amount", 120, HorizontalAlignment.Right)
            .Columns.Add("sum_preceive_qty", 0, HorizontalAlignment.Right)

            '.AutoResizeColumn(2, ColumnHeaderAutoResizeStyle.HeaderSize)
            '.AutoResizeColumn(4, ColumnHeaderAutoResizeStyle.HeaderSize)
            '.AutoResizeColumn(7, ColumnHeaderAutoResizeStyle.ColumnContent)
        End With

        If m_POId <> 0 Then
            cmd = New SqlCommand("usp_tr_po_dtl_SEL", cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm1 As SqlParameter = cmd.Parameters.Add("@po_dtl_id", SqlDbType.Int)
            prm1.Value = 0
            Dim prm2 As SqlParameter = cmd.Parameters.Add("@po_id", SqlDbType.Int)
            prm2.Value = m_POId

            If cn.State = Data.ConnectionState.Closed Then cn.Open()

            Dim myReader As SqlDataReader = cmd.ExecuteReader()

            'Call FillList(myReader, Me.ListView1, 12, 1)
            Dim lvItem As ListViewItem
            Dim i As Integer, intCurrRow As Integer

            While myReader.Read
                lvItem = New ListViewItem(CStr(myReader.Item(1))) 'po_id
                lvItem.Tag = CStr(myReader.Item(0)) & "*~~~~~*" & intCurrRow 'ID
                'lvItem.Tag = "v" & CStr(DR.Item(0))
                For i = 2 To 5 'po_dtl_type, line_type, prequest_dtl_id, prequest_no
                    If myReader.Item(i) Is System.DBNull.Value Then
                        lvItem.SubItems.Add("")
                    Else
                        lvItem.SubItems.Add(myReader.Item(i))
                    End If
                Next
                Select Case myReader.GetString(2) 'sku_id, sku_code
                    Case "S"
                        lvItem.SubItems.Add(myReader.GetInt32(6))
                        lvItem.SubItems.Add(myReader.GetString(7))
                    Case "E"
                        lvItem.SubItems.Add(myReader.GetInt32(18))
                        lvItem.SubItems.Add(myReader.GetString(19))
                    Case Else
                        lvItem.SubItems.Add("0")
                        lvItem.SubItems.Add("")
                End Select
                lvItem.SubItems.Add(myReader.GetString(8)) 'po_dtl_desc
                For i = 9 To 10 'location_id, location
                    If myReader.Item(i) Is System.DBNull.Value Then
                        lvItem.SubItems.Add("")
                    Else
                        lvItem.SubItems.Add(myReader.Item(i))
                    End If
                Next
                lvItem.SubItems.Add(myReader.GetValue(11)) 'po_qty
                If myReader.Item(12) Is System.DBNull.Value Then 'sku_uom
                    lvItem.SubItems.Add("")
                Else
                    lvItem.SubItems.Add(myReader.Item(12))
                End If
                lvItem.SubItems.Add(FormatNumber(myReader.Item(13), Dec))
                For i = 14 To 17 'po_price, po_dtl_gross, po_tax, po_dtl_tax, po_dtl_net
                    If i = 15 Then
                        lvItem.SubItems.Add(FormatNumber(myReader.Item(i), 0))
                    Else
                        lvItem.SubItems.Add(FormatNumber(myReader.Item(i)))
                    End If
                Next
                lvItem.SubItems.Add(myReader.GetValue(21)) 'sum_preceive_qty
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

    Private Sub bindGrid()

        'Sets the appropriate properties on the grid columns to accept data binding.
        setColumnProperties()

        poDetail_DataAdapter = New SqlDataAdapter()
        poDetail_DataTable = New DataTable()

        'Dim conxn As New SqlConnection(getConnectionString())

        'Add commands to the DataAdapter. These should be stored procedures in production.

        'The select command is responsible for retrieving the data only. This one has no parameters because we
        'want all rows from the database.
        poDetail_DataAdapter.SelectCommand = New SqlCommand("exec usp_tr_po_dtl_SEL @po_id", cn)
        'poDetail_DataAdapter.SelectCommand = New SqlCommand("SELECT [Id], [FruitName], [FruitColor], [FruitGrowsOn], [FruitIsYummy] FROM [Fruit];", cn)

        Dim selParamPOId As SqlParameter = New SqlParameter("@po_id", SqlDbType.Int)
        'selParamPOId.SourceColumn = "po_id"
        selParamPOId.Value = m_POId
        poDetail_DataAdapter.SelectCommand.Parameters.Add(selParamPOId)

        poDetail_DataAdapter.Fill(poDetail_DataTable)

        ''The INSERT command is necessary if you want to allow inserting of rows
        'poDetail_DataAdapter.InsertCommand = New SqlCommand("INSERT INTO [Fruit] ([FruitName], [FruitColor], [FruitGrowsOn], [FruitIsYummy]) VALUES(@fruitname,  @fruitcolor,@fruitgrowson,@fruitisyummy)", cn)

        'Dim insParamFruitName As SqlParameter = New SqlParameter("@fruitname", SqlDbType.NVarChar)
        'insParamFruitName.SourceColumn = "FruitName"
        'poDetail_DataAdapter.InsertCommand.Parameters.Add(insParamFruitName)

        'Dim insParamFruitColor As SqlParameter = New SqlParameter("@fruitcolor", SqlDbType.NVarChar)
        'insParamFruitColor.SourceColumn = "FruitColor"
        'fruitDataAdapter.InsertCommand.Parameters.Add(insParamFruitColor)

        'Dim insParamFruitGrowsOn As SqlParameter = New SqlParameter("@fruitgrowson", SqlDbType.Int)
        'insParamFruitGrowsOn.SourceColumn = "FruitGrowsOn"
        'fruitDataAdapter.InsertCommand.Parameters.Add(insParamFruitGrowsOn)

        'Dim insParamFruitIsYummy As SqlParameter = New SqlParameter("@fruitisyummy", SqlDbType.Bit)
        'insParamFruitIsYummy.SourceColumn = "FruitIsYummy"
        'fruitDataAdapter.InsertCommand.Parameters.Add(insParamFruitIsYummy)

        ''No need for an Id parameter because it is defined as IDENTITY so it will create itself in the database

        ''The UPDATE command is necessary if you want to update rows
        'fruitDataAdapter.UpdateCommand = _
        '    New SqlCommand("UPDATE [Fruit] SET [FruitName] = @fruitname, [FruitColor] = @fruitcolor, [FruitGrowsOn] = @fruitgrowson, [FruitIsYummy] = @fruitisyummy WHERE [Id] = @fruitid;", conxn)

        'Dim updParamFruitName As SqlParameter = New SqlParameter("@fruitname", SqlDbType.NVarChar)
        'updParamFruitName.SourceColumn = "FruitName"
        'fruitDataAdapter.UpdateCommand.Parameters.Add(updParamFruitName)

        'Dim updParamFruitColor As SqlParameter = New SqlParameter("@fruitcolor", SqlDbType.NVarChar)
        'updParamFruitColor.SourceColumn = "FruitColor"
        'fruitDataAdapter.UpdateCommand.Parameters.Add(updParamFruitColor)

        'Dim updParamFruitGrowsOn As SqlParameter = New SqlParameter("@fruitgrowson", SqlDbType.Int)
        'updParamFruitGrowsOn.SourceColumn = "FruitGrowsOn"
        'fruitDataAdapter.UpdateCommand.Parameters.Add(updParamFruitGrowsOn)

        'Dim updParamFruitIsYummy As SqlParameter = New SqlParameter("@fruitisyummy", SqlDbType.Bit)
        'updParamFruitIsYummy.SourceColumn = "FruitIsYummy"
        'fruitDataAdapter.UpdateCommand.Parameters.Add(updParamFruitIsYummy)

        'Dim updParamFruitId As SqlParameter = New SqlParameter("@fruitid", SqlDbType.Int)
        'updParamFruitId.SourceColumn = "Id"
        'fruitDataAdapter.UpdateCommand.Parameters.Add(updParamFruitId)

        ''DELECT Command is necessary if you want to enable delete of rows
        'fruitDataAdapter.DeleteCommand = New SqlCommand("DELETE FROM [Fruit] WHERE [Id] = @fruitid", conxn)

        'Dim delParamFruitId As SqlParameter = New SqlParameter("@fruitid", SqlDbType.Int)
        'delParamFruitId.SourceColumn = "Id"
        'fruitDataAdapter.DeleteCommand.Parameters.Add(delParamFruitId)

        'Finally, set the datasource of the grid
        DataGridView1.DataSource = poDetail_DataTable

    End Sub

    Private Sub setColumnProperties()

        Dim fruitNameColumn As DataGridViewTextBoxColumn = DirectCast(DataGridView1.Columns("po_dtl_id"), DataGridViewTextBoxColumn)
        fruitNameColumn.DataPropertyName = "po_dtl_id"

        'Dim fruitColorColumn As DataGridViewTextBoxColumn = DirectCast(FruitGridView.Columns("colFruitColor"), DataGridViewTextBoxColumn)
        'fruitColorColumn.DataPropertyName = "FruitColor"

        'Dim fruitGrowsOnColumn As DataGridViewComboBoxColumn = DirectCast(FruitGridView.Columns("colFruitGrowsOn"), DataGridViewComboBoxColumn)
        'fruitGrowsOnColumn.DataPropertyName = "FruitGrowsOn"

        'Dim fruitIsYummyColumn As DataGridViewCheckBoxColumn = DirectCast(FruitGridView.Columns("colFruitIsYummy"), DataGridViewCheckBoxColumn)
        'fruitIsYummyColumn.DataPropertyName = "FruitIsYummy"

    End Sub

    Sub view_record()
        cmd = New SqlCommand("usp_tr_po_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm1 As SqlParameter = cmd.Parameters.Add("@po_id", SqlDbType.Int)
        prm1.Value = m_POId
        Dim prm2 As SqlParameter = cmd.Parameters.Add("@trx_type", SqlDbType.NVarChar)
        prm2.Value = "ppitching"

        cn.Open()

        Dim myReader As SqlDataReader = cmd.ExecuteReader()

        While myReader.Read
            m_PONo = IIf(myReader.Item(1) Is DBNull.Value, "", myReader.Item(1))
            txtPPitchingNo.Text = myReader.GetString(30)
            dtpPPitchingDate.Value = myReader.GetDateTime(31)
            m_SId = myReader.GetInt32(3)
            txtSCode.Text = myReader.GetString(4)
            txtSName.Text = myReader.GetString(5)
            m_POType = myReader.GetString(6)
            m_POStatus = myReader.GetString(32)
            dtpDeliveryDate.Value = myReader.GetDateTime(9)
            If Not myReader.IsDBNull(myReader.GetOrdinal("ship_via")) Then
                txtShipVia.Text = myReader.GetString(myReader.GetOrdinal("ship_via"))
            Else
                txtShipVia.Text = ""
            End If
            If Not myReader.IsDBNull(myReader.GetOrdinal("ref_no")) Then
                txtRefNo.Text = myReader.GetString(myReader.GetOrdinal("ref_no"))
            Else
                txtRefNo.Text = ""
            End If
            ntbPaymentTerms.Text = myReader.GetInt32(12)
            m_PaymentMethod = myReader.GetString(13)
            If Not myReader.IsDBNull(myReader.GetOrdinal("po_remarks")) Then
                txtPORemarks.Text = myReader.GetString(myReader.GetOrdinal("po_remarks"))
            Else
                txtPORemarks.Text = ""
            End If
            m_PchCodeId = myReader.GetInt32(15)
            txtPchCode.Text = myReader.GetString(16)
            m_CurrId = myReader.GetInt32(17)
            txtCurrCode.Text = myReader.GetString(18)
            ntbPOCurrRate.Text = FormatNumber(myReader.GetValue(19))
            m_POCurrRateBefore = myReader.GetValue(19)
            txtPOSubtotal.Text = FormatNumber(myReader.GetValue(20))
            txtPOTax.Text = FormatNumber(myReader.GetValue(21))
            txtPOTotal.Text = FormatNumber(myReader.GetValue(22))
            txtLocalPOSubTotal.Text = FormatNumber(myReader.GetValue(25))
            txtLocalPOTax.Text = FormatNumber(myReader.GetValue(26))
            txtLocalPOTotal.Text = FormatNumber(myReader.GetValue(27))
            txtRevise.Text = myReader.GetValue(28)
            txtPrinted.Text = myReader.GetValue(29)

        End While

        myReader.Close()
        cn.Close()


        Dim mList As clsMyListStr
        Dim i As Integer
        For i = 1 To cmbPOType.Items.Count
            mList = cmbPOType.Items(i - 1)
            If m_POType = mList.ItemData Then
                cmbPOType.SelectedIndex = i - 1
                Exit For
            End If
        Next

        For i = 0 To m_POStatusArr.GetUpperBound(0)
            If m_POStatus = m_POStatusArr(i, 0) Then
                txtPitchingStatus.Text = m_POStatusArr(i, 1)
                Exit For
            End If
        Next

        For i = 1 To cmbPaymentMethod.Items.Count
            mList = cmbPaymentMethod.Items(i - 1)
            If m_PaymentMethod = mList.ItemData Then
                cmbPaymentMethod.SelectedIndex = i - 1
                Exit For
            End If
        Next
    End Sub

    Sub refresh_total()
        cmd = New SqlCommand("usp_tr_po_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm1 As SqlParameter = cmd.Parameters.Add("@po_id", SqlDbType.Int)
        prm1.Value = m_POId
        Dim prm2 As SqlParameter = cmd.Parameters.Add("@trx_type", SqlDbType.NVarChar)
        prm2.Value = "ppitching"

        cn.Open()

        Dim myReader As SqlDataReader = cmd.ExecuteReader()

        While myReader.Read
            txtPOSubtotal.Text = FormatNumber(myReader.GetValue(20))
            txtPOTax.Text = FormatNumber(myReader.GetValue(21))
            txtPOTotal.Text = FormatNumber(myReader.GetValue(22))
            txtLocalPOSubTotal.Text = FormatNumber(myReader.GetValue(25))
            txtLocalPOTax.Text = FormatNumber(myReader.GetValue(26))
            txtLocalPOTotal.Text = FormatNumber(myReader.GetValue(27))
        End While

        myReader.Close()
        cn.Close()
    End Sub

    Sub refresh_totalD()
        txtPOGrossAmt.Text = FormatNumber((ntbPOQty.Text) * CDbl(ntbPOPrice.Text))
        txtPOTaxAmt.Text = FormatNumber((ntbPOQty.Text) * CDbl(ntbPOPrice.Text) * CDbl(ntbPOTaxPercent.Text) / 100)
        txtPONetAmt.Text = FormatNumber(CDbl(txtPOGrossAmt.Text) + CDbl(txtPOTaxAmt.Text))
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        m_POId = 0
        clear_obj()
        clear_objD()
        clear_lvw()
        lock_obj(False)
        lock_objD(False)
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If m_POId = 0 Then
            Me.Close()
        Else
            lock_obj(True)
            lock_objD(True)
            clear_objD()
            m_PODId = 0
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            If m_SId = 0 Or m_PchCodeId = 0 Then
                MsgBox("Purchase Code, Supplier Code and Supplier Name are primary fields that should be entered. Please enter those fields before you save it.", vbCritical + vbOKOnly, Me.Text)
                txtSCode.Focus()
                Exit Sub
            End If

            If CDbl(txtPOTotal.Text) = 0 Then
                MsgBox("Warning,Purchase Order total is 0 !", vbInformation, Me.Text)
            End If

            'If m_POId = 0 Then
            '    If txtPPitchingNo.Text = "" Then
            '        txtPPitchingNo.Text = GetSysNumber("ppit", Now.Date)
            '        isGetNum = True
            '    Else
            '        isGetNum = False
            '    End If
            'End If

            'cmd = New SqlCommand(IIf(m_POId = 0, "usp_tr_po_INS", "usp_tr_po_UPD"), cn)
            'cmd.CommandType = CommandType.StoredProcedure

            'Dim prm1 As SqlParameter = cmd.Parameters.Add("@ppitching_no", SqlDbType.NVarChar, 50)
            'prm1.Value = txtPPitchingNo.Text
            'Dim prm2 As SqlParameter = cmd.Parameters.Add("@ppitching_date", SqlDbType.SmallDateTime)
            'prm2.Value = dtpPPitchingDate.Value.Date
            'Dim prm3 As SqlParameter = cmd.Parameters.Add("@s_id", SqlDbType.Int)
            'prm3.Value = m_SId
            'Dim prm11 As SqlParameter = cmd.Parameters.Add("@curr_id", SqlDbType.Int)
            'prm11.Value = m_CurrId
            'Dim prm12 As SqlParameter = cmd.Parameters.Add("@po_curr_rate", SqlDbType.Money)
            'prm12.Value = FormatNumber(ntbPOCurrRate.Text)
            'Dim prm4 As SqlParameter = cmd.Parameters.Add("@po_type", SqlDbType.NVarChar, 50)
            'prm4.Value = cmbPOType.Items(cmbPOType.SelectedIndex).ItemData
            'Dim prm13 As SqlParameter = cmd.Parameters.Add("@pch_code_id", SqlDbType.Int)
            'prm13.Value = m_PchCodeId
            'Dim prm5 As SqlParameter = cmd.Parameters.Add("@delivery_date", SqlDbType.SmallDateTime)
            'prm5.Value = dtpDeliveryDate.Value.Date
            'Dim prm6 As SqlParameter = cmd.Parameters.Add("@ship_via", SqlDbType.NVarChar, 50)
            'prm6.Value = IIf(txtShipVia.Text = "", DBNull.Value, txtShipVia.Text)
            'Dim prm7 As SqlParameter = cmd.Parameters.Add("@ref_no", SqlDbType.NVarChar, 50)
            'prm7.Value = IIf(txtRefNo.Text = "", DBNull.Value, txtRefNo.Text)
            'Dim prm8 As SqlParameter = cmd.Parameters.Add("@payment_terms", SqlDbType.Int, 50)
            'prm8.Value = IIf(ntbPaymentTerms.Text = "", 0, ntbPaymentTerms.Text)
            'Dim prm9 As SqlParameter = cmd.Parameters.Add("@payment_method", SqlDbType.NVarChar, 50)
            'prm9.Value = cmbPaymentMethod.Items(cmbPaymentMethod.SelectedIndex).ItemData
            'Dim prm10 As SqlParameter = cmd.Parameters.Add("@po_remarks", SqlDbType.NVarChar)
            'prm10.Value = IIf(txtPORemarks.Text = "", DBNull.Value, txtPORemarks.Text)

            'If isConvertToPO = True Then
            '    m_PONo = GetSysNumber("pord", Now.Date)
            '    Dim prm21 As SqlParameter = cmd.Parameters.Add("@po_no", SqlDbType.NVarChar, 50)
            '    prm21.Value = m_PONo
            '    Dim prm22 As SqlParameter = cmd.Parameters.Add("@po_date", SqlDbType.SmallDateTime)
            '    prm22.Value = Now.Date
            '    Dim prm23 As SqlParameter = cmd.Parameters.Add("@po_status", SqlDbType.NVarChar, 50)
            '    prm23.Value = "O"
            'End If

            'Dim prm15 As SqlParameter = cmd.Parameters.Add("@user_name", SqlDbType.NVarChar, 50)
            'prm15.Value = My.Settings.UserName
            'Dim prm16 As SqlParameter = cmd.Parameters.Add("@po_id", SqlDbType.Int)

            'If m_POId = 0 Then
            '    prm16.Direction = ParameterDirection.Output

            '    cn.Open()
            '    cmd.ExecuteReader()
            '    m_POId = prm16.Value
            '    'MessageBox.Show(m_POId)
            '    cn.Close()
            '    If isGetNum = True Then UpdSysNumber("ppit")
            'Else
            '    prm16.Value = m_POId
            '    If CInt(txtPrinted.Text) > 0 Then txtRevise.Text = CInt(txtRevise.Text) + 1 : txtPrinted.Text = "0"
            '    Dim prm17 As SqlParameter = cmd.Parameters.Add("@revise", SqlDbType.SmallInt)
            '    prm17.Value = txtRevise.Text
            '    Dim prm14 As SqlParameter = cmd.Parameters.Add("@printed", SqlDbType.SmallInt)
            '    prm14.Value = txtPrinted.Text

            '    cn.Open()
            '    cmd.ExecuteReader()
            '    cn.Close()
            '    'clear_lvw()
            '    If CDbl(ntbPOCurrRate.Text) <> m_POCurrRateBefore Then refresh_total()
            'End If
            SavePOHeader()
            lock_obj(True)
            lock_objD(True)
            m_POCurrRateBefore = CDbl(ntbPOCurrRate.Text)

        Catch ex As Exception
            'If Err.Number = 5 Then
            '    MsgBox("This primary code has been used (and deleted) previously. Please create with another code", vbExclamation + vbOKOnly, Me.Text)
            'Else
            MsgBox(ex.Message)
            'End If
            If ConnectionState.Open = 1 Then cn.Close()
        End Try
        'autoRefresh()

        For i As Integer = 0 To DataGridView1.RowCount

        Next
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        clear_objD()
        lock_obj(False)
        lock_objD(False)
        'If m_POStatus = "FR" Then
        '    btnSave.Enabled = False
        '    btnDelete.Enabled = False
        '    lock_objD(True)
        'Else
        If m_POStatus = "PR" Then
            lock_objD(True)
            ntbPOQty.ReadOnly = False
            btnSaveD.Enabled = True
        End If
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If m_POStatus = "O" Then
            If MsgBox("Are you sure you want to delete this record?", vbYesNo + vbCritical, Me.Text) = vbYes Then
                cmd = New SqlCommand("usp_tr_po_DEL", cn)
                cmd.CommandType = CommandType.StoredProcedure

                Dim prm1 As SqlParameter = cmd.Parameters.Add("@po_id", SqlDbType.Int)
                prm1.Value = m_POId
                Dim prm2 As SqlParameter = cmd.Parameters.Add("@user_name", SqlDbType.NVarChar, 50)
                prm2.Value = My.Settings.UserName

                cn.Open()
                cmd.ExecuteReader()
                cn.Close()
                btnAdd_Click(sender, e)
            End If
        Else
            MsgBox("You can't delete this transaction record", vbCritical, Me.Text)
        End If
        autoRefresh()
    End Sub

    Private Sub btnSaveD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveD.Click
        Try
            If m_POId = 0 Then
                If m_SId = 0 Or m_PchCodeId = 0 Then
                    MsgBox("Purchase Code, Supplier Code and Supplier Name are primary fields that should be entered. Please enter those fields before you save it.", vbCritical + vbOKOnly, Me.Text)
                    txtSCode.Focus()
                    Exit Sub
                End If
                SavePOHeader()
                txtPPitchingNo.ReadOnly = True
                m_POCurrRateBefore = CDbl(ntbPOCurrRate.Text)
            End If

            'If m_POStatus = "PR" And m_PODId = 0 Then
            '    MsgBox("For partially received Purchase Order you can only edit the quantity and not add a new line.", vbCritical + vbOKOnly, Me.Text)
            '    clear_objD()
            '    Exit Sub
            'End If

            If txtPODtlDesc.Text = "" Then
                MsgBox("Line Description are primary fields that should be entered. Please enter those fields before you save it.", vbCritical + vbOKOnly, Me.Text)
                txtPODtlDesc.Focus()
                Exit Sub
            End If

            If cmbPODtlType.Items(cmbPODtlType.SelectedIndex).ItemData = "S" And (m_SKUId = 0 Or m_LocationId = 0) Then
                MsgBox("Stock and Location are primary fields that should be entered. Please select before you save it.", vbCritical + vbOKOnly, Me.Text)
                txtPODtlDesc.Focus()
                Exit Sub
            End If

            cmd = New SqlCommand(IIf(m_PODId = 0, "usp_tr_po_dtl_INS", "usp_tr_po_dtl_UPD"), cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm17 As SqlParameter = cmd.Parameters.Add("@po_id", SqlDbType.Int)
            prm17.Value = m_POId
            Dim prm18 As SqlParameter = cmd.Parameters.Add("@po_dtl_type", SqlDbType.NVarChar, 50)
            prm18.Value = cmbPODtlType.Items(cmbPODtlType.SelectedIndex).ItemData
            Dim prm25 As SqlParameter = cmd.Parameters.Add("@prequest_dtl_id", SqlDbType.Int)
            prm25.Value = m_PRequestDId
            Dim prm19 As SqlParameter = cmd.Parameters.Add("@sku_id", SqlDbType.Int)
            prm19.Value = IIf(cmbPODtlType.Items(cmbPODtlType.SelectedIndex).ItemData = "S", m_SKUId, 0)
            Dim prm20 As SqlParameter = cmd.Parameters.Add("@po_dtl_desc", SqlDbType.NVarChar, 255)
            prm20.Value = IIf(txtPODtlDesc.Text = "", DBNull.Value, txtPODtlDesc.Text)
            Dim prm21 As SqlParameter = cmd.Parameters.Add("@po_qty", SqlDbType.Decimal)
            prm21.Value = IIf(ntbPOQty.Text = "", 0, CDbl(ntbPOQty.Text))
            Dim prm22 As SqlParameter = cmd.Parameters.Add("@po_price", SqlDbType.Decimal)
            prm22.Value = FormatNumber(ntbPOPrice.Text, Dec)
            Dim prm23 As SqlParameter = cmd.Parameters.Add("@tax_percent", SqlDbType.Decimal)
            prm23.Value = ntbPOTaxPercent.Text / 100
            Dim prm26 As SqlParameter = cmd.Parameters.Add("@location_id", SqlDbType.Int)
            prm26.Value = m_LocationId
            Dim prm27 As SqlParameter = cmd.Parameters.Add("@expense_id", SqlDbType.Int)
            prm27.Value = IIf(cmbPODtlType.Items(cmbPODtlType.SelectedIndex).ItemData = "E", m_SKUId, 0)

            If m_PODId <> 0 Then
                Dim prm24 As SqlParameter = cmd.Parameters.Add("@po_dtl_id", SqlDbType.Int)
                prm24.Value = m_PODId
            End If
            cn.Open()
            cmd.ExecuteReader()
            cn.Close()

            clear_lvw()
            clear_objD()
            refresh_total()

        Catch ex As Exception
            'If Err.Number = 5 Then
            '    MsgBox("This primary code has been used (and deleted) previously. Please create with another code", vbExclamation + vbOKOnly, Me.Text)
            'Else
            MsgBox(ex.Message)
            'End If
            If ConnectionState.Open = 1 Then cn.Close()
        End Try
    End Sub

    Sub SavePOHeader()
        Try
            'If txtPPitchingNo.Text = "" Then
            '    txtPPitchingNo.Text = GetSysNumber("ppit", Now.Date)
            '    isGetNum = True
            'Else
            '    isGetNum = False
            'End If

            'cmd = New SqlCommand("usp_tr_po_INS", cn)
            'cmd.CommandType = CommandType.StoredProcedure

            'Dim prm1 As SqlParameter = cmd.Parameters.Add("@ppitching_no", SqlDbType.NVarChar, 50)
            'prm1.Value = txtPPitchingNo.Text
            'Dim prm2 As SqlParameter = cmd.Parameters.Add("@ppitching_date", SqlDbType.SmallDateTime)
            'prm2.Value = dtpPPitchingDate.Value.Date
            'Dim prm3 As SqlParameter = cmd.Parameters.Add("@s_id", SqlDbType.Int)
            'prm3.Value = m_SId
            'Dim prm11 As SqlParameter = cmd.Parameters.Add("@curr_id", SqlDbType.Int)
            'prm11.Value = m_CurrId
            'Dim prm12 As SqlParameter = cmd.Parameters.Add("@po_curr_rate", SqlDbType.Money)
            'prm12.Value = FormatNumber(ntbPOCurrRate.Text)
            'Dim prm4 As SqlParameter = cmd.Parameters.Add("@po_type", SqlDbType.NVarChar, 50)
            'prm4.Value = cmbPOType.Items(cmbPOType.SelectedIndex).ItemData
            'Dim prm13 As SqlParameter = cmd.Parameters.Add("@pch_code_id", SqlDbType.Int)
            'prm13.Value = m_PchCodeId
            'Dim prm5 As SqlParameter = cmd.Parameters.Add("@delivery_date", SqlDbType.SmallDateTime)
            'prm5.Value = dtpDeliveryDate.Value.Date
            'Dim prm6 As SqlParameter = cmd.Parameters.Add("@ship_via", SqlDbType.NVarChar, 50)
            'prm6.Value = IIf(txtShipVia.Text = "", DBNull.Value, txtShipVia.Text)
            'Dim prm7 As SqlParameter = cmd.Parameters.Add("@ref_no", SqlDbType.NVarChar, 50)
            'prm7.Value = IIf(txtRefNo.Text = "", DBNull.Value, txtRefNo.Text)
            'Dim prm8 As SqlParameter = cmd.Parameters.Add("@payment_terms", SqlDbType.Int, 50)
            'prm8.Value = IIf(ntbPaymentTerms.Text = "", 0, ntbPaymentTerms.Text)
            'Dim prm9 As SqlParameter = cmd.Parameters.Add("@payment_method", SqlDbType.NVarChar, 50)
            'prm9.Value = cmbPaymentMethod.Items(cmbPaymentMethod.SelectedIndex).ItemData
            'Dim prm10 As SqlParameter = cmd.Parameters.Add("@po_remarks", SqlDbType.NVarChar)
            'prm10.Value = IIf(txtPORemarks.Text = "", DBNull.Value, txtPORemarks.Text)
            'Dim prm15 As SqlParameter = cmd.Parameters.Add("@user_name", SqlDbType.NVarChar, 50)
            'prm15.Value = My.Settings.UserName
            'Dim prm16 As SqlParameter = cmd.Parameters.Add("@po_id", SqlDbType.Int)
            'prm16.Direction = ParameterDirection.Output

            'cn.Open()
            'cmd.ExecuteReader()
            'm_POId = prm16.Value
            'cn.Close()
            'If isGetNum = True Then UpdSysNumber("ppit")

            If m_POId = 0 Then
                If txtPPitchingNo.Text = "" Then
                    txtPPitchingNo.Text = GetSysNumber("ppit", Now.Date)
                    isGetNum = True
                Else
                    isGetNum = False
                End If
            End If

            cmd = New SqlCommand(IIf(m_POId = 0, "usp_tr_po_INS", "usp_tr_po_UPD"), cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm1 As SqlParameter = cmd.Parameters.Add("@ppitching_no", SqlDbType.NVarChar, 50)
            prm1.Value = txtPPitchingNo.Text
            Dim prm2 As SqlParameter = cmd.Parameters.Add("@ppitching_date", SqlDbType.SmallDateTime)
            prm2.Value = dtpPPitchingDate.Value.Date
            Dim prm3 As SqlParameter = cmd.Parameters.Add("@s_id", SqlDbType.Int)
            prm3.Value = m_SId
            Dim prm11 As SqlParameter = cmd.Parameters.Add("@curr_id", SqlDbType.Int)
            prm11.Value = m_CurrId
            Dim prm12 As SqlParameter = cmd.Parameters.Add("@po_curr_rate", SqlDbType.Money)
            prm12.Value = FormatNumber(ntbPOCurrRate.Text)
            Dim prm4 As SqlParameter = cmd.Parameters.Add("@po_type", SqlDbType.NVarChar, 50)
            prm4.Value = cmbPOType.Items(cmbPOType.SelectedIndex).ItemData
            Dim prm13 As SqlParameter = cmd.Parameters.Add("@pch_code_id", SqlDbType.Int)
            prm13.Value = m_PchCodeId
            Dim prm5 As SqlParameter = cmd.Parameters.Add("@delivery_date", SqlDbType.SmallDateTime)
            prm5.Value = dtpDeliveryDate.Value.Date
            Dim prm6 As SqlParameter = cmd.Parameters.Add("@ship_via", SqlDbType.NVarChar, 50)
            prm6.Value = IIf(txtShipVia.Text = "", DBNull.Value, txtShipVia.Text)
            Dim prm7 As SqlParameter = cmd.Parameters.Add("@ref_no", SqlDbType.NVarChar, 50)
            prm7.Value = IIf(txtRefNo.Text = "", DBNull.Value, txtRefNo.Text)
            Dim prm8 As SqlParameter = cmd.Parameters.Add("@payment_terms", SqlDbType.Int, 50)
            prm8.Value = IIf(ntbPaymentTerms.Text = "", 0, ntbPaymentTerms.Text)
            Dim prm9 As SqlParameter = cmd.Parameters.Add("@payment_method", SqlDbType.NVarChar, 50)
            prm9.Value = cmbPaymentMethod.Items(cmbPaymentMethod.SelectedIndex).ItemData
            Dim prm10 As SqlParameter = cmd.Parameters.Add("@po_remarks", SqlDbType.NVarChar)
            prm10.Value = IIf(txtPORemarks.Text = "", DBNull.Value, txtPORemarks.Text)

            If isConvertToPO = True Then
                m_PONo = GetSysNumber("pord", Now.Date)
                Dim prm21 As SqlParameter = cmd.Parameters.Add("@po_no", SqlDbType.NVarChar, 50)
                prm21.Value = m_PONo
                Dim prm22 As SqlParameter = cmd.Parameters.Add("@po_date", SqlDbType.SmallDateTime)
                prm22.Value = Now.Date
                Dim prm23 As SqlParameter = cmd.Parameters.Add("@po_status", SqlDbType.NVarChar, 50)
                prm23.Value = "O"
                Dim prm24 As SqlParameter = cmd.Parameters.Add("@is_convert_to_po", SqlDbType.Bit)
                prm24.Value = 1
            End If

            Dim prm15 As SqlParameter = cmd.Parameters.Add("@user_name", SqlDbType.NVarChar, 50)
            prm15.Value = My.Settings.UserName
            Dim prm16 As SqlParameter = cmd.Parameters.Add("@po_id", SqlDbType.Int)

            If m_POId = 0 Then
                prm16.Direction = ParameterDirection.Output

                cn.Open()
                cmd.ExecuteReader()
                m_POId = prm16.Value
                'MessageBox.Show(m_POId)
                cn.Close()
                If isGetNum = True Then UpdSysNumber("ppit")
            Else
                prm16.Value = m_POId
                If CInt(txtPrinted.Text) > 0 Then txtRevise.Text = CInt(txtRevise.Text) + 1 : txtPrinted.Text = "0"
                Dim prm17 As SqlParameter = cmd.Parameters.Add("@revise", SqlDbType.SmallInt)
                prm17.Value = txtRevise.Text
                Dim prm14 As SqlParameter = cmd.Parameters.Add("@printed", SqlDbType.SmallInt)
                prm14.Value = txtPrinted.Text

                cn.Open()
                cmd.ExecuteReader()
                cn.Close()
                'clear_lvw()
                If CDbl(ntbPOCurrRate.Text) <> m_POCurrRateBefore Then refresh_total()
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

    Private Sub btnDeleteD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteD.Click
        If m_PODId = 0 Then Exit Sub
        If MsgBox("Are you sure you want to delete this record?", vbYesNo + vbCritical, Me.Text) = vbYes Then
            cmd = New SqlCommand("usp_tr_po_dtl_DEL", cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm1 As SqlParameter = cmd.Parameters.Add("@po_dtl_id", SqlDbType.Int, 50)
            prm1.Value = m_PODId

            cn.Open()
            cmd.ExecuteReader()
            cn.Close()

            clear_lvw()
            clear_objD()
            refresh_total()
        End If
    End Sub

    Private Sub ListView1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.Click
        With ListView1.SelectedItems.Item(0)
            m_PODId = LeftSplitUF(.Tag)
            m_PODtlType = .SubItems.Item(1).Text
            Dim mList As clsMyListStr
            Dim i As Integer
            For i = 1 To cmbPODtlType.Items.Count + 1
                mList = cmbPODtlType.Items(i - 1)
                If m_PODtlType = mList.ItemData Then
                    cmbPODtlType.SelectedIndex = i - 1
                    Exit For
                End If
            Next
            m_PRequestDId = IIf(.SubItems.Item(3).Text = "", 0, .SubItems.Item(3).Text)
            txtPRequestNo.Text = IIf(.SubItems.Item(4).Text = "", "", .SubItems.Item(4).Text)
            m_SKUId = .SubItems.Item(5).Text
            txtSKUCode.Text = .SubItems.Item(6).Text
            txtPODtlDesc.Text = .SubItems.Item(7).Text
            m_LocationId = IIf(.SubItems.Item(8).Text = "", 0, .SubItems.Item(8).Text)
            txtLocationCode.Text = .SubItems.Item(9).Text
            ntbPOQty.Text = .SubItems.Item(10).Text
            m_POQtyBefore = .SubItems.Item(10).Text
            txtSKUUoM.Text = .SubItems.Item(11).Text
            ntbPOPrice.Text = FormatNumber(.SubItems.Item(12).Text, Dec)
            txtPOGrossAmt.Text = FormatNumber(.SubItems.Item(13).Text)
            ntbPOTaxPercent.Text = .SubItems.Item(14).Text
            txtPOTaxAmt.Text = FormatNumber(.SubItems.Item(15).Text)
            txtPONetAmt.Text = FormatNumber(.SubItems.Item(16).Text)
            m_SumPReceiveQty = .SubItems.Item(17).Text
        End With
    End Sub

    Private Sub cmbPODtlType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPODtlType.SelectedIndexChanged
        If Not btnAddD.Enabled = True Then Exit Sub
        Select Case cmbPODtlType.Items(cmbPODtlType.SelectedIndex).ItemData
            Case "T"
                'txtSKUCode.ReadOnly = True
                m_SKUId = 0
                txtSKUCode.Text = ""
                btnPRequest.Enabled = False
                btnSKU.Enabled = False
                btnLocation.Enabled = False
                ntbPOQty.ReadOnly = True
                ntbPOQty.Text = IIf(cmbPODtlType.Items(cmbPODtlType.SelectedIndex).ItemData = "E", "1", "0")
                If cmbPODtlType.Items(cmbPODtlType.SelectedIndex).ItemData = "E" Then ntbPOPrice.ReadOnly = False Else ntbPOPrice.ReadOnly = True
                ntbPOTaxPercent.ReadOnly = IIf(cmbPODtlType.Items(cmbPODtlType.SelectedIndex).ItemData = "T", True, False)
                ntbPOTaxPercent.Text = IIf(cmbPODtlType.Items(cmbPODtlType.SelectedIndex).ItemData = "T", "0", FormatNumber(m_POTaxPercent, 0))

            Case "S", "E"
                If Not btnCancel.Enabled = False Then
                    'txtSKUCode.ReadOnly = False
                    btnPRequest.Enabled = True
                    btnSKU.Enabled = True
                    btnLocation.Enabled = True
                    If cmbPODtlType.Items(cmbPODtlType.SelectedIndex).ItemData = "E" Then ntbPOQty.ReadOnly = True Else ntbPOQty.ReadOnly = False
                    ntbPOPrice.ReadOnly = False
                    ntbPOTaxPercent.ReadOnly = False
                    ntbPOTaxPercent.Text = FormatNumber(m_POTaxPercent, 0)
                    If cmbPODtlType.Items(cmbPODtlType.SelectedIndex).ItemData = "E" Then ntbPOQty.Text = "1" Else ntbPOQty.Text = "0"
                End If
        End Select
    End Sub

    Private Sub ntbPOPrice_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ntbPOPrice.LostFocus
        If ntbPOPrice.Text = "" Then ntbPOPrice.Text = FormatNumber(0)
        refresh_totalD()
        ntbPOPrice.Text = FormatNumber(ntbPOPrice.Text, Dec)
    End Sub

    Private Sub ntbPOTax_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ntbPOTaxPercent.LostFocus
        'ntbPOTax.Text = FormatPercent(CSng(ntbPOTax.Text.Replace("%", "")) / 100, 0)
        If ntbPOTaxPercent.Text = "" Then ntbPOTaxPercent.Text = FormatNumber(m_POTaxPercent)
        refresh_totalD()
        ntbPOTaxPercent.Text = FormatNumber(ntbPOTaxPercent.Text, 0)
    End Sub

    Private Sub btnAddD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddD.Click
        clear_objD()
    End Sub

    Private Sub ntbPOQty_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ntbPOQty.LostFocus
        If ntbPOQty.Text = "" Then ntbPOQty.Text = 1
        If ntbPOQty.DecimalValue = 0 Then ntbPOQty.Text = 1
        If m_PODId > 0 And (CDbl(ntbPOQty.Text) < m_SumPReceiveQty) Then
            MsgBox("Total Quantity for existing Purchase Incoming is " & m_SumPReceiveQty & ". Please edit the Quantity to Equal or Lower.", vbInformation, Me.Text)
            ntbPOQty.Text = FormatNumber(m_POQtyBefore)
        Else
            ntbPOQty.Text = FormatNumber(ntbPOQty.Text)
        End If
        refresh_totalD()
    End Sub
    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Dim strConnection As String = My.Settings.ConnStr
        Dim Connection As New SqlConnection(strConnection)
        Dim strSQL As String
        strSQL = "exec RPT_Pch_Order_Form " & m_POId
        Dim DA As New SqlDataAdapter(strSQL, Connection)
        Dim DS As New DataSet

        DA.Fill(DS, "PO_")
        'RPT_Pch_Pitching_Form.rpt
        Dim strReportPath As String = Application.StartupPath & "\Reports\RPT_Pch_Order_Form.rpt"

        If Not IO.File.Exists(strReportPath) Then
            Throw (New Exception("Unable to locate report file:" & _
              vbCrLf & strReportPath))
        End If

        Dim cr As New ReportDocument
        Dim NewMDIChild As New frmDocViewer()
        NewMDIChild.Text = "Purchase Pitching"
        NewMDIChild.Show()

        cr.Load(strReportPath)
        cr.SetDataSource(DS.Tables("PO_"))
        With NewMDIChild
            .myCrystalReportViewer.ShowRefreshButton = False
            .myCrystalReportViewer.ShowCloseButton = False
            .myCrystalReportViewer.ShowGroupTreeButton = False
            .myCrystalReportViewer.ReportSource = cr
        End With
    End Sub
    Private Sub btnPRequest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPRequest.Click
        If m_SId = 0 Or m_PchCodeId = 0 Then
            MsgBox("Purchase Code & Supplier information are primary fields that should be entered. Please enter those fields before you do the selection.", vbCritical + vbOKOnly, Me.Text)
            txtSCode.Focus()
            Exit Sub
        End If
        Dim NewFormDialog As New fdlPRequestOut
        NewFormDialog.FrmCallerId = Me.Name
        NewFormDialog.PchCodeId = m_PchCodeId
        NewFormDialog.ShowDialog()
    End Sub

    Private Sub btnLocation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLocation.Click
        If m_SKUId = 0 Then
            MsgBox("Stock information are primary fields that should be entered. Please enter those fields before you save it.", vbCritical + vbOKOnly, Me.Text)
            btnSKU.Focus()
            Exit Sub
        End If
        Dim NewFormDialog As New fdlLocation
        NewFormDialog.FrmCallerId = Me.Name
        NewFormDialog.SKUId = m_SKUId
        NewFormDialog.ShowDialog()
    End Sub

    Private Sub btnPchCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPchCode.Click
        Dim NewFormDialog As New fdlPchCode
        NewFormDialog.FrmCallerId = Me.Name
        NewFormDialog.ShowDialog()
    End Sub

    Private Sub ntbPOCurrRate_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ntbPOCurrRate.LostFocus
        If ntbPOCurrRate.Text.Length = 0 Then ntbPOCurrRate.Undo()
        'If m_POId = 0 Then
        If m_CurrId = m_CurrBaseId Then
            ntbPOCurrRate.Text = "1"
        Else
            If ntbPOCurrRate.DecimalValue = 0 Then ntbPOCurrRate.Undo()
        End If
        'End If
        'ntbPOCurrRate.Text = FormatNumber(IIf(ntbPOCurrRate.Text = "", 1, ntbPOCurrRate.Text))
        ntbPOCurrRate.Text = FormatNumber(ntbPOCurrRate.Text)
    End Sub

    Private Sub ntbPOQty_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ntbPOQty.TextChanged

    End Sub

    Private Sub btnPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPreview.Click
        Dim strConnection As String = My.Settings.ConnStr
        Dim Connection As New SqlConnection(strConnection)
        Dim strSQL As String
        strSQL = "exec RPT_Pch_Order_Form " & m_POId
        Dim DA As New SqlDataAdapter(strSQL, Connection)
        Dim DS As New DataSet

        DA.Fill(DS, "POPreview_")
        'RPT_Pch_Pitching_Form.rpt
        Dim strReportPath As String = Application.StartupPath & "\Reports\RPT_Pch_Order_Form.rpt"

        If Not IO.File.Exists(strReportPath) Then
            Throw (New Exception("Unable to locate report file:" & _
              vbCrLf & strReportPath))
        End If

        Dim cr As New ReportDocument
        Dim NewMDIChild As New frmDocViewer()
        NewMDIChild.Text = "Purchase Pitching"
        NewMDIChild.Show()

        cr.Load(strReportPath)
        cr.SetDataSource(DS.Tables("POPreview_"))
        With NewMDIChild
            .myCrystalReportViewer.ShowRefreshButton = False
            .myCrystalReportViewer.ShowCloseButton = False
            .myCrystalReportViewer.ShowGroupTreeButton = False
            .myCrystalReportViewer.ShowPrintButton = False
            '.myCrystalReportViewer.ShowCopyButton = False
            .myCrystalReportViewer.ShowExportButton = False
            .myCrystalReportViewer.ReportSource = cr
        End With
    End Sub

    Sub autoRefresh()
        'Set autorefresh form 
        If Application.OpenForms().OfType(Of frmPOList).Any Then
            Call frmPPitchingList.frmPPitchingListShow(Nothing, EventArgs.Empty)
        End If
    End Sub

    Private Sub btnApprove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApprove.Click
        btnSave_Click(sender, e)
        m_POStatus = "A"

        exec_sp_Approval("usp_tr_po_APPROVAL", "po_id", m_POId, "ppitching_status", m_POStatus)

        'Me.Close()
        For i = 0 To m_POStatusArr.GetUpperBound(0)
            If m_POStatus = m_POStatusArr(i, 0) Then
                txtPitchingStatus.Text = m_POStatusArr(i, 1)
                Exit For
            End If
        Next

        lock_obj(True)
        autoRefresh()
    End Sub

    Private Sub btnReject_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReject.Click
        btnSave_Click(sender, e)
        m_POStatus = "R"

        exec_sp_Approval("usp_tr_po_APPROVAL", "po_id", m_POId, "ppitching_status", m_POStatus)

        'Me.Close()
        For i = 0 To m_POStatusArr.GetUpperBound(0)
            If m_POStatus = m_POStatusArr(i, 0) Then
                txtPitchingStatus.Text = m_POStatusArr(i, 1)
                Exit For
            End If
        Next

        lock_obj(True)
        autoRefresh()
    End Sub

    Private Sub btnSubmitApproval_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubmitApproval.Click
        If CDbl(txtPOTotal.Text) = 0 Then
            MsgBox("Please ensure the Unit Price is filled up on all items before you submit for approval!", vbExclamation, Me.Text)
        Else

            btnSave_Click(sender, e)
            m_POStatus = "W"

            exec_sp_Approval("usp_tr_po_APPROVAL", "po_id", m_POId, "ppitching_status", m_POStatus)

            For i = 0 To m_POStatusArr.GetUpperBound(0)
                If m_POStatus = m_POStatusArr(i, 0) Then
                    txtPitchingStatus.Text = m_POStatusArr(i, 1)
                    Exit For
                End If
            Next
            lock_obj(True)
            autoRefresh()
        End If
    End Sub

    Private Sub btnConvertToPO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConvertToPO.Click
        isConvertToPO = True
        btnSave_Click(sender, e)
        UpdSysNumber("pord")
        isConvertToPO = False

        Dim frm1 As New frmPO
        With frm1
            .POId = m_POId
            .MdiParent = frmMAIN
            .AutoSizeMode = Windows.Forms.AutoSizeMode.GrowAndShrink
            .Show()
            .BringToFront()
        End With
    End Sub
End Class
