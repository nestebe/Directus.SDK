using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Directus.SDK.Utils
{
    public class DirectusFilterBuilder
    {
        private readonly List<string> _filterParameters = new List<string>();

        public DirectusFilterBuilder Equals(string field, object value)
        {
            var stringValue = GetValueAsString(value);
            var filter = $"{field},eq,{stringValue}";
            _filterParameters.Add(filter);
            return this;
        }

        public DirectusFilterBuilder NotEquals(string field, object value)
        {
            var stringValue = GetValueAsString(value);
            var filter = $"{field},neq,{stringValue}";
            _filterParameters.Add(filter);
            return this;
        }

        public DirectusFilterBuilder GreaterThan(string field, object value)
        {
            var stringValue = GetValueAsString(value);
            var filter = $"{field},gt,{stringValue}";
            _filterParameters.Add(filter);
            return this;
        }

        public DirectusFilterBuilder GreaterThanOrEqual(string field, object value)
        {
            var stringValue = GetValueAsString(value);
            var filter = $"{field},gte,{stringValue}";
            _filterParameters.Add(filter);
            return this;
        }

        public DirectusFilterBuilder LessThan(string field, object value)
        {
            var stringValue = GetValueAsString(value);
            var filter = $"{field},lt,{stringValue}";
            _filterParameters.Add(filter);
            return this;
        }

        public DirectusFilterBuilder LessThanOrEqual(string field, object value)
        {
            var stringValue = GetValueAsString(value);
            var filter = $"{field},lte,{stringValue}";
            _filterParameters.Add(filter);
            return this;
        }

        public DirectusFilterBuilder Contains(string field, string value)
        {
            var filter = $"{field},contains,{value}";
            _filterParameters.Add(filter);
            return this;
        }

        // Ajoutez d'autres méthodes pour les opérateurs de filtre pris en charge

        public string Build()
        {
            if (_filterParameters.Count == 0)
            {
                return string.Empty;
            }

            var queryString = new StringBuilder("?");
            queryString.AppendJoin("&", _filterParameters.Select(filter => $"filter[]={filter}"));
            return queryString.ToString();
        }

        private string GetValueAsString(object value)
        {
            if (value == null)
            {
                return "null";
            }
            if (value is string)
            {
                return $"\"{value}\"";
            }
            if (value is DateTime)
            {
                var dateTime = (DateTime)value;
                return $"\"{dateTime.ToString("s")}\"";
            }
            return value.ToString();
        }
    }
}

/*
 * var filterBuilder = new DirectusFilterBuilder()
    .Equals("status", "published")
    .GreaterThan("created_on", new DateTime(2022, 1, 1))
    .Contains("title", "example");

string filterString = filterBuilder.Build();*/