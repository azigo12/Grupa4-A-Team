using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using E_lections.Models;

namespace E_lections.Controllers
{
    public class GlasacController : Controller
    {
        private ELectionsDbContext _context;

        public GlasacController(ELectionsDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View("Index", HomeController.currentlyLogged);
        }

        public IActionResult LogOut()
        {
            HomeController.currentlyLogged = null;
            return RedirectToAction("Index", "Home");
        }
    }
}