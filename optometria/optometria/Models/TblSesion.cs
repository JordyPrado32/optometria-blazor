using System;
using System.Collections.Generic;

namespace optometria.Models;

public partial class TblSesion
{
    public int IdSesion { get; set; }

    public int IdUsuario { get; set; }

    public DateTime? FechaInicio { get; set; }

    public DateTime? FechaFin { get; set; }

    public string? Ip { get; set; }

    public virtual TblUsuario IdUsuarioNavigation { get; set; } = null!;
}
