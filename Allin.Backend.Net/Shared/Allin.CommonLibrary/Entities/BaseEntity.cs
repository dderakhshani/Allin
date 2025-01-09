using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

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

    public abstract class BaseHierarchyEntity : IHierarchyEntity
    {
        [Key]
        public long Id { get; set; }
        public HierarchyId Hierarchy { get; set; }
        public long? ParentId { get; set; }


    }
}
