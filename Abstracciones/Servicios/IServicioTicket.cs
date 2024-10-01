using Gestor_de_eventos.DTO.Asistente;
using Gestor_de_eventos.DTO.Ticket;
using Gestor_de_eventos.Modelos;

namespace Gestor_de_eventos.Abstracciones.Servicios
{
    public interface IServicioTicket
    {
        List<TicketDTO> Get();

        Ticket GetById(int id);

        TicketDTO Create(CrearTicketDTO crearTicketDTO);

        TicketDTO Update(int id, ActualizarTicketDTO actualizarTicketDTO);

        void Delete(int id);
    }
}
