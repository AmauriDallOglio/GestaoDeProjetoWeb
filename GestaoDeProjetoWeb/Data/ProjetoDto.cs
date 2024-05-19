namespace GestaoDeProjetoWeb.Data
{
    public class ProjetoDto
    {
        public int Id { get; set; }
        public string NomeProjeto { get; set; }
        public string Descricao { get; set; }
        public DateTime DataHoraInicio { get; set; }
        public DateTime? DataHoraFim { get; set; }
        public SituacaoProjeto Situacao { get; set; }
        public string SituacaoDescricao => Situacao.ToString();
        public bool Selecionado { get; set; }
    }

    public enum SituacaoProjeto : byte
    {
        Planejado = 1,
        EmAndamento = 2,
        Atrasado = 3,
        EmRevisao = 4,
        EmEspera = 5,
        EmAndamentoBaixaPrioridade = 6,
        EmAndamentoMediaPrioridade = 7,
        EmAndamentoAltaPrioridade = 8,
        EmTeste = 9,
        PendenteAprovacao = 10,
        PendenteRecursos = 11,
        AguardandoFeedbackCliente = 12,
        AguardandoAprovacaoInterna = 13,
        Cancelado = 14,
        Concluido = 15
    }

}
