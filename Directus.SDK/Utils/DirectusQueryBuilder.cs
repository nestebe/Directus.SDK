using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Directus.SDK.Utils
{
    public class DirectusQueryBuilder
    {
        private readonly Dictionary<string, string> _queryParameters = new Dictionary<string, string>();

        public DirectusQueryBuilder Fields(params string[] fields)
        {
            _queryParameters["fields"] = string.Join(",", fields);
            return this;
        }

        public DirectusQueryBuilder Limit(int limit)
        {
            _queryParameters["limit"] = limit.ToString();
            return this;
        }

        public DirectusQueryBuilder Offset(int offset)
        {
            _queryParameters["offset"] = offset.ToString();
            return this;
        }

        public DirectusQueryBuilder Sort(params string[] sortFields)
        {
            _queryParameters["sort"] = string.Join(",", sortFields);
            return this;
        }

        public DirectusQueryBuilder Filter(string filterKey, string filterValue, string? operation = "")
        {
            if (string.IsNullOrEmpty(operation))
            {
                _queryParameters[$"filter[{filterKey}]"] = filterValue;
            }
            else
            {
                _queryParameters[$"filter[{filterKey}][{operation}]"] = filterValue;
            }

            return this;
        }


        public DirectusQueryBuilder Search(string searchQuery)
        {
            _queryParameters["search"] = searchQuery;
            return this;
        }

        // Ajoutez d'autres méthodes pour les paramètres de requête pris en charge

        public string Build()
        {
            if (_queryParameters.Count == 0)
            {
                return string.Empty;
            }

            var queryString = new StringBuilder("?");
            queryString.AppendJoin("&", _queryParameters.Select(kvp => $"{kvp.Key}={kvp.Value}"));
            return queryString.ToString();
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