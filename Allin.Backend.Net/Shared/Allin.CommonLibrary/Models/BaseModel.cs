using Microsoft.EntityFrameworkCore;

namespace Allin.Common.Models;

public class BaseModel
{
    public long Id { get; set; }
}

public class BaseHierarchyModel : BaseModel
{
    public HierarchyId Hierarchy { get; set; }
    public long? ParentId { get; set; }
}