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
            var choice = Prompt.Select("Let's Chess!", new[] { "Nova partida", "Sair" });
            switch (choice)
            {
                case "Nova partida":
                    pageStack.Push(1);
                    GamesPage(pageStack, chessPlayer);
                    break;
                case "Sair":
                    Environment.Exit(0);
                    break;
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
                            Console.WriteLine("Número insuficiente de jogadores, convide seus amigos para jogar");
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
                        Menu(chessPlayer);
                        break;
                }
            } while (choice != "Voltar");

        }
    }
}
