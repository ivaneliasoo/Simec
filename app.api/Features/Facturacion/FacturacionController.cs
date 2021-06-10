using app.api.Core;
using app.api.Features.Facturacion.Dtos;
using app.api.Features.Productos.Dtos;
using app.api.SharedKernel;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app.api.Features.Facturacion
{
    [Route("api/[controller]")]
    [ApiController()]
    public class FacturacionController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly GenericRepository<Factura, int> _repository;

        private readonly MapperConfiguration _config = new MapperConfiguration(cfg => cfg.CreateMap<Factura, FacturaDto>().ReverseMap());

        public FacturacionController(IMediator mediator, IMapper mapper, GenericRepository<Factura, int> repository)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpPost("facturas")]
        public async Task<IActionResult> CreateFactura([FromBody] FacturaDto factura)
        {
            var detalle = _mapper.Map<IEnumerable<DetalleDto>, IEnumerable<Detalle>>(factura.Detalle);
            var result = await _mediator.Send(new GenerarFacturaCommand(factura.IdentificadorCliente, factura.Fecha, factura.Total, detalle));
            
            if (result != null)
            {
                return Conflict();
            }

            return CreatedAtAction(nameof(CreateFactura), _repository.GetByIdAsync(result.IdFactura));
        }

        [HttpGet("facturas")]
        public async Task<IActionResult> GetAllFacturas()
        {
            var result = await _repository.GetAll().ProjectTo<FacturaDto>(_config).ToListAsync();
            if (result != null)
            {
                return NoContent();
            }

            return Ok(result);
        }

        [HttpGet("facturas/{idFactura:int}")]
        public async Task<IActionResult> Getfactura(int idFactura)
        {
            var result = await _repository.GetByIdAsync(idFactura);
            if (result != null)
            {
                return NoContent();
            }

            var factura = _mapper.Map<Factura, FacturaDto>(result);
            return Ok(factura);
        }
    }
}
