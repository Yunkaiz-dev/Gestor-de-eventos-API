using System;
using System.Collections.Generic;

namespace Gestor_de_eventos.Modelos;

public partial class Asistente
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
