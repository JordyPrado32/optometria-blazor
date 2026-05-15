using System;
using System.Collections.Generic;

namespace optometria.Models;

public partial class TblComunicacion
{
    public int IdComunicacion { get; set; }

    public int? IdPaciente { get; set; }

    public int? IdOrdenRx { get; set; }

    public int? IdPlantillaMensaje { get; set; }

    public int? IdUsuario { get; set; }

    public string? Canal { get; set; }

    public string? Destinatario { get; set; }

    public DateTime? FechaEnvio { get; set; }

    public string? ContenidoResumen { get; set; }

    public virtual TblOrdenRx? IdOrdenRxNavigation { get; set; }

    public virtual TblPaciente? IdPacienteNavigation { get; set; }

    public virtual TblPlantillaMensaje? IdPlantillaMensajeNavigation { get; set; }

    public virtual TblUsuario? IdUsuarioNavigation { get; set; }
}
