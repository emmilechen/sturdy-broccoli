Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class fdlSOProder
    Private ListView1Sorter As lvColumnSorter
    Dim strConnection As String = My.Settings.ConnStr
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Dim cmd As SqlCommand
    Dim m_FrmCallerId As String
    Dim m_POStat1 As String, m_POStat2 As String

    Public Property FrmCallerId() As String
        Get
            Return m_FrmCallerId
        End Get
        Set(ByVal Value As String)
            m_FrmCallerId = Value
        End Set
    End Property

    Public Property SName() As String
        Get
            Return txtFilter.Text
        End Get
        Set(ByVal Value As String)
            txtFilter.Text = Value
        End Set
    End Property

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        'Me.DialogResult = System.Windows.Forms.DialogResult.OK
        'Me.Close()
        If ListView1.SelectedItems.Count > 0 Then
            ListView1_DoubleClick(sender, e)
        Else
            MessageBox.Show("You didn't select any item yet. Please select an item.", Me.Text)
        End If
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        'Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub fdlSOProder_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With ListView1
            .Clear()
            .View = View.Details
            .Columns.Add("Stock Code", 90)
            .Columns.Add("Stock Name", 100)
            .Columns.Add("so_qty", 0)
            .Columns.Add("Sales Order No.", 110)
            .Columns.Add("so_date", 0)
            .Columns.Add("Customer Code", 90)
            .Columns.Add("Customer Name", 200)
        End With

        cmd = New SqlCommand("usp_tr_so_dtl_SEL_ByProder", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm1 As SqlParameter = cmd.Parameters.Add("@so_no", SqlDbType.NVarChar, 50)
        prm1.Value = IIf(txtPONo.Text = "", DBNull.Value, txtPONo.Text)
        Dim prm2 As SqlParameter = cmd.Parameters.Add("@so_date", SqlDbType.SmallDateTime)
        prm2.Value = frmProcessOrder.dtpProderDate.Value
        Dim prm4 As SqlParameter = cmd.Parameters.Add("@c_name", SqlDbType.NVarChar, 50)
        prm4.Value = IIf(txtFilter.Text = "", DBNull.Value, txtFilter.Text)
        Dim prm5 As SqlParameter = cmd.Parameters.Add("@so_stat1", SqlDbType.NVarChar, 50)
        prm5.Value = "O"
        Dim prm6 As SqlParameter = cmd.Parameters.Add("@so_stat2", SqlDbType.NVarChar, 50)
        prm6.Value = "FD"

        cn.Open()

        Dim myReader As SqlDataReader = cmd.ExecuteReader()

        Call FillList(myReader, Me.ListView1, 7, 1)
        'Dim lvItem As ListViewItem
        'Dim i As Integer, intCurrRow As Integer

        'While myReader.Read
        '    lvItem = New ListViewItem(CStr(myReader.Item(1)))
        '    lvItem.Tag = CStr(myReader.Item(0)) & "*~~~~~*" & intCurrRow 'ID
        '    'lvItem.Tag = "v" & CStr(DR.Item(0))
        '    lvItem.SubItems.Add(myReader.Item(1))
        '    lvItem.SubItems.Add(myReader.Item(2))

        '    If intCurrRow Mod 2 = 0 Then
        '        lvItem.BackColor = Color.Lavender
        '    Else
        '        lvItem.BackColor = Color.White
        '    End If
        '    lvItem.UseItemStyleForSubItems = True

        '    ListView1.Items.Add(lvItem)
        '    intCurrRow += 1
        'End While
        myReader.Close()
        cn.Close()
    End Sub

    Private Sub ListView1_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles ListView1.ColumnClick
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

    Private Sub ListView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.DoubleClick
        With frmProcessOrder
            .SODtlID = LeftSplitUF(ListView1.SelectedItems.Item(0).Tag)
            .SKUCode = ListView1.SelectedItems.Item(0).SubItems.Item(0).Text
            .SKUName = ListView1.SelectedItems.Item(0).SubItems.Item(1).Text
            .SONo = ListView1.SelectedItems.Item(0).SubItems.Item(3).Text
            .CustomerCode = ListView1.SelectedItems.Item(0).SubItems.Item(5).Text
            .CustomerName = ListView1.SelectedItems.Item(0).SubItems.Item(6).Text
        End With
        Me.Close()
    End Sub

    Private Sub txtFilter_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFilter.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            fdlSOProder_Load(sender, e)
        End If
    End Sub

    Private Sub txtPONo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPONo.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            fdlSOProder_Load(sender, e)
        End If
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ListView1Sorter = New lvColumnSorter()
        ListView1.ListViewItemSorter = ListView1Sorter
    End Sub
End Class
