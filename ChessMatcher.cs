using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinalTecnicas
{
    public class ChessMatcher
    {
        private ChessPlayer FirstPlayer;
        private ChessPlayer SecondPlayer;

        public ChessMatcher(ChessPlayer firstPlayer, ChessPlayer secondPlayer)
        {
            FirstPlayer = firstPlayer;
            SecondPlayer = secondPlayer;
        }
        public void ChessMatch()
        {
            object _lock1, _lock2;

            if (FirstPlayer.id < SecondPlayer.id)
            {
                _lock1 = FirstPlayer;
                _lock2 = SecondPlayer;
            }
            else
            {
                _lock1 = SecondPlayer;
                _lock2 = FirstPlayer;
            }

            Console.WriteLine($"  {Thread.CurrentThread.Name}: verificando a conexão do jogador {((ChessPlayer)_lock1).username}");

            lock (_lock1)
            {
                Console.WriteLine($"  {Thread.CurrentThread.Name}: conexão estabelecida");
                Console.WriteLine();
                Console.WriteLine($"  {Thread.CurrentThread.Name}: verificando a conexão do jogador {((ChessPlayer)_lock2).username}");
                lock (_lock2)
                {
                    Console.WriteLine($"  {Thread.CurrentThread.Name}: conexão estabelecida");
                    Console.WriteLine();

                    MatchStarted((ChessPlayer)_lock1, (ChessPlayer)_lock2);
                }
            }
        }
        public static void PrintEllipsis()
        {
            var ellipsis = "...";
            for (int i = 0; i < ellipsis.Length; i++)
            {
                Console.Write(ellipsis[i]);
                Thread.Sleep(500);
            }
        }
        public void MatchStarted(ChessPlayer player1, ChessPlayer player2)
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
            PrintEllipsis();
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
            }
            else
            {
                Console.WriteLine($"  {Thread.CurrentThread.Name}: Jogador {player2.username} venceu!");
                Console.WriteLine($"  {Thread.CurrentThread.Name}: Jogador {player1.username} perdeu");
                player2.wins++;
                player1.loses++;
            }
        }
    }
}
