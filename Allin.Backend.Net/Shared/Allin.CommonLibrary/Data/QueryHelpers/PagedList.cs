using System.Collections.Generic;

namespace Allin.Common.Data.QueryHelpers
{
    public class PagedList<T>
    {
        public IEnumerable<T> Data { get; set; } = default!;
        public long TotalCount { get; set; }

    }
}
