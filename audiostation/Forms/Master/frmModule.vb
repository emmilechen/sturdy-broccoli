Imports System.Data.SqlClient
Public Class frmModule
    Dim strConnection As String = My.Settings.ConnStr
    Private strConn As String = My.Settings.ConnStr
    Private sqlCon As SqlConnection
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Private m_guid As String, m_d_guid As String
    Private Sub frmModule_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        m_guid = "" : Me.Text = "Module-Issues" : Me.Top = 0 : Me.Left = 0
        With Me
            .ListView1.Columns.Clear()
            .ListView1.Columns.Add("Kolom 0", "guid", 0)
            .ListView1.Columns.Add("Kolom 1", "Module", Me.TextBox1.Width)
            .ListView1.Columns.Add("Kolom 2", "Is_Done", 0)
        End With
        Me.ListView1.Items.Clear()
        opensearchform(Me.ListView1, "moduleid", "modulename", "status_id", "mt_module", "status_id=0", "modulename", 0)
        With Me
            .ListView2.Columns.Clear()
            .ListView2.Columns.Add("Kolom 0", "guid", 0)
            .ListView2.Columns.Add("Kolom 1", "Issues", Me.TextBox2.Width + 5)
            .ListView2.Columns.Add("Kolom 2", "Is_Done", Me.CheckBox1.Width + 5)
        End With
        Me.ListView2.Items.Clear()
        opensearchform(Me.ListView2, "moduleid", "modulename", "is_done", "mt_module", "status_id=1", "modulename", 0) : Me.Button2.Enabled = False
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
                    str(2) = IIf(IsDBNull(dr.Item(2).ToString()), "#", dr.Item(2).ToString())
                    itm = New ListViewItem(str)
                    .Items.Add(itm)
                Loop
            End If
            dr.Close()
            cmd.Dispose()
        End With
    End Function

    Private Sub ListView1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ListView1.SelectedIndexChanged
        If ListView1.SelectedItems.Count > 0 Then
            m_guid = Me.ListView1.Items(ListView1.FocusedItem.Index).Text
            Me.TextBox1.Text = Me.ListView1.Items(ListView1.FocusedItem.Index).SubItems(1).Text
            Me.Button2.Enabled = True : Me.TextBox2.Text = "" : m_d_guid = ""
            opensearchform(Me.ListView2, "moduleid", "modulename", "is_done", "mt_module", "parent_id='" & m_guid & "' and status_id=1", "modulename", 0)
        End If
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        If Me.TextBox1.Text = "" Or Me.TextBox1.Text = " " Then Exit Sub
        If m_guid = "" Then
            Executestr("insert into mt_module (modulename, parent_id, status_id, is_done) values ('" & Me.TextBox1.Text & "',NULL,'0','0')")
        Else
            Executestr("update mt_module set modulename='" & Me.TextBox1.Text & "' where moduleid='" & m_guid & "'")
        End If
        opensearchform(Me.ListView1, "moduleid", "modulename", "status_id", "mt_module", "status_id=0", "modulename", 0)
        Me.TextBox1.Text = "" : m_guid = ""
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        If m_guid = "" Or Me.TextBox1.Text = "" Or Me.TextBox1.Text = " " Then Exit Sub
        If m_d_guid = "" Then
            Executestr("insert into mt_module (modulename, parent_id, status_id, is_done) values ('" & Me.TextBox2.Text & "','" & m_guid & "','1','0')")
        Else
            Executestr("update mt_module set modulename='" & Me.TextBox2.Text & "', is_done='" & IIf(Me.CheckBox1.Checked, 1, 0) & "' where moduleid='" & m_d_guid & "'")
        End If
        opensearchform(Me.ListView2, "moduleid", "modulename", "is_done", "mt_module", "parent_id='" & m_guid & "' and status_id=1", "modulename", 0)
        Me.TextBox2.Text = "" : m_d_guid = ""
    End Sub

    Private Sub ListView2_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ListView2.SelectedIndexChanged
        If ListView2.SelectedItems.Count > 0 Then
            m_d_guid = Me.ListView2.Items(ListView2.FocusedItem.Index).Text
            Me.TextBox2.Text = Me.ListView2.Items(ListView2.FocusedItem.Index).SubItems(1).Text
            Me.CheckBox1.Checked = CBool(Me.ListView2.Items(ListView2.FocusedItem.Index).SubItems(2).Text)
            'Me.Button2.Enabled = True
            opensearchform(Me.ListView2, "moduleid", "modulename", "is_done", "mt_module", "parent_id='" & m_guid & "' and status_id=1", "modulename", 0)
        End If
    End Sub

    Private Sub TextBox1_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyCode = Keys.Escape Then Me.TextBox1.Text = "" : m_guid = ""
    End Sub
End Class