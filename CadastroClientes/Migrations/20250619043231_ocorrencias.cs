using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CadastroClientes.Migrations
{
    /// <inheritdoc />
    public partial class ocorrencias : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_clientetest_funcoaterceirizada_FuncaoTerceirizadafuncoaterc~",
                table: "clientetest");

            migrationBuilder.DropForeignKey(
                name: "FK_clientetest_funcoaterceirizada_clientefuncoesterceirizadas",
                table: "clientetest");

            migrationBuilder.DropForeignKey(
                name: "FK_ocorrencias_clientetest_clientepostoid",
                table: "ocorrencias");

            migrationBuilder.DropForeignKey(
                name: "FK_ocorrencias_clientetest_clienteresponsavelid",
                table: "ocorrencias");

            migrationBuilder.DropIndex(
                name: "IX_ocorrencias_clientepostoid",
                table: "ocorrencias");

            migrationBuilder.DropIndex(
                name: "IX_ocorrencias_clienteresponsavelid",
                table: "ocorrencias");

            migrationBuilder.DropIndex(
                name: "IX_clientetest_clientefuncoesterceirizadas",
                table: "clientetest");

            migrationBuilder.DropIndex(
                name: "IX_clientetest_FuncaoTerceirizadafuncoaterceirizadaid",
                table: "clientetest");

            migrationBuilder.DropColumn(
                name: "clientepostoid",
                table: "ocorrencias");

            migrationBuilder.DropColumn(
                name: "clienteresponsavelid",
                table: "ocorrencias");

            migrationBuilder.DropColumn(
                name: "FuncaoTerceirizadafuncoaterceirizadaid",
                table: "clientetest");

            migrationBuilder.AddColumn<string>(
                name: "clienteposto",
                table: "ocorrencias",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "clienteresponsavel",
                table: "ocorrencias",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "ocorrencias",
                keyColumn: "ocorrenciaid",
                keyValue: 1,
                columns: new[] { "clienteposto", "clienteresponsavel" },
                values: new object[] { "nomeposto", "nomeresponsavel" });

            migrationBuilder.UpdateData(
                table: "ocorrencias",
                keyColumn: "ocorrenciaid",
                keyValue: 2,
                columns: new[] { "clienteposto", "clienteresponsavel" },
                values: new object[] { "nomeposto1", "nomeresponsavel" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "clienteposto",
                table: "ocorrencias");

            migrationBuilder.DropColumn(
                name: "clienteresponsavel",
                table: "ocorrencias");

            migrationBuilder.AddColumn<int>(
                name: "clientepostoid",
                table: "ocorrencias",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "clienteresponsavelid",
                table: "ocorrencias",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FuncaoTerceirizadafuncoaterceirizadaid",
                table: "clientetest",
                type: "integer",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "clientetest",
                keyColumn: "clienteid",
                keyValue: 1,
                column: "FuncaoTerceirizadafuncoaterceirizadaid",
                value: null);

            migrationBuilder.UpdateData(
                table: "clientetest",
                keyColumn: "clienteid",
                keyValue: 2,
                column: "FuncaoTerceirizadafuncoaterceirizadaid",
                value: null);

            migrationBuilder.UpdateData(
                table: "ocorrencias",
                keyColumn: "ocorrenciaid",
                keyValue: 1,
                columns: new[] { "clientepostoid", "clienteresponsavelid" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "ocorrencias",
                keyColumn: "ocorrenciaid",
                keyValue: 2,
                columns: new[] { "clientepostoid", "clienteresponsavelid" },
                values: new object[] { 2, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_ocorrencias_clientepostoid",
                table: "ocorrencias",
                column: "clientepostoid");

            migrationBuilder.CreateIndex(
                name: "IX_ocorrencias_clienteresponsavelid",
                table: "ocorrencias",
                column: "clienteresponsavelid");

            migrationBuilder.CreateIndex(
                name: "IX_clientetest_clientefuncoesterceirizadas",
                table: "clientetest",
                column: "clientefuncoesterceirizadas");

            migrationBuilder.CreateIndex(
                name: "IX_clientetest_FuncaoTerceirizadafuncoaterceirizadaid",
                table: "clientetest",
                column: "FuncaoTerceirizadafuncoaterceirizadaid");

            migrationBuilder.AddForeignKey(
                name: "FK_clientetest_funcoaterceirizada_FuncaoTerceirizadafuncoaterc~",
                table: "clientetest",
                column: "FuncaoTerceirizadafuncoaterceirizadaid",
                principalTable: "funcoaterceirizada",
                principalColumn: "funcoaterceirizadaid");

            migrationBuilder.AddForeignKey(
                name: "FK_clientetest_funcoaterceirizada_clientefuncoesterceirizadas",
                table: "clientetest",
                column: "clientefuncoesterceirizadas",
                principalTable: "funcoaterceirizada",
                principalColumn: "funcoaterceirizadaid",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_ocorrencias_clientetest_clientepostoid",
                table: "ocorrencias",
                column: "clientepostoid",
                principalTable: "clientetest",
                principalColumn: "clienteid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ocorrencias_clientetest_clienteresponsavelid",
                table: "ocorrencias",
                column: "clienteresponsavelid",
                principalTable: "clientetest",
                principalColumn: "clienteid",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
