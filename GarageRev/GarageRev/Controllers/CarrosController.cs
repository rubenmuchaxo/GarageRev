﻿using GarageRev.Data;
using GarageRev.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<IdentityUser> userManager


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

        /// <summary>
        /// Metodo para apresentar os comentarios feitos pelos utilizadores

        /// <returns></returns>
        









        // GET: Carros/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carros = await _context.Carros
                .Include(c => c.Categorias)
                //.Include(f => f.Reviews)
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
        [Authorize]
        public async Task<IActionResult> Create([Bind("Id,Marca,Modelo,Versao,Combustivel,Ano,CilindradaouCapacidadeBateria,Potencia,TipoCaixa,Nportas,Foto")] Carros carros, IFormFile fotografia, ICollection<String> ChoosenCategory)
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
            
            //vai percorrer todas as strings category selecionadas na collection choosen category
            foreach (String category in ChoosenCategory)
            {
                
                //vai percorrer as categorias ja existentes
                foreach (Categorias category2 in _context.Categorias)
                {
                    //se a categoria selecionada ja existir na base de dados
                    if (category2.NomeCat == category)
                    {
                        //adicionamos a categoria selecionada ao carro
                        carros.Categorias.Add(category2);
                    }
                }
            }



            if (ChoosenCategory.Count == 0)
            {
                ModelState.AddModelError("", "Please choose at least a category.");
                return View(carros);
            }

            if (fotografia == null)
            {
                ModelState.AddModelError("", "Please insert an image with a valid format(png/jpeg).");
                return View(carros);
            }
            else if (!(fotografia.ContentType == "image/jpeg" || fotografia.ContentType == "image/png" || fotografia.ContentType == "image/jpg"))
            {
                //write the error message
                ModelState.AddModelError("", "Please choose a valid format(png/jpeg)");
                //resend Control to View, with data provided by user
                return View(carros);
            }
            else
            {
                Guid g;
                g = Guid.NewGuid();
                string imageName = carros.Foto + "_" + g.ToString();
                string extensionOfImage = Path.GetExtension(fotografia.FileName).ToLower();
                imageName += extensionOfImage;
                carros.Foto = imageName;

            }

            var errors = ModelState.Values.SelectMany(v => v.Errors);

            if (ModelState.IsValid)
            {
                try
                {
                    //add advertisement data to database
                    _context.Add(carros);
                    //commit
                    await _context.SaveChangesAsync();
                }
                catch (Exception)
                {
                    // if the code arrives here, something wrong has appended
                    // we must fix the error, or at least report it

                    // add a model error to our code
                    ModelState.AddModelError("", "Something went wrong. I can not store data on database");
                    // eventually, before sending control to View
                    // report error. For instance, write a message to the disc
                    // or send an email to admin              

                    //// send control to View
                    return RedirectToAction("Index", "Home");
                    //return View(advertisement);
                }
                // save image file to disk
                //ask the server what address it wants to use
                string addressToStoreFile = _webHostEnvironment.WebRootPath;
                string newimglocation = Path.Combine(addressToStoreFile, "Photos", carros.Foto);

                //save image file to disk
                using var stream = new FileStream(newimglocation, FileMode.Create);
                await fotografia.CopyToAsync(stream);

                return RedirectToAction("Index", "Home");
                //return RedirectToAction(nameof(Index));

            }

            return RedirectToAction("Index", "Home");
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
