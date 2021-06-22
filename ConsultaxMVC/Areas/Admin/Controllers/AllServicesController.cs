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
    public class AllServicesController : Controller
    {
        private readonly ConsultaxTable _context;

        public AllServicesController(ConsultaxTable context)
        {
            _context = context;
        }

        // GET: Admin/AllServices
        public async Task<IActionResult> Index()
        {
            return View(await _context.AllServices.ToListAsync());
        }

        // GET: Admin/AllServices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var allService = await _context.AllServices
                .FirstOrDefaultAsync(m => m.ID == id);
            if (allService == null)
            {
                return NotFound();
            }

            return View(allService);
        }

        // GET: Admin/AllServices/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/AllServices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Header,Title,Icon")] AllService allService)
        {
            if (ModelState.IsValid)
            {
                _context.Add(allService);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(allService);
        }

        // GET: Admin/AllServices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var allService = await _context.AllServices.FindAsync(id);
            if (allService == null)
            {
                return NotFound();
            }
            return View(allService);
        }

        // POST: Admin/AllServices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Header,Title,Icon")] AllService allService)
        {
            if (id != allService.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(allService);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AllServiceExists(allService.ID))
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
            return View(allService);
        }

        // GET: Admin/AllServices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var allService = await _context.AllServices
                .FirstOrDefaultAsync(m => m.ID == id);
            if (allService == null)
            {
                return NotFound();
            }

            return View(allService);
        }

        // POST: Admin/AllServices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var allService = await _context.AllServices.FindAsync(id);
            _context.AllServices.Remove(allService);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AllServiceExists(int id)
        {
            return _context.AllServices.Any(e => e.ID == id);
        }
    }
}
