<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSKU
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSKU))
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.txtSKUCode = New System.Windows.Forms.TextBox()
        Me.txtSKUName = New System.Windows.Forms.TextBox()
        Me.txtStockValue = New System.Windows.Forms.TextBox()
        Me.txtStockBalance = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtLastCost = New System.Windows.Forms.TextBox()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.txtSKUBarcode = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtSKURemarks = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtSKUInfo1 = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtSKUInfo2 = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtSKUInfo3 = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtAvgCost = New System.Windows.Forms.TextBox()
        Me.cmbCategoryID = New System.Windows.Forms.ComboBox()
        Me.lblCurrentRecord = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.cmbUomID = New System.Windows.Forms.ComboBox()
        Me.chbIsFinishedGoods = New System.Windows.Forms.CheckBox()
        Me.NumericTextBox4 = New boxtree.NumericTextBox()
        Me.NumericTextBox3 = New boxtree.NumericTextBox()
        Me.NumericTextBox2 = New boxtree.NumericTextBox()
        Me.NumericTextBox1 = New boxtree.NumericTextBox()
        Me.ntbSalesPrice = New boxtree.NumericTextBox()
        Me.ntbSalesDiscPercent = New boxtree.NumericTextBox()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.btnAddD = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.txtSKUName2 = New System.Windows.Forms.TextBox()
        Me.txtSKUCode2 = New System.Windows.Forms.TextBox()
        Me.btnSKU = New System.Windows.Forms.Button()
        Me.btnDeleteD = New System.Windows.Forms.Button()
        Me.btnSaveD = New System.Windows.Forms.Button()
        Me.ntbRawQty = New boxtree.NumericTextBox()
        Me.ListView2 = New System.Windows.Forms.ListView()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.ListView3 = New System.Windows.Forms.ListView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chbIsFinishedGoods2 = New System.Windows.Forms.CheckBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.cbCategory = New System.Windows.Forms.ComboBox()
        Me.btnFilter = New System.Windows.Forms.Button()
        Me.txtFilter = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbFilterBy = New System.Windows.Forms.ComboBox()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ListView1
        '
        Me.ListView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListView1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListView1.FullRowSelect = True
        Me.ListView1.GridLines = True
        Me.ListView1.Location = New System.Drawing.Point(12, 86)
        Me.ListView1.MultiSelect = False
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(635, 489)
        Me.ListView1.TabIndex = 4
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.List
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Location = New System.Drawing.Point(1022, 590)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 9
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.Location = New System.Drawing.Point(779, 590)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(75, 23)
        Me.btnDelete.TabIndex = 6
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'txtSKUCode
        '
        Me.txtSKUCode.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSKUCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSKUCode.Location = New System.Drawing.Point(134, 6)
        Me.txtSKUCode.MaxLength = 50
        Me.txtSKUCode.Name = "txtSKUCode"
        Me.txtSKUCode.Size = New System.Drawing.Size(148, 21)
        Me.txtSKUCode.TabIndex = 0
        '
        'txtSKUName
        '
        Me.txtSKUName.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSKUName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSKUName.Location = New System.Drawing.Point(134, 33)
        Me.txtSKUName.MaxLength = 255
        Me.txtSKUName.Name = "txtSKUName"
        Me.txtSKUName.Size = New System.Drawing.Size(351, 21)
        Me.txtSKUName.TabIndex = 1
        '
        'txtStockValue
        '
        Me.txtStockValue.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtStockValue.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStockValue.Location = New System.Drawing.Point(134, 277)
        Me.txtStockValue.Name = "txtStockValue"
        Me.txtStockValue.ReadOnly = True
        Me.txtStockValue.Size = New System.Drawing.Size(131, 21)
        Me.txtStockValue.TabIndex = 10
        Me.txtStockValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtStockBalance
        '
        Me.txtStockBalance.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtStockBalance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStockBalance.Location = New System.Drawing.Point(134, 303)
        Me.txtStockBalance.Name = "txtStockBalance"
        Me.txtStockBalance.ReadOnly = True
        Me.txtStockBalance.Size = New System.Drawing.Size(131, 21)
        Me.txtStockBalance.TabIndex = 11
        Me.txtStockBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(21, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Code *"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(21, 36)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Name *"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(20, 253)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 13)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Last Cost"
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(20, 280)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(62, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Stock Value"
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(21, 496)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(58, 13)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Sales Price"
        Me.Label5.Visible = False
        '
        'txtLastCost
        '
        Me.txtLastCost.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtLastCost.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLastCost.Location = New System.Drawing.Point(134, 250)
        Me.txtLastCost.Name = "txtLastCost"
        Me.txtLastCost.ReadOnly = True
        Me.txtLastCost.Size = New System.Drawing.Size(131, 21)
        Me.txtLastCost.TabIndex = 9
        Me.txtLastCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.Location = New System.Drawing.Point(941, 590)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(75, 23)
        Me.btnAdd.TabIndex = 8
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnEdit
        '
        Me.btnEdit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEdit.Location = New System.Drawing.Point(860, 590)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(75, 23)
        Me.btnEdit.TabIndex = 7
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(1101, 590)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 10
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'txtSKUBarcode
        '
        Me.txtSKUBarcode.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSKUBarcode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSKUBarcode.Location = New System.Drawing.Point(134, 87)
        Me.txtSKUBarcode.MaxLength = 50
        Me.txtSKUBarcode.Name = "txtSKUBarcode"
        Me.txtSKUBarcode.Size = New System.Drawing.Size(351, 21)
        Me.txtSKUBarcode.TabIndex = 3
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(22, 87)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(46, 13)
        Me.Label7.TabIndex = 20
        Me.Label7.Text = "Barcode"
        '
        'txtSKURemarks
        '
        Me.txtSKURemarks.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSKURemarks.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSKURemarks.Location = New System.Drawing.Point(134, 357)
        Me.txtSKURemarks.MaxLength = 50
        Me.txtSKURemarks.Name = "txtSKURemarks"
        Me.txtSKURemarks.Size = New System.Drawing.Size(361, 21)
        Me.txtSKURemarks.TabIndex = 13
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(21, 114)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(107, 13)
        Me.Label8.TabIndex = 24
        Me.Label8.Text = "Unit of Measurement"
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(20, 360)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(48, 13)
        Me.Label9.TabIndex = 25
        Me.Label9.Text = "Remarks"
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(21, 467)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(90, 13)
        Me.Label10.TabIndex = 27
        Me.Label10.Text = "Sales Discount %"
        Me.Label10.Visible = False
        '
        'Label11
        '
        Me.Label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(20, 387)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(67, 13)
        Me.Label11.TabIndex = 29
        Me.Label11.Text = "Other Info 1"
        '
        'txtSKUInfo1
        '
        Me.txtSKUInfo1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSKUInfo1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSKUInfo1.Location = New System.Drawing.Point(134, 384)
        Me.txtSKUInfo1.MaxLength = 50
        Me.txtSKUInfo1.Name = "txtSKUInfo1"
        Me.txtSKUInfo1.Size = New System.Drawing.Size(361, 21)
        Me.txtSKUInfo1.TabIndex = 14
        '
        'Label12
        '
        Me.Label12.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(20, 414)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(67, 13)
        Me.Label12.TabIndex = 31
        Me.Label12.Text = "Other Info 2"
        '
        'txtSKUInfo2
        '
        Me.txtSKUInfo2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSKUInfo2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSKUInfo2.Location = New System.Drawing.Point(134, 411)
        Me.txtSKUInfo2.MaxLength = 50
        Me.txtSKUInfo2.Name = "txtSKUInfo2"
        Me.txtSKUInfo2.Size = New System.Drawing.Size(361, 21)
        Me.txtSKUInfo2.TabIndex = 15
        '
        'Label13
        '
        Me.Label13.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(20, 441)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(67, 13)
        Me.Label13.TabIndex = 33
        Me.Label13.Text = "Other Info 3"
        '
        'txtSKUInfo3
        '
        Me.txtSKUInfo3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSKUInfo3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSKUInfo3.Location = New System.Drawing.Point(134, 438)
        Me.txtSKUInfo3.MaxLength = 50
        Me.txtSKUInfo3.Name = "txtSKUInfo3"
        Me.txtSKUInfo3.Size = New System.Drawing.Size(361, 21)
        Me.txtSKUInfo3.TabIndex = 16
        '
        'Label15
        '
        Me.Label15.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(22, 63)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(82, 13)
        Me.Label15.TabIndex = 37
        Me.Label15.Text = "Sub Category *"
        '
        'Label16
        '
        Me.Label16.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(20, 306)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(73, 13)
        Me.Label16.TabIndex = 38
        Me.Label16.Text = "Stock Balance"
        '
        'Label17
        '
        Me.Label17.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(20, 333)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(73, 13)
        Me.Label17.TabIndex = 40
        Me.Label17.Text = "Average Cost"
        '
        'txtAvgCost
        '
        Me.txtAvgCost.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAvgCost.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAvgCost.Location = New System.Drawing.Point(134, 330)
        Me.txtAvgCost.Name = "txtAvgCost"
        Me.txtAvgCost.ReadOnly = True
        Me.txtAvgCost.Size = New System.Drawing.Size(131, 21)
        Me.txtAvgCost.TabIndex = 12
        Me.txtAvgCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmbCategoryID
        '
        Me.cmbCategoryID.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbCategoryID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCategoryID.FormattingEnabled = True
        Me.cmbCategoryID.Location = New System.Drawing.Point(134, 60)
        Me.cmbCategoryID.Name = "cmbCategoryID"
        Me.cmbCategoryID.Size = New System.Drawing.Size(351, 21)
        Me.cmbCategoryID.TabIndex = 2
        '
        'lblCurrentRecord
        '
        Me.lblCurrentRecord.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblCurrentRecord.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCurrentRecord.Location = New System.Drawing.Point(12, 590)
        Me.lblCurrentRecord.Name = "lblCurrentRecord"
        Me.lblCurrentRecord.Size = New System.Drawing.Size(177, 13)
        Me.lblCurrentRecord.TabIndex = 45
        Me.lblCurrentRecord.Text = "Selected record:"
        '
        'Label18
        '
        Me.Label18.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(20, 142)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(86, 13)
        Me.Label18.TabIndex = 64
        Me.Label18.Text = "Jumlah Kemasan"
        '
        'Label19
        '
        Me.Label19.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(20, 169)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(41, 13)
        Me.Label19.TabIndex = 66
        Me.Label19.Text = "Volume"
        '
        'Label20
        '
        Me.Label20.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(20, 196)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(84, 13)
        Me.Label20.TabIndex = 68
        Me.Label20.Text = "Berat Kotor (kg)"
        '
        'Label21
        '
        Me.Label21.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(20, 223)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(87, 13)
        Me.Label21.TabIndex = 70
        Me.Label21.Text = "Berat Bersih (kg)"
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(653, 12)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(523, 567)
        Me.TabControl1.TabIndex = 5
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.cmbUomID)
        Me.TabPage1.Controls.Add(Me.chbIsFinishedGoods)
        Me.TabPage1.Controls.Add(Me.txtStockBalance)
        Me.TabPage1.Controls.Add(Me.txtSKUCode)
        Me.TabPage1.Controls.Add(Me.txtSKUName)
        Me.TabPage1.Controls.Add(Me.txtStockValue)
        Me.TabPage1.Controls.Add(Me.NumericTextBox4)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.Label21)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.NumericTextBox3)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.Label20)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.NumericTextBox2)
        Me.TabPage1.Controls.Add(Me.txtLastCost)
        Me.TabPage1.Controls.Add(Me.Label19)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.NumericTextBox1)
        Me.TabPage1.Controls.Add(Me.txtSKUBarcode)
        Me.TabPage1.Controls.Add(Me.Label18)
        Me.TabPage1.Controls.Add(Me.Label7)
        Me.TabPage1.Controls.Add(Me.txtSKURemarks)
        Me.TabPage1.Controls.Add(Me.ntbSalesPrice)
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Controls.Add(Me.ntbSalesDiscPercent)
        Me.TabPage1.Controls.Add(Me.Label9)
        Me.TabPage1.Controls.Add(Me.cmbCategoryID)
        Me.TabPage1.Controls.Add(Me.Label10)
        Me.TabPage1.Controls.Add(Me.Label17)
        Me.TabPage1.Controls.Add(Me.txtSKUInfo1)
        Me.TabPage1.Controls.Add(Me.txtAvgCost)
        Me.TabPage1.Controls.Add(Me.Label11)
        Me.TabPage1.Controls.Add(Me.Label16)
        Me.TabPage1.Controls.Add(Me.txtSKUInfo2)
        Me.TabPage1.Controls.Add(Me.Label15)
        Me.TabPage1.Controls.Add(Me.Label12)
        Me.TabPage1.Controls.Add(Me.Label13)
        Me.TabPage1.Controls.Add(Me.txtSKUInfo3)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(515, 541)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Primary Information"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'cmbUomID
        '
        Me.cmbUomID.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbUomID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbUomID.FormattingEnabled = True
        Me.cmbUomID.Location = New System.Drawing.Point(134, 114)
        Me.cmbUomID.Name = "cmbUomID"
        Me.cmbUomID.Size = New System.Drawing.Size(148, 21)
        Me.cmbUomID.TabIndex = 72
        '
        'chbIsFinishedGoods
        '
        Me.chbIsFinishedGoods.AutoSize = True
        Me.chbIsFinishedGoods.Location = New System.Drawing.Point(288, 9)
        Me.chbIsFinishedGoods.Name = "chbIsFinishedGoods"
        Me.chbIsFinishedGoods.Size = New System.Drawing.Size(98, 17)
        Me.chbIsFinishedGoods.TabIndex = 71
        Me.chbIsFinishedGoods.Text = "Finished Goods"
        Me.chbIsFinishedGoods.UseVisualStyleBackColor = True
        '
        'NumericTextBox4
        '
        Me.NumericTextBox4.AllowSpace = False
        Me.NumericTextBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NumericTextBox4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NumericTextBox4.Location = New System.Drawing.Point(134, 223)
        Me.NumericTextBox4.MaxLength = 10
        Me.NumericTextBox4.Name = "NumericTextBox4"
        Me.NumericTextBox4.Size = New System.Drawing.Size(131, 21)
        Me.NumericTextBox4.TabIndex = 8
        Me.NumericTextBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'NumericTextBox3
        '
        Me.NumericTextBox3.AllowSpace = False
        Me.NumericTextBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NumericTextBox3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NumericTextBox3.Location = New System.Drawing.Point(134, 196)
        Me.NumericTextBox3.MaxLength = 10
        Me.NumericTextBox3.Name = "NumericTextBox3"
        Me.NumericTextBox3.Size = New System.Drawing.Size(131, 21)
        Me.NumericTextBox3.TabIndex = 7
        Me.NumericTextBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'NumericTextBox2
        '
        Me.NumericTextBox2.AllowSpace = False
        Me.NumericTextBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NumericTextBox2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NumericTextBox2.Location = New System.Drawing.Point(134, 169)
        Me.NumericTextBox2.MaxLength = 10
        Me.NumericTextBox2.Name = "NumericTextBox2"
        Me.NumericTextBox2.Size = New System.Drawing.Size(131, 21)
        Me.NumericTextBox2.TabIndex = 6
        Me.NumericTextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'NumericTextBox1
        '
        Me.NumericTextBox1.AllowSpace = False
        Me.NumericTextBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NumericTextBox1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NumericTextBox1.Location = New System.Drawing.Point(134, 142)
        Me.NumericTextBox1.MaxLength = 10
        Me.NumericTextBox1.Name = "NumericTextBox1"
        Me.NumericTextBox1.Size = New System.Drawing.Size(131, 21)
        Me.NumericTextBox1.TabIndex = 5
        Me.NumericTextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ntbSalesPrice
        '
        Me.ntbSalesPrice.AllowSpace = False
        Me.ntbSalesPrice.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ntbSalesPrice.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ntbSalesPrice.Location = New System.Drawing.Point(134, 493)
        Me.ntbSalesPrice.Name = "ntbSalesPrice"
        Me.ntbSalesPrice.Size = New System.Drawing.Size(131, 21)
        Me.ntbSalesPrice.TabIndex = 18
        Me.ntbSalesPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ntbSalesPrice.Visible = False
        '
        'ntbSalesDiscPercent
        '
        Me.ntbSalesDiscPercent.AllowSpace = False
        Me.ntbSalesDiscPercent.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ntbSalesDiscPercent.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ntbSalesDiscPercent.Location = New System.Drawing.Point(134, 467)
        Me.ntbSalesDiscPercent.MaxLength = 3
        Me.ntbSalesDiscPercent.Name = "ntbSalesDiscPercent"
        Me.ntbSalesDiscPercent.Size = New System.Drawing.Size(131, 21)
        Me.ntbSalesDiscPercent.TabIndex = 17
        Me.ntbSalesDiscPercent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ntbSalesDiscPercent.Visible = False
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.Label23)
        Me.TabPage3.Controls.Add(Me.btnAddD)
        Me.TabPage3.Controls.Add(Me.Label24)
        Me.TabPage3.Controls.Add(Me.Label25)
        Me.TabPage3.Controls.Add(Me.txtSKUName2)
        Me.TabPage3.Controls.Add(Me.txtSKUCode2)
        Me.TabPage3.Controls.Add(Me.btnSKU)
        Me.TabPage3.Controls.Add(Me.btnDeleteD)
        Me.TabPage3.Controls.Add(Me.btnSaveD)
        Me.TabPage3.Controls.Add(Me.ntbRawQty)
        Me.TabPage3.Controls.Add(Me.ListView2)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(515, 541)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Raw Material"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(376, 12)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(29, 13)
        Me.Label23.TabIndex = 137
        Me.Label23.Text = "Qty."
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'btnAddD
        '
        Me.btnAddD.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddD.ImageIndex = 4
        Me.btnAddD.ImageList = Me.ImageList1
        Me.btnAddD.Location = New System.Drawing.Point(471, 26)
        Me.btnAddD.Name = "btnAddD"
        Me.btnAddD.Size = New System.Drawing.Size(29, 25)
        Me.btnAddD.TabIndex = 132
        Me.btnAddD.UseVisualStyleBackColor = True
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "Search.png")
        Me.ImageList1.Images.SetKeyName(1, "Box.png")
        Me.ImageList1.Images.SetKeyName(2, "Remove.png")
        Me.ImageList1.Images.SetKeyName(3, "Checkmark.png")
        Me.ImageList1.Images.SetKeyName(4, "Add_Symbol.png")
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(137, 12)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(74, 13)
        Me.Label24.TabIndex = 136
        Me.Label24.Text = "Product Name"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(17, 13)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(81, 13)
        Me.Label25.TabIndex = 135
        Me.Label25.Text = "Product Code *"
        '
        'txtSKUName2
        '
        Me.txtSKUName2.Location = New System.Drawing.Point(133, 29)
        Me.txtSKUName2.MaxLength = 50
        Me.txtSKUName2.Name = "txtSKUName2"
        Me.txtSKUName2.ReadOnly = True
        Me.txtSKUName2.Size = New System.Drawing.Size(226, 21)
        Me.txtSKUName2.TabIndex = 133
        '
        'txtSKUCode2
        '
        Me.txtSKUCode2.Location = New System.Drawing.Point(16, 29)
        Me.txtSKUCode2.Name = "txtSKUCode2"
        Me.txtSKUCode2.ReadOnly = True
        Me.txtSKUCode2.Size = New System.Drawing.Size(80, 21)
        Me.txtSKUCode2.TabIndex = 134
        Me.txtSKUCode2.TabStop = False
        '
        'btnSKU
        '
        Me.btnSKU.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSKU.ImageIndex = 1
        Me.btnSKU.ImageList = Me.ImageList1
        Me.btnSKU.Location = New System.Drawing.Point(98, 27)
        Me.btnSKU.Name = "btnSKU"
        Me.btnSKU.Size = New System.Drawing.Size(29, 25)
        Me.btnSKU.TabIndex = 128
        Me.btnSKU.UseVisualStyleBackColor = True
        '
        'btnDeleteD
        '
        Me.btnDeleteD.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDeleteD.ImageIndex = 2
        Me.btnDeleteD.ImageList = Me.ImageList1
        Me.btnDeleteD.Location = New System.Drawing.Point(440, 26)
        Me.btnDeleteD.Name = "btnDeleteD"
        Me.btnDeleteD.Size = New System.Drawing.Size(29, 25)
        Me.btnDeleteD.TabIndex = 131
        Me.btnDeleteD.UseVisualStyleBackColor = True
        '
        'btnSaveD
        '
        Me.btnSaveD.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSaveD.ImageIndex = 3
        Me.btnSaveD.ImageList = Me.ImageList1
        Me.btnSaveD.Location = New System.Drawing.Point(409, 26)
        Me.btnSaveD.Name = "btnSaveD"
        Me.btnSaveD.Size = New System.Drawing.Size(29, 25)
        Me.btnSaveD.TabIndex = 130
        Me.btnSaveD.UseVisualStyleBackColor = True
        '
        'ntbRawQty
        '
        Me.ntbRawQty.AllowSpace = False
        Me.ntbRawQty.Location = New System.Drawing.Point(365, 29)
        Me.ntbRawQty.MaxLength = 3
        Me.ntbRawQty.Name = "ntbRawQty"
        Me.ntbRawQty.Size = New System.Drawing.Size(40, 21)
        Me.ntbRawQty.TabIndex = 129
        Me.ntbRawQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ListView2
        '
        Me.ListView2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.ListView2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListView2.FullRowSelect = True
        Me.ListView2.GridLines = True
        Me.ListView2.Location = New System.Drawing.Point(16, 58)
        Me.ListView2.MultiSelect = False
        Me.ListView2.Name = "ListView2"
        Me.ListView2.Size = New System.Drawing.Size(486, 467)
        Me.ListView2.TabIndex = 5
        Me.ListView2.UseCompatibleStateImageBehavior = False
        Me.ListView2.View = System.Windows.Forms.View.List
        '
        'TabPage4
        '
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(515, 541)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Sales Price"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.ListView3)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(515, 541)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Balance"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'ListView3
        '
        Me.ListView3.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.ListView3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListView3.FullRowSelect = True
        Me.ListView3.GridLines = True
        Me.ListView3.Location = New System.Drawing.Point(18, 18)
        Me.ListView3.MultiSelect = False
        Me.ListView3.Name = "ListView3"
        Me.ListView3.Size = New System.Drawing.Size(477, 504)
        Me.ListView3.TabIndex = 4
        Me.ListView3.UseCompatibleStateImageBehavior = False
        Me.ListView3.View = System.Windows.Forms.View.List
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.chbIsFinishedGoods2)
        Me.GroupBox1.Controls.Add(Me.Label22)
        Me.GroupBox1.Controls.Add(Me.cbCategory)
        Me.GroupBox1.Controls.Add(Me.btnFilter)
        Me.GroupBox1.Controls.Add(Me.txtFilter)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.cmbFilterBy)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(635, 75)
        Me.GroupBox1.TabIndex = 74
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filter By"
        '
        'chbIsFinishedGoods2
        '
        Me.chbIsFinishedGoods2.AutoSize = True
        Me.chbIsFinishedGoods2.Location = New System.Drawing.Point(226, 50)
        Me.chbIsFinishedGoods2.Name = "chbIsFinishedGoods2"
        Me.chbIsFinishedGoods2.Size = New System.Drawing.Size(98, 17)
        Me.chbIsFinishedGoods2.TabIndex = 80
        Me.chbIsFinishedGoods2.Text = "Finished Goods"
        Me.chbIsFinishedGoods2.UseVisualStyleBackColor = True
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(5, 50)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(73, 13)
        Me.Label22.TabIndex = 79
        Me.Label22.Text = "Sub Category"
        '
        'cbCategory
        '
        Me.cbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbCategory.FormattingEnabled = True
        Me.cbCategory.Location = New System.Drawing.Point(84, 47)
        Me.cbCategory.Name = "cbCategory"
        Me.cbCategory.Size = New System.Drawing.Size(106, 21)
        Me.cbCategory.TabIndex = 76
        '
        'btnFilter
        '
        Me.btnFilter.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFilter.Location = New System.Drawing.Point(549, 47)
        Me.btnFilter.Name = "btnFilter"
        Me.btnFilter.Size = New System.Drawing.Size(75, 23)
        Me.btnFilter.TabIndex = 77
        Me.btnFilter.Text = "Filter"
        Me.btnFilter.UseVisualStyleBackColor = True
        '
        'txtFilter
        '
        Me.txtFilter.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFilter.Location = New System.Drawing.Point(226, 20)
        Me.txtFilter.MaxLength = 50
        Me.txtFilter.Name = "txtFilter"
        Me.txtFilter.Size = New System.Drawing.Size(254, 21)
        Me.txtFilter.TabIndex = 75
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(5, 23)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(46, 13)
        Me.Label6.TabIndex = 78
        Me.Label6.Text = "Filter By"
        '
        'cmbFilterBy
        '
        Me.cmbFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFilterBy.FormattingEnabled = True
        Me.cmbFilterBy.Location = New System.Drawing.Point(84, 20)
        Me.cmbFilterBy.Name = "cmbFilterBy"
        Me.cmbFilterBy.Size = New System.Drawing.Size(136, 21)
        Me.cmbFilterBy.TabIndex = 74
        '
        'frmSKU
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(1184, 618)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.lblCurrentRecord)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.ListView1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmSKU"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Product"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents txtSKUCode As System.Windows.Forms.TextBox
    Friend WithEvents txtSKUName As System.Windows.Forms.TextBox
    Friend WithEvents txtStockValue As System.Windows.Forms.TextBox
    Friend WithEvents txtStockBalance As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtLastCost As System.Windows.Forms.TextBox
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents txtSKUBarcode As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtSKURemarks As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtSKUInfo1 As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtSKUInfo2 As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtSKUInfo3 As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtAvgCost As System.Windows.Forms.TextBox
    Friend WithEvents cmbCategoryID As System.Windows.Forms.ComboBox
    Friend WithEvents ntbSalesDiscPercent As boxtree.NumericTextBox
    Friend WithEvents ntbSalesPrice As boxtree.NumericTextBox
    Friend WithEvents lblCurrentRecord As System.Windows.Forms.Label
    Friend WithEvents NumericTextBox1 As boxtree.NumericTextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents NumericTextBox2 As boxtree.NumericTextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents NumericTextBox3 As boxtree.NumericTextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents NumericTextBox4 As boxtree.NumericTextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents ListView3 As System.Windows.Forms.ListView
    Friend WithEvents chbIsFinishedGoods As System.Windows.Forms.CheckBox
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents ListView2 As System.Windows.Forms.ListView
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents ntbRawQty As boxtree.NumericTextBox
    Friend WithEvents btnAddD As System.Windows.Forms.Button
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents txtSKUName2 As System.Windows.Forms.TextBox
    Friend WithEvents txtSKUCode2 As System.Windows.Forms.TextBox
    Friend WithEvents btnSKU As System.Windows.Forms.Button
    Friend WithEvents btnDeleteD As System.Windows.Forms.Button
    Friend WithEvents btnSaveD As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents chbIsFinishedGoods2 As System.Windows.Forms.CheckBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents cbCategory As System.Windows.Forms.ComboBox
    Friend WithEvents btnFilter As System.Windows.Forms.Button
    Friend WithEvents txtFilter As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbFilterBy As System.Windows.Forms.ComboBox
    Friend WithEvents cmbUomID As System.Windows.Forms.ComboBox
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
End Class
