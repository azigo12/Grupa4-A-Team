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

            var izbor = await _context.Izbor
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

        // GET: Izbor/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var izbor = await _context.Izbor.FindAsync(id);
            if (izbor == null)
            {
                return NotFound();
            }
            return View(izbor);
        }

        // POST: Izbor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Pocetak,Opis,KantonOgranicenje,Status")] Izbor izbor)
        {
            if (id != izbor.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(izbor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IzborExists(izbor.ID))
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
            return View(izbor);
        }

       
        public async Task<IActionResult> Delete(int id)
        {
            var izbor = await _context.Izbor.FindAsync(id);
            _context.Izbor.Remove(izbor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IzborExists(int id)
        {
            return _context.Izbor.Any(e => e.ID == id);
        }
    }
}
