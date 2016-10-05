using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace DSChapter6_cSharp2
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class frmMain : System.Windows.Forms.Form
	{
		internal System.Windows.Forms.GroupBox grpOperation;
		internal System.Windows.Forms.RadioButton optMoveUser;
		internal System.Windows.Forms.RadioButton optGroupMembership;
		internal System.Windows.Forms.RadioButton optAddUsertoGroup;
		internal System.Windows.Forms.RadioButton optCreateGroup;
		internal System.Windows.Forms.RadioButton optUsers;
		internal System.Windows.Forms.Button btnOk;

		//Variables to build the LDAP Path - These variables are use in each form in the project
		public const string strServerName = "serverName";	//The name of the server you wish to bind to 
		public const string strOU = "Dev";		//THe name of the Organistational Unit that will be in your LDAP string
		public const string strThirdLevelDomain = "internal"; //The third level domain in your LDAP string
		public const string strSecondLevelDomain = "wrox"; //The second level domain in your form
		public const string strTopLevelDomain = "com"; //The the top level domain

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmMain()
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
				if (components != null) 
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
			this.grpOperation = new System.Windows.Forms.GroupBox();
			this.optMoveUser = new System.Windows.Forms.RadioButton();
			this.optGroupMembership = new System.Windows.Forms.RadioButton();
			this.optAddUsertoGroup = new System.Windows.Forms.RadioButton();
			this.optCreateGroup = new System.Windows.Forms.RadioButton();
			this.optUsers = new System.Windows.Forms.RadioButton();
			this.btnOk = new System.Windows.Forms.Button();
			this.grpOperation.SuspendLayout();
			this.SuspendLayout();
			// 
			// grpOperation
			// 
			this.grpOperation.Controls.AddRange(new System.Windows.Forms.Control[] {
																					   this.optMoveUser,
																					   this.optGroupMembership,
																					   this.optAddUsertoGroup,
																					   this.optCreateGroup,
																					   this.optUsers});
			this.grpOperation.Location = new System.Drawing.Point(62, 21);
			this.grpOperation.Name = "grpOperation";
			this.grpOperation.Size = new System.Drawing.Size(168, 184);
			this.grpOperation.TabIndex = 8;
			this.grpOperation.TabStop = false;
			this.grpOperation.Text = "Directory Operations";
			// 
			// optMoveUser
			// 
			this.optMoveUser.Location = new System.Drawing.Point(8, 152);
			this.optMoveUser.Name = "optMoveUser";
			this.optMoveUser.TabIndex = 4;
			this.optMoveUser.Text = "Move User";
			// 
			// optGroupMembership
			// 
			this.optGroupMembership.Location = new System.Drawing.Point(8, 120);
			this.optGroupMembership.Name = "optGroupMembership";
			this.optGroupMembership.Size = new System.Drawing.Size(144, 24);
			this.optGroupMembership.TabIndex = 3;
			this.optGroupMembership.Text = "View Group Members";
			// 
			// optAddUsertoGroup
			// 
			this.optAddUsertoGroup.Location = new System.Drawing.Point(8, 88);
			this.optAddUsertoGroup.Name = "optAddUsertoGroup";
			this.optAddUsertoGroup.Size = new System.Drawing.Size(120, 24);
			this.optAddUsertoGroup.TabIndex = 2;
			this.optAddUsertoGroup.Text = "Add User to Group";
			// 
			// optCreateGroup
			// 
			this.optCreateGroup.Location = new System.Drawing.Point(8, 56);
			this.optCreateGroup.Name = "optCreateGroup";
			this.optCreateGroup.TabIndex = 1;
			this.optCreateGroup.Text = "Create Group";
			// 
			// optUsers
			// 
			this.optUsers.Checked = true;
			this.optUsers.Location = new System.Drawing.Point(8, 24);
			this.optUsers.Name = "optUsers";
			this.optUsers.TabIndex = 0;
			this.optUsers.TabStop = true;
			this.optUsers.Text = "Users";
			// 
			// btnOk
			// 
			this.btnOk.Location = new System.Drawing.Point(110, 229);
			this.btnOk.Name = "btnOk";
			this.btnOk.TabIndex = 9;
			this.btnOk.Text = "&OK";
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			// 
			// frmMain
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 273);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.grpOperation,
																		  this.btnOk});
			this.Name = "frmMain";
			this.Text = "Main";
			this.Load += new System.EventHandler(this.frmMain_Load);
			this.grpOperation.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new frmMain());
		}

		private void btnOk_Click(object sender, System.EventArgs e)
		{
			//Launches the appropriate form based on the users selection.
			if (optUsers.Checked == true)
			{
				frmUserDetails frm = new frmUserDetails();
				frm.Show();
			}
			
			else if (optCreateGroup.Checked == true)
			{
				frmGroupDetails frm = new frmGroupDetails();
				frm.Show();
			}
			
			else if (optAddUsertoGroup.Checked == true)
			{
				frmUserToGroup frm = new frmUserToGroup();
				frm.Show();
			}
			else if (optGroupMembership.Checked == true)
			{
				frmGroupMembership frm = new frmGroupMembership();
				frm.Show();
			}
			else
			{
				frmMoveUser frm = new frmMoveUser();
				frm.Show();
			}
		}

		private void frmMain_Load(object sender, System.EventArgs e)
		{
		
		}
	}
}
