using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PlanoBasico.Models
{
    public class CorMaterial
    {
        [Key, Column("id")]
        public int Id { get; set; }
        [JsonIgnore, Column("corId")]
        public int CorId { get; set; }
        [JsonIgnore, Column("materialId")]
        public int MaterialId { get; set; }

        public virtual Cor Cores { get; set; }
        public virtual Material Materiais { get; set; }
    }
}
