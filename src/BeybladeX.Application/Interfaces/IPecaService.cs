using BeybladeX.Application.DTOs;

namespace BeybladeX.Application.Interfaces;

public interface IPecaService
{
    Task<PecaDto> ObterPorNomeAsync(string nome, CancellationToken cancellationToken = default);
}
