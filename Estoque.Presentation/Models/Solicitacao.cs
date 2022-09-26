namespace Estoque.Presentation.Models
{
    public class Solicitacao
    {
        public int IdSolicitacao { get; set; }
        public string NomeEquipamento { get; set; }
        public int QtdSolicitada { get; set; }
        public string NomeSolicitante { get; set; }
    }
}
