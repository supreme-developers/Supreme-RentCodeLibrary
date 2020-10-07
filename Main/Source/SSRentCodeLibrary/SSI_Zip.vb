Imports System.IO
Imports System.IO.Compression
Imports System.Windows.Forms



Public Class SSI_Zip

    Public Sub ZipProcess(startPath As String, zipPath As String)
        ' string extractPath = @"d:\Test\extract";
        Dim file As New FileInfo(zipPath)
        ' Dim deleteMe As New FileInfo(startPath)

        If file.Exists Then
            file.Delete()
        End If
        Try
            ZipFile.CreateFromDirectory(startPath, zipPath, CompressionLevel.Fastest, False)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        'deleteMe.Delete()




    End Sub

End Class
