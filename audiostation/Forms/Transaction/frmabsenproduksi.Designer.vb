<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmabsenproduksi
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmabsenproduksi))
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.ComboBox3 = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ComboBox4 = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ComboBox5 = New System.Windows.Forms.ComboBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.ComboBox6 = New System.Windows.Forms.ComboBox()
        Me.ComboBox7 = New System.Windows.Forms.ComboBox()
        Me.ComboBox8 = New System.Windows.Forms.ComboBox()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnsave = New System.Windows.Forms.ToolStripButton()
        Me.btnfind = New System.Windows.Forms.ToolStripButton()
        Me.btncancel = New System.Windows.Forms.ToolStripButton()
        Me.btndelete = New System.Windows.Forms.ToolStripButton()
        Me.btnnew = New System.Windows.Forms.ToolStripButton()
        Me.btnexit = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmdprint = New System.Windows.Forms.ToolStripButton()
        Me.txtguid = New System.Windows.Forms.TextBox()
        Me.txtkode = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.ComboBox9 = New System.Windows.Forms.ComboBox()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ComboBox1
        '
        Me.ComboBox1.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(191, 170)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(182, 33)
        Me.ComboBox1.TabIndex = 1
        Me.ComboBox1.Tag = "shift_id"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePicker1.Location = New System.Drawing.Point(191, 92)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(182, 33)
        Me.DateTimePicker1.TabIndex = 12
        Me.DateTimePicker1.Tag = "abs_date"
        '
        'ComboBox2
        '
        Me.ComboBox2.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Location = New System.Drawing.Point(191, 209)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(182, 33)
        Me.ComboBox2.TabIndex = 2
        Me.ComboBox2.Tag = "worker_id"
        '
        'ComboBox3
        '
        Me.ComboBox3.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox3.FormattingEnabled = True
        Me.ComboBox3.Location = New System.Drawing.Point(191, 131)
        Me.ComboBox3.Name = "ComboBox3"
        Me.ComboBox3.Size = New System.Drawing.Size(182, 33)
        Me.ComboBox3.TabIndex = 0
        Me.ComboBox3.Tag = "check_st"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(24, 134)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(137, 25)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Check In/Out"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(24, 98)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 25)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Date"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(24, 173)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 25)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Shift"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(24, 212)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(108, 25)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Worker ID"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(24, 251)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(118, 25)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Machine ID"
        '
        'ComboBox4
        '
        Me.ComboBox4.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox4.FormattingEnabled = True
        Me.ComboBox4.Location = New System.Drawing.Point(191, 248)
        Me.ComboBox4.Name = "ComboBox4"
        Me.ComboBox4.Size = New System.Drawing.Size(182, 33)
        Me.ComboBox4.TabIndex = 3
        Me.ComboBox4.Tag = "machine_id"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(24, 290)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(62, 25)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "MP #"
        '
        'ComboBox5
        '
        Me.ComboBox5.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox5.FormattingEnabled = True
        Me.ComboBox5.Location = New System.Drawing.Point(191, 287)
        Me.ComboBox5.Name = "ComboBox5"
        Me.ComboBox5.Size = New System.Drawing.Size(182, 33)
        Me.ComboBox5.TabIndex = 4
        Me.ComboBox5.Tag = "mp_idf"
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(191, 423)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(182, 33)
        Me.TextBox1.TabIndex = 7
        Me.TextBox1.Tag = "qty_in_val"
        '
        'TextBox2
        '
        Me.TextBox2.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.Location = New System.Drawing.Point(191, 462)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(182, 33)
        Me.TextBox2.TabIndex = 9
        Me.TextBox2.Tag = "qty_out_val"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(24, 426)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(102, 25)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Qty Input"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(24, 465)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(116, 25)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "Qty Output"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(24, 329)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(98, 25)
        Me.Label9.TabIndex = 17
        Me.Label9.Text = "Goods ID"
        '
        'ComboBox6
        '
        Me.ComboBox6.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox6.FormattingEnabled = True
        Me.ComboBox6.Location = New System.Drawing.Point(191, 326)
        Me.ComboBox6.Name = "ComboBox6"
        Me.ComboBox6.Size = New System.Drawing.Size(538, 33)
        Me.ComboBox6.TabIndex = 5
        Me.ComboBox6.Tag = "prod_id"
        '
        'ComboBox7
        '
        Me.ComboBox7.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox7.FormattingEnabled = True
        Me.ComboBox7.Location = New System.Drawing.Point(379, 423)
        Me.ComboBox7.Name = "ComboBox7"
        Me.ComboBox7.Size = New System.Drawing.Size(118, 33)
        Me.ComboBox7.TabIndex = 8
        Me.ComboBox7.Tag = "qty_in_uom"
        '
        'ComboBox8
        '
        Me.ComboBox8.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox8.FormattingEnabled = True
        Me.ComboBox8.Location = New System.Drawing.Point(379, 462)
        Me.ComboBox8.Name = "ComboBox8"
        Me.ComboBox8.Size = New System.Drawing.Size(118, 33)
        Me.ComboBox8.TabIndex = 10
        Me.ComboBox8.Tag = "qty_out_uom"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnsave, Me.btnfind, Me.btncancel, Me.btndelete, Me.btnnew, Me.btnexit, Me.ToolStripSeparator1, Me.cmdprint})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(778, 37)
        Me.ToolStrip1.TabIndex = 11
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnsave
        '
        Me.btnsave.Image = CType(resources.GetObject("btnsave.Image"), System.Drawing.Image)
        Me.btnsave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnsave.Name = "btnsave"
        Me.btnsave.Size = New System.Drawing.Size(78, 34)
        Me.btnsave.Text = "&Save"
        '
        'btnfind
        '
        Me.btnfind.Image = CType(resources.GetObject("btnfind.Image"), System.Drawing.Image)
        Me.btnfind.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnfind.Name = "btnfind"
        Me.btnfind.Size = New System.Drawing.Size(76, 34)
        Me.btnfind.Text = "&Find"
        '
        'btncancel
        '
        Me.btncancel.Image = CType(resources.GetObject("btncancel.Image"), System.Drawing.Image)
        Me.btncancel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btncancel.Name = "btncancel"
        Me.btncancel.Size = New System.Drawing.Size(97, 34)
        Me.btncancel.Text = "&Cancel"
        '
        'btndelete
        '
        Me.btndelete.Image = CType(resources.GetObject("btndelete.Image"), System.Drawing.Image)
        Me.btndelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btndelete.Name = "btndelete"
        Me.btndelete.Size = New System.Drawing.Size(95, 34)
        Me.btndelete.Text = "&Delete"
        '
        'btnnew
        '
        Me.btnnew.Image = CType(resources.GetObject("btnnew.Image"), System.Drawing.Image)
        Me.btnnew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnnew.Name = "btnnew"
        Me.btnnew.Size = New System.Drawing.Size(78, 34)
        Me.btnnew.Text = "&New"
        '
        'btnexit
        '
        Me.btnexit.Image = CType(resources.GetObject("btnexit.Image"), System.Drawing.Image)
        Me.btnexit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnexit.Name = "btnexit"
        Me.btnexit.Size = New System.Drawing.Size(70, 34)
        Me.btnexit.Text = "&Exit"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 37)
        '
        'cmdprint
        '
        Me.cmdprint.Image = CType(resources.GetObject("cmdprint.Image"), System.Drawing.Image)
        Me.cmdprint.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdprint.Name = "cmdprint"
        Me.cmdprint.Size = New System.Drawing.Size(81, 34)
        Me.cmdprint.Text = "&Print"
        '
        'txtguid
        '
        Me.txtguid.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtguid.Location = New System.Drawing.Point(379, 53)
        Me.txtguid.Name = "txtguid"
        Me.txtguid.ReadOnly = True
        Me.txtguid.Size = New System.Drawing.Size(182, 33)
        Me.txtguid.TabIndex = 23
        Me.txtguid.Tag = "abs_id"
        Me.txtguid.Visible = False
        '
        'txtkode
        '
        Me.txtkode.BackColor = System.Drawing.Color.GreenYellow
        Me.txtkode.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtkode.Location = New System.Drawing.Point(191, 53)
        Me.txtkode.Name = "txtkode"
        Me.txtkode.ReadOnly = True
        Me.txtkode.Size = New System.Drawing.Size(182, 33)
        Me.txtkode.TabIndex = 13
        Me.txtkode.Tag = "abs_no"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(24, 56)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(43, 25)
        Me.Label10.TabIndex = 25
        Me.Label10.Text = "No."
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(24, 368)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(162, 25)
        Me.Label11.TabIndex = 27
        Me.Label11.Text = "Raw Material ID"
        '
        'ComboBox9
        '
        Me.ComboBox9.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox9.FormattingEnabled = True
        Me.ComboBox9.Location = New System.Drawing.Point(191, 365)
        Me.ComboBox9.Name = "ComboBox9"
        Me.ComboBox9.Size = New System.Drawing.Size(538, 33)
        Me.ComboBox9.TabIndex = 6
        Me.ComboBox9.Tag = "prod_id"
        '
        'frmabsenproduksi
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(778, 515)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.ComboBox9)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtkode)
        Me.Controls.Add(Me.txtguid)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.ComboBox8)
        Me.Controls.Add(Me.ComboBox7)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.ComboBox6)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.ComboBox5)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.ComboBox4)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ComboBox3)
        Me.Controls.Add(Me.ComboBox2)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.ComboBox1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaximizeBox = False
        Me.Name = "frmabsenproduksi"
        Me.Text = "Absen Produksi"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox3 As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ComboBox4 As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ComboBox5 As System.Windows.Forms.ComboBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents ComboBox6 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox7 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox8 As System.Windows.Forms.ComboBox
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnsave As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnfind As System.Windows.Forms.ToolStripButton
    Friend WithEvents btncancel As System.Windows.Forms.ToolStripButton
    Friend WithEvents btndelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnnew As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnexit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmdprint As System.Windows.Forms.ToolStripButton
    Friend WithEvents txtguid As System.Windows.Forms.TextBox
    Friend WithEvents txtkode As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents ComboBox9 As System.Windows.Forms.ComboBox
End Class
