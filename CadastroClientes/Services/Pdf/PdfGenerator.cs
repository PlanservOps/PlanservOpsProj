using CadastroClientes.Models;
using QuestPDF.Companion;
using QuestPDF.Fluent;

namespace CadastroClientes.Services.Pdf
{
    public static class PdfGenerator
    {
        public static byte[] GerarFormularioPdf(FormularioOperacional formulario)
        {
            return new FormularioPdf(formulario).GeneratePdf();
        }

#if DEBUG
        public static void MostrarPreview(FormularioOperacional formulario)
        {
            new FormularioPdf(formulario).ShowInCompanion();
        }
#endif

    }
}
