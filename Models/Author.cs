using PustokApp.Models.Common;

namespace PustokApp.Models
{
    public class Author:BaseEntity
    {
        public string Name { get; set; }
        public List<Book> Books { get; set; }
    }
}
