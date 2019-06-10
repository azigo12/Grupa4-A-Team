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
            return View(izbor);
        }
    }
}