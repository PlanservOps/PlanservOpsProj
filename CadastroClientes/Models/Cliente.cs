using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CadastroCliente.Models
{
    [Table("Cliente")]
    public class Cliente
    {
        [Key]
        public int ColaboradorId { get; set; }
        public string Posto { get; set; }
        [Required]
        [StringLength(400)]
        public string NomeResponsavel { get; set; }
        [Required]
        public string Contato { get; set; }
        //public string Contato { get; set; }
        [Required]
        public string Endereco { get; set; }
        [Required]
        [EmailAddress]
        [StringLength(400)]
        public string Email { get; set; }
        [Required]
        public string Bairro { get; set; }
    }
}
