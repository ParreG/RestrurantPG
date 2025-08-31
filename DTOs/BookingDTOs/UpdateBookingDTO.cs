using System.ComponentModel.DataAnnotations;

namespace RestrurantPG.DTOs.BookingDTOs
{
    public class UpdateBookingDTO
    {
        [Required, EmailAddress, MaxLength(254)]
        public string Email { get; set; }

        [Range(1, 8)]
        public int NumberOfGuests { get; set; }

        [Required]
        public DateTime BookingStart { get; set; }
    }
}
