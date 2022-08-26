using ProjetoFinalTecnicas.Logic;

namespace ProjetoFinalTecnicas.Interfaces
{
    public interface IHttpClientStarter
    {
        Task<List<ChessPlayer>> StartHttpClient();
    }
}
