using GestaoDeProjetoWeb.Data;
using GestaoDeProjetoWeb.Data.DTOs;
using GestaoDeProjetoWeb.Data.Util;
using System.Text;
using System.Text.Json;

namespace GestaoDeProjetoWeb.Servico
{
    public class ProjetoServico : IProjetoServico
    {
        private readonly HttpClient _httpClient;
        string _url;

        public ProjetoServico()
        {
            _httpClient = new HttpClient();
            _url = new Servidor().ServidorApi();
        }

        public async Task<List<ProjetoDto>> ObterTodosProjetosAsync()
        {
            List<ProjetoDto> projetos = new List<ProjetoDto>();
            try
            {

                var response = await _httpClient.GetStringAsync(_url + "Projeto/ObterTodos");
                RetornoPaginadoGenerico<ProjetoDto> resultado = JsonSerializer.Deserialize<RetornoPaginadoGenerico<ProjetoDto>>(response, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                projetos = resultado.Modelos.ToList();
            }
            catch (Exception)
            {
                projetos = new List<ProjetoDto>
                {
                    new ProjetoDto
                    {
                        Id = 1,
                        NomeProjeto = "Exemplo OFF",
                        Descricao = "Exemplo OFF",
                        DataHoraInicio = DateTime.Now,
                        DataHoraFim = DateTime.Now.AddDays(30),
                        Situacao = 0
                    }
                };
            }
            return projetos;

        }


        public async Task<HttpResponseMessage> CadastroAsync(ProjetoDto projeto)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            //var jsonContent = new StringContent(JsonSerializer.Serialize(projeto), Encoding.UTF8, "application/json");
            if (projeto.Id == 0)
            {
                response = await _httpClient.PostAsJsonAsync("https://localhost:7006/api/v1/Projeto/Inserir", projeto);
            }
            else
            {
                response = await _httpClient.PutAsJsonAsync("https://localhost:7006/api/v1/Projeto/Alterar", projeto);
            }

 
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Erro ao incluir projeto. Status code: {response.StatusCode}");
            }

            return response;
        }


        public async Task<string> Excluir(int id)
        {
            ProjetoExcluirRequest request = new ProjetoExcluirRequest { Id = id };
            StringContent requestContent = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");
            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Delete, "https://localhost:7006/api/v1/Projeto/Excluir")
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


        public async Task<List<ComboItem>> ObterComboAsync()
        {
            List<ComboItem> combo = await _httpClient.GetFromJsonAsync<List<ComboItem>>("https://localhost:7006/api/v1/Projeto/ObterCombo");
            return combo;
        }


    }
}