using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_lections.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_lections.Controllers
{
    public class AdminController : Controller
    {

        private ELectionsDbContext context;

        public AdminController(ELectionsDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult LogOut()
        {
            return RedirectToAction("Index", "Home");
        }

        public IActionResult DodajStranku()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DodajStranku(Stranka s)
        {
            context.Stranka.Add(s);
            context.SaveChanges();
            return View("Index");
        }

        public IActionResult Stranka()
        {
            return View(context.Stranka.ToList());
        }

        public IActionResult ObrisiStranku(int? id)
        {
            var stranka = context.Stranka.FirstOrDefault(s => s.ID == id);
            if (stranka != null) context.Stranka.Remove(stranka);
            context.SaveChanges();
            return View("Index");
        }

        public IActionResult DetaljiStranke(int? id)
        {
            var stranka = context.Stranka.FirstOrDefault(s => s.ID == id);
            return View(stranka);
        }

        public IActionResult Lista(string searching)
        {
            var osobe = context.Osoba.Where(o => searching == null || o.Prezime.Contains(searching));
            return View(osobe);
        }

        public IActionResult Kandidati()
        {
            var kandidati = context.Kandidat.ToList();
            return View(kandidati);
        }

    }
}