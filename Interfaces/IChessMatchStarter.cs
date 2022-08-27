using ProjetoFinalTecnicas.Logic;

namespace ProjetoFinalTecnicas.Interfaces
{
    public interface IChessMatchStarter
    {
        void MatchStarted(IChessPlayer player1, IChessPlayer player2);
    }
}