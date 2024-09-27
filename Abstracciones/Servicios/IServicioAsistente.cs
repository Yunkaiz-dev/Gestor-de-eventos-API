using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Gestor_de_eventos.DTO.Asistente;
using Gestor_de_eventos.Modelos;

namespace Gestor_de_eventos.Abstracciones.Servicios
{
    public class IServicioAsistente
    {
        List<AsistenteDTO> Get();

        Asistente GetById(int id);

        AsistenteDTO Create(CrearAsistenteDTO crearAsistenteDTO);

        AsistenteDTO Update(int id, ActualizarAsistenteDTO actualizarAsistenteDTO);

        void Delete(int id);
    }
}
