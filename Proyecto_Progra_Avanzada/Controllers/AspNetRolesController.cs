using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto_Progra_Avanzada.Data;

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
        public ActionResult Details(String id)
        {
            var role = _context.Roles.FirstOrDefaultAsync( r => r.Id == id);
            return View();
        }

        // GET: AspNetRolesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AspNetRolesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AspNetRolesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AspNetRolesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AspNetRolesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AspNetRolesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
