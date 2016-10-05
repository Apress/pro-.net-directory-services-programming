using System;
using System.Data.OleDb ;

public class ADODB_LDAP
{
	
	public static void ADODBSearch ()
	{			
		//create connecion object 
		OleDbConnection con = new OleDbConnection("Provider=ADsDSOObject");
	
		//create SQL
		string sql= "select name, company, telephonenumber " + 
			"from 'LDAP://apress' where Company <>'apress' and givenname= '*'" +
			"order by name ASC";

		//create command object using SQL and connection and open
		OleDbCommand cmd = new OleDbCommand(sql ,con);				
		con.Open ();
		//create datareader and get the data
		OleDbDataReader adReader;
		adReader = cmd.ExecuteReader();	

		//populate result
		while(adReader.Read()) 
		{
			Console.WriteLine("Name = " + 
				adReader.GetValue(adReader.GetOrdinal("name")));
			Console.WriteLine("Company = " + 
				adReader.GetValue(adReader.GetOrdinal("company")));
			Console.WriteLine("Telephone = " + 
				adReader.GetValue(adReader.GetOrdinal("telephonenumber")));
			Console.WriteLine("");
		}
		//close objects
		adReader.Close();
		con.Close ();
	}
	static void Main(string[] args)
	{
		ADODBSearch();
	}
      
}
