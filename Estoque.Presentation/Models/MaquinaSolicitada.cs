namespace Estoque.Presentation.Models
{
    public class MaquinaSolicitada
    {
        public int Id { get; set; }
        public int QtdSolicitada { get; set; }
        public int SolicitanteId { get; set; }
        public int EquipamentoId { get; set; }

        public Equipamento Equipamento { get; set; }
        public Solicitante Solicitante { get; set; }
    }
}
