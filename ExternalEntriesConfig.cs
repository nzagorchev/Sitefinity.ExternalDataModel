using Telerik.Sitefinity.Modules.GenericContent.Configuration;

namespace Sitefinity.ExternalDataModel
{
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
