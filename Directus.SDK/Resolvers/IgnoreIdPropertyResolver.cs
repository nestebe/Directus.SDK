using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Directus.SDK.Resolvers
{
    public class IgnoreIdPropertyResolver : DefaultContractResolver
    {
        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            var properties = base.CreateProperties(type, memberSerialization);
            var idProperty = properties.FirstOrDefault(p => p.PropertyName == "id" || p.PropertyName == "Id");
            if (idProperty != null)
            {
                idProperty.ShouldSerialize = instance => false;
            }
            return properties;
        }
    }
}
