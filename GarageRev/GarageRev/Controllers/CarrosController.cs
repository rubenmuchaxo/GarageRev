using GarageRev.Data;
using GarageRev.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
        /// <summary>
        /// variavel que recolhe os dados da pessoa que se autenticou
        /// </summary>
        private readonly UserManager<IdentityUser> _userManager;

        public CarrosController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _userManager = userManager;
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
                .Include(c => c.ListaCategorias)
                .Include(f => f.Reviews)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carros == null)
            {
                return NotFound();
            }

            return View(carros);
        }

        /// <summary>
        /// Apresentar as reviews
        /// falta parte de autenticação para poder verificar as reviews
        /// </summary>
        /// <param name="idCarro">Id do Carro respetivo à review</param>
        /// <param name="comentario"> conteudo da review</param>
        /// <returns></returns>
        [HttpPost]
        //[Authorize]
        public async Task<IActionResult> ApresentaReview(int Id, string comentario)
        {
            var utilizador = _context.Utilizadores.Where(u => u.IdUtilizador == _userManager.GetUserId(User)).FirstOrDefault();
            {
                //variavel que contem os dados do carro, review e utilizador
                var review = new Reviews
                {
                    CarroFK = Id,
                    Comentario = comentario.Replace("\r\n", "<br />"),
                    Data = DateTime.Now,
                   Utilizador = utilizador
                };
                //adiciona a review à Base de Dados
                _context.Reviews.Add(review);
                //Guarda as alterações na Base de Dados
                await _context.SaveChangesAsync();
                //redirecionar para a página de detalhes de carro
                return RedirectToAction(nameof(Details), new { Id = Id });
            }
        }
        //[Authorize]
        // GET: Carros/Create
        public IActionResult Create()
        {
            // lista de todas as categorias existentes
            ViewBag.ListaCategorias = _context.Categorias.OrderBy(c => c.Id).ToList();
            return View();
        }

        // POST: Carros/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Marca,Modelo,Versao,Combustivel,Ano,CilindradaouCapacidadeBateria,Potencia,TipoCaixa,Nportas,Foto")] Carros carros, IFormFile fotografia, int[] CategoriaEscolhida)
        {
            // avalia se o array com a lista de categorias escolhidas associadas ao anume está vazio ou não
            if (CategoriaEscolhida.Length == 0)
            {
                //É gerada uma mensagem de erro
                ModelState.AddModelError("", "É necessário selecionar pelo menos uma categoria.");
                // gerar a lista Categorias que podem ser associadas ao anime
                ViewBag.ListaCategorias = _context.Categorias.OrderBy(c => c.Id).ToList();
                // devolver controlo à View
                return View(carros);
            }

            // criar uma lista com os objetos escolhidos das Categorias
            List<Categorias> listaDeCategoriasEscolhidas = new List<Categorias>();
            // Para cada objeto escolhido..
            foreach (int item in CategoriaEscolhida)
            {
                //procurar a categoria
                Categorias Categoria = _context.Categorias.Find(item);
                // adicionar a Categoria à lista
                listaDeCategoriasEscolhidas.Add(Categoria);
            }

            // adicionar a lista ao objeto de "Animes"
            carros.ListaCategorias = listaDeCategoriasEscolhidas;

            ////vai percorrer todas as strings category selecionadas na collection choosen category
            //foreach (String category in ChoosenCategory)
            //{

            //    //vai percorrer as categorias ja existentes
            //    foreach (Categorias category2 in _context.Categorias)
            //    {
            //        //se a categoria selecionada ja existir na base de dados
            //        if (category2.NomeCat == category)
            //        {
            //            //adicionamos a categoria selecionada ao carro
            //            carros.Categorias.Add(category2);
            //        }
            //    }
            //}

            //if (ChoosenCategory.Count == 0)
            //{
            //    ModelState.AddModelError("", "Please choose at least a category.");
            //    return View(carros);
            //}

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
        //[Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            // lista de todas as categorias existentes
            ViewBag.ListaCategorias = _context.Categorias.OrderBy(c => c.Id).ToList();

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
        //[Authorize(Roles ="Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Marca,Modelo,Versao,Combustivel,Ano,CilindradaouCapacidadeBateria,Potencia,TipoCaixa,Nportas,Foto,Categorias")] Carros carros, IFormFile fotografia, int[] CategoriaEscolhida)
        {
            if (id != carros.Id)
            {
                return NotFound();
            }

            // avalia se o array com a lista de categorias escolhidas associadas ao carro está vazio ou não
            if (CategoriaEscolhida.Length == 0)
            {
                //É gerada uma mensagem de erro
                ModelState.AddModelError("", "É necessário selecionar pelo menos uma categoria.");
                // gerar a lista Categorias que podem ser associadas ao carro
                ViewBag.ListaCategorias = _context.Categorias.OrderBy(c => c.Id).ToList();
                // devolver controlo à View
                return View(carros);
            }

            // criar uma lista com os objetos escolhidos das Categorias
            List<Categorias> listaDeCategoriasEscolhidas = new List<Categorias>();
            // Para cada objeto escolhido..
            foreach (int item in CategoriaEscolhida)
            {
                //procurar a categoria
                Categorias Categoria = _context.Categorias.Find(item);
                // adicionar a Categoria à lista
                listaDeCategoriasEscolhidas.Add(Categoria);
            }

            // adicionar a lista ao objeto de "carros"
            carros.ListaCategorias = listaDeCategoriasEscolhidas;
            //se a foto nao for nula, realiza os processo
            if (fotografia != null)
            {
                if (!(fotografia.ContentType == "image/jpeg" || fotografia.ContentType == "image/png" || fotografia.ContentType == "image/jpg"))
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
                    string imageName = carros.Marca + "_" +carros.Modelo + "_"+carros.Versao + "_" + g.ToString();
                    string extensionOfImage = Path.GetExtension(fotografia.FileName).ToLower();
                    imageName += extensionOfImage;
                    carros.Foto = imageName;
                }

                string addressToStoreFile = _webHostEnvironment.WebRootPath;
                string newimglocation = Path.Combine(addressToStoreFile, "Photos", carros.Foto);

                //save image file to disk
                using var stream = new FileStream(newimglocation, FileMode.Create);
                await fotografia.CopyToAsync(stream);




            }
            else
            {
                Carros carros1 = _context.Carros.Find(carros.Id);

                _context.Entry<Carros>(carros1).State = EntityState.Detached;  


                carros.Foto = carros1.Foto;
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
        //[Authorize]
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
        //[Authorize(Roles = "Admin")]
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