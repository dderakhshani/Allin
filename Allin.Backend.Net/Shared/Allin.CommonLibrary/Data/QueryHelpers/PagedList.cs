using System.Collections.Generic;

namespace Allin.Common.Data
{
    public class PagedList<T>
    {
        public IEnumerable<T> Data { get; set; } = default!;
        public long TotalCount { get; set; }

    }
}
