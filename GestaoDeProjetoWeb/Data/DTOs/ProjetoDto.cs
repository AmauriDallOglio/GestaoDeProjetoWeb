using System.ComponentModel.DataAnnotations;

namespace GestaoDeProjetoWeb.Data.DTOs
{
    public class ProjetoDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do projeto é obrigatório!")]
        [MinLength(3, ErrorMessage = "Nome deve ter no mínimo 3 caracteres!")]
        [MaxLength(30, ErrorMessage = "Nome deve ter no máximo 30 caracteres!")]
        public string NomeProjeto { get; set; } = string.Empty;

        [Required(ErrorMessage = "A descrição do projeto é obrigatória!")]
        [MinLength(3, ErrorMessage = "Descrição deve ter no mínimo 3 caracteres!")]
        [MaxLength(30, ErrorMessage = "Descrição deve ter no máximo 30 caracteres!")]
        public string Descricao { get; set; } = string.Empty;

        [Required(ErrorMessage = "A data inicial do projeto é obrigatória!")]
        public DateTime DataHoraInicio { get; set; } = DateTime.Now;

        public DateTime? DataHoraFim { get; set; }


        private short situacao;

        [Required(ErrorMessage = "Situação é obrigatória!")]
        public short Situacao
        {
            get { return situacao; }
            set
            {
                situacao = value;
                SituacaoDescricao = GetSituacaoDescricao(value);
            }
        }

        public string SituacaoDescricao { get; private set; } = string.Empty;


        public bool Selecionado { get; set; }

        private string GetSituacaoDescricao(short situacao)
        {
            if (Enum.IsDefined(typeof(SituacaoProjeto), situacao))
            {
                return ((SituacaoProjeto)situacao).ToString();
            }
            else
            {
                return "Situação Desconhecida";
            }
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
