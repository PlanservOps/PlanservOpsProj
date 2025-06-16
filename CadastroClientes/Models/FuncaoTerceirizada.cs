using CadastroCliente.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CadastroClientes.Models
{
    [Table("funcoaterceirizada")]
    public class FuncaoTerceirizada
    {
        [Key]
        [Column("funcoaterceirizadaid")]
        public int FuncaoTerceirizadaId { get; set; }
        [Column("funcaoTerceirizadaNome", TypeName = "varchar(100)")]
        public string FuncaoTerceirizadaNome { get; set; }

    }
}
