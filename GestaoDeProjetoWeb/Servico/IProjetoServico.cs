using GestaoDeProjetoWeb.Data.Projeto;
using GestaoDeProjetoWeb.Data.Util;

namespace GestaoDeProjetoWeb.Servico
{
    public interface IProjetoServico
    {
        //Task<RetornoPaginadoGenerico<ProjetoDto>> ObterTodosProjetosAsync();

        Task<List<ProjetoDto>> ObterTodosProjetosAsync();

        Task<HttpResponseMessage> CadastroAsync(ProjetoDto projeto);
        Task<List<ComboItem>> ObterComboAsync();

        Task<string> Excluir(int id);
    }
}
