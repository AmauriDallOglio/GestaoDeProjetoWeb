using GestaoDeProjetoWeb.Data;

namespace GestaoDeProjetoWeb.Servico
{
    public interface ISistemaService
    {
        Task<RetornoPaginadoGenerico<ProjetoDto>> ObterTodosProjetosAsync();
        Task IncluirProjetoAsync(ProjetoDto projeto);
    }
}
