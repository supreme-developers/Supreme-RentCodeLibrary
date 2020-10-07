Public Class SSCalendar
    Inherits System.Windows.Forms.UserControl


    Private _SelectedDate As Date
    Private IsInitializing As Boolean
    Private _curText As String
    Private lstView As System.Windows.Forms.ListView
    Private clrHighlightColor As System.Drawing.Color = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.Highlight) ' Color.Khaki
    'Public IsDirty As Boolean = False

    Public DataSource As DataSet
    Public TableName As String
    Public DateMember As String
    Public TimeMember As String
    Public ShowTime As String
    Public TextMember As String
    Public OrderOnField As String
    Public PrimaryKeyFieldName As String
    Public ColorCodeBCFieldName As String
    Public ColorCodeFCFieldName As String
    Public SystemObjectID As Long

    Public Event ShowPopup(ByVal RecordID As Long, ByVal PopupText As String)

    Friend WithEvents lstView1 As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lstView7 As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lstView6 As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lstView5 As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lstView4 As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lstView3 As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lstView2 As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lstView14 As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader14 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lstView13 As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader13 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lstView12 As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader12 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lstView11 As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader11 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lstView10 As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader10 As System.Windows.Forms.ColumnHeader
    'Public WithEvents _lblDay_9 As System.Windows.Forms.Label
    Friend WithEvents lstView9 As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lstView8 As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lstView21 As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader21 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lstView20 As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader20 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lstView19 As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader19 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lstView18 As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader18 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lstView17 As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader17 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lstView16 As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader16 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lstView15 As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader15 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lstView28 As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader28 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lstView27 As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader27 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lstView26 As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader26 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lstView25 As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader25 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lstView24 As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader24 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lstView23 As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader23 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lstView22 As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader22 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lstView33 As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader33 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lstView32 As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader32 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lstView31 As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader31 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lstView30 As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader30 As System.Windows.Forms.ColumnHeader
    'Public WithEvents _lblDay_29 As System.Windows.Forms.Label
    Friend WithEvents lstView29 As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader29 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lstView35 As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader35 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lstView34 As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader34 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lstView42 As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader42 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lstView41 As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader41 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lstView40 As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader40 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lstView39 As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader39 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lstView38 As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader38 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lstView37 As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader37 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lstView36 As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader36 As System.Windows.Forms.ColumnHeader
    Public ShowText As Boolean


    Public Sub New()
        MyBase.New()

        DataSource = Nothing
        TableName = ""
        DateMember = ""
        TimeMember = ""
        ShowTime = False
        TextMember = ""
        ShowText = True

        'This call is required by the Windows Form Designer.
        IsInitializing = True
        InitializeComponent()

        IsInitializing = False
    End Sub

