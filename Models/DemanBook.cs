using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReadBookMuds.Models
{
    [Table("DemandBook")]
    public class DemandBook
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public Book book { get; set; }
        [Required] public int bookId { get; set; }
        [Required] public string username { get; set; }
        [Required] public string phone { get; set; }
        [Required] public string Addresse { get; set; }
        [Required] public string Email { get; set; }
        [Required] public int nbr { get; set; }
        public bool Dilivred { get; set; } = false;
        public DateTime Created { get; set; } = DateTime.Now;


    }
}
