using System.ComponentModel.DataAnnotations;

namespace GarageRev.Models
{
    /// <summary>
    /// Descrição de cada Carro
    /// </summary>
    public class Carros
    {
        /// <summary>
        /// Identificador de cada Carro
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Marca de cada carro
        /// </summary>
        public string Marca { get; set; }
        /// <summary>
        /// Modelo de cada carro
        /// </summary>
        public string Modelo { get; set; }
        /// <summary>
        /// Versão de cada Carro
        /// </summary>
        public string Versão { get; set; }
        /// <summary>
        /// Tipo de Combustivel de cada Carro
        /// </summary>
        public string Combustivel { get; set; }
        /// <summary>
        /// Ano de fabrico de cada Carro
        /// </summary>
        public DateOnly Ano { get; set; }
        /// <summary>
        /// Cilindrada, em cm3, de cada Carro
        /// </summary>
        public string Cilindrada { get; set; }
        /// <summary>
        /// Potencia, em cv, de cada Carro
        /// </summary>
        public int Potencia { get; set; }
        /// <summary>
        /// Tipo de Caixa de cada Carro
        /// </summary>
        public string TipoCaixa { get; set; }
        /// <summary>
        /// Numero de Portas de cada Carro
        /// </summary>
        public string Nportas { get; set; }
        /// <summary>
        /// Fotografias de cada carro
        /// </summary>
        public string Photo { get; set; }

    }
}
