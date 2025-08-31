using System.ComponentModel.DataAnnotations;

namespace RestrurantPG.DTOs.TableDTOs
{
    public class TableDTO
    {
        [Required]
        public int Number { get; set; }

        [Required]
        [Range(1, 8)]
        public int Capacity { get; set; }
    }
}
