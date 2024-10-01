using Gestor_de_eventos.DTO.Asistente;
using Gestor_de_eventos.Modelos;
using Gestor_de_eventos.Abstracciones.Repositorios;

namespace Gestor_de_eventos.Implementaciones.Repositorios
{
    public class RepositorioAsistente : IRepositorioAsistente
    {
        private readonly GestorEventosContext _context;

        public RepositorioAsistente(GestorEventosContext context)
        {
            _context = context;
        }   

        public Asistente Create(CrearAsistenteDTO crearAsistenteDTO)
        {
            var resultado = new Asistente()
            {
                Nombre = crearAsistenteDTO.Nombre,
                Apellido = crearAsistenteDTO.Apellido,
                Telefono = crearAsistenteDTO.Telefono,
                Correo = crearAsistenteDTO.Correo,
            };
            _context.Asistentes.Add(resultado);
            _context.SaveChanges();
            return resultado;
        }

        public void Delete(int id)
        {
            Asistente asistente = GetById(id);
            _context.Remove(asistente);
            _context.SaveChanges();
        }

        public List<Asistente> Get()
        {
            return [.. _context.Asistentes];
        }

        public Asistente GetById(int id)
        {
            return _context.Asistentes.Where(p => p.Id == id).FirstOrDefault();
        }

        Asistente IRepositorioAsistente.Update(int id, ActualizarAsistenteDTO actualizarAsistenteDTO)
        {
            var Asistente_exist = GetById(id);
            
            Asistente_exist.Nombre = actualizarAsistenteDTO.Nombre ?? Asistente_exist.Nombre;
            Asistente_exist.Apellido = actualizarAsistenteDTO.Apellido ?? Asistente_exist.Apellido;
            Asistente_exist.Telefono = actualizarAsistenteDTO.Telefono ?? Asistente_exist.Telefono;
            Asistente_exist.Correo = actualizarAsistenteDTO.Correo ?? Asistente_exist.Correo;

            _context.Update(Asistente_exist);
            _context.SaveChanges();

            var Asistente_actualizado = GetById(id);
            return Asistente_actualizado;
        }
    }
}
