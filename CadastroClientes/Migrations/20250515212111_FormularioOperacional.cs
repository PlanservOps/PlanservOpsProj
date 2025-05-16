using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CadastroClientes.Migrations
{
    /// <inheritdoc />
    public partial class FormularioOperacional : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "clientetest",
            //    columns: table => new
            //    {
            //        clienteid = table.Column<int>(type: "integer", nullable: false)
            //            .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
            //        clienteposto = table.Column<string>(type: "text", nullable: false),
            //        clienteresponsavel = table.Column<string>(type: "character varying(400)", maxLength: 400, nullable: false),
            //        clientecontato = table.Column<string>(type: "text", nullable: false),
            //        clientefuncaoresponsavel = table.Column<int>(type: "integer", nullable: false),
            //        clienteendereco = table.Column<string>(type: "text", nullable: false),
            //        clientebairro = table.Column<string>(type: "text", nullable: false),
            //        clientefuncoesterceirizadas = table.Column<string>(type: "text", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_clientetest", x => x.clienteid);
            //    });

            migrationBuilder.CreateTable(
                name: "formulariooperacional",
                columns: table => new
                {
                    formularioid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    dataenvio = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    horaenvio = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    clientesatendidos = table.Column<int>(type: "integer", nullable: false),
                    problemasreportados = table.Column<int>(type: "integer", nullable: false),
                    gestoresatendidos = table.Column<int>(type: "integer", nullable: false),
                    clienteposto = table.Column<string>(type: "character varying(400)", maxLength: 400, nullable: false),
                    ClientePostoClienteId = table.Column<int>(type: "integer", nullable: false),
                    problemasidentificados = table.Column<string>(type: "character varying(400)", maxLength: 400, nullable: false),
                    solucoesapresentadas = table.Column<string>(type: "character varying(400)", maxLength: 400, nullable: false),
                    avaliacaoigo = table.Column<int>(type: "integer", nullable: false),
                    avaliacaorobson = table.Column<int>(type: "integer", nullable: false),
                    observacoesgerais = table.Column<string>(type: "character varying(400)", maxLength: 400, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_formulariooperacional", x => x.formularioid);
                    table.ForeignKey(
                        name: "FK_formulariooperacional_clientetest_ClientePostoClienteId",
                        column: x => x.ClientePostoClienteId,
                        principalTable: "clientetest",
                        principalColumn: "clienteid",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        //    migrationBuilder.InsertData(
        //        table: "clientetest",
        //        columns: new[] { "clienteid", "clientebairro", "clientecontato", "clienteendereco", "clientefuncaoresponsavel", "clientefuncoesterceirizadas", "clienteposto", "clienteresponsavel" },
        //        values: new object[,]
        //        {
        //            { 1, "Miramar", "83981295876", "RUA DOMINGOS MOROSO, S/N MIRAMAR EM JOAO PESSOA NO ESTADO DA PB, CEP:58043-170", 1, "NPS", "Arvoredo", "Antônio Henrique" },
        //            { 2, "Bessa", "83981295876", "AVENIDA PRESIDENTE AFONSO PENA, 382, BESSA, EM JOAO PESSOA NO ESTADO DA PB, CEP: 58035-030", 0, "NPS", "Imperial Bessa", "Mariana" }
        //        });

        //    migrationBuilder.CreateIndex(
        //        name: "IX_formulariooperacional_ClientePostoClienteId",
        //        table: "formulariooperacional",
        //        column: "ClientePostoClienteId");
        //}

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "formulariooperacional");

            migrationBuilder.DropTable(
                name: "clientetest");
        }
    }
}
