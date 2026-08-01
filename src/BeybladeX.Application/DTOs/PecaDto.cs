namespace BeybladeX.Application.DTOs;

public record PecaDto(
    Guid Id,
    string Nome,
    string CodigoTakaraTomy,
    string? CodigoHasbro,
    string Classificacao,
    string Sistema,
    decimal Peso,
    DateOnly DataLancamento,
    string? DirecaoGiro,
    string? Tipo,
    int? Ataque,
    int? Defesa,
    int? Stamina,
    int? Dash,
    int? ResistenciaABurst
);
