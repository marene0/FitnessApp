using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FitnessApp.Data;
using FitnessApp.Model;
using FitnessApp.Interfaces;

namespace FitnessApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ExercisesController : Controller
    {
        private readonly IExerciseRepository _exerciseReposetory;
        public ExercisesController(IExerciseRepository exerciseRepository)
        {
            _exerciseReposetory = exerciseRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Exercise>))]
        public IActionResult GetExercises()
        {
            var exercise = _exerciseReposetory.GetExercises();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(exercise);

        }

    }
}


//namespace FitnessApp.Controllers
//{
//    public class ExercisesController : Controller
//    {
//        private readonly DataContext _context;

//        public ExercisesController(DataContext context)
//        {
//            _context = context;
//        }

//         // GET: Exercises
//        public async Task<IActionResult> Index()
//        {
//            return View(await _context.Exercises.ToListAsync());
//        }

//        // GET: Exercises/Details/5
//        public async Task<IActionResult> Details(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var exercise = await _context.Exercises
//                .FirstOrDefaultAsync(m => m.ExerciseId == id);
//            if (exercise == null)
//            {
//                return NotFound();
//            }

//            return View(exercise);
//        }

//        // GET: Exercises/Create
//        public IActionResult Create()
//        {
//            return View();
//        }

//        // POST: Exercises/Create
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create([Bind("ExerciseId,ExerciseName,Type,Time,CaloriesLost,Complexity")] Exercise exercise)
//        {
//            if (ModelState.IsValid)
//            {
//                _context.Add(exercise);
//                await _context.SaveChangesAsync();
//                return RedirectToAction(nameof(Index));
//            }
//            return View(exercise);
//        }

//        // GET: Exercises/Edit/5
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var exercise = await _context.Exercises.FindAsync(id);
//            if (exercise == null)
//            {
//                return NotFound();
//            }
//            return View(exercise);
//        }

//        // POST: Exercises/Edit/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, [Bind("ExerciseId,ExerciseName,Type,Time,CaloriesLost,Complexity")] Exercise exercise)
//        {
//            if (id != exercise.ExerciseId)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(exercise);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!ExerciseExists(exercise.ExerciseId))
//                    {
//                        return NotFound();
//                    }
//                    else
//                    {
//                        throw;
//                    }
//                }
//                return RedirectToAction(nameof(Index));
//            }
//            return View(exercise);
//        }

//        // GET: Exercises/Delete/5
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var exercise = await _context.Exercises
//                .FirstOrDefaultAsync(m => m.ExerciseId == id);
//            if (exercise == null)
//            {
//                return NotFound();
//            }

//            return View(exercise);
//        }

//        // POST: Exercises/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            var exercise = await _context.Exercises.FindAsync(id);
//            if (exercise != null)
//            {
//                _context.Exercises.Remove(exercise);
//            }

//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }

//        private bool ExerciseExists(int id)
//        {
//            return _context.Exercises.Any(e => e.ExerciseId == id);
//        }
//    }
//}
