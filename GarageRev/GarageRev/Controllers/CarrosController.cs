using GarageRev.Data;
using GarageRev.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarageRev.Controllers
{
    public class CarrosController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;


        public CarrosController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Carros
        public async Task<IActionResult> Index()
        {
            /* execute the db command
             * select *
             * from Advertisements
             * 
             * and send Data to View
             */
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
        public async Task<IActionResult> Create([Bind("Id,Marca,Modelo,Versao,Combustivel,Ano,CilindradaouCapacidadeBateria,Potencia,TipoCaixa,Nportas")] Carros carros, IFormFileCollection files)
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
            List<Fotografias> fotoscarro = new List<Fotografias>();

            if (!files.Any())
            {
                //nao existe fotos de carros
                fotoscarro.Add(new Fotografias { CarroFK = carros.Id, FotoPath = "noCar.png" });
            }
            else
            {
                foreach (var foto in files)
                {
                    if (!(foto.ContentType == "image/jpeg" || foto.ContentType == "image/png"))
                    {
                        //error message
                        ModelState.AddModelError("", "Por favor selecione uma fotografia do tipo .jpeg ou .png .");
                        //resend control to view with data provided by the user
                        return View(carros);
                    }
                    else
                    {
                        //guardar o nome do ficheiro
                        Guid g;
                        g = Guid.NewGuid();
                        string imageName = carros.Marca + "_" + carros.Modelo + "_" + carros.Versao + "_" + g.ToString();
                        string extensionImage = Path.GetExtension(foto.FileName).ToLower();
                        imageName += extensionImage;
                        //guardar ficheiro
                        string addressToStoreFile = _webHostEnvironment.WebRootPath;
                        string caminho = Path.Combine(addressToStoreFile, "Photos", imageName);

                        //Adição da foto a lista com fk e fotopath coorespondente
                        fotoscarro.Add(new Fotografias { CarroFK = carros.Id, FotoPath = imageName });

                        using var stream = new FileStream(caminho, FileMode.Create);
                        await foto.CopyToAsync(stream);
                    }

                }
            }
            _context.Fotografias.AddRange(fotoscarro);
            await _context.SaveChangesAsync();


            return RedirectToAction(nameof(Index));
        }

        // GET: Carros/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carros = await _context.Carros.FindAsync(id);
            if (carros == null)
            {
                return NotFound();
            }
            return View(carros);
        }

        // POST: Carros/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Marca,Modelo,Versao,Combustivel,Ano,CilindradaouCapacidadeBateria,Potencia,TipoCaixa,Nportas")] Carros carros)
        {
            if (id != carros.Id)
            {
                return NotFound();
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
