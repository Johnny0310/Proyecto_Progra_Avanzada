using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto_Progra_Avanzada.Data;
using Proyecto_Progra_Avanzada.Models;

namespace Proyecto_Progra_Avanzada.Controllers
{
    public class PokedexController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PokedexController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Pokedex
        public async Task<IActionResult> Index()
        {
            var pokedex = await _context.Pokedex.ToListAsync();
            return View(pokedex);
        }

        // GET: Pokedex/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pokedex = await _context.Pokedex
                .FirstOrDefaultAsync(m => m.id_Pokedex == id);
            if (pokedex == null)
            {
                return NotFound();
            }

            return View(pokedex);
        }

        // GET: Pokedex/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pokedex/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_Pokedex,Id,PokemonID,fecha_captura")] Pokedex pokedex)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pokedex);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pokedex);
        }

        // GET: Pokedex/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pokedex = await _context.Pokedex.FindAsync(id);
            if (pokedex == null)
            {
                return NotFound();
            }
            return View(pokedex);
        }

        // POST: Pokedex/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_Pokedex,Id,PokemonID,fecha_captura")] Pokedex pokedex)
        {
            if (id != pokedex.id_Pokedex)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pokedex);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PokedexExists(pokedex.id_Pokedex))
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
            return View(pokedex);
        }

        // GET: Pokedex/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pokedex = await _context.Pokedex
                .FirstOrDefaultAsync(m => m.id_Pokedex == id);
            if (pokedex == null)
            {
                return NotFound();
            }

            return View(pokedex);
        }

        // POST: Pokedex/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pokedex = await _context.Pokedex.FindAsync(id);
            _context.Pokedex.Remove(pokedex);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PokedexExists(int id)
        {
            return _context.Pokedex.Any(e => e.id_Pokedex == id);
        }
    }
}
