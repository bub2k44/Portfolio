using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Portfolio.Data;
using Portfolio.Models;

namespace Portfolio.Controllers
{
    public class HighScoresController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HighScoresController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: HighScores
        public async Task<IActionResult> Index()
        {
              return View(await _context.HighScore.ToListAsync());
        }

        // GET: HighScores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.HighScore == null)
            {
                return NotFound();
            }

            var highScore = await _context.HighScore
                .FirstOrDefaultAsync(m => m.Id == id);
            if (highScore == null)
            {
                return NotFound();
            }

            return View(highScore);
        }

        // GET: HighScores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HighScores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Initials,Score")] HighScore highScore)
        {
            if (ModelState.IsValid)
            {
                _context.Add(highScore);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(highScore);
        }

        // GET: HighScores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.HighScore == null)
            {
                return NotFound();
            }

            var highScore = await _context.HighScore.FindAsync(id);
            if (highScore == null)
            {
                return NotFound();
            }
            return View(highScore);
        }

        // POST: HighScores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Initials,Score")] HighScore highScore)
        {
            if (id != highScore.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(highScore);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HighScoreExists(highScore.Id))
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
            return View(highScore);
        }

        // GET: HighScores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.HighScore == null)
            {
                return NotFound();
            }

            var highScore = await _context.HighScore
                .FirstOrDefaultAsync(m => m.Id == id);
            if (highScore == null)
            {
                return NotFound();
            }

            return View(highScore);
        }

        // POST: HighScores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.HighScore == null)
            {
                return Problem("Entity set 'ApplicationDbContext.HighScore'  is null.");
            }
            var highScore = await _context.HighScore.FindAsync(id);
            if (highScore != null)
            {
                _context.HighScore.Remove(highScore);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HighScoreExists(int id)
        {
          return _context.HighScore.Any(e => e.Id == id);
        }
    }
}
