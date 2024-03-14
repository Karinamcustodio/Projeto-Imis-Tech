using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PlanoBasico.Models
{
    public class Produto
    {
        [Key, Column("id")]
        public int Id { get; set; }
        [Column("marca")]
        public string Marca { get; set; }
        [JsonIgnore, Column("segmentoId")]
        public int SegmentoId { get; set; }
        [JsonIgnore, Column("modeloId")]
        public int ModeloId { get; set; }
        [JsonIgnore, Column("colecaoId")]
        public int ColecaoId { get; set; }
        [Column("codigoProduto")]
        public int? CodigoProduto { get; private set; }
        [Column("descricaoProduto")]
        public string DescricaoProduto { get; set; }
        [JsonIgnore, Column("unidadeMedidaId")]
        public int? UnidadeMedidaId { get; set; }
        [Column("custoProduto")]
        public double? CustoProduto { get; set;}
        [Column("precoVenda")]
        public double? PrecoVenda { get; set; }
        [Column("tamanhos")]
        public string? Tamanhos { get; set; }
        [Column("fotoProduto")]
        public string? FotoProduto { get; set; }

        public virtual Segmento Segmentos { get; set; }
        public virtual Modelo Modelos { get; set; }
        public virtual Colecao Colecoes { get; set; }
        public virtual UnidadeMedida UnidadesMedidas { get; set; }

        public void SetCodigoProdutol(int marcaId, int modeloId, int sequencia)
        {
            string marcaString = marcaId.ToString().PadLeft(2, '0');
            string modeloString = modeloId.ToString().PadLeft(2, '0');
            string sequenciaString = sequencia.ToString().PadLeft(4, '0');
            CodigoProduto = int.Parse($"{marcaString}{modeloString}{sequenciaString}");
        }
    }
}
