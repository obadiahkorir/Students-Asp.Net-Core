using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Students.Business.Models;
using StudentsManagement.Data;

namespace StudentsManagement.Areas.Admin.Views
{
    [Area("Admin")]
    [Authorize]
    public class CountiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CountiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Counties
        public async Task<IActionResult> Index()
        {
            return View(await _context.County.ToListAsync());
        }

        // GET: Admin/Counties/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var county = await _context.County
                .FirstOrDefaultAsync(m => m.Id == id);
            if (county == null)
            {
                return NotFound();
            }

            return View(county);
        }

        // GET: Admin/Counties/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Counties/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CountyName")] County county)
        {
            if (ModelState.IsValid)
            {
                _context.Add(county);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(county);
        }

        // GET: Admin/Counties/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var county = await _context.County.FindAsync(id);
            if (county == null)
            {
                return NotFound();
            }
            return View(county);
        }

        // POST: Admin/Counties/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CountyName")] County county)
        {
            if (id != county.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(county);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CountyExists(county.Id))
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
            return View(county);
        }

        // GET: Admin/Counties/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var county = await _context.County
                .FirstOrDefaultAsync(m => m.Id == id);
            if (county == null)
            {
                return NotFound();
            }

            return View(county);
        }

        // POST: Admin/Counties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var county = await _context.County.FindAsync(id);
            _context.County.Remove(county);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CountyExists(int id)
        {
            return _context.County.Any(e => e.Id == id);
        }
    }
}
