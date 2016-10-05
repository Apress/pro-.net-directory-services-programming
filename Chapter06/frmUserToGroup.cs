using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.DirectoryServices;

namespace DSChapter6_cSharp2
{
	/// <summary>
	/// Summary description for frmUserToGroup.
	/// </summary>
	public class frmUserToGroup : System.Windows.Forms.Form
	{
		internal System.Windows.Forms.Button btnAddUserToGroup;
		internal System.Windows.Forms.ComboBox cboGroup;
		internal System.Windows.Forms.ComboBox cboUser;
		internal System.Windows.Forms.Label lblGroup;
		internal System.Windows.Forms.Label lblUser;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmUserToGroup()
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
			this.btnAddUserToGroup = new System.Windows.Forms.Button();
			this.cboGroup = new System.Windows.Forms.ComboBox();
			this.cboUser = new System.Windows.Forms.ComboBox();
			this.lblGroup = new System.Windows.Forms.Label();
			this.lblUser = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// btnAddUserToGroup
			// 
			this.btnAddUserToGroup.Location = new System.Drawing.Point(80, 80);
			this.btnAddUserToGroup.Name = "btnAddUserToGroup";
			this.btnAddUserToGroup.Size = new System.Drawing.Size(128, 23);
			this.btnAddUserToGroup.TabIndex = 14;
			this.btnAddUserToGroup.Text = "&Add User to Group";
			this.btnAddUserToGroup.Click += new System.EventHandler(this.btnAddUserToGroup_Click);
			// 
			// cboGroup
			// 
			this.cboGroup.Location = new System.Drawing.Point(160, 40);
			this.cboGroup.Name = "cboGroup";
			this.cboGroup.Size = new System.Drawing.Size(121, 21);
			this.cboGroup.TabIndex = 13;
			this.cboGroup.Text = "Select a group";
			// 
			// cboUser
			// 
			this.cboUser.Location = new System.Drawing.Point(8, 40);
			this.cboUser.Name = "cboUser";
			this.cboUser.Size = new System.Drawing.Size(121, 21);
			this.cboUser.TabIndex = 12;
			this.cboUser.Text = "Select a user";
			// 
			// lblGroup
			// 
			this.lblGroup.Location = new System.Drawing.Point(168, 8);
			this.lblGroup.Name = "lblGroup";
			this.lblGroup.TabIndex = 11;
			this.lblGroup.Text = "Group";
			// 
			// lblUser
			// 
			this.lblUser.Location = new System.Drawing.Point(16, 8);
			this.lblUser.Name = "lblUser";
			this.lblUser.TabIndex = 10;
			this.lblUser.Text = "User";
			// 
			// frmUserToGroup
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 117);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.btnAddUserToGroup,
																		  this.cboGroup,
																		  this.cboUser,
																		  this.lblGroup,
																		  this.lblUser});
			this.Name = "frmUserToGroup";
			this.Text = "frmUserToGroup";
			this.Load += new System.EventHandler(this.frmUserToGroup_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void frmUserToGroup_Load(object sender, System.EventArgs e)
		{
		// Populate the two combo boxes
		
		//Path to the OU in which our users and groups reside
        string strLdap = "LDAP://" + frmMain.strServerName + "/OU=" + frmMain.strOU + ",DC=" + 
		frmMain.strThirdLevelDomain + ",DC=" + frmMain.strSecondLevelDomain + ",DC=" + frmMain.strTopLevelDomain;

        DirectoryEntry objOU = new DirectoryEntry(strLdap); //Object representing the OU
		DirectorySearcher objUserSearcher = new DirectorySearcher(objOU); //Directory Searcher object that will be used to find all user objects
        DirectorySearcher objGroupSearcher = new DirectorySearcher(objOU);//Directory Searcher object that will be used to find all group objects
        SearchResultCollection objResults; //Will contain the results of the searches

		//Find all user objects in the OU we are bound to.
        objUserSearcher.PropertiesToLoad.Add("cn"); //Return the CN of the object
        objUserSearcher.Filter = "(objectClass=user)"; //Return only user objects
        objResults = objUserSearcher.FindAll(); //Perform search
	
		//Loop through the results and add each users name to the combom box
        foreach (SearchResult objResult in objResults)
            cboUser.Items.Add(objResult.Properties["cn"][0]);

        objGroupSearcher.PropertiesToLoad.Add("cn"); //Return the CN of the object
        objGroupSearcher.Filter = "(objectClass=group)";//Return only group objects
        objResults = objGroupSearcher.FindAll();//Perform search

		//Loop through the results and add each groups name to the combom box
        foreach (SearchResult objResult in objResults)
            cboGroup.Items.Add(objResult.Properties["cn"][0]);

		//Free resources
        objOU.Close();
        objOU = null;
        objUserSearcher = null;
        objGroupSearcher = null;
        objResults = null;
		}

		private void btnAddUserToGroup_Click(object sender, System.EventArgs e)
		{
		//The fully qualified path to our group object
        string strGroupPath = "LDAP://" + frmMain.strServerName + "/CN=" + cboGroup.Text + ",OU=" + frmMain.strOU + 
		",DC=" + frmMain.strThirdLevelDomain + ",DC=" + frmMain.strSecondLevelDomain + ",DC=" + 
		frmMain.strTopLevelDomain;

        //The fully qualified path to our user object
        string strUserPath = "LDAP://" + frmMain.strServerName + "/CN=" + cboUser.Text + ",OU=" + frmMain.strOU + 
		",DC=" + frmMain.strThirdLevelDomain + ",DC=" + frmMain.strSecondLevelDomain + ",DC=" + 
		frmMain.strTopLevelDomain;

        //Bind to our group object
        DirectoryEntry objGroup = new DirectoryEntry(strGroupPath);

			try
			{
				//Adds a user to a group
				objGroup.Invoke("Add", strUserPath);
				MessageBox.Show(cboUser.Text + " has been added to the group " + cboGroup.Text + ".", "User Added",MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
  
            //Free resources
            objGroup.Close();
            objGroup = null;
		}
	}
}
