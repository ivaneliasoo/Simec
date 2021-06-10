using app.api.SharedKernel;
using Ardalis.GuardClauses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace app.api.Core
{
    public class Factura : Entity<int>, IAggregateRoot
    {
        public Factura(string identificadorCliente, DateTime fecha, IEnumerable<DetalleFactura> detalle = null)
        {
            Guard.Against.NullOrWhiteSpace(identificadorCliente, nameof(identificadorCliente));
            Guard.Against.Null(fecha, nameof(fecha));

            IdentificadorCliente = identificadorCliente;
            Fecha = fecha;

            if (detalle != null)
                _detalle.AddRange(detalle);
        }

        private Factura() { } //para EF

        public string IdentificadorCliente { get; private set; }
        public DateTime Fecha { get; private set; }

        private double? _total;
        public double Total
        {
            get
            {
                if (_total is null)
                    return _detalle.Sum(d => d.Subtotal);

                return _total.Value;
            }
            private set => _total = value;

        }

        [ForeignKey("IdFactura")]
        private readonly List<DetalleFactura> _detalle = new List<DetalleFactura>();
        public virtual IReadOnlyList<DetalleFactura> Detalle => _detalle.AsReadOnly();

        public DetalleFactura CrearDetalle(int idProducto, int idCliente, int idFactura, double cantidad, double precio)
        {
            return new DetalleFactura(idProducto, idCliente, idFactura, cantidad, precio);
        }

        public void AddDetalle(DetalleFactura detalle)
        {
            _detalle.Add(detalle);
        }

        public void RemoveDetalle(int idDetalle)
        {
            var detalle = _detalle.Where(d => d.Id == idDetalle).SingleOrDefault();
            if (detalle != null)
                RemoveDetalle(detalle);
        }
        public void RemoveDetalle(DetalleFactura detalle)
        {
            _detalle.Remove(detalle);
        }
    }
}
