namespace Allin.Admin.Infrastructure.Persistence;

public class Role : AdminBaseEntity
{
    public long? ParentId { get; set; }
    public string Title { get; set; }
    public string UniqueName { get; set; }
    public string Description { get; set; }
    public IList<string> Mobiles { get; set; }
    public virtual ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();
    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}
