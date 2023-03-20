using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Directus.SDK.Models
{
    public class DirectusFile : BaseModel
    {
        public string Storage { get; set; }
        public string Filename { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public long Size { get; set; }
        public int? Width { get; set; }
        public int? Height { get; set; }
        public string Embed { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Tags { get; set; }
        public int? Sort { get; set; }
        public DateTime? UploadedOn { get; set; }
        public string UploadedBy { get; set; }
        public string Checksum { get; set; }
    }
}
