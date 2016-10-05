
Public Class frmMain
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
    Friend WithEvents cmdFind As System.Windows.Forms.Button
    Friend WithEvents rbtDomain As System.Windows.Forms.RadioButton
    Friend WithEvents rbtSchema As System.Windows.Forms.RadioButton
    Friend WithEvents rbtInfrastructure As System.Windows.Forms.RadioButton
    Friend WithEvents rbtRID As System.Windows.Forms.RadioButton
    Friend WithEvents rbtPDC As System.Windows.Forms.RadioButton
    Friend WithEvents lbResults As System.Windows.Forms.ListBox
    Friend WithEvents rbtDomainController As System.Windows.Forms.RadioButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.cmdFind = New System.Windows.Forms.Button()
        Me.rbtDomain = New System.Windows.Forms.RadioButton()
        Me.rbtSchema = New System.Windows.Forms.RadioButton()
        Me.rbtInfrastructure = New System.Windows.Forms.RadioButton()
        Me.rbtRID = New System.Windows.Forms.RadioButton()
        Me.rbtPDC = New System.Windows.Forms.RadioButton()
        Me.lbResults = New System.Windows.Forms.ListBox()
        Me.rbtDomainController = New System.Windows.Forms.RadioButton()
        Me.SuspendLayout()
        '
        'cmdFind
        '
        Me.cmdFind.Location = New System.Drawing.Point(112, 208)
        Me.cmdFind.Name = "cmdFind"
        Me.cmdFind.TabIndex = 0
        Me.cmdFind.Text = "Find!"
        '
        'rbtDomain
        '
        Me.rbtDomain.Location = New System.Drawing.Point(8, 136)
        Me.rbtDomain.Name = "rbtDomain"
        Me.rbtDomain.Size = New System.Drawing.Size(144, 24)
        Me.rbtDomain.TabIndex = 1
        Me.rbtDomain.Text = "Domain Naming Master"
        '
        'rbtSchema
        '
        Me.rbtSchema.Location = New System.Drawing.Point(8, 104)
        Me.rbtSchema.Name = "rbtSchema"
        Me.rbtSchema.TabIndex = 2
        Me.rbtSchema.Text = "Schema Master"
        '
        'rbtInfrastructure
        '
        Me.rbtInfrastructure.Location = New System.Drawing.Point(8, 72)
        Me.rbtInfrastructure.Name = "rbtInfrastructure"
        Me.rbtInfrastructure.Size = New System.Drawing.Size(128, 24)
        Me.rbtInfrastructure.TabIndex = 3
        Me.rbtInfrastructure.Text = "Infrastructure Master"
        '
        'rbtRID
        '
        Me.rbtRID.Location = New System.Drawing.Point(8, 40)
        Me.rbtRID.Name = "rbtRID"
        Me.rbtRID.TabIndex = 4
        Me.rbtRID.Text = "RID Master"
        '
        'rbtPDC
        '
        Me.rbtPDC.Location = New System.Drawing.Point(8, 8)
        Me.rbtPDC.Name = "rbtPDC"
        Me.rbtPDC.TabIndex = 5
        Me.rbtPDC.Text = "PDC Emulator"
        '
        'lbResults
        '
        Me.lbResults.HorizontalScrollbar = True
        Me.lbResults.Location = New System.Drawing.Point(8, 240)
        Me.lbResults.Name = "lbResults"
        Me.lbResults.Size = New System.Drawing.Size(288, 147)
        Me.lbResults.TabIndex = 6
        '
        'rbtDomainController
        '
        Me.rbtDomainController.Location = New System.Drawing.Point(8, 168)
        Me.rbtDomainController.Name = "rbtDomainController"
        Me.rbtDomainController.Size = New System.Drawing.Size(136, 24)
        Me.rbtDomainController.TabIndex = 7
        Me.rbtDomainController.Text = "All Domain Controllers"
        '
        'frmMain
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(304, 397)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.rbtDomainController, Me.lbResults, Me.rbtPDC, Me.rbtRID, Me.rbtInfrastructure, Me.rbtSchema, Me.rbtDomain, Me.cmdFind})
        Me.Name = "frmMain"
        Me.Text = "Discover FSMO Roles"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub cmdFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFind.Click
        Me.Cursor = Cursors.WaitCursor
        Dim strRole As String

        If rbtPDC.Checked Then
            strRole = "domainDNS"
        ElseIf rbtRID.Checked Then
            strRole = "rIDManager"
        ElseIf rbtInfrastructure.Checked Then
            strRole = "infrastructureUpdate"
        ElseIf rbtSchema.Checked Then
            strRole = "dMD"
        ElseIf rbtDomain.Checked Then
            strRole = "crossRefContainer"
        ElseIf rbtDomainController.Checked Then
            strRole = "nTDSDSA"
        End If

        Dim rootDSE As New DirectoryServices.DirectoryEntry("LDAP://rootDSE")
        Dim root As New DirectoryServices.DirectoryEntry("GC://" & rootDSE.Properties("defaultNamingContext").Value.ToString)
        Dim mySearcher As New DirectoryServices.DirectorySearcher(root)
        Dim res As DirectoryServices.SearchResult
        mySearcher.Filter = ("(objectClass=" & strRole & ")")
        For Each res In mySearcher.FindAll()
            If strRole <> "nTDSDSA" Then
                Dim fSMOEntry As New DirectoryServices.DirectoryEntry("LDAP://" & res.GetDirectoryEntry.Properties("distinguishedName").Value.ToString)
                Dim fSMOOwner As New DirectoryServices.DirectoryEntry("LDAP://" & fSMOEntry.Properties("fSMORoleOwner").Value.ToString)
                Dim fSMOParent As New DirectoryServices.DirectoryEntry(fSMOOwner.Parent.Path)
                lbResults.Items.Add(fSMOParent.Path)
            Else
                Dim fSMOEntry As New DirectoryServices.DirectoryEntry("LDAP://" & res.GetDirectoryEntry.Properties("distinguishedName").Value.ToString)
                lbResults.Items.Add(fSMOEntry.Path)
            End If
        Next
        Me.Cursor = Cursors.Arrow
    End Sub
End Class
