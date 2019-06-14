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
            if(HomeController.currentlyLogged.StrankaId == null)
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

        public IActionResult Prijava()
        {
            var glasac = _context.Glasac.FirstOrDefault(i => i.ID == HomeController.currentlyLogged.ID);
            Kandidat k = getKandidat(glasac);
            _context.Kandidat.Add(k);
            _context.Glasac.Remove(glasac);
            _context.SaveChanges();
            HomeController.currentlyLogged = k;
            return RedirectToAction("Change", "Home");
        }

        public IActionResult Glasaj()
        {
            return View();
        }

        private Kandidat getKandidat(Osoba osoba)
        {
            Kandidat k = new Kandidat();
            k.Ime = osoba.Ime;
            k.Prezime = osoba.Prezime;
            k.DatumRodjenja = osoba.DatumRodjenja;
            k.JMBG = osoba.JMBG;
            k.BrojLicneKarte = osoba.BrojLicneKarte;
            k.BirackoMjestoID = osoba.BirackoMjestoID;
            k.StrankaId = osoba.StrankaId;
            k.Spol = osoba.Spol;
            k.Ulica = osoba.Ulica;
            k.Kanton = osoba.Kanton;
            k.Lozinka = osoba.Lozinka;
            return k;
        }

    }
}