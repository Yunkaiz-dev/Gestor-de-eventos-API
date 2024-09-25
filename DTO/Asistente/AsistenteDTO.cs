using Gestor_de_eventos.Modelos;

namespace Gestor_de_eventos.DTO.Asistente
{
    public class AsistenteDTO
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = null!;

        public string Apellido { get; set; } = null!;

        public string Telefono { get; set; } = null!;

        public string Correo { get; set; } = null!;
     }
}
