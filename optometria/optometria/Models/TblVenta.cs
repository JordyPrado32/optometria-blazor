using System;
using System.Collections.Generic;

namespace optometria.Models;

public partial class TblVenta
{
    public int IdVenta { get; set; }

    public int IdPaciente { get; set; }

    public int IdUsuario { get; set; }

    public DateTime? FechaVenta { get; set; }

    public decimal? Subtotal { get; set; }

    public decimal? ImpuestoTotal { get; set; }

    public decimal? DescuentoTotal { get; set; }

    public decimal? Total { get; set; }

    public decimal? ValorCobrado { get; set; }

    public decimal? SaldoPendiente { get; set; }

    public string? Estado { get; set; }

    public string? Concepto { get; set; }

    public virtual TblPaciente IdPacienteNavigation { get; set; } = null!;

    public virtual TblUsuario IdUsuarioNavigation { get; set; } = null!;

    public virtual ICollection<TblAbono> TblAbonos { get; set; } = new List<TblAbono>();

    public virtual ICollection<TblComprobante> TblComprobantes { get; set; } = new List<TblComprobante>();

    public virtual ICollection<TblDetalleVenta> TblDetalleVenta { get; set; } = new List<TblDetalleVenta>();
}
