using Gestor_de_eventos.Abstracciones.Servicios;
using Gestor_de_eventos.DTO.Evento;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gestor_de_eventos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventoController : ControllerBase
    {
        private readonly IServicioEvento servicio;

        public EventoController(IServicioEvento service)
        {
            servicio = service;
        }
        [HttpPost]
        public IActionResult Create(CrearEventoDTO evento)
        {
            var result = servicio.Create(evento);
            return Ok(result);
        }
        [HttpGet]
        public IActionResult Index()
        {
            var result = servicio.Get();
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            servicio.Delete(id);
            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, ActualizarEventoDTO actualizarEvento)
        {
            var result = servicio.Update(id, actualizarEvento);
            return Ok(result);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = servicio.GetById(id);
            return Ok(result);
        }
    }
}
