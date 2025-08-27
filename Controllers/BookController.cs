using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PustokApp.Data;

namespace PustokApp.Controllers
{
    public class BookController(PustokDbContext pustokDb) : Controller
    {
        public IActionResult Index(int? id)
        {
            if (id is null)
                return NotFound();
            var book = pustokDb.Books
                 .Include(b => b.Author)
                 .Include(b => b.Genre)
                 .Include(b => b.BookImages)
                 .FirstOrDefault(b => id == b.Id);
            if (book is null)
                return NotFound();

            return View(book);
        }
        public IActionResult Detail(int? id)
        {
            if (id is null)
                return NotFound();
            var book = pustokDb.Books
                 .Include(b => b.Author)
                 .Include(b => b.Genre)
                  .Include(b => b.BookImages)
                 .Include(b => b.BookTags)
                 .ThenInclude(bt => bt.Tag)
                 .FirstOrDefault(b => id == b.Id);
            if (book is null)
                return NotFound();

            return View(book);
        }
        public IActionResult BookModal(int? id)
        {
            if (id is null)
                return NotFound();
            var book = pustokDb.Books
                 .Include(b => b.Author)
                 .Include(b => b.Genre)
                  .Include(b => b.BookImages)
                 .Include(b => b.BookTags)
                 .ThenInclude(bt => bt.Tag)
                 .FirstOrDefault(b => id == b.Id);
            if (book is null)
                return NotFound();

            return PartialView("_BookModal",book);
        }
    }
}
