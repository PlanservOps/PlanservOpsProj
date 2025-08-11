namespace CadastroClientes.Dtos
{
    public class ChecklistItemDto
    {
        public string HorarioInicio { get; set; }
        public string HorarioFim { get; set; }
        public string Descricao { get; set; }
        public bool Concluido { get; set; }
        public IFormFile? Imagem { get; set; }
    }
}
