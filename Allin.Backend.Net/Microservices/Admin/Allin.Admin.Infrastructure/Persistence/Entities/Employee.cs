using System;
using System.Collections.Generic;
using Allin.Common.Data;
namespace Allin.Admin.Infrastructure.Persistence;

public class Employee : AdminBaseEntity 
{
  public long PersonId { get; set; }
  public long? DepartmentId { get; set; }
  public long? PositionId { get; set; }
  public string EmployeeCode { get; set; } = null!;
  public DateTime? EmploymentDate { get; set; }
  public long ContractTypeBaseId { get; set; }
  public bool Floating { get; set; }
  public DateTime? LeaveDate { get; set; }
    public virtual BaseValueItem ContractTypeBase { get; set; } = null!;
    public virtual Department? Department { get; set; }
    public virtual ICollection<EmployeeTeam> EmployeeTeams { get; set; } = new List<EmployeeTeam>();
    public virtual Person Person { get; set; } = null!;
    public virtual Position? Position { get; set; }
    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
