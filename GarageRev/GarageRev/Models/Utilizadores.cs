using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GarageRev.Models
{
    /// <summary>
    /// Descrição de cada Utilizador
    /// </summary>
    public class Utilizadores
    {
        public Utilizadores()
        {
            Reviews = new HashSet<Reviews>();
        }
        /// <summary>
        /// Identificador do Utilizador
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Nome do Utilizador
        /// </summary>
        [Required(ErrorMessage = "Este campo é obrigatório!")]
        [StringLength(30, ErrorMessage = "O {0} não pode ter mais de {1} carateres")]
        [RegularExpression("[A-ZÁÉÍÓÚÂÔa-záéíóúàèìòùãõõñâêîôûäëïöüç -']+", ErrorMessage = "Só pode escrever letras no {0}")]
        public string Nome { get; set; }
        /// <summary>
        /// email do Utilizador
        /// </summary>
        [Required(ErrorMessage = "Este campo é obrigatório!")]
        [EmailAddress(ErrorMessage = "Insira um email válido.")]
        public string Email { get; set; }
        /// <summary>
        /// Nacionalidade do Utilizador
        /// </summary>
        [StringLength(20, ErrorMessage = "A {0} não pode ter mais de {1} carateres")]
        public string Nacionalidade { get; set; }
        /// <summary>
        /// Idade do Utilizador
        /// </summary>
        [Display(Name = "Data de Nascimento")]
        [DisplayFormat(DataFormatString="{0:yyyy-MM-dd}", ApplyFormatInEditMode=true)]
        [DataType(DataType.Date)]
        public DateTime DataNascimento{ get; set; }
        /// <summary>
        /// Carro favorito do Utilizador
        /// </summary>
        [Display(Name = "Carro Favorito")]
        [ForeignKey(nameof(Carro))]
        public int CarroFavorito { get; set; }
        public Carros Carro { get; set; }
        public ICollection<Reviews> Reviews { get; set; }
    }
}
