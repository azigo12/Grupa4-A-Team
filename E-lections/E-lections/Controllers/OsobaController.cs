﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace E_lections.Controllers
{
    public abstract class OsobaController : Controller
    {
        public abstract IActionResult Index();

        public abstract IActionResult OdjaviSe();

        public abstract IActionResult Glasaj();

        public abstract IActionResult Stranka();
    }
}