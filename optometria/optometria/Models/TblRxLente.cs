using System;
using System.Collections.Generic;

namespace optometria.Models;

public partial class TblRxLente
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

    public virtual TblConsulta IdConsultaNavigation { get; set; } = null!;

    public virtual ICollection<TblOrdenRx> TblOrdenRxes { get; set; } = new List<TblOrdenRx>();
}
