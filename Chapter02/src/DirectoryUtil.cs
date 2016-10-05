using System;
using System.DirectoryServices;
using System.Collections;
using System.Text;
using System.Windows.Forms;

namespace WindowsApplication1
{
	/// <summary>
	/// Summary description for DirectoryBrowserUtil.
	/// </summary>
	/// 
	public delegate void DirectoryUtilEventHandler(object sender, string path);
	public class DirectoryUtil
	{
		
		/// Instance of this class!!!
		private static DirectoryUtil _direcoryUtil;
		//Top of the directory to be handled globally.
		private static DirectoryEntry _rootContainer;
		//Shared instance
		private static DirectoryEntry _sharedDirectorEntry;
		//Path for loading directory.
		private string _path = null;
		private static object _lockObject = "For locking";
		//Event for binding notification
		public event DirectoryUtilEventHandler OnBind;
		private string _username;
		private string _password;
		private bool _isAuthenticated = false;
		/// <summary>
		/// inicialization for all
		/// necessary private members.
		/// </summary>
		private DirectoryUtil()
		{

			//bind to the rootDSE {DirectoryEntry("LDAP://rootDSE");}
			_rootContainer = new DirectoryEntry();
			//Instantiate shared instance
			_sharedDirectorEntry = new DirectoryEntry();
			Bind();
		}

		/// <summary>
		/// Refreshes bindings to current Path 
		/// </summary>
		public void Bind()
		{
			//Bind root container.
			RefreshDirectoryStructure();	

		}

		/// <summary>
		/// Public Shared DirectoryEntry
		/// Mainly used for representing
		/// Real DirectoryEntries in TreeNodes
		/// </summary>
		public DirectoryEntry SharedEntry
		{
			get
			{
				return _sharedDirectorEntry;
			}

		}

		/// <summary>
		/// Represents the top of the 
		/// Directory root, it mirrors the 
		/// first TreeNode in the TreeView
		/// </summary>
		public DirectoryEntry RootContainer
		{
			get
			{
				return _rootContainer;
			}
		}

		/// <summary>
		/// Allows callers to change and
		/// get the current path that binds
		/// the rootContainer DirectoryEntry
		/// </summary>
		public string Path
		{
			get
			{
				return _path;
			}
			set
			{
				_path = value;
				RefreshDirectoryStructure();	
			}
			
		}

		/// <summary>
		/// Returns a new instance or an
		/// existing on of this class instance 
		/// back to the callers.
		/// </summary>
		public static DirectoryUtil Instance
		{
			get
			{
				lock(_lockObject)
				{
					if(_direcoryUtil == null)
						_direcoryUtil = new DirectoryUtil();
				}
				return _direcoryUtil;
			}
		}

		public  bool Authenticate(string username, string password)
		{
			
			if(_path == null)
			{  
				_path = "LDAP://";
				_path += new DirectoryEntry("LDAP://rootDSE").Properties["defaultNamingContext"].Value.ToString();
			}
			try
			{
				DirectoryEntry entry = new DirectoryEntry(_path,username,password,
					AuthenticationTypes.Secure | 
					AuthenticationTypes.Sealing |  
					AuthenticationTypes.Signing);
				entry.RefreshCache();
				_password = password;
				_username = username;
				RefreshDirectoryStructure();
				_isAuthenticated = true;
				return true;
			}
			catch(UnauthorizedAccessException e)
			{

				throw new Exception(e.Message);
			}
			return false;

		}

		/// <summary>
		/// Re-Binds the _rootContainer DirectoryEntry
		/// to the current _path value
		/// </summary>
		private void RefreshDirectoryStructure()
		{
			try
			{
				_rootContainer.Path =_path;
				_rootContainer.Username = _username;
				_rootContainer.Password = _password;
				_rootContainer.AuthenticationType = AuthenticationTypes.Secure | 
													AuthenticationTypes.Sealing |  
													AuthenticationTypes.Signing ;
				_rootContainer.RefreshCache();

				_sharedDirectorEntry.Path =_path;
				_sharedDirectorEntry.Username = _username;
				_sharedDirectorEntry.Password = _password;
				_sharedDirectorEntry.AuthenticationType = AuthenticationTypes.Secure |
														  AuthenticationTypes.Sealing |  
														  AuthenticationTypes.Signing;
				_sharedDirectorEntry.RefreshCache();

				if(OnBind != null)
					OnBind(this,_path);
			}
			catch(Exception e)
			{
				throw new Exception(e.Message);
			}

		}
	}
}
