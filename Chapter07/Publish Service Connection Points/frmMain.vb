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
    Friend WithEvents cmdCreateSCP As System.Windows.Forms.Button
    Friend WithEvents lbComputers As System.Windows.Forms.ListBox
    Friend WithEvents NotifyIcon1 As System.Windows.Forms.NotifyIcon
    Friend WithEvents txtServiceDNSName As System.Windows.Forms.TextBox
    Friend WithEvents txtCN As System.Windows.Forms.TextBox
    Friend WithEvents txtServiceClassName As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtKeywords As System.Windows.Forms.TextBox
    Friend WithEvents lbKeywords As System.Windows.Forms.ListBox
    Friend WithEvents cmdAddKeywords As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents label6 As System.Windows.Forms.Label
    Friend WithEvents cmdAddBinding As System.Windows.Forms.Button
    Friend WithEvents lbServiceBindingInformation As System.Windows.Forms.ListBox
    Friend WithEvents txtBindingInformation As System.Windows.Forms.TextBox
    Friend WithEvents cboSCPClass As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.cmdCreateSCP = New System.Windows.Forms.Button()
        Me.lbComputers = New System.Windows.Forms.ListBox()
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.txtServiceDNSName = New System.Windows.Forms.TextBox()
        Me.txtCN = New System.Windows.Forms.TextBox()
        Me.txtServiceClassName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtKeywords = New System.Windows.Forms.TextBox()
        Me.lbKeywords = New System.Windows.Forms.ListBox()
        Me.cmdAddKeywords = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.label6 = New System.Windows.Forms.Label()
        Me.cmdAddBinding = New System.Windows.Forms.Button()
        Me.lbServiceBindingInformation = New System.Windows.Forms.ListBox()
        Me.txtBindingInformation = New System.Windows.Forms.TextBox()
        Me.cboSCPClass = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'cmdCreateSCP
        '
        Me.cmdCreateSCP.Location = New System.Drawing.Point(216, 640)
        Me.cmdCreateSCP.Name = "cmdCreateSCP"
        Me.cmdCreateSCP.TabIndex = 8
        Me.cmdCreateSCP.Text = "Create SCP"
        '
        'lbComputers
        '
        Me.lbComputers.Location = New System.Drawing.Point(8, 32)
        Me.lbComputers.Name = "lbComputers"
        Me.lbComputers.Size = New System.Drawing.Size(504, 199)
        Me.lbComputers.TabIndex = 9
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.Text = "NotifyIcon1"
        Me.NotifyIcon1.Visible = True
        '
        'txtServiceDNSName
        '
        Me.txtServiceDNSName.Location = New System.Drawing.Point(128, 272)
        Me.txtServiceDNSName.Name = "txtServiceDNSName"
        Me.txtServiceDNSName.Size = New System.Drawing.Size(384, 20)
        Me.txtServiceDNSName.TabIndex = 2
        Me.txtServiceDNSName.Text = ""
        '
        'txtCN
        '
        Me.txtCN.Location = New System.Drawing.Point(128, 240)
        Me.txtCN.Name = "txtCN"
        Me.txtCN.Size = New System.Drawing.Size(384, 20)
        Me.txtCN.TabIndex = 1
        Me.txtCN.Text = ""
        '
        'txtServiceClassName
        '
        Me.txtServiceClassName.Location = New System.Drawing.Point(128, 304)
        Me.txtServiceClassName.Name = "txtServiceClassName"
        Me.txtServiceClassName.Size = New System.Drawing.Size(384, 20)
        Me.txtServiceClassName.TabIndex = 3
        Me.txtServiceClassName.Text = ""
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 240)
        Me.Label1.Name = "Label1"
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "SCP CN"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(8, 272)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 23)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Service DNS Name"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(8, 304)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(112, 23)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Service Class Name"
        '
        'txtKeywords
        '
        Me.txtKeywords.Location = New System.Drawing.Point(8, 408)
        Me.txtKeywords.Name = "txtKeywords"
        Me.txtKeywords.TabIndex = 4
        Me.txtKeywords.Text = ""
        '
        'lbKeywords
        '
        Me.lbKeywords.Location = New System.Drawing.Point(216, 408)
        Me.lbKeywords.Name = "lbKeywords"
        Me.lbKeywords.Size = New System.Drawing.Size(296, 95)
        Me.lbKeywords.TabIndex = 10
        '
        'cmdAddKeywords
        '
        Me.cmdAddKeywords.Location = New System.Drawing.Point(128, 408)
        Me.cmdAddKeywords.Name = "cmdAddKeywords"
        Me.cmdAddKeywords.TabIndex = 5
        Me.cmdAddKeywords.Text = "- >"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(216, 384)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 16)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Keywords"
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(8, 8)
        Me.Label5.Name = "Label5"
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Computer"
        '
        'label6
        '
        Me.label6.Location = New System.Drawing.Point(216, 512)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(128, 16)
        Me.label6.TabIndex = 16
        Me.label6.Text = "Binding Information"
        '
        'cmdAddBinding
        '
        Me.cmdAddBinding.Location = New System.Drawing.Point(128, 536)
        Me.cmdAddBinding.Name = "cmdAddBinding"
        Me.cmdAddBinding.TabIndex = 7
        Me.cmdAddBinding.Text = "- >"
        '
        'lbServiceBindingInformation
        '
        Me.lbServiceBindingInformation.Location = New System.Drawing.Point(216, 536)
        Me.lbServiceBindingInformation.Name = "lbServiceBindingInformation"
        Me.lbServiceBindingInformation.Size = New System.Drawing.Size(296, 95)
        Me.lbServiceBindingInformation.TabIndex = 11
        '
        'txtBindingInformation
        '
        Me.txtBindingInformation.Location = New System.Drawing.Point(8, 536)
        Me.txtBindingInformation.Name = "txtBindingInformation"
        Me.txtBindingInformation.TabIndex = 6
        Me.txtBindingInformation.Text = ""
        '
        'cboSCPClass
        '
        Me.cboSCPClass.Location = New System.Drawing.Point(128, 336)
        Me.cboSCPClass.Name = "cboSCPClass"
        Me.cboSCPClass.Size = New System.Drawing.Size(384, 21)
        Me.cboSCPClass.TabIndex = 17
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(8, 336)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(120, 23)
        Me.Label7.TabIndex = 18
        Me.Label7.Text = "Connection Point Type"
        '
        'frmMain
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(520, 669)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label7, Me.cboSCPClass, Me.label6, Me.cmdAddBinding, Me.lbServiceBindingInformation, Me.txtBindingInformation, Me.Label5, Me.Label4, Me.cmdAddKeywords, Me.lbKeywords, Me.txtKeywords, Me.Label3, Me.Label2, Me.Label1, Me.txtServiceClassName, Me.txtCN, Me.txtServiceDNSName, Me.lbComputers, Me.cmdCreateSCP})
        Me.Name = "frmMain"
        Me.Text = "Publish Service Connection Points"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub cmdCreateSCP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCreateSCP.Click
        Dim i As Integer

        Dim computer As New DirectoryServices.DirectoryEntry("LDAP://" & lbComputers.SelectedItem.ToString)
        Dim children As DirectoryServices.DirectoryEntries
        children = computer.Children
        Dim serviceConnectionPoint As New DirectoryServices.DirectoryEntry()
        serviceConnectionPoint = children.Add("CN=" & txtCN.Text, cboSCPClass.Text)
        serviceConnectionPoint.CommitChanges()
        serviceConnectionPoint.Properties("serviceClassName").Value = txtServiceClassName.Text
        serviceConnectionPoint.Properties("serviceDNSName").Value = txtServiceDNSName.Text

        For i = 1 To lbKeywords.Items.Count
            serviceConnectionPoint.Properties("keywords").Add(lbKeywords.Items(i - 1).ToString)
        Next

        For i = 1 To lbServiceBindingInformation.Items.Count
            serviceConnectionPoint.Properties("serviceBindingInformation").Add(lbServiceBindingInformation.Items(i - 1).ToString)
        Next

        serviceConnectionPoint.CommitChanges()

        MsgBox("Service connection point created successfully")
    End Sub

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim rootDSE As New DirectoryServices.DirectoryEntry("LDAP://rootDSE")
        Dim root As New DirectoryServices.DirectoryEntry("GC://" & rootDSE.Properties("defaultNamingContext").Value.ToString)
        Dim mySearcher As New DirectoryServices.DirectorySearcher(root)
        Dim computer As DirectoryServices.SearchResult
        mySearcher.Filter = ("(objectClass=computer)")
        For Each computer In mySearcher.FindAll()
            lbComputers.Items.Add(computer.GetDirectoryEntry.Properties("distinguishedName").Value.ToString)
        Next
        lbComputers.SelectedIndex = 0

        Dim configRoot As New DirectoryServices.DirectoryEntry("LDAP://" & rootDSE.Properties("schemaNamingContext").Value.ToString)
        Dim configSearcher As New DirectoryServices.DirectorySearcher(configRoot)
        Dim sCPClass As DirectoryServices.SearchResult
        configSearcher.Filter = ("(subClassOf=serviceConnectionPoint)")
        For Each sCPClass In configSearcher.FindAll()
            cboSCPClass.Items.Add(sCPClass.GetDirectoryEntry.Properties("lDAPDisplayName").Value.ToString)
        Next
        cboSCPClass.Items.Add("serviceConnectionPoint")
        cboSCPClass.SelectedIndex = 0
        lbComputers.SelectedIndex = 0

    End Sub

    Private Sub cmdAddKeywords_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddKeywords.Click
        lbKeywords.Items.Add(txtKeywords.Text)
        txtKeywords.Text = ""
    End Sub

    Private Sub cmdAddBinding_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddBinding.Click
        lbServiceBindingInformation.Items.Add(txtBindingInformation.Text)
        txtBindingInformation.Text = ""
    End Sub

    Private Sub txtServiceDNSName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtServiceDNSName.TextChanged

    End Sub
End Class
