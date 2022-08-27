using System.Text.Json;
using Microsoft.Extensions.DependencyInjection;
using ProjetoFinalTecnicas.Interfaces;
using ProjetoFinalTecnicas.Logic;

namespace ProjetoFinalTecnicas
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            IHttpClientStarter _httpClient = Factory.CreateHttpClientStarter();
            IMainMenu _mainmenu = Factory.CreateMainMenu();

            var result = await _httpClient.StartHttpClient();
            _mainmenu.Menu(result);
        }
    }
}