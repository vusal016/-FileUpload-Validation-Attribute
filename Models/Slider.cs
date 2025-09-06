using PustokApp.Models.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PustokApp.Models
{
    public class Slider:BaseEntity
    {

        public string ImageUrl { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        public string ButtonText { get; set; }
        public string ButtonLInk { get; set; }
        public int Order { get; set; }
        [NotMapped]
        public IFormFile File { get; set; }

    }
}
