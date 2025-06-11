using Gestor_de_eventos.Abstracciones.Repositorios;
using Gestor_de_eventos.DTO.Evento;
using Gestor_de_eventos.Modelos;

namespace Gestor_de_eventos.Implementaciones.Repositorios{ }
    public class RepositorioEvento : IRepositorioEvento
    {
        private readonly GestorEventosContext _context;

        public RepositorioEvento(GestorEventosContext context)
        {
            _context = context;
        }

        public List<Evento> Get()
        {
            return [.. _context.Eventos];
        }

        public Evento GetById(int id)
        {
            return _context.Eventos.Where(p => p.Id == id).FirstOrDefault();
        }

        public Evento Create(CrearEventoDTO crearEventoDTO)
        {
            var resultado = new Evento
            {
                Nombre = crearEventoDTO.Nombre,
                Fecha = (DateTime)crearEventoDTO.Fecha,
                Ubicacion = crearEventoDTO.Ubicacion,
                Tipo = crearEventoDTO.Tipo,
                Capacidad = crearEventoDTO.Capacidad,
                Descripcion = crearEventoDTO.Descripcion,
            };
            _context.Eventos.Add(resultado);
            _context.SaveChanges();
            return resultado;
        }

        public Evento Update(int id, ActualizarEventoDTO actualizarEventoDTO)
        {
            var evento_Exist = GetById(id);

            evento_Exist.Nombre = actualizarEventoDTO.Nombre ?? evento_Exist.Nombre;
            evento_Exist.Fecha = actualizarEventoDTO.Fecha ?? evento_Exist.Fecha;
            evento_Exist.Ubicacion = actualizarEventoDTO.Ubicacion ?? evento_Exist.Ubicacion;
            evento_Exist.Tipo = actualizarEventoDTO.Tipo ?? evento_Exist.Tipo;
            evento_Exist.Capacidad = actualizarEventoDTO.Capacidad ?? evento_Exist.Capacidad;
            evento_Exist.Descripcion = actualizarEventoDTO.Descripcion ?? evento_Exist.Descripcion;
            
            _context.Update(evento_Exist);
            _context.SaveChanges();

            var evento_actualizado = GetById(id);
            return evento_actualizado;
        }

        public void Delete(int id)
        {
            Evento evento = GetById(id);
            _context.Remove(evento);
            _context.SaveChanges();
        }

        
    }

