Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class SQLServerFunctions

    Private strConnectString As String
    Private blnFormatConnectStringToADODB As Boolean

    Public Property ADODBConnectString() As String
        Get
            ADODBConnectString = strConnectString
        End Get
        Set(ByVal Value As String)
            If blnFormatConnectStringToADODB = True Then
                strConnectString = FormatMSAccessADPConnectToADODBConnect(Value)
            Else
                strConnectString = Value
            End If
        End Set
    End Property

    Public Property FormatConnectStringToADODB() As Boolean
        Get
            FormatConnectStringToADODB = blnFormatConnectStringToADODB
        End Get
        Set(ByVal Value As Boolean)
            blnFormatConnectStringToADODB = Value
        End Set
    End Property

    Public Function GetNextControlNumber(ByVal lngOfficeID As Long, ByVal strFieldName As String) As String
        Dim lngNextNum As String
        Dim cn As New SqlClient.SqlConnection(strConnectString)
        Dim cmd As New SqlCommand("sp_Sys_GetNextControlNumber " & lngOfficeID & ", '" & strFieldName & "'", cn)

        Try
            cn.Open()
            Dim rdr As SqlDataReader = cmd.ExecuteReader

            Do While rdr.Read
                lngNextNum = rdr.GetSqlString(0).Value
            Loop

            rdr.Close()
            rdr = Nothing

            Return lngNextNum

        Catch e As Exception
            MsgBox("Error getting next control number." & vbCrLf & vbCrLf & e.Message, MsgBoxStyle.Critical, "Error")
        Finally
            cmd = Nothing
            cn.Close()
            cn = Nothing
        End Try
    End Function

    Public Sub SaveUserSetting(ByVal UserID As Long, ByVal Setting As String, ByVal SettingValue As String)
        Dim cn As New SqlClient.SqlConnection(strConnectString)
        Dim cmd As New SqlClient.SqlCommand("sp_Sys_SaveUserSetting " & UserID & ", '" & Setting & "', '" & SettingValue & "'", cn)

        Try
            cn.Open()
            cmd.ExecuteNonQuery()


        Catch ex As Exception
            Err.Raise(Err.Number, , "Error saving user setting in code library." & vbCrLf & vbCrLf & ex.Message)
        Finally
            cmd = Nothing
            cn.Close()
            cn = Nothing
        End Try
    End Sub

    Public Function GetUserSetting(ByVal UserID As Long, ByVal Setting As String) As String
        Dim cn As New SqlClient.SqlConnection(strConnectString)
        Dim cmd As New SqlClient.SqlCommand("sp_SYS_GetUserSetting " & UserID & ", '" & Setting & "'", cn)
        Dim strSettingValue As String

        Try
            cn.Open()
            Dim rdr As SqlClient.SqlDataReader = cmd.ExecuteReader

            Do While rdr.Read
                strSettingValue = rdr.GetString(0).ToString
            Loop

            rdr.Close()
            rdr = Nothing

            If strSettingValue Is Nothing Then strSettingValue = ""

            Return CStr(strSettingValue)
        Catch ex As Exception
            Err.Raise(Err.Number, , "Error getting user setting in code library. " & vbCrLf & vbCrLf & ex.Message)
        Finally
            cmd = Nothing
            cn.Close()
            cn = Nothing
        End Try
    End Function

    Public Sub RunDTSPackage(ByVal ServerName As String, ByVal PackageName As String)
        Try
            Shell("dtsrun /S" & ServerName & " /E /N" & PackageName)
        Catch ex As Exception
            MsgBox("Error executing DTS Package specified." & vbCrLf & vbCrLf & "Error Number: " & Err.Number & vbCrLf & "Error Description: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
End Class


