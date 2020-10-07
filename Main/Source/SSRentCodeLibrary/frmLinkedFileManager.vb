Imports System.Data.SqlClient

Public Class frmLinkedFileManager
    Inherits System.Windows.Forms.Form

    Private Enum EntryMode
        EntryModeAdd = 0
        EntryModeEdit = 1
    End Enum

    Private enumEntryMode As EntryMode

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        'lvwColumnSorter = New ListViewColumnSorter
        'Me.lvLinkedFiles.ListViewItemSorter = lvwColumnSorter
    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents imgPics As System.Windows.Forms.ImageList
    Friend WithEvents lvLinkedFiles As System.Windows.Forms.ListView
    Friend WithEvents colDescription As System.Windows.Forms.ColumnHeader
    Friend WithEvents colPathToFile As System.Windows.Forms.ColumnHeader
    Friend WithEvents colDateCreated As System.Windows.Forms.ColumnHeader
    Friend WithEvents colUserID As System.Windows.Forms.ColumnHeader
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLinkedFileManager))
        Me.lvLinkedFiles = New System.Windows.Forms.ListView()
        Me.colDescription = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colPathToFile = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colDateCreated = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colUserID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.imgPics = New System.Windows.Forms.ImageList(Me.components)
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.SuspendLayout()
        '
        'lvLinkedFiles
        '
        Me.lvLinkedFiles.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lvLinkedFiles.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colDescription, Me.colPathToFile, Me.colDateCreated, Me.colUserID})
        Me.lvLinkedFiles.FullRowSelect = True
        Me.lvLinkedFiles.GridLines = True
        Me.lvLinkedFiles.HoverSelection = True
        Me.lvLinkedFiles.Location = New System.Drawing.Point(8, 8)
        Me.lvLinkedFiles.Name = "lvLinkedFiles"
        Me.lvLinkedFiles.Size = New System.Drawing.Size(805, 424)
        Me.lvLinkedFiles.SmallImageList = Me.imgPics
        Me.lvLinkedFiles.TabIndex = 1
        Me.lvLinkedFiles.Tag = "Double-click to edit..."
        Me.lvLinkedFiles.UseCompatibleStateImageBehavior = False
        Me.lvLinkedFiles.View = System.Windows.Forms.View.Details
        '
        'colDescription
        '
        Me.colDescription.Text = "Description"
        Me.colDescription.Width = 150
        '
        'colPathToFile
        '
        Me.colPathToFile.Text = "Path To File"
        Me.colPathToFile.Width = 275
        '
        'colDateCreated
        '
        Me.colDateCreated.Text = "Date Created"
        Me.colDateCreated.Width = 130
        '
        'colUserID
        '
        Me.colUserID.Text = "Created By"
        Me.colUserID.Width = 100
        '
        'imgPics
        '
        Me.imgPics.ImageStream = CType(resources.GetObject("imgPics.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgPics.TransparentColor = System.Drawing.Color.Transparent
        Me.imgPics.Images.SetKeyName(0, "")
        '
        'frmLinkedFileManager
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(825, 444)
        Me.Controls.Add(Me.lvLinkedFiles)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLinkedFileManager"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Tag = "s"
        Me.Text = "Linked Files"
        Me.ResumeLayout(False)

    End Sub

#End Region
    Private strOldTextValue As String
    'Private lvwColumnSorter As ListViewColumnSorter
    Private strConnectString As String

    Private mlngSystemObjectID As Long
    Private mlngRecordID As Long
    Private mlngUserID As Long

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

    Public Property ADODBConnectString() As String
        Get
            ADODBConnectString = strConnectString
        End Get
        Set(ByVal Value As String)
            strConnectString = Value
        End Set
    End Property

    Public Event ItemSelected(ByVal ObjectID As Long)
    Public Event SelectionCancelled(ByVal Cancelled As Boolean)
    'declare a long here for clients that cannot support the event callback (Access)
    Public lngObjectIDSelected As Long
    Public blnCancelled As Boolean

    Private Sub FillLinkedFileList()
        Dim cn As New SqlConnection(strConnectString)
        Dim cmd As New SqlCommand("sp_Sys_Objects_LinkedFilesList " & SystemObjectID & ", " & RecordID & ", " & mlngUserID, cn)
        Dim intCounter As Integer

        Const colDescription = 0
        Const colFilePath = 1
        Const colCreatedBy = 2
        Const colDateCreated = 3
        Const colID = 4

        Try
            cn.Open()

            lvLinkedFiles.Items.Clear()

            Dim rdr As SqlClient.SqlDataReader = cmd.ExecuteReader

            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            intCounter = 0


            Do While rdr.Read
                With lvLinkedFiles
                    .Items.Add(IIf(rdr.IsDBNull(colDescription), "", rdr.GetValue(colDescription)), 0)
                    .Items(intCounter).SubItems.Add(IIf(rdr.IsDBNull(colFilePath), "", rdr.GetString(colFilePath)))
                    .Items(intCounter).SubItems.Add(IIf(rdr.IsDBNull(colDateCreated), "", CStr(rdr.GetValue(colDateCreated))))
                    .Items(intCounter).SubItems.Add(IIf(rdr.IsDBNull(colCreatedBy), "", rdr.GetValue(colCreatedBy)))
                    .Items(intCounter).Tag = rdr.GetInt32(colID)

                End With

                intCounter = intCounter + 1
            Loop

            If lvLinkedFiles.Items.Count > 0 Then
                lvLinkedFiles.Focus()
                lvLinkedFiles.Items(0).Selected = True
            End If

            rdr.Close()
            rdr = Nothing

        Catch ex As Exception
            MsgBox("An error occurred while populating the list of linked files." & vbCrLf & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Error")
        Finally
            cmd = Nothing
            cn.Close()
            cn = Nothing
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    'Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
    '    RaiseEvent SelectionCancelled(True)
    '    blnCancelled = True
    '    Close()
    'End Sub

    'Private Sub lvItems_ColumnClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvLinkedFiles.ColumnClick
    '    ' Determine if the clicked column is already the column that is 
    '    ' being sorted.
    '    If (e.Column = lvwColumnSorter.SortColumn) Then
    '        ' Reverse the current sort direction for this column.
    '        If (lvwColumnSorter.Order = Windows.Forms.SortOrder.Ascending) Then
    '            lvwColumnSorter.Order = Windows.Forms.SortOrder.Descending
    '        Else
    '            lvwColumnSorter.Order = Windows.Forms.SortOrder.Ascending
    '        End If
    '    Else
    '        ' Set the column number that is to be sorted; default to ascending.
    '        lvwColumnSorter.SortColumn = e.Column
    '        lvwColumnSorter.Order = Windows.Forms.SortOrder.Ascending
    '    End If

    '    ' Perform the sort with these new sort options.
    '    Me.lvItems.Sort()

    'End Sub

    'Private Sub FillInvCategoryList()
    '    Dim cn As New SqlClient.SqlConnection(strConnectString)
    '    Dim cmd As New SqlClient.SqlCommand("Select [Inventory Category] From tblInventoryCategory", cn)

    '    Try
    '        InvCategory.Items.Clear()

    '        cn.Open()

    '        Dim rdr As SqlClient.SqlDataReader = cmd.ExecuteReader

    '        Do While rdr.Read
    '            InvCategory.Items.Add(rdr.GetSqlString(0))
    '        Loop

    '        rdr.Close()
    '        rdr = Nothing

    '    Catch ex As Exception
    '        MsgBox("Error filling inventory category list." & vbCrLf & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Error")
    '    Finally
    '        cmd = Nothing
    '        cn.Close()
    '        cn = Nothing
    '    End Try
    'End Sub

    'Private Sub cmdFindFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFindFile.Click
    '    Try
    '        With OpenFileDialog1
    '            .Title = "Add Linked File To Record"
    '            .Multiselect = False
    '            .Filter = "All Files(*.*)|*.*"
    '            If .ShowDialog() = Windows.Forms.DialogResult.OK Then
    '                Me.PathToFile.Text = .FileName
    '                Me.cmdSave.Enabled = True
    '            End If
    '        End With
    '    Catch ex As Exception
    '        MsgBox("Error locating file. " & vbCrLf & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Error")
    '    End Try
    'End Sub

    'Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
    '    Dim cn As New SqlConnection(strConnectString)
    '    Dim lngLinkedFileID As Long

    '    Try
    '        If Trim(Me.LinkedFileDescription.Text) = "" Then
    '            MsgBox("Description is a required field.", MsgBoxStyle.Information, "Missing Data")
    '            Exit Try
    '        End If

    '        If Trim(Me.PathToFile.Text) = "" Then
    '            MsgBox("Path to File is a required field.", MsgBoxStyle.Information, "Missing Data")
    '            Exit Try
    '        End If

    '        If Me.enumEntryMode = EntryMode.EntryModeAdd Then
    '            lngLinkedFileID = 0
    '        Else
    '            lngLinkedFileID = Me.lvLinkedFiles.SelectedItems(0).Tag
    '        End If

    '        Dim cmd As New SqlCommand("sp_Sys_Objects_LinkedFileUpdate " & SystemObjectID & ", " & RecordID & ", " & UserID & ", '" & Me.LinkedFileDescription.Text & "', '" & Me.PathToFile.Text & "', " & lngLinkedFileID, cn)

    '        Me.Cursor = Windows.Forms.Cursors.WaitCursor

    '        cn.Open()

    '        cmd.ExecuteNonQuery()

    '        cmd = Nothing

    '        Me.cmdSave.Enabled = False
    '        FillLinkedFileList()

    '    Catch ex As Exception
    '        MsgBox("Error saving record. " & vbCrLf & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Error")
    '    Finally
    '        cn.Close()
    '        cn = Nothing
    '        Me.Cursor = Windows.Forms.Cursors.Default
    '    End Try
    'End Sub

    Private Sub frmLinkedFileManager_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FillLinkedFileList()
    End Sub

    'Private Sub mnuNew_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Call NewLinkedFile()
    'End Sub

    'Private Sub mnuEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Call EditLinkedFile()
    'End Sub

    'Private Sub mnuOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Call OpenLinkedFile()
    'End Sub

    'Private Sub mnuDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Call DeleteLinkedFile()
    'End Sub

    'Private Sub NewLinkedFile()
    '    Try
    '        If CheckedSave() = False Then Exit Try

    '        Me.enumEntryMode = EntryMode.EntryModeAdd

    '        Me.LinkedFileDescription.Text = ""
    '        Me.PathToFile.Text = ""

    '        Me.LinkedFileDescription.Focus()

    '    Catch ex As Exception
    '        MsgBox("Error setting to new mode." & vbCrLf & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Error")
    '    End Try
    'End Sub

    'Private Sub EditLinkedFile()
    '    Try
    '        If Me.lvLinkedFiles.SelectedItems.Count = 0 Then
    '            Exit Try
    '        End If

    '        If CheckedSave() = False Then Exit Try

    '        Me.enumEntryMode = EntryMode.EntryModeEdit

    '        Me.LinkedFileDescription.Text = Me.lvLinkedFiles.SelectedItems(0).Text
    '        Me.PathToFile.Text = Me.lvLinkedFiles.SelectedItems(0).SubItems(1).Text

    '    Catch ex As Exception
    '        MsgBox("Error setting to new mode." & vbCrLf & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Error")
    '    End Try
    'End Sub

    'Private Sub DeleteLinkedFile()
    '    Try
    '        If Me.lvLinkedFiles.SelectedItems.Count = 0 Then
    '            Exit Try
    '        End If

    '        If MsgBox("Are you sure you want to delete the selected linked file?", MsgBoxStyle.YesNo, "Confirm Delete") = MsgBoxResult.Yes Then
    '            Dim cn As New SqlConnection(strConnectString)
    '            Dim cmd As New SqlCommand("sp_Sys_Objects_LinkedFilesDelete " & CLng(Me.lvLinkedFiles.SelectedItems(0).Tag), cn)

    '            cn.Open()

    '            cmd.ExecuteNonQuery()

    '            Me.LinkedFileDescription.Text = ""
    '            Me.PathToFile.Text = ""

    '            FillLinkedFileList()

    '            cmd = Nothing
    '            cn.Close()
    '            cn = Nothing
    '        End If
    '    Catch ex As Exception
    '        MsgBox("Error deleting selected item." & vbCrLf & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Error")
    '    End Try
    'End Sub

    'Private Function CheckedSave() As Boolean
    '    Dim msgResponse As MsgBoxResult

    '    Try
    '        If Me.cmdSave.Enabled Then
    '            msgResponse = MsgBox("Do you want to save the changes you made before proceeding?", MsgBoxStyle.YesNoCancel, "Save Changes?")

    '            Select Case msgResponse
    '                Case MsgBoxResult.Yes
    '                    cmdSave_Click(cmdSave, System.EventArgs.Empty)
    '                    Return True
    '                Case MsgBoxResult.Cancel
    '                    Return False
    '                Case MsgBoxResult.No
    '                    Return True
    '            End Select
    '        Else
    '            Return True
    '        End If
    '    Catch ex As Exception

    '    End Try
    'End Function

    Private Sub OpenLinkedFile()
        Dim strFileName As String
        If Me.lvLinkedFiles.SelectedItems.Count = 0 Then Exit Sub

        strFileName = Me.lvLinkedFiles.SelectedItems(0).SubItems(1).Text

        Dim target As String = strFileName

        Try
            System.Diagnostics.Process.Start(target)
        Catch ex As Exception
            MsgBox("Error opening file." & vbCrLf & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    'Private Sub cmnuDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Call DeleteLinkedFile()
    'End Sub

    'Private Sub cmnuEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Call EditLinkedFile()
    'End Sub

    'Private Sub cmnuNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Call NewLinkedFile()
    'End Sub

    'Private Sub PathToFile_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles PathToFile.KeyPress
    '    Me.cmdSave.Enabled = True
    'End Sub

    'Private Sub LinkedFileDescription_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles LinkedFileDescription.KeyPress
    '    Me.cmdSave.Enabled = True
    'End Sub

    'Private Sub cmnuOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Call OpenLinkedFile()
    'End Sub

    Private Sub lvLinkedFiles_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvLinkedFiles.DoubleClick
        Try
            If lvLinkedFiles.Items.Count = 0 Then Exit Try

            Call OpenLinkedFile()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub lvLinkedFiles_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvLinkedFiles.SelectedIndexChanged

    End Sub
End Class
