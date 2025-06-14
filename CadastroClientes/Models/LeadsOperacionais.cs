using CadastroClientes.LeadsOperacionais;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CadastroCliente.Models
{
    [Table("LeadsOperacionais")]
    public class LeadsOperacionais
    {
        [Key]
        public int LeadId { get; set; }
        [Required]
        public string LeadName { get; set; }
        [Required]
        [EmailAddress]
        [StringLength(400)]
        public string LeadEmail { get; set; }
        [Required]
        [StringLength(400)]
        public string LeadPassword { get; set; }
        [Required]
        public LeadsRole LeadRole { get; set; }
    }
}
