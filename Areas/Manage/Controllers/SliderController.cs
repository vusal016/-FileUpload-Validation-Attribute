using Microsoft.AspNetCore.Mvc;
using PustokApp.Data;
using PustokApp.Models;

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
        public IActionResult Create()
        {
            return View();
        }
        [HttpPut]
        public IActionResult Create(Slider slider)
        {
            if (!ModelState.IsValid)
                return View();
            pustokDb.Sliders.Add(slider);
            pustokDb.SaveChanges();
            return RedirectToAction("index");
                
        }

    }
}
