using System.Collections.Generic;
using Telerik.OpenAccess.Metadata;
using Telerik.Sitefinity.Model;
using Telerik.Sitefinity.Modules.GenericContent.Data;

namespace Sitefinity.ExternalDataModel
{
    public class ExternalEntryMetaDataSource : ContentBaseMetadataSource
    {
        private IList<IOpenAccessFluentMapping> sitefinityMappings;

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
            this.sitefinityMappings = mappings;
            return mappings;
        }

        protected override MetadataContainer CreateModel()
        {
            var model = base.CreateModel();

            foreach (var m in this.sitefinityMappings)
                m.ModifyModel(model);

            return model;
        } 
    }
}
