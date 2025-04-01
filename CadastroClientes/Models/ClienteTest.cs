using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CadastroCliente.Models
{
    [Table("ClienteTest")]
    public class ClienteTest
    {
        [Key]
        public int ClienteId { get; set; }
        [Required]
        public string ClientePosto { get; set; }
        [Required]
        [StringLength(400)]
        public string ClienteResponsavel { get; set; }
        [Required]
        public string ClienteContato { get; set; }
        public FuncaoEnum ClienteFuncaoResponsavel { get; set; }
        [Required]
        public string ClienteEndereco { get; set; }
        [Required]
        public string ClienteBairro { get; set; }
        public string ClienteFuncoesTerceirizadas { get; set; }

        public enum FuncaoEnum
        {
            Sindica,
            Sindico,
            Gerente
        }
    }
}
