using System.ComponentModel.DataAnnotations;
namespace GarageRev.Models
{
    /// <summary>
    /// Descrição de cada Categoria
    /// </summary>
    public class Categorias
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

        public ICollection<Carros> Carros { get; set; }

    }
}
