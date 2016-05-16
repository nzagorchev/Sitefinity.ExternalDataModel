using System;
using Telerik.Sitefinity.Model;

namespace Sitefinity.ExternalDataModel
{
    public class ExternalEntry : IDataItem
    {
        public Guid Id
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }

        public object Transaction
        {
            get
            {
                return this.transaction;
            }
            set
            {
                this.transaction = value;
            }
        }

        public object Provider
        {
            get
            {
                return this.provider;
            }
            set
            {
                this.provider = value;
            }
        }

        public DateTime LastModified
        {
            get
            {
                return this.lastModified;
            }
            set
            {
                this.lastModified = value;
            }
        }

        public string ApplicationName
        {
            get
            {
                return this.appName;
            }
            set
            {
                this.appName = value;
            }
        }

        public string Title
        {
            get
            {
                return this.title;
            }
            set
            {
                this.title = value;
            }
        }

        public DateTime? DateCreated
        {
            get
            {
                return this.dateCreated;
            }
            set
            {
                this.dateCreated = value;
            }
        }

        public ExternalEntry()
        {
        }

        public ExternalEntry(string applicationName, Guid id)
        {
            this.ApplicationName = applicationName;
            this.Id = id;
        }

        private Guid id;
        private string appName;
        private object transaction;
        private object provider;
        private DateTime lastModified;
        private string title;
        private DateTime? dateCreated;
    }
}
