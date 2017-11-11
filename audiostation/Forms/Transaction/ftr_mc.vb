Imports System.Data.SqlClient
Imports System.Data.OleDb
Public Class ftr_mc
    Dim strConnection As String = My.Settings.ConnStr
    Private strConn As String = My.Settings.ConnStr
    Private sqlCon As SqlConnection
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Dim cmd As SqlCommand, ctrlstr As String = ""
    Private namatable As String, namafieldPK As String
    Private namafile As String
    Private Function kosong()
        ClearObjectonForm(Me)
        AssignValuetoCombo(Me.ComboBox1, "", "mc_id", "mc_no", "tr_mc", "mc_date>='" & Me.DateTimePicker1.Text & "'", "mc_no")
        AssignValuetoCombo(Me.ComboBox2, "", "c_id", "c_name", "mt_customer", "c_name<>''", "c_name")
        AssignValuetoCombo(Me.ComboBox3, "", "sku_id", "sku_name", "mt_sku", "sku_name<>''", "sku_name")
        AssignValuetoCombo(Me.ComboBox4, "", "primarykey", "sys_dropdown_val", "sys_dropdown", "sys_dropdown_whr='costing_status'", "sys_dropdown_sort")
        With Me
            .ListView1.Columns.Clear()
            .ListView1.Columns.Add("Kolom 0", "id", 0)
            .ListView1.Columns.Add("Kolom 1", "Lokasi", Me.ListView1.Width)
        End With
        Me.ListView1.Items.Clear()
        Me.DateTimePicker1.Select()
        Me.txtguid.Text = ""
        Me.ComboBox4.SelectedValue = "1212"
        Me.cmdcancel.Enabled = False : Me.cmddelete.Enabled = False : Me.cmdprint.Enabled = False
    End Function
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
    Private Function isirecord(ByVal guidno As Integer)
        'Me.txtguid.Text = guidno
        Fillobject(Me.txtguid, Me, "select", "sp_tr_mc", Me.txtguid.Text, "@c_id")
        AssignValuetoCombo(Me.ComboBox1, "", "mc_id", "mc_no", "tr_mc", "mc_id<>" & Me.txtguid.Text & " AND mc_date>='" & Me.DateTimePicker1.Text & "'", "mc_no")
        opensearchform(Me.ListView1, "sys_dropdown_val", "sys_dropdown_val", "sys_dropdown_id", "sys_dropdown", "sys_dropdown_whr='" & Me.Name & "' AND sys_dropdown_sort='" & Me.txtguid.Text & "'", "sys_dropdown_id", 0)
        Me.cmdcancel.Enabled = True : Me.cmddelete.Enabled = True : Me.cmdprint.Enabled = True
    End Function
    Private Sub cmdsave_Click(sender As System.Object, e As System.EventArgs) Handles cmdsave.Click
        On Error Resume Next
        If DateTimePicker1.Text = "" Or ComboBox2.Text = "" Or ComboBox3.Text = "" Then
            MsgBox("Code, Name, Currency and Category are primary fields that should be entered. Please enter those fields before you save it.", vbCritical + vbOKOnly, Me.Text)
            DateTimePicker1.Select()
            Exit Sub
        End If
        If Me.TextBox1.Text = "" Then Me.TextBox1.Text = IIf(Me.txtguid.Text = "", GETGeneralcode("MC", namatable, namafieldPK, "mc_date", CDate(Me.DateTimePicker1.Text), False, 4, 1, "", ""), Me.TextBox1.Text)
        Me.txtguid.Tag = "mc_id"
        If Fillobject(Me.txtguid, Me, IIf(Me.txtguid.Text = "", "insert", "update"), "sp_tr_mc", "", "@c_id") Then
            Executestr("DELETE from sys_dropdown where sys_dropdown_whr='" & Me.Name & "' AND sys_dropdown_sort='" & Me.txtguid.Text & "'")
            For i As Integer = 0 To Me.ListView1.Items.Count - 1
                'kl blm ada, INSERT
                Executestr("INSERT INTO sys_dropdown(sys_dropdown_whr, sys_dropdown_id, sys_dropdown_sort, sys_dropdown_val) VALUES ('" & Me.Name & "','" & i & "','" & Me.txtguid.Text & "','" & ListView1.Items(i).SubItems(1).Text & "')")
            Next
            MsgBox("Data telah disimpan !", MsgBoxStyle.Information, Me.Text)
        Else
            MsgBox("Data Belum disimpan !", MsgBoxStyle.Critical, Me.Text)
        End If

    End Sub
    Private Sub ComboBox3_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboBox3.SelectedIndexChanged

    End Sub
    Private Sub ftr_mc_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        On Error Resume Next
        If cn.State = ConnectionState.Closed Then cn.Open()
        namatable = "tr_mc" : namafieldPK = "mc_no"
        If Me.TextBox1.Text = "" Then
            kosong()
        Else
            'isirec
            'kosong()
        End If
    End Sub
    Private Sub cmdnew_Click(sender As System.Object, e As System.EventArgs) Handles cmdnew.Click
        kosong()
    End Sub
    Private Sub cmdexit_Click(sender As System.Object, e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub
    Private Sub cmdfind_Click(sender As System.Object, e As System.EventArgs) Handles cmdfind.Click
        Dim child As New FDLSearch()
        child.txtopenargs.Text = "8"
        If child.ShowDialog() = DialogResult.OK Then
            Me.txtguid.Text = child.txtChildText0.Text
            isirecord(Me.txtguid.Text)
        End If
    End Sub
    Private Sub cmdcancel_Click(sender As System.Object, e As System.EventArgs) Handles cmdcancel.Click

    End Sub
    Private Sub cmddelete_Click(sender As System.Object, e As System.EventArgs) Handles cmddelete.Click

    End Sub
    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        On Error Resume Next
        Dim li As ListViewItem, i As Integer
        If Me.ListView1.Items.Count >= 3 Then MsgBox("Maksimal gambar yang dapat dilampirkan adalah 3 (tiga) !", MsgBoxStyle.Information, "MC") : Exit Sub
        OpenFileDialog1.Filter = "image file (*.jpg, *.bmp, *.png | *.jpg; *.bmp; *.png; | all files(*.*) | *.*)"
        If OpenFileDialog1.ShowDialog <> Windows.Forms.DialogResult.Cancel Then
            'PictureBox1.Image = Image.FromFile(namafile)
            'Me.txtfilename.Text = namafile
            i = Me.ListView1.Items.Count + 1
            li = ListView1.Items.Add(Me.TextBox4.Text)
            li.SubItems.Add(Me.TextBox4.Text)
        End If
    End Sub
    Private Sub OpenFileDialog1_FileOk(sender As System.Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk
        Try
            If OpenFileDialog1.FileName <> Nothing Or OpenFileDialog1.FileName <> "" Then
                Me.TextBox4.Text = OpenFileDialog1.FileName.Substring(OpenFileDialog1.FileName.LastIndexOf("\") + 1, Len(OpenFileDialog1.FileName) - (OpenFileDialog1.FileName.LastIndexOf("\") + 1))                
            End If
            Exit Sub
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "PO")
        End Try
    End Sub
    Private Sub ListView1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ListView1.SelectedIndexChanged
        On Error Resume Next
        If ListView1.SelectedItems.Count > 0 Then
            Dim lokasi As String = GetInit("defpath", True) & Me.ListView1.Items(ListView1.FocusedItem.Index).Text
            Me.PictureBox1.Image = Image.FromFile(lokasi)
            'Me.txtfilename.Text = namafile
        End If
    End Sub
End Class