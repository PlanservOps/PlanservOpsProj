using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CadastroClientes.Migrations
{
    /// <inheritdoc />
    public partial class FormularioOperacional : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ClienteTest",
                table: "ClienteTest");

            migrationBuilder.RenameTable(
                name: "ClienteTest",
                newName: "clientetest");

            migrationBuilder.RenameColumn(
                name: "ClienteResponsavel",
                table: "clientetest",
                newName: "clienteresponsavel");

            migrationBuilder.RenameColumn(
                name: "ClientePosto",
                table: "clientetest",
                newName: "clienteposto");

            migrationBuilder.RenameColumn(
                name: "ClienteFuncoesTerceirizadas",
                table: "clientetest",
                newName: "clientefuncoesterceirizadas");

            migrationBuilder.RenameColumn(
                name: "ClienteFuncaoResponsavel",
                table: "clientetest",
                newName: "clientefuncaoresponsavel");

            migrationBuilder.RenameColumn(
                name: "ClienteEndereco",
                table: "clientetest",
                newName: "clienteendereco");

            migrationBuilder.RenameColumn(
                name: "ClienteContato",
                table: "clientetest",
                newName: "clientecontato");

            migrationBuilder.RenameColumn(
                name: "ClienteBairro",
                table: "clientetest",
                newName: "clientebairro");

            migrationBuilder.RenameColumn(
                name: "ClienteId",
                table: "clientetest",
                newName: "clienteid");

            migrationBuilder.AlterColumn<string>(
                name: "clienteresponsavel",
                table: "clientetest",
                type: "character varying(400)",
                maxLength: 400,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(400)",
                oldMaxLength: 400);

            migrationBuilder.AlterColumn<string>(
                name: "clienteposto",
                table: "clientetest",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "clientefuncoesterceirizadas",
                table: "clientetest",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "clientefuncaoresponsavel",
                table: "clientetest",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "clienteendereco",
                table: "clientetest",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "clientecontato",
                table: "clientetest",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "clientebairro",
                table: "clientetest",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "clienteid",
                table: "clientetest",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_clientetest",
                table: "clientetest",
                column: "clienteid");

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
                    clienteposto = table.Column<string>(type: "text", nullable: false),
                    ClientePostoClienteId = table.Column<int>(type: "integer", nullable: false),
                    problemasidentificados = table.Column<string>(type: "character varying(360)", maxLength: 360, nullable: false),
                    solucoesapresentadas = table.Column<string>(type: "character varying(360)", maxLength: 360, nullable: false),
                    avaliacaoigor = table.Column<int>(type: "integer", nullable: false),
                    avaliacaorobson = table.Column<int>(type: "integer", nullable: false),
                    observacoesgerais = table.Column<string>(type: "character varying(360)", maxLength: 360, nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_formulariooperacional_ClientePostoClienteId",
                table: "formulariooperacional",
                column: "ClientePostoClienteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "formulariooperacional");

            migrationBuilder.DropPrimaryKey(
                name: "PK_clientetest",
                table: "clientetest");

            migrationBuilder.RenameTable(
                name: "clientetest",
                newName: "ClienteTest");

            migrationBuilder.RenameColumn(
                name: "clienteresponsavel",
                table: "ClienteTest",
                newName: "ClienteResponsavel");

            migrationBuilder.RenameColumn(
                name: "clienteposto",
                table: "ClienteTest",
                newName: "ClientePosto");

            migrationBuilder.RenameColumn(
                name: "clientefuncoesterceirizadas",
                table: "ClienteTest",
                newName: "ClienteFuncoesTerceirizadas");

            migrationBuilder.RenameColumn(
                name: "clientefuncaoresponsavel",
                table: "ClienteTest",
                newName: "ClienteFuncaoResponsavel");

            migrationBuilder.RenameColumn(
                name: "clienteendereco",
                table: "ClienteTest",
                newName: "ClienteEndereco");

            migrationBuilder.RenameColumn(
                name: "clientecontato",
                table: "ClienteTest",
                newName: "ClienteContato");

            migrationBuilder.RenameColumn(
                name: "clientebairro",
                table: "ClienteTest",
                newName: "ClienteBairro");

            migrationBuilder.RenameColumn(
                name: "clienteid",
                table: "ClienteTest",
                newName: "ClienteId");

            migrationBuilder.AlterColumn<string>(
                name: "ClienteResponsavel",
                table: "ClienteTest",
                type: "nvarchar(400)",
                maxLength: 400,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(400)",
                oldMaxLength: 400);

            migrationBuilder.AlterColumn<string>(
                name: "ClientePosto",
                table: "ClienteTest",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "ClienteFuncoesTerceirizadas",
                table: "ClienteTest",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "ClienteFuncaoResponsavel",
                table: "ClienteTest",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "ClienteEndereco",
                table: "ClienteTest",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "ClienteContato",
                table: "ClienteTest",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "ClienteBairro",
                table: "ClienteTest",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "ClienteTest",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClienteTest",
                table: "ClienteTest",
                column: "ClienteId");
        }
    }
}
