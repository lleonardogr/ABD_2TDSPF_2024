using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PrimeiraAppWeb_2TDSPF.Data;
using PrimeiraAppWeb_2TDSPF.Models;

namespace PrimeiraAppWeb_2TDSPF.Controllers
{
    public class BoardgameController : Controller
    {
        private readonly BoardgameDbContext _context;

        public BoardgameController(BoardgameDbContext context)
        {
            _context = context;
        }

        // GET: Boardgame
        public async Task<IActionResult> Index()
        {
            return View(await _context.Boardgames.ToListAsync());
        }

        // GET: Boardgame/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boardgame = await _context.Boardgames
                .FirstOrDefaultAsync(m => m.Id == id);
            if (boardgame == null)
            {
                return NotFound();
            }

            return View(boardgame);
        }

        // GET: Boardgame/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Boardgame/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description")] Boardgame boardgame)
        {
            if (ModelState.IsValid)
            {
                _context.Add(boardgame);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(boardgame);
        }

        // GET: Boardgame/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boardgame = await _context.Boardgames.FindAsync(id);
            if (boardgame == null)
            {
                return NotFound();
            }
            return View(boardgame);
        }

        // POST: Boardgame/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description")] Boardgame boardgame)
        {
            if (id != boardgame.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(boardgame);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BoardgameExists(boardgame.Id))
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
            return View(boardgame);
        }

        // GET: Boardgame/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boardgame = await _context.Boardgames
                .FirstOrDefaultAsync(m => m.Id == id);
            if (boardgame == null)
            {
                return NotFound();
            }

            return View(boardgame);
        }

        // POST: Boardgame/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var boardgame = await _context.Boardgames.FindAsync(id);
            if (boardgame != null)
            {
                _context.Boardgames.Remove(boardgame);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BoardgameExists(int id)
        {
            return _context.Boardgames.Any(e => e.Id == id);
        }
    }
}
