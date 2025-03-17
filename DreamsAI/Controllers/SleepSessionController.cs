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
    public class SleepSessionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SleepSessionController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SleepSession
        public async Task<IActionResult> Index()
        {
            return View(await _context.SleepSessions.ToListAsync());
        }

        // GET: SleepSession/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sleepSession = await _context.SleepSessions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sleepSession == null)
            {
                return NotFound();
            }

            return View(sleepSession);
        }

        // GET: SleepSession/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SleepSession/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BedTime,WakeUpTime,UserId,Id,SleepQuality,Duration")] SleepSession sleepSession)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sleepSession);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sleepSession);
        }

        // GET: SleepSession/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sleepSession = await _context.SleepSessions.FindAsync(id);
            if (sleepSession == null)
            {
                return NotFound();
            }
            return View(sleepSession);
        }

        // POST: SleepSession/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BedTime,WakeUpTime,UserId,Id,SleepQuality,Duration")] SleepSession sleepSession)
        {
            if (id != sleepSession.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sleepSession);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SleepSessionExists(sleepSession.Id))
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
            return View(sleepSession);
        }

        // GET: SleepSession/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sleepSession = await _context.SleepSessions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sleepSession == null)
            {
                return NotFound();
            }

            return View(sleepSession);
        }

        // POST: SleepSession/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sleepSession = await _context.SleepSessions.FindAsync(id);
            if (sleepSession != null)
            {
                _context.SleepSessions.Remove(sleepSession);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SleepSessionExists(int id)
        {
            return _context.SleepSessions.Any(e => e.Id == id);
        }
    }
}
