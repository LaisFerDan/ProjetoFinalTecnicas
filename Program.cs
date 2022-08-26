using System.Net.Http.Headers;
using System.Text.Json;
using System.Collections.Generic;
using Sharprompt;
using System.Diagnostics;

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

            MainMenu(result);
        }
        public static void MainMenu(List<ChessPlayer> chessPlayer)
        {
            Console.Clear();
            var pageStack = new Stack<int>();
            var choice = Prompt.Select("Let's Chess!", new[] { "Nova partida", "Visitar o meu perfil", "Sair" });
            switch (choice)
            {
                case "Nova partida":
                    pageStack.Push(1);
                    GamesPage(pageStack, chessPlayer);
                    break;
                case "Visitar o meu perfil":
                    break;
                case "Sair":
                    Environment.Exit(0);
                    break;
            }
        }
        public static void GamesPage(Stack<int> pageStack, List<ChessPlayer> chessPlayer)
        {
            var playerQueue = new Queue<ChessPlayer>();
            var choice = "";
            var index = 1;
            do
            {
                Console.Clear();
                choice = Prompt.Select("Let's Chess!", new[] { "Começar partida", "Entrar na fila para jogar", "Convidar amigo para jogar", "Voltar" });
                switch (choice)
                {
                    case "Começar partida":
                        if (playerQueue.Count < 2)
                        {
                            Console.WriteLine("Número insuficiente de jogadores, convide seus amigos para jogar");
                            Console.ReadKey();
                        }
                        else
                            GameStart(chessPlayer[0], chessPlayer[1]);
                        break;
                    case "Entrar na fila para jogar":
                        if (playerQueue.Count > 0)
                        {
                            Console.WriteLine("Você já está na fila para jogar, convide seus amigos!");
                            Console.ReadKey();
                        }
                        else
                            playerQueue.Enqueue(chessPlayer[0]);
                        break;
                    case "Convidar amigo para jogar":
                        if (index >= chessPlayer.Count)
                        {
                            Console.WriteLine("Todos os seus amigos já foram convidados");
                            Console.ReadKey();
                        }
                        else if (playerQueue.Count >= 1)
                        {
                            playerQueue.Enqueue(chessPlayer[index]);
                            Console.WriteLine($"Amigo {chessPlayer[index].username} convidado!");
                            index++;
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("Primeiro entre na fila para jogar");
                            Console.ReadKey();
                        }

                        break;
                    case "Voltar":
                        pageStack.Pop();
                        MainMenu(chessPlayer);
                        break;
                }
            } while (choice != "Voltar");
            
        }

        public static void GameStart(ChessPlayer chessPlayer1, ChessPlayer chessPlayer2)
        {
            var answer = false;
            do
            {
                Console.Clear();
                Console.WriteLine("  Let's Chess!");
                ChessMatcher chessMatcher = new ChessMatcher(chessPlayer1, chessPlayer2);

                Thread thread1 = new Thread(chessMatcher.ChessMatch)
                {
                    Name = "Partida"
                };


                thread1.Start();

                thread1.Join();

                Console.WriteLine("  Partida encerrada");
                Console.WriteLine();

                answer = Prompt.Confirm("Revanche?");

            } while (answer == true);
          
        }
    }
}