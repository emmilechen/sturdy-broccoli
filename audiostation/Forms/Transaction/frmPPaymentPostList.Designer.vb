﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPPaymentPostList
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
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.btnPost = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpAPDateTo = New System.Windows.Forms.DateTimePicker()
        Me.dtpAPDateFrom = New System.Windows.Forms.DateTimePicker()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.btnFilter = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtAPNo = New System.Windows.Forms.TextBox()
        Me.txtSName = New System.Windows.Forms.TextBox()
        Me.chbSelectAll = New System.Windows.Forms.CheckBox()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ListView1
        '
        Me.ListView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListView1.CheckBoxes = True
        Me.ListView1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListView1.FullRowSelect = True
        Me.ListView1.GridLines = True
        Me.ListView1.Location = New System.Drawing.Point(11, 140)
        Me.ListView1.MultiSelect = False
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(761, 422)
        Me.ListView1.TabIndex = 4
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.List
        '
        'btnPost
        '
        Me.btnPost.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPost.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPost.Location = New System.Drawing.Point(688, 573)
        Me.btnPost.Name = "btnPost"
        Me.btnPost.Size = New System.Drawing.Size(84, 26)
        Me.btnPost.TabIndex = 5
        Me.btnPost.Text = "Posting"
        Me.btnPost.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.btnFilter)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.dtpAPDateTo)
        Me.GroupBox1.Controls.Add(Me.txtAPNo)
        Me.GroupBox1.Controls.Add(Me.txtSName)
        Me.GroupBox1.Controls.Add(Me.dtpAPDateFrom)
        Me.GroupBox1.Controls.Add(Me.RadioButton2)
        Me.GroupBox1.Controls.Add(Me.RadioButton1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(760, 128)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filter By"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(229, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(17, 13)
        Me.Label3.TabIndex = 65
        Me.Label3.Text = "to"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(89, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(31, 13)
        Me.Label1.TabIndex = 63
        Me.Label1.Text = "From"
        '
        'dtpAPDateTo
        '
        Me.dtpAPDateTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpAPDateTo.Location = New System.Drawing.Point(252, 18)
        Me.dtpAPDateTo.Name = "dtpAPDateTo"
        Me.dtpAPDateTo.Size = New System.Drawing.Size(97, 21)
        Me.dtpAPDateTo.TabIndex = 3
        '
        'dtpAPDateFrom
        '
        Me.dtpAPDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpAPDateFrom.Location = New System.Drawing.Point(126, 18)
        Me.dtpAPDateFrom.Name = "dtpAPDateFrom"
        Me.dtpAPDateFrom.Size = New System.Drawing.Size(97, 21)
        Me.dtpAPDateFrom.TabIndex = 2
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.CheckAlign = System.Drawing.ContentAlignment.TopLeft
        Me.RadioButton2.Location = New System.Drawing.Point(9, 20)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(48, 17)
        Me.RadioButton2.TabIndex = 0
        Me.RadioButton2.Text = "Date"
        Me.RadioButton2.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Location = New System.Drawing.Point(9, 45)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(65, 17)
        Me.RadioButton1.TabIndex = 1
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "Show All"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'btnFilter
        '
        Me.btnFilter.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFilter.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFilter.Location = New System.Drawing.Point(670, 90)
        Me.btnFilter.Name = "btnFilter"
        Me.btnFilter.Size = New System.Drawing.Size(84, 26)
        Me.btnFilter.TabIndex = 3
        Me.btnFilter.Text = "Show"
        Me.btnFilter.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(143, 77)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(45, 13)
        Me.Label4.TabIndex = 74
        Me.Label4.Text = "Supplier"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(8, 77)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(116, 13)
        Me.Label2.TabIndex = 73
        Me.Label2.Text = "Purchase Payment No."
        '
        'txtAPNo
        '
        Me.txtAPNo.Location = New System.Drawing.Point(9, 94)
        Me.txtAPNo.Name = "txtAPNo"
        Me.txtAPNo.Size = New System.Drawing.Size(130, 21)
        Me.txtAPNo.TabIndex = 1
        '
        'txtSName
        '
        Me.txtSName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSName.Location = New System.Drawing.Point(145, 94)
        Me.txtSName.Name = "txtSName"
        Me.txtSName.Size = New System.Drawing.Size(216, 21)
        Me.txtSName.TabIndex = 2
        '
        'chbSelectAll
        '
        Me.chbSelectAll.AutoSize = True
        Me.chbSelectAll.Location = New System.Drawing.Point(11, 579)
        Me.chbSelectAll.Name = "chbSelectAll"
        Me.chbSelectAll.Size = New System.Drawing.Size(69, 17)
        Me.chbSelectAll.TabIndex = 80
        Me.chbSelectAll.Text = "Select All"
        Me.chbSelectAll.UseVisualStyleBackColor = True
        '
        'frmPPaymentPostList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 608)
        Me.Controls.Add(Me.chbSelectAll)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnPost)
        Me.Controls.Add(Me.ListView1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmPPaymentPostList"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Purchase Payment Posting List"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents btnPost As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpAPDateTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpAPDateFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents btnFilter As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtAPNo As System.Windows.Forms.TextBox
    Friend WithEvents txtSName As System.Windows.Forms.TextBox
    Friend WithEvents chbSelectAll As System.Windows.Forms.CheckBox
End Class
