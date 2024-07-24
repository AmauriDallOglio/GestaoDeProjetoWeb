using GestaoDeProjetoWeb.Data.DTOs;

namespace GestaoDeProjetoWeb.Servico
{
    public interface IUsuarioServico
    {
        Task<List<UsuarioDto>> ObterTodasUsuariosAsync();

        //Task<string> ExcluirAsync(int id);
    }
}
