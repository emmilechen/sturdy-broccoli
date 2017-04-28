Imports System.Data.SqlClient
Imports System.Data.OleDb
Public Class frmWorkOrderList
    Private ListView1Sorter As lvColumnSorter
    Dim strConnection As String = My.Settings.ConnStr
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Dim cmd As SqlCommand
    Dim isShowAll As Boolean = False

    Private Sub btnFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        With ListView1
            .Clear()
            .View = View.Details
            .Columns.Add("Work Order No.", 120)
            .Columns.Add("Work Order Date", 120)
            .Columns.Add("Sales Order No", 120)
            .Columns.Add("Customer Code", 0)
            .Columns.Add("Customer Name", 250)
            .Columns.Add("Stock Code", 0)
            .Columns.Add("Stock Name", 250)
            .Columns.Add("Status", 80)
            .Columns.Add("stk_adj_id", 0)
        End With

        cmd = New SqlCommand("usp_tr_work_order_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm1 As SqlParameter = cmd.Parameters.Add("@so_no", SqlDbType.NVarChar, 50)
        prm1.Value = IIf(txtSONo.Text = "", DBNull.Value, txtSONo.Text)
        Dim prm2 As SqlParameter = cmd.Parameters.Add("@wo_no", SqlDbType.NVarChar, 50)
        prm2.Value = IIf(txtWONo.Text = "", DBNull.Value, txtWONo.Text)
        Dim prm3 As SqlParameter = cmd.Parameters.Add("@work_order_date1", SqlDbType.SmallDateTime)
        prm3.Value = IIf(isShowAll = False, dtpPRDateFrom.Value.Date, DBNull.Value)
        Dim prm4 As SqlParameter = cmd.Parameters.Add("@work_order_date2", SqlDbType.SmallDateTime)
        prm4.Value = IIf(isShowAll = False, dtpPRDateTo.Value.Date, DBNull.Value)
        Dim prm5 As SqlParameter = cmd.Parameters.Add("@cust_name", SqlDbType.NVarChar, 50)
        prm5.Value = IIf(txtCName.Text = "", DBNull.Value, txtCName.Text)
        Dim prm6 As SqlParameter = cmd.Parameters.Add("@status", SqlDbType.NVarChar, 50)
        If cmbStatus.SelectedIndex = 0 Or cmbStatus.Text = "" Then
            prm6.Value = DBNull.Value
        Else
            prm6.Value = cmbStatus.Items(cmbStatus.SelectedIndex).ItemData
        End If

        cn.Open()

        Dim myReader As SqlDataReader = cmd.ExecuteReader()

        Dim lvItem As ListViewItem
        Dim intCurrRow As Integer

        While myReader.Read
            lvItem = New ListViewItem(CStr(myReader.Item(0)))
            lvItem.Tag = CStr(myReader.Item(15)) & "*~~~~~*" & intCurrRow 'ID
            'lvItem.Tag = "v" & CStr(DR.Item(0))
            'lvItem.SubItems.Add(myReader.GetString(0))
            lvItem.SubItems.Add(myReader.Item(1))
            lvItem.SubItems.Add(myReader.GetString(2))
            lvItem.SubItems.Add(myReader.GetString(3))
            lvItem.SubItems.Add(myReader.GetString(4))
            lvItem.SubItems.Add(myReader.GetString(5))
            lvItem.SubItems.Add(myReader.GetString(6))
            If myReader.GetString(10) = "C" Then
                lvItem.SubItems.Add("Completed")
            ElseIf myReader.GetString(10) = "V" Then
                lvItem.SubItems.Add("Revised")
            ElseIf myReader.GetString(10) = "R" Then
                lvItem.SubItems.Add("Released")
            ElseIf myReader.GetString(10) = "P" Then
                lvItem.SubItems.Add("Partially Produced")
            Else
                lvItem.SubItems.Add("Outstanding")
            End If
            lvItem.SubItems.Add(myReader.GetString(10)) 'status
            lvItem.SubItems.Add(myReader.GetInt32(15)) 'stk_adj_id
            If intCurrRow Mod 2 = 0 Then
                lvItem.BackColor = Color.Lavender
            Else
                lvItem.BackColor = Color.White
            End If
            lvItem.UseItemStyleForSubItems = True

            ListView1.Items.Add(lvItem)
            intCurrRow += 1
        End While
        myReader.Close()
        cn.Close()

    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        frmWorkOrder.StockAdjId = 0
        frmWorkOrder.MdiParent = frmMAIN
        frmWorkOrder.Show()
    End Sub

    Private Sub frmWorkOrderList_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Add item cmbPRStatus
        cmd = New SqlCommand("sp_sys_dropdown_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm1 = cmd.Parameters.Add("@sys_dropdown_whr", SqlDbType.NVarChar, 50)
        prm1.Value = "wo_status"

        cn.Open()
        Dim myReader = cmd.ExecuteReader

        While myReader.Read
            cmbStatus.Items.Add(New clsMyListStr(myReader.GetString(1), myReader.GetString(0)))
        End While

        chbDate.Checked = False
        chbDate_CheckedChanged(sender, e)

        myReader.Close()
        cn.Close()

        btnFilter_Click(sender, e)
        cmbStatus.SelectedIndex = 0
    End Sub

    Private Sub ListView1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.Click
        lblCurrentRecord.Text = "Selected record: " + CStr(CInt(RightSplitUF(ListView1.SelectedItems.Item(0).Tag) + 1))
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
        'If Not isDeletedRecord("usp_tr_sdelivery_SEL", "sdelivery_id", LeftSplitUF(ListView1.SelectedItems.Item(0).Tag), Me.Text) = False Then
        '    btnFilter_Click(sender, e)
        'Else
        With frmWorkOrder
            .StockAdjId = LeftSplitUF(ListView1.SelectedItems.Item(0).Tag)
            .MdiParent = frmMAIN
            .Show()
        End With
        'End If
    End Sub

    

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        If ListView1.SelectedItems.Count > 0 Then
            ListView1_DoubleClick(sender, e)
        Else
            MessageBox.Show("You didn't select any item yet. Please select an item.", Me.Text)
        End If
    End Sub

    

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ListView1Sorter = New lvColumnSorter()
        ListView1.ListViewItemSorter = ListView1Sorter
    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'If RadioButton2.Checked = True Then
        '    dtpPRDateFrom.Enabled = True
        '    dtpPRDateTo.Enabled = True
        '    dtpPRDateFrom.Value = Now
        '    dtpPRDateTo.Value = Now
        '    isShowAll = False
        'End If
    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'If RadioButton1.Checked = True Then
        '    dtpPRDateFrom.Enabled = False
        '    dtpPRDateTo.Enabled = False
        '    isShowAll = True
        'End If
    End Sub

    Private Sub cmbStatus_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbStatus.SelectedIndexChanged
        btnFilter_Click(sender, e)
    End Sub

    Private Sub txtSkuName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSkuName.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then btnFilter_Click(sender, e)
    End Sub

    Private Sub txtCName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCName.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then btnFilter_Click(sender, e)
    End Sub

    Private Sub txtSONo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSONo.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then btnFilter_Click(sender, e)
    End Sub

    Private Sub txtWONo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtWONo.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then btnFilter_Click(sender, e)
    End Sub

    Private Sub chbDate_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chbDate.CheckedChanged
        If chbDate.Checked = True Then
            dtpPRDateFrom.Enabled = True
            dtpPRDateTo.Enabled = True
            isShowAll = False
        Else
            dtpPRDateFrom.Enabled = False
            dtpPRDateTo.Enabled = False
            dtpPRDateFrom.Value = Now
            dtpPRDateTo.Value = Now
            isShowAll = True
        End If
    End Sub

    Private Sub btnClear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClear.Click
        chbDate.Checked = False
        txtSONo.Text = ""
        txtCName.Text = ""
        txtWONo.Text = ""
        txtSkuName.Text = ""
        cmbStatus.SelectedIndex = 0
    End Sub

    'Autorefresh---Hendra
    Public Sub frmWorkOrderListShow(ByVal sender As System.Object, ByVal e As System.EventArgs)
        btnFilter_Click(sender, e)
    End Sub
End Class