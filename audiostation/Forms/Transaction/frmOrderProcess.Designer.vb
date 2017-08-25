<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOrderProcess
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOrderProcess))
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCCode = New System.Windows.Forms.TextBox()
        Me.txtCName = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtSKUCode = New System.Windows.Forms.TextBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.dtpSODate = New System.Windows.Forms.DateTimePicker()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TextBox6 = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TextBox10 = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TextBox9 = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TextBox8 = New System.Windows.Forms.TextBox()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TextBox12 = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TextBox11 = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TextBox7 = New System.Windows.Forms.TextBox()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.cmdsave = New System.Windows.Forms.ToolStripButton()
        Me.cmdfind = New System.Windows.Forms.ToolStripButton()
        Me.cmdcancel = New System.Windows.Forms.ToolStripButton()
        Me.cmddelete = New System.Windows.Forms.ToolStripButton()
        Me.cmdnew = New System.Windows.Forms.ToolStripButton()
        Me.cmdexit = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmdprint = New System.Windows.Forms.ToolStripButton()
        Me.TextBox13 = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(19, 75)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(83, 13)
        Me.Label23.TabIndex = 71
        Me.Label23.Text = "Customer Name"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(19, 49)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 13)
        Me.Label1.TabIndex = 70
        Me.Label1.Text = "Customer Code"
        '
        'txtCCode
        '
        Me.txtCCode.Location = New System.Drawing.Point(113, 44)
        Me.txtCCode.Name = "txtCCode"
        Me.txtCCode.ReadOnly = True
        Me.txtCCode.Size = New System.Drawing.Size(80, 21)
        Me.txtCCode.TabIndex = 67
        Me.txtCCode.TabStop = False
        '
        'txtCName
        '
        Me.txtCName.Location = New System.Drawing.Point(113, 72)
        Me.txtCName.Name = "txtCName"
        Me.txtCName.ReadOnly = True
        Me.txtCName.Size = New System.Drawing.Size(217, 21)
        Me.txtCName.TabIndex = 69
        Me.txtCName.TabStop = False
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(19, 129)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(26, 13)
        Me.Label18.TabIndex = 75
        Me.Label18.Text = "SKU"
        '
        'txtSKUCode
        '
        Me.txtSKUCode.Location = New System.Drawing.Point(113, 126)
        Me.txtSKUCode.MaxLength = 50
        Me.txtSKUCode.Name = "txtSKUCode"
        Me.txtSKUCode.ReadOnly = True
        Me.txtSKUCode.Size = New System.Drawing.Size(70, 21)
        Me.txtSKUCode.TabIndex = 72
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(189, 126)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(217, 21)
        Me.TextBox1.TabIndex = 77
        Me.TextBox1.TabStop = False
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Location = New System.Drawing.Point(23, 166)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(806, 323)
        Me.TabControl1.TabIndex = 78
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.dtpSODate)
        Me.TabPage1.Controls.Add(Me.Label7)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.TextBox6)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.TextBox5)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.TextBox4)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.TextBox3)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.TextBox2)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(798, 297)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Preparation1"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'dtpSODate
        '
        Me.dtpSODate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpSODate.Location = New System.Drawing.Point(453, 102)
        Me.dtpSODate.Name = "dtpSODate"
        Me.dtpSODate.Size = New System.Drawing.Size(97, 21)
        Me.dtpSODate.TabIndex = 82
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(362, 102)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(46, 13)
        Me.Label7.TabIndex = 81
        Me.Label7.Text = "On date"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 102)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(40, 13)
        Me.Label6.TabIndex = 79
        Me.Label6.Text = "Others"
        '
        'TextBox6
        '
        Me.TextBox6.Location = New System.Drawing.Point(145, 99)
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Size = New System.Drawing.Size(126, 21)
        Me.TextBox6.TabIndex = 78
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(362, 75)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(55, 13)
        Me.Label5.TabIndex = 77
        Me.Label5.Text = "Consist of"
        '
        'TextBox5
        '
        Me.TextBox5.Location = New System.Drawing.Point(453, 75)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(126, 21)
        Me.TextBox5.TabIndex = 76
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(11, 75)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(128, 13)
        Me.Label4.TabIndex = 75
        Me.Label4.Text = "Print on the machine plan"
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(145, 72)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(126, 21)
        Me.TextBox4.TabIndex = 74
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(32, 13)
        Me.Label3.TabIndex = 73
        Me.Label3.Text = "Color"
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(145, 45)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(126, 21)
        Me.TextBox3.TabIndex = 72
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(26, 13)
        Me.Label2.TabIndex = 71
        Me.Label2.Text = "Size"
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(145, 18)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(126, 21)
        Me.TextBox2.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Label10)
        Me.TabPage2.Controls.Add(Me.TextBox10)
        Me.TabPage2.Controls.Add(Me.Label9)
        Me.TabPage2.Controls.Add(Me.TextBox9)
        Me.TabPage2.Controls.Add(Me.Label8)
        Me.TabPage2.Controls.Add(Me.TextBox8)
        Me.TabPage2.Controls.Add(Me.ListView1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(798, 297)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Preparation2"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(277, 22)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(69, 13)
        Me.Label10.TabIndex = 77
        Me.Label10.Text = "Raw Material"
        '
        'TextBox10
        '
        Me.TextBox10.Location = New System.Drawing.Point(280, 38)
        Me.TextBox10.Name = "TextBox10"
        Me.TextBox10.Size = New System.Drawing.Size(126, 21)
        Me.TextBox10.TabIndex = 76
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(145, 22)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(55, 13)
        Me.Label9.TabIndex = 75
        Me.Label9.Text = "Plano Size"
        '
        'TextBox9
        '
        Me.TextBox9.Location = New System.Drawing.Point(148, 38)
        Me.TextBox9.Name = "TextBox9"
        Me.TextBox9.Size = New System.Drawing.Size(126, 21)
        Me.TextBox9.TabIndex = 74
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(13, 22)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(69, 13)
        Me.Label8.TabIndex = 73
        Me.Label8.Text = "Raw Material"
        '
        'TextBox8
        '
        Me.TextBox8.Location = New System.Drawing.Point(16, 38)
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.Size = New System.Drawing.Size(126, 21)
        Me.TextBox8.TabIndex = 72
        '
        'ListView1
        '
        Me.ListView1.Location = New System.Drawing.Point(17, 71)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(749, 199)
        Me.ListView1.TabIndex = 0
        Me.ListView1.UseCompatibleStateImageBehavior = False
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.Label13)
        Me.TabPage3.Controls.Add(Me.TextBox12)
        Me.TabPage3.Controls.Add(Me.Label12)
        Me.TabPage3.Controls.Add(Me.TextBox11)
        Me.TabPage3.Controls.Add(Me.Label11)
        Me.TabPage3.Controls.Add(Me.TextBox7)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(798, 297)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Preparation3"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(363, 256)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(34, 13)
        Me.Label13.TabIndex = 77
        Me.Label13.Text = "Then "
        '
        'TextBox12
        '
        Me.TextBox12.Location = New System.Drawing.Point(448, 250)
        Me.TextBox12.Name = "TextBox12"
        Me.TextBox12.Size = New System.Drawing.Size(126, 21)
        Me.TextBox12.TabIndex = 76
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(93, 253)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(105, 13)
        Me.Label12.TabIndex = 75
        Me.Label12.Text = "This process provide"
        '
        'TextBox11
        '
        Me.TextBox11.Location = New System.Drawing.Point(226, 250)
        Me.TextBox11.Name = "TextBox11"
        Me.TextBox11.Size = New System.Drawing.Size(126, 21)
        Me.TextBox11.TabIndex = 74
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(14, 223)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(195, 13)
        Me.Label11.TabIndex = 73
        Me.Label11.Text = "Based on order, paper material needed"
        '
        'TextBox7
        '
        Me.TextBox7.Location = New System.Drawing.Point(226, 223)
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.Size = New System.Drawing.Size(126, 21)
        Me.TextBox7.TabIndex = 72
        '
        'TabPage4
        '
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(798, 297)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "After printing"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmdsave, Me.cmdfind, Me.cmdcancel, Me.cmddelete, Me.cmdnew, Me.cmdexit, Me.ToolStripSeparator1, Me.cmdprint})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(837, 25)
        Me.ToolStrip1.TabIndex = 79
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'cmdsave
        '
        Me.cmdsave.Image = CType(resources.GetObject("cmdsave.Image"), System.Drawing.Image)
        Me.cmdsave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdsave.Name = "cmdsave"
        Me.cmdsave.Size = New System.Drawing.Size(60, 22)
        Me.cmdsave.Text = "&Save"
        '
        'cmdfind
        '
        Me.cmdfind.Image = CType(resources.GetObject("cmdfind.Image"), System.Drawing.Image)
        Me.cmdfind.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdfind.Name = "cmdfind"
        Me.cmdfind.Size = New System.Drawing.Size(53, 22)
        Me.cmdfind.Text = "&Find"
        '
        'cmdcancel
        '
        Me.cmdcancel.Image = CType(resources.GetObject("cmdcancel.Image"), System.Drawing.Image)
        Me.cmdcancel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdcancel.Name = "cmdcancel"
        Me.cmdcancel.Size = New System.Drawing.Size(70, 22)
        Me.cmdcancel.Text = "&Cancel"
        '
        'cmddelete
        '
        Me.cmddelete.Image = CType(resources.GetObject("cmddelete.Image"), System.Drawing.Image)
        Me.cmddelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmddelete.Name = "cmddelete"
        Me.cmddelete.Size = New System.Drawing.Size(70, 22)
        Me.cmddelete.Text = "&Delete"
        '
        'cmdnew
        '
        Me.cmdnew.Image = CType(resources.GetObject("cmdnew.Image"), System.Drawing.Image)
        Me.cmdnew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdnew.Name = "cmdnew"
        Me.cmdnew.Size = New System.Drawing.Size(55, 22)
        Me.cmdnew.Text = "&New"
        '
        'cmdexit
        '
        Me.cmdexit.Image = CType(resources.GetObject("cmdexit.Image"), System.Drawing.Image)
        Me.cmdexit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(51, 22)
        Me.cmdexit.Text = "&Exit"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'cmdprint
        '
        Me.cmdprint.Image = CType(resources.GetObject("cmdprint.Image"), System.Drawing.Image)
        Me.cmdprint.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdprint.Name = "cmdprint"
        Me.cmdprint.Size = New System.Drawing.Size(59, 22)
        Me.cmdprint.Text = "&Print"
        '
        'TextBox13
        '
        Me.TextBox13.Location = New System.Drawing.Point(113, 99)
        Me.TextBox13.Name = "TextBox13"
        Me.TextBox13.ReadOnly = True
        Me.TextBox13.Size = New System.Drawing.Size(217, 21)
        Me.TextBox13.TabIndex = 81
        Me.TextBox13.TabStop = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(20, 102)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(29, 13)
        Me.Label14.TabIndex = 80
        Me.Label14.Text = "MP#"
        '
        'frmOrderProcess
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(837, 521)
        Me.Controls.Add(Me.TextBox13)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.txtSKUCode)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtCCode)
        Me.Controls.Add(Me.txtCName)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmOrderProcess"
        Me.ShowIcon = False
        Me.Text = "Order Process"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCCode As System.Windows.Forms.TextBox
    Friend WithEvents txtCName As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtSKUCode As System.Windows.Forms.TextBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TextBox6 As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TextBox10 As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TextBox9 As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TextBox8 As System.Windows.Forms.TextBox
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents dtpSODate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents TextBox12 As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TextBox11 As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TextBox7 As System.Windows.Forms.TextBox
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents cmdsave As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmdfind As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmdcancel As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmddelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmdnew As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmdexit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmdprint As System.Windows.Forms.ToolStripButton
    Friend WithEvents TextBox13 As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
End Class
