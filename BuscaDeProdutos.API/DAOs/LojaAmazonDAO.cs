using System.Net;
using DesafioBootcamp.DAOs.Interfaces;
using DesafioBootcamp.DTOs;
using Newtonsoft.Json;

namespace DesafioBootcamp.DAOs;

public class LojaAmazonDAO : ILojasCadastradasDAO
{
    private static readonly string _apiKey = "c3c7dec8b2msh11b9af671cb7e29p14b408jsnf34ad4d67522";
    private static readonly string _urlBase = "https://amazon23.p.rapidapi.com";
    public List<ProdutoAmazonItemDAO> Result { get; set; } = new();
    
    public async Task<List<ProdutoDTO>> BuscarProdutos(string query)
    {
        var client = new HttpClient();
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri($"{_urlBase}/product-search?query={query}&country=BR"),
            Headers =
            {
                { "X-RapidAPI-Key", _apiKey},
                { "X-RapidAPI-Host", "amazon23.p.rapidapi.com" }, 
            },
        };
        using var response = await client.SendAsync(request);
        response.EnsureSuccessStatusCode();
        var retorno = await response.Content.ReadAsStringAsync();
        var produtos = JsonConvert.DeserializeObject<LojaAmazonDAO>(retorno);
        return produtos.Result.Select(s => s.ToProdutoDTO()).ToList();
    }

    public async Task<List<ProdutoDTO>> BuscarProdutosPorId(string id)
    {
        var client = new HttpClient();
        // https://amazon23.p.rapidapi.com/product-details?asin=B08G9J44ZN&country=BR
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri($"{_urlBase}/product-details?asin={id}&country=BR"),
            Headers =
            {
                { "X-RapidAPI-Key", _apiKey},
                { "X-RapidAPI-Host", "amazon23.p.rapidapi.com" }, 
            },
        };
        using var response = await client.SendAsync(request);
        if (response.StatusCode is HttpStatusCode.NotFound)
            return new List<ProdutoDTO>();
        var retorno = await response.Content.ReadAsStringAsync();
        var produtos = JsonConvert.DeserializeObject<LojaAmazonDAO>(retorno);
        return produtos.Result.Select(s => s.ToProdutoDTO()).ToList();
    }
}

public class ProdutoAmazonItemDAO
{
    public string Asin { get; set; }
    public string Title { get; set; }
    public string Url { get; set; }
    public string Thumbnail { get; set; }
    public int AvailableQuantity { get; set; }
    public ProdutoPrecoAmazonDAO Price { get; set; } = new ();

    public ProdutoDTO ToProdutoDTO()
    {
        return new ProdutoDTO()
        {
            Id = "amz$"+Asin,
            Nome = Title,
            Url = Url,
            Thumbnail = Thumbnail,
            QuantidadeDisponivel = AvailableQuantity,
            Preco = Price.CurrentPrice
        };
    }
}

public class ProdutoPrecoAmazonDAO
{
    public float CurrentPrice { get; set; }
}