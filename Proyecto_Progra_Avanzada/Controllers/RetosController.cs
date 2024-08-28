using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto_Progra_Avanzada.Data;
using Proyecto_Progra_Avanzada.Models;

namespace Proyecto_Progra_Avanzada.Controllers
{
    //[Authorize(Roles = "Entrenador")]
    public class RetosController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public RetosController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            var retos = await _context.Retos
                .Where(r => r.RetadorID == currentUser.Id || r.RetadoID == currentUser.Id)
                .ToListAsync();
            return View(retos);
        }

        /*
        [HttpPost]
        public async Task<IActionResult> CrearReto(string retadoId)
        {
            var retador = await _userManager.GetUserAsync(User);
            var reto = new Retos
            {
                RetadorID = retador.Id,
                RetadoID = retadoId,
                FechaReto = DateTime.Now,
                Estado = "Pendiente"
            };
            _context.Retos.Add(reto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        */
    }
}