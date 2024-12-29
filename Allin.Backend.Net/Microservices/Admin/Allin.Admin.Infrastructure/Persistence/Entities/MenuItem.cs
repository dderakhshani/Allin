using System;
using System.Collections.Generic;
namespace Allin.Admin.Infrastructure.Persistence;

public class MenuItem : AdminBaseEntity
{
  public long? ParentId { get; set; }
  public long? PermissionId { get; set; }
  public string Title { get; set; }
  public string ImageUrl { get; set; }
  public string FormUrl { get; set; }
  public string QueryParameterMappings { get; set; }
  public string HelpUrl { get; set; }
  public string PageCaption { get; set; }
  public bool IsActive { get; set; }
  public int OrderIndex { get; set; }
    public virtual ICollection<MenuItem> InverseParent { get; set; } = new List<MenuItem>();
    public virtual MenuItem Parent { get; set; }
    public virtual Permission Permission { get; set; }
}
