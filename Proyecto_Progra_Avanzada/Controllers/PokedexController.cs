using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles = "Administrador")]

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
        public async Task<IActionResult> Create(Pokedex viewModelPokedex)
        {
            var pokedex = new Pokedex()
            {
                Id= viewModelPokedex.Id,
                PokemonID = viewModelPokedex.PokemonID,
         
                fecha_captura = viewModelPokedex.fecha_captura,
                victorias = viewModelPokedex.victorias,
                numeroEvolucion = viewModelPokedex.numeroEvolucion,
                vida = viewModelPokedex.vida
            };
            /* if (ModelState.IsValid)
           {
               _context.Add(pokedex);
               await _context.SaveChangesAsync();
               return RedirectToAction(nameof(Index));
           }*/
            await _context.Pokedex.AddAsync(pokedex);
            await _context.SaveChangesAsync();
            return View(pokedex);
        }

        // GET: Pokedex/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var pokedex = await _context.Pokedex.FindAsync(id);
            /*
            if (id == null)
            {
                return NotFound();
            }

            var pokedex = await _context.Pokedex.FindAsync(id);
            if (pokedex == null)
            {
                return NotFound();
            }*/
            return View(pokedex);
        }

        // POST: Pokedex/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit( Pokedex viewModelPokedex)
        {
            var pokedex = await _context.Pokedex.FindAsync(viewModelPokedex.id_Pokedex);
            if (pokedex is not null)
            {
                
                pokedex.PokemonID = viewModelPokedex.PokemonID;
                pokedex.fecha_captura = viewModelPokedex.fecha_captura;
                pokedex.victorias = viewModelPokedex.victorias;
                pokedex.numeroEvolucion = viewModelPokedex.numeroEvolucion;
                pokedex.vida = viewModelPokedex.vida;

               await _context.SaveChangesAsync();
               
            };
            return RedirectToAction("index", "Pokedex");
           
            


            /*
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
            */
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
        public async Task<IActionResult> DeleteConfirmed(Pokedex viewModelPokedex)
        {
            var pokedex = await _context.Pokedex.AsNoTracking()
                .FirstOrDefaultAsync(x => x.id_Pokedex == viewModelPokedex.id_Pokedex);    
            if(pokedex is not null)
            {
                 _context.Pokedex.Remove(viewModelPokedex);
                await _context.SaveChangesAsync();

            }
            return RedirectToAction("Index", "Pokedex");
            /*
            var pokedex = await _context.Pokedex.FindAsync(id);
            if (pokedex == null)
            {
                return NotFound();
            }

            _context.Pokedex.Remove(pokedex);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            */
        }

        private bool PokedexExists(int id)
        {
            return _context.Pokedex.Any(e => e.id_Pokedex == id);
        }
    }
}
