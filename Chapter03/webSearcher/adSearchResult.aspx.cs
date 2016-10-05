using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.DirectoryServices;

namespace webADSI
{
	/// <summary>
	/// Summary description for WebForm2.
	/// </summary>
	public class WebForm2 : System.Web.UI.Page
	{
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			Response.Write ("<STRONG><FONT color=red size=6 >Search Result</FONT></STRONG>");

			Response.Write ("<HR>");
			Response.Write ("The AdsPath is :" + Request.Form["adsPath"]);  
			Response.Write ("<P></P>The Filter is set for :" + Request.Form["txtFilter"]);
			Response.Write ("<HR>");
			try
			{
				DirectoryEntry ent;
				if (Request.Form["Checkbox1"]== "on")
				{
					ent=new DirectoryEntry( Request.Form["adsPath"],Request.Form["UID"],Request.Form["PWD"]);
				}
				else
				{
					ent=new DirectoryEntry( Request.Form["adsPath"]);
				}
				DirectorySearcher searcher = new DirectorySearcher(ent);
								
				searcher.Filter =Request.Form["txtFilter"];
				SearchAndPopulateResult (searcher);
			}
			catch (Exception eR)
			{
				Response.Write( eR.Message);   
			}
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		 
		public void SearchAndPopulateResult  (DirectorySearcher searcher)
		{
			foreach(SearchResult resEnt in searcher.FindAll())
			{	
				Response.Write("<TABLE border=1>");
				Response.Write("<tr>");				
					Response.Write("<td  bgColor=buttonface align=center><STRONG>Property</STRONG></td>");
					Response.Write("<td  bgColor=buttonface align=center><STRONG>Value</STRONG></td>");						
				Response.Write("</tr>");
				foreach (string pN in resEnt.Properties.PropertyNames)
				{
					foreach (object va in resEnt.Properties[pN])
					{
						Response.Write("<tr>");
						Response.Write("<TD bgColor=#ccffcb align=right>");
						Response.Write(pN);
						Response.Write("</TD>");
						Response.Write("<TD bgcolor=#ffffcc>");
						Response.Write(va);
						Response.Write("</TD></tr>");				 
					}
				}
				Response.Write("</TABLE>");
				Response.Write("<hr>");		
			}
		}
	}
}

						