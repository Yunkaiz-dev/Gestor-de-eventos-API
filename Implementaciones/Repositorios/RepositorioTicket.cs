using Gestor_de_eventos.Abstracciones.Repositorios;
using Gestor_de_eventos.DTO.Ticket;
using Gestor_de_eventos.Modelos;

namespace Gestor_de_eventos.Implementaciones.Repositorios
{
    public class RepositorioTicket : IRepositorioTicket
    {
        private readonly GestorEventosContext _context;

        public RepositorioTicket(GestorEventosContext context)
        {
            _context = context;
        }

        public List<Ticket> Get()
        {
            return [.. _context.Tickets];
        }

        public Ticket GetById(int id)
        {
            return _context.Tickets.Where(p => p.Id == id).FirstOrDefault();
        }

        public Ticket Create(CrearTicketDTO crearTicketDTO)
        {
            var resultado = new Ticket
            {
                TipoTicket = crearTicketDTO.TipoTicket,
                FechaTicket = (DateTime)crearTicketDTO.FechaTicket,
                Precio = crearTicketDTO.Precio,
                Descripcion = crearTicketDTO.Descripcion,
                IdAsistente = crearTicketDTO.IdAsistente,
                IdEvento = crearTicketDTO.IdEvento,
            };
            _context.Tickets.Add(resultado);
            _context.SaveChanges();
            return resultado;
        }

        public Ticket Update(int id, ActualizarTicketDTO actualizarTicketDTO)
        {
            var ticket_Exist = GetById(id);

            ticket_Exist.TipoTicket = actualizarTicketDTO.TipoTicket ?? ticket_Exist.TipoTicket;
            ticket_Exist.FechaTicket = actualizarTicketDTO.FechaTicket ?? ticket_Exist.FechaTicket;
            ticket_Exist.Precio = actualizarTicketDTO.Precio ?? ticket_Exist.Precio;
            ticket_Exist.Descripcion = actualizarTicketDTO.Descripcion ?? ticket_Exist.Descripcion;
            ticket_Exist.IdAsistente = actualizarTicketDTO.IdAsistente ?? ticket_Exist.IdAsistente;
            ticket_Exist.IdEvento = actualizarTicketDTO.IdEvento ?? ticket_Exist.IdEvento;

            _context.Update(ticket_Exist);
            _context.SaveChanges();

            var ticket_actualizado = GetById(id);
            return ticket_actualizado;
        }

        public void Delete(int id)
        {
            Ticket ticket = GetById(id);
            _context.Remove(ticket);
            _context.SaveChanges();
        }
    }
}
