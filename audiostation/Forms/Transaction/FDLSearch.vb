Imports System.Data.SqlClient
Imports System.Data.OleDb
Public Class FDLSearch
    Private ListView1Sorter As lvColumnSorter
    Dim strConnection As String = My.Settings.ConnStr
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Private xfield1 As String, xfield2 As String, xfield3 As String, xtable As String
    Public Sub New()
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ListView1Sorter = New lvColumnSorter()
        ListView1.ListViewItemSorter = ListView1Sorter
    End Sub
    ' Custom property we are adding to the child form
    ' Notice it is public and communicates with the txtChildText control on this form.
    Public Property ChildText() As String
        Get
            Return txtChildText0.Text
        End Get
        Set(value As String)
            txtChildText0.Text = value
        End Set
    End Property
    Private Function opensearchform(ByVal strfield1 As String, ByVal strfield2 As String, ByVal strfield3 As String, ByVal strtabel As String, ByVal strwhr As String, ByVal strord As String, Optional openargs As Integer = 0) As String
        'On Error Resume Next
        Dim cmd As SqlCommand
        Dim str(10) As String, strsql As String
        Dim itm As ListViewItem
        Dim dr As SqlDataReader
        Dim intCount As Integer = 0
        ' If strfield1 = Nothing Then Exit Function
        If cn.State = ConnectionState.Closed Then cn.Open()
        With Me
            .ListView1.Columns.Clear()
            .ListView1.Columns.Add("Kolom 1", "Kode", 100)
            .ListView1.Columns.Add("Kolom 2", "Keterangan1", 250)
            .ListView1.Columns.Add("Kolom 3", "Keterangan2", 250)

            .ListView1.Items.Clear()
            strsql = "SELECT TOP " & Me.txtrows.Text & " " & strfield1 & ", " & strfield2 & ", " & strfield3 & " FROM " & strtabel & " where " & strwhr & " order by " & strord
            cmd = New SqlCommand(strsql, cn)
            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                Do While dr.Read()

                    str(0) = IIf(IsDBNull(dr.Item(0).ToString()), "#", dr.Item(0).ToString())
                    str(1) = IIf(IsDBNull(dr.Item(1).ToString()), "#", dr.Item(1).ToString())
                    str(2) = IIf(IsDBNull(dr.Item(2).ToString()), "#", dr.Item(2).ToString())

                    itm = New ListViewItem(str)
                    .ListView1.Items.Add(itm)
                    If intCount Mod 2 Then
                        ListView1.Items(CInt(intCount)).BackColor = Color.SeaShell
                    Else
                        ListView1.Items(CInt(intCount)).BackColor = Color.White
                    End If
                    intCount = intCount + 1
                Loop
            End If
            Me.Label3.Text = Me.ListView1.Items.Count & " records"
            dr.Close()
            cmd.Dispose()
        End With
    End Function
    Private Sub FDLSearch_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.ComboBox1.Items.Clear()
        Me.ComboBox1.Items.Add("Sound Like")
        Me.ComboBox1.Items.Add("Exactly")
        Me.ComboBox1.Text = "Sound Like"

        Me.txtrows.Text = "28"
        Select Case Me.txtopenargs.Text
            Case Is = 0 'INDUCTION
                xfield1 = "ind_no" : xfield2 = "CONVERT(VARCHAR(11),ind_tgl,106)" : xfield3 = "(select c_name from mt_customer where c_id=ind_c_id)+'/'+ind_keterangan" : xtable = "tr_induction "
                opensearchform(xfield1, xfield2, xfield3, xtable, "ind_no<>''", "ind_no", Me.txtopenargs.Text)
                Me.ComboBox2.Items.Clear()
                Me.ComboBox2.Items.Add("<--ALL-->")
                Me.ComboBox2.Text = "<--ALL-->"
            Case Is = 1 'MESIN
                xfield1 = "primarykey" : xfield2 = "namamesin" : xfield3 = "merekmesin+' ~'+tipemesin+'/'+katmesin" : xtable = "mt_mesin "
                opensearchform(xfield1, xfield2, xfield3, xtable, "idmesin<>''", "idmesin desc", Me.txtopenargs.Text)
                Me.ComboBox2.Items.Clear()
                Me.ComboBox2.Items.Add("<--ALL-->")
                Me.ComboBox2.Items.Add("Nama_Mesin")
                Me.ComboBox2.Items.Add("Merek")
                Me.ComboBox2.Items.Add("Tipe_Mesin")
                Me.ComboBox2.Items.Add("Kategori_Mesin")
                Me.ComboBox2.Text = "<--ALL-->"
            Case Is = 2 'USER
                xfield1 = "user_id" : xfield2 = "user_name" : xfield3 = "user_level_description" : xtable = "mt_user inner join mt_user_level on mt_user.user_level_id=mt_user_level.user_level_id "
                opensearchform(xfield1, xfield2, xfield3, xtable, "user_id<>0", "user_name", Me.txtopenargs.Text)
                Me.ComboBox2.Items.Clear()
                Me.ComboBox2.Items.Add("<--ALL-->")
                Me.ComboBox2.Text = "<--ALL-->"
            Case Is = 3 'Memo Produksi
                xfield1 = "mp_pk" : xfield2 = "mp_no" : xfield3 = "so_no+' ~'+c_name" : xtable = "tr_mp a inner join tr_so b on a.so_id_f=b.so_id inner join mt_customer c on c.c_id=b.c_id "
                opensearchform(xfield1, xfield2, xfield3, xtable, "mp_no<>''", "mp_no", Me.txtopenargs.Text)
                Me.ComboBox2.Items.Clear()
                Me.ComboBox2.Items.Add("<--ALL-->")
                Me.ComboBox2.Text = "<--ALL-->"
            Case Is = 4 'Customer
                xfield1 = "c_id" : xfield2 = "c_code" : xfield3 = "c_code+' ~'+c_name" : xtable = "mt_customer"
                opensearchform(xfield1, xfield2, xfield3, xtable, "c_code<>''", "c_code", Me.txtopenargs.Text)
                Me.ComboBox2.Items.Clear()
                Me.ComboBox2.Items.Add("<--ALL-->")
                Me.ComboBox2.Text = "<--ALL-->"
            Case Is = 5 'Supplier
                xfield1 = "s_id" : xfield2 = "s_code" : xfield3 = "s_code+' ~'+s_name" : xtable = "mt_supplier"
                opensearchform(xfield1, xfield2, xfield3, xtable, "s_code<>''", "s_code", Me.txtopenargs.Text)
                Me.ComboBox2.Items.Clear()
                Me.ComboBox2.Items.Add("<--ALL-->")
                Me.ComboBox2.Text = "<--ALL-->"
            Case Is = 6 'absen produksi
                xfield1 = "abs_id" : xfield2 = "abs_no" : xfield3 = "abs_no+' ~'+mp_no" : xtable = "tr_abs_prod inner join tr_mp on tr_mp.mp_pk=tr_abs_prod.mp_idf"
                opensearchform(xfield1, xfield2, xfield3, xtable, "abs_no<>''", "abs_no", Me.txtopenargs.Text)
                Me.ComboBox2.Items.Clear()
                Me.ComboBox2.Items.Add("<--ALL-->")
                Me.ComboBox2.Text = "<--ALL-->"
            Case Is = 7 'absen produksi
                xfield1 = "cost_id" : xfield2 = "cost_no" : xfield3 = "cost_no+' ~'+cost_note" : xtable = "tr_costing"
                opensearchform(xfield1, xfield2, xfield3, xtable, "cost_no<>''", "cost_no", Me.txtopenargs.Text)
                Me.ComboBox2.Items.Clear()
                Me.ComboBox2.Items.Add("<--ALL-->")
                Me.ComboBox2.Text = "<--ALL-->"
        End Select
        Me.TextBox1.Focus()
    End Sub
    Private Sub TextBox1_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox1.TextChanged
        On Error Resume Next
        opensearchform(xfield1, xfield2, xfield3, xtable, xfield1 & "<>'' and (" & xfield2 & " like '%" & Me.TextBox1.Text & "%' OR " & xfield3 & " like '%" & Me.TextBox1.Text & "%')", xfield2 & " desc", Me.txtopenargs.Text)
        'Select Case Me.txtopenargs.Text
        '    Case Is = 0
        '        opensearchform(xfield1, xfield2, xfield3, xtable, "ind_no<>'' and (ind_no+ind_tgl+ind_keterangan) like '%" & Me.TextBox1.Text & "%'", "ind_no", Me.txtopenargs.Text)
        '    Case Is = 1
        '        opensearchform(xfield1, xfield2, xfield3, xtable, "idmesin<>'' and (idmesin like '%" & Me.TextBox1.Text & "%' OR namamesin like '%" & Me.TextBox1.Text & "%' OR merekmesin like '%" & Me.TextBox1.Text & "%' OR tipemesin like '%" & Me.TextBox1.Text & "%' OR katmesin like '%" & Me.TextBox1.Text & "%')", "idmesin desc", Me.txtopenargs.Text)
        '    Case Is = 2
        '        opensearchform(xfield1, xfield2, xfield3, xtable, "(user_name+user_level_description) like '%" & Me.TextBox1.Text & "%'", "user_name", Me.txtopenargs.Text)
        '    Case Is = 3
        '        opensearchform(xfield1, xfield2, xfield3, xtable, "pono<>'s' and (pono+spkid+name) like '%" & Me.TextBox1.Text & "%'", "pono", Me.txtopenargs.Text)
        'End Select
    End Sub
    Private Sub ListView1_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles ListView1.KeyDown
        'If e.KeyCode = Keys.Enter then
    End Sub
    Private Sub ListView1_MouseDoubleClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles ListView1.MouseDoubleClick
        If Me.ListView1.SelectedItems.Count = 1 Then
            Me.DialogResult = DialogResult.OK
            Me.Close()
        End If
    End Sub
    Private Sub ListView1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ListView1.SelectedIndexChanged
        If Me.ListView1.SelectedItems.Count = 1 Then
            Me.txtChildText0.Text = Me.ListView1.SelectedItems(0).Text
            Me.txtChildText1.Text = Me.ListView1.SelectedItems(0).SubItems(1).Text
            Me.txtChildText2.Text = Me.ListView1.SelectedItems(0).SubItems(2).Text
        End If
    End Sub
    Private Sub txtrows_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtrows.TextChanged
        If xfield1 = Nothing Then Exit Sub
        If IsNumeric(Me.txtrows.Text) Then
            opensearchform(xfield1, xfield2, xfield3, xtable, xfield1 & "<>'' and (" & xfield2 & " like '%" & Me.TextBox1.Text & "%' OR " & xfield3 & " like '%" & Me.TextBox1.Text & "%')", xfield2 & " desc", Me.txtopenargs.Text)
            'Select Case Me.txtopenargs.Text
            '    Case Is = 0
            '        opensearchform(xfield1, xfield2, xfield3, xtable, "ind_no<>'' and (ind_no+ind_tgl+ind_keterangan) like '%" & Me.TextBox1.Text & "%'", "ind_no", Me.txtopenargs.Text)
            '    Case Is = 1
            '        opensearchform(xfield1, xfield2, xfield3, xtable, "idmesin<>'' and (idmesin like '%" & Me.TextBox1.Text & "%' OR namamesin like '%" & Me.TextBox1.Text & "%' OR merekmesin like '%" & Me.TextBox1.Text & "%' OR tipemesin like '%" & Me.TextBox1.Text & "%' OR katmesin like '%" & Me.TextBox1.Text & "%')", "idmesin desc", Me.txtopenargs.Text)
            '    Case Is = 2
            '        opensearchform(xfield1, xfield2, xfield3, xtable, "(user_name+user_level_description) like '%" & Me.TextBox1.Text & "%'", "user_name", Me.txtopenargs.Text)
            '    Case Is = 3
            '        opensearchform(xfield1, xfield2, xfield3, xtable, "pono<>'s' and (pono+spkid+name) like '%" & Me.TextBox1.Text & "%'", "pono", Me.txtopenargs.Text)
            'End Select
        End If
    End Sub
    Private Sub ListView1_ColumnClick(sender As Object, e As System.Windows.Forms.ColumnClickEventArgs) Handles ListView1.ColumnClick
        If (e.Column = ListView1Sorter.SortColumn) Then
            ' Reverse the current sort direction for this column.
            If (ListView1Sorter.Order = Windows.Forms.SortOrder.Ascending) Then
                ListView1Sorter.Order = Windows.Forms.SortOrder.Descending
            Else
                ListView1Sorter.Order = Windows.Forms.SortOrder.Ascending
            End If
        Else
            ' Set the column number that is to be sorted; default to ascending.
            ListView1Sorter.SortColumn = e.Column
            ListView1Sorter.Order = Windows.Forms.SortOrder.Ascending
        End If

        ' Perform the sort with these new sort options.
        ListView1.Sort()
    End Sub
End Class