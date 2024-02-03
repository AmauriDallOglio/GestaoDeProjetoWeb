namespace GestaoDeProjetoWeb.Data
{
    public class RetornoPaginadoGenerico<T>
    {
        public int ItemPorPagina { get; set; } = 30;
        public int Pagina { get; set; } = 1;
        public int TotalRegistros { get; set; } = 0;

        public ICollection<T> Modelos { get; set; }
    }
}