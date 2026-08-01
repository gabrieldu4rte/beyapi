using BeybladeX.Application.DTOs;
using BeybladeX.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BeybladeX.Api.Controllers;

[ApiController]
[Route("api/v1/pecas")]
public class PecasController : ControllerBase
{
    private readonly IPecaService _service;

    public PecasController(IPecaService service)
    {
        _service = service;
    }

    /// <summary>
    /// Obtém uma peça Beyblade X pelo nome.
    /// </summary>
    /// <param name="nome">Nome da peça (case-insensitive)</param>
    /// <param name="ct">Token de cancelamento</param>
    /// <returns>Dados da peça encontrada</returns>
    /// <response code="200">Peça encontrada com sucesso</response>
    /// <response code="400">Nome inválido</response>
    /// <response code="404">Peça não encontrada</response>
    [HttpGet("{nome}")]
    [ProducesResponseType(typeof(PecaDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ObterPorNome([FromRoute] string nome, CancellationToken ct)
    {
        var result = await _service.ObterPorNomeAsync(nome, ct);
        return Ok(result);
    }
}
