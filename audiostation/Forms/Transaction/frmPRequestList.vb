﻿Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class frmPRequestList
    Private ListView1Sorter As lvColumnSorter
    Dim strConnection As String = My.Settings.ConnStr
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Dim cmd As SqlCommand
    Dim isShowAll As Boolean = False

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        With frmPRequest
            .FrmCallerId = Me.Name
            .PRequestId = 0
            'frmPRequest.ShowDialog()
            .MdiParent = frmMAIN
            .Show()
        End With
    End Sub

    Private Sub frmPRequestList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Add item cmbPOStatus
        cmd = New SqlCommand("sp_sys_dropdown_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm1 = cmd.Parameters.Add("@sys_dropdown_whr", SqlDbType.NVarChar, 50)
        prm1.Value = "prequest_status"

        cn.Open()
        Dim myReader = cmd.ExecuteReader

        cmbStatus.Items.Add(New clsMyListStr("All", ""))
        While myReader.Read
            cmbStatus.Items.Add(New clsMyListStr(myReader.GetString(1), myReader.GetString(0)))
        End While

        chbDate.Checked = False
        chbDate_CheckedChanged(sender, e)

        myReader.Close()
        cn.Close()

        'Add item cmbPRequestPriority
        cmd = New SqlCommand("sp_sys_dropdown_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        prm1 = cmd.Parameters.Add("@sys_dropdown_whr", SqlDbType.NVarChar, 50)
        prm1.Value = "prequest_priority"

        cn.Open()
        myReader = cmd.ExecuteReader()

        cmbPRequestPriority.Items.Add(New clsMyListStr("All", ""))
        While myReader.Read
            cmbPRequestPriority.Items.Add(New clsMyListStr(myReader.GetString(1), myReader.GetString(0)))
        End While

        myReader.Close()
        cn.Close()

        cmbPRequestPriority.SelectedIndex = 0
        cmbStatus.SelectedIndex = 0

        btnFilter_Click(sender, e)
        
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
        If Not isDeletedRecord("usp_tr_prequest_SEL", "prequest_id", LeftSplitUF(ListView1.SelectedItems.Item(0).Tag), Me.Text) = False Then
            btnFilter_Click(sender, e)
        ElseIf Not Application.OpenForms().OfType(Of frmPRequest).Any Then
            With frmPRequest
                .PRequestId = LeftSplitUF(ListView1.SelectedItems.Item(0).Tag)
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

    Private Sub cmbStatus_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbStatus.SelectedIndexChanged
        If cmbStatus.SelectedIndex = -1 Then
            cmbStatus.Text = "All"
        End If
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
            .Columns.Add("Purchase Request No.", 120)
            .Columns.Add("Date", 90)
            .Columns.Add("pch_code_id", 0)
            .Columns.Add("purchase_code", 0)
            .Columns.Add("Priority", 90)
            .Columns.Add("DeliveryDate", 0)
            .Columns.Add("Remarks", 0)
            .Columns.Add("prequest_status", 0)
            .Columns.Add("Status", 120)
        End With

        cmd = New SqlCommand("usp_tr_prequest_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure
        '       @prequest_id int = 0,
        '@prequest_no nvarchar(50) = null,
        '@prequest_date1 smalldatetime = null,
        '@prequest_date2 smalldatetime = null,
        '@prequester nvarchar(50) = null,
        '@prequest_status nvarchar(50) = null,
        '@prequest_priority nvarchar(50) = null
        Dim prm1 As SqlParameter = cmd.Parameters.Add("@prequest_id", SqlDbType.Int, 255)
        prm1.Value = 0
        Dim prm2 As SqlParameter = cmd.Parameters.Add("@prequest_no", SqlDbType.NVarChar, 50)
        prm2.Value = IIf(txtPRequestNo.Text = "", DBNull.Value, txtPRequestNo.Text)
        Dim prm3 As SqlParameter = cmd.Parameters.Add("@prequest_date1", SqlDbType.SmallDateTime)
        prm3.Value = IIf(isShowAll = False, dtpPRequestDateFrom.Value.Date, DBNull.Value)
        Dim prm4 As SqlParameter = cmd.Parameters.Add("@prequest_date2", SqlDbType.SmallDateTime)
        prm4.Value = IIf(isShowAll = False, dtpPRequestDateTo.Value.Date, DBNull.Value)
        Dim prm5 As SqlParameter = cmd.Parameters.Add("@prequester", SqlDbType.NVarChar, 50)
        prm5.Value = IIf(txtPRequester.Text = "", DBNull.Value, txtPRequester.Text)
        Dim prm6 As SqlParameter = cmd.Parameters.Add("@prequest_status", SqlDbType.NVarChar, 50)
        If cmbStatus.SelectedIndex = 0 Or cmbStatus.Text = "" Then
            prm6.Value = DBNull.Value
        Else
            prm6.Value = cmbStatus.Items(cmbStatus.SelectedIndex).ItemData
        End If
        Dim prm7 As SqlParameter = cmd.Parameters.Add("@prequest_priority", SqlDbType.NVarChar, 50)
        If cmbPRequestPriority.SelectedIndex = 0 Then
            prm7.Value = DBNull.Value
        Else
            prm7.Value = cmbPRequestPriority.Items(cmbPRequestPriority.SelectedIndex).ItemData
        End If
        If cn.State = ConnectionState.Closed Then cn.Open()

        Dim myReader As SqlDataReader = cmd.ExecuteReader()

        Call FillList(myReader, Me.ListView1, 9, 1)
        'While myReader.Read
        '    Dim lvw As ListViewItem
        '    lvw = ListView1.Items.Add(myReader.GetString(1))
        '    lvw.SubItems.Add(myReader.GetDateTime(2))
        '    lvw.SubItems.Add(myReader.GetInt32(3))
        '    lvw.SubItems.Add(myReader.GetString(4))
        '    lvw.SubItems.Add(myReader.GetString(5))
        'End While
        myReader.Close()
        cn.Close()
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        chbDate.Checked = False
        txtPRequestNo.Text = ""
        txtPRequester.Text = ""
        cmbStatus.SelectedIndex = 0
        cmbPRequestPriority.SelectedIndex = 0
    End Sub

    Private Sub chbDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbDate.CheckedChanged
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
    'Autorefresh---Hendra
    Public Sub frmPRequestListShow(ByVal sender As System.Object, ByVal e As System.EventArgs)
        btnFilter_Click(sender, e)
    End Sub

    Private Sub cmbPRequestPriority_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPRequestPriority.SelectedIndexChanged
        If cmbPRequestPriority.SelectedIndex = -1 Then
            cmbPRequestPriority.Text = "All"
        End If
        btnFilter_Click(sender, e)
    End Sub
End Class
