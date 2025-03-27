using System.ComponentModel.DataAnnotations;

namespace CadastroColaboradores.Models
{
    public class Colaborador
    {
        public int ColaboradorId { get; set; }
        [Required]
        [StringLength(400)]
        public string Nome { get; set; }
        [Required]
        [EmailAddress]
        [StringLength(400)]
        public string Email { get; set; }
        [Required]
        public int Idade { get; set; }
    }
}
