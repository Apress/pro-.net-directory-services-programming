using System;
using System.Reflection;
using System.DirectoryServices;
using CDOEXM;

namespace DSSamples
{
	/// <summary>
	/// Summary description for OtherTechnologies.
	/// </summary>
	public class OtherTechnologies
	{
		public OtherTechnologies()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public String CDOGetSubjects()
		{
			MAPI.Session objSession = new MAPI.Session();
			String retVal = "";

			// Missing.Value represents a default argument
			object objEmpty = Missing.Value;

			// Logon the session using CDO's UI
			objSession.Logon(objEmpty, objEmpty, true, true, 0, true, objEmpty);

			MAPI.Folder objInbox = (MAPI.Folder)objSession.Inbox;
			MAPI.Messages objMessages = (MAPI.Messages)objInbox.Messages;
			MAPI.Message objMessage = (MAPI.Message)objMessages.GetFirst(objEmpty);

			while (objMessage is MAPI.Message)
			{
				retVal += objMessage.Subject.ToString();
				objMessage = (MAPI.Message)objMessages.GetNext();
				if (objMessage is MAPI.Message)
					retVal += "\r\n";
			}
			return retVal;

		}

		public void CDOEXSendEmail(String recipient)
		{
			CDO.Message objMessage = new CDO.Message();
			
			objMessage.From = "Administrator@domain.com";
			objMessage.To = recipient;
			objMessage.Subject = "Testing some CDOEX functionality";
			objMessage.TextBody = "Yup, it seems to be working ok!\r\n\r\nCheers,\r\nMikael";
			objMessage.Send();
		}

		public void CDOEXMDeleteMailbox(String LDAPPath)
		{
			DirectoryEntry objUser;
			IMailboxStore mailboxStore;

			objUser = new DirectoryEntry(LDAPPath);

			mailboxStore = (IMailboxStore)objUser.NativeObject;
			mailboxStore.DeleteMailbox();

			objUser.CommitChanges();
		}	
	}
}
