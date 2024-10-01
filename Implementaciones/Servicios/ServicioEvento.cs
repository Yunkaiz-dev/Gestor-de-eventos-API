using Gestor_de_eventos.Abstracciones.Repositorios;
using Gestor_de_eventos.Abstracciones.Servicios;
using Gestor_de_eventos.DTO.Evento;
using Gestor_de_eventos.Modelos;
using Microsoft.EntityFrameworkCore;

namespace Gestor_de_eventos.Implementaciones.Servicios
{
    public class ServicioEvento : IServicioEvento
    {
        private readonly IRepositorioEvento repositorio;

        public ServicioEvento (IRepositorioEvento Repositorio)
        {
            repositorio =  Repositorio;
        }

        public EventoDTO Create(CrearEventoDTO crearEventoDTO)
        {
            var evento = repositorio.Create(crearEventoDTO);
            var eventoDTO = new EventoDTO
            {
                Nombre = crearEventoDTO.Nombre,
                Fecha = crearEventoDTO.Fecha,
                Ubicacion = crearEventoDTO.Ubicacion,
                Tipo = crearEventoDTO.Tipo,
                Capacidad = crearEventoDTO.Capacidad,
                Descripcion = crearEventoDTO.Descripcion,
            };
            return eventoDTO;
        }

        public void Delete(int id)
        {
            repositorio.Delete(id);
        }

        public List<EventoDTO> Get()
        {
            var eventos = repositorio.Get();
            var eventoDTO = new List<EventoDTO>();

            foreach (Evento evento in eventos)
            {
                var result = new EventoDTO
                {
                    Id = evento.Id,
                    Nombre = evento.Nombre,
                    Fecha = evento.Fecha,
                    Ubicacion = evento.Ubicacion,
                    Tipo = evento.Tipo,
                    Capacidad = evento.Capacidad,
                    Descripcion = evento.Descripcion,
                };
                eventoDTO.Add(result);
            }
            return eventoDTO;
        }

        public Evento GetById(int id)
        {
            return repositorio.GetById(id);
        }

        public EventoDTO Update(int id, ActualizarEventoDTO actualizarEventoDTO)
        {
            var evento = repositorio.Update(id, actualizarEventoDTO);
            var eventoDTO = new EventoDTO
            {
                Id = id,
                Nombre = evento.Nombre,
                Fecha = evento.Fecha,
                Ubicacion = evento.Ubicacion,
                Tipo = evento.Tipo,
                Capacidad = evento.Capacidad,
                Descripcion = evento.Descripcion,
            };
            return eventoDTO;
        }
    }
}
