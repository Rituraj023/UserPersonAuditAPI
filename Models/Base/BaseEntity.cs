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

        public int CreatedById { get; set; }
        public int UpdatedById { get; set; }

        [ForeignKey(nameof(CreatedById))]
        public User CreatedBy { get; set; }

        [ForeignKey(nameof(UpdatedById))]
        public User UpdatedBy { get; set; }
    }


}