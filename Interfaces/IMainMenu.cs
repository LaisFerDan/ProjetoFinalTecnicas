using ProjetoFinalTecnicas.Logic;

namespace ProjetoFinalTecnicas.Interfaces
{
    public interface IMainMenu
    {
        void Menu(List<ChessPlayer> chessPlayer);
        void GamesPage(Stack<int> pageStack, List<ChessPlayer> chessPlayer);
        void ProfilePage(Stack<int> pageStack, List<ChessPlayer> chessPlayer);
    }
}