using GestaoDeProjetoWeb.Data;
using GestaoDeProjetoWeb.Data.Projeto;
using System.Text;
using System.Text.Json;

namespace GestaoDeProjetoWeb.Servico
{
    public class SistemaService : ISistemaService
    {
        private readonly HttpClient _httpClient;
        string _url;

        public SistemaService()
        {
            _httpClient = new HttpClient();
            _url = "https://localhost:7006/api/v1/";
        }

        public async Task<RetornoPaginadoGenerico<ProjetoDto>> ObterTodosProjetosAsync()
        {
            HttpClient httpClient = new HttpClient();
            //var response = await httpClient.GetStringAsync("https://localhost:7006/api/v1/Projeto/ObterTodos");
            //RetornoPaginadoGenerico<ProjetoDto> resultado = JsonSerializer.Deserialize<RetornoPaginadoGenerico<ProjetoDto>>(response, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            //return resultado;


            var response = await httpClient.GetStringAsync("https://localhost:7006/api/v1/Projeto/ObterTodos");
            RetornoPaginadoGenerico<ProjetoDto> resultado = JsonSerializer.Deserialize<RetornoPaginadoGenerico<ProjetoDto>>(response, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return resultado;

        }

        public async Task IncluirProjetoAsync(ProjetoDto projeto)
        {
            var jsonContent = new StringContent(JsonSerializer.Serialize(projeto), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("https://localhost:7006/api/v1/Projeto/Incluir", jsonContent);

            if (!response.IsSuccessStatusCode)
            {
                // Lógica de tratamento de erro, se necessário
                throw new Exception($"Erro ao incluir projeto. Status code: {response.StatusCode}");
            }
        }

        // Implemente outros métodos conforme necessário
    }
}