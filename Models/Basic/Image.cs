﻿using System.ComponentModel.DataAnnotations;

namespace UserPersonAuditAPI.Models.Basic
{
    public class Image
    {
        [Key]
        public ulong Id { get; set; } // Primary key

        [Required]
        [MaxLength(500)] // Adjust the length based on your URL requirements
        public string Url { get; set; } // The URL where the image is stored

        [MaxLength(255)]
        public string AltText { get; set; } // Alternative text for accessibility (optional)

        [MaxLength(100)]
        public string Caption { get; set; } // Caption for the image (optional)

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow; // Timestamp when the image was added
    }
}