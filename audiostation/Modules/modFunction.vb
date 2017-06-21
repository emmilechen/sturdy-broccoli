Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System
Imports System.Security.Cryptography
Imports System.Text
Imports System.Net.NetworkInformation
Imports System.Reflection

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

        cn.Open()
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
        Dim prm2 As SqlParameter = cmd.Parameters.Add("@form_name", SqlDbType.NVarChar, 50)
        prm2.Value = FormName

        cn.Open()
        Dim myReader As SqlDataReader = cmd.ExecuteReader()
        While myReader.Read()
            GetPermission = myReader.GetBoolean(3)
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

            cn.Open()
            Dim myReader As SqlDataReader = cmd.ExecuteReader()
            While myReader.Read
                formDelete = myReader.GetBoolean(4)
            End While
            myReader.Close()
            cn.Close()
            If formDelete = True Then
                Return True
            Else
                Return False
            End If
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

        cn.Open()

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

        cn.Open()
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

            cn.Open()
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

        cn.Open()
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
                GETGeneralcode = kodetrx & Format(requestcode, "yyMM") & Right("0000" & Right(dr.Item("LastBatch").ToString, panjangangka) + 1, panjangangka)
            Else
                GETGeneralcode = kodetrx & Format(requestcode, "yyMM") & "0001"
            End If
            dr.Close()
            cmd.Dispose()
        End If
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
End Module

