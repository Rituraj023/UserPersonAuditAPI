using System.ComponentModel.DataAnnotations;
using UserPersonAuditAPI.Models.Base;

namespace UserPersonAuditAPI.Models.Identity
{
    public class StakeHolderType : BaseEntity<short>
    {
        [Required]
        [MaxLength(100)]
        public string Description { get; set; }
    }
}
