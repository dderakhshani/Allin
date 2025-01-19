using Allin.Admin.Application.Common;
using Allin.Admin.Infrastructure.Persistence;
using Allin.Common.Utilities.Mappings;

namespace Allin.Admin.Application.Models
{
    public class BaseValueTypeModel : AdminBaseModel, IMapFrom<BaseValueType, BaseValueTypeModel>
    {
        public string BaseValueTypeTitle { get; set; } = null!;
        public string? Description { get; set; }
        public string? UniqueName { get; set; }
    }
}
