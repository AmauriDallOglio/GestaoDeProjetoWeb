namespace GestaoDeProjetoWeb.Data
{
    public class ProjetoDto
    {
        public int Id { get; set; }
        public string NomeProjeto { get; set; }
        public string Descricao { get; set; }
        public DateTime DataHoraInicio { get; set; }
        public DateTime? DataHoraFim { get; set; }
        //public short Situacao { get; set; }

        //public string SituacaoDescricao => Situacao.ToString();

        // Propriedade Situacao com getter customizado
        private short situacao;
        public short Situacao
        {
            get { return situacao; }
            set
            {
                situacao = value;
                SituacaoDescricao = GetSituacaoDescricao(value);
            }
        }

        public string SituacaoDescricao { get; private set; }


        public bool Selecionado { get; set; }

        private string GetSituacaoDescricao(short situacao)
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


    }



    public enum SituacaoProjeto : short
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
