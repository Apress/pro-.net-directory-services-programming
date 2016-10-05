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
    Friend WithEvents lbGPO As System.Windows.Forms.ListBox
    Friend WithEvents txtDisplayName As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtVersionNumber As System.Windows.Forms.TextBox
    Friend WithEvents txtUserExtensionNames As System.Windows.Forms.TextBox
    Friend WithEvents txtPCFunctionality As System.Windows.Forms.TextBox
    Friend WithEvents txtMachineExtensionNames As System.Windows.Forms.TextBox
    Friend WithEvents txtPCFileSysPath As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.lbGPO = New System.Windows.Forms.ListBox()
        Me.txtDisplayName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtVersionNumber = New System.Windows.Forms.TextBox()
        Me.txtPCFunctionality = New System.Windows.Forms.TextBox()
        Me.txtUserExtensionNames = New System.Windows.Forms.TextBox()
        Me.txtMachineExtensionNames = New System.Windows.Forms.TextBox()
        Me.txtPCFileSysPath = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lbGPO
        '
        Me.lbGPO.HorizontalScrollbar = True
        Me.lbGPO.Location = New System.Drawing.Point(8, 8)
        Me.lbGPO.Name = "lbGPO"
        Me.lbGPO.Size = New System.Drawing.Size(512, 173)
        Me.lbGPO.TabIndex = 0
        '
        'txtDisplayName
        '
        Me.txtDisplayName.Location = New System.Drawing.Point(152, 192)
        Me.txtDisplayName.Name = "txtDisplayName"
        Me.txtDisplayName.Size = New System.Drawing.Size(368, 20)
        Me.txtDisplayName.TabIndex = 1
        Me.txtDisplayName.Text = ""
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 192)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(136, 23)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Display Name"
        '
        'txtVersionNumber
        '
        Me.txtVersionNumber.Location = New System.Drawing.Point(152, 224)
        Me.txtVersionNumber.Name = "txtVersionNumber"
        Me.txtVersionNumber.Size = New System.Drawing.Size(368, 20)
        Me.txtVersionNumber.TabIndex = 3
        Me.txtVersionNumber.Text = ""
        '
        'txtPCFunctionality
        '
        Me.txtPCFunctionality.Location = New System.Drawing.Point(152, 320)
        Me.txtPCFunctionality.Name = "txtPCFunctionality"
        Me.txtPCFunctionality.Size = New System.Drawing.Size(368, 20)
        Me.txtPCFunctionality.TabIndex = 4
        Me.txtPCFunctionality.Text = ""
        '
        'txtUserExtensionNames
        '
        Me.txtUserExtensionNames.Location = New System.Drawing.Point(152, 256)
        Me.txtUserExtensionNames.Name = "txtUserExtensionNames"
        Me.txtUserExtensionNames.Size = New System.Drawing.Size(368, 20)
        Me.txtUserExtensionNames.TabIndex = 5
        Me.txtUserExtensionNames.Text = ""
        '
        'txtMachineExtensionNames
        '
        Me.txtMachineExtensionNames.Location = New System.Drawing.Point(152, 288)
        Me.txtMachineExtensionNames.Name = "txtMachineExtensionNames"
        Me.txtMachineExtensionNames.Size = New System.Drawing.Size(368, 20)
        Me.txtMachineExtensionNames.TabIndex = 6
        Me.txtMachineExtensionNames.Text = ""
        '
        'txtPCFileSysPath
        '
        Me.txtPCFileSysPath.Location = New System.Drawing.Point(152, 352)
        Me.txtPCFileSysPath.Name = "txtPCFileSysPath"
        Me.txtPCFileSysPath.Size = New System.Drawing.Size(368, 20)
        Me.txtPCFileSysPath.TabIndex = 7
        Me.txtPCFileSysPath.Text = ""
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(8, 224)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(136, 23)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Version Number"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(8, 256)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(136, 23)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "User Extension Names"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(8, 288)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(144, 23)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Machine Extension Names"
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(8, 320)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(136, 23)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "PC Functionality"
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(8, 352)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(136, 23)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "PC File System Path"
        '
        'frmMain
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(528, 381)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label6, Me.Label5, Me.Label4, Me.Label3, Me.Label2, Me.txtPCFileSysPath, Me.txtMachineExtensionNames, Me.txtUserExtensionNames, Me.txtPCFunctionality, Me.txtVersionNumber, Me.Label1, Me.txtDisplayName, Me.lbGPO})
        Me.Name = "frmMain"
        Me.Text = "GPO Management"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim rootDSE As New DirectoryServices.DirectoryEntry("LDAP://rootDSE")
        Dim root As New DirectoryServices.DirectoryEntry("GC://" & rootDSE.Properties("defaultNamingContext").Value.ToString)
        Dim mySearcher As New DirectoryServices.DirectorySearcher(root)
        Dim groupPolicyObject As DirectoryServices.SearchResult
        mySearcher.Filter = ("(objectClass=groupPolicyContainer)")
        For Each groupPolicyObject In mySearcher.FindAll()
            lbGPO.Items.Add(groupPolicyObject.GetDirectoryEntry.Properties("distinguishedName").Value.ToString)
            'lbgpo.Items.Add("").
        Next
        lbGPO.SelectedIndex = 0

    End Sub

    Private Sub lbGPO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbGPO.SelectedIndexChanged
        Dim gPOObject As New DirectoryServices.DirectoryEntry("LDAP://" & lbGPO.SelectedItem.ToString)

        txtDisplayName.Clear()
        txtVersionNumber.Clear()
        txtUserExtensionNames.Clear()
        txtMachineExtensionNames.Clear()
        txtPCFunctionality.Clear()

        txtPCFileSysPath.Text = gPOObject.Properties("gPCFileSysPath").Value.ToString
        Try
            txtDisplayName.Text = gPOObject.Properties("displayName").Value.ToString
            txtVersionNumber.Text = gPOObject.Properties("versionNumber").Value.ToString
            txtUserExtensionNames.Text = gPOObject.Properties("gPCUserExtensionNames").Value.ToString
            txtMachineExtensionNames.Text = gPOObject.Properties("gPCMachineExtensionNames").Value.ToString
            txtPCFunctionality.Text = gPOObject.Properties("gPCFunctionalityVersion").Value.ToString
            txtPCFileSysPath.Text = gPOObject.Properties("gPCFileSysPath").Value.ToString
        Catch
            Return
        End Try
    End Sub
End Class
