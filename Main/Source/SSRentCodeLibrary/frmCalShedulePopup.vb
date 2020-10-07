Imports System.Data.SqlClient

Public Class frmCalShedulePopup
    Friend WithEvents lblDisplay As System.Windows.Forms.Label
    Friend WithEvents txtDisplay As System.Windows.Forms.TextBox

    Public ConnectionString As String
    Public PrimaryKeyValue As Long
    Public SystemObjectID As Long

    Private strPrimaryKeyName As String

    Private Sub frmCalShedulePopup_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        SetUpScreen()

    End Sub

    Private Sub SetUpScreen()
        Dim strStatus As String
        strStatus = ""
        Try
            Dim cn As New SqlConnection()
            Dim cmd As New SqlCommand()
            Dim schemaTable As DataTable
            Dim rdr As SqlDataReader
            Dim fld As DataRow
            Dim prp As DataColumn
            Dim intLabelX As Integer, intLabelY As Integer
            Dim intTextBoxX As Integer, intTextBoxY As Integer
            Dim i As Integer
            Dim strCommandText As String, strColumnIsHidden As String

            intLabelX = 9
            intLabelY = 8
            intTextBoxX = 150
            intTextBoxY = 6

            strStatus = "Starting function"
            Me.Opacity = 0.85

            'Open a connection to the SQL Server Northwind database.
            cn.ConnectionString = Me.ConnectionString
            cn.Open()

            strStatus = "Setting SQL"

            strCommandText = GetDisplaySQL()

            strStatus = strCommandText

            'Retrieve records from the Employees table into a DataReader.
            cmd.Connection = cn
            cmd.CommandText = strCommandText
            rdr = cmd.ExecuteReader(CommandBehavior.KeyInfo)

            strStatus = "Getting Schema"
            'Retrieve column schema into a DataTable.
            schemaTable = rdr.GetSchemaTable()

            'For each field in the table...
            For Each fld In schemaTable.Rows
                'For each property of the field...
                For Each prp In schemaTable.Columns
                    'check if the column is hidden. was running into a problem
                    'with relationships for the table. if a field in the view 
                    'is coming from a foreign table, the primary key of the foreign
                    'table is brought in with the schema.  the "IsHidden" property
                    'gets set to "True" for these fields, so disregard them
                    strStatus = "Getting Hidden Column Setting"
                    strColumnIsHidden = fld(schemaTable.Columns("IsHidden")).ToString
                    If prp.ColumnName = "ColumnName" And strColumnIsHidden = "False" And fld(prp).ToString() <> Me.strPrimaryKeyName Then

                        strStatus = "Adding Label"
                        lblDisplay = New System.Windows.Forms.Label

                        lblDisplay.AutoSize = True
                        lblDisplay.Location = New System.Drawing.Point(intLabelX, intLabelY)
                        lblDisplay.Name = "Label" & fld(prp).ToString()
                        lblDisplay.Size = New System.Drawing.Size(39, 13)
                        lblDisplay.TabIndex = 3
                        lblDisplay.Text = fld(prp).ToString()
                        lblDisplay.ForeColor = Drawing.Color.White

                        strStatus = "Adding Textbox"
                        txtDisplay = New System.Windows.Forms.TextBox

                        txtDisplay.Location = New System.Drawing.Point(intTextBoxX, intTextBoxY)
                        txtDisplay.Name = "TextBox" & fld(prp).ToString()
                        txtDisplay.BorderStyle = Windows.Forms.BorderStyle.FixedSingle
                        txtDisplay.Size = New System.Drawing.Size(275, 20)
                        'txtDisplay.Enabled = False
                        txtDisplay.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                                            Or System.Windows.Forms.AnchorStyles.Left) _
                                            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
                        'txtDisplay.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                        txtDisplay.BackColor = Drawing.Color.Khaki
                        txtDisplay.ForeColor = Drawing.Color.DarkBlue
                        txtDisplay.ReadOnly = True
                        txtDisplay.TabIndex = 4
                        txtDisplay.Tag = fld(prp).ToString()

                        Me.Controls.Add(Me.lblDisplay)
                        Me.Controls.Add(Me.txtDisplay)

                        'txtDisplay.Text = rdrValues("Schedule Number").ToString
                        ''txtDisplay.Text = rdrValues(fld(prp).ToString())

                        intLabelY += 22
                        intTextBoxY += 22
                    End If
                Next
            Next

            strStatus = "Adjusting Form Size"

            'set the height of the screen to correlate with the controls
            'text box height = 20
            'space between each = 2
            'space from top of form to first text box = 6 
            '(add height of one control to give room at bottom of screen)
            'space to give from last text box to bottom of screen = 22
            Dim intControlCount As Integer = Me.Controls.Count / 2 'disregard labels

            Me.Height = intControlCount * 20 + (intControlCount * 2) + 20 + 6 + 22

            strStatus = "Setting Data Values"
            SetDataValues(strCommandText)

            'Always close the DataReader and Connection objects.
            rdr.Close()
            cn.Close()
        Catch ex As Exception
            MsgBox(strStatus)
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Function GetDisplaySQL() As String
        Try
            Dim strSQL As String

            Using cn As New SqlConnection(Me.ConnectionString)
                cn.Open()
                Using cmd As New SqlCommand("Select DisplayTable, DisplayPrimaryKey From tblSYS_SystemObjects Where ModuleID = " & Me.SystemObjectID, cn)
                    Dim rdr As SqlDataReader = cmd.ExecuteReader
                    rdr.Read()

                    Me.strPrimaryKeyName = rdr("DisplayPrimaryKey")

                    strSQL = "Select * From " & rdr("DisplayTable") & " Where [" & rdr("DisplayPrimaryKey") & "] = " & Me.PrimaryKeyValue
                End Using
            End Using

            Return strSQL

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Function

    Private Sub SetDataValues(ByVal CommandText As String)
        Try
            Dim rdrValues As SqlDataReader
            Dim txtBox As System.Windows.Forms.Control

            Using cnValues As New SqlConnection(Me.ConnectionString)
                cnValues.Open()
                Using cmdValues As New SqlCommand(CommandText, cnValues)
                    rdrValues = cmdValues.ExecuteReader()
                    rdrValues.Read()

                    For Each txtBox In Me.Controls
                        If TypeOf txtBox Is System.Windows.Forms.TextBox Then
                            txtBox.Text = rdrValues(txtBox.Tag).ToString
                        End If
                    Next
                End Using
            End Using

            rdrValues.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

End Class