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

            Console.WriteLine($"{Thread.CurrentThread.Name}: trying to connect Player {((ChessPlayer)_lock1).username}");

            lock (_lock1)
            {
                Console.WriteLine($"{Thread.CurrentThread.Name}: Player {((ChessPlayer)_lock1).username} acquired connection");
                Console.Write($"{Thread.CurrentThread.Name}: looking for an opponent");
                PrintEllipsis();
                Console.WriteLine();
                Console.WriteLine($"{Thread.CurrentThread.Name}: trying to connect with Player {((ChessPlayer)_lock2).username}");
                lock (_lock2)
                {
                    Console.WriteLine($"{Thread.CurrentThread.Name}: acquired connection with Player {((ChessPlayer)_lock2).username}");
                    Console.Write("Starting the match");
                    PrintEllipsis();
                    Console.WriteLine();
                    Console.WriteLine("Match started!");
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
            var rnd1 = new Random().Next(100);
            var rnd2 = new Random().Next(100);
            if (rnd1 > rnd2) 
            {
                Console.WriteLine($"{Thread.CurrentThread.Name}: Player {player1.username} wins!");
                Console.WriteLine($"{Thread.CurrentThread.Name}: Player {player2.username} loses");
                player1.wins++;
                player2.loses++;
            }
            else
            {
                Console.WriteLine($"{Thread.CurrentThread.Name}: Player {player2.username} wins!");
                Console.WriteLine($"{Thread.CurrentThread.Name}: Player {player1.username} loses");
                player2.wins++;
                player1.loses++;
            }
        }
    }
}
