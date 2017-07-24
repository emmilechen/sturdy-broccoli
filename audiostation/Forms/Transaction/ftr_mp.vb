Public Class ftr_mp
    Private m_SOId As Integer
    Private m_CId As Integer
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
        Me.btnCustomer.Enabled = Me.cmbcust.SelectedItem.count > 0
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim NewFormDialog As New fdlCUtility
        NewFormDialog.FrmCallerId = Me.Name
        NewFormDialog.Tag = "2"
        NewFormDialog.ShowDialog()
    End Sub

    Private Sub btnSaveD_Click(sender As System.Object, e As System.EventArgs) Handles btnSaveD.Click
        Dim li As ListViewItem, i As Integer
        If Me.txtguid.Text <> "" And Me.txtguid_d.Text <> "" Then
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

    End Sub

    Private Sub ToolStripButton2_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton2.Click
        'find
    End Sub

    Private Sub ToolStripButton3_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton3.Click
        'cancel
    End Sub

    Private Sub ToolStripButton4_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton4.Click
        'delete
    End Sub

    Private Sub ToolStripButton5_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton5.Click
        'new
    End Sub

    Private Sub ToolStripButton6_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton6.Click
        Me.Close()
    End Sub
End Class