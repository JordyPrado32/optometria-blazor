using System;
using System.Collections.Generic;

namespace optometria.Models;

public partial class TblComprobante
{
    public int IdComprobante { get; set; }

    public int IdVenta { get; set; }

    public string? NumeroComprobante { get; set; }

    public string? RutaPdf { get; set; }

    public DateTime? FechaEmision { get; set; }

    public virtual TblVenta IdVentaNavigation { get; set; } = null!;
}
