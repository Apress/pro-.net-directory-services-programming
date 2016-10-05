using System;

namespace WindowsApplication1
{
	/// <summary>
	/// Class definition of TreeNodeInfo
	/// Helper class for storing values from 
	/// a direcotry entry in the TreeNode's Tag property.
	/// </summary>
	class TreeNodeInfo
	{
		private bool _isLoaded;
		private string _ldapPath;
		
		public TreeNodeInfo(string Path, bool isLoaded)
		{
			_ldapPath = Path;
			_isLoaded = isLoaded;
		}

		public string Path
		{
			get
			{
				return _ldapPath;
			}
		}
		public bool IsLoaded
		{
			get
			{
				return _isLoaded;
			}
			set
			{
				_isLoaded = value;
			}
		}
	}
}
