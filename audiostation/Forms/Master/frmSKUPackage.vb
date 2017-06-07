Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class frmSKUPackage
    Dim strConnection As String = My.Settings.ConnStr
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Dim cmd As SqlCommand
    Dim m_SKUId1 As Integer
    Dim m_SKUId2 As Integer
    Dim m_SKUPackageId As Integer
    Dim m_SKUCatId As Integer
    Dim isAllowDelete As Boolean

    Private Sub frmSKUPackage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        isAllowDelete = canDelete(Me.Name + "List")

        ToolTip1.SetToolTip(btnSKU, "Search Stock")
        ToolTip1.SetToolTip(btnSaveD, "Save Line")
        ToolTip1.SetToolTip(btnDeleteD, "Delete Line")
        ToolTip1.SetToolTip(btnAddD, "Add Line")

        cmd = New SqlCommand("usp_mt_sku_category_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm1 As SqlParameter = cmd.Parameters.Add("@category_id", SqlDbType.Int, 50)
        prm1.Value = 0

        cn.Open()
        Dim myReader As SqlDataReader = cmd.ExecuteReader

        Do While myReader.Read
            cmbSKUCatID.Items.Add(New clsMyListInt(myReader.GetString(1), myReader.GetInt32(0)))
        Loop
        myReader.Close()
        cn.Close()


        If m_SKUId1 = 0 Then
            btnAdd_Click(sender, e)
        Else
            m_SKUPackageId = 0
            view_record()
            clear_lvw()
            'btnEdit_Click(sender, e)
            clear_objD()
            lock_obj(True)
            lock_objD(True)
        End If
    End Sub

    Public Property SKUId1() As Integer
        Get
            Return m_SKUId1
        End Get
        Set(ByVal Value As Integer)
            m_SKUId1 = Value
        End Set
    End Property

    Public Property SKUCode1() As String
        Get
            Return txtSKUCode1.Text
        End Get
        Set(ByVal Value As String)
            txtSKUCode1.Text = Value
        End Set
    End Property

    Public Property SKUName1() As String
        Get
            Return txtSKUName1.Text
        End Get
        Set(ByVal Value As String)
            txtSKUName1.Text = Value
        End Set
    End Property

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

    Sub clear_obj()
        m_SKUId1 = 0
        txtSKUCode1.Text = ""
        txtSKUName1.Text = ""
        cmbSKUCatID.SelectedIndex = -1
        txtSKUBarcode.Text = ""
        txtSKUUoM.Text = ""
        ntbSalesDiscPercent.Text = 0
        ntbSalesPrice.Text = FormatNumber(0)
        txtSKURemarks.Text = ""
        txtSKUInfo1.Text = ""
        txtSKUInfo2.Text = ""
        txtSKUInfo3.Text = ""
    End Sub

    Sub clear_objD()
        m_SKUPackageId = 0
        m_SKUId2 = 0
        txtSKUCode2.Text = ""
        txtSKUName2.Text = ""
        ntbSKUPackageQty.Text = ""
    End Sub

    Sub lock_obj(ByVal isLock As Boolean)
        'txtSKUCode1.ReadOnly = isLock
        txtSKUName1.ReadOnly = isLock
        cmbSKUCatID.Enabled = Not isLock
        txtSKUBarcode.ReadOnly = isLock
        txtSKUUoM.ReadOnly = isLock
        ntbSalesDiscPercent.ReadOnly = isLock
        ntbSalesPrice.ReadOnly = isLock

        txtSKURemarks.ReadOnly = isLock
        txtSKUInfo1.ReadOnly = isLock
        txtSKUInfo2.ReadOnly = isLock
        txtSKUInfo3.ReadOnly = isLock
        btnEdit.Enabled = isLock
        btnAdd.Enabled = isLock
        btnSave.Enabled = Not isLock
        btnCancel.Enabled = Not isLock

        If m_SKUId1 = 0 Then
            txtSKUCode1.ReadOnly = False
            btnDelete.Enabled = isLock
        Else
            txtSKUCode1.ReadOnly = True
            If isAllowDelete = True Then btnDelete.Enabled = Not isLock Else btnDelete.Enabled = False
        End If
    End Sub

    Sub lock_objD(ByVal isLock As Boolean)
        ntbSKUPackageQty.ReadOnly = isLock
        btnSKU.Enabled = Not isLock
        btnSaveD.Enabled = Not isLock
        btnDeleteD.Enabled = Not isLock
        btnAddD.Enabled = Not isLock
    End Sub

    Sub clear_lvw()
        With ListView1
            .Clear()
            .View = View.Details
            .Columns.Add("sku_id1", 0)
            .Columns.Add("sku_id2", 0)
            .Columns.Add("Stock Code", 90)
            .Columns.Add("Stock Name", 150)
            .Columns.Add("Qty", 90, HorizontalAlignment.Right)
        End With

        If m_SKUId1 <> 0 Then
            cmd = New SqlCommand("usp_mt_sku_package_SEL", cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm1 As SqlParameter = cmd.Parameters.Add("@sku_id1", SqlDbType.Int, 255)
            prm1.Value = m_SKUId1

            cn.Open()

            Dim myReader As SqlDataReader = cmd.ExecuteReader()

            Call FillList(myReader, Me.ListView1, 5, 1)
            myReader.Close()
            cn.Close()
        End If
    End Sub

    Sub view_record()
        cmd = New SqlCommand("sp_mt_sku_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm1 As SqlParameter = cmd.Parameters.Add("@sku_id", SqlDbType.Int, 255)
        prm1.Value = m_SKUId1

        cn.Open()

        Dim myReader As SqlDataReader = cmd.ExecuteReader()

        While myReader.Read
            m_SKUCatId = myReader.GetInt32(1)
            txtSKUCode1.Text = myReader.GetString(2)
            txtSKUName1.Text = myReader.GetString(3)
            If Not myReader.IsDBNull(myReader.GetOrdinal("sku_barcode")) Then
                txtSKUBarcode.Text = myReader.GetString(myReader.GetOrdinal("sku_barcode"))
            Else
                txtSKUBarcode.Text = ""
            End If
            If Not myReader.IsDBNull(myReader.GetOrdinal("sku_uom")) Then
                txtSKUUoM.Text = myReader.GetString(myReader.GetOrdinal("sku_uom"))
            Else
                txtSKUUoM.Text = ""
            End If
            ntbSalesDiscPercent.Text = FormatNumber(myReader.GetDecimal(6)) * 100
            ntbSalesPrice.Text = FormatNumber(myReader.GetValue(7))
            If Not myReader.IsDBNull(myReader.GetOrdinal("sku_remarks")) Then
                txtSKURemarks.Text = myReader.GetString(myReader.GetOrdinal("sku_remarks"))
            Else
                txtSKURemarks.Text = ""
            End If
            If Not myReader.IsDBNull(myReader.GetOrdinal("sku_info1")) Then
                txtSKUInfo1.Text = myReader.GetString(myReader.GetOrdinal("sku_info1"))
            Else
                txtSKUInfo1.Text = ""
            End If
            If Not myReader.IsDBNull(myReader.GetOrdinal("sku_info2")) Then
                txtSKUInfo2.Text = myReader.GetString(myReader.GetOrdinal("sku_info2"))
            Else
                txtSKUInfo2.Text = ""
            End If
            If Not myReader.IsDBNull(myReader.GetOrdinal("sku_info3")) Then
                txtSKUInfo3.Text = myReader.GetString(myReader.GetOrdinal("sku_info3"))
            Else
                txtSKUInfo3.Text = ""
            End If
        End While

        myReader.Close()
        cn.Close()

        Dim mList As clsMyListInt
        Dim i As Integer
        For i = 1 To cmbSKUCatID.Items.Count
            mList = cmbSKUCatID.Items(i - 1)
            If m_SKUCatId = mList.ItemData Then
                cmbSKUCatID.SelectedIndex = i - 1
                Exit For
            End If
        Next
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        m_SKUId1 = 0
        clear_obj()
        clear_objD()
        clear_lvw()
        lock_obj(False)
        lock_objD(False)
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If m_SKUId1 = 0 Then
            Me.Close()
        Else
            lock_obj(True)
            lock_objD(True)
            clear_objD()
            m_SKUPackageId = 0
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            If txtSKUCode1.Text = "" Or txtSKUName1.Text = "" Then
                MsgBox("Stock Set Code and Stock Set Name are primary fields that should be entered. Please enter those fields before you save it.", vbCritical + vbOKOnly, Me.Text)
                txtSKUCode1.Focus()
                Exit Sub
            End If

            cmd = New SqlCommand(IIf(m_SKUId1 = 0, "sp_mt_sku_INS", "sp_mt_sku_UPD"), cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm2 As SqlParameter = cmd.Parameters.Add("@sku_cat_id", SqlDbType.Int, 50)
            prm2.Value = cmbSKUCatID.Items(cmbSKUCatID.SelectedIndex).ItemData
            Dim prm3 As SqlParameter = cmd.Parameters.Add("@sku_code", SqlDbType.NVarChar, 50)
            prm3.Value = txtSKUCode1.Text
            Dim prm4 As SqlParameter = cmd.Parameters.Add("@sku_name", SqlDbType.NVarChar, 255)
            prm4.Value = txtSKUName1.Text
            Dim prm5 As SqlParameter = cmd.Parameters.Add("@sku_barcode", SqlDbType.NVarChar, 255)
            prm5.Value = IIf(txtSKUBarcode.Text = "", DBNull.Value, txtSKUBarcode.Text)
            Dim prm6 As SqlParameter = cmd.Parameters.Add("@sku_uom", SqlDbType.NVarChar, 50)
            prm6.Value = IIf(txtSKUUoM.Text = "", DBNull.Value, txtSKUUoM.Text)
            Dim prm7 As SqlParameter = cmd.Parameters.Add("@sales_discount", SqlDbType.Decimal)
            prm7.Value = IIf(ntbSalesDiscPercent.Text = "", 0, ntbSalesDiscPercent.Text)
            Dim prm8 As SqlParameter = cmd.Parameters.Add("@sales_price", SqlDbType.Money, 50)
            prm8.Value = IIf(ntbSalesPrice.Text = "", 0, ntbSalesPrice.Text)
            Dim prm9 As SqlParameter = cmd.Parameters.Add("@sku_remarks", SqlDbType.NVarChar, 255)
            prm9.Value = IIf(txtSKURemarks.Text = "", DBNull.Value, txtSKURemarks.Text)
            Dim prm10 As SqlParameter = cmd.Parameters.Add("@sku_info1", SqlDbType.NVarChar, 255)
            prm10.Value = IIf(txtSKUInfo1.Text = "", DBNull.Value, txtSKUInfo1.Text)
            Dim prm11 As SqlParameter = cmd.Parameters.Add("@sku_info2", SqlDbType.NVarChar, 255)
            prm11.Value = IIf(txtSKUInfo2.Text = "", DBNull.Value, txtSKUInfo2.Text)
            Dim prm12 As SqlParameter = cmd.Parameters.Add("@sku_info3", SqlDbType.NVarChar, 255)
            prm12.Value = IIf(txtSKUInfo3.Text = "", DBNull.Value, txtSKUInfo3.Text)
            Dim prm13 As SqlParameter = cmd.Parameters.Add("@is_package", SqlDbType.Bit)
            prm13.Value = 1
            Dim prm15 As SqlParameter = cmd.Parameters.Add("@user_name", SqlDbType.NVarChar, 50)
            prm15.Value = My.Settings.UserName
            Dim prm16 As SqlParameter = cmd.Parameters.Add("@sku_id", SqlDbType.Int, 255)

            If m_SKUId1 = 0 Then
                prm16.Direction = ParameterDirection.Output

                cn.Open()
                cmd.ExecuteReader()
                m_SKUId1 = prm16.Value
                'MessageBox.Show(m_SKUId1)
                cn.Close()
            Else
                prm16.Value = m_SKUId1
                cn.Open()
                cmd.ExecuteReader()
                cn.Close()
                'clear_lvw()
            End If

            lock_obj(True)
            lock_objD(True)

        Catch ex As Exception
            'If Err.Number = 5 Then
            '    MsgBox("This primary code has been used (and deleted) previously. Please create with another code", vbExclamation + vbOKOnly, Me.Text)
            'Else
            MsgBox(ex.Message)
            'End If
            If ConnectionState.Open = 1 Then cn.Close()
        End Try
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        clear_objD()
        lock_obj(False)
        lock_objD(False)
        'If m_POStatus = "FR" Or m_POStatus = "P" Then
        '    btnSave.Enabled = False
        '    btnDelete.Enabled = False
        '    lock_objD(True)
        'End If
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If MsgBox("Are you sure you want to delete this record?", vbYesNo + vbCritical, Me.Text) = vbYes Then
            cmd = New SqlCommand("sp_mt_sku_DEL", cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm1 As SqlParameter = cmd.Parameters.Add("@sku_id", SqlDbType.Int, 50)
            prm1.Value = m_SKUId1
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

    Private Sub btnSaveD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveD.Click
        Try
            If m_SKUId1 = 0 Then
                If txtSKUCode1.Text = "" Or txtSKUName1.Text = "" Then
                    MsgBox("Stock Set Code and Stock Set Name are primary fields that should be entered. Please enter those fields before you save it.", vbCritical + vbOKOnly, Me.Text)
                    txtSKUCode1.Focus()
                    Exit Sub
                End If
                SaveSKUHeader()
            End If

            cmd = New SqlCommand(IIf(m_SKUPackageId = 0, "usp_mt_sku_package_INS", "usp_mt_sku_package_UPD"), cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm17 As SqlParameter = cmd.Parameters.Add("@sku_id1", SqlDbType.Int, 255)
            prm17.Value = m_SKUId1
            Dim prm18 As SqlParameter = cmd.Parameters.Add("@sku_id2", SqlDbType.Int, 255)
            prm18.Value = m_SKUId2
            Dim prm19 As SqlParameter = cmd.Parameters.Add("@sku_package_qty", SqlDbType.Int, 255)
            prm19.Value = IIf(ntbSKUPackageQty.Text = "", 0, ntbSKUPackageQty.Text)

            If m_SKUPackageId <> 0 Then
                Dim prm24 As SqlParameter = cmd.Parameters.Add("@sku_package_id", SqlDbType.Int, 255)
                prm24.Value = m_SKUPackageId
            End If
            cn.Open()
            cmd.ExecuteReader()
            cn.Close()

            clear_lvw()
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

    Sub SaveSKUHeader()
        Try
            cmd = New SqlCommand("sp_mt_sku_INS", cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm2 As SqlParameter = cmd.Parameters.Add("@sku_cat_id", SqlDbType.Int, 50)
            prm2.Value = cmbSKUCatID.Items(cmbSKUCatID.SelectedIndex).ItemData
                Dim prm3 As SqlParameter = cmd.Parameters.Add("@sku_code", SqlDbType.NVarChar, 50)
                prm3.Value = txtSKUCode1.Text
                Dim prm4 As SqlParameter = cmd.Parameters.Add("@sku_name", SqlDbType.NVarChar, 255)
                prm4.Value = txtSKUName1.Text
                Dim prm5 As SqlParameter = cmd.Parameters.Add("@sku_barcode", SqlDbType.NVarChar, 255)
                prm5.Value = IIf(txtSKUBarcode.Text = "", DBNull.Value, txtSKUBarcode.Text)
                Dim prm6 As SqlParameter = cmd.Parameters.Add("@sku_uom", SqlDbType.NVarChar, 50)
                prm6.Value = IIf(txtSKUUoM.Text = "", DBNull.Value, txtSKUUoM.Text)
                Dim prm7 As SqlParameter = cmd.Parameters.Add("@sales_discount", SqlDbType.Decimal)
                prm7.Value = IIf(ntbSalesDiscPercent.Text = "", 0, ntbSalesDiscPercent.Text)
                Dim prm8 As SqlParameter = cmd.Parameters.Add("@sales_price", SqlDbType.Money, 50)
                prm8.Value = IIf(ntbSalesPrice.Text = "", 0, ntbSalesPrice.Text)
                Dim prm9 As SqlParameter = cmd.Parameters.Add("@sku_remarks", SqlDbType.NVarChar, 255)
                prm9.Value = IIf(txtSKURemarks.Text = "", DBNull.Value, txtSKURemarks.Text)
                Dim prm10 As SqlParameter = cmd.Parameters.Add("@sku_info1", SqlDbType.NVarChar, 255)
                prm10.Value = IIf(txtSKUInfo1.Text = "", DBNull.Value, txtSKUInfo1.Text)
                Dim prm11 As SqlParameter = cmd.Parameters.Add("@sku_info2", SqlDbType.NVarChar, 255)
                prm11.Value = IIf(txtSKUInfo2.Text = "", DBNull.Value, txtSKUInfo2.Text)
                Dim prm12 As SqlParameter = cmd.Parameters.Add("@sku_info3", SqlDbType.NVarChar, 255)
                prm12.Value = IIf(txtSKUInfo3.Text = "", DBNull.Value, txtSKUInfo3.Text)
                Dim prm13 As SqlParameter = cmd.Parameters.Add("@is_package", SqlDbType.Bit)
                prm13.Value = 1
                Dim prm15 As SqlParameter = cmd.Parameters.Add("@user_name", SqlDbType.NVarChar, 50)
                prm15.Value = My.Settings.UserName
                Dim prm16 As SqlParameter = cmd.Parameters.Add("@sku_id", SqlDbType.Int, 255)
                prm16.Direction = ParameterDirection.Output

                cn.Open()
                cmd.ExecuteReader()
                m_SKUId1 = prm16.Value
                cn.Close()
                txtSKUCode1.ReadOnly = True

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
        If m_SKUPackageId = 0 Then Exit Sub
        If MsgBox("Are you sure you want to delete this record?", vbYesNo + vbCritical, Me.Text) = vbYes Then
            cmd = New SqlCommand("usp_mt_sku_package_DEL", cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm1 As SqlParameter = cmd.Parameters.Add("@sku_package_id", SqlDbType.Int)
            prm1.Value = m_SKUPackageId

            cn.Open()
            cmd.ExecuteReader()
            cn.Close()

            clear_lvw()
            clear_objD()
        End If
    End Sub

    Private Sub ListView1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.Click
        With ListView1.SelectedItems.Item(0)
            m_SKUPackageId = LeftSplitUF(.Tag)
            m_SKUId2 = .SubItems.Item(1).Text
            txtSKUCode2.Text = .SubItems.Item(2).Text
            txtSKUName2.Text = .SubItems.Item(3).Text
            ntbSKUPackageQty.Text = .SubItems.Item(4).Text
        End With
    End Sub

    Private Sub btnAddD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddD.Click
        clear_objD()
    End Sub

    Private Sub btnSKU_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSKU.Click
        Dim NewFormDialog As New fdlSKU
        NewFormDialog.FrmCallerId = Me.Name
        NewFormDialog.ShowDialog()
    End Sub

    Private Sub ntbSalesPrice_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ntbSalesPrice.LostFocus
        ntbSalesPrice.Text = FormatNumber(ntbSalesPrice.Text)
    End Sub

End Class
