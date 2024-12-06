using System.ComponentModel.DataAnnotations;
using System;

namespace UserPersonAuditAPI.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string Username { get; set; }

        [Required, MaxLength(100)]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        // Navigation properties for audit tracking
        public ICollection<Person> CreatedPersons { get; set; } = new List<Person>();
        public ICollection<Person> UpdatedPersons { get; set; } = new List<Person>();
    }
}
