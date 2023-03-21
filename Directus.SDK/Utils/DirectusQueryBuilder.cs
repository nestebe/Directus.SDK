using Directus.SDK.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Directus.SDK.Utils
{
    public class DirectusQueryBuilder
    {
        private readonly Dictionary<string, string> _parameters;

        public DirectusQueryBuilder()
        {
            _parameters = new Dictionary<string, string>();
        }

        public DirectusQueryBuilder AddParameter(string key, string value)
        {
            _parameters[key] = value;
            return this;
        }

        public DirectusQueryBuilder Filter(string field, string operation, string value)
        {
            return AddParameter($"filter[{field}][{operation}]", value);
        }

        public DirectusQueryBuilder Limit(int limit)
        {
            return AddParameter("limit", limit.ToString());
        }

        public DirectusQueryBuilder Offset(int offset)
        {
            return AddParameter("offset", offset.ToString());
        }

        public DirectusQueryBuilder Search(string search)
        {
            return AddParameter("search", search);
        }

        public DirectusQueryBuilder Sort(string sort)
        {
            return AddParameter("sort", sort);
        }

        public DirectusQueryBuilder CustomFilter(Filter filter)
        {
            AddParameter("filter", JsonConvert.SerializeObject(filter.Value));
            return this;
        }

        public string Build()
        {
            return string.Join("&", _parameters.Select(kv => $"{kv.Key}={kv.Value}"));
        }
    }
}
/*
 * var queryBuilder = new DirectusQueryBuilder()
    .Fields("id", "title", "published")
    .Limit(10)
    .Offset(0)
    .Sort("published")
    .Filter("status", "published")
    .Search("example");

string queryString = queryBuilder.Build();
*/