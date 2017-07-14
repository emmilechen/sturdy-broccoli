Imports System.Data.SqlClient
Imports System.Data.OleDb
Public Class frmUtility
    Private m_SortingColumn As ColumnHeader, frfield As String, fr As String, frtable As String, frwhere As String
    Dim strConnection As String = My.Settings.ConnStr
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Public Sub New(ByVal openargs As String, ByVal judul As String)
        ' This call is required by the designer.
        InitializeComponent()
        Me.txtopenargs.Text = openargs
        Me.Text = judul
        ' Add any initialization after the InitializeComponent() call.
    End Sub
    Private Sub frmUtility_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Top = 0 : Me.Left = 0
        If cn.State = ConnectionState.Closed Then cn.Open()
        With Me
            .ListView1.Columns.Clear()
            .ListView1.Columns.Add("Kolom 0", "guid", 0)
            .ListView1.Columns.Add("Kolom 1", "Urut", Me.txtseq.Width + 5)
            .ListView1.Columns.Add("Kolom 2", "Kode", Me.txtkode.Width + 5)
            .ListView1.Columns.Add("Kolom 3", "Keterangan", Me.txtket.Width - 5)
        End With
        kosong()
        loaddata(Me.txtopenargs.Text, "")
        Me.btndelete.Enabled = False
        Me.btncancel.Enabled = False
        Me.btnsave.Enabled = True
        Me.btnnew.Enabled = True
    End Sub
    Private Sub kosong()
        Me.txtseq.Text = ""
        Me.txtkode.Text = ""
        Me.txtket.Text = "" ': Me.txtket2.Text = ""
        Me.txtguid.Text = ""
        Me.btndelete.Enabled = False
        Me.btncancel.Enabled = False
        Me.btnsave.Enabled = True
        Me.btnnew.Enabled = True
        'loaddata(Me.txtopenargs.Text, "")
        'Me.cmddel.Enabled = False
        'Me.cmdfind.Enabled = False
        'Me.ListView2.Items.Clear()
        'Me.Width = 544
        Me.txtkode.Focus()
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
    Private Function autocompletetext(ByVal namatextbox As TextBox, ByVal outputfield As String, ByVal namatable As String, ByVal kondisi As String, ByVal urutkan As String) As String
        On Error Resume Next
        Dim cmd As SqlCommand
        Dim str(10) As String, strsql As String
        Dim itm As ListViewItem
        Dim dr As SqlDataReader
        If Len(Me.txtsearch.Text) > 1 Then Exit Function
        strsql = "SELECT " & outputfield & " FROM " & namatable & " where " & kondisi & " order by " & urutkan
        cmd = New SqlCommand(strsql, cn)
        dr = cmd.ExecuteReader()
        If dr.HasRows Then
            Do While dr.Read()
                str(0) = IIf(IsDBNull(dr.Item(0).ToString()), "#", dr.Item(0).ToString())
                namatextbox.AutoCompleteCustomSource.Add(str(0))
            Loop
        End If
        dr.Close()
        cmd.Dispose()
    End Function
    Private Sub loaddata(openargs As String, cari As String)
        Select Case openargs
            Case Is = "unit_user_dept", "unit_user_div", "unit_uom_machine_elec", "unit_uom_machine_size", "unit_uom_machine_speed", "machine_cat", "machine_subcat", "machine_division" 'apa aj
                opensearchform(Me.ListView1, "primarykey", "sys_dropdown_sort", "sys_dropdown_id, sys_dropdown_val", "sys_dropdown", "sys_dropdown_whr in ('" & openargs & "')" & cari, "sys_dropdown_sort", 0) : frfield = "3" : fr = "y.catcode" : frtable = "m_member x inner join M_Event_Category y on x.kodemember=y.catname " : Me.btndelete.Enabled = False : Me.btnsave.Enabled = False : Me.btnnew.Enabled = False
                autocompletetext(Me.txtkode, "distinct sys_dropdown_id", "sys_dropdown", "sys_dropdown_whr in ('" & openargs & "')", "sys_dropdown_id")
        End Select
        'kosong()
        Me.lblreckiri.Text = Me.ListView1.Items.Count & " records"
    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ListView1.SelectedIndexChanged
        Dim cmd1 As SqlCommand
        Dim strsql As String
        Dim itm As ListViewItem
        Dim dr1 As SqlDataReader
        If Me.ListView1.SelectedItems.Count = 0 Then Exit Sub
        Me.txtguid.Text = Me.ListView1.SelectedItems(0).Text
        strsql = "SELECT * FROM sys_dropdown where primarykey=" & Me.txtguid.Text
        cmd1 = New SqlCommand(strsql, cn)
        dr1 = cmd1.ExecuteReader()
        If dr1.HasRows Then
            If dr1.Read() Then
                Me.txtseq.Text = dr1.Item("sys_dropdown_sort").ToString() '
                Me.txtkode.Text = dr1.Item("sys_dropdown_id").ToString() 'Me.ListView1.SelectedItems(0).SubItems(1).Text
                Me.txtket.Text = dr1.Item("sys_dropdown_val").ToString() ' Me.ListView1.SelectedItems(0).SubItems(2).Text

            End If
        End If
        cmd1.Dispose()
        dr1.Close()
        Me.btndelete.Enabled = True
        Me.btncancel.Enabled = True
        Me.btnsave.Enabled = True
    End Sub

    Private Sub btncancel_Click(sender As System.Object, e As System.EventArgs) Handles btncancel.Click
        loaddata(Me.txtopenargs.Text, "")
        Me.btndelete.Enabled = False
        Me.btncancel.Enabled = False
        Me.btnsave.Enabled = True
        Me.btnnew.Enabled = True
        Me.txtkode.Focus()
    End Sub

    Private Sub btnnew_Click(sender As System.Object, e As System.EventArgs) Handles btnnew.Click
        kosong()
        'loaddata(Me.txtopenargs.Text, "")
        
    End Sub
    Private Sub btnsave_Click(sender As System.Object, e As System.EventArgs) Handles btnsave.Click
        If Me.txtseq.Text = "" Or Me.txtkode.Text = "" Or Me.txtket.Text = "" Then Exit Sub
        If MsgBox("Data akan disimpan, lanjutkan ?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, Me.Text) = MsgBoxResult.Yes Then
            If Me.txtguid.Text = "" Then
                'insert
                Executestr("insert into sys_dropdown(sys_dropdown_whr,sys_dropdown_id,sys_dropdown_sort,sys_dropdown_val) values ('" & Me.txtopenargs.Text & "','" & Me.txtkode.Text & "','" & Me.txtseq.Text & "','" & Me.txtket.Text & "')")
            Else
                'update
                Executestr("update sys_dropdown SET sys_dropdown_id='" & Me.txtkode.Text & "',sys_dropdown_sort='" & Me.txtseq.Text & "',sys_dropdown_val='" & Me.txtket.Text & "' WHERE primarykey=" & Me.txtguid.Text)
            End If
            kosong()
            loaddata(Me.txtopenargs.Text, "")
            Me.btndelete.Enabled = False
            Me.btncancel.Enabled = False
            Me.btnsave.Enabled = True
            Me.btnnew.Enabled = True
        Else
        End If
    End Sub

    Private Sub btnexit_Click(sender As System.Object, e As System.EventArgs) Handles btnexit.Click
        Me.Close()
    End Sub
End Class