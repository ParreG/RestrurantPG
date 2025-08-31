using RestrurantPG.Models;
using System.ComponentModel.DataAnnotations;

namespace RestrurantPG.DTOs.AuthDTOs
{
    public class AdminRegisterDTO
    {
        [Required, EmailAddress, MaxLength(50)]
        public string Email { get; set; }

        [Required, MaxLength(30)]
        public string UserName { get; set; }

        [Required, MinLength(8)]
        public string Password { get; set; }

        [Required]
        public string RegistrationCode { get; set; }
    }
}
