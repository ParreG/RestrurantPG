namespace RestrurantPG.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Microsoft.EntityFrameworkCore;

    public enum AdminRole
    {
        SuperAdmin,
        Admin
    }

    [Index(nameof(UserName), IsUnique = true)]
    [Index(nameof(Email), IsUnique = true)]
    public class Admin
    {
        [Key]
        public int Admin_Id { get; set; }

        [Required, EmailAddress, MaxLength(50)]
        public string Email { get; set; }

        [Required, MaxLength(50)]
        public string UserName { get; set; }

        [Required, MaxLength(500)]
        public string PasswordHash { get; set; }

        [Required]
        public AdminRole Role { get; set; } = AdminRole.Admin;

        public List<AdminInvite> CreatedInvites { get; set; }
    }
}
