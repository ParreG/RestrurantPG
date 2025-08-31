using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestrurantPG.Models
{
    public class OrderItem
    {
        [Key]
        public int OrderItem_Id { get; set; }

        [ForeignKey("Dish")]
        [Required]
        public int DishId_Fk { get; set; }

        [ForeignKey("Order")]
        [Required]
        public int OrderId_Fk { get; set; }

        [Range(1, 15)]
        public int ItemCount { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        [Range(1, 9999)]
        public decimal ItemPrice { get; set; }

        public Order Order { get; set; }
        public Dish Dish { get; set; }
    }
}
