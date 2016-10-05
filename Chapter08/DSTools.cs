using System;
using System.DirectoryServices;
using CDOEXM;

namespace DSSamples
{
	/// <summary>
	/// Summary description for DSTools.
	/// </summary>
	public class DSTools
	{
		protected String ExceptionOutput = "";

		public DSTools()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public String DisplayDEProperties(String LDAPPath)
		{
			DirectoryEntry objDirEnt;
			String tempOut;

			try
			{
				objDirEnt = new DirectoryEntry(LDAPPath);
			}
			catch(Exception ex)
			{
				ExceptionOutput += ex.Message;
				return null;
			}

			tempOut=("Name\t\t= " + objDirEnt.Name + "\r\n");
			tempOut+=("Path\t\t= " + objDirEnt.Path + "\r\n");
			tempOut+=("SchemaClassName\t= " + objDirEnt.SchemaClassName + "\r\n");
			tempOut+=("\r\n");
			tempOut+=("Properties:" + "\r\n");

			foreach(String Key in objDirEnt.Properties.PropertyNames) 
			{
				tempOut+=(Key + "\t= ");
				foreach(Object objValue in objDirEnt.Properties[Key]) 
				{
					tempOut+=("\t" + objValue.ToString() + "\r\n");
				}
			}
			return tempOut;
		}

		public SearchResultCollection FindDirectoryObjects(String LDAPPath, String SearchCriteria)
		{
			DirectoryEntry objDirEnt;
			DirectorySearcher searcher ;
			SearchResultCollection SearchResults;

			try
			{
				objDirEnt = new DirectoryEntry(LDAPPath);
			}
			catch(Exception ex)
			{
				ExceptionOutput += ex.Message;
				return null;
			}

			searcher = new DirectorySearcher(objDirEnt);
			searcher.Filter = (SearchCriteria);

			try
			{
				SearchResults = searcher.FindAll();
			}
			catch (Exception ex)
			{
				ExceptionOutput += "\n";
				ExceptionOutput += ex.Message;
				return null;
			}

			return SearchResults;
		}

		private void StartRUS()
		{
			String RUSPath = "LDAP://servername.domain.com/CN=Recipient Update Service (DOMAIN),CN=Recipient Update Services,CN=Address Lists Container,CN=OrgName,CN=Microsoft Exchange,CN=Services,CN=Configuration,DC=domain,DC=com";

			DirectoryEntry objRUS = new DirectoryEntry(RUSPath);
			objRUS.Properties["msExchReplicateNow"].Value = true;

			objRUS.CommitChanges();
		}

		public void CreateMailbox(String fullName, String alias)
		{
			DirectoryEntry container, objUser, rootDSE;
			IMailboxStore mailboxStore;

			string password = "newP@ssword";
			string domainName = "domain.com";
			string homeMDB = "CN=Mailbox Store (SERVERNAME),CN=First Storage Group,"
				+ "CN=InformationStore,CN=SERVERNAME,CN=Servers,"
				+ "CN=First Administrative Group,CN=Administrative Groups,CN=OrgName,"
				+ "CN=Microsoft Exchange,CN=Services,CN=Configuration,DC=domain,DC=com";

			// Create user in the default "users" container.
			rootDSE = new DirectoryEntry("LDAP://RootDSE");
			container = new DirectoryEntry("LDAP://CN=Users,"  + rootDSE.Properties["defaultNamingContext"].Value);

			objUser = container.Children.Add("cn=" + fullName, "user");
			objUser.Properties["sAMAccountName"].Add(alias);
			objUser.Properties["userPrincipalName"].Add(alias + "@" + domainName);
			
			// Enable this user object
			objUser.Properties["userAccountControl"].Value = 0x200;

			objUser.CommitChanges();

			objUser.Invoke("SetPassword", new object[]{password});

			mailboxStore = (IMailboxStore)objUser.NativeObject;
			mailboxStore.CreateMailbox(homeMDB);

			objUser.CommitChanges();
		}

		public void DeleteMailbox(String LDAPPath)
		{
			DirectoryEntry trash = new DirectoryEntry(LDAPPath);
			DirectoryEntry parentObject = trash.Parent;
			parentObject.Children.Remove(trash);
		}

		public void HideMailbox(String LDAPPath)
		{
			DirectoryEntry objUser = new DirectoryEntry(LDAPPath);

			objUser.Properties["msExchHideFromAddressLists"].Value = true;
			objUser.CommitChanges();
		}
	
	}
}
