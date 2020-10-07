Public Class SSCalendarInterface

    Private strConnectionString As String
    Private strCalendarSQLStatement As String
    Private strDateFieldName As String
    Private strTimeFieldName As String
    Private strCalendarDescriptionFieldName As String
    Private strOrderOnFieldName As String
    Private strPrimaryKeyFieldName As String
    Private strColorCodeBCFieldName As String
    Private strColorCodeFCFieldName As String
    Private lngSystemObjectID As Long

    Public Property ConnectionString() As String
        Get
            Return strConnectionString
        End Get
        Set(ByVal value As String)
            strConnectionString = value
        End Set
    End Property

    Public Property CalendarSQLStatement() As String
        Get
            Return strCalendarSQLStatement
        End Get
        Set(ByVal value As String)
            strCalendarSQLStatement = value
        End Set
    End Property

    Public Property DateFieldName() As String
        Get
            Return strDateFieldName
        End Get
        Set(ByVal value As String)
            strDateFieldName = value
        End Set
    End Property

    Public Property TimeFieldName() As String
        Get
            Return strTimeFieldName
        End Get
        Set(ByVal value As String)
            strTimeFieldName = value
        End Set
    End Property

    Public Property OrderOnFieldName() As String
        Get
            Return strOrderOnFieldName
        End Get
        Set(ByVal value As String)
            strOrderOnFieldName = value
        End Set
    End Property

    Public Property CalendarDescriptionFieldName() As String
        Get
            Return strCalendarDescriptionFieldName
        End Get
        Set(ByVal value As String)
            strCalendarDescriptionFieldName = value
        End Set
    End Property

    Public Property PrimaryKeyFieldName() As String
        Get
            Return strPrimaryKeyFieldName
        End Get
        Set(ByVal value As String)
            strPrimaryKeyFieldName = value
        End Set
    End Property

    Public Property SystemObjectID() As Long
        Get
            Return lngSystemObjectID
        End Get
        Set(ByVal value As Long)
            lngSystemObjectID = value
        End Set
    End Property

    Public Property ColorCodeBCFieldName() As String
        Get
            Return strColorCodeBCFieldName
        End Get
        Set(ByVal value As String)
            strColorCodeBCFieldName = value
        End Set
    End Property

    Public Property ColorCodeFCFieldName() As String
        Get
            Return strColorCodeFCFieldName
        End Get
        Set(ByVal value As String)
            strColorCodeFCFieldName = value
        End Set
    End Property

    Public Sub ShowCalendar()
        Dim frm As New frmCalSchedule

        With frm
            .ConnectionString = strConnectionString
            .CalendarSQLStatement = strCalendarSQLStatement
            .CalendarDescriptionFieldName = strCalendarDescriptionFieldName
            .DateFieldName = strDateFieldName
            .TimeFieldName = strTimeFieldName
            .OrderOnFieldName = strOrderOnFieldName
            .PrimaryKeyFieldName = strPrimaryKeyFieldName
            .ColorCodeBCFieldName = strColorCodeBCFieldName
            .ColorCodeFCFieldName = strColorCodeFCFieldName
            .SystemObjectID = lngSystemObjectID
            .ShowDialog()
        End With
    End Sub

End Class
