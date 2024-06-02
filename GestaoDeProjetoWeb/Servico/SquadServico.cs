using GestaoDeProjetoWeb.Data;
using GestaoDeProjetoWeb.Data.DTOs;
using GestaoDeProjetoWeb.Data.Util;
using GestaoDeProjetoWeb.Servico;
using System.Text;
using System.Text.Json;

namespace GestaoDeSquadWeb.Servico
{
    public class SquadServico : ISquadServico
    {
        private readonly HttpClient _httpClient;
        string _url;

        public SquadServico()
        {
            _httpClient = new HttpClient();
            _url = new Servidor().ServidorApi();
        }

        public async Task<List<SquadDto>> ObterTodasSquadAsync()
        {
            List<SquadDto> squads = new List<SquadDto>();
            try
            {
                string response = await _httpClient.GetStringAsync(_url + "Squad/ObterTodos");
                RetornoPaginadoGenerico<SquadDto> resultado = JsonSerializer.Deserialize<RetornoPaginadoGenerico<SquadDto>>(response, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                squads = resultado.Modelos.ToList();
            }
            catch (Exception)
            {
                squads = new List<SquadDto>
                {
                    new SquadDto
                    {
                        Id = 1,
                        Descricao = "Exemplo OFF",
                        Inativo = false
                    }
                };
            }
            return squads;

        }


        public async Task<List<ComboItem>> ObterComboAsync()
        {
            List<ComboItem> combo = await _httpClient.GetFromJsonAsync<List<ComboItem>>("https://localhost:7006/api/v1/Squad/ObterCombo");
            return combo;
        }


        public async Task<string> ExcluirAsync(int id)
        {
            SquadExcluirRequest request = new SquadExcluirRequest { Id = id };
            StringContent requestContent = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");
            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Delete, "https://localhost:7006/api/v1/Squad/Excluir")
            {
                Content = requestContent
            };

            string retorno = "";
            var response = await _httpClient.SendAsync(requestMessage);
            if (!response.IsSuccessStatusCode)
            {
                retorno = ($"Erro ao excluir o Squad com Id: {id}");
            }
            return retorno;
        }

        public async Task<HttpResponseMessage> CadastroAsync(SquadDto squad)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            //var jsonContent = new StringContent(JsonSerializer.Serialize(Squad), Encoding.UTF8, "application/json");
            if (squad.Id == 0)
            {
                response = await _httpClient.PostAsJsonAsync("https://localhost:7006/api/v1/Squad/Inserir", squad);
            }
            else
            {
                response = await _httpClient.PutAsJsonAsync("https://localhost:7006/api/v1/Squad/Alterar", squad);
            }


            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Erro ao incluir Squad. Status code: {response.StatusCode}");
            }

            return response;
        }

    }
}
