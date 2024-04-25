using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Directus.SDK.Models
{
    /// <summary>
    /// Collections are the individual collections of items, similar to tables in a database. Changes to collections will alter the schema of the database.
    /// </summary>
    public class DirectusCollection
    {
        /// <summary>
        /// Name of the collection. This matches the table name in the database.
        /// </summary>
        public string Collection { get; set; }

        public DirectusCollectionMeta Meta { get; set; }

        public DirectusCollectionSchema Schema { get; set; }

        public List<DirectusField> Fields { get; set; }

    }

    /// <summary>
    /// Directus metadata, primarily used in the Admin App.
    /// </summary>
    public class DirectusCollectionMeta
    {
        /// <summary>
        /// Name of the collection. This matches the table name in the database.
        /// </summary>
        public string Collection { get; set; }

        /// <summary>
        /// Icon displayed in the Admin App when working with this collection.
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// Short description displayed in the Admin App.
        /// </summary>
        public string Note { get; set; }

        /// <summary>
        /// How items in this collection should be displayed when viewed relationally in the Admin App.
        /// </summary>
        public string DisplayTemplate { get; set; }

        /// <summary>
        /// Whether or not this collection is hidden in the Admin App.
        /// </summary>
        public bool Hidden { get; set; }

        /// <summary>
        /// Whether or not this collection is treated as a singleton.
        /// </summary>
        public bool Singleton { get; set; }

        /// <summary>
        /// How this collection's name is displayed in the different languages in the Admin App.
        /// </summary>
        public object[] Translations { get; set; }

        /// <summary>
        /// What field in the collection holds the archived state.
        /// </summary>
        public string ArchiveField { get; set; }

        /// <summary>
        /// What value the archive field should be set to when archiving an item.
        /// </summary>
        public string ArchiveValue { get; set; }

        /// <summary>
        /// What value the archive field should be set to when unarchiving an item.
        /// </summary>
        public string UnarchiveValue { get; set; }

        /// <summary>
        /// Whether or not the Admin App should allow the user to view archived items.
        /// </summary>
        public bool ArchiveAppFilter { get; set; }

        /// <summary>
        /// What field holds the sort value on the collection. The Admin App uses this to allow drag-and-drop manual sorting.
        /// </summary>
        public bool SortField { get; set; }

        /// <summary>
        /// What data is tracked. One of all, activity. See Accountability for more information.
        /// </summary>
        public string Accountability { get; set; }

        /// <summary>
        /// What fields are duplicated during "Save as copy" action of an item in this collection. See Duplication for more information.
        /// </summary>
        public object[] ItemDuplicationFields { get; set; }

        /// <summary>
        /// The name of the parent collection. This is used in grouping/nesting of collections.
        /// </summary>
        public string Group { get; set; }

        /// <summary>
        /// What sort order of the collection relative to other collections of the same level. This is used in sorting of collections.
        /// </summary>
        public int Sort { get; set; }

        /// <summary>
        /// What is the default behavior of this collection or "folder" collection when it has nested collections. One of open, closed, locked.
        /// </summary>
        public string Collapse { get; set; }

        /// <summary>
        /// Whether or not Content Versioning is enabled for this collection.
        /// </summary>
        public bool Versioning { get; set; }
    }

    /// <summary>
    /// "Raw" database information. Based on the database vendor used, different information might be returned. The following are available for all drivers.
    /// </summary>
    public class DirectusCollectionSchema
    {
        /// <summary>
        /// The table name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The table comment
        /// </summary>
        public string Comment { get; set; }

    }


}
