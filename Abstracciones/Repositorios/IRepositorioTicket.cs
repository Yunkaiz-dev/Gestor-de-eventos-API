using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Update.Internal;
using Gestor_de_eventos.DTO.Ticket;
using Gestor_de_eventos.Modelos;

namespace Gestor_de_eventos.Abstracciones.Repositorios
{
    public interface IRepositorioTicket
    {
        List<TicketDTO> Get();

        Ticket GetById(int id);

        TicketDTO Create(CrearTicketDTO crearTicketDTO);

        TicketDTO Update(int id, ActualizarTicketDTO actualizarTicketDTO);

        void Delete(int id);
    }
}
