using CadastroCliente.Models;
using Microsoft.EntityFrameworkCore;

namespace CadastroCliente.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
        }

        public DbSet<ClienteTest> ClienteTest { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClienteTest>().HasData(
                new ClienteTest
                {
                    ClienteId = 1,
                    ClientePosto = "Arvoredo",
                    ClienteResponsavel = "Antônio Henrique",
                    ClienteContato = "83981295876",
                    ClienteFuncaoResponsavel = Models.ClienteTest.FuncaoEnum.Sindico,
                    ClienteEndereco = "RUA DOMINGOS MOROSO, S/N MIRAMAR EM JOAO PESSOA NO ESTADO DA PB, CEP:58043-170",
                    ClienteBairro = "Miramar",
                    ClienteFuncoesTerceirizadas = "NPS"
                },
                new ClienteTest
                {
                    ClienteId = 2,
                    ClientePosto = "Imperial Bessa",
                    ClienteResponsavel = "Mariana",
                    ClienteContato = "83981295876",
                    ClienteFuncaoResponsavel = Models.ClienteTest.FuncaoEnum.Sindica,
                    ClienteEndereco = "AVENIDA PRESIDENTE AFONSO PENA, 382, BESSA, EM JOAO PESSOA NO ESTADO DA PB, CEP: 58035-030",
                    ClienteBairro = "Bessa",
                    ClienteFuncoesTerceirizadas = "NPS"
                }
            );
        }

    }
}
