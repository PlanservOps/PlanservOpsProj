using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CadastroClientes.Migrations
{
    /// <inheritdoc />
    public partial class funcaoTerceirizada : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_clientetest_FuncaoTerceirizada_clientefuncoesterceirizadas",
                table: "clientetest");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FuncaoTerceirizada",
                table: "FuncaoTerceirizada");

            migrationBuilder.DeleteData(
                table: "LeadsOperacionais",
                keyColumn: "leadid",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "formulariooperacional",
                keyColumn: "formularioid",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ocorrencias",
                keyColumn: "ocorrenciaid",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ocorrencias",
                keyColumn: "ocorrenciaid",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "clientetest",
                keyColumn: "clienteid",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "clientetest",
                keyColumn: "clienteid",
                keyValue: 2);

            migrationBuilder.RenameTable(
                name: "FuncaoTerceirizada",
                newName: "funcoaterceirizada");

            migrationBuilder.RenameColumn(
                name: "FuncaoTerceirizadaNome",
                table: "funcoaterceirizada",
                newName: "funcaoTerceirizadaNome");

            migrationBuilder.RenameColumn(
                name: "FuncaoTerceirizadaId",
                table: "funcoaterceirizada",
                newName: "funcoaterceirizadaid");

            migrationBuilder.AlterColumn<string>(
                name: "funcaoTerceirizadaNome",
                table: "funcoaterceirizada",
                type: "varchar(100)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddPrimaryKey(
                name: "PK_funcoaterceirizada",
                table: "funcoaterceirizada",
                column: "funcoaterceirizadaid");

            migrationBuilder.AddForeignKey(
                name: "FK_clientetest_funcoaterceirizada_clientefuncoesterceirizadas",
                table: "clientetest",
                column: "clientefuncoesterceirizadas",
                principalTable: "funcoaterceirizada",
                principalColumn: "funcoaterceirizadaid",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_clientetest_funcoaterceirizada_clientefuncoesterceirizadas",
                table: "clientetest");

            migrationBuilder.DropPrimaryKey(
                name: "PK_funcoaterceirizada",
                table: "funcoaterceirizada");

            migrationBuilder.RenameTable(
                name: "funcoaterceirizada",
                newName: "FuncaoTerceirizada");

            migrationBuilder.RenameColumn(
                name: "funcaoTerceirizadaNome",
                table: "FuncaoTerceirizada",
                newName: "FuncaoTerceirizadaNome");

            migrationBuilder.RenameColumn(
                name: "funcoaterceirizadaid",
                table: "FuncaoTerceirizada",
                newName: "FuncaoTerceirizadaId");

            migrationBuilder.AlterColumn<string>(
                name: "FuncaoTerceirizadaNome",
                table: "FuncaoTerceirizada",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FuncaoTerceirizada",
                table: "FuncaoTerceirizada",
                column: "FuncaoTerceirizadaId");

            migrationBuilder.InsertData(
                table: "LeadsOperacionais",
                columns: new[] { "leadid", "leademail", "leadname", "leadpassword", "leadcreateddate" },
                values: new object[] { 1, "", "João Silva", "senha123", 0 });

            migrationBuilder.InsertData(
                table: "clientetest",
                columns: new[] { "clienteid", "clientebairro", "clientecontato", "clienteendereco", "clientefuncaoresponsavel", "clientefuncoesterceirizadas", "clienteposto", "clienteresponsavel" },
                values: new object[,]
                {
                    { 1, "Miramar", "83981295876", "RUA DOMINGOS MOROSO, S/N MIRAMAR EM JOAO PESSOA NO ESTADO DA PB, CEP:58043-170", 1, 1, "Arvoredo", "Antônio Henrique" },
                    { 2, "Bessa", "83981295876", "AVENIDA PRESIDENTE AFONSO PENA, 382, BESSA, EM JOAO PESSOA NO ESTADO DA PB, CEP: 58035-030", 0, 1, "Imperial Bessa", "Mariana" }
                });

            migrationBuilder.InsertData(
                table: "formulariooperacional",
                columns: new[] { "formularioid", "avaliacaoigo", "avaliacaorobson", "clientepostoid", "clientesatendidos", "dataenvio", "gestoresatendidos", "horaenvio", "observacoesgerais", "problemasidentificados", "problemasreportados", "solucoesapresentadas" },
                values: new object[] { 1, 4, 5, 1, 10, new DateTime(2024, 6, 15, 0, 0, 0, 0, DateTimeKind.Utc), 5, new DateTime(2024, 6, 15, 8, 0, 0, 0, DateTimeKind.Utc), "Serviço de limpeza agendado para amanhã.", "Falta de limpeza na área comum", 2, "Contratação de serviços de limpeza" });

            migrationBuilder.InsertData(
                table: "ocorrencias",
                columns: new[] { "ocorrenciaid", "clientepostoid", "clienteresponsavelid", "ocorrenciadata", "ocorrenciadescricao", "ocorrenciastatus" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(2024, 6, 15, 8, 0, 0, 0, DateTimeKind.Utc), "Problema de vazamento no banheiro", 3 },
                    { 2, 2, 2, new DateTime(2024, 6, 15, 9, 0, 0, 0, DateTimeKind.Utc), "Falta de energia na área comum", 3 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_clientetest_FuncaoTerceirizada_clientefuncoesterceirizadas",
                table: "clientetest",
                column: "clientefuncoesterceirizadas",
                principalTable: "FuncaoTerceirizada",
                principalColumn: "FuncaoTerceirizadaId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
