using Basico.Models;
using Microsoft.EntityFrameworkCore;

namespace Basico.Data
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options) : base(options) { }

        public DbSet<Material> Material { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<UnidadeMedida> UnidadeMedida { get; set; }
        public DbSet<Cor> Cor { get; set; }
        public DbSet<Cor_Material> Cor_Material { get; set; }
        public DbSet<UnidadeMedida_Material> UnidadeMedida_Material { get; set; }
    }
}