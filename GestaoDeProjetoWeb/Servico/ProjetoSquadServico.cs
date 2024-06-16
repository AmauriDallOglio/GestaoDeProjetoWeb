using GestaoDeProjetoWeb.Data;
using GestaoDeProjetoWeb.Data.DTOs;
using System.Text;
using System.Text.Json;

namespace GestaoDeProjetoWeb.Servico
{
    public class ProjetoSquadServico : IProjetoSquadServico
    {
        private readonly HttpClient _httpClient;
        string _url;

        public ProjetoSquadServico()
        {
            _httpClient = new HttpClient();
            _url = new Servidor().ServidorApi();
        }

        public async Task<HttpResponseMessage> InserirAsync(ProjetoSquadDto projetoSquadDto)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            //var jsonContent = new StringContent(JsonSerializer.Serialize(projeto), Encoding.UTF8, "application/json");
            response = await _httpClient.PostAsJsonAsync("https://localhost:7006/api/v1/ProjetoSquad/Inserir", projetoSquadDto);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Erro ao incluir a squad no projeto. Status code: {response.StatusCode}");
            }
            return response;
        }

        public async Task<HttpResponseMessage> AlterarAsync(ProjetoSquadDto projetoSquadDto)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            //var jsonContent = new StringContent(JsonSerializer.Serialize(projeto), Encoding.UTF8, "application/json");
            response = await _httpClient.PostAsJsonAsync("https://localhost:7006/api/v1/ProjetoSquad/Alterar", projetoSquadDto);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Erro ao alterar a squad no projeto. Status code: {response.StatusCode}");
            }
            return response;
        }

        public async Task<List<ProjetoSquadDto>> ObterTodosAsync()
        {
            List<ProjetoSquadDto> lista = new List<ProjetoSquadDto>();
            try
            {

                var response = await _httpClient.GetStringAsync(_url + "ProjetoSquad/ObterTodos");
                RetornoPaginadoGenerico<ProjetoSquadDto> resultado = JsonSerializer.Deserialize<RetornoPaginadoGenerico<ProjetoSquadDto>>(response, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                lista = resultado.Modelos.ToList();
            }
            catch (Exception)
            {
                lista.Add
                (
                    new ProjetoSquadDto
                    {
                
                        NomeProjeto = "Exemplo OFF"

                    }
                );
            }
            return lista;
        }


        public async Task<string> Excluir(int id)
        {
            ProjetoExcluirRequest request = new ProjetoExcluirRequest { Id = id };
            StringContent requestContent = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");
            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Delete, "https://localhost:7006/api/v1/ProjetoSquad/Excluir")
            {
                Content = requestContent
            };

            string retorno = "";
            var response = await _httpClient.SendAsync(requestMessage);
            if (!response.IsSuccessStatusCode)
            {
                retorno = ($"Erro ao excluir o projeto com Id: {id}");
            }
            return retorno;
        }

    }
}
