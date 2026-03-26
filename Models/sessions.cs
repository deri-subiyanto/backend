using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreBackend.Models
{
    [Table("sessions")]
    public class Sessions
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("userId")]
        public Guid UserId { get; set; }

        [ForeignKey("idUser")]
        public virtual required User User {get; set;}

        [Required]
        [Column("token")]
        public required string Token { get; set; }

        [Column("expiredAt")]
        public DateTime ExpiredAt { get; set; }

        [Column("createAt")]
        public DateTime CreateAt { get; set; } = DateTime.UtcNow;
    }
}