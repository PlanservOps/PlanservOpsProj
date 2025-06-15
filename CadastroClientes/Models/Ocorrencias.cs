using CadastroCliente.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CadastroClientes.Models
{
    [Table("ocorrencias")]
    public class Ocorrencias
    {
        [Key]
        [Column("ocorrenciaid")]
        public int OcorrenciaId { get; set; }
        [Required]
        [Column("clientepostoid")]
        public int ClientePostoId { get; set; }
        public virtual ClienteTest ClientePosto { get; set; }
        [Required]
        [Column("clienteresponsavelid")]
        public int ClienteResponsavelId { get; set; }
        public virtual ClienteTest ClienteResponsavel { get; set; }
        [Required]
        [Column("ocorrenciadata")]
        public DateTime OcorrenciaData { get; set; }
        [Required]
        [Column("ocorrenciadescricao")]
        public string OcorrenciaDescricao { get; set; }
        [Required]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        [Column("ocorrenciastatus")]
        public StatusEnum OcorrenciaStatus { get; set; }
        public enum StatusEnum
        {
            Pendente,
            PrioridadeAlta,
            NaoAtendido,
            Resolvido
        }
    }
}
