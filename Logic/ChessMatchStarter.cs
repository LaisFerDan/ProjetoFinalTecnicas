using ProjetoFinalTecnicas.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinalTecnicas.Logic
{
    public class ChessMatchStarter : IChessMatchStarter
    {
        private readonly IStandardMessages _standardMessage;
        public ChessMatchStarter(IStandardMessages standardMessage)
        {
            _standardMessage = standardMessage;
        }

        public void MatchStarted(IChessPlayer player1, IChessPlayer player2)
        {
            var rnd1 = new Random();
            var rnd2 = new Random();
            if (rnd1.Next(100) > rnd2.Next(100))
            {
                Console.WriteLine($"  {Thread.CurrentThread.Name}: {player1.username} está com as peças brancas");
                Console.WriteLine($"  {Thread.CurrentThread.Name}: {player2.username} está com as peças pretas");
            }
            else
            {
                Console.WriteLine($"  {Thread.CurrentThread.Name}: {player2.username} está com as peças brancas");
                Console.WriteLine($"  {Thread.CurrentThread.Name}: {player1.username} está com as peças pretas");
            }

            Console.Write($"  {Thread.CurrentThread.Name}: Começando a partida");
            _standardMessage.PrintEllipsis();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine($"  {Thread.CurrentThread.Name}: Começou!");
            Thread.Sleep(800);

            if (rnd1.Next(100) > rnd2.Next(100))
            {
                Console.WriteLine($"  {Thread.CurrentThread.Name}: Jogador {player1.username} venceu!");
                Console.WriteLine($"  {Thread.CurrentThread.Name}: Jogador {player2.username} perdeu");
                player1.wins++;
                player2.loses++;
                player1.number_of_games++;
                player2.number_of_games++;
            }
            else
            {
                Console.WriteLine($"  {Thread.CurrentThread.Name}: Jogador {player2.username} venceu!");
                Console.WriteLine($"  {Thread.CurrentThread.Name}: Jogador {player1.username} perdeu");
                player2.wins++;
                player1.loses++;
                player1.number_of_games++;
                player2.number_of_games++;
            }
        }

    }
}
