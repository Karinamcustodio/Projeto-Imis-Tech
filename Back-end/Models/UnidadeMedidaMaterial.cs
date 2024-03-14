using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PlanoBasico.Models
{
    public class UnidadeMedidaMaterial
    {
        [Key, Column("id")]
        public int Id { get; set; }
        [JsonIgnore, Column("unidadeMedidaId")]
        public int UnidadeMedidaId { get; set; }
        [JsonIgnore, Column("materialId")]
        public int MaterialId { get; set; }

        public virtual UnidadeMedida UnidadesMedidas { get; set; }
        public virtual Material Materiais { get; set; }
    }
}
