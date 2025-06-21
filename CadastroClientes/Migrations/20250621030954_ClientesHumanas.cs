using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CadastroClientes.Migrations
{
    /// <inheritdoc />
    public partial class ClientesHumanas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_formulariooperacional_clientetest_clientepostoid",
                table: "formulariooperacional");

            migrationBuilder.DropPrimaryKey(
                name: "PK_clientetest",
                table: "clientetest");

            migrationBuilder.RenameTable(
                name: "clientetest",
                newName: "clienteshumanas");

            migrationBuilder.AddPrimaryKey(
                name: "PK_clienteshumanas",
                table: "clienteshumanas",
                column: "clienteid");

            migrationBuilder.AddForeignKey(
                name: "FK_formulariooperacional_clienteshumanas_clientepostoid",
                table: "formulariooperacional",
                column: "clientepostoid",
                principalTable: "clienteshumanas",
                principalColumn: "clienteid",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_formulariooperacional_clienteshumanas_clientepostoid",
                table: "formulariooperacional");

            migrationBuilder.DropPrimaryKey(
                name: "PK_clienteshumanas",
                table: "clienteshumanas");

            migrationBuilder.RenameTable(
                name: "clienteshumanas",
                newName: "clientetest");

            migrationBuilder.AddPrimaryKey(
                name: "PK_clientetest",
                table: "clientetest",
                column: "clienteid");

            migrationBuilder.AddForeignKey(
                name: "FK_formulariooperacional_clientetest_clientepostoid",
                table: "formulariooperacional",
                column: "clientepostoid",
                principalTable: "clientetest",
                principalColumn: "clienteid",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
