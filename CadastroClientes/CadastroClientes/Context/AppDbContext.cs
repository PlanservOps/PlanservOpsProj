using Microsoft.EntityFrameworkCore;

namespace CadastroColaboradores.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
        }

        public DbSet<Colaborador> Colaboradores { get; set; }
    }
}
