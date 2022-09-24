using GarageRev.Data;
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

namespace GarageRev.Controllers {
    public class CarrosController : Controller {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        /// <summary>
        /// variavel que recolhe os dados da pessoa que se autenticou
        /// </summary>
        private readonly UserManager<IdentityUser> _userManager;

        public CarrosController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment, UserManager<IdentityUser> userManager) {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _userManager = userManager;
        }

        // GET: Carros
        public async Task<IActionResult> Index() {
            /* execute the db command
             * select *
             * from Advertisements
             * 
             * and send Data to View
             */
            return View(await _context.Carros.ToListAsync());
        }

        // GET: Carros/Details/5
        public async Task<IActionResult> Details(int? id) {
            if (id == null) {
                return NotFound();
            }

            var carros = await _context.Carros
                .Include(c => c.ListaCategorias)
                .Include(f => f.Reviews)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carros == null) {
                return NotFound();
            }
            ViewBag.ListadeCategorias = _context.Categorias.OrderBy(c => c.NomeCat).ToList();

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
        [Authorize]
        public async Task<IActionResult> ApresentaReview(int Id, string comentario) {
            var utilizador = _context.Utilizadores.Where(u => u.IdUtilizador == _userManager.GetUserId(User)).FirstOrDefault();
            {
                //variavel que contem os dados do carro, review e utilizador
                var review = new Reviews {
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
        [Authorize(Roles = "Admin")]
        // GET: Carros/Create
        public IActionResult Create() {
            ViewBag.ListadeCategorias = _context.Categorias.OrderBy(c => c.NomeCat).ToList();

            return View();
        }

        // POST: Carros/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([Bind("Id,Marca,Modelo,Versao,Combustivel,Ano,CilindradaouCapacidadeBateria,Potencia,TipoCaixa,Nportas,Foto")] Carros carros, IFormFile fotografia, int[] CategoriaEscolhida) {
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
            //ve se o array com a lista de categorias escolhidas está vazio
            if (CategoriaEscolhida.Length == 0) {
                ModelState.AddModelError("", "É necessário selecionar pelo menos uma categoria.");
                ViewBag.ListadeCategorias = _context.Categorias.OrderBy(c => c.NomeCat).ToList();

                return View(carros);
            }
            List<Categorias> listadeCategoriasEscolhidas = new List<Categorias>();

            foreach (int item in CategoriaEscolhida) {
                Categorias cat = _context.Categorias.Find(item);
                listadeCategoriasEscolhidas.Add(cat);
            }

            carros.ListaCategorias = listadeCategoriasEscolhidas;



            if (fotografia == null) {
                ModelState.AddModelError("", "Please insert an image with a valid format(png/jpeg).");
                return View(carros);
            }
            else if (!(fotografia.ContentType == "image/jpeg" || fotografia.ContentType == "image/png" || fotografia.ContentType == "image/jpg")) {
                //write the error message
                ModelState.AddModelError("", "Please choose a valid format(png/jpeg)");
                //resend Control to View, with data provided by user
                return View(carros);
            }
            else {
                Guid g;
                g = Guid.NewGuid();
                string imageName = carros.Foto + "_" + g.ToString();
                string extensionOfImage = Path.GetExtension(fotografia.FileName).ToLower();
                imageName += extensionOfImage;
                carros.Foto = imageName;

            }

            var errors = ModelState.Values.SelectMany(v => v.Errors);

            if (ModelState.IsValid) {
                try {
                    //add advertisement data to database
                    _context.Add(carros);
                    //commit
                    await _context.SaveChangesAsync();
                }
                catch (Exception) {
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
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id) {
            if (id == null) {
                return NotFound();
            }

            var carros = await _context.Carros
                                        .Include(c => c.ListaCategorias)
                                        .FirstOrDefaultAsync(m => m.Id == id);

            if (carros == null) {
                return NotFound();
            }
            ViewBag.ListadeCategorias = _context.Categorias.OrderBy(c => c.NomeCat).ToList();

            return View(carros);
        }





        // POST: Carros/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Marca,Modelo,Versao,Combustivel,Ano,CilindradaouCapacidadeBateria,Potencia,TipoCaixa,Nportas,Foto,Categorias")] Carros newCarro, IFormFile fotografia, int[] CategoriaEscolhida) {
            if (id != newCarro.Id) {
                return NotFound();
            }

            // var auxiliar
            bool apagaOldFoto = false;

            //obtem dados anteriormente guardados
            var carro = await _context.Carros
                                      .Where(c => c.Id == id)
                                      .Include(c => c.ListaCategorias)
                                      .FirstOrDefaultAsync();
            //obtem a lista dos IDs das Categorias associadas ao carro antes da edição
            var oldListadeCategorias = carro.ListaCategorias
                                            .Select(c => c.Id)
                                            .ToList();
            //avaliar se o utilizador alterou alguma categoria associada ao carro
            IEnumerable<int> adicionadas;
            if (oldListadeCategorias.Any()) { adicionadas = CategoriaEscolhida.Except(oldListadeCategorias); }
            else { adicionadas = CategoriaEscolhida; }
            var retiradas = oldListadeCategorias.Except(CategoriaEscolhida.ToList());

            //se alguma categoria foi adicionada ou retirada
            //é necessário alterar a lista de cat

            if (adicionadas.Any() || retiradas.Any()) {
                if (retiradas.Any()) {
                    //retira cat
                    foreach (int oldCat in retiradas) {
                        var catToRemove = carro.ListaCategorias.FirstOrDefault(c => c.Id == oldCat);
                        carro.ListaCategorias.Remove(catToRemove);
                    }
                }
                if (adicionadas.Any()) {
                    //adiciona cat
                    foreach (int newCat in adicionadas) {
                        var catToAdd = _context.Categorias.FirstOrDefault(c => c.Id == newCat);
                        carro.ListaCategorias.Add(catToAdd);
                    }
                }
            }

            //se a foto nao for nula, realiza os processo
            if (fotografia != null) {
                if (!(fotografia.ContentType == "image/jpeg" || fotografia.ContentType == "image/png" || fotografia.ContentType == "image/jpg")) {
                    //write the error message
                    ModelState.AddModelError("", "Please choose a valid format(png/jpeg)");
                    //resend Control to View, with data provided by user
                    return View(newCarro);
                }
                else {
                    apagaOldFoto = true;
                    Guid g;
                    g = Guid.NewGuid();
                    string imageName = newCarro.Marca + "_" + newCarro.Modelo + "_" + newCarro.Versao + "_" + g.ToString();
                    string extensionOfImage = Path.GetExtension(fotografia.FileName).ToLower();
                    imageName += extensionOfImage;
                    carro.Foto = imageName;


                    string addressToStoreFile = _webHostEnvironment.WebRootPath;
                    string newImgLocation = Path.Combine(addressToStoreFile, "Photos", newCarro.Foto);

                    //save image file to disk
                    using var stream = new FileStream(newImgLocation, FileMode.Create);
                    await fotografia.CopyToAsync(stream);
                }
            }


            if (ModelState.IsValid) {
                // foto antiga do carro
                string fotoParApagar = carro.Foto;

                try {

                    // Transferir os dados do 'newCarro' para o 'carro'
                    carro.Ano = newCarro.Ano;
                    carro.CilindradaouCapacidadeBateria = newCarro.CilindradaouCapacidadeBateria;
                    carro.Combustivel = newCarro.Combustivel;
                    carro.Marca = newCarro.Marca;
                    carro.Modelo = newCarro.Modelo;
                    carro.Nportas = newCarro.Nportas;
                    carro.Potencia = newCarro.Potencia;
                    carro.TipoCaixa = newCarro.TipoCaixa;
                    carro.Versao = newCarro.Versao;

                    _context.Update(carro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException ex) {
                    if (!CarrosExists(carro.Id)) {
                        return NotFound();
                    }
                    else {
                        throw;
                    }
                }
                //se correr tudo bem
                return Redirect("~/");
            }
            return View(newCarro);
        }

        // GET: Carros/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id) {
            if (id == null) {
                return NotFound();
            }

            var carros = await _context.Carros
                .Include(c => c.ListaCategorias)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carros == null) {
                return NotFound();
            }
            ViewBag.ListadeCategorias = _context.Categorias.OrderBy(c => c.NomeCat).ToList();

            return View(carros);
        }

        // POST: Carros/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id) {
            //obtem o carro a ser apagado
            var carro = await _context.Carros
                                      .Where(c => c.Id == id)
                                      .Include(c => c.ListaCategorias)
                                      .FirstOrDefaultAsync();
            //obtem a lista de Categorias a remover do carro a ser apagado
            var ListadeCategorias = carro.ListaCategorias
                                            .Select(c => c.Id)
                                            .ToList();
            //valida se a lista está vazia
            if (ListadeCategorias.Any()) {
                //percorre o id de cada cat 1 a 1 na lista
                foreach (int cat in ListadeCategorias) {
                    //encontra a categoria a remover pelo id
                    var catToRemove = _context.Categorias.FirstOrDefault(c => c.Id == cat);
                    //remove
                    carro.ListaCategorias.Remove(catToRemove);

                }
            }
            _context.Carros.Remove(carro);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarrosExists(int id) {
            return _context.Carros.Any(e => e.Id == id);
        }
    }
}
