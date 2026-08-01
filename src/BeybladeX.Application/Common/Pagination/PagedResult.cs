namespace BeybladeX.Application.Common.Pagination;

public class PagedResult<T>
{
    public IReadOnlyList<T> Itens { get; init; } = [];
    public int PaginaAtual { get; init; }
    public int TamanhoPagina { get; init; }
    public int TotalItens { get; init; }
    public int TotalPaginas { get; init; }
    public bool TemProximaPagina { get; init; }
    public bool TemPaginaAnterior { get; init; }
}
