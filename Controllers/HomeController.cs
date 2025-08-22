using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PustokApp.Data;
using PustokApp.Models;
using PustokApp.ViewModels;
using System.Diagnostics;

namespace PustokApp.Controllers
{
    public class HomeController(PustokDbContext pustokDb) : Controller
    {
        public IActionResult Index()
        {
            HomeVm homevm = new()
            {
                Sliders = pustokDb.Sliders.ToList()
            };
            return View(homevm);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
