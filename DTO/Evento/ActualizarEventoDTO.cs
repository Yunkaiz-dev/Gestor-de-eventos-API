namespace Gestor_de_eventos.DTO.Evento
{
    public class ActualizarEventoDTO
    {
        public string Nombre { get; set; } = null!;

        public DateTime Fecha { get; set; }

        public string Ubicacion { get; set; } = null!;

        public string Tipo { get; set; } = null!;

        public decimal Capacidad { get; set; }

        public string? Descripcion { get; set; }
    }
}
