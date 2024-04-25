using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Directus.SDK.Models
{   
    /// <summary>
    /// Fields are individual pieces of content within an item. They are mapped to columns in the database.
    /// </summary>
    public class DirectusField
    {
        /// <summary>
        /// Name of the collection the field resides in.
        /// </summary>
        public string Collection { get; set; }

        /// <summary>
        /// The identifier of the field. This matches the table column name.
        /// </summary>
        public string Field { get; set; }

        /// <summary>
        /// The Directus data type of the field
        /// </summary>
        public string Type { get; set; }

        public DirectusFieldMeta? Meta { get; set; }

        public DirectusFieldSchema Schema { get; set; }
    }

    /// <summary>
    /// Directus metadata, primarily used in the Admin App. Meta is optional.
    /// </summary>
    public class DirectusFieldMeta
    {
        /// <summary>
        /// Primary key of the metadata row in directus_fields.
        /// </summary>
        public string Collection { get; set; }

        /// <summary>
        /// Identifier of the field. Matches the column name in the database.

        /// </summary>
        public string Field { get; set; }

        /// <summary>
        /// Any special transform flags that apply to this field.
        /// </summary>
        public string Special { get; set; }

        /// <summary>
        /// The interface used for this field.
        /// </summary>
        public string Interface { get; set; }

        /// <summary>
        /// The interface options configured for this field. The structure is based on the interface used.
        /// </summary>
        public object Options { get; set; }

        /// <summary>
        /// The display used for this field.
        /// </summary>
        public string Display { get; set; }

        /// <summary>
        /// The configured options for the used display.
        /// </summary>
        public string DisplayOptions{ get; set; }

        /// <summary>
        /// If the field is considered readonly in the Admin App.
        /// </summary>
        public bool ReadOnly { get; set; }

        /// <summary>
        /// If the field is hidden from the edit page in the Admin App.
        /// </summary>
        public bool Hidden { get; set; }

        /// <summary>
        /// Where this field is shown on the edit page in the Admin App.
        /// </summary>
        public int Sort { get; set; }

        /// <summary>
        /// How wide the interface is rendered on the edit page in the Admin App. One of half, half-left, half-right, half-space, full, fill.
        /// </summary>
        public string Width  { get; set; }

        /// <summary>
        /// How this field's name is displayed in the different languages in the Admin App.
        /// </summary>
        public object[] Translations { get; set; }

        /// <summary>
        /// Short description displayed in the Admin App.
        /// </summary>
        public string Note { get; set; }

    }

    /// <summary>
    /// "Raw" database information. Based on the database vendor used, different information might be returned. 
    /// The following are available for all drivers. Note: schema is optional. If a field exist in directus_fields, but not in the database, it's an alias commonly used for relational (O2M) or presentation purposes in the Admin App.
    /// </summary>
    public class DirectusFieldSchema
    {
        /// <summary>
        /// Identifier of the field. Matches the column name in the database.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Name of the table the column resides in.
        /// </summary>
        public string Table { get; set; }

        /// <summary>
        /// The datatype as used in the database. Note: this value is database vendor specific.
        /// </summary>
        public string DataType { get; set; }

        /// <summary>
        /// The configured default value for the column.
        /// </summary>
        public object DefaultValue { get; set; }

        /// <summary>
        /// Configured length for varchar type columns.
        /// </summary>
        public int MaxLength { get; set; }

        /// <summary>
        /// Precision for integer/float/decimal type fields.
        /// </summary>
        public int NumericPrecision { get; set; }

        /// <summary>
        /// Scale for integer/float/decimal type fields.
        /// </summary>
        public int NumericScale { get; set; }

        /// <summary>
        /// Whether or not the column is nullable. This is what is used as the "required" state in Directus.
        /// </summary>
        public bool IsNullable { get; set; }

        /// <summary>
        /// Whether or not the field is the primary key of the table.
        /// </summary>
        public bool IsPrimaryKey { get; set; }

        /// <summary>
        /// If the current column has a foreign key constraint, this points to the related column.
        /// </summary>
        public string ForeignKeyColumn { get; set; }

        /// <summary>
        /// If the current column has a foreign key constraint, this points to the related table.
        /// </summary>
        public string ForeignKeyTable { get; set; }

        /// <summary>
        /// Comment as stored in the database.
        /// </summary>
        public string Comment { get; set; }

    }
}
