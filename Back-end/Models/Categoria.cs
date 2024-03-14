using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlanoBasico.Models
{
    public class Categoria
    {
        [Key, Column("id")]
        public int Id { get; set; }
        [Column("descricaoCategoria")]
        public string DescricaoCategoria { get; set; }
    }
}