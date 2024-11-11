using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EcommerceStore.DataAccess.Data;
using EcommerceStore.Model;

namespace EcommerceStore.Web.Areas.SuperAdmin.Controllers
{
    [Area("SuperAdmin")]
    public class ConfigurationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ConfigurationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SuperAdmin/Configurations
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Configurations.Include(c => c.ConfigurationType);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: SuperAdmin/Configurations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var configurations = await _context.Configurations
                .Include(c => c.ConfigurationType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (configurations == null)
            {
                return NotFound();
            }

            return View(configurations);
        }

        // GET: SuperAdmin/Configurations/Create
        public IActionResult Create()
        {
            ViewData["ConfigurationTypeId"] = new SelectList(_context.ConfigurationType, "Id", "Name");
            return View();
        }

        // POST: SuperAdmin/Configurations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Key,Value,Description,Url,ImagePath,ConfigurationTypeId")] Configurations configurations)
        {
            if (ModelState.IsValid)
            {
                _context.Add(configurations);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ConfigurationTypeId"] = new SelectList(_context.ConfigurationType, "Id", "Name", configurations.ConfigurationTypeId);
            return View(configurations);
        }

        // GET: SuperAdmin/Configurations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var configurations = await _context.Configurations.FindAsync(id);
            if (configurations == null)
            {
                return NotFound();
            }
            ViewData["ConfigurationTypeId"] = new SelectList(_context.ConfigurationType, "Id", "Name", configurations.ConfigurationTypeId);
            return View(configurations);
        }

        // POST: SuperAdmin/Configurations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Key,Value,Description,Url,ImagePath,ConfigurationTypeId")] Configurations configurations)
        {
            if (id != configurations.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(configurations);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConfigurationsExists(configurations.Id))
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
            ViewData["ConfigurationTypeId"] = new SelectList(_context.ConfigurationType, "Id", "Name", configurations.ConfigurationTypeId);
            return View(configurations);
        }

        // GET: SuperAdmin/Configurations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var configurations = await _context.Configurations
                .Include(c => c.ConfigurationType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (configurations == null)
            {
                return NotFound();
            }

            return View(configurations);
        }

        // POST: SuperAdmin/Configurations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var configurations = await _context.Configurations.FindAsync(id);
            if (configurations != null)
            {
                _context.Configurations.Remove(configurations);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConfigurationsExists(int id)
        {
            return _context.Configurations.Any(e => e.Id == id);
        }
    }
}
