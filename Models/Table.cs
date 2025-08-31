using System.ComponentModel.DataAnnotations;

namespace RestrurantPG.Models
{
    public class Table
    {
        [Key]
        public int Table_Id { get; set; }

        [Required]
        public int Number { get; set; }  

        [Required]
        [Range(1, 8)] 
        public int Capacity { get; set; }
    }
}
