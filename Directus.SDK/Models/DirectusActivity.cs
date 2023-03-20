using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Directus.SDK.Models
{
    public class DirectusActivity
    {
        public int Id { get; set; }
        public string Action { get; set; }
        public string Collection { get; set; }
        public string Item { get; set; }
        public int UserId { get; set; }
        public DateTime? Timestamp { get; set; }
        public string Comment { get; set; }

    }
}
