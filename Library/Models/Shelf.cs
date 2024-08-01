using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Models
{
    public class Shelf
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "גובה המדף")]
        public int High {  get; set; }
        [Display(Name = "רוחב המדף")]
        public int Widgh { get; set; }
        public Libery? liberies { get; set; }
        [NotMapped] public int LibId { get; set; }

    }
}
