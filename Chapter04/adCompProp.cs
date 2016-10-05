using System;
using ActiveDs;
using System.DirectoryServices ;

class adCompProp
{
   
	public static void getCompProp()
	{
		IADsComputer cp;
		DirectoryEntry e = new DirectoryEntry("WinNT://ORG"); 
		cp =(IADsComputer)e.NativeObject;
   
		Console.WriteLine ("Name :" + cp.Name); 
		Console.WriteLine ("Class :" + cp.Class); 
		Console.WriteLine ("GUID :" + cp.GUID); 
		Console.WriteLine ("ADsPath :" + cp.ADsPath); 
		Console.WriteLine ("Parent :" + cp.Parent); 
		Console.WriteLine ("Schema :" + cp.Schema); 
		Console.WriteLine ("Owner :" + cp.Owner); 
		Console.WriteLine ("Division :" + cp.Division); 
		Console.WriteLine ("OperatingSystem :" + cp.OperatingSystem); 
		Console.WriteLine ("OperatingSystemVersion :" + cp.OperatingSystemVersion); 
		Console.WriteLine ("Processor :" + cp.Processor); 
		Console.WriteLine ("ProcessorCount :" + cp.ProcessorCount);
	}


	static void Main(string[] args)
	{
		getCompProp();
	}
}
