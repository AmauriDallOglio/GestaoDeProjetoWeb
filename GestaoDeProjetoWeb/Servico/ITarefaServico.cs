using GestaoDeProjetoWeb.Data.DTOs;

namespace GestaoDeProjetoWeb.Servico
{
    public interface ITarefaServico
    {
        Task<List<TarefaDto>> ObterTodasTarefasAsync();
    }
}
