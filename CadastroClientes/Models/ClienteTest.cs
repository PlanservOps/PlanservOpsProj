using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CadastroCliente.Models
{
    [Table("ClienteTest")]
    public class ClienteTest
    {
        [Key]
        public int ColaboradorId { get; set; }
        public string Posto { get; set; }
        [Required]
        [StringLength(400)]
        public string NomeResponsavel { get; set; }
        [Required]
        public string ContatoResponsavel { get; set; }
        public FuncaoEnum Funcao { get; set; }
        [Required]
        public string Endereco { get; set; }
        [Required]
        public string Bairro { get; set; }
        public string FuncoesTerceirizadas { get; set; }

        public enum FuncaoEnum
        {
            Sindica,
            Sindico,
            Gerente
        }
    }
}
