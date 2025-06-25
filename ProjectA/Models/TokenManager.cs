using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectA.Models
{
    [Table("TokenManagers")]
    public class TokenManager
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public required string TokenValue { get; set; }

        public int ClientId { get; set; }

        [ForeignKey("ClientId")]
        public required Client Client { get; set; }

        public DateTime IssuedAt { get; set; } = DateTime.UtcNow;

        public DateTime ExpiresAt { get; set; }

        public bool IsRevoked { get; set; } = false;
    }
}
