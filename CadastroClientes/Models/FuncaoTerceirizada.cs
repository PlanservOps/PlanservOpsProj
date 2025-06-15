using CadastroCliente.Models;

namespace CadastroClientes.Models
{
    public class FuncaoTerceirizada
    {
        public int FuncaoTerceirizadaId { get; set; }
        public string FuncaoTerceirizadaNome { get; set; }

        public ICollection<ClienteTest> Clientes { get; set; } = new List<ClienteTest>();
    }
}
