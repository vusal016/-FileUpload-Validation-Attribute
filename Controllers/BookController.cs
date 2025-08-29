using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PustokApp.Data;
using PustokApp.ViewModels;

namespace PustokApp.Controllers
{
    public class BookController(PustokDbContext pustokDb,
        IMapper mapper
        ) : Controller
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
            BookDetailVm bookDetailVm = new()
            {
                Book = book,
                RelatedBooks = pustokDb.Books
                .Where(b => b.GenreId == book.GenreId && b.Id != book.Id)
                .Include(b => b.BookImages)
                .Include(b => b.Author)
                .Include(b => b.Genre)
                .Include(b => b.BookTags)
                .ThenInclude(bt => bt.Tag)
                .ToList()
            };

            return View(bookDetailVm);
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

            return PartialView("_BookModal", book);
        }
        public IActionResult Test(int? id)
        {
            if (id is null)
                return NotFound();
            var book = pustokDb.Books
                .Include(b => b.BookImages)
                .Include(b => b.Author)
                .Include(b => b.Genre)
                .Include(b => b.BookTags)
                .ThenInclude(bt => bt.Tag)
                .FirstOrDefault(b => b.Id == id);
            if (book is null)
                return NotFound();
            BookTestVm bookTestVm = mapper.Map<BookTestVm>(book);
            return Ok(book);
         
        }
    }
}





