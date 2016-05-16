# Sitefinity.ExternalDataModel
Sample for integrating a custom type into the Stefinity Data Model. This way the data is integrated in the Sitefinity database and CRUD operations can easily be performed.

###Sample usage
```cs
ExternalEntryManager manager = ExternalEntryManager.GetManager();

ExternalEntryProvider provider = manager.Provider as ExternalEntryProvider;

var entry = provider.CreateExternalEntry();
entry.Title = "My external entry";
entry.DateCreated = DateTime.UtcNow;

var entry2 = provider.CreateExternalEntry();
entry2.Title = "My external entry2";
entry2.DateCreated = DateTime.UtcNow;

manager.SaveChanges();

var item = provider.GetExternalEntry(entry.Id);

var items = provider.GetExternalEntries().Where(x => x.Title.Contains("My external entry")).ToList();

provider.Delete(entry2);
manager.SaveChanges();
```