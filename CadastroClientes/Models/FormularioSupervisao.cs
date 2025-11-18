using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CadastroClientes.Models
{
    [Table("formulariossupervisao_pdf")]
    public class FormularioPdfEntity
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Cliente { get; set; }

        [Required]
        public DateTime DataSubmissao { get; set; }

        [Required]
        public byte[] PdfCompactado { get; set; }

        [Required]
        public DateTime ExpiraEm { get; set; }
    }
}
