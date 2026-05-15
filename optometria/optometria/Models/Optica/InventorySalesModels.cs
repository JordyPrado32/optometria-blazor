namespace optometria.Models.Optica;

public class Laboratorio
{
    public int IdLaboratorio { get; set; }
    public string Nombre { get; set; } = null!;
    public string? Correo { get; set; }
    public string? Whatsapp { get; set; }
    public string? PersonaContacto { get; set; }
    public string? Direccion { get; set; }
    public bool Activo { get; set; }

    public ICollection<OrdenRx> OrdenesRx { get; set; } = new List<OrdenRx>();
}

public class Proveedor
{
    public int IdProveedor { get; set; }
    public string Nombre { get; set; } = null!;
    public string? Telefono { get; set; }
    public string? Email { get; set; }
    public string? Direccion { get; set; }
    public string? Observaciones { get; set; }

    public ICollection<Producto> Productos { get; set; } = new List<Producto>();
}

public class CategoriaProducto
{
    public int IdCategoria { get; set; }
    public string Nombre { get; set; } = null!;
    public string? Descripcion { get; set; }

    public ICollection<Producto> Productos { get; set; } = new List<Producto>();
}

public class Producto
{
    public int IdProducto { get; set; }
    public int? IdProveedor { get; set; }
    public int? IdCategoria { get; set; }
    public string CodigoProducto { get; set; } = null!;
    public string NombreProducto { get; set; } = null!;
    public string? Descripcion { get; set; }
    public decimal? PrecioCosto { get; set; }
    public decimal PrecioVenta { get; set; }
    public int StockActual { get; set; }
    public int StockMinimo { get; set; }
    public bool Activo { get; set; }

    public Proveedor? Proveedor { get; set; }
    public CategoriaProducto? Categoria { get; set; }
    public ICollection<DetalleVenta> DetallesVenta { get; set; } = new List<DetalleVenta>();
    public ICollection<MovimientoInventario> MovimientosInventario { get; set; } = new List<MovimientoInventario>();
}

public class Venta
{
    public int IdVenta { get; set; }
    public int IdPaciente { get; set; }
    public int IdUsuario { get; set; }
    public DateTime FechaVenta { get; set; }
    public decimal? Subtotal { get; set; }
    public decimal? ImpuestoTotal { get; set; }
    public decimal? DescuentoTotal { get; set; }
    public decimal? Total { get; set; }
    public decimal? ValorCobrado { get; set; }
    public decimal? SaldoPendiente { get; set; }
    public string Estado { get; set; } = null!;
    public string? Concepto { get; set; }

    public Paciente Paciente { get; set; } = null!;
    public Usuario Usuario { get; set; } = null!;
    public ICollection<DetalleVenta> DetallesVenta { get; set; } = new List<DetalleVenta>();
    public ICollection<Abono> Abonos { get; set; } = new List<Abono>();
    public ICollection<Comprobante> Comprobantes { get; set; } = new List<Comprobante>();
}

public class DetalleVenta
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

    public Venta Venta { get; set; } = null!;
    public Producto Producto { get; set; } = null!;
}

public class MetodoPago
{
    public int IdMetodoPago { get; set; }
    public string Nombre { get; set; } = null!;

    public ICollection<Abono> Abonos { get; set; } = new List<Abono>();
}

public class Abono
{
    public int IdAbono { get; set; }
    public int IdVenta { get; set; }
    public int IdUsuario { get; set; }
    public int IdMetodoPago { get; set; }
    public decimal Monto { get; set; }
    public DateTime FechaAbono { get; set; }
    public string? Concepto { get; set; }

    public Venta Venta { get; set; } = null!;
    public Usuario Usuario { get; set; } = null!;
    public MetodoPago MetodoPago { get; set; } = null!;
}

public class Comprobante
{
    public int IdComprobante { get; set; }
    public int IdVenta { get; set; }
    public string? NumeroComprobante { get; set; }
    public string? RutaPdf { get; set; }
    public DateTime FechaEmision { get; set; }

    public Venta Venta { get; set; } = null!;
}

public class MovimientoInventario
{
    public int IdMovimientoInventario { get; set; }
    public int IdProducto { get; set; }
    public int IdUsuario { get; set; }
    public string? TipoMovimiento { get; set; }
    public int Cantidad { get; set; }
    public int? StockAnterior { get; set; }
    public int? StockResultante { get; set; }
    public DateTime FechaMovimiento { get; set; }
    public string? Observaciones { get; set; }

    public Producto Producto { get; set; } = null!;
    public Usuario Usuario { get; set; } = null!;
}
