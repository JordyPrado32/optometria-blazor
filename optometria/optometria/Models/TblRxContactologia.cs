using System;
using System.Collections.Generic;

namespace optometria.Models;

public partial class TblRxContactologia
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

    public virtual TblConsulta IdConsultaNavigation { get; set; } = null!;

    public virtual ICollection<TblOrdenRx> TblOrdenRxes { get; set; } = new List<TblOrdenRx>();
}
