using BeybladeX.Domain.Entities;
using BeybladeX.Domain.Interfaces;
using BeybladeX.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace BeybladeX.Infrastructure.Persistence.Repositories;

public class PecaRepository : IPecaRepository
{
    private readonly AppDbContext _context;

    public PecaRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Peca?> ObterPorNomeAsync(string nome, CancellationToken cancellationToken = default)
    {
        return await _context.Pecas
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.Nome.ToLower() == nome.ToLower(), cancellationToken);
    }
}
