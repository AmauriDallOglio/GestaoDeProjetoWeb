namespace GestaoDeProjetoWeb.Data
{
    public class ProjetoDto
    {
        public int Id { get; set; }
        public string NomeProjeto { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public int Status { get; set; }
    }
}
