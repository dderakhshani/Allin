using Allin.Admin.Infrastructure.Persistence;
using Allin.Common.Models;
using Allin.Common.Utilities.Mappings;

namespace Allin.Admin.Application.Models
{
    public class TeamModel : BaseHierarchyModel, IMapFrom<Team, TeamModel>
    {
        public long? PlaceBaseId { get; set; }
        public string PlaceTitle { get; set; } = null!;
    }
}
