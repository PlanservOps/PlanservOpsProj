using CadastroCliente.Models;
using CadastroClientes.LeadsOperacionais;
using CadastroClientes.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CadastroCliente.Context
{
    public class AppDbContext : IdentityDbContext<IdentityUser, IdentityRole, string>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
        }

        public DbSet<ClienteTest> ClienteTest { get; set; }
        public DbSet<FormularioOperacional> FormularioOperacional { get; set; }
        public DbSet<Ocorrencias> Ocorrencias { get; set; }
        public DbSet<LeadsOperacionais> LeadsOperacionais { get; set; }
        public DbSet<FuncaoTerceirizada> FuncaoTerceirizada { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            base.OnModelCreating(modelBuilder);

            //Força todos os DateTime para UTC
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var property in entityType.GetProperties())
                {
                    if (property.ClrType == typeof(DateTime) || property.ClrType == typeof(DateTime?))
                    {
                        property.SetValueConverter(
                            new Microsoft.EntityFrameworkCore.Storage.ValueConversion.ValueConverter<DateTime, DateTime>(
                                v => v.ToUniversalTime(),
                                v => DateTime.SpecifyKind(v, DateTimeKind.Utc)
                            )
                        );
                    }
                }
            }

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
                    ClienteFuncoesTerceirizadasId = 1, // Agente de Portaria

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
                    ClienteFuncoesTerceirizadasId = 2 // Auxiliar de Serviços Gerais
                }
            );

            modelBuilder.Entity<FormularioOperacional>().HasData(
                new FormularioOperacional
                {
                    Id = 1,
                    DataEnvio = new DateTime(2024, 6, 15, 0, 0, 0, DateTimeKind.Utc),
                    HoraEnvio = new DateTime(2024, 6, 15, 8, 0, 0, DateTimeKind.Utc),
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
                    ClientePosto = "nomeposto",
                    ClienteResponsavel = "nomeresponsavel",
                    OcorrenciaData = new DateTime(2024, 6, 15, 8, 0, 0, DateTimeKind.Utc),
                    OcorrenciaDescricao = "Problema de vazamento no banheiro",
                    OcorrenciaStatus = CadastroClientes.Models.Ocorrencias.StatusEnum.Resolvido,
                },
                new Ocorrencias
                {
                    OcorrenciaId = 2,
                    ClientePosto = "nomeposto1",
                    ClienteResponsavel = "nomeresponsavel",
                    OcorrenciaData = new DateTime(2024, 6, 15, 9, 0, 0, DateTimeKind.Utc),
                    OcorrenciaDescricao = "Falta de energia na área comum",
                    OcorrenciaStatus = CadastroClientes.Models.Ocorrencias.StatusEnum.Resolvido,
                }
            );
            modelBuilder.Entity<LeadsOperacionais>().HasData(
                new LeadsOperacionais
                {
                    LeadId = 1,
                    LeadName = "João Silva",
                    LeadEmail = "",
                    LeadPassword = "senha123",
                    LeadRole = LeadsRole.AdminMaster
                }
            );

            modelBuilder.Entity<FuncaoTerceirizada>().HasData(
                new FuncaoTerceirizada { funcoaterceirizadaid = 1, funcaoTerceirizadaNome = "Agente de Portaria" },
                new FuncaoTerceirizada { funcoaterceirizadaid = 2, funcaoTerceirizadaNome = "Auxiliar de Serviços Gerais" },
                new FuncaoTerceirizada { funcoaterceirizadaid = 3, funcaoTerceirizadaNome = "Jardineiro" },
                new FuncaoTerceirizada { funcoaterceirizadaid = 4, funcaoTerceirizadaNome = "Concierge" }
            );

        }
    }
}
