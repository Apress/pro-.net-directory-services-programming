using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace DSSamples
{
	/// <summary>
	/// Summary description for CreateMailbox.
	/// </summary>
	public class CreateMailbox : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox Alias;
		private System.Windows.Forms.TextBox DisplayName;
		private System.Windows.Forms.Button Create;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public CreateMailbox()
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
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.Alias = new System.Windows.Forms.TextBox();
			this.DisplayName = new System.Windows.Forms.TextBox();
			this.Create = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.TabIndex = 0;
			this.label1.Text = "Display Name";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 56);
			this.label2.Name = "label2";
			this.label2.TabIndex = 1;
			this.label2.Text = "Alias";
			// 
			// Alias
			// 
			this.Alias.Location = new System.Drawing.Point(8, 72);
			this.Alias.Name = "Alias";
			this.Alias.TabIndex = 2;
			this.Alias.Text = "";
			// 
			// DisplayName
			// 
			this.DisplayName.Location = new System.Drawing.Point(8, 24);
			this.DisplayName.Name = "DisplayName";
			this.DisplayName.Size = new System.Drawing.Size(192, 20);
			this.DisplayName.TabIndex = 3;
			this.DisplayName.Text = "";
			// 
			// Create
			// 
			this.Create.Location = new System.Drawing.Point(128, 72);
			this.Create.Name = "Create";
			this.Create.Size = new System.Drawing.Size(72, 23);
			this.Create.TabIndex = 4;
			this.Create.Text = "&OK";
			this.Create.Click += new System.EventHandler(this.Create_Click);
			// 
			// CreateMailbox
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(208, 101);
			this.ControlBox = false;
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.Create,
																		  this.DisplayName,
																		  this.Alias,
																		  this.label2,
																		  this.label1});
			this.Name = "CreateMailbox";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "CreateMailbox";
			this.Load += new System.EventHandler(this.CreateMailbox_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void CreateMailbox_Load(object sender, System.EventArgs e)
		{
		
		}

		private void Create_Click(object sender, System.EventArgs e)
		{
			DSTools PropertyTool = new DSTools();
			PropertyTool.CreateMailbox(DisplayName.Text, Alias.Text); 

			this.Close();
		}

	}
}
