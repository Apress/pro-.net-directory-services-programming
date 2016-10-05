using System;
using ActiveDs;
using System.DirectoryServices ;
using System.Runtime.InteropServices;
using System.Reflection; 

public class adGetExPutEx
{
	public static void putEx_getEx()
	{
		IADs ia;      
		DirectoryEntry e = new DirectoryEntry("LDAP://org.apress.com/CN=Jeff Crouch,"+ 
			"OU=Reviewer,OU=Technical,OU=Staff,OU=Domain Controllers,DC=apress,DC=com"); 
		ia =(IADs) e.NativeObject; 
   
		//Get the old numbers
		Console.WriteLine("Printing old numbers"); 
		Array oPh= (Array)ia.GetEx("OtherHomePhone") ;
		foreach ( Object pH in oPh )  
		{
			Console.WriteLine(pH);
		}
																																																		Console.WriteLine("Updating new numbers"); 

		//new numbers
		Object[] obArray = new Object[3] {280212,220520,5433318};     
    
		//update the numbers
		ia.PutEx(ADS_PROPERTY_OPERATION_ENUM.ADS_PROPERTY_UPDATE,
			"OtherHomePhone",obArray);         
		ia.SetInfo(); 
   
		Console.WriteLine("Printing changed numbers...."); 

		oPh= (Array)ia.GetEx("OtherHomePhone");

		foreach ( object phone in oPh )  
		{
			Console.WriteLine(phone);
		}
	}

	static void Main(string[] args)
	{
		putEx_getEx();
	}
}
