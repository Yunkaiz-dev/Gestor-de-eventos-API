namespace Gestor_de_eventos.DTO.Ticket
{
    public class TicketDTO
    {
        public int Id { get; set; }

        public string TipoTicket { get; set; } = null!;

        public DateTime FechaTicket { get; set; }

        public decimal Precio { get; set; }

        public string? Descripcion { get; set; }

        public int? IdAsistente { get; set; }

        public int? IdEvento { get; set; }

    }
}
