using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PlanoBasico.Models
{
    public class Segmento
    {
        [Key, Column("id")]
        public int Id { get; set; }
        [Column("descricaoSegmento")]
        public string DescricaoSegmento { get; set; }
    }
}
