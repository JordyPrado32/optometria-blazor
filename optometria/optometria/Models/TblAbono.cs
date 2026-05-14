using System;
using System.Collections.Generic;

namespace optometria.Models;

public partial class TblAbono
{
    public int IdAbono { get; set; }

    public int IdVenta { get; set; }

    public int IdUsuario { get; set; }

    public int IdMetodoPago { get; set; }

    public decimal Monto { get; set; }

    public DateTime? FechaAbono { get; set; }

    public string? Concepto { get; set; }

    public virtual TblMetodoPago IdMetodoPagoNavigation { get; set; } = null!;

    public virtual TblUsuario IdUsuarioNavigation { get; set; } = null!;

    public virtual TblVenta IdVentaNavigation { get; set; } = null!;
}
