using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Web;
using System.Web.Services;
using System.DirectoryServices;
using System.Xml;
using System.IO ;

namespace dirSearcherService
{
	public class adSearchWS : System.Web.Services.WebService
	{
		public adSearchWS()
		{
			//CODEGEN: This call is required by the ASP.NET Web Services Designer
			InitializeComponent();
		}

		#region Component Designer generated code
		
		//Required by the Web Services Designer 
		private IContainer components = null;
				
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if(disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);		
		}
		
		#endregion

		[WebMethod]
		public string getADDetails(string xmlParams,string []propToLoad)
		{

			//create XmlDocument object
			XmlDocument doc =new XmlDocument(); 
			//load xml formatted string
			doc.LoadXml(xmlParams); 
			//create DirectoryEntry object by extracting XML
			DirectoryEntry root = new DirectoryEntry (
				doc.GetElementsByTagName("ROOT")[0].InnerXml,
				doc.GetElementsByTagName("ID")[0].InnerXml ,
				doc.GetElementsByTagName("PWD")[0].InnerXml);

			DirectorySearcher searcher=new DirectorySearcher(root);

			//Assign filter
			searcher.Filter = doc.GetElementsByTagName("FILTER")[0].InnerXml;
			//Add properties to load from string array
			for (int i=0; i< propToLoad.Length  ;i++)
				searcher.PropertiesToLoad.Add (propToLoad[i]); 

			//populate and return result in XML format to client
			return SearchAndPopulateResultInXML(searcher);
		}
		private static string SearchAndPopulateResultInXML  (DirectorySearcher searcher)
		{
			StringWriter w =new StringWriter(); 
			XmlTextWriter xw = new XmlTextWriter (w);
			xw.Formatting = Formatting.Indented;
			//create XML using properties and values 
			xw.WriteStartDocument(); 
			xw.WriteStartElement("ADSearchData");

			foreach(SearchResult resEnt in searcher.FindAll())
			{
				foreach (string pN in resEnt.Properties.PropertyNames)
				{
					foreach (object val in resEnt.Properties[pN]) 
					{
						xw.WriteElementString(pN, val.ToString() );
					}            
				}               
			}
			xw.WriteEndElement();
			xw.WriteEndDocument();    
			xw.Flush ();
			xw.Close ();
			return w.ToString();      
		}
	}
}

