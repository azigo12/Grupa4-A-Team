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

        public IzborController(ELectionsDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index(int id)
        {
            var izbor = context.Izbor.FirstOrDefault(i => i.ID == id);
            return View("Detalji", izbor);
        }

        public IActionResult Detalji(Izbor izbor)
        {
            return View(izbor.GlasackiListici);
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
            context.GlasackiListic.Add(gl);
            context.SaveChanges();
            return View("Index");
        }
    }
}