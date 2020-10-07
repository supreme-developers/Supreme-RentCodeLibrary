
Public Class Form1

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim obj As New SSRentCodeLibrary.SSCalendarInterface

        With obj
            .ConnectionString = "Data Source=AGROS;Initial Catalog=Rent Test;Integrated Security=True"
            .CalendarSQLStatement = "Select * From tblDelHeader"
            .DateFieldName = "[Ship Date]"
            .TimeFieldName = "[Ship Date]"
            .OrderOnFieldName = "Delivery Ticket Number"
            .CalendarDescriptionFieldName = "Delivery Ticket Number"
            .PrimaryKeyFieldName = "Delivery Ticket ID"
            .SystemObjectID = 29
            .ShowCalendar()
        End With

        obj = Nothing
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim obj As New SSRentCodeLibrary.SSCalendarInterface

        With obj
            .ConnectionString = "Data Source=AGROS;Initial Catalog=Rent Test;Integrated Security=True"
            .CalendarSQLStatement = "Select *, 'Red' As BCColor, 'White' As FCColor From tblSYS_Scheduling"
            .DateFieldName = "[NextScheduleDate]"
            .TimeFieldName = "[NextScheduleDate]"
            .OrderOnFieldName = "NextScheduleDate"
            .CalendarDescriptionFieldName = "ShortDescription"
            .PrimaryKeyFieldName = "SchedulingID"
            .ColorCodeBCFieldName = "BCColor"
            .ColorCodeFCFieldName = "FCColor"
            .SystemObjectID = 53
            .ShowCalendar()
        End With

        obj = Nothing
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim obj As New SSRentCodeLibrary.SSCalendarInterface

        With obj
            .ConnectionString = "Data Source=AGROS;Initial Catalog=Rent Test;Integrated Security=True"
            .CalendarSQLStatement = "Select *, 'Red' As ColorTest From tblPOPurchaseOrders"
            .DateFieldName = "[PODate]"
            .TimeFieldName = "[PODate]"
            .OrderOnFieldName = "POPurchaseOrderNumber"
            .CalendarDescriptionFieldName = "POPurchaseOrderNumber"
            .PrimaryKeyFieldName = "POPurchaseOrderID"
            '.ColorFieldName = "ColorTest"
            .SystemObjectID = 1
            .ShowCalendar()
        End With

        obj = Nothing
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim obj As New SSRentCodeLibrary.VPFinancialDocs

        With obj
            .UserID = 137
            .ADODBConnectString = "Data Source=SSI-3\SSI2008;Initial Catalog=SSIRent;Integrated Security=True"
            .ShowDialog()
        End With
    End Sub
End Class
