using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UserPersonAuditAPI.Models.Person;

namespace UserPersonAuditAPI.Models.Identity
{
    public class User
    {
        [Key]
        public int Id { get; set; } // Primary Key

        [Required]
        [MaxLength(50)]
        public string Username { get; set; }

        [Required]
        [MaxLength(100)]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; }
        
        public int? StakeHolderId { get; set; } // Foreign Key

        // One-to-One Relationship with Person
        [ForeignKey(nameof(StakeHolderId))]
        public StakeHolder StakeHolder { get; set; } // Navigation property   

    }
}
