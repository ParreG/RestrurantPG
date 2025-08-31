using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestrurantPG.Models
{
    public class Dish
    {
        [Key]
        public int Dish_Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [MaxLength(50)]
        public string Description { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        [Range(1.00, 9999.00)]
        public decimal Price { get; set; }

        public bool IsPopular { get; set; }

        //[Url] Denna gör att jag inte kan ha null
        [MaxLength(200)]
        public string? PictureUrl { get; set; }
    }
}
