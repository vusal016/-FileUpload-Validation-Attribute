using PustokApp.Models;

namespace PustokApp.ViewModels
{
    public class HomeVm
    {
        public List<Slider> Sliders { get; set; }
        public List<Book> NewBooks { get; set; }
        public List <Book>FeaturedBooks{ get; set; }
        public List <Book> DiscountBook { get; set; }
    }
}
