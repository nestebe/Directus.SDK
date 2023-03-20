using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Directus.SDK.Models
{
    public class DirectusCollection : BaseModel
    {
        public string? Name { get; set; }
        public string Note { get; set; }
        public bool? Sort { get; set; }
        public string Display { get; set; }
        public string Icon { get; set; }
        public bool? Hidden { get; set; }
        public int? Translation { get; set; }
    }
}
