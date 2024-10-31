using Microsoft.EntityFrameworkCore;
using SerTerraQueijaria.Models;

namespace SerTerraQueijaria.Data
{
    public class SerTerraContext : DbContext
    {
        public SerTerraContext(DbContextOptions<SerTerraContext> options) : base(options) { }

        public DbSet<TiposProduto> TiposProduto { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<ItensPedido> ItensPedido { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TiposProduto>().ToTable("tbTiposProdutos");
            modelBuilder.Entity<Cliente>().ToTable("tbClientes");
            modelBuilder.Entity<Produto>().ToTable("tbProdutos");
            modelBuilder.Entity<Pedido>().ToTable("tbPedidos");
            modelBuilder.Entity<ItensPedido>().ToTable("tbItensPedido");
        }
    }
}
