using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GarageRev.Data;
using GarageRev.Models;

namespace GarageRev.Controllers
{
    public class CarrosController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;


        public CarrosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Carros
        public async Task<IActionResult> Index()
        {
            return View(await _context.Carros.ToListAsync());
        }

        // GET: Carros/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carros = await _context.Carros
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carros == null)
            {
                return NotFound();
            }

            return View(carros);
        }

        // GET: Carros/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Carros/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Marca,Modelo,Versão,Combustivel,Ano,Cilindrada,Potencia,TipoCaixa,Nportas,Fotografia")] Carros carros, IFormFile newFotoCarro)
        {
            ///process the image
            ///if file is null
            ///     -> add a predefined image to vet
            ///else
            ///     if file is not image
            ///         -> send error message to user, asking for image
            ///     else
            ///         -> define the name that the image must have
            ///         -> add the filename to vet data
            ///         -> save the file on the disk

            if (newFotoCarro == null)
            {
                carros.Fotografia = "noCar.png";
            }
            else if (!(newFotoCarro.ContentType == "image/jpeg" || newFotoCarro.ContentType == "image/pen"))
            {
                //error message
                ModelState.AddModelError("", "Por favor selecione uma fotografia.");
                //resend control to view with data provided by the user
                return View(carros);
            }
            else
            {
                //define image name
                Guid g;
                g = Guid.NewGuid();
                string imageName = carros.Marca + "_" + carros.Modelo + "_" + carros.Versão + "_" + g.ToString();
                string extensionImage = Path.GetExtension(newFotoCarro.FileName).ToLower();
                imageName += extensionImage;
                //add image name to vet data
                carros.Fotografia = imageName;
            }

            //validate if data provided by user is good
            if (ModelState.IsValid)
            {
                try
                {//add vet data to database
                    _context.Add(carros);
                    //commit (DB)
                    await _context.SaveChangesAsync();
                }
                catch (Exception)
                {
                    //if the code arrives here, some exception was caught -> error
                    //add a model error 
                    ModelState.AddModelError("", "Something went wrong. Unable to store data");
                    return View(carros);
                }

                //save image file to disk
                if (newFotoCarro != null)
                {
                    //ask the server what address it wants to use
                    string addressToStoreFile = _webHostEnvironment.WebRootPath;
                    string newImageLocation = Path.Combine(addressToStoreFile, "Photos", carros.Fotografia);

                    //save image file to disk
                    using var stream = new FileStream(newImageLocation, FileMode.Create);
                    await newFotoCarro.CopyToAsync(stream);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(carros);
        }

        // GET: Carros/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var carros = await _context.Carros.FindAsync(id);
            if (carros == null)
            {
                return RedirectToAction("Index");
            }

            HttpContext.Session.SetInt32("CarroID", carros.Id);

            return View(carros);
        }

        // POST: Carros/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Marca,Modelo,Versão,Combustivel,Ano,Cilindrada,Potencia,TipoCaixa,Nportas,Fotografia")] Carros carros)
        {
            if (id != carros.Id)
            {
                return NotFound();
            }

            /*antes de editar os dados do carro, é necessário validar os dados:
             *  -ler a variável de sessão
             *  -comparar com os dados que o browser fornece
             *  - se não forem iguais é problemático
            */
            var CarroIDPrevStored = HttpContext.Session.GetInt32("CarroID");

            //se esta var for nula:
            //  -o método da app está a ser acedido por ferramentas externas
            //  -está a demorar mais tempo que o suposto
            if (CarroIDPrevStored == null)
            {
                ModelState.AddModelError("", "Excedeu o tempo permitido.");
                //return RedirectToAction("Index");
                return View(carros);
            }

            if (CarroIDPrevStored != carros.Id)
            {   //Errado -> redirecionar para index
                return RedirectToAction("Index");

            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carros);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarrosExists(carros.Id))
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
            return View(carros);
        }

        // GET: Carros/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carros = await _context.Carros
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carros == null)
            {
                return NotFound();
            }

            return View(carros);
        }

        // POST: Carros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carros = await _context.Carros.FindAsync(id);
            _context.Carros.Remove(carros);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarrosExists(int id)
        {
            return _context.Carros.Any(e => e.Id == id);
        }
    }
}
