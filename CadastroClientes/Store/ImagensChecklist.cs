namespace CadastroClientes.Store
{
    public class ImagensChecklist
    {
        private readonly IWebHostEnvironment _env;

        public ImagensChecklist(IWebHostEnvironment env)
        {
            _env = env;
        }

        public string SalvarImagemTemporaria(byte[] imagemBytes, string nomeArquivo)
        {
            var rootPath = _env.WebRootPath ?? Path.Combine(_env.ContentRootPath, "wwwroot");
            var imagensPath = Path.Combine(rootPath, "temporary-images");

            Directory.CreateDirectory(imagensPath);

            var safeName = $"{DateTime.UtcNow:yyyyMMdd_HHmmssfff}_{Guid.NewGuid():N}{Path.GetExtension(nomeArquivo)}";

            var caminhoCompleto = Path.Combine(imagensPath, safeName);

            File.WriteAllBytes(caminhoCompleto, imagemBytes);

            return caminhoCompleto; // caminho absoluto!
        }

        internal void ExcluirImagemTemporaria(string path)
        {
            throw new NotImplementedException();
        }
    }
}
