using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using E_lections.Models;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;
using System.Net;

namespace E_lections.Controllers
{
    public class HomeController : Controller
    {
        private ELectionsDbContext context;
        public static Osoba currentlyLogged = null;
        private static int code;
        private static Glasac glasacKojiSeDodaje;

        public HomeController(ELectionsDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Glasac o)
        {
            string msg = null;
            if(IsValid(o, ref msg) == false)
            {
                ViewBag.Reg = msg;
                return View();
            }
            if(ModelState.IsValid)
            {
                glasacKojiSeDodaje = o;
                Random rnd = new Random();
                code = rnd.Next(10000, 99999);
                return RedirectToAction("SendEmail", "Home");
            }
            return View();
        }

        public IActionResult SendEmail() 
        {
            var fromAddress = new MailAddress("ooad.elections@gmail.com", "Elections");
            var toAddress = new MailAddress(glasacKojiSeDodaje.EMail, null);
            const string fromPassword = "ooad2019.";
            const string subject = "Kod za pristup računu";
            string body = "Za aktivaciju računa unesite sljedeći kod: " + code;

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }

            return View();
        }

        [HttpPost]
        public IActionResult SendEmail(string aktivacijskiKod)
        {
            if (code == Int32.Parse(aktivacijskiKod))
            {
                context.Glasac.Add(glasacKojiSeDodaje);
                context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(String username, String password)
        {
            var osoba = context.Osoba.Include(o => o.Stranka).Where(o => o.JMBG.Equals(username) && o.Lozinka.Equals(password));
            var admin = context.Admin.Where(a => a.JMBG.Equals(username) && a.Lozinka.Equals(password));
            if (osoba.Count() == 0 && admin.Count() == 0)
            {
                ViewBag.Message = "Niste registrovani na sistem!";
                return View();
            }
            else if (osoba.Count() != 0)
            {
                currentlyLogged = osoba.First();
                if (currentlyLogged is Glasac) return RedirectToAction("Index", "Glasac");
                else return RedirectToAction("Index", "Kandidat");
            }
            return RedirectToAction("Index", "Admin");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Change()
        {
            return RedirectToAction("Index", "Kandidat");
        }

        private bool IsValid(Glasac g, ref string msg)
        {
            if(g.Ime == null || g.Ime == "")
            {
                msg = "Unesite ime!";
                return false;
            }
            if (g.Prezime == null || g.Ime == "")
            {
                msg = "Unesite prezime!";
                return false;
            }
            DateTime now = DateTime.Today;
            DateTime glasac = (DateTime)g.DatumRodjenja;
            int age = now.Year - glasac.Year;
            if (glasac > now.AddYears(-age)) age--;
            if(age < 18)
            {
                msg = "Niste punoljetni!";
                return false;
            }
            return true;
        }
    }
}
