using System.ComponentModel.DataAnnotations;

namespace RestrurantPG.DTOs.GuestDTOs
{
    public class GuestDTO
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        [MaxLength(30)]
        public string LastName { get; set; }

        [Required]
        [Phone]
        [MaxLength(12)]
        public string Tel { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(55)]
        public string Email { get; set; }
    }
}

