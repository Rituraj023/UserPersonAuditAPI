using System.ComponentModel.DataAnnotations;
using UserPersonAuditAPI.Models.Base;

namespace UserPersonAuditAPI.Models.Person
{

    public class Person : BaseEntity<ulong>
    {
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }

    }
}
