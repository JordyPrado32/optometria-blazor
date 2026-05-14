using System;
using System.Collections.Generic;

namespace optometria.Models;

public partial class TblProducto
{
    public int IdProducto { get; set; }

    public int? IdProveedor { get; set; }

    public int? IdCategoria { get; set; }

    public string CodigoProducto { get; set; } = null!;

    public string NombreProducto { get; set; } = null!;

    public string? Descripcion { get; set; }

    public decimal? PrecioCosto { get; set; }

    public decimal PrecioVenta { get; set; }

    public int? StockActual { get; set; }

    public int? StockMinimo { get; set; }

    public bool? Activo { get; set; }

    public virtual TblCategoriaProducto? IdCategoriaNavigation { get; set; }

    public virtual TblProveedor? IdProveedorNavigation { get; set; }

    public virtual ICollection<TblDetalleVenta> TblDetalleVenta { get; set; } = new List<TblDetalleVenta>();

    public virtual ICollection<TblMovimientoInventario> TblMovimientoInventarios { get; set; } = new List<TblMovimientoInventario>();
}
