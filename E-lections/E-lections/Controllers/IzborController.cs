﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace E_lections.Controllers
{
    public class IzborController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}