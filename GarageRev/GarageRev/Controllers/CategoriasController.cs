using GarageRev.Data;
using GarageRev.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GarageRev.Controllers {
    public class CategoriasController : Controller {
        private readonly ApplicationDbContext _context;

        public CategoriasController(ApplicationDbContext context) {
            _context = context;
        }

        // GET: Categorias
        public async Task<IActionResult> Index() {
            return View(await _context.Categorias.ToListAsync());
        }

        // GET: Categorias/Details/5
        public async Task<IActionResult> Details(int? id) {
            if (id == null) {
                return NotFound();
            }

            var categorias = await _context.Categorias
                .FirstOrDefaultAsync(m => m.Id == id);
            if (categorias == null) {
                return NotFound();
            }

            return View(categorias);
        }

        // GET: Categorias/Create
        [Authorize]
        public IActionResult Create() {
            return View();
        }
        [Authorize(Roles = "Admin")]
        // POST: Categorias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NomeCat")] Categorias categorias) {
            if (ModelState.IsValid) {
                _context.Add(categorias);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(categorias);
        }

        // GET: Categorias/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id) {
            if (id == null) {
                return RedirectToAction("Index");
            }

            var categorias = await _context.Categorias.FindAsync(id);
            if (categorias == null) {
                return RedirectToAction("Index");
            }

            //criar variável de sessão para guardar ID do que vai ser editado
            HttpContext.Session.SetInt32("CategoriaID", categorias.Id);

            return RedirectToAction("Index");
        }

        // POST: Categorias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NomeCat")] Categorias categorias) {
            if (id != categorias.Id) {
                return NotFound();
            }

            /*antes de editar os dados do utilizador, é necessário validar os dados:
             *  -ler a variável de sessão
             *  -comparar com os dados que o browser fornece
             *  - se não forem iguais é problemático
            */
            var CategoriaIDPrevStored = HttpContext.Session.GetInt32("UserID");

            //se esta var for nula:
            //  -o método da app está a ser acedido por ferramentas externas
            //  -está a demorar mais tempo que o suposto
            if (CategoriaIDPrevStored == null) {
                ModelState.AddModelError("", "Excedeu o tempo permitido.");
                //return RedirectToAction("Index");
                return View(categorias);
            }

            if (CategoriaIDPrevStored != categorias.Id) {   //Errado -> redirecionar para index
                return RedirectToAction("Index");

            }

            if (ModelState.IsValid) {
                try {
                    _context.Update(categorias);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException) {
                    if (!CategoriasExists(categorias.Id)) {
                        return NotFound();
                    }
                    else {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(categorias);
        }

        // GET: Categorias/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id) {
            if (id == null) {
                return NotFound();
            }

            var categorias = await _context.Categorias
                .FirstOrDefaultAsync(m => m.Id == id);
            if (categorias == null) {
                return NotFound();
            }

            return View(categorias);
        }

        // POST: Categorias/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id) {
            var categorias = await _context.Categorias.FindAsync(id);
            _context.Categorias.Remove(categorias);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoriasExists(int id) {
            return _context.Categorias.Any(e => e.Id == id);
        }
    }
}
