using System.Text.Json;
using ProjetoFinalTecnicas.Interfaces;
using ProjetoFinalTecnicas.Logic;

namespace ProjetoFinalTecnicas
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            HttpClient httpClient = new HttpClient();

            var response = await httpClient.GetAsync($"https://localhost:7112/player");
            var code = response.StatusCode;
            var message = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<List<ChessPlayer>>(message);
            //List<ChessPlayer>? result = await _httpClientStarter.StartHttpClient
            
            IGameStarter _gamestarter = new GameStarter();
            IMainMenu _mainmenu = new MainMenu(_gamestarter);

            _mainmenu.Menu(result);
        }
    }
}