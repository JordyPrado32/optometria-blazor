using System;
using System.Collections.Generic;

namespace optometria.Models;

public partial class TblEnvioLaboratorio
{
    public int IdEnvioLaboratorio { get; set; }

    public int IdOrdenRx { get; set; }

    public int IdUsuario { get; set; }

    public string? Canal { get; set; }

    public string? Estado { get; set; }

    public DateTime? FechaEnvio { get; set; }

    public DateTime? FechaCambioEstado { get; set; }

    public int? IdUsuarioEntrega { get; set; }

    public virtual TblOrdenRx IdOrdenRxNavigation { get; set; } = null!;

    public virtual TblUsuario? IdUsuarioEntregaNavigation { get; set; }

    public virtual TblUsuario IdUsuarioNavigation { get; set; } = null!;
}
