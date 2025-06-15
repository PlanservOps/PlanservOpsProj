using CadastroCliente.Models;
using CadastroClientes.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CadastroCliente.Context
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
        }

        public DbSet<ClienteTest> ClienteTest { get; set; }
        public DbSet<FormularioOperacional> FormularioOperacional { get; set; }
        public DbSet<Ocorrencias> Ocorrencias { get; set; }
        public DbSet<FuncaoTerceirizada> FuncaoTerceirizada { get; set; }

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
                    ClienteFuncoesTerceirizadasId = 1
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
                    ClienteFuncoesTerceirizadasId = 1
                }
            );

            modelBuilder.Entity<FormularioOperacional>().HasData(
                new FormularioOperacional
                {
                    Id = 1,
                    DataEnvio = new DateTime(2024, 6, 15),
                    HoraEnvio = new DateTime(2024, 6, 15, 8, 0, 0),
                    ClientesAtendidos = 10,
                    ProblemasReportados = 2,
                    GestoresAtendidos = 5,
                    ClientePostoId = 1,
                    ProblemasIdentificados = "Falta de limpeza na área comum",
                    SolucoesApresentadas = "Contratação de serviços de limpeza",
                    AvaliacaoIgo = 4,
                    AvaliacaoRobson = 5,
                    ObservacoesGerais = "Serviço de limpeza agendado para amanhã."
                }
            );

            modelBuilder.Entity<Ocorrencias>().HasData(
                new Ocorrencias
                {
                    OcorrenciaId = 1,
                    ClientePostoId = 1, 
                    ClienteResponsavelId = 1, 
                    OcorrenciaData = new DateTime(2024, 6, 15, 8, 0, 0),
                    OcorrenciaDescricao = "Problema de vazamento no banheiro",
                    OcorrenciaStatus = CadastroClientes.Models.Ocorrencias.StatusEnum.Resolvido,
                },
                new Ocorrencias
                {
                    OcorrenciaId = 2,
                    ClientePostoId = 2, 
                    ClienteResponsavelId = 2, 
                    OcorrenciaData = new DateTime(2024, 6, 15, 9, 0, 0),
                    OcorrenciaDescricao = "Falta de energia na área comum",
                    OcorrenciaStatus = CadastroClientes.Models.Ocorrencias.StatusEnum.Resolvido,
                }
            );

            modelBuilder.Entity<FuncaoTerceirizada>().HasData(
                new FuncaoTerceirizada { FuncaoTerceirizadaId = 1, FuncaoTerceirizadaNome = "Agente de Portaria" },
                new FuncaoTerceirizada { FuncaoTerceirizadaId = 2, FuncaoTerceirizadaNome = "Auxiliar de Serviços Gerais" },
                new FuncaoTerceirizada { FuncaoTerceirizadaId = 3, FuncaoTerceirizadaNome = "Jardineiro" },
                new FuncaoTerceirizada { FuncaoTerceirizadaId = 4, FuncaoTerceirizadaNome = "Concierge" }
            );

            modelBuilder.Entity<Ocorrencias>()
                .HasOne(o => o.ClientePosto)
                .WithMany()
                .HasForeignKey(o => o.ClientePostoId);

            modelBuilder.Entity<Ocorrencias>()
                .HasOne(o => o.ClienteResponsavel)
                .WithMany()
                .HasForeignKey(o => o.ClienteResponsavelId);
        }
    }
}
