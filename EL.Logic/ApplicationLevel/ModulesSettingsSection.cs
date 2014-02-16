using System.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;

namespace EL.Logic.ApplicationLevel
{
	public sealed class ModulesSettingsSection : SerializableConfigurationSection
	{
		#region Constants

		private const string MODULES_NAME = "modules";
		private const string DEFAULT_MODULE_NAME = "defaultModule";

		#endregion
		#region Properties

		[ConfigurationProperty(MODULES_NAME, IsRequired = true)]
		public NamedElementCollection<PagesSettingsElement> Modules
		{
			get
			{
				return (NamedElementCollection<PagesSettingsElement>)base[MODULES_NAME];
			}
		}

		#endregion
	}

	public sealed class PagesSettingsElement : ModuleSettingsElement
	{
		#region Constants

		private const string MODULES_NAME = "pages";

		#endregion
		#region Properties

		[ConfigurationProperty(MODULES_NAME, IsRequired = true)]
		public NamedElementCollection<ModuleSettingsElement> Pages
		{
			get
			{
				return (NamedElementCollection<ModuleSettingsElement>)base[MODULES_NAME];
			}
		}

		#endregion
	}

	public class ModuleSettingsElement : NamedConfigurationElement
	{
		#region Constants

		private const string SETTINGS_NAME = "settings";

		#endregion
		#region Properties

		[ConfigurationProperty(SETTINGS_NAME, IsRequired = true)]
		public KeyValueConfigurationCollection Settings
		{
			get
			{
				return (KeyValueConfigurationCollection)base[SETTINGS_NAME];
			}
		}

		#endregion
	}
}