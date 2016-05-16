using Telerik.Sitefinity.Data;
using Telerik.Sitefinity.Modules.GenericContent.Configuration;

namespace Sitefinity.ExternalDataModel
{
    public class ExternalEntryManager : ManagerBase<ExternalEntryProvider>
    {
        public ExternalEntryManager()
            : this(null)
        {
        }

        public ExternalEntryManager(string providerName)
            : base(providerName)
        {
        }

        public static ExternalEntryManager GetManager()
        {
            return ManagerBase<ExternalEntryProvider>.GetManager<ExternalEntryManager>();
        }

        public static ExternalEntryManager GetManager(string providerName)
        {
            return ManagerBase<ExternalEntryProvider>.GetManager<ExternalEntryManager>(providerName);
        }

        protected override GetDefaultProvider DefaultProviderDelegate
        {
            get
            {
                return () => ExternalEntryProvider.DefaultProvider;
            }
        }

        public override string ModuleName
        {
            get { return ExternalEntryManager.DefaultModuleName; }
        }

        protected override Telerik.Sitefinity.Configuration.ConfigElementDictionary<string, Telerik.Sitefinity.Configuration.DataProviderSettings> ProvidersSettings
        {
            get
            {
                return new ExternalEntriesConfig().Providers;
            }
        }

        public static string DefaultModuleName = "ExternalEntries";
    }

    public class ExternalEntriesConfig : ModuleConfigBase
    {
        protected override void InitializeDefaultProviders(Telerik.Sitefinity.Configuration.ConfigElementDictionary<string, Telerik.Sitefinity.Configuration.DataProviderSettings> providers)
        {
            providers.Add(new Telerik.Sitefinity.Configuration.DataProviderSettings(providers)
            {
                Name = ExternalEntryProvider.DefaultProvider,
                Title = string.Format("Default {0}", ExternalEntryManager.DefaultModuleName),
                ProviderType = typeof(ExternalEntryProvider),
                Parameters = new System.Collections.Specialized.NameValueCollection() { { "applicationName", ExternalEntryProvider.DefaultApplicationName } }
            });
        }
    }
}
