Option Explicit On
'Option Strict On
Imports System.Data.SqlClient
Imports System.Data.OleDb
Public Class frmSYSSetting
    Dim strConnection As String = My.Settings.ConnStr
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Dim cmd As SqlCommand
    Dim m_FirstFiscalMonth As Integer
    Private Sub frmSYSSetting_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        On Error Resume Next
        Dim field1 As String = ""
        cmbFirstFiscalMonth.Items.Clear()
        For i As Integer = 1 To 11
            field1 = field1 & " Select '" & i & "' as guidstr, '" & MonthName(i) & "' as nama UNION "
        Next
        AssignValuetoCombo(Me.cmbFirstFiscalMonth, field1, "12", "'" & MonthName(12) & "'", "mt_bank", "bank_account_id<>'0'", "guidstr")

        cbDecimal.Items.Clear() : field1 = ""
        For i = 0 To 5
            field1 = field1 & " Select '" & i & "' as guidstr, '" & i & "' as nama UNION "
        Next
        AssignValuetoCombo(Me.cbDecimal, field1, "6", "6", "mt_bank", "bank_account_id<>'0'", "guidstr")
        m_FirstFiscalMonth = IIf(GetSysInit("first_fiscal_month") = "", 0, GetSysInit("first_fiscal_month"))

        Dim mList As clsMyListInt
        For i = 1 To cmbFirstFiscalMonth.Items.Count
            mList = cmbFirstFiscalMonth.Items(i - 1)
            If m_FirstFiscalMonth = mList.ItemData Then
                cmbFirstFiscalMonth.SelectedValue = i - 1
                Exit For
            End If
        Next
        AssignValuetoCombo(Me.ComboBox1, "", "bank_id", "bank_code+'-'+bank_account_no", "mt_bank", "bank_account_id<>'0'", "bank_code")
        AssignValuetoCombo(Me.ComboBox2, "", "bank_id", "bank_code+'-'+bank_account_no", "mt_bank", "bank_account_id<>'0'", "bank_code")
        AssignValuetoCombo(Me.ComboBox3, "SELECT 0 as guidstr,'TIDAK' as nama UNION ", "1", "'YA'", "mt_bank", "bank_account_id<>'0'", "nama")
        FillSysInit(True, Me.TabPage1, "sys_init") : FillSysInit(True, Me.TabPage2, "sys_init") : FillSysInit(True, Me.TabPage3, "sys_init") : FillSysInit(True, Me.TabPage4, "sys_init")
        FillSysInit(True, Me.TabPage5, "sys_init") : FillSysInit(True, Me.TabPage6, "sys_init") : FillSysInit(True, Me.TabPage7, "sys_init") : FillSysInit(True, Me.TabPage8, "sys_init")
        With Me
            .ListView1.Columns.Clear()
            .ListView1.Columns.Add("Kolom 0", "guid", 0)
            .ListView1.Columns.Add("Kolom 1", "Document Name", Me.TextBox5.Width)
            .ListView2.Columns.Clear()
            .ListView2.Columns.Add("Kolom 0", "guid", 0)
            .ListView2.Columns.Add("Kolom 1", "Document Name", Me.TextBox6.Width)
        End With
        Me.ListView1.Items.Clear() : Me.ListView2.Items.Clear()
        opensearchform(Me.ListView1, "primarykey", "sys_dropdown_val", "sys_dropdown_id", "sys_dropdown a", "a.sys_dropdown_whr in ('" & Me.Label13.Tag & "')", "a.primarykey", 0)
        opensearchform(Me.ListView2, "primarykey", "sys_dropdown_val", "sys_dropdown_id", "sys_dropdown a", "a.sys_dropdown_whr in ('" & Me.Label14.Tag & "')", "a.primarykey", 0)
    End Sub
    Private Function opensearchform(ByVal namalistview As ListView, ByVal strfield1 As String, ByVal strfield2 As String, ByVal strfield3 As String, ByVal strtabel As String, ByVal strwhr As String, ByVal strord As String, Optional openargs As Integer = 0) As String
        'On Error Resume Next
        Dim cmd As SqlCommand
        Dim str(10) As String, strsql As String
        Dim itm As ListViewItem
        Dim dr As SqlDataReader
        If cn.State = ConnectionState.Closed Then cn.Open()
        With namalistview
            .Items.Clear()
            strsql = "SELECT " & strfield1 & ", " & strfield2 & ", " & strfield3 & " FROM " & strtabel & " where " & strwhr & " order by " & strord
            cmd = New SqlCommand(strsql, cn)
            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                Do While dr.Read()
                    str(0) = IIf(IsDBNull(dr.Item(0).ToString()), "#", dr.Item(0).ToString())
                    str(1) = IIf(IsDBNull(dr.Item(1).ToString()), "#", dr.Item(1).ToString())
                    itm = New ListViewItem(str)
                    .Items.Add(itm)
                Loop
            End If
            dr.Close()
            cmd.Dispose()
        End With
    End Function
    Private Sub btnexit_Click(sender As System.Object, e As System.EventArgs) Handles btnexit.Click
        Me.Close()
    End Sub
    Private Sub ToolStripButton1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton1.Click
        Try
            FillSysInit(False, Me.TabPage1, "sys_init") : FillSysInit(False, Me.TabPage2, "sys_init") : FillSysInit(False, Me.TabPage3, "sys_init") : FillSysInit(False, Me.TabPage4, "sys_init")
            FillSysInit(False, Me.TabPage5, "sys_init") : FillSysInit(False, Me.TabPage6, "sys_init") : FillSysInit(False, Me.TabPage7, "sys_init") : FillSysInit(False, Me.TabPage8, "sys_init")
            MsgBox("Successfully Saved", vbInformation, Me.Text)
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            If ConnectionState.Open = 1 Then cn.Close()
        End Try
    End Sub
    Private Sub btnSaveD_Click(sender As System.Object, e As System.EventArgs) Handles btnSaveD.Click
        'purchase_doc_rcpt_inv
        If Me.TextBox5.Tag = "" Then
            'insert
            Executestr("insert into sys_dropdown(sys_dropdown_whr,sys_dropdown_id,sys_dropdown_sort,sys_dropdown_val) values ('" & Me.Label13.Tag & "','" & Me.TextBox5.Text & "','0','" & Me.TextBox5.Text & "')")
        Else
            'update
            Executestr("update sys_dropdown SET sys_dropdown_id='" & Me.TextBox5.Text & "', sys_dropdown_sort='0', sys_dropdown_val='" & Me.TextBox5.Text & "' WHERE primarykey='" & Me.TextBox5.Tag & "'")
        End If
        Me.TextBox5.Tag = "" : Me.TextBox5.Text = ""
        opensearchform(Me.ListView1, "primarykey", "sys_dropdown_val", "sys_dropdown_id", "sys_dropdown a", "a.sys_dropdown_whr in ('" & Me.Label13.Tag & "')", "a.primarykey", 0)
    End Sub
    Private Sub ListView1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ListView1.SelectedIndexChanged
        If ListView1.SelectedItems.Count > 0 Then
            Me.TextBox5.Tag = Me.ListView1.Items(ListView1.FocusedItem.Index).Text
            Me.TextBox5.Text = Me.ListView1.Items(ListView1.FocusedItem.Index).SubItems(1).Text
        End If
    End Sub
    Private Sub Button5_Click(sender As System.Object, e As System.EventArgs) Handles Button5.Click
        'purchase_doc_rcpt_inv
        If Me.TextBox6.Tag = "" Then
            'insert
            Executestr("insert into sys_dropdown(sys_dropdown_whr,sys_dropdown_id,sys_dropdown_sort,sys_dropdown_val) values ('" & Me.Label14.Tag & "','" & Me.TextBox6.Text & "','0','" & Me.TextBox6.Text & "')")
        Else
            'update
            Executestr("update sys_dropdown SET sys_dropdown_id='" & Me.TextBox6.Text & "', sys_dropdown_sort='0', sys_dropdown_val='" & Me.TextBox6.Text & "' WHERE primarykey='" & Me.TextBox6.Tag & "'")
        End If
        Me.TextBox6.Tag = "" : Me.TextBox6.Text = ""
        opensearchform(Me.ListView2, "primarykey", "sys_dropdown_val", "sys_dropdown_id", "sys_dropdown a", "a.sys_dropdown_whr in ('" & Me.Label14.Tag & "')", "a.primarykey", 0)
    End Sub
    Private Sub ListView2_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ListView2.SelectedIndexChanged
        If ListView2.SelectedItems.Count > 0 Then
            Me.TextBox6.Tag = Me.ListView2.Items(ListView2.FocusedItem.Index).Text
            Me.TextBox6.Text = Me.ListView2.Items(ListView2.FocusedItem.Index).SubItems(1).Text
        End If
    End Sub
    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
            Me.TextBox1.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
            Me.TextBox2.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub
End Class