using System;
using System.DirectoryServices;
public class dirFindAllSearchAndPopulate
{
	public static void SearchAndPopulateResult  (DirectorySearcher searcher)
	{
		foreach(SearchResult resEnt in searcher.FindAll())
		{	
			searcher.PageSize =2; 
			foreach (string pN in resEnt.Properties.PropertyNames)
			{					
				foreach (object val in resEnt.Properties[pN]) 
				{
					Console.WriteLine(pN + " = " + val );
				}				
			}
			Console.WriteLine("");
			DirectoryEntry e ;
				
		}
	}
	static void Main(string[] args)
	{
			DirectoryEntry root = new DirectoryEntry("GC://DC=org,DC=apress,DC=com");
			DirectorySearcher searcher=new DirectorySearcher(root);
			SearchAndPopulateResult (searcher);			
	}
}