#Region "Windows Form Designer generated code "

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal Disposing As Boolean)
        If Disposing Then
            If Not components Is Nothing Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(Disposing)
    End Sub
    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer
    Public ToolTip1 As System.Windows.Forms.ToolTip
    Public WithEvents _lblDay_6 As System.Windows.Forms.Label
    Public WithEvents _picDay_6 As System.Windows.Forms.Panel
    Public WithEvents _lblDay_5 As System.Windows.Forms.Label
    Public WithEvents _picDay_5 As System.Windows.Forms.Panel
    Public WithEvents _lblDay_4 As System.Windows.Forms.Label
    Public WithEvents _picDay_4 As System.Windows.Forms.Panel
    Public WithEvents _lblDay_3 As System.Windows.Forms.Label
    Public WithEvents _picDay_3 As System.Windows.Forms.Panel
    Public WithEvents _lblDay_2 As System.Windows.Forms.Label
    Public WithEvents _picDay_2 As System.Windows.Forms.Panel
    Public WithEvents _lblDay_1 As System.Windows.Forms.Label
    Public WithEvents _picDay_1 As System.Windows.Forms.Panel
    Public WithEvents _lblDay_0 As System.Windows.Forms.Label
    Public WithEvents _picDay_0 As System.Windows.Forms.Panel
    Public WithEvents _lblDay_13 As System.Windows.Forms.Label
    Public WithEvents _picDay_13 As System.Windows.Forms.Panel
    Public WithEvents _lblDay_12 As System.Windows.Forms.Label
    Public WithEvents _picDay_12 As System.Windows.Forms.Panel
    Public WithEvents _lblDay_11 As System.Windows.Forms.Label
    Public WithEvents _picDay_11 As System.Windows.Forms.Panel
    Public WithEvents _lblDay_10 As System.Windows.Forms.Label
    Public WithEvents _picDay_10 As System.Windows.Forms.Panel
    Public WithEvents _lblDay_9 As System.Windows.Forms.Label
    Public WithEvents _picDay_9 As System.Windows.Forms.Panel
    Public WithEvents _lblDay_8 As System.Windows.Forms.Label
    Public WithEvents _picDay_8 As System.Windows.Forms.Panel
    Public WithEvents _lblDay_7 As System.Windows.Forms.Label
    Public WithEvents _picDay_7 As System.Windows.Forms.Panel
    Public WithEvents _lblDay_20 As System.Windows.Forms.Label
    Public WithEvents _picDay_20 As System.Windows.Forms.Panel
    Public WithEvents _lblDay_19 As System.Windows.Forms.Label
    Public WithEvents _picDay_19 As System.Windows.Forms.Panel
    Public WithEvents _lblDay_18 As System.Windows.Forms.Label
    Public WithEvents _picDay_18 As System.Windows.Forms.Panel
    Public WithEvents _lblDay_17 As System.Windows.Forms.Label
    Public WithEvents _picDay_17 As System.Windows.Forms.Panel
    Public WithEvents _lblDay_16 As System.Windows.Forms.Label
    Public WithEvents _picDay_16 As System.Windows.Forms.Panel
    Public WithEvents _lblDay_15 As System.Windows.Forms.Label
    Public WithEvents _picDay_15 As System.Windows.Forms.Panel
    Public WithEvents _lblDay_14 As System.Windows.Forms.Label
    Public WithEvents _picDay_14 As System.Windows.Forms.Panel
    Public WithEvents _lblDay_27 As System.Windows.Forms.Label
    Public WithEvents _picDay_27 As System.Windows.Forms.Panel
    Public WithEvents _lblDay_26 As System.Windows.Forms.Label
    Public WithEvents _picDay_26 As System.Windows.Forms.Panel
    Public WithEvents _lblDay_25 As System.Windows.Forms.Label
    Public WithEvents _picDay_25 As System.Windows.Forms.Panel
    Public WithEvents _lblDay_24 As System.Windows.Forms.Label
    Public WithEvents _picDay_24 As System.Windows.Forms.Panel
    Public WithEvents _lblDay_23 As System.Windows.Forms.Label
    Public WithEvents _picDay_23 As System.Windows.Forms.Panel
    Public WithEvents _lblDay_22 As System.Windows.Forms.Label
    Public WithEvents _picDay_22 As System.Windows.Forms.Panel
    Public WithEvents _lblDay_21 As System.Windows.Forms.Label
    Public WithEvents _picDay_21 As System.Windows.Forms.Panel
    Public WithEvents _lblDay_34 As System.Windows.Forms.Label
    Public WithEvents _picDay_34 As System.Windows.Forms.Panel
    Public WithEvents _lblDay_33 As System.Windows.Forms.Label
    Public WithEvents _picDay_33 As System.Windows.Forms.Panel
    Public WithEvents _lblDay_32 As System.Windows.Forms.Label
    Public WithEvents _picDay_32 As System.Windows.Forms.Panel
    Public WithEvents _lblDay_31 As System.Windows.Forms.Label
    Public WithEvents _picDay_31 As System.Windows.Forms.Panel
    Public WithEvents _lblDay_30 As System.Windows.Forms.Label
    Public WithEvents _picDay_30 As System.Windows.Forms.Panel
    Public WithEvents _lblDay_29 As System.Windows.Forms.Label
    Public WithEvents _picDay_29 As System.Windows.Forms.Panel
    Public WithEvents _lblDay_28 As System.Windows.Forms.Label
    Public WithEvents _picDay_28 As System.Windows.Forms.Panel
    Public WithEvents _lblDay_41 As System.Windows.Forms.Label
    Public WithEvents _picDay_41 As System.Windows.Forms.Panel
    Public WithEvents _lblDay_40 As System.Windows.Forms.Label
    Public WithEvents _picDay_40 As System.Windows.Forms.Panel
    Public WithEvents _lblDay_39 As System.Windows.Forms.Label
    Public WithEvents _picDay_39 As System.Windows.Forms.Panel
    Public WithEvents _lblDay_38 As System.Windows.Forms.Label
    Public WithEvents _picDay_38 As System.Windows.Forms.Panel
    Public WithEvents _lblDay_37 As System.Windows.Forms.Label
    Public WithEvents _picDay_37 As System.Windows.Forms.Panel
    Public WithEvents _lblDay_36 As System.Windows.Forms.Label
    Public WithEvents _picDay_36 As System.Windows.Forms.Panel
    Public WithEvents _lblDay_35 As System.Windows.Forms.Label
    Public WithEvents _picDay_35 As System.Windows.Forms.Panel
    Public WithEvents lblSunday As System.Windows.Forms.Label
    Public WithEvents lblDay As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    Public WithEvents picDay As Microsoft.VisualBasic.Compatibility.VB6.PanelArray
    Public WithEvents txtDay As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Public WithEvents lblFriday As System.Windows.Forms.Label
    Public WithEvents lblWednesday As System.Windows.Forms.Label
    Public WithEvents lblTuesday As System.Windows.Forms.Label
    Public WithEvents lblMonday As System.Windows.Forms.Label
    Public WithEvents lblThursday As System.Windows.Forms.Label
    Public WithEvents lblSaturday As System.Windows.Forms.Label
    Friend WithEvents HeaderPanel As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents HeaderLable As System.Windows.Forms.Label
    Friend WithEvents MonthCombo As System.Windows.Forms.ComboBox
    Friend WithEvents YearUpDown As System.Windows.Forms.NumericUpDown
    Friend WithEvents bkBtn As System.Windows.Forms.Button
    Friend WithEvents nxtBtn As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SSCalendar))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me._picDay_6 = New System.Windows.Forms.Panel
        Me.lstView7 = New System.Windows.Forms.ListView
        Me.ColumnHeader7 = New System.Windows.Forms.ColumnHeader
        Me._lblDay_6 = New System.Windows.Forms.Label
        Me._picDay_5 = New System.Windows.Forms.Panel
        Me.lstView6 = New System.Windows.Forms.ListView
        Me.ColumnHeader6 = New System.Windows.Forms.ColumnHeader
        Me._lblDay_5 = New System.Windows.Forms.Label
        Me._picDay_4 = New System.Windows.Forms.Panel
        Me.lstView5 = New System.Windows.Forms.ListView
        Me.ColumnHeader5 = New System.Windows.Forms.ColumnHeader
        Me._lblDay_4 = New System.Windows.Forms.Label
        Me._picDay_3 = New System.Windows.Forms.Panel
        Me.lstView4 = New System.Windows.Forms.ListView
        Me.ColumnHeader4 = New System.Windows.Forms.ColumnHeader
        Me._lblDay_3 = New System.Windows.Forms.Label
        Me._picDay_2 = New System.Windows.Forms.Panel
        Me.lstView3 = New System.Windows.Forms.ListView
        Me.ColumnHeader3 = New System.Windows.Forms.ColumnHeader
        Me._lblDay_2 = New System.Windows.Forms.Label
        Me._picDay_1 = New System.Windows.Forms.Panel
        Me.lstView2 = New System.Windows.Forms.ListView
        Me.ColumnHeader2 = New System.Windows.Forms.ColumnHeader
        Me._lblDay_1 = New System.Windows.Forms.Label
        Me._picDay_0 = New System.Windows.Forms.Panel
        Me.lstView1 = New System.Windows.Forms.ListView
        Me.ColumnHeader1 = New System.Windows.Forms.ColumnHeader
        Me._lblDay_0 = New System.Windows.Forms.Label
        Me._picDay_13 = New System.Windows.Forms.Panel
        Me.lstView14 = New System.Windows.Forms.ListView
        Me.ColumnHeader14 = New System.Windows.Forms.ColumnHeader
        Me._lblDay_13 = New System.Windows.Forms.Label
        Me._picDay_12 = New System.Windows.Forms.Panel
        Me.lstView13 = New System.Windows.Forms.ListView
        Me.ColumnHeader13 = New System.Windows.Forms.ColumnHeader
        Me._lblDay_12 = New System.Windows.Forms.Label
        Me._picDay_11 = New System.Windows.Forms.Panel
        Me.lstView12 = New System.Windows.Forms.ListView
        Me.ColumnHeader12 = New System.Windows.Forms.ColumnHeader
        Me._lblDay_11 = New System.Windows.Forms.Label
        Me._picDay_10 = New System.Windows.Forms.Panel
        Me.lstView11 = New System.Windows.Forms.ListView
        Me.ColumnHeader11 = New System.Windows.Forms.ColumnHeader
        Me._lblDay_10 = New System.Windows.Forms.Label
        Me._picDay_9 = New System.Windows.Forms.Panel
        Me.lstView10 = New System.Windows.Forms.ListView
        Me.ColumnHeader10 = New System.Windows.Forms.ColumnHeader
        Me._lblDay_9 = New System.Windows.Forms.Label
        Me._picDay_8 = New System.Windows.Forms.Panel
        Me.lstView9 = New System.Windows.Forms.ListView
        Me.ColumnHeader9 = New System.Windows.Forms.ColumnHeader
        Me._lblDay_8 = New System.Windows.Forms.Label
        Me._picDay_7 = New System.Windows.Forms.Panel
        Me.lstView8 = New System.Windows.Forms.ListView
        Me.ColumnHeader8 = New System.Windows.Forms.ColumnHeader
        Me._lblDay_7 = New System.Windows.Forms.Label
        Me._picDay_20 = New System.Windows.Forms.Panel
        Me.lstView21 = New System.Windows.Forms.ListView
        Me.ColumnHeader21 = New System.Windows.Forms.ColumnHeader
        Me._lblDay_20 = New System.Windows.Forms.Label
        Me._picDay_19 = New System.Windows.Forms.Panel
        Me.lstView20 = New System.Windows.Forms.ListView
        Me.ColumnHeader20 = New System.Windows.Forms.ColumnHeader
        Me._lblDay_19 = New System.Windows.Forms.Label
        Me._picDay_18 = New System.Windows.Forms.Panel
        Me.lstView19 = New System.Windows.Forms.ListView
        Me.ColumnHeader19 = New System.Windows.Forms.ColumnHeader
        Me._lblDay_18 = New System.Windows.Forms.Label
        Me._picDay_17 = New System.Windows.Forms.Panel
        Me.lstView18 = New System.Windows.Forms.ListView
        Me.ColumnHeader18 = New System.Windows.Forms.ColumnHeader
        Me._lblDay_17 = New System.Windows.Forms.Label
        Me._picDay_16 = New System.Windows.Forms.Panel
        Me.lstView17 = New System.Windows.Forms.ListView
        Me.ColumnHeader17 = New System.Windows.Forms.ColumnHeader
        Me._lblDay_16 = New System.Windows.Forms.Label
        Me._picDay_15 = New System.Windows.Forms.Panel
        Me.lstView16 = New System.Windows.Forms.ListView
        Me.ColumnHeader16 = New System.Windows.Forms.ColumnHeader
        Me._lblDay_15 = New System.Windows.Forms.Label
        Me._picDay_14 = New System.Windows.Forms.Panel
        Me.lstView15 = New System.Windows.Forms.ListView
        Me.ColumnHeader15 = New System.Windows.Forms.ColumnHeader
        Me._lblDay_14 = New System.Windows.Forms.Label
        Me._picDay_27 = New System.Windows.Forms.Panel
        Me.lstView28 = New System.Windows.Forms.ListView
        Me.ColumnHeader28 = New System.Windows.Forms.ColumnHeader
        Me._lblDay_27 = New System.Windows.Forms.Label
        Me._picDay_26 = New System.Windows.Forms.Panel
        Me.lstView27 = New System.Windows.Forms.ListView
        Me.ColumnHeader27 = New System.Windows.Forms.ColumnHeader
        Me._lblDay_26 = New System.Windows.Forms.Label
        Me._picDay_25 = New System.Windows.Forms.Panel
        Me.lstView26 = New System.Windows.Forms.ListView
        Me.ColumnHeader26 = New System.Windows.Forms.ColumnHeader
        Me._lblDay_25 = New System.Windows.Forms.Label
        Me._picDay_24 = New System.Windows.Forms.Panel
        Me.lstView25 = New System.Windows.Forms.ListView
        Me.ColumnHeader25 = New System.Windows.Forms.ColumnHeader
        Me._lblDay_24 = New System.Windows.Forms.Label
        Me._picDay_23 = New System.Windows.Forms.Panel
        Me.lstView24 = New System.Windows.Forms.ListView
        Me.ColumnHeader24 = New System.Windows.Forms.ColumnHeader
        Me._lblDay_23 = New System.Windows.Forms.Label
        Me._picDay_22 = New System.Windows.Forms.Panel
        Me.lstView23 = New System.Windows.Forms.ListView
        Me.ColumnHeader23 = New System.Windows.Forms.ColumnHeader
        Me._lblDay_22 = New System.Windows.Forms.Label
        Me._picDay_21 = New System.Windows.Forms.Panel
        Me.lstView22 = New System.Windows.Forms.ListView
        Me.ColumnHeader22 = New System.Windows.Forms.ColumnHeader
        Me._lblDay_21 = New System.Windows.Forms.Label
        Me._picDay_34 = New System.Windows.Forms.Panel
        Me.lstView35 = New System.Windows.Forms.ListView
        Me.ColumnHeader35 = New System.Windows.Forms.ColumnHeader
        Me._lblDay_34 = New System.Windows.Forms.Label
        Me._picDay_33 = New System.Windows.Forms.Panel
        Me.lstView34 = New System.Windows.Forms.ListView
        Me.ColumnHeader34 = New System.Windows.Forms.ColumnHeader
        Me._lblDay_33 = New System.Windows.Forms.Label
        Me._picDay_32 = New System.Windows.Forms.Panel
        Me.lstView33 = New System.Windows.Forms.ListView
        Me.ColumnHeader33 = New System.Windows.Forms.ColumnHeader
        Me._lblDay_32 = New System.Windows.Forms.Label
        Me._picDay_31 = New System.Windows.Forms.Panel
        Me.lstView32 = New System.Windows.Forms.ListView
        Me.ColumnHeader32 = New System.Windows.Forms.ColumnHeader
        Me._lblDay_31 = New System.Windows.Forms.Label
        Me._picDay_30 = New System.Windows.Forms.Panel
        Me.lstView31 = New System.Windows.Forms.ListView
        Me.ColumnHeader31 = New System.Windows.Forms.ColumnHeader
        Me._lblDay_30 = New System.Windows.Forms.Label
        Me._picDay_29 = New System.Windows.Forms.Panel
        Me.lstView30 = New System.Windows.Forms.ListView
        Me.ColumnHeader30 = New System.Windows.Forms.ColumnHeader
        Me._lblDay_29 = New System.Windows.Forms.Label
        Me._picDay_28 = New System.Windows.Forms.Panel
        Me.lstView29 = New System.Windows.Forms.ListView
        Me.ColumnHeader29 = New System.Windows.Forms.ColumnHeader
        Me._lblDay_28 = New System.Windows.Forms.Label
        Me._picDay_41 = New System.Windows.Forms.Panel
        Me.lstView42 = New System.Windows.Forms.ListView
        Me.ColumnHeader42 = New System.Windows.Forms.ColumnHeader
        Me._lblDay_41 = New System.Windows.Forms.Label
        Me._picDay_40 = New System.Windows.Forms.Panel
        Me.lstView41 = New System.Windows.Forms.ListView
        Me.ColumnHeader41 = New System.Windows.Forms.ColumnHeader
        Me._lblDay_40 = New System.Windows.Forms.Label
        Me._picDay_39 = New System.Windows.Forms.Panel
        Me.lstView40 = New System.Windows.Forms.ListView
        Me.ColumnHeader40 = New System.Windows.Forms.ColumnHeader
        Me._lblDay_39 = New System.Windows.Forms.Label
        Me._picDay_38 = New System.Windows.Forms.Panel
        Me.lstView39 = New System.Windows.Forms.ListView
        Me.ColumnHeader39 = New System.Windows.Forms.ColumnHeader
        Me._lblDay_38 = New System.Windows.Forms.Label
        Me._picDay_37 = New System.Windows.Forms.Panel
        Me.lstView38 = New System.Windows.Forms.ListView
        Me.ColumnHeader38 = New System.Windows.Forms.ColumnHeader
        Me._lblDay_37 = New System.Windows.Forms.Label
        Me._picDay_36 = New System.Windows.Forms.Panel
        Me.lstView37 = New System.Windows.Forms.ListView
        Me.ColumnHeader37 = New System.Windows.Forms.ColumnHeader
        Me._lblDay_36 = New System.Windows.Forms.Label
        Me._picDay_35 = New System.Windows.Forms.Panel
        Me.lstView36 = New System.Windows.Forms.ListView
        Me.ColumnHeader36 = New System.Windows.Forms.ColumnHeader
        Me._lblDay_35 = New System.Windows.Forms.Label
        Me.lblSaturday = New System.Windows.Forms.Label
        Me.lblFriday = New System.Windows.Forms.Label
        Me.lblThursday = New System.Windows.Forms.Label
        Me.lblWednesday = New System.Windows.Forms.Label
        Me.lblTuesday = New System.Windows.Forms.Label
        Me.lblMonday = New System.Windows.Forms.Label
        Me.lblSunday = New System.Windows.Forms.Label
        Me.lblDay = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
        Me.picDay = New Microsoft.VisualBasic.Compatibility.VB6.PanelArray(Me.components)
        Me.txtDay = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(Me.components)
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.HeaderPanel = New System.Windows.Forms.Panel
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.HeaderLable = New System.Windows.Forms.Label
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.nxtBtn = New System.Windows.Forms.Button
        Me.bkBtn = New System.Windows.Forms.Button
        Me.YearUpDown = New System.Windows.Forms.NumericUpDown
        Me.MonthCombo = New System.Windows.Forms.ComboBox
        Me._picDay_6.SuspendLayout()
        Me._picDay_5.SuspendLayout()
        Me._picDay_4.SuspendLayout()
        Me._picDay_3.SuspendLayout()
        Me._picDay_2.SuspendLayout()
        Me._picDay_1.SuspendLayout()
        Me._picDay_0.SuspendLayout()
        Me._picDay_13.SuspendLayout()
        Me._picDay_12.SuspendLayout()
        Me._picDay_11.SuspendLayout()
        Me._picDay_10.SuspendLayout()
        Me._picDay_9.SuspendLayout()
        Me._picDay_8.SuspendLayout()
        Me._picDay_7.SuspendLayout()
        Me._picDay_20.SuspendLayout()
        Me._picDay_19.SuspendLayout()
        Me._picDay_18.SuspendLayout()
        Me._picDay_17.SuspendLayout()
        Me._picDay_16.SuspendLayout()
        Me._picDay_15.SuspendLayout()
        Me._picDay_14.SuspendLayout()
        Me._picDay_27.SuspendLayout()
        Me._picDay_26.SuspendLayout()
        Me._picDay_25.SuspendLayout()
        Me._picDay_24.SuspendLayout()
        Me._picDay_23.SuspendLayout()
        Me._picDay_22.SuspendLayout()
        Me._picDay_21.SuspendLayout()
        Me._picDay_34.SuspendLayout()
        Me._picDay_33.SuspendLayout()
        Me._picDay_32.SuspendLayout()
        Me._picDay_31.SuspendLayout()
        Me._picDay_30.SuspendLayout()
        Me._picDay_29.SuspendLayout()
        Me._picDay_28.SuspendLayout()
        Me._picDay_41.SuspendLayout()
        Me._picDay_40.SuspendLayout()
        Me._picDay_39.SuspendLayout()
        Me._picDay_38.SuspendLayout()
        Me._picDay_37.SuspendLayout()
        Me._picDay_36.SuspendLayout()
        Me._picDay_35.SuspendLayout()
        CType(Me.lblDay, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picDay, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDay, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.HeaderPanel.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.YearUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        '_picDay_6
        '
        Me._picDay_6.BackColor = System.Drawing.SystemColors.Control
        Me._picDay_6.Controls.Add(Me.lstView7)
        Me._picDay_6.Controls.Add(Me._lblDay_6)
        Me._picDay_6.Cursor = System.Windows.Forms.Cursors.Default
        Me._picDay_6.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._picDay_6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.picDay.SetIndex(Me._picDay_6, CType(6, Short))
        Me._picDay_6.Location = New System.Drawing.Point(536, 64)
        Me._picDay_6.Name = "_picDay_6"
        Me._picDay_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._picDay_6.Size = New System.Drawing.Size(89, 83)
        Me._picDay_6.TabIndex = 26
        Me._picDay_6.TabStop = True
        '
        'lstView7
        '
        Me.lstView7.Activation = System.Windows.Forms.ItemActivation.TwoClick
        Me.lstView7.BackColor = System.Drawing.SystemColors.Window
        Me.lstView7.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader7})
        Me.lstView7.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstView7.FullRowSelect = True
        Me.lstView7.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lstView7.Location = New System.Drawing.Point(0, 16)
        Me.lstView7.MultiSelect = False
        Me.lstView7.Name = "lstView7"
        Me.lstView7.ShowItemToolTips = True
        Me.lstView7.Size = New System.Drawing.Size(89, 67)
        Me.lstView7.TabIndex = 29
        Me.lstView7.UseCompatibleStateImageBehavior = False
        Me.lstView7.View = System.Windows.Forms.View.Details
        '
        '_lblDay_6
        '
        Me._lblDay_6.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me._lblDay_6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblDay_6.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblDay_6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblDay_6.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblDay.SetIndex(Me._lblDay_6, CType(6, Short))
        Me._lblDay_6.Location = New System.Drawing.Point(0, 0)
        Me._lblDay_6.Name = "_lblDay_6"
        Me._lblDay_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblDay_6.Size = New System.Drawing.Size(25, 17)
        Me._lblDay_6.TabIndex = 28
        Me._lblDay_6.Text = "-"
        '
        '_picDay_5
        '
        Me._picDay_5.BackColor = System.Drawing.SystemColors.Control
        Me._picDay_5.Controls.Add(Me.lstView6)
        Me._picDay_5.Controls.Add(Me._lblDay_5)
        Me._picDay_5.Cursor = System.Windows.Forms.Cursors.Default
        Me._picDay_5.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._picDay_5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.picDay.SetIndex(Me._picDay_5, CType(5, Short))
        Me._picDay_5.Location = New System.Drawing.Point(448, 64)
        Me._picDay_5.Name = "_picDay_5"
        Me._picDay_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._picDay_5.Size = New System.Drawing.Size(89, 83)
        Me._picDay_5.TabIndex = 23
        Me._picDay_5.TabStop = True
        '
        'lstView6
        '
        Me.lstView6.Activation = System.Windows.Forms.ItemActivation.TwoClick
        Me.lstView6.BackColor = System.Drawing.SystemColors.Window
        Me.lstView6.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader6})
        Me.lstView6.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstView6.FullRowSelect = True
        Me.lstView6.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lstView6.Location = New System.Drawing.Point(0, 16)
        Me.lstView6.MultiSelect = False
        Me.lstView6.Name = "lstView6"
        Me.lstView6.ShowItemToolTips = True
        Me.lstView6.Size = New System.Drawing.Size(89, 67)
        Me.lstView6.TabIndex = 26
        Me.lstView6.UseCompatibleStateImageBehavior = False
        Me.lstView6.View = System.Windows.Forms.View.Details
        '
        '_lblDay_5
        '
        Me._lblDay_5.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me._lblDay_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblDay_5.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblDay_5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblDay_5.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblDay.SetIndex(Me._lblDay_5, CType(5, Short))
        Me._lblDay_5.Location = New System.Drawing.Point(0, 0)
        Me._lblDay_5.Name = "_lblDay_5"
        Me._lblDay_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblDay_5.Size = New System.Drawing.Size(25, 17)
        Me._lblDay_5.TabIndex = 25
        Me._lblDay_5.Text = "-"
        '
        '_picDay_4
        '
        Me._picDay_4.BackColor = System.Drawing.SystemColors.Control
        Me._picDay_4.Controls.Add(Me.lstView5)
        Me._picDay_4.Controls.Add(Me._lblDay_4)
        Me._picDay_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._picDay_4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._picDay_4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.picDay.SetIndex(Me._picDay_4, CType(4, Short))
        Me._picDay_4.Location = New System.Drawing.Point(360, 64)
        Me._picDay_4.Name = "_picDay_4"
        Me._picDay_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._picDay_4.Size = New System.Drawing.Size(89, 83)
        Me._picDay_4.TabIndex = 20
        Me._picDay_4.TabStop = True
        '
        'lstView5
        '
        Me.lstView5.Activation = System.Windows.Forms.ItemActivation.TwoClick
        Me.lstView5.BackColor = System.Drawing.SystemColors.Window
        Me.lstView5.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader5})
        Me.lstView5.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstView5.FullRowSelect = True
        Me.lstView5.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lstView5.Location = New System.Drawing.Point(0, 16)
        Me.lstView5.MultiSelect = False
        Me.lstView5.Name = "lstView5"
        Me.lstView5.ShowItemToolTips = True
        Me.lstView5.Size = New System.Drawing.Size(89, 67)
        Me.lstView5.TabIndex = 23
        Me.lstView5.UseCompatibleStateImageBehavior = False
        Me.lstView5.View = System.Windows.Forms.View.Details
        '
        '_lblDay_4
        '
        Me._lblDay_4.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me._lblDay_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblDay_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblDay_4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblDay_4.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblDay.SetIndex(Me._lblDay_4, CType(4, Short))
        Me._lblDay_4.Location = New System.Drawing.Point(0, 0)
        Me._lblDay_4.Name = "_lblDay_4"
        Me._lblDay_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblDay_4.Size = New System.Drawing.Size(25, 17)
        Me._lblDay_4.TabIndex = 22
        Me._lblDay_4.Text = "-"
        '
        '_picDay_3
        '
        Me._picDay_3.BackColor = System.Drawing.SystemColors.Control
        Me._picDay_3.Controls.Add(Me.lstView4)
        Me._picDay_3.Controls.Add(Me._lblDay_3)
        Me._picDay_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._picDay_3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._picDay_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.picDay.SetIndex(Me._picDay_3, CType(3, Short))
        Me._picDay_3.Location = New System.Drawing.Point(272, 64)
        Me._picDay_3.Name = "_picDay_3"
        Me._picDay_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._picDay_3.Size = New System.Drawing.Size(89, 83)
        Me._picDay_3.TabIndex = 17
        Me._picDay_3.TabStop = True
        '
        'lstView4
        '
        Me.lstView4.Activation = System.Windows.Forms.ItemActivation.TwoClick
        Me.lstView4.BackColor = System.Drawing.SystemColors.Window
        Me.lstView4.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader4})
        Me.lstView4.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstView4.FullRowSelect = True
        Me.lstView4.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lstView4.Location = New System.Drawing.Point(0, 16)
        Me.lstView4.MultiSelect = False
        Me.lstView4.Name = "lstView4"
        Me.lstView4.ShowItemToolTips = True
        Me.lstView4.Size = New System.Drawing.Size(89, 67)
        Me.lstView4.TabIndex = 20
        Me.lstView4.UseCompatibleStateImageBehavior = False
        Me.lstView4.View = System.Windows.Forms.View.Details
        '
        '_lblDay_3
        '
        Me._lblDay_3.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me._lblDay_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblDay_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblDay_3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblDay_3.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblDay.SetIndex(Me._lblDay_3, CType(3, Short))
        Me._lblDay_3.Location = New System.Drawing.Point(0, 0)
        Me._lblDay_3.Name = "_lblDay_3"
        Me._lblDay_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblDay_3.Size = New System.Drawing.Size(25, 17)
        Me._lblDay_3.TabIndex = 19
        Me._lblDay_3.Text = "-"
        '
        '_picDay_2
        '
        Me._picDay_2.BackColor = System.Drawing.SystemColors.Control
        Me._picDay_2.Controls.Add(Me.lstView3)
        Me._picDay_2.Controls.Add(Me._lblDay_2)
        Me._picDay_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._picDay_2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._picDay_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.picDay.SetIndex(Me._picDay_2, CType(2, Short))
        Me._picDay_2.Location = New System.Drawing.Point(184, 64)
        Me._picDay_2.Name = "_picDay_2"
        Me._picDay_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._picDay_2.Size = New System.Drawing.Size(89, 83)
        Me._picDay_2.TabIndex = 14
        Me._picDay_2.TabStop = True
        '
        'lstView3
        '
        Me.lstView3.Activation = System.Windows.Forms.ItemActivation.TwoClick
        Me.lstView3.BackColor = System.Drawing.SystemColors.Window
        Me.lstView3.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader3})
        Me.lstView3.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstView3.FullRowSelect = True
        Me.lstView3.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lstView3.Location = New System.Drawing.Point(0, 16)
        Me.lstView3.MultiSelect = False
        Me.lstView3.Name = "lstView3"
        Me.lstView3.ShowItemToolTips = True
        Me.lstView3.Size = New System.Drawing.Size(89, 67)
        Me.lstView3.TabIndex = 17
        Me.lstView3.UseCompatibleStateImageBehavior = False
        Me.lstView3.View = System.Windows.Forms.View.Details
        '
        '_lblDay_2
        '
        Me._lblDay_2.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me._lblDay_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblDay_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblDay_2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblDay_2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblDay.SetIndex(Me._lblDay_2, CType(2, Short))
        Me._lblDay_2.Location = New System.Drawing.Point(0, 0)
        Me._lblDay_2.Name = "_lblDay_2"
        Me._lblDay_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblDay_2.Size = New System.Drawing.Size(25, 17)
        Me._lblDay_2.TabIndex = 16
        Me._lblDay_2.Text = "-"
        '
        '_picDay_1
        '
        Me._picDay_1.BackColor = System.Drawing.SystemColors.Control
        Me._picDay_1.Controls.Add(Me.lstView2)
        Me._picDay_1.Controls.Add(Me._lblDay_1)
        Me._picDay_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._picDay_1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._picDay_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.picDay.SetIndex(Me._picDay_1, CType(1, Short))
        Me._picDay_1.Location = New System.Drawing.Point(96, 64)
        Me._picDay_1.Name = "_picDay_1"
        Me._picDay_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._picDay_1.Size = New System.Drawing.Size(89, 83)
        Me._picDay_1.TabIndex = 11
        Me._picDay_1.TabStop = True
        '
        'lstView2
        '
        Me.lstView2.Activation = System.Windows.Forms.ItemActivation.TwoClick
        Me.lstView2.BackColor = System.Drawing.SystemColors.Window
        Me.lstView2.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader2})
        Me.lstView2.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstView2.FullRowSelect = True
        Me.lstView2.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lstView2.Location = New System.Drawing.Point(0, 16)
        Me.lstView2.MultiSelect = False
        Me.lstView2.Name = "lstView2"
        Me.lstView2.ShowItemToolTips = True
        Me.lstView2.Size = New System.Drawing.Size(89, 67)
        Me.lstView2.TabIndex = 14
        Me.lstView2.UseCompatibleStateImageBehavior = False
        Me.lstView2.View = System.Windows.Forms.View.Details
        '
        '_lblDay_1
        '
        Me._lblDay_1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me._lblDay_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblDay_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblDay_1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblDay_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblDay.SetIndex(Me._lblDay_1, CType(1, Short))
        Me._lblDay_1.Location = New System.Drawing.Point(0, 0)
        Me._lblDay_1.Name = "_lblDay_1"
        Me._lblDay_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblDay_1.Size = New System.Drawing.Size(25, 17)
        Me._lblDay_1.TabIndex = 13
        Me._lblDay_1.Text = "-"
        '
        '_picDay_0
        '
        Me._picDay_0.BackColor = System.Drawing.SystemColors.Control
        Me._picDay_0.Controls.Add(Me.lstView1)
        Me._picDay_0.Controls.Add(Me._lblDay_0)
        Me._picDay_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._picDay_0.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._picDay_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.picDay.SetIndex(Me._picDay_0, CType(0, Short))
        Me._picDay_0.Location = New System.Drawing.Point(8, 64)
        Me._picDay_0.Name = "_picDay_0"
        Me._picDay_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._picDay_0.Size = New System.Drawing.Size(89, 83)
        Me._picDay_0.TabIndex = 8
        Me._picDay_0.TabStop = True
        '
        'lstView1
        '
        Me.lstView1.Activation = System.Windows.Forms.ItemActivation.TwoClick
        Me.lstView1.BackColor = System.Drawing.SystemColors.Window
        Me.lstView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1})
        Me.lstView1.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstView1.FullRowSelect = True
        Me.lstView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lstView1.Location = New System.Drawing.Point(0, 16)
        Me.lstView1.MultiSelect = False
        Me.lstView1.Name = "lstView1"
        Me.lstView1.ShowItemToolTips = True
        Me.lstView1.Size = New System.Drawing.Size(89, 67)
        Me.lstView1.TabIndex = 11
        Me.lstView1.UseCompatibleStateImageBehavior = False
        Me.lstView1.View = System.Windows.Forms.View.Details
        '
        '_lblDay_0
        '
        Me._lblDay_0.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me._lblDay_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblDay_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblDay_0.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblDay_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblDay.SetIndex(Me._lblDay_0, CType(0, Short))
        Me._lblDay_0.Location = New System.Drawing.Point(0, 0)
        Me._lblDay_0.Name = "_lblDay_0"
        Me._lblDay_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblDay_0.Size = New System.Drawing.Size(25, 17)
        Me._lblDay_0.TabIndex = 10
        Me._lblDay_0.Text = "-"
        '
        '_picDay_13
        '
        Me._picDay_13.BackColor = System.Drawing.SystemColors.Control
        Me._picDay_13.Controls.Add(Me.lstView14)
        Me._picDay_13.Controls.Add(Me._lblDay_13)
        Me._picDay_13.Cursor = System.Windows.Forms.Cursors.Default
        Me._picDay_13.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._picDay_13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.picDay.SetIndex(Me._picDay_13, CType(13, Short))
        Me._picDay_13.Location = New System.Drawing.Point(536, 147)
        Me._picDay_13.Name = "_picDay_13"
        Me._picDay_13.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._picDay_13.Size = New System.Drawing.Size(89, 83)
        Me._picDay_13.TabIndex = 47
        Me._picDay_13.TabStop = True
        '
        'lstView14
        '
        Me.lstView14.Activation = System.Windows.Forms.ItemActivation.TwoClick
        Me.lstView14.BackColor = System.Drawing.SystemColors.Window
        Me.lstView14.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader14})
        Me.lstView14.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstView14.FullRowSelect = True
        Me.lstView14.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lstView14.Location = New System.Drawing.Point(0, 16)
        Me.lstView14.MultiSelect = False
        Me.lstView14.Name = "lstView14"
        Me.lstView14.ShowItemToolTips = True
        Me.lstView14.Size = New System.Drawing.Size(89, 67)
        Me.lstView14.TabIndex = 50
        Me.lstView14.UseCompatibleStateImageBehavior = False
        Me.lstView14.View = System.Windows.Forms.View.Details
        '
        '_lblDay_13
        '
        Me._lblDay_13.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me._lblDay_13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblDay_13.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblDay_13.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblDay_13.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblDay.SetIndex(Me._lblDay_13, CType(13, Short))
        Me._lblDay_13.Location = New System.Drawing.Point(0, 0)
        Me._lblDay_13.Name = "_lblDay_13"
        Me._lblDay_13.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblDay_13.Size = New System.Drawing.Size(25, 17)
        Me._lblDay_13.TabIndex = 49
        Me._lblDay_13.Text = "-"
        '
        '_picDay_12
        '
        Me._picDay_12.BackColor = System.Drawing.SystemColors.Control
        Me._picDay_12.Controls.Add(Me.lstView13)
        Me._picDay_12.Controls.Add(Me._lblDay_12)
        Me._picDay_12.Cursor = System.Windows.Forms.Cursors.Default
        Me._picDay_12.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._picDay_12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.picDay.SetIndex(Me._picDay_12, CType(12, Short))
        Me._picDay_12.Location = New System.Drawing.Point(448, 147)
        Me._picDay_12.Name = "_picDay_12"
        Me._picDay_12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._picDay_12.Size = New System.Drawing.Size(89, 83)
        Me._picDay_12.TabIndex = 44
        Me._picDay_12.TabStop = True
        '
        'lstView13
        '
        Me.lstView13.Activation = System.Windows.Forms.ItemActivation.TwoClick
        Me.lstView13.BackColor = System.Drawing.SystemColors.Window
        Me.lstView13.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader13})
        Me.lstView13.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstView13.FullRowSelect = True
        Me.lstView13.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lstView13.Location = New System.Drawing.Point(0, 16)
        Me.lstView13.MultiSelect = False
        Me.lstView13.Name = "lstView13"
        Me.lstView13.ShowItemToolTips = True
        Me.lstView13.Size = New System.Drawing.Size(89, 67)
        Me.lstView13.TabIndex = 47
        Me.lstView13.UseCompatibleStateImageBehavior = False
        Me.lstView13.View = System.Windows.Forms.View.Details
        '
        '_lblDay_12
        '
        Me._lblDay_12.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me._lblDay_12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblDay_12.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblDay_12.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblDay_12.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblDay.SetIndex(Me._lblDay_12, CType(12, Short))
        Me._lblDay_12.Location = New System.Drawing.Point(0, 0)
        Me._lblDay_12.Name = "_lblDay_12"
        Me._lblDay_12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblDay_12.Size = New System.Drawing.Size(25, 17)
        Me._lblDay_12.TabIndex = 46
        Me._lblDay_12.Text = "-"
        '
        '_picDay_11
        '
        Me._picDay_11.BackColor = System.Drawing.SystemColors.Control
        Me._picDay_11.Controls.Add(Me.lstView12)
        Me._picDay_11.Controls.Add(Me._lblDay_11)
        Me._picDay_11.Cursor = System.Windows.Forms.Cursors.Default
        Me._picDay_11.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._picDay_11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.picDay.SetIndex(Me._picDay_11, CType(11, Short))
        Me._picDay_11.Location = New System.Drawing.Point(360, 147)
        Me._picDay_11.Name = "_picDay_11"
        Me._picDay_11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._picDay_11.Size = New System.Drawing.Size(89, 83)
        Me._picDay_11.TabIndex = 41
        Me._picDay_11.TabStop = True
        '
        'lstView12
        '
        Me.lstView12.Activation = System.Windows.Forms.ItemActivation.TwoClick
        Me.lstView12.BackColor = System.Drawing.SystemColors.Window
        Me.lstView12.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader12})
        Me.lstView12.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstView12.FullRowSelect = True
        Me.lstView12.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lstView12.Location = New System.Drawing.Point(0, 16)
        Me.lstView12.MultiSelect = False
        Me.lstView12.Name = "lstView12"
        Me.lstView12.ShowItemToolTips = True
        Me.lstView12.Size = New System.Drawing.Size(89, 67)
        Me.lstView12.TabIndex = 44
        Me.lstView12.UseCompatibleStateImageBehavior = False
        Me.lstView12.View = System.Windows.Forms.View.Details
        '
        '_lblDay_11
        '
        Me._lblDay_11.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me._lblDay_11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblDay_11.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblDay_11.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblDay_11.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblDay.SetIndex(Me._lblDay_11, CType(11, Short))
        Me._lblDay_11.Location = New System.Drawing.Point(0, 0)
        Me._lblDay_11.Name = "_lblDay_11"
        Me._lblDay_11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblDay_11.Size = New System.Drawing.Size(25, 17)
        Me._lblDay_11.TabIndex = 43
        Me._lblDay_11.Text = "-"
        '
        '_picDay_10
        '
        Me._picDay_10.BackColor = System.Drawing.SystemColors.Control
        Me._picDay_10.Controls.Add(Me.lstView11)
        Me._picDay_10.Controls.Add(Me._lblDay_10)
        Me._picDay_10.Cursor = System.Windows.Forms.Cursors.Default
        Me._picDay_10.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._picDay_10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.picDay.SetIndex(Me._picDay_10, CType(10, Short))
        Me._picDay_10.Location = New System.Drawing.Point(272, 147)
        Me._picDay_10.Name = "_picDay_10"
        Me._picDay_10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._picDay_10.Size = New System.Drawing.Size(89, 83)
        Me._picDay_10.TabIndex = 38
        Me._picDay_10.TabStop = True
        '
        'lstView11
        '
        Me.lstView11.Activation = System.Windows.Forms.ItemActivation.TwoClick
        Me.lstView11.BackColor = System.Drawing.SystemColors.Window
        Me.lstView11.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader11})
        Me.lstView11.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstView11.FullRowSelect = True
        Me.lstView11.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lstView11.Location = New System.Drawing.Point(0, 16)
        Me.lstView11.MultiSelect = False
        Me.lstView11.Name = "lstView11"
        Me.lstView11.ShowItemToolTips = True
        Me.lstView11.Size = New System.Drawing.Size(89, 67)
        Me.lstView11.TabIndex = 41
        Me.lstView11.UseCompatibleStateImageBehavior = False
        Me.lstView11.View = System.Windows.Forms.View.Details
        '
        '_lblDay_10
        '
        Me._lblDay_10.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me._lblDay_10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblDay_10.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblDay_10.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblDay_10.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblDay.SetIndex(Me._lblDay_10, CType(10, Short))
        Me._lblDay_10.Location = New System.Drawing.Point(0, 0)
        Me._lblDay_10.Name = "_lblDay_10"
        Me._lblDay_10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblDay_10.Size = New System.Drawing.Size(25, 17)
        Me._lblDay_10.TabIndex = 40
        Me._lblDay_10.Text = "-"
        '
        '_picDay_9
        '
        Me._picDay_9.BackColor = System.Drawing.SystemColors.Control
        Me._picDay_9.Controls.Add(Me.lstView10)
        Me._picDay_9.Controls.Add(Me._lblDay_9)
        Me._picDay_9.Cursor = System.Windows.Forms.Cursors.Default
        Me._picDay_9.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._picDay_9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.picDay.SetIndex(Me._picDay_9, CType(9, Short))
        Me._picDay_9.Location = New System.Drawing.Point(184, 147)
        Me._picDay_9.Name = "_picDay_9"
        Me._picDay_9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._picDay_9.Size = New System.Drawing.Size(89, 83)
        Me._picDay_9.TabIndex = 35
        Me._picDay_9.TabStop = True
        '
        'lstView10
        '
        Me.lstView10.Activation = System.Windows.Forms.ItemActivation.TwoClick
        Me.lstView10.BackColor = System.Drawing.SystemColors.Window
        Me.lstView10.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader10})
        Me.lstView10.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstView10.FullRowSelect = True
        Me.lstView10.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lstView10.Location = New System.Drawing.Point(0, 16)
        Me.lstView10.MultiSelect = False
        Me.lstView10.Name = "lstView10"
        Me.lstView10.ShowItemToolTips = True
        Me.lstView10.Size = New System.Drawing.Size(89, 67)
        Me.lstView10.TabIndex = 38
        Me.lstView10.UseCompatibleStateImageBehavior = False
        Me.lstView10.View = System.Windows.Forms.View.Details
        '
        '_lblDay_9
        '
        Me._lblDay_9.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me._lblDay_9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblDay_9.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblDay_9.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblDay_9.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblDay.SetIndex(Me._lblDay_9, CType(9, Short))
        Me._lblDay_9.Location = New System.Drawing.Point(0, 0)
        Me._lblDay_9.Name = "_lblDay_9"
        Me._lblDay_9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblDay_9.Size = New System.Drawing.Size(25, 17)
        Me._lblDay_9.TabIndex = 37
        Me._lblDay_9.Text = "-"
        '
        '_picDay_8
        '
        Me._picDay_8.BackColor = System.Drawing.SystemColors.Control
        Me._picDay_8.Controls.Add(Me.lstView9)
        Me._picDay_8.Controls.Add(Me._lblDay_8)
        Me._picDay_8.Cursor = System.Windows.Forms.Cursors.Default
        Me._picDay_8.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._picDay_8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.picDay.SetIndex(Me._picDay_8, CType(8, Short))
        Me._picDay_8.Location = New System.Drawing.Point(96, 147)
        Me._picDay_8.Name = "_picDay_8"
        Me._picDay_8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._picDay_8.Size = New System.Drawing.Size(89, 83)
        Me._picDay_8.TabIndex = 32
        Me._picDay_8.TabStop = True
        '
        'lstView9
        '
        Me.lstView9.Activation = System.Windows.Forms.ItemActivation.TwoClick
        Me.lstView9.BackColor = System.Drawing.SystemColors.Window
        Me.lstView9.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader9})
        Me.lstView9.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstView9.FullRowSelect = True
        Me.lstView9.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lstView9.Location = New System.Drawing.Point(0, 16)
        Me.lstView9.MultiSelect = False
        Me.lstView9.Name = "lstView9"
        Me.lstView9.ShowItemToolTips = True
        Me.lstView9.Size = New System.Drawing.Size(89, 67)
        Me.lstView9.TabIndex = 35
        Me.lstView9.UseCompatibleStateImageBehavior = False
        Me.lstView9.View = System.Windows.Forms.View.Details
        '
        '_lblDay_8
        '
        Me._lblDay_8.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me._lblDay_8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblDay_8.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblDay_8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblDay_8.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblDay.SetIndex(Me._lblDay_8, CType(8, Short))
        Me._lblDay_8.Location = New System.Drawing.Point(0, 0)
        Me._lblDay_8.Name = "_lblDay_8"
        Me._lblDay_8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblDay_8.Size = New System.Drawing.Size(25, 17)
        Me._lblDay_8.TabIndex = 34
        Me._lblDay_8.Text = "-"
        '
        '_picDay_7
        '
        Me._picDay_7.BackColor = System.Drawing.SystemColors.Control
        Me._picDay_7.Controls.Add(Me.lstView8)
        Me._picDay_7.Controls.Add(Me._lblDay_7)
        Me._picDay_7.Cursor = System.Windows.Forms.Cursors.Default
        Me._picDay_7.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._picDay_7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.picDay.SetIndex(Me._picDay_7, CType(7, Short))
        Me._picDay_7.Location = New System.Drawing.Point(8, 147)
        Me._picDay_7.Name = "_picDay_7"
        Me._picDay_7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._picDay_7.Size = New System.Drawing.Size(89, 83)
        Me._picDay_7.TabIndex = 29
        Me._picDay_7.TabStop = True
        '
        'lstView8
        '
        Me.lstView8.Activation = System.Windows.Forms.ItemActivation.TwoClick
        Me.lstView8.BackColor = System.Drawing.SystemColors.Window
        Me.lstView8.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader8})
        Me.lstView8.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstView8.FullRowSelect = True
        Me.lstView8.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lstView8.Location = New System.Drawing.Point(0, 16)
        Me.lstView8.MultiSelect = False
        Me.lstView8.Name = "lstView8"
        Me.lstView8.ShowItemToolTips = True
        Me.lstView8.Size = New System.Drawing.Size(89, 67)
        Me.lstView8.TabIndex = 32
        Me.lstView8.UseCompatibleStateImageBehavior = False
        Me.lstView8.View = System.Windows.Forms.View.Details
        '
        '_lblDay_7
        '
        Me._lblDay_7.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me._lblDay_7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblDay_7.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblDay_7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblDay_7.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblDay.SetIndex(Me._lblDay_7, CType(7, Short))
        Me._lblDay_7.Location = New System.Drawing.Point(0, 0)
        Me._lblDay_7.Name = "_lblDay_7"
        Me._lblDay_7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblDay_7.Size = New System.Drawing.Size(25, 17)
        Me._lblDay_7.TabIndex = 31
        Me._lblDay_7.Text = "-"
        '
        '_picDay_20
        '
        Me._picDay_20.BackColor = System.Drawing.SystemColors.Control
        Me._picDay_20.Controls.Add(Me.lstView21)
        Me._picDay_20.Controls.Add(Me._lblDay_20)
        Me._picDay_20.Cursor = System.Windows.Forms.Cursors.Default
        Me._picDay_20.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._picDay_20.ForeColor = System.Drawing.SystemColors.ControlText
        Me.picDay.SetIndex(Me._picDay_20, CType(20, Short))
        Me._picDay_20.Location = New System.Drawing.Point(536, 227)
        Me._picDay_20.Name = "_picDay_20"
        Me._picDay_20.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._picDay_20.Size = New System.Drawing.Size(89, 83)
        Me._picDay_20.TabIndex = 68
        Me._picDay_20.TabStop = True
        '
        'lstView21
        '
        Me.lstView21.Activation = System.Windows.Forms.ItemActivation.TwoClick
        Me.lstView21.BackColor = System.Drawing.SystemColors.Window
        Me.lstView21.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader21})
        Me.lstView21.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstView21.FullRowSelect = True
        Me.lstView21.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lstView21.Location = New System.Drawing.Point(0, 16)
        Me.lstView21.MultiSelect = False
        Me.lstView21.Name = "lstView21"
        Me.lstView21.ShowItemToolTips = True
        Me.lstView21.Size = New System.Drawing.Size(89, 67)
        Me.lstView21.TabIndex = 71
        Me.lstView21.UseCompatibleStateImageBehavior = False
        Me.lstView21.View = System.Windows.Forms.View.Details
        '
        '_lblDay_20
        '
        Me._lblDay_20.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me._lblDay_20.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblDay_20.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblDay_20.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblDay_20.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblDay.SetIndex(Me._lblDay_20, CType(20, Short))
        Me._lblDay_20.Location = New System.Drawing.Point(0, 0)
        Me._lblDay_20.Name = "_lblDay_20"
        Me._lblDay_20.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblDay_20.Size = New System.Drawing.Size(25, 17)
        Me._lblDay_20.TabIndex = 70
        Me._lblDay_20.Text = "-"
        '
        '_picDay_19
        '
        Me._picDay_19.BackColor = System.Drawing.SystemColors.Control
        Me._picDay_19.Controls.Add(Me.lstView20)
        Me._picDay_19.Controls.Add(Me._lblDay_19)
        Me._picDay_19.Cursor = System.Windows.Forms.Cursors.Default
        Me._picDay_19.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._picDay_19.ForeColor = System.Drawing.SystemColors.ControlText
        Me.picDay.SetIndex(Me._picDay_19, CType(19, Short))
        Me._picDay_19.Location = New System.Drawing.Point(448, 227)
        Me._picDay_19.Name = "_picDay_19"
        Me._picDay_19.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._picDay_19.Size = New System.Drawing.Size(89, 83)
        Me._picDay_19.TabIndex = 65
        Me._picDay_19.TabStop = True
        '
        'lstView20
        '
        Me.lstView20.Activation = System.Windows.Forms.ItemActivation.TwoClick
        Me.lstView20.BackColor = System.Drawing.SystemColors.Window
        Me.lstView20.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader20})
        Me.lstView20.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstView20.FullRowSelect = True
        Me.lstView20.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lstView20.Location = New System.Drawing.Point(0, 16)
        Me.lstView20.MultiSelect = False
        Me.lstView20.Name = "lstView20"
        Me.lstView20.ShowItemToolTips = True
        Me.lstView20.Size = New System.Drawing.Size(89, 67)
        Me.lstView20.TabIndex = 68
        Me.lstView20.UseCompatibleStateImageBehavior = False
        Me.lstView20.View = System.Windows.Forms.View.Details
        '
        '_lblDay_19
        '
        Me._lblDay_19.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me._lblDay_19.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblDay_19.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblDay_19.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblDay_19.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblDay.SetIndex(Me._lblDay_19, CType(19, Short))
        Me._lblDay_19.Location = New System.Drawing.Point(0, 0)
        Me._lblDay_19.Name = "_lblDay_19"
        Me._lblDay_19.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblDay_19.Size = New System.Drawing.Size(25, 17)
        Me._lblDay_19.TabIndex = 67
        Me._lblDay_19.Text = "-"
        '
        '_picDay_18
        '
        Me._picDay_18.BackColor = System.Drawing.SystemColors.Control
        Me._picDay_18.Controls.Add(Me.lstView19)
        Me._picDay_18.Controls.Add(Me._lblDay_18)
        Me._picDay_18.Cursor = System.Windows.Forms.Cursors.Default
        Me._picDay_18.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._picDay_18.ForeColor = System.Drawing.SystemColors.ControlText
        Me.picDay.SetIndex(Me._picDay_18, CType(18, Short))
        Me._picDay_18.Location = New System.Drawing.Point(360, 227)
        Me._picDay_18.Name = "_picDay_18"
        Me._picDay_18.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._picDay_18.Size = New System.Drawing.Size(89, 83)
        Me._picDay_18.TabIndex = 62
        Me._picDay_18.TabStop = True
        '
        'lstView19
        '
        Me.lstView19.Activation = System.Windows.Forms.ItemActivation.TwoClick
        Me.lstView19.BackColor = System.Drawing.SystemColors.Window
        Me.lstView19.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader19})
        Me.lstView19.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstView19.FullRowSelect = True
        Me.lstView19.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lstView19.Location = New System.Drawing.Point(0, 16)
        Me.lstView19.MultiSelect = False
        Me.lstView19.Name = "lstView19"
        Me.lstView19.ShowItemToolTips = True
        Me.lstView19.Size = New System.Drawing.Size(89, 67)
        Me.lstView19.TabIndex = 65
        Me.lstView19.UseCompatibleStateImageBehavior = False
        Me.lstView19.View = System.Windows.Forms.View.Details
        '
        '_lblDay_18
        '
        Me._lblDay_18.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me._lblDay_18.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblDay_18.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblDay_18.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblDay_18.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblDay.SetIndex(Me._lblDay_18, CType(18, Short))
        Me._lblDay_18.Location = New System.Drawing.Point(0, 0)
        Me._lblDay_18.Name = "_lblDay_18"
        Me._lblDay_18.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblDay_18.Size = New System.Drawing.Size(25, 17)
        Me._lblDay_18.TabIndex = 64
        Me._lblDay_18.Text = "-"
        '
        '_picDay_17
        '
        Me._picDay_17.BackColor = System.Drawing.SystemColors.Control
        Me._picDay_17.Controls.Add(Me.lstView18)
        Me._picDay_17.Controls.Add(Me._lblDay_17)
        Me._picDay_17.Cursor = System.Windows.Forms.Cursors.Default
        Me._picDay_17.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._picDay_17.ForeColor = System.Drawing.SystemColors.ControlText
        Me.picDay.SetIndex(Me._picDay_17, CType(17, Short))
        Me._picDay_17.Location = New System.Drawing.Point(272, 227)
        Me._picDay_17.Name = "_picDay_17"
        Me._picDay_17.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._picDay_17.Size = New System.Drawing.Size(89, 83)
        Me._picDay_17.TabIndex = 59
        Me._picDay_17.TabStop = True
        '
        'lstView18
        '
        Me.lstView18.Activation = System.Windows.Forms.ItemActivation.TwoClick
        Me.lstView18.BackColor = System.Drawing.SystemColors.Window
        Me.lstView18.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader18})
        Me.lstView18.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstView18.FullRowSelect = True
        Me.lstView18.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lstView18.Location = New System.Drawing.Point(0, 16)
        Me.lstView18.MultiSelect = False
        Me.lstView18.Name = "lstView18"
        Me.lstView18.ShowItemToolTips = True
        Me.lstView18.Size = New System.Drawing.Size(89, 67)
        Me.lstView18.TabIndex = 62
        Me.lstView18.UseCompatibleStateImageBehavior = False
        Me.lstView18.View = System.Windows.Forms.View.Details
        '
        '_lblDay_17
        '
        Me._lblDay_17.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me._lblDay_17.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblDay_17.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblDay_17.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblDay_17.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblDay.SetIndex(Me._lblDay_17, CType(17, Short))
        Me._lblDay_17.Location = New System.Drawing.Point(0, 0)
        Me._lblDay_17.Name = "_lblDay_17"
        Me._lblDay_17.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblDay_17.Size = New System.Drawing.Size(25, 17)
        Me._lblDay_17.TabIndex = 61
        Me._lblDay_17.Text = "-"
        '
        '_picDay_16
        '
        Me._picDay_16.BackColor = System.Drawing.SystemColors.Control
        Me._picDay_16.Controls.Add(Me.lstView17)
        Me._picDay_16.Controls.Add(Me._lblDay_16)
        Me._picDay_16.Cursor = System.Windows.Forms.Cursors.Default
        Me._picDay_16.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._picDay_16.ForeColor = System.Drawing.SystemColors.ControlText
        Me.picDay.SetIndex(Me._picDay_16, CType(16, Short))
        Me._picDay_16.Location = New System.Drawing.Point(184, 227)
        Me._picDay_16.Name = "_picDay_16"
        Me._picDay_16.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._picDay_16.Size = New System.Drawing.Size(89, 83)
        Me._picDay_16.TabIndex = 56
        Me._picDay_16.TabStop = True
        '
        'lstView17
        '
        Me.lstView17.Activation = System.Windows.Forms.ItemActivation.TwoClick
        Me.lstView17.BackColor = System.Drawing.SystemColors.Window
        Me.lstView17.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader17})
        Me.lstView17.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstView17.FullRowSelect = True
        Me.lstView17.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lstView17.Location = New System.Drawing.Point(0, 16)
        Me.lstView17.MultiSelect = False
        Me.lstView17.Name = "lstView17"
        Me.lstView17.ShowItemToolTips = True
        Me.lstView17.Size = New System.Drawing.Size(89, 67)
        Me.lstView17.TabIndex = 59
        Me.lstView17.UseCompatibleStateImageBehavior = False
        Me.lstView17.View = System.Windows.Forms.View.Details
        '
        '_lblDay_16
        '
        Me._lblDay_16.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me._lblDay_16.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblDay_16.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblDay_16.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblDay_16.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblDay.SetIndex(Me._lblDay_16, CType(16, Short))
        Me._lblDay_16.Location = New System.Drawing.Point(0, 0)
        Me._lblDay_16.Name = "_lblDay_16"
        Me._lblDay_16.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblDay_16.Size = New System.Drawing.Size(25, 17)
        Me._lblDay_16.TabIndex = 58
        Me._lblDay_16.Text = "-"
        '
        '_picDay_15
        '
        Me._picDay_15.BackColor = System.Drawing.SystemColors.Control
        Me._picDay_15.Controls.Add(Me.lstView16)
        Me._picDay_15.Controls.Add(Me._lblDay_15)
        Me._picDay_15.Cursor = System.Windows.Forms.Cursors.Default
        Me._picDay_15.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._picDay_15.ForeColor = System.Drawing.SystemColors.ControlText
        Me.picDay.SetIndex(Me._picDay_15, CType(15, Short))
        Me._picDay_15.Location = New System.Drawing.Point(96, 227)
        Me._picDay_15.Name = "_picDay_15"
        Me._picDay_15.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._picDay_15.Size = New System.Drawing.Size(89, 83)
        Me._picDay_15.TabIndex = 53
        Me._picDay_15.TabStop = True
        '
        'lstView16
        '
        Me.lstView16.Activation = System.Windows.Forms.ItemActivation.TwoClick
        Me.lstView16.BackColor = System.Drawing.SystemColors.Window
        Me.lstView16.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader16})
        Me.lstView16.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstView16.FullRowSelect = True
        Me.lstView16.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lstView16.Location = New System.Drawing.Point(0, 16)
        Me.lstView16.MultiSelect = False
        Me.lstView16.Name = "lstView16"
        Me.lstView16.ShowItemToolTips = True
        Me.lstView16.Size = New System.Drawing.Size(89, 67)
        Me.lstView16.TabIndex = 56
        Me.lstView16.UseCompatibleStateImageBehavior = False
        Me.lstView16.View = System.Windows.Forms.View.Details
        '
        '_lblDay_15
        '
        Me._lblDay_15.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me._lblDay_15.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblDay_15.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblDay_15.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblDay_15.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblDay.SetIndex(Me._lblDay_15, CType(15, Short))
        Me._lblDay_15.Location = New System.Drawing.Point(0, 0)
        Me._lblDay_15.Name = "_lblDay_15"
        Me._lblDay_15.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblDay_15.Size = New System.Drawing.Size(25, 17)
        Me._lblDay_15.TabIndex = 55
        Me._lblDay_15.Text = "-"
        '
        '_picDay_14
        '
        Me._picDay_14.BackColor = System.Drawing.SystemColors.Control
        Me._picDay_14.Controls.Add(Me.lstView15)
        Me._picDay_14.Controls.Add(Me._lblDay_14)
        Me._picDay_14.Cursor = System.Windows.Forms.Cursors.Default
        Me._picDay_14.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._picDay_14.ForeColor = System.Drawing.SystemColors.ControlText
        Me.picDay.SetIndex(Me._picDay_14, CType(14, Short))
        Me._picDay_14.Location = New System.Drawing.Point(8, 227)
        Me._picDay_14.Name = "_picDay_14"
        Me._picDay_14.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._picDay_14.Size = New System.Drawing.Size(89, 83)
        Me._picDay_14.TabIndex = 50
        Me._picDay_14.TabStop = True
        '
        'lstView15
        '
        Me.lstView15.Activation = System.Windows.Forms.ItemActivation.TwoClick
        Me.lstView15.BackColor = System.Drawing.SystemColors.Window
        Me.lstView15.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader15})
        Me.lstView15.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstView15.FullRowSelect = True
        Me.lstView15.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lstView15.Location = New System.Drawing.Point(0, 16)
        Me.lstView15.MultiSelect = False
        Me.lstView15.Name = "lstView15"
        Me.lstView15.ShowItemToolTips = True
        Me.lstView15.Size = New System.Drawing.Size(89, 67)
        Me.lstView15.TabIndex = 53
        Me.lstView15.UseCompatibleStateImageBehavior = False
        Me.lstView15.View = System.Windows.Forms.View.Details
        '
        '_lblDay_14
        '
        Me._lblDay_14.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me._lblDay_14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblDay_14.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblDay_14.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblDay_14.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblDay.SetIndex(Me._lblDay_14, CType(14, Short))
        Me._lblDay_14.Location = New System.Drawing.Point(0, 0)
        Me._lblDay_14.Name = "_lblDay_14"
        Me._lblDay_14.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblDay_14.Size = New System.Drawing.Size(25, 17)
        Me._lblDay_14.TabIndex = 52
        Me._lblDay_14.Text = "-"
        '
        '_picDay_27
        '
        Me._picDay_27.BackColor = System.Drawing.SystemColors.Control
        Me._picDay_27.Controls.Add(Me.lstView28)
        Me._picDay_27.Controls.Add(Me._lblDay_27)
        Me._picDay_27.Cursor = System.Windows.Forms.Cursors.Default
        Me._picDay_27.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._picDay_27.ForeColor = System.Drawing.SystemColors.ControlText
        Me.picDay.SetIndex(Me._picDay_27, CType(27, Short))
        Me._picDay_27.Location = New System.Drawing.Point(536, 307)
        Me._picDay_27.Name = "_picDay_27"
        Me._picDay_27.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._picDay_27.Size = New System.Drawing.Size(89, 83)
        Me._picDay_27.TabIndex = 89
        Me._picDay_27.TabStop = True
        '
        'lstView28
        '
        Me.lstView28.Activation = System.Windows.Forms.ItemActivation.TwoClick
        Me.lstView28.BackColor = System.Drawing.SystemColors.Window
        Me.lstView28.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader28})
        Me.lstView28.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstView28.FullRowSelect = True
        Me.lstView28.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lstView28.Location = New System.Drawing.Point(0, 16)
        Me.lstView28.MultiSelect = False
        Me.lstView28.Name = "lstView28"
        Me.lstView28.ShowItemToolTips = True
        Me.lstView28.Size = New System.Drawing.Size(89, 67)
        Me.lstView28.TabIndex = 92
        Me.lstView28.UseCompatibleStateImageBehavior = False
        Me.lstView28.View = System.Windows.Forms.View.Details
        '
        '_lblDay_27
        '
        Me._lblDay_27.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me._lblDay_27.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblDay_27.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblDay_27.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblDay_27.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblDay.SetIndex(Me._lblDay_27, CType(27, Short))
        Me._lblDay_27.Location = New System.Drawing.Point(0, 0)
        Me._lblDay_27.Name = "_lblDay_27"
        Me._lblDay_27.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblDay_27.Size = New System.Drawing.Size(25, 17)
        Me._lblDay_27.TabIndex = 91
        Me._lblDay_27.Text = "-"
        '
        '_picDay_26
        '
        Me._picDay_26.BackColor = System.Drawing.SystemColors.Control
        Me._picDay_26.Controls.Add(Me.lstView27)
        Me._picDay_26.Controls.Add(Me._lblDay_26)
        Me._picDay_26.Cursor = System.Windows.Forms.Cursors.Default
        Me._picDay_26.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._picDay_26.ForeColor = System.Drawing.SystemColors.ControlText
        Me.picDay.SetIndex(Me._picDay_26, CType(26, Short))
        Me._picDay_26.Location = New System.Drawing.Point(448, 307)
        Me._picDay_26.Name = "_picDay_26"
        Me._picDay_26.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._picDay_26.Size = New System.Drawing.Size(89, 83)
        Me._picDay_26.TabIndex = 86
        Me._picDay_26.TabStop = True
        '
        'lstView27
        '
        Me.lstView27.Activation = System.Windows.Forms.ItemActivation.TwoClick
        Me.lstView27.BackColor = System.Drawing.SystemColors.Window
        Me.lstView27.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader27})
        Me.lstView27.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstView27.FullRowSelect = True
        Me.lstView27.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lstView27.Location = New System.Drawing.Point(0, 16)
        Me.lstView27.MultiSelect = False
        Me.lstView27.Name = "lstView27"
        Me.lstView27.ShowItemToolTips = True
        Me.lstView27.Size = New System.Drawing.Size(89, 67)
        Me.lstView27.TabIndex = 89
        Me.lstView27.UseCompatibleStateImageBehavior = False
        Me.lstView27.View = System.Windows.Forms.View.Details
        '
        '_lblDay_26
        '
        Me._lblDay_26.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me._lblDay_26.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblDay_26.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblDay_26.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblDay_26.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblDay.SetIndex(Me._lblDay_26, CType(26, Short))
        Me._lblDay_26.Location = New System.Drawing.Point(0, 0)
        Me._lblDay_26.Name = "_lblDay_26"
        Me._lblDay_26.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblDay_26.Size = New System.Drawing.Size(25, 17)
        Me._lblDay_26.TabIndex = 88
        Me._lblDay_26.Text = "-"
        '
        '_picDay_25
        '
        Me._picDay_25.BackColor = System.Drawing.SystemColors.Control
        Me._picDay_25.Controls.Add(Me.lstView26)
        Me._picDay_25.Controls.Add(Me._lblDay_25)
        Me._picDay_25.Cursor = System.Windows.Forms.Cursors.Default
        Me._picDay_25.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._picDay_25.ForeColor = System.Drawing.SystemColors.ControlText
        Me.picDay.SetIndex(Me._picDay_25, CType(25, Short))
        Me._picDay_25.Location = New System.Drawing.Point(360, 307)
        Me._picDay_25.Name = "_picDay_25"
        Me._picDay_25.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._picDay_25.Size = New System.Drawing.Size(89, 83)
        Me._picDay_25.TabIndex = 83
        Me._picDay_25.TabStop = True
        '
        'lstView26
        '
        Me.lstView26.Activation = System.Windows.Forms.ItemActivation.TwoClick
        Me.lstView26.BackColor = System.Drawing.SystemColors.Window
        Me.lstView26.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader26})
        Me.lstView26.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstView26.FullRowSelect = True
        Me.lstView26.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lstView26.Location = New System.Drawing.Point(0, 16)
        Me.lstView26.MultiSelect = False
        Me.lstView26.Name = "lstView26"
        Me.lstView26.ShowItemToolTips = True
        Me.lstView26.Size = New System.Drawing.Size(89, 67)
        Me.lstView26.TabIndex = 86
        Me.lstView26.UseCompatibleStateImageBehavior = False
        Me.lstView26.View = System.Windows.Forms.View.Details
        '
        '_lblDay_25
        '
        Me._lblDay_25.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me._lblDay_25.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblDay_25.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblDay_25.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblDay_25.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblDay.SetIndex(Me._lblDay_25, CType(25, Short))
        Me._lblDay_25.Location = New System.Drawing.Point(0, 0)
        Me._lblDay_25.Name = "_lblDay_25"
        Me._lblDay_25.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblDay_25.Size = New System.Drawing.Size(25, 17)
        Me._lblDay_25.TabIndex = 85
        Me._lblDay_25.Text = "-"
        '
        '_picDay_24
        '
        Me._picDay_24.BackColor = System.Drawing.SystemColors.Control
        Me._picDay_24.Controls.Add(Me.lstView25)
        Me._picDay_24.Controls.Add(Me._lblDay_24)
        Me._picDay_24.Cursor = System.Windows.Forms.Cursors.Default
        Me._picDay_24.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._picDay_24.ForeColor = System.Drawing.SystemColors.ControlText
        Me.picDay.SetIndex(Me._picDay_24, CType(24, Short))
        Me._picDay_24.Location = New System.Drawing.Point(272, 307)
        Me._picDay_24.Name = "_picDay_24"
        Me._picDay_24.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._picDay_24.Size = New System.Drawing.Size(89, 83)
        Me._picDay_24.TabIndex = 80
        Me._picDay_24.TabStop = True
        '
        'lstView25
        '
        Me.lstView25.Activation = System.Windows.Forms.ItemActivation.TwoClick
        Me.lstView25.BackColor = System.Drawing.SystemColors.Window
        Me.lstView25.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader25})
        Me.lstView25.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstView25.FullRowSelect = True
        Me.lstView25.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lstView25.Location = New System.Drawing.Point(0, 16)
        Me.lstView25.MultiSelect = False
        Me.lstView25.Name = "lstView25"
        Me.lstView25.ShowItemToolTips = True
        Me.lstView25.Size = New System.Drawing.Size(89, 67)
        Me.lstView25.TabIndex = 83
        Me.lstView25.UseCompatibleStateImageBehavior = False
        Me.lstView25.View = System.Windows.Forms.View.Details
        '
        '_lblDay_24
        '
        Me._lblDay_24.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me._lblDay_24.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblDay_24.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblDay_24.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblDay_24.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblDay.SetIndex(Me._lblDay_24, CType(24, Short))
        Me._lblDay_24.Location = New System.Drawing.Point(0, 0)
        Me._lblDay_24.Name = "_lblDay_24"
        Me._lblDay_24.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblDay_24.Size = New System.Drawing.Size(25, 17)
        Me._lblDay_24.TabIndex = 82
        Me._lblDay_24.Text = "-"
        '
        '_picDay_23
        '
        Me._picDay_23.BackColor = System.Drawing.SystemColors.Control
        Me._picDay_23.Controls.Add(Me.lstView24)
        Me._picDay_23.Controls.Add(Me._lblDay_23)
        Me._picDay_23.Cursor = System.Windows.Forms.Cursors.Default
        Me._picDay_23.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._picDay_23.ForeColor = System.Drawing.SystemColors.ControlText
        Me.picDay.SetIndex(Me._picDay_23, CType(23, Short))
        Me._picDay_23.Location = New System.Drawing.Point(184, 307)
        Me._picDay_23.Name = "_picDay_23"
        Me._picDay_23.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._picDay_23.Size = New System.Drawing.Size(89, 83)
        Me._picDay_23.TabIndex = 77
        Me._picDay_23.TabStop = True
        '
        'lstView24
        '
        Me.lstView24.Activation = System.Windows.Forms.ItemActivation.TwoClick
        Me.lstView24.BackColor = System.Drawing.SystemColors.Window
        Me.lstView24.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader24})
        Me.lstView24.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstView24.FullRowSelect = True
        Me.lstView24.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lstView24.Location = New System.Drawing.Point(0, 16)
        Me.lstView24.MultiSelect = False
        Me.lstView24.Name = "lstView24"
        Me.lstView24.ShowItemToolTips = True
        Me.lstView24.Size = New System.Drawing.Size(89, 67)
        Me.lstView24.TabIndex = 80
        Me.lstView24.UseCompatibleStateImageBehavior = False
        Me.lstView24.View = System.Windows.Forms.View.Details
        '
        '_lblDay_23
        '
        Me._lblDay_23.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me._lblDay_23.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblDay_23.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblDay_23.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblDay_23.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblDay.SetIndex(Me._lblDay_23, CType(23, Short))
        Me._lblDay_23.Location = New System.Drawing.Point(0, 0)
        Me._lblDay_23.Name = "_lblDay_23"
        Me._lblDay_23.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblDay_23.Size = New System.Drawing.Size(25, 17)
        Me._lblDay_23.TabIndex = 79
        Me._lblDay_23.Text = "-"
        '
        '_picDay_22
        '
        Me._picDay_22.BackColor = System.Drawing.SystemColors.Control
        Me._picDay_22.Controls.Add(Me.lstView23)
        Me._picDay_22.Controls.Add(Me._lblDay_22)
        Me._picDay_22.Cursor = System.Windows.Forms.Cursors.Default
        Me._picDay_22.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._picDay_22.ForeColor = System.Drawing.SystemColors.ControlText
        Me.picDay.SetIndex(Me._picDay_22, CType(22, Short))
        Me._picDay_22.Location = New System.Drawing.Point(96, 307)
        Me._picDay_22.Name = "_picDay_22"
        Me._picDay_22.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._picDay_22.Size = New System.Drawing.Size(89, 83)
        Me._picDay_22.TabIndex = 74
        Me._picDay_22.TabStop = True
        '
        'lstView23
        '
        Me.lstView23.Activation = System.Windows.Forms.ItemActivation.TwoClick
        Me.lstView23.BackColor = System.Drawing.SystemColors.Window
        Me.lstView23.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader23})
        Me.lstView23.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstView23.FullRowSelect = True
        Me.lstView23.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lstView23.Location = New System.Drawing.Point(0, 16)
        Me.lstView23.MultiSelect = False
        Me.lstView23.Name = "lstView23"
        Me.lstView23.ShowItemToolTips = True
        Me.lstView23.Size = New System.Drawing.Size(89, 67)
        Me.lstView23.TabIndex = 77
        Me.lstView23.UseCompatibleStateImageBehavior = False
        Me.lstView23.View = System.Windows.Forms.View.Details
        '
        '_lblDay_22
        '
        Me._lblDay_22.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me._lblDay_22.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblDay_22.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblDay_22.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblDay_22.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblDay.SetIndex(Me._lblDay_22, CType(22, Short))
        Me._lblDay_22.Location = New System.Drawing.Point(0, 0)
        Me._lblDay_22.Name = "_lblDay_22"
        Me._lblDay_22.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblDay_22.Size = New System.Drawing.Size(25, 17)
        Me._lblDay_22.TabIndex = 76
        Me._lblDay_22.Text = "-"
        '
        '_picDay_21
        '
        Me._picDay_21.BackColor = System.Drawing.SystemColors.Control
        Me._picDay_21.Controls.Add(Me.lstView22)
        Me._picDay_21.Controls.Add(Me._lblDay_21)
        Me._picDay_21.Cursor = System.Windows.Forms.Cursors.Default
        Me._picDay_21.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._picDay_21.ForeColor = System.Drawing.SystemColors.ControlText
        Me.picDay.SetIndex(Me._picDay_21, CType(21, Short))
        Me._picDay_21.Location = New System.Drawing.Point(8, 307)
        Me._picDay_21.Name = "_picDay_21"
        Me._picDay_21.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._picDay_21.Size = New System.Drawing.Size(89, 83)
        Me._picDay_21.TabIndex = 71
        Me._picDay_21.TabStop = True
        '
        'lstView22
        '
        Me.lstView22.Activation = System.Windows.Forms.ItemActivation.TwoClick
        Me.lstView22.BackColor = System.Drawing.SystemColors.Window
        Me.lstView22.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader22})
        Me.lstView22.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstView22.FullRowSelect = True
        Me.lstView22.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lstView22.Location = New System.Drawing.Point(0, 16)
        Me.lstView22.MultiSelect = False
        Me.lstView22.Name = "lstView22"
        Me.lstView22.ShowItemToolTips = True
        Me.lstView22.Size = New System.Drawing.Size(89, 67)
        Me.lstView22.TabIndex = 74
        Me.lstView22.UseCompatibleStateImageBehavior = False
        Me.lstView22.View = System.Windows.Forms.View.Details
        '
        '_lblDay_21
        '
        Me._lblDay_21.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me._lblDay_21.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblDay_21.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblDay_21.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblDay_21.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblDay.SetIndex(Me._lblDay_21, CType(21, Short))
        Me._lblDay_21.Location = New System.Drawing.Point(0, 0)
        Me._lblDay_21.Name = "_lblDay_21"
        Me._lblDay_21.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblDay_21.Size = New System.Drawing.Size(25, 17)
        Me._lblDay_21.TabIndex = 73
        Me._lblDay_21.Text = "-"
        '
        '_picDay_34
        '
        Me._picDay_34.BackColor = System.Drawing.SystemColors.Control
        Me._picDay_34.Controls.Add(Me.lstView35)
        Me._picDay_34.Controls.Add(Me._lblDay_34)
        Me._picDay_34.Cursor = System.Windows.Forms.Cursors.Default
        Me._picDay_34.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._picDay_34.ForeColor = System.Drawing.SystemColors.ControlText
        Me.picDay.SetIndex(Me._picDay_34, CType(34, Short))
        Me._picDay_34.Location = New System.Drawing.Point(536, 387)
        Me._picDay_34.Name = "_picDay_34"
        Me._picDay_34.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._picDay_34.Size = New System.Drawing.Size(89, 83)
        Me._picDay_34.TabIndex = 110
        Me._picDay_34.TabStop = True
        '
        'lstView35
        '
        Me.lstView35.Activation = System.Windows.Forms.ItemActivation.TwoClick
        Me.lstView35.BackColor = System.Drawing.SystemColors.Window
        Me.lstView35.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader35})
        Me.lstView35.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstView35.FullRowSelect = True
        Me.lstView35.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lstView35.Location = New System.Drawing.Point(0, 16)
        Me.lstView35.MultiSelect = False
        Me.lstView35.Name = "lstView35"
        Me.lstView35.ShowItemToolTips = True
        Me.lstView35.Size = New System.Drawing.Size(89, 67)
        Me.lstView35.TabIndex = 113
        Me.lstView35.UseCompatibleStateImageBehavior = False
        Me.lstView35.View = System.Windows.Forms.View.Details
        '
        '_lblDay_34
        '
        Me._lblDay_34.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me._lblDay_34.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblDay_34.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblDay_34.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblDay_34.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblDay.SetIndex(Me._lblDay_34, CType(34, Short))
        Me._lblDay_34.Location = New System.Drawing.Point(0, 0)
        Me._lblDay_34.Name = "_lblDay_34"
        Me._lblDay_34.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblDay_34.Size = New System.Drawing.Size(25, 17)
        Me._lblDay_34.TabIndex = 112
        Me._lblDay_34.Text = "-"
        '
        '_picDay_33
        '
        Me._picDay_33.BackColor = System.Drawing.SystemColors.Control
        Me._picDay_33.Controls.Add(Me.lstView34)
        Me._picDay_33.Controls.Add(Me._lblDay_33)
        Me._picDay_33.Cursor = System.Windows.Forms.Cursors.Default
        Me._picDay_33.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._picDay_33.ForeColor = System.Drawing.SystemColors.ControlText
        Me.picDay.SetIndex(Me._picDay_33, CType(33, Short))
        Me._picDay_33.Location = New System.Drawing.Point(448, 387)
        Me._picDay_33.Name = "_picDay_33"
        Me._picDay_33.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._picDay_33.Size = New System.Drawing.Size(89, 83)
        Me._picDay_33.TabIndex = 107
        Me._picDay_33.TabStop = True
        '
        'lstView34
        '
        Me.lstView34.Activation = System.Windows.Forms.ItemActivation.TwoClick
        Me.lstView34.BackColor = System.Drawing.SystemColors.Window
        Me.lstView34.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader34})
        Me.lstView34.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstView34.FullRowSelect = True
        Me.lstView34.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lstView34.Location = New System.Drawing.Point(0, 16)
        Me.lstView34.MultiSelect = False
        Me.lstView34.Name = "lstView34"
        Me.lstView34.ShowItemToolTips = True
        Me.lstView34.Size = New System.Drawing.Size(89, 67)
        Me.lstView34.TabIndex = 110
        Me.lstView34.UseCompatibleStateImageBehavior = False
        Me.lstView34.View = System.Windows.Forms.View.Details
        '
        '_lblDay_33
        '
        Me._lblDay_33.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me._lblDay_33.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblDay_33.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblDay_33.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblDay_33.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblDay.SetIndex(Me._lblDay_33, CType(33, Short))
        Me._lblDay_33.Location = New System.Drawing.Point(0, 0)
        Me._lblDay_33.Name = "_lblDay_33"
        Me._lblDay_33.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblDay_33.Size = New System.Drawing.Size(25, 17)
        Me._lblDay_33.TabIndex = 109
        Me._lblDay_33.Text = "-"
        '
        '_picDay_32
        '
        Me._picDay_32.BackColor = System.Drawing.SystemColors.Control
        Me._picDay_32.Controls.Add(Me.lstView33)
        Me._picDay_32.Controls.Add(Me._lblDay_32)
        Me._picDay_32.Cursor = System.Windows.Forms.Cursors.Default
        Me._picDay_32.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._picDay_32.ForeColor = System.Drawing.SystemColors.ControlText
        Me.picDay.SetIndex(Me._picDay_32, CType(32, Short))
        Me._picDay_32.Location = New System.Drawing.Point(360, 387)
        Me._picDay_32.Name = "_picDay_32"
        Me._picDay_32.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._picDay_32.Size = New System.Drawing.Size(89, 83)
        Me._picDay_32.TabIndex = 104
        Me._picDay_32.TabStop = True
        '
        'lstView33
        '
        Me.lstView33.Activation = System.Windows.Forms.ItemActivation.TwoClick
        Me.lstView33.BackColor = System.Drawing.SystemColors.Window
        Me.lstView33.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader33})
        Me.lstView33.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstView33.FullRowSelect = True
        Me.lstView33.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lstView33.Location = New System.Drawing.Point(0, 16)
        Me.lstView33.MultiSelect = False
        Me.lstView33.Name = "lstView33"
        Me.lstView33.ShowItemToolTips = True
        Me.lstView33.Size = New System.Drawing.Size(89, 67)
        Me.lstView33.TabIndex = 107
        Me.lstView33.UseCompatibleStateImageBehavior = False
        Me.lstView33.View = System.Windows.Forms.View.Details
        '
        '_lblDay_32
        '
        Me._lblDay_32.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me._lblDay_32.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblDay_32.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblDay_32.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblDay_32.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblDay.SetIndex(Me._lblDay_32, CType(32, Short))
        Me._lblDay_32.Location = New System.Drawing.Point(0, 0)
        Me._lblDay_32.Name = "_lblDay_32"
        Me._lblDay_32.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblDay_32.Size = New System.Drawing.Size(25, 17)
        Me._lblDay_32.TabIndex = 106
        Me._lblDay_32.Text = "-"
        '
        '_picDay_31
        '
        Me._picDay_31.BackColor = System.Drawing.SystemColors.Control
        Me._picDay_31.Controls.Add(Me.lstView32)
        Me._picDay_31.Controls.Add(Me._lblDay_31)
        Me._picDay_31.Cursor = System.Windows.Forms.Cursors.Default
        Me._picDay_31.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._picDay_31.ForeColor = System.Drawing.SystemColors.ControlText
        Me.picDay.SetIndex(Me._picDay_31, CType(31, Short))
        Me._picDay_31.Location = New System.Drawing.Point(272, 387)
        Me._picDay_31.Name = "_picDay_31"
        Me._picDay_31.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._picDay_31.Size = New System.Drawing.Size(89, 83)
        Me._picDay_31.TabIndex = 101
        Me._picDay_31.TabStop = True
        '
        'lstView32
        '
        Me.lstView32.Activation = System.Windows.Forms.ItemActivation.TwoClick
        Me.lstView32.BackColor = System.Drawing.SystemColors.Window
        Me.lstView32.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader32})
        Me.lstView32.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstView32.FullRowSelect = True
        Me.lstView32.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lstView32.Location = New System.Drawing.Point(0, 16)
        Me.lstView32.MultiSelect = False
        Me.lstView32.Name = "lstView32"
        Me.lstView32.ShowItemToolTips = True
        Me.lstView32.Size = New System.Drawing.Size(89, 67)
        Me.lstView32.TabIndex = 104
        Me.lstView32.UseCompatibleStateImageBehavior = False
        Me.lstView32.View = System.Windows.Forms.View.Details
        '
        '_lblDay_31
        '
        Me._lblDay_31.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me._lblDay_31.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblDay_31.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblDay_31.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblDay_31.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblDay.SetIndex(Me._lblDay_31, CType(31, Short))
        Me._lblDay_31.Location = New System.Drawing.Point(0, 0)
        Me._lblDay_31.Name = "_lblDay_31"
        Me._lblDay_31.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblDay_31.Size = New System.Drawing.Size(25, 17)
        Me._lblDay_31.TabIndex = 103
        Me._lblDay_31.Text = "-"
        '
        '_picDay_30
        '
        Me._picDay_30.BackColor = System.Drawing.SystemColors.Control
        Me._picDay_30.Controls.Add(Me.lstView31)
        Me._picDay_30.Controls.Add(Me._lblDay_30)
        Me._picDay_30.Cursor = System.Windows.Forms.Cursors.Default
        Me._picDay_30.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._picDay_30.ForeColor = System.Drawing.SystemColors.ControlText
        Me.picDay.SetIndex(Me._picDay_30, CType(30, Short))
        Me._picDay_30.Location = New System.Drawing.Point(184, 387)
        Me._picDay_30.Name = "_picDay_30"
        Me._picDay_30.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._picDay_30.Size = New System.Drawing.Size(89, 83)
        Me._picDay_30.TabIndex = 98
        Me._picDay_30.TabStop = True
        '
        'lstView31
        '
        Me.lstView31.Activation = System.Windows.Forms.ItemActivation.TwoClick
        Me.lstView31.BackColor = System.Drawing.SystemColors.Window
        Me.lstView31.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader31})
        Me.lstView31.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstView31.FullRowSelect = True
        Me.lstView31.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lstView31.Location = New System.Drawing.Point(0, 16)
        Me.lstView31.MultiSelect = False
        Me.lstView31.Name = "lstView31"
        Me.lstView31.ShowItemToolTips = True
        Me.lstView31.Size = New System.Drawing.Size(89, 67)
        Me.lstView31.TabIndex = 101
        Me.lstView31.UseCompatibleStateImageBehavior = False
        Me.lstView31.View = System.Windows.Forms.View.Details
        '
        '_lblDay_30
        '
        Me._lblDay_30.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me._lblDay_30.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblDay_30.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblDay_30.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblDay_30.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblDay.SetIndex(Me._lblDay_30, CType(30, Short))
        Me._lblDay_30.Location = New System.Drawing.Point(0, 0)
        Me._lblDay_30.Name = "_lblDay_30"
        Me._lblDay_30.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblDay_30.Size = New System.Drawing.Size(25, 17)
        Me._lblDay_30.TabIndex = 100
        Me._lblDay_30.Text = "-"
        '
        '_picDay_29
        '
        Me._picDay_29.BackColor = System.Drawing.SystemColors.Control
        Me._picDay_29.Controls.Add(Me.lstView30)
        Me._picDay_29.Controls.Add(Me._lblDay_29)
        Me._picDay_29.Cursor = System.Windows.Forms.Cursors.Default
        Me._picDay_29.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._picDay_29.ForeColor = System.Drawing.SystemColors.ControlText
        Me.picDay.SetIndex(Me._picDay_29, CType(29, Short))
        Me._picDay_29.Location = New System.Drawing.Point(96, 387)
        Me._picDay_29.Name = "_picDay_29"
        Me._picDay_29.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._picDay_29.Size = New System.Drawing.Size(89, 83)
        Me._picDay_29.TabIndex = 95
        Me._picDay_29.TabStop = True
        '
        'lstView30
        '
        Me.lstView30.Activation = System.Windows.Forms.ItemActivation.TwoClick
        Me.lstView30.BackColor = System.Drawing.SystemColors.Window
        Me.lstView30.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader30})
        Me.lstView30.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstView30.FullRowSelect = True
        Me.lstView30.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lstView30.Location = New System.Drawing.Point(0, 16)
        Me.lstView30.MultiSelect = False
        Me.lstView30.Name = "lstView30"
        Me.lstView30.ShowItemToolTips = True
        Me.lstView30.Size = New System.Drawing.Size(89, 67)
        Me.lstView30.TabIndex = 98
        Me.lstView30.UseCompatibleStateImageBehavior = False
        Me.lstView30.View = System.Windows.Forms.View.Details
        '
        '_lblDay_29
        '
        Me._lblDay_29.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me._lblDay_29.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblDay_29.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblDay_29.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblDay_29.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblDay.SetIndex(Me._lblDay_29, CType(29, Short))
        Me._lblDay_29.Location = New System.Drawing.Point(0, 0)
        Me._lblDay_29.Name = "_lblDay_29"
        Me._lblDay_29.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblDay_29.Size = New System.Drawing.Size(25, 17)
        Me._lblDay_29.TabIndex = 97
        Me._lblDay_29.Text = "-"
        '
        '_picDay_28
        '
        Me._picDay_28.BackColor = System.Drawing.SystemColors.Control
        Me._picDay_28.Controls.Add(Me.lstView29)
        Me._picDay_28.Controls.Add(Me._lblDay_28)
        Me._picDay_28.Cursor = System.Windows.Forms.Cursors.Default
        Me._picDay_28.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._picDay_28.ForeColor = System.Drawing.SystemColors.ControlText
        Me.picDay.SetIndex(Me._picDay_28, CType(28, Short))
        Me._picDay_28.Location = New System.Drawing.Point(8, 387)
        Me._picDay_28.Name = "_picDay_28"
        Me._picDay_28.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._picDay_28.Size = New System.Drawing.Size(89, 83)
        Me._picDay_28.TabIndex = 92
        Me._picDay_28.TabStop = True
        '
        'lstView29
        '
        Me.lstView29.Activation = System.Windows.Forms.ItemActivation.TwoClick
        Me.lstView29.BackColor = System.Drawing.SystemColors.Window
        Me.lstView29.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader29})
        Me.lstView29.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstView29.FullRowSelect = True
        Me.lstView29.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lstView29.Location = New System.Drawing.Point(0, 16)
        Me.lstView29.MultiSelect = False
        Me.lstView29.Name = "lstView29"
        Me.lstView29.ShowItemToolTips = True
        Me.lstView29.Size = New System.Drawing.Size(89, 67)
        Me.lstView29.TabIndex = 95
        Me.lstView29.UseCompatibleStateImageBehavior = False
        Me.lstView29.View = System.Windows.Forms.View.Details
        '
        '_lblDay_28
        '
        Me._lblDay_28.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me._lblDay_28.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblDay_28.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblDay_28.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblDay_28.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblDay.SetIndex(Me._lblDay_28, CType(28, Short))
        Me._lblDay_28.Location = New System.Drawing.Point(0, 0)
        Me._lblDay_28.Name = "_lblDay_28"
        Me._lblDay_28.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblDay_28.Size = New System.Drawing.Size(25, 17)
        Me._lblDay_28.TabIndex = 94
        Me._lblDay_28.Text = "-"
        '
        '_picDay_41
        '
        Me._picDay_41.BackColor = System.Drawing.SystemColors.Control
        Me._picDay_41.Controls.Add(Me.lstView42)
        Me._picDay_41.Controls.Add(Me._lblDay_41)
        Me._picDay_41.Cursor = System.Windows.Forms.Cursors.Default
        Me._picDay_41.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._picDay_41.ForeColor = System.Drawing.SystemColors.ControlText
        Me.picDay.SetIndex(Me._picDay_41, CType(41, Short))
        Me._picDay_41.Location = New System.Drawing.Point(536, 475)
        Me._picDay_41.Name = "_picDay_41"
        Me._picDay_41.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._picDay_41.Size = New System.Drawing.Size(89, 83)
        Me._picDay_41.TabIndex = 114
        Me._picDay_41.TabStop = True
        '
        'lstView42
        '
        Me.lstView42.Activation = System.Windows.Forms.ItemActivation.TwoClick
        Me.lstView42.BackColor = System.Drawing.SystemColors.Window
        Me.lstView42.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader42})
        Me.lstView42.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstView42.FullRowSelect = True
        Me.lstView42.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lstView42.Location = New System.Drawing.Point(0, 16)
        Me.lstView42.MultiSelect = False
        Me.lstView42.Name = "lstView42"
        Me.lstView42.ShowItemToolTips = True
        Me.lstView42.Size = New System.Drawing.Size(89, 67)
        Me.lstView42.TabIndex = 117
        Me.lstView42.UseCompatibleStateImageBehavior = False
        Me.lstView42.View = System.Windows.Forms.View.Details
        '
        '_lblDay_41
        '
        Me._lblDay_41.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me._lblDay_41.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblDay_41.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblDay_41.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblDay_41.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblDay.SetIndex(Me._lblDay_41, CType(41, Short))
        Me._lblDay_41.Location = New System.Drawing.Point(0, 0)
        Me._lblDay_41.Name = "_lblDay_41"
        Me._lblDay_41.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblDay_41.Size = New System.Drawing.Size(25, 17)
        Me._lblDay_41.TabIndex = 116
        Me._lblDay_41.Text = "-"
        '
        '_picDay_40
        '
        Me._picDay_40.BackColor = System.Drawing.SystemColors.Control
        Me._picDay_40.Controls.Add(Me.lstView41)
        Me._picDay_40.Controls.Add(Me._lblDay_40)
        Me._picDay_40.Cursor = System.Windows.Forms.Cursors.Default
        Me._picDay_40.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._picDay_40.ForeColor = System.Drawing.SystemColors.ControlText
        Me.picDay.SetIndex(Me._picDay_40, CType(40, Short))
        Me._picDay_40.Location = New System.Drawing.Point(448, 475)
        Me._picDay_40.Name = "_picDay_40"
        Me._picDay_40.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._picDay_40.Size = New System.Drawing.Size(89, 83)
        Me._picDay_40.TabIndex = 117
        Me._picDay_40.TabStop = True
        '
        'lstView41
        '
        Me.lstView41.Activation = System.Windows.Forms.ItemActivation.TwoClick
        Me.lstView41.BackColor = System.Drawing.SystemColors.Window
        Me.lstView41.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader41})
        Me.lstView41.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstView41.FullRowSelect = True
        Me.lstView41.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lstView41.Location = New System.Drawing.Point(0, 16)
        Me.lstView41.MultiSelect = False
        Me.lstView41.Name = "lstView41"
        Me.lstView41.ShowItemToolTips = True
        Me.lstView41.Size = New System.Drawing.Size(89, 67)
        Me.lstView41.TabIndex = 120
        Me.lstView41.UseCompatibleStateImageBehavior = False
        Me.lstView41.View = System.Windows.Forms.View.Details
        '
        '_lblDay_40
        '
        Me._lblDay_40.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me._lblDay_40.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblDay_40.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblDay_40.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblDay_40.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblDay.SetIndex(Me._lblDay_40, CType(40, Short))
        Me._lblDay_40.Location = New System.Drawing.Point(0, 0)
        Me._lblDay_40.Name = "_lblDay_40"
        Me._lblDay_40.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblDay_40.Size = New System.Drawing.Size(25, 17)
        Me._lblDay_40.TabIndex = 119
        Me._lblDay_40.Text = "-"
        '
        '_picDay_39
        '
        Me._picDay_39.BackColor = System.Drawing.SystemColors.Control
        Me._picDay_39.Controls.Add(Me.lstView40)
        Me._picDay_39.Controls.Add(Me._lblDay_39)
        Me._picDay_39.Cursor = System.Windows.Forms.Cursors.Default
        Me._picDay_39.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._picDay_39.ForeColor = System.Drawing.SystemColors.ControlText
        Me.picDay.SetIndex(Me._picDay_39, CType(39, Short))
        Me._picDay_39.Location = New System.Drawing.Point(360, 475)
        Me._picDay_39.Name = "_picDay_39"
        Me._picDay_39.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._picDay_39.Size = New System.Drawing.Size(89, 83)
        Me._picDay_39.TabIndex = 120
        Me._picDay_39.TabStop = True
        '
        'lstView40
        '
        Me.lstView40.Activation = System.Windows.Forms.ItemActivation.TwoClick
        Me.lstView40.BackColor = System.Drawing.SystemColors.Window
        Me.lstView40.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader40})
        Me.lstView40.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstView40.FullRowSelect = True
        Me.lstView40.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lstView40.Location = New System.Drawing.Point(0, 16)
        Me.lstView40.MultiSelect = False
        Me.lstView40.Name = "lstView40"
        Me.lstView40.ShowItemToolTips = True
        Me.lstView40.Size = New System.Drawing.Size(89, 67)
        Me.lstView40.TabIndex = 123
        Me.lstView40.UseCompatibleStateImageBehavior = False
        Me.lstView40.View = System.Windows.Forms.View.Details
        '
        '_lblDay_39
        '
        Me._lblDay_39.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me._lblDay_39.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblDay_39.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblDay_39.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblDay_39.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblDay.SetIndex(Me._lblDay_39, CType(39, Short))
        Me._lblDay_39.Location = New System.Drawing.Point(0, 0)
        Me._lblDay_39.Name = "_lblDay_39"
        Me._lblDay_39.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblDay_39.Size = New System.Drawing.Size(25, 17)
        Me._lblDay_39.TabIndex = 122
        Me._lblDay_39.Text = "-"
        '
        '_picDay_38
        '
        Me._picDay_38.BackColor = System.Drawing.SystemColors.Control
        Me._picDay_38.Controls.Add(Me.lstView39)
        Me._picDay_38.Controls.Add(Me._lblDay_38)
        Me._picDay_38.Cursor = System.Windows.Forms.Cursors.Default
        Me._picDay_38.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._picDay_38.ForeColor = System.Drawing.SystemColors.ControlText
        Me.picDay.SetIndex(Me._picDay_38, CType(38, Short))
        Me._picDay_38.Location = New System.Drawing.Point(272, 475)
        Me._picDay_38.Name = "_picDay_38"
        Me._picDay_38.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._picDay_38.Size = New System.Drawing.Size(89, 83)
        Me._picDay_38.TabIndex = 123
        Me._picDay_38.TabStop = True
        '
        'lstView39
        '
        Me.lstView39.Activation = System.Windows.Forms.ItemActivation.TwoClick
        Me.lstView39.BackColor = System.Drawing.SystemColors.Window
        Me.lstView39.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader39})
        Me.lstView39.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstView39.FullRowSelect = True
        Me.lstView39.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lstView39.Location = New System.Drawing.Point(0, 16)
        Me.lstView39.MultiSelect = False
        Me.lstView39.Name = "lstView39"
        Me.lstView39.ShowItemToolTips = True
        Me.lstView39.Size = New System.Drawing.Size(89, 67)
        Me.lstView39.TabIndex = 126
        Me.lstView39.UseCompatibleStateImageBehavior = False
        Me.lstView39.View = System.Windows.Forms.View.Details
        '
        '_lblDay_38
        '
        Me._lblDay_38.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me._lblDay_38.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblDay_38.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblDay_38.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblDay_38.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblDay.SetIndex(Me._lblDay_38, CType(38, Short))
        Me._lblDay_38.Location = New System.Drawing.Point(0, 0)
        Me._lblDay_38.Name = "_lblDay_38"
        Me._lblDay_38.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblDay_38.Size = New System.Drawing.Size(25, 17)
        Me._lblDay_38.TabIndex = 125
        Me._lblDay_38.Text = "-"
        '
        '_picDay_37
        '
        Me._picDay_37.BackColor = System.Drawing.SystemColors.Control
        Me._picDay_37.Controls.Add(Me.lstView38)
        Me._picDay_37.Controls.Add(Me._lblDay_37)
        Me._picDay_37.Cursor = System.Windows.Forms.Cursors.Default
        Me._picDay_37.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._picDay_37.ForeColor = System.Drawing.SystemColors.ControlText
        Me.picDay.SetIndex(Me._picDay_37, CType(37, Short))
        Me._picDay_37.Location = New System.Drawing.Point(184, 475)
        Me._picDay_37.Name = "_picDay_37"
        Me._picDay_37.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._picDay_37.Size = New System.Drawing.Size(89, 83)
        Me._picDay_37.TabIndex = 126
        Me._picDay_37.TabStop = True
        '
        'lstView38
        '
        Me.lstView38.Activation = System.Windows.Forms.ItemActivation.TwoClick
        Me.lstView38.BackColor = System.Drawing.SystemColors.Window
        Me.lstView38.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader38})
        Me.lstView38.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstView38.FullRowSelect = True
        Me.lstView38.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lstView38.Location = New System.Drawing.Point(0, 16)
        Me.lstView38.MultiSelect = False
        Me.lstView38.Name = "lstView38"
        Me.lstView38.ShowItemToolTips = True
        Me.lstView38.Size = New System.Drawing.Size(89, 67)
        Me.lstView38.TabIndex = 129
        Me.lstView38.UseCompatibleStateImageBehavior = False
        Me.lstView38.View = System.Windows.Forms.View.Details
        '
        '_lblDay_37
        '
        Me._lblDay_37.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me._lblDay_37.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblDay_37.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblDay_37.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblDay_37.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblDay.SetIndex(Me._lblDay_37, CType(37, Short))
        Me._lblDay_37.Location = New System.Drawing.Point(0, 0)
        Me._lblDay_37.Name = "_lblDay_37"
        Me._lblDay_37.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblDay_37.Size = New System.Drawing.Size(25, 17)
        Me._lblDay_37.TabIndex = 128
        Me._lblDay_37.Text = "-"
        '
        '_picDay_36
        '
        Me._picDay_36.BackColor = System.Drawing.SystemColors.Control
        Me._picDay_36.Controls.Add(Me.lstView37)
        Me._picDay_36.Controls.Add(Me._lblDay_36)
        Me._picDay_36.Cursor = System.Windows.Forms.Cursors.Default
        Me._picDay_36.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._picDay_36.ForeColor = System.Drawing.SystemColors.ControlText
        Me.picDay.SetIndex(Me._picDay_36, CType(36, Short))
        Me._picDay_36.Location = New System.Drawing.Point(96, 475)
        Me._picDay_36.Name = "_picDay_36"
        Me._picDay_36.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._picDay_36.Size = New System.Drawing.Size(89, 83)
        Me._picDay_36.TabIndex = 129
        Me._picDay_36.TabStop = True
        '
        'lstView37
        '
        Me.lstView37.Activation = System.Windows.Forms.ItemActivation.TwoClick
        Me.lstView37.BackColor = System.Drawing.SystemColors.Window
        Me.lstView37.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader37})
        Me.lstView37.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstView37.FullRowSelect = True
        Me.lstView37.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lstView37.Location = New System.Drawing.Point(0, 16)
        Me.lstView37.MultiSelect = False
        Me.lstView37.Name = "lstView37"
        Me.lstView37.ShowItemToolTips = True
        Me.lstView37.Size = New System.Drawing.Size(89, 67)
        Me.lstView37.TabIndex = 132
        Me.lstView37.UseCompatibleStateImageBehavior = False
        Me.lstView37.View = System.Windows.Forms.View.Details
        '
        '_lblDay_36
        '
        Me._lblDay_36.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me._lblDay_36.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblDay_36.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblDay_36.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblDay_36.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblDay.SetIndex(Me._lblDay_36, CType(36, Short))
        Me._lblDay_36.Location = New System.Drawing.Point(0, 0)
        Me._lblDay_36.Name = "_lblDay_36"
        Me._lblDay_36.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblDay_36.Size = New System.Drawing.Size(25, 17)
        Me._lblDay_36.TabIndex = 131
        Me._lblDay_36.Text = "-"
        '
        '_picDay_35
        '
        Me._picDay_35.BackColor = System.Drawing.SystemColors.Control
        Me._picDay_35.Controls.Add(Me.lstView36)
        Me._picDay_35.Controls.Add(Me._lblDay_35)
        Me._picDay_35.Cursor = System.Windows.Forms.Cursors.Default
        Me._picDay_35.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._picDay_35.ForeColor = System.Drawing.SystemColors.ControlText
        Me.picDay.SetIndex(Me._picDay_35, CType(35, Short))
        Me._picDay_35.Location = New System.Drawing.Point(8, 475)
        Me._picDay_35.Name = "_picDay_35"
        Me._picDay_35.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._picDay_35.Size = New System.Drawing.Size(89, 83)
        Me._picDay_35.TabIndex = 132
        Me._picDay_35.TabStop = True
        '
        'lstView36
        '
        Me.lstView36.Activation = System.Windows.Forms.ItemActivation.TwoClick
        Me.lstView36.BackColor = System.Drawing.SystemColors.Window
        Me.lstView36.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader36})
        Me.lstView36.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstView36.FullRowSelect = True
        Me.lstView36.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lstView36.Location = New System.Drawing.Point(0, 16)
        Me.lstView36.MultiSelect = False
        Me.lstView36.Name = "lstView36"
        Me.lstView36.ShowItemToolTips = True
        Me.lstView36.Size = New System.Drawing.Size(89, 67)
        Me.lstView36.TabIndex = 135
        Me.lstView36.UseCompatibleStateImageBehavior = False
        Me.lstView36.View = System.Windows.Forms.View.Details
        '
        '_lblDay_35
        '
        Me._lblDay_35.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me._lblDay_35.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblDay_35.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblDay_35.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblDay_35.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblDay.SetIndex(Me._lblDay_35, CType(35, Short))
        Me._lblDay_35.Location = New System.Drawing.Point(0, 0)
        Me._lblDay_35.Name = "_lblDay_35"
        Me._lblDay_35.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblDay_35.Size = New System.Drawing.Size(25, 17)
        Me._lblDay_35.TabIndex = 134
        Me._lblDay_35.Text = "-"
        '
        'lblSaturday
        '
        Me.lblSaturday.BackColor = System.Drawing.SystemColors.Highlight
        Me.lblSaturday.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblSaturday.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblSaturday.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSaturday.ForeColor = System.Drawing.Color.White
        Me.lblSaturday.Location = New System.Drawing.Point(536, 40)
        Me.lblSaturday.Name = "lblSaturday"
        Me.lblSaturday.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblSaturday.Size = New System.Drawing.Size(89, 17)
        Me.lblSaturday.TabIndex = 7
        Me.lblSaturday.Text = "Sat"
        Me.lblSaturday.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblFriday
        '
        Me.lblFriday.BackColor = System.Drawing.SystemColors.Highlight
        Me.lblFriday.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFriday.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblFriday.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFriday.ForeColor = System.Drawing.Color.White
        Me.lblFriday.Location = New System.Drawing.Point(448, 40)
        Me.lblFriday.Name = "lblFriday"
        Me.lblFriday.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblFriday.Size = New System.Drawing.Size(89, 17)
        Me.lblFriday.TabIndex = 6
        Me.lblFriday.Text = "Fri"
        Me.lblFriday.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblThursday
        '
        Me.lblThursday.BackColor = System.Drawing.SystemColors.Highlight
        Me.lblThursday.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblThursday.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblThursday.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblThursday.ForeColor = System.Drawing.Color.White
        Me.lblThursday.Location = New System.Drawing.Point(360, 40)
        Me.lblThursday.Name = "lblThursday"
        Me.lblThursday.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblThursday.Size = New System.Drawing.Size(89, 17)
        Me.lblThursday.TabIndex = 5
        Me.lblThursday.Text = "Thu"
        Me.lblThursday.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblWednesday
        '
        Me.lblWednesday.BackColor = System.Drawing.SystemColors.Highlight
        Me.lblWednesday.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblWednesday.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblWednesday.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWednesday.ForeColor = System.Drawing.Color.White
        Me.lblWednesday.Location = New System.Drawing.Point(272, 40)
        Me.lblWednesday.Name = "lblWednesday"
        Me.lblWednesday.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblWednesday.Size = New System.Drawing.Size(89, 17)
        Me.lblWednesday.TabIndex = 4
        Me.lblWednesday.Text = "Wed"
        Me.lblWednesday.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTuesday
        '
        Me.lblTuesday.BackColor = System.Drawing.SystemColors.Highlight
        Me.lblTuesday.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTuesday.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblTuesday.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTuesday.ForeColor = System.Drawing.Color.White
        Me.lblTuesday.Location = New System.Drawing.Point(184, 40)
        Me.lblTuesday.Name = "lblTuesday"
        Me.lblTuesday.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblTuesday.Size = New System.Drawing.Size(89, 17)
        Me.lblTuesday.TabIndex = 3
        Me.lblTuesday.Text = "Tue"
        Me.lblTuesday.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblMonday
        '
        Me.lblMonday.BackColor = System.Drawing.SystemColors.Highlight
        Me.lblMonday.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblMonday.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblMonday.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMonday.ForeColor = System.Drawing.Color.White
        Me.lblMonday.Location = New System.Drawing.Point(96, 40)
        Me.lblMonday.Name = "lblMonday"
        Me.lblMonday.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblMonday.Size = New System.Drawing.Size(89, 17)
        Me.lblMonday.TabIndex = 2
        Me.lblMonday.Text = "Mon"
        Me.lblMonday.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblSunday
        '
        Me.lblSunday.BackColor = System.Drawing.SystemColors.Highlight
        Me.lblSunday.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblSunday.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblSunday.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSunday.ForeColor = System.Drawing.Color.White
        Me.lblSunday.Location = New System.Drawing.Point(8, 40)
        Me.lblSunday.Name = "lblSunday"
        Me.lblSunday.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblSunday.Size = New System.Drawing.Size(89, 17)
        Me.lblSunday.TabIndex = 1
        Me.lblSunday.Text = "Sun"
        Me.lblSunday.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'picDay
        '
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "")
        '
        'HeaderPanel
        '
        Me.HeaderPanel.Controls.Add(Me.Panel1)
        Me.HeaderPanel.Controls.Add(Me.Panel2)
        Me.HeaderPanel.Location = New System.Drawing.Point(8, 0)
        Me.HeaderPanel.Name = "HeaderPanel"
        Me.HeaderPanel.Size = New System.Drawing.Size(616, 32)
        Me.HeaderPanel.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.HeaderLable)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(312, 32)
        Me.Panel1.TabIndex = 0
        '
        'HeaderLable
        '
        Me.HeaderLable.BackColor = System.Drawing.SystemColors.Highlight
        Me.HeaderLable.Dock = System.Windows.Forms.DockStyle.Fill
        Me.HeaderLable.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HeaderLable.ForeColor = System.Drawing.Color.White
        Me.HeaderLable.Location = New System.Drawing.Point(0, 0)
        Me.HeaderLable.Name = "HeaderLable"
        Me.HeaderLable.Size = New System.Drawing.Size(312, 32)
        Me.HeaderLable.TabIndex = 0
        Me.HeaderLable.Text = "-"
        Me.HeaderLable.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.nxtBtn)
        Me.Panel2.Controls.Add(Me.bkBtn)
        Me.Panel2.Controls.Add(Me.YearUpDown)
        Me.Panel2.Controls.Add(Me.MonthCombo)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel2.Location = New System.Drawing.Point(312, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(304, 32)
        Me.Panel2.TabIndex = 1
        '
        'nxtBtn
        '
        Me.nxtBtn.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.nxtBtn.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nxtBtn.Location = New System.Drawing.Point(272, 5)
        Me.nxtBtn.Name = "nxtBtn"
        Me.nxtBtn.Size = New System.Drawing.Size(24, 23)
        Me.nxtBtn.TabIndex = 3
        Me.nxtBtn.Text = ">"
        '
        'bkBtn
        '
        Me.bkBtn.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.bkBtn.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bkBtn.Location = New System.Drawing.Point(248, 5)
        Me.bkBtn.Name = "bkBtn"
        Me.bkBtn.Size = New System.Drawing.Size(24, 23)
        Me.bkBtn.TabIndex = 2
        Me.bkBtn.Text = "<"
        '
        'YearUpDown
        '
        Me.YearUpDown.Location = New System.Drawing.Point(160, 6)
        Me.YearUpDown.Maximum = New Decimal(New Integer() {2021, 0, 0, 0})
        Me.YearUpDown.Minimum = New Decimal(New Integer() {1912, 0, 0, 0})
        Me.YearUpDown.Name = "YearUpDown"
        Me.YearUpDown.Size = New System.Drawing.Size(56, 21)
        Me.YearUpDown.TabIndex = 1
        Me.YearUpDown.Value = New Decimal(New Integer() {1912, 0, 0, 0})
        '
        'MonthCombo
        '
        Me.MonthCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MonthCombo.Items.AddRange(New Object() {"January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"})
        Me.MonthCombo.Location = New System.Drawing.Point(16, 6)
        Me.MonthCombo.Name = "MonthCombo"
        Me.MonthCombo.Size = New System.Drawing.Size(121, 21)
        Me.MonthCombo.TabIndex = 0
        '
        'SSCalendar
        '
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.Controls.Add(Me.HeaderPanel)
        Me.Controls.Add(Me._picDay_6)
        Me.Controls.Add(Me._picDay_5)
        Me.Controls.Add(Me._picDay_4)
        Me.Controls.Add(Me._picDay_3)
        Me.Controls.Add(Me._picDay_2)
        Me.Controls.Add(Me._picDay_1)
        Me.Controls.Add(Me._picDay_0)
        Me.Controls.Add(Me._picDay_13)
        Me.Controls.Add(Me._picDay_12)
        Me.Controls.Add(Me._picDay_11)
        Me.Controls.Add(Me._picDay_10)
        Me.Controls.Add(Me._picDay_9)
        Me.Controls.Add(Me._picDay_8)
        Me.Controls.Add(Me._picDay_7)
        Me.Controls.Add(Me._picDay_20)
        Me.Controls.Add(Me._picDay_19)
        Me.Controls.Add(Me._picDay_18)
        Me.Controls.Add(Me._picDay_17)
        Me.Controls.Add(Me._picDay_16)
        Me.Controls.Add(Me._picDay_15)
        Me.Controls.Add(Me._picDay_14)
        Me.Controls.Add(Me._picDay_27)
        Me.Controls.Add(Me._picDay_26)
        Me.Controls.Add(Me._picDay_25)
        Me.Controls.Add(Me._picDay_24)
        Me.Controls.Add(Me._picDay_23)
        Me.Controls.Add(Me._picDay_22)
        Me.Controls.Add(Me._picDay_21)
        Me.Controls.Add(Me._picDay_34)
        Me.Controls.Add(Me._picDay_33)
        Me.Controls.Add(Me._picDay_32)
        Me.Controls.Add(Me._picDay_31)
        Me.Controls.Add(Me._picDay_30)
        Me.Controls.Add(Me._picDay_29)
        Me.Controls.Add(Me._picDay_28)
        Me.Controls.Add(Me._picDay_41)
        Me.Controls.Add(Me._picDay_40)
        Me.Controls.Add(Me._picDay_39)
        Me.Controls.Add(Me._picDay_38)
        Me.Controls.Add(Me._picDay_37)
        Me.Controls.Add(Me._picDay_36)
        Me.Controls.Add(Me._picDay_35)
        Me.Controls.Add(Me.lblSaturday)
        Me.Controls.Add(Me.lblFriday)
        Me.Controls.Add(Me.lblThursday)
        Me.Controls.Add(Me.lblWednesday)
        Me.Controls.Add(Me.lblTuesday)
        Me.Controls.Add(Me.lblMonday)
        Me.Controls.Add(Me.lblSunday)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Location = New System.Drawing.Point(4, 23)
        Me.Name = "SSCalendar"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Size = New System.Drawing.Size(630, 564)
        Me._picDay_6.ResumeLayout(False)
        Me._picDay_5.ResumeLayout(False)
        Me._picDay_4.ResumeLayout(False)
        Me._picDay_3.ResumeLayout(False)
        Me._picDay_2.ResumeLayout(False)
        Me._picDay_1.ResumeLayout(False)
        Me._picDay_0.ResumeLayout(False)
        Me._picDay_13.ResumeLayout(False)
        Me._picDay_12.ResumeLayout(False)
        Me._picDay_11.ResumeLayout(False)
        Me._picDay_10.ResumeLayout(False)
        Me._picDay_9.ResumeLayout(False)
        Me._picDay_8.ResumeLayout(False)
        Me._picDay_7.ResumeLayout(False)
        Me._picDay_20.ResumeLayout(False)
        Me._picDay_19.ResumeLayout(False)
        Me._picDay_18.ResumeLayout(False)
        Me._picDay_17.ResumeLayout(False)
        Me._picDay_16.ResumeLayout(False)
        Me._picDay_15.ResumeLayout(False)
        Me._picDay_14.ResumeLayout(False)
        Me._picDay_27.ResumeLayout(False)
        Me._picDay_26.ResumeLayout(False)
        Me._picDay_25.ResumeLayout(False)
        Me._picDay_24.ResumeLayout(False)
        Me._picDay_23.ResumeLayout(False)
        Me._picDay_22.ResumeLayout(False)
        Me._picDay_21.ResumeLayout(False)
        Me._picDay_34.ResumeLayout(False)
        Me._picDay_33.ResumeLayout(False)
        Me._picDay_32.ResumeLayout(False)
        Me._picDay_31.ResumeLayout(False)
        Me._picDay_30.ResumeLayout(False)
        Me._picDay_29.ResumeLayout(False)
        Me._picDay_28.ResumeLayout(False)
        Me._picDay_41.ResumeLayout(False)
        Me._picDay_40.ResumeLayout(False)
        Me._picDay_39.ResumeLayout(False)
        Me._picDay_38.ResumeLayout(False)
        Me._picDay_37.ResumeLayout(False)
        Me._picDay_36.ResumeLayout(False)
        Me._picDay_35.ResumeLayout(False)
        CType(Me.lblDay, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picDay, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDay, System.ComponentModel.ISupportInitialize).EndInit()
        Me.HeaderPanel.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        CType(Me.YearUpDown, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
#End Region

    Private Sub WinCalendar_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        _SelectedDate = Now

        IsInitializing = True
        MonthCombo.SelectedIndex = _SelectedDate.Month - 1
        YearUpDown.Value = _SelectedDate.Year
        IsInitializing = False

        DrawCalendar()
    End Sub

    'Private Sub txtDay_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtDay.TextChanged
    '    If Not IsInitializing Then
    '        IsInitializing = True
    '        CType(eventSender, TextBox).Text = _curText
    '        IsInitializing = False
    '    End If
    'End Sub

    'Private Sub txtDay_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDay.KeyDown
    '    _curText = CType(sender, TextBox).Text()
    'End Sub

    'Private Sub txtDay_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDay.KeyUp
    '    'CType(sender, TextBox).Text = _curText
    'End Sub

    Public Sub DrawCalendar()
        IsInitializing = True

        Dim intNumberOfDays As Integer
        Dim datFirstDay As Date

        Dim x As Integer
        Dim i As Integer
        Dim ctrlBackColor As System.Drawing.Color
        Dim ctrlForeColor As System.Drawing.Color

        ctrlBackColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.Khaki) ' System.Drawing.Color.FromKnownColor(Drawing.KnownColor.LightBlue)
        ctrlForeColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.MidnightBlue)

        'Clean the txtDay / lblDay
        For i = 0 To 41
            lblDay(i).Text = ""
            lblDay(i).BackColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.Control)
            lblDay(i).ForeColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.ControlText)
            'txtDay(i).BackColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.Window)
            'txtDay(i).ForeColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.ControlText)

            'SetlstViewCtl(i + 1)
            'lstView.BackColor = ctrlBackColor
            'lstView.ForeColor = ctrlForeColor
            'lstView.Items.Clear()

            Select Case i
                Case 0
                    lstView1.BackColor = ctrlBackColor
                    lstView1.ForeColor = ctrlForeColor
                    lstView1.Items.Clear()
                Case 1
                    lstView2.BackColor = ctrlBackColor
                    lstView2.ForeColor = ctrlForeColor
                    lstView2.Items.Clear()
                Case 2
                    lstView3.BackColor = ctrlBackColor
                    lstView3.ForeColor = ctrlForeColor
                    lstView3.Items.Clear()
                Case 3
                    lstView4.BackColor = ctrlBackColor
                    lstView4.ForeColor = ctrlForeColor
                    lstView4.Items.Clear()
                Case 4
                    lstView5.BackColor = ctrlBackColor
                    lstView5.ForeColor = ctrlForeColor
                    lstView5.Items.Clear()
                Case 5
                    lstView6.BackColor = ctrlBackColor
                    lstView6.ForeColor = ctrlForeColor
                    lstView6.Items.Clear()
                Case 6
                    lstView7.BackColor = ctrlBackColor
                    lstView7.ForeColor = ctrlForeColor
                    lstView7.Items.Clear()
                Case 7
                    lstView8.BackColor = ctrlBackColor
                    lstView8.ForeColor = ctrlForeColor
                    lstView8.Items.Clear()
                Case 8
                    lstView9.BackColor = ctrlBackColor
                    lstView9.ForeColor = ctrlForeColor
                    lstView9.Items.Clear()
                Case 9
                    lstView10.BackColor = ctrlBackColor
                    lstView10.ForeColor = ctrlForeColor
                    lstView10.Items.Clear()
                Case 10
                    lstView11.BackColor = ctrlBackColor
                    lstView11.ForeColor = ctrlForeColor
                    lstView11.Items.Clear()
                Case 11
                    lstView12.BackColor = ctrlBackColor
                    lstView12.ForeColor = ctrlForeColor
                    lstView12.Items.Clear()
                Case 12
                    lstView13.BackColor = ctrlBackColor
                    lstView13.ForeColor = ctrlForeColor
                    lstView13.Items.Clear()
                Case 13
                    lstView14.BackColor = ctrlBackColor
                    lstView14.ForeColor = ctrlForeColor
                    lstView14.Items.Clear()
                Case 14
                    lstView15.BackColor = ctrlBackColor
                    lstView15.ForeColor = ctrlForeColor
                    lstView15.Items.Clear()
                Case 15
                    lstView16.BackColor = ctrlBackColor
                    lstView16.ForeColor = ctrlForeColor
                    lstView16.Items.Clear()
                Case 16
                    lstView17.BackColor = ctrlBackColor
                    lstView17.ForeColor = ctrlForeColor
                    lstView17.Items.Clear()
                Case 17
                    lstView18.BackColor = ctrlBackColor
                    lstView18.ForeColor = ctrlForeColor
                    lstView18.Items.Clear()
                Case 18
                    lstView19.BackColor = ctrlBackColor
                    lstView19.ForeColor = ctrlForeColor
                    lstView19.Items.Clear()
                Case 19
                    lstView20.BackColor = ctrlBackColor
                    lstView20.ForeColor = ctrlForeColor
                    lstView20.Items.Clear()
                Case 20
                    lstView21.BackColor = ctrlBackColor
                    lstView21.ForeColor = ctrlForeColor
                    lstView21.Items.Clear()
                Case 21
                    lstView22.BackColor = ctrlBackColor
                    lstView22.ForeColor = ctrlForeColor
                    lstView22.Items.Clear()
                Case 22
                    lstView23.BackColor = ctrlBackColor
                    lstView23.ForeColor = ctrlForeColor
                    lstView23.Items.Clear()
                Case 23
                    lstView24.BackColor = ctrlBackColor
                    lstView24.ForeColor = ctrlForeColor
                    lstView24.Items.Clear()
                Case 24
                    lstView25.BackColor = ctrlBackColor
                    lstView25.ForeColor = ctrlForeColor
                    lstView25.Items.Clear()
                Case 25
                    lstView26.BackColor = ctrlBackColor
                    lstView26.ForeColor = ctrlForeColor
                    lstView26.Items.Clear()
                Case 26
                    lstView27.BackColor = ctrlBackColor
                    lstView27.ForeColor = ctrlForeColor
                    lstView27.Items.Clear()
                Case 27
                    lstView28.BackColor = ctrlBackColor
                    lstView28.ForeColor = ctrlForeColor
                    lstView28.Items.Clear()
                Case 28
                    lstView29.BackColor = ctrlBackColor
                    lstView29.ForeColor = ctrlForeColor
                    lstView29.Items.Clear()
                Case 29
                    lstView30.BackColor = ctrlBackColor
                    lstView30.ForeColor = ctrlForeColor
                    lstView30.Items.Clear()
                Case 30
                    lstView31.BackColor = ctrlBackColor
                    lstView31.ForeColor = ctrlForeColor
                    lstView31.Items.Clear()
                Case 31
                    lstView32.BackColor = ctrlBackColor
                    lstView32.ForeColor = ctrlForeColor
                    lstView32.Items.Clear()
                Case 32
                    lstView33.BackColor = ctrlBackColor
                    lstView33.ForeColor = ctrlForeColor
                    lstView33.Items.Clear()
                Case 33
                    lstView34.BackColor = ctrlBackColor
                    lstView34.ForeColor = ctrlForeColor
                    lstView34.Items.Clear()
                Case 34
                    lstView35.BackColor = ctrlBackColor
                    lstView35.ForeColor = ctrlForeColor
                    lstView35.Items.Clear()
                Case 35
                    lstView36.BackColor = ctrlBackColor
                    lstView36.ForeColor = ctrlForeColor
                    lstView36.Items.Clear()
                Case 36
                    lstView37.BackColor = ctrlBackColor
                    lstView37.ForeColor = ctrlForeColor
                    lstView37.Items.Clear()
                Case 37
                    lstView38.BackColor = ctrlBackColor
                    lstView38.ForeColor = ctrlForeColor
                    lstView38.Items.Clear()
                Case 38
                    lstView39.BackColor = ctrlBackColor
                    lstView39.ForeColor = ctrlForeColor
                    lstView39.Items.Clear()
                Case 39
                    lstView40.BackColor = ctrlBackColor
                    lstView40.ForeColor = ctrlForeColor
                    lstView40.Items.Clear()
                Case 40
                    lstView41.BackColor = ctrlBackColor
                    lstView41.ForeColor = ctrlForeColor
                    lstView41.Items.Clear()
                Case 41
                    lstView42.BackColor = ctrlBackColor
                    lstView42.ForeColor = ctrlForeColor
                    lstView42.Items.Clear()
            End Select

            picDay(i).BackgroundImage = Nothing
            'txtDay(i).Text = ""

            picDay(i).Visible = True
        Next i

        HeaderLable.Text = _SelectedDate.ToString("MMMM yyyy")
        MonthCombo.SelectedIndex = _SelectedDate.Month - 1
        YearUpDown.Value = _SelectedDate.Year

        intNumberOfDays = _SelectedDate.DaysInMonth(_SelectedDate.Year, _SelectedDate.Month)
        datFirstDay = CDate(_SelectedDate.Month & "/" & 1 & "/" & _SelectedDate.Year)
        x = 1

        'Gets an array list of days
        'Dim mTriggers As ArrayList = TriggerDays(m_SelectedDate.Month)
        Dim trgDate As Date

        Dim dv As DataView = Nothing
        If Not DataSource Is Nothing Then
            If TableName.Length > 0 Then
                If DateMember.Length > 0 Then
                    If TimeMember.Length > 0 Then
                        Try
                            dv = DataSource.DefaultViewManager.CreateDataView(DataSource.Tables(TableName))
                        Catch ex As Exception
                            System.Windows.Forms.MessageBox.Show(ex.Message)
                        End Try
                    End If
                End If
            End If
        End If

        ctrlBackColor = clrHighlightColor

        For i = Weekday(datFirstDay) - 1 To intNumberOfDays + Weekday(datFirstDay) - 2
            lblDay(i).Text = CStr(x)

            ' Today gets special background
            If _SelectedDate.Month = Now.Month And _SelectedDate.Year = Now.Year Then
                If x = Now.Day Then

                    'SetlstViewCtl(i + 1)
                    'lstView.BackColor = ctrlBackColor

                    Select Case (i + 1)
                        Case 1
                            lstView1.BackColor = ctrlBackColor
                        Case 2
                            lstView2.BackColor = ctrlBackColor
                        Case 3
                            lstView3.BackColor = ctrlBackColor
                        Case 4
                            lstView4.BackColor = ctrlBackColor
                        Case 5
                            lstView5.BackColor = ctrlBackColor
                        Case 6
                            lstView6.BackColor = ctrlBackColor
                        Case 7
                            lstView7.BackColor = ctrlBackColor
                        Case 8
                            lstView8.BackColor = ctrlBackColor
                        Case 9
                            lstView9.BackColor = ctrlBackColor
                        Case 10
                            lstView10.BackColor = ctrlBackColor
                        Case 11
                            lstView11.BackColor = ctrlBackColor
                        Case 12
                            lstView12.BackColor = ctrlBackColor
                        Case 13
                            lstView13.BackColor = ctrlBackColor
                        Case 14
                            lstView14.BackColor = ctrlBackColor
                        Case 15
                            lstView15.BackColor = ctrlBackColor
                        Case 16
                            lstView16.BackColor = ctrlBackColor
                        Case 17
                            lstView17.BackColor = ctrlBackColor
                        Case 18
                            lstView18.BackColor = ctrlBackColor
                        Case 19
                            lstView19.BackColor = ctrlBackColor
                        Case 20
                            lstView20.BackColor = ctrlBackColor
                        Case 21
                            lstView21.BackColor = ctrlBackColor
                        Case 22
                            lstView22.BackColor = ctrlBackColor
                        Case 23
                            lstView23.BackColor = ctrlBackColor
                        Case 24
                            lstView24.BackColor = ctrlBackColor
                        Case 25
                            lstView25.BackColor = ctrlBackColor
                        Case 26
                            lstView26.BackColor = ctrlBackColor
                        Case 27
                            lstView27.BackColor = ctrlBackColor
                        Case 28
                            lstView28.BackColor = ctrlBackColor
                        Case 29
                            lstView29.BackColor = ctrlBackColor
                        Case 30
                            lstView30.BackColor = ctrlBackColor
                        Case 31
                            lstView31.BackColor = ctrlBackColor
                        Case 32
                            lstView32.BackColor = ctrlBackColor
                        Case 33
                            lstView33.BackColor = ctrlBackColor
                        Case 34
                            lstView34.BackColor = ctrlBackColor
                        Case 35
                            lstView35.BackColor = ctrlBackColor
                        Case 36
                            lstView36.BackColor = ctrlBackColor
                        Case 37
                            lstView37.BackColor = ctrlBackColor
                        Case 38
                            lstView38.BackColor = ctrlBackColor
                        Case 39
                            lstView39.BackColor = ctrlBackColor
                        Case 40
                            lstView40.BackColor = ctrlBackColor
                        Case 41
                            lstView41.BackColor = ctrlBackColor
                        Case 42
                            lstView42.BackColor = ctrlBackColor
                    End Select

                    'txtDay(i).BackColor = ctrlBackColor
                    lblDay(i).BackColor = ctrlBackColor
                    lblDay(i).ForeColor = System.Drawing.Color.White
                End If
            End If

            ' show appontments
            SetAppointment(dv, New DateTime(_SelectedDate.Year, _SelectedDate.Month, x), i, False)

            x = x + 1
        Next

        'Make the picDays that aren't from the month invisible
        x = 1
        For i = 27 To 41
            If lblDay(i).Text = "" Then
                lblDay(i).Text = Str(x)
                lblDay(i).ForeColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.ControlDark)
                SetAppointment(dv, New DateTime(_SelectedDate.AddMonths(1).Year, _SelectedDate.AddMonths(1).Month, x), i, True)
                x += 1

                'SetlstViewCtl(i + 1)
                'lstView.BackColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.Control)
                'lstView.ForeColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.ControlDark)

                Select Case (i + 1)
                    Case 1
                        lstView1.BackColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.Control)
                        lstView1.ForeColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.ControlDark)
                    Case 2
                        lstView2.BackColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.Control)
                        lstView2.ForeColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.ControlDark)
                    Case 3
                        lstView3.BackColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.Control)
                        lstView3.ForeColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.ControlDark)
                    Case 4
                        lstView4.BackColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.Control)
                        lstView4.ForeColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.ControlDark)
                    Case 5
                        lstView5.BackColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.Control)
                        lstView5.ForeColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.ControlDark)
                    Case 6
                        lstView6.BackColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.Control)
                        lstView6.ForeColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.ControlDark)
                    Case 7
                        lstView7.BackColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.Control)
                        lstView7.ForeColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.ControlDark)
                    Case 8
                        lstView8.BackColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.Control)
                        lstView8.ForeColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.ControlDark)
                    Case 9
                        lstView9.BackColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.Control)
                        lstView9.ForeColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.ControlDark)
                    Case 10
                        lstView10.BackColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.Control)
                        lstView10.ForeColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.ControlDark)
                    Case 11
                        lstView11.BackColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.Control)
                        lstView11.ForeColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.ControlDark)
                    Case 12
                        lstView12.BackColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.Control)
                        lstView12.ForeColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.ControlDark)
                    Case 13
                        lstView13.BackColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.Control)
                        lstView13.ForeColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.ControlDark)
                    Case 14
                        lstView14.BackColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.Control)
                        lstView14.ForeColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.ControlDark)
                    Case 15
                        lstView15.BackColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.Control)
                        lstView15.ForeColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.ControlDark)
                    Case 16
                        lstView16.BackColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.Control)
                        lstView16.ForeColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.ControlDark)
                    Case 17
                        lstView17.BackColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.Control)
                        lstView17.ForeColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.ControlDark)
                    Case 18
                        lstView18.BackColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.Control)
                        lstView18.ForeColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.ControlDark)
                    Case 19
                        lstView19.BackColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.Control)
                        lstView19.ForeColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.ControlDark)
                    Case 20
                        lstView20.BackColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.Control)
                        lstView20.ForeColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.ControlDark)
                    Case 21
                        lstView21.BackColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.Control)
                        lstView21.ForeColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.ControlDark)
                    Case 22
                        lstView22.BackColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.Control)
                        lstView22.ForeColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.ControlDark)
                    Case 23
                        lstView23.BackColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.Control)
                        lstView23.ForeColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.ControlDark)
                    Case 24
                        lstView24.BackColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.Control)
                        lstView24.ForeColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.ControlDark)
                    Case 25
                        lstView25.BackColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.Control)
                        lstView25.ForeColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.ControlDark)
                    Case 26
                        lstView26.BackColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.Control)
                        lstView26.ForeColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.ControlDark)
                    Case 27
                        lstView27.BackColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.Control)
                        lstView27.ForeColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.ControlDark)
                    Case 28
                        lstView28.BackColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.Control)
                        lstView28.ForeColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.ControlDark)
                    Case 29
                        lstView29.BackColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.Control)
                        lstView29.ForeColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.ControlDark)
                    Case 30
                        lstView30.BackColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.Control)
                        lstView30.ForeColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.ControlDark)
                    Case 31
                        lstView31.BackColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.Control)
                        lstView31.ForeColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.ControlDark)
                    Case 32
                        lstView32.BackColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.Control)
                        lstView32.ForeColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.ControlDark)
                    Case 33
                        lstView33.BackColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.Control)
                        lstView33.ForeColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.ControlDark)
                    Case 34
                        lstView34.BackColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.Control)
                        lstView34.ForeColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.ControlDark)
                    Case 35
                        lstView35.BackColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.Control)
                        lstView35.ForeColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.ControlDark)
                    Case 36
                        lstView36.BackColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.Control)
                        lstView36.ForeColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.ControlDark)
                    Case 37
                        lstView37.BackColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.Control)
                        lstView37.ForeColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.ControlDark)
                    Case 38
                        lstView38.BackColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.Control)
                        lstView38.ForeColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.ControlDark)
                    Case 39
                        lstView39.BackColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.Control)
                        lstView39.ForeColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.ControlDark)
                    Case 40
                        lstView40.BackColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.Control)
                        lstView40.ForeColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.ControlDark)
                    Case 41
                        lstView41.BackColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.Control)
                        lstView41.ForeColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.ControlDark)
                    Case 42
                        lstView42.BackColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.Control)
                        lstView42.ForeColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.ControlDark)
                End Select

                'txtDay(i).BackColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.Control)
                'txtDay(i).ForeColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.ControlDark)
            End If
        Next

        x = DateTime.DaysInMonth(_SelectedDate.AddMonths(-1).Year, _SelectedDate.AddMonths(-1).Month)
        For i = 7 To 0 Step -1
            If lblDay(i).Text = "" Then
                lblDay(i).Text = Str(x)
                lblDay(i).ForeColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.ControlDark)
                SetAppointment(dv, New DateTime(_SelectedDate.AddMonths(-1).Year, _SelectedDate.AddMonths(-1).Month, x), i, True)
                x -= 1

                'SetlstViewCtl(i + 1)
                'lstView.BackColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.Control)
                'lstView.ForeColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.ControlDark)

                Select Case (i + 1)
                    Case 1
                        lstView1.BackColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.Control)
                        lstView1.ForeColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.ControlDark)
                    Case 2
                        lstView2.BackColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.Control)
                        lstView2.ForeColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.ControlDark)
                    Case 3
                        lstView3.BackColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.Control)
                        lstView3.ForeColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.ControlDark)
                    Case 4
                        lstView4.BackColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.Control)
                        lstView4.ForeColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.ControlDark)
                    Case 5
                        lstView5.BackColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.Control)
                        lstView5.ForeColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.ControlDark)
                    Case 6
                        lstView6.BackColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.Control)
                        lstView6.ForeColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.ControlDark)
                    Case 7
                        lstView7.BackColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.Control)
                        lstView7.ForeColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.ControlDark)
                    Case 8
                        lstView8.BackColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.Control)
                        lstView8.ForeColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.ControlDark)
                    Case 9
                        lstView9.BackColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.Control)
                        lstView9.ForeColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.ControlDark)
                    Case 10
                        lstView10.BackColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.Control)
                        lstView10.ForeColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.ControlDark)
                    Case 11
                        lstView11.BackColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.Control)
                        lstView11.ForeColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.ControlDark)
                    Case 12
                        lstView12.BackColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.Control)
                        lstView12.ForeColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.ControlDark)
                    Case 13
                        lstView13.BackColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.Control)
                        lstView13.ForeColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.ControlDark)
                    Case 14
                        lstView14.BackColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.Control)
                        lstView14.ForeColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.ControlDark)
                    Case 15
                        lstView15.BackColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.Control)
                        lstView15.ForeColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.ControlDark)
                    Case 16
                        lstView16.BackColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.Control)
                        lstView16.ForeColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.ControlDark)
                    Case 17
                        lstView17.BackColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.Control)
                        lstView17.ForeColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.ControlDark)
                    Case 18
                        lstView18.BackColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.Control)
                        lstView18.ForeColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.ControlDark)
                    Case 19
                        lstView19.BackColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.Control)
                        lstView19.ForeColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.ControlDark)
                    Case 20
                        lstView20.BackColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.Control)
                        lstView20.ForeColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.ControlDark)
                    Case 21
                        lstView21.BackColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.Control)
                        lstView21.ForeColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.ControlDark)
                    Case 22
                        lstView22.BackColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.Control)
                        lstView22.ForeColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.ControlDark)
                    Case 23
                        lstView23.BackColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.Control)
                        lstView23.ForeColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.ControlDark)
                    Case 24
                        lstView24.BackColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.Control)
                        lstView24.ForeColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.ControlDark)
                    Case 25
                        lstView25.BackColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.Control)
                        lstView25.ForeColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.ControlDark)
                    Case 26
                        lstView26.BackColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.Control)
                        lstView26.ForeColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.ControlDark)
                    Case 27
                        lstView27.BackColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.Control)
                        lstView27.ForeColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.ControlDark)
                    Case 28
                        lstView28.BackColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.Control)
                        lstView28.ForeColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.ControlDark)
                    Case 29
                        lstView29.BackColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.Control)
                        lstView29.ForeColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.ControlDark)
                    Case 30
                        lstView30.BackColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.Control)
                        lstView30.ForeColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.ControlDark)
                    Case 31
                        lstView31.BackColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.Control)
                        lstView31.ForeColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.ControlDark)
                    Case 32
                        lstView32.BackColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.Control)
                        lstView32.ForeColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.ControlDark)
                    Case 33
                        lstView33.BackColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.Control)
                        lstView33.ForeColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.ControlDark)
                    Case 34
                        lstView34.BackColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.Control)
                        lstView34.ForeColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.ControlDark)
                    Case 35
                        lstView35.BackColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.Control)
                        lstView35.ForeColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.ControlDark)
                    Case 36
                        lstView36.BackColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.Control)
                        lstView36.ForeColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.ControlDark)
                    Case 37
                        lstView37.BackColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.Control)
                        lstView37.ForeColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.ControlDark)
                    Case 38
                        lstView38.BackColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.Control)
                        lstView38.ForeColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.ControlDark)
                    Case 39
                        lstView39.BackColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.Control)
                        lstView39.ForeColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.ControlDark)
                    Case 40
                        lstView40.BackColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.Control)
                        lstView40.ForeColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.ControlDark)
                    Case 41
                        lstView41.BackColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.Control)
                        lstView41.ForeColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.ControlDark)
                    Case 42
                        lstView42.BackColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.Control)
                        lstView42.ForeColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.ControlDark)
                End Select

                'txtDay(i).BackColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.Control)
                'txtDay(i).ForeColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.ControlDark)
            End If
        Next

        IsInitializing = False
    End Sub

    Private Sub SetAppointment(ByRef dv As DataView, ByVal dt As DateTime, ByVal index As Integer, ByVal faded As Boolean)

        If Not dv Is Nothing Then
            Try
                Dim dtStr As String = dt.Month.ToString() & "/" & dt.Day.ToString() & "/" & dt.Year.ToString()
                dv.RowFilter = DateMember & " >= '" & dtStr & " 12:00:00 AM' AND " & DateMember & " <= '" & dtStr & " 11:59:59 PM'"
                If OrderOnField IsNot Nothing Then
                    dv.Sort = TimeMember
                Else
                    dv.Sort = OrderOnField
                End If
                'dv.Sort = TimeMember

                Dim disp As String = ""
                Dim j As Integer
                For j = 0 To dv.Count - 1
                    'If j > 0 Then
                    '    disp += vbNewLine
                    'End If
                    disp = ""
                    If ShowTime Then
                        disp += CType(dv(j)(TimeMember), DateTime).ToShortTimeString()
                    End If
                    If ShowText Then
                        If ShowTime Then
                            disp += " "
                            'Else
                            '    disp += ""
                        End If
                        disp += dv(j)(TextMember)
                    End If

                    SetlstViewCtl(index + 1)

                    lstView.Items.Add(disp)
                    lstView.Items(lstView.Items.Count - 1).Tag = dv(j)(PrimaryKeyFieldName)

                    'set backcolor if value is passed
                    If Me.ColorCodeBCFieldName <> "" Then
                        If dv(j)(Me.ColorCodeBCFieldName) IsNot DBNull.Value Then
                            lstView.Items(lstView.Items.Count - 1).BackColor = System.Drawing.Color.FromName(dv(j)(Me.ColorCodeBCFieldName))
                        End If
                    End If

                    'set forecolor if value is passed
                    If Me.ColorCodeFCFieldName <> "" Then
                        If dv(j)(Me.ColorCodeFCFieldName) IsNot DBNull.Value Then
                            lstView.Items(lstView.Items.Count - 1).ForeColor = System.Drawing.Color.FromName(dv(j)(Me.ColorCodeFCFieldName))
                        End If
                    End If
                Next

                'txtDay(index).Text = disp
                If disp.Length > 0 Then
                    picDay(index).BackgroundImage = ImageList1.Images(0)
                    If faded Then
                        lblDay(index).BackColor = System.Drawing.Color.LightBlue
                        lblDay(index).ForeColor = System.Drawing.Color.Black
                    Else
                        lblDay(index).BackColor = clrHighlightColor ' System.Drawing.Color.Yellow
                        lblDay(index).ForeColor = System.Drawing.Color.White
                    End If
                End If
            Catch ex As Exception
                System.Windows.Forms.MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    Public Property SelectedDate() As Date
        Get
            If Not IsInitializing Then
                SelectedDate = _SelectedDate
            End If
        End Get
        Set(ByVal Value As Date)
            If Not IsInitializing Then
                Dim redraw As Boolean = Value.Month <> _SelectedDate.Month Or Value.Year <> _SelectedDate.Year
                _SelectedDate = Value

                If redraw Then
                    DrawCalendar()
                End If
            End If
        End Set
    End Property

    Private Sub UCCalendar_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        Dim colWidth As Integer = (Width - 8) / 7
        HeaderPanel.Width = Width - 8
        lblSunday.Width = colWidth
        lblMonday.Left = lblSunday.Left + colWidth - 1
        lblMonday.Width = colWidth
        lblTuesday.Left = lblMonday.Left + colWidth - 1
        lblTuesday.Width = colWidth
        lblWednesday.Left = lblTuesday.Left + colWidth - 1
        lblWednesday.Width = colWidth
        lblThursday.Left = lblWednesday.Left + colWidth - 1
        lblThursday.Width = colWidth
        lblFriday.Left = lblThursday.Left + colWidth - 1
        lblFriday.Width = colWidth
        lblSaturday.Left = lblFriday.Left + colWidth - 1
        lblSaturday.Width = colWidth

        Dim rowHeight As Integer = (Height - 8 - lblSunday.Height - 40 - HeaderPanel.Height) / 6

        Dim i As Integer
        For i = 0 To 41
            If i > 0 Then
                If (i) Mod 7 <> 0 Then
                    picDay.Item(i).Left = picDay.Item(i - 1).Left + picDay.Item(i - 1).Width - 1
                End If

                If i > 6 Then
                    picDay.Item(i).Top = picDay.Item(i - 7).Top + picDay.Item(i - 7).Height + 5
                End If
            End If
            picDay.Item(i).Width = colWidth

            SetlstViewCtl(i)
            'lstView.Width = colWidth
            'lstView.Height = (picDay.Item(i).Height - lblDay(i).Height + 1) + 25

            Select Case i
                Case 0
                    lstView1.Width = colWidth
                    lstView1.Height = (picDay.Item(i).Height - lblDay(i).Height + 1) + 25
                Case 1
                    lstView2.Width = colWidth
                    lstView2.Height = (picDay.Item(i).Height - lblDay(i).Height + 1) + 25
                Case 2
                    lstView3.Width = colWidth
                    lstView3.Height = (picDay.Item(i).Height - lblDay(i).Height + 1) + 25
                Case 3
                    lstView4.Width = colWidth
                    lstView4.Height = (picDay.Item(i).Height - lblDay(i).Height + 1) + 25
                Case 4
                    lstView5.Width = colWidth
                    lstView5.Height = (picDay.Item(i).Height - lblDay(i).Height + 1) + 25
                Case 5
                    lstView6.Width = colWidth
                    lstView6.Height = (picDay.Item(i).Height - lblDay(i).Height + 1) + 25
                Case 6
                    lstView7.Width = colWidth
                    lstView7.Height = (picDay.Item(i).Height - lblDay(i).Height + 1) + 25
                Case 7
                    lstView8.Width = colWidth
                    lstView8.Height = (picDay.Item(i).Height - lblDay(i).Height + 1) + 25
                Case 8
                    lstView9.Width = colWidth
                    lstView9.Height = (picDay.Item(i).Height - lblDay(i).Height + 1) + 25
                Case 9
                    lstView10.Width = colWidth
                    lstView10.Height = (picDay.Item(i).Height - lblDay(i).Height + 1) + 25
                Case 10
                    lstView11.Width = colWidth
                    lstView11.Height = (picDay.Item(i).Height - lblDay(i).Height + 1) + 25
                Case 11
                    lstView12.Width = colWidth
                    lstView12.Height = (picDay.Item(i).Height - lblDay(i).Height + 1) + 25
                Case 12
                    lstView13.Width = colWidth
                    lstView13.Height = (picDay.Item(i).Height - lblDay(i).Height + 1) + 25
                Case 13
                    lstView14.Width = colWidth
                    lstView14.Height = (picDay.Item(i).Height - lblDay(i).Height + 1) + 25
                Case 14
                    lstView15.Width = colWidth
                    lstView15.Height = (picDay.Item(i).Height - lblDay(i).Height + 1) + 25
                Case 15
                    lstView16.Width = colWidth
                    lstView16.Height = (picDay.Item(i).Height - lblDay(i).Height + 1) + 25
                Case 16
                    lstView17.Width = colWidth
                    lstView17.Height = (picDay.Item(i).Height - lblDay(i).Height + 1) + 25
                Case 17
                    lstView18.Width = colWidth
                    lstView18.Height = (picDay.Item(i).Height - lblDay(i).Height + 1) + 25
                Case 18
                    lstView19.Width = colWidth
                    lstView19.Height = (picDay.Item(i).Height - lblDay(i).Height + 1) + 25
                Case 19
                    lstView20.Width = colWidth
                    lstView20.Height = (picDay.Item(i).Height - lblDay(i).Height + 1) + 25
                Case 20
                    lstView21.Width = colWidth
                    lstView21.Height = (picDay.Item(i).Height - lblDay(i).Height + 1) + 25
                Case 21
                    lstView22.Width = colWidth
                    lstView22.Height = (picDay.Item(i).Height - lblDay(i).Height + 1) + 25
                Case 22
                    lstView23.Width = colWidth
                    lstView23.Height = (picDay.Item(i).Height - lblDay(i).Height + 1) + 25
                Case 23
                    lstView24.Width = colWidth
                    lstView24.Height = (picDay.Item(i).Height - lblDay(i).Height + 1) + 25
                Case 24
                    lstView25.Width = colWidth
                    lstView25.Height = (picDay.Item(i).Height - lblDay(i).Height + 1) + 25
                Case 25
                    lstView26.Width = colWidth
                    lstView26.Height = (picDay.Item(i).Height - lblDay(i).Height + 1) + 25
                Case 26
                    lstView27.Width = colWidth
                    lstView27.Height = (picDay.Item(i).Height - lblDay(i).Height + 1) + 25
                Case 27
                    lstView28.Width = colWidth
                    lstView28.Height = (picDay.Item(i).Height - lblDay(i).Height + 1) + 25
                Case 28
                    lstView29.Width = colWidth
                    lstView29.Height = (picDay.Item(i).Height - lblDay(i).Height + 1) + 25
                Case 29
                    lstView30.Width = colWidth
                    lstView30.Height = (picDay.Item(i).Height - lblDay(i).Height + 1) + 25
                Case 30
                    lstView31.Width = colWidth
                    lstView31.Height = (picDay.Item(i).Height - lblDay(i).Height + 1) + 25
                Case 31
                    lstView32.Width = colWidth
                    lstView32.Height = (picDay.Item(i).Height - lblDay(i).Height + 1) + 25
                Case 32
                    lstView33.Width = colWidth
                    lstView33.Height = (picDay.Item(i).Height - lblDay(i).Height + 1) + 25
                Case 33
                    lstView34.Width = colWidth
                    lstView34.Height = (picDay.Item(i).Height - lblDay(i).Height + 1) + 25
                Case 34
                    lstView35.Width = colWidth
                    lstView35.Height = (picDay.Item(i).Height - lblDay(i).Height + 1) + 25
                Case 35
                    lstView36.Width = colWidth
                    lstView36.Height = (picDay.Item(i).Height - lblDay(i).Height + 1) + 25
                Case 36
                    lstView37.Width = colWidth
                    lstView37.Height = (picDay.Item(i).Height - lblDay(i).Height + 1) + 25
                Case 37
                    lstView38.Width = colWidth
                    lstView38.Height = (picDay.Item(i).Height - lblDay(i).Height + 1) + 25
                Case 38
                    lstView39.Width = colWidth
                    lstView39.Height = (picDay.Item(i).Height - lblDay(i).Height + 1) + 25
                Case 39
                    lstView40.Width = colWidth
                    lstView40.Height = (picDay.Item(i).Height - lblDay(i).Height + 1) + 25
                Case 40
                    lstView41.Width = colWidth
                    lstView41.Height = (picDay.Item(i).Height - lblDay(i).Height + 1) + 25
                Case 41
                    lstView42.Width = colWidth
                    lstView42.Height = (picDay.Item(i).Height - lblDay(i).Height + 1) + 25
            End Select

            SetLVColumnWidths(i)

            'txtDay.Item(i).Width = colWidth

            picDay.Item(i).Height = rowHeight

            'txtDay.Item(i).Height = (picDay.Item(i).Height - lblDay(i).Height + 1) + 25

            'picDay.Item(i).Invalidate(True)
            'picDay.Item(i).Refresh()
        Next
    End Sub

    Private Sub dayPanel_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles picDay.Resize
        'CType(sender, Panel).Invalidate(True)
        'CType(sender, Panel).Refresh()
    End Sub

    Private Sub MonthCombo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MonthCombo.SelectedIndexChanged
        If Not IsInitializing Then
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            SelectedDate = New DateTime(_SelectedDate.Year, MonthCombo.SelectedIndex + 1, _SelectedDate.Day)
            Me.Cursor = System.Windows.Forms.Cursors.Default
        End If
    End Sub

    Private Sub YearUpDown_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles YearUpDown.ValueChanged
        If Not IsInitializing Then
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            SelectedDate = New DateTime(YearUpDown.Value, _SelectedDate.Month, _SelectedDate.Day)
            Me.Cursor = System.Windows.Forms.Cursors.Default
        End If
    End Sub

    Private Sub bkBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bkBtn.Click
        Dim m As Integer
        Dim y As Integer = _SelectedDate.Year
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        If _SelectedDate.Month = 1 Then
            m = 12
            If _SelectedDate.Year > 1912 Then
                y = _SelectedDate.Year - 1
            End If
        Else
            m = _SelectedDate.Month - 1
        End If
        SelectedDate = New DateTime(y, m, _SelectedDate.Day)
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub nxtBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nxtBtn.Click
        Dim m As Integer
        Dim y As Integer = _SelectedDate.Year
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        If _SelectedDate.Month = 12 Then
            m = 1
            If _SelectedDate.Year < 2021 Then
                y = _SelectedDate.Year + 1
            End If
        Else
            m = _SelectedDate.Month + 1
        End If
        SelectedDate = New DateTime(y, m, _SelectedDate.Day)
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub SetLVColumnWidths(ByVal colindex As Integer)
        Dim intLessScroll As Integer

        intLessScroll = 7

        'SetlstViewCtl(colindex)
        'lstView.Columns(0).Width = lstView1.Width - intLessScroll

        Select Case (colindex)
            Case 1
                lstView1.Columns(0).Width = lstView1.Width - intLessScroll
            Case 2
                lstView2.Columns(0).Width = lstView2.Width - intLessScroll
            Case 3
                lstView3.Columns(0).Width = lstView3.Width - intLessScroll
            Case 4
                lstView4.Columns(0).Width = lstView4.Width - intLessScroll
            Case 5
                lstView5.Columns(0).Width = lstView5.Width - intLessScroll
            Case 6
                lstView6.Columns(0).Width = lstView6.Width - intLessScroll
            Case 7
                lstView7.Columns(0).Width = lstView7.Width - intLessScroll
            Case 8
                lstView8.Columns(0).Width = lstView8.Width - intLessScroll
            Case 9
                lstView9.Columns(0).Width = lstView9.Width - intLessScroll
            Case 10
                lstView10.Columns(0).Width = lstView10.Width - intLessScroll
            Case 11
                lstView11.Columns(0).Width = lstView11.Width - intLessScroll
            Case 12
                lstView12.Columns(0).Width = lstView12.Width - intLessScroll
            Case 13
                lstView13.Columns(0).Width = lstView13.Width - intLessScroll
            Case 14
                lstView14.Columns(0).Width = lstView14.Width - intLessScroll
            Case 15
                lstView15.Columns(0).Width = lstView15.Width - intLessScroll
            Case 16
                lstView16.Columns(0).Width = lstView16.Width - intLessScroll
            Case 17
                lstView17.Columns(0).Width = lstView17.Width - intLessScroll
            Case 18
                lstView18.Columns(0).Width = lstView18.Width - intLessScroll
            Case 19
                lstView19.Columns(0).Width = lstView19.Width - intLessScroll
            Case 20
                lstView20.Columns(0).Width = lstView20.Width - intLessScroll
            Case 21
                lstView21.Columns(0).Width = lstView21.Width - intLessScroll
            Case 22
                lstView22.Columns(0).Width = lstView22.Width - intLessScroll
            Case 23
                lstView23.Columns(0).Width = lstView23.Width - intLessScroll
            Case 24
                lstView24.Columns(0).Width = lstView24.Width - intLessScroll
            Case 25
                lstView25.Columns(0).Width = lstView25.Width - intLessScroll
            Case 26
                lstView26.Columns(0).Width = lstView26.Width - intLessScroll
            Case 27
                lstView27.Columns(0).Width = lstView27.Width - intLessScroll
            Case 28
                lstView28.Columns(0).Width = lstView28.Width - intLessScroll
            Case 29
                lstView29.Columns(0).Width = lstView29.Width - intLessScroll
            Case 30
                lstView30.Columns(0).Width = lstView30.Width - intLessScroll
            Case 31
                lstView31.Columns(0).Width = lstView31.Width - intLessScroll
            Case 32
                lstView32.Columns(0).Width = lstView32.Width - intLessScroll
            Case 33
                lstView33.Columns(0).Width = lstView33.Width - intLessScroll
            Case 34
                lstView34.Columns(0).Width = lstView34.Width - intLessScroll
            Case 35
                lstView35.Columns(0).Width = lstView35.Width - intLessScroll
            Case 36
                lstView36.Columns(0).Width = lstView36.Width - intLessScroll
            Case 37
                lstView37.Columns(0).Width = lstView37.Width - intLessScroll
            Case 38
                lstView38.Columns(0).Width = lstView38.Width - intLessScroll
            Case 39
                lstView39.Columns(0).Width = lstView39.Width - intLessScroll
            Case 40
                lstView40.Columns(0).Width = lstView40.Width - intLessScroll
            Case 41
                lstView41.Columns(0).Width = lstView41.Width - intLessScroll
            Case 42
                lstView42.Columns(0).Width = lstView42.Width - intLessScroll
        End Select
    End Sub

    Private Sub SetlstViewCtl(ByVal index As Integer)
        Select Case index
            Case 1
                lstView = lstView1
            Case 2
                lstView = lstView2
            Case 3
                lstView = lstView3
            Case 4
                lstView = lstView4
            Case 5
                lstView = lstView5
            Case 6
                lstView = lstView6
            Case 7
                lstView = lstView7
            Case 8
                lstView = lstView8
            Case 9
                lstView = lstView9
            Case 10
                lstView = lstView10
            Case 11
                lstView = lstView11
            Case 12
                lstView = lstView12
            Case 13
                lstView = lstView13
            Case 14
                lstView = lstView14
            Case 15
                lstView = lstView15
            Case 16
                lstView = lstView16
            Case 17
                lstView = lstView17
            Case 18
                lstView = lstView18
            Case 19
                lstView = lstView19
            Case 20
                lstView = lstView20
            Case 21
                lstView = lstView21
            Case 22
                lstView = lstView22
            Case 23
                lstView = lstView23
            Case 24
                lstView = lstView24
            Case 25
                lstView = lstView25
            Case 26
                lstView = lstView26
            Case 27
                lstView = lstView27
            Case 28
                lstView = lstView28
            Case 29
                lstView = lstView29
            Case 30
                lstView = lstView30
            Case 31
                lstView = lstView31
            Case 32
                lstView = lstView32
            Case 33
                lstView = lstView33
            Case 34
                lstView = lstView34
            Case 35
                lstView = lstView35
            Case 36
                lstView = lstView36
            Case 37
                lstView = lstView37
            Case 38
                lstView = lstView38
            Case 39
                lstView = lstView39
            Case 40
                lstView = lstView40
            Case 41
                lstView = lstView41
            Case 42
                lstView = lstView42
        End Select
    End Sub

    Private Sub RunListViewClick(ByVal sender As Object)
        Dim lv As System.Windows.Forms.ListView
        lv = sender

        RaiseEvent ShowPopup(CLng(lv.SelectedItems(0).Tag), lv.SelectedItems(0).Text)
    End Sub

    Private Sub lstView3_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstView3.DoubleClick
        RunListViewClick(sender)
    End Sub

    Private Sub lstView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstView1.DoubleClick
        RunListViewClick(sender)
    End Sub

    Private Sub lstView2_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstView2.DoubleClick
        RunListViewClick(sender)
    End Sub

    Private Sub lstView10_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstView10.DoubleClick
        RunListViewClick(sender)
    End Sub

    Private Sub lstView11_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstView11.DoubleClick
        RunListViewClick(sender)
    End Sub

    Private Sub lstView12_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstView12.DoubleClick
        RunListViewClick(sender)
    End Sub

    Private Sub lstView13_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstView13.DoubleClick
        RunListViewClick(sender)
    End Sub

    Private Sub lstView14_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstView14.DoubleClick
        RunListViewClick(sender)
    End Sub

    Private Sub lstView15_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstView15.DoubleClick
        RunListViewClick(sender)
    End Sub

    Private Sub lstView16_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstView16.DoubleClick
        RunListViewClick(sender)
    End Sub

    Private Sub lstView17_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstView17.DoubleClick
        RunListViewClick(sender)
    End Sub

    Private Sub lstView18_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstView18.DoubleClick
        RunListViewClick(sender)
    End Sub

    Private Sub lstView19_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstView19.DoubleClick
        RunListViewClick(sender)
    End Sub

    Private Sub lstView20_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstView20.DoubleClick
        RunListViewClick(sender)
    End Sub

    Private Sub lstView21_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstView21.DoubleClick
        RunListViewClick(sender)
    End Sub

    Private Sub lstView22_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstView22.DoubleClick
        RunListViewClick(sender)
    End Sub

    Private Sub lstView23_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstView23.DoubleClick
        RunListViewClick(sender)
    End Sub

    Private Sub lstView24_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstView24.DoubleClick
        RunListViewClick(sender)
    End Sub

    Private Sub lstView25_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstView25.DoubleClick
        RunListViewClick(sender)
    End Sub

    Private Sub lstView26_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstView26.DoubleClick
        RunListViewClick(sender)
    End Sub

    Private Sub lstView27_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstView27.DoubleClick
        RunListViewClick(sender)
    End Sub

    Private Sub lstView28_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstView28.DoubleClick
        RunListViewClick(sender)
    End Sub

    Private Sub lstView29_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstView29.DoubleClick
        RunListViewClick(sender)
    End Sub

    Private Sub lstView30_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstView30.DoubleClick
        RunListViewClick(sender)
    End Sub

    Private Sub lstView31_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstView31.DoubleClick
        RunListViewClick(sender)
    End Sub

    Private Sub lstView32_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstView32.DoubleClick
        RunListViewClick(sender)
    End Sub

    Private Sub lstView33_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstView33.DoubleClick
        RunListViewClick(sender)
    End Sub

    Private Sub lstView34_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstView34.DoubleClick
        RunListViewClick(sender)
    End Sub

    Private Sub lstView35_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstView35.DoubleClick
        RunListViewClick(sender)
    End Sub

    Private Sub lstView36_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstView36.DoubleClick
        RunListViewClick(sender)
    End Sub

    Private Sub lstView37_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstView37.DoubleClick
        RunListViewClick(sender)
    End Sub

    Private Sub lstView38_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstView38.DoubleClick
        RunListViewClick(sender)
    End Sub

    Private Sub lstView39_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstView39.DoubleClick
        RunListViewClick(sender)
    End Sub

    Private Sub lstView4_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstView4.DoubleClick
        RunListViewClick(sender)
    End Sub

    Private Sub lstView40_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstView40.DoubleClick
        RunListViewClick(sender)
    End Sub

    Private Sub lstView41_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstView41.DoubleClick
        RunListViewClick(sender)
    End Sub

    Private Sub lstView42_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstView42.DoubleClick
        RunListViewClick(sender)
    End Sub

    Private Sub lstView5_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstView5.DoubleClick
        RunListViewClick(sender)
    End Sub

    Private Sub lstView6_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstView6.DoubleClick
        RunListViewClick(sender)
    End Sub

    Private Sub lstView7_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstView7.DoubleClick
        RunListViewClick(sender)
    End Sub

    Private Sub lstView8_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstView8.DoubleClick
        RunListViewClick(sender)
    End Sub

    Private Sub lstView9_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstView9.DoubleClick
        RunListViewClick(sender)
    End Sub
End Class
