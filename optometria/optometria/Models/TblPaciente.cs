using System;
using System.Collections.Generic;

namespace optometria.Models;

public partial class TblPaciente
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

    public bool? Activo { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public int? IdUsuarioRegistro { get; set; }

    public virtual TblUsuario? IdUsuarioRegistroNavigation { get; set; }

    public virtual ICollection<TblComunicacion> TblComunicacions { get; set; } = new List<TblComunicacion>();

    public virtual ICollection<TblConsulta> TblConsulta { get; set; } = new List<TblConsulta>();

    public virtual ICollection<TblVenta> TblVenta { get; set; } = new List<TblVenta>();
}
