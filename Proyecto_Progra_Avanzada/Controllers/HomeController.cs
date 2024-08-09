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
        public IActionResult ChooseRole()
        {
            ViewData["ID"] = _userManager.GetUserId(this.User);

            return View();
        }

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
                    return RedirectToAction("Privacy");
                }
            }

            return Content("<a>SALIO MAL</a>");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
