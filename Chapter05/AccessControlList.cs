using System;
using ActiveDs;
using System.Collections;
using System.DirectoryServices;   
using System.IO;
using System.Text;


namespace Wrox.DirectoryServices.Securiy
{
	/// <summary>
	/// Creates a custom Access Control Entry List for DirectoryEntry
	/// </summary>AccessControlList
	public class AccessControlList : IEnumerable
	{
		
		private AccessControlEntries _aceList = 
			new AccessControlEntries();
		private AccessControlEntries _pendingAceList = 
			new AccessControlEntries();

		private DirectoryEntry _user;
		private int _index = -1;
		private IADsSecurityDescriptor _securityDescriptor; 
		private IADsAccessControlList _accessControlList; 
		
		
		public AccessControlList(DirectoryEntry user)
		{
			_user = user;
			if(_securityDescriptor == null)
			{
				try
				{
					_securityDescriptor = _user.Properties["ntSecurityDescriptor"].Value as IADsSecurityDescriptor;
					_accessControlList = _securityDescriptor.DiscretionaryAcl as IADsAccessControlList;
					
				}
				catch(Exception e)
				{
					//trace error
				}
			}
			Fill();
		}
		
		



		private void Fill()
		{	
			int index = 0;
			foreach(IADsAccessControlEntry ace  in _accessControlList)
			{
				string objectType  = string.Empty;
				string  inheritedObjectType  = string.Empty;
				
				try
				{
					
		
					//AccessMask
					string accesMask  = Enum.Format(typeof(ADS_RIGHTS_ENUM), 
						Convert.ToUInt32(ace.AccessMask), "F");
					string[] arrayAccessMask = accesMask.Replace(" ","").Split(',');
				
					//AceType
					string aceType = Enum.Format(typeof(ADS_ACETYPE_ENUM), 
						ace.AceType,
						"F");
					string[] arrayAceType = aceType.Replace(" ","").Split(',');

					//AceFlag
					string aceFlag = Enum.Format(typeof(ADS_ACEFLAG_ENUM), 
						Convert.ToByte(ace.AceFlags),
						"F");
					string[] arrayAceFlag = aceFlag.Replace(" ","").Split(',');

					//Flag
					string flag = Enum.Format(typeof(ADS_FLAGTYPE_ENUM), 
						ace.Flags,
						"f");
					string[] flagArray = flag.Replace(" ","").Split(',');

				
					if(ace.Flags > 0)
					{
						//Inherited object
						if(ace.InheritedObjectType != null)
						{
							inheritedObjectType = NativeGUIDToPath(ace.InheritedObjectType);
						}
						//Object Type
						if(ace.ObjectType != null)
						{
							objectType = NativeGUIDToPath(ace.ObjectType);
						}
					}
					
					_aceList.Add(new AccessControlEntry(ace.Trustee,
						arrayAceType,arrayAccessMask, arrayAceFlag, flagArray,objectType, inheritedObjectType, ace));
				}
				catch(Exception e)
				{
					//TODO: Log error...
				}
			}
		
		}	

		
	

		public void CommitChanges()
		{

			try
			{
				_user.Invoke("Put",new Object[]{"ntSecurityDescriptor",_securityDescriptor});
				_user.CommitChanges();
			}
			catch(Exception e)
			{
				Console.Write(e);
			}

		
		}

		public  void ApplyPermission(string trustee,
			ADS_ACETYPE_ENUM aceType,
			ADS_RIGHTS_ENUM accessMask,
			ADS_ACEFLAG_ENUM aceFlags,
			ADS_FLAGTYPE_ENUM flag
			)
								
		{
			ApplyPermission(trustee,aceType,accessMask,aceFlags,flag,null,null);


		}

		public void ApplyPermission(string trustee,
					ADS_ACETYPE_ENUM aceType,
					ADS_RIGHTS_ENUM accessMask,
					ADS_ACEFLAG_ENUM aceFlags,
					ADS_FLAGTYPE_ENUM flag,
					DirectoryEntry objectType,
					DirectoryEntry inheritedObject)
								
