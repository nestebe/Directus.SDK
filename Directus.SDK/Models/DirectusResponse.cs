using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Directus.SDK.Models
{
    public class DirectusResponse<T>
    {
        [JsonProperty("data")]
        public T Data { get; set; }
    }
}
