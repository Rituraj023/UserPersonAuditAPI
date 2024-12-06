using System.ComponentModel.DataAnnotations;

namespace UserPersonAuditAPI.Models
{
    public class Person
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string FirstName { get; set; }

        [Required, MaxLength(50)]
        public string LastName { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }

        // Audit properties
        public DateTime CreatedOn { get; set; }
        public int CreatedById { get; set; }
        public User CreatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }
        public int? UpdatedById { get; set; }
        public User UpdatedBy { get; set; }
    }
}
