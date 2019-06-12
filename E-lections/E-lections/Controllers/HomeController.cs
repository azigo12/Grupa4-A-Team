using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using E_lections.Models;

namespace E_lections.Controllers
{
    public class HomeController : Controller
    {
        private ELectionsDbContext context;

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
        public IActionResult Register(Osoba o)
        {

        }

        public IActionResult Login()
        {
            return RedirectToAction("Index", "Admin");
        }

        [HttpPost]
        public IActionResult Login(String username, String password)
        {
            //ovdje id provjera iz baze
            //TODO!
            return View("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
