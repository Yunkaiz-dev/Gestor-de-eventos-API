using Gestor_de_eventos.Abstracciones.Servicios;
using Gestor_de_eventos.DTO.Asistente;
using Microsoft.AspNetCore.Mvc;

namespace Gestor_de_eventos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsistenteController : Controller
    {
        private readonly IServicioAsistente service;

        public AsistenteController(IServicioAsistente servicio)
        {
            service = servicio;
        }
        [HttpPost]
        public IActionResult Create(CrearAsistenteDTO asistente)
        {
            var result = service.Create(asistente);
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
        public IActionResult Update(int id, ActualizarAsistenteDTO asistente)
        {
            var result = service.Update(id, asistente);
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
