using System.Text.Json.Serialization;

namespace Basico.Models
{
    public class Material
    {
        public int Id { get; set; }

        [JsonIgnore]
        public int CategoriaId { get; set; }
        public int CodigoMaterial { get; set; }
        public string DescricaoMaterial { get; set; }
        public string? Composicao { get; set; }
        public string? Largura {  get; set; }
        public string? Gramatura { get; set; }
        public double? Preco { get; set; }
        public double? PrecoMedida { get; set; }
        public string? ConversaoMedida { get; set; }
        public string? FotoMaterial { get; set; }

        public virtual Categoria Categorias { get; set; }
    }
}
