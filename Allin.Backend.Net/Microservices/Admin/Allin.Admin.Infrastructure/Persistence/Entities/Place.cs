using System;
using System.Collections.Generic;
using Allin.Common.Data;
namespace Allin.Admin.Infrastructure.Persistence;

public class Place : AdminBaseEntity
{
    public long? ParentId { get; set; }
    public long LocationBaseId { get; set; }
    public string LocationTitle { get; set; } = null!;
    public virtual ICollection<Place> InverseParent { get; set; } = new List<Place>();
    public virtual Place? Parent { get; set; }
}
