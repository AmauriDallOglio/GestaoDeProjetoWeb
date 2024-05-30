using GestaoDeProjetoWeb.Data;
using GestaoDeProjetoWeb.Data.Squad;
using GestaoDeProjetoWeb.Data.Util;
using System.Text.Json;

namespace GestaoDeProjetoWeb.Servico
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

    }
}
