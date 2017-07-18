Imports System.Data
Public Class frmdashboard
    Dim dt As New DataTable
    Protected Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            Const CS_DBLCLKS As Int32 = &H8
            Const CS_NOCLOSE As Int32 = &H200
            cp.ClassStyle = CS_DBLCLKS Or CS_NOCLOSE
            Return cp
        End Get
    End Property
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        dt.Columns.Add(New DataColumn("Column1"))
        dt.Columns.Add(New DataColumn("Column2"))

        Dim row1 As DataRow = dt.NewRow()
        row1("Column1") = "A"
        row1("Column2") = "Green"
        dt.Rows.Add(row1)

        Dim row2 As DataRow = dt.NewRow()
        row2("Column1") = "A"
        row2("Column2") = "Pink"
        dt.Rows.Add(row2)

        Dim row3 As DataRow = dt.NewRow()
        row3("Column1") = "B"
        row3("Column2") = "Red"
        dt.Rows.Add(row3)

        Dim row4 As DataRow = dt.NewRow()
        row4("Column1") = "C"
        row4("Column2") = "Blue"
        dt.Rows.Add(row4)

        Dim row5 As DataRow = dt.NewRow()
        row5("Column1") = "D"
        row5("Column2") = "Green"
        dt.Rows.Add(row5)

        Dim row6 As DataRow = dt.NewRow()
        row6("Column1") = "D"
        row6("Column2") = "Blue"
        dt.Rows.Add(row6)

        Dim row7 As DataRow = dt.NewRow()
        row7("Column1") = "E"
        row7("Column2") = "Green"
        dt.Rows.Add(row7)

        Dim row8 As DataRow = dt.NewRow()
        row8("Column1") = "E"
        row8("Column2") = "Black"
        dt.Rows.Add(row8)

        Dim row9 As DataRow = dt.NewRow()
        row9("Column1") = "E"
        row9("Column2") = "Blue"
        dt.Rows.Add(row9)

        Dim row10 As DataRow = dt.NewRow()
        row10("Column1") = "E"
        row10("Column2") = "Red"
        dt.Rows.Add(row10)

        DataGridView1.DataSource = dt

    End Sub

    Private Sub frmdashboard_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Timer1.Enabled = True
        Me.Label4.Text = " PT. INTERACT CORPINDO, Jl. Raya Narogong No.36, Bojong Menteng, Rawalumbu, Kota Bks, Jawa Barat 17117, Indonesia ~ PT. Interact Corpindo offers offset printing services. The company designs and develops various printed pieces, including printing with 1 to 11 colors, high gloss U.V. coating "
    End Sub

    Private Sub frmdashboard_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Dim lebarform As Decimal = (Me.Width / 2) - 25, tinggiform As Decimal = (Me.Height / 2) - 50, tinggiformkanan As Decimal = (Me.Height / 2) - 50
        Me.Top = 0 : Me.Left = 0
        Me.ListView1.Width = lebarform : Me.ListView2.Width = lebarform : Me.ListView3.Width = Me.Width - 40
        Me.ListView1.Height = tinggiform : Me.ListView2.Height = tinggiform
        Me.ListView2.Top = Me.ListView1.Top : Me.ListView2.Left = Me.ListView1.Width + 25

        Me.ListView3.Height = tinggiformkanan - 25
        Me.ListView3.Left = Me.ListView1.Left
        Me.ListView3.Top = Me.ListView1.Top + Me.ListView1.Height + 25

        Me.Label2.Top = Me.Label1.Top : Me.Label3.Top = Me.ListView1.Height + Me.Label1.Top + 25 : Me.Label4.Top = Me.ListView3.Height + Me.Label3.Top + 25
        Me.Label2.Left = Me.ListView2.Left : Me.Label3.Left = Me.Label1.Left : Me.Label4.Left = Me.Label3.Left : Me.Label4.Width = Me.ListView3.Width
    End Sub

    Private Sub DataGridView1_CellFormatting(sender As Object, e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DataGridView1.CellFormatting

    End Sub

    Private Sub DataGridView1_CellPainting(sender As Object, e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles DataGridView1.CellPainting
        Dim low_score_style As New DataGridViewCellStyle()
        low_score_style.BackColor = Color.Pink
        low_score_style.ForeColor = Color.Red
        If e.ColumnIndex = 0 AndAlso e.RowIndex <> -1 Then
            DataGridView1.Item(1, 4).Style = low_score_style
            Using gridBrush As Brush = New SolidBrush(Me.DataGridView1.GridColor), backColorBrush As Brush = New SolidBrush(e.CellStyle.BackColor)

                Using gridLinePen As Pen = New Pen(gridBrush)
                    ' Clear cell  
                    e.Graphics.FillRectangle(backColorBrush, e.CellBounds)

                    ' Draw line (bottom border and right border of current cell)  
                    'If next row cell has different content, only draw bottom border line of current cell  
                    If e.RowIndex < DataGridView1.Rows.Count - 2 AndAlso DataGridView1.Rows(e.RowIndex + 1).Cells(e.ColumnIndex).Value.ToString() <> e.Value.ToString() Then
                        e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right - 1, e.CellBounds.Bottom - 1)
                    End If

                    ' Draw right border line of current cell  
                    e.Graphics.DrawLine(gridLinePen, e.CellBounds.Right - 1, e.CellBounds.Top, e.CellBounds.Right - 1, e.CellBounds.Bottom)

                    ' draw/fill content in current cell, and fill only one cell of multiple same cells  
                    If Not e.Value Is Nothing Then
                        If e.RowIndex > 0 AndAlso DataGridView1.Rows(e.RowIndex - 1).Cells(e.ColumnIndex).Value.ToString() = e.Value.ToString() Then
                        Else
                            e.Graphics.DrawString(CType(e.Value, String), e.CellStyle.Font, Brushes.Black, e.CellBounds.X + 2, e.CellBounds.Y + 5, StringFormat.GenericDefault)
                        End If
                    End If

                    e.Handled = True
                End Using
            End Using
        End If
        'If e.RowIndex = 0 Then

        '    If (DataGridView1.Rows(e.RowIndex).Cells(0).Value.ToString() = DataGridView1.Rows(e.RowIndex + 1).Cells(0).Value.ToString()) Then
        '        If (e.ColumnIndex = 0) Then
        '            e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None
        '        End If
        '    End If

        'End If

        'If e.RowIndex > 0 Then
        '    If e.RowIndex < DataGridView1.Rows.Count - 2 Then
        '        If (DataGridView1.Rows(e.RowIndex - 1).Cells(0).Value.ToString() = DataGridView1.Rows(e.RowIndex).Cells(0).Value.ToString()) Then
        '            If (e.ColumnIndex = 0) Then
        '                e.AdvancedBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.None
        '            End If
        '        End If

        '        If (DataGridView1.Rows(e.RowIndex).Cells(0).Value.ToString() = DataGridView1.Rows(e.RowIndex + 1).Cells(0).Value.ToString()) Then
        '            If (e.ColumnIndex = 0) Then
        '                e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None
        '            End If
        '        End If
        '    End If

        'End If

    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        Me.Label4.Text = MarqueeLeft(Label4.Text)
    End Sub
End Class