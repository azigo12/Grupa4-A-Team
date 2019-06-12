using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_lections.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_lections.Controllers
{
    public class IzborController : Controller
    {

        private ELectionsDbContext context;
        private int idTrenutnog;

        public IzborController(ELectionsDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index(int idIzbora)
        {
            idTrenutnog = idIzbora;
            ViewBag.id = idTrenutnog;
            return View();
        }

        public IActionResult Detalji(ICollection<GlasackiListic> gl)
        {
            var trenutni = context.Izbor.FirstOrDefault(i => i.ID == idTrenutnog);
            return View(trenutni.GlasackiListici);
        }

        public IActionResult Info(int id)
        {
            var glasackiListic = context.GlasackiListic.FirstOrDefault(l => l.ID == id);
            return View(glasackiListic.Kandidati);
        }

        public IActionResult Kreiraj()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Kreiraj(GlasackiListic gl)
        {
            gl.IzborId = idTrenutnog;
            context.GlasackiListic.Add(gl);
            context.SaveChanges();
            return View("Index");
        }
    }
}