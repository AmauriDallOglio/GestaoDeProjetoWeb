using GestaoDeProjetoWeb.Data;

namespace GestaoDeProjetoWeb.Servico
{
    public interface ISistemaService
    {
        Task<List<ProjetoDto>> ObterTodosProjetosAsync();
        Task IncluirProjetoAsync(ProjetoDto projeto);
    }
}
