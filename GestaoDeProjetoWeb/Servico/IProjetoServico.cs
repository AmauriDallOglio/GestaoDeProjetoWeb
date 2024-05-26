using GestaoDeProjetoWeb.Data.Projeto;
using GestaoDeProjetoWeb.Data;

namespace GestaoDeProjetoWeb.Servico
{
    public interface IProjetoServico
    {
        //Task<RetornoPaginadoGenerico<ProjetoDto>> ObterTodosProjetosAsync();

        Task<List<ProjetoDto>> ObterTodosProjetosAsync();

        Task<HttpResponseMessage> CadastroAsync(ProjetoDto projeto);

        Task<string> Excluir(int id);
    }
}
