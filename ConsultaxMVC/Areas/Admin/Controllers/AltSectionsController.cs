using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ConsultaxMVC.Data;
using ConsultaxMVC.Models;

namespace ConsultaxMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AltSectionsController : Controller
    {
        private readonly ConsultaxTable _context;

        public AltSectionsController(ConsultaxTable context)
        {
            _context = context;
        }

        // GET: Admin/AltSections
        public async Task<IActionResult> Index()
        {
            return View(await _context.AltSections.ToListAsync());
        }

        // GET: Admin/AltSections/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var altSection = await _context.AltSections
                .FirstOrDefaultAsync(m => m.ID == id);
            if (altSection == null)
            {
                return NotFound();
            }

            return View(altSection);
        }

        // GET: Admin/AltSections/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/AltSections/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Header,Title,Icon")] AltSection altSection)
        {
            if (ModelState.IsValid)
            {
                _context.Add(altSection);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(altSection);
        }

        // GET: Admin/AltSections/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var altSection = await _context.AltSections.FindAsync(id);
            if (altSection == null)
            {
                return NotFound();
            }
            return View(altSection);
        }

        // POST: Admin/AltSections/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Header,Title,Icon")] AltSection altSection)
        {
            if (id != altSection.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(altSection);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AltSectionExists(altSection.ID))
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
            return View(altSection);
        }

        // GET: Admin/AltSections/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var altSection = await _context.AltSections
                .FirstOrDefaultAsync(m => m.ID == id);
            if (altSection == null)
            {
                return NotFound();
            }

            return View(altSection);
        }

        // POST: Admin/AltSections/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var altSection = await _context.AltSections.FindAsync(id);
            _context.AltSections.Remove(altSection);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AltSectionExists(int id)
        {
            return _context.AltSections.Any(e => e.ID == id);
        }
    }
}
