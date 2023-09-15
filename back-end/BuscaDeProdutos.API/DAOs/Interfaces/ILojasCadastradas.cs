using DesafioBootcamp.DTOs;

namespace DesafioBootcamp.DAOs.Interfaces;

public interface ILojasCadastradas
{
    Task<List<ProdutoDTO>> BuscarProdutos(string query);
    Task<List<ProdutoDTO>> BuscarProdutosPorId(string id);
}