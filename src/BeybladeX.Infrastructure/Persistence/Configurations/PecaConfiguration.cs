using BeybladeX.Domain.Entities;
using BeybladeX.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeybladeX.Infrastructure.Persistence.Configurations;

public class PecaConfiguration : IEntityTypeConfiguration<Peca>
{
    public void Configure(EntityTypeBuilder<Peca> builder)
    {
        // Tabela e chave primária
        builder.ToTable("pecas");
        builder.HasKey(p => p.Id);

        // Discriminador TPH
        builder.HasDiscriminator<string>("tipo_peca")
            .HasValue<LockChip>("LockChip")
            .HasValue<Blade>("Blade")
            .HasValue<OverBlade>("OverBlade")
            .HasValue<MetalBlade>("MetalBlade")
            .HasValue<AssistBlade>("AssistBlade")
            .HasValue<Ratchet>("Ratchet")
            .HasValue<Bit>("Bit")
            .HasValue<BladeRatchetIntegrada>("BladeRatchetIntegrada");

        // Propriedades da entidade base
        builder.Property(p => p.Nome)
            .HasColumnName("nome")
            .HasMaxLength(120)
            .IsRequired();

        builder.Property(p => p.CodigoTakaraTomy)
            .HasColumnName("codigo_takara_tomy")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(p => p.CodigoHasbro)
            .HasColumnName("codigo_hasbro")
            .HasMaxLength(50);

        builder.Property(p => p.Classificacao)
            .HasColumnName("classificacao")
            .HasConversion<string>()
            .HasMaxLength(30);

        builder.Property(p => p.Sistema)
            .HasColumnName("sistema")
            .HasConversion<string>()
            .HasMaxLength(30);

        builder.Property(p => p.Peso)
            .HasColumnName("peso")
            .HasColumnType("numeric(6,2)");

        builder.Property(p => p.DataLancamento)
            .HasColumnName("data_lancamento");

        builder.Property(p => p.CriadoEm)
            .HasColumnName("criado_em");

        builder.Property(p => p.AtualizadoEm)
            .HasColumnName("atualizado_em");

        // Propriedades dos subtipos que compartilham colunas no TPH

        // DirecaoGiro: existe em LockChip, Blade, OverBlade, MetalBlade, AssistBlade, BladeRatchetIntegrada
        // Configurado como shadow property no tipo base para mapear para a coluna compartilhada
        builder.Property<DirecaoGiro?>("DirecaoGiro")
            .HasConversion<string>()
            .HasMaxLength(15)
            .HasColumnName("direcao_giro");

        // TipoEstilo: existe em Blade, OverBlade, MetalBlade, AssistBlade, Bit, BladeRatchetIntegrada
        builder.Property<TipoEstilo?>("TipoEstilo")
            .HasConversion<string>()
            .HasMaxLength(15)
            .HasColumnName("tipo_estilo");

        // Índices
        // Nota: o índice case-insensitive LOWER(nome) é criado com SQL raw na migration (task 5.5),
        // pois o EF Core não suporta expression indexes via Fluent API.
        // Aqui definimos o índice no modelo para que o EF Core registre a restrição de unicidade;
        // a migration gerada será customizada para usar LOWER(nome).
        builder.HasIndex(p => p.Nome)
            .IsUnique()
            .HasDatabaseName("ix_pecas_nome");

        builder.HasIndex(p => p.Sistema)
            .HasDatabaseName("ix_pecas_sistema");

        builder.HasIndex(p => p.CodigoTakaraTomy)
            .HasDatabaseName("ix_pecas_codigo_takara_tomy");
    }
}
