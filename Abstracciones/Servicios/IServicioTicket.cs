using Gestor_de_eventos.DTO.Asistente;
using Gestor_de_eventos.DTO.Ticket;
using Gestor_de_eventos.Modelos;

namespace Gestor_de_eventos.Abstracciones.Servicios
{
    public class IServicioTicket
    {
        List<AsistenteDTO> Get();

        Asistente GetById(int id);

        AsistenteDTO Create(CrearAsistenteDTO crearAsistenteDTO);

        AsistenteDTO Update(int id, ActualizarAsistenteDTO actualizarAsistenteDTO);

        void Delete(int id);
    }
}
