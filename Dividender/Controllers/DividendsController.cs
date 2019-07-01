using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Dividender.Data;
using Dividender.Models.Portfolio;

namespace Dividender.Views
{
    public class DividendsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DividendsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Dividends
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Dividends.Include(d => d.Ticker);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Dividends/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dividend = await _context.Dividends
                .Include(d => d.Ticker)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dividend == null)
            {
                return NotFound();
            }

            return View(dividend);
        }

        // GET: Dividends/Create
        public IActionResult Create()
        {
            ViewData["TickerId"] = new SelectList(_context.Tickers, "Id", "Symbol");
            return View();
        }

        // POST: Dividends/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Shares,Amount,Date,TickerId")] Dividend dividend)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dividend);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TickerId"] = new SelectList(_context.Tickers, "Id", "Symbol", dividend.TickerId);
            return View(dividend);
        }

        // GET: Dividends/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dividend = await _context.Dividends.FindAsync(id);
            if (dividend == null)
            {
                return NotFound();
            }
            ViewData["TickerId"] = new SelectList(_context.Tickers, "Id", "Symbol", dividend.TickerId);
            return View(dividend);
        }

        // POST: Dividends/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Shares,Amount,Date,TickerId")] Dividend dividend)
        {
            if (id != dividend.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dividend);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DividendExists(dividend.Id))
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
            ViewData["TickerId"] = new SelectList(_context.Tickers, "Id", "Symbol", dividend.TickerId);
            return View(dividend);
        }

        // GET: Dividends/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dividend = await _context.Dividends
                .Include(d => d.Ticker)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dividend == null)
            {
                return NotFound();
            }

            return View(dividend);
        }

        // POST: Dividends/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dividend = await _context.Dividends.FindAsync(id);
            _context.Dividends.Remove(dividend);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DividendExists(int id)
        {
            return _context.Dividends.Any(e => e.Id == id);
        }
    }
}
