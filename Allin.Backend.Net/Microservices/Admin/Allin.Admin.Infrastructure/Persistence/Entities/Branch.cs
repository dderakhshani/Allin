namespace Allin.Admin.Infrastructure.Persistence;

public class Branch : AdminBaseEntity
{
    public string Title { get; set; }
    public string UniqueName { get; set; }
    public virtual ICollection<Department> Departments { get; set; } = new List<Department>();
}
