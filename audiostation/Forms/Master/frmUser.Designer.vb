﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUser
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmUser))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnsave = New System.Windows.Forms.ToolStripButton()
        Me.btnfind = New System.Windows.Forms.ToolStripButton()
        Me.btncancel = New System.Windows.Forms.ToolStripButton()
        Me.btndelete = New System.Windows.Forms.ToolStripButton()
        Me.btnnew = New System.Windows.Forms.ToolStripButton()
        Me.btnexit = New System.Windows.Forms.ToolStripButton()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.txtguid = New System.Windows.Forms.TextBox()
        Me.txtac = New System.Windows.Forms.TextBox()
        Me.txtuserid = New System.Windows.Forms.TextBox()
        Me.TextBox6 = New System.Windows.Forms.TextBox()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtfname = New System.Windows.Forms.TextBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtnip = New System.Windows.Forms.TextBox()
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmbdept = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbdiv = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbUserLevelID = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtUserPassword = New System.Windows.Forms.TextBox()
        Me.txtUserName = New System.Windows.Forms.TextBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.ToolStrip1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnsave, Me.btnfind, Me.btncancel, Me.btndelete, Me.btnnew, Me.btnexit})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(736, 25)
        Me.ToolStrip1.TabIndex = 89
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnsave
        '
        Me.btnsave.Image = CType(resources.GetObject("btnsave.Image"), System.Drawing.Image)
        Me.btnsave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnsave.Name = "btnsave"
        Me.btnsave.Size = New System.Drawing.Size(60, 22)
        Me.btnsave.Text = "&Save"
        '
        'btnfind
        '
        Me.btnfind.Image = CType(resources.GetObject("btnfind.Image"), System.Drawing.Image)
        Me.btnfind.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnfind.Name = "btnfind"
        Me.btnfind.Size = New System.Drawing.Size(53, 22)
        Me.btnfind.Text = "&Find"
        '
        'btncancel
        '
        Me.btncancel.Image = CType(resources.GetObject("btncancel.Image"), System.Drawing.Image)
        Me.btncancel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btncancel.Name = "btncancel"
        Me.btncancel.Size = New System.Drawing.Size(70, 22)
        Me.btncancel.Text = "&Cancel"
        '
        'btndelete
        '
        Me.btndelete.Image = CType(resources.GetObject("btndelete.Image"), System.Drawing.Image)
        Me.btndelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btndelete.Name = "btndelete"
        Me.btndelete.Size = New System.Drawing.Size(70, 22)
        Me.btndelete.Text = "&Delete"
        '
        'btnnew
        '
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
        Me.btnexit.Text = "Exit"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(12, 28)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(718, 435)
        Me.TabControl1.TabIndex = 90
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Label12)
        Me.TabPage1.Controls.Add(Me.CheckBox1)
        Me.TabPage1.Controls.Add(Me.txtguid)
        Me.TabPage1.Controls.Add(Me.txtac)
        Me.TabPage1.Controls.Add(Me.txtuserid)
        Me.TabPage1.Controls.Add(Me.TextBox6)
        Me.TabPage1.Controls.Add(Me.TextBox5)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.txtfname)
        Me.TabPage1.Controls.Add(Me.TextBox3)
        Me.TabPage1.Controls.Add(Me.Label11)
        Me.TabPage1.Controls.Add(Me.Label10)
        Me.TabPage1.Controls.Add(Me.txtnip)
        Me.TabPage1.Controls.Add(Me.DateTimePicker2)
        Me.TabPage1.Controls.Add(Me.Label9)
        Me.TabPage1.Controls.Add(Me.DateTimePicker1)
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Controls.Add(Me.TextBox2)
        Me.TabPage1.Controls.Add(Me.Label7)
        Me.TabPage1.Controls.Add(Me.cmbdept)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.cmbdiv)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.cmbUserLevelID)
        Me.TabPage1.Controls.Add(Me.Label15)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.txtUserPassword)
        Me.TabPage1.Controls.Add(Me.txtUserName)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(710, 409)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "User Detail"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'txtguid
        '
        Me.txtguid.BackColor = System.Drawing.Color.GreenYellow
        Me.txtguid.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtguid.Location = New System.Drawing.Point(334, 285)
        Me.txtguid.MaxLength = 50
        Me.txtguid.Name = "txtguid"
        Me.txtguid.Size = New System.Drawing.Size(68, 21)
        Me.txtguid.TabIndex = 127
        Me.txtguid.Visible = False
        '
        'txtac
        '
        Me.txtac.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtac.Location = New System.Drawing.Point(260, 285)
        Me.txtac.MaxLength = 50
        Me.txtac.Name = "txtac"
        Me.txtac.Size = New System.Drawing.Size(68, 21)
        Me.txtac.TabIndex = 125
        Me.txtac.Tag = "ac"
        Me.txtac.Text = "0"
        Me.txtac.Visible = False
        '
        'txtuserid
        '
        Me.txtuserid.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtuserid.Location = New System.Drawing.Point(260, 312)
        Me.txtuserid.MaxLength = 50
        Me.txtuserid.Name = "txtuserid"
        Me.txtuserid.Size = New System.Drawing.Size(68, 21)
        Me.txtuserid.TabIndex = 126
        Me.txtuserid.Tag = "user_id"
        Me.txtuserid.Visible = False
        '
        'TextBox6
        '
        Me.TextBox6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox6.Location = New System.Drawing.Point(271, 231)
        Me.TextBox6.MaxLength = 50
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Size = New System.Drawing.Size(131, 21)
        Me.TextBox6.TabIndex = 121
        Me.TextBox6.Tag = "user_phone2"
        '
        'TextBox5
        '
        Me.TextBox5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox5.Location = New System.Drawing.Point(129, 231)
        Me.TextBox5.MaxLength = 50
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(131, 21)
        Me.TextBox5.TabIndex = 120
        Me.TextBox5.Tag = "user_phone1"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(15, 234)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(62, 13)
        Me.Label6.TabIndex = 139
        Me.Label6.Text = "Phone 1 / 2"
        '
        'txtfname
        '
        Me.txtfname.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtfname.Location = New System.Drawing.Point(129, 69)
        Me.txtfname.MaxLength = 50
        Me.txtfname.Name = "txtfname"
        Me.txtfname.Size = New System.Drawing.Size(273, 21)
        Me.txtfname.TabIndex = 114
        Me.txtfname.Tag = "user_fname"
        '
        'TextBox3
        '
        Me.TextBox3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox3.Location = New System.Drawing.Point(129, 204)
        Me.TextBox3.MaxLength = 50
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(273, 21)
        Me.TextBox3.TabIndex = 119
        Me.TextBox3.Tag = "user_email"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(15, 207)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(34, 13)
        Me.Label11.TabIndex = 138
        Me.Label11.Text = "Email "
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(16, 45)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(33, 13)
        Me.Label10.TabIndex = 137
        Me.Label10.Text = "NIP *"
        '
        'txtnip
        '
        Me.txtnip.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtnip.Location = New System.Drawing.Point(129, 42)
        Me.txtnip.MaxLength = 50
        Me.txtnip.Name = "txtnip"
        Me.txtnip.Size = New System.Drawing.Size(273, 21)
        Me.txtnip.TabIndex = 113
        Me.txtnip.Tag = "user_nip"
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Location = New System.Drawing.Point(129, 312)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(118, 21)
        Me.DateTimePicker2.TabIndex = 123
        Me.DateTimePicker2.Tag = "user_memberdate"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(17, 313)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(81, 13)
        Me.Label9.TabIndex = 136
        Me.Label9.Text = "Member since *"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Location = New System.Drawing.Point(129, 284)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(118, 21)
        Me.DateTimePicker1.TabIndex = 122
        Me.DateTimePicker1.Tag = "user_bday"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(16, 342)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(44, 13)
        Me.Label8.TabIndex = 135
        Me.Label8.Text = "Notes *"
        '
        'TextBox2
        '
        Me.TextBox2.AcceptsReturn = True
        Me.TextBox2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.Location = New System.Drawing.Point(129, 339)
        Me.TextBox2.MaxLength = 50
        Me.TextBox2.Multiline = True
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(273, 42)
        Me.TextBox2.TabIndex = 124
        Me.TextBox2.Tag = "user_notes"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(17, 288)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(56, 13)
        Me.Label7.TabIndex = 134
        Me.Label7.Text = "Birthday *"
        '
        'cmbdept
        '
        Me.cmbdept.FormattingEnabled = True
        Me.cmbdept.Location = New System.Drawing.Point(129, 150)
        Me.cmbdept.Name = "cmbdept"
        Me.cmbdept.Size = New System.Drawing.Size(273, 21)
        Me.cmbdept.TabIndex = 117
        Me.cmbdept.Tag = "user_dept"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(15, 153)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(73, 13)
        Me.Label5.TabIndex = 133
        Me.Label5.Text = "Department *"
        '
        'cmbdiv
        '
        Me.cmbdiv.FormattingEnabled = True
        Me.cmbdiv.Location = New System.Drawing.Point(129, 177)
        Me.cmbdiv.Name = "cmbdiv"
        Me.cmbdiv.Size = New System.Drawing.Size(273, 21)
        Me.cmbdiv.TabIndex = 118
        Me.cmbdiv.Tag = "user_divisi"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(15, 180)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 13)
        Me.Label4.TabIndex = 132
        Me.Label4.Text = "Division *"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(15, 72)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 13)
        Me.Label3.TabIndex = 131
        Me.Label3.Text = "Full Name *"
        '
        'cmbUserLevelID
        '
        Me.cmbUserLevelID.FormattingEnabled = True
        Me.cmbUserLevelID.Location = New System.Drawing.Point(129, 123)
        Me.cmbUserLevelID.Name = "cmbUserLevelID"
        Me.cmbUserLevelID.Size = New System.Drawing.Size(273, 21)
        Me.cmbUserLevelID.TabIndex = 116
        Me.cmbUserLevelID.Tag = "user_level_id"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(15, 126)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(70, 13)
        Me.Label15.TabIndex = 130
        Me.Label15.Text = "User Group *"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(16, 99)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 13)
        Me.Label2.TabIndex = 129
        Me.Label2.Text = "Password *"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(15, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 13)
        Me.Label1.TabIndex = 128
        Me.Label1.Text = "User Name *"
        '
        'txtUserPassword
        '
        Me.txtUserPassword.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUserPassword.Location = New System.Drawing.Point(129, 96)
        Me.txtUserPassword.MaxLength = 50
        Me.txtUserPassword.Name = "txtUserPassword"
        Me.txtUserPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtUserPassword.Size = New System.Drawing.Size(273, 21)
        Me.txtUserPassword.TabIndex = 115
        Me.txtUserPassword.Tag = "user_password"
        '
        'txtUserName
        '
        Me.txtUserName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUserName.Location = New System.Drawing.Point(129, 15)
        Me.txtUserName.MaxLength = 50
        Me.txtUserName.Name = "txtUserName"
        Me.txtUserName.ReadOnly = True
        Me.txtUserName.Size = New System.Drawing.Size(273, 21)
        Me.txtUserName.TabIndex = 112
        Me.txtUserName.Tag = "user_name"
        '
        'TabPage2
        '
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(710, 409)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Others"
        Me.TabPage2.UseVisualStyleBackColor = True
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
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(129, 258)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(150, 17)
        Me.CheckBox1.TabIndex = 140
        Me.CheckBox1.Tag = "issales"
        Me.CheckBox1.Text = "(Sales Person = Checked)"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(15, 262)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(76, 13)
        Me.Label12.TabIndex = 141
        Me.Label12.Text = "Sales Person ?"
        '
        'frmUser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(736, 469)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmUser"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "User"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnsave As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnfind As System.Windows.Forms.ToolStripButton
    Friend WithEvents btncancel As System.Windows.Forms.ToolStripButton
    Friend WithEvents btndelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnnew As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnexit As System.Windows.Forms.ToolStripButton
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents txtguid As System.Windows.Forms.TextBox
    Friend WithEvents txtac As System.Windows.Forms.TextBox
    Friend WithEvents txtuserid As System.Windows.Forms.TextBox
    Friend WithEvents TextBox6 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtfname As System.Windows.Forms.TextBox
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtnip As System.Windows.Forms.TextBox
    Friend WithEvents DateTimePicker2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmbdept As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmbdiv As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbUserLevelID As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtUserPassword As System.Windows.Forms.TextBox
    Friend WithEvents txtUserName As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
End Class
