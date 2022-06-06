using System.ComponentModel.DataAnnotations;

namespace GarageRev.Models
{
    /// <summary>
    /// Descrição de cada Carro
    /// </summary>
    public class Carros
    {

        public Carros()
        {
            Fotografias = new HashSet<Fotografias>();
            Categorias = new HashSet<Categorias>();
            Reviews = new HashSet<Reviews>();
        }

        /// <summary>
        /// Identificador de cada Carro
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Marca de cada carro
        /// </summary>
        [Required]
        public string Marca { get; set; }
        /// <summary>
        /// Modelo de cada carro
        /// </summary>
        [Required]
        public string Modelo { get; set; }
        /// <summary>
        /// Versao de cada Carro
        /// </summary>
        [Required]
        public string Versao { get; set; }
        /// <summary>
        /// Tipo de Combustivel de cada Carro
        /// </summary>
        [Required]
        [Display(Name = "Combustível")]
        public string Combustivel { get; set; }
        /// <summary>
        /// Ano de fabrico de cada Carro
        /// </summary>
        [Required]
        public int Ano { get; set; }
        /// <summary>
        /// CilindradaouCapacidadeBateria, Cilindrada em cm3, de cada Carro, eCapacidade de bateria em kWh 
        /// </summary>
        [Required]
        public int CilindradaouCapacidadeBateria { get; set; }
        
        /// <summary>
        /// Potencia, em PS, de cada Carro
        /// </summary>
        [Required]
        [Display(Name = "Potência")]
        public int Potencia { get; set; }
        /// <summary>
        /// Tipo de Caixa de cada Carro
        /// </summary>
        [Required]
        [Display(Name = "Tipo de Caixa")]
        public string TipoCaixa { get; set; }
        /// <summary>
        /// Numero de Portas de cada Carro
        /// </summary>
        [Required]
        [Display(Name = "Número de Portas")]
        public string Nportas { get; set; }

        public ICollection<Fotografias> Fotografias { get; set; }
        public ICollection<Categorias> Categorias { get; set; }
        public ICollection<Reviews> Reviews { get; set; }

    }
}
