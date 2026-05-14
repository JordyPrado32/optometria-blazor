using System;
using System.Collections.Generic;

namespace optometria.Models;

public partial class TblLaboratorio
{
    public int IdLaboratorio { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Correo { get; set; }

    public string? Whatsapp { get; set; }

    public string? PersonaContacto { get; set; }

    public string? Direccion { get; set; }

    public bool? Activo { get; set; }

    public virtual ICollection<TblOrdenRx> TblOrdenRxes { get; set; } = new List<TblOrdenRx>();
}
