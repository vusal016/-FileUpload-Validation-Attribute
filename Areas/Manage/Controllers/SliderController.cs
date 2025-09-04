using Microsoft.AspNetCore.Mvc;
using PustokApp.Data;

namespace PustokApp.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class SliderController (PustokDbContext pustokDb): Controller
    {
        public IActionResult Index()
        {
            var sliders = pustokDb.Sliders.ToList();
            return View(sliders);
        }
    }
}
