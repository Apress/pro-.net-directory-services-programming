using System;
using ActiveDs;
using System.DirectoryServices ;
using System.Runtime.InteropServices;
using System.Reflection; 

public class adGetPut
{
	public static void IADs_Get_Put()
	{
		IADs ia;      
		DirectoryEntry e = new DirectoryEntry("LDAP://org.apress.com/" +
			"CN=Jeff Crouch,OU=Reviewer,OU=Technical," +
			"OU=Staff,OU=Domain Controllers,DC=apress,DC=com"); 

		ia =(IADs) e.NativeObject;    																																													//Get   Method thatwhich returns multiple values
																		Array oA= (Array)ia.Get("OtherHomePhone") ;

		foreach (object hP in oA )  
		{
			Console.WriteLine(hP);
		}

		//Get   Method which that returns single value
		Console.WriteLine("Old Home Page : " + ia.Get("wWWhomePage").ToString ());

		
		//Put
		ia.Put ("wWWhomepage","www.apress.com\\crouch");
		Console.WriteLine("New Home Page : " + ia.Get("wWWhomePage").ToString ());
   
		//Commit the result
		ia.SetInfo ();
	}

	static void Main(string[] args)
	{
		IADs_Get_Put();
	}
}
