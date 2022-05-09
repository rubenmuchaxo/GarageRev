using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GarageRev.Models
{
    /// <summary>
    /// Descrição de cada Fotografia
    /// </summary>
    public class Fotografias
    {
        /// <summary>
        /// Identificador de cada Fotografia
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Caminho de cada Fotografia
        /// </summary>
        public string FotoPath { get; set; }

        [ForeignKey(nameof(Carro))]
        public int CarroFK { get; set; }
        public Carros Carro { get; set; }
    }
}
