using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GarageRev.Data;
using GarageRev.Models;
using Microsoft.AspNetCore.Authorization;

namespace GarageRev.Controllers
{
    public class ReviewsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReviewsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Reviews
        public async Task<IActionResult> Index(int id)
        {
            var applicationDbContext = _context.Reviews.Include(r => r.Carro).Include(r => r.Utilizador);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Reviews/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reviews = await _context.Reviews
                .Include(r => r.Carro)
                .Include(r => r.Utilizador)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reviews == null)
            {
                return NotFound();
            }

            return View(reviews);
        }

        // GET: Reviews/Create
        public IActionResult Create()
        {
            ViewData["CarroFK"] = new SelectList(_context.Carros, "Id", "Id");
            ViewData["UtilizadorFK"] = new SelectList(_context.Utilizadores, "Id", "Nome");
            return View();
        }

        // POST: Reviews/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Comentario,UtilizadorFK,CarroFK")] Reviews reviews)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reviews);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarroFK"] = new SelectList(_context.Carros, "Id", "Id", reviews.CarroFK);
            ViewData["UtilizadorFK"] = new SelectList(_context.Utilizadores, "Id", "Nome", reviews.UtilizadorFK);
            return View(reviews);
        }

        // GET: Reviews/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var reviews = await _context.Reviews.FindAsync(id);
            if (reviews == null)
            {
                return RedirectToAction("Index");
            }
            //criar variável de sessão para guardar ID do que vai ser editado
            HttpContext.Session.SetInt32("ReviewID", reviews.Id);

            ViewData["CarroFK"] = new SelectList(_context.Carros, "Id", "Id", reviews.CarroFK);
            ViewData["UtilizadorFK"] = new SelectList(_context.Utilizadores, "Id", "Nome", reviews.UtilizadorFK);
            return View(reviews);
        }

        // POST: Reviews/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Comentario,UtilizadorFK,CarroFK")] Reviews reviews)
        {
            if (id != reviews.Id)
            {
                return NotFound();
            }

            /*antes de editar os dados da review, é necessário validar os dados:
             *  -ler a variável de sessão
             *  -comparar com os dados que o browser fornece
             *  - se não forem iguais é problemático
            */
            var ReviewIDPrevStored = HttpContext.Session.GetInt32("UserID");

            //se esta var for nula:
            //  -o método da app está a ser acedido por ferramentas externas
            //  -está a demorar mais tempo que o suposto
            if (ReviewIDPrevStored == null)
            {
                ModelState.AddModelError("", "Excedeu o tempo permitido.");
                //return RedirectToAction("Index");
                return View(reviews);
            }

            if (ReviewIDPrevStored != reviews.Id)
            {   //Errado -> redirecionar para index
                return RedirectToAction("Index");

            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reviews);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReviewsExists(reviews.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarroFK"] = new SelectList(_context.Carros, "Id", "Id", reviews.CarroFK);
            ViewData["UtilizadorFK"] = new SelectList(_context.Utilizadores, "Id", "Nome", reviews.UtilizadorFK);
            return View(reviews);
        }

        // GET: Reviews/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reviews = await _context.Reviews
                .Include(r => r.Carro)
                .Include(r => r.Utilizador)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reviews == null)
            {
                return NotFound();
            }

            return View(reviews);
        }

        // POST: Reviews/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reviews = await _context.Reviews.FindAsync(id);
            _context.Reviews.Remove(reviews);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReviewsExists(int id)
        {
            return _context.Reviews.Any(e => e.Id == id);
        }
    }
}
