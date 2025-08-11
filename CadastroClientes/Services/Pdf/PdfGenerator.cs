using CadastroClientes.Dtos;
using QuestPDF.Companion;
using QuestPDF.Fluent;

namespace CadastroClientes.Services.Pdf
{
    public static class PdfGenerator
    {
        public static byte[] GerarFormularioPdf( ChecklistFormDto form, ChecklistSendDto send, Dictionary <int, string> imagens)
        {
            return new FormularioPdf(form, send, imagens).GeneratePdf();
        }

#if DEBUG
        public static void MostrarPreview(ChecklistFormDto form, ChecklistSendDto send, Dictionary<int, string> imagens)
        {
            new FormularioPdf(form, send, imagens).ShowInCompanion(12500);
        }
#endif

    }
}
