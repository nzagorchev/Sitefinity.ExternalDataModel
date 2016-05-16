﻿using System;
using System.Linq;
using Telerik.OpenAccess.Metadata;
using Telerik.Sitefinity.Data;
using Telerik.Sitefinity.Data.Linq;
using Telerik.Sitefinity.Data.OA;
using Telerik.Sitefinity.Model;

namespace Sitefinity.ExternalDataModel
{
    public class ExternalEntryProvider : DataProviderBase, IOpenAccessDataProvider, IOpenAccessUpgradableProvider
    {
        public ExternalEntry CreateExternalEntry()
        {
            return this.CreateExternalEntry(this.GetNewGuid());
        }

        public ExternalEntry CreateExternalEntry(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("Id cannot be an Empty Guid");

            var item = new ExternalEntry(this.ApplicationName, id);
            ((IDataItem)item).Provider = this;
            this.GetContext().Add(item);
            return item;
        }

        public ExternalEntry GetExternalEntry(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("Id cannot be an Empty Guid");

            var item = this.GetContext().GetItemById<ExternalEntry>(id.ToString());
            ((IDataItem)item).Provider = this;
            return item;
        }

        public IQueryable<ExternalEntry> GetExternalEntries()
        {
            var appName = this.ApplicationName;
            var query = from c in SitefinityQuery.Get<ExternalEntry>(this)
                        where c.ApplicationName == appName
                        select c;
            return query;
        }

        public void Delete(ExternalEntry item)
        {
            this.GetContext().Remove(item);
        }

        public void Delete(Guid id)
        {
            ExternalEntry item = this.GetExternalEntry(id);
            this.GetContext().Remove(item);
        }

        public string ProviderName
        {
            get { return _providerName; }
            set { _providerName = value; }
        }

        private ManagerInfo ManagerInfo
        {
            get
            {
                return _managerInfo ?? (_managerInfo = new ManagerInfo()
                {
                    ProviderName = this.ProviderName,
                    ManagerType = typeof(ExternalEntryManager).Name,
                    ApplicationName = this.ApplicationName
                });
            }
        }

        #region Overridden
        public override string ApplicationName
        {
            get
            {
                return "/ExternalEntryProvider";
            }
        }
        #endregion

        #region DataProviderBase
        public override Type[] GetKnownTypes()
        {
            if (ExternalEntryProvider.knownTypes == null)
            {
                ExternalEntryProvider.knownTypes = new Type[]
                {
                    typeof(ExternalEntry)
                };
            }

            return ExternalEntryProvider.knownTypes;
        }

        public override string RootKey
        {
            get { return "ExternalEntryDataProvider"; }
        }

        MetadataSource IOpenAccessMetadataProvider.GetMetaDataSource(IDatabaseMappingContext context)
        {
            return new ExternalEntryMetaDataSource(context);
        }
        #endregion

        #region IOpenAccessDataProvider
        public OpenAccessProviderContext Context
        {
            get;
            set;
        }
        #endregion

        private static Type[] knownTypes;
        private ManagerInfo _managerInfo;
        private string _providerName = "ExternalEntryProvider";
        // TODO: refactor these static strings
        public static string DefaultProvider = "ExternalEntryProvider";
        public static string DefaultApplicationName = "ExternalEntryProvider";

        public int CurrentSchemaVersionNumber
        {
            get 
            { 
                return 2;
            }
        }

        public void OnUpgraded(UpgradingContext context, int upgradedFromSchemaVersionNumber)
        {
        }

        public void OnUpgrading(UpgradingContext context, int upgradingFromSchemaVersionNumber)
        {
        }
    }
}
