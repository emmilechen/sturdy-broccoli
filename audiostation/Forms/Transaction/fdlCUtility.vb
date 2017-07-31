Imports System.Windows.Forms
Imports System.Data.SqlClient
Public Class fdlCUtility
    Private ListView1Sorter As lvColumnSorter
    Dim strConnection As String = My.Settings.ConnStr
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Dim cmd As SqlCommand
    Dim m_FrmCallerId As String
    Dim Dec As Integer = GetSysInit("decimal_digit")
    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        ListView1Sorter = New lvColumnSorter()
        ListView1.ListViewItemSorter = ListView1Sorter
    End Sub
    Public Property FrmCallerId() As String
        Get
            Return m_FrmCallerId
        End Get
        Set(ByVal Value As String)
            m_FrmCallerId = Value
        End Set
    End Property
    Private Sub fdlCUtility_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        If cn.State = ConnectionState.Closed Then cn.Open()
        
        Select Case m_FrmCallerId
            Case "ftr_mp"
                With Me
                    .ListView1.Columns.Clear()
                    .ListView1.Columns.Add("Kolom 0", "guid", 0)
                    .ListView1.Columns.Add("Kolom 1", "Urut", 25)
                    .ListView1.Columns.Add("Kolom 2", "Kode", 100)
                    .ListView1.Columns.Add("Kolom 3", "Keterangan", 200)
                End With
                loaddata(m_FrmCallerId, "")
            Case "frmSO"

        End Select
        'Me.Close()
    End Sub
    Private Sub loaddata(openargs As String, cari As String)
        Select Case openargs
            Case Is = "ftr_mp" 'apa aj
                Select Case Me.Tag
                    Case Is = 1
                        opensearchform(Me.ListView1, "so_id", "squote_no", "squote_date, ref_no", "tr_so", "c_id in (" & ftr_mp.cmbcust.SelectedValue & ")" & cari, "squote_no", 0) ' : frfield = "3" : fr = "y.catcode" : frtable = "m_member x inner join M_Event_Category y on x.kodemember=y.catname "
                    Case Is = 2
                        opensearchform(Me.ListView1, "mt_sku.sku_id", "sku_code", "sku_name, sku_barcode", "dbo.tr_so INNER JOIN dbo.tr_so_dtl ON dbo.tr_so.so_id = dbo.tr_so_dtl.so_id INNER JOIN dbo.mt_sku ON dbo.tr_so_dtl.sku_id = dbo.mt_sku.sku_id", "c_id in (" & ftr_mp.cmbcust.SelectedValue & ")" & cari, "sku_code", 0) ' : frfield = "3" : fr = "y.catcode" : frtable = "m_member x inner join M_Event_Category y on x.kodemember=y.catname "
                End Select
        End Select
        'kosong()
        Me.Text = "Utility Form - " & Me.ListView1.Items.Count & " records"
    End Sub
    Private Function opensearchform(ByVal namalistview As ListView, ByVal strfield1 As String, ByVal strfield2 As String, ByVal strfield3 As String, ByVal strtabel As String, ByVal strwhr As String, ByVal strord As String, Optional openargs As Integer = 0) As String
        On Error Resume Next
        Dim cmd As SqlCommand
        Dim str(10) As String, strsql As String
        Dim itm As ListViewItem
        Dim dr As SqlDataReader

        With namalistview
            .Items.Clear()
            strsql = "SELECT " & strfield1 & ", " & strfield2 & ", " & strfield3 & " FROM " & strtabel & " where " & strwhr & " order by " & strord
            cmd = New SqlCommand(strsql, cn)
            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                Do While dr.Read()
                    str(0) = IIf(IsDBNull(dr.Item(0).ToString()), "#", dr.Item(0).ToString())
                    str(1) = IIf(IsDBNull(dr.Item(1).ToString()), "#", dr.Item(1).ToString())
                    str(2) = IIf(IsDBNull(dr.Item(2).ToString()), "#", dr.Item(2).ToString())
                    str(3) = IIf(IsDBNull(dr.Item(3).ToString()), "#", dr.Item(3).ToString())

                    itm = New ListViewItem(str)
                    .Items.Add(itm)
                Loop
            End If
            dr.Close()
            cmd.Dispose()
        End With
    End Function
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
    Private Sub ListView1_DoubleClick(sender As Object, e As System.EventArgs) Handles ListView1.DoubleClick
        If ListView1.SelectedItems.Count > 0 Then
            Select Case m_FrmCallerId
                Case "ftr_mp"
                    With ftr_mp
                        Select Case Me.Tag
                            Case Is = "1"
                                .soid = ListView1.SelectedItems.Item(0).Text
                                .sono = ListView1.SelectedItems.Item(0).SubItems.Item(1).Text
                                .txtpono.Text = ListView1.SelectedItems.Item(0).SubItems.Item(3).Text
                            Case Is = "2"
                                .txtskuid.Text = ListView1.SelectedItems.Item(0).Text
                                .TextBox4.Text = ListView1.SelectedItems.Item(0).SubItems.Item(1).Text
                                .TextBox5.Text = ListView1.SelectedItems.Item(0).SubItems.Item(2).Text
                                .TextBox1.Text = "PCS"
                                .txtguid_d.Text = 0
                        End Select
                        
                    End With
                Case "frmSO"
                    With frmSO
                        .SKUId = LeftSplitUF(ListView1.SelectedItems.Item(0).Tag)
                        .SKUCode = ListView1.SelectedItems.Item(0).SubItems.Item(1).Text
                        .SKUName = ListView1.SelectedItems.Item(0).SubItems.Item(2).Text
                        .SalesDiscount = ListView1.SelectedItems.Item(0).SubItems.Item(5).Text * 100
                        '.SalesPrice = FormatNumber(CDbl(ListView1.SelectedItems.Item(0).SubItems.Item(6).Text) / .ntbSOCurrRate.DecimalValue, Dec)
                        .SalesPrice = FormatNumber(ListView1.SelectedItems.Item(0).SubItems.Item(6).Text, Dec)
                        '.SKUPackageCheck = ListView1.SelectedItems.Item(0).SubItems.Item(10).Text
                        '.SKUUoM = ListView1.SelectedItems.Item(0).SubItems.Item(13).Text
                    End With
            End Select
        Else
            MessageBox.Show("You didn't select any item yet. Please select an item.", Me.Text)
        End If
        
        Me.Close()
    End Sub


End Class