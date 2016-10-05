using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.DirectoryServices;

namespace DSChapter6_cSharp2
{
	/// <summary>
	/// Summary description for frmGroupMembership.
	/// </summary>
	public class frmGroupMembership : System.Windows.Forms.Form
	{
		internal System.Windows.Forms.Button btnRemoveUser;
		internal System.Windows.Forms.ListBox lstMembers;
		internal System.Windows.Forms.ComboBox cboGroups;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmGroupMembership()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.btnRemoveUser = new System.Windows.Forms.Button();
			this.lstMembers = new System.Windows.Forms.ListBox();
			this.cboGroups = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// btnRemoveUser
			// 
			this.btnRemoveUser.Location = new System.Drawing.Point(96, 201);
			this.btnRemoveUser.Name = "btnRemoveUser";
			this.btnRemoveUser.Size = new System.Drawing.Size(88, 23);
			this.btnRemoveUser.TabIndex = 8;
			this.btnRemoveUser.Text = "&Remove User";
			this.btnRemoveUser.Click += new System.EventHandler(this.btnRemoveUser_Click);
			// 
			// lstMembers
			// 
			this.lstMembers.Location = new System.Drawing.Point(21, 81);
			this.lstMembers.Name = "lstMembers";
			this.lstMembers.Size = new System.Drawing.Size(250, 95);
			this.lstMembers.TabIndex = 7;
			// 
			// cboGroups
			// 
			this.cboGroups.Location = new System.Drawing.Point(86, 49);
			this.cboGroups.Name = "cboGroups";
			this.cboGroups.Size = new System.Drawing.Size(121, 21);
			this.cboGroups.TabIndex = 6;
			this.cboGroups.Text = "Groups";
			this.cboGroups.SelectedIndexChanged += new System.EventHandler(this.cboGroups_SelectedIndexChanged);
			// 
			// frmGroupMembership
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 273);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.btnRemoveUser,
																		  this.lstMembers,
																		  this.cboGroups});
			this.Name = "frmGroupMembership";
			this.Text = "frmGroupMembership";
			this.Load += new System.EventHandler(this.frmGroupMembership_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void frmGroupMembership_Load(object sender, System.EventArgs e)
		{
		//Populates the two combo boxes

		//The path the the OU we will be working in
		string strLdapPath = "LDAP://" + frmMain.strServerName + "/OU=" + frmMain.strOU + ",DC=" + frmMain.strThirdLevelDomain + ",DC=" + 
		frmMain.strSecondLevelDomain + ",DC=" + frmMain.strTopLevelDomain;

		DirectoryEntry objOU = new DirectoryEntry(strLdapPath); //An object representing the OU
		DirectorySearcher objGroupSearcher = new DirectorySearcher(objOU); //A DirectorySearcher to be used to search our OU
      
        SearchResultCollection objResults; //The collection that will contain the results of our search

        objGroupSearcher.PropertiesToLoad.Add("cn"); //Return only the CN of the group object
        objGroupSearcher.Filter = "(objectClass=group)";//Return only group objects
        objResults = objGroupSearcher.FindAll();//Perform search

		//Loop throught the search results and add them to cboGroups
        foreach (SearchResult objResult in objResults)
            cboGroups.Items.Add(objResult.Properties["cn"][0]);
        
		//Free resources
        objResults = null;
		objGroupSearcher = null;
        objOU.Close();
        objOU = null;
		}

		private void cboGroups_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		//Enumerate the selected group's membership and populate the list box

		lstMembers.Items.Clear(); //Reset the list box

		//Path to the group selected in the combo box
        string strGroupPath = "LDAP://" + frmMain.strServerName + "/CN=" + cboGroups.Text + ",OU=" + frmMain.strOU + ",DC=" +
        frmMain.strThirdLevelDomain + ",DC=" + frmMain.strSecondLevelDomain + ",DC=" + frmMain.strTopLevelDomain;

        DirectoryEntry objGroup = new DirectoryEntry(strGroupPath); //An object representing the group selected

        //Enumerate the groups group members and add the members to the list box
        foreach (string strMemberName in objGroup.Properties["member"])
            lstMembers.Items.Add(strMemberName);
		
		//Free resources
        objGroup.Close();
        objGroup = null;
		}

		private void btnRemoveUser_Click(object sender, System.EventArgs e)
		{
		//Removes the selected user from a group

        //The fully qualified path to our group object
        string strGroupPath = "LDAP://" + frmMain.strServerName + "/CN=" + cboGroups.Text + ",OU=" + frmMain.strOU + ",DC=" +
        frmMain.strThirdLevelDomain + ",DC=" + frmMain.strSecondLevelDomain + ",DC=" + frmMain.strTopLevelDomain;

        //The fully qualified path to the group member object
        string strUserPath = "LDAP://" + frmMain.strServerName + "/" + lstMembers.SelectedItem;
        int intSelectedItem = lstMembers.SelectedIndex; //The index in the list box of the user to be removed

        //Bind to our group object
        DirectoryEntry objGroup = new DirectoryEntry(strGroupPath);

		try
		{
			//Removes a group member from objGroup
			objGroup.Invoke("Remove", strUserPath);

			//Inform the user that the member has been removed.
			MessageBox.Show("Group member has been removed from " + cboGroups.Text + ".", "Group Membership",MessageBoxButtons.OK, MessageBoxIcon.Asterisk);	

			lstMembers.Items.RemoveAt(intSelectedItem); //Removes the user from the list box
		}

		catch (System.Reflection.TargetInvocationException ex)
		{
			MessageBox.Show("An error has occured. It is possible that the user you are attempting to remove is no longer a member of that group: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		finally
		{
			//Free resources
			objGroup.Close();
			objGroup = null;
		}

		}
	}
}
