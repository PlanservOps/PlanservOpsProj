using CadastroCliente.Models;
using Microsoft.EntityFrameworkCore;

namespace CadastroCliente.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
        }

        public DbSet<Cliente> Cliente { get; set; }

        public DbSet<LeadsOperacionais> LeadsOperacionais { get; set; }
    }
}
