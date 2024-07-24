using GestaoDeProjetoWeb.Data.DTOs;
using GestaoDeProjetoWeb.Data;
using System.Text.Json;

namespace GestaoDeProjetoWeb.Servico
{
    public class UsuarioServico : IUsuarioServico
    {

        private readonly HttpClient _httpClient;
        string _url;

        public UsuarioServico()
        {
            _httpClient = new HttpClient();
            _url = new Servidor().ServidorApi();
        }


        public async Task<List<UsuarioDto>> ObterTodasUsuariosAsync()
        {
            List<UsuarioDto> usuarios = new List<UsuarioDto>();
            try
            {
                string response = await _httpClient.GetStringAsync(_url + "Usuario/ObterTodos");
                RetornoPaginadoGenerico<UsuarioDto> resultado = JsonSerializer.Deserialize<RetornoPaginadoGenerico<UsuarioDto>>(response, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                usuarios = resultado.Modelos.ToList();
            }
            catch (Exception)
            {
                usuarios = new List<UsuarioDto>
                {
                    new UsuarioDto
                    {
                        Id = 1,
                        Nome = "Exemplo OFF",
                        Cargo = "Exemplo OFF",
                        Email = "Exemplo OFF",
                        Telefone = "Exemplo OFF",

                        Situacao = 0
                    }
                };
            }
            return usuarios;

        }

        public async Task<string> ExcluirAsync(int id)
        {
  
            var retorno = ($"Erro ao excluir o Squad com Id: {id}");
            
            return retorno;
        }


    }
}
