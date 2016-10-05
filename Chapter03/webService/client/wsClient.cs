using System;
using System.DirectoryServices;
public class dirFindOne
{
	public static void findOne()
	{	
		DirectoryEntry root = new DirectoryEntry("LDAP://org.apress.com/OU=Reviewer, OU=Technical,OU=Staff,OU=Domain Controllers,DC=apress,DC=com");        
		DirectorySearcher searcher=new DirectorySearcher(root);

		searcher.Filter = "(cn=*)"; 

		searcher.PropertiesToLoad.Add("name");
		searcher.PropertiesToLoad.Add("telephonenumber");
		searcher.PropertiesToLoad.Add("co");

		SearchResult resEnt = searcher.FindOne();

		ResultPropertyCollection myResultPropColl;
		myResultPropColl = resEnt.Properties;
   
		// Process properties of the retrieved object	
		foreach( string myKey in myResultPropColl.PropertyNames)
		{		
			foreach( Object myCollection in myResultPropColl[myKey])
			{
				Console.WriteLine(myKey + " = " + myCollection);
			}
		}
	}
	public static void main()
	{
		findOne();
	}
}