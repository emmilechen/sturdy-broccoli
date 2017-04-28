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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSYSSetting))
        Me.Label12 = New System.Windows.Forms.Label()
        Me.chbStockMinusSetting = New System.Windows.Forms.CheckBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbAllowBankMinus = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ntbTaxPercent = New boxtree.NumericTextBox()
        Me.cbDecimal = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbFirstFiscalMonth = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(12, 129)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(131, 13)
        Me.Label12.TabIndex = 35
        Me.Label12.Text = "Allow Minus Stock Balance"
        '
        'chbStockMinusSetting
        '
        Me.chbStockMinusSetting.AutoSize = True
        Me.chbStockMinusSetting.Location = New System.Drawing.Point(165, 129)
        Me.chbStockMinusSetting.Name = "chbStockMinusSetting"
        Me.chbStockMinusSetting.Size = New System.Drawing.Size(15, 14)
        Me.chbStockMinusSetting.TabIndex = 2
        Me.chbStockMinusSetting.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(12, 67)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(84, 13)
        Me.Label9.TabIndex = 33
        Me.Label9.Text = "Tax Setting (%)"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(206, 9)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(197, 19)
        Me.Label8.TabIndex = 164
        Me.Label8.Text = "Background Parameter"
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.Location = New System.Drawing.Point(324, 260)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 6
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Location = New System.Drawing.Point(243, 260)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 5
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 156)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(128, 13)
        Me.Label1.TabIndex = 168
        Me.Label1.Text = "Allow Minus Bank Balance"
        '
        'cbAllowBankMinus
        '
        Me.cbAllowBankMinus.AutoSize = True
        Me.cbAllowBankMinus.Location = New System.Drawing.Point(165, 156)
        Me.cbAllowBankMinus.Name = "cbAllowBankMinus"
        Me.cbAllowBankMinus.Size = New System.Drawing.Size(15, 14)
        Me.cbAllowBankMinus.TabIndex = 3
        Me.cbAllowBankMinus.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 99)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(109, 13)
        Me.Label2.TabIndex = 170
        Me.Label2.Text = "Decimal digit for price"
        '
        'ntbTaxPercent
        '
        Me.ntbTaxPercent.AllowSpace = False
        Me.ntbTaxPercent.Location = New System.Drawing.Point(165, 64)
        Me.ntbTaxPercent.MaxLength = 3
        Me.ntbTaxPercent.Name = "ntbTaxPercent"
        Me.ntbTaxPercent.Size = New System.Drawing.Size(55, 20)
        Me.ntbTaxPercent.TabIndex = 0
        Me.ntbTaxPercent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cbDecimal
        '
        Me.cbDecimal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbDecimal.FormattingEnabled = True
        Me.cbDecimal.Location = New System.Drawing.Point(165, 97)
        Me.cbDecimal.Name = "cbDecimal"
        Me.cbDecimal.Size = New System.Drawing.Size(55, 21)
        Me.cbDecimal.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 184)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(90, 13)
        Me.Label3.TabIndex = 173
        Me.Label3.Text = "First Fiscal Month"
        '
        'cmbFirstFiscalMonth
        '
        Me.cmbFirstFiscalMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFirstFiscalMonth.FormattingEnabled = True
        Me.cmbFirstFiscalMonth.Location = New System.Drawing.Point(165, 181)
        Me.cmbFirstFiscalMonth.Name = "cmbFirstFiscalMonth"
        Me.cmbFirstFiscalMonth.Size = New System.Drawing.Size(110, 21)
        Me.cmbFirstFiscalMonth.TabIndex = 4
        '
        'frmSYSSetting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(411, 295)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cmbFirstFiscalMonth)
        Me.Controls.Add(Me.cbDecimal)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cbAllowBankMinus)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.chbStockMinusSetting)
        Me.Controls.Add(Me.ntbTaxPercent)
        Me.Controls.Add(Me.Label9)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmSYSSetting"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Background Parameter"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents chbStockMinusSetting As System.Windows.Forms.CheckBox
    Friend WithEvents ntbTaxPercent As boxtree.NumericTextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbAllowBankMinus As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbDecimal As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbFirstFiscalMonth As System.Windows.Forms.ComboBox
End Class
