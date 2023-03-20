using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Directus.SDK.Models
{
    public class DirectusItem : BaseModel
    {
        public Dictionary<string, object> Fields { get; set; }
    }
}
