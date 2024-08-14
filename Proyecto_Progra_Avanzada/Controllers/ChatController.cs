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
    public class ChatController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public ChatController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            var chats = await _context.ParticipantesChat
                .Where(p => p.UsuarioID == currentUser.Id)
                .Select(p => p.ChatID)
                .Distinct()
                .ToListAsync();
            return View(chats);
        }

        [HttpPost]
        public async Task<IActionResult> EnviarMensaje(int chatId, string contenido)
        {
            var usuario = await _userManager.GetUserAsync(User);
            var mensaje = new MensajeChat
            {
                ChatID = chatId,
                UsuarioID = usuario.Id,
                Contenido = contenido,
                FechaEnvio = DateTime.Now
            };
            _context.MensajesChat.Add(mensaje);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}

