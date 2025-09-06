using Microsoft.AspNetCore.Mvc;
using PustokApp.Data;
using PustokApp.Extentions;
using PustokApp.Models;
using static System.Net.Mime.MediaTypeNames;

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
        [HttpPost]
        public IActionResult Create(Slider slider)
        {
            if (!ModelState.IsValid) return View();
            var file = slider.File;
            if (file == null)
            {
                ModelState.AddModelError("File", "Image is required");
                return View();
            }
            if (!file.CheckContentType("image/"))
            {
                ModelState.AddModelError("File", "File must be image");
                return View();  
            }
            if (!file.CheckFileSize(2))
            {
                ModelState.AddModelError("File", "Image size must be max 2MB");
                return View();
            }
    
            slider.ImageUrl = file.SaveFile("image/bg-image");
      
            pustokDb.Sliders.Add(slider);
            pustokDb.SaveChanges();
            return RedirectToAction("index");
                
             
        }
        public IActionResult Delete(int id)
        {
            var slider = pustokDb.Sliders.Find(id);
            if (slider == null) return NotFound();
            pustokDb.Sliders.Remove(slider);
            pustokDb.SaveChanges();
            FileManager.DeleteFile("image/bg-images", slider.ImageUrl);
            return Ok();
        }
        public IActionResult Edit(int id)
        {
            var slider = pustokDb.Sliders.Find(id);
            if (slider == null) return NotFound();
            return View(slider);
        }
        [HttpPost]
        public IActionResult Edit(Slider slider)
        {
            if (!ModelState.IsValid) return View();
            var existSlider = pustokDb.Sliders.Find(slider.Id);
            if (existSlider == null) return NotFound();
            var file = slider.File;
            if (file != null)
            {
                if (!file.CheckContentType("image/"))
                {
                    ModelState.AddModelError("File", "file must be image");
                    return View();
                }
                if (!file.CheckFileSize(2))
                {
                    ModelState.AddModelError("file", "Image size must be max 2MB");
                    return View();

                }
                FileManager.DeleteFile("image/bg-images", existSlider.ImageUrl);
                existSlider.ImageUrl = file.SaveFile("image/bg-images");

            }
            existSlider.Title = slider.Title;
            existSlider.Description = slider.Description;
            existSlider.ButtonText = slider.ButtonText;
            existSlider.ButtonLInk = slider.ButtonLInk;
            existSlider.Order = slider.Order;

            pustokDb.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
