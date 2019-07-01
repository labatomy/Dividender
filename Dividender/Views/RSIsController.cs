using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Divendender.Models.Indicators;
using Dividender.Data;

namespace Dividender.Views
{
    public class RSIsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RSIsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RSIs
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.RSIs.Include(r => r.Ticker);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: RSIs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rSI = await _context.RSIs
                .Include(r => r.Ticker)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rSI == null)
            {
                return NotFound();
            }

            return View(rSI);
        }

        // GET: RSIs/Create
        public IActionResult Create()
        {
            ViewData["TickerId"] = new SelectList(_context.Tickers, "Id", "Id");
            return View();
        }

        // POST: RSIs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Time,Value,TickerId")] RSI rSI)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rSI);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TickerId"] = new SelectList(_context.Tickers, "Id", "Id", rSI.TickerId);
            return View(rSI);
        }

        // GET: RSIs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rSI = await _context.RSIs.FindAsync(id);
            if (rSI == null)
            {
                return NotFound();
            }
            ViewData["TickerId"] = new SelectList(_context.Tickers, "Id", "Id", rSI.TickerId);
            return View(rSI);
        }

        // POST: RSIs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Time,Value,TickerId")] RSI rSI)
        {
            if (id != rSI.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rSI);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RSIExists(rSI.Id))
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
            ViewData["TickerId"] = new SelectList(_context.Tickers, "Id", "Id", rSI.TickerId);
            return View(rSI);
        }

        // GET: RSIs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rSI = await _context.RSIs
                .Include(r => r.Ticker)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rSI == null)
            {
                return NotFound();
            }

            return View(rSI);
        }

        // POST: RSIs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rSI = await _context.RSIs.FindAsync(id);
            _context.RSIs.Remove(rSI);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RSIExists(int id)
        {
            return _context.RSIs.Any(e => e.Id == id);
        }
    }
}
