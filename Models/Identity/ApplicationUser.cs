using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserPersonAuditAPI.Models.Identity
{
    public class ApplicationUser : IdentityUser<ulong>
    {             
        public ulong? StakeHolderId { get; set; } // Foreign Key

        [ForeignKey(nameof(StakeHolderId))]
        public StakeHolder StakeHolder { get; set; } // Navigation property   

    }

    public class ApplicationRole : IdentityRole<ulong>
    {
        [Required]
        [Column(TypeName = "uniqueidentifier")]
        public Guid RecordId { get; set; } = Guid.NewGuid(); // Unique Guid for display

        [Required]
        [MaxLength(150)]
        public string Name { get; set; } // Additional property for roles
    }

    public class ApplicationUserRole : IdentityUserRole<ulong>
    {
    }

    public class ApplicationUserClaim : IdentityUserClaim<ulong>
    {
    }

    public class ApplicationRoleClaim : IdentityRoleClaim<ulong>
    {
    }

    public class ApplicationUserLogin : IdentityUserLogin<ulong>
    {
    }

    public class ApplicationUserToken : IdentityUserToken<ulong>
    {
    }
    //IdentityUserLogin<int>
}
