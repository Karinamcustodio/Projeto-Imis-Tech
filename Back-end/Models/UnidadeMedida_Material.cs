namespace Basico.Models
{
    public class UnidadeMedida_Material
    {
        public int Id { get; set; }
        public int UnidadeMedidaId { get; set; }
        public int MaterialId { get; set; }

        public virtual UnidadeMedida UnidadesMedida { get; set; }
        public virtual Material Materiais { get; set; }
    }
}
