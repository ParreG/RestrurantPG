using RestrurantPG.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestrurantPG.DTOs.BookingDTOs
{
    public class NewBookingDTO
    {

        [Required, MaxLength(50)]
        public string Name { get; set; }

        [Required, MaxLength(50)]
        public string LastName { get; set; }

        [Required, EmailAddress, MaxLength(254)]
        public string Email { get; set; }

        [Required, MaxLength(30)]
        public string Tel { get; set; }

        [Range(1, 8)]
        public int NumberOfGuests { get; set; }

        [Required]
        public DateTime BookingStart { get; set; }
    }
}
