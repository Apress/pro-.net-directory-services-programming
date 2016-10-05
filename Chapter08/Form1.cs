using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.DirectoryServices;

namespace DSSamples
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox Output;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnShowProperties;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox LDAPPath;
		private System.Windows.Forms.TextBox Input;
		private System.Windows.Forms.ListBox DirectoryObjects;
		private System.Windows.Forms.Label label4;

		private String[] m_LDAPPaths;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button Deleter;
		private System.Windows.Forms.Button CreateMailbox;
		private System.Windows.Forms.Button btnPopulate;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Button RemoveMailbox;
		private System.Windows.Forms.Button SendEmail;
		private System.Windows.Forms.Button ShowSubjects;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
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
			this.Output = new System.Windows.Forms.TextBox();
			this.btnShowProperties = new System.Windows.Forms.Button();
			this.LDAPPath = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.Input = new System.Windows.Forms.TextBox();
			this.DirectoryObjects = new System.Windows.Forms.ListBox();
			this.label4 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.CreateMailbox = new System.Windows.Forms.Button();
			this.Deleter = new System.Windows.Forms.Button();
			this.btnPopulate = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.RemoveMailbox = new System.Windows.Forms.Button();
			this.SendEmail = new System.Windows.Forms.Button();
			this.ShowSubjects = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// Output
			// 
			this.Output.AcceptsReturn = true;
			this.Output.AcceptsTab = true;
			this.Output.Location = new System.Drawing.Point(24, 96);
			this.Output.Multiline = true;
			this.Output.Name = "Output";
			this.Output.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.Output.Size = new System.Drawing.Size(472, 432);
			this.Output.TabIndex = 0;
			this.Output.Text = "";
			this.Output.WordWrap = false;
			// 
			// btnShowProperties
			// 
			this.btnShowProperties.Location = new System.Drawing.Point(512, 8);
			this.btnShowProperties.Name = "btnShowProperties";
			this.btnShowProperties.Size = new System.Drawing.Size(96, 23);
			this.btnShowProperties.TabIndex = 1;
			this.btnShowProperties.Text = "&Show properties";
			this.btnShowProperties.Click += new System.EventHandler(this.btnShowProperties_Click);
			// 
			// LDAPPath
			// 
			this.LDAPPath.Location = new System.Drawing.Point(88, 8);
			this.LDAPPath.Name = "LDAPPath";
			this.LDAPPath.Size = new System.Drawing.Size(408, 20);
			this.LDAPPath.TabIndex = 2;
			this.LDAPPath.Text = "LDAP://DC=domain,DC=com";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(24, 8);
			this.label1.Name = "label1";
			this.label1.TabIndex = 3;
			this.label1.Text = "LDAP Path";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(24, 80);
			this.label2.Name = "label2";
			this.label2.TabIndex = 4;
			this.label2.Text = "Output";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(24, 40);
			this.label3.Name = "label3";
			this.label3.TabIndex = 5;
			this.label3.Text = "Input";
			// 
			// Input
			// 
			this.Input.Location = new System.Drawing.Point(88, 40);
			this.Input.Name = "Input";
			this.Input.Size = new System.Drawing.Size(408, 20);
			this.Input.TabIndex = 6;
			this.Input.Text = "";
			// 
			// DirectoryObjects
			// 
			this.DirectoryObjects.Location = new System.Drawing.Point(512, 96);
			this.DirectoryObjects.Name = "DirectoryObjects";
			this.DirectoryObjects.Size = new System.Drawing.Size(120, 433);
			this.DirectoryObjects.TabIndex = 7;
			this.DirectoryObjects.SelectedIndexChanged += new System.EventHandler(this.DirectoryObjects_SelectedIndexChanged);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(512, 80);
			this.label4.Name = "label4";
			this.label4.TabIndex = 8;
			this.label4.Text = "Directory Objects";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.CreateMailbox,
																					this.Deleter,
																					this.btnPopulate});
			this.groupBox1.Location = new System.Drawing.Point(640, 200);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(120, 136);
			this.groupBox1.TabIndex = 19;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Mailbox Related";
			// 
			// CreateMailbox
			// 
			this.CreateMailbox.Location = new System.Drawing.Point(8, 104);
			this.CreateMailbox.Name = "CreateMailbox";
			this.CreateMailbox.Size = new System.Drawing.Size(104, 23);
			this.CreateMailbox.TabIndex = 17;
			this.CreateMailbox.Text = "&Create Mailbox";
			this.CreateMailbox.Click += new System.EventHandler(this.CreateMailbox_Click);
			// 
			// Deleter
			// 
			this.Deleter.Location = new System.Drawing.Point(8, 64);
			this.Deleter.Name = "Deleter";
			this.Deleter.Size = new System.Drawing.Size(104, 23);
			this.Deleter.TabIndex = 18;
			this.Deleter.Text = "&Delete selected";
			this.Deleter.Click += new System.EventHandler(this.Deleter_Click);
			// 
			// btnPopulate
			// 
			this.btnPopulate.Location = new System.Drawing.Point(8, 24);
			this.btnPopulate.Name = "btnPopulate";
			this.btnPopulate.Size = new System.Drawing.Size(104, 23);
			this.btnPopulate.TabIndex = 16;
			this.btnPopulate.Text = "&Populate list";
			this.btnPopulate.Click += new System.EventHandler(this.btnPopulate_Click);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.RemoveMailbox,
																					this.SendEmail,
																					this.ShowSubjects});
			this.groupBox2.Location = new System.Drawing.Point(640, 384);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(120, 144);
			this.groupBox2.TabIndex = 20;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Other Technologies";
			// 
			// RemoveMailbox
			// 
			this.RemoveMailbox.Location = new System.Drawing.Point(8, 104);
			this.RemoveMailbox.Name = "RemoveMailbox";
			this.RemoveMailbox.Size = new System.Drawing.Size(104, 23);
			this.RemoveMailbox.TabIndex = 19;
			this.RemoveMailbox.Text = "Remove &Mailbox";
			this.RemoveMailbox.Click += new System.EventHandler(this.RemoveMailbox_Click);
			// 
			// SendEmail
			// 
			this.SendEmail.Location = new System.Drawing.Point(8, 64);
			this.SendEmail.Name = "SendEmail";
			this.SendEmail.Size = new System.Drawing.Size(104, 23);
			this.SendEmail.TabIndex = 18;
			this.SendEmail.Text = "Send &Email";
			this.SendEmail.Click += new System.EventHandler(this.SendEmail_Click);
			// 
			// ShowSubjects
			// 
			this.ShowSubjects.Location = new System.Drawing.Point(8, 24);
			this.ShowSubjects.Name = "ShowSubjects";
			this.ShowSubjects.Size = new System.Drawing.Size(104, 23);
			this.ShowSubjects.TabIndex = 17;
			this.ShowSubjects.Text = "&Render Subjects";
			this.ShowSubjects.Click += new System.EventHandler(this.ShowSubjects_Click);
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(512, 40);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(368, 32);
			this.label5.TabIndex = 21;
			this.label5.Text = "The Input textbox can be used to provide custom filters for populating the Direct" +
				"ory objects listbox. If Input is empty, a default filter is used.";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(768, 200);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(200, 56);
			this.label6.TabIndex = 22;
			this.label6.Text = "Populate populates the listbox with directory objects. A custom filter can be app" +
				"lied from the Input textbox. If input is empty, a default filter is used.";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(768, 264);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(200, 32);
			this.label7.TabIndex = 23;
			this.label7.Text = "Delete selected deletes the selected Directory Object.";
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(768, 304);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(200, 40);
			this.label8.TabIndex = 24;
			this.label8.Text = "Create Mailbox lets you create a new mailbox-enabled account.";
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(768, 408);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(200, 32);
			this.label9.TabIndex = 25;
			this.label9.Text = "Render Subjects displays all subjects from the Inbox.";
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(768, 448);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(200, 24);
			this.label10.TabIndex = 26;
			this.label10.Text = "Send Email sends an email to the account selected in the listbox.";
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(768, 488);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(208, 32);
			this.label11.TabIndex = 27;
			this.label11.Text = "Remove Mailbox deletes the mailbox from the selected account";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(968, 541);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.label11,
																		  this.label10,
																		  this.label9,
																		  this.label8,
																		  this.label7,
																		  this.label6,
																		  this.label5,
																		  this.groupBox2,
																		  this.groupBox1,
																		  this.DirectoryObjects,
																		  this.Input,
																		  this.label3,
																		  this.LDAPPath,
																		  this.btnShowProperties,
																		  this.Output,
																		  this.label1,
																		  this.label2,
																		  this.label4});
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "DirectoryService Exchange Manager";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void btnShowProperties_Click(object sender, System.EventArgs e)
		{
			DSTools PropertyTool = new DSTools();

			Output.Text = PropertyTool.DisplayDEProperties(LDAPPath.Text);
		}

		private void btnPopulate_Click(object sender, System.EventArgs e)
		{
			int resultCounter = 0;
			DSTools PropertyTool = new DSTools();
			String filterString = "";

			DirectoryObjects.Items.Clear();
			
			if (Input.Text == "")
				// Using the filter string for All Users
				filterString = "(& (mailnickname=*)(|(&(objectCategory=person)(objectClass=user))(&(objectCategory=person)(objectClass=user)(|(homeMDB=*)(msExchHomeServerName=*)))))";
			else
				filterString = Input.Text;

			SearchResultCollection SearchResults = PropertyTool.FindDirectoryObjects(LDAPPath.Text, filterString);

			m_LDAPPaths = new String[SearchResults.Count];

			try
			{
				foreach(SearchResult result in SearchResults) 
				{
					ResultPropertyCollection coll = result.Properties;

					// Since we know that this is a 1-item property, we can jump directly
					// to its item 0, otherwise, a foreach would have worked fine
					DirectoryObjects.Items.Add(result.Properties["name"][0].ToString());

					// Get the LDAP path for the object
					m_LDAPPaths[resultCounter] = result.GetDirectoryEntry().Path;
					resultCounter++;
				}
			}
			catch (Exception ex)
			{
				Output.Text = ex.Message;
			}

		}

		private void DirectoryObjects_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			DSTools PropertyTool = new DSTools();

			Output.Text = PropertyTool.DisplayDEProperties(m_LDAPPaths[DirectoryObjects.SelectedIndex]);		
		}

		private void SendEmail_Click(object sender, System.EventArgs e)
		{
			OtherTechnologies Alternative = new OtherTechnologies();

			DirectoryEntry objDE = new DirectoryEntry(m_LDAPPaths[DirectoryObjects.SelectedIndex]);
			
			Alternative.CDOEXSendEmail(objDE.Properties["mail"].Value.ToString());
		}

		private void CreateMailbox_Click(object sender, System.EventArgs e)
		{
			
			Form cmForm = new CreateMailbox();

			cmForm.ShowDialog();
		}

		private void Deleter_Click(object sender, System.EventArgs e)
		{
			DSTools PropertyTool = new DSTools();

			PropertyTool.DeleteMailbox(m_LDAPPaths[DirectoryObjects.SelectedIndex]);
		}

		private void RemoveMailbox_Click(object sender, System.EventArgs e)
		{
			OtherTechnologies Alternative = new OtherTechnologies();
			
			Alternative.CDOEXMDeleteMailbox(m_LDAPPaths[DirectoryObjects.SelectedIndex]);
		}

		private void ShowSubjects_Click(object sender, System.EventArgs e)
		{
			OtherTechnologies Alternative = new OtherTechnologies();
			
			Output.Text = Alternative.CDOGetSubjects();
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
		
		}

	}
}
