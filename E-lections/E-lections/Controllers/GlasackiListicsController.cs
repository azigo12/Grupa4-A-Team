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

            return View(glasackiListic);
        }

        // GET: GlasackiListics/Create
        public IActionResult Create()
        {
            ViewData["IzborId"] = new SelectList(_context.Izbor, "ID", "KantonOgranicenje");
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
            ViewData["IzborId"] = new SelectList(_context.Izbor, "ID", "KantonOgranicenje", glasackiListic.IzborId);
            return View(glasackiListic);
        }

        // GET: GlasackiListics/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var glasackiListic = await _context.GlasackiListic.FindAsync(id);
            if (glasackiListic == null)
            {
                return NotFound();
            }
            ViewData["IzborId"] = new SelectList(_context.Izbor, "ID", "KantonOgranicenje", glasackiListic.IzborId);
            return View(glasackiListic);
        }

        // POST: GlasackiListics/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,MaxOdabir,BrojGlasova,Opis,IzborId")] GlasackiListic glasackiListic)
        {
            if (id != glasackiListic.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(glasackiListic);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GlasackiListicExists(glasackiListic.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IzborId"] = new SelectList(_context.Izbor, "ID", "KantonOgranicenje", glasackiListic.IzborId);
            return View(glasackiListic);
        }

        // GET: GlasackiListics/Delete/5
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

            return View(glasackiListic);
        }

        // POST: GlasackiListics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var glasackiListic = await _context.GlasackiListic.FindAsync(id);
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
