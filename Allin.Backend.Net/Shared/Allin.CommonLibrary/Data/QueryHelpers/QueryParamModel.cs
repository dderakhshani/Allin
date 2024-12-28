using Allin.Common.Data.QueryHelpers.QueryParsing;
using Allin.Common.Utilities.CustomBindings;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Allin.Common.Data.QueryHelpers
{

    [ModelBinder(BinderType = typeof(QueryParamModelBinder))]
    public class QueryParamModel
    {
        [JsonConverter(typeof(PropertyJsonConverter))]
        public string? Group { get; set; }


        public Paging? PagingProperties { get; set; }


        [JsonConverter(typeof(PropertyJsonConverter))]
        public string? OrderByProperties { get; set; }

        public List<Condition>? Conditions { get; set; }




        [JsonConverter(typeof(PropertyListJsonConverter))]
        public string ColumnsNamesToShow { get; set; } = null!;

        [JsonConverter(typeof(PropertyJsonConverter))]
        public string? SearchTerm { get; set; }

        private List<string>? _columnsNamesToUse;
        public List<string> ColumnsNamesToUse
        {
            get
            {
                if (_columnsNamesToUse == default)
                {
                    _columnsNamesToUse = GetAllColumnToUse();
                }
                return _columnsNamesToUse;
            }
        }


        private List<string> GetAllColumnToUse()
        {
            List<string> cols = ColumnsNamesToShow.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList();
            if (Conditions != null)
                foreach (var c in Conditions)
                    if (!string.IsNullOrEmpty(c.PropertyName) && !cols.Contains(c.PropertyName))
                        cols.Add(c.PropertyName);

            if (!string.IsNullOrWhiteSpace(OrderByProperties))
                foreach (var o in OrderByProperties.Split(",", StringSplitOptions.RemoveEmptyEntries))
                {
                    var colNameWithoutAscDesc = o.Split(' ', StringSplitOptions.RemoveEmptyEntries)[0];
                    if (!string.IsNullOrEmpty(colNameWithoutAscDesc) && !cols.Contains(colNameWithoutAscDesc))
                        cols.Add(colNameWithoutAscDesc);
                }
            if (!string.IsNullOrWhiteSpace(Group))
                foreach (var g in Group.Split(",", StringSplitOptions.RemoveEmptyEntries))
                    if (!string.IsNullOrEmpty(g) && !cols.Contains(g.Trim()))
                        cols.Add(g.Trim());

            return cols;
        }

        public class Paging
        {
            public int PageSize { get; set; }
            public int PageIndex { get; set; }
        }
    }
}