namespace Allin.Admin.Infrastructure.Persistence;

public class PersonAddress : AdminBaseEntity
{
    public long PersonId { get; set; }
    public long TypeBaseId { get; set; }
    public long CityBaseId { get; set; }
    public string Address { get; set; }
    public virtual BaseValue CityBase { get; set; }
    public virtual Person Person { get; set; }
    public virtual BaseValue TypeBase { get; set; }
}
