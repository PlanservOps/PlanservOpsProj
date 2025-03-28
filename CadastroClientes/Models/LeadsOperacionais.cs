using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CadastroClientes.Models
{
    [Table("LeadsOperacionais")]
    public class LeadsOperacionais
    {
        [Key]
        public int LeadsId { get; set; }
        [Required]
        public string LeadsName { get; set; }
        [Required]
        [EmailAddress]
        [StringLength(400)]
        public string Email { get; set; }
    }
}
