using app.api.Features.Facturacion.Dtos;
using MediatR;
using System;
using System.Collections.Generic;

namespace app.api.Features.Productos.Dtos
{
    public class GenerarFacturaCommand : IRequest<GenerarFacturaResult>
    {
        public GenerarFacturaCommand(string identificadorCliente, DateTime fecha, double total, IEnumerable<Detalle> detalle)
        {
            IdentificadorCliente = identificadorCliente;
            Fecha = fecha;
            Total = total;
            Detalle = detalle;
        }

        public string Id { get; }
        public string IdentificadorCliente { get; }
        public DateTime Fecha { get; }

        public double Total { get; }
        
        public  IEnumerable<Detalle> Detalle { get; }
    }

    public class Detalle
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
