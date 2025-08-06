#if DEBUG
using CadastroClientes.Dtos;
using CadastroClientes.Services.Pdf;

namespace CadastroClientes.Debug
{
    public class PdfPreviewRunner
    {
        public static void Run()
        {
            var form = new ChecklistFormDto
            {
                ClienteId = Guid.NewGuid(),
                DataHoraSubmissao = DateTime.Now,
                Itens = new List<ChecklistItemDto>
                {
                    new ChecklistItemDto
                    {
                        HorarioInicio = "06:00",
                        HorarioFim = "06:10",
                        Descricao = "Retirada de material de limpeza",
                        Concluido = true
                    },
                    new ChecklistItemDto
                    {
                        HorarioInicio = "06:10",
                        HorarioFim = "07:30",
                        Descricao = "Limpeza dos elevadores e halls",
                        Concluido = true
                    },
                    new ChecklistItemDto
                    {
                        HorarioInicio = "07:30",
                        HorarioFim = "08:30",
                        Descricao = "Limpeza dos banheiros",
                        Concluido = false
                    }
                }
            };

            // Simula caminhos de imagens existentes (adicione alguns arquivos .jpg no seu projeto para teste)
            var imagens = new Dictionary<int, string>
            {
                { 0, "Root/temp-images/exemplo1.jpg" },
                { 1, "Root/temp-images/exemplo2.jpg" }
            };

            PdfGenerator.MostrarPreview(form, imagens);
        }
    }
}
#endif
