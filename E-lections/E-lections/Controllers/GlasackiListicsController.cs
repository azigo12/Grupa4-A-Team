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
    public class GlasackiListicsController : Controller
    {
        private readonly ELectionsDbContext _context;

        public GlasackiListicsController(ELectionsDbContext context)
        {
            _context = context;
        }

        // GET: GlasackiListics
        public async Task<IActionResult> Index()
        {
            var eLectionsDbContext = _context.GlasackiListic.Include(g => g.Izbor);
            return View(await eLectionsDbContext.ToListAsync());
        }

        // GET: GlasackiListics/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var glasackiListic = await _context.GlasackiListic
                .Include(g => g.Izbor)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (glasackiListic == null)
            {
                return NotFound();
            }
            glasackiListic.Kandidati = _context.Kandidat.Where(k => k.GlasackiListicId == id).ToList();
            return View(glasackiListic);
        }

        // GET: GlasackiListics/Create
        public IActionResult Create()
        {
            ViewData["IzborId"] = new SelectList(_context.Izbor, "ID", "Opis");
            return View();
        }

        // POST: GlasackiListics/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,MaxOdabir,BrojGlasova,Opis,IzborId")] GlasackiListic glasackiListic)
        {
            if (ModelState.IsValid)
            {
                _context.Add(glasackiListic);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IzborId"] = new SelectList(_context.Izbor, "ID", "Opis", glasackiListic.IzborId);
            return View(glasackiListic);
        }

        public IActionResult Rezultati(int id)
        {
            var glasackiListic = _context.GlasackiListic.Include(k => k.Kandidati).Include(k => k.Izbor).Where(g => g.ID == id).FirstOrDefault();
            if(glasackiListic.Izbor.Pocetak > DateTime.Now)
            {
                ViewBag.Msg = "Izbori nisu počeli!";
                return View("Index");
            }
            return View(glasackiListic);
        }
       
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var glasackiListic = await _context.GlasackiListic
                .Include(g => g.Izbor)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (glasackiListic == null)
            {
                return NotFound();
            }
            _context.GlasackiListic.Remove(glasackiListic);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GlasackiListicExists(int id)
        {
            return _context.GlasackiListic.Any(e => e.ID == id);
        }
    }
}
