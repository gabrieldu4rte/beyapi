using BeybladeX.Application.Common.Exceptions;
using BeybladeX.Application.DTOs;
using BeybladeX.Application.Interfaces;
using BeybladeX.Application.Mappings;
using BeybladeX.Domain.Interfaces;

namespace BeybladeX.Application.Services;

public class PecaService : IPecaService
{
    private readonly IPecaRepository _repository;

    public PecaService(IPecaRepository repository)
    {
        _repository = repository;
    }

    public async Task<PecaDto> ObterPorNomeAsync(string nome, CancellationToken cancellationToken = default)
    {
        var peca = await _repository.ObterPorNomeAsync(nome, cancellationToken);

        if (peca is null)
            throw new PecaNaoEncontradaException(nome);

        return peca.ToDto();
    }
}
