using app.api.Core;
using app.api.Features.Facturacion.Dtos;
using app.api.Features.Productos.Dtos;
using app.api.SharedKernel;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace app.api.Features.Facturacion.Handlers
{
    public class GenerarFacturaCommandHandler : IRequestHandler<GenerarFacturaCommand, GenerarFacturaResult>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Factura, int> _repository;

        public GenerarFacturaCommandHandler(IMapper mapper, IGenericRepository<Factura, int> repository)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        public async Task<GenerarFacturaResult> Handle(GenerarFacturaCommand request, CancellationToken cancellationToken)
        {
            var detalle = _mapper.Map<IEnumerable<Detalle>, IEnumerable<DetalleFactura>>(request.Detalle);
            var factura = new Factura(request.IdentificadorCliente, request.Fecha, detalle);

            if (factura.Total == 0)
                throw new Exception("No se Pueden Emitir Facturas con Total en Cero (0)");

            try
            {
                await _repository.AddAsync(factura);
            }
            catch (DbException ex)
            {
                throw new Exception("Error Intentado Generar la Factura", ex);
            }

            return new GenerarFacturaResult();
        }
    }
}
