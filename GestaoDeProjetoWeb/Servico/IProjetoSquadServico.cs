using GestaoDeProjetoWeb.Data.DTOs;

namespace GestaoDeProjetoWeb.Servico
{
    public interface IProjetoSquadServico
    {
        Task<HttpResponseMessage> InserirAsync(ProjetoSquadDto projetoSquadDto);

        Task<List<ProjetoSquadDto>> ObterTodosAsync();
        Task<string> Excluir(int id);
    }
}
