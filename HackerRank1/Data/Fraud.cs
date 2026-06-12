using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryService.WebAPI.Data
{
    public class Fraud
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string ImpostorDetails { get; set; }

        [Required]
        public string ContactInfo { get; set; }

        public string Comments { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}