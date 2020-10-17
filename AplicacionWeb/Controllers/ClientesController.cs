using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webAPI.Models;
using webAPI.Services;

namespace webAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        readonly DataBaseService _clienteService;
        public ClientesController(DataBaseService clienteServise)
        {
            _clienteService = clienteServise;
        }
        // GET: api/<ClienteController>
        [HttpGet]
        public ActionResult<IEnumerable<Cliente>> Get()
        {
            return _clienteService.Get<Cliente>();
        }

        // GET api/<clientesController>/5
        [HttpGet("{id}", Name = "GetCliente")]
        public ActionResult<Cliente> Get(string id)
        {
            var cliente = _clienteService.Get<Cliente>(id);
            if (cliente == null)
                return NotFound();
            return cliente;
        }

        // POST api/<ClientesController>
        [HttpPost]
        public ActionResult<Cliente> create(Cliente cliente)
        {
            _clienteService.Create(cliente);
            return CreatedAtRoute("GetCliente", new { id = cliente.Id.ToString() }, cliente);
        }

        // PUT api/<clientesController>/5
        [HttpPut("{id}")]
        public ActionResult update(string id, Cliente clienteIn)
        {
            var cliente = _clienteService.Get<Cliente>(id);
            if (cliente == null)
            {
                return NotFound();
            }
            _clienteService.Update(id, clienteIn);
            return NoContent();

        }

        // DELETE api/<ClientesController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var cliente = _clienteService.Get<Cliente>(id);
            if (cliente == null)
            {
                return NotFound();
            }
            _clienteService.Remove<Cliente>(id);
            return NoContent();
        }
    }
}
