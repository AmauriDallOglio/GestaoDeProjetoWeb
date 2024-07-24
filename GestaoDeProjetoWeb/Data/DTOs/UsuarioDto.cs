namespace GestaoDeProjetoWeb.Data.DTOs
{
    public class UsuarioDto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Cargo { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public int Situacao { get; set; }

        public bool Selecionado { get; set; }
    }
}
