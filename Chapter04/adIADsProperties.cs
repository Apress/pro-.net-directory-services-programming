using System;
using ActiveDs;
using System.Collections;
using System.DirectoryServices ;
using System.Runtime.InteropServices;
using System.Reflection; 

public class adIADsProperties
{
	public static void iADsPropPrinting()
	{
		IADs iad;
		DirectoryEntry e = new DirectoryEntry("LDAP://apress"); 
		iad =(IADs) e.NativeObject;

		Console.WriteLine ("Name :" + iad.Name); 
		Console.WriteLine ("Class :" + iad.Class); 
		Console.WriteLine ("GUID :" + iad.GUID); 
		Console.WriteLine ("ADsPath :" + iad.ADsPath); 
		Console.WriteLine ("Parent :" + iad.Parent); 
		Console.WriteLine ("Schema :" + iad.Schema); 
	}

	public static void iADsPropPrinting2()
	{
		IADs iad;
		DirectoryEntry e = new DirectoryEntry("LDAP://apress"); 
		iad =(IADs) e.NativeObject;

		Type t = typeof(IADs);

		PropertyInfo[] props = t.GetProperties();

		foreach (PropertyInfo pi in props)
		{
			try
			{
				string name = pi.GetValue(iad, null).ToString();
				Console.WriteLine(pi.Name + ": " + name);
			}
			catch (Exception exc)
			{
				Console.WriteLine(pi.Name+ ": Value not obtainable");
			}
		}
	}

	static void Main(string[] args)
	{
		iADsPropPrinting();
				Console.WriteLine("--------------------------------------------------");

		iADsPropPrinting2();
	}
}
