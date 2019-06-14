using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using E_lections.Models;

namespace E_lections.Controllers
{
    public class KandidatController : Controller
    {

        private ELectionsDbContext _context;

        public KandidatController(ELectionsDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Izbori()
        {
            return View(_context.Izbor.Include(i => i.GlasackiListici).Where(i => i.Status == StatusIzbora.Aktivan).ToList());
        }

        public IActionResult Stranka()
        {
            return View(_context.Stranka.ToList());
        }

        public IActionResult NapustiStranku()
        {
            if (HomeController.currentlyLogged.StrankaId == null)
                ViewBag.Message = "Niste član niti jedne stranke!";
            else
            {
                ViewBag.Message = "Napustili ste stranku!";
                var stranka = _context.Stranka.Include(c => c.UpisiUStranku).FirstOrDefault(s => s.ID == HomeController.currentlyLogged.StrankaId);
                var osoba = stranka.UpisiUStranku.First(o => o.StrankaId == HomeController.currentlyLogged.StrankaId);
                stranka.UpisiUStranku.Remove(osoba);
                _context.SaveChanges();
                HomeController.currentlyLogged.StrankaId = null;
                HomeController.currentlyLogged.Stranka = null;
            }
            return View("Index");
        }

        public IActionResult UclaniSe(int id)
        {
            if (HomeController.currentlyLogged.StrankaId != null)
            {
                ViewBag.Message = "Već ste član stranke!";
                return View("Stranka", _context.Stranka.ToList());
            }
            var stranka = _context.Stranka.Include(c => c.UpisiUStranku).FirstOrDefault(s => s.ID == id);
            stranka.UpisiUStranku.Add(HomeController.currentlyLogged);
            _context.SaveChanges();
            return View("Index");
        }

        public IActionResult Detalji(int? id)
        {
            return View(_context.GlasackiListic.Include(k => k.Kandidati).Where(i => i.IzborId == id).ToList());
        }

        public IActionResult DetaljiKandidata(int? id)
        {
            return View(_context.Kandidat.Where(k => k.GlasackiListicId == id).ToList());
        }

        public IActionResult LogOut()
        {
            HomeController.currentlyLogged = null;
            return RedirectToAction("Index", "Home");
        }
    }
}