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
                    ColaboradorId = 1,
                    Posto = "Arvoredo",
                    NomeResponsavel = "Antônio Henrique",
                    ContatoResponsavel = "83981295876",
                    Funcao = Models.ClienteTest.FuncaoEnum.Sindico, 
                    Endereco = "RUA DOMINGOS MOROSO, S/N MIRAMAR EM JOAO PESSOA NO ESTADO DA PB, CEP:58043-170",
                    Bairro = "Miramar",
                    FuncoesTerceirizadas = "NPS"
                },
                new ClienteTest
                {
                    ColaboradorId = 2,
                    Posto = "Imperial Bessa",
                    NomeResponsavel = "Mariana",
                    ContatoResponsavel = "83981295876",
                    Funcao = Models.ClienteTest.FuncaoEnum.Sindica,
                    Endereco = "AVENIDA PRESIDENTE AFONSO PENA, 382, BESSA, EM JOAO PESSOA NO ESTADO DA PB, CEP: 58035-030",
                    Bairro = "Bessa",
                    FuncoesTerceirizadas = "NPS"
                }
                );
        }

    }
}
