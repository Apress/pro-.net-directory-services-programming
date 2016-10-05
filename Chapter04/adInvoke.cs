using System;
using ActiveDs;
using System.Collections;
using System.DirectoryServices ;
using System.Runtime.InteropServices;
using System.Reflection; 

public class adInvoke
{
	public static void useingInvoke()
	{   
		DirectoryEntry e = new DirectoryEntry("LDAP://org.apress.com/CN=Mix Char,OU=Staff,OU=Domain Controllers,DC=apress,DC=com");

		Object [] parArray=new Object [2]{"samAccountName", "suchi"};
	      
		e.Invoke("Put",parArray);
		e.Invoke("SetInfo");         
		Console.WriteLine("Changes are made!!"); 
	}
	static void Main(string[] args)
	{
		useingInvoke();
	}
}
