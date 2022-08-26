using ProjetoFinalTecnicas.Interfaces;
using System.Text.Json;

namespace ProjetoFinalTecnicas.Logic
{
    public class HttpClientStarter : IHttpClientStarter
    {
        public async Task<List<ChessPlayer>> StartHttpClient()
        {
            HttpClient httpClient = new HttpClient();

            var response = await httpClient.GetAsync($"https://localhost:7112/player");
            var code = response.StatusCode;
            var message = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<List<ChessPlayer>>(message);
            return result;
        }
    }
}
