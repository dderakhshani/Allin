namespace Allin.Admin.Infrastructure.Persistence;

public class Employee : AdminBaseEntity
{
    public long PersonId { get; set; }
    public long? DepartmentPositionId { get; set; }
    public string EmployeeCode { get; set; } = null!;
    public DateTime? EmploymentDate { get; set; }
    public long ContractTypeBaseId { get; set; }
    public bool Floating { get; set; }
    public DateTime? LeaveDate { get; set; }
    public virtual BaseValueItem ContractTypeBase { get; set; } = null!;
    public virtual DepartmentPosition? DepartmentPosition { get; set; }
    public virtual Person Person { get; set; } = null!;
    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
