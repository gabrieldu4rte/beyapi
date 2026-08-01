namespace BeybladeX.Application.Common.Exceptions;

public class PecaNaoEncontradaException : Exception
{
    public PecaNaoEncontradaException(string nome)
        : base($"Peça '{nome}' não foi encontrada.") { }
}
