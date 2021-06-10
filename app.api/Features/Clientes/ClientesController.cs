using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using app.api.Core;
using app.api.Infrastructure.Data;
using app.api.Features.Productos.Services;
using app.api.Features.Productos.Dtos;

namespace app.api.Features.Clientes
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly ClientesService _clientesService;

        public ClientesController(ClientesService clientesService)
        {
            _clientesService = clientesService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClienteDto>>> GetClientes()
        {
            return Ok(await _clientesService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClienteDto>> GetCliente(string id)
        {
            var cliente = await _clientesService.Get(id);

            if (cliente == null)
            {
                return NotFound();
            }

            return cliente;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCliente(string id, ClienteDto cliente)
        {
            if (id != cliente.Id)
            {
                return BadRequest();
            }

            try
            {
                await _clientesService.Update(cliente);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await ClienteExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<ClienteDto>> PostCliente([FromBody]ClienteDto cliente)
        {
            try
            {
                await _clientesService.Add(cliente);
            }
            catch (DbUpdateException)
            {
                if (await ClienteExists(cliente.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCliente", new { id = cliente.Id }, cliente);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(string id)
        {
            var cliente = await ClienteExists(id);
            if (!cliente)
            {
                return NotFound();
            }

            await _clientesService.Delete(id);
            

            return NoContent();
        }

        private async ValueTask<bool> ClienteExists(string id)
        {
            return (await _clientesService.Get(id)) != null;
        }
    }
}
