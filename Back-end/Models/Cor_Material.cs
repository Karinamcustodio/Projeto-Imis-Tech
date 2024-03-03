namespace Basico.Models
{
    public class Cor_Material
    {
        public int Id { get; set; }
        public int CorId { get; set; }
        public int MaterialId { get; set; }

        public virtual Cor Cores { get; set; }
        public virtual Material Materiais { get; set; }
    }
}
