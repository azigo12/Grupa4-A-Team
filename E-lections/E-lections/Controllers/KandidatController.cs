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
        private static int? currentIzbor;

        public KandidatController(ELectionsDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View("Index", HomeController.currentlyLogged);
        }

        public IActionResult Izbori()
        {
            return View(_context.Izbor.Include(i => i.GlasackiListici).Include(i => i.Statistika).Where(i => i.Status == StatusIzbora.Aktivan).ToList());
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
            var osoba = _context.Kandidat.Where(k => k.ID == HomeController.currentlyLogged.ID).FirstOrDefault();
            stranka.UpisiUStranku.Add(osoba);
            _context.SaveChanges();
            return View("Index");
        }

        public IActionResult Detalji(int? id)
        {
            ViewBag.Listic = _context.Kandidat.FirstOrDefault(k => k.ID == HomeController.currentlyLogged.ID).GlasackiListicId;
            currentIzbor = id;
            return View(_context.GlasackiListic.Include(k => k.Kandidati).Where(i => i.IzborId == id).ToList());
        }

        public IActionResult Rezultati(int ?id)
        {
            var glasackiListic = _context.GlasackiListic.Include(g => g.Izbor).Include(g => g.Kandidati).Where(g => g.ID == id).FirstOrDefault();
            return View(glasackiListic.Kandidati);
        }

        public IActionResult DetaljiKandidata(int? id)
        {
            return View(_context.Kandidat.Where(k => k.GlasackiListicId == id).ToList());
        }

        public IActionResult Prijava(int? id)
        {
            Kandidat k = _context.Kandidat.Include(ka => ka.GlasackiListic).Where(ka => ka.ID == HomeController.currentlyLogged.ID).FirstOrDefault();
            if(k.GlasackiListic != null)
            {
                ViewBag.Message = "Već ste prijavljeni na izbore!";
                return View("Detalji", _context.GlasackiListic.Include(g => g.Kandidati).Where(i => i.IzborId == currentIzbor).ToList());
            }
            var glasackiListic = _context.GlasackiListic.Include(g => g.Kandidati).Include(g => g.Izbor).FirstOrDefault(g => g.ID == id);
            var izboriPoc = glasackiListic.Izbor.Pocetak;
            if(DateTime.Now > izboriPoc)
            {
                ViewBag.Message = "Prijave su završene!";
                return View("Detalji", _context.GlasackiListic.Include(g => g.Kandidati).Where(i => i.IzborId == currentIzbor).ToList());
            }
            glasackiListic.Kandidati.Add(k);
            _context.SaveChanges();
            ViewBag.Message = "Uspješno ste se prijavili na izbore!";
            return View("Detalji", _context.GlasackiListic.Include(g => g.Kandidati).Where(i => i.IzborId == currentIzbor).ToList());
        }

        public IActionResult Odjava(int? id)
        {
            Kandidat k = _context.Kandidat.Include(ka => ka.GlasackiListic).Where(ka => ka.ID == HomeController.currentlyLogged.ID).FirstOrDefault();
            var glasackiListic = _context.GlasackiListic.Include(g => g.Kandidati).FirstOrDefault(g => g.ID == id);
            glasackiListic.Kandidati.Remove(k);
            _context.SaveChanges();
            ViewBag.Message = "Odjavili ste sa izbora!";
            return View("izbori", _context.Izbor.Include(i => i.GlasackiListici).ToList());
        }

        public IActionResult LogOut()
        {
            HomeController.currentlyLogged = null;
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Glasaj(int? id)
        {
            var glasac = _context.Osoba.Include(g => g.HistorijaGlasanja).FirstOrDefault(g => g.ID == HomeController.currentlyLogged.ID);
            var opcije = _context.GlasackiListic.Include(g => g.Kandidati).Include(g => g.Izbor).Where(g => g.ID == id).FirstOrDefault();
            if(DateTime.Now < opcije.Izbor.Pocetak)
            {
                ViewBag.Glasao = "Izbori još nisu počeli!";
                return View("Detalji", _context.GlasackiListic.Include(k => k.Kandidati).Where(i => i.IzborId == currentIzbor).ToList());

            }
            if(DateTime.Now > opcije.Izbor.Pocetak.AddHours(12))
            {
                ViewBag.Glasao = "Izbori su završeni!";
                return View("Detalji", _context.GlasackiListic.Include(k => k.Kandidati).Where(i => i.IzborId == currentIzbor).ToList());
            }
            if (glasac.HistorijaGlasanja == null)
            {
                glasac.HistorijaGlasanja = new HistorijaGlasanja();
                glasac.HistorijaGlasanja.DodajGlas((int)id);
            }
            else
            {
                foreach (var listic in glasac.HistorijaGlasanja.DajGlasove())
                {
                    if (listic == id)
                    {
                        ViewBag.Glasao = "Već ste glasali na ovim izborima";
                        return View("Detalji", _context.GlasackiListic.Include(k => k.Kandidati).Where(i => i.IzborId == currentIzbor).ToList());
                    }
                }
                glasac.HistorijaGlasanja.DodajGlas((int)id);
            }
            _context.SaveChanges();
            return View(opcije);
        }

        [HttpPost]
        public IActionResult Glasaj(string[] glasovi)
        {
            List<int> lista = new List<int>();
            foreach (string s in glasovi)
            {
                lista.Add(Int32.Parse(s));
            }
            foreach (int id in lista)
            {
                var osoba = _context.Kandidat.FirstOrDefault(k => k.ID == id);
                osoba.brojGlasova++;
            }
            var izbor = _context.Izbor.Include(i => i.Statistika).Where(i => i.ID == currentIzbor).FirstOrDefault();
            var glas = _context.GlasackiListic.Where(i => i.IzborId == currentIzbor).FirstOrDefault();
            if (izbor.Statistika == null) izbor.Statistika = new Statistika();
            if (HomeController.currentlyLogged.Spol == Spol.Muski) izbor.Statistika.GlasoviMusko++;
            else izbor.Statistika.GlasoviZensko++;
            if (glasovi.Length == 0 || glasovi.Length > glas.MaxOdabir) izbor.Statistika.GlasoviNevalidni++;
            else izbor.Statistika.GlasoviValidni++;
            _context.SaveChanges();
            ViewBag.PorukaGlasanje = "Hvala što ste glasali!";
            return View("Detalji",_context.GlasackiListic.Include(k => k.Kandidati).Where(i => i.IzborId == currentIzbor).ToList());
        }

        public IActionResult Profil()
        {
            var kandidat = _context.Kandidat.Include(k => k.Profil).Where(k => k.ID == HomeController.currentlyLogged.ID).FirstOrDefault();
            if (kandidat.Profil == null) kandidat.Profil = new Profil();
            _context.SaveChanges();
            return View(kandidat.Profil);
        }

        [HttpPost]
        public IActionResult Profil(string profil)
        {
            var kandidat = _context.Kandidat.Include(k => k.Profil).Where(k => k.ID == HomeController.currentlyLogged.ID).FirstOrDefault();
            if (kandidat.Profil == null) kandidat.Profil = new Profil();
            kandidat.Profil.Opis = profil;
            _context.SaveChanges();
            return View("Index");
        }

        public IActionResult ProfilKandidata(int? id)
        {
            var kandidat = _context.Kandidat.Include(k => k.Profil).Where(k => k.ID == id).FirstOrDefault();
            return View(kandidat.Profil);
        }

        public IActionResult Izvjestaj(int id)
        {
            var izbor = _context.Izbor.Include(i => i.Statistika).Where(i => i.ID == id).FirstOrDefault();
            return View(izbor.Statistika);
        }

    }
}