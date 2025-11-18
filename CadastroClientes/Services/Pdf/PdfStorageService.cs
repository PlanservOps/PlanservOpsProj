using CadastroCliente.Context;
using CadastroClientes.Models;
using Microsoft.EntityFrameworkCore;
using System.IO.Compression;

namespace CadastroClientes.Services.Pdf
{
    public class PdfStorageService
    {
        private readonly AppDbContext _db;

        public PdfStorageService(AppDbContext db)
        {
            _db = db;
        }

        // Compacta e salva no banco
        public async Task<Guid> SalvarPdfAsync(string cliente, DateTime data, byte[] pdfBytes)
        {
            var compactado = Compactar(pdfBytes);
            var entity = new FormularioPdfEntity
            {
                Id = Guid.NewGuid(),
                Cliente = cliente,
                DataSubmissao = data,
                PdfCompactado = compactado,
                ExpiraEm = DateTime.UtcNow.AddDays(30)
            };

            _db.Add(entity);
            await _db.SaveChangesAsync();
            return entity.Id;
        }

        // Recupera e descompacta
        public async Task<byte[]?> ObterPdfAsync(Guid id)
        {
            var entity = await _db.Set<FormularioPdfEntity>().FindAsync(id);
            if (entity == null || entity.ExpiraEm < DateTime.UtcNow)
                return null;

            return Descompactar(entity.PdfCompactado);
        }

        // Métodos utilitários
        private static byte[] Compactar(byte[] data)
        {
            using var output = new MemoryStream();
            using (var gzip = new GZipStream(output, CompressionMode.Compress))
                gzip.Write(data, 0, data.Length);
            return output.ToArray();
        }

        private static byte[] Descompactar(byte[] data)
        {
            using var input = new MemoryStream(data);
            using var gzip = new GZipStream(input, CompressionMode.Decompress);
            using var output = new MemoryStream();
            gzip.CopyTo(output);
            return output.ToArray();
        }

        // Limpeza de PDFs expirados
        public async Task RemoverExpiradosAsync()
        {
            var expirados = await _db.Set<FormularioPdfEntity>()
                .Where(x => x.ExpiraEm < DateTime.UtcNow)
                .ToListAsync();

            if (expirados.Any())
            {
                _db.RemoveRange(expirados);
                await _db.SaveChangesAsync();
            }
        }
    }
}
