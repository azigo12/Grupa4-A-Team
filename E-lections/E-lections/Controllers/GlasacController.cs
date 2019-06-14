using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace E_lections.Controllers
{
    public class GlasacController : Controller
    {
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