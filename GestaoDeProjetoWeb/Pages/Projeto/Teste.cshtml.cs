using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GestaoDeProjetoWeb.Pages.Projeto
{
    public class TesteModel : PageModel
    {
        public List<AtivoLocalModel> ativosLocais { get; private set; }

        public async Task OnGetAsync()
        {
            await Task.Run(() =>
            {
                ativosLocais = new List<AtivoLocalModel>
                {
                    new AtivoLocalModel
                    {
                        Referencia = "REF001",
                        Area = "Área A",
                        Setor = "Setor 1",
                        Descricao = "Descrição do Ativo 1",
                        Inativo = false
                    },
                    new AtivoLocalModel
                    {
                        Referencia = "REF002",
                        Area = "Área B",
                        Setor = "Setor 2",
                        Descricao = "Descrição do Ativo 2",
                        Inativo = true
                    },
                    new AtivoLocalModel
                    {
                        Referencia = "REF003",
                        Area = "Área C",
                        Setor = "Setor 3",
                        Descricao = "Descrição do Ativo 3",
                        Inativo = false
                    }
                };
            });
        }
    }

    public class AtivoLocalModel
    {
        public string Referencia { get; set; }
        public string Area { get; set; }
        public string Setor { get; set; }
        public string Descricao { get; set; }
        public bool Inativo { get; set; }
    }
}
