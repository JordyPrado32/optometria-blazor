namespace optometria.Models.Optica;

public class Rol
{
    public int IdRol { get; set; }
    public string Nombre { get; set; } = null!;
    public string? Descripcion { get; set; }

    public ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}

public class Usuario
{
    public int IdUsuario { get; set; }
    public int IdRol { get; set; }
    public string Nombres { get; set; } = null!;
    public string Apellidos { get; set; } = null!;
    public string? Email { get; set; }
    public string UsuarioLogin { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;
    public string? Telefono { get; set; }
    public bool Activo { get; set; }
    public int IntentosFallidos { get; set; }
    public bool Bloqueado { get; set; }
    public DateOnly? UltimoCambioPassword { get; set; }
    public DateTime FechaCreacion { get; set; }

    public Rol Rol { get; set; } = null!;
    public ICollection<Paciente> PacientesRegistrados { get; set; } = new List<Paciente>();
    public ICollection<Consulta> ConsultasComoOptometra { get; set; } = new List<Consulta>();
    public ICollection<Venta> Ventas { get; set; } = new List<Venta>();
    public ICollection<Abono> Abonos { get; set; } = new List<Abono>();
    public ICollection<EnvioLaboratorio> EnviosLaboratorio { get; set; } = new List<EnvioLaboratorio>();
    public ICollection<EnvioLaboratorio> EnviosEntregados { get; set; } = new List<EnvioLaboratorio>();
    public ICollection<Comunicacion> Comunicaciones { get; set; } = new List<Comunicacion>();
    public ICollection<MovimientoInventario> MovimientosInventario { get; set; } = new List<MovimientoInventario>();
    public ICollection<Sesion> Sesiones { get; set; } = new List<Sesion>();
    public ICollection<LogAuditoria> LogsAuditoria { get; set; } = new List<LogAuditoria>();
}

public class Sesion
{
    public int IdSesion { get; set; }
    public int IdUsuario { get; set; }
    public DateTime? FechaInicio { get; set; }
    public DateTime? FechaFin { get; set; }
    public string? Ip { get; set; }

    public Usuario Usuario { get; set; } = null!;
}

public class LogAuditoria
{
    public int IdLogAuditoria { get; set; }
    public int? IdUsuario { get; set; }
    public string? Accion { get; set; }
    public string? Modulo { get; set; }
    public DateTime Fecha { get; set; }
    public string? Detalle { get; set; }

    public Usuario? Usuario { get; set; }
}
