Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Public Class frmdashboard
    Dim strConnection As String = My.Settings.ConnStr
    Dim cn As SqlConnection = New SqlConnection(strConnection)
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
        Dim cmd3 As SqlCommand
        Dim dr3 As SqlDataReader
        Dim strfield As String
        Me.Timer1.Enabled = True
        If cn.State = ConnectionState.Closed Then cn.Open()
        Me.Cursor = Cursors.WaitCursor
        Me.Label6.Text = GetSysInit("sys_marquee")
        Me.TextBox1.Text = " Welcome " & GetCurrentID("user_fname", "mt_user", "user_id=" & My.Settings.UserID)
        'Bagian Procurement : 1;Semua Data Purchase Request yang belum di Pitching (No.Req, Tgl, Requester, Nama Barang, Qty);2; Semua Pitching yang belum dibuat PO;3;Semua data PO yang belum datang (Partial, belum Lunas)
        'Bagian Sales : 1;Semua Data Purchase Request yang belum di Pitching (No.Req, Tgl, Requester, Nama Barang, Qty);2; Semua Pitching yang belum dibuat PO;3;Semua data PO yang belum datang (Partial, belum Lunas)
        '**************TO BE CHECKED******************LIST3
        With Me 'formname=@formname, fieldname=@fieldname, signlevelid=@signlevelid, userid=@userid
            .ListView3.Columns.Clear()
            .ListView3.Columns.Add("Kolom 0", "formname", 0)
            .ListView3.Columns.Add("Kolom 1", "fieldname", 0)
            .ListView3.Columns.Add("Kolom 2", "tablename", 100)
            .ListView3.Columns.Add("Kolom 3", "fieldpk", 100)
            .ListView3.Columns.Add("Kolom 4", "fieldno", 100)
            .ListView3.Columns.Add("Kolom 5", "fielddate", 100)
            .ListView3.Columns.Add("Kolom 6", "fieldnote", 100)
        End With
        list3returnvalue(Me.ListView3, "a.formname, a.fieldname, a.tablename, b.fieldpk, b.fieldno, b.fielddate, b.fieldnote", "rt_form_sign a inner join mt_form b on b.form_name=a.formname", "a.userid in ('" & My.Settings.UserID & "')", "a.formname", 0)
        With Me 'List4
            .ListView4.Columns.Clear()
            .ListView4.Columns.Add("Kolom 0", "User", 75)
            .ListView4.Columns.Add("Kolom 1", "Komputer", 100)
            .ListView4.Columns.Add("Kolom 2", "Keterangan", 225)
            .ListView4.Columns.Add("Kolom 3", "Tanggal", 175)
            .ListView4.Columns.Add("Kolom 4", "Modul", 100)
        End With
        list4returnvalue(Me.ListView4, "namauser, namakomputer, keterangan, tanggal, NamaEvent", "tr_logFile", "CONVERT(date, Tanggal)=CONVERT(date, getdate())", "tanggal desc", 0)
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub frmdashboard_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Dim lebarform As Decimal = (frmMAIN.Width / 2) - 25, tinggiform As Decimal = (frmMAIN.Height / 2) - Me.TextBox1.Height, tinggiformkanan As Decimal = (frmMAIN.Height / 2) - 175
        Me.Top = 0 : Me.Left = 0
        Me.TextBox1.Top = 0 : Me.TextBox1.Left = 0 : Me.TextBox1.Width = frmMAIN.Width : Me.TextBox1.BackColor = Color.White

        Me.ListView1.Width = lebarform : Me.ListView2.Width = lebarform : Me.ListView5.Width = lebarform 'Me.Width - 40
        Me.ListView1.Height = tinggiform : Me.ListView2.Height = tinggiform

        Me.ListView2.Top = Me.ListView1.Top : Me.ListView2.Left = Me.ListView1.Width + 25
        Me.Label2.Top = Me.Label1.Top : Me.Label5.Top = Me.ListView1.Height + Me.Label1.Top + 25
        Me.Label2.Left = Me.ListView2.Left : Me.Label5.Left = Me.Label1.Left

        Me.ListView5.Height = tinggiformkanan
        Me.ListView5.Left = Me.ListView1.Left
        Me.ListView5.Top = Me.ListView1.Top + Me.ListView1.Height + 25

        Me.Label6.Top = Me.ListView5.Height + Me.Label5.Top + 25 : Me.Label6.Left = Me.Label5.Left

        Me.Label3.Top = Me.Label5.Top : Me.Label3.Left = Me.Label2.Left
        Me.ListView3.Top = Me.ListView5.Top : Me.ListView3.Left = Me.ListView2.Left : Me.ListView3.Width = Me.ListView2.Width : Me.ListView3.Height = Me.ListView5.Height / 2

        Me.ListView4.Top = Me.ListView3.Top + Me.ListView3.Height
        Me.ListView4.Height = Me.ListView5.Height / 2 : Me.ListView4.Left = Me.ListView2.Left : Me.ListView4.Width = Me.ListView3.Width

        Me.Label4.Left = Me.Label3.Left : Me.Label4.Top = Me.ListView4.Top - 20
        Me.ListView3.Height = Me.ListView3.Height - 25
        Me.ListView3.Visible = True : Me.ListView4.Visible = True : Me.Label3.Visible = True : Me.Label4.Visible = True
        Me.Label6.Width = Me.TextBox1.Width
        Me.PictureBox1.Top = Me.TextBox1.Top + 2 : Me.PictureBox1.Height = Me.TextBox1.Height - 4 : Me.PictureBox1.Left = Me.TextBox1.Width - (Me.PictureBox1.Width + 20)
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
        Me.Label6.Text = MarqueeLeft(Label6.Text)
    End Sub
    Private Function list3returnvalue(ByVal namalistview As ListView, ByVal strfield1 As String, ByVal strtabel As String, ByVal strwhr As String, ByVal strord As String, Optional openargs As Integer = 0) As String
        'On Error Resume Next
        Dim cmd As SqlCommand
        Dim str(10) As String, strsql As String
        Dim itm As ListViewItem
        Dim dr As SqlDataReader
        If cn.State = ConnectionState.Closed Then cn.Open()
        With namalistview
            .Items.Clear()
            strsql = "SELECT " & strfield1 & " FROM " & strtabel & " where " & strwhr & " order by " & strord
            cmd = New SqlCommand(strsql, cn)
            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                Do While dr.Read() 'SELECT rt_form_id, formname, tablename, fieldname, signlevelid, userid FROM rt_form_sign where rt_form_sign.userid in ('1') order by formname
                    str(0) = IIf(IsDBNull(dr.Item(0).ToString()), "#", dr.Item(0).ToString()) 'guid
                    str(1) = IIf(IsDBNull(dr.Item(1).ToString()), "#", dr.Item(1).ToString()) 'formid
                    str(2) = IIf(IsDBNull(dr.Item(2).ToString()), "#", dr.Item(2).ToString()) 'formname
                    str(3) = IIf(IsDBNull(dr.Item(3).ToString()), "#", dr.Item(3).ToString()) 'tablename
                    str(4) = IIf(IsDBNull(dr.Item(4).ToString()), "#", dr.Item(4).ToString()) 'fieldname
                    str(5) = IIf(IsDBNull(dr.Item(5).ToString()), "#", dr.Item(5).ToString()) 'signlevelid
                    str(6) = IIf(IsDBNull(dr.Item(6).ToString()), "#", dr.Item(6).ToString()) 'userid
                    str(7) = GetCurrentID("user_fname", "mt_user", "user_id=" & dr.Item(5).ToString()) 'username
                    itm = New ListViewItem(str)
                    .Items.Add(itm)
                Loop
            End If
            dr.Close()
            cmd.Dispose()
        End With
    End Function
    Private Function list4returnvalue(ByVal namalistview As ListView, ByVal strfield1 As String, ByVal strtabel As String, ByVal strwhr As String, ByVal strord As String, Optional openargs As Integer = 0) As String
        'On Error Resume Next
        Dim cmd As SqlCommand
        Dim str(10) As String, strsql As String
        Dim itm As ListViewItem
        Dim dr As SqlDataReader
        If cn.State = ConnectionState.Closed Then cn.Open()
        With namalistview
            .Items.Clear()
            strsql = "SELECT " & strfield1 & " FROM " & strtabel & " where " & strwhr & " order by " & strord
            cmd = New SqlCommand(strsql, cn)
            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                Do While dr.Read() 'SELECT rt_form_id, formname, tablename, fieldname, signlevelid, userid FROM rt_form_sign where rt_form_sign.userid in ('1') order by formname
                    str(0) = IIf(IsDBNull(dr.Item(0).ToString()), "#", dr.Item(0).ToString()) 'NamaUser
                    str(1) = IIf(IsDBNull(dr.Item(1).ToString()), "#", dr.Item(1).ToString()) 'NamaKomputer
                    str(2) = IIf(IsDBNull(dr.Item(2).ToString()), "#", dr.Item(2).ToString()) 'Keterangan
                    str(3) = IIf(IsDBNull(dr.Item(3).ToString()), "#", dr.Item(3).ToString()) 'Tanggal
                    str(4) = IIf(IsDBNull(dr.Item(4).ToString()), "#", dr.Item(4).ToString()) 'NamaEvent
                    itm = New ListViewItem(str)
                    .Items.Add(itm)
                Loop
            End If
            dr.Close()
            cmd.Dispose()
        End With
    End Function
    Private Sub Label4_Click(sender As System.Object, e As System.EventArgs) Handles Label4.Click
        list4returnvalue(Me.ListView4, "namauser, namakomputer, keterangan, tanggal, NamaEvent", "tr_logFile", "CONVERT(date, Tanggal)=CONVERT(date, getdate())", "tanggal desc", 0)
    End Sub
    Private Sub Label3_Click(sender As System.Object, e As System.EventArgs) Handles Label3.Click
        list3returnvalue(Me.ListView3, "a.formname, a.fieldname, a.tablename, b.fieldpk, b.fieldno, b.fielddate, b.fieldnote", "rt_form_sign a inner join mt_form b on b.form_name=a.formname", "a.userid in ('" & My.Settings.UserID & "')", "a.formname", 0)
    End Sub
End Class