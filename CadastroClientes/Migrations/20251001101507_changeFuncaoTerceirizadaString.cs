using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CadastroClientes.Migrations
{
    /// <inheritdoc />
    public partial class changeFuncaoTerceirizadaString : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "clientefuncoesterceirizadas",
                table: "clienteshumanas",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "clientefuncoesterceirizadas",
                table: "clienteshumanas",
                type: "integer",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
