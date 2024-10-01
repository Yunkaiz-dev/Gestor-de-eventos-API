using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Update.Internal;
using Gestor_de_eventos.DTO.Ticket;
using Gestor_de_eventos.Modelos;

namespace Gestor_de_eventos.Abstracciones.Repositorios
{
    public interface IRepositorioTicket
    {
        List<Ticket> Get();

        Ticket GetById(int id);

        Ticket Create(CrearTicketDTO crearTicketDTO);

        Ticket Update(int id, ActualizarTicketDTO actualizarTicketDTO);

        void Delete(int id);
    }
}
