namespace SerTerraQueijaria.Models
{
    public class ItensPedido
    {
        public Guid ItemPedidoId { get; set; }
        public Guid PedidoId { get; set; }
        public Guid ProdutoId { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorUnitario { get; set; }
    }
}
