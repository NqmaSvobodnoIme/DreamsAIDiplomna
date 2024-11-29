using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DreamsAI.Data;
using DreamsAI.Models;

namespace DreamsAI.Controllers
{
    public class DreamsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DreamsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Dreams
        public async Task<IActionResult> Index()
        {
            return View(await _context.Dream.ToListAsync());
        }

        // GET: Dreams/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dream = await _context.Dream
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dream == null)
            {
                return NotFound();
            }

            return View(dream);
        }

        // GET: Dreams/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Dreams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Dream model)
        {
            if (ModelState.IsValid)
            {
                // Запазване в базата данни
                _context.Dream.Add(model);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: Dreams/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dream = await _context.Dream.FindAsync(id);
            if (dream == null)
            {
                return NotFound();
            }
            return View(dream);
        }

        // POST: Dreams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,CreatedAt")] Dream dream)
        {
            if (id != dream.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dream);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DreamExists(dream.Id))
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
            return View(dream);
        }

        // GET: Dreams/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dream = await _context.Dream
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dream == null)
            {
                return NotFound();
            }

            return View(dream);
        }

        // POST: Dreams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dream = await _context.Dream.FindAsync(id);
            if (dream != null)
            {
                _context.Dream.Remove(dream);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DreamExists(int id)
        {
            return _context.Dream.Any(e => e.Id == id);
        }
    }
}
