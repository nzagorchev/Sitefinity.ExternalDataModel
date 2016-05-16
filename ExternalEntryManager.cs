using Telerik.Sitefinity.Data;

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
                return () => ExternalEntryManager.DefaultProvider;
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

        public static readonly string DefaultModuleName = "ExternalEntries";
        public static readonly string DefaultProvider = "ExternalEntryProvider";
    }
}
