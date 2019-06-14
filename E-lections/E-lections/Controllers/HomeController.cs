using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using E_lections.Models;
using Microsoft.EntityFrameworkCore;

namespace E_lections.Controllers
{
    public class HomeController : Controller
    {
        private ELectionsDbContext context;
        public static Osoba currentlyLogged = null; 

        public HomeController(ELectionsDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Glasac o)
        {
            if(ModelState.IsValid)
            {
                context.Osoba.Add(o);
                context.SaveChangesAsync();
            }
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(String username, String password)
        {
            var osoba = context.Osoba.Include(o => o.Stranka).Where(o => o.JMBG.Equals(username) && o.Lozinka.Equals(password));
            var admin = context.Admin.Where(a => a.JMBG.Equals(username) && a.Lozinka.Equals(password));
            if (osoba.Count() == 0 && admin.Count() == 0)
            {
                ViewBag.Message = "Niste registrovani na sistem!";
                return View();
            }
            else if (osoba.Count() != 0)
            {
                currentlyLogged = osoba.First();
                if (currentlyLogged is Glasac) return View("../Glasac/Index", currentlyLogged);
                else return View("../Kandidat/Index", currentlyLogged);
            }
            return RedirectToAction("Index", "Admin");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
