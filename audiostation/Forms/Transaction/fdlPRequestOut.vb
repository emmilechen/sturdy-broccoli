Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class fdlPRequestOut
    Dim m_FrmCallerId As String
    Dim m_POId As Integer
    Dim m_PchCodeId As Integer
    Private ListView1Sorter As lvColumnSorter
    Dim strConnection As String = My.Settings.ConnStr
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Dim cmd As SqlCommand

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        If ListView1.CheckedItems.Count > 0 Then
            Select Case m_FrmCallerId
                Case "frmPPitching"
                    With frmPPitching
                        If .POId = 0 Then .SavePOHeader()
                        If .POId > 0 Then
                            m_POId = .POId
                            FillUpPO()
                            .clear_lvw()
                            .refresh_total()
                        Else
                            MessageBox.Show("Can't insert to line items because error was happened before", Me.Text)
                        End If
                    End With

                Case "frmPO"
                    With frmPO
                        If .POId = 0 Then .SavePOHeader()
                        If .POId > 0 Then
                            m_POId = .POId
                            FillUpPO()
                            .clear_lvw()
                            .refresh_total()
                        Else
                            MessageBox.Show("Can't insert to line items because error was happened before", Me.Text)
                        End If
                    End With
            End Select
            Me.Close()
        Else
            MessageBox.Show("You didn't select any item yet. Please select an item.", Me.Text)
        End If
        'Me.DialogResult = System.Windows.Forms.DialogResult.OK
        'Me.Close()
        'If ListView1.SelectedItems.Count > 0 Then
        '    ListView1_DoubleClick(sender, e)
        'Else
        '    MessageBox.Show("You didn't select any item yet. Please select an item.", Me.Text)
        'End If
    End Sub

    Public Property FrmCallerId() As String
        Get
            Return m_FrmCallerId
        End Get
        Set(ByVal Value As String)
            m_FrmCallerId = Value
        End Set
    End Property

    Public Property PchCodeId() As Integer
        Get
            Return m_PchCodeId
        End Get
        Set(ByVal Value As Integer)
            m_PchCodeId = Value
        End Set
    End Property

    Sub FillUpPO()
        Try
            For i = 1 To ListView1.Items.Count
                If ListView1.Items(i - 1).Checked = True Then
                    cmd = New SqlCommand("usp_tr_po_dtl_INS", cn)
                    cmd.CommandType = CommandType.StoredProcedure

                    Dim prm1 As SqlParameter = cmd.Parameters.Add("@po_id", SqlDbType.Int)
                    prm1.Value = m_POId
                    Dim prm2 As SqlParameter = cmd.Parameters.Add("@po_dtl_type", SqlDbType.NVarChar)
                    prm2.Value = ListView1.Items(i - 1).SubItems.Item(3).Text
                    Dim prm3 As SqlParameter = cmd.Parameters.Add("@prequest_dtl_id", SqlDbType.Int)
                    prm3.Value = LeftSplitUF(ListView1.Items(i - 1).Tag)
                    Dim prm4 As SqlParameter = cmd.Parameters.Add("@sku_id", SqlDbType.Int)
                    prm4.Value = IIf(ListView1.Items(i - 1).SubItems.Item(3).Text = "S", ListView1.Items(i - 1).SubItems.Item(4).Text, 0)
                    Dim prm5 As SqlParameter = cmd.Parameters.Add("@po_dtl_desc", SqlDbType.NVarChar)
                    prm5.Value = ListView1.Items(i - 1).SubItems.Item(6).Text
                    Dim prm6 As SqlParameter = cmd.Parameters.Add("@po_qty", SqlDbType.Decimal)
                    prm6.Value = ListView1.Items(i - 1).SubItems.Item(7).Text
                    Dim prm7 As SqlParameter = cmd.Parameters.Add("@po_price", SqlDbType.Money)
                    prm7.Value = FormatNumber(ListView1.Items(i - 1).SubItems.Item(8).Text)
                    Dim prm8 As SqlParameter = cmd.Parameters.Add("@tax_percent", SqlDbType.Decimal)
                    prm8.Value = GetSysInit("tax_percent")
                    Dim prm9 As SqlParameter = cmd.Parameters.Add("@expense_id", SqlDbType.Int, 255)
                    prm9.Value = IIf(ListView1.Items(i - 1).SubItems.Item(3).Text = "E", ListView1.Items(i - 1).SubItems.Item(4).Text, 0)
                    cn.Open()
                    cmd.ExecuteReader()
                    cn.Close()
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
            If cn.State = ConnectionState.Open Then cn.Close()
        End Try
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        'Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub fdlPRequest_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With ListView1
            .Clear()
            .View = View.Details
            .Columns.Add("Purchase Request No.", 130)
            .Columns.Add("Date", 90)
            .Columns.Add("Required Date", 90)
            .Columns.Add("prequest_dtl_type", 0)
            .Columns.Add("sku_id", 0)
            .Columns.Add("sku_code", 0)
            .Columns.Add("Stock Name", 200)
            .Columns.Add("Qty", 90, HorizontalAlignment.Right)
            .Columns.Add("last_cost", 0)
        End With

        cmd = New SqlCommand("usp_tr_prequest_dtl_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm1 As SqlParameter = cmd.Parameters.Add("@outstanding", SqlDbType.Bit)
        prm1.Value = 1
        Dim prm2 As SqlParameter = cmd.Parameters.Add("@prequest_no", SqlDbType.NVarChar, 50)
        prm2.Value = IIf(txtPRequestNo.Text = "", DBNull.Value, txtPRequestNo.Text)
        Dim prm3 As SqlParameter = cmd.Parameters.Add("@sku_name", SqlDbType.NVarChar, 50)
        prm3.Value = IIf(txtFilter.Text = "", DBNull.Value, txtFilter.Text)
        Dim prm4 As SqlParameter = cmd.Parameters.Add("@pch_code_id", SqlDbType.Int)
        prm4.Value = m_PchCodeId

        cn.Open()

        Dim myReader As SqlDataReader = cmd.ExecuteReader()

        'Call FillList(myReader, Me.ListView1, 16, 1)
        Dim lvItem As ListViewItem
        Dim intCurrRow As Integer

        While myReader.Read
            lvItem = New ListViewItem(CStr(myReader.Item(10))) 'prequest_no
            lvItem.Tag = CStr(myReader.Item(0)) & "*~~~~~*" & intCurrRow 'ID
            'lvItem.Tag = "v" & CStr(DR.Item(0))
            lvItem.SubItems.Add(myReader.Item(11)) 'prequest_date
            lvItem.SubItems.Add(myReader.Item(12)) 'required_date
            lvItem.SubItems.Add(myReader.Item(2)) 'prequest_dtl_type
            Select Case myReader.GetString(2) 'sku_id, sku_code
                Case "S"
                    lvItem.SubItems.Add(myReader.GetInt32(4))
                    lvItem.SubItems.Add(myReader.GetString(5))
                Case "E"
                    lvItem.SubItems.Add(myReader.GetInt32(13))
                    lvItem.SubItems.Add(myReader.GetString(14))
                Case Else
                    lvItem.SubItems.Add("")
                    lvItem.SubItems.Add("")
            End Select
            lvItem.SubItems.Add(myReader.Item(6)) 'sku_name
            lvItem.SubItems.Add(myReader.GetValue(7)) 'prequest_qty
            lvItem.SubItems.Add(myReader.Item(15)) 'last_cost
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

        If ListView1.Items.Count > 0 Then chbSelectAll.Enabled = True Else chbSelectAll.Enabled = False
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
        'With frmPO
        '    .PrequestId = LeftSplitUF(ListView1.SelectedItems.Item(0).Tag)
        '    .PRequestNo = ListView1.SelectedItems.Item(0).SubItems.Item(0).Text
        '    .SKUId = ListView1.SelectedItems.Item(0).SubItems.Item(2).Text
        '    .SKUCode = ListView1.SelectedItems.Item(0).SubItems.Item(3).Text
        '    .SKUName = ListView1.SelectedItems.Item(0).SubItems.Item(4).Text
        '    .POQty = ListView1.SelectedItems.Item(0).SubItems.Item(5).Text
        'End With
        'Me.Close()
    End Sub

    Private Sub txtFilter_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFilter.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            fdlPRequest_Load(sender, e)
        End If
    End Sub

    Private Sub txtPRequestNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPRequestNo.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            fdlPRequest_Load(sender, e)
        End If
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ListView1Sorter = New lvColumnSorter()
        ListView1.ListViewItemSorter = ListView1Sorter
    End Sub

    Private Sub txtPRequestNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPRequestNo.TextChanged

    End Sub

    Private Sub chbSelectAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbSelectAll.CheckedChanged
        If chbSelectAll.Checked = True Then
            With ListView1
                For i = 1 To .Items.Count
                    .Items.Item(i - 1).Checked = True
                Next
            End With
        Else
            With ListView1
                For i = 1 To .Items.Count
                    .Items.Item(i - 1).Checked = False
                Next
            End With
        End If
    End Sub
End Class
