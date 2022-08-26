using ProjetoFinalTecnicas.Interfaces;
using Sharprompt;

namespace ProjetoFinalTecnicas.Logic
{
    public class GameStarter : IGameStarter
    {
        public async void GameStart(ChessPlayer chessPlayer1, ChessPlayer chessPlayer2)
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
