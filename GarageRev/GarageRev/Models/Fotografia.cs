using System.ComponentModel.DataAnnotations;

namespace GarageRev.Models
{
    /// <summary>
    /// Descrição de cada Fotografia
    /// </summary>
    public class Fotografia
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
    }
}
