using System;
using System.Collections.Generic;

namespace optometria.Models;

public partial class TblLogAuditoria
{
    public int IdLogAuditoria { get; set; }

    public int? IdUsuario { get; set; }

    public string? Accion { get; set; }

    public string? Modulo { get; set; }

    public DateTime? Fecha { get; set; }

    public string? Detalle { get; set; }

    public virtual TblUsuario? IdUsuarioNavigation { get; set; }
}
