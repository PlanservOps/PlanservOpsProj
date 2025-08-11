namespace CadastroClientes.Dtos
{
    public class ChecklistSendDto
    {
        public string Cliente { get; set; }
        public DateTime DataHoraSubmissao { get; set; }
        public List<ChecklistItemDto> Itens { get; set; }
    }
}
