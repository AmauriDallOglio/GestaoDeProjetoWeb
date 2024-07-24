using GestaoDeProjetoWeb.Data;
using GestaoDeProjetoWeb.Data.DTOs;
using System.Text.Json;

namespace GestaoDeProjetoWeb.Servico
{
    public class TarefaServico : ITarefaServico
    {
        private readonly HttpClient _httpClient;
        string _url;

        public TarefaServico()
        {
            _httpClient = new HttpClient();
            _url = new Servidor().ServidorApi();
        }

        public async Task<List<TarefaDto>> ObterTodasTarefasAsync()
        {
            List<TarefaDto> tarefas = new List<TarefaDto>();
            try
            {
                string response = await _httpClient.GetStringAsync(_url + "Tarefa/ObterTodos");
                RetornoPaginadoGenerico<TarefaDto> resultado = JsonSerializer.Deserialize<RetornoPaginadoGenerico<TarefaDto>>(response, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                tarefas = resultado.Modelos.ToList();
            }
            catch (Exception)
            {
                tarefas = new List<TarefaDto>
                {
                    new TarefaDto
                    {
 
                        Id = 1,
                        Id_Empresa = 1,
                        Empresa = new EmpresaDto { Id = 1, NomeFantasia = "Empresa OFF" },
                        Id_Projeto = 1,
                        Projeto = new ProjetoDto { Id = 1, NomeProjeto = "Projeto OFF" },
                        Descricao = "Tarefa de OFF",
                        Objetivo = "Objetivo da tarefa de OFF",
                        Resultado = "Resultado esperado",
                        Fase = 1,
                        Ordem = 1,
                        HorasEstimada = 10,
                        DataInicialEstimado = new DateTime(2024, 5, 13, 8, 0, 0),
                        DataFinalEstimado = new DateTime(2024, 5, 13, 18, 0, 0),
                        DataInicialRealizado = new DateTime(2024, 5, 13, 8, 0, 0),
                        DataFinalRealizado = new DateTime(2024, 5, 13, 18, 0, 0),
                        Sprint = "Sprint 1",
                        Situacao = 0
 
                    }
                };
            }
            return tarefas;
        }
    }
}
