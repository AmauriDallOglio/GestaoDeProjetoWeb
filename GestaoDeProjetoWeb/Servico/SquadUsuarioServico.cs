using GestaoDeProjetoWeb.Data;
using GestaoDeProjetoWeb.Data.DTOs;
using System.Text.Json;

namespace GestaoDeProjetoWeb.Servico
{
    public class SquadUsuarioServico : ISquadUsuarioServico
    {
        private readonly HttpClient _httpClient;
        string _url;

        public SquadUsuarioServico()
        {
            _httpClient = new HttpClient();
            _url = new Servidor().ServidorApi();
        }


       
    }
}
