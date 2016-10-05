using System;
using System.DirectoryServices;
public class dirgetpropertiesFromSearchedResult
{
	public static void getpropertiesFromSearchedResult()
	{
		//Create DirectoryEntry object
		DirectoryEntry ent = new DirectoryEntry("LDAP://apress");
      
		//Create DirectorySearcher by specifying filter criteria
		DirectorySearcher searcher = new DirectorySearcher 
			(ent,"(givenname=Douglas)");   

		//retrieve the search result
		SearchResult searchResult = searcher.FindOne();      
		//get the properties in collection
		ResultPropertyCollection searchResultPropColl = searchResult.Properties;

		//populate collection
		foreach( string prop in searchResultPropColl.PropertyNames)
		{
			foreach( Object coll in searchResultPropColl[prop])
			{
				Console.WriteLine(prop + "--" + coll);
			}
		}
	}
	static void Main(string[] args)
	{
		getpropertiesFromSearchedResult();
	}
}
