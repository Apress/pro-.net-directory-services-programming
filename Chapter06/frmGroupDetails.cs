using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.DirectoryServices;

namespace DSChapter6_cSharp2
{
	/// <summary>
	/// Summary description for frmGroupDetails.
	/// </summary>
	/// 

	public enum ADS_GROUP_TYPE_ENUM
	{
		ADS_GROUP_TYPE_GLOBAL_GROUP = 0x00000002, 
		ADS_GROUP_TYPE_DOMAIN_LOCAL_GROUP = 0x00000004, 
		ADS_GROUP_TYPE_LOCAL_GROUP = 0x00000004, 
		ADS_GROUP_TYPE_UNIVERSAL_GROUP = 0x00000008,
		ADS_GROUP_TYPE_SECURITY_ENABLED = -2147483648 //0x80000000
	};


	public class frmGroupDetails : System.Windows.Forms.Form
	{
		internal System.Windows.Forms.GroupBox grpGroupScope;
		internal System.Windows.Forms.RadioButton optUniversal;
		internal System.Windows.Forms.RadioButton optGlobal;
		internal System.Windows.Forms.RadioButton optDomainLocal;
		internal System.Windows.Forms.GroupBox brpGroupType;
		internal System.Windows.Forms.RadioButton optDistribution;
		internal System.Windows.Forms.RadioButton optSecurity;
		internal System.Windows.Forms.TextBox txtGroupName;
		internal System.Windows.Forms.Button btnCreateGroup;
		internal System.Windows.Forms.Label lblGroupName;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmGroupDetails()
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
			this.grpGroupScope = new System.Windows.Forms.GroupBox();
			this.optUniversal = new System.Windows.Forms.RadioButton();
			this.optGlobal = new System.Windows.Forms.RadioButton();
			this.optDomainLocal = new System.Windows.Forms.RadioButton();
			this.brpGroupType = new System.Windows.Forms.GroupBox();
			this.optDistribution = new System.Windows.Forms.RadioButton();
			this.optSecurity = new System.Windows.Forms.RadioButton();
			this.txtGroupName = new System.Windows.Forms.TextBox();
			this.btnCreateGroup = new System.Windows.Forms.Button();
			this.lblGroupName = new System.Windows.Forms.Label();
			this.grpGroupScope.SuspendLayout();
			this.brpGroupType.SuspendLayout();
			this.SuspendLayout();
			// 
			// grpGroupScope
			// 
			this.grpGroupScope.Controls.AddRange(new System.Windows.Forms.Control[] {
																						this.optUniversal,
																						this.optGlobal,
																						this.optDomainLocal});
			this.grpGroupScope.Location = new System.Drawing.Point(78, 44);
			this.grpGroupScope.Name = "grpGroupScope";
			this.grpGroupScope.Size = new System.Drawing.Size(136, 88);
			this.grpGroupScope.TabIndex = 16;
			this.grpGroupScope.TabStop = false;
			this.grpGroupScope.Text = "Group Scope";
			// 
			// optUniversal
			// 
			this.optUniversal.Location = new System.Drawing.Point(24, 60);
			this.optUniversal.Name = "optUniversal";
			this.optUniversal.TabIndex = 2;
			this.optUniversal.Text = "Universal";
			// 
			// optGlobal
			// 
			this.optGlobal.Checked = true;
			this.optGlobal.Location = new System.Drawing.Point(24, 35);
			this.optGlobal.Name = "optGlobal";
			this.optGlobal.TabIndex = 1;
			this.optGlobal.TabStop = true;
			this.optGlobal.Text = "Global";
			// 
			// optDomainLocal
			// 
			this.optDomainLocal.Location = new System.Drawing.Point(24, 11);
			this.optDomainLocal.Name = "optDomainLocal";
			this.optDomainLocal.TabIndex = 0;
			this.optDomainLocal.Text = "Domain Local";
			// 
			// brpGroupType
			// 
			this.brpGroupType.Controls.AddRange(new System.Windows.Forms.Control[] {
																					   this.optDistribution,
																					   this.optSecurity});
			this.brpGroupType.Location = new System.Drawing.Point(78, 140);
			this.brpGroupType.Name = "brpGroupType";
			this.brpGroupType.Size = new System.Drawing.Size(136, 72);
			this.brpGroupType.TabIndex = 15;
			this.brpGroupType.TabStop = false;
			this.brpGroupType.Text = "Group Type";
			// 
			// optDistribution
			// 
			this.optDistribution.Location = new System.Drawing.Point(20, 40);
			this.optDistribution.Name = "optDistribution";
			this.optDistribution.TabIndex = 1;
			this.optDistribution.Text = "Distribution";
			// 
			// optSecurity
			// 
			this.optSecurity.Checked = true;
			this.optSecurity.Location = new System.Drawing.Point(20, 16);
			this.optSecurity.Name = "optSecurity";
			this.optSecurity.TabIndex = 0;
			this.optSecurity.TabStop = true;
			this.optSecurity.Text = "Security";
			// 
			// txtGroupName
			// 
			this.txtGroupName.Location = new System.Drawing.Point(136, 15);
			this.txtGroupName.Name = "txtGroupName";
			this.txtGroupName.TabIndex = 14;
			this.txtGroupName.Text = "";
			// 
			// btnCreateGroup
			// 
			this.btnCreateGroup.Location = new System.Drawing.Point(100, 226);
			this.btnCreateGroup.Name = "btnCreateGroup";
			this.btnCreateGroup.Size = new System.Drawing.Size(93, 32);
			this.btnCreateGroup.TabIndex = 13;
			this.btnCreateGroup.Text = "&Create Group";
			this.btnCreateGroup.Click += new System.EventHandler(this.btnCreateGroup_Click);
			// 
			// lblGroupName
			// 
			this.lblGroupName.Location = new System.Drawing.Point(57, 17);
			this.lblGroupName.Name = "lblGroupName";
			this.lblGroupName.Size = new System.Drawing.Size(72, 23);
			this.lblGroupName.TabIndex = 12;
			this.lblGroupName.Text = "Group Name";
			// 
			// frmGroupDetails
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 273);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.grpGroupScope,
																		  this.brpGroupType,
																		  this.txtGroupName,
																		  this.btnCreateGroup,
																		  this.lblGroupName});
			this.Name = "frmGroupDetails";
			this.Text = "frmGroupDetails";
			this.grpGroupScope.ResumeLayout(false);
			this.brpGroupType.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void btnCreateGroup_Click(object sender, System.EventArgs e)
		{
		//Creates a group of the type and scope selected by the user.

		int intGroupScope; //Stores the group scope - Domain Local, Global or Universal
		int intGroupType; //Stores the group type. Security or Distribution


        //Set the Group Scope
        if (optDomainLocal.Checked)
		{
			intGroupScope = (int)ADS_GROUP_TYPE_ENUM.ADS_GROUP_TYPE_DOMAIN_LOCAL_GROUP;
		}
        else if (optGlobal.Checked)
		{
			intGroupScope = (int)ADS_GROUP_TYPE_ENUM.ADS_GROUP_TYPE_GLOBAL_GROUP;
		}
        else
		{
			intGroupScope = (int)ADS_GROUP_TYPE_ENUM.ADS_GROUP_TYPE_UNIVERSAL_GROUP;
		}

        //Set the group type
		if (optSecurity.Checked)
		{
			intGroupType = (int)ADS_GROUP_TYPE_ENUM.ADS_GROUP_TYPE_SECURITY_ENABLED;
		}
		else
		{
			intGroupType = 0;
		}

        //Path to the OU in which the group will be created.
        string strLdapPath = "LDAP://" + frmMain.strServerName + "/OU=" + frmMain.strOU + ",DC=" +
        frmMain.strThirdLevelDomain + ",DC=" + frmMain.strSecondLevelDomain + ",DC=" + frmMain.strTopLevelDomain;

        DirectoryEntry objOU = new DirectoryEntry(strLdapPath); //An object representing an OU
        DirectoryEntry objNewGroup = objOU.Children.Add("cn=" + txtGroupName.Text, "Group"); //Add a child (group) to obOU

        objNewGroup.Properties["samAccountName"].Value = txtGroupName.Text; //Set the SAM name


		//Set the group type and scope
        if (intGroupType == 0)
		{
			//The group is a distribution group
			objNewGroup.Properties["groupType"].Add(intGroupScope);
		}
        else
		{
			//The group is a security group.
			objNewGroup.Properties["groupType"].Add(intGroupScope ^ intGroupType);
		}


			try
			{

				objNewGroup.CommitChanges(); //Update the DIT

				//Inform the user that the update was successful
				MessageBox.Show("The group " + txtGroupName.Text + " has been created.", "Group Created", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			
			finally
			{
				// Free resources
				objOU.Close();
				objOU = null;
				objNewGroup.Close();
				objNewGroup = null;
			}
		}
	}
}
