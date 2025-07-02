using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CadastroClientes.Migrations
{
    /// <inheritdoc />
    public partial class attformulariooperacional : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_formulariooperacional_clienteshumanas_clientepostoid",
                table: "formulariooperacional");

            migrationBuilder.DropIndex(
                name: "IX_formulariooperacional_clientepostoid",
                table: "formulariooperacional");

            migrationBuilder.DeleteData(
                table: "LeadsOperacionais",
                keyColumn: "leadid",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "clienteshumanas",
                keyColumn: "clienteid",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "clienteshumanas",
                keyColumn: "clienteid",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "funcoaterceirizada",
                keyColumn: "funcoaterceirizadaid",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "funcoaterceirizada",
                keyColumn: "funcoaterceirizadaid",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "funcoaterceirizada",
                keyColumn: "funcoaterceirizadaid",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "funcoaterceirizada",
                keyColumn: "funcoaterceirizadaid",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ocorrencias",
                keyColumn: "ocorrenciaid",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ocorrencias",
                keyColumn: "ocorrenciaid",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "clientepostoid",
                table: "formulariooperacional");

            migrationBuilder.AddColumn<string>(
                name: "clienteposto",
                table: "formulariooperacional",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "clientefuncaoresponsavel",
                table: "clienteshumanas",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.UpdateData(
                table: "formulariooperacional",
                keyColumn: "formularioid",
                keyValue: 1,
                column: "clienteposto",
                value: "Arvoredo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "clienteposto",
                table: "formulariooperacional");

            migrationBuilder.AddColumn<int>(
                name: "clientepostoid",
                table: "formulariooperacional",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "clientefuncaoresponsavel",
                table: "clienteshumanas",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.InsertData(
                table: "LeadsOperacionais",
                columns: new[] { "leadid", "leademail", "leadname", "leadpassword", "leadcreateddate" },
                values: new object[] { 1, "", "João Silva", "senha123", 0 });

            migrationBuilder.InsertData(
                table: "clienteshumanas",
                columns: new[] { "clienteid", "clientebairro", "clientecontato", "clienteendereco", "clientefuncaoresponsavel", "clientefuncoesterceirizadas", "clienteposto", "clienteresponsavel" },
                values: new object[,]
                {
                    { 1, "Miramar", "83981295876", "RUA DOMINGOS MOROSO, S/N MIRAMAR EM JOAO PESSOA NO ESTADO DA PB, CEP:58043-170", 1, 1, "Arvoredo", "Antônio Henrique" },
                    { 2, "Bessa", "83981295876", "AVENIDA PRESIDENTE AFONSO PENA, 382, BESSA, EM JOAO PESSOA NO ESTADO DA PB, CEP: 58035-030", 0, 2, "Imperial Bessa", "Mariana" }
                });

            migrationBuilder.UpdateData(
                table: "formulariooperacional",
                keyColumn: "formularioid",
                keyValue: 1,
                column: "clientepostoid",
                value: 1);

            migrationBuilder.InsertData(
                table: "funcoaterceirizada",
                columns: new[] { "funcoaterceirizadaid", "funcaoTerceirizadaNome" },
                values: new object[,]
                {
                    { 1, "Agente de Portaria" },
                    { 2, "Auxiliar de Serviços Gerais" },
                    { 3, "Jardineiro" },
                    { 4, "Concierge" }
                });

            migrationBuilder.InsertData(
                table: "ocorrencias",
                columns: new[] { "ocorrenciaid", "clienteposto", "clienteresponsavel", "ocorrenciadata", "ocorrenciadescricao", "ocorrenciastatus" },
                values: new object[,]
                {
                    { 1, "nomeposto", "nomeresponsavel", new DateTime(2024, 6, 15, 8, 0, 0, 0, DateTimeKind.Utc), "Problema de vazamento no banheiro", 3 },
                    { 2, "nomeposto1", "nomeresponsavel", new DateTime(2024, 6, 15, 9, 0, 0, 0, DateTimeKind.Utc), "Falta de energia na área comum", 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_formulariooperacional_clientepostoid",
                table: "formulariooperacional",
                column: "clientepostoid");

            migrationBuilder.AddForeignKey(
                name: "FK_formulariooperacional_clienteshumanas_clientepostoid",
                table: "formulariooperacional",
                column: "clientepostoid",
                principalTable: "clienteshumanas",
                principalColumn: "clienteid",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
