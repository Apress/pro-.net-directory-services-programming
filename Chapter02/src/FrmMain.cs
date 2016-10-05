using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Text;
using System.Reflection;

using Wrox.DirectoryServices.Securiy;
using System.DirectoryServices;

namespace WindowsApplication1
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class FrmMain : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TreeView tvwDirectory;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.Label lblPath;
		private System.Windows.Forms.Button btnRemovePropertyValue;
		private System.Windows.Forms.TextBox txtPropertyValue;
		private System.Windows.Forms.ListBox lstPropertyValue;
		private System.Windows.Forms.ListBox lstProperties;
		private System.Windows.Forms.TabControl tabMain;
		private System.Windows.Forms.TabPage tabProperties;
		private System.Windows.Forms.Button btnAddUpdatePropertyValue;
		private System.Windows.Forms.ImageList imgList;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ContextMenu ctxContext;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.MenuItem menuItem5;
		private System.Windows.Forms.TabPage tabSecurity;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ListView lvwPermEntries;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		private System.Windows.Forms.MenuItem menuItem6;
		public static bool isAuthenticated = false;
		private System.Windows.Forms.ComboBox cboTrustees;
		private bool hasLoadedSecInfo = false;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.ToolTip toolTip;
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.Windows.Forms.MenuItem menuItem7;
		private System.Windows.Forms.MenuItem menuItem8;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.CheckedListBox lstPermList;
		
		private DirectoryUtil util;

		public FrmMain()
		{
			InitializeComponent();
			//Singlenton reference.
			util = DirectoryUtil.Instance;
//			util.Path = "IIS://LocalHost";
			

			util.OnBind += new DirectoryUtilEventHandler(RefreshedDirectoryHandler);
			InitTree();
		
		this.tvwDirectory.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvwDirectory_AfterSelect);
		}

		private void RefreshedDirectoryHandler(object sender, string path)
		{
			this.lblPath.Text = path;
			this.InitTree();
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

		private void LoadPropertyValues(string propertyName)
		{
			this.lstPropertyValue.Items.Clear();
			foreach(object propValue in util.SharedEntry.Properties[propertyName])
			{
				this.lstPropertyValue.Items.Add(propValue);
			}

		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(FrmMain));
			this.imgList = new System.Windows.Forms.ImageList(this.components);
			this.tvwDirectory = new System.Windows.Forms.TreeView();
			this.ctxContext = new System.Windows.Forms.ContextMenu();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.menuItem4 = new System.Windows.Forms.MenuItem();
			this.menuItem5 = new System.Windows.Forms.MenuItem();
			this.menuItem6 = new System.Windows.Forms.MenuItem();
			this.lblPath = new System.Windows.Forms.Label();
			this.tabMain = new System.Windows.Forms.TabControl();
			this.tabSecurity = new System.Windows.Forms.TabPage();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.lstPermList = new System.Windows.Forms.CheckedListBox();
			this.button1 = new System.Windows.Forms.Button();
			this.label7 = new System.Windows.Forms.Label();
			this.cboTrustees = new System.Windows.Forms.ComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.lvwPermEntries = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
			this.label3 = new System.Windows.Forms.Label();
			this.tabProperties = new System.Windows.Forms.TabPage();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.btnRemovePropertyValue = new System.Windows.Forms.Button();
			this.btnAddUpdatePropertyValue = new System.Windows.Forms.Button();
			this.txtPropertyValue = new System.Windows.Forms.TextBox();
			this.lstPropertyValue = new System.Windows.Forms.ListBox();
			this.lstProperties = new System.Windows.Forms.ListBox();
			this.toolTip = new System.Windows.Forms.ToolTip(this.components);
			this.contextMenu1 = new System.Windows.Forms.ContextMenu();
			this.menuItem7 = new System.Windows.Forms.MenuItem();
			this.menuItem8 = new System.Windows.Forms.MenuItem();
			this.tabMain.SuspendLayout();
			this.tabSecurity.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.tabProperties.SuspendLayout();
			this.SuspendLayout();
			// 
			// imgList
			// 
			this.imgList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
			this.imgList.ImageSize = new System.Drawing.Size(16, 16);
			this.imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList.ImageStream")));
			this.imgList.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// tvwDirectory
			// 
			this.tvwDirectory.AllowDrop = true;
			this.tvwDirectory.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left);
			this.tvwDirectory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tvwDirectory.ContextMenu = this.ctxContext;
			this.tvwDirectory.ImageList = this.imgList;
			this.tvwDirectory.LabelEdit = true;
			this.tvwDirectory.Location = new System.Drawing.Point(8, 40);
			this.tvwDirectory.Name = "tvwDirectory";
			this.tvwDirectory.Size = new System.Drawing.Size(328, 664);
			this.tvwDirectory.Sorted = true;
			this.tvwDirectory.TabIndex = 0;
			this.tvwDirectory.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tvwDirectory_KeyDown);
			this.tvwDirectory.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.tvwDirectory_AfterLabelEdit);
			// 
			// ctxContext
			// 
			this.ctxContext.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					   this.menuItem2,
																					   this.menuItem1,
																					   this.menuItem3,
																					   this.menuItem4,
																					   this.menuItem5,
																					   this.menuItem6});
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 0;
			this.menuItem2.Text = "Move To";
			this.menuItem2.Click += new System.EventHandler(this.MoveTo_Click);
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 1;
			this.menuItem1.Text = "Load Properties";
			this.menuItem1.Click += new System.EventHandler(this.LoadProperties_Click);
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 2;
			this.menuItem3.Text = "Add Entry";
			this.menuItem3.Click += new System.EventHandler(this.AddEntry_Click);
			// 
			// menuItem4
			// 
			this.menuItem4.Index = 3;
			this.menuItem4.Text = "Delete Entry";
			this.menuItem4.Click += new System.EventHandler(this.DeleteEntry_Click);
			// 
			// menuItem5
			// 
			this.menuItem5.Index = 4;
			this.menuItem5.Text = "Change Path";
			this.menuItem5.Click += new System.EventHandler(this.ChangePath_Click);
			// 
			// menuItem6
			// 
			this.menuItem6.Index = 5;
			this.menuItem6.Text = "Load Security";
			this.menuItem6.Click += new System.EventHandler(this.LoadSecurity_Click);
			// 
			// lblPath
			// 
			this.lblPath.AutoSize = true;
			this.lblPath.Location = new System.Drawing.Point(8, 16);
			this.lblPath.Name = "lblPath";
			this.lblPath.Size = new System.Drawing.Size(0, 13);
			this.lblPath.TabIndex = 2;
			// 
			// tabMain
			// 
			this.tabMain.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.tabMain.Controls.AddRange(new System.Windows.Forms.Control[] {
																				  this.tabSecurity,
																				  this.tabProperties});
			this.tabMain.Location = new System.Drawing.Point(360, 60);
			this.tabMain.Name = "tabMain";
			this.tabMain.SelectedIndex = 0;
			this.tabMain.Size = new System.Drawing.Size(712, 604);
			this.tabMain.TabIndex = 3;
			// 
			// tabSecurity
			// 
			this.tabSecurity.Controls.AddRange(new System.Windows.Forms.Control[] {
																					  this.groupBox1,
																					  this.lvwPermEntries,
																					  this.label3});
			this.tabSecurity.Location = new System.Drawing.Point(4, 22);
			this.tabSecurity.Name = "tabSecurity";
			this.tabSecurity.Size = new System.Drawing.Size(704, 578);
			this.tabSecurity.TabIndex = 1;
			this.tabSecurity.Text = "Security";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.lstPermList,
																					this.button1,
																					this.label7,
																					this.cboTrustees,
																					this.label5});
			this.groupBox1.Location = new System.Drawing.Point(16, 304);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(624, 248);
			this.groupBox1.TabIndex = 24;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Add new permission";
			
			// 
			// lstPermList
			// 
			this.lstPermList.Location = new System.Drawing.Point(200, 64);
			this.lstPermList.Name = "lstPermList";
			this.lstPermList.Size = new System.Drawing.Size(176, 169);
			this.lstPermList.TabIndex = 30;
			
			// 
			// button1
			// 
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button1.Location = new System.Drawing.Point(96, 192);
			this.button1.Name = "button1";
			this.button1.TabIndex = 26;
			this.button1.Text = "Apply";
			this.button1.Click += new System.EventHandler(this.button1_Click_2);
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(200, 40);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(98, 13);
			this.label7.TabIndex = 25;
			this.label7.Text = "Permission Details";
			// 
			// cboTrustees
			// 
			this.cboTrustees.Location = new System.Drawing.Point(24, 48);
			this.cboTrustees.Name = "cboTrustees";
			this.cboTrustees.Size = new System.Drawing.Size(160, 21);
			this.cboTrustees.TabIndex = 21;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(24, 32);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(48, 13);
			this.label5.TabIndex = 23;
			this.label5.Text = "Trustees";
			// 
			// lvwPermEntries
			// 
			this.lvwPermEntries.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lvwPermEntries.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																							 this.columnHeader1,
																							 this.columnHeader2,
																							 this.columnHeader3,
																							 this.columnHeader4,
																							 this.columnHeader5});
			this.lvwPermEntries.HoverSelection = true;
			this.lvwPermEntries.Location = new System.Drawing.Point(16, 24);
			this.lvwPermEntries.MultiSelect = false;
			this.lvwPermEntries.Name = "lvwPermEntries";
			this.lvwPermEntries.Size = new System.Drawing.Size(680, 264);
			this.lvwPermEntries.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.lvwPermEntries.TabIndex = 19;
			this.lvwPermEntries.View = System.Windows.Forms.View.Details;
			this.lvwPermEntries.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lvwPermEntries_MouseDown);
			this.lvwPermEntries.Click += new System.EventHandler(this.lvwPermEntries_Click);
			this.lvwPermEntries.DoubleClick += new System.EventHandler(this.lvwPermEntries_DoubleClick);
			this.lvwPermEntries.SelectedIndexChanged += new System.EventHandler(this.lvwPermEntries_SelectedIndexChanged);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Type";
			this.columnHeader1.Width = 80;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Trustee Name";
			this.columnHeader2.Width = 260;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Permission";
			this.columnHeader3.Width = 150;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "Inherited From";
			this.columnHeader4.Width = 100;
			// 
			// columnHeader5
			// 
			this.columnHeader5.Text = "Apply to";
			this.columnHeader5.Width = 130;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(16, 8);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(102, 13);
			this.label3.TabIndex = 13;
			this.label3.Text = "Permission Entries:";
			// 
			// tabProperties
			// 
			this.tabProperties.Controls.AddRange(new System.Windows.Forms.Control[] {
																						this.label2,
																						this.label1,
																						this.btnRemovePropertyValue,
																						this.btnAddUpdatePropertyValue,
																						this.txtPropertyValue,
																						this.lstPropertyValue,
																						this.lstProperties});
			this.tabProperties.Location = new System.Drawing.Point(4, 22);
			this.tabProperties.Name = "tabProperties";
			this.tabProperties.Size = new System.Drawing.Size(704, 578);
			this.tabProperties.TabIndex = 0;
			this.tabProperties.Text = "Properties";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(16, 200);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(95, 13);
			this.label2.TabIndex = 13;
			this.label2.Text = "Property Value(s):";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(16, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(89, 13);
			this.label1.TabIndex = 12;
			this.label1.Text = "Property Names:";
			// 
			// btnRemovePropertyValue
			// 
			this.btnRemovePropertyValue.Enabled = false;
			this.btnRemovePropertyValue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnRemovePropertyValue.Location = new System.Drawing.Point(152, 336);
			this.btnRemovePropertyValue.Name = "btnRemovePropertyValue";
			this.btnRemovePropertyValue.Size = new System.Drawing.Size(152, 23);
			this.btnRemovePropertyValue.TabIndex = 11;
			this.btnRemovePropertyValue.Text = "Remove Property Value";
			this.btnRemovePropertyValue.Click += new System.EventHandler(this.btnRemovePropertyValue_Click_1);
			// 
			// btnAddUpdatePropertyValue
			// 
			this.btnAddUpdatePropertyValue.Enabled = false;
			this.btnAddUpdatePropertyValue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnAddUpdatePropertyValue.Location = new System.Drawing.Point(16, 337);
			this.btnAddUpdatePropertyValue.Name = "btnAddUpdatePropertyValue";
			this.btnAddUpdatePropertyValue.Size = new System.Drawing.Size(128, 23);
			this.btnAddUpdatePropertyValue.TabIndex = 10;
			this.btnAddUpdatePropertyValue.Text = "Add / Update Property";
			this.btnAddUpdatePropertyValue.Click += new System.EventHandler(this.btnAddPropertyValue_Click);
			// 
			// txtPropertyValue
			// 
			this.txtPropertyValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtPropertyValue.Enabled = false;
			this.txtPropertyValue.Location = new System.Drawing.Point(16, 376);
			this.txtPropertyValue.Name = "txtPropertyValue";
			this.txtPropertyValue.Size = new System.Drawing.Size(160, 20);
			this.txtPropertyValue.TabIndex = 9;
			this.txtPropertyValue.Text = "";
			// 
			// lstPropertyValue
			// 
			this.lstPropertyValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lstPropertyValue.Location = new System.Drawing.Point(16, 217);
			this.lstPropertyValue.Name = "lstPropertyValue";
			this.lstPropertyValue.Size = new System.Drawing.Size(288, 106);
			this.lstPropertyValue.TabIndex = 8;
			this.lstPropertyValue.DoubleClick += new System.EventHandler(this.lstPropertyValue_DoubleClick);
			// 
			// lstProperties
			// 
			this.lstProperties.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lstProperties.Location = new System.Drawing.Point(16, 25);
			this.lstProperties.Name = "lstProperties";
			this.lstProperties.Size = new System.Drawing.Size(280, 171);
			this.lstProperties.TabIndex = 7;
			this.lstProperties.SelectedIndexChanged += new System.EventHandler(this.lstProperties_SelectedIndexChanged);
			// 
			// contextMenu1
			// 
			this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						 this.menuItem7,
																						 this.menuItem8});
			
			// 
			// menuItem7
			// 
			this.menuItem7.Index = 0;
			this.menuItem7.Text = "Delete permission";
			this.menuItem7.Click += new System.EventHandler(this.menuItem7_Click);
			// 
			// menuItem8
			// 
			this.menuItem8.Index = 1;
			this.menuItem8.Text = "Add permission";
			this.menuItem8.Click += new System.EventHandler(this.menuItem8_Click);
			// 
			// FrmMain
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(1096, 682);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.tabMain,
																		  this.lblPath,
																		  this.tvwDirectory});
			this.Name = "FrmMain";
			this.Text = "Directory Browser";
			this.Load += new System.EventHandler(this.FrmMain_Load);
			this.tabMain.ResumeLayout(false);
			this.tabSecurity.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.tabProperties.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			try
			{
				Application.Run(new FrmMain());
			}
			catch(Exception e)
			{
				Console.Write(e.Message);

			}
		}


		/// <summary>
		/// Inicializes the TreeView
		/// Responsible for inicial 
		/// loading of TreeNodes
		/// </summary>
		private void InitTree()
		{
			this.tvwDirectory.Nodes.Clear();
			this.tvwDirectory.Nodes.Add(new TreeNode(util.RootContainer.Name,0,0));
			//Tag TreeNode
			this.tvwDirectory.Nodes[0].Tag = new 
				TreeNodeInfo(util.Path,true);
			int index = 0;
			foreach(DirectoryEntry child in util.SharedEntry.Children)
			{
				index = this.tvwDirectory.Nodes[0].Nodes.Add(new TreeNode(child.Name,3,4));
				//Tag TreeNode
				this.tvwDirectory.Nodes[0].Nodes[index].Tag = 
										new TreeNodeInfo(child.Path,false);
			}
			this.tvwDirectory.ExpandAll();
		}

		/// <summary>
		/// After a user selects a TreeNode in the
		/// TreeView it will fire this event....complete this later...
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tvwDirectory_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			this.lstProperties.Items.Clear();	
			TreeNodeInfo nodeInfo = (TreeNodeInfo)e.Node.Tag;
			int index = 0;
			//Bind to an instance of the current node entry in the TreeView
			util.SharedEntry.Path = (nodeInfo.Path);
			//Only Re-Bind the SharedEntry.
			util.SharedEntry.RefreshCache();
			//Add current path on the lable
			this.lblPath.Text = nodeInfo.Path;
			//Check if the TreeNode was previoulsy loaded
			if(!nodeInfo.IsLoaded)
			{
				try
				{
					//Iterate through out the child nodes
					foreach(DirectoryEntry child in util.SharedEntry.Children)
					{
						switch(child.SchemaClassName)
						{
							case "user"://User
								index = e.Node.Nodes.Add(new TreeNode(child.Name,1,1));
								break;
							case "group"://Group
								index = e.Node.Nodes.Add(new TreeNode(child.Name,2,2));
				
								break;
							case "computer"://Computer
								index = e.Node.Nodes.Add(new TreeNode(child.Name,5,5));
								break;

							case "mS-SQL-SQLServer"://Sql Server
								index = e.Node.Nodes.Add(new TreeNode(child.Name,6,6));
								break;

							case "printQueue"://Printer
								index = e.Node.Nodes.Add(new TreeNode(child.Name,7,7));
								break;

							default://Generic folders
								index = e.Node.Nodes.Add(new TreeNode(child.Name,3,4));
								break;

						}
						e.Node.Nodes[index].Tag = new TreeNodeInfo(child.Path,false);
					}
					//Re-Tag node
					nodeInfo.IsLoaded = true;
					e.Node.ExpandAll();
					
				}
				catch (Exception ex)
				{
					//Trace errors
				}
			}
		}

	

		/// <summary>
		/// Used for loading properties that are
		/// selected into the lstPropertiesValue
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void lstProperties_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			//Disable controls
			this.btnRemovePropertyValue.Enabled = false;
			this.btnAddUpdatePropertyValue.Enabled = false;
			this.txtPropertyValue.Enabled = false;
 
			string propertyName  = this.lstProperties.Items[this.lstProperties.SelectedIndex].ToString();
			LoadPropertyValues(propertyName );
		}

		/// <summary>
		/// Enables editing controls for property handling
		/// if there is any selected property.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void lstPropertyValue_DoubleClick(object sender, System.EventArgs e)
		{
			if(this.lstPropertyValue.SelectedIndex > -1)
			{
				this.btnRemovePropertyValue.Enabled = true;
				btnAddUpdatePropertyValue.Enabled = true;
				this.txtPropertyValue.Enabled = true;

			}		
		}

		/// <summary>
		/// Adds a new property in the PropertyValueCollection
		/// of a Property
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnAddPropertyValue_Click(object sender, System.EventArgs e)
		{
			string propertyName = null;

			try
			{
				//Get Current property name
				propertyName =
					this.lstProperties.Items[this.lstProperties.SelectedIndex].ToString();
				//Check if we can add multiple values to the property
				try
				{
					util.SharedEntry.Properties[propertyName].Add(this.txtPropertyValue.Text);
					//Update directory	
					util.SharedEntry.CommitChanges();
				}
				catch(Exception ex)
				{
					util.SharedEntry.Properties[propertyName].Value = (object)this.txtPropertyValue.Text;
					//Update directory	
					util.SharedEntry.CommitChanges();
				}		
			}
			catch(System.UnauthorizedAccessException exy)
			{
				MessageBox.Show("Access denied");

			}
			
			//Reload property value list
			ReloadPropertyValues(propertyName);
		}

		/// <summary>
		/// Removes a PropertyValue
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnRemovePropertyValue_Click_1(object sender, System.EventArgs e)
		{
			string property = this.lstPropertyValue.Items[this.lstPropertyValue.SelectedIndex].ToString();
			string propertyName = this.lstProperties.Items[this.lstProperties.SelectedIndex].ToString();
			util.SharedEntry.Properties[propertyName].Remove(property);
			util.SharedEntry.CommitChanges();
			//Reload property value list
			ReloadPropertyValues(propertyName);
		}

		/// <summary>
		/// Loads or reload the property values
		/// into the lstPropertyValue ListBox
		/// </summary>
		/// <param name="propertyName"></param>
		private void ReloadPropertyValues(string propertyName)
		{

			this.lstPropertyValue.Items.Clear();
			foreach(object propValue in util.SharedEntry.Properties[propertyName])
			{
				this.lstPropertyValue.Items.Add(propValue);
			}
		}

		/// <summary>
		/// Places the selected TreeNode in Edit mode
		/// for changing the label
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tvwDirectory_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
	
			if(e.KeyCode == Keys.F2)
				this.tvwDirectory.SelectedNode.BeginEdit();
		}

	
		/// <summary>
		/// Updates the TreeNode label
		/// after editing.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tvwDirectory_AfterLabelEdit(object sender, System.Windows.Forms.NodeLabelEditEventArgs e)
		{
			try
			{
				util.SharedEntry.Rename(e.Label);
				util.SharedEntry.CommitChanges();
			}
			catch(Exception ex)
			{	
				//Trace
			}
		}
	
	
		/// <summary>
		/// Changes the current Path
		/// from the Root Container.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ChangePath_Click(object sender, System.EventArgs e)
		{
			//Pop up a new inputbox and return the string.
			string newPath =  
				Microsoft.VisualBasic.Interaction.InputBox(
				"Enter a new Path:",
				"Change Path","",
				this.tvwDirectory.Location.X,this.tvwDirectory.Location.Y);
			//Only change path if new path is returned.
			if(newPath.Length > 0)
			{
				util.Path = newPath;
			}
		}

		/// <summary>
		/// Shows FrmAdd for adding new entries
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void AddEntry_Click(object sender, System.EventArgs e)
		{
			//Check if parent is a container
			if(util.SharedEntry.SchemaClassName == "container")
			{		//Show form for adding new entry
				FrmAdd frm = new FrmAdd();
				frm.ShowDialog();
			}
			else
			{
				MessageBox.Show("Current Entry is not a container",
					"Error adding new Entry",
					MessageBoxButtons.OK,MessageBoxIcon.Error);
			}
			//Refresh structure.
			util.Bind();
		}

		/// <summary>
		/// Deletes an entry from the directory
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void DeleteEntry_Click(object sender, System.EventArgs e)
		{
			try
			{
				util.SharedEntry.RefreshCache();
				util.SharedEntry.DeleteTree();
				util.SharedEntry.CommitChanges();
				//Refresh structure.
				util.Bind();
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			
			}
		}

		/// <summary>
		/// Shows the FrmMove form for
		/// moving entries between locations
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void MoveTo_Click(object sender, System.EventArgs e)
		{
			FrmMove frm = new FrmMove();
			frm.ShowDialog();
			util.Bind();
		}

		/// <summary>
		/// Load property names into 
		/// lstProperties listbox
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void LoadProperties_Click(object sender, System.EventArgs e)
		{
			this.lstProperties.Items.Clear();		
			foreach(string propertyName in util.SharedEntry.Properties.PropertyNames)
			{
				this.lstProperties.Items.Add(propertyName);
			}
		}


	
		private void ReloadTrustees(string path)
		{
		
			
		}

		private void LoadAceDetails()
		{
			string schemaPath = "LDAP://";
			schemaPath += new DirectoryEntry("LDAP://RootDSE").Properties["schemaNamingContext"].Value.ToString();
			
			DirectoryEntry schemaEntry = new DirectoryEntry(schemaPath);

			schemaEntry.Path = "LDAP://CN=Users," +  new DirectoryEntry("LDAP://RootDSE").Properties["defaultNamingContext"].Value.ToString();
			foreach(DirectoryEntry child in schemaEntry.Children)
			{
				try
				{
					this.cboTrustees.Items.Add(child.Properties["userPrincipalName"].Value.ToString());
				}
				catch(Exception e)
				{

				}
			}


			foreach(string perm in Enum.GetNames(typeof(ADS_RIGHTS_ENUM)))
			{
				if(perm != Enum.GetName(typeof(ADS_RIGHTS_ENUM),ADS_RIGHTS_ENUM.ADS_RIGHT_DS_READ_PROP)
					|| perm != Enum.GetName(typeof(ADS_RIGHTS_ENUM),ADS_RIGHTS_ENUM.ADS_RIGHT_DS_WRITE_PROP))
				{


					object p = Enum.Parse(typeof(ADS_RIGHTS_ENUM),perm);
					PermissionItem o = new PermissionItem(Enum.Parse(typeof(ADS_RIGHTS_ENUM),perm),
						AccessControlEntry.GetFriendlyName(perm));
					this.lstPermList.Items.Add(
						o,CheckState.Unchecked);
					Console.Write("");
				}

			}
	
			hasLoadedSecInfo = true;
		}

		private void LoadSecurity_Click(object sender, System.EventArgs e)
		{

			this.lvwPermEntries.Items.Clear();
			AccessControlList acl = new AccessControlList(util.SharedEntry);


			string accessMask = null;
			string inheritedObject = null;
			string aceFlags = null;

			
			
			foreach(AccessControlEntry ace in acl)
			{
				aceFlags =	AccessControlEntry.GetFriendlyName("ADS_ACEFLAG_INHERIT_ACE");

				if(ace.AceFlags != null)
				{
					foreach(string flag in ace.AceFlags)
					{
						if(flag == "ADS_ACEFLAG_NO_PROPAGATE_INHERIT_ACE")
						{
							
							aceFlags =	AccessControlEntry.GetFriendlyName(flag);
							break;
					
						}
					}
				}

				switch(ace.AccessMask.Length)
				{
					case 1:
						accessMask = AccessControlEntry.GetFriendlyName(ace.AccessMask.GetValue(0).ToString());
						break;
					case 13:
						accessMask = "Full Control";
						break;
					
					default:
					accessMask = "Special";
						break;
				}
				if(ace.ObjectType.Length > 1)
					accessMask += " " + ace.ObjectType;
				
			
				if(ace.InheritedObject.Length == 0)
					inheritedObject = "<<not inherited>>";
				else
					inheritedObject = ace.InheritedObject + " Objects";



				string[] items = 
					new string[]{AccessControlEntry.GetFriendlyName(ace.AceType.GetValue(0).ToString())
								,ace.Trustee,
								accessMask,
								inheritedObject,
								aceFlags};
				ListViewItem item = this.lvwPermEntries.Items.Add(new ListViewItem(items));
				item.Tag = new object[]{ace.AccessMask,ace.NativeAce};
				
				
			}
			
		}

		private void FrmMain_Load(object sender, System.EventArgs e)
		{
			FrmLogin frm =new FrmLogin();
			frm.ShowDialog();
			if(!isAuthenticated)
				this.Dispose();
			util.Bind();

		}

		private void lvwPermEntries_SelectedIndexChanged(object sender, System.EventArgs e)
		{	
		
					
		}

		private void lvwPermEntries_DoubleClick(object sender, System.EventArgs e)
		{
//		this.lstPermDetails.Items.Clear();
			
			object[] hiddenObject = (object[])this.lvwPermEntries.SelectedItems[0].Tag;
			ContextMenu ctx = new ContextMenu();
			string[] masks = (string[])hiddenObject.GetValue(0);
			string items = null;
			foreach(string mask in masks)
				items += AccessControlEntry.GetFriendlyName(mask) + "\n";
				
			this.toolTip.SetToolTip(this.lvwPermEntries,items);
		
		}

		private void button1_Click_1(object sender, System.EventArgs e)
		{


		}

		private void button1_Click_2(object sender, System.EventArgs e)
		{

			StringBuilder builder = new StringBuilder();
			AccessControlList acl = new AccessControlList(util.SharedEntry);
			string enumValues = null;

//			for(int	i=0;i<this.lstPermList.CheckedIndices.Count;i++)
//			{
//				PermissionItem o = (PermissionItem)lstPermList.Items[lstPermList.CheckedIndices[i]];
//				Console.Write("");
//			}
		
			IEnumerator myEnumerator;
			myEnumerator = this.lstPermList.CheckedIndices.GetEnumerator();
			int index;
			while (myEnumerator.MoveNext() != false)
			{
				index =(int) myEnumerator.Current;
				PermissionItem item = (PermissionItem)lstPermList.Items[index] ;
						builder.Append(item.EnumObject);
					builder.Append(',');
			}


		string concatValue =	builder.ToString().TrimEnd(new Char[]{','});
		ADS_RIGHTS_ENUM accessMask = (ADS_RIGHTS_ENUM)Enum.Parse(typeof(ADS_RIGHTS_ENUM),concatValue);

			acl.ApplyPermission(this.cboTrustees.Text,
								ADS_ACETYPE_ENUM.ADS_ACETYPE_ACCESS_ALLOWED ,
								accessMask,
								ADS_ACEFLAG_ENUM.ADS_ACEFLAG_INHERIT_ACE,
								ADS_FLAGTYPE_ENUM.ADS_FLAG_OBJECT_TYPE_PRESENT);
			


			acl.CommitChanges();

			LoadSecurity_Click(this,new EventArgs());
								
		}

		public Enum ParseEnum (System.Type enumType, string val)
		{
			FieldInfo fi = enumType.GetField(val, BindingFlags.Instance|BindingFlags.Public|BindingFlags.Static);
			if ( fi == null )
			{
				throw new ArgumentException("Enum member does not exist: " + val);
			}
			return (Enum) fi.GetValue(null);
		}


		private void lvwPermEntries_Click(object sender, System.EventArgs e)
		{
			
		}

		private void lvwPermEntries_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if( e.Button == MouseButtons.Right )
				this.contextMenu1.Show(this.lvwPermEntries,new Point(e.X,e.Y));

		}

		private void menuItem7_Click(object sender, System.EventArgs e)
		{
			object[] hiddenObject = (object[])this.lvwPermEntries.SelectedItems[0].Tag;
			
			object ace = (object)hiddenObject.GetValue(1);
		

			AccessControlList acl = new AccessControlList(util.SharedEntry);
			acl.Remove(ace);
	
			acl.CommitChanges();

		LoadSecurity_Click(this,new EventArgs());
		}

		private void menuItem8_Click(object sender, System.EventArgs e)
		{
			if(!hasLoadedSecInfo)
				LoadAceDetails();
		}

		
	}

	class PermissionItem
	{
		private object _enumValue = null;
		private string _text = null;

		public PermissionItem(object enumValue,string text)
		{
			_enumValue = enumValue;
			_text = text;
		}
	
		public override string ToString()
		{
			return _text;
		}

		public object EnumObject
		{
			get
			{
				return _enumValue;
			}
		}
	}

	
}
