using DesafioBootcamp.Factory;
using DesafioBootcamp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DesafioBootcamp.Controllers;

[ApiController]
[Route("[controller]")]
[Produces("application/json")]
public class ProdutoController : ControllerBase
{
    private readonly IProdutoService _produtoService;

    public ProdutoController(IProdutoService produtoService)
    {
        _produtoService = produtoService;
    }

    [HttpGet, Route("[action]")]
    public async Task<IActionResult> BuscarProdutosPorNome(string nome)
    {
        return Ok(await _produtoService.BuscarProdutosPorNome(nome));
    }
    
    [HttpGet, Route("[action]")]
    public async Task<IActionResult> ObterProdutoPorId(string id)
    {
        return Ok(await _produtoService.ObterProdutosPorId(id));
    }
}