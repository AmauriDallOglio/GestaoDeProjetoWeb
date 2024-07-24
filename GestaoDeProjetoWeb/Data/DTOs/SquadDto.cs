namespace GestaoDeProjetoWeb.Data.DTOs
{
    public class SquadDto
    {
        public int Id { get; set; }
        public int Id_Empresa { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public bool Inativo { get; set; }

        public bool Selecionado { get; set; }

    }

    public class SquadExcluirRequest
    {
        public int Id { get; set; }
    }
}
