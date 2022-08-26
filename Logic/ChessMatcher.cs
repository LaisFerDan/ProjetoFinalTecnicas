﻿using ProjetoFinalTecnicas.Interfaces;

namespace ProjetoFinalTecnicas.Logic
{
    public class ChessMatcher : IChessMatcher
    {
        private readonly ChessPlayer FirstPlayer;
        private readonly ChessPlayer SecondPlayer;
        private readonly IChessMatchStarter _chessMatchStarter;

        public ChessMatcher(ChessPlayer firstPlayer, ChessPlayer secondPlayer, IChessMatchStarter chessMatchStarter)
        {
            FirstPlayer = firstPlayer;
            SecondPlayer = secondPlayer;
            _chessMatchStarter = chessMatchStarter;
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

                    _chessMatchStarter.MatchStarted((ChessPlayer)_lock1, (ChessPlayer)_lock2);
                }
            }
        }
    }
}
