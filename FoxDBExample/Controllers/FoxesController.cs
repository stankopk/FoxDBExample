using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FoxDBExample.Data;
using FoxDBExample.Models;

namespace FoxDBExample.Controllers
{
    public class FoxesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FoxesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Foxes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Fox.ToListAsync());
        }

        // GET: Foxes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fox = await _context.Fox
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fox == null)
            {
                return NotFound();
            }

            return View(fox);
        }

        // GET: Foxes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Foxes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Age")] Fox fox)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fox);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fox);
        }

        // GET: Foxes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fox = await _context.Fox.FindAsync(id);
            if (fox == null)
            {
                return NotFound();
            }
            return View(fox);
        }

        // POST: Foxes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Age")] Fox fox)
        {
            if (id != fox.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fox);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FoxExists(fox.Id))
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
            return View(fox);
        }

        // GET: Foxes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fox = await _context.Fox
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fox == null)
            {
                return NotFound();
            }

            return View(fox);
        }

        // POST: Foxes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fox = await _context.Fox.FindAsync(id);
            if (fox != null)
            {
                _context.Fox.Remove(fox);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FoxExists(int id)
        {
            return _context.Fox.Any(e => e.Id == id);
        }
    }
}
