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
    [Authorize(Roles = "Entrenador")]
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
            ViewData["RetadorID"] = _userManager.GetUserId(this.User);
            string user = _userManager.GetUserId(this.User);
            return View(_context.ApplicationUsers.Where(p => p.IsOnline == true &&  p.Id != user).ToList());
        }
        public async Task<IActionResult> VerRetos()
        {
            ViewData["RetadorID"] = _userManager.GetUserId(this.User);
            return View(_context.Retos.ToList());
        }



        [HttpPost]
        public async Task<IActionResult> SubmitReto(string RetadorID, string RetadoID, DateTime FechaReto)
        {
            using (_context)
            {
                var reto = new Retos
                {
                    RetadorID = RetadorID,
                    RetadoID = RetadoID,
                    FechaReto = FechaReto,
                    Ganador = "N/A"
                };

                _context.Retos.Add(reto);
                await _context.SaveChangesAsync();
                return RedirectToAction("VerRetos");
            }
        }
        
    }
}