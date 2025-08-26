using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PustokApp.Data;

namespace PustokApp.Controllers
{
    public class BookController(PustokDbContext pustokDb) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Detail(int? id)
        {
            if (id is null)
                return NotFound();
            var book = pustokDb.Books
                 .Include(b => b.Author)
                 .Include(b => b.Genre)
                 .FirstOrDefault(b => id == b.Id);
            if (book is null)
                return NotFound();

            return View(book);
        }
    }
}
