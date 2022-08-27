using ProjetoFinalTecnicas.Interfaces;
using Sharprompt;

namespace ProjetoFinalTecnicas.Logic
{
    public class MainMenu : IMainMenu
    {
        private readonly IGameStarter _gameStarter;
        public MainMenu(IGameStarter gameStarter)
        {
            _gameStarter = gameStarter;
        }
        public void Menu(List<ChessPlayer> chessPlayer)
        {
            Console.Clear();
            var pageStack = new Stack<int>();
            if (chessPlayer.Count > 0)
            {
                var choice = Prompt.Select("Let's Chess!", new[] { "Nova partida", "Visualizar meu perfil", "Sair" });
                switch (choice)
                {
                    case "Nova partida":
                        pageStack.Push(1);
                        GamesPage(pageStack, chessPlayer);
                        break;
                    case "Visualizar meu perfil":
                        pageStack.Push(2);
                        ProfilePage(pageStack, chessPlayer);
                        break;
                    case "Sair":
                        Environment.Exit(0);
                        break;
                }
            }
            else
            {
                Console.WriteLine("Parece que sua lista de jogadores está vazia. \nUse o Web API para adicionar jogadores e volte para jogar.");
                Console.ReadKey();
                Environment.Exit(0);
            }
        }

        public void GamesPage(Stack<int> pageStack, List<ChessPlayer> chessPlayer)
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
                            Console.WriteLine("Número insuficiente de jogadores");
                            Console.ReadKey();
                        }
                        else
                            _gameStarter.GameStart(playerQueue.Dequeue(), playerQueue.Dequeue());
                        break;

                    case "Entrar na fila para jogar":
                        if (playerQueue.Contains(chessPlayer[0]))
                        {
                            Console.WriteLine("Você já está na fila para jogar, convide seus amigos!");
                            Console.ReadKey();
                        }
                        else
                            playerQueue.Enqueue(chessPlayer[0]);
                        break;

                    case "Convidar amigo para jogar":
                        if (chessPlayer.Count == playerQueue.Count && playerQueue.Contains(chessPlayer[0]))
                        {
                            Console.WriteLine("Todos os seus amigos já foram convidados");
                            Console.ReadKey();
                        }
                        else if (playerQueue.Contains(chessPlayer[0]))
                        {
                            if (index > playerQueue.Count)
                                index = 1;
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
                        Menu(chessPlayer);
                        break;
                }
            } while (choice != "Voltar");
        }
        public void ProfilePage(Stack<int> pageStack, List<ChessPlayer> chessPlayer)
        {
            var answer = true;
            string username = chessPlayer[0].username;
            do
            {
                Console.Clear();
                Console.WriteLine($" {chessPlayer[0].url}");
                Console.WriteLine($"  {char.ToUpper(username[0]) + username.Substring(1)} {chessPlayer[0].country}");
                Console.WriteLine($"  {chessPlayer[0].name}");
                Console.WriteLine($"  Last online: {chessPlayer[0].last_online.ToString("dd-MM-yyyy")} | Joined: {chessPlayer[0].joined.ToString("dd-MM-yyyy")} | Followers: {chessPlayer[0].followers}");
                Console.WriteLine($"  Best rating: {chessPlayer[0].best_rating}");
                Console.WriteLine($"  Games: {chessPlayer[0].number_of_games}");
                Console.WriteLine($"  W {chessPlayer[0].wins} | L {chessPlayer[0].loses}");

                Console.WriteLine();
                answer = Prompt.Confirm("Deseja voltar?");
            } while (answer == false);
            pageStack.Pop();
            Menu(chessPlayer);
        }
    }
}
