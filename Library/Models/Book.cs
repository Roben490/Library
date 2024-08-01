using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "שם הספר")]
        public string? Name { get; set; }
        [Display(Name = "גובה הספר")]
        public int High { get; set; }
        [Display(Name = "רוחב הספר")]
        public int Widgh { get; set; }
        [NotMapped] public int slfid {  get; set; } 
        public Shelf? shelf { get; set; }
    }
}
