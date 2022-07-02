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
            Categorias = new HashSet<Categorias>();
            Reviews = new HashSet<Reviews>();
            Utilizadores = new HashSet<Utilizadores>();
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
        /// Versão de cada Carro
        /// </summary>
        [Required]
        [Display(Name = "Versão")]
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
        /// Cilindrada, em cm3, de cada Carro ou bateria em kwh
        /// </summary>
        [Required]
        [Display(Name = "Cilindrada/Bateria(cm3/kWh")]
        public int CilindradaouCapacidadeBateria { get; set; }
        /// <summary>
        /// Potencia, em cv, de cada Carro
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
        /// <summary>
        /// Fotografias de cada carro
        /// </summary>
        /// 
        public string Foto { get; set; }

        public ICollection<Categorias> Categorias { get; set; }
        public ICollection<Reviews> Reviews { get; set; }
        public ICollection<Utilizadores> Utilizadores { get; set; }

    }
}
