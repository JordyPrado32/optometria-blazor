using System;
using System.Collections.Generic;

namespace optometria.Models;

public partial class TblDetalleVenta
{
    public int IdDetalleVenta { get; set; }

    public int IdVenta { get; set; }

    public int IdProducto { get; set; }

    public int Cantidad { get; set; }

    public decimal? PrecioUnitario { get; set; }

    public decimal? Descuento { get; set; }

    public string? MotivoDescuento { get; set; }

    public string? ConceptoItem { get; set; }

    public decimal? TotalItem { get; set; }

    public virtual TblProducto IdProductoNavigation { get; set; } = null!;

    public virtual TblVenta IdVentaNavigation { get; set; } = null!;
}
