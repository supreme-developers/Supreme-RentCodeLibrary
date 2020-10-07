Public Class frmCalSchedule
    Public ConnectionString As String
    Public CalendarSQLStatement As String
    Public DateFieldName As String
    Public TimeFieldName As String
    Public CalendarDescriptionFieldName As String
    Public OrderOnFieldName As String
    Public PrimaryKeyFieldName As String
    Public ColorCodeBCFieldName As String
    Public ColorCodeFCFieldName As String
    Public SystemObjectID As Long

    Private Sub frmCalSchedule_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim cn As New SqlClient.SqlConnection(Me.ConnectionString)

        'Dim da As SqlClient.SqlDataAdapter = New SqlClient.SqlDataAdapter("Select * From tblDelHeader Where [Delivery Ticket Number] Is Not Null", cn)
        Dim da As SqlClient.SqlDataAdapter = New SqlClient.SqlDataAdapter(Me.CalendarSQLStatement, cn)
        Dim dsSchedule As DataSet = New DataSet

        da.Fill(dsSchedule, "CalendarData")

        With SsCalendar1
            .DataSource = dsSchedule
            .TableName = "CalendarData"
            .DateMember = Me.DateFieldName
            .TimeMember = Me.TimeFieldName
            .OrderOnField = Me.OrderOnFieldName
            .TextMember = Me.CalendarDescriptionFieldName
            .PrimaryKeyFieldName = Me.PrimaryKeyFieldName
            .ColorCodeBCFieldName = Me.ColorCodeBCFieldName
            .ColorCodeFCFieldName = Me.ColorCodeFCFieldName
            .SystemObjectID = Me.SystemObjectID
            .DrawCalendar()
        End With
    End Sub

    Private Sub SsCalendar1_ShowPopup(ByVal RecordID As Long, ByVal PopupText As String) Handles SsCalendar1.ShowPopup
        Try
            Dim frm As New frmCalShedulePopup

            With frm
                .PrimaryKeyValue = RecordID
                .ConnectionString = Me.ConnectionString
                .SystemObjectID = Me.SystemObjectID
                .Text = PopupText
                .ShowDialog()
            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
End Class