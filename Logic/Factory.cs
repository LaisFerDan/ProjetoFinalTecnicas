using ProjetoFinalTecnicas.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinalTecnicas.Logic
{
    public static class Factory
    {
        public static IChessMatcher CreateChessMatcher()
        {
            return new ChessMatcher(CreateChessPlayer(), CreateChessPlayer(), CreateChessMatchStarter());
        }

        public static IChessMatchStarter CreateChessMatchStarter()
        {
            return new ChessMatchStarter(CreateStandardMessages());
        }
        public static IChessPlayer CreateChessPlayer()
        {
            return new ChessPlayer();
        }

        public static IGameStarter CreateGameStarter()
        {
            return new GameStarter(CreateChessMatchStarter());
        }

        public static IHttpClientStarter CreateHttpClientStarter()
        {
            return new HttpClientStarter();
        }
        public static IMainMenu CreateMainMenu()
        {
            return new MainMenu(CreateGameStarter());
        }

        public static IStandardMessages CreateStandardMessages()
        {
            return new StandardMessages();
        }
    }
}
