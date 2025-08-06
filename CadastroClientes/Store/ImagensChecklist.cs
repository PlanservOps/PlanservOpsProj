namespace CadastroClientes.Store
{
    public class ImagensChecklist
    {
        private readonly IWebHostEnvironment _env;
        private readonly string _tempDir;

        public ImagensChecklist(IWebHostEnvironment env)
        {
            _env = env;
            _tempDir = Path.Combine(_env.WebRootPath, "temp-images");
            Directory.CreateDirectory(_tempDir);
        }

        public async Task<string> SalvarAsync(IFormFile imagem)
        {
            var nomeArquivo = $"{Guid.NewGuid()}{Path.GetExtension(imagem.FileName)}";
            var caminho = Path.Combine(_tempDir, nomeArquivo);

            using var stream = new FileStream(caminho, FileMode.Create);
            await imagem.CopyToAsync(stream);

            return caminho;
        }

        public void RemoverImagem(string caminho)
        {
            if (File.Exists(caminho))
                File.Delete(caminho);
        }
    }
}
