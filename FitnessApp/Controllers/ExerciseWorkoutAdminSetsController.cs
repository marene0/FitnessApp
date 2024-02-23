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
    public class ExerciseWorkoutAdminSetsController : Controller
    {
        private readonly DataContext _context;

        public ExerciseWorkoutAdminSetsController(DataContext context)
        {
            _context = context;
        }

        // GET: ExerciseWorkoutAdminSets
        public async Task<IActionResult> Index()
        {
            return View(await _context.ExerciseWorkoutAdminSets.ToListAsync());
        }

        // GET: ExerciseWorkoutAdminSets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exerciseWorkoutAdminSet = await _context.ExerciseWorkoutAdminSets
                .FirstOrDefaultAsync(m => m.ExerciseWorkoutAdminSetId == id);
            if (exerciseWorkoutAdminSet == null)
            {
                return NotFound();
            }

            return View(exerciseWorkoutAdminSet);
        }

        // GET: ExerciseWorkoutAdminSets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ExerciseWorkoutAdminSets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ExerciseWorkoutAdminSetId")] ExerciseWorkoutAdminSet exerciseWorkoutAdminSet)
        {
            if (ModelState.IsValid)
            {
                _context.Add(exerciseWorkoutAdminSet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(exerciseWorkoutAdminSet);
        }

        // GET: ExerciseWorkoutAdminSets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exerciseWorkoutAdminSet = await _context.ExerciseWorkoutAdminSets.FindAsync(id);
            if (exerciseWorkoutAdminSet == null)
            {
                return NotFound();
            }
            return View(exerciseWorkoutAdminSet);
        }

        // POST: ExerciseWorkoutAdminSets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ExerciseWorkoutAdminSetId")] ExerciseWorkoutAdminSet exerciseWorkoutAdminSet)
        {
            if (id != exerciseWorkoutAdminSet.ExerciseWorkoutAdminSetId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(exerciseWorkoutAdminSet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExerciseWorkoutAdminSetExists(exerciseWorkoutAdminSet.ExerciseWorkoutAdminSetId))
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
            return View(exerciseWorkoutAdminSet);
        }

        // GET: ExerciseWorkoutAdminSets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exerciseWorkoutAdminSet = await _context.ExerciseWorkoutAdminSets
                .FirstOrDefaultAsync(m => m.ExerciseWorkoutAdminSetId == id);
            if (exerciseWorkoutAdminSet == null)
            {
                return NotFound();
            }

            return View(exerciseWorkoutAdminSet);
        }

        // POST: ExerciseWorkoutAdminSets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var exerciseWorkoutAdminSet = await _context.ExerciseWorkoutAdminSets.FindAsync(id);
            if (exerciseWorkoutAdminSet != null)
            {
                _context.ExerciseWorkoutAdminSets.Remove(exerciseWorkoutAdminSet);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExerciseWorkoutAdminSetExists(int id)
        {
            return _context.ExerciseWorkoutAdminSets.Any(e => e.ExerciseWorkoutAdminSetId == id);
        }
    }
}
