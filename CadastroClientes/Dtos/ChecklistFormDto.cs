namespace CadastroClientes.Dtos
{
    public class ChecklistFormDto
    {
        public string Cliente { get; set; }
        public DateTime DataHoraSubmissao { get; set; }

        public List<string> ItensDescricao { get; set; } = new();
        public List<string> ItensHorarioInicio { get; set; } = new();
        public List<string> ItensHorarioFim { get; set; } = new();
        public List<bool> ItensConcluido { get; set; } = new();
        public List<IFormFile>? ItensImagem { get; set; }
    }
}
