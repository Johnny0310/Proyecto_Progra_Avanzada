using System;
using System.Collections.Generic;
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
            var chatIds = await _context.ParticipantesChat
                .Where(p => p.UsuarioID == currentUser.Id)
                .Select(p => p.ChatID)
                .Distinct()
                .ToListAsync();

            var allUsers = await _userManager.Users
                .Where(u => u.Id != currentUser.Id)
                .Select(u => new { u.Id, u.UserName })
                .ToListAsync();

            ViewBag.AllUsers = allUsers;

            var chatParticipants = new Dictionary<int, string>();
            foreach (var chatId in chatIds)
            {
                var otherParticipant = await _context.ParticipantesChat
                    .Where(p => p.ChatID == chatId && p.UsuarioID != currentUser.Id)
                    .Select(p => p.Usuario.UserName)
                    .FirstOrDefaultAsync();
                chatParticipants[chatId] = otherParticipant;
            }
            ViewBag.ChatParticipants = chatParticipants;

            // Obtener los mensajes de los chats
            var chatMessages = new Dictionary<int, List<MensajeChat>>();
            foreach (var chatId in chatIds)
            {
                var messages = await _context.MensajesChat
                    .Where(m => m.ChatID == chatId)
                    .OrderBy(m => m.FechaEnvio)
                    .ToListAsync();
                chatMessages[chatId] = messages;
            }
            ViewBag.ChatMessages = chatMessages;

            return View(chatIds);
        }

        [HttpPost]
        public async Task<IActionResult> IniciarChat(string receptorId)
        {
            var currentUser = await _userManager.GetUserAsync(User);

            // Crear un nuevo registro de Chat
            var nuevoChat = new Chat { Nombre = "Nuevo Chat" };
            _context.Chats.Add(nuevoChat);
            await _context.SaveChangesAsync();

            // Obtener el ChatID generado
            var nuevoChatId = nuevoChat.ChatID;

            // Añadir los participantes al chat
            var participantes = new List<ParticipanteChat>
            {
                new ParticipanteChat { ChatID = nuevoChatId, UsuarioID = currentUser.Id },
                new ParticipanteChat { ChatID = nuevoChatId, UsuarioID = receptorId }
            };
            await _context.ParticipantesChat.AddRangeAsync(participantes);
            await _context.SaveChangesAsync();  // Guarda los participantes del chat

            return RedirectToAction(nameof(Index));
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

        [HttpPost]
        public async Task<IActionResult> EliminarChat(int chatId)
        {
            // Obtener el chat a eliminar
            var chat = await _context.Chats.FindAsync(chatId);
            if (chat != null)
            {

                var mensajes = await _context.MensajesChat.Where(m => m.ChatID == chatId).ToListAsync();
                _context.MensajesChat.RemoveRange(mensajes);


                var participantes = await _context.ParticipantesChat.Where(p => p.ChatID == chatId).ToListAsync();
                _context.ParticipantesChat.RemoveRange(participantes);

                // Eliminar el chat
                _context.Chats.Remove(chat);

                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}