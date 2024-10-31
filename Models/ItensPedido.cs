namespace SerTerraQueijaria.Models
{
    public class ItensPedido
    {
        public Guid ItensPedidoId { get; set; }
        public Guid PedidoId { get; set; }
        public Pedido? Pedido { get; set; }
        public Guid ProdutoId { get; set; }
        public Produto? Produto { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorUnitario { get; set; }
    }
}
