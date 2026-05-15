using System;
using System.Collections.Generic;

namespace optometria.Models;

public partial class TblConsulta
{
    public int IdConsulta { get; set; }

    public int IdPaciente { get; set; }

    public int IdOptometra { get; set; }

    public DateTime? FechaConsulta { get; set; }

    public string? MotivoConsulta { get; set; }

    public string? AntecedentesPersonales { get; set; }

    public string? AntecedentesFamiliares { get; set; }

    public string? AntecedentesOculares { get; set; }

    public string? EnfermedadesPrevias { get; set; }

    public string? Alergias { get; set; }

    public string? Medicamentos { get; set; }

    public bool? UsaLentes { get; set; }

    public string? DetalleUsaLentes { get; set; }

    public string? HistoriaClinica { get; set; }

    public string? ExamenesPreliminares { get; set; }

    public string? Evaluaciones { get; set; }

    public string? ExamenesVarios { get; set; }

    public string? Notas { get; set; }

    public virtual TblUsuario IdOptometraNavigation { get; set; } = null!;

    public virtual TblPaciente IdPacienteNavigation { get; set; } = null!;

    public virtual ICollection<TblArchivoConsulta> TblArchivoConsulta { get; set; } = new List<TblArchivoConsulta>();

    public virtual ICollection<TblOrdenRx> TblOrdenRxes { get; set; } = new List<TblOrdenRx>();

    public virtual ICollection<TblRxContactologia> TblRxContactologia { get; set; } = new List<TblRxContactologia>();

    public virtual ICollection<TblRxLente> TblRxLentes { get; set; } = new List<TblRxLente>();
}
