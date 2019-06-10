using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace E_lections.Controllers
{
    public class AdminController : Controller
    {
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
    }
}