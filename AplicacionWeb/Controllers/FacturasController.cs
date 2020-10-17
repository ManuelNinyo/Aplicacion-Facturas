using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using webAPI.Models;
using webAPI.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace webAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturasController : ControllerBase
    {
        readonly DataBaseService _facturaService;
        readonly SmtpService _smtpService;
        public FacturasController(DataBaseService facturaServise,SmtpService smtpService)
        {
            _smtpService = smtpService;
            _facturaService = facturaServise;
        }
        // GET: api/<FacturasController>
        [HttpGet]
        public ActionResult<IEnumerable<Factura>> Get()
        {
            return _facturaService.Get<Factura>();
        }

        // GET api/<FacturasController>/5
        [HttpGet("{id}",Name = "GetFactura")]
        public ActionResult<Factura> Get(string id)
        {
            var factura= _facturaService.Get<Factura>(id);
            if (factura == null)
                return NotFound();
            return factura;
        }

        // POST api/<FacturasController>
        [HttpPost]
        public ActionResult<Factura> create(Factura factura)
        {
            factura.IVA = factura.SubTotal * 0.16;
            factura.Retencion = factura.SubTotal * 0.01;
            factura.Total = factura.SubTotal + factura.IVA + factura.Retencion;
            factura.Fecha = DateTime.Today;
            factura.Estado = "PrimerRecordatorio";
            factura.Pagada = false;
            factura.FechaPago = "";
            _facturaService.Create(factura);
            return CreatedAtRoute("GetFactura", new { id = factura.Id.ToString() },factura);
        }

        // PUT api/<FacturasController>/5
        [HttpPut("{id}")]
        public ActionResult update(string id, Factura facturaIn)
        {
            var factura = _facturaService.Get<Factura>(id);
            if (factura == null)
            {
                return NotFound();
            }
            if (factura.Estado.Equals("PrimerRecordatorio"))
            {
                try
                {
                    this._smtpService.sendMessage(factura);
                }
                catch { }
                
                factura.Estado = "SegundoRecordatorio";
                

            }
            else if (factura.Estado.Equals("SegundoRecordatorio"))
            {
                try
                {
                    this._smtpService.sendMessage(factura);
                }
                catch { }
                factura.Estado = "desactivado";
                
            }
            _facturaService.Update(id, factura);
            return NoContent();

        }

        // DELETE api/<FacturasController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var factura = _facturaService.Get<Factura>(id);
            if (factura == null)
            {
                return NotFound();
            }
            _facturaService.Remove<Factura>(id);
            return NoContent();
        }
    }
}
