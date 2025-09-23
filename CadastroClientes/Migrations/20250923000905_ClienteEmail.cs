using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CadastroClientes.Migrations
{
    /// <inheritdoc />
    public partial class ClienteEmail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("TRUNCATE TABLE \"clienteshumanas\" RESTART IDENTITY CASCADE;");

            migrationBuilder.AddColumn<string>(
                name: "clienteteemail",
                table: "clienteshumanas",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "clienteteemail",
                table: "clienteshumanas");
        }
    }
}
