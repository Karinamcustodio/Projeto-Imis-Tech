using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PlanoBasico.Models
{
    public class CorProduto
    {
        [Key, Column("id")]
        public int Id { get; set; }
        [JsonIgnore, Column("corId")]
        public int CorId { get; set; }
        [JsonIgnore, Column("produtoId")]
        public int ProdutoId { get; set; }

        public virtual Cor Cores { get; set; }
        public virtual Produto Produtos { get; set; }
    }
}
