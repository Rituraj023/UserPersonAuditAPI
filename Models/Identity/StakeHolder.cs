using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UserPersonAuditAPI.Models.Base;

namespace UserPersonAuditAPI.Models.Identity
{
    public class StakeHolder : BaseEntity<ulong>
    {
        public short StakeHolderTypeId { get; set; }
        public ulong PersonId { get; set; }
        //public uint? ProfileImageId { get; set; } // Foreign key to the Image table

        [Required]
        [MaxLength(500)] // Adjust the length based on your URL requirements
        public string ProfileImageUrl { get; set; } // The URL where the image is stored

        [ForeignKey(nameof(StakeHolderTypeId))]
        public StakeHolderType StakeHolderType { get; set; }

        [ForeignKey(nameof(PersonId))]
        public Person Person { get; set; }

        
        //[ForeignKey(nameof(ProfileImageId))]
        //public Image ProfileImage { get; set; } // Navigation property for the profile image
    }
}
