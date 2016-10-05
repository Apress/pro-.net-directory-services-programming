using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.DirectoryServices;

namespace WindowsApplication1
{
	/// <summary>
	/// Summary description for FrmAdd.
	/// </summary>
	public class FrmAdd : System.Windows.Forms.Form
	{
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox txtEntryName;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtPassword;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Button btnCancel;
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.RadioButton radioChoiceGroup;
		private System.Windows.Forms.RadioButton radioChoiceUser;
		private string _containerPath = null;
		private DirectoryUtil util;

		public FrmAdd()
		{
			//Get Sinngleton reference
			util = DirectoryUtil.Instance;
			InitializeComponent();
			
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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.radioChoiceGroup = new System.Windows.Forms.RadioButton();
			this.radioChoiceUser = new System.Windows.Forms.RadioButton();
			this.txtEntryName = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.txtPassword = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.btnOk = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.radioChoiceGroup,
																					this.radioChoiceUser});
			this.groupBox1.Location = new System.Drawing.Point(24, 16);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(144, 72);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Entry Type";
			// 
			// radioChoiceGroup
			// 
			this.radioChoiceGroup.Location = new System.Drawing.Point(80, 24);
			this.radioChoiceGroup.Name = "radioChoiceGroup";
			this.radioChoiceGroup.Size = new System.Drawing.Size(56, 24);
			this.radioChoiceGroup.TabIndex = 2;
			this.radioChoiceGroup.Text = "Group";
			this.radioChoiceGroup.CheckedChanged += new System.EventHandler(this.radioGroup_CheckedChanged);
			// 
			// radioChoiceUser
			// 
			this.radioChoiceUser.Checked = true;
			this.radioChoiceUser.Location = new System.Drawing.Point(16, 24);
			this.radioChoiceUser.Name = "radioChoiceUser";
			this.radioChoiceUser.Size = new System.Drawing.Size(48, 24);
			this.radioChoiceUser.TabIndex = 1;
			this.radioChoiceUser.TabStop = true;
			this.radioChoiceUser.Text = "User";
			this.radioChoiceUser.CheckedChanged += new System.EventHandler(this.radioUser_CheckedChanged);
			// 
			// txtEntryName
			// 
			this.txtEntryName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtEntryName.Location = new System.Drawing.Point(24, 104);
			this.txtEntryName.Name = "txtEntryName";
			this.txtEntryName.Size = new System.Drawing.Size(144, 20);
			this.txtEntryName.TabIndex = 1;
			this.txtEntryName.Text = "";
			
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(24, 88);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Entry Name";
			// 
			// txtPassword
			// 
			this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtPassword.Location = new System.Drawing.Point(24, 160);
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.PasswordChar = '*';
			this.txtPassword.Size = new System.Drawing.Size(144, 20);
			this.txtPassword.TabIndex = 3;
			this.txtPassword.Text = "";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(24, 144);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(54, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "Password";
			// 
			// btnOk
			// 
			this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnOk.Location = new System.Drawing.Point(96, 200);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(72, 23);
			this.btnOk.TabIndex = 5;
			this.btnOk.Text = "Ok";
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnCancel.Location = new System.Drawing.Point(96, 232);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(72, 23);
			this.btnCancel.TabIndex = 6;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// FrmAdd
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(202, 262);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.btnCancel,
																		  this.btnOk,
																		  this.label2,
																		  this.txtPassword,
																		  this.label1,
																		  this.txtEntryName,
																		  this.groupBox1});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "FrmAdd";
			this.Text = "Add New Entry";
			
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

	
		private void radioGroup_CheckedChanged(object sender, System.EventArgs e)
		{
			this.txtPassword.Enabled = false;
		}

		private void radioUser_CheckedChanged(object sender, System.EventArgs e)
		{
			this.txtPassword.Enabled = true;
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			this.Dispose();
		}

		/// <summary>
		/// Add new entry
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnOk_Click(object sender, System.EventArgs e)
		{
			try
			{
				DirectoryEntry child = null;			
				if(this.radioChoiceGroup.Checked)
				{

					child = 
						util.SharedEntry.Children.Add("CN=" + this.txtEntryName.Text, "Group");
					//Mandatory property					
					child.Properties["samAccountName"].Add(this.txtEntryName.Text.ToLower());
					if(DirectoryEntry.Exists(child.Path))
						throw new Exception("Entry alreay exists in the Directory");
					//Update changes
					child.CommitChanges();
				}
				else
				{
					
					child = util.SharedEntry.Children.Add("CN=" + this.txtEntryName.Text, "User");
					//Mandatory property
					child.Properties["samAccountName"].Add(this.txtEntryName.Text.ToLower());
					//Enable user.
					child.Properties["userAccountControl"].Add(0x0200);
					//Update changes
					if(DirectoryEntry.Exists(child.Path))
						throw new Exception("The Directory Entry alreay exists in the Directory");
					child.CommitChanges();
				}				
				this.Dispose();
			}
			catch(Exception ex)
			{
					MessageBox.Show(ex.Message,
									this.Text,
									MessageBoxButtons.
									OK,MessageBoxIcon.Stop);
			}
		
		}

	}
}
