using System;
using ActiveDs;
using System.DirectoryServices ;

class adSchema
{
   static void Main(string[] args)
   {
      
      DirectoryEntry e = new DirectoryEntry(
            "IIS://localhost/Logging/Custom Logging/Extended Properties");

      IADs iad = (IADs)e.NativeObject;

      e.Path = iad.Schema;
      e.RefreshCache();

      IADsClass iac = (IADsClass)e.NativeObject;

      Console.WriteLine("MANDATORY PROPERTIES");

      Array mandatoryProps = (Array)iac.MandatoryProperties;

      foreach (object o in mandatoryProps)
      {
         Console.WriteLine(o);
      }

      Console.WriteLine("OPTIONAL PROPERTIES");

      Array optionalProps = (Array)iac.OptionalProperties;
      foreach (object o in optionalProps)
      {
         Console.WriteLine(o);
      }
   }
}
