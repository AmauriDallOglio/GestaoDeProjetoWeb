namespace GestaoDeProjetoWeb.Data.DTOs
{
    public class ProjetoSquadDto
    {
        public int Id { get; set; }
        public int Id_Projeto { get; set; }

        public int Id_Squad { get; set; }

        public bool Inativo { get; set; }

        public int ComboSquad { get; set; }

        public string NomeProjeto { get; set; } = string.Empty;
        public string NomeSquad { get; set; } = string.Empty;

        public bool Selecionado { get; set; }
    }
}
