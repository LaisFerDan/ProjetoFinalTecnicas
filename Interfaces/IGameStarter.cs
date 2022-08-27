using ProjetoFinalTecnicas.Logic;

namespace ProjetoFinalTecnicas.Interfaces
{
    public interface IGameStarter
    {
        void GameStart(IChessPlayer chessPlayer1, IChessPlayer chessPlayer2);
    }
}