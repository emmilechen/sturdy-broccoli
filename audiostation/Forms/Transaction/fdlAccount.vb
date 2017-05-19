Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class fdlAccount
    Dim strConnection As String = My.Settings.ConnStr
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Dim cmd As SqlCommand
    Dim m_FrmCallerId As String

    Public Property FrmCallerId() As String
        Get
            Return m_FrmCallerId
        End Get
        Set(ByVal Value As String)
            m_FrmCallerId = Value
        End Set
    End Property


    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        'Me.DialogResult = System.Windows.Forms.DialogResult.OK
        'Me.Close()
        If ListView1.SelectedItems.Count > 0 Then
            ListView1_DoubleClick(sender, e)
        Else
            MessageBox.Show("You didn't select any item yet. Please select an item.", Me.Text)
        End If
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        'Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub fdlAccount_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With ListView1
            .Clear()
            .View = View.Details
            .Columns.Add("Account Code", 90)
            .Columns.Add("Account Name", 250)
        End With

        cmd = New SqlCommand("usp_mt_account_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm1 As SqlParameter = cmd.Parameters.Add("@account_code", SqlDbType.NVarChar, 50)
        prm1.Value = IIf(txtFilter.Text = "", DBNull.Value, txtFilter.Text)

        cn.Open()

        Dim myReader As SqlDataReader = cmd.ExecuteReader()

        Call FillList(myReader, Me.ListView1, 3, 1)
        myReader.Close()
        cn.Close()
    End Sub

    Private Sub ListView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.DoubleClick
        Select Case m_FrmCallerId
            Case "frmSYSAccount"
                With frmSYSAccount
                    .AccountId = LeftSplitUF(ListView1.SelectedItems.Item(0).Tag)
                    .AccountCode = ListView1.SelectedItems.Item(0).SubItems.Item(0).Text
                End With
            Case "frmSKUCat"
                With frmSKUCategory
                    .AccountId = LeftSplitUF(ListView1.SelectedItems.Item(0).Tag)
                    .AccountCode = ListView1.SelectedItems.Item(0).SubItems.Item(0).Text
                End With
            Case "frmExpInc"
                With frmExpInc
                    .AccountId = LeftSplitUF(ListView1.SelectedItems.Item(0).Tag)
                    .AccountCode = ListView1.SelectedItems.Item(0).SubItems.Item(0).Text
                End With
            Case "frmJournal"
                With frmJournal
                    .AccountId = LeftSplitUF(ListView1.SelectedItems.Item(0).Tag)
                    .AccountCode = ListView1.SelectedItems.Item(0).SubItems.Item(0).Text
                    .AccountName = ListView1.SelectedItems.Item(0).SubItems.Item(1).Text
                End With
            Case "rptGLJournalTransFrom"
                With rptGLJournalTrans
                    .AccountCodeFrom = ListView1.SelectedItems.Item(0).SubItems.Item(0).Text
                End With
            Case "rptGLJournalTransTo"
                With rptGLJournalTrans
                    .AccountCodeTo = ListView1.SelectedItems.Item(0).SubItems.Item(0).Text
                End With
        End Select
        Me.Close()
    End Sub

    Private Sub txtFilter_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFilter.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            fdlAccount_Load(sender, e)
        End If
    End Sub

    Private Sub fdlAccount_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        'Me.Dispose()
    End Sub
End Class
