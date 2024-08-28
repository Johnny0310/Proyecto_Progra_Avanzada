using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto_Progra_Avanzada.Data;
using Proyecto_Progra_Avanzada.Models;

namespace Proyecto_Progra_Avanzada.Controllers
{
    public class AspNetRolesController : Controller
    {

        private readonly ApplicationDbContext _context;

        public AspNetRolesController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: AspNetRolesController
        public ActionResult Index()
        {
            var roles = _context.Roles.ToList();

            return View(roles);
        }

        // GET: AspNetRolesController/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return NotFound(); 
            }
            var role = _context.Roles.FirstOrDefaultAsync( r => r.Id == id);
            
            if (role == null)
            {
                return NotFound();
            }
            return View();
        }

        // GET: AspNetRolesController/Create
        public  ActionResult Create()
        {
            

            return View();
        }

        /*
        // POST: AspNetRolesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AspNetRoles viewModelRoles)
        {

            var role = new AspNetRoles()
            {
                Name = viewModelRoles.Name,
                NormalizedName = viewModelRoles.NormalizedName,
                Descripcion = viewModelRoles.Descripcion
            };
            await _context.AspNetRoles.AddAsync(role);
            await _context.SaveChangesAsync();

            return View(role);

          
        }

        // GET: AspNetRolesController/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            var role = await _context.AspNetRoles.FindAsync(id);
            return View();
        }

        // POST: AspNetRolesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> Edit(AspNetRoles viewModelRoles)
        {
            var role = await _context.AspNetRoles.FindAsync(viewModelRoles.RoleId);
            if(role is not null)
            {
                role.Name = viewModelRoles.Name;
                role.NormalizedName = viewModelRoles.NormalizedName;
                role.Descripcion = viewModelRoles.Descripcion;

                await _context.SaveChangesAsync();
            }
            return RedirectToAction("index", "AspNetRoles");
           
        }

        // GET: AspNetRolesController/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                
            }
            var role = await _context.AspNetRoles
                .FirstOrDefaultAsync(r => r.RoleId == id);
            if (role is null)
            {
                return NotFound();
            }
            return View();
        }

        // POST: AspNetRolesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(AspNetRoles viewModelRoles)
        {
            var role = await _context.AspNetRoles.AsNoTracking()
                .FirstOrDefaultAsync(r => r.RoleId == viewModelRoles.RoleId);
            if (role is null)
            {
                _context.AspNetRoles.Remove(viewModelRoles);
                await _context.SaveChangesAsync();
            }

            
            {
                return RedirectToAction("Index", "AspNetRoles");
            }
        }

        */
    }
}
