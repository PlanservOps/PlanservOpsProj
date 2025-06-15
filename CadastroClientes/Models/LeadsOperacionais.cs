using CadastroClientes.LeadsOperacionais;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CadastroCliente.Models
{
    [Table("LeadsOperacionais")]
    public class LeadsOperacionais
    {
        [Key]
        [Column("leadid")]
        public int LeadId { get; set; }
        [Required]
        [StringLength(400)]
        [Column("leadname")]
        public string LeadName { get; set; }
        [Required]
        [EmailAddress]
        [StringLength(400)]
        [Column("leademail")]
        public string LeadEmail { get; set; }
        [Required]
        [StringLength(400)]
        [Column("leadpassword")]
        public string LeadPassword { get; set; }
        [Required]
        [Column("leadcreateddate")]
        public LeadsRole LeadRole { get; set; }
    }
}
