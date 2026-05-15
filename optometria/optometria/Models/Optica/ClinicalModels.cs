namespace optometria.Models.Optica;

public class Paciente
{
    public int IdPaciente { get; set; }
    public string? CodigoPaciente { get; set; }
    public string Cedula { get; set; } = null!;
    public string Nombres { get; set; } = null!;
    public string Apellidos { get; set; } = null!;
    public DateOnly? FechaNacimiento { get; set; }
    public int? Edad { get; set; }
    public string? Genero { get; set; }
    public string? EstadoCivil { get; set; }
    public string? Ocupacion { get; set; }
    public string? Direccion { get; set; }
    public string? Telefono { get; set; }
    public string? Email { get; set; }
    public string? Observaciones { get; set; }
    public bool Activo { get; set; }
    public DateTime FechaRegistro { get; set; }
    public int? IdUsuarioRegistro { get; set; }

    public Usuario? UsuarioRegistro { get; set; }
    public ICollection<Consulta> Consultas { get; set; } = new List<Consulta>();
    public ICollection<Venta> Ventas { get; set; } = new List<Venta>();
    public ICollection<Comunicacion> Comunicaciones { get; set; } = new List<Comunicacion>();
}

public class Consulta
{
    public int IdConsulta { get; set; }
    public int IdPaciente { get; set; }
    public int IdOptometra { get; set; }
    public DateTime FechaConsulta { get; set; }
    public string? MotivoConsulta { get; set; }
    public string? AntecedentesPersonales { get; set; }
    public string? AntecedentesFamiliares { get; set; }
    public string? AntecedentesOculares { get; set; }
    public string? EnfermedadesPrevias { get; set; }
    public string? Alergias { get; set; }
    public string? Medicamentos { get; set; }
    public bool UsaLentes { get; set; }
    public string? DetalleUsaLentes { get; set; }
    public string? HistoriaClinica { get; set; }
    public string? ExamenesPreliminares { get; set; }
    public string? Evaluaciones { get; set; }
    public string? ExamenesVarios { get; set; }
    public string? Notas { get; set; }

    public Paciente Paciente { get; set; } = null!;
    public Usuario Optometra { get; set; } = null!;
    public ICollection<RxContactologia> RxContactologias { get; set; } = new List<RxContactologia>();
    public ICollection<RxLente> RxLentes { get; set; } = new List<RxLente>();
    public ICollection<OrdenRx> OrdenesRx { get; set; } = new List<OrdenRx>();
    public ICollection<ArchivoConsulta> ArchivosConsulta { get; set; } = new List<ArchivoConsulta>();
}

public class RxContactologia
{
    public int IdRxContactologia { get; set; }
    public int IdConsulta { get; set; }
    public decimal? OdEsfera { get; set; }
    public decimal? OdCilindro { get; set; }
    public decimal? OdEje { get; set; }
    public decimal? OdDiametro { get; set; }
    public decimal? OdCurvaBase { get; set; }
    public string? OdAv { get; set; }
    public string? OdAvccLejos { get; set; }
    public string? OdAvccCerca { get; set; }
    public decimal? OiEsfera { get; set; }
    public decimal? OiCilindro { get; set; }
    public decimal? OiEje { get; set; }
    public decimal? OiDiametro { get; set; }
    public decimal? OiCurvaBase { get; set; }
    public string? OiAv { get; set; }
    public string? OiAvccLejos { get; set; }
    public string? OiAvccCerca { get; set; }
    public string? TipoLente { get; set; }
    public string? Observaciones { get; set; }

    public Consulta Consulta { get; set; } = null!;
    public ICollection<OrdenRx> OrdenesRx { get; set; } = new List<OrdenRx>();
}

public class RxLente
{
    public int IdRxLente { get; set; }
    public int IdConsulta { get; set; }
    public decimal? OdEsfera { get; set; }
    public decimal? OdCilindro { get; set; }
    public decimal? OdEje { get; set; }
    public decimal? OdAddicion { get; set; }
    public decimal? OdPrisma { get; set; }
    public decimal? OdDnp { get; set; }
    public decimal? OdDp { get; set; }
    public decimal? OdAltura { get; set; }
    public decimal? OiEsfera { get; set; }
    public decimal? OiCilindro { get; set; }
    public decimal? OiEje { get; set; }
    public decimal? OiAddicion { get; set; }
    public decimal? OiPrisma { get; set; }
    public decimal? OiDnp { get; set; }
    public decimal? OiDp { get; set; }
    public decimal? OiAltura { get; set; }
    public string? DisenoLente { get; set; }
    public string? Material { get; set; }
    public string? Tratamiento { get; set; }
    public string? Observaciones { get; set; }

    public Consulta Consulta { get; set; } = null!;
    public ICollection<OrdenRx> OrdenesRx { get; set; } = new List<OrdenRx>();
}

public class OrdenRx
{
    public int IdOrdenRx { get; set; }
    public int IdConsulta { get; set; }
    public int IdLaboratorio { get; set; }
    public int? IdRxContactologia { get; set; }
    public int? IdRxLente { get; set; }
    public string? NumeroOrden { get; set; }
    public string? TipoRx { get; set; }
    public string Estado { get; set; } = null!;
    public DateTime FechaCreacion { get; set; }
    public string? Observaciones { get; set; }

    public Consulta Consulta { get; set; } = null!;
    public Laboratorio Laboratorio { get; set; } = null!;
    public RxContactologia? RxContactologia { get; set; }
    public RxLente? RxLente { get; set; }
    public ICollection<EnvioLaboratorio> EnviosLaboratorio { get; set; } = new List<EnvioLaboratorio>();
    public ICollection<Comunicacion> Comunicaciones { get; set; } = new List<Comunicacion>();
}

public class EnvioLaboratorio
{
    public int IdEnvioLaboratorio { get; set; }
    public int IdOrdenRx { get; set; }
    public int IdUsuario { get; set; }
    public string? Canal { get; set; }
    public string? Estado { get; set; }
    public DateTime FechaEnvio { get; set; }
    public DateTime? FechaCambioEstado { get; set; }
    public int? IdUsuarioEntrega { get; set; }

    public OrdenRx OrdenRx { get; set; } = null!;
    public Usuario Usuario { get; set; } = null!;
    public Usuario? UsuarioEntrega { get; set; }
}

public class PlantillaMensaje
{
    public int IdPlantillaMensaje { get; set; }
    public string? Nombre { get; set; }
    public string? Canal { get; set; }
    public string? Tipo { get; set; }
    public string? Contenido { get; set; }

    public ICollection<Comunicacion> Comunicaciones { get; set; } = new List<Comunicacion>();
}

public class Comunicacion
{
    public int IdComunicacion { get; set; }
    public int? IdPaciente { get; set; }
    public int? IdOrdenRx { get; set; }
    public int? IdPlantillaMensaje { get; set; }
    public int? IdUsuario { get; set; }
    public string? Canal { get; set; }
    public string? Destinatario { get; set; }
    public DateTime FechaEnvio { get; set; }
    public string? ContenidoResumen { get; set; }

    public Paciente? Paciente { get; set; }
    public OrdenRx? OrdenRx { get; set; }
    public PlantillaMensaje? PlantillaMensaje { get; set; }
    public Usuario? Usuario { get; set; }
}

public class ArchivoConsulta
{
    public int IdArchivoConsulta { get; set; }
    public int IdConsulta { get; set; }
    public string? RutaArchivo { get; set; }
    public string? NombreOriginal { get; set; }
    public string? TipoArchivo { get; set; }
    public DateTime FechaSubida { get; set; }

    public Consulta Consulta { get; set; } = null!;
}
