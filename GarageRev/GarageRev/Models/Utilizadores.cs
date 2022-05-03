using System.ComponentModel.DataAnnotations;

namespace GarageRev.Models
{
    /// <summary>
    /// Descrição de cada Utilizador
    /// </summary>
    public class Utilizadores
    {
        /// <summary>
        /// Identificador do Utilizador
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Nome do Utilizador
        /// </summary>
        [Required]
        public string Nome { get; set; }
        /// <summary>
        /// email do Utilizador
        /// </summary>
        [Required]
        public string Email { get; set; }
        /// <summary>
        /// Nacionalidade do Utilizador
        /// </summary>
        public string Nacionalidade { get; set; }
        /// <summary>
        /// Idade do Utilizador
        /// </summary>
        public DateOnly DataNascimento{ get; set; }
        /// <summary>
        /// Carro favorito do Utilizador
        /// </summary>
        public string CarroFav { get; set; }
        public ICollection<Reviews> Reviews { get; set; }
    }
}
