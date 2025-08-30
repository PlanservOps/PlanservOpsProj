using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CadastroClientes.Models
{
    [Table("reclamacoes")]
    public class Reclamacoes
    {
        [Key]
        [Column("reclamacaoid")]
        public int Reclamacaoid { get; set; }

        [Required]
        [Column("clienteposto")]
        public string ClientePosto { get; set; }

        [Required]
        [Column("reclamacaodescricao")]
        public string ReclamacaoDescricao { get; set; }

        [Required]
        [Column("reclamacaodata")]
        public DateTime ReclamacaoData { get; set; }
        [Required]
        [Column("reclamacaoresolucao")]
        public string ReclamacaoResolucao { get; set; }

        public StatusReclamacao Status { get; set; } = StatusReclamacao.Pendente;
        public DateTime? DataResolucao { get; set; }
    }

    public enum StatusReclamacao
    {
        Pendente = 0,
        Resolvido = 1,
        Cancelado = 2
    }
}
