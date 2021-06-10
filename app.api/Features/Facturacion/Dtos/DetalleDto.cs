namespace app.api.Features.Productos.Dtos
{
    public class DetalleDto
    {
        public string Id { get; set; }
        public int IdProducto { get; set; }
        public string ProductoDescripcion { get; set; }
        public int IdCliente { get; set; }
        public int IdFactura { get; set; }
        public double Cantidad { get; set; }
        public double Precio { get; set; }

        public double Subtotal { get; set; }
    }
}
