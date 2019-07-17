using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Dividender.Data;
using Dividender.Models.Portfolio;
using Microsoft.AspNetCore.Authorization;

namespace Dividender.Views
{
    [Authorize]
    public class TradesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TradesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Trades
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Trades.Include(t => t.Ticker);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Trades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trade = await _context.Trades
                .Include(t => t.Ticker)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trade == null)
            {
                return NotFound();
            }

            return View(trade);
        }

        // GET: Trades/Create
        public IActionResult Create()
        {
            ViewData["TickerId"] = new SelectList(_context.Tickers, "Id", "Symbol");
            return View();
        }

        // POST: Trades/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Shares,PurchaseDate,PurchasePrice,SellDate,SellPrice,Target,Reason,Transaction,TickerId")] Trade trade)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trade);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TickerId"] = new SelectList(_context.Tickers, "Id", "Symbol", trade.TickerId);
            return View(trade);
        }

        // GET: Trades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trade = await _context.Trades.FindAsync(id);
            if (trade == null)
            {
                return NotFound();
            }
            ViewData["TickerId"] = new SelectList(_context.Tickers, "Id", "Symbol", trade.TickerId);
            return View(trade);
        }

        // POST: Trades/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Shares,PurchaseDate,PurchasePrice,SellDate,SellPrice,Target,Reason,Transaction,TickerId")] Trade trade)
        {
            if (id != trade.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trade);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TradeExists(trade.Id))
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
            ViewData["TickerId"] = new SelectList(_context.Tickers, "Id", "Symbol", trade.TickerId);
            return View(trade);
        }

        // GET: Trades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trade = await _context.Trades
                .Include(t => t.Ticker)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trade == null)
            {
                return NotFound();
            }

            return View(trade);
        }

        // POST: Trades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var trade = await _context.Trades.FindAsync(id);
            _context.Trades.Remove(trade);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TradeExists(int id)
        {
            return _context.Trades.Any(e => e.Id == id);
        }
    }
}
