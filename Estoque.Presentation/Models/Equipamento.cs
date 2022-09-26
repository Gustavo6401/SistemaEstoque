namespace Estoque.Presentation.Models
{
    public class Equipamento
    {
        public int Id { get; set; }
        // Quantidade de Equipamentos Disponíveis
        public int QtdEstoque { get; set; }
        public string Nome { get; set; }
        public int QtdTotal { get; set; }
        public string Site { get; set; }
    }
}
