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
        [Column("clienteposto")]
        public string ClientePosto { get; set; }
        [Required]
        [Column("clienteresponsavel")]
        public string ClienteResponsavel { get; set; }
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
