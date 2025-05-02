using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CadastroCliente.Models
{
    [Table("clientetest")]
    public class ClienteTest
    {
        [Key]
        [Column("clienteid")]
        public int ClienteId { get; set; }
        [Required]
        [Column("clienteposto")]
        public string ClientePosto { get; set; }
        [Required]
        [StringLength(400)]
        [Column("clienteresponsavel")]
        public string ClienteResponsavel { get; set; }
        [Required]
        [Column("clientecontato")]
        public string ClienteContato { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        [Column("clientefuncaoresponsavel")]
        public FuncaoEnum ClienteFuncaoResponsavel { get; set; }
        [Required]
        [Column("clienteendereco")]
        public string ClienteEndereco { get; set; }
        [Required]
        [Column("clientebairro")]
        public string ClienteBairro { get; set; }
        [Column("clientefuncoesterceirizadas")]
        public string ClienteFuncoesTerceirizadas { get; set; }

        public enum FuncaoEnum
        {
            Sindica,
            Sindico,
            Gerente
        }
    }
}
