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
    public class WhoWeAresController : Controller
    {
        private readonly ConsultaxTable _context;

        public WhoWeAresController(ConsultaxTable context)
        {
            _context = context;
        }

        // GET: Admin/WhoWeAres
        public async Task<IActionResult> Index()
        {
            return View(await _context.whoWeAres.ToListAsync());
        }

        // GET: Admin/WhoWeAres/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var whoWeAre = await _context.whoWeAres
                .FirstOrDefaultAsync(m => m.ID == id);
            if (whoWeAre == null)
            {
                return NotFound();
            }

            return View(whoWeAre);
        }

        // GET: Admin/WhoWeAres/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/WhoWeAres/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,SubHeader,Header,Title,Name,WorkName,SignaturePhoto,PhotoUrl")] WhoWeAre whoWeAre)
        {
            if (ModelState.IsValid)
            {
                _context.Add(whoWeAre);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(whoWeAre);
        }

        // GET: Admin/WhoWeAres/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var whoWeAre = await _context.whoWeAres.FindAsync(id);
            if (whoWeAre == null)
            {
                return NotFound();
            }
            return View(whoWeAre);
        }

        // POST: Admin/WhoWeAres/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,SubHeader,Header,Title,Name,WorkName,SignaturePhoto,PhotoUrl")] WhoWeAre whoWeAre)
        {
            if (id != whoWeAre.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(whoWeAre);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WhoWeAreExists(whoWeAre.ID))
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
            return View(whoWeAre);
        }

        // GET: Admin/WhoWeAres/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var whoWeAre = await _context.whoWeAres
                .FirstOrDefaultAsync(m => m.ID == id);
            if (whoWeAre == null)
            {
                return NotFound();
            }

            return View(whoWeAre);
        }

        // POST: Admin/WhoWeAres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var whoWeAre = await _context.whoWeAres.FindAsync(id);
            _context.whoWeAres.Remove(whoWeAre);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WhoWeAreExists(int id)
        {
            return _context.whoWeAres.Any(e => e.ID == id);
        }
    }
}
