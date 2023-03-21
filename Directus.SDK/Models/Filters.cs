using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Directus.SDK.Models
{
    public class Filter
    {
        public object Value { get; set; }

        protected Filter(object value)
        {
            Value = value;
        }
    }

    public class AndFilter : Filter
    {
        public AndFilter(params Filter[] filters) : base(new { _and = filters.Select(f => f.Value).ToArray() })
        {
        }
    }

    public class OrFilter : Filter
    {
        public OrFilter(params Filter[] filters) : base(new { _or = filters.Select(f => f.Value).ToArray() })
        {
        }
    }

    public class EqFilter : Filter
    {
        public EqFilter(string key, object value) : base(new Dictionary<string, object> { { key, new { _eq = value } } })
        {
        }
    }

    public class NeqFilter : Filter
    {
        public NeqFilter(string key, object value) : base(new Dictionary<string, object> { { key, new { _neq = value } } })
        {
        }
    }

    public class InFilter : Filter
    {
        public InFilter(string key, params string[] values) : base(new Dictionary<string, object> { { key, new { _in = values } } })
        {
        }
    }

}
