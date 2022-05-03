using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GarageRev.Models
{
    /// <summary>
    /// Descrição de cada Review
    /// </summary>
    public class Reviews
    {
        /// <summary>
        /// Identificador da Review
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Conteudo da Review
        /// </summary>
        [Required]
        public string Comentario { get; set; }

        [ForeignKey(nameof(Utilizador))]
        public int UtilizadorFK { get; set; }
        public Utilizadores Utilizador { get; set; }

        [ForeignKey(nameof(Carro))]
        public int CarroFK { get; set; }
        public Carros Carro { get; set; }




    }
}
