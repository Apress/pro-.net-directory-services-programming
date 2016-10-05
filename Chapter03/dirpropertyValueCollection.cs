using System;
using System.DirectoryServices;
public class dirpropertyValueCollection
{
	public static void propertyValueCollection()
	{
		//Create DirectoryEntry object
		DirectoryEntry ent = new DirectoryEntry("LDAP://apress");
  
		//Create DirectorySearcher by specifying filter criteria
		DirectorySearcher dirSearcher = new DirectorySearcher (ent,"(name=Doug*)");

		//retrieve the search result
		SearchResult searchResult = dirSearcher.FindOne();   
   
		//get the value in ResultPropertyValueCollection
		ResultPropertyValueCollection searchResultPropColl1=
			searchResult.Properties["sn"];
   
		//print value
		Console.WriteLine(searchResultPropColl1[0].ToString());
	}

	static void Main(string[] args)
	{
		propertyValueCollection();
	}
}
