using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using UserPersonAuditAPI.Models.Identity;

namespace UserPersonAuditAPI.Models.Base
{

    public abstract class BaseEntity<T>
    {
        [Key]
        public T Id { get; set; } // Primary key (generic type)

        [Required]
        [Column(TypeName = "uniqueidentifier")]
        public Guid RecordId { get; set; } = Guid.NewGuid(); // Unique Guid for display

        [Required]
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedOn { get; set; } = DateTime.UtcNow;

        public ulong CreatedById { get; set; }
        public ulong UpdatedById { get; set; }

        [ForeignKey(nameof(CreatedById))]
        public ApplicationUser CreatedBy { get; set; }

        [ForeignKey(nameof(UpdatedById))]
        public ApplicationUser UpdatedBy { get; set; }
    }


}