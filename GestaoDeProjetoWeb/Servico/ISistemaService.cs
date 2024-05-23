using GestaoDeProjetoWeb.Data;
using GestaoDeProjetoWeb.Data.Projeto;

namespace GestaoDeProjetoWeb.Servico
{
    public interface ISistemaService
    {
        Task<RetornoPaginadoGenerico<ProjetoDto>> ObterTodosProjetosAsync();
        Task IncluirProjetoAsync(ProjetoDto projeto);
    }
}
