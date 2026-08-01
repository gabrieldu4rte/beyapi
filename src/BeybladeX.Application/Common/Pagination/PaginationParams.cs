namespace BeybladeX.Application.Common.Pagination;

public class PaginationParams
{
    private int _pagina = 1;
    private int _tamanhoPagina = 20;

    public int Pagina
    {
        get => _pagina;
        set => _pagina = value < 1 ? 1 : value;
    }

    public int TamanhoPagina
    {
        get => _tamanhoPagina;
        set => _tamanhoPagina = value < 1 ? 1 : value > 100 ? 100 : value;
    }
}
