using System;
using System.Collections.Generic;
using Allin.Common.Data;
namespace Allin.Admin.Infrastructure.Persistence;

public class Person : AdminBaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Ssn { get; set; }
    public bool? IsLegal { get; set; }
    public IList<string> Mobiles { get; set; }
    public string Email { get; set; }
    public string PhotoUrl { get; set; }
    public string SignatureImageUrl { get; set; }
    public DateOnly? BirthDate { get; set; }
    public GenderEnums GenderEnum { get; set; }
    public MaritalEnums? MaritalEnum { get; set; }
    public virtual Employee Employee { get; set; }
    public virtual ICollection<PersonAddress> PersonAddresses { get; set; } = new List<PersonAddress>();
    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
