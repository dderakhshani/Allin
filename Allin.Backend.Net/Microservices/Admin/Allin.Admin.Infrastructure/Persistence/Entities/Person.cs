using System.ComponentModel.DataAnnotations.Schema;

namespace Allin.Admin.Infrastructure.Persistence.Entities
{
    [Table("Persons", Schema = "Organization")]
    public class Person : AdminBaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SSN { get; set; }
        public string? MobilesJson { get; set; }
        public string? Email { get; set; }
        public string? PhotoUrl { get; set; }
        public string? SignatureImageUrl { get; set; }
        public DateTime? BirthDate { get; set; }
        public long GenderBaseId { get; set; }
        public short Maritalstatus { get; set; }
    }
}
