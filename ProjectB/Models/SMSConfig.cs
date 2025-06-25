using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectB.Models
{
    [Table("SMSConfigs")]
    public class SMSConfig
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public required string ProviderName { get; set; }

        [Required]
        [StringLength(200)]
        public required string ApiKey { get; set; }

        [StringLength(200)]
        public required string ApiSecret { get; set; }

        [StringLength(50)]
        public string? SenderId { get; set; }

        [StringLength(500)]
        public string? WebhookUrl { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedAt { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
