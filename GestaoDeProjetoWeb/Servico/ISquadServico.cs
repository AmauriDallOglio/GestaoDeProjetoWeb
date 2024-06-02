using GestaoDeProjetoWeb.Data.DTOs;
using GestaoDeProjetoWeb.Data.Util;

namespace GestaoDeProjetoWeb.Servico
{
    public interface ISquadServico
    {

        Task<List<SquadDto>> ObterTodasSquadAsync();
        Task<List<ComboItem>> ObterComboAsync();
        Task<string> ExcluirAsync(int id);

        Task<HttpResponseMessage> CadastroAsync(SquadDto squadDto);
    }
}
