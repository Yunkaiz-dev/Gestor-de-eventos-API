using System;
using System.Collections.Generic;

namespace Gestor_de_eventos.Modelos;

public partial class Ticket
{
    public int Id { get; set; }

    public string TipoTicket { get; set; } = null!;

    public DateTime FechaTicket { get; set; }

    public decimal Precio { get; set; }

    public string? Descripcion { get; set; }

    public int? IdAsistente { get; set; }

    public int? IdEvento { get; set; }

    public virtual Asistente? IdAsistenteNavigation { get; set; }

    public virtual Evento? IdEventoNavigation { get; set; }
}
