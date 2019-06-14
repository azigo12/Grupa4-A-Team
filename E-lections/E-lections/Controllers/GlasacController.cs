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

        public IActionResult NapustiStranku()
        {
            if(HomeController.currentlyLogged.StrankaId == null)
                ViewBag.Message = "Niste član niti jedne stranke!";
            else
            {
                ViewBag.Message = "Napustili ste stranku!";
                HomeController.currentlyLogged.Stranka.UpisiUStranku.Remove(HomeController.currentlyLogged);
                HomeController.currentlyLogged.StrankaId = null;
                HomeController.currentlyLogged.Stranka = null;
                _context.SaveChanges();
            }
            return View("Index");
        }

        public IActionResult UclaniSe(int id)
        {
            if(HomeController.currentlyLogged.StrankaId != null)
            {
                ViewBag.Message = "Već ste član stranke!";
                return View("Stranka", _context.Stranka.ToList());
            }
            var stranka = _context.Stranka.Include(c => c.UpisiUStranku).FirstOrDefault(s => s.ID == id);
            stranka.UpisiUStranku.Add(HomeController.currentlyLogged);
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