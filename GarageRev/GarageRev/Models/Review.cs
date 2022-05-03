using System.ComponentModel.DataAnnotations;

namespace GarageRev.Models
{
    /// <summary>
    /// Descrição de cada Review
    /// </summary>
    public class Review
    {
        /// <summary>
        /// Identificador da Review
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Conteudo da Review
        /// </summary>
        public string Comentario { get; set; }




    }
}
