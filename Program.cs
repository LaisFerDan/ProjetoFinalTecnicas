using System.Net.Http.Headers;
using System.Text.Json;
using System.Collections.Generic;

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

            Console.WriteLine("Main Thread Started");
            ChessPlayer chessPlayer1 = new ChessPlayer(result[0].username);
            ChessPlayer chessPlayer2 = new ChessPlayer(result[1].username);
            ChessMatcher chessMatcher1 = new ChessMatcher(chessPlayer1, chessPlayer2);

            Thread thread1 = new Thread(chessMatcher1.ChessMatch)
            {
                Name = "Thread1"
            };

            
            thread1.Start();

            thread1.Join();

            Console.WriteLine("Main Thread Completed");
            Console.ReadKey();
        }
    }
}