using GestaoDeProjetoWeb.Data;
using System.Text.Json;
using System.Text;

namespace GestaoDeProjetoWeb.Servico
{
    public class SistemaService : ISistemaService
    {
        private readonly HttpClient _httpClient;

        public SistemaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ProjetoDto>> ObterTodosProjetosAsync()
        {
            var response = await _httpClient.GetStringAsync("https://localhost:7006/api/v1/Projeto/ObterTodos");
            return JsonSerializer.Deserialize<List<ProjetoDto>>(response, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
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