using System.ComponentModel.DataAnnotations;
namespace GarageRev.Models
{
    /// <summary>
    /// Descrição de cada Categoria
    /// </summary>
    public class Categoria
    {
        /// <summary>
        /// identificador de cada Categoria
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Nome de cada Categoria
        /// </summary>
        public string NomeCat { get; set; }


    }
}
