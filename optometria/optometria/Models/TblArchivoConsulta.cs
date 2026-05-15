using System;
using System.Collections.Generic;

namespace optometria.Models;

public partial class TblArchivoConsulta
{
    public int IdArchivoConsulta { get; set; }

    public int IdConsulta { get; set; }

    public string? RutaArchivo { get; set; }

    public string? NombreOriginal { get; set; }

    public string? TipoArchivo { get; set; }

    public DateTime? FechaSubida { get; set; }

    public virtual TblConsulta IdConsultaNavigation { get; set; } = null!;
}
