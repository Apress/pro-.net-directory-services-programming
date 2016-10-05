using System;
using System.DirectoryServices;
public class dirSorting
{
	public static void SortResults()
	{
		DirectoryEntry root = new DirectoryEntry("LDAP://apress");
		DirectorySearcher searcher=new DirectorySearcher(root);

		searcher.Filter = "(mail=*)"; 
			
		searcher.PropertiesToLoad.Add("name");
		searcher.PropertiesToLoad.Add("mail");
		searcher.PropertiesToLoad.Add("co"); 
			
		SortOption sorter = new SortOption();
		
		//need to set properties to sort accordingly
		sorter.PropertyName = "name";
		sorter.Direction = SortDirection.Ascending ;
		searcher.Sort = sorter;
		//use SearchAndPopulateResult() method from dirFindAllSearchAndPopulate.cs
		SearchAndPopulateResult(searcher);			
	}
	static void Main(string[] args)
	{
		SortResults();
	}
}
