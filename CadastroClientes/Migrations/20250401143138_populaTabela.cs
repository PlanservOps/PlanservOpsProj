using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CadastroClientes.Migrations
{
    /// <inheritdoc />
    public partial class populaTabela : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ClienteTest",
                columns: new[] { "ClienteId", "ClienteBairro", "ClienteContato", "ClienteEndereco", "ClienteFuncaoResponsavel", "ClienteFuncoesTerceirizadas", "ClientePosto", "ClienteResponsavel" },
                values: new object[,]
                {
                    { 1, "Miramar", "83981295876", "RUA DOMINGOS MOROSO, S/N MIRAMAR EM JOAO PESSOA NO ESTADO DA PB, CEP:58043-170", 1, "NPS", "Arvoredo", "Antônio Henrique" },
                    { 2, "Bessa", "83981295876", "AVENIDA PRESIDENTE AFONSO PENA, 382, BESSA, EM JOAO PESSOA NO ESTADO DA PB, CEP: 58035-030", 0, "NPS", "Imperial Bessa", "Mariana" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ClienteTest",
                keyColumn: "ClienteId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ClienteTest",
                keyColumn: "ClienteId",
                keyValue: 2);
        }
    }
}
