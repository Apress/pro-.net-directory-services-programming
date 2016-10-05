Imports System.IO

Public Class frmClasses
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
    Friend WithEvents cmdGo As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtGovernsID As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCN As System.Windows.Forms.TextBox
    Friend WithEvents txtLDAPDisplayName As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lbAttributes As System.Windows.Forms.ListBox
    Friend WithEvents cmdLoad As System.Windows.Forms.Button
    Friend WithEvents cmdCode As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.cmdGo = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtGovernsID = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCN = New System.Windows.Forms.TextBox()
        Me.txtLDAPDisplayName = New System.Windows.Forms.TextBox()
        Me.lbAttributes = New System.Windows.Forms.ListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmdLoad = New System.Windows.Forms.Button()
        Me.cmdCode = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'cmdGo
        '
        Me.cmdGo.Location = New System.Drawing.Point(96, 256)
        Me.cmdGo.Name = "cmdGo"
        Me.cmdGo.TabIndex = 6
        Me.cmdGo.Text = "Create LDIF"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(8, 80)
        Me.Label4.Name = "Label4"
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "Class OID"
        '
        'txtGovernsID
        '
        Me.txtGovernsID.Location = New System.Drawing.Point(120, 80)
        Me.txtGovernsID.Name = "txtGovernsID"
        Me.txtGovernsID.Size = New System.Drawing.Size(232, 20)
        Me.txtGovernsID.TabIndex = 3
        Me.txtGovernsID.Text = ""
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(8, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(112, 23)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "LDAP Display Name"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(8, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Common Name"
        '
        'txtCN
        '
        Me.txtCN.Location = New System.Drawing.Point(120, 16)
        Me.txtCN.Name = "txtCN"
        Me.txtCN.Size = New System.Drawing.Size(232, 20)
        Me.txtCN.TabIndex = 1
        Me.txtCN.Text = ""
        '
        'txtLDAPDisplayName
        '
        Me.txtLDAPDisplayName.Location = New System.Drawing.Point(120, 48)
        Me.txtLDAPDisplayName.Name = "txtLDAPDisplayName"
        Me.txtLDAPDisplayName.Size = New System.Drawing.Size(232, 20)
        Me.txtLDAPDisplayName.TabIndex = 2
        Me.txtLDAPDisplayName.Text = ""
        '
        'lbAttributes
        '
        Me.lbAttributes.Location = New System.Drawing.Point(8, 136)
        Me.lbAttributes.Name = "lbAttributes"
        Me.lbAttributes.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lbAttributes.Size = New System.Drawing.Size(256, 95)
        Me.lbAttributes.Sorted = True
        Me.lbAttributes.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 112)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(144, 23)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "May Contain Attributes"
        '
        'cmdLoad
        '
        Me.cmdLoad.Location = New System.Drawing.Point(280, 176)
        Me.cmdLoad.Name = "cmdLoad"
        Me.cmdLoad.TabIndex = 4
        Me.cmdLoad.Text = "Load"
        '
        'cmdCode
        '
        Me.cmdCode.Location = New System.Drawing.Point(192, 256)
        Me.cmdCode.Name = "cmdCode"
        Me.cmdCode.Size = New System.Drawing.Size(96, 23)
        Me.cmdCode.TabIndex = 20
        Me.cmdCode.Text = "Create In Code"
        '
        'frmClasses
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(368, 301)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdCode, Me.cmdLoad, Me.Label1, Me.lbAttributes, Me.Label4, Me.txtGovernsID, Me.Label3, Me.Label2, Me.txtCN, Me.txtLDAPDisplayName, Me.cmdGo})
        Me.Name = "frmClasses"
        Me.Text = "Add Custom Classes"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub cmdGo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGo.Click
        Dim distinguishedName As String
        Dim lDAPDisplayName As String
        Dim governsID As String
        Dim item As Object

        Dim guidArray() As Byte
        Dim guid As New Guid()
        guidArray = guid.NewGuid().ToByteArray()

        Dim rootDSE As New DirectoryServices.DirectoryEntry("LDAP://rootDSE")
        Dim schemaRoot As New DirectoryServices.DirectoryEntry("LDAP://" & rootDSE.Properties("schemaNamingContext").Value.ToString)
        Dim domainRoot As New DirectoryServices.DirectoryEntry("LDAP://" & rootDSE.Properties("defaultNamingContext").Value.ToString)

        lDAPDisplayName = txtLDAPDisplayName.Text
        distinguishedName = txtCN.Text
        governsID = txtGovernsID.Text

        Dim objStreamWriter As New StreamWriter(Application.StartupPath & "\" & distinguishedName & ".ldf")

        'Write a second line of text.
        objStreamWriter.WriteLine("dn: CN=" & distinguishedName & "," & schemaRoot.Properties("distinguishedName").Value.ToString)
        objStreamWriter.WriteLine("changetype: add")
        objStreamWriter.WriteLine("adminDisplayName: " & distinguishedName)
        objStreamWriter.WriteLine("cn: " & distinguishedName)
        objStreamWriter.WriteLine("lDAPDisplayName: " & lDAPDisplayName)
        objStreamWriter.WriteLine("distinguishedName: CN=" & distinguishedName & "," & schemaRoot.Properties("distinguishedName").Value.ToString)
        objStreamWriter.WriteLine("objectCategory: CN=Class-Schema," & schemaRoot.Properties("distinguishedName").Value.ToString)
        objStreamWriter.WriteLine("objectClass: classSchema")
        objStreamWriter.WriteLine("name: " & distinguishedName)
        objStreamWriter.WriteLine("schemaIDGUID:: " & Convert.ToBase64String(guidArray))
        objStreamWriter.WriteLine("description: " & distinguishedName)
        objStreamWriter.WriteLine("adminDescription: " & distinguishedName)
        objStreamWriter.WriteLine("governsID: " & governsID)
        objStreamWriter.WriteLine("subClassOf: serviceConnectionPoint")
        objStreamWriter.WriteLine("objectClassCategory: 1")
        objStreamWriter.WriteLine("possSuperiors: organizationalUnit")
        objStreamWriter.WriteLine("possSuperiors: computer")
        objStreamWriter.WriteLine("possSuperiors: serviceConnectionPoint")
        For Each item In lbAttributes.SelectedItems
            objStreamWriter.WriteLine("systemMayContain: " & item.ToString)
        Next
        objStreamWriter.WriteLine("")
        objStreamWriter.WriteLine("dn:")
        objStreamWriter.WriteLine("changetype: modify")
        objStreamWriter.WriteLine("add: schemaUpdateNow")
        objStreamWriter.WriteLine("schemaUpdateNow: 1")
        objStreamWriter.WriteLine("-")

        'Close the file.
        objStreamWriter.Close()

        MsgBox("Class " & distinguishedName & " successfully added to " & distinguishedName & ".ldf")
    End Sub

    Private Sub cmdLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLoad.Click
        Me.Cursor = Cursors.WaitCursor
        Dim rootDSE As New DirectoryServices.DirectoryEntry("LDAP://rootDSE")
        Dim root As New DirectoryServices.DirectoryEntry("GC://" & rootDSE.Properties("defaultNamingContext").Value.ToString)
        Dim mySearcher As New DirectoryServices.DirectorySearcher(root)
        Dim attribute As DirectoryServices.SearchResult
        mySearcher.Filter = ("(objectClass=attributeSchema)")
        For Each attribute In mySearcher.FindAll()
            lbAttributes.Items.Add(attribute.GetDirectoryEntry.Properties("lDAPDisplayName").Value.ToString)
            System.Windows.Forms.Application.DoEvents()
        Next
        lbAttributes.SelectedIndex = -1
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub cmdCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCode.Click
        Dim distinguishedName As String
        Dim lDAPDisplayName As String
        Dim governsID As String
        Dim item As Object

        Dim guidArray() As Byte
        Dim guidID As New Guid()
        guidID = Guid.NewGuid()
        guidArray = guidID.ToByteArray()

        lDAPDisplayName = txtLDAPDisplayName.Text
        distinguishedName = txtCN.Text
        governsID = txtGovernsID.Text

        Dim rootDSE As New DirectoryServices.DirectoryEntry("LDAP://rootDSE")
        Dim schemaRoot As New DirectoryServices.DirectoryEntry("LDAP://" & rootDSE.Properties("schemaNamingContext").Value.ToString)
        Dim children As DirectoryServices.DirectoryEntries
        children = schemaRoot.Children

        Dim schemaClass As New DirectoryServices.DirectoryEntry()

        schemaClass = children.Add("cn=" & distinguishedName, "classSchema")
        schemaClass.Properties("adminDisplayName").Value = distinguishedName
        schemaClass.Properties("adminDescription").Value = distinguishedName
        schemaClass.Properties("description").Value = distinguishedName
        schemaClass.Properties("lDAPDisplayName").Value = lDAPDisplayName
        schemaClass.Properties("governsID").Value = governsID
        schemaClass.Properties("subClassOf").Value = "serviceConnectionPoint"
        schemaClass.Properties("objectClassCategory").Value = 1
        schemaClass.Properties("possSuperiors").Add("organizationalUnit")
        schemaClass.Properties("possSuperiors").Add("computer")
        schemaClass.Properties("possSuperiors").Add("serviceConnectionPoint")
        schemaClass.Properties("schemaIDGUID").Add(guidArray)
        For Each item In lbAttributes.SelectedItems
            schemaClass.Properties("systemMayContain").Add(item.ToString)
        Next
        schemaClass.CommitChanges()

        MsgBox("Class " & distinguishedName & " successfully added to the schema.")

    End Sub
End Class
