using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Proyecto_Progra_Avanzada.Data;
using Proyecto_Progra_Avanzada.Models;
using System.Diagnostics;

namespace Proyecto_Progra_Avanzada.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, UserManager<IdentityUser> UserManager, ApplicationDbContext context)
        {
            _logger = logger;
            _userManager = UserManager;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult MainView()
        {
            return View();
        }

        public IActionResult ChooseRole()
        {
            ViewData["ID"] = _userManager.GetUserId(this.User);
            var userId = _userManager.GetUserId(this.User);

            var user = _context.ApplicationUsers.FirstOrDefault(p => p.Id == userId);

            if (user != null)
            {
                user.IsOnline = true;
                _context.SaveChanges();
            }
            return View();
        }

        // Metodo para introducir el Rol
        [HttpPost]
        public async Task<IActionResult> SubmitForm(string UserId, string RoleId)
        {
            if (UserId != null && RoleId != null)
            {
                using (_context)
                {
                    var user = await _userManager.FindByIdAsync(UserId);

                    if (user == null)
                    {
                        return Content("<a>Usuario no encontrado</a>");
                    }

                    if (RoleId == "Entrenador")
                    {
                        await _userManager.AddToRoleAsync(user, "Entrenador");
                    }
                    else if (RoleId == "Enfermero")
                    {
                        await _userManager.AddToRoleAsync(user, "Enfermero");
                    }
                    else if (RoleId == "Administrador")
                    {
                        await _userManager.AddToRoleAsync(user, "Administrador");
                    }

                    await _context.SaveChangesAsync();
                    return RedirectToAction("MainView");
                }
            }

            return Content("<a>SALIO MAL</a>");
        }

        // Metodo para introducir Pokemon en Pokedex

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> GetPokemon(int PokemonID, DateTime fecha_captura)
        {
            string UserId = _userManager.GetUserId(this.User);
            if (UserId != null)
            {
                using (_context)
                {
                    var pokedex = new Pokedex
                    {
                        Id = UserId,
                        PokemonID = PokemonID,
                        numeroEvolucion = 1,
                        fecha_captura = fecha_captura,
                        vida = 100,
                        victorias = 0
                    };

                    _context.Pokedex.Add(pokedex);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("MainView");
                }
            }

            return Content("<a>SALIO MAL</a>");
        }


        public IActionResult OpenPokedex()
        {
            // Get the current logged-in user's ID from the session or authentication context
            var userId = _userManager.GetUserId(this.User);

            List<Pokedex> userPokedexList;
            using (_context)
            {
                // Filter Pokedex records by the logged-in user's ID
                userPokedexList = _context.Pokedex
                    .Where(p => p.Id == userId)
                    .ToList();
            }

            // Pass the filtered list of Pokedex records to the view
            return View(userPokedexList);
        }


        public IActionResult Retos2()
        {
            ViewData["RetadorID"] = _userManager.GetUserId(this.User);
            return View(_context.ApplicationUsers.Where(p => p.IsOnline == true).ToList());
        }

        public IActionResult MarkLogin()
        {
            var userId = _userManager.GetUserId(this.User);

            var user = _context.ApplicationUsers.FirstOrDefault(p => p.Id == userId);

            if (user != null)
            {
                user.IsOnline = true;
                _context.SaveChanges();
            }

            return RedirectToAction("MainView");
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> SubmitReto(string RetadorID, string RetadoID, DateTime FechaReto)
        {
            using (_context)
            {
                var reto = new Retos
                {
                    RetadorID = RetadorID,
                    RetadoID = RetadoID,
                    FechaReto = FechaReto
                };

                _context.Retos.Add(reto);
                await _context.SaveChangesAsync();
                return RedirectToAction("MainView");
            }

        }

        public IActionResult MarkLogOut()
        {
            var userId = _userManager.GetUserId(this.User);

            var user = _context.ApplicationUsers.FirstOrDefault(p => p.Id == userId);

            if (user != null)
            {
                user.IsOnline = false;
                _context.SaveChanges();
            }

            return RedirectToAction("Retos2");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
