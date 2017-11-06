<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSYSSetting
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSYSSetting))
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage7 = New System.Windows.Forms.TabPage()
        Me.txtguid = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbFirstFiscalMonth = New System.Windows.Forms.ComboBox()
        Me.cbDecimal = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TabPage6 = New System.Windows.Forms.TabPage()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.btnAddD = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.btnDeleteD = New System.Windows.Forms.Button()
        Me.btnSaveD = New System.Windows.Forms.Button()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.ListView2 = New System.Windows.Forms.ListView()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.TextBox6 = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.ComboBox3 = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.chbStockMinusSetting = New System.Windows.Forms.CheckBox()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbAllowBankMinus = New System.Windows.Forms.CheckBox()
        Me.TabPage8 = New System.Windows.Forms.TabPage()
        Me.ntbTaxPercent = New boxtree.NumericTextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.btnfind = New System.Windows.Forms.ToolStripButton()
        Me.btncancel = New System.Windows.Forms.ToolStripButton()
        Me.btndelete = New System.Windows.Forms.ToolStripButton()
        Me.btnnew = New System.Windows.Forms.ToolStripButton()
        Me.btnexit = New System.Windows.Forms.ToolStripButton()
        Me.TabControl1.SuspendLayout()
        Me.TabPage7.SuspendLayout()
        Me.TabPage6.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.TabPage5.SuspendLayout()
        Me.TabPage8.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage7)
        Me.TabControl1.Controls.Add(Me.TabPage6)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Controls.Add(Me.TabPage5)
        Me.TabControl1.Controls.Add(Me.TabPage8)
        Me.TabControl1.Location = New System.Drawing.Point(16, 32)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1240, 480)
        Me.TabControl1.TabIndex = 174
        '
        'TabPage7
        '
        Me.TabPage7.Controls.Add(Me.txtguid)
        Me.TabPage7.Controls.Add(Me.Label5)
        Me.TabPage7.Controls.Add(Me.Label4)
        Me.TabPage7.Controls.Add(Me.Button2)
        Me.TabPage7.Controls.Add(Me.Button1)
        Me.TabPage7.Controls.Add(Me.TextBox2)
        Me.TabPage7.Controls.Add(Me.TextBox1)
        Me.TabPage7.Controls.Add(Me.Label3)
        Me.TabPage7.Controls.Add(Me.cmbFirstFiscalMonth)
        Me.TabPage7.Controls.Add(Me.cbDecimal)
        Me.TabPage7.Controls.Add(Me.Label2)
        Me.TabPage7.Location = New System.Drawing.Point(4, 22)
        Me.TabPage7.Name = "TabPage7"
        Me.TabPage7.Size = New System.Drawing.Size(1232, 454)
        Me.TabPage7.TabIndex = 6
        Me.TabPage7.Text = "General"
        Me.TabPage7.UseVisualStyleBackColor = True
        '
        'txtguid
        '
        Me.txtguid.Location = New System.Drawing.Point(500, 217)
        Me.txtguid.Name = "txtguid"
        Me.txtguid.Size = New System.Drawing.Size(232, 20)
        Me.txtguid.TabIndex = 182
        Me.txtguid.Tag = ""
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(16, 104)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(83, 13)
        Me.Label5.TabIndex = 181
        Me.Label5.Text = "Picture Location"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(16, 72)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(98, 13)
        Me.Label4.TabIndex = 180
        Me.Label4.Text = "Document Location"
        '
        'Button2
        '
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.Location = New System.Drawing.Point(408, 100)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(40, 24)
        Me.Button2.TabIndex = 179
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(408, 67)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(40, 24)
        Me.Button1.TabIndex = 178
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(168, 104)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(232, 20)
        Me.TextBox2.TabIndex = 177
        Me.TextBox2.Tag = "gen_pic_loc"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(168, 72)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(232, 20)
        Me.TextBox1.TabIndex = 176
        Me.TextBox1.Tag = "gen_doc_loc"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(15, 43)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(90, 13)
        Me.Label3.TabIndex = 175
        Me.Label3.Text = "First Fiscal Month"
        '
        'cmbFirstFiscalMonth
        '
        Me.cmbFirstFiscalMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFirstFiscalMonth.FormattingEnabled = True
        Me.cmbFirstFiscalMonth.Location = New System.Drawing.Point(168, 40)
        Me.cmbFirstFiscalMonth.Name = "cmbFirstFiscalMonth"
        Me.cmbFirstFiscalMonth.Size = New System.Drawing.Size(110, 21)
        Me.cmbFirstFiscalMonth.TabIndex = 174
        Me.cmbFirstFiscalMonth.Tag = "first_fiscal_month"
        '
        'cbDecimal
        '
        Me.cbDecimal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbDecimal.FormattingEnabled = True
        Me.cbDecimal.Location = New System.Drawing.Point(168, 16)
        Me.cbDecimal.Name = "cbDecimal"
        Me.cbDecimal.Size = New System.Drawing.Size(55, 21)
        Me.cbDecimal.TabIndex = 171
        Me.cbDecimal.Tag = "decimal_digit"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(16, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(109, 13)
        Me.Label2.TabIndex = 172
        Me.Label2.Text = "Decimal digit for price"
        '
        'TabPage6
        '
        Me.TabPage6.Controls.Add(Me.Label10)
        Me.TabPage6.Controls.Add(Me.TextBox4)
        Me.TabPage6.Location = New System.Drawing.Point(4, 22)
        Me.TabPage6.Name = "TabPage6"
        Me.TabPage6.Size = New System.Drawing.Size(1232, 454)
        Me.TabPage6.TabIndex = 5
        Me.TabPage6.Text = "User"
        Me.TabPage6.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(16, 16)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(116, 13)
        Me.Label10.TabIndex = 182
        Me.Label10.Text = "Default User Password"
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(168, 16)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(232, 20)
        Me.TextBox4.TabIndex = 181
        Me.TextBox4.Tag = "user_def_pwd"
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.ListView1)
        Me.TabPage1.Controls.Add(Me.Label13)
        Me.TabPage1.Controls.Add(Me.btnAddD)
        Me.TabPage1.Controls.Add(Me.btnDeleteD)
        Me.TabPage1.Controls.Add(Me.btnSaveD)
        Me.TabPage1.Controls.Add(Me.TextBox5)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.ComboBox1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1232, 454)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Purchase"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'ListView1
        '
        Me.ListView1.FullRowSelect = True
        Me.ListView1.GridLines = True
        Me.ListView1.Location = New System.Drawing.Point(240, 72)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(360, 176)
        Me.ListView1.TabIndex = 11
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(16, 48)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(217, 13)
        Me.Label13.TabIndex = 10
        Me.Label13.Tag = "purchase_doc_rcpt_inv"
        Me.Label13.Text = "Document Receipt Checklist when Invoicing"
        '
        'btnAddD
        '
        Me.btnAddD.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddD.ImageIndex = 0
        Me.btnAddD.ImageList = Me.ImageList1
        Me.btnAddD.Location = New System.Drawing.Point(568, 41)
        Me.btnAddD.Name = "btnAddD"
        Me.btnAddD.Size = New System.Drawing.Size(29, 25)
        Me.btnAddD.TabIndex = 9
        Me.btnAddD.UseVisualStyleBackColor = True
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "add.png")
        Me.ImageList1.Images.SetKeyName(1, "Checkmark.png")
        Me.ImageList1.Images.SetKeyName(2, "Remove.png")
        Me.ImageList1.Images.SetKeyName(3, "Search.png")
        '
        'btnDeleteD
        '
        Me.btnDeleteD.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDeleteD.ImageIndex = 2
        Me.btnDeleteD.ImageList = Me.ImageList1
        Me.btnDeleteD.Location = New System.Drawing.Point(537, 41)
        Me.btnDeleteD.Name = "btnDeleteD"
        Me.btnDeleteD.Size = New System.Drawing.Size(29, 25)
        Me.btnDeleteD.TabIndex = 8
        Me.btnDeleteD.UseVisualStyleBackColor = True
        '
        'btnSaveD
        '
        Me.btnSaveD.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSaveD.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSaveD.ImageIndex = 1
        Me.btnSaveD.ImageList = Me.ImageList1
        Me.btnSaveD.Location = New System.Drawing.Point(505, 41)
        Me.btnSaveD.Name = "btnSaveD"
        Me.btnSaveD.Size = New System.Drawing.Size(29, 25)
        Me.btnSaveD.TabIndex = 7
        Me.btnSaveD.UseVisualStyleBackColor = True
        '
        'TextBox5
        '
        Me.TextBox5.Location = New System.Drawing.Point(240, 48)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(256, 20)
        Me.TextBox5.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(16, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(190, 13)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Default A/C No. on Purchase Payment"
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(240, 16)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(176, 21)
        Me.ComboBox1.TabIndex = 0
        Me.ComboBox1.Tag = "purchase_def_ac"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.ListView2)
        Me.TabPage2.Controls.Add(Me.Label14)
        Me.TabPage2.Controls.Add(Me.Button3)
        Me.TabPage2.Controls.Add(Me.Button4)
        Me.TabPage2.Controls.Add(Me.Button5)
        Me.TabPage2.Controls.Add(Me.TextBox6)
        Me.TabPage2.Controls.Add(Me.Label11)
        Me.TabPage2.Controls.Add(Me.TextBox3)
        Me.TabPage2.Controls.Add(Me.Label8)
        Me.TabPage2.Controls.Add(Me.ComboBox3)
        Me.TabPage2.Controls.Add(Me.Label7)
        Me.TabPage2.Controls.Add(Me.ComboBox2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1232, 454)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Sales"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'ListView2
        '
        Me.ListView2.FullRowSelect = True
        Me.ListView2.GridLines = True
        Me.ListView2.Location = New System.Drawing.Point(240, 136)
        Me.ListView2.Name = "ListView2"
        Me.ListView2.Size = New System.Drawing.Size(360, 176)
        Me.ListView2.TabIndex = 190
        Me.ListView2.UseCompatibleStateImageBehavior = False
        Me.ListView2.View = System.Windows.Forms.View.Details
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(16, 112)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(217, 13)
        Me.Label14.TabIndex = 189
        Me.Label14.Tag = "sales_doc_rcpt_inv"
        Me.Label14.Text = "Document Receipt Checklist when Invoicing"
        '
        'Button3
        '
        Me.Button3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ImageIndex = 0
        Me.Button3.ImageList = Me.ImageList1
        Me.Button3.Location = New System.Drawing.Point(568, 105)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(29, 25)
        Me.Button3.TabIndex = 188
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.ImageIndex = 2
        Me.Button4.ImageList = Me.ImageList1
        Me.Button4.Location = New System.Drawing.Point(537, 105)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(29, 25)
        Me.Button4.TabIndex = 187
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button5.ImageIndex = 1
        Me.Button5.ImageList = Me.ImageList1
        Me.Button5.Location = New System.Drawing.Point(505, 105)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(29, 25)
        Me.Button5.TabIndex = 186
        Me.Button5.UseVisualStyleBackColor = True
        '
        'TextBox6
        '
        Me.TextBox6.Location = New System.Drawing.Point(240, 112)
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Size = New System.Drawing.Size(256, 20)
        Me.TextBox6.TabIndex = 185
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(16, 80)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(189, 13)
        Me.Label11.TabIndex = 184
        Me.Label11.Text = "Maximum Validity on Quotation (Days)"
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(240, 80)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(176, 20)
        Me.TextBox3.TabIndex = 183
        Me.TextBox3.Tag = "sales_max_validso"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(16, 48)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(205, 13)
        Me.Label8.TabIndex = 5
        Me.Label8.Text = "Allow Over Credit Limit on Sales Quotation"
        '
        'ComboBox3
        '
        Me.ComboBox3.FormattingEnabled = True
        Me.ComboBox3.Location = New System.Drawing.Point(240, 48)
        Me.ComboBox3.Name = "ComboBox3"
        Me.ComboBox3.Size = New System.Drawing.Size(176, 21)
        Me.ComboBox3.TabIndex = 4
        Me.ComboBox3.Tag = "sales_allow_overlimit"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(16, 16)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(171, 13)
        Me.Label7.TabIndex = 3
        Me.Label7.Text = "Default A/C No. on Sales Payment"
        '
        'ComboBox2
        '
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Location = New System.Drawing.Point(240, 16)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(176, 21)
        Me.ComboBox2.TabIndex = 2
        Me.ComboBox2.Tag = "sales_def_ac"
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.Label12)
        Me.TabPage3.Controls.Add(Me.chbStockMinusSetting)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(1232, 454)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Inventory"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(16, 16)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(131, 13)
        Me.Label12.TabIndex = 37
        Me.Label12.Text = "Allow Minus Stock Balance"
        '
        'chbStockMinusSetting
        '
        Me.chbStockMinusSetting.AutoSize = True
        Me.chbStockMinusSetting.Location = New System.Drawing.Point(169, 16)
        Me.chbStockMinusSetting.Name = "chbStockMinusSetting"
        Me.chbStockMinusSetting.Size = New System.Drawing.Size(15, 14)
        Me.chbStockMinusSetting.TabIndex = 36
        Me.chbStockMinusSetting.Tag = "sku_qty_minus"
        Me.chbStockMinusSetting.UseVisualStyleBackColor = True
        '
        'TabPage4
        '
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(1232, 454)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Production"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'TabPage5
        '
        Me.TabPage5.Controls.Add(Me.Label1)
        Me.TabPage5.Controls.Add(Me.cbAllowBankMinus)
        Me.TabPage5.Location = New System.Drawing.Point(4, 22)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Size = New System.Drawing.Size(1232, 454)
        Me.TabPage5.TabIndex = 4
        Me.TabPage5.Text = "GL"
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(128, 13)
        Me.Label1.TabIndex = 170
        Me.Label1.Text = "Allow Minus Bank Balance"
        '
        'cbAllowBankMinus
        '
        Me.cbAllowBankMinus.AutoSize = True
        Me.cbAllowBankMinus.Location = New System.Drawing.Point(169, 16)
        Me.cbAllowBankMinus.Name = "cbAllowBankMinus"
        Me.cbAllowBankMinus.Size = New System.Drawing.Size(15, 14)
        Me.cbAllowBankMinus.TabIndex = 169
        Me.cbAllowBankMinus.Tag = "bank_amount_minus"
        Me.cbAllowBankMinus.UseVisualStyleBackColor = True
        '
        'TabPage8
        '
        Me.TabPage8.Controls.Add(Me.ntbTaxPercent)
        Me.TabPage8.Controls.Add(Me.Label9)
        Me.TabPage8.Location = New System.Drawing.Point(4, 22)
        Me.TabPage8.Name = "TabPage8"
        Me.TabPage8.Size = New System.Drawing.Size(1232, 454)
        Me.TabPage8.TabIndex = 7
        Me.TabPage8.Text = "Taxes"
        Me.TabPage8.UseVisualStyleBackColor = True
        '
        'ntbTaxPercent
        '
        Me.ntbTaxPercent.AllowSpace = False
        Me.ntbTaxPercent.Location = New System.Drawing.Point(176, 16)
        Me.ntbTaxPercent.MaxLength = 3
        Me.ntbTaxPercent.Name = "ntbTaxPercent"
        Me.ntbTaxPercent.Size = New System.Drawing.Size(55, 20)
        Me.ntbTaxPercent.TabIndex = 34
        Me.ntbTaxPercent.Tag = "tax_percent"
        Me.ntbTaxPercent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(16, 16)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(84, 13)
        Me.Label9.TabIndex = 35
        Me.Label9.Text = "Tax Setting (%)"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.btnfind, Me.btncancel, Me.btndelete, Me.btnnew, Me.btnexit})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1264, 25)
        Me.ToolStrip1.TabIndex = 175
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(60, 22)
        Me.ToolStripButton1.Text = "&Save"
        '
        'btnfind
        '
        Me.btnfind.Enabled = False
        Me.btnfind.Image = CType(resources.GetObject("btnfind.Image"), System.Drawing.Image)
        Me.btnfind.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnfind.Name = "btnfind"
        Me.btnfind.Size = New System.Drawing.Size(53, 22)
        Me.btnfind.Text = "&Find"
        '
        'btncancel
        '
        Me.btncancel.Enabled = False
        Me.btncancel.Image = CType(resources.GetObject("btncancel.Image"), System.Drawing.Image)
        Me.btncancel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btncancel.Name = "btncancel"
        Me.btncancel.Size = New System.Drawing.Size(70, 22)
        Me.btncancel.Text = "&Cancel"
        '
        'btndelete
        '
        Me.btndelete.Enabled = False
        Me.btndelete.Image = CType(resources.GetObject("btndelete.Image"), System.Drawing.Image)
        Me.btndelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btndelete.Name = "btndelete"
        Me.btndelete.Size = New System.Drawing.Size(70, 22)
        Me.btndelete.Text = "&Delete"
        '
        'btnnew
        '
        Me.btnnew.Enabled = False
        Me.btnnew.Image = CType(resources.GetObject("btnnew.Image"), System.Drawing.Image)
        Me.btnnew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnnew.Name = "btnnew"
        Me.btnnew.Size = New System.Drawing.Size(55, 22)
        Me.btnnew.Text = "&New"
        '
        'btnexit
        '
        Me.btnexit.Image = CType(resources.GetObject("btnexit.Image"), System.Drawing.Image)
        Me.btnexit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnexit.Name = "btnexit"
        Me.btnexit.Size = New System.Drawing.Size(51, 22)
        Me.btnexit.Text = "&Exit"
        '
        'frmSYSSetting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1264, 561)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.TabControl1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmSYSSetting"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Background Parameter"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage7.ResumeLayout(False)
        Me.TabPage7.PerformLayout()
        Me.TabPage6.ResumeLayout(False)
        Me.TabPage6.PerformLayout()
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.TabPage5.ResumeLayout(False)
        Me.TabPage5.PerformLayout()
        Me.TabPage8.ResumeLayout(False)
        Me.TabPage8.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage7 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage6 As System.Windows.Forms.TabPage
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbFirstFiscalMonth As System.Windows.Forms.ComboBox
    Friend WithEvents cbDecimal As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents chbStockMinusSetting As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbAllowBankMinus As System.Windows.Forms.CheckBox
    Friend WithEvents TabPage8 As System.Windows.Forms.TabPage
    Friend WithEvents ntbTaxPercent As boxtree.NumericTextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents ComboBox3 As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnfind As System.Windows.Forms.ToolStripButton
    Friend WithEvents btncancel As System.Windows.Forms.ToolStripButton
    Friend WithEvents btndelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnnew As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnexit As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents txtguid As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents btnAddD As System.Windows.Forms.Button
    Friend WithEvents btnDeleteD As System.Windows.Forms.Button
    Friend WithEvents btnSaveD As System.Windows.Forms.Button
    Friend WithEvents ListView2 As System.Windows.Forms.ListView
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents TextBox6 As System.Windows.Forms.TextBox
End Class
