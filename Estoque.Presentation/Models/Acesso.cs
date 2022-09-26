namespace Estoque.Presentation.Models
{
    public class Acesso
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public DateTime Hora { get; set; }
        public DateTime Final { get; set; }

        public Usuario Usuario { get; set; }
    }
}
