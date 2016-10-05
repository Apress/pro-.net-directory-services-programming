using System;
using System.Collections;
namespace Wrox.DirectoryServices.Securiy
{				
	public class AccessControlEntry
	{
		
		private string _trustee;
		private  string[] _aceType;
		private  string[] _accessMask;
		private  string[] _aceFlags;
		private  string[] _flags;
		private string _objectType = null;
		private string _inheritedObject = null;

		private object _nativeAce = null;


		public AccessControlEntry( string trustee,
									string[] aceType,
									string[] accessMask,
									string[] aceFlags,
									string[] flags,
									string objectType,
									string inheritedObject,
									object ace)
		{
			
			_flags = flags;
			_aceType = aceType;
			_accessMask = accessMask;
			if(!(aceFlags.Length == 1))
				_aceFlags = aceFlags;
			
					
			_trustee = trustee;

			if(inheritedObject != null)
			{
				_inheritedObject = inheritedObject;
			}

			if(objectType != null)
			{
				_objectType = objectType;
			}
		
			_nativeAce = ace;
		}

		
		public AccessControlEntry(string trustee)
		{
			_trustee = trustee;

		}

		public void AddRights(ADS_RIGHTS_ENUM enumValue)
		{
			ArrayList temp = new ArrayList();
			foreach(string s in this._accessMask)
				temp.Add(s);
			
			temp.Add(Enum.GetName(typeof(ADS_RIGHTS_ENUM),enumValue));
			this._accessMask = (string[])temp.ToArray(typeof(string));

		}

		public object  NativeAce
		{
			get
			{
				return _nativeAce;
			}
		}
		
	
		public string[]  AceFlags
		{
			get
			{
				return _aceFlags;
			}
		}

		public string ObjectType
		{
			get
			{
				return _objectType;
			}
			set
			{
				_objectType = value;
			}

		}

		public string InheritedObject
		{
			get
			{
				return _inheritedObject;
			}
			set
			{
				_inheritedObject = value;
			}
		}
		
		public string Trustee
		{
			get
			{
				return _trustee;
			}
			set
			{
				_trustee = value;
			}
		}

		public string[]  AceType
		{
			get
			{
				return _aceType;
			}
		}

		public string[]  AccessMask
		{
			get
			{
				return _accessMask;
			}
		}


		public static string GetFriendlyName(string enumName)
		{
			string enumType = enumName.Split('_').GetValue(1).ToString();

			switch(enumType)
			{
				case "RIGHT":
					return GetFriendlyAccessMask(enumName);
				
				case "ACEFLAG":
					return GetFriendlyAceFlag(enumName);

				case "FLAG":
					return GetFriendlyFlag(enumName);

				case "ACETYPE":
					return GetFriendlyAceType(enumName);

			}
			return string.Empty;
		}


		private static string GetFriendlyAceFlag(string enumName)
		{
			switch(enumName)
			{
				case "ADS_ACEFLAG_INHERIT_ACE":
					return "This object and all child objects";

				case "ADS_ACEFLAG_NO_PROPAGATE_INHERIT_ACE":
					return "This object only";
 
				case "ADS_ACEFLAG_INHERIT_ONLY_ACE":
					return "Inherite only";
				
				case "ADS_ACEFLAG_INHERITED_ACE":
					return "Inherited";

				case "ADS_ACEFLAG_VALID_INHERIT_FLAGS":
					return "Valid";

				case "ADS_ACEFLAG_SUCCESSFUL_ACCESS":
					return "Audit Sucess";
				
				case "ADS_ACEFLAG_FAILED_ACCESS":
					return "Audit Failed";
				
			}
			return string.Empty;
		}

		

		private static string GetFriendlyFlag(string enumName)
		{
			switch(enumName)
			{
				case "ADS_FLAG_OBJECT_TYPE_PRESENT":
					return "Allow";

				case " ADS_FLAG_INHERITED_OBJECT_TYPE_PRESENT":
					return "Deny";
			}
			return string.Empty;
		}


		private static string GetFriendlyAceType(string enumName)
		{
			switch(enumName)
			{
				case "ADS_ACETYPE_ACCESS_ALLOWED":
					return "Allow";

				case "ADS_ACETYPE_ACCESS_DENIED":
					return "Deny";
 
				case "ADS_ACETYPE_SYSTEM_AUDIT":
					return "Audit";
				
				case "ADS_ACETYPE_ACCESS_ALLOWED_OBJECT":
					return "Allow Object";

				case "ADS_ACETYPE_ACCESS_DENIED_OBJECT":
					return "Deny Object";
				
				case "ADS_ACETYPE_SYSTEM_AUDIT_OBJECT":
					return "Audit Object";
				
					//Not used.
				case "ADS_ACETYPE_SYSTEM_ALARM_OBJECT":
					return string.Empty;
			}
			return string.Empty;

		}

		private static string GetFriendlyAccessMask(string enumName)
		{
			switch(enumName)
			{
				case "ADS_RIGHT_DS_CREATE_CHILD":
					return "Delete Child";
					

				case "ADS_RIGHT_DS_DELETE_CHILD":
					return "Delete Child Objects";
					
				
				case "ADS_RIGHT_ACTRL_DS_LIST": 
					return "List Child Objects";
					

				case "ADS_RIGHT_DS_SELF":
					return "Self";
					
				
				case "ADS_RIGHT_DS_READ_PROP":
					return "Read Property";
					

				case "ADS_RIGHT_DS_WRITE_PROP": 
					return "Write Property";
					break;

				case "ADS_RIGHT_DS_DELETE_TREE":
					return "Delete Tree";
					

				case "ADS_RIGHT_DS_LIST_OBJECT":
					return "List Objects";
					

				case "ADS_RIGHT_DS_CONTROL_ACCESS": 
					return "Read Permission";
					

				case "ADS_RIGHT_DELETE": 
					return "Delete";
					

				case "ADS_RIGHT_READ_CONTROL": 
					return  "Extended Rights";
					

				case "ADS_RIGHT_WRITE_DAC":
					return "Modify Permissions";
					

				case "ADS_RIGHT_WRITE_OWNER":
					return "Modify Owner";
					

				case "ADS_RIGHT_SYNCHRONIZE": 
					return "Syncronize";
					
				
				case "ADS_RIGHT_ACCESS_SYSTEM_SECURITY":
					return "ddd";
					

				case "ADS_RIGHT_GENERIC_ALL":
					return "Read, Write";
					
					
				case "ADS_RIGHT_GENERIC_EXECUTE":
					return "Execute";
					
                
				case "ADS_RIGHT_GENERIC_WRITE":
					return "Write";
					
	
				case "ADS_RIGHT_GENERIC_READ": 
					return "Read";
					
			}
			return string.Empty;
		}


	}

	public class AccessControlEntries : CollectionBase
	{

		public void Add(AccessControlEntry accessControlEntry)
		{
			List.Add(accessControlEntry);

		}

		public void Remove(AccessControlEntry accessControlEntry)
		{
			List.Remove(accessControlEntry);

		}

		public AccessControlEntry this[int index]
		{
			get
			{
				return (AccessControlEntry)List[index];
			}


		}

	}


}
