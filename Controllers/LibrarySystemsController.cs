using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Library_Management_System.Data;
using Library_Management_System.Models;

namespace Library_Management_System.Controllers
{
    public class LibrarySystemsController : Controller
    {
        private readonly Library_Management_SystemContext _context;

        public LibrarySystemsController(Library_Management_SystemContext context)
        {
            _context = context;
        }

        // GET: LibrarySystems
        public async Task<IActionResult> Index()
        {
            return View(await _context.LibrarySystem.ToListAsync());
        }

        // GET: LibrarySystems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var librarySystem = await _context.LibrarySystem
                .FirstOrDefaultAsync(m => m.Id == id);
            if (librarySystem == null)
            {
                return NotFound();
            }

            return View(librarySystem);
        }

        // GET: LibrarySystems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LibrarySystems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BorrowerName,BookTitle,Author,BorrowDate,ReturnDate")] LibrarySystem librarySystem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(librarySystem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(librarySystem);
        }

        // GET: LibrarySystems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var librarySystem = await _context.LibrarySystem.FindAsync(id);
            if (librarySystem == null)
            {
                return NotFound();
            }
            return View(librarySystem);
        }

        // POST: LibrarySystems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BorrowerName,BookTitle,Author,BorrowDate,ReturnDate")] LibrarySystem librarySystem)
        {
            if (id != librarySystem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(librarySystem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LibrarySystemExists(librarySystem.Id))
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
            return View(librarySystem);
        }

        // GET: LibrarySystems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var librarySystem = await _context.LibrarySystem
                .FirstOrDefaultAsync(m => m.Id == id);
            if (librarySystem == null)
            {
                return NotFound();
            }

            return View(librarySystem);
        }

        // POST: LibrarySystems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var librarySystem = await _context.LibrarySystem.FindAsync(id);
            if (librarySystem != null)
            {
                _context.LibrarySystem.Remove(librarySystem);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LibrarySystemExists(int id)
        {
            return _context.LibrarySystem.Any(e => e.Id == id);
        }

        //---

        // GET: LibrarySystems/Filtered
        public IActionResult Filtered(string category = "All")
        {
            // Pull all records into memory
            var records = _context.LibrarySystem.ToList();

            // Apply filter on computed properties in C#
            if (!string.IsNullOrEmpty(category) && category != "All")
            {
                records = records.Where(r => r.BorrowDurationCategory == category).ToList();
            }

            return View(records);
        }


    }
}
