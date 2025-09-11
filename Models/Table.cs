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

        // X och Y axel för placering i resturangen!
        public int? X { get; set; }
        public int? Y { get; set; }
    }
}
