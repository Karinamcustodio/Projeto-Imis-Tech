using Microsoft.EntityFrameworkCore;
using PlanoBasico.Models;

namespace PlanoBasico.Data
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options) : base(options) { }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Cor> Cores { get; set; }
        public DbSet<Material> Materiais { get; set; }
        public DbSet<CorMaterial> CoresMateriais { get; set; }
        public DbSet<UnidadeMedida> UnidadesMedidas { get; set; }
        public DbSet<UnidadeMedidaMaterial> UnidadesMedidasMateriais { get; set; }
        public DbSet<Segmento> Segmentos { get; set; }
        public DbSet<Colecao> Colecoes { get; set; }
        public DbSet<Modelo> Modelos { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<CorProduto> CoresProdutos { get; set; }


    }
}
