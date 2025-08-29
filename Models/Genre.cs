using PustokApp.Models.Common;
using System.ComponentModel.DataAnnotations;

namespace PustokApp.Models
{
    public class Genre:BaseEntity
    {
        [Required]
        [StringLength(20,ErrorMessage="Name cannot be longer than 50 chraracters.")]
        public string Name { get; set; }
        public List<Book> Books { get; set; }
    }
}
public class GenreVm
{
    public string Name { get; set; }
    public int BooksCount { get; set; }
}