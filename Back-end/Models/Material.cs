using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PlanoBasico.Models
{
    public class Material
    {
        [Key, Column("id")]
        public int Id { get; set; }
        [JsonIgnore, Column("categoriaId")]
        public int CategoriaId { get; set; }
        [Column("codigoMaterial")]
        public int CodigoMaterial { get; private set; }
        [Column("descricaoMaterial")]
        public string DescricaoMaterial { get; set; }
        [Column("composicao")]
        public string? Composicao { get; set; }
        [Column("largura")]
        public string? Largura { get; set; }
        [Column("gramatura")]
        public string? Gramatura { get; set; }
        [Column("precoMaterial")]
        public double? PrecoMaterial { get; set; }
        [Column("precoMedida")]
        public double? PrecoMedida { get; set; }
        [Column("conversaoMedida")]
        public double? ConversaoMedida { get; set; }
        [Column("fotoMaterial")]
        public string? FotoMaterial { get; set; }

        public virtual Categoria Categorias { get; set; }

        public void SetCodigoMaterial(int categoriaId, int sequencia)
        {
            string categoriaString = categoriaId.ToString().PadLeft(2, '0');
            string sequenciaString = sequencia.ToString().PadLeft(4, '0');
            CodigoMaterial = int.Parse($"{categoriaString}{sequenciaString}");
        }
    }
}