using BeybladeX.Domain.Entities;

namespace BeybladeX.Domain.Interfaces;

public interface IPecaRepository
{
    Task<Peca?> ObterPorNomeAsync(string nome, CancellationToken cancellationToken = default);
}
