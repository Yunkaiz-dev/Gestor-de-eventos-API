using Gestor_de_eventos.Abstracciones.Servicios;
using Gestor_de_eventos.DTO.Ticket;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gestor_de_eventos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly IServicioTicket service;

        public TicketController(IServicioTicket servicio)
        {
            service = servicio;
        }
        [HttpPost]
        public IActionResult Create(CrearTicketDTO ticket)
        {
            var result = service.Create(ticket);
            return Ok(result);
        }
        [HttpGet]
        public IActionResult Index()
        {
            var result = service.Get();
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            service.Delete(id);
            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, ActualizarTicketDTO ticket)
        {
            var result = service.Update(id, ticket);
            return Ok(result);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = service.GetById(id);
            return Ok(result);
        }
    }
}
