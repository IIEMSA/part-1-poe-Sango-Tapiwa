using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EventEase.Models;

namespace EventEase.Controllers
{
    public class EventsController : Controller
    {
        private readonly ApplicationDbContext _context;
        public EventsController(ApplicationDbContext context) => _context = context;

        public async Task<IActionResult> Index() => View(await _context.Events.ToListAsync());

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(Events eventModel)
        {
            if (!ModelState.IsValid) return View(eventModel);

            _context.Events.Add(eventModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var eventModel = await _context.Events.FirstOrDefaultAsync(m => m.Id == id);
            if (eventModel == null) return NotFound();

            return View(eventModel);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var eventModel = await _context.Events.FindAsync(id);
            if (eventModel == null) return NotFound();

            return View(eventModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Events eventModel)
        {
            if (id != eventModel.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eventModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Events.Any(e => e.Id == id)) return NotFound();
                    else throw;
                }

                return RedirectToAction(nameof(Index));
            }

            return View(eventModel);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var eventModel = await _context.Events.FirstOrDefaultAsync(m => m.Id == id);
            if (eventModel == null) return NotFound();

            return View(eventModel);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var eventModel = await _context.Events.FindAsync(id);
            _context.Events.Remove(eventModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
