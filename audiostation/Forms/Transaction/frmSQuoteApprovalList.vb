Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class frmSQuoteApprovalList
    Private ListView1Sorter As lvColumnSorter
    Dim strConnection As String = My.Settings.ConnStr
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Dim cmd As SqlCommand
    Dim isShowAll As Boolean = False

    Private Sub btnApproval_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApproval.Click
        If ListView1.CheckedItems.Count > 0 Then
            For i = 1 To ListView1.Items.Count
                If ListView1.Items(i - 1).Checked = True Then
                    cmd = New SqlCommand("usp_tr_so_APPROVAL", cn)
                    cmd.CommandType = CommandType.StoredProcedure

                    Dim prm1 As SqlParameter = cmd.Parameters.Add("@so_id", SqlDbType.Int, 255)
                    prm1.Value = LeftSplitUF(ListView1.Items(i - 1).Tag)
                    Dim prm2 As SqlParameter = cmd.Parameters.Add("@squote_status", SqlDbType.NVarChar)
                    prm2.Value = "A"
                    Dim prm3 As SqlParameter = cmd.Parameters.Add("@user_name", SqlDbType.NVarChar, 50)
                    prm3.Value = My.Settings.UserName

                    cn.Open()
                    cmd.ExecuteReader()
                    cn.Close()
                End If
            Next
            btnFilter_Click(sender, e)
        Else
            MessageBox.Show("You didn't select any item yet. Please select an item.", Me.Text)
        End If
    End Sub

    Private Sub frmPPitchingApprovalList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        chbDate.Checked = False
        chbDate_CheckedChanged(sender, e)

        btnFilter_Click(sender, e)
    End Sub

    Private Sub ListView1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.Click
        'lblCurrentRecord.Text = "Selected record: " + CStr(CInt(RightSplitUF(ListView1.SelectedItems.Item(0).Tag) + 1))
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
        Dim isDeletedRecord As Boolean = False
        cmd = New SqlCommand("usp_tr_so_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm1 As SqlParameter = cmd.Parameters.Add("@so_id", SqlDbType.Int)
        prm1.Value = LeftSplitUF(ListView1.SelectedItems.Item(0).Tag)
        Dim prm2 As SqlParameter = cmd.Parameters.Add("@trx_type", SqlDbType.NVarChar)
        prm2.Value = "squote"

        cn.Open()

        Dim myReader As SqlDataReader = cmd.ExecuteReader()

        If myReader.HasRows = False Then
            MsgBox("This record has been deleted before.", vbCritical + vbOKOnly, Me.Text)
            isDeletedRecord = True
        End If
        myReader.Close()
        cn.Close()

        If Not isDeletedRecord = False Then
            btnFilter_Click(sender, e)
        ElseIf Not Application.OpenForms().OfType(Of frmSQuote).Any Then
            With frmSQuote
                .SOId = LeftSplitUF(ListView1.SelectedItems.Item(0).Tag)
                .FrmCallerId = Me.Name
                .MdiParent = frmMAIN
                .Show()
            End With
        End If
    End Sub

    Private Sub txtPONo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPRequestNo.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then btnFilter_Click(sender, e)
    End Sub

    Private Sub txtSName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPRequester.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then btnFilter_Click(sender, e)
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        If ListView1.SelectedItems.Count > 0 Then
            ListView1_DoubleClick(sender, e)
        Else
            MessageBox.Show("You didn't select any item yet. Please select an item.", Me.Text)
        End If
    End Sub

    Private Sub ListView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.SelectedIndexChanged

    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ListView1Sorter = New lvColumnSorter()
        ListView1.ListViewItemSorter = ListView1Sorter
    End Sub

    Private Sub cmbStatus_Click(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub cmbStatus_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        btnFilter_Click(sender, e)
    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'If RadioButton1.Checked = True Then
        '    dtpPRequestDateFrom.Enabled = False
        '    dtpPRequestDateTo.Enabled = False
        '    'txtPONo.Text = ""
        '    'txtSName.Text = ""
        '    'cmbStatus.SelectedIndex = -1
        '    isShowAll = True
        'End If
    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'If RadioButton2.Checked = True Then
        '    dtpPRequestDateFrom.Enabled = True
        '    dtpPRequestDateTo.Enabled = True
        '    dtpPRequestDateFrom.Value = Now
        '    dtpPRequestDateTo.Value = Now
        '    isShowAll = False
        'End If
    End Sub

    Private Sub btnFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        With ListView1
            .Clear()
            .View = View.Details
            .Columns.Add("Quotation No.", 120)
            .Columns.Add("Date", 90)
            .Columns.Add("sls_code_id", 0)
            .Columns.Add("sales_code", 0)
            .Columns.Add("Requester", 300)
            .Columns.Add("DeliveryDate", 0)
            .Columns.Add("Remarks", 0)
            .Columns.Add("squote_status", 0)
            .Columns.Add("Status", 120)
        End With

        cmd = New SqlCommand("usp_tr_so_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm1 As SqlParameter = cmd.Parameters.Add("@so_id", SqlDbType.Int, 255)
        prm1.Value = 0
        Dim prm2 As SqlParameter = cmd.Parameters.Add("@squote_no", SqlDbType.NVarChar, 50)
        prm2.Value = IIf(txtPRequestNo.Text = "", DBNull.Value, txtPRequestNo.Text)
        Dim prm3 As SqlParameter = cmd.Parameters.Add("@squote_date1", SqlDbType.SmallDateTime)
        prm3.Value = IIf(isShowAll = False, dtpPRequestDateFrom.Value.Date, DBNull.Value)
        Dim prm4 As SqlParameter = cmd.Parameters.Add("@squote_date2", SqlDbType.SmallDateTime)
        prm4.Value = IIf(isShowAll = False, dtpPRequestDateTo.Value.Date, DBNull.Value)
        Dim prm5 As SqlParameter = cmd.Parameters.Add("@srequester", SqlDbType.NVarChar, 50)
        prm5.Value = IIf(txtPRequester.Text = "", DBNull.Value, txtPRequester.Text)
        Dim prm6 As SqlParameter = cmd.Parameters.Add("@squote_status", SqlDbType.NVarChar, 50)
        prm6.Value = "W"
        Dim prm7 As SqlParameter = cmd.Parameters.Add("@trx_type", SqlDbType.NVarChar)
        prm7.Value = "squote"

        cn.Open()

        Dim myReader As SqlDataReader = cmd.ExecuteReader()
        Dim lvItem As ListViewItem
        Dim intCurrRow As Integer

        'Call FillList(myReader, Me.ListView1, 8, 1)
        While myReader.Read
            lvItem = New ListViewItem(CStr(myReader.Item(30)))
            lvItem.Tag = CStr(myReader.Item(0)) & "*~~~~~*" & intCurrRow 'ID
            'lvItem.Tag = "v" & CStr(DR.Item(0))
            lvItem.SubItems.Add(myReader.Item(31))
            lvItem.SubItems.Add(myReader.GetInt32(15))
            lvItem.SubItems.Add(myReader.GetString(16))
            lvItem.SubItems.Add(myReader.GetString(33))
            lvItem.SubItems.Add(myReader.GetDateTime(9))
            lvItem.SubItems.Add(IIf(myReader.Item(14) Is DBNull.Value, "", myReader.Item(14)))
            lvItem.SubItems.Add(myReader.GetString(32))
            lvItem.SubItems.Add(myReader.GetString(8))

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

    Private Sub btnReject_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReject.Click
        If ListView1.CheckedItems.Count > 0 Then
            cn.Open()
            For i = 1 To ListView1.Items.Count
                If ListView1.Items(i - 1).Checked = True Then
                    cmd = New SqlCommand("usp_tr_so_APPROVAL", cn)
                    cmd.CommandType = CommandType.StoredProcedure

                    Dim prm1 As SqlParameter = cmd.Parameters.Add("@so_id", SqlDbType.Int, 255)
                    prm1.Value = LeftSplitUF(ListView1.Items(i - 1).Tag)
                    Dim prm2 As SqlParameter = cmd.Parameters.Add("@squote_status", SqlDbType.NVarChar)
                    prm2.Value = "R"
                    Dim prm3 As SqlParameter = cmd.Parameters.Add("@user_name", SqlDbType.NVarChar, 50)
                    prm3.Value = My.Settings.UserName

                    cmd.ExecuteReader()
                End If
            Next
            cn.Close()
            btnFilter_Click(sender, e)
        Else
            MessageBox.Show("You didn't select any item yet. Please select an item.", Me.Text)
        End If
    End Sub
    Private Sub chbDate_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chbDate.CheckedChanged
        If chbDate.Checked = True Then
            dtpPRequestDateFrom.Enabled = True
            dtpPRequestDateTo.Enabled = True
            isShowAll = False
        Else
            dtpPRequestDateFrom.Enabled = False
            dtpPRequestDateTo.Enabled = False
            dtpPRequestDateFrom.Value = Now
            dtpPRequestDateTo.Value = Now
            isShowAll = True
        End If
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        chbDate.Checked = False
        txtPRequestNo.Text = ""
        txtPRequester.Text = ""
    End Sub

    'Autorefresh---Hendra
    Public Sub frmPRequestApprovalListShow(ByVal sender As System.Object, ByVal e As System.EventArgs)
        btnFilter_Click(sender, e)
    End Sub
End Class
