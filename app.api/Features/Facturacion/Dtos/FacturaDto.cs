using System;
using System.Collections.Generic;

namespace app.api.Features.Productos.Dtos
{
    public class FacturaDto
    {
        public string Id { get; set; }
        public string IdentificadorCliente { get; set; }
        public DateTime Fecha { get; set; }

        public double Total { get; set; }
        
        public virtual IEnumerable<DetalleDto> Detalle { get; set; }
    }
}
