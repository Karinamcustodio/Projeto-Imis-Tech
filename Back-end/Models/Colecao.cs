using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PlanoBasico.Models
{
    public class Colecao
    {
        [Key, Column("id")]
        public int Id { get; set; }
        [Column("descricaoColecao")]
        public string DescricaoColecao { get; set; }
    }
}
