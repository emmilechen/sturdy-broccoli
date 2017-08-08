Imports System.Windows.Forms
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO
Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class frmMAIN
    Dim strConnection As String = My.Settings.ConnStr
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Dim cmd As SqlCommand, formkiri As Integer
    Sub DefineToolstrip()
        Dim myReader As SqlDataReader
        Dim prm1, prm2 As SqlParameter

        cmd = New SqlCommand("usp_mt_user_access_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        prm1 = cmd.Parameters.Add("@user_level_id", SqlDbType.Int)
        prm1.Value = p_UserLevel

        prm2 = cmd.Parameters.Add("@is_menu", SqlDbType.Bit)
        prm2.Value = 1

        cn.Open()
        myReader = cmd.ExecuteReader

        'Dim dt As New DataTable
        'dt.Load(myReader)
        'Dim values(myReader.FieldCount - 1) As Object
        'Dim fieldCount As Integer = myReader.GetValues(values)

        Dim al1 As New ArrayList()
        Dim al2 As New ArrayList()

        While myReader.Read
            Dim dict1 As New Dictionary(Of String, Object)
            For count As Integer = 0 To (myReader.FieldCount - 1)
                dict1.Add(myReader.GetName(count), myReader(count))
            Next
            al1.Add(dict1)
        End While

        myReader.NextResult()

        While myReader.Read
            Dim dict2 As New Dictionary(Of String, Object)
            For count As Integer = 0 To (myReader.FieldCount - 1)
                dict2.Add(myReader.GetName(count), myReader(count))
            Next
            al2.Add(dict2)
        End While

        myReader.Close()
        cn.Close()

        Dim menu As New MenuStrip()

        For Each i As Dictionary(Of String, Object) In al1
            'Console.Write(dat("menustrip_name"))
            Dim item As New ToolStripMenuItem(String.Format(i.Item("menustrip_name")))
            For Each j As Dictionary(Of String, Object) In al2
                If j("parent_id") = i("menu_id") Then
                    'Console.Write(dat("toolstrip_name"))
                    Dim innerItem As New ToolStripMenuItem(String.Format(j.Item("toolstrip_name")))

                    'Give the DropDown Item a name so it can be identified in the handler sub
                    'innerItem.Name = item.Text & "_" & j.ToString
                    innerItem.Name = j.Item("form_name")

                    'Add a Click handler to the DropDown Item
                    AddHandler innerItem.Click, AddressOf ToolStripMenuItem1_Click

                    item.DropDownItems.Add(innerItem)
                End If
            Next
            Menu.Items.Add(item)
        Next
        'Dim windowMenu As New ToolStripMenuItem("Window")
        'Dim windowNewMenu As New ToolStripMenuItem("New", Nothing, New EventHandler(AddressOf windowNewMenu_Click))
        'windowMenu.DropDownItems.Add(windowNewMenu)

        'menu.MdiWindowListItem = windowMenu
        'menu.Items.Add(windowMenu)

        'For i As Integer = 0 To 2
        '    Dim item As New ToolStripMenuItem(String.Format("Main Item{0}", i.ToString()))
        '    For j As Integer = 0 To 7
        '        Dim innerItem As New ToolStripMenuItem(String.Format("Inner Menu Item {0}", j.ToString()))

        '        'Give the DropDown Item a name so it can be identified in the handler sub
        '        innerItem.Name = item.Text & "_" & j.ToString

        '        'Add a Click handler to the DropDown Item
        '        AddHandler innerItem.Click, AddressOf ToolStripMenuItem1_Click

        '        item.DropDownItems.Add(innerItem)
        '    Next
        '    menu.Items.Add(item)
        '    'MenuStrip.Items.Add(item)
        'Next
        Me.Controls.Add(menu)
    End Sub
    Private Function openformutility(openargs As String, judul As String)
        Me.Cursor = Cursors.AppStarting
        For Each f As Form In Application.OpenForms
            If TypeOf f Is frmUtility And (f.Text = judul) Then
                'formkiri = IIf(formkiri = 0, f.Width, formkiri)
                f.Activate() : f.Left = 0 : Me.Cursor = Cursors.Default
                Exit Function
            ElseIf TypeOf f Is frmUtility And (f.Text <> judul) Then
                'formkiri = f.Width
            Else
                'formkiri = 0
            End If
        Next
        Dim MDIForm As New frmUtility(openargs, judul)
        MDIForm.MdiParent = Me
        'MDIForm.Left = formkiri
        MDIForm.Show()
        Me.Cursor = Cursors.Default
    End Function
    Private Sub frmMAIN_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'MenuStrip.Visible = False
        Try
            Dim fileReader As System.IO.StreamReader
            fileReader = My.Computer.FileSystem.OpenTextFileReader("C:\ProgramData\kbh.txt")

            Dim stringReader As String
            stringReader = fileReader.ReadLine()
            ' "k0t4r0m1n4m1" '
            If stringReader = "k0t4r0m1n4m1" Then

                Dim userCount As Integer
                Dim userEncrypt As String
                Dim userVal As Integer

                cmd = New SqlCommand("usp_mt_user_COUNT", cn)
                cmd.CommandType = CommandType.StoredProcedure

                cn.Open()
                Dim myReader = cmd.ExecuteReader

                While myReader.Read
                    userCount = myReader.GetInt32(0)
                End While

                myReader.Close()
                cn.Close()

                cmd = New SqlCommand("SELECT user_val from sys_company", cn)
                cn.Open()
                Dim myReader1 = cmd.ExecuteReader

                While myReader1.Read
                    userEncrypt = myReader1.GetString(0)
                End While

                myReader1.Close()
                cn.Close()

                '-------------------------DECRYPT FROM DB-------------------------------
                Dim cipherText As String = userEncrypt
                Dim password As String = "b119"
                Dim wrapper As New Dencrypt(password)
                userVal = CInt(wrapper.DecryptData(cipherText))
                '-------------------------END OF DECRYPT--------------------------------

                'If userCount <= userVal Then
                fdlLogin.ShowDialog()

                frmdashboard.MdiParent = Me
                frmdashboard.Show()
                frmdashboard.BringToFront()

                'Else
                '    MsgBox("User is more than " + CStr(userVal - 1) + " user please purchase additional user, contact support@mybrightsolution.com(Er:03)", MsgBoxStyle.Critical)
                '    End
                'End If
            End If
        Catch ex As Exception
            MsgBox("Unable to start Box Tree, please check :" + vbCrLf + "1.License" + vbCrLf + "2.Connection to server" + vbCrLf + "3.Server database" + vbCrLf + "For help please contact us at support@mybrightsolution.com" + vbCrLf + vbCrLf + "Error Message :" + vbCrLf + ex.Message, MsgBoxStyle.Critical)
            End
        End Try
    End Sub

    Private Sub ShowNewForm(ByVal sender As Object, ByVal e As EventArgs) Handles NewToolStripButton.Click
        ' Create a new instance of the child form.
        Dim ChildForm As New System.Windows.Forms.Form
        ' Make it a child of this MDI form before showing it.
        ChildForm.MdiParent = Me

        m_ChildFormNumber += 1
        ChildForm.Text = "Window " & m_ChildFormNumber

        ChildForm.Show()
    End Sub

    Private Sub OpenFile(ByVal sender As Object, ByVal e As EventArgs) Handles OpenToolStripButton.Click
        Dim OpenFileDialog As New OpenFileDialog
        OpenFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        OpenFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
        If (OpenFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = OpenFileDialog.FileName
            ' TODO: Add code here to open the file.
        End If
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim SaveFileDialog As New SaveFileDialog
        SaveFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        SaveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"

        If (SaveFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = SaveFileDialog.FileName
            ' TODO: Add code here to save the current contents of the form to a file.
        End If
    End Sub


    Private Sub ExitToolsStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub CutToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Use My.Computer.Clipboard to insert the selected text or images into the clipboard
    End Sub

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Use My.Computer.Clipboard to insert the selected text or images into the clipboard
    End Sub

    Private Sub PasteToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        'Use My.Computer.Clipboard.GetText() or My.Computer.Clipboard.GetData to retrieve information from the clipboard.
    End Sub

    Private Sub ToolBarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)

    End Sub

    Private Sub StatusBarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)

    End Sub

    Private Sub CascadeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub TileVerticalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub TileHorizontalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub ArrangeIconsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub

    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Close all child forms of the parent.
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
    End Sub

    Private m_ChildFormNumber As Integer

    Private Sub frmMAIN_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If MsgBox("Are you sure you want to exit?", vbCritical + vbOKCancel, Me.Text) = vbCancel Then
            e.Cancel = True
        End If
    End Sub

    Private Sub windowNewMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim DropDownName As String = DirectCast(sender, ToolStripItem).Name
        'MessageBox.Show(DropDownName)

        Dim strCreatedFromButton As String = DirectCast(sender, ToolStripItem).Name
        If Not GetPermission(strCreatedFromButton) = False Then
            Dim frm1 As New Form
            frm1 = DirectCast(CreateObjectInstance(strCreatedFromButton), Form)
            frm1.MdiParent = Me
            frm1.Show()
            frm1.BringToFront()
        End If
    End Sub

    Private Sub PurchaseOrderToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PurchaseOrderToolStripMenuItem1.Click
        If Not GetPermission("frmPOList") = False Then
            frmPOList.MdiParent = Me
            frmPOList.Show()
            frmPOList.BringToFront()
        End If
    End Sub

    Private Sub PurchaseReceiptToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PurchaseReceiptToolStripMenuItem1.Click
        If Not GetPermission("frmPReceiveList") = False Then
            frmPReceiveList.MdiParent = Me
            frmPReceiveList.Show()
            frmPReceiveList.BringToFront()
        End If
    End Sub

    Private Sub PaymentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PaymentToolStripMenuItem.Click
        If Not GetPermission("frmPPaymentList") = False Then
            frmPPaymentList.MdiParent = Me
            frmPPaymentList.Show()
            frmPPaymentList.BringToFront()
        End If
    End Sub

    Private Sub SalesOrderToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesOrderToolStripMenuItem1.Click
        If Not GetPermission("frmSOList") = False Then
            frmSOList.MdiParent = Me
            frmSOList.Show()
            frmSOList.BringToFront()
        End If
    End Sub

    Private Sub SalesInvoiceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesInvoiceToolStripMenuItem.Click
        If Not GetPermission("frmSInvoiceList") = False Then
            frmSInvoiceList.MdiParent = Me
            frmSInvoiceList.Show()
            frmSInvoiceList.BringToFront()
        End If
    End Sub

    Private Sub SalesPaymentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesPaymentToolStripMenuItem.Click
        If Not GetPermission("frmSPaymentList") = False Then
            With frmSPaymentList
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub SupplierMasterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SupplierMasterToolStripMenuItem.Click
        If Not GetPermission("frmSupplier") = False Then
            frmSupplier.MdiParent = Me
            frmSupplier.Show()
            frmSupplier.BringToFront()
        Else
            frmSupplier.Visible = False
        End If
    End Sub

    Private Sub StockMasterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StockMasterToolStripMenuItem.Click
        If Not GetPermission("frmSKU") = False Then
            frmSKU.MdiParent = Me
            frmSKU.Show()
            frmSKU.BringToFront()
        End If
    End Sub

    Private Sub StockCategoryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StockCategoryToolStripMenuItem.Click
        'If Not GetPermission("frmSKUCategory") = False Then
        frmSKUCategory.MdiParent = Me
        frmSKUCategory.Show()
        frmSKUCategory.BringToFront()
        'End If
    End Sub

    Private Sub CustomerMasterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CustomerMasterToolStripMenuItem.Click
        If Not GetPermission("frmCustomer") = False Then
            frmCustomer.MdiParent = Me
            frmCustomer.Show()
            frmCustomer.BringToFront()
        End If
    End Sub

    Private Sub StockAdjToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StockAdjToolStripMenuItem.Click
        If Not GetPermission("frmStockAdjList") = False Then
            frmStockAdjList.MdiParent = Me
            frmStockAdjList.Show()
            frmStockAdjList.BringToFront()
        End If
    End Sub

    Private Sub SystemNumberToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TransactionNumberToolStripMenuItem.Click
        If Not GetPermission("frmSYSNo") = False Then
            frmSYSNo.MdiParent = Me
            frmSYSNo.Show()
            frmSYSNo.BringToFront()
        End If
    End Sub

    Private Sub SignOutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SignOutToolStripMenuItem.Click
        Me.Text = "BoxTree"
        fdlLogin.ShowDialog()
    End Sub

    Private Sub SupplierListToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SupplierListToolStripMenuItem.Click
        If Not GetPermission("rptSupplierList") = False Then
            With rptSupplierList
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub StockListReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StockListReportToolStripMenuItem.Click
        If Not GetPermission("rptStkList") = False Then
            With rptStkList
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub CustomerListReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CustomerListReportToolStripMenuItem.Click
        If Not GetPermission("rptCustomerList") = False Then
            With rptCustomerList
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub CompanyProfileToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CompanyProfileToolStripMenuItem.Click
        If Not GetPermission("frmSYSCompany") = False Then
            frmSYSCompany.MdiParent = Me
            frmSYSCompany.Show()
            frmSYSCompany.BringToFront()
        End If
    End Sub

    Private Sub PurchaseRequestToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PurchaseRequestToolStripMenuItem.Click
        If Not GetPermission("frmPRequestList") = False Then
            With frmPRequestList
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub CurrencyToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CurrencyToolStripMenuItem1.Click
        If Not GetPermission("frmCurrency") = False Then
            With frmCurrency
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub LocationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LocationToolStripMenuItem.Click
        If Not GetPermission("frmLocation") = False Then
            With frmLocation
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub PurchaseRequestApprovalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PurchaseRequestApprovalToolStripMenuItem.Click
        If Not GetPermission("frmPRequestApprovalList") = False Then
            With frmPRequestApprovalList
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub ExpenseIncomeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExpenseIncomeToolStripMenuItem.Click
        If Not GetPermission("frmExpInc") = False Then
            With frmExpInc
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub StockSetToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not GetPermission("frmSKUPackageList") = False Then
            With frmSKURawList
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub PurchaseInvoiceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PurchaseInvoiceToolStripMenuItem.Click
        If Not GetPermission("frmPInvoiceList") = False Then
            With frmPInvoiceList
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub StockLocationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StockLocationToolStripMenuItem.Click
        If Not GetPermission("frmSKULocationList") = False Then
            With frmSKULocationList
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub SalesDeliveryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesDeliveryToolStripMenuItem.Click
        If Not GetPermission("frmSDeliveryList") = False Then
            With frmSDeliveryList
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub CurrencyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CurrencyToolStripMenuItem.Click
        With frmCurrencyR
            .MdiParent = Me
            .Show()
        End With
    End Sub

    Private Sub ExpenseIncomeToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExpenseIncomeToolStripMenuItem1.Click
        With frmExpenseR
            .MdiParent = Me
            .Show()
        End With
    End Sub

    Private Sub StockLocationMasterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StockLocationMasterToolStripMenuItem.Click
        If Not GetPermission("rptStkLocation") = False Then
            With rptStkLocation
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub BC40ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not GetPermission("frmBCList") = False Then
            With frmBCList
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub PurchaseReturnToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PurchaseReturnToolStripMenuItem.Click
        If Not GetPermission("frmPReturnList") = False Then
            With frmPReturnList
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub PurchaseOrderRecapToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PurchaseOrderRecapToolStripMenuItem.Click
        If Not GetPermission("rptPORecap") = False Then
            With rptPORecap
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub PurchaseOrderListToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PurchaseOrderListToolStripMenuItem.Click
        If Not GetPermission("rptPOList") = False Then
            With rptPOList
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub StockPriceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StockPriceToolStripMenuItem.Click
        If Not GetPermission("frmSKUPrice") = False Then
            With frmSKUPrice
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub StockMovementToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StockMovementToolStripMenuItem.Click
        If Not GetPermission("frmStockMovementList") = False Then
            With frmStockMovementList
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub PurchaseCodeStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PurchaseCodeStripMenuItem.Click
        If Not GetPermission("frmPurchaseCode") = False Then
            With frmPurchaseCode
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub SalesCodeStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesCodeStripMenuItem.Click
        If Not GetPermission("frmSalesCode") = False Then
            With frmSalesCode
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub SalesReturnToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesReturnToolStripMenuItem.Click
        If Not GetPermission("frmSReturnList") = False Then
            With frmSReturnList
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub StockTransactionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StockTransactionToolStripMenuItem.Click
        If Not GetPermission("rptStkTransaction") = False Then
            With rptStkTransaction
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub PurchaseIncomingReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PurchaseIncomingReportToolStripMenuItem.Click
        If Not GetPermission("rptPIncoming") = False Then
            With rptPIncoming
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub StockMovementReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StockMovementReportToolStripMenuItem.Click
        If Not GetPermission("rptStkMovement") = False Then
            With rptStkMovement
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub PurchaseRequestReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PurchaseRequestReportToolStripMenuItem.Click
        If Not GetPermission("rptPRequest") = False Then
            With rptPRequest
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub PurchaseInvoiceReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PurchaseInvoiceReportToolStripMenuItem.Click
        If Not GetPermission("rptPInvoice") = False Then
            With rptPInvoice
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub StockAdjustmentReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StockAdjustmentReportToolStripMenuItem.Click
        If Not GetPermission("rptStkAdjustment") = False Then
            With rptStkAdjustment
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub PurchaseReturnReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PurchaseReturnReportToolStripMenuItem.Click
        If Not GetPermission("rptPReturn") = False Then
            With rptPReturn
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub StockSetListToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StockSetListToolStripMenuItem.Click
        If Not GetPermission("rptStkSet") = False Then
            With rptStkSet
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub LocationListToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LocationListToolStripMenuItem.Click
        If Not GetPermission("rptLocation") = False Then
            Dim strConnection As String = My.Settings.ConnStr
            Dim Connection As New SqlConnection(strConnection)
            Dim strSQL As String


            strSQL = "exec RPT_Location_Report "

            Dim DA As New SqlDataAdapter(strSQL, Connection)
            Dim DS As New DataSet

            DA.Fill(DS, "Location_")

            Dim strReportPath As String = Application.StartupPath & "\Reports\RPT_Location_Report.rpt"

            If Not IO.File.Exists(strReportPath) Then
                Throw (New Exception("Unable to locate report file:" & _
                  vbCrLf & strReportPath))
            End If

            Dim cr As New ReportDocument
            Dim NewMDIChild As New frmDocViewer()
            NewMDIChild.Text = "Location"
            NewMDIChild.Show()

            cr.Load(strReportPath)
            cr.SetDataSource(DS.Tables("Location_"))
            With NewMDIChild
                .myCrystalReportViewer.ShowRefreshButton = False
                .myCrystalReportViewer.ShowCloseButton = False
                .myCrystalReportViewer.ShowGroupTreeButton = False
                .myCrystalReportViewer.ReportSource = cr
            End With
        End If
    End Sub

    Private Sub StockCategoryListToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StockCategoryListToolStripMenuItem.Click
        If Not GetPermission("rptStkCategory") = False Then
            Dim strConnection As String = My.Settings.ConnStr
            Dim Connection As New SqlConnection(strConnection)
            Dim strSQL As String


            strSQL = "exec RPT_Stk_Category_Report "

            Dim DA As New SqlDataAdapter(strSQL, Connection)
            Dim DS As New DataSet

            DA.Fill(DS, "StkCategory_")

            Dim strReportPath As String = Application.StartupPath & "\Reports\RPT_Stk_Category_Report.rpt"

            If Not IO.File.Exists(strReportPath) Then
                Throw (New Exception("Unable to locate report file:" & _
                  vbCrLf & strReportPath))
            End If

            Dim cr As New ReportDocument
            Dim NewMDIChild As New frmDocViewer()
            NewMDIChild.Text = "Stock Category"
            NewMDIChild.Show()

            cr.Load(strReportPath)
            cr.SetDataSource(DS.Tables("StkCategory_"))
            With NewMDIChild
                .myCrystalReportViewer.ShowRefreshButton = False
                .myCrystalReportViewer.ShowCloseButton = False
                .myCrystalReportViewer.ShowGroupTreeButton = False
                .myCrystalReportViewer.ReportSource = cr
            End With
        End If
    End Sub

    Private Sub FakturPajakToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        LvtAboutBox.Show()
    End Sub

    Private Sub PeriodToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PeriodToolStripMenuItem.Click
        If Not GetPermission("frmSYSPeriodList") = False Then
            With frmSYSPeriodList
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub SalesReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesReportToolStripMenuItem.Click
        If Not GetPermission("rptSlsOrder") = False Then
            With rptSlsOrder
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub SalesDeliveryReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesDeliveryReportToolStripMenuItem.Click
        If Not GetPermission("rptSlsDel") = False Then
            With rptSlsDel
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub SalesInvoiceReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesInvoiceReportToolStripMenuItem.Click
        If Not GetPermission("rptSlsInvoice") = False Then
            With rptSlsInvoice
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub SalesReturnReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesReturnReportToolStripMenuItem.Click
        If Not GetPermission("rptSlsReturn") = False Then
            With rptSlsReturn
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub PurchaseTransactionReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PurchaseTransactionReportToolStripMenuItem.Click
        If Not GetPermission("rptPTransaction") = False Then
            With rptPTransaction
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub SalesPriceListToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesPriceListToolStripMenuItem.Click
        If Not GetPermission("rptStkPrice") = False Then
            With rptStkPrice
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub SalesTransactionReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesTransactionReportToolStripMenuItem.Click
        If Not GetPermission("rptSlsTransaction") = False Then
            With rptSlsTransaction
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub BankCardToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BankCardToolStripMenuItem.Click
        If Not GetPermission("frmBank") = False Then
            With frmBank
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub ExpenseIncomeReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExpenseIncomeReportToolStripMenuItem.Click
        If Not GetPermission("rptExpInc") = False Then
            With rptExpInc
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub AccountMasterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AccountMasterToolStripMenuItem.Click
        If Not GetPermission("frmAccount") = False Then
            With frmAccount
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If

        'With frmSYSAccount
        '    .MdiParent = Me
        '    .Show()
        '    .BringToFront()
        'End With
    End Sub

    Private Sub JournalEntryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles JournalEntryToolStripMenuItem.Click
        If Not GetPermission("frmJournalList") = False Then
            With frmJournalList
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub PurchaseIncomingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PurchaseIncomingToolStripMenuItem.Click
        If Not GetPermission("frmPReceivePostList") = False Then
            With frmPReceivePostList
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub BankToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BankToolStripMenuItem1.Click
        If Not GetPermission("rptBankList") = False Then
            With rptBankList
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub PurchasePaymentReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PurchasePaymentReportToolStripMenuItem.Click
        If Not GetPermission("rptPPayment") = False Then
            With rptPPayment
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub SalesReceiptReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesReceiptReportToolStripMenuItem.Click
        If Not GetPermission("rptSlsReceipt") = False Then
            With rptSlsReceipt
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub GeneralLedgerAccountToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LedgerAccountSettingToolStripMenuItem.Click
        If Not GetPermission("frmSYSAccount") = False Then
            With frmSYSAccount
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub PurchaseInvoiceToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PurchaseInvoiceToolStripMenuItem1.Click
        If Not GetPermission("frmPInvoicePostList") = False Then
            With frmPInvoicePostList
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub WorkOrderToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not GetPermission("frmWorkOrderList") = False Then
            With frmWorkOrderList
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub BankTransactionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BankTransactionToolStripMenuItem.Click
        If Not GetPermission("rptBankTransaction") = False Then
            With rptBankTransaction
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub StockControlReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StockControlReportToolStripMenuItem.Click
        If Not GetPermission("rptStkControl") = False Then
            With rptStkControl
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub FakturPajakToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FakturPajakToolStripMenuItem.Click
        If Not GetPermission("rptFakturPajak") = False Then
            With rptFakturPajak
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub WorkOrderReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WorkOrderReportToolStripMenuItem.Click
        If Not GetPermission("rptWorkOrder") = False Then
            With rptWorkOrder
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub LedgerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LedgerToolStripMenuItem.Click

    End Sub

    Private Sub MenuStrip_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles MenuStrip.ItemClicked

    End Sub

    Private Sub PurchasePaymentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PurchasePaymentToolStripMenuItem.Click
        If Not GetPermission("frmPPaymentPostList") = False Then
            With frmPPaymentPostList
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub BankAdjustmentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BankAdjustmentToolStripMenuItem.Click
        If Not GetPermission("frmBankAdjList") = False Then
            With frmBankAdjList
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub PurchaseReturnToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PurchaseReturnToolStripMenuItem1.Click
        If Not GetPermission("frmPReturnPostList") = False Then
            With frmPReturnPostList
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub WorkOrderSummaryReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WorkOrderSummaryReportToolStripMenuItem.Click
        'If Not GetPermission("rptWorkOrderSummary") = False Then
        '    With rptWorkOrderSummary
        '        .MdiParent = Me
        '        .Show()
        '        .BringToFront()
        '    End With
        'End If
    End Sub

    Private Sub SalesMonthlyStatementReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesMonthlyStatementReportToolStripMenuItem.Click
        If Not GetPermission("rptSlsMonthlyStatement") = False Then
            With rptSlsMonthlyStatement
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub BackgroundParameterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BackgroundParameterToolStripMenuItem.Click
        If Not GetPermission("frmSYSSetting") = False Then
            With frmSYSSetting
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub BankPaymentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BankPaymentToolStripMenuItem.Click
        If Not GetPermission("frmBankPaymentList") = False Then
            With frmBankPaymentList
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub BankReceiptToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BankReceiptToolStripMenuItem.Click
        If Not GetPermission("frmBankReceiptList") = False Then
            With frmBankReceiptList
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub StockCostAdjustmentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StockCostAdjustmentToolStripMenuItem.Click
        If Not GetPermission("frmStockCostAdjList") = False Then
            With frmStockCostAdjList
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub SalesDeliveryToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesDeliveryToolStripMenuItem1.Click
        If Not GetPermission("frmSDeliveryPostList") = False Then
            With frmSDeliveryPostList
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub SalesInvoiceToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesInvoiceToolStripMenuItem1.Click
        If Not GetPermission("frmSInvoicePostList") = False Then
            With frmSInvoicePostList
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub SalesReceiptToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesReceiptToolStripMenuItem.Click
        If Not GetPermission("frmSPaymentPostList") = False Then
            With frmSPaymentPostList
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub SupplierAdjustmentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SupplierAdjustmentToolStripMenuItem.Click
        If Not GetPermission("frmSupplierAdjList") = False Then
            With frmSupplierAdjList
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub SalesReturnToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesReturnToolStripMenuItem1.Click
        If Not GetPermission("frmSReturnPostList") = False Then
            With frmSReturnPostList
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub PurchaseAPAgingReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PurchaseAPAgingReportToolStripMenuItem.Click
        If Not GetPermission("rptPAPAging") = False Then
            With rptPAPAging
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub SalesARAgingReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesARAgingReportToolStripMenuItem.Click
        If Not GetPermission("rptSlSARAging") = False Then
            With rptSlsARAging
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub PurchaseInvoiceSummaryReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PurchaseInvoiceSummaryReportToolStripMenuItem.Click
        If Not GetPermission("rptPInvoiceSum") = False Then
            With rptPInvoiceSum
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub StockAdjustmentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StockAdjustmentToolStripMenuItem.Click
        If Not GetPermission("frmStockAdjPostList") = False Then
            With frmStockAdjPostList
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub StockMovementToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StockMovementToolStripMenuItem1.Click
        If Not GetPermission("frmStockMovementPostList") = False Then
            With frmStockMovementPostList
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub BankReceiptToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BankReceiptToolStripMenuItem1.Click
        If Not GetPermission("frmBankReceiptPostList") = False Then
            With frmBankReceiptPostList
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub BankPaymentToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BankPaymentToolStripMenuItem1.Click
        If Not GetPermission("frmBankPaymentPostList") = False Then
            With frmBankPaymentPostList
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub COGSReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles COGSReportToolStripMenuItem.Click
        If Not GetPermission("rptSlsCOGS") = False Then
            With rptSlsCOGS
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub CurrencyRevaluationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CurrencyRevaluationToolStripMenuItem.Click
        If Not GetPermission("frmCurrencyRevaluation") = False Then
            With frmCurrencyRevaluation
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub JournalTransactionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles JournalTransactionToolStripMenuItem.Click
        If Not GetPermission("rptGLJournalTrans") = False Then
            With rptGLJournalTrans
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub StockSubCategoryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StockSubCategoryToolStripMenuItem.Click
        'If Not GetPermission("frmSKUCategorySub") = False Then
        frmSKUCategorySub.MdiParent = Me
        frmSKUCategorySub.Show()
        frmSKUCategorySub.BringToFront()
        'End If
    End Sub

    Private Sub FormInductionToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles FormInductionToolStripMenuItem.Click
        'If Not GetPermission("frmSOList") = False Then
        FTR_Induction.MdiParent = Me
        FTR_Induction.Show()
        FTR_Induction.BringToFront()
        'End If
    End Sub

    Private Sub MachineToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles MachineToolStripMenuItem.Click
        'If Not GetPermission("frmSOList") = False Then
        frmMesin.MdiParent = Me
        frmMesin.Show()
        frmMesin.BringToFront()
        'End If
    End Sub

    Private Sub PurchasePitchingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PurchasePitchingToolStripMenuItem.Click
        frmPPitchingList.MdiParent = Me
        frmPPitchingList.Show()
        frmPPitchingList.BringToFront()
    End Sub

    Private Sub PurchasePitchingApprovalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PurchasePitchingApprovalToolStripMenuItem.Click
        frmPPitchingApprovalList.MdiParent = Me
        frmPPitchingApprovalList.Show()
        frmPPitchingApprovalList.BringToFront()
    End Sub

    Private Sub UtilityFormToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles UtilityFormToolStripMenuItem.Click
        frmFormmod.MdiParent = Me
        frmFormmod.Show()
        frmFormmod.BringToFront()
    End Sub
    Private Sub DepartementToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles DepartementToolStripMenuItem.Click
        openformutility(sender.Tag.ToString, sender.ToString)
    End Sub
    Private Sub DivisionToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles DivisionToolStripMenuItem.Click
        openformutility(sender.Tag.ToString, sender.ToString)
    End Sub
    Private Sub UnitOfMeasurementElectricalToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles UnitOfMeasurementElectricalToolStripMenuItem.Click
        openformutility(sender.Tag.ToString, sender.ToString)
    End Sub
    Private Sub UnitOfMeasurementSizeToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles UnitOfMeasurementSizeToolStripMenuItem.Click
        openformutility(sender.Tag.ToString, sender.ToString)
    End Sub
    Private Sub UnitOfMeasurementSpeedToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles UnitOfMeasurementSpeedToolStripMenuItem.Click
        openformutility(sender.Tag.ToString, sender.ToString)
    End Sub
    Private Sub PurchaseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PurchaseToolStripMenuItem.Click

    End Sub
    Private Sub MasterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MasterToolStripMenuItem.Click

    End Sub
    Private Sub UnitOfMeasurementToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UnitOfMeasurementToolStripMenuItem.Click
        frmSKUUoM.MdiParent = Me
        frmSKUUoM.Show()
        frmSKUUoM.BringToFront()
    End Sub

    Private Sub UserToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles UserToolStripMenuItem.Click
        If Not GetPermission("frmUser") = False Then
            frmUser.MdiParent = Me
            frmUser.Show()
            frmUser.BringToFront()
        End If
    End Sub

    Private Sub UserLevelToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles UserLevelToolStripMenuItem.Click
        If Not GetPermission("frmUserLevel") = False Then
            frmUserLevel.MdiParent = Me
            frmUserLevel.Show()
            frmUserLevel.BringToFront()
        End If
    End Sub

    Private Sub UOMElectricalToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles UOMElectricalToolStripMenuItem.Click
        openformutility(sender.Tag.ToString, sender.ToString)
    End Sub

    Private Sub UOMSizeToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles UOMSizeToolStripMenuItem.Click
        openformutility(sender.Tag.ToString, sender.ToString)
    End Sub

    Private Sub UOMSpeedToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles UOMSpeedToolStripMenuItem.Click
        openformutility(sender.Tag.ToString, sender.ToString)
    End Sub

    Private Sub MachineCategoryToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles MachineCategoryToolStripMenuItem.Click
        openformutility(sender.Tag.ToString, sender.ToString)
    End Sub

    Private Sub MachineSubCategoryToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles MachineSubCategoryToolStripMenuItem.Click
        openformutility(sender.Tag.ToString, sender.ToString)
    End Sub

    Private Sub MachineDivisionToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles MachineDivisionToolStripMenuItem.Click
        openformutility(sender.Tag.ToString, sender.ToString)
    End Sub

    Private Sub SalesQuotionToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SalesQuotionToolStripMenuItem.Click
        frmSQuoteList.MdiParent = Me
        frmSQuoteList.Show()
        frmSQuoteList.BringToFront()
    End Sub

    Private Sub SalesQuotationApprovalToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SalesQuotationApprovalToolStripMenuItem.Click
        frmSQuoteApprovalList.MdiParent = Me
        frmSQuoteApprovalList.Show()
        frmSQuoteApprovalList.BringToFront()
    End Sub

    Private Sub ProductionMemoToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ProductionMemoToolStripMenuItem.Click
        ftr_mp.MdiParent = Me
        ftr_mp.Show()
        ftr_mp.BringToFront()
    End Sub

    Private Sub RequestMemoToWarehouseToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RequestMemoToWarehouseToolStripMenuItem.Click
        ftr_mrq.MdiParent = Me
        ftr_mrq.Show()
        ftr_mrq.BringToFront()
    End Sub

    Private Sub CustomerCategoryToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CustomerCategoryToolStripMenuItem.Click
        openformutility(sender.Tag.ToString, sender.ToString)
    End Sub

    Private Sub CustomerTitleToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CustomerTitleToolStripMenuItem.Click
        openformutility(sender.Tag.ToString, sender.ToString)
    End Sub
End Class
