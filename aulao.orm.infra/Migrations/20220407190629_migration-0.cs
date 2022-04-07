using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace aulao.orm.infra.Migrations
{
    public partial class migration0 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cor",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LenteGrau",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Esquerdo = table.Column<string>(nullable: true),
                    Direito = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LenteGrau", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Armacao",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Marca = table.Column<string>(nullable: true),
                    Material = table.Column<int>(nullable: false),
                    CorId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Armacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Armacao_Cor_CorId",
                        column: x => x.CorId,
                        principalTable: "Cor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Lente",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    GrauId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lente_LenteGrau_GrauId",
                        column: x => x.GrauId,
                        principalTable: "LenteGrau",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LenteCaracteristica",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Caracteristica = table.Column<string>(nullable: true),
                    LenteId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LenteCaracteristica", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LenteCaracteristica_Lente_LenteId",
                        column: x => x.LenteId,
                        principalTable: "Lente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Oculos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    LenteId = table.Column<Guid>(nullable: true),
                    ArmacaoId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oculos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Oculos_Armacao_ArmacaoId",
                        column: x => x.ArmacaoId,
                        principalTable: "Armacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Oculos_Lente_LenteId",
                        column: x => x.LenteId,
                        principalTable: "Lente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Armacao_CorId",
                table: "Armacao",
                column: "CorId");

            migrationBuilder.CreateIndex(
                name: "IX_Lente_GrauId",
                table: "Lente",
                column: "GrauId");

            migrationBuilder.CreateIndex(
                name: "IX_LenteCaracteristica_LenteId",
                table: "LenteCaracteristica",
                column: "LenteId");

            migrationBuilder.CreateIndex(
                name: "IX_Oculos_ArmacaoId",
                table: "Oculos",
                column: "ArmacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Oculos_LenteId",
                table: "Oculos",
                column: "LenteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LenteCaracteristica");

            migrationBuilder.DropTable(
                name: "Oculos");

            migrationBuilder.DropTable(
                name: "Armacao");

            migrationBuilder.DropTable(
                name: "Lente");

            migrationBuilder.DropTable(
                name: "Cor");

            migrationBuilder.DropTable(
                name: "LenteGrau");
        }
    }
}
