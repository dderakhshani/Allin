using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Allin.Common.Models
{
    public class TextValue<T>
    {
        public T? Value { get; set; }
        public string? Text { get; set; }

        public object? ExtraProperties { get; set; }

    }
}
