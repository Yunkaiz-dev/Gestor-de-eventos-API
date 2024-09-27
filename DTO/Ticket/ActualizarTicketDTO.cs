namespace Gestor_de_eventos.DTO.Ticket
{
    public class ActualizarTicketDTO
    {
        public string TipoTicket { get; set; } = null!;

        public DateTime FechaTicket { get; set; }

        public decimal Precio { get; set; }

        public string? Descripcion { get; set; }

        public int? IdAsistente { get; set; }

        public int? IdEvento { get; set; }
    }
}
