using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FitnessApp.Data;
using FitnessApp.Model;

namespace FitnessApp.Controllers
{
    public class WorkoutAdminSetsController : Controller
    {
        private readonly DataContext _context;

        public WorkoutAdminSetsController(DataContext context)
        {
            _context = context;
        }

        // GET: WorkoutAdminSets
        public async Task<IActionResult> Index()
        {
            return View(await _context.WorkoutAdminSets.ToListAsync());
        }

        // GET: WorkoutAdminSets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workoutAdminSet = await _context.WorkoutAdminSets
                .FirstOrDefaultAsync(m => m.WorkoutAdminSetId == id);
            if (workoutAdminSet == null)
            {
                return NotFound();
            }

            return View(workoutAdminSet);
        }

        // GET: WorkoutAdminSets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WorkoutAdminSets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WorkoutAdminSetId,SetName")] WorkoutAdminSet workoutAdminSet)
        {
            if (ModelState.IsValid)
            {
                _context.Add(workoutAdminSet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(workoutAdminSet);
        }

        // GET: WorkoutAdminSets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workoutAdminSet = await _context.WorkoutAdminSets.FindAsync(id);
            if (workoutAdminSet == null)
            {
                return NotFound();
            }
            return View(workoutAdminSet);
        }

        // POST: WorkoutAdminSets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("WorkoutAdminSetId,SetName")] WorkoutAdminSet workoutAdminSet)
        {
            if (id != workoutAdminSet.WorkoutAdminSetId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(workoutAdminSet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkoutAdminSetExists(workoutAdminSet.WorkoutAdminSetId))
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
            return View(workoutAdminSet);
        }

        // GET: WorkoutAdminSets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workoutAdminSet = await _context.WorkoutAdminSets
                .FirstOrDefaultAsync(m => m.WorkoutAdminSetId == id);
            if (workoutAdminSet == null)
            {
                return NotFound();
            }

            return View(workoutAdminSet);
        }

        // POST: WorkoutAdminSets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var workoutAdminSet = await _context.WorkoutAdminSets.FindAsync(id);
            if (workoutAdminSet != null)
            {
                _context.WorkoutAdminSets.Remove(workoutAdminSet);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkoutAdminSetExists(int id)
        {
            return _context.WorkoutAdminSets.Any(e => e.WorkoutAdminSetId == id);
        }
    }
}
