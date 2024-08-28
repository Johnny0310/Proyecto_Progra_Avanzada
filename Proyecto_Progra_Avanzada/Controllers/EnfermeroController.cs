using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto_Progra_Avanzada.Data;
using Proyecto_Progra_Avanzada.Models;

namespace Proyecto_Progra_Avanzada.Controllers
{
    public class EnfermeroController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EnfermeroController(ApplicationDbContext context)
        {
            _context = context;
        }
        [Authorize(Roles = "Enfermero")]
        public IActionResult Index()
        {
            List<Pokedex> userPokedexList;
            using (_context)
            {
                // Filter Pokedex records by the logged-in user's ID
                userPokedexList = _context.Pokedex
                    .Where(p => p.vida <= 25)
                    .ToList();
            }

            // Pass the filtered list of Pokedex records to the view
            return View(userPokedexList);
        }

        // GET: Pokedex/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var pokedex = await _context.Pokedex.FindAsync(id);
            return View(pokedex);
        }

        // POST: Pokedex/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Pokedex viewModelPokedex)
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
            return RedirectToAction("Index", "Enfermero");
        }
    }
}
