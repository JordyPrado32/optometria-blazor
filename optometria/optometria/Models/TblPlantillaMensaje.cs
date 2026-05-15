using System;
using System.Collections.Generic;

namespace optometria.Models;

public partial class TblPlantillaMensaje
{
    public int IdPlantillaMensaje { get; set; }

    public string? Nombre { get; set; }

    public string? Canal { get; set; }

    public string? Tipo { get; set; }

    public string? Contenido { get; set; }

    public virtual ICollection<TblComunicacion> TblComunicacions { get; set; } = new List<TblComunicacion>();
}
