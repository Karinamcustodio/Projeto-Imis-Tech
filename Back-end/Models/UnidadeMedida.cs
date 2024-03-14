using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PlanoBasico.Models
{
    public class UnidadeMedida
    {
        [Key, Column("id")]
        public int Id { get; set; }
        [Column("abreviacaoMedida")]
        public string AbreviacaoMedida { get; set; }
        [Column("descricaoMedida")]
        public string DescricaoMedida { get; set; }
    }
}
