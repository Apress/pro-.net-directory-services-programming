using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.DirectoryServices;

namespace WindowsApplication1
{
	/// <summary>
	/// Summary description for FrmMoveToContainer.
	/// </summary>
	public class FrmMove: System.Windows.Forms.Form
	{
		private System.Windows.Forms.TreeView tvwContainer;
		private System.Windows.Forms.ImageList imgList;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Button btnCancel;
		private DirectoryUtil util;

		public FrmMove()
		{
			//Get singleton reference
			util = DirectoryUtil.Instance;
			
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			this.tvwContainer.ExpandAll();
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
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(FrmMove));
			this.tvwContainer = new System.Windows.Forms.TreeView();
			this.imgList = new System.Windows.Forms.ImageList(this.components);
			this.btnOk = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// tvwContainer
			// 
			this.tvwContainer.ImageList = this.imgList;
			this.tvwContainer.Name = "tvwContainer";
			this.tvwContainer.Size = new System.Drawing.Size(304, 306);
			this.tvwContainer.TabIndex = 0;
			this.tvwContainer.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvwContainer_AfterSelect);
			// 
			// imgList
			// 
			this.imgList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
			this.imgList.ImageSize = new System.Drawing.Size(16, 16);
			this.imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList.ImageStream")));
			this.imgList.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// btnOk
			// 
			this.btnOk.Location = new System.Drawing.Point(120, 320);
			this.btnOk.Name = "btnOk";
			this.btnOk.TabIndex = 1;
			this.btnOk.Text = "Ok";
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(216, 320);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 2;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// FrmMoveToContainer
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(306, 358);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.btnCancel,
																		  this.btnOk,
																		  this.tvwContainer});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "FrmMoveToContainer";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Load += new System.EventHandler(this.FrmMoveToContainer_Load);
			this.ResumeLayout(false);

		}
		#endregion

		
		
	
		/// <summary>
		/// Prepare TreeView for loading
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void FrmMoveToContainer_Load(object sender, System.EventArgs e)
		{
			this.Text = "Move Entries";
			
			this.tvwContainer.Nodes.Clear();
			this.tvwContainer.Nodes.Add(new TreeNode(util.RootContainer.Name,0,0));
			this.tvwContainer.Nodes[0].Tag = new TreeNodeInfo(util.RootContainer.Path,false);
			
		}

	
		/// <summary>
		/// Load TreeNodes
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tvwContainer_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
		
			TreeNodeInfo nodeInfo = (TreeNodeInfo)e.Node.Tag;
			int index = 0;
		    DirectoryEntry temp = new DirectoryEntry();
			if(!nodeInfo.IsLoaded)
			{
				try
				{
		
					foreach(DirectoryEntry child in temp.Children)
					{
						if(child.SchemaClassName == "container")
						{
							index = e.Node.Nodes.Add(new TreeNode(child.Name,3,4));
							e.Node.Nodes[index].Tag = new TreeNodeInfo(child.Path,false);
						}
					}
					nodeInfo.IsLoaded = true;
					this.tvwContainer.ExpandAll();
				}

				catch(Exception ex)
				{

					//Add tracing
				}
			}
		}

	
		/// <summary>
		/// Move Object
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnOk_Click(object sender, System.EventArgs e)
		{
			try
			{
				TreeNodeInfo nodeInfo = (TreeNodeInfo)this.tvwContainer.SelectedNode.Tag;
				//Validate
				//Check if any TreeNode is selected
				if(!(this.tvwContainer.SelectedNode.Index > 0))
					throw new Exception("Please Select a Destination");
				else
					//Do moving
					new DirectoryEntry(util.SharedEntry.Path).MoveTo(new DirectoryEntry(nodeInfo.Path));
				//Go back to FrmMain		
				this.Dispose();	
				
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message,
								this.Text.ToString(),
								MessageBoxButtons.OK,
								MessageBoxIcon.Stop);
			}
		
		}

		/// <summary>
		/// Cancel all
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			this.Dispose();
		}
	}

	
}
