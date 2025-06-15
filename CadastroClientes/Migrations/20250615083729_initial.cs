using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CadastroClientes.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FuncaoTerceirizada",
                columns: table => new
                {
                    FuncaoTerceirizadaId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FuncaoTerceirizadaNome = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuncaoTerceirizada", x => x.FuncaoTerceirizadaId);
                });

            migrationBuilder.CreateTable(
                name: "LeadsOperacionais",
                columns: table => new
                {
                    leadid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    leadname = table.Column<string>(type: "character varying(400)", maxLength: 400, nullable: false),
                    leademail = table.Column<string>(type: "character varying(400)", maxLength: 400, nullable: false),
                    leadpassword = table.Column<string>(type: "character varying(400)", maxLength: 400, nullable: false),
                    leadcreateddate = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeadsOperacionais", x => x.leadid);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "clientetest",
                columns: table => new
                {
                    clienteid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    clienteposto = table.Column<string>(type: "text", nullable: false),
                    clienteresponsavel = table.Column<string>(type: "character varying(400)", maxLength: 400, nullable: false),
                    clientecontato = table.Column<string>(type: "text", nullable: false),
                    clientefuncaoresponsavel = table.Column<int>(type: "integer", nullable: false),
                    clienteendereco = table.Column<string>(type: "text", nullable: false),
                    clientebairro = table.Column<string>(type: "text", nullable: false),
                    clientefuncoesterceirizadas = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clientetest", x => x.clienteid);
                    table.ForeignKey(
                        name: "FK_clientetest_FuncaoTerceirizada_clientefuncoesterceirizadas",
                        column: x => x.clientefuncoesterceirizadas,
                        principalTable: "FuncaoTerceirizada",
                        principalColumn: "FuncaoTerceirizadaId",
                        onDelete: ReferentialAction.Cascade);
                });

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
                    clientepostoid = table.Column<int>(type: "integer", nullable: false),
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
                        name: "FK_formulariooperacional_clientetest_clientepostoid",
                        column: x => x.clientepostoid,
                        principalTable: "clientetest",
                        principalColumn: "clienteid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ocorrencias",
                columns: table => new
                {
                    ocorrenciaid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    clientepostoid = table.Column<int>(type: "integer", nullable: false),
                    clienteresponsavelid = table.Column<int>(type: "integer", nullable: false),
                    ocorrenciadata = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ocorrenciadescricao = table.Column<string>(type: "text", nullable: false),
                    ocorrenciastatus = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ocorrencias", x => x.ocorrenciaid);
                    table.ForeignKey(
                        name: "FK_ocorrencias_clientetest_clientepostoid",
                        column: x => x.clientepostoid,
                        principalTable: "clientetest",
                        principalColumn: "clienteid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ocorrencias_clientetest_clienteresponsavelid",
                        column: x => x.clienteresponsavelid,
                        principalTable: "clientetest",
                        principalColumn: "clienteid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "FuncaoTerceirizada",
                columns: new[] { "FuncaoTerceirizadaId", "FuncaoTerceirizadaNome" },
                values: new object[,]
                {
                    { 1, "Agente de Portaria" },
                    { 2, "Auxiliar de Serviços Gerais" },
                    { 3, "Jardineiro" },
                    { 4, "Concierge" }
                });

            migrationBuilder.InsertData(
                table: "LeadsOperacionais",
                columns: new[] { "leadid", "leademail", "leadname", "leadpassword", "leadcreateddate" },
                values: new object[] { 1, "", "João Silva", "senha123", 0 });

            migrationBuilder.InsertData(
                table: "clientetest",
                columns: new[] { "clienteid", "clientebairro", "clientecontato", "clienteendereco", "clientefuncaoresponsavel", "clientefuncoesterceirizadas", "clienteposto", "clienteresponsavel" },
                values: new object[,]
                {
                    { 1, "Miramar", "83981295876", "RUA DOMINGOS MOROSO, S/N MIRAMAR EM JOAO PESSOA NO ESTADO DA PB, CEP:58043-170", 1, 1, "Arvoredo", "Antônio Henrique" },
                    { 2, "Bessa", "83981295876", "AVENIDA PRESIDENTE AFONSO PENA, 382, BESSA, EM JOAO PESSOA NO ESTADO DA PB, CEP: 58035-030", 0, 1, "Imperial Bessa", "Mariana" }
                });

            migrationBuilder.InsertData(
                table: "formulariooperacional",
                columns: new[] { "formularioid", "avaliacaoigo", "avaliacaorobson", "clientepostoid", "clientesatendidos", "dataenvio", "gestoresatendidos", "horaenvio", "observacoesgerais", "problemasidentificados", "problemasreportados", "solucoesapresentadas" },
                values: new object[] { 1, 4, 5, 1, 10, new DateTime(2024, 6, 15, 0, 0, 0, 0, DateTimeKind.Utc), 5, new DateTime(2024, 6, 15, 8, 0, 0, 0, DateTimeKind.Utc), "Serviço de limpeza agendado para amanhã.", "Falta de limpeza na área comum", 2, "Contratação de serviços de limpeza" });

            migrationBuilder.InsertData(
                table: "ocorrencias",
                columns: new[] { "ocorrenciaid", "clientepostoid", "clienteresponsavelid", "ocorrenciadata", "ocorrenciadescricao", "ocorrenciastatus" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(2024, 6, 15, 8, 0, 0, 0, DateTimeKind.Utc), "Problema de vazamento no banheiro", 3 },
                    { 2, 2, 2, new DateTime(2024, 6, 15, 9, 0, 0, 0, DateTimeKind.Utc), "Falta de energia na área comum", 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_clientetest_clientefuncoesterceirizadas",
                table: "clientetest",
                column: "clientefuncoesterceirizadas");

            migrationBuilder.CreateIndex(
                name: "IX_formulariooperacional_clientepostoid",
                table: "formulariooperacional",
                column: "clientepostoid");

            migrationBuilder.CreateIndex(
                name: "IX_ocorrencias_clientepostoid",
                table: "ocorrencias",
                column: "clientepostoid");

            migrationBuilder.CreateIndex(
                name: "IX_ocorrencias_clienteresponsavelid",
                table: "ocorrencias",
                column: "clienteresponsavelid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "formulariooperacional");

            migrationBuilder.DropTable(
                name: "LeadsOperacionais");

            migrationBuilder.DropTable(
                name: "ocorrencias");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "clientetest");

            migrationBuilder.DropTable(
                name: "FuncaoTerceirizada");
        }
    }
}
