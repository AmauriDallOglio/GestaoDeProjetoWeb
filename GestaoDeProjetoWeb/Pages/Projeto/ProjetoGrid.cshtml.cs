using GestaoDeProjetoWeb.Data;
using GestaoDeProjetoWeb.Servico;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;
using System.Text.Json;

namespace GestaoDeProjetoWeb.Pages.Projeto
{
    public class ProjetoGridModel : PageModel
    {
 
        public HttpClient httpClient = new HttpClient();
        public string filtro = string.Empty;
        public List<ProjetoDto> projetos = new();

        private readonly ISistemaService _ISistemaService;

      
        public List<ProjetoDto> listaProjetoGridDto { get; private set; }

        public ProjetoGridModel(ISistemaService service)
        {
            _ISistemaService = service;
        }


        public async Task OnGetAsync(CancellationToken cancellationToken = default)
        {
            projetos = await CarregaTodosProjetosAsync();
        }

        public async Task<List<ProjetoDto>> CarregaTodosProjetosAsync()
        {
            try
            {
                RetornoPaginadoGenerico<ProjetoDto> resultado = _ISistemaService.ObterTodosProjetosAsync().Result;
                projetos = resultado.Modelos.ToList();

                //var response = await httpClient.GetStringAsync("https://localhost:7006/api/v1/Projeto/ObterTodos");
                //RetornoPaginadoGenerico<ProjetoDto> resultado = JsonSerializer.Deserialize<RetornoPaginadoGenerico<ProjetoDto>>(response, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                //projetos = resultado.Modelos.ToList();
            }
            catch (Exception)
            {
                projetos = new List<ProjetoDto>
                {
                    new ProjetoDto
                    {
                        Id = 1,
                        NomeProjeto = "Exemplo OFF",
                        Descricao = "Projeto de exemplo OFF",
                        DataHoraInicio = DateTime.Now,
                        DataHoraFim = DateTime.Now.AddDays(30),
                        Situacao = 0
                    }
                };
            }
            return projetos;
        }

        public string erro;
        public string sucesso;
        public ProjetoDto novaEmpresa = new ProjetoDto();

        public async Task Adicionar()
        {
            try
            {
                if (string.IsNullOrEmpty(novaEmpresa.Descricao))
                {
                    erro = "Descrição não possui informação!";
                    AtivarTemporizadorErro();
                }
                else
                {
                    var response = await httpClient.GetStringAsync("https://localhost:7006/api/v1/Projeto/ObterTodos");
                    projetos = JsonSerializer.Deserialize<List<ProjetoDto>>(response, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });


                    if (projetos.Count() > 0)
                    {
                        await CarregaTodosProjetosAsync();
                        sucesso = "Salvo com sucesso!";
                        AtivarTemporizadorSucesso();
                    }
                    else
                    {
                        erro = "Ocorreu um erro ao adicionar a empresa. Por favor, tente novamente.";
                        AtivarTemporizadorErro();
                    }
                }
            }
            catch (Exception ex)
            {
                erro = "Ocorreu um erro inesperado: " + ex.Message;
                AtivarTemporizadorErro();
            }
        }

        public async Task ExcluirProjetosSelecionados()
        {
            foreach (var projeto in projetosSelecionados)
            {
                // Cria a requisição de exclusão
                var request = new ProjetoExcluirRequest { Id = projeto.Id };

                // Serializa a requisição para JSON
                var requestContent = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");

                // Configura a requisição HTTP DELETE com o corpo JSON
                var requestMessage = new HttpRequestMessage(HttpMethod.Delete, "https://localhost:7006/api/v1/Projeto/Excluir")
                {
                    Content = requestContent
                };

                // Faz a chamada HTTP DELETE
                var response = await httpClient.SendAsync(requestMessage);

                // Verifica se a resposta foi bem-sucedida
                if (!response.IsSuccessStatusCode)
                {
                    // Lidar com erros de exclusão
                    Console.WriteLine($"Erro ao excluir o projeto com Id: {projeto.Id}");
                }
            }
            projetosSelecionados.Clear();
            await CarregaTodosProjetosAsync();
        }


        public string GetSituacaoDescricao(int situacao)
        {
            return situacao switch
            {
                1 => "Planejado",
                2 => "Em Andamento",
                3 => "Concluído",
                4 => "Atrasado",
                5 => "Em Revisão",
                6 => "Em Espera",
                7 => "Em Andamento (Baixa Prioridade)",
                8 => "Em Andamento (Média Prioridade)",
                9 => "Em Andamento (Alta Prioridade)",
                10 => "Em Teste",
                11 => "Pendente Aprovação",
                12 => "Pendente Recursos",
                13 => "Aguardando Feedback do Cliente",
                14 => "Aguardando Aprovação Interna",
                _ => "Desconhecido"
            };
        }

        public async Task AtivarTemporizadorErro()
        {
            await Task.Delay(2000); // Aguarda segundos
            erro = null;
            sucesso = null;
            //StateHasChanged(); // Notifica o Blazor para atualizar a exibição
        }

        public async Task AtivarTemporizadorSucesso()
        {
            await Task.Delay(2000); // Aguarda segundos
            erro = null;
            sucesso = null;
            //StateHasChanged(); // Notifica o Blazor para atualizar a exibição
        }

        public async Task Atualizar()
        {
            try
            {
                novaEmpresa = new ProjetoDto();
                await CarregaTodosProjetosAsync();
            }
            catch (Exception ex)
            {
                erro = "Ocorreu um erro inesperado: " + ex.Message;
                AtivarTemporizadorErro();
            }
        }

        public void AbrirFormulario()
        {
            //NavigationManager.NavigateTo("Projetos/Cadastro");
        }

        public void EditarEmpresa(ProjetoDto empresa)
        {

        }



        public List<ProjetoDto> projetosSelecionados = new List<ProjetoDto>();
        public int contadorSelecionados = 0;
        public bool botaoExcluirHabilitado => projetosSelecionados.Count >= 2;
        bool idSelecionarTodos = false;


        public void SelecionarTodos()
        {
            idSelecionarTodos = !idSelecionarTodos;
            contadorSelecionados = 0;
            projetosSelecionados.Clear();

            if (idSelecionarTodos)
            {
                foreach (var projeto in projetos)
                {
                    projeto.Selecionado = true;
                    if (!projetosSelecionados.Contains(projeto))
                    {
                        projetosSelecionados.Add(projeto);
                        contadorSelecionados++;
                        projeto.Selecionado = true;
                    }
                }
                Console.WriteLine("Checkbox selecionado");
            }
            else
            {
                foreach (var projeto in projetos)
                {
                    projeto.Selecionado = true;
                    if (!projetosSelecionados.Contains(projeto))
                    {
                        projeto.Selecionado = false;
                    }
                }
                Console.WriteLine("Checkbox não selecionado");
            }

        }


        public ProjetoDto projetoSelecionado = null;
        void Selecionado(ProjetoDto projeto)
        {

            if (!projeto.Selecionado)
            {
                projetosSelecionados.Add(projeto);
                contadorSelecionados++;
                projeto.Selecionado = true;
                projetoSelecionado = projeto;
            }
            else
            {
                projetosSelecionados.Remove(projeto);
                contadorSelecionados--;
                projeto.Selecionado = false;
                projetoSelecionado = null;
            }
        }
    }
}
