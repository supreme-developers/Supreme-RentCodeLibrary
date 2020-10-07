Module modStringFunctions
    Public Function FormatMSAccessADPConnectToADODBConnect(ByVal strConnectString As String) As String
        Dim strADODBConnect As String, strTemp As String
        Dim lngPlaceHolder As Integer

        strADODBConnect = strConnectString

        'string coming in from Access ADP Project
        '   -- find out if using SQL or Windows authentication 
        '       -- Windows if contains <Integrated Security=SSPI>
        '       -- If SQL Authentication and password = "", replace "" with nothing
        '   -- Remove <Provider=Microsoft...;>
        '   -- Remove <Data Provider=Data Provider=...;>

        Try
            If InStr(strADODBConnect, "Integrated Security=SSPI", CompareMethod.Text) = 0 Then
                'sql authentication. 
                strADODBConnect = Replace(strADODBConnect, "Password=""""", "Password=")
            End If

            lngPlaceHolder = InStr(InStr(strADODBConnect, "Provider=Microsoft"), strADODBConnect, ";")

            If lngPlaceHolder = 0 Then
                strADODBConnect = Replace(strADODBConnect, Mid(strADODBConnect, InStr(strADODBConnect, "Provider=Microsoft"), Len(strADODBConnect)), "")
            Else
                strADODBConnect = Replace(strADODBConnect, Mid(strADODBConnect, InStr(strADODBConnect, "Provider=Microsoft"), lngPlaceHolder), "")
            End If

            lngPlaceHolder = InStr(InStr(strADODBConnect, "Data Provider="), strADODBConnect, ";")

            If lngPlaceHolder = 0 Then
                strADODBConnect = Replace(strADODBConnect, Mid(strADODBConnect, InStr(strADODBConnect, "Data Provider="), Len(strADODBConnect)), "")
            Else
                strADODBConnect = Replace(strADODBConnect, Mid(strADODBConnect, InStr(strADODBConnect, "Data Provider="), lngPlaceHolder), "")
            End If

            Return strADODBConnect
        Catch ex As Exception
            MsgBox("Error formatting MS Access ADP Project connection string to ADODB connect string." & vbCrLf & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Function
End Module
