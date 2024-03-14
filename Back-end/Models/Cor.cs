using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PlanoBasico.Models
{
    public class Cor
    {
        [Key, Column("id")]
        public int Id { get; set; }
        [Column("codigoCor")]
        public string? CodigoCor { get; set; }
        [Column("nomeCor")]
        public string NomeCor { get; set; }
        [Column("corReferencia")]
        public string? CorReferencia { get; set; }
    }
}
