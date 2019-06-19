using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using E_lections.Models;

namespace E_lections.Controllers
{
    public class IzborController : Controller
    {
        private readonly ELectionsDbContext _context;

        public IzborController(ELectionsDbContext context)
        {
            _context = context;
        }

        // GET: Izbor
        public async Task<IActionResult> Index()
        {
            return View(await _context.Izbor.ToListAsync());
        }

        // GET: Izbor/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var izbor = await _context.Izbor.Include(g => g.GlasackiListici)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (izbor == null)
            {
                return NotFound();
            }
            return View(izbor);
        }

        // GET: Izbor/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Izbor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Pocetak,Opis,KantonOgranicenje,Status")] Izbor izbor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(izbor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(izbor);
        }

       
        public async Task<IActionResult> Delete(int id)
        {
            var izbor = await _context.Izbor.FindAsync(id);
            _context.Izbor.Remove(izbor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Izvjestaj(int id)
        {
            var izbor = _context.Izbor.Include(i => i.Statistika).Where(i => i.ID == id).FirstOrDefault();
            if (izbor.Statistika == null) izbor.Statistika = new Statistika();
            if (izbor.Pocetak > DateTime.Now) ViewBag.Izvjestaj = "Izbori nisu počeli!";
            else
            {
                ViewBag.Izvjestaj = "Izvještaj je generisan!";
                izbor.Statistika.Visible = true;
                _context.SaveChanges();
            }
            return View("Index", _context.Izbor.Include(g => g.GlasackiListici).ToList());
        }
        
        public IActionResult IzvView(int id)
        {
            var izbor = _context.Izbor.Include(i => i.Statistika).Where(i => i.ID == id).FirstOrDefault();
            if (izbor.Statistika == null) izbor.Statistika = new Statistika();
            return View(izbor.Statistika);
        }

        private bool IzborExists(int id)
        {
            return _context.Izbor.Any(e => e.ID == id);
        }
    }
}
