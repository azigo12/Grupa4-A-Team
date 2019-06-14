using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using E_lections.Models;
using Microsoft.EntityFrameworkCore;

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

        public IActionResult Stranka()
        {
            return View(_context.Stranka.ToList());
        }

        public IActionResult UclaniSe(int id)
        {
            var stranka = _context.Stranka.Include(c => c.UpisiUStranku).FirstOrDefault(s => s.ID == id);
            //stranka.UpisiUStranku.Add(HomeController.currentlyLogged);
            _context.SaveChanges();
            return View("Index");
        }

        public IActionResult LogOut()
        {
            HomeController.currentlyLogged = null;
            return RedirectToAction("Index", "Home");
        }
    }
}