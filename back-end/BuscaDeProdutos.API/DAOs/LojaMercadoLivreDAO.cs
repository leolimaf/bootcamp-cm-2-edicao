using System.Net.Http.Headers;
using DesafioBootcamp.DAOs.Interfaces;
using DesafioBootcamp.DTOs;
using Newtonsoft.Json;

namespace DesafioBootcamp.DAOs;

public class LojaMercadoLivreDAO : ILojasCadastradas
{
    private static readonly string _apiKey = "0UgEpizqJM7CSl3O9nbIzrTvTuaU2JZG";
    private static readonly string _urlBase = "https://api.mercadolibre.com";
    public List<ProdutoMercardoLivreItem> Results { get; set; } = new();
    
    public async Task<List<ProdutoDTO>> BuscarProdutos(string query)
    {
        var client = new HttpClient(new HttpClientHandler());
        client.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", _apiKey);
        client.BaseAddress = new Uri(_urlBase);
        var response = await client.GetStringAsync($"/sites/MLB/search?q={query}&status=active");

        var responseObj = JsonConvert.DeserializeObject<LojaMercadoLivreDAO>(response)!;

        return responseObj.Results.Select(s => s.ToProdutoDTO()).ToList();
    }

    public async Task<List<ProdutoDTO>> BuscarProdutosPorId(string id)
    {
        var client = new HttpClient(new HttpClientHandler());
        client.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", _apiKey);
        client.BaseAddress = new Uri(_urlBase);
        var response = await client.GetStringAsync($"/items?ids={id}");

        var responseObj = JsonConvert.DeserializeObject<LojaMercadoLivreDAO>(response)!;

        return responseObj.Results.Select(s => s.ToProdutoDTO()).ToList();
    }
}

public class ProdutoMercardoLivreItem
{
    public string Id { get; set; }
    public string Title { get; set; }
    public string Permalink { get; set; }
    public string Thumbnail { get; set; }
    public int AvailableQuantity { get; set; }
    public float Price { get; set; }
    public ProdutoDTO ToProdutoDTO()
    {
        return new ProdutoDTO()
        {
            Id = "ml$"+Id,
            Nome = Title,
            Url = Permalink,
            Thumbnail = Thumbnail,
            QuantidadeDisponivel = AvailableQuantity,
            Preco = Price
        };
    }
}

