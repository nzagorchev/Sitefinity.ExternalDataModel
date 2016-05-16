using System.Collections.Generic;
using Telerik.OpenAccess.Metadata;
using Telerik.OpenAccess.Metadata.Fluent;
using Telerik.Sitefinity;
using Telerik.Sitefinity.Model;

namespace Sitefinity.ExternalDataModel
{
    internal class ExternalEntryFluentMapping : OpenAccessFluentMappingBase
    {
        public ExternalEntryFluentMapping(IDatabaseMappingContext context)
            : base(context)
        {
        }

        public override IList<Telerik.OpenAccess.Metadata.Fluent.MappingConfiguration> GetMapping()
        {
            var mappings = new List<MappingConfiguration>();
            this.MapExternalType(mappings);
            return mappings;
        }

        private void MapExternalType(IList<MappingConfiguration> mappings)
        {
            var externalTypeMapping = new MappingConfiguration<ExternalEntry>();
            externalTypeMapping.MapType(x => new { }).SetTableName("sf_external_entry", this.Context);
            externalTypeMapping.HasProperty(x => x.Id).HasFieldName("id").IsIdentity().IsNotNullable();
            externalTypeMapping.HasProperty(x => x.LastModified).ToColumn("last_modified").IsCalculatedOn(Telerik.OpenAccess.Metadata.DateTimeAutosetMode.InsertAndUpdate).IsNullable();
            externalTypeMapping.HasProperty(x => x.ApplicationName).HasFieldName("appName").ToColumn("app_name").HasLength(50).IsNullable();
            externalTypeMapping.HasProperty(x => x.Title).IsNullable();
            externalTypeMapping.HasProperty(x => x.DateCreated).ToColumn("date_created").IsNullable();

            mappings.Add(externalTypeMapping);
        }
    }
}
