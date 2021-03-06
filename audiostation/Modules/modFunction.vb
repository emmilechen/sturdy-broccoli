﻿Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System
Imports System.Security.Cryptography
Imports System.Text
Imports System.Net.NetworkInformation
Imports System.Reflection
Imports System.IO
Module modFunction
    Dim strConnection As String = My.Settings.ConnStr
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Dim cmd As SqlCommand
    'Function used to left split user fields
    Public Function LeftSplitUF(ByVal srcUF As String) As String
        If srcUF = "*~~~~~*" Then LeftSplitUF = "" : Exit Function
        Dim i As Integer
        Dim t As String = ""
        For i = 1 To Len(srcUF)
            If Mid$(srcUF, i, 7) = "*~~~~~*" Then
                Exit For
            Else
                t &= Mid$(srcUF, i, 1)
            End If
        Next i
        LeftSplitUF = t
        i = 0
        t = ""
    End Function
    'Function used to right split user fields
    Public Function RightSplitUF(ByVal srcUF As String) As String
        If srcUF = "*~~~~~*" Then RightSplitUF = "" : Exit Function
        Dim i As Integer
        Dim t As String = ""
        For i = (InStr(1, srcUF, "*~~~~~*", vbTextCompare) + 7) To Len(srcUF)
            t &= Mid$(srcUF, i, 1)
        Next i
        RightSplitUF = t
        i = 0
        t = ""
    End Function

    Function GetSysNumber(ByVal TrxType As String, ByVal m_Date As Date) As String
        GetSysNumber = ""
        cmd = New SqlCommand("sp_sys_no_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm1 As SqlParameter = cmd.Parameters.Add("@trxtype", SqlDbType.NVarChar, 50)
        prm1.Value = TrxType

        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If
        Dim myReader As SqlDataReader = cmd.ExecuteReader()
        While myReader.Read()
            GetSysNumber = CStr(myReader.GetInt32(2))
            For i = 1 To myReader.GetInt32(4)
                If Len(GetSysNumber) < myReader.GetInt32(4) Then
                    GetSysNumber = "0" + GetSysNumber
                End If
            Next i
            If myReader.GetBoolean(5) = True Then
                GetSysNumber = m_Date.ToString("yy") + m_Date.ToString("MM") + GetSysNumber
            Else
                GetSysNumber = m_Date.ToString("yy") + GetSysNumber
            End If

            If Not myReader.IsDBNull(myReader.GetOrdinal("TrxPrefix")) Then
                GetSysNumber = myReader.GetString(myReader.GetOrdinal("TrxPrefix")) + GetSysNumber
            End If
        End While
        myReader.Close()
        cn.Close()
    End Function
    Function GetSysInit(ByVal sysInitId As String) As String
        GetSysInit = ""
        cmd = New SqlCommand("usp_sys_init_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm1 As SqlParameter = cmd.Parameters.Add("@sys_init_id", SqlDbType.NVarChar, 50)
        prm1.Value = sysInitId

        If cn.State = Data.ConnectionState.Closed Then cn.Open()
        Dim myReader As SqlDataReader = cmd.ExecuteReader()
        While myReader.Read()
            GetSysInit = myReader.GetString(2)
        End While
        myReader.Close()
        cn.Close()
    End Function
    Function GetPermission(ByVal FormName As String) As Boolean
        GetPermission = False
        cmd = New SqlCommand("usp_mt_user_access_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm1 As SqlParameter = cmd.Parameters.Add("@user_level_id", SqlDbType.Int, 50)
        prm1.Value = p_UserLevel
        Dim prm2 As SqlParameter = cmd.Parameters.Add("@user_access_id", SqlDbType.Int, 50)
        prm2.Value = 0
        Dim prm3 As SqlParameter = cmd.Parameters.Add("@form_name", SqlDbType.NVarChar, 50)
        prm3.Value = FormName

        If cn.State = Data.ConnectionState.Closed Then cn.Open()
        Dim myReader As SqlDataReader = cmd.ExecuteReader()
        While myReader.Read()
            GetPermission = CBool(myReader.GetValue(3).ToString)
            If GetPermission = False Then
                MsgBox("You don't have authority to open the form. Please contact your administrator.", vbCritical + vbOKOnly, myReader.GetString(2))
            End If
        End While
        myReader.Close()
        cn.Close()
    End Function

    Function GetSysAccount(ByVal sysAccountType As String) As Integer
        GetSysAccount = 0
        cmd = New SqlCommand("usp_sys_account_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm1 As SqlParameter = cmd.Parameters.Add("@sys_account_type", SqlDbType.NVarChar, 50)
        prm1.Value = sysAccountType

        cn.Open()
        Dim myReader As SqlDataReader = cmd.ExecuteReader()
        While myReader.Read()
            If myReader.Item(2) Is System.DBNull.Value Then
                GetSysAccount = 0
            Else
                GetSysAccount = myReader.Item(2)
            End If
        End While
        myReader.Close()
        cn.Close()
    End Function

    Function canDelete(ByVal form_name As String) As Boolean
        Dim formDelete As Boolean
        Try
            cmd = New SqlCommand("usp_mt_user_access_SEL", cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm1 As SqlParameter = cmd.Parameters.Add("@user_level_id", SqlDbType.Int, 50)
            prm1.Value = p_UserLevel
            Dim prm2 As SqlParameter = cmd.Parameters.Add("@form_name", SqlDbType.NVarChar, 50)
            prm2.Value = form_name

            If cn.State = Data.ConnectionState.Closed Then cn.Open()
            Dim myReader As SqlDataReader = cmd.ExecuteReader()
            While myReader.Read
                formDelete = CBool(myReader.GetValue(4))
            End While
            myReader.Close()
            cn.Close()
            If formDelete = True Then
                Return True
            Else
                Return False
            End If
            Exit Function
        Catch ex As Exception
            MsgBox(ex.Message)
            If ConnectionState.Open = 1 Then cn.Close()
            Return False
        End Try
    End Function

    Function isDeletedRecord(ByVal spName As String, ByVal fieldName As String, ByVal fieldId As Integer, ByVal formText As String) As Boolean
        isDeletedRecord = False
        cmd = New SqlCommand(spName, cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm1 As SqlParameter = cmd.Parameters.Add("@" & fieldName, SqlDbType.Int)
        prm1.Value = fieldId

        If cn.State = Data.ConnectionState.Closed Then cn.Open()

        Dim myReader As SqlDataReader = cmd.ExecuteReader()

        If myReader.HasRows = False Then
            MsgBox("This record has been deleted before.", vbCritical + vbOKOnly, formText)
            isDeletedRecord = True
        End If
        myReader.Close()
        cn.Close()
    End Function

    Function existingDocumentNo(ByVal tableName As String, ByVal fieldName As String, ByVal fieldValue As String) As Boolean
        Dim myReader As SqlDataReader

        cmd = New SqlCommand("select * from " + tableName + " where " + fieldName + "='" + fieldValue + "' ", cn)

        If cn.State = Data.ConnectionState.Closed Then cn.Open()
        myReader = cmd.ExecuteReader

        If myReader.HasRows Then
            existingDocumentNo = True
        Else
            existingDocumentNo = False
        End If

        myReader.Close()
        cn.Close()
    End Function

    Function GetMd5Hash(ByVal md5Hash As MD5, ByVal input As String) As String

        ' Convert the input string to a byte array and compute the hash. 
        Dim data As Byte() = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input))

        ' Create a new Stringbuilder to collect the bytes 
        ' and create a string. 
        Dim sBuilder As New StringBuilder()

        ' Loop through each byte of the hashed data  
        ' and format each one as a hexadecimal string. 
        Dim i As Integer
        For i = 0 To data.Length - 1
            sBuilder.Append(data(i).ToString("x2"))
        Next i

        ' Return the hexadecimal string. 
        Return sBuilder.ToString()

    End Function 'GetMd5Hash

    ' Verify a hash against a string. 
    Function VerifyMd5Hash(ByVal md5Hash As MD5, ByVal input As String, ByVal hash As String) As Boolean
        ' Hash the input. 
        Dim hashOfInput As String = GetMd5Hash(md5Hash, input)

        ' Create a StringComparer an compare the hashes. 
        Dim comparer As StringComparer = StringComparer.OrdinalIgnoreCase

        If 0 = comparer.Compare(hashOfInput, hash) Then
            Return True
        Else
            Return False
        End If

    End Function 'VerifyMd5Hash
    'Program 
    ' This code example produces the following output: 
    ' 
    ' The MD5 hash of Hello World! is: ed076287532e86365e841e92bfc50d8c. 
    ' Verifying the hash... 
    ' The hashes are the same.

    Function getMacAddress()
        Dim nics() As NetworkInterface = NetworkInterface.GetAllNetworkInterfaces()
        Return nics(0).GetPhysicalAddress.ToString
    End Function

    'Check user log
    Function checkUserLog(ByVal userName As String, ByVal workStation As String) As Boolean
        Dim isLogged As Boolean
        Try
            cmd = New SqlCommand("usp_sys_SEL", cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm1 As SqlParameter = cmd.Parameters.Add("@user_name", SqlDbType.NVarChar, 50)
            '------------------------ENCRYPTING PASSWORD----------------------------
            Dim plainText As String = userName
            Dim password As String = "b119"

            Dim wrapper As New Dencrypt(password)
            Dim EncryptPass As String = wrapper.EncryptData(plainText)
            '------------------------END OF ENCRYPTING PASSWORD----------------------------
            prm1.Value = EncryptPass

            Dim prm2 As SqlParameter = cmd.Parameters.Add("@workstation", SqlDbType.NVarChar, 100)
            '------------------------ENCRYPTING PASSWORD----------------------------
            Dim plainText2 As String = workStation
            Dim password2 As String = "b119"

            Dim wrapper2 As New Dencrypt(password2)
            Dim EncryptPass2 As String = wrapper2.EncryptData(plainText2)
            '------------------------END OF ENCRYPTING PASSWORD----------------------------
            prm2.Value = EncryptPass2

            If cn.State = Data.ConnectionState.Closed Then cn.Open()
            Dim myReader As SqlDataReader = cmd.ExecuteReader()
            If myReader.HasRows Then
                isLogged = True
            Else
                isLogged = False
            End If
            myReader.Close()
            cn.Close()
        Catch ex As Exception
            If ConnectionState.Open = 1 Then cn.Close()
        End Try
        If isLogged = True Then
            Return True
        Else
            Return False
        End If
    End Function

    'return line frmMAIN license file
    Public Function ReadLine(ByVal lineNumber As Integer, ByVal lines As List(Of String)) As String
        Return lines(lineNumber)
    End Function

    Function GetPeriodName(ByVal PeriodId As Integer) As String
        GetPeriodName = ""
        cmd = New SqlCommand("usp_sys_period_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm1 As SqlParameter = cmd.Parameters.Add("@period_id", SqlDbType.Int)
        prm1.Value = PeriodId

        If cn.State = Data.ConnectionState.Closed Then cn.Open()
        Dim myReader As SqlDataReader = cmd.ExecuteReader()
        While myReader.Read()
            GetPeriodName = myReader.GetString(1)
        End While
        myReader.Close()
        cn.Close()
    End Function

    Public Function CreateObjectInstance(ByVal objectName As String) As Object
        Dim obj As Object
        Try
            If objectName.LastIndexOf(".") = -1 Then
                objectName = [Assembly].GetEntryAssembly.GetName.Name & "." & objectName
            End If

            obj = [Assembly].GetEntryAssembly.CreateInstance(objectName)

        Catch ex As Exception
            obj = Nothing
        End Try
        Return obj

    End Function
    Public Function getvalcheck(ByVal kondisi As Boolean) As Integer
        getvalcheck = IIf(kondisi, 1, 0)
        Return getvalcheck
    End Function
    Public Function Executestr(ByVal strsql As String) As Boolean
        'On Error Resume Next
        Dim cmd As SqlCommand
        Try
            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If

            cmd = New SqlCommand(strsql, cn)
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            Executestr = True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Exec Str")
            Executestr = False
        End Try

    End Function
    Public Function checkisnumber(ByVal KCode As String) As Boolean
        If Asc(KCode) <> 13 AndAlso Asc(KCode) <> 8 AndAlso Not IsNumeric(KCode) AndAlso Not KCode = "." Then
            MsgBox("Please enter numbers only !", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Box-Tree")
            checkisnumber = False
        Else
            checkisnumber = True
        End If
    End Function
    Function GetCurrentID(ByVal outputfield As String, ByVal namatable As String, ByVal kondisi As String) As String
        On Error Resume Next
        Dim cmd As SqlCommand
        Dim dr As SqlDataReader

        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If

        cmd = New SqlCommand("Select " & outputfield & " from " & namatable & " where " & kondisi, cn)
        dr = cmd.ExecuteReader()

        If dr.Read() Then

            GetCurrentID = dr.Item(outputfield).ToString()

        End If

        dr.Close()
        cmd.Dispose()
        'Exit Function
    End Function
    Function GETGeneralcode(ByVal kodetrx As String, ByVal namatable As String, ByVal NamaField As String, ByVal strtgl As String, ByVal requestcode As Object, ByVal masterno As Boolean, Optional panjangangka As Integer = 1, Optional ambilangka As Integer = 1, Optional pembatas As String = "", Optional kondisi As String = "") As String
        Dim cmd As SqlCommand
        Dim dr As SqlDataReader
        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If

        If masterno Then
            'mst only
            If kondisi = "" Then
                cmd = New SqlCommand("Select Max(Right([" & NamaField & "]," & panjangangka & ")) as mstcode from " & namatable & " where Left(" & NamaField & "," & ambilangka & ")='" & Left(requestcode, ambilangka) & "'", cn)
                dr = cmd.ExecuteReader()
                If dr.Read() Then
                    GETGeneralcode = Left(UCase(requestcode), ambilangka) & pembatas & Right("000" & Right(IIf(IsDBNull(dr.Item("mstcode").ToString()) Or dr.Item("mstcode").ToString() = "", 0, dr.Item("mstcode").ToString()), panjangangka) + 1, panjangangka)
                Else
                    GETGeneralcode = Left(UCase(requestcode), ambilangka) & pembatas & "001"
                End If
                dr.Close()
                cmd.Dispose()
            Else
                cmd = New SqlCommand("Select Max(Right([" & NamaField & "]," & panjangangka & ")) as mstcode from " & namatable & " where " & kondisi, cn)
                dr = cmd.ExecuteReader()
                If dr.Read() Then
                    GETGeneralcode = Right("000000000" & Right(IIf(IsDBNull(dr.Item("mstcode").ToString()) Or dr.Item("mstcode").ToString() = "", 0, Trim(System.Text.RegularExpressions.Regex.Replace(dr.Item("mstcode").ToString(), "[^\d]", " "))), panjangangka) + 1, panjangangka)
                Else
                    GETGeneralcode = "000000001"
                End If
                dr.Close()
                cmd.Dispose()
            End If
        Else
            'trx only
            cmd = New SqlCommand("SELECT Max(Right([" & NamaField & "]," & panjangangka & ")) AS LastBatch, SUBSTRING(CONVERT(varchar, " & strtgl & ", 112), 1, 6) AS Expr1  " & _
                                 " FROM " & namatable & " GROUP BY SUBSTRING(CONVERT(varchar, " & strtgl & ", 112), 1, 6) Having SUBSTRING(CONVERT(varchar, " & strtgl & ", 112), 1, 6) ='" & Format(requestcode, "yyyyMM") & "'", cn)
            dr = cmd.ExecuteReader()
            If dr.Read() Then
                GETGeneralcode = kodetrx & BulanAbjad(CDate(requestcode)) & Right("0000" & Right(dr.Item("LastBatch").ToString, panjangangka) + 1, panjangangka)
            Else
                GETGeneralcode = kodetrx & BulanAbjad(CDate(requestcode)) & "0001" 'Format(requestcode, "yyMM") 
            End If
            dr.Close()
            cmd.Dispose()
        End If
    End Function
    Public Function BulanAbjad(Tanggal As Date) As String
        Dim BULAN As Integer
        Dim BranchID As Integer = 1
        BULAN = Month(Tanggal)
        Select Case BULAN
            Case 1
                BulanAbjad = "A"
            Case 2
                BulanAbjad = "B"
            Case 3
                BulanAbjad = "C"
            Case 4
                BulanAbjad = "D"
            Case 5
                BulanAbjad = "E"
            Case 6
                BulanAbjad = "F"
            Case 7
                BulanAbjad = "G"
            Case 8
                BulanAbjad = "H"
            Case 9 ' ngak ada I, krn rancu dgn angka 1
                BulanAbjad = "J"
            Case 10
                BulanAbjad = "K"
            Case 11
                BulanAbjad = "L"
            Case 12
                BulanAbjad = "M"
        End Select
        BulanAbjad = BranchID & Right(Year(Tanggal), 2) & BulanAbjad
    End Function
    Public Function getpwd(ByVal pwd As String, ByVal parampwd As String, ByVal formathash As String) As String
        Dim plainText As String = pwd
        Dim password As String = parampwd

        Dim wrapper As New Dencrypt(password)
        If formathash = "enc" Then
            getpwd = wrapper.EncryptData(plainText)
        Else
            getpwd = wrapper.DecryptData(plainText)
        End If
        Return getpwd
    End Function
    Public Function Fillobject(ByVal txtid As TextBox, ByVal root As Control, ByVal action As String, ByVal namasp As String, Optional filterby As String = "", Optional outputid As String = "", Optional TanpaSP As Boolean = False) As Boolean
        Dim sqlComm As New SqlCommand()
        Dim strConn As String = My.Settings.ConnStr
        Try
            'If cn.State = ConnectionState.Closed Then cn.Open()
            Dim sqlCon = New SqlConnection(strConn)

            Using (sqlCon)
                sqlCon.Open()
                '=====================BEGIN=====================
                If Not TanpaSP Then
                    '====================DENGAN SP==================================
                    sqlComm = New SqlCommand(namasp, sqlCon)
                    sqlComm.CommandType = CommandType.StoredProcedure
                    For Each ctrl As Control In root.Controls
                        If ctrl.Tag <> "" Or ctrl.Tag <> Nothing Then
                            If TypeOf ctrl Is TextBox And (ctrl.Name = txtid.Name) Then sqlComm.Parameters.AddWithValue("@" & ctrl.Tag, CInt(IIf(ctrl.Text = "", 0, ctrl.Text)))
                            If (TypeOf ctrl Is TextBox Or (TypeOf ctrl Is DateTimePicker)) And (ctrl.Name <> txtid.Name) Then sqlComm.Parameters.AddWithValue("@" & ctrl.Tag, ctrl.Text)
                            'If (TypeOf ctrl Is DateTimePicker) Then sqlComm.Parameters.AddWithValue("@" & ctrl.Tag, CDate(ctrl.Text))
                            If TypeOf ctrl Is ComboBox Then sqlComm.Parameters.AddWithValue("@" & ctrl.Tag, CType(ctrl, ComboBox).SelectedValue)
                            If TypeOf ctrl Is CheckBox Then sqlComm.Parameters.AddWithValue("@" & ctrl.Tag, CType(ctrl, CheckBox).Checked)
                            'Debug.Print(ctrl.Tag)
                        Else
                        End If
                    Next ctrl
                    sqlComm.Parameters.AddWithValue("@action", action)
                    sqlComm.Parameters.AddWithValue(outputid, SqlDbType.Int) 'If action = "select" Then sqlComm.Parameters.AddWithValue(outputid, 0) Else sqlComm.Parameters.AddWithValue(outputid, SqlDbType.Int)
                    sqlComm.Parameters.AddWithValue("@created", (Format(Date.Now(), "MM/dd/yyyy hh:mm:ss tt"))) : sqlComm.Parameters.AddWithValue("@createdby", My.Settings.UserName)
                    sqlComm.Parameters.AddWithValue("@modified", (Format(Date.Now(), "MM/dd/yyyy hh:mm:ss tt"))) : sqlComm.Parameters.AddWithValue("@modifiedby", My.Settings.UserName)
                    Dim paramoutput As SqlParameter = sqlComm.Parameters(outputid)
                    If action = "insert" Then
                        paramoutput.Direction = ParameterDirection.Output
                        'Dim prm17 As SqlParameter = cmd.Parameters.Add("@so_id", SqlDbType.Int)

                        'If m_SOId = 0 Then
                        '    prm17.Direction = ParameterDirection.Output
                        sqlComm.ExecuteNonQuery()
                        txtid.Text = System.Convert.ToInt32(sqlComm.Parameters(outputid).Value) 'sqlComm.Parameters(outputid).SqlValue.ToString
                    ElseIf action = "update" Then
                        sqlComm.ExecuteNonQuery()
                    ElseIf action = "select" Then
                        Dim sqlReader As SqlDataReader = sqlComm.ExecuteReader()
                        If sqlReader.HasRows Then
                            While (sqlReader.Read())
                                For Each ctrl As Control In root.Controls
                                    If ctrl.Tag <> "" Or ctrl.Tag <> Nothing Then
                                        If Microsoft.VisualBasic.Right(ctrl.Tag, 3) = "val" Then
                                            ctrl.Text = IIf(sqlReader.Item(ctrl.Tag).ToString = Decimal.Ceiling(sqlReader.Item(ctrl.Tag).ToString), Decimal.ToInt32(sqlReader.Item(ctrl.Tag).ToString).ToString(), sqlReader.Item(ctrl.Tag).ToString)
                                        Else 'kalo outputnya ga ada field ybs, maka gagal
                                            If TypeOf ctrl Is TextBox Or TypeOf ctrl Is DateTimePicker Then ctrl.Text = IIf(sqlReader.Item(ctrl.Tag).ToString = "False", "0", IIf(sqlReader.Item(ctrl.Tag).ToString = "True", "1", sqlReader.Item(ctrl.Tag).ToString))
                                            If TypeOf ctrl Is ComboBox Then CType(ctrl, ComboBox).SelectedValue = sqlReader.Item(ctrl.Tag).ToString
                                            If TypeOf ctrl Is CheckBox Then CType(ctrl, CheckBox).Checked = CBool(sqlReader.Item(ctrl.Tag).ToString)
                                        End If
                                    Else
                                    End If
                                Next ctrl
                            End While
                        End If
                        sqlReader.Close()
                    Else
                        'delete
                        sqlComm.ExecuteNonQuery()
                    End If
                Else
                    '=========================TANPA SP=============================

                    Dim strsql1 As String = IIf(action.Substring(0, action.Length - 3) = "ins", "(created, createdby, modified, modifiedby", ""), strsql2 As String = IIf(action.Substring(0, action.Length - 3) = "ins", "('" & Format(Date.Now(), "MM/dd/yyyy hh:mm:ss tt") & "', '" & My.Settings.UserName & "', '" & Format(Date.Now(), "MM/dd/yyyy hh:mm:ss tt") & "', '" & My.Settings.UserName & "','", "modified='" & Format(Date.Now(), "MM/dd/yyyy hh:mm:ss tt") & "', modifiedby='" & My.Settings.UserName & "'")
                    For Each ctrl As Control In root.Controls
                        If ctrl.Tag <> "" Or ctrl.Tag <> Nothing Then
                            If action.Substring(0, action.Length - 3) = "ins" Then
                                If TypeOf ctrl Is TextBox And (ctrl.Name = txtid.Name) Then strsql1 = strsql1 & ctrl.Tag & ", " : strsql2 = strsql2 & CInt(ctrl.Text) & "', '"
                                If (TypeOf ctrl Is TextBox Or TypeOf ctrl Is DateTimePicker) And (ctrl.Name <> txtid.Name) Then strsql1 = strsql1 & ctrl.Tag & ", " : strsql2 = strsql2 & ctrl.Text & "', '"
                                If TypeOf ctrl Is ComboBox Then strsql1 = strsql1 & ctrl.Tag & ", " : strsql2 = strsql2 & CType(ctrl, ComboBox).SelectedValue & "', '"
                                If TypeOf ctrl Is CheckBox Then strsql1 = strsql1 & ctrl.Tag & ", " : strsql2 = strsql2 & CType(ctrl, CheckBox).Checked & "', '"
                            ElseIf action.Substring(0, action.Length - 3) = "upd" Then
                                If TypeOf ctrl Is TextBox And (ctrl.Name = txtid.Name) Then strsql2 = strsql2 & ctrl.Tag & "='" & CInt(ctrl.Text) & "', "
                                If (TypeOf ctrl Is TextBox Or TypeOf ctrl Is DateTimePicker) And (ctrl.Name <> txtid.Name) Then strsql1 = strsql1 & ctrl.Tag & "='" & ctrl.Text & "', "
                                If TypeOf ctrl Is ComboBox Then strsql1 = strsql1 & ctrl.Tag & "='" & CType(ctrl, ComboBox).SelectedValue & "', "
                                If TypeOf ctrl Is CheckBox Then strsql1 = strsql1 & ctrl.Tag & "='" & CType(ctrl, CheckBox).Checked & "', "
                            ElseIf action.Substring(0, action.Length - 3) = "sel" Then
                                If TypeOf ctrl Is TextBox And (ctrl.Name = txtid.Name) Then strsql2 = strsql2 & ctrl.Tag & ", "
                                If (TypeOf ctrl Is TextBox Or TypeOf ctrl Is DateTimePicker) And (ctrl.Name <> txtid.Name) Then strsql1 = strsql1 & ctrl.Tag & ", "
                                If TypeOf ctrl Is ComboBox Then strsql1 = strsql1 & ctrl.Tag & ", "
                                If TypeOf ctrl Is CheckBox Then strsql1 = strsql1 & ctrl.Tag & ", "
                            ElseIf action.Substring(0, action.Length - 3) = "del" Then
                                If TypeOf ctrl Is TextBox And (ctrl.Name = txtid.Name) Then strsql2 = strsql2 & ctrl.Tag & "='" & CInt(ctrl.Text) & "', "
                                If (TypeOf ctrl Is TextBox Or TypeOf ctrl Is DateTimePicker) And (ctrl.Name <> txtid.Name) Then strsql1 = strsql1 & ctrl.Tag & "='" & ctrl.Text & "', "
                                If TypeOf ctrl Is ComboBox Then strsql1 = strsql1 & ctrl.Tag & "='" & CType(ctrl, ComboBox).SelectedValue & "', "
                                If TypeOf ctrl Is CheckBox Then strsql1 = strsql1 & ctrl.Tag & "='" & CType(ctrl, CheckBox).Checked & "', "
                            End If
                        Else
                        End If
                    Next ctrl
                    If action = "insert" Then
                        strsql1 = strsql1.Substring(0, strsql1.Length - 2) & ")"
                        strsql2 = strsql2.Substring(0, strsql2.Length - 3) & ")"
                        Dim strsqlexec As String = action & " into " & namasp & " " & strsql1 & " values " & strsql2
                        sqlComm = New SqlCommand(strsqlexec, sqlCon)
                        sqlComm.ExecuteNonQuery()
                        sqlComm.Dispose()
                        txtid.Text = GetCurrentID(outputid, namasp, filterby)
                    ElseIf action = "update" Then
                        strsql1 = strsql1.Substring(0, strsql1.Length - 2)
                        Dim strsqlexec As String = action & " " & namasp & " set " & strsql1 & " where " & filterby
                        sqlComm = New SqlCommand(strsqlexec, sqlCon)
                        sqlComm.ExecuteNonQuery()
                        sqlComm.Dispose()
                    ElseIf action = "select" Then
                        Dim strsqlexec As String = action & " * from " & namasp & " where " & filterby
                        sqlComm = New SqlCommand(strsqlexec, sqlCon)
                        Dim sqlReader As SqlDataReader = sqlComm.ExecuteReader()
                        If sqlReader.HasRows Then
                            While (sqlReader.Read())
                                For Each ctrl As Control In root.Controls
                                    If ctrl.Tag <> "" Or ctrl.Tag <> Nothing Then
                                        If Microsoft.VisualBasic.Right(ctrl.Tag, 3) = "val" Then
                                            ctrl.Text = IIf(sqlReader.Item(ctrl.Tag).ToString = Decimal.Ceiling(sqlReader.Item(ctrl.Tag).ToString), Decimal.ToInt32(sqlReader.Item(ctrl.Tag).ToString).ToString(), sqlReader.Item(ctrl.Tag).ToString)
                                        Else 'kalo outputnya ga ada field ybs, maka gagal
                                            If TypeOf ctrl Is TextBox Or TypeOf ctrl Is DateTimePicker Then ctrl.Text = IIf(sqlReader.Item(ctrl.Tag).ToString = "False", "0", IIf(sqlReader.Item(ctrl.Tag).ToString = "True", "1", sqlReader.Item(ctrl.Tag).ToString))
                                            If TypeOf ctrl Is ComboBox Then CType(ctrl, ComboBox).SelectedValue = sqlReader.Item(ctrl.Tag).ToString
                                            If TypeOf ctrl Is CheckBox Then CType(ctrl, CheckBox).Checked = CBool(sqlReader.Item(ctrl.Tag).ToString)
                                        End If
                                    Else
                                    End If
                                Next ctrl
                            End While
                        End If
                        sqlReader.Close()
                    Else
                        'delete
                        'sqlComm.ExecuteNonQuery()
                    End If
                End If
                
                '=====================END=====================
                sqlCon.Close()
            End Using
            Fillobject = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "-")
            Fillobject = False
            Exit Function
        End Try
    End Function
    Public Function FillSysInit(ByVal task As Boolean, ByVal root As Control, ByVal namasp As String) As Boolean
        Dim sqlComm As New SqlCommand()
        Dim strConn As String = My.Settings.ConnStr
        Try
            Dim sqlCon = New SqlConnection(strConn)
            Using (sqlCon)
                sqlCon.Open()
                '=====================BEGIN=====================
                For Each ctrl As Control In root.Controls
                    If ctrl.Tag <> "" Or ctrl.Tag <> Nothing Then
                        Dim nilai As String
                            'cek dulu ada ga object yg dimaksud
                            Dim strsqlexec As String = "select * from " & namasp & " where sys_init_id='" & ctrl.Tag & "'"
                            sqlComm = New SqlCommand(strsqlexec, sqlCon)
                            Dim sqlReader As SqlDataReader = sqlComm.ExecuteReader()
                        If sqlReader.Read Then
                            If task Then 'select
                                If Microsoft.VisualBasic.Right(ctrl.Tag, 3) = "val" Then
                                    ctrl.Text = IIf(sqlReader.Item(2).ToString = Decimal.Ceiling(sqlReader.Item(2).ToString), Decimal.ToInt32(sqlReader.Item(2).ToString).ToString(), sqlReader.Item(2).ToString)
                                Else 'kalo outputnya ga ada field ybs, maka gagal
                                    If TypeOf ctrl Is TextBox Or TypeOf ctrl Is DateTimePicker Then ctrl.Text = IIf(sqlReader.Item(2).ToString = "False", "0", IIf(sqlReader.Item(2).ToString = "True", "1", sqlReader.Item(2).ToString))
                                    If TypeOf ctrl Is ComboBox Then CType(ctrl, ComboBox).SelectedValue = sqlReader.Item(2).ToString 'sqlReader.Item("sys_init_val").ToString
                                    If TypeOf ctrl Is CheckBox Then CType(ctrl, CheckBox).Checked = getvalcheck(sqlReader.Item(2).ToString)
                                End If
                            Else 'update
                                If TypeOf ctrl Is TextBox Or TypeOf ctrl Is DateTimePicker Then nilai = ctrl.Text '= IIf(sqlReader.Item(ctrl.Tag).ToString = "False", "0", IIf(sqlReader.Item(ctrl.Tag).ToString = "True", "1", sqlReader.Item(ctrl.Tag).ToString))
                                If TypeOf ctrl Is ComboBox Then nilai = CType(ctrl, ComboBox).SelectedValue ' = sqlReader.Item(ctrl.Tag).ToString
                                If TypeOf ctrl Is CheckBox Then nilai = CType(ctrl, CheckBox).Checked '= CBool(sqlReader.Item(ctrl.Tag).ToString)
                                Executestr("update sys_init SET modified='" & Format(Date.Now(), "MM/dd/yyyy hh:mm:ss tt") & "',modifiedby='" & My.Settings.UserName & "',sys_init_val='" & nilai & "' WHERE sys_init_id='" & ctrl.Tag & "'") ' values ('" & Format(Date.Now(), "MM/dd/yyyy hh:mm:ss tt") & "', '" & My.Settings.UserName & "', '" & Format(Date.Now(), "MM/dd/yyyy hh:mm:ss tt") & "', '" & My.Settings.UserName & "','" & ctrl.Tag & "','" & ctrl.Tag & "','" & nilai & "')")
                            End If
                        Else
                            'insert to table
                            If TypeOf ctrl Is TextBox Or TypeOf ctrl Is DateTimePicker Then nilai = ctrl.Text '= IIf(sqlReader.Item(ctrl.Tag).ToString = "False", "0", IIf(sqlReader.Item(ctrl.Tag).ToString = "True", "1", sqlReader.Item(ctrl.Tag).ToString))
                            If TypeOf ctrl Is ComboBox Then nilai = CType(ctrl, ComboBox).SelectedValue ' = sqlReader.Item(ctrl.Tag).ToString
                            If TypeOf ctrl Is CheckBox Then nilai = CType(ctrl, CheckBox).Checked '= CBool(sqlReader.Item(ctrl.Tag).ToString)
                            Executestr("insert into sys_init(created,createdby,modified,modifiedby,sys_init_id, sys_init_desc, sys_init_val) values ('" & Format(Date.Now(), "MM/dd/yyyy hh:mm:ss tt") & "', '" & My.Settings.UserName & "', '" & Format(Date.Now(), "MM/dd/yyyy hh:mm:ss tt") & "', '" & My.Settings.UserName & "','" & ctrl.Tag & "','" & ctrl.Tag & "','" & nilai & "')")
                            If task Then 'select
                                If Microsoft.VisualBasic.Right(ctrl.Tag, 3) = "val" Then
                                    ctrl.Text = IIf(sqlReader.Item(ctrl.Tag).ToString = Decimal.Ceiling(sqlReader.Item(ctrl.Tag).ToString), Decimal.ToInt32(sqlReader.Item(ctrl.Tag).ToString).ToString(), sqlReader.Item(ctrl.Tag).ToString)
                                Else 'kalo outputnya ga ada field ybs, maka gagal
                                    If TypeOf ctrl Is TextBox Or TypeOf ctrl Is DateTimePicker Then ctrl.Text = IIf(sqlReader.Item(2).ToString = "False", "0", IIf(sqlReader.Item(2).ToString = "True", "1", sqlReader.Item(2).ToString))
                                    If TypeOf ctrl Is ComboBox Then CType(ctrl, ComboBox).SelectedValue = sqlReader.Item(2).ToString 'sqlReader.Item("sys_init_val").ToString
                                    If TypeOf ctrl Is CheckBox Then CType(ctrl, CheckBox).Checked = getvalcheck(sqlReader.Item(2).ToString)
                                End If
                            End If
                        End If
                            sqlComm.Dispose() : sqlReader.Close()
                    End If
                Next ctrl
                '=====================END=====================
                sqlCon.Close()
            End Using
            FillSysInit = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "-")
            FillSysInit = False
            Exit Function
        End Try
    End Function
    Public Function AssignValuetoCombo(ByVal namacombo As ComboBox, strunion As String, fieldkey As String, fieldteks As String, namatabel As String, kondisi As String, sortby As String, Optional defaultval As String = "")
        On Error Resume Next
        '==========================================Fill Combo Template=========================================
        Dim DA As New SqlDataAdapter(strunion & "select " & fieldkey & " as guidstr, " & fieldteks & " as nama from " & namatabel & " where " & kondisi & " order by " & sortby, cn)
        Dim DS As New DataSet

        DA.Fill(DS, "event")

        Dim dt As New DataTable
        dt.Columns.Add("nama", GetType(System.String))
        dt.Columns.Add("guidstr", GetType(System.String))
        '
        ' Populate the DataTable to bind to the Combobox.
        '
        Dim drDSRow As DataRow
        Dim drNewRow As DataRow

        For Each drDSRow In DS.Tables("event").Rows()
            drNewRow = dt.NewRow()
            drNewRow("nama") = UCase(drDSRow("nama"))
            drNewRow("guidstr") = drDSRow("guidstr")
            dt.Rows.Add(drNewRow)
        Next

        namacombo.DropDownStyle = ComboBoxStyle.DropDownList
        With namacombo
            .DataSource = dt
            .DisplayMember = "nama"
            .ValueMember = "guidstr"
            .SelectedIndex = 0
        End With
        namacombo.SelectedValue = defaultval

        DA.Dispose()
        DS.Dispose()
        '==========================================END Fill combo Combo1=========================================
    End Function
    Public Function GetInit(ByVal initName As String, ByVal System As Boolean) As String
        On Error Resume Next
        Dim cmd As SqlCommand
        Dim dr As SqlDataReader

        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If

        cmd = New SqlCommand("select sys_dropdown_val from sys_dropdown where sys_dropdown_whr='" & initName & "'", cn)
        dr = cmd.ExecuteReader()

        If dr.Read() Then

            GetInit = IIf(IsDBNull(dr.Item("sys_dropdown_val").ToString()), "#", dr.Item("sys_dropdown_val").ToString())

        End If

        dr.Close()
        cmd.Dispose()
    End Function
    Public Function ClearObjectonForm(ByVal root As Control)
        On Error Resume Next
        Dim ctrlstr As String = ""
        For Each ctrl As Control In root.Controls
            If TypeOf ctrl Is TextBox Or (TypeOf ctrl Is ComboBox) Then ctrlstr &= "," & ctrl.Name
            ClearObjectonForm(ctrl)
            If TypeOf ctrl Is TextBox Then
                CType(ctrl, TextBox).Text = String.Empty
            End If
            If TypeOf ctrl Is DateTimePicker Then
                CType(ctrl, DateTimePicker).Format = DateTimePickerFormat.Custom : CType(ctrl, DateTimePicker).CustomFormat = "yyyy-MM-dd" : CType(ctrl, DateTimePicker).Text = Now.Date
            End If
        Next ctrl
    End Function
    Public Function ClearCheckBoxonForm(ByVal root As Control)
        On Error Resume Next
        For Each ctrl As Control In root.Controls
            ClearCheckBoxonForm(ctrl)
            If TypeOf ctrl Is CheckBox Then
                CType(ctrl, CheckBox).Checked = False
                CType(ctrl, CheckBox).Text = ""
            End If
        Next ctrl
    End Function
    Public Function MarqueeLeft(ByVal Text As String)
        Dim Str1 As String = Text.Remove(0, 1)
        Dim Str2 As String = Text(0)
        Return Str1 & Str2
    End Function
    Public Function InsertLogFile(ByVal namaevent As String, ByVal ketlogfile As String, ByVal namahost As String, ByVal namamodul As String, ByVal curuserlogin As String)
        On Error Resume Next
        If cn.State = Data.ConnectionState.Closed Then
            cn.Open()
        End If
        Dim strsql As String = "sp_ins_LOG '" & ketlogfile & "','" & namahost & "','" & curuserlogin & "','" & Format(Date.Now(), "MM/dd/yyyy hh:mm:ss tt") & "','" & namamodul & "','" & namaevent & "'"
        Dim cmd As New SqlCommand(strsql, cn)
        cmd.ExecuteNonQuery()
        cmd.Dispose()
        cmd = Nothing
        'con.Close()itu yg baru
    End Function
    Public Function autocompleteteks(ByVal namatextbox As TextBox, ByVal outputfield As String, ByVal namatable As String, ByVal kondisi As String, ByVal urutkan As String) As String
        On Error Resume Next
        Dim cmd As SqlCommand
        Dim str(10) As String, strsql As String
        Dim itm As ListViewItem
        Dim dr As SqlDataReader
        'If Len(namatextbox) > 1 Then Exit Function
        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If
        strsql = "SELECT " & outputfield & " FROM " & namatable & " where " & kondisi & " order by " & urutkan
        cmd = New SqlCommand(strsql, cn)
        dr = cmd.ExecuteReader()
        If dr.HasRows Then
            Do While dr.Read()
                str(0) = IIf(IsDBNull(dr.Item(0).ToString()), "#", dr.Item(0).ToString())
                namatextbox.AutoCompleteCustomSource.Add(str(0))
            Loop
        End If
        'autocompleteteks = str(0)
        dr.Close()
        cmd.Dispose()
    End Function
    Public Function getfiledate(lokasi As String) As DateTime
        Dim fileName As String = lokasi
        If File.Exists(fileName) Then
            getfiledate = File.GetLastWriteTime(fileName).ToString
        End If
    End Function
    Public Function CountRecordnya(ByVal namafield As String, ByVal Namatable As String, ByVal kondisi As String, ByVal strwhrlangsung As Boolean) As Integer
        On Error Resume Next
        Dim cmd As SqlCommand
        Dim dr As SqlDataReader

        If cn.State = ConnectionState.Closed Then cn.Open()
        CountRecordnya = 0
        cmd = New SqlCommand("Select " & namafield & " from " & Namatable & " where " & kondisi, cn)
        dr = cmd.ExecuteReader()
        If dr.HasRows() Then
            While dr.Read
                CountRecordnya = CountRecordnya + 1
            End While
        Else
            CountRecordnya = 0
        End If
        dr.Close()
        cmd.Dispose()
        Exit Function
    End Function
    Public Function loopthroughlistview(ByVal namalistview As ListView, ByVal kolom As Integer, Optional strskip As String = "", Optional penjumlahan As Boolean = False) As String
        On Error Resume Next
        Dim jmlsementara As Decimal
        For a As Integer = 0 To namalistview.Items.Count - 1
            If penjumlahan Then
                jmlsementara = jmlsementara + CDec(namalistview.Items(a).SubItems(kolom).Text)
            Else
                If strskip <> namalistview.Items(a).SubItems(kolom).Text Then loopthroughlistview = loopthroughlistview + namalistview.Items(a).SubItems(kolom).Text + "," Else loopthroughlistview = loopthroughlistview + "0,"
            End If
        Next
        If loopthroughlistview = Nothing And penjumlahan = False Then Exit Function
        If penjumlahan Then
            loopthroughlistview = jmlsementara
        Else
            loopthroughlistview = loopthroughlistview.Substring(0, loopthroughlistview.Length - 1)
        End If
    End Function
End Module

