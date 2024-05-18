namespace GestaoDeProjetoWeb.Data
{
    public class ProjetoDto
    {
        public int Id { get; set; }
        public string NomeProjeto { get; set; }
        public string Descricao { get; set; }
        public DateTime DataHoraInicio { get; set; }
        public DateTime? DataHoraFim { get; set; }
        public int Situacao { get; set; }
        public bool Selecionado { get; set; }
    }
}
