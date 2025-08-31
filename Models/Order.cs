using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestrurantPG.Models
{
    public class Order
    {
        [Key]
        public int Order_Id { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        [Range(1, 9999)]
        public decimal TotalCost { get; set; }

        [ForeignKey("Booking")]
        [Required]
        public int BookingId_Fk { get; set; }

        public Booking Booking { get; set; }

    }
}
