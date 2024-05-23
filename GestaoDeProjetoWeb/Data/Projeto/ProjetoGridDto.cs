using System.ComponentModel.DataAnnotations;

namespace GestaoDeProjetoWeb.Data.Projeto
{
    public class ProjetoGridDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [MaxLength(30, ErrorMessage = "Nome deve ter no max. 30 caracteres")]
        [MinLength(3, ErrorMessage = "Nome deve ter no min. 3 caracteres")]
        public string NomeProjeto { get; set; } = string.Empty;

        public string Descricao { get; set; }
        public DateTime DataHoraInicio { get; set; }
        public DateTime? DataHoraFim { get; set; }

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
}
