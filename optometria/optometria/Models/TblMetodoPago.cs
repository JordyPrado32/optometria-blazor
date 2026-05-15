using System;
using System.Collections.Generic;

namespace optometria.Models;

public partial class TblMetodoPago
{
    public int IdMetodoPago { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<TblAbono> TblAbonos { get; set; } = new List<TblAbono>();
}
