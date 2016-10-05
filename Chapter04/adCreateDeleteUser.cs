using System;
using ActiveDs;
using System.DirectoryServices ;

class adCreateDeleteUser
{
   
	public static void IADsContainer_CreateDeleteUser()
	{
		IADsContainer cont;    
		IADsUser usr;

		DirectoryEntry e = new DirectoryEntry(
			"LDAP://org.apress.com/OU=Editor,OU=Technical,OU=Staff," +
			"OU=Domain Controllers,DC=apress,DC=com"); 
		cont=(IADsContainer)e.NativeObject;
		usr=(IADsUser)cont.Create("user","CN=James Cook");
		usr.Put ("sAMAccountName", "jcook");
		usr.SetInfo ();
		Console.WriteLine ("Press any key to delete newly created object");
		Console.ReadLine(); 
		cont.Delete("user","CN=James Cook");
	}

	static void Main(string[] args)
	{
		IADsContainer_CreateDeleteUser();
	}
}
