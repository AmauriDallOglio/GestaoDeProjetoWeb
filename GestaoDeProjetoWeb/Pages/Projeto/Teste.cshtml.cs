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
                        Area = "�rea A",
                        Setor = "Setor 1",
                        Descricao = "Descri��o do Ativo 1",
                        Inativo = false
                    },
                    new AtivoLocalModel
                    {
                        Referencia = "REF002",
                        Area = "�rea B",
                        Setor = "Setor 2",
                        Descricao = "Descri��o do Ativo 2",
                        Inativo = true
                    },
                    new AtivoLocalModel
                    {
                        Referencia = "REF003",
                        Area = "�rea C",
                        Setor = "Setor 3",
                        Descricao = "Descri��o do Ativo 3",
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
