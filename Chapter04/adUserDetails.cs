using System;
using ActiveDs;
using System.DirectoryServices ;

class adUserDetails
{
   
	public static void getUserDetails()
	{    
		IADsUser objUser;          
		DirectoryEntry e = new DirectoryEntry("LDAP://org.apress.com/" +
			"CN=Jeff Crouch,OU=Reviewer,OU=Technical,OU=Staff," +
			"OU=Domain Controllers,DC=apress,DC=com"); 
		objUser =( IADsUser)e.NativeObject;
		Console.WriteLine (objUser.Get ("EmailAddress").ToString()) ;
		Console.WriteLine (objUser.Get ("HomePage").ToString()) ;
	}

	static void Main(string[] args)
	{
		getUserDetails();
	}
}
