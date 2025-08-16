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
            // Fallback: se WebRootPath for null, usar ContentRootPath/wwwroot
            var rootPath = _env.WebRootPath ?? Path.Combine(_env.ContentRootPath, "wwwroot");

            // Caminho da pasta de imagens temporárias
            var imagensPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "temporary-images");

            // Garantir que a pasta exista
            if (!Directory.Exists(imagensPath))
                Directory.CreateDirectory(imagensPath);

            // Caminho completo do arquivo
            var caminhoCompleto = Path.Combine(imagensPath, nomeArquivo);

            // Salvar arquivo no disco
            File.WriteAllBytes(caminhoCompleto, imagemBytes);

            // Retornar o caminho relativo para uso em URL
            return Path.Combine("ImagensChecklist", nomeArquivo).Replace("\\", "/");
        }
    }
}
