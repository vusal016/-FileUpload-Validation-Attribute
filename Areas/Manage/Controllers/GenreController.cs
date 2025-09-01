using Microsoft.AspNetCore.Mvc;
using PustokApp.Data;
using PustokApp.Models;

namespace PustokApp.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class GenreController(PustokDbContext pustokDb) : Controller
    {
        public IActionResult Index()
        {
            var genres = pustokDb.Genres.ToList();
            return View(genres);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Genre genre)
        {   if (!ModelState.IsValid)
                return View();
            if (pustokDb.Genres.Any(n => n.Name.ToLower() == genre.Name.ToLower()))
                return BadRequest();
            pustokDb.Genres.Add(genre);
            pustokDb.SaveChanges();
            return RedirectToAction(nameof(Index));  
        }
    }
}
