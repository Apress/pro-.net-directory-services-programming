using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.DirectoryServices;

namespace DSChapter6_cSharp2
{
	/// <summary>
	/// Summary description for frmUserDetails.
	/// </summary>
	/// 

	//An enumeration representing the possible user flags.
	public enum ADS_USER_FLAG_ENUM
	{
		ADS_UF_SCRIPT = 0X0001, 
		ADS_UF_ACCOUNTDISABLE = 0X0002, 
		ADS_UF_HOMEDIR_REQUIRED = 0X0008, 
		ADS_UF_LOCKOUT = 0X0010, 
		ADS_UF_PASSWD_NOTREQD = 0X0020, 
		ADS_UF_PASSWD_CANT_CHANGE = 0X0040, 
		ADS_UF_ENCRYPTED_TEXT_PASSWORD_ALLOWED = 0X0080, 
		ADS_UF_TEMP_DUPLICATE_ACCOUNT = 0X0100, 
		ADS_UF_NORMAL_ACCOUNT = 0X0200, 
		ADS_UF_INTERDOMAIN_TRUST_ACCOUNT = 0X0800, 
		ADS_UF_WORKSTATION_TRUST_ACCOUNT = 0X1000, 
		ADS_UF_SERVER_TRUST_ACCOUNT = 0X2000, 
		ADS_UF_DONT_EXPIRE_PASSWD = 0X10000, 
		ADS_UF_MNS_LOGON_ACCOUNT = 0X20000, 
		ADS_UF_SMARTCARD_REQUIRED = 0X40000, 
		ADS_UF_TRUSTED_FOR_DELEGATION = 0X80000, 
		ADS_UF_NOT_DELEGATED = 0X100000, 
		ADS_UF_USE_DES_KEY_ONLY = 0x200000, 
		ADS_UF_DONT_REQUIRE_PREAUTH = 0x400000, 
		ADS_UF_PASSWORD_EXPIRED = 0x800000, 
		ADS_UF_TRUSTED_TO_AUTHENTICATE_FOR_DELEGATION = 0x1000000
	};

	public class frmUserDetails : System.Windows.Forms.Form
	{

