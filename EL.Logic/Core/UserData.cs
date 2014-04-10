using System;
using System.Collections.Generic;

namespace EL.Logic.Core
{
	public class UserData
	{
		/// <summary>
		/// User identifier of local server
		/// according to Domain/UserName
		/// </summary>
		public Int32 UserId;

		/// <summary>
		/// User domain
		/// </summary>
		public string Domain;

		/// <summary>
		/// User login in Domain
		/// </summary>
		public string UserName;

		/// <summary>
		/// Server identifier on local server
		/// </summary>
		public Int32 ServerId;

		/// <summary>
		/// Return in what context handler is called
		/// </summary>
		//public Destination Destination;

		/// <summary>
		/// Prefix to main handler
		/// </summary>
		//[XmlElement(Names.Query.Prefix)]
		public String Prefix;

		/// <summary>
		/// ProductId from UserInfo
		/// </summary>
		public int ProductId;

		/// <summary>
		/// User security identifier
		/// </summary>
		//[XmlElement(Names.Query.Prefix)]
		public String UserSecId;

		/// <summary>
		/// Connected user version
		/// </summary>
		public Int32 RemoteVersion;

		/// <summary>
		/// User license languages
		/// CrossLanguageDescriptor.Language contains list of licensed languages
		/// </summary>
		private List<CrossLanguageDescriptor> _licenseLanguages;

		//[XmlElement(Names.Query.LicenseLanguages)]
		public List<CrossLanguageDescriptor> LicenseLanguages
		{
			get { return _licenseLanguages; }
			set { _licenseLanguages = value; }
		}

		public bool ContainsLicenseLanguage(int language)
		{
			if (_licenseLanguages == null)
				return false;

			foreach (CrossLanguageDescriptor _descr in _licenseLanguages)
				if (_descr.Language == language)
					return true;

			return false;

		}

		public List<int> GetCrossLanguages(int language)
		{
			List<int> _crlist = new List<int>();

			if (_licenseLanguages == null)
				throw new ApplicationException("LicenseLanguages == null");

			foreach (CrossLanguageDescriptor _descr in _licenseLanguages)
				if (_descr.Language == language)
				{
					_crlist.AddRange(_descr.CrossLanguages);
					return _crlist;
				}

			throw new ApplicationException("no specified language in LicenseLanguages");
		}

		public void SetLicenseLanguages(Dictionary<int, List<int>> licenseLanguages)
		{
			if (licenseLanguages == null)
				throw new ApplicationException("null input value");

			if (_licenseLanguages == null)
				_licenseLanguages = new List<CrossLanguageDescriptor>();
			else
				_licenseLanguages.Clear();

			foreach (KeyValuePair<int, List<int>> pair in licenseLanguages)
			{
				var _descr = new CrossLanguageDescriptor();
				_descr.CrossLanguages = new List<int>(pair.Value);
				_descr.Language = pair.Key;
				_licenseLanguages.Add(_descr);
			}
		}



		/// <summary>
		/// Create copy of object:
		/// 'full' is true (not supported now): full copy
		/// 'full' is false: create only object's copy, inner fields will be presented as references
		/// </summary>
		public UserData Copy(bool full)
		{
			UserData copy = new UserData();
			Copy(copy, full);

			return copy;
		}

		protected void Copy(UserData obj, bool full)
		{
			obj.UserId = UserId;
			obj.ServerId = ServerId;
			obj.UserSecId = UserSecId;
			obj.RemoteVersion = RemoteVersion;
			obj.Prefix = Prefix;
			obj.ProductId = ProductId;

			if (full)
			{
				// Deep copy
				obj.Domain = String.Copy(Domain);
				obj.UserName = String.Copy(UserName);
				obj.LicenseLanguages = new List<CrossLanguageDescriptor>(LicenseLanguages);
			}
			else
			{
				// Copy references
				obj.Domain = Domain;
				obj.UserName = UserName;
				obj._licenseLanguages = _licenseLanguages;
			}
		}
	}

	public class CrossLanguageDescriptor
	{
		/// <summary>
		/// Initial language
		/// </summary>
		//[XmlElement(Names.Query.Language)]
		public int Language;

		/// <summary>
		/// List of cross languages for initial language
		/// </summary>
		//[XmlElement(Names.Query.CrossLanguages)]
		public List<int> CrossLanguages;
	}
}
