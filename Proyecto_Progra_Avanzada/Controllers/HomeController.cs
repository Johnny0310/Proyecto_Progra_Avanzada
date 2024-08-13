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

        public HomeController(ILogger<HomeController> logger, UserManager<IdentityUser> UserManager)
        {
            _logger = logger;
            _userManager = UserManager;
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
            ViewData["ID"] = _userManager.GetUserId(this.User);
            return View();
        }

        public IActionResult ChooseRole()
        {
            ViewData["ID"] = _userManager.GetUserId(this.User);

            return View();
        }

        // Metodo para introducir el Rol
        [HttpPost]
        public async Task<IActionResult> SubmitForm(string UserId, string RoleId)
        {
            if (UserId != null && RoleId != null)
            {
                using (var context = new DemoContext())
                {
                    var userRole = new AspNetUserRoles
                    {
                        UserId = UserId,
                        RoleId = RoleId
                    };

                    context.AspNetUserRoles.Add(userRole);
                    await context.SaveChangesAsync();
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
                using (var context = new DemoContext())
                {
                    var pokedex = new Pokedex
                    {
                        Id = UserId,
                        PokemonID = PokemonID,
                        fecha_captura = fecha_captura
                    };

                    context.Pokedex.Add(pokedex);
                    await context.SaveChangesAsync();
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
            using (var context = new DemoContext())
            {
                // Filter Pokedex records by the logged-in user's ID
                userPokedexList = context.Pokedex
                    .Where(p => p.Id == userId)
                    .ToList();
            }

            // Pass the filtered list of Pokedex records to the view
            return View(userPokedexList);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
