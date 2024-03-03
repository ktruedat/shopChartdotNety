using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using shopChart.Data;

namespace shopChart
{
    public class ProducersDbController : Controller
    {
        private readonly ProductContext _context;

        public ProducersDbController(ProductContext context)
        {
            _context = context;
        }

        // GET: ProducersDb
        public async Task<IActionResult> Index()
        {
              return _context.Producers != null ? 
                          View(await _context.Producers.ToListAsync()) :
                          Problem("Entity set 'ProductContext.Producers'  is null.");
        }

        // GET: ProducersDb/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Producers == null)
            {
                return NotFound();
            }

            var producer = await _context.Producers
                .FirstOrDefaultAsync(m => m.ProducerID == id);
            if (producer == null)
            {
                return NotFound();
            }

            return View(producer);
        }

        // GET: ProducersDb/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProducersDb/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProducerID,ProducerName,ProducerLocation")] Producer producer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(producer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(producer);
        }

        // GET: ProducersDb/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Producers == null)
            {
                return NotFound();
            }

            var producer = await _context.Producers.FindAsync(id);
            if (producer == null)
            {
                return NotFound();
            }
            return View(producer);
        }

        // POST: ProducersDb/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProducerID,ProducerName,ProducerLocation")] Producer producer)
        {
            if (id != producer.ProducerID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(producer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProducerExists(producer.ProducerID))
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
            return View(producer);
        }

        // GET: ProducersDb/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Producers == null)
            {
                return NotFound();
            }

            var producer = await _context.Producers
                .FirstOrDefaultAsync(m => m.ProducerID == id);
            if (producer == null)
            {
                return NotFound();
            }

            return View(producer);
        }

        // POST: ProducersDb/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Producers == null)
            {
                return Problem("Entity set 'ProductContext.Producers'  is null.");
            }
            var producer = await _context.Producers.FindAsync(id);
            if (producer != null)
            {
                _context.Producers.Remove(producer);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProducerExists(int id)
        {
          return (_context.Producers?.Any(e => e.ProducerID == id)).GetValueOrDefault();
        }
    }
}
