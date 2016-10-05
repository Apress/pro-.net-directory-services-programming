Public Class frmPrinters
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lbPrinters As System.Windows.Forms.ListBox
    Friend WithEvents txtPrinterName As System.Windows.Forms.TextBox
    Friend WithEvents txtServerName As System.Windows.Forms.TextBox
    Friend WithEvents txtVersionNumber As System.Windows.Forms.TextBox
    Friend WithEvents txtShortServerName As System.Windows.Forms.TextBox
    Friend WithEvents txtUNCName As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.lbPrinters = New System.Windows.Forms.ListBox()
        Me.txtPrinterName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtServerName = New System.Windows.Forms.TextBox()
        Me.txtVersionNumber = New System.Windows.Forms.TextBox()
        Me.txtShortServerName = New System.Windows.Forms.TextBox()
        Me.txtUNCName = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lbPrinters
        '
        Me.lbPrinters.HorizontalScrollbar = True
        Me.lbPrinters.Location = New System.Drawing.Point(8, 8)
        Me.lbPrinters.Name = "lbPrinters"
        Me.lbPrinters.Size = New System.Drawing.Size(512, 173)
        Me.lbPrinters.TabIndex = 0
        '
        'txtPrinterName
        '
        Me.txtPrinterName.Location = New System.Drawing.Point(152, 192)
        Me.txtPrinterName.Name = "txtPrinterName"
        Me.txtPrinterName.Size = New System.Drawing.Size(368, 20)
        Me.txtPrinterName.TabIndex = 1
        Me.txtPrinterName.Text = ""
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 192)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(136, 23)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Printer Name"
        '
        'txtServerName
        '
        Me.txtServerName.Location = New System.Drawing.Point(152, 224)
        Me.txtServerName.Name = "txtServerName"
        Me.txtServerName.Size = New System.Drawing.Size(368, 20)
        Me.txtServerName.TabIndex = 3
        Me.txtServerName.Text = ""
        '
        'txtVersionNumber
        '
        Me.txtVersionNumber.Location = New System.Drawing.Point(152, 320)
        Me.txtVersionNumber.Name = "txtVersionNumber"
        Me.txtVersionNumber.Size = New System.Drawing.Size(368, 20)
        Me.txtVersionNumber.TabIndex = 4
        Me.txtVersionNumber.Text = ""
        '
        'txtShortServerName
        '
        Me.txtShortServerName.Location = New System.Drawing.Point(152, 256)
        Me.txtShortServerName.Name = "txtShortServerName"
        Me.txtShortServerName.Size = New System.Drawing.Size(368, 20)
        Me.txtShortServerName.TabIndex = 5
        Me.txtShortServerName.Text = ""
        '
        'txtUNCName
        '
        Me.txtUNCName.Location = New System.Drawing.Point(152, 288)
        Me.txtUNCName.Name = "txtUNCName"
        Me.txtUNCName.Size = New System.Drawing.Size(368, 20)
        Me.txtUNCName.TabIndex = 6
        Me.txtUNCName.Text = ""
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(8, 224)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(136, 23)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Server Name"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(8, 256)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(136, 23)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Short Server Name"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(8, 288)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(144, 23)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "UNC Name"
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(8, 320)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(136, 23)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Version Number"
        '
        'frmPrinters
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(528, 349)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label5, Me.Label4, Me.Label3, Me.Label2, Me.txtUNCName, Me.txtShortServerName, Me.txtVersionNumber, Me.txtServerName, Me.Label1, Me.txtPrinterName, Me.lbPrinters})
        Me.Name = "frmPrinters"
        Me.Text = "Discover Printers"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub frmPrinters_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim rootDSE As New DirectoryServices.DirectoryEntry("LDAP://rootDSE")
        Dim root As New DirectoryServices.DirectoryEntry("GC://" & rootDSE.Properties("defaultNamingContext").Value.ToString)
        Dim mySearcher As New DirectoryServices.DirectorySearcher(root)
        Dim groupPolicyObject As DirectoryServices.SearchResult
        mySearcher.Filter = ("(objectClass=printQueue)")
        For Each groupPolicyObject In mySearcher.FindAll()
            lbPrinters.Items.Add(groupPolicyObject.GetDirectoryEntry.Properties("distinguishedName").Value.ToString)
        Next

    End Sub

    Private Sub lbPrinters_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbPrinters.SelectedIndexChanged
        Dim gPOObject As New DirectoryServices.DirectoryEntry("LDAP://" & lbPrinters.SelectedItem.ToString)

        txtPrinterName.Clear()
        txtServerName.Clear()
        txtShortServerName.Clear()
        txtUNCName.Clear()
        txtVersionNumber.Clear()

        Try
            txtPrinterName.Text = gPOObject.Properties("printerName").Value.ToString
            txtVersionNumber.Text = gPOObject.Properties("versionNumber").Value.ToString
            txtServerName.Text = gPOObject.Properties("serverName").Value.ToString
            txtShortServerName.Text = gPOObject.Properties("shortServerName").Value.ToString
            txtUNCName.Text = gPOObject.Properties("uNCName").Value.ToString
        Catch
            Return
        End Try
    End Sub
End Class
