using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Concert.Web.Data;
using Concert.Web.Models;

namespace Concert.Web.Controllers
{
    public class ConcertController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ConcertController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Concert
        public async Task<IActionResult> Index()
        {
            return View(await _context.Concerts.ToListAsync());
        }

        // GET: Concert/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var concertModel = await _context.Concerts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (concertModel == null)
            {
                return NotFound();
            }

            return View(concertModel);
        }

        // GET: Concert/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Concert/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ConcertName,ConcertDate,ConcertPrice,ConcertPlace,ConcertUrl")] ConcertModel concertModel)
        {
            if (ModelState.IsValid)
            {
                concertModel.Id = Guid.NewGuid();
                _context.Add(concertModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(concertModel);
        }

        // GET: Concert/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var concertModel = await _context.Concerts.FindAsync(id);
            if (concertModel == null)
            {
                return NotFound();
            }
            return View(concertModel);
        }

        // POST: Concert/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,ConcertName,ConcertDate,ConcertPrice,ConcertPlace,ConcertUrl")] ConcertModel concertModel)
        {
            if (id != concertModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(concertModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConcertModelExists(concertModel.Id))
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
            return View(concertModel);
        }

        // GET: Concert/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var concertModel = await _context.Concerts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (concertModel == null)
            {
                return NotFound();
            }

            return View(concertModel);
        }

        // POST: Concert/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var concertModel = await _context.Concerts.FindAsync(id);
            if (concertModel != null)
            {
                _context.Concerts.Remove(concertModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConcertModelExists(Guid id)
        {
            return _context.Concerts.Any(e => e.Id == id);
        }
    }
}
