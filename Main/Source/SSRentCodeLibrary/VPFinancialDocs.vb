Imports System.Data.SqlClient
Imports System.IO
Imports System.Data.OleDb


Public Class VPFinancialDocs
    Private strConnectString As String = My.Settings.SSIRentConnectionString.ToString
    Private mlngUserID As Long
    

    Private mlngSystemObjectID As Long
    Private mlngRecordID As Long

    Public Property UserID() As Long
        Get
            UserID = mlngUserID
        End Get
        Set(ByVal Value As Long)
            mlngUserID = Value
        End Set
    End Property
    Private Sub VPFinancialDocs_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim cn As New SqlConnection(strConnectString)
        Dim cmd As New SqlCommand("sp_Sys_Objects_VPFinancialDocs " & mlngUserID, cn)


        Try
            cn.Open()
            Dim path As String = cmd.ExecuteScalar
            cn.Close()
            cn.Dispose()

            OpenFileDialog1.InitialDirectory = path
            If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
                Me.Close()
            End If




        Catch ex As Exception
            MsgBox("An error occurred while retreiving the path. You may not be authorized." & vbCrLf & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Error")
        Finally
            cmd = Nothing
            cn.Close()
            cn = Nothing
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try

       
    End Sub

    Private Sub OpenFileDialog1_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles OpenFileDialog1.Disposed
        MsgBox("dispose")
    End Sub
    
    Private Sub OpenFileDialog1_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk

        Try
            System.Diagnostics.Process.Start(OpenFileDialog1.FileName)
            LogFinFolderAccess(OpenFileDialog1.FileName, UserID, DateTime.Now())
        Catch ex As Exception
            MsgBox("Error Logging: " & ex.Message)
        End Try
        Me.Close()
    End Sub

    Public Sub LogFinFolderAccess(ByVal FileName As String, ByVal UserId As Integer, ByVal TimeOpen As DateTime)
        Dim cn As New SqlConnection(strConnectString)
        Dim cmd As New SqlCommand("sp_Sys_LogVPFinFolderAccess", cn)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@FileName", FileName)
        cmd.Parameters.AddWithValue("@UserID", UserId)
        cmd.Parameters.AddWithValue("@TimeOpen", TimeOpen)
        Try
            cn.Open()
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox("Error Logging: " & ex.Message)
        Finally
            cn.Close()
            cn.Dispose()
        End Try

    End Sub
End Class