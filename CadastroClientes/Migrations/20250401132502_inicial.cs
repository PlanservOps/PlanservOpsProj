using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CadastroClientes.Migrations
{
    /// <inheritdoc />
    public partial class inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClienteTest",
                columns: table => new
                {
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientePosto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClienteResponsavel = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    ClienteContato = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClienteFuncaoResponsavel = table.Column<int>(type: "int", nullable: false),
                    ClienteEndereco = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClienteBairro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClienteFuncoesTerceirizadas = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClienteTest", x => x.ClienteId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClienteTest");
        }
    }
}
