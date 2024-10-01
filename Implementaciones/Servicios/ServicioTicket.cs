using Gestor_de_eventos.Abstracciones.Repositorios;
using Gestor_de_eventos.Abstracciones.Servicios;
using Gestor_de_eventos.DTO.Evento;
using Gestor_de_eventos.DTO.Ticket;
using Gestor_de_eventos.Modelos;

namespace Gestor_de_eventos.Implementaciones.Servicios
{
    public class ServicioTicket : IServicioTicket
    {
        private readonly IRepositorioTicket repositorio;

        public ServicioTicket(IRepositorioTicket Repositorio)
        {
            repositorio = Repositorio;
        }

        public TicketDTO Create(CrearTicketDTO crearTicketDTO)
        {
            var ticket = repositorio.Create(crearTicketDTO);
            var ticketDTO = new TicketDTO
            {
                Id = ticket.Id,
                TipoTicket = ticket.TipoTicket,
                FechaTicket = ticket.FechaTicket,
                Precio = ticket.Precio,
                Descripcion = ticket.Descripcion,
                IdAsistente = ticket.IdAsistente,
                IdEvento = ticket.IdEvento,
            };
            return ticketDTO;
        }

        public void Delete(int id)
        {
            repositorio.Delete(id);
        }

        public List<TicketDTO> Get()
        {
            var tickets = repositorio.Get();
            var ticketDTO = new List<TicketDTO>();
            
            foreach (Ticket ticket in tickets)
            {
                var result = new TicketDTO
                {
                    Id = ticket.Id,
                    TipoTicket = ticket.TipoTicket,
                    FechaTicket = ticket.FechaTicket,
                    Precio = ticket.Precio,
                    Descripcion = ticket.Descripcion,
                    IdAsistente = ticket.IdAsistente,
                    IdEvento = ticket.IdEvento,
                };
                ticketDTO.Add(result);
            }
            return ticketDTO;
        }

        public Ticket GetById(int id)
        {
            return repositorio.GetById(id);
        }

        public TicketDTO Update(int id, ActualizarTicketDTO actualizarTicketDTO)
        {
            var ticket = repositorio.Update(id, actualizarTicketDTO);
            var ticketDTO = new TicketDTO
            {
                Id = id,
                FechaTicket = ticket.FechaTicket,
                TipoTicket = ticket.TipoTicket,
                Precio = ticket.Precio,
                Descripcion = ticket.Descripcion,
                IdAsistente = ticket.IdAsistente,
                IdEvento = ticket.IdEvento,
            };
            return ticketDTO;
        }
    }
}
