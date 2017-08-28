<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUtility
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmUtility))
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.txtseq = New System.Windows.Forms.TextBox()
        Me.txtkode = New System.Windows.Forms.TextBox()
        Me.txtket = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtguid = New System.Windows.Forms.TextBox()
        Me.txtsearch = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblreckiri = New System.Windows.Forms.Label()
        Me.txtopenargs = New System.Windows.Forms.TextBox()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnsave = New System.Windows.Forms.ToolStripButton()
        Me.btncancel = New System.Windows.Forms.ToolStripButton()
        Me.btndelete = New System.Windows.Forms.ToolStripButton()
        Me.btnnew = New System.Windows.Forms.ToolStripButton()
        Me.btnexit = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ListView1
        '
        Me.ListView1.FullRowSelect = True
        Me.ListView1.GridLines = True
        Me.ListView1.Location = New System.Drawing.Point(18, 116)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(439, 374)
        Me.ListView1.TabIndex = 0
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'txtseq
        '
        Me.txtseq.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtseq.Location = New System.Drawing.Point(18, 90)
        Me.txtseq.Name = "txtseq"
        Me.txtseq.Size = New System.Drawing.Size(54, 21)
        Me.txtseq.TabIndex = 1
        '
        'txtkode
        '
        Me.txtkode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtkode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtkode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtkode.Location = New System.Drawing.Point(78, 90)
        Me.txtkode.Name = "txtkode"
        Me.txtkode.Size = New System.Drawing.Size(133, 21)
        Me.txtkode.TabIndex = 2
        '
        'txtket
        '
        Me.txtket.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtket.Location = New System.Drawing.Point(217, 90)
        Me.txtket.Name = "txtket"
        Me.txtket.Size = New System.Drawing.Size(240, 21)
        Me.txtket.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(15, 74)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Urutan"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(75, 74)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Kode"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(214, 74)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(73, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Keterangan"
        '
        'txtguid
        '
        Me.txtguid.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtguid.Location = New System.Drawing.Point(157, 64)
        Me.txtguid.Name = "txtguid"
        Me.txtguid.Size = New System.Drawing.Size(54, 21)
        Me.txtguid.TabIndex = 8
        Me.txtguid.Visible = False
        '
        'txtsearch
        '
        Me.txtsearch.BackColor = System.Drawing.Color.LightGreen
        Me.txtsearch.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtsearch.Location = New System.Drawing.Point(78, 38)
        Me.txtsearch.Name = "txtsearch"
        Me.txtsearch.Size = New System.Drawing.Size(379, 21)
        Me.txtsearch.TabIndex = 9
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(15, 41)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(35, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Cari :"
        '
        'lblreckiri
        '
        Me.lblreckiri.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblreckiri.Location = New System.Drawing.Point(15, 501)
        Me.lblreckiri.Name = "lblreckiri"
        Me.lblreckiri.Size = New System.Drawing.Size(442, 13)
        Me.lblreckiri.TabIndex = 12
        Me.lblreckiri.Text = "Records"
        '
        'txtopenargs
        '
        Me.txtopenargs.Location = New System.Drawing.Point(316, 64)
        Me.txtopenargs.Name = "txtopenargs"
        Me.txtopenargs.Size = New System.Drawing.Size(141, 20)
        Me.txtopenargs.TabIndex = 13
        Me.txtopenargs.Visible = False
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnsave, Me.btncancel, Me.btndelete, Me.btnnew, Me.btnexit})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(469, 26)
        Me.ToolStrip1.TabIndex = 14
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnsave
        '
        Me.btnsave.Image = CType(resources.GetObject("btnsave.Image"), System.Drawing.Image)
        Me.btnsave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnsave.Name = "btnsave"
        Me.btnsave.Size = New System.Drawing.Size(68, 23)
        Me.btnsave.Text = "&Save"
        '
        'btncancel
        '
        Me.btncancel.Image = CType(resources.GetObject("btncancel.Image"), System.Drawing.Image)
        Me.btncancel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btncancel.Name = "btncancel"
        Me.btncancel.Size = New System.Drawing.Size(83, 23)
        Me.btncancel.Text = "&Cancel"
        '
        'btndelete
        '
        Me.btndelete.Image = CType(resources.GetObject("btndelete.Image"), System.Drawing.Image)
        Me.btndelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btndelete.Name = "btndelete"
        Me.btndelete.Size = New System.Drawing.Size(83, 23)
        Me.btndelete.Text = "&Delete"
        '
        'btnnew
        '
        Me.btnnew.Image = CType(resources.GetObject("btnnew.Image"), System.Drawing.Image)
        Me.btnnew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnnew.Name = "btnnew"
        Me.btnnew.Size = New System.Drawing.Size(65, 23)
        Me.btnnew.Text = "&New"
        '
        'btnexit
        '
        Me.btnexit.Image = CType(resources.GetObject("btnexit.Image"), System.Drawing.Image)
        Me.btnexit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnexit.Name = "btnexit"
        Me.btnexit.Size = New System.Drawing.Size(61, 23)
        Me.btnexit.Text = "&Exit"
        '
        'frmUtility
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(469, 523)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.txtopenargs)
        Me.Controls.Add(Me.lblreckiri)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtsearch)
        Me.Controls.Add(Me.txtguid)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtket)
        Me.Controls.Add(Me.txtkode)
        Me.Controls.Add(Me.txtseq)
        Me.Controls.Add(Me.ListView1)
        Me.MaximizeBox = False
        Me.Name = "frmUtility"
        Me.Text = "frmUtility"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents txtseq As System.Windows.Forms.TextBox
    Friend WithEvents txtkode As System.Windows.Forms.TextBox
    Friend WithEvents txtket As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtguid As System.Windows.Forms.TextBox
    Friend WithEvents txtsearch As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblreckiri As System.Windows.Forms.Label
    Friend WithEvents txtopenargs As System.Windows.Forms.TextBox
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnsave As System.Windows.Forms.ToolStripButton
    Friend WithEvents btncancel As System.Windows.Forms.ToolStripButton
    Friend WithEvents btndelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnnew As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnexit As System.Windows.Forms.ToolStripButton
End Class
