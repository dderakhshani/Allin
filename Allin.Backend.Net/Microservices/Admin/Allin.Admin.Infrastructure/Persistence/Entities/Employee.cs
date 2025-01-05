using System;
using System.Collections.Generic;
using Allin.Common.Entities;
namespace Allin.Admin.Infrastructure.Persistence;

public class Employee : AdminBaseEntity 
{
  public long PersonId { get; set; }
  public long? DepartmentPositionId { get; set; }
  public string EmployeeCode { get; set; }
  public DateTime? EmploymentDate { get; set; }
  public long ContractTypeBaseId { get; set; }
  public bool Floating { get; set; }
  public DateTime? LeaveDate { get; set; }
    public virtual Person Person { get; set; }
}
