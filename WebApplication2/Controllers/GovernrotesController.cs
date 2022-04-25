#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class GovernrotesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GovernrotesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Governrotes
        public async Task<IActionResult> Index()
        {
            //List<Governrote> governrotes = new List<Governrote>()
            //{
            //    new Governrote(){Name="Cairo"},
            //    new Governrote(){Name="Gize"}
            //};
            return View(await _context.governrotes.ToListAsync());
        }

        // GET: Governrotes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var governrote = await _context.governrotes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (governrote == null)
            {
                return NotFound();
            }

            return View(governrote);
        }

        // GET: Governrotes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Governrotes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Governrote governrote)
        {
            if (ModelState.IsValid)
            {
                _context.Add(governrote);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(governrote);
        }

        // GET: Governrotes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var governrote = await _context.governrotes.FindAsync(id);
            if (governrote == null)
            {
                return NotFound();
            }
            return View(governrote);
        }

        // POST: Governrotes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Governrote governrote)
        {
            if (id != governrote.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(governrote);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GovernroteExists(governrote.Id))
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
            return View(governrote);
        }

        // GET: Governrotes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var governrote = await _context.governrotes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (governrote == null)
            {
                return NotFound();
            }

            return View(governrote);
        }

        // POST: Governrotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var governrote = await _context.governrotes.FindAsync(id);
            _context.governrotes.Remove(governrote);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GovernroteExists(int id)
        {
            return _context.governrotes.Any(e => e.Id == id);
        }
    }
}
