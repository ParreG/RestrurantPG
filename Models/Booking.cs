using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestrurantPG.Models
{
    public class Booking
    {
        [Key]
        public int Booking_Id { get; set; }

        [ForeignKey("Guest")]
        [Required]
        public int GuestId_Fk { get; set; }

        [ForeignKey("Table")]
        [Required]
        public int TableId_Fk { get; set; }

        [Range(1, 8)]
        public int NumberOfGuests { get; set; }

        [Required]
        public DateTime BookingStart { get; set; }

        [Required]
        public DateTime BookingEnd { get; set; }

        public Guest Guest { get; set; }
        public Table Table { get; set; }
    }
}
