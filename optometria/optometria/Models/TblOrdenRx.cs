using System;
using System.Collections.Generic;

namespace optometria.Models;

public partial class TblOrdenRx
{
    public int IdOrdenRx { get; set; }

    public int IdConsulta { get; set; }

    public int IdLaboratorio { get; set; }

    public int? IdRxContactologia { get; set; }

    public int? IdRxLente { get; set; }

    public string? NumeroOrden { get; set; }

    public string? TipoRx { get; set; }

    public string? Estado { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public string? Observaciones { get; set; }

    public virtual TblConsulta IdConsultaNavigation { get; set; } = null!;

    public virtual TblLaboratorio IdLaboratorioNavigation { get; set; } = null!;

    public virtual TblRxContactologia? IdRxContactologiaNavigation { get; set; }

    public virtual TblRxLente? IdRxLenteNavigation { get; set; }

    public virtual ICollection<TblComunicacion> TblComunicacions { get; set; } = new List<TblComunicacion>();

    public virtual ICollection<TblEnvioLaboratorio> TblEnvioLaboratorios { get; set; } = new List<TblEnvioLaboratorio>();
}
