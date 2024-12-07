using System.ComponentModel.DataAnnotations.Schema;
using UserPersonAuditAPI.Models.Base;
using UserPersonAuditAPI.Models.Basic;

namespace UserPersonAuditAPI.Models.Person
{
    public class StakeHolder : BaseEntity<ulong>
    {
        public short StakeHolderTypeId { get; set; }
        public ulong PersonId { get; set; }
        public uint? ProfileImageId { get; set; } // Foreign key to the Image table

        [ForeignKey(nameof(StakeHolderTypeId))]
        public StakeHolderType StakeHolderType { get; set; }

        [ForeignKey(nameof(PersonId))]
        public Person Person { get; set; }

        [ForeignKey(nameof(ProfileImageId))]
        public Image ProfileImage { get; set; } // Navigation property for the profile image
    }
}
