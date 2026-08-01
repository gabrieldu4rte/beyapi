using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeybladeX.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "pecas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    nome = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false),
                    codigo_takara_tomy = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    codigo_hasbro = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    classificacao = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    sistema = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    peso = table.Column<decimal>(type: "numeric(6,2)", nullable: false),
                    data_lancamento = table.Column<DateOnly>(type: "date", nullable: false),
                    criado_em = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    atualizado_em = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    direcao_giro = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    tipo_estilo = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    tipo_peca = table.Column<string>(type: "character varying(21)", maxLength: 21, nullable: false),
                    AssistBlade_Tipo = table.Column<int>(type: "integer", nullable: true),
                    AssistBlade_Ataque = table.Column<int>(type: "integer", nullable: true),
                    AssistBlade_Defesa = table.Column<int>(type: "integer", nullable: true),
                    AssistBlade_Stamina = table.Column<int>(type: "integer", nullable: true),
                    Bit_Tipo = table.Column<int>(type: "integer", nullable: true),
                    Bit_Ataque = table.Column<int>(type: "integer", nullable: true),
                    Bit_Defesa = table.Column<int>(type: "integer", nullable: true),
                    Bit_Stamina = table.Column<int>(type: "integer", nullable: true),
                    Dash = table.Column<int>(type: "integer", nullable: true),
                    ResistenciaABurst = table.Column<int>(type: "integer", nullable: true),
                    Blade_Tipo = table.Column<int>(type: "integer", nullable: true),
                    Blade_Ataque = table.Column<int>(type: "integer", nullable: true),
                    Blade_Defesa = table.Column<int>(type: "integer", nullable: true),
                    Blade_Stamina = table.Column<int>(type: "integer", nullable: true),
                    BladeRatchetIntegrada_Tipo = table.Column<int>(type: "integer", nullable: true),
                    BladeRatchetIntegrada_Ataque = table.Column<int>(type: "integer", nullable: true),
                    BladeRatchetIntegrada_Defesa = table.Column<int>(type: "integer", nullable: true),
                    BladeRatchetIntegrada_Stamina = table.Column<int>(type: "integer", nullable: true),
                    MetalBlade_Tipo = table.Column<int>(type: "integer", nullable: true),
                    MetalBlade_Ataque = table.Column<int>(type: "integer", nullable: true),
                    MetalBlade_Defesa = table.Column<int>(type: "integer", nullable: true),
                    MetalBlade_Stamina = table.Column<int>(type: "integer", nullable: true),
                    Tipo = table.Column<int>(type: "integer", nullable: true),
                    Ataque = table.Column<int>(type: "integer", nullable: true),
                    Defesa = table.Column<int>(type: "integer", nullable: true),
                    Stamina = table.Column<int>(type: "integer", nullable: true),
                    Ratchet_Ataque = table.Column<int>(type: "integer", nullable: true),
                    Ratchet_Defesa = table.Column<int>(type: "integer", nullable: true),
                    Ratchet_Stamina = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pecas", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "ix_pecas_codigo_takara_tomy",
                table: "pecas",
                column: "codigo_takara_tomy");

            // Índice case-insensitive via expressão LOWER(nome) — não suportado nativamente pelo EF Core
            migrationBuilder.Sql("CREATE UNIQUE INDEX ix_pecas_nome ON pecas (LOWER(nome));");

            migrationBuilder.CreateIndex(
                name: "ix_pecas_sistema",
                table: "pecas",
                column: "sistema");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Remove o índice de expressão criado com SQL raw antes de dropar a tabela
            migrationBuilder.Sql("DROP INDEX IF EXISTS ix_pecas_nome;");

            migrationBuilder.DropTable(
                name: "pecas");
        }
    }
}
