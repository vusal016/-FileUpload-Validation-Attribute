using PustokApp.Models.Common;

namespace PustokApp.Models
{
    public class Slider:BaseEntity
    {
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ButtonText { get; set; }
        public string ButtonLInk { get; set; }
        public int Order { get; set; }

    }
}
