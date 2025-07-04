﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CadastroCliente.Models
{
    [Table("clienteshumanas")]
    public class ClientesHumanas
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
        [Required]
        //[JsonConverter(typeof(JsonStringEnumConverter))]
        [Column("clientefuncaoresponsavel")]
        public string ClienteFuncaoResponsavel { get; set; }
        [Required]
        [Column("clienteendereco")]
        public string ClienteEndereco { get; set; }
        [Required]
        [Column("clientebairro")]
        public string ClienteBairro { get; set; }

        [Column("clientefuncoesterceirizadas")]
        public int? ClienteFuncoesTerceirizadasId { get; set; }

        public enum FuncaoEnum
        {
            Sindica,
            Sindico,
            Gerente
        }
    }
}
