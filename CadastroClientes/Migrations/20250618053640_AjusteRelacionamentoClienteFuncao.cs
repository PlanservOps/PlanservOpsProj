using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CadastroClientes.Migrations
{
    /// <inheritdoc />
    public partial class AjusteRelacionamentoClienteFuncao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_clientetest_funcoaterceirizada_clientefuncoesterceirizadas",
                table: "clientetest");

            migrationBuilder.AlterColumn<int>(
                name: "clientefuncoesterceirizadas",
                table: "clientetest",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_clientetest_funcoaterceirizada_FuncaoTerceirizadafuncoaterc~",
                table: "clientetest");

            migrationBuilder.DropForeignKey(
                name: "FK_clientetest_funcoaterceirizada_clientefuncoesterceirizadas",
                table: "clientetest");

            migrationBuilder.DropIndex(
                name: "IX_clientetest_FuncaoTerceirizadafuncoaterceirizadaid",
                table: "clientetest");

            migrationBuilder.DropColumn(
                name: "FuncaoTerceirizadafuncoaterceirizadaid",
                table: "clientetest");

            migrationBuilder.AlterColumn<int>(
                name: "clientefuncoesterceirizadas",
                table: "clientetest",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_clientetest_funcoaterceirizada_clientefuncoesterceirizadas",
                table: "clientetest",
                column: "clientefuncoesterceirizadas",
                principalTable: "funcoaterceirizada",
                principalColumn: "funcoaterceirizadaid",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
