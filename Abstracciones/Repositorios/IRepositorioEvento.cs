using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Update.Internal;
using Gestor_de_eventos.DTO.Evento;
using Gestor_de_eventos.Modelos;

namespace Gestor_de_eventos.Abstracciones.Repositorios
{
    public interface IRepositorioEvento
    {
        List<Evento> Get();

        Evento GetById(int id);

        Evento Create(CrearEventoDTO crearEventoDTO);

        Evento Update(int id, ActualizarEventoDTO actualizarEventoDTO);

        void Delete(int id);
    }
}
