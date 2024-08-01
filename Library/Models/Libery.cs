using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Models
{
    public class Libery
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "שם הז'אנר")]
        public string zzaner { get; set; }
        public List<Shelf> shelfs { get; set; }


    }
}
