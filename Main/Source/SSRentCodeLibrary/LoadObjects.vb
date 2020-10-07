Public Class LoadObjects
    Private mlngSystemObjectID As Long
    Private mlngRecordID As Long
    Private mlngUserID As Long
    Private mstrConnectString As String
    Private blnFormatConnectStringToADODB As Boolean

    Public Property ADODBConnectString() As String
        Get
            ADODBConnectString = mstrConnectString
        End Get
        Set(ByVal Value As String)
            If blnFormatConnectStringToADODB = True Then
                mstrConnectString = FormatMSAccessADPConnectToADODBConnect(Value)
            Else
                mstrConnectString = Value
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

    Public Property SystemObjectID() As Long
        Get
            SystemObjectID = mlngSystemObjectID
        End Get
        Set(ByVal Value As Long)
            mlngSystemObjectID = Value
        End Set
    End Property

    Public Property RecordID() As Long
        Get
            RecordID = mlngRecordID
        End Get
        Set(ByVal Value As Long)
            mlngRecordID = Value
        End Set
    End Property

    Public Property UserID() As Long
        Get
            UserID = mlngUserID
        End Get
        Set(ByVal Value As Long)
            mlngUserID = Value
        End Set
    End Property

    Public Sub LoadLinkedFileManager()
        Try
            If mstrConnectString = "" Then
                MsgBox("ADODB connect string not initialized.  Contact system administrator for more information.", MsgBoxStyle.Information, "Insufficient Information")
                Exit Try
            End If

            If mlngSystemObjectID = 0 Then
                MsgBox("System Object ID was not assigned.  Contact system administrator for more information.", MsgBoxStyle.Information, "Insufficient Information")
                Exit Try
            End If

            If mlngRecordID = 0 Then
                MsgBox("Record ID was not assigned.  Contact system administrator for more information.", MsgBoxStyle.Information, "Insufficient Information")
                Exit Try
            End If

            If mlngUserID = 0 Then
                MsgBox("User ID was not assigned.  Contact system administrator for more information.", MsgBoxStyle.Information, "Insufficient Information")
                Exit Try
            End If

            Dim frmLFM As New frmLinkedFileManager

            With frmLFM
                .ADODBConnectString = mstrConnectString
                .SystemObjectID = mlngSystemObjectID
                .RecordID = mlngRecordID
                .UserID = mlngUserID
                .ShowDialog()
            End With

        Catch ex As Exception
            MsgBox("Error loading linked file manager. " & vbCrLf & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Public Sub LoadVPFinAccess(ByVal UserID As Long)
        Dim obj As New SSRentCodeLibrary.VPFinancialDocs

        With obj
            .UserID = UserID
            .ShowDialog()
        End With

        obj = Nothing
    End Sub
End Class
