using app.api.SharedKernel;
using Ardalis.GuardClauses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace app.api.Core
{
    //casi siempre es útil darle una columna de autoincrementada a este tipo de tablas ayudan al performance, a conocer detalles como el orden en el que se insertan los registros que ayudan tambien con la auditoría
    public class DetalleFactura : Entity<int>
    {
        internal DetalleFactura(int idProducto, int idCliente, int idFactura, double cantidad, double precio)
        {
            Guard.Against.NegativeOrZero(idProducto, nameof(idProducto));
            Guard.Against.NegativeOrZero(idCliente, nameof(idCliente));
            Guard.Against.Negative(cantidad, nameof(cantidad));
            Guard.Against.Negative(precio, nameof(precio));


            IdProducto = idProducto;
            IdCliente = idCliente;
            IdFactura = idFactura;
            Cantidad = cantidad;
            Precio = precio;
        }

        private DetalleFactura() { } //para EF
        public int IdProducto { get; private set; }
        [ForeignKey("IdProducto")]
        public Producto Producto { get; set; }
        public int IdCliente { get; private set; }
        public int IdFactura { get; private set; }
        [ForeignKey("IdFactura")]
        public Factura Factura { get; private set; }
        public double Cantidad { get; private set; }
        public double Precio { get; private set; }

        private double? _subtotal;

        public double Subtotal
        {
            get
            {
                if(_subtotal is null)
                    return Precio * Cantidad;

                return _subtotal ?? 0;
            }
            private set { _subtotal = value; }
        }

    }
}
