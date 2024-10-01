using Gestor_de_eventos.Abstracciones.Repositorios;
using Gestor_de_eventos.Abstracciones.Servicios;
using Gestor_de_eventos.DTO.Asistente;
using Gestor_de_eventos.Modelos;

namespace Gestor_de_eventos.Implementaciones.Servicios
{
    public class ServicioAsistente : IServicioAsistente
    {
        private readonly IRepositorioAsistente repositorioAsistente;

        public ServicioAsistente (IRepositorioAsistente RepositorioAsistente)
        {
            repositorioAsistente = RepositorioAsistente;
        }

        public AsistenteDTO Create(CrearAsistenteDTO CrearAsistente)
        {
            var Asistente = repositorioAsistente.Create(CrearAsistente);
            var AsistenteDTO = new AsistenteDTO
            {
                Id = Asistente.Id,
                Nombre = Asistente.Nombre,
                Apellido = Asistente.Apellido,
                Telefono = Asistente.Telefono,
                Correo = Asistente.Correo,
            };
            return AsistenteDTO;
        }

        public AsistenteDTO Update(int id,ActualizarAsistenteDTO actualizarAsistente)
        {
            var asistente = repositorioAsistente.Update(id,actualizarAsistente);
            var AsistenteDTO = new AsistenteDTO
            {
                Id = asistente.Id,
                Nombre = asistente.Nombre,
                Apellido = asistente.Apellido,
                Telefono = asistente.Telefono,
                Correo = asistente.Correo,

            };
            return AsistenteDTO;
        }

        public void Delete(int id)
        {
            repositorioAsistente.Delete(id);
        }

        public Asistente GetById(int id)
        {
            return repositorioAsistente.GetById(id);
        }

        public List<AsistenteDTO> Get()
        {
            var asistentes = repositorioAsistente.Get();
            var AsistenteDTO = new List<AsistenteDTO>();

            foreach (Asistente asistente in asistentes)
            {
                var result = new AsistenteDTO
                {
                    Id = asistente.Id,
                    Nombre = asistente.Nombre,
                    Apellido = asistente.Apellido,
                    Telefono = asistente.Telefono,
                    Correo = asistente.Correo,
                };
                AsistenteDTO.Add(result);
            }
            return AsistenteDTO;
        }

    }
}
