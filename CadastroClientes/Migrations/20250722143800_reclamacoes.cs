using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CadastroClientes.Migrations
{
    /// <inheritdoc />
    public partial class reclamacoes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "formulariooperacional",
                keyColumn: "formularioid",
                keyValue: 1);

            migrationBuilder.CreateTable(
                name: "reclamacoes",
                columns: table => new
                {
                    reclamacaoid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    clienteposto = table.Column<string>(type: "text", nullable: false),
                    reclamacaodescricao = table.Column<string>(type: "text", nullable: false),
                    reclamacaodata = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    DataResolucao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reclamacoes", x => x.reclamacaoid);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "reclamacoes");

            migrationBuilder.InsertData(
                table: "formulariooperacional",
                columns: new[] { "formularioid", "avaliacaoigo", "avaliacaorobson", "clienteposto", "clientesatendidos", "dataenvio", "gestoresatendidos", "horaenvio", "observacoesgerais", "problemasidentificados", "problemasreportados", "solucoesapresentadas" },
                values: new object[] { 1, 4, 5, "Arvoredo", 10, new DateTime(2024, 6, 15, 0, 0, 0, 0, DateTimeKind.Utc), 5, new DateTime(2024, 6, 15, 8, 0, 0, 0, DateTimeKind.Utc), "Serviço de limpeza agendado para amanhã.", "Falta de limpeza na área comum", 2, "Contratação de serviços de limpeza" });
        }
    }
}
