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
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents lbOUs As System.Windows.Forms.ListBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCN As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtSAM As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.lbOUs = New System.Windows.Forms.ListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCN = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtSAM = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(184, 232)
        Me.Button1.Name = "Button1"
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Go"
        '
        'lbOUs
        '
        Me.lbOUs.Location = New System.Drawing.Point(8, 32)
        Me.lbOUs.Name = "lbOUs"
        Me.lbOUs.Size = New System.Drawing.Size(424, 95)
        Me.lbOUs.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Parent OU"
        '
        'txtCN
        '
        Me.txtCN.Location = New System.Drawing.Point(136, 136)
        Me.txtCN.Name = "txtCN"
        Me.txtCN.Size = New System.Drawing.Size(296, 20)
        Me.txtCN.TabIndex = 3
        Me.txtCN.Text = ""
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(8, 136)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 23)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Common Name (CN)"
        '
        'txtSAM
        '
        Me.txtSAM.Location = New System.Drawing.Point(136, 168)
        Me.txtSAM.Name = "txtSAM"
        Me.txtSAM.Size = New System.Drawing.Size(296, 20)
        Me.txtSAM.TabIndex = 5
        Me.txtSAM.Text = ""
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(8, 168)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(120, 23)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "SAM Account Name"
        '
        'txtDescription
        '
        Me.txtDescription.Location = New System.Drawing.Point(136, 200)
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(296, 20)
        Me.txtDescription.TabIndex = 7
        Me.txtDescription.Text = ""
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(8, 200)
        Me.Label4.Name = "Label4"
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Description"
        '
        'frmMain
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(440, 261)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label4, Me.txtDescription, Me.Label3, Me.txtSAM, Me.Label2, Me.txtCN, Me.Label1, Me.lbOUs, Me.Button1})
        Me.Name = "frmMain"
        Me.Text = "Create Computer"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim rootDSE As New DirectoryServices.DirectoryEntry("LDAP://rootDSE")
        Dim root As New DirectoryServices.DirectoryEntry("GC://" & rootDSE.Properties("defaultNamingContext").Value.ToString)
        Dim mySearcher As New DirectoryServices.DirectorySearcher(root)
        Dim OU As DirectoryServices.SearchResult
        mySearcher.Filter = ("(objectClass=organizationalUnit)")
        For Each OU In mySearcher.FindAll()
            lbOUs.Items.Add(OU.GetDirectoryEntry.Properties("distinguishedName").Value.ToString)
        Next
        lbOUs.SelectedIndex = 0
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim OU As New DirectoryServices.DirectoryEntry("LDAP://" & lbOUs.SelectedItem.ToString)
        Dim children As DirectoryServices.DirectoryEntries
        children = OU.Children
        Dim computer As New DirectoryServices.DirectoryEntry()
        computer = children.Add("CN=" & txtCN.Text, "computer")
        computer.Properties("sAMAccountName").Add(txtSAM.Text)
        computer.Properties("description").Add(txtDescription.Text)
        computer.Properties("userAccountControl").Value = 544
        computer.CommitChanges()

        MsgBox("Computer created successfully")
    End Sub
End Class
