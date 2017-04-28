<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmWorkOrder
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmWorkOrder))
        Me.txtWOStatus = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtSONo = New System.Windows.Forms.TextBox()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.btnSONo = New System.Windows.Forms.Button()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.txtWORemarks = New System.Windows.Forms.TextBox()
        Me.dtpWODate = New System.Windows.Forms.DateTimePicker()
        Me.txtWONo = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtUomDetail = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.ntbQtyPerUnitDetail = New boxtree.NumericTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ntbCostDetail = New boxtree.NumericTextBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.txtLocationDetail = New System.Windows.Forms.TextBox()
        Me.btnLocationDetail = New System.Windows.Forms.Button()
        Me.btnSKUDetail = New System.Windows.Forms.Button()
        Me.btnAddD = New System.Windows.Forms.Button()
        Me.btnDeleteD = New System.Windows.Forms.Button()
        Me.btnSaveD = New System.Windows.Forms.Button()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.ntbQtyDetail = New boxtree.NumericTextBox()
        Me.txtSkuNameDetail = New System.Windows.Forms.TextBox()
        Me.txtSkuCodeDetail = New System.Windows.Forms.TextBox()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtUoM = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtLocationHeader = New System.Windows.Forms.TextBox()
        Me.btnLocationHeader = New System.Windows.Forms.Button()
        Me.btnSkuCodeHeader = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.ntbQtyHeader = New boxtree.NumericTextBox()
        Me.txtSkuNameHeader = New System.Windows.Forms.TextBox()
        Me.txtSkuCodeHeader = New System.Windows.Forms.TextBox()
        Me.btnConfirm = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtCustomerCode = New System.Windows.Forms.TextBox()
        Me.txtCustomerName = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtInfo1 = New System.Windows.Forms.TextBox()
        Me.lblInfo1 = New System.Windows.Forms.Label()
        Me.txtInfo2 = New System.Windows.Forms.TextBox()
        Me.lblInfo2 = New System.Windows.Forms.Label()
        Me.txtInfo3 = New System.Windows.Forms.TextBox()
        Me.lblInfo3 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.dtpWODelDate = New System.Windows.Forms.DateTimePicker()
        Me.btnConfirmOut = New System.Windows.Forms.Button()
        Me.ntbTotalQtyProduced = New boxtree.NumericTextBox()
        Me.ntbQtyOutstanding = New boxtree.NumericTextBox()
        Me.ntbQtyProduced = New boxtree.NumericTextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.cmbPeriodId = New System.Windows.Forms.ComboBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtWOStatus
        '
        Me.txtWOStatus.Location = New System.Drawing.Point(749, 15)
        Me.txtWOStatus.MaxLength = 50
        Me.txtWOStatus.Name = "txtWOStatus"
        Me.txtWOStatus.ReadOnly = True
        Me.txtWOStatus.Size = New System.Drawing.Size(153, 20)
        Me.txtWOStatus.TabIndex = 7
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(675, 18)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(37, 13)
        Me.Label14.TabIndex = 169
        Me.Label14.Text = "Status"
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "Search.png")
        Me.ImageList1.Images.SetKeyName(1, "Box.png")
        Me.ImageList1.Images.SetKeyName(2, "Remove.png")
        Me.ImageList1.Images.SetKeyName(3, "Checkmark.png")
        Me.ImageList1.Images.SetKeyName(4, "add.png")
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(303, 18)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(89, 13)
        Me.Label15.TabIndex = 143
        Me.Label15.Text = "Sales Order No. *"
        '
        'txtSONo
        '
        Me.txtSONo.Location = New System.Drawing.Point(431, 15)
        Me.txtSONo.MaxLength = 50
        Me.txtSONo.Name = "txtSONo"
        Me.txtSONo.ReadOnly = True
        Me.txtSONo.Size = New System.Drawing.Size(127, 20)
        Me.txtSONo.TabIndex = 3
        '
        'btnPrint
        '
        Me.btnPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPrint.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrint.Location = New System.Drawing.Point(822, 549)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(84, 26)
        Me.btnPrint.TabIndex = 21
        Me.btnPrint.Text = "Print"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'btnSONo
        '
        Me.btnSONo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSONo.ImageIndex = 0
        Me.btnSONo.ImageList = Me.ImageList1
        Me.btnSONo.Location = New System.Drawing.Point(565, 12)
        Me.btnSONo.Name = "btnSONo"
        Me.btnSONo.Size = New System.Drawing.Size(29, 25)
        Me.btnSONo.TabIndex = 4
        Me.btnSONo.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(609, 23)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(49, 13)
        Me.Label12.TabIndex = 139
        Me.Label12.Text = "Remarks"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(11, 46)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(88, 13)
        Me.Label7.TabIndex = 138
        Me.Label7.Text = "Work Order Date"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(11, 18)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.Size = New System.Drawing.Size(102, 13)
        Me.Label6.TabIndex = 137
        Me.Label6.Text = "Work Order No. *"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(727, 549)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(84, 26)
        Me.btnCancel.TabIndex = 20
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnEdit
        '
        Me.btnEdit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEdit.Location = New System.Drawing.Point(459, 549)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(84, 26)
        Me.btnEdit.TabIndex = 17
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.Location = New System.Drawing.Point(547, 549)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(84, 26)
        Me.btnAdd.TabIndex = 18
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.Location = New System.Drawing.Point(369, 549)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(84, 26)
        Me.btnDelete.TabIndex = 16
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Location = New System.Drawing.Point(637, 549)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(84, 26)
        Me.btnSave.TabIndex = 19
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'txtWORemarks
        '
        Me.txtWORemarks.Location = New System.Drawing.Point(612, 38)
        Me.txtWORemarks.MaxLength = 255
        Me.txtWORemarks.Multiline = True
        Me.txtWORemarks.Name = "txtWORemarks"
        Me.txtWORemarks.Size = New System.Drawing.Size(273, 47)
        Me.txtWORemarks.TabIndex = 7
        '
        'dtpWODate
        '
        Me.dtpWODate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpWODate.Location = New System.Drawing.Point(147, 41)
        Me.dtpWODate.Name = "dtpWODate"
        Me.dtpWODate.Size = New System.Drawing.Size(97, 20)
        Me.dtpWODate.TabIndex = 1
        '
        'txtWONo
        '
        Me.txtWONo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtWONo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWONo.Location = New System.Drawing.Point(147, 14)
        Me.txtWONo.MaxLength = 50
        Me.txtWONo.Name = "txtWONo"
        Me.txtWONo.Size = New System.Drawing.Size(127, 21)
        Me.txtWONo.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.txtUomDetail)
        Me.GroupBox1.Controls.Add(Me.Label22)
        Me.GroupBox1.Controls.Add(Me.Label21)
        Me.GroupBox1.Controls.Add(Me.ntbQtyPerUnitDetail)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.ntbCostDetail)
        Me.GroupBox1.Controls.Add(Me.Label31)
        Me.GroupBox1.Controls.Add(Me.txtLocationDetail)
        Me.GroupBox1.Controls.Add(Me.btnLocationDetail)
        Me.GroupBox1.Controls.Add(Me.btnSKUDetail)
        Me.GroupBox1.Controls.Add(Me.btnAddD)
        Me.GroupBox1.Controls.Add(Me.btnDeleteD)
        Me.GroupBox1.Controls.Add(Me.btnSaveD)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.ntbQtyDetail)
        Me.GroupBox1.Controls.Add(Me.txtSkuNameDetail)
        Me.GroupBox1.Controls.Add(Me.txtSkuCodeDetail)
        Me.GroupBox1.Controls.Add(Me.ListView1)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 215)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(896, 282)
        Me.GroupBox1.TabIndex = 177
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Material Requirement"
        '
        'txtUomDetail
        '
        Me.txtUomDetail.Location = New System.Drawing.Point(608, 37)
        Me.txtUomDetail.Name = "txtUomDetail"
        Me.txtUomDetail.ReadOnly = True
        Me.txtUomDetail.Size = New System.Drawing.Size(71, 20)
        Me.txtUomDetail.TabIndex = 7
        Me.txtUomDetail.TabStop = False
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(605, 22)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(30, 13)
        Me.Label22.TabIndex = 196
        Me.Label22.Text = "UoM"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(458, 23)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(45, 13)
        Me.Label21.TabIndex = 196
        Me.Label21.Text = "Unit Qty"
        '
        'ntbQtyPerUnitDetail
        '
        Me.ntbQtyPerUnitDetail.AllowSpace = False
        Me.ntbQtyPerUnitDetail.Location = New System.Drawing.Point(462, 38)
        Me.ntbQtyPerUnitDetail.MaxLength = 8
        Me.ntbQtyPerUnitDetail.Name = "ntbQtyPerUnitDetail"
        Me.ntbQtyPerUnitDetail.ReadOnly = True
        Me.ntbQtyPerUnitDetail.Size = New System.Drawing.Size(67, 20)
        Me.ntbQtyPerUnitDetail.TabIndex = 5
        Me.ntbQtyPerUnitDetail.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(682, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(28, 13)
        Me.Label1.TabIndex = 194
        Me.Label1.Text = "Cost"
        '
        'ntbCostDetail
        '
        Me.ntbCostDetail.AllowSpace = False
        Me.ntbCostDetail.Location = New System.Drawing.Point(685, 37)
        Me.ntbCostDetail.MaxLength = 8
        Me.ntbCostDetail.Name = "ntbCostDetail"
        Me.ntbCostDetail.Size = New System.Drawing.Size(100, 20)
        Me.ntbCostDetail.TabIndex = 8
        Me.ntbCostDetail.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(338, 23)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(55, 13)
        Me.Label31.TabIndex = 192
        Me.Label31.Text = "Location *"
        '
        'txtLocationDetail
        '
        Me.txtLocationDetail.Location = New System.Drawing.Point(341, 39)
        Me.txtLocationDetail.Name = "txtLocationDetail"
        Me.txtLocationDetail.ReadOnly = True
        Me.txtLocationDetail.Size = New System.Drawing.Size(80, 20)
        Me.txtLocationDetail.TabIndex = 3
        Me.txtLocationDetail.TabStop = False
        '
        'btnLocationDetail
        '
        Me.btnLocationDetail.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLocationDetail.ImageIndex = 1
        Me.btnLocationDetail.ImageList = Me.ImageList1
        Me.btnLocationDetail.Location = New System.Drawing.Point(425, 36)
        Me.btnLocationDetail.Name = "btnLocationDetail"
        Me.btnLocationDetail.Size = New System.Drawing.Size(29, 25)
        Me.btnLocationDetail.TabIndex = 4
        Me.btnLocationDetail.UseVisualStyleBackColor = True
        '
        'btnSKUDetail
        '
        Me.btnSKUDetail.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSKUDetail.ImageIndex = 1
        Me.btnSKUDetail.ImageList = Me.ImageList1
        Me.btnSKUDetail.Location = New System.Drawing.Point(91, 36)
        Me.btnSKUDetail.Name = "btnSKUDetail"
        Me.btnSKUDetail.Size = New System.Drawing.Size(29, 25)
        Me.btnSKUDetail.TabIndex = 1
        Me.btnSKUDetail.UseVisualStyleBackColor = True
        '
        'btnAddD
        '
        Me.btnAddD.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddD.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddD.ImageIndex = 4
        Me.btnAddD.ImageList = Me.ImageList1
        Me.btnAddD.Location = New System.Drawing.Point(856, 34)
        Me.btnAddD.Name = "btnAddD"
        Me.btnAddD.Size = New System.Drawing.Size(29, 25)
        Me.btnAddD.TabIndex = 11
        Me.btnAddD.UseVisualStyleBackColor = True
        '
        'btnDeleteD
        '
        Me.btnDeleteD.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDeleteD.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDeleteD.ImageIndex = 2
        Me.btnDeleteD.ImageList = Me.ImageList1
        Me.btnDeleteD.Location = New System.Drawing.Point(824, 34)
        Me.btnDeleteD.Name = "btnDeleteD"
        Me.btnDeleteD.Size = New System.Drawing.Size(29, 25)
        Me.btnDeleteD.TabIndex = 10
        Me.btnDeleteD.UseVisualStyleBackColor = True
        '
        'btnSaveD
        '
        Me.btnSaveD.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSaveD.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSaveD.ImageIndex = 3
        Me.btnSaveD.ImageList = Me.ImageList1
        Me.btnSaveD.Location = New System.Drawing.Point(793, 34)
        Me.btnSaveD.Name = "btnSaveD"
        Me.btnSaveD.Size = New System.Drawing.Size(29, 25)
        Me.btnSaveD.TabIndex = 9
        Me.btnSaveD.UseVisualStyleBackColor = True
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(531, 23)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(50, 13)
        Me.Label19.TabIndex = 180
        Me.Label19.Text = "Total Qty"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(123, 23)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(83, 13)
        Me.Label18.TabIndex = 179
        Me.Label18.Text = "Line Description"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(6, 23)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(70, 13)
        Me.Label17.TabIndex = 178
        Me.Label17.Text = "Stock Code *"
        '
        'ntbQtyDetail
        '
        Me.ntbQtyDetail.AllowSpace = False
        Me.ntbQtyDetail.Location = New System.Drawing.Point(535, 38)
        Me.ntbQtyDetail.MaxLength = 8
        Me.ntbQtyDetail.Name = "ntbQtyDetail"
        Me.ntbQtyDetail.Size = New System.Drawing.Size(67, 20)
        Me.ntbQtyDetail.TabIndex = 6
        Me.ntbQtyDetail.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSkuNameDetail
        '
        Me.txtSkuNameDetail.Location = New System.Drawing.Point(126, 39)
        Me.txtSkuNameDetail.MaxLength = 100
        Me.txtSkuNameDetail.Name = "txtSkuNameDetail"
        Me.txtSkuNameDetail.ReadOnly = True
        Me.txtSkuNameDetail.Size = New System.Drawing.Size(209, 20)
        Me.txtSkuNameDetail.TabIndex = 2
        '
        'txtSkuCodeDetail
        '
        Me.txtSkuCodeDetail.Location = New System.Drawing.Point(7, 38)
        Me.txtSkuCodeDetail.MaxLength = 50
        Me.txtSkuCodeDetail.Name = "txtSkuCodeDetail"
        Me.txtSkuCodeDetail.ReadOnly = True
        Me.txtSkuCodeDetail.Size = New System.Drawing.Size(80, 20)
        Me.txtSkuCodeDetail.TabIndex = 0
        Me.txtSkuCodeDetail.TabStop = False
        '
        'ListView1
        '
        Me.ListView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListView1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListView1.FullRowSelect = True
        Me.ListView1.GridLines = True
        Me.ListView1.Location = New System.Drawing.Point(4, 67)
        Me.ListView1.MultiSelect = False
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(881, 207)
        Me.ListView1.TabIndex = 12
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.List
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtUoM)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.txtLocationHeader)
        Me.GroupBox2.Controls.Add(Me.btnLocationHeader)
        Me.GroupBox2.Controls.Add(Me.btnSkuCodeHeader)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.ntbQtyHeader)
        Me.GroupBox2.Controls.Add(Me.txtSkuNameHeader)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.txtSkuCodeHeader)
        Me.GroupBox2.Controls.Add(Me.txtWORemarks)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 122)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(896, 91)
        Me.GroupBox2.TabIndex = 195
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Finished Goods"
        '
        'txtUoM
        '
        Me.txtUoM.Location = New System.Drawing.Point(535, 38)
        Me.txtUoM.Name = "txtUoM"
        Me.txtUoM.ReadOnly = True
        Me.txtUoM.Size = New System.Drawing.Size(71, 20)
        Me.txtUoM.TabIndex = 6
        Me.txtUoM.TabStop = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(532, 23)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(30, 13)
        Me.Label10.TabIndex = 194
        Me.Label10.Text = "UoM"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(338, 23)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 13)
        Me.Label3.TabIndex = 192
        Me.Label3.Text = "Location *"
        '
        'txtLocationHeader
        '
        Me.txtLocationHeader.Location = New System.Drawing.Point(341, 39)
        Me.txtLocationHeader.Name = "txtLocationHeader"
        Me.txtLocationHeader.ReadOnly = True
        Me.txtLocationHeader.Size = New System.Drawing.Size(80, 20)
        Me.txtLocationHeader.TabIndex = 3
        Me.txtLocationHeader.TabStop = False
        '
        'btnLocationHeader
        '
        Me.btnLocationHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLocationHeader.ImageIndex = 1
        Me.btnLocationHeader.ImageList = Me.ImageList1
        Me.btnLocationHeader.Location = New System.Drawing.Point(425, 36)
        Me.btnLocationHeader.Name = "btnLocationHeader"
        Me.btnLocationHeader.Size = New System.Drawing.Size(29, 25)
        Me.btnLocationHeader.TabIndex = 4
        Me.btnLocationHeader.UseVisualStyleBackColor = True
        '
        'btnSkuCodeHeader
        '
        Me.btnSkuCodeHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSkuCodeHeader.ImageIndex = 1
        Me.btnSkuCodeHeader.ImageList = Me.ImageList1
        Me.btnSkuCodeHeader.Location = New System.Drawing.Point(91, 36)
        Me.btnSkuCodeHeader.Name = "btnSkuCodeHeader"
        Me.btnSkuCodeHeader.Size = New System.Drawing.Size(29, 25)
        Me.btnSkuCodeHeader.TabIndex = 1
        Me.btnSkuCodeHeader.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(459, 23)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 13)
        Me.Label4.TabIndex = 180
        Me.Label4.Text = "Qty Ordered"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(123, 23)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(83, 13)
        Me.Label5.TabIndex = 179
        Me.Label5.Text = "Line Description"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 23)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(70, 13)
        Me.Label8.TabIndex = 178
        Me.Label8.Text = "Stock Code *"
        '
        'ntbQtyHeader
        '
        Me.ntbQtyHeader.AllowSpace = False
        Me.ntbQtyHeader.Location = New System.Drawing.Point(463, 38)
        Me.ntbQtyHeader.MaxLength = 8
        Me.ntbQtyHeader.Name = "ntbQtyHeader"
        Me.ntbQtyHeader.Size = New System.Drawing.Size(67, 20)
        Me.ntbQtyHeader.TabIndex = 5
        Me.ntbQtyHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSkuNameHeader
        '
        Me.txtSkuNameHeader.Location = New System.Drawing.Point(126, 39)
        Me.txtSkuNameHeader.MaxLength = 100
        Me.txtSkuNameHeader.Name = "txtSkuNameHeader"
        Me.txtSkuNameHeader.ReadOnly = True
        Me.txtSkuNameHeader.Size = New System.Drawing.Size(209, 20)
        Me.txtSkuNameHeader.TabIndex = 2
        '
        'txtSkuCodeHeader
        '
        Me.txtSkuCodeHeader.Location = New System.Drawing.Point(7, 38)
        Me.txtSkuCodeHeader.MaxLength = 50
        Me.txtSkuCodeHeader.Name = "txtSkuCodeHeader"
        Me.txtSkuCodeHeader.ReadOnly = True
        Me.txtSkuCodeHeader.Size = New System.Drawing.Size(80, 20)
        Me.txtSkuCodeHeader.TabIndex = 0
        Me.txtSkuCodeHeader.TabStop = False
        '
        'btnConfirm
        '
        Me.btnConfirm.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnConfirm.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConfirm.Location = New System.Drawing.Point(100, 549)
        Me.btnConfirm.Name = "btnConfirm"
        Me.btnConfirm.Size = New System.Drawing.Size(84, 26)
        Me.btnConfirm.TabIndex = 15
        Me.btnConfirm.Text = "Confirm In"
        Me.btnConfirm.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(11, 514)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 13)
        Me.Label2.TabIndex = 194
        Me.Label2.Text = "Qty To Produce"
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(162, 513)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(83, 13)
        Me.Label9.TabIndex = 198
        Me.Label9.Text = "Outstanding Qty"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(304, 45)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(79, 13)
        Me.Label11.TabIndex = 200
        Me.Label11.Text = "Customer Code"
        '
        'txtCustomerCode
        '
        Me.txtCustomerCode.Location = New System.Drawing.Point(431, 42)
        Me.txtCustomerCode.MaxLength = 50
        Me.txtCustomerCode.Name = "txtCustomerCode"
        Me.txtCustomerCode.ReadOnly = True
        Me.txtCustomerCode.Size = New System.Drawing.Size(127, 20)
        Me.txtCustomerCode.TabIndex = 5
        '
        'txtCustomerName
        '
        Me.txtCustomerName.Location = New System.Drawing.Point(431, 70)
        Me.txtCustomerName.MaxLength = 255
        Me.txtCustomerName.Name = "txtCustomerName"
        Me.txtCustomerName.ReadOnly = True
        Me.txtCustomerName.Size = New System.Drawing.Size(163, 20)
        Me.txtCustomerName.TabIndex = 6
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(11, 73)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(76, 13)
        Me.Label13.TabIndex = 203
        Me.Label13.Text = "Required Date"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(304, 73)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(82, 13)
        Me.Label16.TabIndex = 204
        Me.Label16.Text = "Customer Name"
        '
        'txtInfo1
        '
        Me.txtInfo1.Location = New System.Drawing.Point(749, 41)
        Me.txtInfo1.MaxLength = 255
        Me.txtInfo1.Name = "txtInfo1"
        Me.txtInfo1.Size = New System.Drawing.Size(153, 20)
        Me.txtInfo1.TabIndex = 8
        '
        'lblInfo1
        '
        Me.lblInfo1.AutoSize = True
        Me.lblInfo1.Location = New System.Drawing.Point(675, 47)
        Me.lblInfo1.Name = "lblInfo1"
        Me.lblInfo1.Size = New System.Drawing.Size(48, 13)
        Me.lblInfo1.TabIndex = 205
        Me.lblInfo1.Text = "Machine"
        '
        'txtInfo2
        '
        Me.txtInfo2.Location = New System.Drawing.Point(749, 69)
        Me.txtInfo2.MaxLength = 255
        Me.txtInfo2.Name = "txtInfo2"
        Me.txtInfo2.Size = New System.Drawing.Size(153, 20)
        Me.txtInfo2.TabIndex = 9
        '
        'lblInfo2
        '
        Me.lblInfo2.AutoSize = True
        Me.lblInfo2.Location = New System.Drawing.Point(675, 73)
        Me.lblInfo2.Name = "lblInfo2"
        Me.lblInfo2.Size = New System.Drawing.Size(71, 13)
        Me.lblInfo2.TabIndex = 207
        Me.lblInfo2.Text = "Time Process"
        '
        'txtInfo3
        '
        Me.txtInfo3.Location = New System.Drawing.Point(749, 97)
        Me.txtInfo3.MaxLength = 255
        Me.txtInfo3.Name = "txtInfo3"
        Me.txtInfo3.Size = New System.Drawing.Size(153, 20)
        Me.txtInfo3.TabIndex = 10
        '
        'lblInfo3
        '
        Me.lblInfo3.AutoSize = True
        Me.lblInfo3.Location = New System.Drawing.Point(675, 102)
        Me.lblInfo3.Name = "lblInfo3"
        Me.lblInfo3.Size = New System.Drawing.Size(68, 13)
        Me.lblInfo3.TabIndex = 209
        Me.lblInfo3.Text = "Specification"
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(723, 510)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 213
        Me.Button3.Text = "Total Cost"
        Me.Button3.UseVisualStyleBackColor = True
        Me.Button3.Visible = False
        '
        'Label20
        '
        Me.Label20.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(322, 513)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(99, 13)
        Me.Label20.TabIndex = 216
        Me.Label20.Text = "Total Qty Produced"
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(804, 510)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(75, 23)
        Me.Button4.TabIndex = 217
        Me.Button4.Text = "Unit Cost"
        Me.Button4.UseVisualStyleBackColor = True
        Me.Button4.Visible = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(645, 509)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 218
        Me.Button1.Text = "Detail"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(565, 509)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 219
        Me.Button2.Text = "Header"
        Me.Button2.UseVisualStyleBackColor = True
        Me.Button2.Visible = False
        '
        'dtpWODelDate
        '
        Me.dtpWODelDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpWODelDate.Location = New System.Drawing.Point(147, 67)
        Me.dtpWODelDate.Name = "dtpWODelDate"
        Me.dtpWODelDate.Size = New System.Drawing.Size(97, 20)
        Me.dtpWODelDate.TabIndex = 2
        '
        'btnConfirmOut
        '
        Me.btnConfirmOut.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnConfirmOut.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConfirmOut.Location = New System.Drawing.Point(9, 549)
        Me.btnConfirmOut.Name = "btnConfirmOut"
        Me.btnConfirmOut.Size = New System.Drawing.Size(84, 26)
        Me.btnConfirmOut.TabIndex = 14
        Me.btnConfirmOut.Text = "Confirm Out"
        Me.btnConfirmOut.UseVisualStyleBackColor = True
        '
        'ntbTotalQtyProduced
        '
        Me.ntbTotalQtyProduced.AllowSpace = False
        Me.ntbTotalQtyProduced.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ntbTotalQtyProduced.Location = New System.Drawing.Point(424, 509)
        Me.ntbTotalQtyProduced.MaxLength = 8
        Me.ntbTotalQtyProduced.Name = "ntbTotalQtyProduced"
        Me.ntbTotalQtyProduced.ReadOnly = True
        Me.ntbTotalQtyProduced.Size = New System.Drawing.Size(60, 20)
        Me.ntbTotalQtyProduced.TabIndex = 13
        Me.ntbTotalQtyProduced.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ntbQtyOutstanding
        '
        Me.ntbQtyOutstanding.AllowSpace = False
        Me.ntbQtyOutstanding.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ntbQtyOutstanding.Location = New System.Drawing.Point(248, 509)
        Me.ntbQtyOutstanding.MaxLength = 8
        Me.ntbQtyOutstanding.Name = "ntbQtyOutstanding"
        Me.ntbQtyOutstanding.ReadOnly = True
        Me.ntbQtyOutstanding.Size = New System.Drawing.Size(60, 20)
        Me.ntbQtyOutstanding.TabIndex = 12
        Me.ntbQtyOutstanding.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ntbQtyProduced
        '
        Me.ntbQtyProduced.AllowSpace = False
        Me.ntbQtyProduced.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ntbQtyProduced.Location = New System.Drawing.Point(97, 510)
        Me.ntbQtyProduced.MaxLength = 8
        Me.ntbQtyProduced.Name = "ntbQtyProduced"
        Me.ntbQtyProduced.Size = New System.Drawing.Size(60, 20)
        Me.ntbQtyProduced.TabIndex = 11
        Me.ntbQtyProduced.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(12, 97)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(37, 13)
        Me.Label23.TabIndex = 221
        Me.Label23.Text = "Period"
        '
        'cmbPeriodId
        '
        Me.cmbPeriodId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPeriodId.Enabled = False
        Me.cmbPeriodId.FormattingEnabled = True
        Me.cmbPeriodId.Location = New System.Drawing.Point(148, 91)
        Me.cmbPeriodId.Name = "cmbPeriodId"
        Me.cmbPeriodId.Size = New System.Drawing.Size(97, 21)
        Me.cmbPeriodId.TabIndex = 220
        '
        'frmWorkOrder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(915, 582)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.cmbPeriodId)
        Me.Controls.Add(Me.btnConfirmOut)
        Me.Controls.Add(Me.dtpWODelDate)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.ntbTotalQtyProduced)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.txtInfo3)
        Me.Controls.Add(Me.lblInfo3)
        Me.Controls.Add(Me.txtInfo2)
        Me.Controls.Add(Me.lblInfo2)
        Me.Controls.Add(Me.txtInfo1)
        Me.Controls.Add(Me.lblInfo1)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.txtCustomerName)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtCustomerCode)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.ntbQtyOutstanding)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnConfirm)
        Me.Controls.Add(Me.ntbQtyProduced)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.txtWOStatus)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.txtSONo)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.btnSONo)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.dtpWODate)
        Me.Controls.Add(Me.txtWONo)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmWorkOrder"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Work Order - BETA"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtWOStatus As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtSONo As System.Windows.Forms.TextBox
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents btnSONo As System.Windows.Forms.Button
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents txtWORemarks As System.Windows.Forms.TextBox
    Friend WithEvents dtpWODate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtWONo As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ntbCostDetail As boxtree.NumericTextBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents txtLocationDetail As System.Windows.Forms.TextBox
    Friend WithEvents btnLocationDetail As System.Windows.Forms.Button
    Friend WithEvents btnSKUDetail As System.Windows.Forms.Button
    Friend WithEvents btnAddD As System.Windows.Forms.Button
    Friend WithEvents btnDeleteD As System.Windows.Forms.Button
    Friend WithEvents btnSaveD As System.Windows.Forms.Button
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents ntbQtyDetail As boxtree.NumericTextBox
    Friend WithEvents txtSkuNameDetail As System.Windows.Forms.TextBox
    Friend WithEvents txtSkuCodeDetail As System.Windows.Forms.TextBox
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtLocationHeader As System.Windows.Forms.TextBox
    Friend WithEvents btnLocationHeader As System.Windows.Forms.Button
    Friend WithEvents btnSkuCodeHeader As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents ntbQtyHeader As boxtree.NumericTextBox
    Friend WithEvents txtSkuNameHeader As System.Windows.Forms.TextBox
    Friend WithEvents txtSkuCodeHeader As System.Windows.Forms.TextBox
    Friend WithEvents btnConfirm As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ntbQtyProduced As boxtree.NumericTextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents ntbQtyOutstanding As boxtree.NumericTextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtUoM As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtCustomerCode As System.Windows.Forms.TextBox
    Friend WithEvents txtCustomerName As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtInfo1 As System.Windows.Forms.TextBox
    Friend WithEvents lblInfo1 As System.Windows.Forms.Label
    Friend WithEvents txtInfo2 As System.Windows.Forms.TextBox
    Friend WithEvents lblInfo2 As System.Windows.Forms.Label
    Friend WithEvents txtInfo3 As System.Windows.Forms.TextBox
    Friend WithEvents lblInfo3 As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents ntbTotalQtyProduced As boxtree.NumericTextBox
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents ntbQtyPerUnitDetail As boxtree.NumericTextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents txtUomDetail As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents dtpWODelDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnConfirmOut As System.Windows.Forms.Button
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents cmbPeriodId As System.Windows.Forms.ComboBox
End Class
