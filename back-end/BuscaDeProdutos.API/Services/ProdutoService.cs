using DesafioBootcamp.DTOs;
using DesafioBootcamp.Factory;
using DesafioBootcamp.Services.Interfaces;

namespace DesafioBootcamp.Services;

public class ProdutoService : IProdutoService
{
    public async Task<IEnumerable<ProdutoDTO>> BuscarProdutosPorNome(string nome)
    {
        var lista = LojaFactory.Get().Values;
        var produtos = new List<ProdutoDTO>();
        foreach (var loja in lista)
        {
            var result = await loja.BuscarProdutos(nome);
            produtos.AddRange(result);
        }

        return produtos;
    }

    public async Task<IEnumerable<ProdutoDTO>> ObterProdutosPorId(string id)
    {
        var loja = id.Split("$");
        var lojasCadastradas = LojaFactory.RetornarLojas(loja[0]);
        return await lojasCadastradas.BuscarProdutosPorId(loja[1]);
    }
}