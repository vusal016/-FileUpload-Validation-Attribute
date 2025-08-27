using PustokApp.Models.Common;
using System.ComponentModel.DataAnnotations;

namespace PustokApp.Models
{
    public class Tag:BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public ICollection <BookTag> BookTags { get; set; }
    }
}
