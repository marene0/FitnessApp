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
    public class ExercisesWorkoutsController : Controller
    {
        private readonly DataContext _context;

        public ExercisesWorkoutsController(DataContext context)
        {
            _context = context;
        }

        // GET: ExercisesWorkouts
        public async Task<IActionResult> Index()
        {
            return View(await _context.ExercisesWorkouts.ToListAsync());
        }

        // GET: ExercisesWorkouts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exercisesWorkout = await _context.ExercisesWorkouts
                .FirstOrDefaultAsync(m => m.ExercisesWorkoutId == id);
            if (exercisesWorkout == null)
            {
                return NotFound();
            }

            return View(exercisesWorkout);
        }

        // GET: ExercisesWorkouts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ExercisesWorkouts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ExercisesWorkoutId,Count")] ExercisesWorkout exercisesWorkout)
        {
            if (ModelState.IsValid)
            {
                _context.Add(exercisesWorkout);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(exercisesWorkout);
        }

        // GET: ExercisesWorkouts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exercisesWorkout = await _context.ExercisesWorkouts.FindAsync(id);
            if (exercisesWorkout == null)
            {
                return NotFound();
            }
            return View(exercisesWorkout);
        }

        // POST: ExercisesWorkouts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ExercisesWorkoutId,Count")] ExercisesWorkout exercisesWorkout)
        {
            if (id != exercisesWorkout.ExercisesWorkoutId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(exercisesWorkout);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExercisesWorkoutExists(exercisesWorkout.ExercisesWorkoutId))
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
            return View(exercisesWorkout);
        }

        // GET: ExercisesWorkouts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exercisesWorkout = await _context.ExercisesWorkouts
                .FirstOrDefaultAsync(m => m.ExercisesWorkoutId == id);
            if (exercisesWorkout == null)
            {
                return NotFound();
            }

            return View(exercisesWorkout);
        }

        // POST: ExercisesWorkouts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var exercisesWorkout = await _context.ExercisesWorkouts.FindAsync(id);
            if (exercisesWorkout != null)
            {
                _context.ExercisesWorkouts.Remove(exercisesWorkout);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExercisesWorkoutExists(int id)
        {
            return _context.ExercisesWorkouts.Any(e => e.ExercisesWorkoutId == id);
        }
    }
}
