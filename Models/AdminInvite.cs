namespace RestrurantPG.Models
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Index(nameof(InviteCode), IsUnique = true)]
    public class AdminInvite
    {
        [Key]
        public int AdminInvite_Id { get; set; }

        [Required]
        
        public Guid InviteCode { get; set; } = Guid.NewGuid();

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? ExpiresAt { get; set; } = DateTime.UtcNow.AddDays(7);

        public bool IsUsed { get; set; } = false;

        [ForeignKey("Admin")]
        public int AdminId_Fk { get; set; }
        public Admin CreatedByAdmin { get; set; }
    }
}
