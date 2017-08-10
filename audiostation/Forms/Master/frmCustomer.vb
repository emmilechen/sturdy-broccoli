Imports System.Data.SqlClient
Imports System.Data.OleDb
Public Class frmCustomer
    Private m_CurrId As Integer, m_CId As Integer, isAllowDelete As Boolean
    Dim strConnection As String = My.Settings.ConnStr
    Private strConn As String = My.Settings.ConnStr
    Private sqlCon As SqlConnection
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Dim cmd As SqlCommand, ctrlstr As String = ""
    Private namatable As String, namafieldPK As String
    Private Sub kosong()
        ClearObjectonForm(Me)
        clear_lvw2()
        AssignValuetoCombo(Me.cmbCCategory, "", "sys_dropdown_val", "sys_dropdown_val", "sys_dropdown", "sys_dropdown_whr='unit_customer_category'", "sys_dropdown_sort")
        AssignValuetoCombo(Me.cmbCTitle, "", "sys_dropdown_val", "sys_dropdown_val", "sys_dropdown", "sys_dropdown_whr='unit_customer_title'", "sys_dropdown_sort")
        With Me
            .ListView1.Columns.Clear()
            .ListView1.Columns.Add("Kolom 0", "", 50)
            .ListView1.Columns.Add("Kolom 1", "Keterangan", Me.ListView1.Width - 50)
            .ListView1.Columns.Add("Kolom 2", "kode", 0)
            .ListView1.Columns.Add("Kolom 3", "guid", 0)
            .ListView1.Columns(0).DisplayIndex = .ListView1.Columns.Count - 1
            .ListView1.CheckBoxes = False
        End With
        Me.btncancel.Enabled = False
        Me.btndelete.Enabled = False
        Me.TabControl1.SelectedTab = Me.TabPage1
        Me.cmbCTitle.Focus()
    End Sub
    Private Function isirecord(ByVal guidno As Integer)
        'Me.txtguid.Text = guidno ' : Me.txtkode.Text = guidno
        Me.ListView1.CheckBoxes = True
        Fillobject(Me.txtguid, Me.TabPage1, "select", "sp_mt_customer", Me.txtguid.Text, "@c_id") : clear_lvw2()
        opensearchform(Me.ListView1, "primarykey", "sys_dropdown_sort", "sys_dropdown_id, sys_dropdown_val", "sys_dropdown", "sys_dropdown_whr in ('machine_division')", "sys_dropdown_sort", 0)
        Me.btncancel.Enabled = True : Me.btndelete.Enabled = True
    End Function
    Private Function opensearchform(ByVal namalistview As ListView, ByVal strfield1 As String, ByVal strfield2 As String, ByVal strfield3 As String, ByVal strtabel As String, ByVal strwhr As String, ByVal strord As String, Optional openargs As Integer = 0) As String
        On Error Resume Next
        Dim cmd As SqlCommand
        Dim str(10) As String, strsql As String
        Dim itm As ListViewItem
        Dim dr As SqlDataReader, ix As Integer = 0
        If cn.State = ConnectionState.Closed Then cn.Open()
        With namalistview
            .Items.Clear()
            strsql = "SELECT " & strfield1 & ", " & strfield2 & ", " & strfield3 & " FROM " & strtabel & " where " & strwhr & " order by " & strord
            cmd = New SqlCommand(strsql, cn)
            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                Do While dr.Read()
                    str(0) = "" 'IIf(IsDBNull(dr.Item(0).ToString()), "#", dr.Item(0).ToString())
                    str(1) = IIf(IsDBNull(dr.Item(3).ToString()), "#", dr.Item(3).ToString())
                    str(2) = IIf(IsDBNull(dr.Item(2).ToString()), "#", dr.Item(2).ToString())
                    str(3) = IIf(IsDBNull(dr.Item(0).ToString()), "#", dr.Item(0).ToString())
                    itm = New ListViewItem(str)
                    .Items.Add(itm)
                    If Me.txtguid.Text <> "" Then namalistview.Items(CInt(ix)).Checked = IIf(GetCurrentID("pk_mesin_id", "rt_mesin_div", "flag_id=2 and pk_mesin_id='" & Me.txtCCode.Text & "' and pk_mesin_idf='" & dr.Item(0).ToString() & "'") = Me.txtCCode.Text, True, False)
                    ix = ix + 1
                Loop
            End If
            dr.Close()
            cmd.Dispose()
        End With
    End Function
    Private Sub frmCustomer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error Resume Next
        If cn.State = ConnectionState.Closed Then cn.Open()
        namatable = "mt_customer" : namafieldPK = "c_id"
        If Me.txtCCode.Text = "" Then
            kosong()
        Else
            'isirec
            'kosong()
        End If
        Me.Left = 0 : Me.Top = 0
    End Sub
    Public Property CurrId() As Integer
        Get
            Return m_CurrId
        End Get
        Set(ByVal Value As Integer)
            m_CurrId = Value
        End Set
    End Property
    Public Property CurrCode() As String
        Get
            Return txtCCurrCode.Text
        End Get
        Set(ByVal Value As String)
            txtCCurrCode.Text = Value
        End Set
    End Property
    Sub clear_lvw2()
        With ListView2
            .Clear()
            .View = View.Details
            .Columns.Add("period_id", 0)
            .Columns.Add("Period Name", 120)
            .Columns.Add("Beginning Balance", 120, HorizontalAlignment.Right)
            .Columns.Add("Base Beginning Balance", 120, HorizontalAlignment.Right)
            .Columns.Add("Total Trans", 120, HorizontalAlignment.Right)
            .Columns.Add("Base Total Trans", 120, HorizontalAlignment.Right)
        End With

        cmd = New SqlCommand("sp_mt_customer_balance_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm1 As SqlParameter = cmd.Parameters.Add("@c_id", SqlDbType.Int, 255)
        prm1.Value = m_CId

        If cn.State = ConnectionState.Closed Then cn.Open()

        Dim myReader As SqlDataReader = cmd.ExecuteReader()

        'Call FillList(myReader, Me.ListView2, 6, 1)
        Dim lvItem As ListViewItem
        Dim intCurrRow As Integer

        While myReader.Read
            lvItem = New ListViewItem(CStr(myReader.Item(1))) 'period_id
            lvItem.Tag = CStr(myReader.Item(0)) & "*~~~~~*" & intCurrRow 'balance_id
            'lvItem.Tag = "v" & CStr(DR.Item(0))
            lvItem.SubItems.Add(myReader.Item(2)) 'period_name
            lvItem.SubItems.Add(FormatNumber(myReader.Item(3))) 'bal_begin
            lvItem.SubItems.Add(FormatNumber(myReader.Item(5))) 'base_bal_begin
            lvItem.SubItems.Add(FormatNumber(myReader.Item(4))) 'total_trans
            lvItem.SubItems.Add(FormatNumber(myReader.Item(6))) 'base_total_trans
            If intCurrRow Mod 2 = 0 Then
                lvItem.BackColor = Color.Lavender
            Else
                lvItem.BackColor = Color.White
            End If
            lvItem.UseItemStyleForSubItems = True

            ListView2.Items.Add(lvItem)
            intCurrRow += 1
        End While

        myReader.Close()
        cn.Close()
    End Sub
    Sub lock_obj(ByVal isLock As Boolean)
        txtCCode.ReadOnly = isLock
        txtCName.ReadOnly = isLock
        cmbCCategory.Enabled = Not isLock
        txtCNpwp.ReadOnly = isLock
        txtCAddress1.ReadOnly = isLock
        txtCAddress2.ReadOnly = isLock
        txtCContact.ReadOnly = isLock
        txtCPhone.ReadOnly = isLock
        txtCFax.ReadOnly = isLock
        txtCEmail.ReadOnly = isLock
        txtCTPBNo.ReadOnly = isLock
        txtCPaymentTerms.ReadOnly = isLock
        txtCRemarks.ReadOnly = isLock
        txtCInfo1.ReadOnly = isLock
        txtCInfo2.ReadOnly = isLock
        txtCInfo3.ReadOnly = isLock

        If m_CId > 0 Then btnCurrency.Enabled = False Else btnCurrency.Enabled = Not isLock
        If m_CId = 0 Then
            btndelete.Enabled = isLock
        Else
            If isAllowDelete = True Then btndelete.Enabled = Not isLock Else btndelete.Enabled = False
        End If
        'btnEdit.Enabled = isLock
        btnnew.Enabled = isLock
        btnsave.Enabled = Not isLock
        btncancel.Enabled = Not isLock
    End Sub
    Private Sub txtCPaymentTerm_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCPaymentTerms.KeyPress
        Dim key As Integer = Asc(e.KeyChar)
        If Not ((key >= 48 And key <= 57) Or key = 8) Then
            e.Handled = True
        End If
    End Sub
    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.       
    End Sub
    Private Sub btnCurrency_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCurrency.Click
        Dim NewFormDialog As New fdlCurrency
        NewFormDialog.FrmCallerId = Me.Name
        NewFormDialog.ShowDialog()
    End Sub
    Private Sub btnfind_Click(sender As System.Object, e As System.EventArgs) Handles btnfind.Click
        Dim child As New FDLSearch()
        child.txtopenargs.Text = "4"
        If child.ShowDialog() = DialogResult.OK Then
            Me.txtguid.Text = child.txtChildText0.Text
        End If
    End Sub
    Private Sub btnnew_Click(sender As System.Object, e As System.EventArgs) Handles btnnew.Click
        kosong()
    End Sub
    Private Sub txtguid_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtguid.TextChanged
        If Me.txtguid.Text <> "" Then m_CId = Me.txtguid.Text : Me.txtguid.Tag = "custid" : isirecord(Me.txtguid.Text)
    End Sub
    Private Sub btnexit_Click(sender As System.Object, e As System.EventArgs) Handles btnexit.Click
        Me.Close()
    End Sub
    Private Sub txt_c_curr_id_TextChanged(sender As System.Object, e As System.EventArgs) Handles txt_c_curr_id.TextChanged
        If Me.txt_c_curr_id.Text <> "" And Me.txtCCurrCode.Text <> "0" Then
            'isi
            Me.txtCCurrCode.Text = GetCurrentID("curr_code", "mt_curr", "curr_id='" & Me.txt_c_curr_id.Text & "'")
        Else

        End If
    End Sub
    Private Sub btnsave_Click(sender As System.Object, e As System.EventArgs) Handles btnsave.Click
        On Error GoTo err_btnsave_Click

        If txtCName.Text = "" Or cmbCCategory.Text = "" Or cmbCTitle.Text = "" Or txtCCurrCode.Text = "" Then
            MsgBox("Code, Name, Currency and Category are primary fields that should be entered. Please enter those fields before you save it.", vbCritical + vbOKOnly, Me.Text)
            txtCCode.Focus()
            Exit Sub
        End If
        If Me.txtCCode.Text = "" Then Me.txtCCode.Text = GETGeneralcode("", "mt_customer", "c_code", "", Me.txtCName.Text, True, 2, 1, "", "")
        Me.txtguid.Tag = "custid"
        If Fillobject(Me.txtguid, Me.TabPage1, IIf(Me.txtguid.Text = "", "insert", "update"), "sp_mt_customer", "", "@c_id") Then MsgBox("Data telah disimpan !", MsgBoxStyle.Information, Me.Text) Else MsgBox("Data Belum disimpan !", MsgBoxStyle.Critical, Me.Text)


exit_btnsave_Click:
        If ConnectionState.Open = 1 Then cn.Close()
        Exit Sub

err_btnsave_Click:
        'If Err.Number = 5 Then
        '    MsgBox("This primary code has been used (and deleted) previously. Please create with another code", vbExclamation + vbOKOnly, Me.Text)
        'Else
        MsgBox(Err.Description)
        'End If
        Resume exit_btnsave_Click
    End Sub
    Private Sub btndelete_Click(sender As System.Object, e As System.EventArgs) Handles btndelete.Click
        If MsgBox("Are you sure you want to delete this record?", vbYesNo + vbCritical, Me.Text) = vbYes Then
            cmd = New SqlCommand("sp_mt_customer_DEL", cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm1 As SqlParameter = cmd.Parameters.Add("@c_id", SqlDbType.Int, 255)
            prm1.Value = m_CId
            Dim prm2 As SqlParameter = cmd.Parameters.Add("@user_name", SqlDbType.NVarChar, 50)
            prm2.Value = My.Settings.UserName
            Dim prm3 As SqlParameter = cmd.Parameters.Add("@row_count", SqlDbType.Int)
            prm3.Direction = ParameterDirection.Output
            If cn.State = ConnectionState.Closed Then cn.Open()
            cmd.ExecuteReader()
            cn.Close()
            If prm3.Value = 1 Then
                MsgBox("You can't delete this record because it's already used in transaction.", vbCritical, Me.Text)
            Else
                kosong()
            End If
            lock_obj(True)
        End If
    End Sub

    Private Sub ListView1_ItemChecked(sender As Object, e As System.Windows.Forms.ItemCheckedEventArgs) Handles ListView1.ItemChecked
        If Me.txtCCode.Text = "" Then Exit Sub
        If Me.ListView1.SelectedItems.Count = 1 Then
            If Me.ListView1.SelectedItems(0).Checked = True Then
                Executestr("insert into rt_mesin_div (pk_mesin_id, pk_mesin_idf, flag_id) values ('" & Me.txtCCode.Text & "','" & Me.ListView1.SelectedItems(0).SubItems(3).Text & "','2')")
            Else
                Executestr("delete from rt_mesin_div where pk_mesin_id='" & Me.txtCCode.Text & "' and pk_mesin_idf='" & Me.ListView1.SelectedItems(0).SubItems(3).Text & "' and flag_id=2")
            End If

        End If
    End Sub
End Class