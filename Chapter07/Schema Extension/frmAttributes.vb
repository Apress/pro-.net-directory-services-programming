Imports System.IO

Public Class frmAttributes

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
    Friend WithEvents cboSyntax As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtLDAPDisplayName As System.Windows.Forms.TextBox
    Friend WithEvents txtCN As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents chkGC As System.Windows.Forms.CheckBox
    Friend WithEvents chkSingleValued As System.Windows.Forms.CheckBox
    Friend WithEvents txtAttributeID As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmdCode As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.cboSyntax = New System.Windows.Forms.ComboBox()
        Me.cmdGo = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtLDAPDisplayName = New System.Windows.Forms.TextBox()
        Me.txtCN = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.chkGC = New System.Windows.Forms.CheckBox()
        Me.chkSingleValued = New System.Windows.Forms.CheckBox()
        Me.txtAttributeID = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmdCode = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'cboSyntax
        '
        Me.cboSyntax.Items.AddRange(New Object() {"AccessPointDN", "Boolean", "CaseExactString", "CaseIgnoreString", "DirectoryString", "DN", "DNWithOctetString", "DNWithString", "Enumeration", "GeneralizedTime", "IASString", "Integer", "INTEGER8", "NumericString", "ObjectSecurityDescriptor", "OctetString", "OID", "ORName", "PresentationAddress", "PrintableString", "ReplicaLink", "Sid", "UTCTime"})
        Me.cboSyntax.Location = New System.Drawing.Point(120, 88)
        Me.cboSyntax.Name = "cboSyntax"
        Me.cboSyntax.Size = New System.Drawing.Size(232, 21)
        Me.cboSyntax.Sorted = True
        Me.cboSyntax.TabIndex = 3
        '
        'cmdGo
        '
        Me.cmdGo.Location = New System.Drawing.Point(96, 240)
        Me.cmdGo.Name = "cmdGo"
        Me.cmdGo.TabIndex = 7
        Me.cmdGo.Text = "Create LDIF"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 88)
        Me.Label1.Name = "Label1"
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Attribute Syntax"
        '
        'txtLDAPDisplayName
        '
        Me.txtLDAPDisplayName.Location = New System.Drawing.Point(120, 56)
        Me.txtLDAPDisplayName.Name = "txtLDAPDisplayName"
        Me.txtLDAPDisplayName.Size = New System.Drawing.Size(232, 20)
        Me.txtLDAPDisplayName.TabIndex = 2
        Me.txtLDAPDisplayName.Text = ""
        '
        'txtCN
        '
        Me.txtCN.Location = New System.Drawing.Point(120, 24)
        Me.txtCN.Name = "txtCN"
        Me.txtCN.Size = New System.Drawing.Size(232, 20)
        Me.txtCN.TabIndex = 1
        Me.txtCN.Text = ""
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(8, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Common Name"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(8, 56)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(112, 23)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "LDAP Display Name"
        '
        'chkGC
        '
        Me.chkGC.Location = New System.Drawing.Point(8, 168)
        Me.chkGC.Name = "chkGC"
        Me.chkGC.Size = New System.Drawing.Size(240, 24)
        Me.chkGC.TabIndex = 5
        Me.chkGC.Text = "Is Member Of Gloabl Catalog"
        '
        'chkSingleValued
        '
        Me.chkSingleValued.Location = New System.Drawing.Point(8, 200)
        Me.chkSingleValued.Name = "chkSingleValued"
        Me.chkSingleValued.Size = New System.Drawing.Size(216, 24)
        Me.chkSingleValued.TabIndex = 6
        Me.chkSingleValued.Text = "Is Single Valued"
        '
        'txtAttributeID
        '
        Me.txtAttributeID.Location = New System.Drawing.Point(120, 120)
        Me.txtAttributeID.Name = "txtAttributeID"
        Me.txtAttributeID.Size = New System.Drawing.Size(232, 20)
        Me.txtAttributeID.TabIndex = 4
        Me.txtAttributeID.Text = ""
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(8, 120)
        Me.Label4.Name = "Label4"
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Attribute OID"
        '
        'cmdCode
        '
        Me.cmdCode.Location = New System.Drawing.Point(184, 240)
        Me.cmdCode.Name = "cmdCode"
        Me.cmdCode.Size = New System.Drawing.Size(88, 23)
        Me.cmdCode.TabIndex = 12
        Me.cmdCode.Text = "Create in Code"
        '
        'frmAttributes
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(360, 277)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdCode, Me.Label4, Me.txtAttributeID, Me.chkSingleValued, Me.chkGC, Me.Label3, Me.Label2, Me.txtCN, Me.txtLDAPDisplayName, Me.Label1, Me.cmdGo, Me.cboSyntax})
        Me.Name = "frmAttributes"
        Me.Text = "Add Custom Attributes"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub cmdCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCode.Click
        Dim attributeSyntax As String
        Dim oMSyntax As Integer
        Dim distinguishedName As String
        Dim lDAPDisplayName As String
        Dim isSingleValued As Boolean
        Dim isMemberOfGC As Boolean
        Dim attributeID As String

        lDAPDisplayName = txtLDAPDisplayName.Text
        distinguishedName = txtCN.Text
        attributeID = txtAttributeID.Text

        isSingleValued = chkSingleValued.Checked
        isMemberOfGC = chkGC.Checked

        Select Case cboSyntax.Text
            Case "Boolean"
                attributeSyntax = "2.5.5.8"
                oMSyntax = 1
            Case "Integer"
                attributeSyntax = "2.5.5.9"
                oMSyntax = 2
            Case "OctetString"
                attributeSyntax = "2.5.5.10"
                oMSyntax = 4
            Case "INTEGER8"
                attributeSyntax = "2.5.5.16"
                oMSyntax = 65
            Case "ObjectSecurityDescriptor"
                attributeSyntax = "2.5.5.15"
                oMSyntax = 66
            Case "DN"
                attributeSyntax = "2.5.5.1"
                oMSyntax = 127
            Case "DNWithOctetString"
                attributeSyntax = "2.5.5.7"
                oMSyntax = 127
            Case "ORName"
                attributeSyntax = "2.5.5.7"
                oMSyntax = 127
            Case "CaseExactString"
                attributeSyntax = "2.5.5.3"
                oMSyntax = 27
            Case "DirectoryString"
                attributeSyntax = "2.5.5.12"
                oMSyntax = 64
            Case "GeneralizedTime"
                attributeSyntax = "2.5.5.11"
                oMSyntax = 24
            Case "IASString"
                attributeSyntax = "2.5.5.5"
                oMSyntax = 22
            Case "NumericString"
                attributeSyntax = "2.5.5.6"
                oMSyntax = 18
            Case "OID"
                attributeSyntax = "2.5.5.2"
                oMSyntax = 6
            Case "UTCTime"
                attributeSyntax = "2.5.5.11"
                oMSyntax = 23
            Case "CaseIgnoreString"
                attributeSyntax = "2.5.5.4"
                oMSyntax = 20
            Case "AccessPointDN"
                attributeSyntax = "2.5.5.14"
                oMSyntax = 127
            Case "PresentationAddress"
                attributeSyntax = "2.5.5.13"
                oMSyntax = 127
            Case "PrintableString"
                attributeSyntax = "2.5.5.5"
                oMSyntax = 19
            Case "DNWithString"
                attributeSyntax = "2.5.5.14"
                oMSyntax = 127
            Case "Enumeration"
                attributeSyntax = "2.5.5.9"
                oMSyntax = 10
            Case "ReplicaLink"
                attributeSyntax = "2.5.5.10"
                oMSyntax = 127
            Case "Sid"
                attributeSyntax = "2.5.5.17"
                oMSyntax = 4
        End Select
        Dim guidArray() As Byte
        Dim guidID As New Guid()
        guidID = guid.NewGuid()
        guidArray = guidID.ToByteArray()


        Dim rootDSE As New DirectoryServices.DirectoryEntry("LDAP://rootDSE")
        Dim root As New DirectoryServices.DirectoryEntry("LDAP://" & rootDSE.Properties("schemaNamingContext").Value.ToString)
        Dim children As DirectoryServices.DirectoryEntries
        children = root.Children

        Dim schemaAttribute As New DirectoryServices.DirectoryEntry()

        schemaAttribute = children.Add("cn=" & distinguishedName, "attributeSchema")
        schemaAttribute.Properties("adminDisplayName").Value = distinguishedName
        schemaAttribute.Properties("adminDescription").Value = distinguishedName
        schemaAttribute.Properties("description").Value = distinguishedName
        schemaAttribute.Properties("lDAPDisplayName").Value = lDAPDisplayName
        schemaAttribute.Properties("isSingleValued").Value = UCase(isSingleValued)
        schemaAttribute.Properties("instanceType").Value = 4
        schemaAttribute.Properties("oMSyntax").Value = oMSyntax
        schemaAttribute.Properties("attributeSyntax").Value = attributeSyntax
        schemaAttribute.Properties("isMemberOfPartialAttributeSet").Value = UCase(isMemberOfGC)
        schemaAttribute.Properties("attributeID").Value = attributeID
        schemaAttribute.Properties("schemaIDGUID").Add(guidArray)
        schemaAttribute.CommitChanges()

        MsgBox("Attribute " & distinguishedName & " successfully added to the schema.")
    End Sub

    Private Sub cmdGo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGo.Click
        Dim attributeSyntax As String
        Dim oMSyntax As Integer
        Dim distinguishedName As String
        Dim lDAPDisplayName As String
        Dim isSingleValued As Boolean
        Dim isMemberOfGC As Boolean
        Dim attributeID As String

        Dim guidArray() As Byte
        Dim guid As New Guid()
        guidArray = guid.NewGuid().ToByteArray()

        Dim rootDSE As New DirectoryServices.DirectoryEntry("LDAP://rootDSE")
        Dim schemaRoot As New DirectoryServices.DirectoryEntry("LDAP://" & rootDSE.Properties("schemaNamingContext").Value.ToString)
        Dim domainRoot As New DirectoryServices.DirectoryEntry("LDAP://" & rootDSE.Properties("defaultNamingContext").Value.ToString)

        lDAPDisplayName = txtLDAPDisplayName.Text
        distinguishedName = txtCN.Text
        attributeID = txtAttributeID.Text

        isSingleValued = chkSingleValued.Checked
        isMemberOfGC = chkGC.Checked

        Select Case cboSyntax.Text
            Case "Boolean"
                attributeSyntax = "2.5.5.8"
                oMSyntax = 1
            Case "Integer"
                attributeSyntax = "2.5.5.9"
                oMSyntax = 2
            Case "OctetString"
                attributeSyntax = "2.5.5.10"
                oMSyntax = 4
            Case "INTEGER8"
                attributeSyntax = "2.5.5.16"
                oMSyntax = 65
            Case "ObjectSecurityDescriptor"
                attributeSyntax = "2.5.5.15"
                oMSyntax = 66
            Case "DN"
                attributeSyntax = "2.5.5.1"
                oMSyntax = 127
            Case "DNWithOctetString"
                attributeSyntax = "2.5.5.7"
                oMSyntax = 127
            Case "ORName"
                attributeSyntax = "2.5.5.7"
                oMSyntax = 127
            Case "CaseExactString"
                attributeSyntax = "2.5.5.3"
                oMSyntax = 27
            Case "DirectoryString"
                attributeSyntax = "2.5.5.12"
                oMSyntax = 64
            Case "GeneralizedTime"
                attributeSyntax = "2.5.5.11"
                oMSyntax = 24
            Case "IASString"
                attributeSyntax = "2.5.5.5"
                oMSyntax = 22
            Case "NumericString"
                attributeSyntax = "2.5.5.6"
                oMSyntax = 18
            Case "OID"
                attributeSyntax = "2.5.5.2"
                oMSyntax = 6
            Case "UTCTime"
                attributeSyntax = "2.5.5.11"
                oMSyntax = 23
            Case "CaseIgnoreString"
                attributeSyntax = "2.5.5.4"
                oMSyntax = 20
            Case "AccessPointDN"
                attributeSyntax = "2.5.5.14"
                oMSyntax = 127
            Case "PresentationAddress"
                attributeSyntax = "2.5.5.13"
                oMSyntax = 127
            Case "PrintableString"
                attributeSyntax = "2.5.5.5"
                oMSyntax = 19
            Case "DNWithString"
                attributeSyntax = "2.5.5.14"
                oMSyntax = 127
            Case "Enumeration"
                attributeSyntax = "2.5.5.9"
                oMSyntax = 10
            Case "ReplicaLink"
                attributeSyntax = "2.5.5.10"
                oMSyntax = 127
            Case "Sid"
                attributeSyntax = "2.5.5.17"
                oMSyntax = 4
        End Select

        Dim objStreamWriter As New StreamWriter(Application.StartupPath & "\" & distinguishedName & ".ldf")

        'Write a second line of text.
        objStreamWriter.WriteLine("dn: CN=" & distinguishedName & "," & schemaRoot.Properties("distinguishedName").Value.ToString)
        objStreamWriter.WriteLine("changetype: add")
        objStreamWriter.WriteLine("adminDisplayName: " & distinguishedName)
        objStreamWriter.WriteLine("cn: " & distinguishedName)
        objStreamWriter.WriteLine("instanceType: 4")
        objStreamWriter.WriteLine("isSingleValued: " & UCase(isSingleValued))
        objStreamWriter.WriteLine("lDAPDisplayName: " & lDAPDisplayName)
        objStreamWriter.WriteLine("distinguishedName: CN=" & distinguishedName & "," & schemaRoot.Properties("distinguishedName").Value.ToString)
        objStreamWriter.WriteLine("objectCategory: CN=Attribute-Schema," & schemaRoot.Properties("distinguishedName").Value.ToString)
        objStreamWriter.WriteLine("objectClass: attributeSchema")
        objStreamWriter.WriteLine("oMSyntax: " & oMSyntax)
        objStreamWriter.WriteLine("name: " & distinguishedName)
        objStreamWriter.WriteLine("showInAdvancedViewOnly: TRUE")
        objStreamWriter.WriteLine("isMemberOfPartialAttributeSet: " & UCase(isMemberOfGC))
        objStreamWriter.WriteLine("schemaIDGUID:: " & Convert.ToBase64String(guidArray))
        objStreamWriter.WriteLine("attributeID: " & attributeID)
        objStreamWriter.WriteLine("attributeSyntax: " & attributeSyntax)
        objStreamWriter.WriteLine("description: " & distinguishedName)
        objStreamWriter.WriteLine("")
        objStreamWriter.WriteLine("dn:")
        objStreamWriter.WriteLine("changetype: modify")
        objStreamWriter.WriteLine("add: schemaUpdateNow")
        objStreamWriter.WriteLine("schemaUpdateNow: 1")
        objStreamWriter.WriteLine("-")

        'Close the file.
        objStreamWriter.Close()

        MsgBox("Attribute " & distinguishedName & " successfully added to " & distinguishedName & ".ldf")

    End Sub

End Class
