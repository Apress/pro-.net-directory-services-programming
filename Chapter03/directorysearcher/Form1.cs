using System;
using System.DirectoryServices;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

 
namespace ADSearcher
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.CheckBox chkAuth;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtPwd;
		private System.Windows.Forms.TextBox txtUID;
		private System.Windows.Forms.TextBox txtAdsPath;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Button txtRemove;
		private System.Windows.Forms.Button txtAdd;
		private System.Windows.Forms.ListBox listBox2;
		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button txtSearch;
		private System.Windows.Forms.Button cmdLoadProp;
		private System.Windows.Forms.TextBox txtFilter;
		private System.Windows.Forms.DataGrid dataGrid1;
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
			System.Configuration.AppSettingsReader configurationAppSettings = new System.Configuration.AppSettingsReader();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.txtFilter = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.cmdLoadProp = new System.Windows.Forms.Button();
			this.txtRemove = new System.Windows.Forms.Button();
			this.txtAdd = new System.Windows.Forms.Button();
			this.listBox2 = new System.Windows.Forms.ListBox();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.chkAuth = new System.Windows.Forms.CheckBox();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.txtPwd = new System.Windows.Forms.TextBox();
			this.txtUID = new System.Windows.Forms.TextBox();
			this.txtAdsPath = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtSearch = new System.Windows.Forms.Button();
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.txtFilter,
																					this.label5,
																					this.groupBox3,
																					this.chkAuth,
																					this.label1,
																					this.groupBox1,
																					this.txtAdsPath});
			this.groupBox2.Location = new System.Drawing.Point(8, 0);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(320, 344);
			this.groupBox2.TabIndex = 14;
			this.groupBox2.TabStop = false;
			this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
			// 
			// txtFilter
			// 
			this.txtFilter.Location = new System.Drawing.Point(58, 48);
			this.txtFilter.Name = "txtFilter";
			this.txtFilter.Size = new System.Drawing.Size(256, 20);
			this.txtFilter.TabIndex = 1;
			this.txtFilter.Text = "";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(28, 48);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(29, 13);
			this.label5.TabIndex = 24;
			this.label5.Text = "Filter";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.cmdLoadProp,
																					this.txtRemove,
																					this.txtAdd,
																					this.listBox2,
																					this.listBox1});
			this.groupBox3.Location = new System.Drawing.Point(3, 160);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(317, 168);
			this.groupBox3.TabIndex = 23;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Properties to Search";
			// 
			// cmdLoadProp
			// 
			this.cmdLoadProp.Location = new System.Drawing.Point(104, 16);
			this.cmdLoadProp.Name = "cmdLoadProp";
			this.cmdLoadProp.Size = new System.Drawing.Size(104, 24);
			this.cmdLoadProp.TabIndex = 5;
			this.cmdLoadProp.Text = "&Load Properties";
			this.cmdLoadProp.Click += new System.EventHandler(this.cmdLoadProp_Click);
			// 
			// txtRemove
			// 
			this.txtRemove.Location = new System.Drawing.Point(136, 112);
			this.txtRemove.Name = "txtRemove";
			this.txtRemove.Size = new System.Drawing.Size(44, 24);
			this.txtRemove.TabIndex = 7;
			this.txtRemove.Text = "&<<";
			this.txtRemove.Click += new System.EventHandler(this.txtRemove_Click);
			// 
			// txtAdd
			// 
			this.txtAdd.Location = new System.Drawing.Point(136, 72);
			this.txtAdd.Name = "txtAdd";
			this.txtAdd.Size = new System.Drawing.Size(44, 24);
			this.txtAdd.TabIndex = 6;
			this.txtAdd.Text = "&>>";
			this.txtAdd.Click += new System.EventHandler(this.txtAdd_Click);
			// 
			// listBox2
			// 
			this.listBox2.Location = new System.Drawing.Point(183, 48);
			this.listBox2.Name = "listBox2";
			this.listBox2.Size = new System.Drawing.Size(130, 108);
			this.listBox2.TabIndex = 9;
			// 
			// listBox1
			// 
			this.listBox1.Location = new System.Drawing.Point(1, 48);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(130, 108);
			this.listBox1.TabIndex = 8;
			// 
			// chkAuth
			// 
			this.chkAuth.Location = new System.Drawing.Point(10, 71);
			this.chkAuth.Name = "chkAuth";
			this.chkAuth.Size = new System.Drawing.Size(120, 16);
			this.chkAuth.TabIndex = 2;
			this.chkAuth.Text = "Use &Authentication";
			this.chkAuth.CheckedChanged += new System.EventHandler(this.chkAuth_CheckedChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(10, 22);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(47, 13);
			this.label1.TabIndex = 21;
			this.label1.Text = "AdsPath";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.label4,
																					this.label3,
																					this.txtPwd,
																					this.txtUID});
			this.groupBox1.Enabled = ((bool)(configurationAppSettings.GetValue("groupBox1.Enabled=false", typeof(bool))));
			this.groupBox1.Location = new System.Drawing.Point(9, 91);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(302, 64);
			this.groupBox1.TabIndex = 20;
			this.groupBox1.TabStop = false;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(40, 38);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(57, 13);
			this.label4.TabIndex = 14;
			this.label4.Text = "Password:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(56, 14);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(46, 13);
			this.label3.TabIndex = 13;
			this.label3.Text = "User ID:";
			// 
			// txtPwd
			// 
			this.txtPwd.Location = new System.Drawing.Point(120, 38);
			this.txtPwd.Name = "txtPwd";
			this.txtPwd.PasswordChar = '*';
			this.txtPwd.Size = new System.Drawing.Size(130, 20);
			this.txtPwd.TabIndex = 4;
			this.txtPwd.Text = "";
			// 
			// txtUID
			// 
			this.txtUID.Location = new System.Drawing.Point(120, 14);
			this.txtUID.Name = "txtUID";
			this.txtUID.Size = new System.Drawing.Size(130, 20);
			this.txtUID.TabIndex = 3;
			this.txtUID.Text = "";
			// 
			// txtAdsPath
			// 
			this.txtAdsPath.Location = new System.Drawing.Point(58, 18);
			this.txtAdsPath.Name = "txtAdsPath";
			this.txtAdsPath.Size = new System.Drawing.Size(254, 20);
			this.txtAdsPath.TabIndex = 0;
			this.txtAdsPath.Text = "";
			this.txtAdsPath.TextChanged += new System.EventHandler(this.txtAdsPath_TextChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label2.Location = new System.Drawing.Point(416, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(96, 15);
			this.label2.TabIndex = 22;
			this.label2.Text = "Search Results";
			// 
			// txtSearch
			// 
			this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtSearch.Location = new System.Drawing.Point(400, 304);
			this.txtSearch.Name = "txtSearch";
			this.txtSearch.Size = new System.Drawing.Size(104, 32);
			this.txtSearch.TabIndex = 10;
			this.txtSearch.Text = "&Search";
			this.txtSearch.Click += new System.EventHandler(this.txtSearch_Click);
			// 
			// dataGrid1
			// 
			this.dataGrid1.CaptionVisible = false;
			this.dataGrid1.DataMember = "";
			this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid1.Location = new System.Drawing.Point(336, 24);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.ParentRowsVisible = false;
			this.dataGrid1.PreferredColumnWidth = 100;
			this.dataGrid1.ReadOnly = true;
			this.dataGrid1.RowHeadersVisible = false;
			this.dataGrid1.Size = new System.Drawing.Size(232, 272);
			this.dataGrid1.TabIndex = 24;
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(576, 349);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.dataGrid1,
																		  this.txtSearch,
																		  this.label2,
																		  this.groupBox2});
			this.MaximizeBox = false;
			this.Name = "Form1";
			this.Text = "AD Searcher";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.groupBox2.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
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

		private void label3_Click(object sender, System.EventArgs e)
		{
		
		}

		private void chkAuth_CheckedChanged(object sender, System.EventArgs e)
		{
			groupBox1.Enabled = chkAuth.Checked;  
		}

		private void txtAdd_Click(object sender, System.EventArgs e)
		{
			try
			{
				listBox2.Items.Add (listBox1.SelectedItem);
				listBox1.Items.RemoveAt(listBox1.SelectedIndex);
			}
			catch(Exception eR){}
		}
		private void txtRemove_Click(object sender, System.EventArgs e)
		{
			try
			{
				listBox1.Items.Add (listBox2.SelectedItem);   
				listBox2.Items.RemoveAt(listBox2.SelectedIndex);
			}
			catch(Exception eR){}
		}

		private void groupBox2_Enter(object sender, System.EventArgs e)
		{
		
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
			groupBox1.Enabled =false; 
			getProperties();
		}
		private void getProperties()
		{
			
			//clean the list boxes for new entry
			listBox1.Items.Clear (); 
			listBox2.Items.Clear (); 
			try
			{
				DirectoryEntry ent;
				if (chkAuth.Checked)
				{
					ent = new DirectoryEntry (txtAdsPath.Text,txtUID.Text ,txtPwd.Text);
				}
				else
				{
					ent = new DirectoryEntry (txtAdsPath.Text);
				}
				DirectorySearcher propSearch = new DirectorySearcher(ent);			 
				propSearch.Filter =txtFilter.Text;
				foreach(SearchResult resEnt in propSearch.FindAll())
				{	
					foreach (string pN in resEnt.Properties.PropertyNames)
					{					
						listBox1.Items.Add (pN);									
					}					
				}
			}
			catch (Exception eR)
			{
				MessageBox.Show (eR.Message ); 
			}
		}

		

		private void cmdLoadProp_Click(object sender, System.EventArgs e)
		{
			getProperties();
		}

		private void txtAdsPath_TextChanged(object sender, System.EventArgs e)
		{
		
		}
		
		private void txtSearch_Click(object sender, System.EventArgs e)
		{
			try
			{
				DirectoryEntry root;
				if (txtUID.Text.Length>1)
				{
					root = new DirectoryEntry(txtAdsPath.Text,txtUID.Text ,txtPwd.Text);
				}
				else
				{
					root = new DirectoryEntry (txtAdsPath.Text);
				}
				
				DirectorySearcher searcher=new DirectorySearcher(root);
				searcher.Filter = txtFilter.Text;
				
				//Assign user selected properties 
				for (int i=0 ;i<listBox2.Items.Count;i++)
				{
					searcher.PropertiesToLoad.Add(listBox2.Items[i].ToString() ); 
				}

				//call method to search and bind the result to Data Grid
				searchAndBind(searcher);			
			}
			catch (Exception eR)
			{
				MessageBox.Show (eR.Message ); 
			}
		}
		private void searchAndBind(DirectorySearcher searcher)
		{
			DataSet propValDS = new DataSet();
			DataTable propValTable = new DataTable ("propVal");
			propValTable.Columns.Add ("Property",System.Type.GetType("System.String"));
			propValTable.Columns.Add ("Value",System.Type.GetType("System.String"));
			propValDS.Tables.Add  (propValTable); 
							
			foreach(SearchResult sRes in searcher.FindAll())
			{	
				foreach (string pName in sRes.Properties.PropertyNames)
				{					
					foreach (object val in sRes.Properties[pName]) 
					{
						
						DataRow dR = propValDS.Tables["propVal"].NewRow();

						dR["Property"]=pName;
						dR["Value"]=val;

						propValDS.Tables ["propVal"].Rows.Add(dR);
					}				
				}				
			}
			dataGrid1.DataSource =propValDS.Tables ["propVal"];
		}

	}
}
