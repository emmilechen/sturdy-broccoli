Imports System.Data.SqlClient
Imports System.Data.OleDb
Public Class FDLSearch
    Private ListView1Sorter As lvColumnSorter
    Dim strConnection As String = My.Settings.ConnStr
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Public Sub New()
        InitializeComponent()
    End Sub
    ' Custom property we are adding to the child form
    ' Notice it is public and communicates with the txtChildText control on this form.
    Public Property ChildText() As String
        Get
            Return txtChildText0.Text
        End Get
        Set(value As String)
            txtChildText0.Text = value
        End Set
    End Property
    Private Sub FDLSearch_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.ComboBox1.Items.Clear()
        Me.ComboBox1.Items.Add("Sound Like")
        Me.ComboBox1.Items.Add("Exactly")
        Me.ComboBox1.Text = "Sound Like"

        Me.txtrows.Text = "28"
        Select Case Me.txtopenargs.Text
            Case Is = 0
                opensearchform("ind_no", "CONVERT(VARCHAR(11),ind_tgl,106)", "(select c_name from mt_customer where c_id=ind_c_id)+'/'+ind_keterangan", "tr_induction", "ind_no<>''", "ind_no", Me.txtopenargs.Text)
                Me.ComboBox2.Items.Clear()
                Me.ComboBox2.Items.Add("<--ALL-->")
                Me.ComboBox2.Text = "<--ALL-->"
            Case Is = 1
                opensearchform("kodemember", "namamember", "kodekomsel+' ~'+namapa+'/'+namapks", "m_member", "kodemember<>''", "kodemember desc", Me.txtopenargs.Text)
                Me.ComboBox2.Items.Clear()
                Me.ComboBox2.Items.Add("<--ALL-->")
                Me.ComboBox2.Items.Add("Nama_PA")
                Me.ComboBox2.Items.Add("Nama_PKS")
                Me.ComboBox2.Items.Add("Jenis_Kelamin")
                Me.ComboBox2.Items.Add("Gol_Darah")
                Me.ComboBox2.Items.Add("Alamat_Tinggal")
                Me.ComboBox2.Items.Add("Alamat_Komsel")
                Me.ComboBox2.Items.Add("Status_Pernikahan")
                Me.ComboBox2.Items.Add("Status_Kejemaatan")
                Me.ComboBox2.Items.Add("Fungsi_Keluarga")
                Me.ComboBox2.Items.Add("Pendidikan_Terakhir")
                Me.ComboBox2.Text = "<--ALL-->"
            Case Is = 2
                opensearchform("username", "usercode", "levelname", "M_UserLogin inner join M_UserLevel on M_UserLogin.levelsecurity=M_UserLevel.Levelid", "userid<>0", "username", Me.txtopenargs.Text)
                Me.ComboBox2.Items.Clear()
                Me.ComboBox2.Items.Add("<--ALL-->")
                Me.ComboBox2.Text = "<--ALL-->"
            Case Is = 3
                opensearchform("pono", "spkid", "name", "txpo inner join T_CARD on t_card.code=txpo.supplierid ", "pono<>'s'", "pono", Me.txtopenargs.Text)
                Me.ComboBox2.Items.Clear()
                Me.ComboBox2.Items.Add("<--ALL-->")
                Me.ComboBox2.Text = "<--ALL-->"
        End Select
        Me.TextBox1.Focus()
    End Sub
    Private Sub TextBox1_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox1.TextChanged
        On Error Resume Next
        Select Case Me.txtopenargs.Text
            Case Is = 0
                opensearchform("ind_no", "CONVERT(VARCHAR(11),ind_tgl,106)", "(select c_name from mt_customer where c_id=ind_c_id)+'/'+ind_keterangan", "tr_induction", "ind_no<>'' and (ind_no+ind_tgl+ind_keterangan) like '%" & Me.TextBox1.Text & "%'", "ind_no", Me.txtopenargs.Text)
            Case Is = 1
                If Me.ComboBox2.Text = "<--ALL-->" Then
                    opensearchform("kodemember", "namamember", "kodekomsel+' ~'+namapa+'/'+namapks", "m_member", "kodemember<>'' and (kodemember like '%" & Me.TextBox1.Text & "%' OR namamember like '%" & Me.TextBox1.Text & "%' OR kodekomsel like '%" & Me.TextBox1.Text & "%' OR telpmember like '%" & Me.TextBox1.Text & "%' OR wano like '%" & Me.TextBox1.Text & "%')", "kodemember desc", Me.txtopenargs.Text)
                    'Me.txttelp.Text = dr.Item("telpmember").ToString()
                    'Me.TextBox31.Text = dr.Item("telprumah").ToString()
                    'Me.TextBox3.Text = dr.Item("hape").ToString()
                    'Me.TextBox51.Text = dr.Item("hape2").ToString()
                    'Me.TextBox27.Text = dr.Item("wano").ToString()
                    'Me.TextBox52.Text = dr.Item("telpkantor").ToString()
                Else
                    Select Case Me.ComboBox2.Text
                        Case Is = "Nama_PA"
                            opensearchform("a.kodemember", "a.namamember", "a.kodekomsel+' ~'+a.namapa+'/'+a.namapks", "m_member a inner join m_member b on a.namapa=b.namapa", "(b.kodemember like '%" & Me.TextBox1.Text & "%' OR b.namamember like '%" & Me.TextBox1.Text & "%')", "a.kodemember desc", Me.txtopenargs.Text)
                        Case Is = "Nama_PKS"
                            opensearchform("a.kodemember", "a.namamember", "a.kodekomsel+' ~'+a.namapa+'/'+a.namapks", "m_member a inner join m_member b on a.namapks=b.namapks", "(b.kodemember like '%" & Me.TextBox1.Text & "%' OR b.namamember like '%" & Me.TextBox1.Text & "%')", "a.kodemember desc", Me.txtopenargs.Text)
                        Case Is = "Jenis_Kelamin"
                            opensearchform("a.kodemember", "a.namamember", "a.kodekomsel+' ~'+a.namapa+'/'+a.namapks", "m_member a inner join M_Event_Category b on a.jeniskelamin=b.catid", "(b.catcode like '%" & Me.TextBox1.Text & "%' OR b.catname like '%" & Me.TextBox1.Text & "%')", "a.kodemember desc", Me.txtopenargs.Text)
                        Case Is = "Gol_Darah"
                            opensearchform("a.kodemember", "a.namamember", "a.kodekomsel+' ~'+a.namapa+'/'+a.namapks", "m_member a inner join M_Event_Category b on a.goldarah=b.catid", "(b.catcode like '%" & Me.TextBox1.Text & "%' OR b.catname like '%" & Me.TextBox1.Text & "%')", "a.kodemember desc", Me.txtopenargs.Text)
                        Case Is = "Alamat_Tinggal"
                            opensearchform("kodemember", "namamember", "kodekomsel+' ~'+namapa+'/'+namapks", "m_member", "(alamatrumah like '%" & Me.TextBox1.Text & "%')", "kodemember desc", Me.txtopenargs.Text)
                        Case Is = "Alamat_Komsel"
                            opensearchform("a.kodemember", "a.namamember", "a.kodekomsel+' ~'+a.namapa+'/'+a.namapks", "m_member a inner join M_Event_Category b on a.komselid=b.catid", "(b.catcode like '%" & Me.TextBox1.Text & "%' OR b.catname like '%" & Me.TextBox1.Text & "%')", "a.kodemember desc", Me.txtopenargs.Text)
                        Case Is = "Status_Pernikahan"
                            opensearchform("a.kodemember", "a.namamember", "a.kodekomsel+' ~'+a.namapa+'/'+a.namapks", "m_member a inner join M_Event_Category b on a.statuspernikahan=b.catid", "(b.catcode like '%" & Me.TextBox1.Text & "%' OR b.catname like '%" & Me.TextBox1.Text & "%')", "a.kodemember desc", Me.txtopenargs.Text)
                        Case Is = "Status_Kejemaatan"
                            opensearchform("a.kodemember", "a.namamember", "a.kodekomsel+' ~'+a.namapa+'/'+a.namapks", "m_member a inner join M_Event_Category b on a.statusmember=b.catid", "(b.catcode like '%" & Me.TextBox1.Text & "%' OR b.catname like '%" & Me.TextBox1.Text & "%')", "a.kodemember desc", Me.txtopenargs.Text)
                        Case Is = "Fungsi_Keluarga"
                            opensearchform("a.kodemember", "a.namamember", "a.kodekomsel+' ~'+a.namapa+'/'+a.namapks", "m_member a inner join M_Event_Category b on a.fungsidalamkel=b.catid", "(b.catcode like '%" & Me.TextBox1.Text & "%' OR b.catname like '%" & Me.TextBox1.Text & "%')", "a.kodemember desc", Me.txtopenargs.Text)
                        Case Is = "Pendidikan_Terakhir"
                            opensearchform("a.kodemember", "a.namamember", "a.kodekomsel+' ~'+a.namapa+'/'+a.namapks", "m_member a inner join M_Event_Category b on a.pendidikanterakhir=b.catid", "(b.catcode like '%" & Me.TextBox1.Text & "%' OR b.catname like '%" & Me.TextBox1.Text & "%')", "a.kodemember desc", Me.txtopenargs.Text)
                    End Select
                End If
            Case Is = 2
                opensearchform("username", "usercode", "levelname", "M_UserLogin inner join M_UserLevel on M_UserLogin.levelsecurity=M_UserLevel.Levelid", "(username+levelname) like '%" & Me.TextBox1.Text & "%'", "username", Me.txtopenargs.Text)
            Case Is = 3
                opensearchform("pono", "spkid", "name", "txpo inner join T_CARD on t_card.code=txpo.supplierid ", "pono<>'s' and (pono+spkid+name) like '%" & Me.TextBox1.Text & "%'", "pono", Me.txtopenargs.Text)
        End Select
    End Sub

    Private Sub ListView1_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles ListView1.KeyDown
        'If e.KeyCode = Keys.Enter then
    End Sub
    Private Sub ListView1_MouseDoubleClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles ListView1.MouseDoubleClick
        If Me.ListView1.SelectedItems.Count = 1 Then
            Me.DialogResult = DialogResult.OK
            Me.Close()
        End If
    End Sub
    Private Sub ListView1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ListView1.SelectedIndexChanged
        If Me.ListView1.SelectedItems.Count = 1 Then
            Me.txtChildText0.Text = Me.ListView1.SelectedItems(0).Text
            Me.txtChildText1.Text = Me.ListView1.SelectedItems(0).SubItems(1).Text
            Me.txtChildText2.Text = Me.ListView1.SelectedItems(0).SubItems(2).Text
        End If
    End Sub
    Private Function opensearchform(ByVal strfield1 As String, ByVal strfield2 As String, ByVal strfield3 As String, ByVal strtabel As String, ByVal strwhr As String, ByVal strord As String, Optional openargs As Integer = 0) As String
        'On Error Resume Next
        Dim cmd As SqlCommand
        Dim str(10) As String, strsql As String
        Dim itm As ListViewItem
        Dim dr As SqlDataReader
        Dim intCount As Integer = 0
        If cn.State = ConnectionState.Closed Then cn.Open()
        With Me
            .ListView1.Columns.Clear()
            .ListView1.Columns.Add("Kolom 1", "Kode", 100)
            .ListView1.Columns.Add("Kolom 2", "Keterangan1", 250)
            .ListView1.Columns.Add("Kolom 3", "Keterangan2", 250)

            .ListView1.Items.Clear()
            strsql = "SELECT TOP " & Me.txtrows.Text & " " & strfield1 & ", " & strfield2 & ", " & strfield3 & " FROM " & strtabel & " where " & strwhr & " order by " & strord
            cmd = New SqlCommand(strsql, cn)
            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                Do While dr.Read()

                    str(0) = IIf(IsDBNull(dr.Item(0).ToString()), "#", dr.Item(0).ToString())
                    str(1) = IIf(IsDBNull(dr.Item(1).ToString()), "#", dr.Item(1).ToString())
                    str(2) = IIf(IsDBNull(dr.Item(2).ToString()), "#", dr.Item(2).ToString())

                    itm = New ListViewItem(str)
                    .ListView1.Items.Add(itm)
                    If intCount Mod 2 Then
                        ListView1.Items(CInt(intCount)).BackColor = Color.SeaShell
                    Else
                        ListView1.Items(CInt(intCount)).BackColor = Color.White
                    End If
                    intCount = intCount + 1
                Loop
            End If
            Me.Label3.Text = Me.ListView1.Items.Count & " records"
            dr.Close()
            cmd.Dispose()
        End With
    End Function
    Private Sub txtrows_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtrows.TextChanged
        'If Me.TextBox1.Text <> "" Then TextBox1.PerformLayout()
        If IsNumeric(Me.txtrows.Text) Then
            Select Case Me.txtopenargs.Text
                Case Is = 0
                    opensearchform("ind_no", "CONVERT(VARCHAR(11),ind_tgl,106)", "(select c_name from mt_customer where c_id=ind_c_id)+'/'+ind_keterangan", "tr_induction", "ind_no<>'' and (ind_no+ind_tgl+ind_keterangan) like '%" & Me.TextBox1.Text & "%'", "ind_no", Me.txtopenargs.Text)
                Case Is = 1
                    If Me.ComboBox2.Text = "<--ALL-->" Then
                        opensearchform("kodemember", "namamember", "kodekomsel+' ~'+namapa+'/'+namapks", "m_member", "kodemember<>'' and (kodemember like '%" & Me.TextBox1.Text & "%' OR namamember like '%" & Me.TextBox1.Text & "%' OR kodekomsel like '%" & Me.TextBox1.Text & "%' OR telpmember like '%" & Me.TextBox1.Text & "%')", "kodemember desc", Me.txtopenargs.Text)
                    Else
                        Select Case Me.ComboBox2.Text
                            Case Is = "Nama_PA"
                                opensearchform("a.kodemember", "a.namamember", "a.kodekomsel+' ~'+a.namapa+'/'+a.namapks", "m_member a inner join m_member b on a.namapa=b.namapa", "(b.kodemember like '%" & Me.TextBox1.Text & "%' OR b.namamember like '%" & Me.TextBox1.Text & "%')", "a.kodemember desc", Me.txtopenargs.Text)
                            Case Is = "Nama_PKS"
                                opensearchform("a.kodemember", "a.namamember", "a.kodekomsel+' ~'+a.namapa+'/'+a.namapks", "m_member a inner join m_member b on a.namapks=b.namapks", "(b.kodemember like '%" & Me.TextBox1.Text & "%' OR b.namamember like '%" & Me.TextBox1.Text & "%')", "a.kodemember desc", Me.txtopenargs.Text)
                            Case Is = "Jenis_Kelamin"
                                opensearchform("a.kodemember", "a.namamember", "a.kodekomsel+' ~'+a.namapa+'/'+a.namapks", "m_member a inner join M_Event_Category b on a.jeniskelamin=b.catid", "(b.catcode like '%" & Me.TextBox1.Text & "%' OR b.catname like '%" & Me.TextBox1.Text & "%')", "a.kodemember desc", Me.txtopenargs.Text)
                            Case Is = "Gol_Darah"
                                opensearchform("a.kodemember", "a.namamember", "a.kodekomsel+' ~'+a.namapa+'/'+a.namapks", "m_member a inner join M_Event_Category b on a.goldarah=b.catid", "(b.catcode like '%" & Me.TextBox1.Text & "%' OR b.catname like '%" & Me.TextBox1.Text & "%')", "a.kodemember desc", Me.txtopenargs.Text)
                            Case Is = "Alamat_Tinggal"
                                opensearchform("kodemember", "namamember", "kodekomsel+' ~'+namapa+'/'+namapks", "m_member", "(alamatrumah like '%" & Me.TextBox1.Text & "%')", "kodemember desc", Me.txtopenargs.Text)
                            Case Is = "Alamat_Komsel"
                                opensearchform("a.kodemember", "a.namamember", "a.kodekomsel+' ~'+a.namapa+'/'+a.namapks", "m_member a inner join M_Event_Category b on a.komselid=b.catid", "(b.catcode like '%" & Me.TextBox1.Text & "%' OR b.catname like '%" & Me.TextBox1.Text & "%')", "a.kodemember desc", Me.txtopenargs.Text)
                            Case Is = "Status_Pernikahan"
                                opensearchform("a.kodemember", "a.namamember", "a.kodekomsel+' ~'+a.namapa+'/'+a.namapks", "m_member a inner join M_Event_Category b on a.statuspernikahan=b.catid", "(b.catcode like '%" & Me.TextBox1.Text & "%' OR b.catname like '%" & Me.TextBox1.Text & "%')", "a.kodemember desc", Me.txtopenargs.Text)
                            Case Is = "Status_Kejemaatan"
                                opensearchform("a.kodemember", "a.namamember", "a.kodekomsel+' ~'+a.namapa+'/'+a.namapks", "m_member a inner join M_Event_Category b on a.statusmember=b.catid", "(b.catcode like '%" & Me.TextBox1.Text & "%' OR b.catname like '%" & Me.TextBox1.Text & "%')", "a.kodemember desc", Me.txtopenargs.Text)
                            Case Is = "Fungsi_Keluarga"
                                opensearchform("a.kodemember", "a.namamember", "a.kodekomsel+' ~'+a.namapa+'/'+a.namapks", "m_member a inner join M_Event_Category b on a.fungsidalamkel=b.catid", "(b.catcode like '%" & Me.TextBox1.Text & "%' OR b.catname like '%" & Me.TextBox1.Text & "%')", "a.kodemember desc", Me.txtopenargs.Text)
                            Case Is = "Pendidikan_Terakhir"
                                opensearchform("a.kodemember", "a.namamember", "a.kodekomsel+' ~'+a.namapa+'/'+a.namapks", "m_member a inner join M_Event_Category b on a.pendidikanterakhir=b.catid", "(b.catcode like '%" & Me.TextBox1.Text & "%' OR b.catname like '%" & Me.TextBox1.Text & "%')", "a.kodemember desc", Me.txtopenargs.Text)
                        End Select
                    End If
                Case Is = 2
                    opensearchform("username", "usercode", "levelname", "M_UserLogin inner join M_UserLevel on M_UserLogin.levelsecurity=M_UserLevel.Levelid", "(username+levelname) like '%" & Me.TextBox1.Text & "%'", "username", Me.txtopenargs.Text)
                Case Is = 3
                    opensearchform("pono", "spkid", "name", "txpo inner join T_CARD on t_card.code=txpo.supplierid ", "pono<>'s' and (pono+spkid+name) like '%" & Me.TextBox1.Text & "%'", "pono", Me.txtopenargs.Text)
            End Select
        End If
    End Sub
    Private Sub ListView1_ColumnClick(sender As Object, e As System.Windows.Forms.ColumnClickEventArgs) Handles ListView1.ColumnClick
        'If (e.Column = ListView1Sorter.SortColumn) Then
        '    ' Reverse the current sort direction for this column.
        '    If (ListView1Sorter.Order = Windows.Forms.SortOrder.Ascending) Then
        '        ListView1Sorter.Order = Windows.Forms.SortOrder.Descending
        '    Else
        '        ListView1Sorter.Order = Windows.Forms.SortOrder.Ascending
        '    End If
        'Else
        '    ' Set the column number that is to be sorted; default to ascending.
        '    ListView1Sorter.SortColumn = e.Column
        '    ListView1Sorter.Order = Windows.Forms.SortOrder.Ascending
        'End If

        '' Perform the sort with these new sort options.
        'ListView1.Sort()
    End Sub
End Class