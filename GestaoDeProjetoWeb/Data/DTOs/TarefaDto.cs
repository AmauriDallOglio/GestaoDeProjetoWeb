namespace GestaoDeProjetoWeb.Data.DTOs
{
    public class TarefaDto
    {
        public int Id { get; set; }
        public int Id_Empresa { get; set; }
        public EmpresaDto Empresa { get; set; } // Relacionamento com a entidade Empresa
        public int Id_Projeto { get; set; }
        public ProjetoDto Projeto { get; set; } // Relacionamento com a entidade Projeto
        public string Descricao { get; set; }
        public string Objetivo { get; set; }
        public string Resultado { get; set; }
        public int Fase { get; set; }
        public int Ordem { get; set; }
        public int HorasEstimada { get; set; }
        public DateTime DataInicialEstimado { get; set; }
        public DateTime DataFinalEstimado { get; set; }
        public DateTime DataInicialRealizado { get; set; }
        public DateTime DataFinalRealizado { get; set; }
        public string Sprint { get; set; }
        public int Situacao { get; set; }

        public bool Selecionado { get; set; }
    }
}
