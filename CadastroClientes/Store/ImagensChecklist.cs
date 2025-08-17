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

            if (!Directory.Exists(imagensPath))
                Directory.CreateDirectory(imagensPath);

            var caminhoCompleto = Path.Combine(imagensPath, nomeArquivo);
            File.WriteAllBytes(caminhoCompleto, imagemBytes);

            return caminhoCompleto; // caminho absoluto!
        }

    }
}