		internal System.Windows.Forms.CheckBox chkDisableUser;
		internal System.Windows.Forms.Button btnDeleteUser;
		internal System.Windows.Forms.ListBox lstGroups;
		internal System.Windows.Forms.Button btnChangeUser;
		internal System.Windows.Forms.ComboBox cboUsers;
		internal System.Windows.Forms.Button btnCreateUser;
		internal System.Windows.Forms.TextBox txtAccountName;
		internal System.Windows.Forms.Label lblAccountName;
		internal System.Windows.Forms.Label lblWebSite;
		internal System.Windows.Forms.Label lblEmailAddress;
		internal System.Windows.Forms.Label lblPhoneNumber;
		internal System.Windows.Forms.Label lblDescription;
		internal System.Windows.Forms.Label lblLastName;
		internal System.Windows.Forms.Label lblFirstName;
		internal System.Windows.Forms.TextBox txtWebSite;
		internal System.Windows.Forms.TextBox txtEmail;
		internal System.Windows.Forms.TextBox txtPhoneNumber;
		internal System.Windows.Forms.TextBox txtDescription;
		internal System.Windows.Forms.TextBox txtLastName;
		internal System.Windows.Forms.TextBox txtFirstName;
		private System.Windows.Forms.CheckBox chkResetPassword;
		private System.Windows.Forms.Panel pnlPasswords;
		private System.Windows.Forms.TextBox txtPassword;
		private System.Windows.Forms.TextBox txtConfirmPassword;
		private System.Windows.Forms.Label lblPassword;
		private System.Windows.Forms.Label lblConfirmPassword;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmUserDetails()
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
			this.chkDisableUser = new System.Windows.Forms.CheckBox();
			this.btnDeleteUser = new System.Windows.Forms.Button();
			this.lstGroups = new System.Windows.Forms.ListBox();
			this.btnChangeUser = new System.Windows.Forms.Button();
			this.cboUsers = new System.Windows.Forms.ComboBox();
			this.btnCreateUser = new System.Windows.Forms.Button();
			this.txtAccountName = new System.Windows.Forms.TextBox();
			this.lblAccountName = new System.Windows.Forms.Label();
			this.lblWebSite = new System.Windows.Forms.Label();
			this.lblEmailAddress = new System.Windows.Forms.Label();
			this.lblPhoneNumber = new System.Windows.Forms.Label();
			this.lblDescription = new System.Windows.Forms.Label();
			this.lblLastName = new System.Windows.Forms.Label();
			this.lblFirstName = new System.Windows.Forms.Label();
			this.txtWebSite = new System.Windows.Forms.TextBox();
			this.txtEmail = new System.Windows.Forms.TextBox();
			this.txtPhoneNumber = new System.Windows.Forms.TextBox();
			this.txtDescription = new System.Windows.Forms.TextBox();
			this.txtLastName = new System.Windows.Forms.TextBox();
			this.txtFirstName = new System.Windows.Forms.TextBox();
			this.pnlPasswords = new System.Windows.Forms.Panel();
			this.lblConfirmPassword = new System.Windows.Forms.Label();
			this.lblPassword = new System.Windows.Forms.Label();
			this.txtConfirmPassword = new System.Windows.Forms.TextBox();
			this.txtPassword = new System.Windows.Forms.TextBox();
			this.chkResetPassword = new System.Windows.Forms.CheckBox();
			this.pnlPasswords.SuspendLayout();
			this.SuspendLayout();
			// 
			// chkDisableUser
			// 
			this.chkDisableUser.Location = new System.Drawing.Point(220, 3);
			this.chkDisableUser.Name = "chkDisableUser";
			this.chkDisableUser.Size = new System.Drawing.Size(88, 24);
			this.chkDisableUser.TabIndex = 71;
			this.chkDisableUser.Text = "Disable User";
			// 
			// btnDeleteUser
			// 
			this.btnDeleteUser.Location = new System.Drawing.Point(192, 408);
			this.btnDeleteUser.Name = "btnDeleteUser";
			this.btnDeleteUser.Size = new System.Drawing.Size(80, 23);
			this.btnDeleteUser.TabIndex = 70;
			this.btnDeleteUser.Text = "&Delete User";
			this.btnDeleteUser.Visible = false;
			this.btnDeleteUser.Click += new System.EventHandler(this.btnDeleteUser_Click);
			// 
			// lstGroups
			// 
			this.lstGroups.Location = new System.Drawing.Point(20, 27);
			this.lstGroups.Name = "lstGroups";
			this.lstGroups.Size = new System.Drawing.Size(288, 30);
			this.lstGroups.TabIndex = 69;
			// 
			// btnChangeUser
			// 
			this.btnChangeUser.Location = new System.Drawing.Point(72, 408);
			this.btnChangeUser.Name = "btnChangeUser";
			this.btnChangeUser.Size = new System.Drawing.Size(104, 23);
			this.btnChangeUser.TabIndex = 68;
			this.btnChangeUser.Text = "&Change User";
			this.btnChangeUser.Visible = false;
			this.btnChangeUser.Click += new System.EventHandler(this.btnChangeUser_Click);
			// 
			// cboUsers
			// 
			this.cboUsers.Location = new System.Drawing.Point(20, 3);
			this.cboUsers.Name = "cboUsers";
			this.cboUsers.Size = new System.Drawing.Size(184, 21);
			this.cboUsers.TabIndex = 67;
			this.cboUsers.Text = "New User";
			this.cboUsers.SelectedIndexChanged += new System.EventHandler(this.cboUsers_SelectedIndexChanged);
			// 
			// btnCreateUser
			// 
			this.btnCreateUser.Location = new System.Drawing.Point(120, 408);
			this.btnCreateUser.Name = "btnCreateUser";
			this.btnCreateUser.Size = new System.Drawing.Size(104, 23);
			this.btnCreateUser.TabIndex = 59;
			this.btnCreateUser.Text = "&Create User";
			this.btnCreateUser.Click += new System.EventHandler(this.btnCreateUser_Click);
			// 
			// txtAccountName
			// 
			this.txtAccountName.Location = new System.Drawing.Point(132, 67);
			this.txtAccountName.Name = "txtAccountName";
			this.txtAccountName.Size = new System.Drawing.Size(168, 20);
			this.txtAccountName.TabIndex = 48;
			this.txtAccountName.Text = "";
			// 
			// lblAccountName
			// 
			this.lblAccountName.Location = new System.Drawing.Point(20, 67);
			this.lblAccountName.Name = "lblAccountName";
			this.lblAccountName.TabIndex = 57;
			this.lblAccountName.Text = "Account Name";
			// 
			// lblWebSite
			// 
			this.lblWebSite.Location = new System.Drawing.Point(20, 264);
			this.lblWebSite.Name = "lblWebSite";
			this.lblWebSite.TabIndex = 64;
			this.lblWebSite.Text = "Web Site";
			// 
			// lblEmailAddress
			// 
			this.lblEmailAddress.Location = new System.Drawing.Point(20, 227);
			this.lblEmailAddress.Name = "lblEmailAddress";
			this.lblEmailAddress.TabIndex = 63;
			this.lblEmailAddress.Text = "Email";
			// 
			// lblPhoneNumber
			// 
			this.lblPhoneNumber.Location = new System.Drawing.Point(20, 195);
			this.lblPhoneNumber.Name = "lblPhoneNumber";
			this.lblPhoneNumber.TabIndex = 62;
			this.lblPhoneNumber.Text = "Phone No.";
			// 
			// lblDescription
			// 
			this.lblDescription.Location = new System.Drawing.Point(20, 163);
			this.lblDescription.Name = "lblDescription";
			this.lblDescription.TabIndex = 61;
			this.lblDescription.Text = "Description";
			// 
			// lblLastName
			// 
			this.lblLastName.Location = new System.Drawing.Point(20, 131);
			this.lblLastName.Name = "lblLastName";
			this.lblLastName.TabIndex = 60;
			this.lblLastName.Text = "Last Name";
			// 
			// lblFirstName
			// 
			this.lblFirstName.Location = new System.Drawing.Point(20, 99);
			this.lblFirstName.Name = "lblFirstName";
			this.lblFirstName.Size = new System.Drawing.Size(100, 16);
			this.lblFirstName.TabIndex = 58;
			this.lblFirstName.Text = "First Name";
			// 
			// txtWebSite
			// 
			this.txtWebSite.Location = new System.Drawing.Point(132, 259);
			this.txtWebSite.Name = "txtWebSite";
			this.txtWebSite.Size = new System.Drawing.Size(168, 20);
			this.txtWebSite.TabIndex = 54;
			this.txtWebSite.Text = "";
			// 
			// txtEmail
			// 
			this.txtEmail.Location = new System.Drawing.Point(132, 227);
			this.txtEmail.Name = "txtEmail";
			this.txtEmail.Size = new System.Drawing.Size(168, 20);
			this.txtEmail.TabIndex = 53;
			this.txtEmail.Text = "";
			// 
			// txtPhoneNumber
			// 
			this.txtPhoneNumber.Location = new System.Drawing.Point(132, 195);
			this.txtPhoneNumber.Name = "txtPhoneNumber";
			this.txtPhoneNumber.Size = new System.Drawing.Size(168, 20);
			this.txtPhoneNumber.TabIndex = 52;
			this.txtPhoneNumber.Text = "";
			// 
			// txtDescription
			// 
			this.txtDescription.Location = new System.Drawing.Point(132, 163);
			this.txtDescription.Name = "txtDescription";
			this.txtDescription.Size = new System.Drawing.Size(168, 20);
			this.txtDescription.TabIndex = 51;
			this.txtDescription.Text = "";
			// 
			// txtLastName
			// 
			this.txtLastName.Location = new System.Drawing.Point(132, 131);
			this.txtLastName.Name = "txtLastName";
			this.txtLastName.Size = new System.Drawing.Size(168, 20);
			this.txtLastName.TabIndex = 50;
			this.txtLastName.Text = "";
			// 
			// txtFirstName
			// 
			this.txtFirstName.Location = new System.Drawing.Point(132, 99);
			this.txtFirstName.Name = "txtFirstName";
			this.txtFirstName.Size = new System.Drawing.Size(168, 20);
			this.txtFirstName.TabIndex = 49;
			this.txtFirstName.Text = "";
			// 
			// pnlPasswords
			// 
			this.pnlPasswords.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pnlPasswords.Controls.AddRange(new System.Windows.Forms.Control[] {
																					   this.lblConfirmPassword,
																					   this.lblPassword,
																					   this.txtConfirmPassword,
																					   this.txtPassword});
			this.pnlPasswords.Location = new System.Drawing.Point(16, 312);
			this.pnlPasswords.Name = "pnlPasswords";
			this.pnlPasswords.Size = new System.Drawing.Size(296, 88);
			this.pnlPasswords.TabIndex = 72;
			// 
			// lblConfirmPassword
			// 
			this.lblConfirmPassword.Location = new System.Drawing.Point(8, 48);
			this.lblConfirmPassword.Name = "lblConfirmPassword";
			this.lblConfirmPassword.TabIndex = 3;
			this.lblConfirmPassword.Text = "Confirm Password";
			// 
			// lblPassword
			// 
			this.lblPassword.Location = new System.Drawing.Point(8, 8);
			this.lblPassword.Name = "lblPassword";
			this.lblPassword.Size = new System.Drawing.Size(88, 24);
			this.lblPassword.TabIndex = 2;
			this.lblPassword.Text = "Password";
			// 
			// txtConfirmPassword
			// 
			this.txtConfirmPassword.Location = new System.Drawing.Point(112, 48);
			this.txtConfirmPassword.Name = "txtConfirmPassword";
			this.txtConfirmPassword.PasswordChar = '*';
			this.txtConfirmPassword.Size = new System.Drawing.Size(168, 20);
			this.txtConfirmPassword.TabIndex = 1;
			this.txtConfirmPassword.Text = "";
			// 
			// txtPassword
			// 
			this.txtPassword.Location = new System.Drawing.Point(112, 8);
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.PasswordChar = '*';
			this.txtPassword.Size = new System.Drawing.Size(168, 20);
			this.txtPassword.TabIndex = 0;
			this.txtPassword.Text = "";
			// 
			// chkResetPassword
			// 
			this.chkResetPassword.Location = new System.Drawing.Point(32, 288);
			this.chkResetPassword.Name = "chkResetPassword";
			this.chkResetPassword.Size = new System.Drawing.Size(136, 16);
			this.chkResetPassword.TabIndex = 73;
			this.chkResetPassword.Text = "Reset Password";
			this.chkResetPassword.Visible = false;
			this.chkResetPassword.CheckedChanged += new System.EventHandler(this.chkResetPassword_CheckedChanged);
			// 
			// frmUserDetails
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.SystemColors.ActiveBorder;
			this.ClientSize = new System.Drawing.Size(328, 437);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.chkResetPassword,
																		  this.chkDisableUser,
																		  this.btnDeleteUser,
																		  this.lstGroups,
																		  this.btnChangeUser,
																		  this.cboUsers,
																		  this.btnCreateUser,
																		  this.txtAccountName,
																		  this.lblAccountName,
																		  this.lblWebSite,
																		  this.lblEmailAddress,
																		  this.lblPhoneNumber,
																		  this.lblDescription,
																		  this.lblLastName,
																		  this.lblFirstName,
																		  this.txtWebSite,
																		  this.txtEmail,
																		  this.txtPhoneNumber,
																		  this.txtDescription,
																		  this.txtLastName,
																		  this.txtFirstName,
																		  this.pnlPasswords});
			this.Name = "frmUserDetails";
			this.Text = "frmUserDetails";
			this.Load += new System.EventHandler(this.frmUserDetails_Load);
			this.pnlPasswords.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void frmUserDetails_Load(object sender, System.EventArgs e)
		{
			//Populates the combo box with a list of users in OU=Dev

			//The path the the user objects
			string strLdap = "LDAP://" + frmMain.strServerName + "/OU=" + frmMain.strOU + ",DC=" +
			frmMain.strThirdLevelDomain + ",DC=" + frmMain.strSecondLevelDomain + ",DC=" + frmMain.strTopLevelDomain;

			DirectoryEntry objOU = new DirectoryEntry(strLdap); // A DirectoryEntry representing OU=Dev
			DirectorySearcher objUserSearcher = new DirectorySearcher(objOU); //Instantiate a DirectorySearcher passing the DirectoryEntry we wish to search
			SearchResultCollection objResults; //The results of the search

			//Search for user objects
			objUserSearcher.PropertiesToLoad.Add("cn"); //Specify what property(s) to return as the search results
			objUserSearcher.Filter = "(objectClass=user)";//Specify that we wish to fins user objects
			objResults = objUserSearcher.FindAll();//Perform the search
			
			cboUsers.Items.Add("New User"); //Set the text property of the combo box

			//Loop through the search results adding each one to the combo box
			foreach (SearchResult objResult in objResults)
				cboUsers.Items.Add(objResult.Properties["cn"][0]);

			//Free resources
			objOU.Close();
			objOU = null;
			objUserSearcher = null;
			objResults = null;
		}

		private void btnChangeUser_Click(object sender, System.EventArgs e)
		{
			/* 
			 * Handles the click event for btnChangeUser.
			 */

			//If the reset password box is checked then checks that the passwords match
			if ((chkResetPassword.Checked && checkPasswordsMatch(txtPassword.Text,txtConfirmPassword.Text)) || chkResetPassword.Checked==false)
			{
				//Path to the user object that will be bound to and changed.
				string strLdapPath = "LDAP://" + frmMain.strServerName + "/CN=" + cboUsers.Text + ",OU=" + frmMain.strOU + ",DC=" +
				frmMain.strThirdLevelDomain + ",DC=" + frmMain.strSecondLevelDomain + ",DC=" + frmMain.strTopLevelDomain;
				
				DirectoryEntry objUser = new DirectoryEntry(strLdapPath); //Bind to the user object

				//Set the properties from the form
				objUser.Properties["givenName"].Value = txtFirstName.Text;
				objUser.Properties["SN"].Value = txtLastName.Text;
				objUser.Properties["displayName"].Value = txtFirstName.Text + " " + txtLastName.Text;
				objUser.Properties["description"].Value = txtDescription.Text;
				objUser.Properties["telephoneNumber"].Value = txtPhoneNumber.Text;
				objUser.Properties["mail"].Value = txtEmail.Text;
				objUser.Properties["wWWhomePage"].Value = txtWebSite.Text;
				objUser.Properties["sAMAccountName"].Value = txtAccountName.Text;
				objUser.Properties["userPrincipalName"].Value = txtAccountName.Text; //@internal.wrox.com"
				
				//Check to see if the user has elected to disable the user
				if (chkDisableUser.Checked == true)
				{
					//Disable the user
					objUser.Properties["userAccountControl"].Value = ADS_USER_FLAG_ENUM.ADS_UF_ACCOUNTDISABLE;
				}
				else
				{
					//Normal Account
					objUser.Properties["userAccountControl"].Value = ADS_USER_FLAG_ENUM.ADS_UF_NORMAL_ACCOUNT;
				}

				try
				{
					objUser.CommitChanges(); //Commit the changes to the directory service
					
					//Check to see if the user has elected to reset the password
					if (chkResetPassword.Checked == true)
					{
						objUser.Invoke("SetPassword", txtPassword.Text); //Set the password from the form
					}

					//Inform the user of that the change has been made
					MessageBox.Show("User " + txtAccountName.Text + " has been changed!", "User modified",MessageBoxButtons.OK,MessageBoxIcon.Information);
				}

				catch (System.Runtime.InteropServices.COMException ex)
				{
					MessageBox.Show("An error has occured: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}

				catch (System.Reflection.TargetInvocationException ex)
				{
					//The invoke method failed for some reason. The password may violate a password  policy
					MessageBox.Show("An error has occured. It is possible that your password does not satisfy the password policy: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				
				finally
				{
					//Free resources
					objUser.Close();
					objUser = null;
				}

				}
			else
			{
				//tell the user the passwords do not match
				MessageBox.Show("Passwords do not match!","Password Mismatch",MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}

		}

		private void btnDeleteUser_Click(object sender, System.EventArgs e)
		{
		//Deletes the selectes user object from the DIT

			//Confirms with the user that they actually do want to remove the user object
			DialogResult dlgAnswer = MessageBox.Show("Are you sure you want to delete " + cboUsers.Text + "?","Delete User?",MessageBoxButtons.YesNo, MessageBoxIcon.Question);

			if (dlgAnswer==DialogResult.Yes)
			{
			//The user has selected Yes from the Message box

			//The path to OU=Dev
            string strOuPath = "LDAP://" + frmMain.strServerName + "/OU=" + frmMain.strOU + ",DC=" +
            frmMain.strThirdLevelDomain + ",DC=" + frmMain.strSecondLevelDomain + ",DC=" + frmMain.strTopLevelDomain;

			//The path to the user object that will be deleted. The CN is from the combo box.
            string strUserPath = "LDAP://" + frmMain.strServerName + "/CN=" + cboUsers.Text + ",OU=" + frmMain.strOU + ",DC=" +
            frmMain.strThirdLevelDomain + ",DC=" + frmMain.strSecondLevelDomain + ",DC=" + frmMain.strTopLevelDomain;

            DirectoryEntry objOU = new DirectoryEntry(strOuPath); //An object representing the OU in wich the to be delted user exists
            DirectoryEntry objUser = new DirectoryEntry(strUserPath); //An object representing the User to be deleted

				try
				{
					objOU.Children.Remove(objUser); //Remove the user object
					
					//Inform the user of the object deletion.
					MessageBox.Show(cboUsers.Text + " has been removed.","User Deleted",MessageBoxButtons.OK, MessageBoxIcon.Information);
				}

				catch(System.Runtime.InteropServices.COMException ex)
				{
					if (ex.ErrorCode==-2147016656)
					{
						//The user object does not exist.		
						MessageBox.Show("The user " + cboUsers.Text + " does not exist in the Directory.", "User does not exist", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
					else
					{
						MessageBox.Show("An error was encountered deleting " + cboUsers.Text + " " + ex.ErrorCode + " " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
				
				finally
				{
					//Free resources
					objUser.Close();
					objUser = null;
					objOU.Close();
					objOU = null;
				}

            cboUsers.Items.RemoveAt(cboUsers.SelectedIndex);//Remove the user CN from the list of user objects in the combo box
            ClearTextForm(); //Reset the form
            cboUsers.Text = "New User"; //Reset the text property of the Combo Box
			}
		}

		private void btnCreateUser_Click(object sender, System.EventArgs e)
		{
			//Creates the user in the DIT
			if (checkPasswordsMatch(txtPassword.Text,txtConfirmPassword.Text)) //Checks to make sure the passwords match
			{	
				//The path to the OU in which the user will be created
				string strLdapPath = "LDAP://" + frmMain.strServerName + "/OU=" + frmMain.strOU + ",DC=" +
				frmMain.strThirdLevelDomain + ",DC=" + frmMain.strSecondLevelDomain + ",DC=" + frmMain.strTopLevelDomain;

				DirectoryEntry objOU = new DirectoryEntry(strLdapPath);//An object representing the OU
				DirectoryEntry objNewUser = objOU.Children.Add("cn=" + txtAccountName.Text, "User"); //Adds a User object to the OU

				//Set some properties of the User object
				objNewUser.Properties["givenName"].Add(txtFirstName.Text);
				objNewUser.Properties["SN"].Add(txtLastName.Text);
				objNewUser.Properties["displayName"].Add(txtFirstName.Text + " " + txtLastName.Text);
				objNewUser.Properties["description"].Add(txtDescription.Text);
				objNewUser.Properties["telephoneNumber"].Add(txtPhoneNumber.Text);
				objNewUser.Properties["mail"].Add(txtEmail.Text);
				objNewUser.Properties["wWWhomePage"].Add(txtWebSite.Text);
				objNewUser.Properties["sAMAccountName"].Add(txtAccountName.Text);
				objNewUser.Properties["userPrincipalName"].Add(txtAccountName.Text); //@internal.wrox.com"

				/* Note that you would need to set the password before you call CommitChages if your Directory
				 * service has a minimum length password policy set. However, the LDAP provider does not allow
				 * for the setting of a password on an object that has not yet actually been created in the DIT.
				 */


				if (chkDisableUser.Checked == true)
				{
					//Create the account as disabled
					objNewUser.Properties["userAccountControl"].Add(ADS_USER_FLAG_ENUM.ADS_UF_ACCOUNTDISABLE);
				}
				else
				{
					//Create the account as enabled
					objNewUser.Properties["userAccountControl"].Add(ADS_USER_FLAG_ENUM.ADS_UF_NORMAL_ACCOUNT);
				}

				try
				{
					objNewUser.CommitChanges(); //Create the user in the underlying DIT

					//Note that the password is now set AFTER we CommitChanges and therefore create the account in the
					//underlying DIT.
					objNewUser.Invoke("SetPassword", txtPassword.Text);

					//Inform the user that the object was created
					MessageBox.Show("User " + txtAccountName.Text + " has been created!", "User Created",MessageBoxButtons.OK,MessageBoxIcon.Information);
					cboUsers.Items.Add(txtAccountName.Text); //Add the user name to the combo box
					cboUsers.Text = txtAccountName.Text; //Place the user name in the Account Name text box
				}
				catch (System.Runtime.InteropServices.COMException ex)
				{
					//Catches an exception in the event that the user already exists
					MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
				}

				catch (System.Reflection.TargetInvocationException ex)
				{
					//The invoke method failed for some reason. The password may violate a password  policy
					MessageBox.Show("An error has occured. It is possible that your password does not satisfy the password policy: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				
				finally
				{
					//Free resources
					objOU.Close();
					objOU = null;
					objNewUser.Close();
					objNewUser = null;
				}
			}
			else
			{
				//Inform the user that the passwords do not match
				MessageBox.Show("Passwords do not match!","Password Mismatch",MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		private void ClearTextForm(){
			//Clears the various text boxes on the form and resets the panel and check boxes.
			txtFirstName.Text = "";
			txtLastName.Text = "";
			txtDescription.Text = "";
			txtPhoneNumber.Text = "";
			txtEmail.Text = "";
			txtWebSite.Text = "";
			txtAccountName.Text = "";
			txtPassword.Text = "";
			txtConfirmPassword.Text = "";
			chkDisableUser.Checked = false;
			pnlPasswords.Enabled = false;
			chkResetPassword.Checked = false;
		}

		private static bool checkPasswordsMatch(string strPassword1, string strPassword2)
		{
			//Checks to see that the passwords match and returns true if they do and false otherwise
			if (strPassword1.CompareTo(strPassword2) == 0)
			{
				//The passwords match.
				return true;
			}
			else
			{
				//The passwords do not match.
				return false;
			}
		}

		private void cboUsers_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		//Populates the form based on the Selected Index Changed event for the cboUsers combo box.

		//clear the list box
        lstGroups.Items.Clear();

			if (cboUsers.Text != "New User")
			{
				//Path to the user object.
				string strLdapPath = "LDAP://" + frmMain.strServerName + "/CN=" + cboUsers.Text + ",OU=" + frmMain.strOU +
					",DC=" + frmMain.strThirdLevelDomain + ",DC=" + frmMain.strSecondLevelDomain + ",DC=" + frmMain.strTopLevelDomain;

				DirectoryEntry objUser = new DirectoryEntry(strLdapPath); //Represents the user that we will delete or change

				//Populate the user form with user details
				txtFirstName.Text = objUser.Properties["givenName"].Value.ToString();
				txtLastName.Text = objUser.Properties["SN"].Value.ToString();
				txtDescription.Text = objUser.Properties["description"].Value.ToString();
				txtPhoneNumber.Text = objUser.Properties["telephoneNumber"].Value.ToString();
				txtEmail.Text = objUser.Properties["mail"].Value.ToString();
				txtWebSite.Text = objUser.Properties["wWWhomePage"].Value.ToString();
				txtAccountName.Text = objUser.Properties["sAMAccountName"].Value.ToString();
				
				if (objUser.Properties["userAccountControl"].Value.ToString()=="514") //514 is the value of the userAccountControl of a disabled user object
				{
					//The account is disabled
					chkDisableUser.Checked = true;
				}
				else
				{
					//Not disabled
					chkDisableUser.Checked = false;
				}

				//Enumerate the users group membership

				foreach (string strGroupName in objUser.Properties["memberOf"])
					lstGroups.Items.Add(strGroupName);

				//Swap the buttons
				btnCreateUser.Visible = false;
				btnChangeUser.Visible = true;
				btnDeleteUser.Visible = true;

				//Disable the passowrd boxes
				pnlPasswords.Enabled=false;
				chkResetPassword.Visible =true;
				chkResetPassword.Checked =false;

				//Free resources
				objUser.Close();
				objUser = null;
			}
			else
			{
				ClearTextForm(); //Reset the form

				//Swap the buttons
				btnCreateUser.Visible = true;
				btnChangeUser.Visible = false;
				btnDeleteUser.Visible = false;
				pnlPasswords.Enabled=true;
				chkResetPassword.Visible =false;
			}
		}

		private void chkResetPassword_CheckedChanged(object sender, System.EventArgs e)
		{
			//Enables or disables the password text boxes based on the value of the chkResetPassword check box
			if (chkResetPassword.Checked==true)
			{
				//Enable the panel containing the text boxes
				pnlPasswords.Enabled = true;
			}
			else
			{
				//Disable the panel containing the text boxes
				pnlPasswords.Enabled = false;
			}
		}
	}
}
