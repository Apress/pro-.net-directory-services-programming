using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.DirectoryServices;

namespace DSChapter6_cSharp2
{
	/// <summary>
	/// Summary description for frmMoveUser.
	/// </summary>
	public class frmMoveUser : System.Windows.Forms.Form
	{
		internal System.Windows.Forms.Label lblOU;
		internal System.Windows.Forms.Label lblUser;
		internal System.Windows.Forms.Button btnMoveUser;
		internal System.Windows.Forms.ComboBox cboOU;
		internal System.Windows.Forms.ComboBox cboUser;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmMoveUser()
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
			this.lblOU = new System.Windows.Forms.Label();
			this.lblUser = new System.Windows.Forms.Label();
			this.btnMoveUser = new System.Windows.Forms.Button();
			this.cboOU = new System.Windows.Forms.ComboBox();
			this.cboUser = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// lblOU
			// 
			this.lblOU.Location = new System.Drawing.Point(200, 8);
			this.lblOU.Name = "lblOU";
			this.lblOU.Size = new System.Drawing.Size(24, 23);
			this.lblOU.TabIndex = 14;
			this.lblOU.Text = "OU";
			// 
			// lblUser
			// 
			this.lblUser.Location = new System.Drawing.Point(48, 8);
			this.lblUser.Name = "lblUser";
			this.lblUser.Size = new System.Drawing.Size(32, 23);
			this.lblUser.TabIndex = 13;
			this.lblUser.Text = "User";
			// 
			// btnMoveUser
			// 
			this.btnMoveUser.Location = new System.Drawing.Point(104, 72);
			this.btnMoveUser.Name = "btnMoveUser";
			this.btnMoveUser.TabIndex = 12;
			this.btnMoveUser.Text = "&Move User";
			this.btnMoveUser.Click += new System.EventHandler(this.btnMoveUser_Click);
			// 
			// cboOU
			// 
			this.cboOU.Location = new System.Drawing.Point(152, 32);
			this.cboOU.Name = "cboOU";
			this.cboOU.Size = new System.Drawing.Size(121, 21);
			this.cboOU.TabIndex = 11;
			this.cboOU.Text = "OU";
			// 
			// cboUser
			// 
			this.cboUser.Location = new System.Drawing.Point(16, 32);
			this.cboUser.Name = "cboUser";
			this.cboUser.Size = new System.Drawing.Size(121, 21);
			this.cboUser.TabIndex = 10;
			this.cboUser.Text = "User";
			// 
			// frmMoveUser
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 117);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.lblOU,
																		  this.lblUser,
																		  this.btnMoveUser,
																		  this.cboOU,
																		  this.cboUser});
			this.Name = "frmMoveUser";
			this.Text = "frmMoveUser";
			this.Load += new System.EventHandler(this.frmMoveUser_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void btnMoveUser_Click(object sender, System.EventArgs e)
		{
		/*
		 * This procedure handles the click event for the button btnMoveUser. It binds to both 
		 *  user object and and an OU and moves the user object to the new OU.
		 */
			//This is the path to the user object accepting the CN of the user from the control
			//cboUser on the calling form.
			string strUserPath = "LDAP://" + frmMain.strServerName + "/CN=" + cboUser.Text + ",OU=" + frmMain.strOU + 
			",DC=" + frmMain.strThirdLevelDomain + ",DC=" + frmMain.strSecondLevelDomain + ",DC=" + 
			frmMain.strTopLevelDomain;
			
			//The path of the destination OU, accepting the name of the OU from the calling form.
			string strDestinationPath = "LDAP://" + frmMain.strServerName + "/OU=" + cboOU.Text + ",DC=" +
			frmMain.strThirdLevelDomain + ",DC=" + frmMain.strSecondLevelDomain + ",DC=" + frmMain.strTopLevelDomain;

			//Instantiate a new objects representing the user object and the destination OU object
			DirectoryEntry objUser = new DirectoryEntry(strUserPath);
			DirectoryEntry objDestination = new DirectoryEntry(strDestinationPath);

			string strName = objUser.Name; //Holds the CN of the user object
			int intUserComboPosition = cboUser.SelectedIndex; //Holds the position user object in the Combo box so it can be removed later.

			objUser.MoveTo(objDestination, strName); //Moves the user to the new OU
			
			//Free resources
			objUser.Close(); 
			objUser = null;
			objDestination.Close();
			objDestination = null;
			//Inform the usre that the user has been moved
			MessageBox.Show(cboUser.Text + " has been moved to " + cboOU.Text + ".", "User Moved",MessageBoxButtons.OK,MessageBoxIcon.Information);

			cboUser.Items.RemoveAt(intUserComboPosition); //Remove the user from the list of users in OU=Dev
			cboUser.Text = "User"; //Reset the text property of the COmbo Box
		}

		private void frmMoveUser_Load(object sender, System.EventArgs e)
		{
		/*Populates one combo boxe with user names from OU=Dev and the other with OU names that
		 * reside directly under the root of the DIT
		 */
		
		//The path to OU=Dev
        string strSourceOUPath = "LDAP://" + frmMain.strServerName + "/OU=" + frmMain.strOU + ",DC=" + 
		frmMain.strThirdLevelDomain + ",DC=" + frmMain.strSecondLevelDomain + ",DC=" + frmMain.strTopLevelDomain;

		//The path to the root fo the DIT
        string strDestOuPath = "LDAP://" + frmMain.strServerName + "/DC=" + frmMain.strThirdLevelDomain + ",DC=" +
        frmMain.strSecondLevelDomain + ",DC=" + frmMain.strTopLevelDomain;

        DirectoryEntry objSourceOU = new DirectoryEntry(strSourceOUPath); //An object representing OU=Dev
		DirectoryEntry objDestOU = new DirectoryEntry(strDestOuPath); //An object representing the location of the destination OUs
        DirectorySearcher objUserSearcher = new DirectorySearcher(objSourceOU); //Instantiate a DirectorySearcher passing it the object representing OU=Dev
        DirectorySearcher objDestOUSearcher = new DirectorySearcher(objDestOU); //Instantiate a DirectorySearcher passing it the object representing the destination OUs
        SearchResultCollection objUserResults; //The results of the search for User objects in OU=Dev
		SearchResultCollection objOUResults; //The results of the search for OU objects at the root
		
		//Search for user objects
        objUserSearcher.PropertiesToLoad.Add("cn"); //Specify what property(s) to return as the search results
        objUserSearcher.Filter = "(objectClass=user)"; //Specify what type of object to return. In this case user objects.
        objUserResults = objUserSearcher.FindAll(); //Perform the search

		//Loop through the search results adding the CN of each user to the combo box.
        foreach (SearchResult objResult in objUserResults)
            cboUser.Items.Add(objResult.Properties["cn"][0]);
		
		//Search for OUs
        objDestOUSearcher.PropertiesToLoad.Add("ou"); //Specify what property(s) to return as the search results
        objDestOUSearcher.Filter = "(objectClass=organizationalUnit)";//Specify what type of object to return. In this case OUs.
        objOUResults = objDestOUSearcher.FindAll();//Perform the search

		//Loop through the search results adding the name of each OU to the combo box.
        foreach (SearchResult objResult in objOUResults)
            cboOU.Items.Add(objResult.Properties["ou"][0]);

		//Free resources
        objSourceOU.Close();
        objSourceOU = null;
		objDestOU.Close();
		objDestOU = null;
        objUserSearcher = null;
        objDestOUSearcher = null;
        objUserResults = null;
		objOUResults = null;
		}
	}
}
