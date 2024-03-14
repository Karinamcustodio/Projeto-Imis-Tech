using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PlanoBasico.Models
{
    public class Modelo
    {
        [Key, Column("id")]
        public int Id { get; set; }
        [Column("nomeModelo")]
        public string NomeModelo { get; set; }
    }
}
