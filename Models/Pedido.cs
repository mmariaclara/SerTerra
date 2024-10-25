namespace SerTerraQueijaria.Models
{
    public class Pedido
    {
        public Guid PedidoId { get; set; }
        public DateTime DataHora { get; set; }
        public Guid ClienteId { get; set; }
        public decimal ValorDesconto { get; set; }
    }
}
