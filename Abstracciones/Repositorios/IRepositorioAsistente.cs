using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Update.Internal;
using Gestor_de_eventos.DTO.Asistente;
using Gestor_de_eventos.Modelos;

namespace Gestor_de_eventos.Abstracciones.Repositorios
{
    public interface IRepositorioAsistente
    {
        List<Asistente> Get();

        Asistente GetById(int id);

        Asistente Create(CrearAsistenteDTO crearAsistenteDTO);

        Asistente Update(int id, ActualizarAsistenteDTO actualizarAsistenteDTO);

        void Delete(int id);
    }
}
