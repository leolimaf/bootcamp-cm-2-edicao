using DesafioBootcamp.DTOs;

namespace DesafioBootcamp.Services.Interfaces;

public interface IProdutoService
{
    Task<IEnumerable<ProdutoDTO>> BuscarProdutosPorNome(string nome);
    Task<IEnumerable<ProdutoDTO>> ObterProdutosPorId(string id);
}