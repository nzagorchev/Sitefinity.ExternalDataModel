using System.Collections.Generic;
using Telerik.Sitefinity.Model;
using Telerik.Sitefinity.Modules.GenericContent.Data;

namespace Sitefinity.ExternalDataModel
{
    public class ExternalEntryMetaDataSource : ContentBaseMetadataSource
    {
        public ExternalEntryMetaDataSource()
            : base(null)
        {
        }

        public ExternalEntryMetaDataSource(IDatabaseMappingContext context)
            : base(context)
        {
        }

        protected override IList<IOpenAccessFluentMapping> BuildCustomMappings()
        {
            var mappings = base.BuildCustomMappings();
            mappings.Add(new ExternalEntryFluentMapping(this.Context));
            return mappings;
        }
    }
}
