using System.Text.Json;
using ProjetoFinalTecnicas.Interfaces;
using ProjetoFinalTecnicas.Logic;

namespace ProjetoFinalTecnicas
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            IHttpClientStarter _httpClient = new HttpClientStarter();
            IStandardMessages _standardMessage = new StandardMessages();
            IChessMatchStarter _chessMatchStarter = new ChessMatchStarter(_standardMessage);
            IGameStarter _gamestarter = new GameStarter(_chessMatchStarter);
            IMainMenu _mainmenu = new MainMenu(_gamestarter);

            var result = await _httpClient.StartHttpClient();
            _mainmenu.Menu(result);
        }
    }
}