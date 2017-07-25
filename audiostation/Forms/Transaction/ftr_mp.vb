Imports System.Data.SqlClient
Imports System.Data.OleDb
Public Class ftr_mp
    Private m_SOId As Integer, m_CId As Integer
    Private namatable As String, namafieldPK As String
    Dim strConnection As String = My.Settings.ConnStr
    Private strConn As String = My.Settings.ConnStr
    Private sqlCon As SqlConnection
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Public Property soid() As Integer
        Get
            Return txtso_id_f.Text 'm_SOId
        End Get
        Set(ByVal Value As Integer)
            txtso_id_f.Text = Value
        End Set
    End Property

    Public Property sono() As String
        Get
            Return txtsono.Text
        End Get
        Set(ByVal Value As String)
            txtsono.Text = Value
        End Set
    End Property
    Private Function kosong()
        ClearObjectonForm(Me)
        AssignValuetoCombo(Me.cmbcust, "", "c_id", "c_code+'-'+c_name", "mt_customer", "c_code<>''", "c_name")
        Me.dttpmp_tgl.Focus()
        Me.txtguid.Text = "0"
        Me.btnSaveD.Tag = "N"
    End Function
    Private Sub ftr_mp_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Top = 0 : Me.Left = 0
        kosong()
    End Sub

    Private Sub btnCustomer_Click(sender As System.Object, e As System.EventArgs) Handles btnCustomer.Click
        Dim NewFormDialog As New fdlCUtility
        NewFormDialog.FrmCallerId = Me.Name
        NewFormDialog.Tag = "1"
        NewFormDialog.ShowDialog()
    End Sub

    Private Sub cmbcust_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbcust.SelectedIndexChanged
        On Error Resume Next
        ' Me.btnCustomer.Enabled = Me.cmbcust.SelectedValue <> "0" ' Me.cmbcust.SelectedIndex > 0
        Me.btnCustomer.Enabled = Me.cmbcust.SelectedIndex >= 0
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim NewFormDialog As New fdlCUtility
        NewFormDialog.FrmCallerId = Me.Name
        NewFormDialog.Tag = "2"
        NewFormDialog.ShowDialog()
    End Sub

    Private Sub btnSaveD_Click(sender As System.Object, e As System.EventArgs) Handles btnSaveD.Click
        Dim li As ListViewItem, i As Integer
        If Me.txtguid.Text <> "0" And Me.txtguid_d.Text <> "0" Then

        Else
            'insert
            With Me
                .ListView1.Columns.Clear()
                .ListView1.Columns.Add("Kolom 0", "guid", 0)
                .ListView1.Columns.Add("Kolom 1", "skuid", 0)
                .ListView1.Columns.Add("Kolom 2", "Kode", Me.TextBox4.Width + Me.btnCustomer.Width + 5)
                .ListView1.Columns.Add("Kolom 3", "Keterangan", Me.TextBox5.Width + 5)
                .ListView1.Columns.Add("Kolom 4", "Qty", Me.TextBox6.Width + 5)
                .ListView1.Columns.Add("Kolom 5", "UOM", Me.TextBox1.Width + 5)
                .ListView1.Columns.Add("Kolom 6", "Tgl_Kirim", Me.TextBox7.Width + 5)
                .ListView1.Columns.Add("Kolom 7", "Tgl_Permintaan", Me.TextBox8.Width + 5)
            End With


            If FindSubItem(ListView1, Me.txtskuid.Text) = True And Me.btnSaveD.Tag = "N" Then
                'it is a duplicate do something
                MsgBox("Duplicate data !", MsgBoxStyle.Critical, "Production Memo")
                Exit Sub
            Else
                'it is not a duplicate, go ahead and add it.
                If Me.btnSaveD.Tag = "N" Then

                Else
                    For a As Integer = ListView1.SelectedItems.Count - 1 To 0
                        ListView1.SelectedItems(a).Remove()
                    Next
                End If
                i = Me.ListView1.Items.Count + 1
                li = ListView1.Items.Add(Me.txtguid_d.Text)
                li.SubItems.Add(Me.txtskuid.Text)
                li.SubItems.Add(Me.TextBox4.Text)
                li.SubItems.Add(Me.TextBox5.Text)
                li.SubItems.Add(Me.TextBox6.Text)
                li.SubItems.Add(Me.TextBox1.Text)
                li.SubItems.Add(Me.TextBox7.Text)
                li.SubItems.Add(Me.TextBox8.Text)

                Me.txtguid_d.Text = ""
                Me.txtskuid.Text = ""
                Me.TextBox4.Text = ""
                Me.TextBox5.Text = ""
                Me.TextBox6.Text = ""
                Me.TextBox1.Text = ""
                Me.TextBox7.Text = ""
                Me.TextBox8.Text = ""
                Me.btnSaveD.Tag = "N"
            End If


        End If
    End Sub
    Private Function FindSubItem(ByVal lv As ListView, ByVal SearchString As String) As Boolean
        'find column index in listview by name "acctcode"
        Dim idx = (From c In ListView1.Columns Where c.Text = "skuid" Select c = c.Index).First()
        For Each itm As ListViewItem In lv.Items
            'search only subitems of column "acctcode"
            If itm.SubItems(idx).Text = SearchString Then Return True
        Next
        Return False
    End Function

    Private Sub ListView1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ListView1.SelectedIndexChanged
        If ListView1.SelectedItems.Count > 0 Then
            Me.txtguid_d.Text = Me.ListView1.Items(ListView1.FocusedItem.Index).Text
            Me.txtskuid.Text = Me.ListView1.Items(ListView1.FocusedItem.Index).SubItems(1).Text
            Me.TextBox4.Text = Me.ListView1.Items(ListView1.FocusedItem.Index).SubItems(2).Text
            Me.TextBox5.Text = Me.ListView1.Items(ListView1.FocusedItem.Index).SubItems(3).Text
            Me.TextBox6.Text = Me.ListView1.Items(ListView1.FocusedItem.Index).SubItems(4).Text
            Me.TextBox1.Text = Me.ListView1.Items(ListView1.FocusedItem.Index).SubItems(5).Text
            Me.TextBox7.Text = Me.ListView1.Items(ListView1.FocusedItem.Index).SubItems(6).Text
            Me.TextBox8.Text = Me.ListView1.Items(ListView1.FocusedItem.Index).SubItems(7).Text
            Me.btnSaveD.Tag = "E"
        End If
    End Sub
    Private Sub btnDeleteD_Click(sender As System.Object, e As System.EventArgs) Handles btnDeleteD.Click
        If ListView1.SelectedItems.Count > 0 Then
            For a As Integer = ListView1.SelectedItems.Count - 1 To 0
                ListView1.SelectedItems(a).Remove()
            Next
        End If
    End Sub

    Private Sub btnAddD_Click(sender As System.Object, e As System.EventArgs) Handles btnAddD.Click
        Me.txtguid_d.Text = ""
        Me.txtskuid.Text = ""
        Me.TextBox4.Text = ""
        Me.TextBox5.Text = ""
        Me.TextBox6.Text = ""
        Me.TextBox1.Text = ""
        Me.TextBox7.Text = ""
        Me.TextBox8.Text = ""
        Me.btnSaveD.Tag = "N"
    End Sub
    Private Sub ToolStripButton1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton1.Click
        'save
        On Error GoTo err_ToolStripButton1_Click
        If Me.ListView1.Items.Count = 0 Then MsgBox("Data tidak dapat disimpan, karena detil barang masih kosong !", vbCritical + vbOKOnly, Me.Text) : Exit Sub
        If Me.cmbcust.Text = "" Or Me.txtsono.Text = "" Then
            MsgBox("Customer Code, Customer Name and SO # are primary fields that should be entered. Please enter those fields before you save it.", vbCritical + vbOKOnly, Me.Text)
            cmbcust.Focus()
            Exit Sub
        End If
        If MsgBox("Data akan di" & IIf(Me.txtguid.Text = "0", "simpan", "simpan ulang") & ", lanjutkan ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "MP") = MsgBoxResult.Yes Then
            namatable = "tr_mp" : namafieldPK = "mp_no"
            Me.txtmp_no.Text = IIf(Me.txtguid.Text = "0", GETGeneralcode("MP", namatable, namafieldPK, "mp_tgl", CDate(Me.dttpmp_tgl.Text), False, 4, 1, "", ""), Me.txtmp_no.Text)
            If Fillobject(Me.txtguid, Me.Panel1, IIf(Me.txtguid.Text = "0", "insert", "update"), "sp_tr_mp", "", "@mp_pk") Then MsgBox("Data telah di" & IIf(Me.txtguid.Text = "0", "simpan", "simpan ulang") & " !", MsgBoxStyle.Information, "MP") Else Me.txtmp_no.Text = "" : MsgBox("Data gagal disimpan !", MsgBoxStyle.Critical, "MP")
        Else
            MsgBox("Data Belum disimpan !", MsgBoxStyle.Critical, "MP")
        End If
exit_ToolStripButton1_Click:
        If ConnectionState.Open = 1 Then cn.Close()
        Exit Sub

err_ToolStripButton1_Click:
        MsgBox(Err.Description)
        Resume exit_ToolStripButton1_Click

    End Sub

    Private Sub ToolStripButton2_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton2.Click
        'find
    End Sub

    Private Sub ToolStripButton3_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton3.Click
        'cancel
    End Sub

    Private Sub ToolStripButton4_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton4.Click
        'delete
        On Error GoTo err_ToolStripButton4_Click
        If Me.txtguid.Text = "" Then Exit Sub
        If MsgBox("Data akan dihapus, lanjutkan ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "MP") = MsgBoxResult.Yes Then
            If Fillobject(Me.txtguid, Me.Panel1, "delete", "sp_tr_mp", "", "@mp_pk") Then MsgBox("Data telah dihapus !", MsgBoxStyle.Information, "MP") Else Me.txtmp_no.Text = "" : MsgBox("Data gagal dihapus !", MsgBoxStyle.Critical, "MP")
        Else
            MsgBox("Data belum dihapus !", MsgBoxStyle.Critical, "MP")
        End If

exit_ToolStripButton4_Click:
        If ConnectionState.Open = 1 Then cn.Close()
        Exit Sub

err_ToolStripButton4_Click:
        MsgBox(Err.Description)
        Resume exit_ToolStripButton4_Click


    End Sub

    Private Sub ToolStripButton5_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton5.Click
        'new
    End Sub

    Private Sub ToolStripButton6_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton6.Click
        Me.Close()
    End Sub
End Class