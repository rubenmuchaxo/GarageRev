using GarageRev.Data;
using Microsoft.AspNetCore.Mvc;
using GarageRev.Models;
using Microsoft.EntityFrameworkCore;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GarageRev.Controllers.Apicontroller {
    [Route("api/[controller]")]
    [ApiController]
    public class CarrosAPI : ControllerBase {
        private readonly ApplicationDbContext _context;

        private readonly IWebHostEnvironment _caminho;

        public CarrosAPI(ApplicationDbContext context, IWebHostEnvironment caminho) {
            _context = context;
            _caminho = caminho;
        }



        // GET: api/<CarrosAPI>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ApiViewModel>>> GetAllCarros() {
            //busca aos carros da db os dados para criar um API ViewMODEL,
            return await _context.Carros.Select(x => new ApiViewModel {
                IdCarro = x.Id,
                Ano = x.Ano,
                CilindradaouCapacidadeBateria = x.CilindradaouCapacidadeBateria,
                Combustivel = x.Combustivel,
                Foto = x.Foto,
                Marca = x.Marca,
                Modelo = x.Modelo,
                Nportas = x.Nportas,
                Potencia = x.Potencia,
                TipoCaixa = x.TipoCaixa,
                Versao = x.Versao
            })
                                        .OrderBy(x => x.Marca)
                                        .ToListAsync();

        }

        // GET api/<CarrosAPI>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Carros>> GetACarro(int id) {
            // car vai ser o carro cujo id seja igual ao do httpget
            var car = await _context.Carros.FindAsync(id);
            //se car for null da not found
            if (car == null) {
                return NotFound();
            }
            //senao retorna os dados do car cujo id pertence
            return car;
            
        }

        // POST api/<CarrosAPI>
        //Publicar um carro? um create?de certa forma...
        [HttpPost]
        public async Task<ActionResult<Carros>> PostCarro([FromForm] Carros car, IFormFile newfoto) {
            // sem a anotação [FromForm] o ASP .NET não sabe ler os dados
            // que lhe estão a ser enviados
            car.Foto = "noCar.png";
            try {
                _context.Carros.Add(car);
                await _context.SaveChangesAsync();
            } catch (Exception ex) {

                throw;
            }

            return CreatedAtAction("GetACarro", new {id = car.Id }, car);

        }

        // PUT api/<CarrosAPI>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> PutCarro(int id, Carros car) {
            if (id != car.Id) {
                return BadRequest();
            }
            _context.Entry(car).State = EntityState.Modified;


            try {
                await _context.SaveChangesAsync();
            } catch (DbUpdateConcurrencyException) {
                if (!CarroExists(id)) {
                    return NotFound();
                }
                else {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE api/<CarrosAPI>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCarro(int id) {
            var car = await _context.Carros.FindAsync(id);
            if (car == null) {
                return NotFound();
            }

            _context.Carros.Remove(car);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CarroExists(int id) {
            return _context.Carros.Any(x => x.Id == id);
        }
    }
}
