using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CadastroClientes.Models
{
    [Table("formulariooperacional")]
    public class FormularioOperacional
    {
        [Key]
        [Column("formularioid")]
        public int Id { get; set; }

        [Required]
        [Column("dataenvio")]
        public DateTime DataEnvio { get; set; }

        [Required]
        [Column("horaenvio")]
        public DateTime HoraEnvio { get; set; }

        [Required]
        [Column("clientesatendidos")]
        public int ClientesAtendidos { get; set; }

        [Required]
        [Column("problemasreportados")]
        public int ProblemasReportados { get; set; }

        [Required]
        [Column("gestoresatendidos")]
        public int GestoresAtendidos { get; set; }

        [Required]
        [Column("clienteposto")]
        public string ClientePosto { get; set; }

        [Required]
        [StringLength(400)]
        [Column("problemasidentificados")]
        public string ProblemasIdentificados { get; set; }

        [Required]
        [StringLength(400)]
        [Column("solucoesapresentadas")]
        public string SolucoesApresentadas { get; set; }

        [Required]
        [Column("avaliacaoigo")]
        public int AvaliacaoIgo { get; set; }

        [Required]
        [Column("avaliacaorobson")]
        public int AvaliacaoRobson { get; set; }

        [Required]
        [StringLength(400)]
        [Column("observacoesgerais")]
        public string ObservacoesGerais { get; set; }
    }
}
