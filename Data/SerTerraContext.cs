using Microsoft.EntityFrameworkCore;
using SerTerraQueijaria.Models;

namespace SerTerraQueijaria.Data
{
    public class SerTerraContext : DbContext
    {
        public SerTerraContext(DbContextOptions<SerTerraContext> options) : base(options) { }

        public DbSet<TiposProdutos> TiposProd { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TiposProdutos>().ToTable("tbTiposProdutos");
            modelBuilder.Entity<Cliente>().ToTable("tbClientes");
            modelBuilder.Entity<Produto>().ToTable("tbProdutos");
        }
    }
}
