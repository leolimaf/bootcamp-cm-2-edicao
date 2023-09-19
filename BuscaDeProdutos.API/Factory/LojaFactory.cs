using DesafioBootcamp.DAOs;
using DesafioBootcamp.DAOs.Interfaces;

namespace DesafioBootcamp.Factory;

public abstract class LojaFactory
{
    private static readonly Dictionary<string, ILojasCadastradasDAO> LojasCadastradas = new ();
    public static Dictionary<string, ILojasCadastradasDAO> Get() =>  LojasCadastradas;

    static LojaFactory()
    {
        // LojasCadastradas.Add("amz", new LojaAmazonDAO());
        LojasCadastradas.Add("ml", new LojaMercadoLivreDAO());
    }
    
    public static ILojasCadastradasDAO RetornarLojas(string monitor)
    {
        if (!LojasCadastradas.ContainsKey(monitor.ToLower()))
            throw new Exception("Erro: Loja invalida");
        return LojasCadastradas[monitor];
    }
}