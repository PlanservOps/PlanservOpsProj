using CadastroClientes.Dtos;
using QuestPDF.Companion;
using QuestPDF.Fluent;

namespace CadastroClientes.Services.Pdf
{
    public static class PdfGenerator
    {
        public static byte[] GerarFormularioPdf( ChecklistFormDto form, Dictionary <int, string> imagens)
        {
            return new FormularioPdf(form, imagens).GeneratePdf();
        }

#if DEBUG
        public static void MostrarPreview(ChecklistFormDto form, Dictionary<int, string> imagens)
        {
            new FormularioPdf(form, imagens).ShowInCompanion(12500);
        }
#endif

    }
}
