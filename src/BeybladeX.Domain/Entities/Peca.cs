using BeybladeX.Domain.Enums;

namespace BeybladeX.Domain.Entities;

public abstract class Peca
{
    public Guid Id { get; protected set; }
    public string Nome { get; protected set; } = string.Empty;
    public string CodigoTakaraTomy { get; protected set; } = string.Empty;
    public string? CodigoHasbro { get; protected set; }
    public TipoPeca Classificacao { get; protected set; }
    public SistemaBeyblade Sistema { get; protected set; }
    public decimal Peso { get; protected set; }
    public DateOnly DataLancamento { get; protected set; }
    public DateTime CriadoEm { get; protected set; }
    public DateTime? AtualizadoEm { get; protected set; }
}