		{
	
			ActiveDs.AccessControlEntryClass ace = new AccessControlEntryClass();
			ace.AccessMask =(int)accessMask;
			ace.Flags = (int)Enum.Parse(typeof(ActiveDs.ADS_FLAGTYPE_ENUM),Enum.GetName(typeof(ADS_FLAGTYPE_ENUM),flag));
			ace.AceFlags = (int)Enum.Parse(typeof(ActiveDs.ADS_ACEFLAG_ENUM),Enum.GetName(typeof(ADS_ACEFLAG_ENUM),aceFlags));
			ace.AceType = (int)Enum.Parse(typeof(ActiveDs.ADS_ACETYPE_ENUM),Enum.GetName(typeof(ADS_ACETYPE_ENUM),aceType));
		
			ace.Trustee = trustee; 
	
			this._accessControlList.AddAce(ace);
			_securityDescriptor.DiscretionaryAcl = this._accessControlList;
			this.CommitChanges();
		}

		public IEnumerator GetEnumerator()
		{
			return (IEnumerator)new AccessControlListEnumerator(this);
		}
		
		public void Add(AccessControlEntry newTrustee, AccessControlEntry ace)
		{
			_pendingAceList.Add(newTrustee);

		}

		public void Remove(object nativeAce)
		{
			this._accessControlList.RemoveAce(nativeAce as  ActiveDs.IADsAccessControlEntry);
			_securityDescriptor.DiscretionaryAcl = this._accessControlList;
			CommitChanges();
		}

		public int Count
		{
			get
			{
				return _aceList.Count;
			}
		}

		public AccessControlEntry this[int index]
		{
			get
			{
				_index++;
				return (AccessControlEntry)_aceList[_index];
				
			}
		}

		//Private Enumerator for DirectoryEntryAceListEnumerator
		private class AccessControlListEnumerator : IEnumerator
		{
			private AccessControlList __aceList;
			private int __index;

			public AccessControlListEnumerator(AccessControlList aceList)
			{
				__aceList = aceList;
				__index = -1;
			}

			public object Current
			{
				get
				{
					return __aceList[__index];
				}
			}
		
			public void Reset()
			{
				__index = -1;
			}

			public bool MoveNext()
			{
				__index++;
				if((__aceList.Count -1) >= __index )
				{
					return true;
				}
				else
				{
					return false;
				}
			}

			
		}

		/// <summary>
		/// Utility method converts Native GUID
		/// to Octect string
		/// </summary>
		/// <param name="byteArray"></param>
		/// <returns></returns>
		private static string NativeGUIDToOctetString(byte[] byteArray)
		{
			StringBuilder builder = null;
			builder = new StringBuilder(byteArray.Length * 2);
			for(int iCount = 0; iCount < byteArray.Length; iCount++)
			{
				builder.Append(@"\");
				builder.Append(byteArray[iCount].ToString("X2"));

			}
			return builder.ToString();
		}

		private static string NativeGUIDToPath(string GUID)
		{
			//Create GUID
			Guid guid = new Guid(GUID);
			//Get the schema path
			string schemaPath = "LDAP://";
			schemaPath += new DirectoryEntry("LDAP://RootDSE").Properties["schemaNamingContext"].Value.ToString();
			//Create an Schema path object
			DirectoryEntry schemaEntry = new DirectoryEntry(schemaPath);
			//Translate the GUID object to an octet string
			string schemaIDGuid = NativeGUIDToOctetString(guid.ToByteArray());

			//Build a filter
			string filter = "(schemaIDGUID=" + schemaIDGuid + ")";
			//Create a Searcher object
			DirectorySearcher searcher = new DirectorySearcher(schemaEntry);
			searcher.Filter = filter;
			//Get result from search
			SearchResult result = searcher.FindOne();
			//return common name.
			string cn = (string)result.Properties["cn"][0];
			return cn;
		}

	}
	
}
