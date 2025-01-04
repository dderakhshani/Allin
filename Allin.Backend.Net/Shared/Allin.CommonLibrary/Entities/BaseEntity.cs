using System.ComponentModel.DataAnnotations;

namespace Allin.Common.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        public long Id { get; set; }

        //public DateTime CreatedAt { get; set; }
        //public DateTime? ModifiedAt { get; set; }
        //public bool IsDeleted { get; set; }
    }
}
