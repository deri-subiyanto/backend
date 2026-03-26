using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreBackend.Models
{
    [Table("users")]
    public class User
    {
        [Key]
        [Column("id")]
        public Guid id {get; set;}

        [Required]
        [Column("username")]
        [StringLength(50)]
        public required string UserName { get; set; }

        [Required]
        [Column("passwordHash")]
        public required string PasswordHash { get; set; }

        [Required]
        [Column("datauser", TypeName = "jsonb")]
        public required string DataUser { get; set; }

        [Column("createdAt")]
        public DateTime CreateAt { get; set; } = DateTime.UtcNow;

        [Required]
        [Column("enabled")]
        public required bool Enabled {get; set;} = true;
    }
}