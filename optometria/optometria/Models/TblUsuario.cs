using System;
using System.Collections.Generic;

namespace optometria.Models;

public partial class TblUsuario
{
    public int IdUsuario { get; set; }

    public int IdRol { get; set; }

    public string Nombres { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public string? Email { get; set; }

    public string Usuario { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string? Telefono { get; set; }

    public bool? Activo { get; set; }

    public int? IntentosFallidos { get; set; }

    public bool? Bloqueado { get; set; }

    public DateOnly? UltimoCambioPassword { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual TblRol IdRolNavigation { get; set; } = null!;

    public virtual ICollection<TblAbono> TblAbonos { get; set; } = new List<TblAbono>();

    public virtual ICollection<TblComunicacion> TblComunicacions { get; set; } = new List<TblComunicacion>();

    public virtual ICollection<TblConsulta> TblConsulta { get; set; } = new List<TblConsulta>();

    public virtual ICollection<TblEnvioLaboratorio> TblEnvioLaboratorioIdUsuarioEntregaNavigations { get; set; } = new List<TblEnvioLaboratorio>();

    public virtual ICollection<TblEnvioLaboratorio> TblEnvioLaboratorioIdUsuarioNavigations { get; set; } = new List<TblEnvioLaboratorio>();

    public virtual ICollection<TblLogAuditoria> TblLogAuditoria { get; set; } = new List<TblLogAuditoria>();

    public virtual ICollection<TblMovimientoInventario> TblMovimientoInventarios { get; set; } = new List<TblMovimientoInventario>();

    public virtual ICollection<TblPaciente> TblPacientes { get; set; } = new List<TblPaciente>();

    public virtual ICollection<TblSesion> TblSesions { get; set; } = new List<TblSesion>();

    public virtual ICollection<TblVenta> TblVenta { get; set; } = new List<TblVenta>();
}
