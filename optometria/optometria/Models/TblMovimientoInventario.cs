using System;
using System.Collections.Generic;

namespace optometria.Models;

public partial class TblMovimientoInventario
{
    public int IdMovimientoInventario { get; set; }

    public int IdProducto { get; set; }

    public int IdUsuario { get; set; }

    public string? TipoMovimiento { get; set; }

    public int Cantidad { get; set; }

    public int? StockAnterior { get; set; }

    public int? StockResultante { get; set; }

    public DateTime? FechaMovimiento { get; set; }

    public string? Observaciones { get; set; }

    public virtual TblProducto IdProductoNavigation { get; set; } = null!;

    public virtual TblUsuario IdUsuarioNavigation { get; set; } = null!;
}
